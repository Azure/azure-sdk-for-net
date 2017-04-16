::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
set autoRestVersion=0.17.0-Nightly20160704
if  "%1" == "" (
		set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-graphrbac/compositeGraphRbacManagementClient.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%
call "%repoRoot%\tools\autorest.composite.gen.cmd" %specFile% Microsoft.Azure.Graph.RBAC %autoRestVersion% %generateFolder%
