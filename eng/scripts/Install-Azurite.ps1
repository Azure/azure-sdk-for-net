<#
.DESCRIPTION

This script installs Azurite using npm to a specific location. It does not utilize the caching mechanism provided by azure devops.

#>
param (
    [Parameter(Mandatory = $true)]
    [string]$AzuriteLocation,
    [Parameter(Mandatory = $true)]
    [string]$AzuriteVersion
)

npm install --prefix $AzuriteLocation azurite@$AzuriteVersion

if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to install Azurite."
    exit $LASTEXITCODE
}

if ($env:TF_BUILD -or $env:CI) {
    Write-Output "##vso[task.setvariable variable=Azure.Azurite.Location]$AzuriteLocation"
}