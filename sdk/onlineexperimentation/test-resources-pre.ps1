# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# IMPORTANT: Do not invoke this file directly. Please instead run eng/New-TestResources.ps1 from the repository root.

#Requires -Version 6.0
#Requires -PSEdition Core

# Use same parameter names as declared in eng/New-TestResources.ps1 (assume validation therein).
[CmdletBinding(SupportsShouldProcess = $true, ConfirmImpact = 'Medium')]
param (
    [Parameter(Mandatory = $true)]
    [string] $SubscriptionId,

    [Parameter()]
    [string] $BaseName,

    # Captures any arguments from eng/New-TestResources.ps1 not declared here (no parameter errors).
    [Parameter(ValueFromRemainingArguments = $true)]
    $RemainingArguments
)

# If the App Configuration store is in a soft-deleted state the ARM deployment fails with error code NameUnavailable.
Write-Output "Checking for App Configuration store named $BaseName-* is in soft-deleted state..."
$appConfigSoftDeleted = Get-AzAppConfigurationDeletedStore -ErrorAction SilentlyContinue | Where-Object Name -like "$BaseName-*";
if ($appConfigSoftDeleted) {
    Write-Output "Purging App Configuration store '$($appConfigSoftDeleted.Name)'..."
    $appConfigSoftDeleted | Clear-AzAppConfigurationDeletedStore;
}
else {
    Write-Output "No soft-deleted App Configuration stores with name $BaseName-* detected."
}

Write-Output "Checking for KeyVaults $BaseName-* is in soft-deleted state..."
$keyVaultSoftDeleted = Get-AzKeyVault -InRemovedState -ErrorAction SilentlyContinue | Where-Object VaultName -like "$BaseName-*";
if ($keyVaultSoftDeleted) {
    if ($keyVaultSoftDeleted.EnablePurgeProtection) {
        Write-Output "KeyVault '$($keyVaultSoftDeleted.VaultName)' is purge-protected, deployment will use createMode='recover'."
        $templateFileParameters['keyVaultIsSoftDeleted'] = $true;
    }
    else {
        Write-Output "Purging KeyVault '$($keyVaultSoftDeleted.VaultName)'..."
        $keyVaultSoftDeleted | Remove-AzKeyVault -Force;
    }
}
else {
    Write-Output "No soft-deleted KeyVaults with name $BaseName-* detected."
}
