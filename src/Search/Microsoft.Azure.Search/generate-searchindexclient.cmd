::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
set autoRestVersion=0.17.0-Nightly20160626
if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/search/2015-02-28-Preview/swagger/searchindex.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..
set generateFolder=%~dp0GeneratedSearchIndex
set header=MICROSOFT_MIT_NO_VERSION

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.gen.cmd" %specFile% Microsoft.Azure.Search %autoRestVersion% %generateFolder% %header%

:: Delete any extra files generated for types that are shared between SearchServiceClient and SearchIndexClient.
del "%generateFolder%\Models\SearchRequestOptions.cs"

:: Delete extra files we don't need.
del "%generateFolder%\DocumentsProxyOperationsExtensions.cs"

:: Make any necessary modifications
powershell.exe .\Fix-GeneratedCode.ps1
