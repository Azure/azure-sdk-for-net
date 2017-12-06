::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
rem call %~dp0..\..\..\..\tools\generate.cmd compute/resource-manager latest Azure current azure-rest-api-specs
call %~dp0..\..\..\..\tools\generate.cmd locationbasedservices/resource-manager %*

