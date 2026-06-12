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
$primaryResourceId = $DeploymentOutputs['CONTENTUNDERSTANDING_SOURCE_RESOURCE_ID']
$copyTargetResourceId = $DeploymentOutputs['CONTENTUNDERSTANDING_TARGET_RESOURCE_ID']

if (-not $primaryResourceId) {
    Write-Error "CONTENTUNDERSTANDING_SOURCE_RESOURCE_ID (Primary Microsoft Foundry resource ID) not found in deployment outputs"
    exit 1
}

if (-not $copyTargetResourceId) {
    Write-Error "CONTENTUNDERSTANDING_TARGET_RESOURCE_ID (Copy target Microsoft Foundry resource ID) not found in deployment outputs"
    exit 1
}

# Extract account names from resource IDs
# Format: /subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.CognitiveServices/accounts/{accountName}
$primaryAccountName = $primaryResourceId -replace '^.*/accounts/', ''
$copyTargetAccountName = $copyTargetResourceId -replace '^.*/accounts/', ''

# Get endpoints from deployment outputs
$primaryEndpoint = $DeploymentOutputs['CONTENTUNDERSTANDING_ENDPOINT']
$copyTargetEndpoint = $DeploymentOutputs['CONTENTUNDERSTANDING_TARGET_ENDPOINT']

if (-not $primaryEndpoint) {
    Write-Error "CONTENTUNDERSTANDING_ENDPOINT (Primary Microsoft Foundry endpoint) not found in deployment outputs"
    exit 1
}

if (-not $copyTargetEndpoint) {
    Write-Error "CONTENTUNDERSTANDING_TARGET_ENDPOINT (Copy target Microsoft Foundry endpoint) not found in deployment outputs"
    exit 1
}

Write-Host "Deploying models to Primary Microsoft Foundry resource: $primaryAccountName"
Write-Host "Deploying models to copy target Foundry resource: $copyTargetAccountName"

