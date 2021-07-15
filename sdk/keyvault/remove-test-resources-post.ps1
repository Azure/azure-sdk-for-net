# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# IMPORTANT: Do not invoke this file directly. Please instead run eng/common/TestResources/Remove-TestResources.ps1 from the repository root.

# Use same parameter names as declared in eng/New-TestResources.ps1 (assume validation therein).
[CmdletBinding(SupportsShouldProcess = $true, ConfirmImpact = 'Medium')]
param (
    [Parameter()]
    [ValidatePattern('^[-a-zA-Z0-9\.\(\)_]{0,80}(?<=[a-zA-Z0-9\(\)])$')]
    [string] $BaseName,

    [Parameter()]
    [switch] $CI,

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

$managedHSM = $env:AZURE_MANAGEDHSM_URL
if (!$managedHSM -and !$CI) {
    # This should match what is in test-resources.json.
    $managedHSM = "${BaseName}hsm"
}

if ($managedHSM) {
    # Ignore if the managed HSM was not deployed in the first place.
    Log "Purging Managed HSM '$managedHSM'"
    Remove-AzKeyVaultManagedHsm -Name $managedHSM -InRemovedState -Force -ErrorAction:Continue
    if (!$? -and !$CI) {
        Write-Warning "Managed HSM '$managedHSM' was not found in a deleted state. If you know an HSM was deployed, please be sure to purge it manually."
    }
}
