@echo off

if defined SDKNetRoot exit /b 0

echo Initializing environment

if exist "%USERPROFILE%\SetNugetFeed.cmd" call "%USERPROFILE%\SetNugetFeed.cmd"

set "SDKNetRoot=%~dp0"
::get rid of the \tools\
set "SDKNetRoot=%SDKNetRoot:~0,-7%" 

if defined ProgramFiles(x86) (
    set "ADXSDKProgramFiles=%ProgramFiles(x86)%"
) else (
    set "ADXSDKProgramFiles=%ProgramFiles%"
)

if exist "%ADXSDKProgramFiles%\Microsoft Visual Studio 12.0" (
    set ADXSDKVSVersion=12.0
) else (
    set ADXSDKVSVersion=11.0
)

call "%ADXSDKProgramFiles%\Microsoft Visual Studio %ADXSDKVSVersion%\VC\vcvarsall.bat" x86
