::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
set autoRestVersion=1.0.0-Nightly20170202
if  "%1" == "" (
    set specFile="https://github.com/Azure/azure-rest-api-specs/blob/c683f6510a689e1629adb5d8e9e21848c68f2ca3/arm-servicefabric/2016-09-01/swagger/servicefabric.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.composite.gen.cmd" %specFile% Microsoft.Azure.Management.ServiceFabric %autoRestVersion% %generateFolder%