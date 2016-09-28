:: 
:: Microsoft Azure SDK for Net - Generate library code 
:: Copyright (C) Microsoft Corporation. All Rights Reserved. 
:: 

 
@echo off 
set autoRestVersion=0.17.0-Nightly20160914
if  "%1" == "" (
   set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/insights/compositeInsightsClient.json"
) else (
   set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated\Insights

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.composite.gen.cmd" %specFile% Microsoft.Azure.Insights %autoRestVersion% %generateFolder% "-FT 1"

if  "%2" == "" (
   set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-insights/compositeInsightsManagementClient.json"
) else (
   set specFile="%2"
)

set generateFolder=%~dp0Generated\Management\Insights

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.composite.gen.cmd" %specFile% Microsoft.Azure.Management.Insights %autoRestVersion% %generateFolder% "-FT 1"