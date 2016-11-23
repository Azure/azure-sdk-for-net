::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
set autoRestVersion=0.16.0-Nightly20160406
if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/188c597d6e87fede4a3b0048ddff3fbfdb7cfd4c/arm-recoveryservicesbackup/compositeRecoveryServicesBackupClient.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.composite.gen.cmd" %specFile% Microsoft.Azure.Management.RecoveryServices.Backup %autoRestVersion% %generateFolder% "-FT 1"
