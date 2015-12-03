::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal
set autoRestVersion=0.13.0-Nightly20151202
set source=-Source https://www.myget.org/F/autorest/api/v2

:: TODO: Uncomment these and remove the local ones once they are checked in.
::set accountSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-datalake-store/account/2015-10-01-preview/swagger/account.json"
::set filesystemSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-datalake-store/filesystem/2015-10-01-preview/swagger/filesystem.json"


set accountSpecFile="C:\SRC\AzureSDK\azure-rest-api-specs\arm-datalake-store\account\2015-10-01-preview\swagger\account.json"
set filesystemSpecFile="C:\SRC\AzureSDK\azure-rest-api-specs\arm-datalake-store\filesystem\2015-10-01-preview\swagger\filesystem.json"

set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

call "%repoRoot%\tools\autorest.gen.cmd" %accountSpecFile% Microsoft.Azure.Management.DataLake.Store %autoRestVersion% %generateFolder% 
call "%repoRoot%\tools\autorest.gen.cmd" %filesystemSpecFile% Microsoft.Azure.Management.DataLake.Store %autoRestVersion% %generateFolder% 

endlocal