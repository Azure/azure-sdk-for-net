# Wrapper Script for ChangeLog Verification
param (
  [String]$ChangeLogLocation,
  [String]$VersionString,
  [string]$PackageName,
  [string]$ServiceName,
  [string]$RepoRoot,
  [ValidateSet("net", "java", "js", "python")]
  [string]$Language,
  [string]$RepoName,
  [boolean]$ForRelease = $False
)

$ProgressPreference = "SilentlyContinue"
. (Join-Path $PSScriptRoot SemVer.ps1)
Import-Module (Join-Path $PSScriptRoot modules ChangeLog-Operations.psm1)

$validChangeLog = $false
if ($ChangeLogLocation -and $VersionString) 
{
  $validChangeLog = Confirm-ChangeLogEntry -ChangeLogLocation $ChangeLogLocation -VersionString $VersionString -ForRelease $ForRelease
}
else
{
  Import-Module (Join-Path $PSScriptRoot modules Package-Properties.psm1)
  if ([System.String]::IsNullOrEmpty($Language))
  {
    if ($RepoName -match "azure-sdk-for-(?<lang>[^-]+)")
    {
      $Language = $matches["lang"]
    }
    else
    {
      Write-Error "Failed to set Language automatically. Please pass the appropriate Language as a parameter."
      exit 1
    }
  }

  $PackageProp = Get-PkgProperties -PackageName $PackageName -ServiceName $ServiceName -Language $Language -RepoRoot $RepoRoot
  $validChangeLog = Confirm-ChangeLogEntry -ChangeLogLocation $PackageProp.pkgChangeLogPath -VersionString $PackageProp.pkgVersion -ForRelease $ForRelease
}

if (!$validChangeLog)
{
  exit 1
}

exit 0