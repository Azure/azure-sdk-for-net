::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal

set accountSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/5f839ce3d1f11a3107a61375a61580ff1353b98b/specification/datalake-analytics/resource-manager/Microsoft.DataLakeAnalytics/2016-11-01/account.json"
set jobSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/5f839ce3d1f11a3107a61375a61580ff1353b98b/specification/datalake-analytics/data-plane/Microsoft.DataLakeAnalytics/2016-11-01/job.json"
set catalogSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/5f839ce3d1f11a3107a61375a61580ff1353b98b/specification/datalake-analytics/data-plane/Microsoft.DataLakeAnalytics/2016-11-01/catalog.json"

set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

call autorest --latest -CodeGenerator Azure.CSharp -Input %accountSpecFile% -Namespace Microsoft.Azure.Management.DataLake.Analytics -outputDirectory %generateFolder% -Header MICROSOFT_MIT -ClientSideValidation
call autorest --latest -CodeGenerator Azure.CSharp -Input %jobSpecFile% -Namespace Microsoft.Azure.Management.DataLake.Analytics -outputDirectory %generateFolder% -Header MICROSOFT_MIT -ClientSideValidation
call autorest --latest -CodeGenerator Azure.CSharp -Input %catalogSpecFile% -Namespace Microsoft.Azure.Management.DataLake.Analytics -outputDirectory %generateFolder% -Header MICROSOFT_MIT -ClientSideValidation

endlocal