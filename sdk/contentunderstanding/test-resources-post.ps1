# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# This script is used to deploy model deployments to the Foundry resources after the main ARM template deployment.
# It is invoked by the New-TestResources.ps1 script after the ARM template is finished being deployed.
# The ARM template creates the Foundry resources, and this script deploys the required models.
# After model deployments are complete, it calls the Content Understanding UpdateDefaults API to configure
# the default model deployment mappings.

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

# Get endpoints from deployment outputs
$sourceEndpoint = $DeploymentOutputs['CONTENTUNDERSTANDING_ENDPOINT']
$targetEndpoint = $DeploymentOutputs['CONTENTUNDERSTANDING_TARGET_ENDPOINT']

if (-not $sourceEndpoint) {
    Write-Error "CONTENTUNDERSTANDING_ENDPOINT not found in deployment outputs"
    exit 1
}

if (-not $targetEndpoint) {
    Write-Error "CONTENTUNDERSTANDING_TARGET_ENDPOINT not found in deployment outputs"
    exit 1
}

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

# Function to wait for a deployment to be ready (provisioning state = Succeeded)
# Returns $true if deployment is ready, $false if timeout or failed
function Wait-ForDeployment {
    param (
        [string] $ResourceGroupName,
        [string] $AccountName,
        [string] $DeploymentName,
        [int] $MaxWaitMinutes = 15,
        [int] $PollIntervalSeconds = 30
    )

    Write-Host "Waiting for deployment '$DeploymentName' to be ready..."
    $startTime = Get-Date
    $maxWaitTime = $startTime.AddMinutes($MaxWaitMinutes)

    while ((Get-Date) -lt $maxWaitTime) {
        try {
            $deploymentJson = az cognitiveservices account deployment show `
                --resource-group $ResourceGroupName `
                --name $AccountName `
                --deployment-name $DeploymentName `
                --output json 2>&1

            if ($LASTEXITCODE -eq 0) {
                $deployment = $deploymentJson | ConvertFrom-Json
                $provisioningState = $deployment.properties.provisioningState

                if ($provisioningState -eq 'Succeeded') {
                    Write-Host "Deployment '$DeploymentName' is ready (Status: $provisioningState)" -ForegroundColor Green
                    return $true
                }
                elseif ($provisioningState -eq 'Failed') {
                    Write-Error "Deployment '$DeploymentName' failed" -ErrorAction Continue
                    return $false
                }
                else {
                    Write-Host "Deployment '$DeploymentName' status: $provisioningState (waiting...)"
                }
            }
            else {
                Write-Host "Could not check deployment status, will retry..."
            }
        }
        catch {
            Write-Host "Error checking deployment status: $_, will retry..."
        }

        Start-Sleep -Seconds $PollIntervalSeconds
    }

    Write-Warning "Timeout waiting for deployment '$DeploymentName' to be ready after $MaxWaitMinutes minutes"
    return $false
}

