# # Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# IMPORTANT: Do not invoke this file directly. Please instead run eng/Remove-TestResources.ps1 from the repository root.

#Requires -Version 6.0
#Requires -PSEdition Core

# Use same parameter names as declared in eng/Remove-TestResources.ps1 (assume validation therein).
[CmdletBinding(SupportsShouldProcess = $true, ConfirmImpact = 'Medium')]
param (
    [Parameter(Mandatory = $true)]
    [string] $ResourceGroupName,

    
    [ValidateNotNullOrEmpty()]
    [string] $TenantId,

    [ValidatePattern('^[0-9a-f]{8}(-[0-9a-f]{4}){3}-[0-9a-f]{12}$')]
    [string] $SubscriptionId,

    [ValidatePattern('^[0-9a-f]{8}(-[0-9a-f]{4}){3}-[0-9a-f]{12}$')]
    [string] $ProvisionerApplicationId,

    [Parameter(ParameterSetName = 'ResourceGroup+Provisioner', Mandatory = $true)]
    [string] $ProvisionerApplicationSecret,

    # Captures any arguments from eng/Remove-TestResources.ps1 not declared here (no parameter errors).
    [Parameter(ValueFromRemainingArguments = $true)]
    $RemainingArguments
)

function Log($Message) {
    Write-Host ('{0} - {1}' -f [DateTime]::Now.ToLongTimeString(), $Message)
}

Log "Logging into service principal '$ProvisionerApplicationId'"

az login --service-principal -u $ProvisionerApplicationId -p $ProvisionerApplicationSecret --tenant $TenantId
az account set --subscription $SubscriptionId

Log "Running pre removal script for resource group $ResourceGroupName"

$adtInstanceName = az rest --method get --uri "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.DigitalTwins/digitalTwinsInstances?api-version=2020-03-01-preview" --query "value[*].{Name:name}" --output tsv

if (![string]::IsNullOrWhiteSpace($adtInstanceName)) {
    Write-Verbose "remove-test-resources-pre.ps1: Deleting configured endpoint on '$adtInstanceName' ADT instance to avoid issues during deletion of '$ResourceGroupName' resource group"
    az rest --method delete --uri "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.DigitalTwins/digitalTwinsInstances/$adtInstanceName/endpoints/someEventHubEndpoint?api-version=2020-03-01-preview"
}

az logout