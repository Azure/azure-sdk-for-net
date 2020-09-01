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
# == Function Imports ==
# ==========================

. .\functions\azure-resource-functions.ps1

function DisplayHelp
{
  <#
    .SYNOPSIS
      Displays the usage help text.

    .DESCRIPTION
      Displays the help text for usage.

    .OUTPUTS
      Help text for usage to the console window.
  #>

  $indent = "    "

  Write-Host "`n"
  Write-Host "Event Hubs Live Test Environment Setup"
  Write-Host ""
  Write-Host "$($indent)This script handles creation and configuration of needed resources within an Azure subscription"
  Write-Host "$($indent)for use with the Event Hubs client library Live test suite."
  Write-Host ""
  Write-Host "$($indent)Upon completion, the script will output a set of environment variables with sensitive information which"
  Write-Host "$($indent)are used for testing.  When running Live tests, please be sure to have these environment variables available,"
  Write-Host "$($indent)either within Visual Studio or command line environment."
  Write-Host ""
  Write-Host "$($indent)NOTE: Some of these values, such as the client secret, are difficult to recover; please copy them and keep in a"
  Write-Host "$($indent)safe place."
  Write-Host ""
  Write-Host ""
  Write-Host "$($indent)Available Parameters:"
  Write-Host ""
  Write-Host "$($indent)-Help`t`t`tDisplays this message."
  Write-Host ""

  Write-Host "$($indent)-SubscriptionName`t`tRequired.  The name of the Azure subscription to be used for"
  Write-Host "$($indent)`t`t`t`trunning the Live tests."
  Write-Host ""
    
  Write-Host "$($indent)-ResourceGroupName`t`tRequired.  The name of the Azure Resource Group that will contain the resources"
  Write-Host "$($indent)`t`t`t`tused for the tests.  This will be created if it does not exist."
  Write-Host ""

  Write-Host "$($indent)-ServicePrincipalName`tRequired.  The name to use for the service principal that will"
  Write-Host "$($indent)`t`t`t`tbe created to manage the Event Hub instances dynamically for the tests.  This"
  Write-Host "$($indent)`t`t`t`tprincipal must not already exist."
  Write-Host ""

  Write-Host "$($indent)-AzureRegion`t`tThe Azure region that resources should be created in.  This value should be"
  Write-Host "$($indent)`t`t`t`tthe name of the region, in lowercase, with no spaces.  For example: southcentralus"
  Write-Host ""
  Write-Host "$($indent)`t`t`t`tDefault: South Central US (southcentralus)"
  Write-Host ""  
}

# ====================
# == Script Actions ==
# ====================

if ($Help)
{
  DisplayHelp $Defaults
  exit 0
}

if ([string]::IsNullOrEmpty($azureRegion)) 
{
  $azureRegion = "southcentralus"
}

ValidateParameters -ServicePrincipalName "$($servicePrincipalName)" -AzureRegion "$($azureRegion)"
$subscription = GetSubscriptionAndSetAzureContext -SubscriptionName "$($subscriptionName)"
$wasResourceGroupCreated = CreateResourceGroupIfMissing -ResourceGroupName "$($resourceGroupName)" -AzureRegion "$($azureRegion)"

# At this point, we may have created a resource, so be safe and allow for removing any
# resources created should the script fail.

try 
{
    Start-Sleep 1

    $credentials = GenerateRandomCredentials               
    $principal = CreateServicePrincipalAndWait -ServicePrincipalName "$($servicePrincipalName)" -Credentials $credentials

    AssignRole -ApplicationId "$($principal.ApplicationId)" `
               -RoleDefinitionName "Contributor" `
               -ResourceGroupName "$($resourceGroupName)"

    # The "Azure Event Hubs Data Owner" role is needed to test the Azure Identity samples. 
    # These samples do not use a "Shared Access Signatures" as a means of authentication
    # and authorization and rely on role-based access control to authorize users, for example, to send events to one of the hubs.

    AssignRole -ApplicationId "$($principal.ApplicationId)" `
               -RoleDefinitionName "Azure Event Hubs Data Owner" `
               -ResourceGroupName "$($resourceGroupName)"

    # Write the environment variables.

    Write-Host "Done."
    Write-Host ""
    Write-Host ""
    Write-Host "EVENTHUB_RESOURCE_GROUP=$($resourceGroupName)"
    Write-Host ""
    Write-Host "EVENTHUB_SUBSCRIPTION_ID=$($subscription.SubscriptionId)"
    Write-Host ""
    Write-Host "EVENTHUB_TENANT_ID=$($subscription.TenantId)"
    Write-Host ""
    Write-Host "EVENTHUB_CLIENT_ID=$($principal.ApplicationId)"
    Write-Host ""
    Write-Host "EVENTHUB_CLIENT_SECRET=$($credentials.Password)"
    Write-Host ""
}
catch
{
    Write-Error $_.Exception.Message
    TearDownResources -ResourceGroupName "$($resourceGroupName)" `
                      -WasResourceGroupCreated $wasResourceGroupCreated
    exit -1
}
