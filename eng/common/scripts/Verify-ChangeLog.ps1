# Wrapper Script for ChangeLog Verification
# Parameter description
# ChangeLogLocation: Path to the changelog file
# VersionString: Version string to verify in the changelog
# PackageName: Name of the package
# ServiceDirectory: Service directory path
# ForRelease: Whether to verify for release (default: false)
# GroupId: Optional. The group ID for the package. Used for filtering packages in languages that support group identifiers (e.g., Java).

[CmdletBinding()]
param (
  [String]$ChangeLogLocation,
  [String]$VersionString,
  [string]$PackageName,
  [string]$ServiceDirectory,
  [boolean]$ForRelease = $False,
  [String]$PackageInfoFilePath
)
Set-StrictMode -Version 3

. (Join-Path $PSScriptRoot common.ps1)

$validChangeLog = $false
if ($ChangeLogLocation -and $VersionString)
{
  $validChangeLog = Confirm-ChangeLogEntry -ChangeLogLocation $ChangeLogLocation -VersionString $VersionString -ForRelease $ForRelease
}
else
{
  # Load package info to extract GroupId if available
  $GroupId = $null
  if ($PackageInfoFilePath -and (Test-Path $PackageInfoFilePath)) {
    $packageInfoJson = Get-Content $PackageInfoFilePath | ConvertFrom-Json
    if ($packageInfoJson.PSObject.Properties.Name -contains "Group") {
      $GroupId = $packageInfoJson.Group
    }
  }
  
  $PackageProp = Get-PkgProperties -PackageName $PackageName -ServiceDirectory $ServiceDirectory -GroupId $GroupId
  $validChangeLog = Confirm-ChangeLogEntry -ChangeLogLocation $PackageProp.ChangeLogPath -VersionString $PackageProp.Version -ForRelease $ForRelease
}

if (!$validChangeLog)
{
  exit 1
}

exit 0