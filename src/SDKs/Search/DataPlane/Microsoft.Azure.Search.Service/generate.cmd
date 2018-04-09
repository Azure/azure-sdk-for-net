::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
set repoRoot=%~dp0..\..\..\..\..
set generateFolder=%~dp0Generated
set sharedGenerateFolder=%generateFolder%\..\..\Microsoft.Azure.Search.Common\Generated

if exist %generateFolder% rd /S /Q  %generateFolder%
call %repoRoot%\tools\generate.cmd search/data-plane/Microsoft.Azure.Search.Service %*

:: Move any extra files generated for types that are shared between SearchServiceClient and SearchIndexClient to Common.
if exist %sharedGenerateFolder% rd /S /Q %sharedGenerateFolder%
mkdir %sharedGenerateFolder%
move "%generateFolder%\Models\SearchRequestOptions.cs" %sharedGenerateFolder%
