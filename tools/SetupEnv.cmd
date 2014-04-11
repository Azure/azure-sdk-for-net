@echo off

if not defined PRIVATE_FEED_URL (
    echo Error: you will beed to set up Private Feed URL 
	exit /b 1
)

if defined SDKNetRoot exit /b 0

set "SDKNetRoot=%~dp0"
set "SDKNetRoot=%SDKNetRoot:~0,-7%"
echo Initializing environment
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

if note define 

call "%ADXSDKProgramFiles%\Microsoft Visual Studio %ADXSDKVSVersion%\VC\vcvarsall.bat" x86
