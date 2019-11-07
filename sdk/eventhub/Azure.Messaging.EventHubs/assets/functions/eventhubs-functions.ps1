# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

function CreateNamespaceIfMissing()
{
  <#
    .SYNOPSIS
      It tries to retrieve the specified namespace.
      It creates if it may not be found.
      
    .DESCRIPTION
      It tries to retrieve the specified namespace.
      It creates if it may not be found.
  #>

  param
  (
    [Parameter(Mandatory=$true)]
    [string] $resourceGroupName,

    [Parameter(Mandatory=$true)]
    [string] $namespaceName
  )

  # Tries to retrieve the Namespace
  Write-Host "`t...Requesting namespace"

  $nameSpace = Get-AzEventHubNamespace -ResourceGroupName $ResourceGroupName -NamespaceName $NamespaceName -ErrorAction SilentlyContinue

  if ($nameSpace -eq $null)
  {
      # Creates the Namespace if does not exist
      Write-Host "`t...Creating new namespace"
      
      New-AzEventHubNamespace -ResourceGroupName $ResourceGroupName -NamespaceName $NamespaceName -Location $AzureRegion | Out-Null
  }
}

function CreateHubIfMissing()
{
  <#
    .SYNOPSIS
      It tries to retrieve the specified namespace.
      It creates if it may not be found.
      
    .DESCRIPTION
      It tries to retrieve the specified namespace.
      It creates if it may not be found.
  #>

  param
  (
    [Parameter(Mandatory=$true)]
    [string] $resourceGroupName,

    [Parameter(Mandatory=$true)]
    [string] $namespaceName,

    [Parameter(Mandatory=$true)]
    [string] $eventHubName
  )

  Write-Host "`t...Requesting eventHub"
  
  $eventHub = Get-AzEventHub -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -EventHubName $eventHubName -ErrorAction SilentlyContinue

  if ($eventHub -eq $null)
  {
      # Creates the Event Hub if does not exist
      Write-Host "`t...Creating new eventHub"

      New-AzEventHub -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -EventHubName $eventHubName | Out-Null
  } 
}