::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal
set autoRestVersion=1.0.0-Nightly20161206
set source=-Source https://www.myget.org/F/autorest/api/v2

set accountSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/bd6687e49fe9ff4c136eebd27eb120060eb758a5/arm-datalake-analytics/account/2016-11-01/swagger/account.json"
set jobSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/bd6687e49fe9ff4c136eebd27eb120060eb758a5/arm-datalake-analytics/job/2016-11-01/swagger/job.json"
set catalogSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/bd6687e49fe9ff4c136eebd27eb120060eb758a5/arm-datalake-analytics/catalog/2016-11-01/swagger/catalog.json"

set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

call "%repoRoot%\tools\autorest.gen.cmd" %accountSpecFile% Microsoft.Azure.Management.DataLake.Analytics %autoRestVersion% %generateFolder% 
call "%repoRoot%\tools\autorest.gen.cmd" %jobSpecFile% Microsoft.Azure.Management.DataLake.Analytics %autoRestVersion% %generateFolder% 
call "%repoRoot%\tools\autorest.gen.cmd" %catalogSpecFile% Microsoft.Azure.Management.DataLake.Analytics %autoRestVersion% %generateFolder% 

endlocal