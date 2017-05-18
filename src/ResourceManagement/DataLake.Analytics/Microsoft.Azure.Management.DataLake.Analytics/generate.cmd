::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal

set accountSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/0ade6547eff89bab427eb400ebc5da870f2c5bd0/arm-datalake-analytics/account/2016-11-01/swagger/account.json"
set jobSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/0ade6547eff89bab427eb400ebc5da870f2c5bd0/arm-datalake-analytics/job/2016-11-01/swagger/job.json"
set catalogSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/0ade6547eff89bab427eb400ebc5da870f2c5bd0/arm-datalake-analytics/catalog/2016-11-01/swagger/catalog.json"

set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

call autorest --latest -CodeGenerator Azure.CSharp -Input %accountSpecFile% -Namespace Microsoft.Azure.Management.DataLake.Analytics -outputDirectory %generateFolder% -Header MICROSOFT_MIT
call autorest --latest -CodeGenerator Azure.CSharp -Input %jobSpecFile% -Namespace Microsoft.Azure.Management.DataLake.Analytics -outputDirectory %generateFolder% -Header MICROSOFT_MIT
call autorest --latest -CodeGenerator Azure.CSharp -Input %catalogSpecFile% -Namespace Microsoft.Azure.Management.DataLake.Analytics -outputDirectory %generateFolder% -Header MICROSOFT_MIT

endlocal