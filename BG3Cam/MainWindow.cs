using System.Diagnostics;

namespace BG3Cam
{
    public partial class MainWindow : Form
    {
        Memory mem;
        public MainWindow()
        {
            InitializeComponent();
        }
        nint obj;
        int camOffset;
        int camMaxOffset;
        int camMaxAbsOffset;
        int camTiltOffset;
        float defaultZoomMax = 12f;
        float defaultZoomMin = 3.5f;
        float defaultMaxAbs = 1f;
        float defaultPitchMaxZoom = 1f;
        float defaultPitchMinZoom = 1f;
        int prevMouseY;
        float curTilt;
        void MainWindow_Load(object sender, EventArgs e)
        {
            var bg3Proc = Process.GetProcesses().FirstOrDefault(p => p.ProcessName == "bg3" || p.ProcessName == "bg3_dx11");
            if (bg3Proc == null)
            {
                MessageBox.Show("Baldur's Gate 3 not found", "BG3 not found");
                Environment.Exit(0);
            }
            mem = new Memory(bg3Proc);
            var camFuncAddr = mem.FindPattern("4C 8B 05 ? ? ? ? 41 80 B8");
            var objBase = mem.ReadProcessMemory<int>(camFuncAddr + 3);
            obj = mem.ReadProcessMemory<nint>(camFuncAddr + 3 + 4 + objBase);

            var camFuncBytes = mem.ReadProcessMemory(camFuncAddr, 0x100);

            var camOffsetStart = mem.FindPattern("F6 C1 01 75 07 49 8D 80", bytes: camFuncBytes);
            camOffset = BitConverter.ToInt32(camFuncBytes, (int)camOffsetStart + 8);

            var maxDistOffAddr = mem.FindPattern("C3 F3 0F 10 48", bytes: camFuncBytes);
            camMaxOffset = camFuncBytes[maxDistOffAddr + 5];

            var camMaxAbs = mem.FindPattern("F3 0F 10 80 ? ? ? ? C3", bytes: camFuncBytes);
            camMaxAbsOffset = camFuncBytes[camMaxAbs + 4];

            var camTilt = mem.FindPattern("C3 F3 0F 10 80 ? ? ? ? F3 0F 10 88 ? ? ? ? 0F 14 C8 66 48 0F 7E C8 C3");
            camTiltOffset = mem.ReadProcessMemory<int>(camTilt + 5);

            var curMaxZoom = mem.ReadProcessMemory<float>(obj + camOffset + camMaxOffset); // default val is 12, addr offset is 0x7b4 in release patch
            if (curMaxZoom != defaultZoomMax)
            {
                MessageBox.Show("Max Zoom not found", "Bad Game State");
                Environment.Exit(0);
            }
            maxZoomVal.Value = (decimal)100f;
            minZoomVal.Value = (decimal)0.5f;
            defaultZoomMin = mem.ReadProcessMemory<float>(obj + camOffset + camMaxOffset + 4);
            defaultMaxAbs = mem.ReadProcessMemory<float>(obj + camOffset + camMaxAbsOffset);
            curTilt = defaultPitchMaxZoom = mem.ReadProcessMemory<float>(obj + camOffset + camTiltOffset);
            defaultPitchMinZoom = mem.ReadProcessMemory<float>(obj + camOffset + camTiltOffset + 4);
            mem.WriteProcessMemory(obj + camOffset + camMaxAbsOffset, 10000.0f);
            mem.WriteProcessMemory(obj + camOffset + camTiltOffset, curTilt);
            mem.WriteProcessMemory(obj + camOffset + camTiltOffset + 4, curTilt);
            ChangePitchOnMouseMove();
        }
        bool running = true;
        void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
            mem.WriteProcessMemory(obj + camOffset + camMaxOffset, defaultZoomMax);
            mem.WriteProcessMemory(obj + camOffset + camMaxOffset + 4, defaultZoomMin);
            mem.WriteProcessMemory(obj + camOffset + camMaxAbsOffset, defaultMaxAbs);
            mem.WriteProcessMemory(obj + camOffset + camTiltOffset, defaultPitchMaxZoom);
            mem.WriteProcessMemory(obj + camOffset + camTiltOffset + 4, defaultPitchMinZoom);
        }
        void maxZoomVal_ValueChanged(object sender, EventArgs e)
        {
            mem.WriteProcessMemory(obj + camOffset + camMaxOffset, (float)maxZoomVal.Value);
        }
        void minZoomVal_ValueChanged(object sender, EventArgs e)
        {
            mem.WriteProcessMemory(obj + camOffset + camMaxOffset + 4, (float)minZoomVal.Value);
        }
        async Task ChangePitchOnMouseMove()
        {
            while (running)
            {
                if (Hotkeys.SinglePress(Keys.MButton)) prevMouseY = Cursor.Position.Y;
                if (Hotkeys.IsPressed(Keys.MButton))
                {
                    var diff = Cursor.Position.Y - prevMouseY;
                    if (diff != 0)
                    {
                        curTilt += diff * 0.05f;
                        mem.WriteProcessMemory(obj + camOffset + camTiltOffset, curTilt);
                        mem.WriteProcessMemory(obj + camOffset + camTiltOffset + 4, curTilt);
                        prevMouseY = Cursor.Position.Y;
                    }
                }
                await Task.Delay(16);
            }
        }
    }
}