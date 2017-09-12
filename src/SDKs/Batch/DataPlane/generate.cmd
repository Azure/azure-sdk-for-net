::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
call %~dp0..\..\..\..\tools\generate.cmd batch/data-plane %*

:: This is a stop-gap until https://github.com/Azure/autorest/issues/2558 is fixed
powershell .\fixup.ps1
