#Requires -Version 7.0

param(
    [string] $GeneratorVersion,
    [string] $BuildNumber,
    [string] $OutputDirectory
)

if ([string]::IsNullOrEmpty($GeneratorVersion)) {
    Write-Host "GeneratorVersion is required"
    exit 1
}

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
$packageRoot = (Resolve-Path "$PSScriptRoot/../..").Path.Replace('\', '/')
. "$packageRoot/../../../eng/common/scripts/Helpers/CommandInvocation-Helpers.ps1"
Set-ConsoleEncoding

Write-Host "Building generator for BuildNumber: '$BuildNumber', Version: '$GeneratorVersion', Output: '$OutputDirectory'"


function Write-PackageInfo {
    param(
        [string] $packageName,
        [string] $directoryPath,
        [string] $version
    )

    $packageInfoPath = "$outputPath/PackageInfo"

    if (!(Test-Path $packageInfoPath)) {
        New-Item -ItemType Directory -Force -Path $packageInfoPath | Out-Null
    }

    @{
        Name = $packageName
        Version = $version
        DirectoryPath = $directoryPath
        SdkType = "client"
        IsNewSdk = $true
        ReleaseStatus = "Unreleased"
    } | ConvertTo-Json | Set-Content -Path "$packageInfoPath/$packageName.json"
}

function Pack-And-Write-Info {
    param(
        [string] $package,
        [string] $version
    )

    $versionOption = "/p:Version=$version"
    $hasReleaseVersionOption = $version.Contains("alpha") ? "/p:HasReleaseVersion=false" : ""
    Invoke-LoggedCommand "dotnet pack ./$package/src/$package.csproj $versionOption $hasReleaseVersionOption -c Release -o $outputPath/packages"
    Write-PackageInfo -packageName $package -directoryPath "eng/packages/http-client-csharp/generator/$package/src" -version $version
}

# create the output folders if they don't exist
$outputPath = $OutputDirectory ? $OutputDirectory : (Join-Path $RepoRoot "artifacts" "emitters")
New-Item -ItemType Directory -Force -Path "$outputPath/packages" | Out-Null

$generatorVersion = $GeneratorVersion


# Build and pack the generator
Push-Location "$packageRoot/generator"
try {
    Write-Host "Working in $PWD"

    Invoke-LoggedCommand "npm run build:generator" -GroupOutput
    Pack-And-Write-Info -package "Azure.Generator" -version $generatorVersion
}
finally
{
    Pop-Location
}

$packageMatrix = [ordered]@{
    "azure.generator" = $generatorVersion
}

$packageMatrix | ConvertTo-Json | Set-Content "$outputPath/package-versions.json"
