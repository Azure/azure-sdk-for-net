# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

using namespace Microsoft.Azure.Commands.ActiveDirectory

function TearDownResources 
{
  <#
    .SYNOPSIS
      Cleans up any Azure resources created by the script.
      
    .DESCRIPTION
      Responsible for cleaning up any Azure resources created 
      by the script in case of failure.
  #>
    
  param
  (
    [Parameter(Mandatory=$true)]
    [string] $resourceGroupName
  )
    
  Write-Host("Cleaning up resources that were created:")
    
  try 
  {
    Write-Host "`t...Removing resource group `"$($resourceGroupName)`""
    Remove-AzResourceGroup -Name "$($resourceGroupName)" -Force | Out-Null
  }
  catch 
  {
    Write-Error "The resource group: $($resourceGroupName) could not be removed.  You will need to delete this manually."
    Write-Error ""            
    Write-Error $_.Exception.Message
  }
}

function CreateServicePrincipalAndWait 
{
  <#
    .SYNOPSIS
      Creates a service principal on Azure Active Directory
      
    .DESCRIPTION
      Creates a service principal on Azure Active Directory
      with the specified name and credentials.

      It waits 60 seconds to allow the principal to be made available
      on Azure Active Directory for Role Base Access Control.
  #>

  param
  (
    [Parameter(Mandatory=$true)]
    [string] $servicePrincipalName,

    [Parameter(Mandatory=$true)]
    [PSADPasswordCredential] $credentials
  )

  Write-Host "`t...Creating new service principal"
  Start-Sleep 1

  $principal = New-AzADServicePrincipal -DisplayName "$($servicePrincipalName)" `
                                        -PasswordCredential $credentials `
                                        -ErrorAction SilentlyContinue

  if ($principal -eq $null)
  {
      Write-Error "Unable to create the service principal: $($ServicePrincipalName)"
      exit -1
  }
    
  Write-Host "`t...Waiting for identity propagation"

  Start-Sleep 60

  return $principal
}


function GetSubscriptionAndSetAzureContext
{
  <#
    .SYNOPSIS
      Get an Azure Subscription and sets the context using it.
      
    .DESCRIPTION
      Tries getting an Azure Subscription by name.
      It raises an error if not found. It sets the context 
      using its information otherwise.
  #>

  param
  (
    [Parameter(Mandatory=$true)]
    [string] $subscriptionName
  )

  # Capture the subscription.  The cmdlet will error if there was no subscription, 
  # so no need to validate.
  
  Write-Host ""
  Write-Host "Working:"
  Write-Host "`t...Requesting subscription"
  $subscription = Get-AzSubscription -SubscriptionName "$($SubscriptionName)" -ErrorAction SilentlyContinue
  
  if ($subscription -eq $null)
  {
      Write-Error "Unable to locate the requested Azure subscription: $($SubscriptionName)"
      exit -1
  }
  
  Set-AzContext -SubscriptionId "$($subscription.Id)" -Scope "Process" | Out-Null

  return $subscription
}

function CreateResourceGroupIfMissing()
{
  <#
    .SYNOPSIS
      It tries to retrieve the specified resource group.
      It creates if it may not be found.
      
    .DESCRIPTION
      It tries to retrieve the specified resource group.
      It creates if it may not be found.
  #>

  param
  (
    [Parameter(Mandatory=$true)]
    [string] $resourceGroupName,

    [Parameter(Mandatory=$true)]  
    [string] $azureRegion
  )

  # Create the resource group, if needed.

  Write-Host "`t...Requesting resource group"

  $createResourceGroup = $false
  $resourceGroup = (Get-AzResourceGroup -ResourceGroupName "$($resourceGroupName)" -ErrorAction SilentlyContinue)

  if ($resourceGroup -eq $null)
  {
      $createResourceGroup = $true
  }

  if ($createResourceGroup)
  {
      Write-Host "`t...Creating new resource group"
      $resourceGroup = (New-AzResourceGroup -Name "$($resourceGroupName)" -Location "$($azureRegion)")
  }

  if ($resourceGroup -eq $null)
  {
      Write-Error "Unable to locate or create the resource group: $($resourceGroupName)"
      exit -1
  }
}
