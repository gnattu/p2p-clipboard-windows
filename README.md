# p2p-clipboard-windows

p2p-clipboard-windows is a Windows tray application wrapper for the command-line based [p2p-clipboard](https://github.com/gnattu/p2p-clipboard), allowing for easy configuration and usage of the clipboard synchronization tool.

This application is compatible with Windows 10+, and requires the [.NET 6.0 framework](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) to be installed.

- Alternatively, a self-contained build that bundles the .NET 6.0 runtime with it will also be provided. This one will be significantly larger and is not recommended unless you really cannot install the .NET framework separately.

## Features

This tray application allows you to:

- Start p2p-clipboard in the background
- Modify all command line options via GUI
- Show running log using powershell
- Set the app to autostart at user login

## Build instructions

1. Ensure you have the .NET 6.0 SDK installed.
2. Clone or download this repository:
```
git clone https://github.com/gnattu/p2p-clipboard-windows.git
```
3. Place the pre-built `p2p-clipboard.exe` binary into the `p2pClipboard-Windows\Core` folder.
4. Open `p2pClipboard-Windows.sln` in Visual Studio then build the solution.
	- Alternatively, you can use `dotnet publish` in command line. 

## Caveats

- The autostart entry records the current path of the exe when it is running. If you move the exe, you need to re-enable the autostart to update the recorded path.

## Cleanup

If you want to remove this from your Windows system, besides deleting files, you may also want to remove the following:

- The autostart entry in the registry, stored in `HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run` and named `p2pClipboardTray`.
- Most configurations are stored in the registry in `HKEY_CURRENT_USER\Software\Gnattu\p2pClipboard`.
- The saved pre-shared key is stored in the Credential Vault. You can find it using the Credential Manager in Control Panel, then you will find it under Web Credentials named `net.gnattu.p2pClipboard`.


## License

This project is licensed under the [MIT License](LICENSE).
