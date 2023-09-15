<#
.SYNOPSIS
Verify that the json files used to generate docs have the required members.

.DESCRIPTION
Given a doc repo location verify that the required members are in json
metadata files. This does not verify for correctness, only that the required
members exist within the file and are non-null. The required members are:
  Name
  Version
  ServiceDirectory
  SdkType
  IsNewSdk
For Java only
  Group

.PARAMETER DocRepoLocation
Location of the documentation repo.
#>

param (
  [Parameter(Mandatory = $true)]
  [string] $DocRepoLocation # the location of the cloned doc repo
)

. (Join-Path $PSScriptRoot common.ps1)
Set-StrictMode -Version 3

$script:FoundError = $false

function Test-RequiredDocsJsonMembers($moniker) {

  $searchPath = Join-Path $DocRepoLocation 'metadata' $moniker
  Write-Host "Scanning json files in $searchPath"
  if (!(Test-Path $searchPath)) {
    return
  }
  $paths = Get-ChildItem -Path $searchPath -Filter *.json

  foreach ($path in $paths) {
    $fileContents = Get-Content $path -Raw
    $fileObject = ConvertFrom-Json -InputObject $fileContents

    if ($fileObject.PSObject.Members.Name -contains "Name") {
      if ($null -eq $fileObject.Name -or $fileObject.Name -eq "") {
        Write-Host "$path has a null or empty Name member. The Name member cannot be null or empty."
        $script:FoundError = $true
      }
    } else {
      Write-Host "$path is missing its Name member. The Name member must exist and cannot be null or empty."
      $script:FoundError = $true
    }

    if ($fileObject.PSObject.Members.Name -contains "Version") {
      if ($null -eq $fileObject.Version -or $fileObject.Version -eq "") {
        Write-Host "$path has a null or empty Version member. The Version member cannot be null or empty."
        $script:FoundError = $true
      }
    } else {
      Write-Host "$path is missing its Version member. The Version member must exist and cannot be null or empty."
      $script:FoundError = $true
    }

    if ($fileObject.PSObject.Members.Name -contains "ServiceDirectory") {
      if ($null -eq $fileObject.ServiceDirectory -or $fileObject.ServiceDirectory -eq "") {
        Write-Host "$path has a null or empty ServiceDirectory member. If the ServiceDirectory is unknown please use ""NA"""
        $script:FoundError = $true
      }
    } else {
      Write-Host "$path is missing its ServiceDirectory member. If the ServiceDirectory is unknown please use ""NA""."
      $script:FoundError = $true
    }

    if ($fileObject.PSObject.Members.Name -contains "SdkType") {
      if ($null -eq $fileObject.SdkType -or $fileObject.SdkType -eq "") {
        Write-Host "$path has a null or empty SdkType member. If the SdkType is unknwon please use ""NA""."
        $script:FoundError = $true
      }
    } else {
      Write-Host "$path is missing its SdkType member. If the SdkType is unknwon please use ""NA""."
      $script:FoundError = $true
    }

    if ($fileObject.PSObject.Members.Name -contains "IsNewSdk") {
      # IsNewSdk is a boolean, no empty string check necessary
      if ($null -eq $fileObject.IsNewSdk) {
        Write-Host "$path has a null IsNewSdk member which must be true or false."
      }
    } else {
      Write-Host "$path is missing its IsNewSdk member which must be true or false."
      $script:FoundError = $true
    }

    if ($fileObject.PSObject.Members.Name -contains 'DirectoryPath') {
      if ($null -eq $fileObject.DirectoryPath) { 
        Write-Host "$path has a null DirectoryPath member. If the DirectoryPath is unknown please use the value `"`"."
        $script:FoundError = $true
      }
    } else { 
      Write-Host "$path is missing its DirectoryPath member. If the DirectoryPath is unknown please use the value `"`"."
      $script:FoundError = $true
    }

    if ($Language -eq "java") {
      if ($fileObject.PSObject.Members.Name -contains "Group")
      {
        if ($null -eq $fileObject.Group -or $fileObject.Group -eq "") {
          Write-Host "$path has an null or empty Group member. The Group member cannot be null or empty."
          $script:FoundError = $true
        }
      } else {
        Write-Host "$path is missing its Group member. The Group member must exist and cannot be null or empty."
        $script:FoundError = $true
      }
    }
  }
}

Test-RequiredDocsJsonMembers 'latest'
Test-RequiredDocsJsonMembers 'preview'

if ($script:FoundError)
{
  LogError "There were missing or empty members docs metadata json files. Please see above for specifics.`
The missing entries were either the result of the MsToc update or were directly checked into the repository."
  exit 1
}

Write-Host "The json files appear to contain the required members."
exit 0
