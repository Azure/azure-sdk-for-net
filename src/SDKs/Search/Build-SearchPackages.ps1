$scriptDir = Split-Path $MyInvocation.MyCommand.Path -Parent
$packagesDir = "$scriptDir\..\..\..\binaries\packages"

if (!(Test-Path -Path $packagesDir))
{
    mkdir $packagesDir
}

msbuild "$scriptDir\..\..\..\build.proj" /t:CreateNugetPackage /p:Scope="SDKs\Search\Management"
msbuild "$scriptDir\..\..\..\build.proj" /t:CreateNugetPackage /p:Scope="SDKs\Search\DataPlane"
