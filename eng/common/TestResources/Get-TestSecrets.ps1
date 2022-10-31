#!/usr/bin/env pwsh

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

#Requires -Version 6.0
#Requires -PSEdition Core
#Requires -Modules @{ModuleName='Az.Accounts'; ModuleVersion='1.6.4'}
#Requires -Modules @{ModuleName='Az.KeyVault'; ModuleVersion='4.6.0'}

[CmdletBinding()]
[OutputType([pscustomobject])]
param (
    [Parameter(Mandatory=$true, Position=0)]
    [string] $VaultName,

    [Parameter(Mandatory=$true, Position=1)]
    [string] $Name
)

# By default stop for any error.
if (!$PSBoundParameters.ContainsKey('ErrorAction')) {
    $ErrorActionPreference = 'Stop'
}

$secret = Get-AzKeyVaultSecret -VaultName:$VaultName -Name:$Name -ErrorAction SilentlyContinue -ErrorVariable err
if ($err) {
    if ($err.Exception.SocketErrorCode -eq 'HostNotFound') {
        Write-Error "Key Vault $VaultName not found. Use 'Set-AzContext -SubscriptionId {subscriptionId}' to select appropriate subscription."
        return
    }

    Write-Error -Exception:$err.Exception
    return
}

if (!$secret) {
    Write-Error "Secret $Name not found." -Category ObjectNotFound -TargetObject $Name
    return
}

$secretValue = $secret.SecretValue | ConvertFrom-SecureString -AsPlainText

# ConvertFrom-Json may throw and ignore -ea and -ev parameters.
try {
    $parameters = $secretValue | ConvertFrom-Json -AsHashtable -ErrorAction SilentlyContinue -ErrorVariable err
    if ($err) {
        throw $err
    }

    return [pscustomobject]$parameters
} catch {}

# Return the secret name and value as a hashtable.
[pscustomobject]@{$Name = $secretValue}

<#
.SYNOPSIS
Gets configuration secrets from Key Vault.

.DESCRIPTION
Gets configuration secrets from Key Vault and returns them as an object you can pass to `New-TestResources.ps` similar to what live test pipelines would do.
If the secret contains JSON-formatted data, it is parsed and returned as an object containing multiple properties.
If the secret does not contain JSON-formatted data, the passed-in name is returned as a custom property with the secret value as its value.

.PARAMETER VaultName
The name of the Key Vault containing secrets.

.PARAMETER Name
The name of the secret.

.EXAMPLE
$secretValue = @{
    SubscriptionId=$env:AZURE_SUBSCRIPTION_ID
    TestApplicationId=$env:AZURE_CLIENT_ID
    TestApplicationSecret=$env:AZURE_CLIENT_SECRET
    } `
    | ConvertTo-Json -Compress `
    | ConvertTo-SecureString -AsPlainText -Force
Set-AzKeyVaultSecret `
    -VaultName myvault `
    -Name mysecret `
    -SecretValue $secretValue
Get-TestSecrets.ps1 myvault mysecret `
    | New-TestResources.ps1 -ServiceDirectory myservice

Gets the contents of "mysecret" from "myvault" and passed them through to New-TestResources.ps1.
#>
