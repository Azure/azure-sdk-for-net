$scriptDir = Split-Path $MyInvocation.MyCommand.Path -Parent
$engDir = "$scriptDir\..\..\eng\"

msbuild "$scriptDir\..\..\build.proj" /t:CreateNugetPackage /p:Scope="search"

dotnet restore
dotnet build "$engDir/service.proj" /p:ServiceDirectory="search"
dotnet test "$engDir/service.proj" /p:ServiceDirectory="search"
dotnet pack "$engDir/service.proj" /p:ServiceDirectory="search"