# Model deployment configurations
$modelConfigs = @(
    @{
        Name = 'gpt-4.1'
        ModelName = 'gpt-4.1'
        Format = 'OpenAI'
        Version = '2025-04-14'
        SkuName = 'Standard'
        SkuCapacity = 150  # Rate limit: 150,000 tokens per minute
    },
    @{
        Name = 'gpt-4.1-mini'
        ModelName = 'gpt-4.1-mini'
        Format = 'OpenAI'
        Version = '2025-04-14'
        SkuName = 'Standard'
        SkuCapacity = 150  # Rate limit: 150,000 tokens per minute
    },
    @{
        Name = 'text-embedding-3-large'
        ModelName = 'text-embedding-3-large'
        Format = 'OpenAI'
        Version = '1'
        SkuName = 'GlobalStandard'
        SkuCapacity = 100  # Rate limit: 100,000 tokens per minute
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
# Retries on DeploymentIdNotFound errors to handle propagation delay
function Update-ContentUnderstandingDefaults {
    param (
        [string] $Endpoint,
        [string] $AccountName,
        [hashtable] $ModelDeployments,
        [int] $MaxRetries = 10,
        [int] $RetryDelaySeconds = 30
    )

    Write-Host "Updating Content Understanding defaults for account '$AccountName'..."

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

    # Use the Cognitive Services resource URL for authentication
    # For Azure Cognitive Services, the resource identifier is https://cognitiveservices.azure.com
    $resourceUrl = "https://cognitiveservices.azure.com"

    $attempt = 0
    while ($attempt -lt $MaxRetries) {
        $attempt++

        if ($attempt -gt 1) {
            Write-Host "Retry attempt $attempt of $MaxRetries (waiting $RetryDelaySeconds seconds for deployment propagation)..."
            Start-Sleep -Seconds $RetryDelaySeconds
        }
        else {
            Write-Host "Calling UpdateDefaults API: $apiUrl"
            Write-Host "Request body: $requestBody"
        }

        try {
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
                # Check if the error is DeploymentIdNotFound (propagation delay)
                $errorMessage = $response -join " "
                if ($errorMessage -match "DeploymentIdNotFound") {
                    if ($attempt -lt $MaxRetries) {
                        Write-Host "Deployment not yet visible to Content Understanding API (attempt $attempt/$MaxRetries). This is normal due to propagation delay." -ForegroundColor Yellow
                        continue
                    }
                    else {
                        Write-Error "FAILED to update Content Understanding defaults for '$AccountName' after $MaxRetries attempts: Deployment still not visible to API after waiting. $errorMessage" -ErrorAction Continue
                        return $false
                    }
                }
                else {
                    # Non-propagation error - don't retry
                    Write-Error "FAILED to update Content Understanding defaults for '$AccountName': $errorMessage" -ErrorAction Continue
                    return $false
                }
            }
        }
        catch {
            Write-Error "FAILED to update Content Understanding defaults for '$AccountName': $_" -ErrorAction Continue
            return $false
        }
    }

    return $false
}

# Deploy models to Primary Microsoft Foundry resource
foreach ($model in $modelConfigs) {
    $result = Deploy-Model `
        -ResourceGroupName $ResourceGroupName `
        -AccountName $primaryAccountName `
        -DeploymentName $model.Name `
        -ModelName $model.ModelName `
        -ModelFormat $model.Format `
        -ModelVersion $model.Version `
        -SkuName $model.SkuName `
        -SkuCapacity $model.SkuCapacity
    if (-not $result) {
        Write-Error "Failed to deploy '$($model.Name)' to Primary Microsoft Foundry resource. Exiting." -ErrorAction Stop
        exit 1
    }
}

# Deploy models to copy target resource
foreach ($model in $modelConfigs) {
    $result = Deploy-Model `
        -ResourceGroupName $ResourceGroupName `
        -AccountName $copyTargetAccountName `
        -DeploymentName $model.Name `
        -ModelName $model.ModelName `
        -ModelFormat $model.Format `
        -ModelVersion $model.Version `
        -SkuName $model.SkuName `
        -SkuCapacity $model.SkuCapacity
    if (-not $result) {
        Write-Error "Failed to deploy '$($model.Name)' to copy target resource. Exiting." -ErrorAction Stop
        exit 1
    }
}

Write-Host ""
Write-Host "Model deployment script completed successfully." -ForegroundColor Green
Write-Host ""
Write-Host "IMPORTANT: Model deployments may take 5-15 minutes to propagate to the Content Understanding API." -ForegroundColor Yellow
Write-Host "Even though deployments show 'Succeeded' in Azure Resource Manager, the Content Understanding" -ForegroundColor Yellow
Write-Host "API may not see them immediately. If tests fail with 'DeploymentIdNotFound', wait a few" -ForegroundColor Yellow
Write-Host "more minutes and retry the tests." -ForegroundColor Yellow

# Wait for deployments to be ready before calling UpdateDefaults
Write-Host ""
Write-Host "Waiting for model deployments to be ready before updating Content Understanding defaults..." -ForegroundColor Cyan

$allDeploymentsReady = $true

# Wait for Primary Microsoft Foundry resource deployments
Write-Host "Checking Primary Microsoft Foundry resource deployments..."
foreach ($model in $modelConfigs) {
    $isReady = Wait-ForDeployment `
        -ResourceGroupName $ResourceGroupName `
        -AccountName $primaryAccountName `
        -DeploymentName $model.Name `
        -MaxWaitMinutes 15 `
        -PollIntervalSeconds 30
    if (-not $isReady) {
        $allDeploymentsReady = $false
    }
}

# Wait for copy target resource deployments
Write-Host "Checking copy target resource deployments..."
foreach ($model in $modelConfigs) {
    $isReady = Wait-ForDeployment `
        -ResourceGroupName $ResourceGroupName `
        -AccountName $copyTargetAccountName `
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
    $modelDeployments = @{}
    foreach ($model in $modelConfigs) {
        if ($null -ne $model.Name -and -not [string]::IsNullOrWhiteSpace([string]$model.Name)) {
            $modelDeployments[$model.Name] = $model.Name
        }
    }

    # Update defaults for Primary Microsoft Foundry resource
    $updatePrimaryResult = Update-ContentUnderstandingDefaults `
        -Endpoint $primaryEndpoint `
        -AccountName $primaryAccountName `
        -ModelDeployments $modelDeployments

    # Update defaults for copy target resource
    $updateCopyTargetResult = Update-ContentUnderstandingDefaults `
        -Endpoint $copyTargetEndpoint `
        -AccountName $copyTargetAccountName `
        -ModelDeployments $modelDeployments

    if ($updatePrimaryResult -and $updateCopyTargetResult) {
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

