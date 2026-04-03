# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# IMPORTANT: Do not invoke this file directly. Please instead run eng/New-TestResources.ps1 from the repository root.

# Use same parameter names as declared in eng/New-TestResources.ps1 (assume validation therein).
[CmdletBinding(SupportsShouldProcess = $true, ConfirmImpact = 'Medium')]
param (
    [Parameter()]
    [string] $TestApplicationOid,

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

# Resolve the principal display name from the current context to use as the
# PostgreSQL Entra ID administrator.  The test framework provides the OID but
# the PostgreSQL admin resource requires a display name / UPN.

if ($CI) {
    # In CI the test application is a service principal.  Look up its display name.
    Log "Resolving service principal display name for OID '$TestApplicationOid'"
    $sp = Get-AzADServicePrincipal -ObjectId $TestApplicationOid
    $principalName = $sp.DisplayName
    $principalType = 'ServicePrincipal'
    Log "Resolved service principal name: '$principalName'"
} else {
    # Running locally — use the signed-in user's UPN.
    $principalName = (Get-AzContext).Account.Id
    $principalType = 'User'
    Log "Using signed-in user principal name: '$principalName'"
}

$templateFileParameters['principalName'] = $principalName
$templateFileParameters['principalType'] = $principalType
