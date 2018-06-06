::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
rd Generated /S /Q
call %~dp0..\..\..\..\tools\generate.cmd azsadmin/resource-manager/subscriptions latest azure master azure-rest-api-specs %CD%
::move /Y Subscriptions\Subscriptions.Admin\Generated .
::rd Subscriptions /S /Q
