::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/609ab70389dd2ba4e70ce5a8836fca5019d3b699/specification/sql/resource-manager/readme.md"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

echo autorest %specFile% --latest --csharp --csharp-sdks-folder=%~dp0..
autorest %specFile% --version=1.1.0 --csharp --csharp-sdks-folder=%~dp0..\..

