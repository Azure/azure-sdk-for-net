::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
set autoRestVersion=1.0.0-Nightly20170126
if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/99b77b4ff1ecbfb41cf33fc2b8e1d6e957312214/arm-compute/compositeComputeClient.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.composite.gen.cmd" %specFile% Microsoft.Azure.Management.Compute %autoRestVersion% %generateFolder% "-FT 1"
