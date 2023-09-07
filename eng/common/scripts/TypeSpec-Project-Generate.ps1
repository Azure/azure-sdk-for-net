# For details see https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/TypeSpec-Project-Scripts.md

[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ProjectDirectory,
    [string] $TypespecAdditionalOptions = $null, ## addtional typespec emitter options, separated by semicolon if more than one, e.g. option1=value1;option2=value2
    [switch] $SaveInputs = $false ## saves the temporary files during execution, default false
)

$ErrorActionPreference = "Stop"
. $PSScriptRoot/Helpers/PSModule-Helpers.ps1
. $PSScriptRoot/Helpers/CommandInvocation-Helpers.ps1
. $PSScriptRoot/common.ps1
Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module

$resolvedProjectDirectory = Resolve-Path $ProjectDirectory
$emitterName = &$GetEmitterNameFn
$typespecConfigurationFile = Resolve-Path "$ProjectDirectory/tsp-location.yaml"

Write-Host "Reading configuration from $typespecConfigurationFile"
$configuration = Get-Content -Path $typespecConfigurationFile -Raw | ConvertFrom-Yaml

$specSubDirectory = $configuration["directory"]
$innerFolder = Split-Path $specSubDirectory -Leaf

$tempFolder = "$ProjectDirectory/TempTypeSpecFiles"
$npmWorkingDir = Resolve-Path $tempFolder/$innerFolder
$mainTypeSpecFile = If (Test-Path "$npmWorkingDir/client.*") { Resolve-Path "$npmWorkingDir/client.*" } Else { Resolve-Path "$npmWorkingDir/main.*"}

Push-Location $npmWorkingDir
try {
    . $PSScriptRoot/Invoke-NpmInstall.ps1

    if ($LASTEXITCODE) { exit $LASTEXITCODE }

    if (Test-Path "Function:$GetEmitterAdditionalOptionsFn") {
        $emitterAdditionalOptions = &$GetEmitterAdditionalOptionsFn $resolvedProjectDirectory
        if ($emitterAdditionalOptions.Length -gt 0) {
            $emitterAdditionalOptions = " $emitterAdditionalOptions"
        }
    }
    $typespecCompileCommand = "npx --no tsp compile $mainTypeSpecFile --emit $emitterName$emitterAdditionalOptions"
    if ($TypespecAdditionalOptions) {
        $options = $TypespecAdditionalOptions.Split(";");
        foreach ($option in $options) {
            $typespecCompileCommand += " --option $emitterName.$option"
        }
    }

    if ($SaveInputs) {
        $typespecCompileCommand += " --option $emitterName.save-inputs=true"
    }

    Invoke-LoggedCommand $typespecCompileCommand

    if ($LASTEXITCODE) { exit $LASTEXITCODE }
}
finally {
    Pop-Location
}

$shouldCleanUp = !$SaveInputs
if ($shouldCleanUp) {
    Remove-Item $tempFolder -Recurse -Force
}
exit 0
