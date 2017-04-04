::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
set autoRestVersion=1.0.1.0
if  "%1" == "" (
    set specFile="https://github.com/Azure/azure-rest-api-specs/blob/1c421b473ac5d927a380ed28c06a0eec31b796f2/arm-recoveryservices/compositeRecoveryServicesClient.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.composite.gen.cmd" %specFile% Microsoft.Azure.Management.RecoveryServices %autoRestVersion% %generateFolder% "-FT 1"
