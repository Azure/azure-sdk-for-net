# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

<#
  .SYNOPSIS
    Performs the tasks needed to setup a service principal to perform authentication against 
    Azure Active Directory and sets the roles needed to access Event Hubs resources.

    It creates an Azure Event Hub Namespace and an Azure Event Hub using the specified names.

  .DESCRIPTION
    This script handles creation of a service principal and assigns the role 
    "Azure Event Hubs Data Owner" to the resource group whose name is passed in.

    The script attempts creation of an Azure Event Hubs Namespace and an Azure Event Hub
    using the names passed in as arguments.
    
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
  Write-Host "Creation of an Azure Active Directory Service Principal"
  Write-Host ""
  Write-Host "$($indent)This script handles creation of a service principal and assigns the role"
  Write-Host "$($indent)'Azure Event Hubs Data Owner' to the resource group name passed as input."
  Write-Host ""
  Write-Host "$($indent)The script attempts creation of an Azure Event Hubs Namespace and an Azure Event Hub"
  Write-Host "$($indent)using the names passed in as arguments."
  Write-Host ""
  Write-Host "$($indent)Upon completion, the script will output the principal's sensitive information."
  Write-Host ""
  Write-Host "$($indent)NOTE: Some of these values, such as the client secret, are difficult to recover; please copy them and keep in a"
  Write-Host "$($indent)safe place."
  Write-Host ""
  Write-Host ""
  Write-Host "$($indent)Available Parameters:"
  Write-Host ""
  Write-Host "$($indent)-Help`t`t`tDisplays this message."
  Write-Host ""

  Write-Host "$($indent)-SubscriptionName`t`tRequired.  The name of the Azure subscription used."
  Write-Host ""

  Write-Host "$($indent)-ResourceGroupName`t`tRequired.  The name of the Azure Resource Group that contains the resources."
  Write-Host ""

  Write-Host "$($indent)-NamespaceName`t`tRequired.  The name of the Azure Event Hubs Namespace."
  Write-Host ""

  Write-Host "$($indent)-EventHubName`t`tRequired.  The name of the Azure Event Hub."
  Write-Host ""

  Write-Host "$($indent)-ServicePrincipalName`tRequired.  The name to use for the service principal that will be created."
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

# Disallow principal names with a space.

if ($ServicePrincipalName.Contains(" "))
{
    Write-Error "The principal name may not contain spaces."
    exit -1
}

if ([String]::IsNullOrEmpty($AzureRegion))
{
    $AzureRegion = "southcentralus"
}

$isValidLocation = (IsValidEventHubRegion -AzureRegion "$($AzureRegion)")

if (!$isValidLocation)
{
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
    $createResourceGroup = $true
}

if ($createResourceGroup)
{
    Write-Host "`t...Creating new resource group"
    $resourceGroup = (New-AzResourceGroup -Name "$($ResourceGroupName)" -Location "$($AzureRegion)")
}

if ($resourceGroup -eq $null)
{
    Write-Error "Unable to locate the resource group: $($ResourceGroupName)"
    exit -1
}

# At this point, we may have created a resource, so be safe and allow for removing any
# resources created should the script fail.

try
{
    # Tries to retrieve the Namespace
    Write-Host "`t...Requesting namespace"

    $nameSpace = (Get-AzEventHubNamespace -ResourceGroupName $ResourceGroupName -NamespaceName $NamespaceName -ErrorAction SilentlyContinue)

    if ($nameSpace -eq $null)
    {
        # Creates the Namespace if does not exist
        Write-Host "`t...Creating new namespace"
        
        New-AzEventHubNamespace -ResourceGroupName $ResourceGroupName -NamespaceName $NamespaceName -Location $AzureRegion | Out-Null
    }

    # Tries to retrieve the EventHub
    Write-Host "`t...Requesting EventHub"

    $eventHub = (Get-AzEventHub -ResourceGroupName $ResourceGroupName -NamespaceName $NamespaceName -EventHubName $EventHubName -ErrorAction SilentlyContinue)

    if ($eventHub -eq $null)
    {
        # Creates the Event Hub if does not exist
        Write-Host "`t...Creating new EventHub"

        New-AzEventHub -ResourceGroupName $ResourceGroupName -NamespaceName $NamespaceName -EventHubName $EventHubName | Out-Null
    } 

    # Create the service principal and grant 'Azure Event Hubs Data Owner' access in the event hubs.
    Start-Sleep 1

    $credentials = New-Object Microsoft.Azure.Commands.ActiveDirectory.PSADPasswordCredential -Property @{StartDate=Get-Date; EndDate=Get-Date -Year 2099; Password="$(GenerateRandomPassword)"}                 

    $principal = (CreateServicePrincipal -ServicePrincipalName "$($ServicePrincipalName)" -Credentials $credentials)

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
        New-AzRoleAssignment -ApplicationId "$($principal.ApplicationId)" -RoleDefinitionName "Azure Event Hubs Data Owner" -ResourceName "$($NamespaceName)" -ResourceType "Microsoft.EventHub/namespaces" -ResourceGroupName "$($ResourceGroupName)" | Out-Null
    }
    catch 
    {
        Write-Host "`t...Still waiting for identity propagation (this will take a moment)"
        Start-Sleep 60
        New-AzRoleAssignment -ApplicationId "$($principal.ApplicationId)" -RoleDefinitionName "Azure Event Hubs Data Owner" -ResourceName "$($NamespaceName)" -ResourceType "Microsoft.EventHub/namespaces" -ResourceGroupName "$($ResourceGroupName)" | Out-Null
        
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
    (TearDownResources -ResourceGroupName $ResourceGroupName)
    exit -1
}
