# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

<#
  .SYNOPSIS
    Performs the tasks needed to setup a service principal to perform authentication against 
    Azure Active Directory and sets the roles needed to access Event Hubs resources.

  .DESCRIPTION
    This script handles creation of a service principal and assigns the role 
    "Azure Event Hubs Data Owner" to the resource group name passed as input.
    
    Upon completion, the script will output the principal information.
 
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
  [string] $ServicePrincipalName
)

# =====================
# == Module Imports  ==
# =====================

Import-Module Az.Resources

# ==========================
# == Function Definitions ==
# ==========================

. .\functions\functions.ps1

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
  Write-Host "Creation of an Azure Active Directory Service Principal"
  Write-Host ""
  Write-Host "$($indent)This script handles creation of a service principal and assigns the role"
  Write-Host "$($indent)'Azure Event Hubs Data Owner' to the resource group name passed as input."
  Write-Host ""
  Write-Host "$($indent)Upon completion, the script will output the principal's sensitive information. "
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
  Write-Host "$($indent)`t`t`t`tused for the tests."
  Write-Host ""

  Write-Host "$($indent)-ServicePrincipalName`tRequired.  The name to use for the service principal that will be created"
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

# Disallow principal names with a space.

if ($ServicePrincipalName.Contains(" "))
{
    Write-Error "The principal name may not contain spaces."
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

# Tries to retrieve the resource group

Write-Host "`t...Requesting resource group"

$resourceGroup = (Get-AzResourceGroup -ResourceGroupName "$($ResourceGroupName)" -ErrorAction SilentlyContinue)

if ($resourceGroup -eq $null)
{
    Write-Error "Unable to locate the resource group: $($ResourceGroupName)"
    exit -1
}

# At this point, we may have created a resource, so be safe and allow for removing any
# resources created should the script fail.

try
{
    # Create the service principal and grant 'Azure Event Hubs Data Owner' access in the event hubs.
    Start-Sleep 1

    $credentials = New-Object Microsoft.Azure.Commands.ActiveDirectory.PSADPasswordCredential -Property @{StartDate=Get-Date; EndDate=Get-Date -Year 2099; Password="$(GenerateRandomPassword)"}                 

    $principal = (CreateServicePrincipal -ServicePrincipalName "$($ServicePrincipalName)" -Credentials $Credentials -ResourceGroupName "$($ResourceGroupName)" -Role "Azure Event Hubs Data Owner")

    if ($principal -eq $null)
    {
        Write-Error "Unable to create the service principal: $($ServicePrincipalName)"
        exit -1
    }

    Write-Host "Done."
    Write-Host ""
    Write-Host ""
    Write-Host "Client Id=$($principal.ApplicationId)"
    Write-Host ""
    Write-Host "Secret=$($credentials.Password)"
    Write-Host ""
}
catch 
{
    Write-Error $_.Exception.Message
    exit -1
}
