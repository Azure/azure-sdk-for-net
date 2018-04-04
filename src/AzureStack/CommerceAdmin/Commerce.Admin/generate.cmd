::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
call %~dp0..\..\..\..\tools\generate.cmd azsadmin/resource-manager/commerce latest deathly809 azs.commerce.admin azure-rest-api-specs %CD%
rd Generated /S /Q
move Commerce\Commerce.Admin\Generated .
rd Commerce /S /Q