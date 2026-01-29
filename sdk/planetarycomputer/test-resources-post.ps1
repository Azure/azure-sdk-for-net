# Post-deployment script to generate SAS token
# This runs automatically after test-resources.bicep deployment

param(
    [hashtable] $DeploymentOutputs,
    [string] $ResourceGroupName
)

$ErrorActionPreference = 'Stop'

Write-Host "Running post-deployment script to generate SAS token..." -ForegroundColor Yellow

# Get the storage account name from deployment outputs
$storageAccountName = $DeploymentOutputs['PLANETARYCOMPUTER_STORAGE_ACCOUNT_NAME']
$containerName = $DeploymentOutputs['PLANETARYCOMPUTER_CONTAINER_NAME']

if (-not $storageAccountName) {
    Write-Host "Storage account name not found in deployment outputs" -ForegroundColor Red
    return
}

Write-Host "Storage Account: $storageAccountName"
Write-Host "Container: $containerName"

# Generate SAS token with 1 year expiration
$startTime = Get-Date
$expiryTime = $startTime.AddYears(1)

Write-Host "Generating SAS token (valid until: $($expiryTime.ToString('yyyy-MM-dd')))" -ForegroundColor Yellow

# Get storage account key
$keys = az storage account keys list `
    --account-name $storageAccountName `
    --resource-group $ResourceGroupName `
    --output json | ConvertFrom-Json

$accountKey = $keys[0].value

# Generate container-level SAS token
$sasToken = az storage container generate-sas `
    --account-name $storageAccountName `
    --account-key $accountKey `
    --name $containerName `
    --permissions rl `
    --start $startTime.ToString('yyyy-MM-ddTHH:mm:ssZ') `
    --expiry $expiryTime.ToString('yyyy-MM-ddTHH:mm:ssZ') `
    --output tsv

if ($sasToken) {
    # Add the SAS token to DeploymentOutputs so it gets written to .bicep.env
    $DeploymentOutputs['PLANETARYCOMPUTER_INGESTION_SAS_TOKEN'] = $sasToken

    Write-Host "SAS token generated successfully" -ForegroundColor Green
    Write-Host "PLANETARYCOMPUTER_INGESTION_SAS_TOKEN=[REDACTED]" -ForegroundColor Green
} else {
    Write-Host "Failed to generate SAS token" -ForegroundColor Red
}
