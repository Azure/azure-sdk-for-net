::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal
set autoRestVersion=0.17.0-Nightly20160731
set source=-Source https://www.myget.org/F/autorest/api/v2

set accountSpecFile="https://raw.githubusercontent.com/begoldsm/azure-rest-api-specs/master/arm-datalake-analytics/account/2015-10-01-preview/swagger/account.json"
set jobSpecFile="https://raw.githubusercontent.com/begoldsm/azure-rest-api-specs/master/arm-datalake-analytics/job/2016-03-20-preview/swagger/job.json"
set catalogSpecFile="https://raw.githubusercontent.com/begoldsm/azure-rest-api-specs/master/arm-datalake-analytics/catalog/2015-10-01-preview/swagger/catalog.json"

set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

call "%repoRoot%\tools\autorest.gen.cmd" %accountSpecFile% Microsoft.Azure.Management.DataLake.Analytics %autoRestVersion% %generateFolder% 
call "%repoRoot%\tools\autorest.gen.cmd" %jobSpecFile% Microsoft.Azure.Management.DataLake.Analytics %autoRestVersion% %generateFolder% 
call "%repoRoot%\tools\autorest.gen.cmd" %catalogSpecFile% Microsoft.Azure.Management.DataLake.Analytics %autoRestVersion% %generateFolder% 

:: TODO: This should be removed once all the manual fixes are part of the generation functionality.
:: Current manual fix up list:
::  Fix the dynamic host parameters (accountname and datalakejob and catalog service uri)
:: call "powershell.exe" -Command "& %repoRoot%\tools\Fix-AdlGeneratedCode.ps1 -DataLakeAnalytics"
endlocal