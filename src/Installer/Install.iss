[Setup]
AppName=Memcached Manager
AppVerName=MemcachedManager
AppCopyright=Copyright (C) 2022 Robert Gelb
AppPublisher=Robert Gelb
DefaultDirName={userpf}\MemcachedManager
DisableDirPage=yes
DisableProgramGroupPage=yes
DisableReadyPage=yes
UninstallDisplayIcon={app}\MemcachedManager.exe
OutputBaseFilename=MemcachedManagerSetup
AppID=MemcachedManager.1
VersionInfoVersion=1.0.0.0
PrivilegesRequired=lowest

[Files]
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\MemcachedManager.UI.exe"; DestDir: "{app}"


Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\appsettings.json"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Dapper.Contrib.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Dapper.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\EnyimMemcachedCore.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\e_sqlite3.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Humanizer.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\MemcachedManager.DB.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\MemcachedManager.DB.pdb"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\MemcachedManager.Entities.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\MemcachedManager.Entities.pdb"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\MemcachedManager.UI.deps.json"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\MemcachedManager.UI.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\MemcachedManager.UI.pdb"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\MemcachedManager.UI.runtimeconfig.json"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Microsoft.AspNetCore.Http.Abstractions.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Microsoft.AspNetCore.Http.Features.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Microsoft.Data.Sqlite.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Microsoft.Extensions.Caching.Abstractions.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Microsoft.Extensions.Configuration.Abstractions.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Microsoft.Extensions.Configuration.Binder.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Microsoft.Extensions.Configuration.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Microsoft.Extensions.Configuration.EnvironmentVariables.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Microsoft.Extensions.Configuration.FileExtensions.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Microsoft.Extensions.Configuration.Json.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Microsoft.Extensions.DependencyInjection.Abstractions.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Microsoft.Extensions.FileProviders.Abstractions.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Microsoft.Extensions.FileProviders.Physical.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Microsoft.Extensions.FileSystemGlobbing.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Microsoft.Extensions.Logging.Abstractions.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Microsoft.Extensions.Options.ConfigurationExtensions.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Microsoft.Extensions.Options.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Microsoft.Extensions.Primitives.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Newtonsoft.Json.Bson.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Newtonsoft.Json.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\ScintillaNET.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\SQLitePCLRaw.batteries_v2.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\SQLitePCLRaw.core.dll"; DestDir: "{app}"
Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\SQLitePCLRaw.provider.e_sqlite3.dll"; DestDir: "{app}"

Source: "..\MemcachedManagerUI\bin\Release\net6.0-windows\publish\win-x64\Database\Readme.txt"; DestDir: "{app}\Database"


[Icons]
Name: "{group}\Memcached Manager"; Filename: "{app}\MemcachedManager.UI.exe"; 

[Run]
Filename: "{app}\MemcachedManager.UI.exe"; Description: "Launch Memcached Manager"; Flags: postinstall nowait skipifsilent

; rename the uninstaller to avoid tripping windows security
; unfortunately doesn't work because in the Apps & Features, the uninstaller is still being kicked off with privilige elevation
; Filename: {cmd}; Parameters: "/C Move ""{app}\unins000.exe"" ""{app}\RemoveMemcachedManager.exe"""; StatusMsg: Installing Memcached Manager...; Flags: RunHidden WaitUntilTerminated
; Filename: {cmd}; Parameters: "/C Move ""{app}\unins000.dat"" ""{app}\RemoveMemcachedManager.dat"""; StatusMsg: Installing Memcached Manager...; Flags: RunHidden WaitUntilTerminated
; Filename: REG.exe; Parameters: "ADD ""HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\MemcachedManager.1_is1"" /V ""UninstallString""      /T ""REG_SZ"" /D ""\""{app}\RemoveMemcachedManager.exe\"""" /F"; StatusMsg: Installing Memcached Manager...; Flags: RunHidden WaitUntilTerminated
; Filename: REG.exe; Parameters: "ADD ""HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\MemcachedManager.1_is1"" /V ""QuietUninstallString"" /T ""REG_SZ"" /D ""\""{app}\RemoveMemcachedManager.exe\"" /SILENT"" /F"; StatusMsg: Installing Memcached Manager...; Flags: RunHidden WaitUntilTerminated