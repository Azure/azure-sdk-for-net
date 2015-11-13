::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
set autoRestVersion=0.13.0-Nightly20151111
if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/search/2015-02-28/swagger/searchservice.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..
set generateFolder=%~dp0GeneratedSearchService

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.gen.cmd" %specFile% Microsoft.Azure.Search %autoRestVersion% %generateFolder% 
