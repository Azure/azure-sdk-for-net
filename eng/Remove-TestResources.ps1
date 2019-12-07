#!/usr/bin/env pwsh

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

#Requires -Version 6.0
#Requires -PSEdition Core
#Requires -Modules @{ModuleName='Az.Resources'; ModuleVersion='1.8.0'}

[CmdletBinding(SupportsShouldProcess = $true, ConfirmImpact = 'Medium')]
param (
    [Parameter(Mandatory = $true, Position = 0)]
    [string] $BaseName,

    [Parameter()]
    [switch] $Force
)

# By default stop for any error.
if (!$PSBoundParameters.ContainsKey('ErrorAction')) {
    $ErrorActionPreference = 'Stop'
}

function Log($Message) {
    Write-Host ('{0} - {1}' -f [DateTime]::Now.ToLongTimeString(), $Message)
}

Log "Deleting resource group '${BaseName}rg'"
if (Remove-AzResourceGroup -Name "${BaseName}rg" -Force:$Force) {
    Write-Verbose "Successfully deleted resource group '${BaseName}rg'"
}
