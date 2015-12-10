::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal
set autoRestVersion=0.13.0-Nightly20151207
set source=-Source https://www.myget.org/F/autorest/api/v2

:: TODO: Uncomment these and remove the local ones once they are checked in.
::set accountSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-datalake-analytics/account/2015-10-01-preview/swagger/account.json"
::set jobSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-datalake-analytics/job/2015-10-01-preview/swagger/job.json"
::set catalogSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-datalake-analytics/catalog/2015-10-01-preview/swagger/catalog.json"

set accountSpecFile="C:\SRC\AzureSDK\azure-rest-api-specs\arm-datalake-analytics\account\2015-10-01-preview\swagger\account.json"
set jobSpecFile="C:\SRC\AzureSDK\azure-rest-api-specs\arm-datalake-analytics\job\2015-10-01-preview\swagger\job.json"
set catalogSpecFile="C:\SRC\AzureSDK\azure-rest-api-specs\arm-datalake-analytics\catalog\2015-10-01-preview\swagger\catalog.json"

set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

call "%repoRoot%\tools\autorest.gen.cmd" %accountSpecFile% Microsoft.Azure.Management.DataLake.Analytics %autoRestVersion% %generateFolder% 
call "%repoRoot%\tools\autorest.gen.cmd" %jobSpecFile% Microsoft.Azure.Management.DataLake.Analytics %autoRestVersion% %generateFolder% 
call "%repoRoot%\tools\autorest.gen.cmd" %catalogSpecFile% Microsoft.Azure.Management.DataLake.Analytics %autoRestVersion% %generateFolder% 

endlocal