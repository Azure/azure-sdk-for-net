::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal
set autoRestVersion=0.17.0-Nightly20160731
set source=-Source https://www.myget.org/F/autorest/api/v2

set accountSpecFile="https://raw.githubusercontent.com/begoldsm/azure-rest-api-specs/master/arm-datalake-store/account/2015-10-01-preview/swagger/account.json"
set filesystemSpecFile="https://raw.githubusercontent.com/begoldsm/azure-rest-api-specs/master/arm-datalake-store/filesystem/2015-10-01-preview/swagger/filesystem.json"

set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

call "%repoRoot%\tools\autorest.gen.cmd" %accountSpecFile% Microsoft.Azure.Management.DataLake.Store %autoRestVersion% %generateFolder% 
call "%repoRoot%\tools\autorest.gen.cmd" %filesystemSpecFile% Microsoft.Azure.Management.DataLake.Store %autoRestVersion% %generateFolder% 

:: TODO: This should be removed once all the manual fixes are part of the generation functionality.
:: Current manual fix up list:
::  Fix the dynamic host parameters. (accountname and datalakeserviceuri)
::  Add redirect logic into all the constructors by default.
::  Fix redirect URIs to be full paths (Create, Open and Append)
:: call "powershell.exe" -Command "& %repoRoot%\tools\Fix-AdlGeneratedCode.ps1 -DataLakeStore"

endlocal