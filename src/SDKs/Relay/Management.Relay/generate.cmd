::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal

set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-relay/2017-04-01/swagger/relay.json"

set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

call autorest --latest -CodeGenerator Azure.CSharp -Input %specFile% -Namespace Microsoft.Azure.Management.Relay  -outputDirectory %generateFolder% -Header MICROSOFT_MIT -ClientSideValidationntSideValidation

endlocal