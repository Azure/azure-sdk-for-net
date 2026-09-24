<#
.SYNOPSIS
    Generates an Azure.Provisioning package from its tsp-location.yaml file.

.EXAMPLE
    .\Generate-ProvisioningLibrary.ps1 `
        -PackagePath sdk\appnetwork\Azure.Provisioning.AppNetwork
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string]$PackagePath
)

$ErrorActionPreference = "Stop"
$PackagePath = (Resolve-Path $PackagePath).Path
$LocationPath = Join-Path $PackagePath "tsp-location.yaml"
$SourcePath = Join-Path $PackagePath "src"

if (-not (Test-Path $LocationPath)) {
    throw "Could not find tsp-location.yaml under $PackagePath"
}

$location = Get-Content $LocationPath -Raw
if ($location -notmatch "(?m)^repo:\s*Azure/azure-rest-api-specs\s*$") {
    throw "tsp-location.yaml must use Azure/azure-rest-api-specs"
}

if ($location -notmatch "(?m)^commit:\s*[0-9a-f]{40}\s*$") {
    throw "tsp-location.yaml must contain a full 40-character spec commit"
}

Push-Location $SourcePath
try {
    & dotnet build /t:GenerateCode
    if ($LASTEXITCODE -ne 0) {
        throw "Provisioning SDK generation failed"
    }
}
finally {
    Pop-Location
}
