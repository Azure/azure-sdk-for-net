::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::
setlocal
@echo off
set autoRestVersion=1.0.0-Nightly20170129

if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/19f63015ea5a8a0fc64b9d7e2cdfeac447d93eaf/arm-batch/2017-05-01/swagger/BatchManagement.json"
) else (
    set specFile="%1"
)

set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Management.Batch\Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

call "%repoRoot%\tools\autorest.gen.cmd" %specFile% Microsoft.Azure.Management.Batch %autoRestVersion% %generateFolder% MICROSOFT_MIT_NO_VERSION "-ft 1"

endlocal