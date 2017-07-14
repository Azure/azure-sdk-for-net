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
set specFile="https://github.com/%specsRepoUser%/azure-rest-api-specs/blob/%specsRepoBranch%/specification/search/data-plane/readme.md"

set sdksRoot=%~dp0..\..\..

if "%3" == "" (call npm i -g autorest)


@echo on
:: call autorest %specFile% --csharp --csharp-sdks-folder=%sdksRoot% --latest --package-searchservice --tag=null --clear-output-folder
call autorest "--input-file=https://github.com/%specsRepoUser%/azure-rest-api-specs/blob/%specsRepoBranch%/specification/search/data-plane/Microsoft.Search/2016-09-01/searchservice.json" --csharp.azure-arm --output-folder=%sdksRoot%\Search\DataPlane\Microsoft.Azure.Search\GeneratedSearchService --latest --namespace=Microsoft.Azure.Search --license-header=MICROSOFT_MIT --clear-output-folder

endlocal