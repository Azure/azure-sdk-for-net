# Wrapper Script for Readme Verification
[CmdletBinding()]
param (
  [Parameter(Mandatory = $true)]
  [string]$DocWardenVersion,
  [Parameter(Mandatory = $true)]
  [string]$ScanPath,
  [string]$RepoRoot,
  [Parameter(Mandatory = $true)]
  [string]$SettingsPath
)

pip install setuptools wheel --quiet
pip install doc-warden==$DocWardenVersion --quiet

if ($RepoRoot)
{
  ward scan -d $ScanPath -u $RepoRoot -c $SettingsPath
}
else
{
  ward scan -d $ScanPath -c $SettingsPath
}

