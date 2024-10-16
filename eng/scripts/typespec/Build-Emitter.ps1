#Requires -Version 7.0

param(
    [string] $BuildNumber,
    [string] $OutputDirectory,
    [switch] $Prerelease,
    [switch] $TargetNpmJsFeed
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
. "$PSScriptRoot/../../common/scripts/common.ps1"
Set-ConsoleEncoding

$packageRoot = Resolve-Path "$RepoRoot/eng/packages/http-client-csharp"
$outputPath = $OutputDirectory ? $OutputDirectory : (Join-Path $packageRoot "artifacts" "build")

Push-Location $packageRoot
try {
    Write-Host "Working in $PWD"
    
    $outputPath = New-Item -ItemType Directory -Force -Path $outputPath | Select-Object -ExpandProperty FullName

    $emitterVersion = (npm pkg get version).Trim('"')

    if ($BuildNumber) {
        # set package versions
        $versionTag = $Prerelease ? "-alpha" : "-beta"

        $emitterVersion = "$($emitterVersion.Split('-')[0])$versionTag.$BuildNumber"
        Write-Host "Setting output variable 'emitterVersion' to $emitterVersion"
        Write-Host "##vso[task.setvariable variable=emitterVersion;isoutput=true]$emitterVersion"
    }

    # build and pack the emitter
    Invoke-LoggedCommand "npm run build" -GroupOutput

    if ($BuildNumber) {
        Write-Host "Updating version package.json to the new emitter version`n"
        Invoke-LoggedCommand "npm pkg set version=$emitterVersion"
    }

    # remove any existing tarballs
    Remove-Item -Path "./*.tgz" -Force | Out-Null
    
    #pack the emitter
    Invoke-LoggedCommand "npm pack"
    $file = Get-ChildItem -Filter "*.tgz" | Select-Object -ExpandProperty FullName

    # ensure the packages directory exists
    New-Item -ItemType Directory -Force -Path "$outputPath/packages" | Out-Null

    Write-Host "Copying $file to $outputPath/packages"
    Copy-Item $file -Destination "$outputPath/packages"

    if ($TargetNpmJsFeed) {
        $overrides = @{}
    }
    else {
        $feedUrl = "https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-js-test-autorest/npm/registry"

        $overrides = @{
            "@azure-typespec/http-client-csharp" = "$feedUrl/@azure-typespec/http-client-csharp/-/http-client-csharp-$emitterVersion.tgz"
        }
    }

    $overrides | ConvertTo-Json | Set-Content "$outputPath/overrides.json"

    $packageMatrix = [ordered]@{
        "emitter" = $emitterVersion
    }

    $packageMatrix | ConvertTo-Json | Set-Content "$outputPath/package-versions.json"
}
finally {
    Pop-Location
}
