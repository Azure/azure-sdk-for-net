::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
set repoRoot=%~dp0..\..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%
call %repoRoot%\tools\generate.cmd search/data-plane/Microsoft.Azure.Search.Data %*

:: Delete any extra files generated for types that are shared between SearchServiceClient and SearchIndexClient.
del "%generateFolder%\Models\SearchRequestOptions.cs"

:: Delete extra files we don't need.
del "%generateFolder%\DocumentsProxyOperationsExtensions.cs"

:: Make any necessary modifications
powershell.exe .\Fix-GeneratedCode.ps1
