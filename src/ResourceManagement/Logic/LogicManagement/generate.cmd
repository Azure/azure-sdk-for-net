::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::
 
set autoRestVersion=0.11.0-Nightly20150727
set specUrl="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-logic/2015-02-01-preview/swagger/logic.json?token=AH8IX8feQ_AbVGqLGTA3zABKe4sMSgv4ks5VwpPzwA=="
set source=-Source https://www.myget.org/F/autorest/api/v2

set repoRoot=%~dp0..\..\..\..
set autoRestExe=%repoRoot%\packages\autorest.%autoRestVersion%\tools\AutoRest.exe
set generateFolder=%~dp0Generated

%repoRoot%\tools\nuget.exe install autorest %source% -Version %autoRestVersion% -o %repoRoot%\packages

if exist %generateFolder% rd /S /Q  %generateFolder%
%autoRestExe% -Input %specUrl% -outputDirectory %generateFolder% -Namespace Microsoft.Azure.Management.Logic -Header MICROSOFT_APACHE -CodeGenerator Azure.CSharp -AddCredentials
