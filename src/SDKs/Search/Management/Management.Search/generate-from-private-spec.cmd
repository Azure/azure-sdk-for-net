::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::
:: This generates the SDK code from a private Swagger spec
:: hosted in your private fork of Azure/azure-rest-api-specs
::
:: Paramters:
:: 1. Your GitHub user name
:: 2. Your remote branch name

@echo off
call .\generate.cmd latest %1 %2
