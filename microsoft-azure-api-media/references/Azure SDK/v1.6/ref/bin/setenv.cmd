@echo off
:: Leave things as they are if this is already set
if not "%ServiceHostingSDKInstallPath%" == "" (
  goto :eof
)

:: Check for 64-bit Framework 
if exist %SystemRoot%\Microsoft.NET\Framework64\v3.5 (
  goto :setup
)

:: Check for 32-bit Framework 
if exist %SystemRoot%\Microsoft.NET\Framework\v3.5 (
  goto :setup
)

echo Please install the .NET 3.5 Framework.
goto :eof

:: Set up paths and environment variables
:setup
set WindowsAzureEmulatorInstallPath=
for /f "usebackq tokens=2,*" %%p in (`"reg query "HKLM\SOFTWARE\Microsoft\Windows Azure Emulator" /v InstallPath /s | find "InstallPath""`) do set WindowsAzureEmulatorInstallPath=%%q

path %~dp0;%WindowsAzureEmulatorInstallPath%emulator\;%WindowsAzureEmulatorInstallPath%emulator\devstore\;%path%
call :setroot "%~dp0..\"
goto :chatter


:: Display some information
:chatter
if not '%1'=='/quiet' (
 echo Windows Azure SDK Shell
 title Windows Azure SDK Environment
 cd /D %ServiceHostingSDKInstallPath%
)
goto :eof

:: Get fully qualified path without the ..
:setroot
   set ServiceHostingSDKInstallPath=%~fp1
goto :eof