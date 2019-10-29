# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

<#
  .SYNOPSIS
    Performs the tasks needed to setup a service principal to perform authentication against 
    Azure Active Directory and sets the roles needed to access Event Hubs's resources.

  .DESCRIPTION
    This script handles creation and configuration of a service principal and the role 
    "Azure Event Hubs Data Owner" to it.
    
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
  [string] $EventHubsName,

  [Parameter(Mandatory=$true, ParameterSetName="Execute")]
  [ValidateNotNullOrEmpty()]
  [ValidateScript({ $_.Length -ge 6})]
  [string] $ServicePrincipalName
)

# =====================
# == Module Imports  ==
# =====================

Import-Module Az.Resources

# ==========================
# == Function Definitions ==
# ==========================

. .\functions\live-tests-functions.ps1

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
  Write-Host "Event Hubs With Azure Identity Test Environment Setup"
  Write-Host ""
  Write-Host "$($indent)This script handles creation and configuration of needed resources within an Azure subscription"
  Write-Host "$($indent)for use with the Event Hubs client library Live test suite regarding authentication with Azure Active Directory"
  Write-Host "$($indent)and the Azure.Identity SDK."
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
    
  Write-Host "$($indent)-ResourceGroupName`t`tThe name of the Azure Resource Group that will contain the resources"
  Write-Host "$($indent)`t`t`t`tused for the tests.  This will be created if it does not exist."
  Write-Host ""
  Write-Host ""
    
  Write-Host "$($indent)-EventHubsName`t`tThe name of the Event Hubs that will be used for testings."
  Write-Host ""

  Write-Host "$($indent)-ServicePrincipalName`tThe name to use for the service principal that will"
  Write-Host "$($indent)`t`t`t`tbe created to manage the Event Hub instances dynamically for the tests.  This"
  Write-Host "$($indent)`t`t`t`tprincipal must not already exist."
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

if ([String]::IsNullOrEmpty($AzureRegion))
{
    $AzureRegion = "southcentralus"
}

# Disallow principal names with a space.

if ($ServicePrincipalName.Contains(" "))
{
    Write-Error "The principal name may not contain spaces."
    exit -1
}

# Verify the location is valid for an Event Hubs namespace.

$validLocations = @{}
Get-AzLocation | where { $_.Providers.Contains("Microsoft.EventHub")} | ForEach { $validLocations[$_.Location] = $_.Location }

if (!$validLocations.Contains($AzureRegion))
{
    Write-Error "The Azure region must be one of: `n$($validLocations.Keys -join ", ")`n`n" 
    exit -1
}

# Capture the subscription.  The cmdlet will error if there was no subscription, 
# so no need to validate.

Write-Host ""
Write-Host "Working:"
Write-Host "`t...Requesting subscription"
$subscription = (Get-AzSubscription -SubscriptionName "$($SubscriptionName)" -ErrorAction SilentlyContinue)

if ($subscription -eq $null)
{
    Write-Error "Unable to locate the requested Azure subscription: $($SubscriptionName)"
    exit -1
}

Set-AzContext -SubscriptionId "$($subscription.Id)" -Scope "Process" | Out-Null

# Tries to retrieve the resource group created with the script 'live-tests-azure-setup.ps1'

Write-Host "`t...Requesting resource group"

$resourceGroup = (Get-AzResourceGroup -ResourceGroupName "$($ResourceGroupName)" -ErrorAction SilentlyContinue)

if ($resourceGroup -eq $null)
{
    Write-Error "Unable to locate or create the resource group: $($ResourceGroupName)"
    exit -1
}

# At this point, we may have created a resource, so be safe and allow for removing any
# resources created should the script fail.

try 
{
    # Create the service principal and grant contributor access for management in the event hubs.

    Write-Host "`t...Creating new service principal for use with Azure.Identity"
    Start-Sleep 1

    $credentials = New-Object Microsoft.Azure.Commands.ActiveDirectory.PSADPasswordCredential -Property @{StartDate=Get-Date; EndDate=Get-Date -Year 2099; Password="$(GenerateRandomPassword)"}            
    $principal = (New-AzADServicePrincipal -DisplayName "$($ServicePrincipalName)" -PasswordCredential $credentials)

    if ($principal -eq $null)
    {
        Write-Error "Unable to create the service principal: $($ServicePrincipalName)"
        exit -1
    }
    
    Write-Host "`t...Assigning permissions (this will take a moment)"
    Start-Sleep 60

    # The propagation of the identity is non-deterministic.  Attempt to retry once after waiting for another minute if
    # the initial attempt fails.

    try 
    {
        New-AzRoleAssignment -ApplicationId "$($principal.ApplicationId)" -RoleDefinitionName "Azure Event Hubs Data Owner" -ResourceName "$($EventHubsName)" -ResourceType "Microsoft.EventHub/namespaces" -ResourceGroupName "$($ResourceGroupName)" | Out-Null
    }
    catch 
    {
        Write-Host "`t...Still waiting for identity propagation (this will take a moment)"
        Start-Sleep 60
        New-AzRoleAssignment -ApplicationId "$($principal.ApplicationId)" -RoleDefinitionName "Azure Event Hubs Data Owner" -ResourceName "$($EventHubsName)" -ResourceType "Microsoft.EventHub/namespaces" -ResourceGroupName "$($ResourceGroupName)" | Out-Null
    }    

    # Write the environment variables.

    Write-Host "Done."
    Write-Host ""
    Write-Host ""
    Write-Host "EVENT_HUBS_IDENTITY_CLIENT=$($principal.ApplicationId)"
    Write-Host ""
    Write-Host "EVENT_HUBS_IDENTITY_SECRET=$($credentials.Password)"
    Write-Host ""
}
catch 
{
    Write-Error $_.Exception.Message
    exit -1
}
