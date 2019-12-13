#!/usr/bin/env pwsh

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

#Requires -Version 6.0
#Requires -PSEdition Core
#Requires -Modules @{ModuleName='Az.Accounts'; ModuleVersion='1.6.4'}
#Requires -Modules @{ModuleName='Az.Resources'; ModuleVersion='1.8.0'}

[CmdletBinding(DefaultParameterSetName = 'Default', SupportsShouldProcess = $true, ConfirmImpact = 'Medium')]
param (
    # Limit $BaseName to enough characters to be under limit plus prefixes, and https://docs.microsoft.com/azure/architecture/best-practices/resource-naming.
    [Parameter(ParameterSetName = 'Default', Mandatory = $true, Position = 0)]
    [Parameter(ParameterSetName = 'Default+Provisioner', Mandatory = $true, Position = 0)]
    [ValidatePattern('^[-a-zA-Z0-9\.\(\)_]{0,80}(?<=[a-zA-Z0-9\(\)])$')]
    [string] $BaseName,

    # TODO: When https://github.com/Azure/azure-sdk-for-net/issues/9061 is resolved, default this to previously saved data.
    [Parameter(ParameterSetName = 'Default', Mandatory = $true)]
    [Parameter(ParameterSetName = 'Default+Provisioner', Mandatory = $true)]
    [string] $ServiceDirectory,

    [Parameter(ParameterSetName = 'ResourceGroup', Mandatory = $true)]
    [Parameter(ParameterSetName = 'ResourceGroup+Provisioner', Mandatory = $true)]
    [string] $ResourceGroupName,

    [Parameter(ParameterSetName = 'Default+Provisioner', Mandatory = $true)]
    [Parameter(ParameterSetName = 'ResourceGroup+Provisioner', Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string] $TenantId,

    [Parameter(ParameterSetName = 'Default+Provisioner', Mandatory = $true)]
    [Parameter(ParameterSetName = 'ResourceGroup+Provisioner', Mandatory = $true)]
    [ValidatePattern('^[0-9a-f]{8}(-[0-9a-f]{4}){3}-[0-9a-f]{12}$')]
    [string] $ProvisionerApplicationId,

    [Parameter(ParameterSetName = 'Default+Provisioner', Mandatory = $true)]
    [Parameter(ParameterSetName = 'ResourceGroup+Provisioner', Mandatory = $true)]
    [string] $ProvisionerApplicationSecret,

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

# Support actions to invoke on exit.
$exitActions = @({
    if ($exitActions.Count -gt 1) {
        Write-Verbose 'Running registered exit actions.'
    }
})

trap {
    # Like using try..finally in PowerShell, but without keeping track of more braces or tabbing content.
    $exitActions.Invoke()
}

if ($ProvisionerApplicationId) {
    $null = Disable-AzContextAutosave -Scope Process

    Log "Logging into service principal '$ProvisionerApplicationId'"
    $provisionerSecret = ConvertTo-SecureString -String $ProvisionerApplicationSecret -AsPlainText -Force
    $provisionerCredential = [System.Management.Automation.PSCredential]::new($ProvisionerApplicationId, $provisionerSecret)
    $provisionerAccount = Connect-AzAccount -Tenant $TenantId -Credential $provisionerCredential -ServicePrincipal

    $exitActions += {
        Write-Verbose "Logging out of service principal '$($provisionerAccount.Context.Account)'"
        $null = Disconnect-AzAccount -AzureContext $provisionerAccount.Context
    }
}

if (!$ResourceGroupName) {
    # Format the resource group name based on resource group naming recommendations and limitations.
    $ResourceGroupName = "rg-{0}-$baseName" -f ($ServiceDirectory -replace '[\\\/]', '-').Substring(0, [Math]::Min($ServiceDirectory.Length, 90 - $BaseName.Length - 4)).Trim('-')
}

Log "Deleting resource group '${ResourceGroupName}'"
if (Remove-AzResourceGroup -Name "${ResourceGroupName}" -Force:$Force) {
    Write-Verbose "Successfully deleted resource group '${ResourceGroupName}'"
}

$exitActions.Invoke()

<#
.SYNOPSIS
Deletes the resource group deployed for a service directory from Azure.

.DESCRIPTION
Removes a resource group and all its resources previously deployed for the specified $ServiceDirectory using New-TestResources.ps1. The $ServiceDirectory must match the previously specified value, e.g. 'keyvault' as shown in examples.

If you are not currently logged into an account in the Az PowerShell module, you will be asked to log in with Connect-AzAccount. Alternatively, you (or a build pipeline) can pass $ProvisionerApplicationId and $ProvisionerApplicationSecret to authenticate a service principal with access to create resources.

.PARAMETER BaseName
A name to use in the resource group and passed to the ARM template as 'baseName'.

.PARAMETER ServiceDirectory
A directory under 'sdk' in the repository root - optionally with subdirectories specified - in which to discover ARM templates named 'test-resources.json'.

.PARAMETER ResourceGroupName
The name of the resource group to delete.

.PARAMETER TenantId
The tenant ID of a service principal when a provisioner is specified.

.PARAMETER ProvisionerApplicationId
A service principal ID to provision test resources when a provisioner is specified.

.PARAMETER ProvisionerApplicationSecret
A service principal secret (password) to provision test resources when a provisioner is specified.

.PARAMETER NoProvisionerAutoSave
Do not save credentials for the provisioner in the current process.

.PARAMETER Force
Force creation of resources instead of being prompted.

.EXAMPLE
./Remove-Template.ps1 -BaseName uuid123 -ServiceDirectory keyvault -Force

Use the currently logged-in account to delete the resource group provisioned by the sdk/keyvault/test-resources.json ARM template.

.LINK
Remove-TestResources.ps1
#>
