param(
  $ServiceDirectory = '',
  $RelativePackagePath = ''
)

if ($ServiceDirectory -and $RelativePackagePath) {
  throw "Cannot specify both ServiceDirectory and RelativePackagePath parameters."
}

Set-StrictMode -Version 3.0
."$PSScriptRoot/../common/scripts/common.ps1"

$files = @()
if ($ServiceDirectory) {
  $files = Get-ChildItem -Path "$PSScriptRoot/../../sdk/$ServiceDirectory/*/api/*.cs" -File
} elseif ($RelativePackagePath) {
  $files = Get-ChildItem -Path "$PSScriptRoot/../../sdk/$RelativePackagePath/api/*.cs" -File
} else {
  $files = Get-ChildItem -Path "$PSScriptRoot/../../sdk/*/*/api/*.cs" -File
}

Write-Host "Found $($files.Count) public API surface files to spell check."

$repoRoot = Resolve-Path "$PSScriptRoot/../.."
$cspellConfigPath = "$repoRoot/.vscode/cspell.json"
if ($ServiceDirectory) {
  $serviceCspellConfigPath = "$repoRoot/sdk/$ServiceDirectory/cspell.yaml"
  if (Test-Path $serviceCspellConfigPath) {
    $cspellConfigPath = $serviceCspellConfigPath
  }
} elseif ($RelativePackagePath) {
  $serviceDirectory = ($RelativePackagePath -split '[/\\]')[0]
  $serviceCspellConfigPath = "$repoRoot/sdk/$serviceDirectory/cspell.yaml"
  if (Test-Path $serviceCspellConfigPath) {
    $cspellConfigPath = $serviceCspellConfigPath
  }
}

."$PSScriptRoot/../common/spelling/Invoke-Cspell.ps1" `
  -CSpellConfigPath $cspellConfigPath `
  -FileList $files.FullName
