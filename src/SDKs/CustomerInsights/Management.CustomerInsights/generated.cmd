::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
set autoRestVersion=1.0.0-Nightly20170209 
if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/4bb79249445a02e222e2aec3b47969e0217981de/arm-customer-insights/2017-01-01/swagger/customer-insights.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.gen.cmd" %specFile% Microsoft.Azure.Management.CustomerInsights %autoRestVersion% %generateFolder% 
