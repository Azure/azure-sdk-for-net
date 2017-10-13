@echo off
pushd %~dp0
cd ..\libraries\src

set AZTOOLS=..\..\..\azure-sdk-tools\WindowsAzurePowerShell\src

robocopy /E .\ %AZTOOLS%\ManagementLibraries\ /XD CloudServiceManagement /XD Keys /XD PackageSpecs /XD Playground /XD Scheduler /XD bin /XD obj /XD Common.NetFramework /XF AssemblyInfo.cs /XF libraries.targets /XF .gitignore /XF packages.config /XF app.config /XF *.csproj
robocopy /E .\Common.NetFramework\ %AZTOOLS%\ManagementLibraries.NetFramework\ /XF AssemblyInfo.cs /XF libraries.targets /XF .gitignore /XF packages.config /XF app.config /XF *.csproj /XD bin /XD obj

: done
popd
