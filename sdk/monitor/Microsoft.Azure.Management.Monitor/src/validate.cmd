::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
setlocal

if not "%1" == "" (set specsRepoUser="%1")
if not "%2" == "" (set specsRepoBranch="%2")
if "%specsRepoUser%" == ""   (set specsRepoUser="Azure")
if "%specsRepoBranch%" == "" (set specsRepoBranch="current")
set specFile1="https://github.com/%specsRepoUser%/azure-rest-api-specs/blob/%specsRepoBranch%/specification/monitor/resource-manager/readme.md"
set specFile2="https://github.com/%specsRepoUser%/azure-rest-api-specs/blob/%specsRepoBranch%/specification/monitor/data-plane/readme.md"


set sdksRoot=%~dp0..\..

if "%3" == "" (call npm i -g autorest)

@echo on
call autorest %specFile1% --csharp --csharp-sdks-folder=%sdksRoot% --latest --azure-validator
call autorest %specFile2% --csharp --csharp-sdks-folder=%sdksRoot% --latest --azure-validator

endlocal
