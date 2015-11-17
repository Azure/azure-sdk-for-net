::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
set autoRestVersion=0.13.0-Nightly20151115
if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/stankovski/azure-rest-api-specs/master/arm-graphrbac/1.42-previewInternal/swagger/graphrbac.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.gen.cmd" %specFile% Microsoft.Azure.Graph.RBAC %autoRestVersion% %generateFolder%
