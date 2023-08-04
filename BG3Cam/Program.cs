namespace BG3Cam
{
    static class Program
    {
        [STAThread] static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow());
        }
    }
}