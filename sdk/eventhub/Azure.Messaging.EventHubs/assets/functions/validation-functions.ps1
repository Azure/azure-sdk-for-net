# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

function ValidateParameters() 
{
  <#
    .SYNOPSIS
      Checks if a region provides Azure Event Hubs
      
    .DESCRIPTION
      Lists all the regions that provide Azure Event Hubs
      and looks for the one passed in as a parameter. It returns 
      true if found or false otherwise. It outputs an error message listing 
      all the available regions if the one chosen could not be found.
  #>

  param
  (
    [Parameter(Mandatory=$true)]
    [string] $servicePrincipalName,

    [Parameter(Mandatory=$true)]
    [string] $azureRegion
  )

  ValidateServicePrincipal -ServicePrincipalName $servicePrincipalName
  ValidateAzureRegion -AzureRegion $azureRegion
}

function ValidateServicePrincipal() 
{
  <#
    .SYNOPSIS
      It validates the service principal name.
      
    .DESCRIPTION
      Checks if the service principal contains any space.
      It returns an error if any is found.
  #>

  param
  (
    [Parameter(Mandatory=$true)]
    [string] $servicePrincipalName
  )

  # Disallow principal names with a space.
  if ($servicePrincipalName.Contains(" ")) 
  {
    Write-Error "The principal name may not contain spaces."
    exit -1
  }

}
function ValidateAzureRegion() 
{
  <#
    .SYNOPSIS
      It validates the azure region.
      
    .DESCRIPTION
      Checks if the an azure region is in those that offer eventhubs.
      If none is passed, it is defaulted to 'South Central US'.
      An error is returned if the location chosen does not offer event hubs.
  #>

  param
  (
    [AllowNull()]
    [string] $azureRegion
  )

  IsValidEventHubRegion -AzureRegion "$($azureRegion)"
}

function IsValidEventHubRegion 
{
  <#
    .SYNOPSIS
      Checks if a region provides Azure Event Hubs.
      
    .DESCRIPTION
      Lists all the regions that provide Azure Event Hubs
      and looks for the one passed in as a parameter. It returns 
      true if found or false otherwise. It outputs an error message listing 
      all the available regions if the one chosen could not be found.
  #>

  param
  (
    [AllowNull()]
    [string] $azureRegion
  )
  
  # Verify the location is valid for an Event Hubs namespace.

  $validLocations = @{ }
  
  Get-AzLocation | where { $_.Providers.Contains("Microsoft.EventHub") } | ForEach { $validLocations[$_.Location] = $_.Location }

  $isValidLocation = $validLocations.Contains($azureRegion)

  if (!$isValidLocation) 
  {
    Write-Error "The Azure region must be one of: `n$($validLocations.Keys -join ", ")`n`n" 

    exit -1
  }
}
