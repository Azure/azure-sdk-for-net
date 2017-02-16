:: 
:: Microsoft Azure SDK for Net - Generate library code 
:: Copyright (C) Microsoft Corporation. All Rights Reserved. 
:: 

 
@echo off 
set autoRestVersion=1.0.0-Nightly20161116
if  "%1" == "" (
   set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/1f823636981e779b6d4155aa18d042146e1270fb/monitor/compositeMonitorClient.json"
) else (
   set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated\Monitor

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.composite.gen.cmd" %specFile% Microsoft.Azure.Monitor %autoRestVersion% %generateFolder% "-FT 1"

if  "%2" == "" (
   set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/1f823636981e779b6d4155aa18d042146e1270fb/arm-monitor/compositeMonitorManagementClient.json"
) else (
   set specFile="%2"
)

set generateFolder=%~dp0Generated\Management\Monitor

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.composite.gen.cmd" %specFile% Microsoft.Azure.Management.Monitor %autoRestVersion% %generateFolder% "-FT 1"
 