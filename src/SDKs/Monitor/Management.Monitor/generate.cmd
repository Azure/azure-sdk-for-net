:: 
:: Microsoft Azure SDK for Net - Generate library code 
:: Copyright (C) Microsoft Corporation. All Rights Reserved. 
:: 
 
@echo off 

if  "%2" == "" (
   set specFile1="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/5288e653adfe3dd6ce235a790008a8215eedb918/monitor/compositeMonitorClient.json"
) else (
   set specFile1="%2"
)

if  "%3" == "" (
   set specFile2="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/5288e653adfe3dd6ce235a790008a8215eedb918/arm-monitor/compositeMonitorManagementClient.json"
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


autoRest -Modeler CompositeSwagger -CodeGenerator Azure.CSharp -Namespace Microsoft.Azure.Management.Monitor -Input G:\temp\monitor\compositeMonitorClient.json -outputDirectory G:\GitHub\azure-sdk-for-net\src\SDKs\monitor\Management.Monitor\Generated\Monitor -Header MICROSOFT_MIT -FT 1
autoRest -Modeler CompositeSwagger -CodeGenerator Azure.CSharp -Namespace Microsoft.Azure.Management.Monitor.Management -Input G:\temp\arm-monitor\compositeMonitorManagementClient.json -outputDirectory G:\GitHub\azure-sdk-for-net\src\SDKs\monitor\Management.Monitor\Generated\Management\Monitor -Header MICROSOFT_MIT -FT 1