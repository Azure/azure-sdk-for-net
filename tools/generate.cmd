::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal

:: repo information
if not "%2" == "" (set version="%2")         else (set version="latest")
if not "%3" == "" (set specsRepoUser="%3")   else (set specsRepoUser="Azure")
if not "%4" == "" (set specsRepoBranch="%4") else (set specsRepoBranch="current")
set configFile="https://github.com/%specsRepoUser%/azure-rest-api-specs/blob/%specsRepoBranch%/specification/%1/readme.md"

:: installation
if "%5" == "" (call npm i -g autorest)

:: code generation
@echo on
call autorest %configFile% --csharp --csharp-sdks-folder=%~dp0\..\src\SDKs --version=%version%
@echo off

endlocal