# Function to call Content Understanding UpdateDefaults API using az rest
# Returns $true if successful, $false if failed
function Update-ContentUnderstandingDefaults {
    param (
        [string] $Endpoint,
        [string] $AccountName,
        [hashtable] $ModelDeployments
    )

    Write-Host "Updating Content Understanding defaults for account '$AccountName'..."

    try {
        # Build the request body JSON
        # Format: { "modelDeployments": { "gpt-4.1": "gpt-4.1", "gpt-4.1-mini": "gpt-4.1-mini", "text-embedding-3-large": "text-embedding-3-large" } }
        $modelDeploymentsJson = @{}
        foreach ($kvp in $ModelDeployments.GetEnumerator()) {
            $modelDeploymentsJson[$kvp.Key] = $kvp.Value
        }
        $requestBody = @{
            modelDeployments = $modelDeploymentsJson
        } | ConvertTo-Json -Depth 10 -Compress

        # Call UpdateDefaults API using az rest
        # Endpoint: {endpoint}/contentunderstanding/defaults?api-version=2025-11-01
        # Method: PATCH
        # Content-Type: application/merge-patch+json
        # Note: az rest will automatically determine the resource from the URL for known endpoints
        $apiUrl = "$($Endpoint.TrimEnd('/'))/contentunderstanding/defaults?api-version=2025-11-01"

        Write-Host "Calling UpdateDefaults API: $apiUrl"
        Write-Host "Request body: $requestBody"

        # Use the Cognitive Services resource URL for authentication
        # For Azure Cognitive Services, the resource identifier is https://cognitiveservices.azure.com
        $resourceUrl = "https://cognitiveservices.azure.com"

        $response = az rest --method patch `
            --url $apiUrl `
            --resource $resourceUrl `
            --headers "Content-Type=application/merge-patch+json" `
            --body $requestBody `
            --output json 2>&1

        if ($LASTEXITCODE -eq 0) {
            $result = $response | ConvertFrom-Json
            Write-Host "Successfully updated Content Understanding defaults for '$AccountName'" -ForegroundColor Green
            if ($result.modelDeployments) {
                Write-Host "Configured model deployments:"
                foreach ($kvp in $result.modelDeployments.PSObject.Properties) {
                    Write-Host "  $($kvp.Name): $($kvp.Value)"
                }
            }
            return $true
        }
        else {
            Write-Error "FAILED to update Content Understanding defaults for '$AccountName': $response" -ErrorAction Continue
            return $false
        }
    }
    catch {
        Write-Error "FAILED to update Content Understanding defaults for '$AccountName': $_" -ErrorAction Continue
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

# Wait for deployments to be ready before calling UpdateDefaults
Write-Host ""
Write-Host "Waiting for model deployments to be ready before updating Content Understanding defaults..." -ForegroundColor Cyan

$allDeploymentsReady = $true

# Wait for source resource deployments
Write-Host "Checking source resource deployments..."
foreach ($model in $modelConfigs) {
    $isReady = Wait-ForDeployment `
        -ResourceGroupName $ResourceGroupName `
        -AccountName $sourceAccountName `
        -DeploymentName $model.Name `
        -MaxWaitMinutes 15 `
        -PollIntervalSeconds 30
    if (-not $isReady) {
        $allDeploymentsReady = $false
    }
}

# Wait for target resource deployments
Write-Host "Checking target resource deployments..."
foreach ($model in $modelConfigs) {
    $isReady = Wait-ForDeployment `
        -ResourceGroupName $ResourceGroupName `
        -AccountName $targetAccountName `
        -DeploymentName $model.Name `
        -MaxWaitMinutes 15 `
        -PollIntervalSeconds 30
    if (-not $isReady) {
        $allDeploymentsReady = $false
    }
}

if ($allDeploymentsReady) {
    Write-Host ""
    Write-Host "All deployments are ready. Updating Content Understanding defaults..." -ForegroundColor Cyan

    # Build model deployments mapping (model name -> deployment name)
    # The deployment name is the same as the model name in our configuration
    $modelDeployments = @{
        'gpt-4.1' = 'gpt-4.1'
        'gpt-4.1-mini' = 'gpt-4.1-mini'
        'text-embedding-3-large' = 'text-embedding-3-large'
    }

    # Update defaults for source resource
    $updateSourceResult = Update-ContentUnderstandingDefaults `
        -Endpoint $sourceEndpoint `
        -AccountName $sourceAccountName `
        -ModelDeployments $modelDeployments

    # Update defaults for target resource
    $updateTargetResult = Update-ContentUnderstandingDefaults `
        -Endpoint $targetEndpoint `
        -AccountName $targetAccountName `
        -ModelDeployments $modelDeployments

    if ($updateSourceResult -and $updateTargetResult) {
        Write-Host ""
        Write-Host "Content Understanding defaults updated successfully for both resources!" -ForegroundColor Green
    }
    else {
        Write-Host ""
        Write-Warning "Some UpdateDefaults calls may have failed. Check the error messages above."
    }
}
else {
    Write-Host ""
    Write-Warning "Not all deployments are ready. Skipping UpdateDefaults API call."
    Write-Warning "You may need to manually call UpdateDefaults after deployments are ready."
}

