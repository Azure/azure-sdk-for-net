:: 
:: Microsoft Azure SDK for Net - Generate library code 
:: Copyright (C) Microsoft Corporation. All Rights Reserved. 
:: 
 
@echo off 

if  "%2" == "" (
   set specFile="https://github.com/solankisamir/azure-rest-api-specs/blob/apim_2017-03-01/arm-apimanagement/compositeApiManagementClient.json"
) else (
   set specFile="%2"
)

set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

if "%1" == "install" goto install
goto new

:install
echo **** INFO: Installing AutoRest package
call npm install autorest -g

:new
call autoRest -Modeler CompositeSwagger -CodeGenerator Azure.CSharp -Namespace Microsoft.Azure.Management.ApiManagement -Input %specFile% -outputDirectory %generateFolder% -Header MICROSOFT_MIT -FT 1

