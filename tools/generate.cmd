::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal

:: help requested?
set pot_help="%1%2"
if not x%pot_help%==x%pot_help:help=% (set req_help=T)
if not x%pot_help%==x%pot_help:?=%    (set req_help=T)
if not "%req_help%" == "" (
    echo.
    echo Usage: generate.cmd
    echo             ^<RP, e.g. 'network/resource-manager'^>
    echo             ^<AutoRest version, defaults to 'latest'^>
    echo             ^<GitHub user of azure-rest-api-specs repo, defaults to 'Azure'^>
    echo             ^<Branch of azure-rest-api-specs repo, defaults to 'current'^>
    echo.
    echo Example: generate.cmd monitor/data-plane 1.1.0 olydis new-cool-feature
    exit /B
)

:: repo information
set rp="%1"
if not "%2" == "" (set version="%2")         else (set version="latest")
if not "%3" == "" (set specsRepoUser="%3")   else (set specsRepoUser="Azure")
if not "%4" == "" (set specsRepoBranch="%4") else (set specsRepoBranch="current")
set configFile="https://github.com/%specsRepoUser%/azure-rest-api-specs/blob/%specsRepoBranch%/specification/%rp%/readme.md"

:: installation
if "%5" == "" (call npm i -g autorest)

:: code generation
@echo on
call autorest %configFile% --csharp --csharp-sdks-folder=%~dp0\..\src\SDKs --version=%version%
@echo off

:: metadata
call powershell %~dp0\generateMetadata.ps1 %specsRepoUser% %specsRepoBranch% %version% %configFile% > %~dp0\..\src\SDKs\_metadata\%rp:/=_%.txt

endlocal
