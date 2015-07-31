::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal
set autoRestVersion=0.11.0-Nightly20150727
set source=-Source https://www.myget.org/F/autorest/api/v2

set resSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-resources/2014-04-01-preview/swagger/resources.json?token=AFvFAUt8kd8h4EHb6NQ9pfECnwPrhv9wks5Vv8qQwA=="
set authSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-authorization/2015-01-01/swagger/authorization.json?token=AFvFAdC1UDb8X4apaW2jBlybnEIsDIEjks5Vv_eWwA=="
set featureSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-features/2014-08-01-preview/swagger/features.json?token=AFvFAdK0vX5j75nicb0DQY5ihN425UExks5Vv_fGwA=="
set subscriptionSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-subscriptions/2014-04-01-preview/swagger/subscriptions.json?token=AFvFAbQmNVtX9zfhY0EO8vcXdF6iOyyKks5Vv_flwA=="

set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

call "%repoRoot%\tools\autorest.gen.cmd" %resSpecFile% Microsoft.Azure.Management.Resources %autoRestVersion% %generateFolder% 
call "%repoRoot%\tools\autorest.gen.cmd" %authSpecFile% Microsoft.Azure.Management.Resources %autoRestVersion% %generateFolder% 
call "%repoRoot%\tools\autorest.gen.cmd" %featureSpecFile% Microsoft.Azure.Management.Resources %autoRestVersion% %generateFolder% 
call "%repoRoot%\tools\autorest.gen.cmd" %subscriptionSpecFile% Microsoft.Azure.Management.Resources %autoRestVersion% %generateFolder% 

endlocal