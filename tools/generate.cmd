::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal

:: help requested?
set pot_help=%1%2
if "%pot_help%"==""            (set req_help=T)
if "%2"=="help"                (set req_help=T)
if "%2"=="-help"               (set req_help=T)
if "%2"=="--help"              (set req_help=T)
if "%2"=="/help"               (set req_help=T)
if "%pot_help%"=="help"        (set req_help=T)
if "%pot_help%"=="-help"       (set req_help=T)
if "%pot_help%"=="--help"      (set req_help=T)
if "%pot_help%"=="/help"       (set req_help=T)
if not x%pot_help%==x%pot_help:?=% (set req_help=T)
if not "%req_help%" == "" (
    echo.
    echo Usage: generate.cmd
    echo             ^<service, e.g. 'network/resource-manager'^>
    echo             ^<AutoRest version, defaults to 'latest'^>
    echo             ^<GitHub user of specs repo, defaults to 'Azure'^>
    echo             ^<Branch or commit ID of specs repo, defaults to 'master'^>
    echo             ^<actual name of specs repo, defaults to 'azure-rest-api-specs'^>
    echo.
    echo Example: generate.cmd monitor/data-plane 1.2.2 olydis new-cool-feature azure-rest-api-specs-pr
    echo Note: If you are calling an SDK's generate.cmd, the first parameter is already provided for you.
    echo.
    echo To display this help, run either of
    echo      generate.cmd help
    echo      generate.cmd -help
    echo      generate.cmd --help
    echo      generate.cmd /help
    echo      generate.cmd ?
    echo      generate.cmd -?
    echo      generate.cmd --?
    echo      generate.cmd /?
    exit /B
)

:: repo information
set rp="%1"
if not "%2" == "" (set autoRestVersion="%2")         else (set autoRestVersion="latest")
if not "%3" == "" (set specsRepoFork="%3")   else (set specsRepoFork="Azure")
if not "%4" == "" (set specsRepoBranch="%4") else (set specsRepoBranch="master")
if not "%5" == "" (set specsRepoName="%5")   else (set specsRepoName="azure-rest-api-specs")
if not "%6" == "" (set sdkDirectory="%6")      else (set sdkDirectory=%~dp0..\src\SDKS)

:: code generation
@echo on
call powershell.exe -ExecutionPolicy Bypass -NoLogo -NonInteractive -NoProfile -File "%~dp0\generateTool.ps1" -ResourceProvider %rp% -SpecsRepoFork %specsRepoFork% -SpecsRepoBranch %specsRepoBranch% -SpecsRepoName %specsRepoName% -SdkDirectory %sdkDirectory% -AutoRestVersion %autoRestVersion%
@echo off