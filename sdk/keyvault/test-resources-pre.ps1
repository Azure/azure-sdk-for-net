# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# IMPORTANT: Do not invoke this file directly. Please instead run eng/New-TestResources.ps1 from the repository root.

#Requires -Version 6.0
#Requires -PSEdition Core
#Requires -Module @{ ModuleName = 'az.keyvault'; RequiredVersion = '3.0.0' }

# Use same parameter names as declared in eng/New-TestResources.ps1 (assume validation therein).
[CmdletBinding(SupportsShouldProcess = $true, ConfirmImpact = 'Medium')]
param (
    # BUGBUG: In CIs, the BaseName may be wrong. Need to fix https://github.com/Azure/azure-sdk-tools/issues/1177 first.
    [Parameter()]
    [string] $BaseName,

    # Keep in sync with default parameter value test-resources.json.
    [Parameter()]
    [string] $Location = 'westus2',

    # Captures any arguments from eng/New-TestResources.ps1 not declared here (no parameter errors).
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

Log "Checking for deleted Key Vault: $BaseName"
$deleted = Get-AzKeyVault -Name $BaseName -Location $Location -InRemovedState
if ($deleted) {
    Log "Removing deleted Key Vault: $BaseName"
    $deleted | Remove-AzKeyVault -InRemovedState -Force
}
