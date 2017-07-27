::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
REM set autoRestVersion=0.14.0-Nightly20160125
REM set autoRestVersion=0.16.0-Nightly20160406  
set autoRestVersion=1.0.0-Nightly20170124

if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-dns/2016-04-01/swagger/dns.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.gen.cmd" %specFile% Microsoft.Azure.Management.Dns %autoRestVersion% %generateFolder%
