:: 
:: Microsoft Azure SDK for Net - Generate library code 
:: Copyright (C) Microsoft Corporation. All Rights Reserved. 
:: 
 
@echo off 

if  "%2" == "" (
   set specFile1="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/efed63280648eebdec8be513470cd6c23783efb6/monitor/compositeMonitorClient.json"
) else (
   set specFile1="%2"
)

if  "%3" == "" (
   set specFile2="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/efed63280648eebdec8be513470cd6c23783efb6/arm-monitor/compositeMonitorManagementClient.json"
) else (
   set specFile2="%3"
)

set repoRoot=%~dp0..\..\..\..
set generateFolder1=%~dp0Generated\Monitor
set generateFolder2=%~dp0Generated\Management\Monitor
set autoRestVersion="1.0.0-Nightly20170212"

if exist %generateFolder1% rd /S /Q  %generateFolder1%
if exist %generateFolder2% rd /S /Q  %generateFolder2%

if "%1" == "new" goto new
if "%1" == "install" goto install

call "%repoRoot%\tools\autorest.composite.gen.cmd" %specFile1% Microsoft.Azure.Insights %autoRestVersion% %generateFolder1% "-FT 1"
call "%repoRoot%\tools\autorest.composite.gen.cmd" %specFile2% Microsoft.Azure.Management.Insights %autoRestVersion% %generateFolder2% "-FT 1"

goto :eof
:install

echo **** INFO: Installing AutoRest package
call npm install autorest -g

:new

call autoRest -Modeler CompositeSwagger -CodeGenerator Azure.CSharp -Namespace Microsoft.Azure.Insights -Input %specFile1% -outputDirectory %generateFolder1% -Header MICROSOFT_MIT -FT 1
call autoRest -Modeler CompositeSwagger -CodeGenerator Azure.CSharp -Namespace Microsoft.Azure.Management.Insights -Input %specFile2% -outputDirectory %generateFolder2% -Header MICROSOFT_MIT -FT 1
