::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal

set accountSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91edc3084d674ecabb105584ad926d4d8449b054/specification/datalake-store/resource-manager/Microsoft.DataLakeStore/2016-11-01/account.json"
set filesystemSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91edc3084d674ecabb105584ad926d4d8449b054/specification/datalake-store/data-plane/Microsoft.DataLakeStore/2016-11-01/filesystem.json"

set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

call autorest --latest -CodeGenerator Azure.CSharp -Input %accountSpecFile% -Namespace Microsoft.Azure.Management.DataLake.Store -outputDirectory %generateFolder% -Header MICROSOFT_MIT -ClientSideValidation %~5
call autorest --latest -CodeGenerator Azure.CSharp -Input %filesystemSpecFile% -Namespace Microsoft.Azure.Management.DataLake.Store -outputDirectory %generateFolder% -Header MICROSOFT_MIT -ClientSideValidation %~5

endlocal