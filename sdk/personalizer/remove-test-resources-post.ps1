# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# IMPORTANT: Do not invoke this file directly. Please instead run eng/common/TestResources/Remove-TestResources.ps1 from the repository root.

#Requires -Version 6.0
#Requires -PSEdition Core

# Use same parameter names as declared in eng/common/TestResources/Remove-TestResources.ps1 (assume validation therein).
[CmdletBinding()]
param (
    [Parameter()]
    [string] $SubscriptionId,

    # Captures any arguments from eng/common/Remove-TestResources.ps1 not declared here (no parameter errors).
    [Parameter(ValueFromRemainingArguments = $true)]
    $RemainingArguments
)

# By default stop for any error.
if (!$PSBoundParameters.ContainsKey('ErrorAction')) {
    $ErrorActionPreference = 'Stop'
}

function Log($Message) {
    Write-Host ('{0} - {1}' -f [DateTime]::Now.ToLongTimeString(), $Message)
}

function GetSoftDeletedInstances($SubscriptionId) {
    Log "Getting soft deleted resources"
    Get-AzResource -ResourceId "/subscriptions/$SubscriptionId/providers/Microsoft.CognitiveServices/deletedAccounts" -ApiVersion 2021-04-30
}

function PurgePersonalizerInstance ($Resource) {
    # All deleted resources are of type Microsoft.CognitiveServices/locations/resourceGroups/deletedAccounts
    # The only way to identify the personalizer resorces to delete is by the resource group name which contains personalizer
    $resourceId = $Resource.ResourceId
    if ($resourceId -match "personalizer") {
        Log "Deleting Personalizer instance: '$($resourceId)'"
        Remove-AzResource -ResourceId $resourceId -Force
    }
}

Log "Permanently deleting all Personalizer instances"
GetSoftDeletedInstances -SubscriptionId $SubscriptionId | ForEach-Object { PurgePersonalizerInstance($_) }
