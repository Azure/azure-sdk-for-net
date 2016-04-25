setlocal
set specFile=%1
set namespace=%2
set autoRestVersion=%3
set generateFolder=%4
set header=%5

if [%header%]==[] set header=MICROSOFT_MIT

set source=-Source https://www.myget.org/F/autorest/api/v2

set repoRoot=%~dp0..
set autoRestExe=%repoRoot%\packages\autorest.%autoRestVersion%\tools\AutoRest.exe

%repoRoot%\tools\nuget.exe install autorest %source% -Version %autoRestVersion% -o %repoRoot%\packages -verbosity quiet

@echo on
%autoRestExe% -Modeler Swagger -CodeGenerator Azure.CSharp -Namespace %namespace% -Input %specFile% -outputDirectory %generateFolder% -Header %header% %~6
@echo off
endlocal