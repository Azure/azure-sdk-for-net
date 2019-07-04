$scriptDir = Split-Path $MyInvocation.MyCommand.Path -Parent
$engDir = "$scriptDir\..\..\eng\"

dotnet msbuild "$scriptDir\..\..\mgmt.proj" /t:CreateNugetPackage /p:Scope=Search

dotnet restore
dotnet build "$engDir/service.proj" /p:ServiceDirectory="search"
dotnet test "$engDir/service.proj" /p:ServiceDirectory="search"
dotnet pack "$engDir/service.proj" /p:ServiceDirectory="search"
