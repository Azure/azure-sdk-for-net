::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal

if not "%1" == "" (set version="%1")         else (set version="latest")
if not "%2" == "" (set specsRepoUser="%2")   else (set specsRepoUser="Azure")
if not "%3" == "" (set specsRepoBranch="%3") else (set specsRepoBranch="current")
set specFile="https://github.com/%specsRepoUser%/azure-rest-api-specs/blob/%specsRepoBranch%/specification/search/data-plane/readme.md"

set sdksRoot=%~dp0..\..\..

if "%4" == "" (call npm i -g autorest)

@echo on
call autorest %specFile% --version=%version% --csharp-sdks-folder=%sdksRoot% --csharp --search-folder=SearchIndex   --input-file=./Microsoft.Search/2016-09-01/searchindex.json
call autorest %specFile% --version=%version% --csharp-sdks-folder=%sdksRoot% --csharp --search-folder=SearchService --input-file=./Microsoft.Search/2016-09-01/searchservice.json

:: Make any necessary modifications
pushd %~dp0
powershell.exe .\Fix-GeneratedCode.ps1
popd

endlocal