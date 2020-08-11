$engDir = "$PSScriptRoot\..\..\eng\"

dotnet msbuild "$PSScriptRoot\..\..\mgmt.proj" /t:CreateNugetPackage /p:Scope=Search

dotnet test "$engDir/service.proj" /p:ServiceDirectory="search"
dotnet pack "$engDir/service.proj" /p:ServiceDirectory="search"
