# For details see https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/Cadl-Project-Scripts.md

[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ProjectDirectory,
    [Parameter(Position=1)]
    [string] $CadlAdditionalOptions ## additional cadl emitter options, separated by semicolon if more than one, e.g. option1=value1;option2=value2
)

$ErrorActionPreference = "Stop"
. $PSScriptRoot/Helpers/PSModule-Helpers.ps1
. $PSScriptRoot/common.ps1
Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module

function NpmInstallForProject([string]$workingDirectory) {
    Push-Location $workingDirectory
    try {
        $currentDur = Resolve-Path "."
        Write-Host "Generating from $currentDur"

        if (Test-Path "package.json") {
            Remove-Item -Path "package.json" -Force
        }

        if (Test-Path ".npmrc") {
            Remove-Item -Path ".npmrc" -Force
        }

        if (Test-Path "node_modules") {
            Remove-Item -Path "node_modules" -Force -Recurse
        }

        if (Test-Path "package-lock.json") {
            Remove-Item -Path "package-lock.json" -Force
        }

        #default to root/eng/emitter-package.json but you can override by writing
        #Get-${Language}-EmitterPackageJsonPath in your Language-Settings.ps1
        $replacementPackageJson = "$PSScriptRoot/../../emitter-package.json"
        if (Test-Path "Function:$GetEmitterPackageJsonPathFn") {
            $replacementPackageJson = &$GetEmitterPackageJsonPathFn
        }

        Write-Host("Copying package.json from $replacementPackageJson")
        Copy-Item -Path $replacementPackageJson -Destination "package.json" -Force
        npm install --no-lock-file
        if ($LASTEXITCODE) { exit $LASTEXITCODE }
    }
    finally {
        Pop-Location
    }
}

$resolvedProjectDirectory = Resolve-Path $ProjectDirectory
$emitterName = &$GetEmitterNameFn
$cadlConfigurationFile = Resolve-Path "$ProjectDirectory/cadl-location.yaml"

Write-Host "Reading configuration from $cadlConfigurationFile"
$configuration = Get-Content -Path $cadlConfigurationFile -Raw | ConvertFrom-Yaml

$specSubDirectory = $configuration["directory"]
$innerFolder = Split-Path $specSubDirectory -Leaf

$tempFolder = "$ProjectDirectory/TempCadlFiles"
$npmWorkingDir = Resolve-Path $tempFolder/$innerFolder
$mainCadlFile = If (Test-Path "$npmWorkingDir/client.cadl") { Resolve-Path "$npmWorkingDir/client.cadl" } Else { Resolve-Path "$npmWorkingDir/main.cadl"}

try {
    Push-Location $npmWorkingDir
    NpmInstallForProject $npmWorkingDir

    if ($LASTEXITCODE) { exit $LASTEXITCODE }

    if (Test-Path "Function:$GetEmitterAdditionalOptionsFn") {
        $emitterAdditionalOptions = &$GetEmitterAdditionalOptionsFn $resolvedProjectDirectory
        if ($emitterAdditionalOptions.Length -gt 0) {
            $emitterAdditionalOptions = " $emitterAdditionalOptions"
        }
    }
    $cadlCompileCommand = "npx cadl compile $mainCadlFile --emit $emitterName$emitterAdditionalOptions"
    if ($CadlAdditionalOptions) {
        $options = $CadlAdditionalOptions.Split(";");
        foreach ($option in $options) {
            $cadlCompileCommand += " --option $emitterName.$option"
        }
    }
    Write-Host($cadlCompileCommand)
    Invoke-Expression $cadlCompileCommand

    if ($LASTEXITCODE) { exit $LASTEXITCODE }
}
finally {
    Pop-Location
}

$shouldCleanUp = $configuration["cleanup"] ?? $true
if ($shouldCleanUp) {
    Remove-Item $tempFolder -Recurse -Force
}
