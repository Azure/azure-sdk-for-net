#Requires -Version 7.0

param(
    [string] $OutputDirectory,
    [switch] $TargetNpmJsFeed,
    [string] $emitterPackagePath
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
        }

        # restore the package.json and package-lock.json files to their original state
        Write-Host "Restoring package.json and package-lock.json to their original state"
        Invoke-LoggedCommand "git restore package.json package-lock.json"
    }
    finally {
        Pop-Location
    }
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

Write-Host "Writing overrides to $outputPath/overrides.json"

$overrides | ConvertTo-Json | Out-File -FilePath "$outputPath/overrides.json" -Encoding utf8 -Force
Get-Content -Path "$outputPath/overrides.json" | Out-Host
