::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal
set autoRestVersion=0.17.0-Special-20161018
set source=-Source https://www.myget.org/F/autorest/api/v2

set resSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/559116780819474db8605387c4bc3de4a038533a/arm-resources/resources/2017-05-10/swagger/resources.json"
set lockSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/559116780819474db8605387c4bc3de4a038533a/arm-resources/locks/2016-09-01/swagger/locks.json"
set featureSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/559116780819474db8605387c4bc3de4a038533a/arm-resources/features/2015-12-01/swagger/features.json"
set subscriptionSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/559116780819474db8605387c4bc3de4a038533a/arm-resources/subscriptions/2016-06-01/swagger/subscriptions.json"
set policySpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/559116780819474db8605387c4bc3de4a038533a/arm-resources/policy/2016-04-01/swagger/policy.json"
set linkSpecFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/559116780819474db8605387c4bc3de4a038533a/arm-resources/links/2016-09-01/swagger/links.json"

set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

call "%repoRoot%\tools\autorest.gen.cmd" %resSpecFile% Microsoft.Azure.Management.ResourceManager %autoRestVersion% %generateFolder% 
call "%repoRoot%\tools\autorest.gen.cmd" %lockSpecFile% Microsoft.Azure.Management.ResourceManager %autoRestVersion% %generateFolder% 
call "%repoRoot%\tools\autorest.gen.cmd" %featureSpecFile% Microsoft.Azure.Management.ResourceManager %autoRestVersion% %generateFolder% 
call "%repoRoot%\tools\autorest.gen.cmd" %subscriptionSpecFile% Microsoft.Azure.Management.ResourceManager %autoRestVersion% %generateFolder% 
call "%repoRoot%\tools\autorest.gen.cmd" %policySpecFile% Microsoft.Azure.Management.ResourceManager %autoRestVersion% %generateFolder% 
call "%repoRoot%\tools\autorest.gen.cmd" %linkSpecFile% Microsoft.Azure.Management.ResourceManager %autoRestVersion% %generateFolder% 

endlocal
