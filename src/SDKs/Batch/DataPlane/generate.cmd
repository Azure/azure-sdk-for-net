::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::
setlocal
@echo off
set autoRestVersion=1.0.0-Nightly20170209

if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/da7d66b6789f532b76e89e4ba2deba58608a919e/specification/batch/data-plane/Microsoft.Batch/2017-06-01.5.1/BatchService.json"
) else (
    set specFile="%1"
)

set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Azure.Batch\GeneratedProtocol

if exist %generateFolder% rd /S /Q  %generateFolder%

call "%repoRoot%\tools\autorest.gen.cmd" %specFile% Microsoft.Azure.Batch.Protocol %autoRestVersion% %generateFolder% MICROSOFT_MIT_NO_VERSION "-ft 1 -disablesimplifier"

endlocal