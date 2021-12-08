# Wrapper Script for Readme Verification
[CmdletBinding()]
param (
  [string]$DocWardenVersion = "0.7.2",
  [Parameter(Mandatory = $true)]
  [string]$ScanPath,
  [string]$RepoRoot,
  [Parameter(Mandatory = $true)]
  [string]$SettingsPath
)

pip install setuptools wheel --quiet
pip install doc-warden==$DocWardenVersion --quiet

if (-not [System.String]::IsNullOrWhiteSpace($RepoRoot))
{
  ward scan -d $ScanPath -u $RepoRoot -c $SettingsPath
}
else
{
  ward scan -d $ScanPath -c $SettingsPath
}

