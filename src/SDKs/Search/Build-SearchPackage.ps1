$scriptDir = Split-Path $MyInvocation.MyCommand.Path -Parent
msbuild "$scriptDir\..\..\build.proj" /t:"build;package" /p:scope=Search