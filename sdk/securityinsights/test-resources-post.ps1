# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# IMPORTANT: Do not invoke this file directly. Please instead run eng/New-TestResources.ps1 from the repository root.

#Requires -Version 6.0
#Requires -PSEdition Core

# Use same parameter names as declared in eng/New-TestResources.ps1 (assume validation therein).
[CmdletBinding(SupportsShouldProcess = $true, ConfirmImpact = 'Medium')]
param (
    [Parameter(Mandatory = $true)]
    [string] $ResourceGroupName,

    [Parameter()]
    [string] $TestApplicationOid,

    [Parameter()]
    [hashtable] $DeploymentOutputs,

    # Captures any arguments from eng/New-TestResources.ps1 not declared here (no parameter errors).
    [Parameter(ValueFromRemainingArguments = $true)]
    $RemainingArguments
)

function Log($Message) {
    Write-Host ('{0} - {1}' -f [DateTime]::Now.ToLongTimeString(), $Message)
}

Write-Verbose "Example post-deployment script for Azure Security Insights in resource group '$ResourceGroupName' accessible to $TestApplicationOid."
if ($DeploymentOutputs) {
    $names = $DeploymentOutputs.Keys -join ', '
    Log "Output variable names: $names"
}

Add-Type -AssemblyName System.Web

#set variables
[string]$subscription = $DeploymentOutputs.AZURE_SECURITYINSIGHTS_SUBSCRIPTION
[string]$workspaceName = $DeploymentOutputs.AZURE_SECURITYINSIGHTS_WORKSPACE
[string]$AzureClientID = $DeploymentOutputs.AZURE_CLIENT_ID
[string]$AzureClientSecret = $DeploymentOutputs.AZURE_CLIENT_SECRET
[string]$AzureTenantId = $DeploymentOutputs.AZURE_TENANT_ID
[string]$AzureLocation = $DeploymentOutputs.AZURE_SECURITYINSIGHTS_LOCATION
[string]$Resource = "https://management.core.windows.net/"
[string] $url = "https://management.azure.com/subscriptions/$subscription/resourceGroups/$ResourceGroupName/providers/Microsoft.OperationsManagement/solutions/SecurityInsights($workspaceName)?api-version=2015-11-01-preview"

#Get Auth Token  and make headers
$encodedSecret = [System.Web.HttpUtility]::UrlEncode($AzureClientSecret)
$RequestAccessTokenUri = "https://login.microsoftonline.com/$AzureTenantId/oauth2/token"
$body = "grant_type=client_credentials&client_id=$AzureClientID&client_secret=$encodedSecret&resource=$Resource"
$contentType = 'application/x-www-form-urlencoded'
$authToken = Invoke-RestMethod -Method Post -Uri $RequestAccessTokenUri -Body $body -ContentType $contentType
$headers = @{ 'authorization' = "$($authToken.token_type) $($authToken.access_token) " }

#Build Body
$body = @{
    location = "$AzureLocation"
    properties = @{
        workspaceResourceId = "/subscriptions/$subscription/resourcegroups/$ResourceGroupName/providers/microsoft.operationalinsights/workspaces/$workspaceName"
    }
    plan = @{
        name = "SecurityInsights($workspaceName)"
        publisher = "Microsoft"
        product = "OMSGallery/SecurityInsights"
    }
}

#Make the call
Invoke-RestMethod -Method PUT -Uri $url -Body ($body | ConvertTo-Json) -Headers $headers

