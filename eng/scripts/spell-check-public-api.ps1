param(
  [Parameter(mandatory = $false)]
  $ServiceDirectory = ''
)

Set-StrictMode -Version 3.0
."$PSScriptRoot/../common/scripts/common.ps1"

$files = @()
if ($ServiceDirectory) {
  $files = Get-ChildItem -Path "$PSScriptRoot/../../sdk/$ServiceDirectory/*/api/*.cs" -File
} else {
  $files = Get-ChildItem -Path "$PSScriptRoot/../../sdk/*/*/api/*.cs" -File
}


Write-Host "Found $($files.Count) public API surface files to spell check."
."$PSScriptRoot/../common/spelling/Invoke-Cspell.ps1" `
  -CSpellConfigPath "./.vscode/cspell.json" `
  -FileList $files.FullName
