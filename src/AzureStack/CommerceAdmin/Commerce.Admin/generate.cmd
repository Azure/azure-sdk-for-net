::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
call %~dp0..\..\..\..\tools\generate.cmd azsadmin/resource-manager/commerce latest Azure bcb638a668dbb79eaf3190324ca6d690be84b9f6 azure-rest-api-specs %CD%
rd Generated /S /Q
move Commerce\Commerce.Admin\Generated .
rd Commerce /S /Q
