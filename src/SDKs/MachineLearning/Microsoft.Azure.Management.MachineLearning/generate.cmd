::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

:: @echo off
setlocal

set autoRestVersion=0.17.0-Nightly20160824

set webServicesSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-machinelearning/2017-01-01/swagger/webservices.json"
set commitmentPlansSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-machinelearning/2016-05-01-preview/swagger/commitmentPlans.json"

set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated
set webServicesGenerateFolder=%generateFolder%\WebServices
set commitmentPlansGenerateFolder=%generateFolder%\CommitmentPlans

if exist %generateFolder% rd /S /Q  %generateFolder%

call "%repoRoot%\tools\autorest.gen.cmd" %webServicesSpecFile% Microsoft.Azure.Management.MachineLearning.WebServices %autoRestVersion% %webServicesGenerateFolder%
call "%repoRoot%\tools\autorest.gen.cmd" %commitmentPlansSpecFile% Microsoft.Azure.Management.MachineLearning.CommitmentPlans %autoRestVersion% %commitmentPlansGenerateFolder%

endlocal