::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
call %~dp0..\..\..\..\tools\generate.cmd azsadmin/resource-manager/InfrastructureInsights latest Azure current azure-rest-api-specs %CD%
move InfrastructureInsights\InfrastructureInsights.Admin\Generated .
rd InfrastructureInsights /S /Q