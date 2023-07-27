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
if not "%2" == "" (set version="%2")         else (set version="latest")
if not "%3" == "" (set specsRepoUser="%3")   else (set specsRepoUser="Azure")
if not "%4" == "" (set specsRepoBranch="%4") else (set specsRepoBranch="master")
if not "%5" == "" (set specsRepoName="%5")   else (set specsRepoName="azure-rest-api-specs")
if not "%6" == "" (set sdksFolder="%6")      else (set sdksFolder=%~dp0..\sdk)
set configFile="https://github.com/%specsRepoUser%/%specsRepoName%/blob/%specsRepoBranch%/specification/%rp%/readme.md"

:: installation
if "%7" == "" (call npm i -g autorest)

:: code generation
@echo on
call autorest %configFile% --csharp --csharp-sdks-folder=%sdksFolder% --version=%version% --reflect-api-versions --generation1-convenience-client
@echo off

:: metadata
mkdir %~dp0\..\src\SDKs\_metadata >nul 2>&1
call powershell %~dp0\generateMetadata.ps1 %specsRepoUser% %specsRepoBranch% %version% %configFile% > %~dp0\..\src\SDKs\_metadata\%rp:/=_%.txt

endlocal
