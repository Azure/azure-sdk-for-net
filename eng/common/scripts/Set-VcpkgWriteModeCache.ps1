#!/bin/env pwsh
param(
  [string] $StorageAccountName = 'azuresdkartifacts',
  [string] $StorageContainerName = 'public-vcpkg-container'
)

. "$PSScriptRoot/Helpers/PSModule-Helpers.ps1"

Write-Host "`$env:PSModulePath = $($env:PSModulePath)"

# Work around double backslash
if ($IsWindows) {
  $hostedAgentModulePath = $env:SystemDrive + "\\Modules"
  $moduleSeperator = ";"
}
else {
  $hostedAgentModulePath = "/usr/share"
  $moduleSeperator = ":"
}
$modulePaths = $env:PSModulePath -split $moduleSeperator
$modulePaths = $modulePaths.Where({ !$_.StartsWith($hostedAgentModulePath) })
$AzModuleCachePath = (Get-ChildItem "$hostedAgentModulePath/az_*" -Attributes Directory) -join $moduleSeperator
if ($AzModuleCachePath -and $env:PSModulePath -notcontains $AzModuleCachePath) {
  $modulePaths += $AzModuleCachePath
}

$env:PSModulePath = $modulePaths -join $moduleSeperator

Install-ModuleIfNotInstalled "Az.Storage" "4.3.0" | Import-Module

$ctx = New-AzStorageContext `
  -StorageAccountName $StorageAccountName `
  -UseConnectedAccount

$vcpkgBinarySourceSas = New-AzStorageContainerSASToken `
  -Name $StorageContainerName `
  -Permission "rwcl" `
  -Context $ctx `
  -ExpiryTime (Get-Date).AddHours(1)

Write-Host "Ensure redaction of SAS tokens in logs"
Write-Host "##vso[task.setvariable variable=VCPKG_BINARY_SAS_TOKEN;issecret=true;]$vcpkgBinarySourceSas"

Write-Host "Setting vcpkg binary cache to read and write"
Write-Host "##vso[task.setvariable variable=VCPKG_BINARY_SOURCES_SECRET;issecret=true;]clear;x-azcopy-sas,https://$StorageAccountName.blob.core.windows.net/$StorageContainerName,$vcpkgBinarySourceSas,readwrite"
Write-Host "##vso[task.setvariable variable=X_VCPKG_ASSET_SOURCES_SECRET;issecret=true;]clear;x-azurl,https://$StorageAccountName.blob.core.windows.net/$StorageContainerName,$vcpkgBinarySourceSas,readwrite"
