using System.Diagnostics;
using SharpDX.XInput;

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
        int battleCamOffset;
        int worldCamOffset;
        int camMaxOffset;
        int camMaxAbsOffset;
        int camTiltOffset;
        int camTiltSpeedOffset;
        Dictionary<nint, float> defaultVals = new Dictionary<nint, float>();
        int prevMouseY;
        float curTilt;

        Controller controller;
        Gamepad gamepad;

        //get addresses
        void MainWindow_Load(object sender, EventArgs e)
        {
            controller = new Controller(UserIndex.One);

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

            var battleCamOffsetStart = mem.FindPattern("49 8D 80 ? ? ? ? F6 C1 01", bytes: camFuncBytes);
            battleCamOffset = BitConverter.ToInt32(camFuncBytes, (int)battleCamOffsetStart + 3);

            var worldCamOffsetStart = mem.FindPattern("F6 C1 01 75 07 49 8D 80", bytes: camFuncBytes);
            worldCamOffset = BitConverter.ToInt32(camFuncBytes, (int)worldCamOffsetStart + 8);

            var maxDistOffAddr = mem.FindPattern("C3 F3 0F 10 48", bytes: camFuncBytes);
            camMaxOffset = camFuncBytes[maxDistOffAddr + 5];

            var camMaxAbs = mem.FindPattern("F3 0F 10 80 ? ? ? ? C3", bytes: camFuncBytes);
            camMaxAbsOffset = camFuncBytes[camMaxAbs + 4];

            var camTilt = mem.FindPattern("C3 F3 0F 10 80 ? ? ? ? F3 0F 10 88 ? ? ? ? 0F 14 C8 66 48 0F 7E C8 C3");
            camTiltOffset = mem.ReadProcessMemory<int>(camTilt + 5);

            /*
            var camTiltSpeed = mem.FindPattern("F3 0F 10 96 F0", bytes: camFuncBytes);
            //var camTiltSpeed = mem.FindPattern("E8 76 01 02 ?", bytes: camFuncBytes);
            //var camTiltSpeed = mem.FindPattern("F3 0F 59 4B 5C", bytes: camFuncBytes);
            camTiltSpeedOffset = camFuncBytes[camTiltSpeed];
            //camTiltSpeedOffset = (int)mem.ReadProcessMemory<float>(camTilt);
            */

            /*
            TO ADD
            Tactical Adjustment Boxes
            Combat Adjustments
            Disable Combat Zoom
            Version Checker *maybe uneeded
            Saving of Settings
            */

            var curMaxZoom = AddDefaultVal(obj + worldCamOffset + camMaxOffset); // default val is 12, addr offset is 0x7b4 in release patch
            if (curMaxZoom != 12)
            {
                var res = MessageBox.Show("Max Zoom not found, expected 12.0, found : " + curMaxZoom, "Bad Game State", MessageBoxButtons.AbortRetryIgnore);
                if (res == DialogResult.Abort)
                    Environment.Exit(0);
            }
            maxZoomVal.Value = (decimal)24f;
            minZoomVal.Value = (decimal)0.5f;
            panSpeedVal.Value = (decimal)30f;
            fovVal.Value = (decimal)55f; //do fov together
            scrollSpeedVal.Value = (decimal)(float)0.8f;
            cameraDistanceVal.Value = (decimal)50f;

            AddDefaultVal(obj + battleCamOffset + camMaxOffset);
            AddDefaultVal(obj + battleCamOffset + camMaxOffset + 4);
            AddDefaultVal(obj + worldCamOffset + camTiltSpeedOffset + 240);
            curTilt = AddDefaultVal(obj + worldCamOffset + camTiltOffset);
            AddDefaultVal(obj + worldCamOffset + camTiltOffset + 4);
            AddDefaultVal(obj + worldCamOffset + camTiltOffset + 8);
            AddDefaultVal(obj + worldCamOffset + camTiltOffset + 12);
            AddDefaultVal(obj + battleCamOffset + camTiltOffset);
            AddDefaultVal(obj + battleCamOffset + camTiltOffset + 4);
            AddDefaultVal(obj + battleCamOffset + camTiltOffset + 8);
            AddDefaultVal(obj + battleCamOffset + camTiltOffset + 228);
            AddDefaultVal(obj + battleCamOffset + camMaxOffset);
            AddDefaultVal(obj + battleCamOffset + camMaxOffset + 60);
            AddDefaultVal(obj + battleCamOffset + camMaxOffset + 92);
            AddDefaultVal(obj + battleCamOffset + camMaxOffset + 96);
            AddDefaultVal(obj + battleCamOffset + camMaxOffset + 132);
            AddDefaultVal(obj + battleCamOffset + camMaxOffset + 136);
            AddDefaultVal(obj + battleCamOffset + camMaxOffset + 160);
            AddDefaultVal(obj + battleCamOffset + camMaxOffset + 164);
            AddDefaultVal(obj + battleCamOffset + camMaxOffset + 172);
            AddDefaultVal(obj + battleCamOffset + camMaxOffset + 200);

            mem.WriteProcessMemory(obj + worldCamOffset + camMaxAbsOffset, 1000.0f);
            mem.WriteProcessMemory(obj + worldCamOffset + camTiltOffset, curTilt);
            mem.WriteProcessMemory(obj + worldCamOffset + camTiltOffset + 4, curTilt);
            ChangePitchOnMouseMove();
            /*Debug.WriteLine($"Camera Tilt Speed: {camTiltSpeedOffset}");
            //mem.WriteProcessMemory(obj + worldCamOffset + camTiltSpeedOffset + 240, (float)panSpeedVal.Value);
            Debug.WriteLine($"15: {AddDefaultVal(obj + worldCamOffset + camMaxOffset + 60)}"); //cam height
            Debug.WriteLine($"1: {AddDefaultVal(obj + worldCamOffset + camMaxOffset + 92)}"); //fov close
            Debug.WriteLine($"1: {AddDefaultVal(obj + worldCamOffset + camMaxOffset + 96)}"); //fove far
            Debug.WriteLine($"8: {AddDefaultVal(obj + worldCamOffset + camMaxOffset + 132)}"); //zoom speed or something
            Debug.WriteLine($"9: {AddDefaultVal(obj + worldCamOffset + camMaxOffset + 136)}"); //scroll speed
            Debug.WriteLine($"15: {AddDefaultVal(obj + worldCamOffset + camMaxOffset + 160)}"); //tact min
            Debug.WriteLine($"16: {AddDefaultVal(obj + worldCamOffset + camMaxOffset + 164)}"); //tact max
            Debug.WriteLine($"18: {AddDefaultVal(obj + worldCamOffset + camMaxOffset + 172)}"); //cam distance
            Debug.WriteLine($"18: {AddDefaultVal(obj + worldCamOffset + camMaxOffset + 200)}"); //pan speed
            */

        }
        bool running = true;
        float AddDefaultVal(nint addr)
        {
            defaultVals[addr] = mem.ReadProcessMemory<float>(addr);
            return defaultVals[addr];
        }
        void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
            foreach (var val in defaultVals) mem.WriteProcessMemory(val.Key, val.Value);
        }

        //writes to memory 
        void maxZoomVal_ValueChanged(object sender, EventArgs e)
        {
            mem.WriteProcessMemory(obj + worldCamOffset + camMaxOffset, (float)maxZoomVal.Value);
            mem.WriteProcessMemory(obj + battleCamOffset + camMaxOffset, (float)maxZoomVal.Value);
        }
        void minZoomVal_ValueChanged(object sender, EventArgs e)
        {
            mem.WriteProcessMemory(obj + worldCamOffset + camMaxOffset + 4, (float)minZoomVal.Value);
            mem.WriteProcessMemory(obj + battleCamOffset + camMaxOffset + 4, (float)minZoomVal.Value);
        }
        void panSpeedVal_ValueChanged(object sender, EventArgs e)
        {
            mem.WriteProcessMemory(obj + worldCamOffset + camMaxOffset + 200, (float)panSpeedVal.Value);
        }
        void fovVal_ValueChanged(object sender, EventArgs e)
        {
            mem.WriteProcessMemory(obj + worldCamOffset + camMaxOffset + 92, (float)fovVal.Value);
            mem.WriteProcessMemory(obj + worldCamOffset + camMaxOffset + 96, (float)fovVal.Value);
        }

        void scrollSpeedVal_ValueChanged(object sender, EventArgs e)
        {
            mem.WriteProcessMemory(obj + worldCamOffset + camMaxOffset + 136, (float)scrollSpeedVal.Value);
        }

        void cameraDistanceVal_ValueChanged(object sender, EventArgs e)
        {
            mem.WriteProcessMemory(obj + worldCamOffset + camMaxOffset + 172, (float)cameraDistanceVal.Value);
        }

        //camera tilt from mouse
        async Task ChangePitchOnMouseMove()
        {
            while (running)
            {
                var diff = 0;
                var Mouse = false;
                if (Hotkeys.SinglePress(Keys.MButton)) prevMouseY = Cursor.Position.Y;

                if (Hotkeys.IsPressed(Keys.MButton) || Hotkeys.IsPressed(Keys.R))
                {
                    diff = Cursor.Position.Y - prevMouseY;
                    Mouse = true;
                }

                if (controller.IsConnected == true && controller.GetState().Gamepad.Buttons == GamepadButtonFlags.RightThumb)
                {
                    gamepad = controller.GetState().Gamepad;
                    if (gamepad.RightThumbY > 4500 && gamepad.RightThumbY < 24000)
                    {
                        diff = 15;
                    }
                    else if (gamepad.RightThumbY < -4500 && gamepad.RightThumbY > -24000)
                    {
                        diff = -15;
                    }
                }

                if (diff != 0)
                {
                    curTilt += diff * 0.05f;
                    mem.WriteProcessMemory(obj + worldCamOffset + camTiltOffset, curTilt);
                    mem.WriteProcessMemory(obj + worldCamOffset + camTiltOffset + 4, curTilt);
                    mem.WriteProcessMemory(obj + worldCamOffset + camTiltOffset + 8, curTilt);
                    mem.WriteProcessMemory(obj + worldCamOffset + camTiltOffset + 12, curTilt);
                    mem.WriteProcessMemory(obj + battleCamOffset + camTiltOffset, curTilt);
                    mem.WriteProcessMemory(obj + battleCamOffset + camTiltOffset + 4, curTilt);
                    mem.WriteProcessMemory(obj + battleCamOffset + camTiltOffset + 8, curTilt);
                    mem.WriteProcessMemory(obj + battleCamOffset + camTiltOffset + 12, curTilt);
                    if (Mouse == false)
                    {
                        prevMouseY = (int)curTilt;
                    }
                    else
                    {
                        prevMouseY = Cursor.Position.Y;
                        Mouse = false;
                    }
                }
                await Task.Delay(16);
            }
        }
    }
}
