::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/97eb2b1a9e8c6c1ebadd3033b0afa6a92f9766ff/arm-network/compositeNetworkClient.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

call npm install -g autorest@1.1.0
call autorest -m CompositeSwagger -g Azure.CSharp -Namespace Microsoft.Azure.Management.Network -i %specFile% -o %generateFolder% -Header MICROSOFT_MIT