::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/9c3e59d35f802851c56574d08e687e5119a5d2d8/arm-billing/2017-04-24-preview/swagger/billing.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

autorest --version=1.0.1-20170425-2300-nightly -CodeGenerator Azure.CSharp -Namespace Microsoft.Azure.Management.Billing -Input %specFile% -outputDirectory %generateFolder% -Header MICROSOFT_MIT %~5
