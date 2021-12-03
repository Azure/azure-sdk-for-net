# Wrapper Script for Readme Verification
[CmdletBinding()]
param (
  [string]$DocWardenVersion = "0.7.1",

  [Parameter(Mandatory = $true)]
  [string]$ScanPath,

  [Parameter(Mandatory = $true)]
  [string]$SettingsPath
)

pip install setuptools wheel --quiet
pip install doc-warden==$DocWardenVersion --quiet
ward scan -d $ScanPath -c $SettingsPath
