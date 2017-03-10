::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
set autoRestVersion=1.0.0-Nightly20170212
if  "%1" == "" (
    set specFile="https://raw.githubusercontent.com/Azure/azure-rest-api-specs/b379c30fcb506b1bd643f6085b4bf318b8164b16/arm-sql/compositeSql.json"
) else (
    set specFile="%1"
)
set repoRoot=%~dp0..\..\..\..
set generateFolder=%~dp0Generated

if exist %generateFolder% rd /S /Q  %generateFolder%

autorest -Modeler CompositeSwagger -CodeGenerator Azure.CSharp -Namespace Microsoft.Azure.Management.Sql -Input %specFile% -outputDirectory %generateFolder% -Header MICROSOFT_MIT %~5
