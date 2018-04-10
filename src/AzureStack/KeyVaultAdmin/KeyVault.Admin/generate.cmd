::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
rd /S /Q Generated
call %~dp0..\..\..\..\tools\generate.cmd azsadmin/resource-manager/keyvault latest Azure master azure-rest-api-specs %CD%
move KeyVault\KeyVault.Admin\Generated .
rd /S /Q KeyVault
