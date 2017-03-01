@echo off
SET currDir=%~dp0
SET PSModulePath=%PSModulePath%;%currDir%\Modules
"%VS140COMNTOOLS%VsDevCmd.bat"
