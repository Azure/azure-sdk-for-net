::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
call %~dp0..\..\..\..\..\tools\generate.cmd search/data-plane %*

:: Make any necessary modifications
pushd %~dp0
powershell.exe .\Fix-GeneratedCode.ps1
popd