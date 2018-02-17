::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
set repoRoot=%~dp0..\..\..\..\..
set generateFolder=%~dp0GeneratedSearchService

if exist %generateFolder% rd /S /Q  %generateFolder%
call %repoRoot%\tools\generate.cmd search/data-plane/Microsoft.Azure.Search.Service %*
