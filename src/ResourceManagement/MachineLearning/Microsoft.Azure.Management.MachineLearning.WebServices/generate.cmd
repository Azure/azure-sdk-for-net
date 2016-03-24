::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
set autoRestVersion=0.15.0-Nightly20160212
if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/NonStatic2014/azure-rest-api-specs/master/arm-machinelearning/2016-04-01-privatepreview/swagger/webservices.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.gen.cmd" %specFile% Microsoft.Azure.Management.MachineLearning.WebServices %autoRestVersion% %generateFolder% 
