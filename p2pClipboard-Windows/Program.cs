namespace p2pClipboard_Windows
{
    internal static class Program
    {
        #pragma warning disable IDE0052
        private static Mutex? _mutex;
        #pragma warning restore IDE0052
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (IsAlreadyRunning())
            {
                MessageBox.Show("The p2pClipboard Tray is already running.", "Info", new MessageBoxButtons { }, MessageBoxIcon.Information);
                Environment.Exit(1);
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var trayApplicationContext = new TrayApplicationContext();
            if (trayApplicationContext.InitApplication())
            {
                Application.Run(trayApplicationContext);
            }
        }

        private static bool IsAlreadyRunning()
        {
            _mutex = new Mutex(true, "p2pClipboard-Windows", out bool shouldStart);

            return !shouldStart;
        }
    }
}