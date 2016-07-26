::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal
set autoRestVersion=0.16.0-Nightly20160413

set iotHubSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-iothub/2016-02-03/swagger/iothub.json"

set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

call "%repoRoot%\tools\autorest.gen.cmd" %iotHubSpecFile% Microsoft.Azure.Management.IotHub %autoRestVersion% %generateFolder% 

endlocal