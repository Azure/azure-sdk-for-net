# For details see https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/Cadl-Project-Scripts.md

[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ProjectDirectory,
    [Parameter(Position=1)]
    [string] $CadlAdditionalOptions ## addtional cadl emitter options, separated by semicolon if more than one, e.g. option1=value1;option2=value2
)

$ErrorActionPreference = "Stop"
. $PSScriptRoot/Helpers/PSModule-Helpers.ps1
. $PSScriptRoot/Helpers/CommandInvocation-Helpers.ps1
. $PSScriptRoot/common.ps1
Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module

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

Push-Location $npmWorkingDir
try {
    . $PSScriptRoot/Invoke-EmitterNpmInstall.ps1

    if ($LASTEXITCODE) { exit $LASTEXITCODE }

    if (Test-Path "Function:$GetEmitterAdditionalOptionsFn") {
        $emitterAdditionalOptions = &$GetEmitterAdditionalOptionsFn $resolvedProjectDirectory
        if ($emitterAdditionalOptions.Length -gt 0) {
            $emitterAdditionalOptions = " $emitterAdditionalOptions"
        }
    }
    $cadlCompileCommand = "npx --no cadl compile $mainCadlFile --emit $emitterName$emitterAdditionalOptions"
    if ($CadlAdditionalOptions) {
        $options = $CadlAdditionalOptions.Split(";");
        foreach ($option in $options) {
            $cadlCompileCommand += " --option $emitterName.$option"
        }
    }

    Invoke-LoggedCommand $cadlCompileCommand

    if ($LASTEXITCODE) { exit $LASTEXITCODE }
}
finally {
    Pop-Location
}

$shouldCleanUp = $configuration["cleanup"] ?? $true
if ($shouldCleanUp) {
    Remove-Item $tempFolder -Recurse -Force
}