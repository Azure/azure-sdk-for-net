@echo off

if defined SDKNetRoot exit /b 0

if exist "%USERPROFILE%\SetNugetFeed.cmd" call "%USERPROFILE%\SetNugetFeed.cmd"

if not defined PRIVATE_FEED_URL (
    echo Error, please set following environment variables so build script can download Hydra Spec Nuget Packages:
	echo     PRIVATE_FEED_URL, PRIVATE_FEED_USER_NAME and PRIVATE_FEED_PASSWORD
	exit /b 1
)

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

call "%ADXSDKProgramFiles%\Microsoft Visual Studio %ADXSDKVSVersion%\VC\vcvarsall.bat" x86
