::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
set autoRestVersion=0.12.0-Nightly20151022
if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-web/2015-08-01/swagger/service.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.gen.cmd" %specFile% Microsoft.Azure.Management.WebSites %autoRestVersion% %generateFolder% 
