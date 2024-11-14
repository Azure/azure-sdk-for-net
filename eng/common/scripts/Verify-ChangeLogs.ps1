# Wrapper Script for ChangeLog Verification in a PR
[CmdletBinding()]
param (
  [String]$PackagePropertiesFolder
)
Set-StrictMode -Version 3

. (Join-Path $PSScriptRoot common.ps1)

function ShouldVerifyChangeLog ($PkgArtifactDetails) {
  if ($PkgArtifactDetails) {
    Write-Host $PkgArtifactDetails.Name
    $possibleValue = $PkgArtifactDetails.PSObject.Properties["skipVerifyChangeLog"]

    if ($possibleValue) {
      if ($possibleValue -eq $true) {
        return $false
      }
    }

    return $true
  }

  return $false
}

# find which packages we need to confirm the changelog for
$packageProperties = Get-ChildItem -Recurse "$PackagePropertiesFolder" *.json

# grab the json file, then confirm the changelog entry for it
$allPassing = $true
foreach($propertiesFile in $packageProperties) {
  $PackageProp = Get-Content -Path $propertiesFile | ConvertFrom-Json

  if (-not (ShouldVerifyChangeLog $PackageProp.ArtifactDetails)) {
        Write-Host "Skipping changelog verification for $($PackageProp.Name)"
        continue
  }

  $validChangeLog =  Confirm-ChangeLogEntry -ChangeLogLocation $PackageProp.ChangeLogPath -VersionString $PackageProp.Version -ForRelease $false

  if (-not $validChangeLog) {
    $allPassing = $false
  }
}

if (!$allPassing)
{
  exit 1
}

exit 0
