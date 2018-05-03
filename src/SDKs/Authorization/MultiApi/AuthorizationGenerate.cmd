@echo off
setlocal

set rp=authorization\resource-manager
set configFile=C:\myFork\restSpecs\specification\%rp%\readme.md
rem set configFile=https://github.com/Azure/azure-rest-api-specs/blob/master/specification/authorization/resource-manager/readme.md
set sdkDir=%cd%\Management.Authorization
REM set autorestVersion=latest
set autorestVersion=C:\myFork\autorest\src\autorest-core

call autorest %configFile% --csharp --csharp-sdks-folder=%sdkDir% --version=%autorestVersion% --reflect-api-versions --MultiApi

endlocal