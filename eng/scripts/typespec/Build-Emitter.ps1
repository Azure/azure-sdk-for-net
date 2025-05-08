#Requires -Version 7.0

param(
    [string] $OutputDirectory,
    [switch] $TargetNpmJsFeed,
    [string] $emitterPackagePath,
    [string] $GeneratorVersion
)

if ([string]::IsNullOrEmpty($GeneratorVersion)) {
    Write-Host "GeneratorVersion is required"
    exit 1
}

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
. "$PSScriptRoot/../../common/scripts/common.ps1"
Set-ConsoleEncoding

function Build-Emitter {
    param (
        [string]$packageRoot,
        [string]$outputPath,
        [hashtable]$overrides
    )

    Push-Location $packageRoot
    try {
        Write-Host "Working in $PWD"
        Write-Host "TargetNpmJsFeed: $TargetNpmJsFeed"

        $outputPath = New-Item -ItemType Directory -Force -Path $outputPath | Select-Object -ExpandProperty FullName

        # build and pack the emitter
        Invoke-LoggedCommand "npm run build" -GroupOutput

        # remove any existing tarballs
        Remove-Item -Path "./*.tgz" -Force | Out-Null

        #pack the emitter
        Invoke-LoggedCommand "npm pack"
        $file = Get-ChildItem -Filter "*.tgz" | Select-Object -ExpandProperty FullName

        Write-Host "Copying $file to $outputPath"
        Copy-Item $file -Destination $outputPath

        if (!$TargetNpmJsFeed) {
            $feedUrl = "https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-js-test-autorest/npm/registry"

            $packageJson = Get-Content -Path "./package.json" | ConvertFrom-Json
            $packageVersion = $packageJson.version
            $packageName = $packageJson.name

            $unscopedName = $packageName.Split("/")[1]
            $overrides[$packageName] = "$feedUrl/$packageName/-/$unscopedName-$packageVersion.tgz"
        }

        # restore the package.json and package-lock.json files to their original state
        Write-Host "Restoring package.json and package-lock.json to their original state"
        Invoke-LoggedCommand "git restore package.json package-lock.json"
    }
    finally {
        Pop-Location
    }
}

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
        [string] $version,
        [string] $outputPath
    )

    $versionOption = "/p:Version=$version"
    $hasReleaseVersionOption = $version.Contains("alpha") ? "/p:HasReleaseVersion=false" : ""
    Invoke-LoggedCommand "dotnet pack ./$package/src/$package.csproj $versionOption $hasReleaseVersionOption -c Release -o $outputPath"
    Write-PackageInfo -packageName $package -directoryPath "$emitterPackagePath/generator/$package/src" -version $version
}


$overrides = @{}

$outputPath = $OutputDirectory ? $OutputDirectory : (Join-Path $RepoRoot "artifacts" "emitters")
New-Item -ItemType Directory -Force -Path $outputPath | Out-Null

# strip leading slash from emitterPackagePath if it exists
if ($emitterPackagePath.StartsWith("/")) {
    $emitterPackagePath = $emitterPackagePath.Substring(1)
}
$packageRoot = Join-Path $RepoRoot $emitterPackagePath
Build-Emitter -packageRoot $packageRoot -outputPath $outputPath -overrides $overrides

# Pack the generator
Push-Location "$packageRoot/generator"
$generatorSolutionFile = Get-ChildItem -Path . -Filter "*.sln" -File | Select-Object -First 1
$generatorName = $generatorSolutionFile.BaseName
try {
    Write-Host "Working in $PWD"
    Pack-And-Write-Info -package $generatorName -version $GeneratorVersion -outputPath $outputPath
}
finally
{
    Pop-Location
}

$packageMatrix = [ordered]@{
    $generatorName.ToLower() = $generatorVersion
}

$packageMatrix | ConvertTo-Json | Set-Content "$outputPath/package-versions.json"

Write-Host "Writing overrides to $outputPath/overrides.json"

$overrides | ConvertTo-Json | Out-File -FilePath "$outputPath/overrides.json" -Encoding utf8 -Force
Get-Content -Path "$outputPath/overrides.json" | Out-Host
