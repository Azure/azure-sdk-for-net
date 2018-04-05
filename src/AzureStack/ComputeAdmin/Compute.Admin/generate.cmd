::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
rd Generated /S /Q
call %~dp0..\..\..\..\tools\generate.cmd azsadmin/resource-manager/compute latest deathly809 azs.compute.admin azure-rest-api-specs %CD%
move /Y Compute\Compute.Admin\Generated .
rd Compute /S /Q