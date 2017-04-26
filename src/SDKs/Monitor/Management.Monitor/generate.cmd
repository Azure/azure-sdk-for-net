:: 
:: Microsoft Azure SDK for Net - Generate library code 
:: Copyright (C) Microsoft Corporation. All Rights Reserved. 
:: 
 
@echo off 

if  "%2" == "" (
   set specFile1="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/0fde282c1aac0c9a07c35dd7054b3723bd890d45/monitor/compositeMonitorClient.json"
) else (
   set specFile1="%2"
)

if  "%3" == "" (
   set specFile2="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/186e73d857b8cad3336aed74f8959dc9dbcf8475/arm-monitor/compositeMonitorManagementClient.json"
) else (
   set specFile2="%3"
)

set generateFolder1=%~dp0Generated\Monitor
set generateFolder2=%~dp0Generated\Management\Monitor

if exist %generateFolder1% rd /S /Q  %generateFolder1%
if exist %generateFolder2% rd /S /Q  %generateFolder2%

if "%1" == "install" goto install
goto new

:install
echo **** INFO: Installing AutoRest package
call npm install autorest -g

:new
call autoRest -Modeler CompositeSwagger -CodeGenerator Azure.CSharp -Namespace Microsoft.Azure.Management.Monitor -Input %specFile1% -outputDirectory %generateFolder1% -Header MICROSOFT_MIT -FT 1
call autoRest -Modeler CompositeSwagger -CodeGenerator Azure.CSharp -Namespace Microsoft.Azure.Management.Monitor.Management -Input %specFile2% -outputDirectory %generateFolder2% -Header MICROSOFT_MIT -FT 1
