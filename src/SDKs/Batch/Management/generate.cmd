::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::
setlocal
@echo off
set autoRestVersion=1.0.0-Nightly20170129

if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/118315820bf944185beaa95b51ca647ec1a87e1b/specification/batch/resource-manager/Microsoft.Batch/2017-05-01/BatchManagement.json"
) else (
    set specFile="%1"
)

set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Management.Batch\Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

call "%repoRoot%\tools\autorest.gen.cmd" %specFile% Microsoft.Azure.Management.Batch %autoRestVersion% %generateFolder% MICROSOFT_MIT_NO_VERSION "-ft 1"

endlocal