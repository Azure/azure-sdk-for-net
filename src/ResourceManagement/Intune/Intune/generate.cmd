::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
::set autoRestVersion=0.13.0-Nightly20151029
set autoRestVersion=0.12.0-Nightly20151022
if  "%1" == "" (
    set specFile="https://github.com/vrmurthy01/azure-rest-api-specs/blob/master/arm-intune/2015-01-11-alpha/swagger/intune.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.gen.cmd" %specFile% Microsoft.Azure.Management.Intune %autoRestVersion% %generateFolder% 
