$scriptDir = Split-Path $MyInvocation.MyCommand.Path -Parent

msbuild "$scriptDir\..\..\build.proj" /t:Util /p:UtilityName="InstallPsModules"
