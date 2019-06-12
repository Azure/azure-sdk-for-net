::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
call %~dp0..\..\..\..\tools\generate.cmd datalake-store/resource-manager %*
call %~dp0..\..\..\..\tools\generate.cmd datalake-store/data-plane %*
