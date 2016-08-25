::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
set autoRestVersion=0.17.0-Nightly20160626
if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-search/2015-02-28/swagger/search.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..
set generateFolder=%~dp0Generated
set header=MICROSOFT_MIT_NO_VERSION

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.gen.cmd" %specFile% Microsoft.Azure.Management.Search %autoRestVersion% %generateFolder% %header% 
