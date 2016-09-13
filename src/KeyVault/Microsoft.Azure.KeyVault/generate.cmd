::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
set autoRestVersion=0.17.0-Nightly20160726

if  "%1" == "" (
	set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-keyvault/2015-06-01/swagger/keyvault.json"
) else (
    set specFile="%1"
)

set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

call "%repoRoot%\tools\autorest.gen.cmd" %specFile%  Microsoft.Azure.KeyVault %autoRestVersion% %generateFolder% -SyncMethods None 

endlocal