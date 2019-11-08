# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

using namespace Microsoft.Azure.Commands.EventHub.Models
using namespace System.Uri

function CreateNamespaceIfMissing()
{
  <#
    .SYNOPSIS
      It tries to retrieve the specified namespace.
      It creates one if it may not be found.
  #>

  param
  (
    [Parameter(Mandatory=$true)]
    [string] $resourceGroupName,

    [Parameter(Mandatory=$true)]
    [string] $namespaceName,

    [Parameter(Mandatory=$true)]  
    [string] $azureRegion
  )

  # Tries to retrieve the Namespace
  Write-Host "`t...Requesting namespace"

  $nameSpace = Get-AzEventHubNamespace -ResourceGroupName "$($resourceGroupName)" `
                                       -NamespaceName "$($namespaceName)" `
                                       -ErrorAction SilentlyContinue

  if ($nameSpace -eq $null)
  {
      # Creates the Namespace if does not exist
      Write-Host "`t...Creating new namespace"
      
      New-AzEventHubNamespace -ResourceGroupName "$($resourceGroupName)" `
                              -NamespaceName "$($namespaceName)" `
                              -Location "$($azureRegion)" | Out-Null
  }
}

function CreateHubIfMissing()
{
  <#
    .SYNOPSIS
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

      New-AzEventHub -ResourceGroupName $resourceGroupName `
                     -NamespaceName $namespaceName `
                     -EventHubName $eventHubName | Out-Null
  } 
}

function GetFullyQualifiedDomainName()
{
  <#
    .SYNOPSIS
      It takes an access key as input.
      It returns the fully qualified domain name (FQDN).

    .DESCRIPTION
      It returns the fully qualified domain name.
      It does that using the "System.Uri" namespace.

      https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string
  #>
  
  param
  (
    [Parameter(Mandatory=$true)]
    [string] $resourceGroupName,

    [Parameter(Mandatory=$true)]
    [string] $namespaceName
  )

  Write-Host "`t...Retrieving fully qualified domain name"

  $nameSpace = Get-AzEventHubNamespace -ResourceGroupName "$($resourceGroupName)" -NamespaceName "$($namespaceName)"

  if($null -eq $nameSpace)
  {
    Write-Error "`t...Could not retrieve the service bus endpoint associated with the namespace"

    return -1
  }

  $serviceBusEndpoint = $namespace.ServiceBusEndpoint

  if($null -eq $serviceBusEndpoint)
  {
    Write-Error "`t...Could not retrieve the service bus endpoint associated with the namespace"

    return -1
  }

  return ([System.Uri]$serviceBusEndpoint).Host
}

function GetRootManageSharedAccessKey()
{
  <#
    .SYNOPSIS
      It returns the access keys connected to a namespace.

    .DESCRIPTION
      It calls Get-AzEventHubKey and returns the RootManageSharedAccessKey.
  #>
  
  param
  (
    [Parameter(Mandatory=$true)]
    [string] $resourceGroupName,

    [Parameter(Mandatory=$true)]
    [string] $namespaceName
  )

  Write-Host "`t...Retrieving primary connection string"
  
  $keys = Get-AzEventHubKey -ResourceGroupName "$($resourceGroupName)" `
                            -NamespaceName "$($namespaceName)" `
                            -AuthorizationRuleName "RootManageSharedAccessKey"
  
  return $keys.PrimaryConnectionString
}

function GetNamespaceInformation()
{
  <#
    .SYNOPSIS
      It returns the access keys connected to a namespace.
      It returns the fully qualified domain name (FQDN).

    .DESCRIPTION
      It returns the access keys by calling 'GetRootManageSharedAccessKey'.
      It returns the fully qualified domain name (FQDN) by calling 'GetFullyQualifiedDomainName'.

      It aggregates the values into a single anonymous object.
  #>

  param
  (
    [Parameter(Mandatory=$true)]
    [string] $resourceGroupName,
    
    [Parameter(Mandatory=$true)]
    [string] $namespaceName
  )

  return [pscustomobject] @{
    FullyQualifiedDomainName = (GetFullyQualifiedDomainName -ResourceGroupName "$($resourceGroupName)" -NamespaceName "$($namespaceName)");
    PrimaryConnectionString = (GetRootManageSharedAccessKey -ResourceGroupName "$($resourceGroupName)" -NamespaceName "$($namespaceName)");
  }
}