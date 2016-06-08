::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

:: https://github.com/Azure/azure-rest-api-specs/commits/master

@echo off
set autoRestVersion=0.17.0-Nightly20160607
if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-powerbiembedded/2016-01-29/swagger/powerbiembedded.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.gen.cmd" %specFile% Microsoft.Azure.Management.PowerBIEmbedded %autoRestVersion% %generateFolder% "-FT 2"
