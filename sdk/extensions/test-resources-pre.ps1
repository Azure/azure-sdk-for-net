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

    # Captures any arguments from eng/New-TestResources.ps1 not declared here (no parameter errors).
    [Parameter(ValueFromRemainingArguments = $true)]
    $RemainingArguments
)

Write-Output "Retrieving AD for test application with OID $TestApplicationOid ..."
$SP=Get-AzADServicePrincipal -ObjectId $TestApplicationOid
Write-Output "AAD database admin: $($SP.DisplayName) ..."
Write-Output "Get current IP address..."
$ipAddress = Invoke-RestMethod "http://whatismyip.akamai.com"
$templateFileParameters['testApplicationServicePrincipal']=$SP.DisplayName
$templateFileParameters['clientIpAddress']=$ipAddress
Write-Output "Generating random password for MySQL..."
$templateFileParameters['mysqlPassword']=-join ((97..122) | Get-Random -Count 10 | ForEach-Object {[char]$_})

