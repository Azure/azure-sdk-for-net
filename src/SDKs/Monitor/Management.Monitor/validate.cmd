::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off

if not "%1" == "" (set specsRepoUser="%1")
if not "%2" == "" (set specsRepoBranch="%2")
if "%specsRepoUser%" == ""   (set specsRepoUser="Azure")
if "%specsRepoBranch%" == "" (set specsRepoBranch="current")
set specFile="https://github.com/%specsRepoUser%/azure-rest-api-specs/blob/%specsRepoBranch%/specification/analysisservices/resource-manager/readme.md"

set sdksRoot=%~dp0..\..

if "%3" == "" (call npm i -g autorest)
if exist %generateFolder% rd /S /Q %~dp0Generated

@echo on
call autorest %specFile% --csharp --csharp-sdks-folder=%sdksRoot% --latest












if  "%2" == "" (
   set specFile1="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/0fde282c1aac0c9a07c35dd7054b3723bd890d45/monitor/compositeMonitorClient.json"
) else (
   set specFile1="%2"
)

if  "%3" == "" (
   set specFile2="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/0fde282c1aac0c9a07c35dd7054b3723bd890d45/arm-monitor/compositeMonitorManagementClient.json"
) else (
   set specFile2="%3"
)

if "%1" == "install" goto install
goto new

:install
echo **** INFO: Installing AutoRest package
call npm install autorest -g

:new
call autoRest -Modeler CompositeSwagger -CodeGenerator None -Input %specFile1% -jsonvalidationmessages
call autoRest -Modeler CompositeSwagger -CodeGenerator None -Input %specFile2% -jsonvalidationmessages

rem autoRest -CodeGenerator None -I G:\GitHub\azure-rest-api-specs\monitor\2014-04-01\swagger\usageMetrics_API.json -jsonvalidationmessages
rem autoRest -CodeGenerator None -I G:\GitHub\azure-rest-api-specs\arm-monitor\2015-04-01\swagger\autoscale_API.json


