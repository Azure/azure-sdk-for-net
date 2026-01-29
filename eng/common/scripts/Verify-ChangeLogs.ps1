# Wrapper Script for ChangeLog Verification in a PR
[CmdletBinding()]
param (
  [String]$PackagePropertiesFolder,
  [boolean]$ForRelease = $False
)
Set-StrictMode -Version 3

. (Join-Path $PSScriptRoot common.ps1)


function ShouldVerifyChangeLog ($PkgArtifactDetails) {
  if ($PkgArtifactDetails) {
    if ($PkgArtifactDetails.PSObject.Properties.Name -contains "skipVerifyChangeLog") {
      if ($PkgArtifactDetails.skipVerifyChangeLog) {
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

  Write-Host "Verifying changelog for $($PackageProp.Name)"

  $validChangeLog =  Confirm-ChangeLogEntry -ChangeLogLocation $PackageProp.ChangeLogPath -VersionString $PackageProp.Version -ForRelease $ForRelease

  if (-not $validChangeLog) {
    $allPassing = $false
  }
}

if (!$allPassing)
{
  exit 1
}

exit 0
