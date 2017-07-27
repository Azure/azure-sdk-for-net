::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal
set source=-Source https://www.myget.org/F/autorest/api/v2

set resSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-streamanalytics/compositeStreamAnalytics.json"

set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

call AutoRest --latest -Modeler CompositeSwagger -CodeGenerator Azure.CSharp -Namespace Microsoft.Azure.Management.StreamAnalytics -Input %resSpecFile% -outputDirectory %generateFolder% -Header MICROSOFT_MIT
endlocal
