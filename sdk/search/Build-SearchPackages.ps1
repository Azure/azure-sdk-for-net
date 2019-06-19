$scriptDir = Split-Path $MyInvocation.MyCommand.Path -Parent
$packagesDir = "$scriptDir\..\..\binaries\packages"

if (!(Test-Path -Path $packagesDir)) {
    mkdir $packagesDir
}

msbuild "$scriptDir\..\..\build.proj" /t:CreateNugetPackage /p:Scope="sdk\search\Microsoft.Azure.Management.Search"
msbuild "$scriptDir\..\..\build.proj" /t:CreateNugetPackage /p:Scope="sdk\search"
