$scriptDir = Split-Path $MyInvocation.MyCommand.Path -Parent
$packagesDir = "$scriptDir\..\..\..\binaries\packages"

if (!(Test-Path -Path $packagesDir))
{
    mkdir $packagesDir
}

msbuild "$scriptDir\..\..\..\build.proj" /t:CreateNugetPackage /p:Scope="SDKs\Search\Management" /p:NugetPackageName="Microsoft.Azure.Management.Search"
msbuild "$scriptDir\..\..\..\build.proj" /t:CreateNugetPackage /p:Scope="SDKs\Search\DataPlane" /p:NugetPackageName="Microsoft.Azure.Search"
