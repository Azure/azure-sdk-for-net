# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

function AssignRole()
{
  <#
    .SYNOPSIS
      It tries to assign a role to an existing principal.

    .DESCRIPTION
      Using the principal and the resource passed as input,
      it tries to assign the specified role for the principal and the resource.
  #>

  param
  (
    [Parameter(Mandatory=$true)]
    [string] $applicationId,

    [Parameter(Mandatory=$true)]
    [string] $roleDefinitionName,

    [Parameter(Mandatory=$true)]
    [string] $resourceGroupName
  )

  # The propagation of the identity is non-deterministic.  Attempt to retry once after waiting for another minute if
  # the initial attempt fails.

  try 
  {
      Write-Host "`t...Assigning role '$roleDefinitionName' to resource group"

      New-AzRoleAssignment -ApplicationId "$($principal.ApplicationId)" `
                           -RoleDefinitionName "$($roleDefinitionName)" `
                           -ResourceGroupName "$($resourceGroupName)" | Out-Null
  }
  catch 
  {
      Write-Host "`t...Still waiting for identity propagation (this will take a moment)"
      Start-Sleep 60

      New-AzRoleAssignment -ApplicationId "$($principal.ApplicationId)" `
                           -RoleDefinitionName "$($roleDefinitionName)" `
                           -ResourceGroupName "$($resourceGroupName)" | Out-Null
      
      exit -1
  }    
}

function AssignRoleToNamespace()
{
  <#
    .SYNOPSIS
      It tries to assign a role to an existing principal and eventhubs namespace.
      
    .DESCRIPTION
      Using the principal and the resource passed as input,
      it tries to assign the specified role for the principal and the resource.

      It assigns the role to the named eventhubs namespace.
  #>

  param
  (
    [Parameter(Mandatory=$true)]
    [string] $applicationId,

    [Parameter(Mandatory=$true)]
    [string] $roleDefinitionName,

    [Parameter(Mandatory=$true)]
    [string] $resourceGroupName,

    [Parameter(Mandatory=$true)]
    [string] $namespaceName
  )

  try
  {
      Write-Host "`t...Assigning role '$roleDefinitionName' to namespace"

      New-AzRoleAssignment -ApplicationId "$($principal.ApplicationId)" `
                           -RoleDefinitionName "$($roleDefinitionName)" `
                           -ResourceGroupName "$($resourceGroupName)" `
                           -ResourceName "$($namespaceName)" `
                           -ResourceType "Microsoft.EventHub/namespaces" | Out-Null
  }
  catch 
  {
      Write-Host "`t...Still waiting for identity propagation (this will take a moment)"
      Start-Sleep 60

      New-AzRoleAssignment -ApplicationId "$($principal.ApplicationId)" `
                           -RoleDefinitionName "$($roleDefinitionName)" `
                           -ResourceGroupName "$($resourceGroupName)" `
                           -ResourceName "$($namespaceName)" `
                           -ResourceType "Microsoft.EventHub/namespaces" | Out-Null
      
      exit -1
  }    
}