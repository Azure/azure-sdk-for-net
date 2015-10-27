::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal

set autoRestVersion=0.12.0-Nightly20151022
set repoRoot=%~dp0..\..\..\..
set generatedFolder=%~dp0Generated

if "%1" == "" (
    set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-logic/2015-02-01-preview/swagger/logic.json"
) else (
    set specFile="%1"
)

if exist %generatedFolder% rd /S /Q  %generatedFolder%

call "%repoRoot%\tools\autorest.gen.cmd" %specFile% Microsoft.Azure.Management.Logic %autoRestVersion% %generatedFolder%

endlocal
