[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ProjectDirectory
)

$ErrorActionPreference = "Stop"
. $PSScriptRoot/../common/scripts/Helpers/PSModule-Helpers.ps1
Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module

$cadlConfigurationFile = Resolve-Path "$ProjectDirectory/src/cadl-location.yaml"

Write-Host "Reading configuration from $cadlConfigurationFile"
$configuration = Get-Content -Path $cadlConfigurationFile -Raw | ConvertFrom-Yaml

$specSubDirectory = $configuration["directory"]
$innerFolder = Split-Path $specSubDirectory -Leaf

$tempFolder = "$ProjectDirectory/TempCadlFiles"

try {
    Push-Location $tempFolder/$innerFolder
    Write-Host("npx cadl compile --emit `"`@azure-tools/cadl-csharp`" --output-path `"$ProjectDirectory/src/Generated`" --option @azure-tools/cadl-csharp.clear-output-folder=true `"$tempFolder/$innerFolder`"")
    npx cadl compile --emit "@azure-tools/cadl-csharp" --output-path "$ProjectDirectory/src/Generated" --option @azure-tools/cadl-csharp.clear-output-folder=true "$tempFolder/$innerFolder"
}
finally {
    Pop-Location
}

$shouldCleanUp = $configuration["cleanup"] ?? $true
if ($shouldCleanUp) {
    Remove-Item $tempFolder -Recurse -Force
}