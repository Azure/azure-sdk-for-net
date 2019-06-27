@echo off
setlocal
set localPath=%1
rmdir Generated /Q /S

IF [%1] == [] GOTO Default

@echo on
call autorest.cmd %localPath%\specification\compute\resource-manager\readme.md --csharp --version=latest --reflect-api-versions --csharp.output-folder=%~dp0Generated
@echo off

GOTO Exit

:Default
@echo on
call autorest.cmd https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/compute/resource-manager/readme.md --csharp --version=latest --reflect-api-versions --csharp.output-folder=%~dp0Generated
@echo off

:Exit
