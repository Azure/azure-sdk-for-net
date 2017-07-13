::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal

if not "%1" == "" (set specsRepoUser="%1")
if not "%2" == "" (set specsRepoBranch="%2")
if "%specsRepoUser%" == ""   (set specsRepoUser="Azure")
if "%specsRepoBranch%" == "" (set specsRepoBranch="current")
set specFile="https://github.com/%specsRepoUser%/azure-rest-api-specs/blob/%specsRepoBranch%/specification/search/data-plane/readme.md"

set autoRestVersion=1.2.0
set sdksRoot=%~dp0..\..

if "%3" == "" (call npm i -g autorest)
rd /S /Q %~dp0Generated

@echo on
:: call autorest %specFile% --csharp --csharp-sdks-folder=%sdksRoot% --version=%autoRestVersion% --package-searchindex --tag=null
call autorest "https://github.com/%specsRepoUser%/azure-rest-api-specs/blob/%specsRepoBranch%/specification/search/data-plane/Microsoft.Search/2016-09-01/searchindex.json" --csharp --csharp-sdks-folder=%sdksRoot% --version=%autoRestVersion% --package-searchindex --tag=null

endlocal

:: TODO: get rid of the following! check whether this can be replaced with composite

:: Delete any extra files generated for types that are shared between SearchServiceClient and SearchIndexClient.
del "%generateFolder%\Models\SearchRequestOptions.cs"

:: Delete extra files we don't need.
del "%generateFolder%\DocumentsProxyOperationsExtensions.cs"

:: Make any necessary modifications
powershell.exe .\Fix-GeneratedCode.ps1
