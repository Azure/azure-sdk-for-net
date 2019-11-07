# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

<#
  .SYNOPSIS
    Performs the tasks needed to setup an Azure subscription for use with the Event Hubs client
    library test suite.

  .DESCRIPTION
    This script handles creation and configuration of needed resources within an Azure subscription
    for use with the Event Hubs client library's Live test suite.  
    
    Upon completion, the script will output a set of environment variables with sensitive information which
    are used for testing.  When running Live tests, please be sure to have these environment variables available,
    either within Visual Studio or command line environment.
 
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
  DisplayHelp $Defaults
  exit 0
}

ValidateParameters -ServicePrincipalName $servicePrincipalName -AzureRegion $azureRegion
$subscription = GetSubscriptionAndSetAzureContext -SubscriptionName $subscriptionName
CreateResourceGroupIfMissing -ResourceGroupName $resourceGroupName

# At this point, we may have created a resource, so be safe and allow for removing any
# resources created should the script fail.

try 
{
    Start-Sleep 1

    $credentials = GenerateRandomCredentials               
    $principal = CreateServicePrincipalAndWait -ServicePrincipalName "$($ServicePrincipalName)" -Credentials $credentials
    
    Write-Host "`t...Assigning the 'Contributor' role to resource group"
    
    AssignRole -ApplicationId "$($principal.ApplicationId)" `
               -RoleDefinitionName "Contributor" `
               -ResourceGroupName "$($ResourceGroupName)"

    Write-Host "`t...Assigning the 'Azure Event Hubs Data Owner' role to resource group"
            
    # The "Azure Event Hubs Data Owner" role is needed to test the Azure Identity samples. 
    # These samples do not use a "Shared Access Signatures" as a means of authentication
    # and authorization and rely on role-based access control to authorize users, for example, to send events to one of the hubs.

    AssignRole -ApplicationId "$($principal.ApplicationId)" `
               -RoleDefinitionName "Azure Event Hubs Data Owner" `
               -ResourceGroupName "$($ResourceGroupName)"

    # Write the environment variables.

    Write-Host "Done."
    Write-Host ""
    Write-Host ""
    Write-Host "EVENT_HUBS_RESOURCEGROUP=$($ResourceGroupName)"
    Write-Host ""
    Write-Host "EVENT_HUBS_SUBSCRIPTION=$($subscription.SubscriptionId)"
    Write-Host ""
    Write-Host "EVENT_HUBS_TENANT=$($subscription.TenantId)"
    Write-Host ""
    Write-Host "EVENT_HUBS_CLIENT=$($principal.ApplicationId)"
    Write-Host ""
    Write-Host "EVENT_HUBS_SECRET=$($credentials.Password)"
    Write-Host ""
}
catch 
{
    Write-Error $_.Exception.Message
    TearDownResources -ResourceGroupName $ResourceGroupName
    exit -1
}
