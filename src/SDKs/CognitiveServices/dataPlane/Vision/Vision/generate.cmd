::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
call %~dp0..\..\..\..\..\..\tools\generate.cmd cognitiveservices/data-plane/Face %*
call %~dp0..\..\..\..\..\..\tools\generate.cmd cognitiveservices/data-plane/ComputerVision %*