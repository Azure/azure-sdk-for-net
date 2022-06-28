# Wrapper Script for Readme Verification
[CmdletBinding()]
param (
  [Parameter(Mandatory = $false)]
  [string]$DocWardenVersion,
  [string]$RepoRoot,
  [string]$ScanPaths,
  [Parameter(Mandatory = $true)]
  [string]$SettingsPath
)
. (Join-Path $PSScriptRoot common.ps1)
$DefaultDocWardenVersion = "0.7.2"
$script:FoundError = $false

function Test-Readme-Files {
  param(
    [string]$SettingsPath,
    [string]$ScanPath,
    [string]$RepoRoot)

      Write-Host "Scanning..."

      if ($RepoRoot)
      {
        Write-Host "ward scan -d $ScanPath -u $RepoRoot -c $SettingsPath"
        ward scan -d $ScanPath -u $RepoRoot -c $SettingsPath
      }
      else
      {
        Write-Host "ward scan -d $ScanPath -c $SettingsPath"
        ward scan -d $ScanPath -c $SettingsPath
      }
      # ward scan is what returns the non-zero exit code on failure.
      # Since it's being called from a function, that error needs to
      # be propagated back so the script can exit appropriately
      if ($LASTEXITCODE -ne 0) {
        $script:FoundError = $true
      }
}

# Verify all of the inputs before running anything
if ([String]::IsNullOrWhiteSpace($DocWardenVersion)) {
  $DocWardenVersion = $DefaultDocWardenVersion
}

# verify the doc settings file exists
if (!(Test-Path -Path $SettingsPath -PathType leaf)) {
  LogError "Setting file, $SettingsPath, does not exist"
  $script:FoundError = $true
}

# Verify that either ScanPath or ScanPaths were set but not both or neither
if ([String]::IsNullOrWhiteSpace($ScanPaths)) {
  LogError "ScanPaths cannot be empty."
} else {
  foreach ($path in $ScanPaths.Split(',')) {
    if (!(Test-Path -Path $path -PathType Container)) {
      LogError "path, $path, doesn't exist or isn't a directory"
      $script:FoundError = $true
    }
  }
}

# Exit out now if there were any argument issues
if ($script:FoundError) {
  LogError "There were argument failures, please see above for specifics"
  exit 1
}

# Echo back the settings
Write-Host "DocWardenVersion=$DocWardenVersion"
Write-Host "SettingsPath=$SettingsPath"

if ($RepoRoot) {
  Write-Host "RepoRoot=$RepoRoot"
}

Write-Host "ScanPath=$ScanPaths"

Write-Host "Installing setup tools and DocWarden"
Write-Host "pip install setuptools wheel --quiet"
pip install setuptools wheel --quiet
if ($LASTEXITCODE -ne 0) {
  LogError "pip install setuptools wheel --quiet failed with exit code $LASTEXITCODE"
  exit 1
}
Write-Host "pip install doc-warden==$DocWardenVersion --quiet"
pip install doc-warden==$DocWardenVersion --quiet
if ($LASTEXITCODE -ne 0) {
  LogError "pip install doc-warden==$DocWardenVersion --quiet failed with exit code $LASTEXITCODE"
  exit 1
}

# Finally, do the scanning
foreach ($path in $ScanPaths.Split(',')) {
  Test-Readme-Files $SettingsPath $path $RepoRoot
}

if ($script:FoundError) {
  LogError "There were README verification failures, scroll up to see the issue(s)"
  exit 1
}