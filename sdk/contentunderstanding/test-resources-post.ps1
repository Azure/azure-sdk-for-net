# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# This script is used to deploy model deployments to the Foundry resources after the main ARM template deployment.
# It is invoked by the New-TestResources.ps1 script after the ARM template is finished being deployed.
# The ARM template creates the Foundry resources, and this script deploys the required models.

param (
    [hashtable] $DeploymentOutputs,
    [string] $ResourceGroupName
)

# Get resource IDs from deployment outputs
$sourceResourceId = $DeploymentOutputs['AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID']
$targetResourceId = $DeploymentOutputs['AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID']

if (-not $sourceResourceId) {
    Write-Error "AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID not found in deployment outputs"
    exit 1
}

if (-not $targetResourceId) {
    Write-Error "AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID not found in deployment outputs"
    exit 1
}

# Extract account names from resource IDs
# Format: /subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.CognitiveServices/accounts/{accountName}
$sourceAccountName = $sourceResourceId -replace '^.*/accounts/', ''
$targetAccountName = $targetResourceId -replace '^.*/accounts/', ''

Write-Host "Deploying models to source Foundry resource: $sourceAccountName"
Write-Host "Deploying models to target Foundry resource: $targetAccountName"

# Model deployment configurations
# Note: Model versions and SKUs are verified to work with Azure AI Foundry
$modelConfigs = @(
    @{
        Name = 'gpt-4.1'
        ModelName = 'gpt-4.1'
        Format = 'OpenAI'
        Version = '2025-04-14'  # Verified: correct version for gpt-4.1
        SkuName = 'Standard'
        SkuCapacity = 150  # Rate limit: 150,000 tokens per minute
    },
    @{
        Name = 'gpt-4.1-mini'
        ModelName = 'gpt-4.1-mini'
        Format = 'OpenAI'
        Version = '2025-04-14'  # Verified: correct version for gpt-4.1-mini
        SkuName = 'Standard'
        SkuCapacity = 150  # Rate limit: 150,000 tokens per minute
    },
    @{
        Name = 'text-embedding-3-large'
        ModelName = 'text-embedding-3-large'
        Format = 'OpenAI'
        Version = '1'
        SkuName = 'GlobalStandard'  # Verified: embedding models require GlobalStandard SKU, not Standard
        SkuCapacity = 150  # Rate limit: 120,000 tokens per minute
    }
)

# Function to deploy a model using Azure CLI
# Returns $true if successful, $false if failed
function Deploy-Model {
    param (
        [string] $ResourceGroupName,
        [string] $AccountName,
        [string] $DeploymentName,
        [string] $ModelName,
        [string] $ModelFormat,
        [string] $ModelVersion,
        [string] $SkuName,
        [int] $SkuCapacity
    )

    Write-Host "Deploying model '$ModelName' as deployment '$DeploymentName' to account '$AccountName'..."

    try {
        # Check if deployment already exists
        $null = az cognitiveservices account deployment show `
            --resource-group $ResourceGroupName `
            --name $AccountName `
            --deployment-name $DeploymentName `
            2>&1

        if ($LASTEXITCODE -eq 0) {
            Write-Host "Deployment '$DeploymentName' already exists, skipping..."
            return $true
        }

        # Build Azure CLI command arguments
        $azArgs = @(
            'cognitiveservices', 'account', 'deployment', 'create',
            '--resource-group', $ResourceGroupName,
            '--name', $AccountName,
            '--deployment-name', $DeploymentName,
            '--model-format', $ModelFormat,
            '--model-name', $ModelName,
            '--model-version', $ModelVersion,
            '--output', 'json'
        )

        # Add SKU parameters only if specified
        if ($SkuName) {
            $azArgs += '--sku-name', $SkuName
        }
        if ($SkuCapacity -gt 0) {
            $azArgs += '--sku-capacity', $SkuCapacity.ToString()
        }

        # Create deployment using Azure CLI
        # Note: Azure CLI requires individual parameters, not a JSON body
        # Note: --rai-policy-name and --version-upgrade-option are not supported in current Azure CLI version
        $deploymentJson = & az $azArgs 2>&1

        if ($LASTEXITCODE -eq 0) {
            $deployment = $deploymentJson | ConvertFrom-Json
            Write-Host "Successfully deployed '$DeploymentName' (Status: $($deployment.properties.provisioningState))" -ForegroundColor Green
            return $true
        }
        else {
            Write-Error "FAILED to deploy '$DeploymentName': $deploymentJson" -ErrorAction Continue
            return $false
        }
    }
    catch {
        Write-Error "FAILED to deploy '$DeploymentName': $_" -ErrorAction Continue
        return $false
    }
}

# Deploy models to source resource
$deploymentCount = 0
$successCount = 0
$failedDeployments = @()

foreach ($model in $modelConfigs) {
    $deploymentCount++
    $result = Deploy-Model `
        -ResourceGroupName $ResourceGroupName `
        -AccountName $sourceAccountName `
        -DeploymentName $model.Name `
        -ModelName $model.ModelName `
        -ModelFormat $model.Format `
        -ModelVersion $model.Version `
        -SkuName $model.SkuName `
        -SkuCapacity $model.SkuCapacity
    if ($result) {
        $successCount++
    }
    else {
        $failedDeployments += "$($model.Name) on source account"
    }
}

# Deploy models to target resource
foreach ($model in $modelConfigs) {
    $deploymentCount++
    $result = Deploy-Model `
        -ResourceGroupName $ResourceGroupName `
        -AccountName $targetAccountName `
        -DeploymentName $model.Name `
        -ModelName $model.ModelName `
        -ModelFormat $model.Format `
        -ModelVersion $model.Version `
        -SkuName $model.SkuName `
        -SkuCapacity $model.SkuCapacity
    if ($result) {
        $successCount++
    }
    else {
        $failedDeployments += "$($model.Name) on target account"
    }
}

Write-Host ""
Write-Host "Model deployment script completed."
Write-Host "Attempted $deploymentCount deployments, $successCount succeeded, $($deploymentCount - $successCount) failed."
Write-Host ""
Write-Host "IMPORTANT: Model deployments may take 5-15 minutes to propagate to the Content Understanding API." -ForegroundColor Yellow
Write-Host "Even though deployments show 'Succeeded' in Azure Resource Manager, the Content Understanding" -ForegroundColor Yellow
Write-Host "API may not see them immediately. If tests fail with 'DeploymentIdNotFound', wait a few" -ForegroundColor Yellow
Write-Host "more minutes and retry the tests." -ForegroundColor Yellow

if ($successCount -lt $deploymentCount) {
    Write-Host ""
    Write-Error "FAILED deployments:" -ErrorAction Continue
    foreach ($failed in $failedDeployments) {
        Write-Error "  - $failed" -ErrorAction Continue
    }
    Write-Host ""
    Write-Host "Deployment failures may be expected if:" -ForegroundColor Yellow
    Write-Host "  - Models are not available in your region/subscription" -ForegroundColor Yellow
    Write-Host "  - Model names/versions are incorrect" -ForegroundColor Yellow
    Write-Host "  - SKU is not supported for the model in this region" -ForegroundColor Yellow
    Write-Host "Check the error messages above for specific details." -ForegroundColor Yellow
    Write-Host "You may need to update the model configurations in this script to match available models." -ForegroundColor Yellow
}

Write-Host ""
Write-Host "Note: Model deployments are asynchronous and may take 5-15 minutes to fully provision."
Write-Host "The deployments will be in 'Succeeded' state when ready for use."

