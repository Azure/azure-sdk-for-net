# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

<#
  .SYNOPSIS
    This script handles creation of the principal and the resources needed to run identity samples.

  .DESCRIPTION
    It tries to retrieve a resource group, an Azure Event Hubs Namespace and an Azure Event Hub
    using the names passed in as arguments. It attempts the creation of the resources if not found.

    It always tries to create the named service principal.
    
    It assigns the 'Azure Event Hubs Data Owner' role to the namespace.

    Upon completion, the script will output the principal's sensitive information and the parameters
    needed to run the samples.
 
    For more detailed help, please use the -Help switch. 
#>

# =======================
# == Script Parameters ==
# =======================

[CmdletBinding(DefaultParameterSetName="Help")] 
[OutputType([String])] 
param
( 
  [Parameter(Mandatory=$true, ParameterSetName="Help", Position=0)]
  [Switch] $Help,

  [Parameter(Mandatory=$true, ParameterSetName="Execute", Position=0)]
  [ValidateNotNullOrEmpty()]
  [string] $SubscriptionName,

  [Parameter(Mandatory=$true, ParameterSetName="Execute")]
  [ValidateNotNullOrEmpty()]
  [string] $ResourceGroupName,

  [Parameter(Mandatory=$true, ParameterSetName="Execute")]
  [ValidateNotNullOrEmpty()]
  [string] $NamespaceName,

  [Parameter(Mandatory=$true, ParameterSetName="Execute")]
  [ValidateNotNullOrEmpty()]
  [string] $EventHubName,

  [Parameter(Mandatory=$true, ParameterSetName="Execute")]
  [ValidateNotNullOrEmpty()]
  [ValidateScript({ $_.Length -ge 6})]
  [string] $ServicePrincipalName,

  [Parameter(Mandatory=$true, ParameterSetName="Execute")]
  [AllowNull()]  
  [string] $AzureRegion = $null
)

# =====================
# == Module Imports  ==
# =====================

Import-Module Az.Resources

# ==========================
# == Function Definitions ==
# ==========================

. .\functions\validation-functions.ps1
. .\functions\help-functions.ps1
. .\functions\credentials-functions.ps1
. .\functions\eventhubs-functions.ps1
. .\functions\resource-management-functions.ps1
. .\functions\role-assignment-functions.ps1

# ====================
# == Script Actions ==
# ====================

if ($Help)
{
  DisplayIdentityHelp $Defaults
  exit 0
}

if ([string]::IsNullOrEmpty($azureRegion)) 
{
  $azureRegion = "southcentralus"
}

ValidateParameters -ServicePrincipalName "$($servicePrincipalName)" -AzureRegion "$($azureRegion)"
$subscription = GetSubscriptionAndSetAzureContext -SubscriptionName "$($subscriptionName)"
CreateResourceGroupIfMissing -ResourceGroupName "$($resourceGroupName)" -AzureRegion "$($azureRegion)"

# At this point, we may have created a resource, so be safe and allow for removing any
# resources created should the script fail.

try
{
    Start-Sleep 1

    CreateNamespaceIfMissing -ResourceGroupName "$($resourceGroupName)" `
                             -NamespaceName "$($namespaceName)" `
                             -AzureRegion "$($azureRegion)"

    $namespaceInformation = GetNamespaceInformation -ResourceGroupName "$($resourceGroupName)" -NamespaceName "$($namespaceName)"

    CreateHubIfMissing -ResourceGroupName "$($resourceGroupName)" `
                       -NamespaceName "$($namespaceName)" `
                       -EventHubName "$($eventHubName)"

    # Create the service principal and grant 'Azure Event Hubs Data Owner' access in the event hubs.

    $credentials = GenerateRandomCredentials           
    $principal = CreateServicePrincipalAndWait -ServicePrincipalName "$($servicePrincipalName)" -Credentials $credentials

    AssignRoleToNamespace -ApplicationId "$($principal.ApplicationId)" `
                          -RoleDefinitionName "Azure Event Hubs Data Owner" `
                          -ResourceGroupName "$($resourceGroupName)" `
                          -NamespaceName "$($namespaceName)"

    Write-Host "Done."
    Write-Host ""
    Write-Host ""
    Write-Host "Connection-String=$($namespaceInformation.PrimaryConnectionString)"
    Write-Host ""
    Write-Host "FullyQualifiedNamespace=$($namespaceInformation.FullyQualifiedDomainName)"
    Write-Host ""
    Write-Host "EventHub Name=$($EventHubName)"
    Write-Host ""
    Write-Host "Tenant=$($subscription.TenantId)"
    Write-Host ""
    Write-Host "Client=$($principal.ApplicationId)"
    Write-Host ""
    Write-Host "Secret=$($credentials.Password)"
    Write-Host ""
}
catch 
{
    Write-Error $_.Exception.Message
    TearDownResources -ResourceGroupName $resourceGroupName
    exit -1
}
