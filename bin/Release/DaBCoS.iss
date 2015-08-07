; Script generated by the Inno Script Studio Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "DaBCoS"
#define MyAppVersion "0.9"
#define MyAppPublisher "LDC"
#define MyAppURL "http://ldc.lu.se"
#define MyAppExeName "DaBCoS.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{2F120A1F-6478-456C-8AB6-9067EBEA302F}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputBaseFilename=setup
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "DaBCoS.Engine.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "DaBCoS.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "DaBCoS.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "DaBCoS.exe.formdata.xml"; DestDir: "{app}"; Flags: ignoreversion; Permissions: everyone-full
Source: "dabcos-cmd.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "DifferenceEngine.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "General.VersionDetect.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "SqlLogins.xml"; DestDir: "{app}"; Flags: ignoreversion; Permissions: everyone-full
Source: "SqlServer.7.xml"; DestDir: "{app}"; Flags: ignoreversion; Permissions: everyone-full
Source: "SqlServer.2000.xml"; DestDir: "{app}"; Flags: ignoreversion; Permissions: everyone-full
Source: "SqlServer.VersionsInfo.xml"; DestDir: "{app}"; Flags: ignoreversion; Permissions: everyone-full

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
