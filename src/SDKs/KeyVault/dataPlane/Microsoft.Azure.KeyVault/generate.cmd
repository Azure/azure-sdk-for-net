::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal
set autoRestVersion=1.0.0-Nightly20170212

if  "%1" == "" (
	set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/f1c9d6628d71fcc2be98c9064698eb3f98287ba4/keyvault/2016-10-01/swagger/keyvault.json"
) else (
    set specFile="%1"
)

set repoRoot=%~dp0..\..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

call "%repoRoot%\tools\autorest.gen.cmd" %specFile%  Microsoft.Azure.KeyVault %autoRestVersion% %generateFolder% MICROSOFT_MIT "-SyncMethods None" 

endlocal