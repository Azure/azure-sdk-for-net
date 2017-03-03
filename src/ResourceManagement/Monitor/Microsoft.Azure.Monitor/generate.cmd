:: 
:: Microsoft Azure SDK for Net - Generate library code 
:: Copyright (C) Microsoft Corporation. All Rights Reserved. 
:: 

 
@echo off 
set autoRestVersion=1.0.0-Nightly20170212
if  "%1" == "" (
   set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/efed63280648eebdec8be513470cd6c23783efb6/monitor/compositeMonitorClient.json"
) else (
   set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated\Monitor

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.composite.gen.cmd" %specFile% Microsoft.Azure.Insights %autoRestVersion% %generateFolder% "-FT 1"

if  "%2" == "" (
   set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/efed63280648eebdec8be513470cd6c23783efb6/arm-monitor/compositeMonitorManagementClient.json"
) else (
   set specFile="%2"
)

set generateFolder=%~dp0Generated\Management\Monitor

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.composite.gen.cmd" %specFile% Microsoft.Azure.Management.Insights %autoRestVersion% %generateFolder% "-FT 1"
 