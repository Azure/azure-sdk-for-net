# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

<#
  .SYNOPSIS
    Performs the tasks needed to setup an Azure subscription for use with the Event Hubs client
    library test suite.

  .DESCRIPTION
    This script handles the creation and configuration of needed resources within an Azure subscription
    for use with the Event Hubs client library's Live test suite.  
    
    Upon completion, the script will output a set of environment variables with sensitive information which
    is used for testing.  When running Live tests, please be sure to have these environment variables available,
    either within Visual Studio or command-line environment.
 
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
  $AzureRegion = $null
)

# =====================
# == Module Imports  ==
# =====================

Import-Module Az.Resources

# ==========================
# == Function Definitions ==
# ==========================

. .\functions\azure-principal-functions.ps1

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
  Write-Host "$($indent)This script handles the creation and configuration of needed resources within an Azure subscription"
  Write-Host "$($indent)for use with the Event Hubs client library Live test suite."
  Write-Host ""
  Write-Host "$($indent)Upon completion, the script will output a set of environment variables with sensitive information which"
  Write-Host "$($indent)is used for testing.  When running Live tests, please be sure to have these environment variables available,"
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

# Create the resource group, if needed.

Write-Host "`t...Requesting resource group"

$createResourceGroup = $false
$resourceGroup = (Get-AzResourceGroup -ResourceGroupName "$($ResourceGroupName)" -ErrorAction SilentlyContinue)

if ($resourceGroup -eq $null)
{
    $createResourceGroup = $true
}

if ($createResourceGroup)
{
    Write-Host "`t...Creating new resource group"
    $resourceGroup = (New-AzResourceGroup -Name "$($ResourceGroupName)" -Location "$($AzureRegion)")
}

if ($resourceGroup -eq $null)
{
    Write-Error "Unable to locate or create the resource group: $($ResourceGroupName)"
    exit -1
}

# At this point, we may have created a resource, so be safe and allow for removing any
# resources created should the script fail.

try 
{
    # Create the service principal and grant contributor access for management in the resource group.

    Start-Sleep 1

    $credentials = New-Object Microsoft.Azure.Commands.ActiveDirectory.PSADPasswordCredential -Property @{StartDate=Get-Date; EndDate=Get-Date -Year 2099; Password="$(GenerateRandomPassword)"}                 

    $principal = (CreateServicePrincipal -Role "Contributor" -ServicePrincipalName "$($ServicePrincipalName)" -Credentials $Credentials -ResourceGroupName "$($ResourceGroupName)")

    if ($principal -eq $null)
    {
        Write-Error "Unable to create the service principal: $($ServicePrincipalName)"
        exit -1
    }   

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
    TearDownResources $createResourceGroup
    exit -1
}
