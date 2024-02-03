using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace p2pClipboard_Windows
{
    /// <summary>
    /// Tray application context.
    /// </summary>
    public class TrayApplicationContext : ApplicationContext
    {
        private const string TrayIconResourceName = "p2pClipboard_Windows.icon.ico";
        public readonly string _autostartKey = "p2pClipboardTray";
        public bool useConnect = false;
        public bool setListen = false;
        public bool setPrivateKey = false;
        public bool disableMdns = false;
        public string connectIp = "";
        public string connectPort = "";
        public string connectPeerId = "";
        public string listenIp = "";
        public string listenPort = "";
        public string privateKeyPath = "";
        private bool _disposed = false;
        private readonly string _programPath;
        private readonly string _executablePath;
        private readonly string _logPath;
        private readonly StreamWriter _logger;
        private Process? _p2pClipboardCoreProcess;
        // We have to use our own image because the default one looks terrible and has wrong layout
        private readonly Bitmap _imageCheck;
        private readonly Bitmap _imageEmpty;
        private SettingsWindow? _settingsWindow;
        private NotifyIcon? _trayIcon;
        private ToolStripMenuItem? _menuItemAutostart;
        private ToolStripMenuItem? _menuItemStart;
        private ToolStripMenuItem? _menuItemStop;
        private ToolStripMenuItem? _menuItemOpenSettings;
        private ToolStripMenuItem? _menuItemShowLogs;
        private ToolStripMenuItem? _menuItemExit;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrayApplicationContext"/> class.
        /// </summary>
        public TrayApplicationContext()
        {
            using var checkMarkStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("p2pClipboard_Windows.Resources.checkmark.png");
            _imageCheck = (Bitmap)Image.FromStream(checkMarkStream!);
            using var checkMarkPlaceHolderStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("p2pClipboard_Windows.Resources.checkmark-placeholder.png");
            _imageEmpty = (Bitmap)Image.FromStream(checkMarkPlaceHolderStream!);
            _programPath = Application.StartupPath;
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _logPath = Path.Combine(appdata, @".\p2pClipboard-core.log");
            _executablePath = Path.Combine(_programPath, @".\Core\p2p-clipboard.exe");
            _logger = new StreamWriter(_logPath)
            {
                AutoFlush = true
            };
        }

        public bool AutoStart
        {
            get
            {
                using RegistryKey? key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                return key?.GetValue(_autostartKey) != null;
            }

            set
            {
                using RegistryKey? key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (value && key?.GetValue(_autostartKey) == null)
                {
                    key?.SetValue(_autostartKey, Path.ChangeExtension(Application.ExecutablePath, "exe"));
                }
                else if (!value && key?.GetValue(_autostartKey) != null)
                {
                    key?.DeleteValue(_autostartKey);
                }
            }
        }

        /// <summary>
        ///     Setups and Starts the application.
        /// </summary>
        /// <returns>boolean value if the application should start rendering its UI.</returns>
        public bool InitApplication()
        {
            try
            {
                LoadP2pClipboardConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\r\nThe application will now close.");
                return false;
            }
            _settingsWindow = new SettingsWindow(this);
            CreateTrayIcon();

            // check if p2p-clipboard is already running, if not, start it
            if (Process.GetProcessesByName("p2p-clipboard").Length == 0)
            {
                //Start(null, null);
            }

            return true;
        }

        private void CreateTrayIcon()
        {
            _menuItemAutostart = new ToolStripMenuItem("Autostart", null, AutoStartToggle);
            _menuItemStart = new ToolStripMenuItem("Start p2pClipboard", null, Start);
            _menuItemStop = new ToolStripMenuItem("Stop p2pClipboard", null, Stop);
            _menuItemOpenSettings = new ToolStripMenuItem("Open Settings", null, OpenSettings);
            _menuItemShowLogs = new ToolStripMenuItem("Show Logs", null, ShowLogs);
            _menuItemExit = new ToolStripMenuItem("Exit", null, Exit);

            _menuItemAutostart.CheckedChanged += LaunchAtLogin_CheckedChanged;

            ContextMenuStrip contextMenu = new()
            {
                Renderer = fDropDownToolbarRenderer
            };
            contextMenu.Items.Add(_menuItemAutostart);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(_menuItemStart);
            contextMenu.Items.Add(_menuItemStop);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(_menuItemOpenSettings);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(_menuItemShowLogs);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(_menuItemExit);

            contextMenu.Opening += new CancelEventHandler(ContextMenuOnPopup);
            using var iconStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(TrayIconResourceName);
            _trayIcon = new NotifyIcon() { Icon = new Icon(iconStream!), ContextMenuStrip = contextMenu, Visible = true, Text = "p2pClipboard" };
            _trayIcon.DoubleClick += OpenSettings;
        }

        private void LoadP2pClipboardConfig()
        {
            using RegistryKey? registryKey = Registry.CurrentUser.OpenSubKey("Software\\Gnattu\\p2pClipboard");
            useConnect = (int?)registryKey?.GetValue("UseConnect") > 0;
            setListen = (int?)registryKey?.GetValue("SetListen") > 0;
            setPrivateKey = (int?)registryKey?.GetValue("SetPrivateKey") > 0;
            disableMdns = (int?)registryKey?.GetValue("DisableMdns") > 0;
            connectIp = registryKey?.GetValue("ConnectIP")?.ToString() ?? "";
            connectPort = registryKey?.GetValue("ConnectPort")?.ToString() ?? "";
            connectPeerId = registryKey?.GetValue("ConnectPeerID")?.ToString() ?? "";
            listenIp = registryKey?.GetValue("ListenIP")?.ToString() ?? "";
            listenPort = registryKey?.GetValue("ListenPort")?.ToString() ?? "";
            privateKeyPath = registryKey?.GetValue("PrivateKeyPath")?.ToString() ?? "";
        }

        private void SetP2pClipboardConfig() 
        {
            using RegistryKey? registryKey = Registry.CurrentUser.CreateSubKey("Software\\Gnattu\\p2pClipboard");
            registryKey?.SetValue("UseConnect", Convert.ToByte(useConnect), RegistryValueKind.DWord);
            registryKey?.SetValue("SetListen", Convert.ToByte(setListen), RegistryValueKind.DWord);
            registryKey?.SetValue("SetPrivateKey", Convert.ToByte(setPrivateKey), RegistryValueKind.DWord);
            registryKey?.SetValue("DisableMdns", Convert.ToByte(disableMdns), RegistryValueKind.DWord);
            registryKey?.SetValue("ConnectIP", connectIp);
            registryKey?.SetValue("ConnectPort", connectPort);
            registryKey?.SetValue("ConnectPeerID", connectPeerId);
            registryKey?.SetValue("ListenIP", listenIp);
            registryKey?.SetValue("ListenPort", listenPort);
            registryKey?.SetValue("PrivateKeyPath", privateKeyPath);
        }


        private void AutoStartToggle(object? sender, EventArgs? e)
        {
            AutoStart = !AutoStart;
        }

        private void OpenSettings(object? sender, EventArgs? e)
        {
            if (_settingsWindow is null || _settingsWindow.IsDisposed) _settingsWindow = new SettingsWindow(this);
            _settingsWindow.Show();
        }

        private void ShowLogs(object? sender, EventArgs? e)
        {
            var logViewer = $"Get-Content {_logPath} -Wait -Tail 30";
            Process.Start("Powershell", logViewer);
        }

        private void ContextMenuOnPopup(object? sender, EventArgs? e)
        {
            bool exeRunning = Process.GetProcessesByName("p2p-clipboard").Length > 0;

            bool running = exeRunning;
            bool stopped = !exeRunning;
            _menuItemStart!.Enabled = stopped;
            _menuItemStop!.Enabled = running;
            _menuItemAutostart!.Checked = AutoStart;
        }

        private void Start(object? sender, EventArgs? e)
        {

            _p2pClipboardCoreProcess = new();
            try
            {
                var args = new List<String>();
                if (useConnect) {
                    args.Add($"-c {connectIp}:{connectPort} {connectPeerId}");
                }
                if (setListen) {
                    args.Add($"-l {listenIp}:{listenPort}");
                }
                if (setPrivateKey) { 
                    args.Add($"-k {privateKeyPath}");
                }
                if (disableMdns) {
                    args.Add("--no-mdns");
                }
                _p2pClipboardCoreProcess.StartInfo.FileName = _executablePath;
                _p2pClipboardCoreProcess.StartInfo.CreateNoWindow = true;
                _p2pClipboardCoreProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                _p2pClipboardCoreProcess.StartInfo.RedirectStandardOutput = true;
                _p2pClipboardCoreProcess.StartInfo.RedirectStandardError = true;
                _p2pClipboardCoreProcess.StartInfo.UseShellExecute = false;
                _p2pClipboardCoreProcess.StartInfo.Arguments = string.Join(" ", args);
                _p2pClipboardCoreProcess.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        _logger.WriteLine(e.Data);
                    }
                });
                _p2pClipboardCoreProcess.ErrorDataReceived += new DataReceivedEventHandler((sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        _logger.WriteLine(e.Data);
                    }
                });
                _p2pClipboardCoreProcess.Start();
                var startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                _logger.WriteLine($"p2pClipboard Core Started at {startTime}");
                _p2pClipboardCoreProcess.BeginOutputReadLine();
                _p2pClipboardCoreProcess.BeginErrorReadLine();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Could not start p2pClipboard Core. " +
                                $"\r\n Because: '{exception.Message}'.");
                return;
            }

            Task.Delay(TimeSpan.FromSeconds(15)).ContinueWith(
                (t) =>
                {
                    using var running = Process.GetProcessesByName("p2p-clipboard").FirstOrDefault();
                    if (running is null || running.HasExited)
                    {
                        MessageBox.Show($"Could not start p2pClipboard Core process after the specified wait period.");
                    }
                },
                TaskScheduler.Default);
        }

        private void Stop(object? sender, EventArgs? e)
        {
            Process? process = _p2pClipboardCoreProcess ?? Process.GetProcessesByName("p2p-clipboard").FirstOrDefault();
            if (process == null)
            {
                return;
            }

            if (!process.CloseMainWindow())
            {
                process.Kill();
                process.WaitForExit();
                process.Dispose();
            }
        }

        public void SaveConfigAndRestart()
        {
            SetP2pClipboardConfig();
            Stop(null, null);
            Thread.Sleep(1000);
            Start(null, null);
        }

        private void Exit(object? sender, EventArgs? e)
        {
            Stop(null, null);
            if (_trayIcon is not null) _trayIcon.Visible = false;
            Application.Exit();
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _trayIcon?.Dispose();
                    _menuItemAutostart?.Dispose();
                    _menuItemStart?.Dispose();
                    _menuItemStop?.Dispose();
                    _menuItemOpenSettings?.Dispose();
                    _menuItemShowLogs?.Dispose();
                    _menuItemExit?.Dispose();
                }
            }

            _disposed = true;

            base.Dispose(disposing);
        }

        // We want to remove the unnecessary gray in the menu because it looks like shit on HiDPi Screen.
        internal class DropDownToolbarRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderImageMargin(ToolStripRenderEventArgs e){}
        }

        private static readonly DropDownToolbarRenderer fDropDownToolbarRenderer = new();

        private void SetMenuItemChecked(ToolStripMenuItem item, bool check)
        {
            if (check)
                item.Image = _imageCheck;
            else
                item.Image = _imageEmpty;
        }

        private void LaunchAtLogin_CheckedChanged(object? sender, EventArgs e)
        {
            SetMenuItemChecked((ToolStripMenuItem)sender!, AutoStart);
        }
    }
}
