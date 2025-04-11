#Requires -Version 7.0

param(
    [string] $OutputDirectory,
    [switch] $TargetNpmJsFeed
)

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

            Write-Host "Adding $packageName to overrides with URL $overrides[$packageName]"
        }
    }
    finally {
        Pop-Location
    }
}

$overrides = @{}

$outputPath = $OutputDirectory ? $OutputDirectory : (Join-Path $RepoRoot "artifacts" "emitters")
New-Item -ItemType Directory -Force -Path $outputPath | Out-Null

$packageRoot = Resolve-Path "$RepoRoot/eng/packages/http-client-csharp"
Build-Emitter -packageRoot $packageRoot -outputPath $outputPath -overrides $overrides

# $packageRoot = Resolve-Path "$RepoRoot/eng/packages/http-client-csharp-mgmt"
# Build-Emitter -packageRoot $packageRoot -outputPath $outputPath -overrides $overrides

Write-Host "Writing overrides to $outputPath/overrides.json"

$overrides | ConvertTo-Json | Out-File -FilePath "$outputPath/overrides.json" -Encoding utf8 -Force
Get-Content -Path "$outputPath/overrides.json" | Out-Host
