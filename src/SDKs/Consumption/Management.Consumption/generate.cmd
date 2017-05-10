::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/1141893c69c16724c1702f26d8c2c9a2da516be9/arm-consumption/2017-04-24-preview/swagger/consumption.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

autorest --version=1.0.1-20170425-2300-nightly -CodeGenerator Azure.CSharp -Namespace Microsoft.Azure.Management.Consumption -Input %specFile% -outputDirectory %generateFolder% -Header MICROSOFT_MIT %~5
