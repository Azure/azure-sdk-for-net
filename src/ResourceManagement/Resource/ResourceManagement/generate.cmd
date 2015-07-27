::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::
 
set autoRestVersion=0.11.0-Nightly20150727
set specUrl="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-resources/2014-04-01-preview/swagger/resources.json?token=AFvFAUt8kd8h4EHb6NQ9pfECnwPrhv9wks5Vv8qQwA=="

:: uncomment the line below if you are using the nightly build
REM set source=-Source https://www.myget.org/F/autorest/api/v2

set repoRoot=%~dp0..\..\..\..
set autoRestExe=%repoRoot%\packages\autorest.%autoRestVersion%\tools\AutoRest.exe

%repoRoot%\tools\nuget.exe install autorest %source% -Version %autoRestVersion% -o %repoRoot%\packages
%autoRestExe% -Modeler Swagger -CodeGenerator Azure.CSharp -Namespace Microsoft.Azure.Management.Resources -Input %specUrl% -Header NONE