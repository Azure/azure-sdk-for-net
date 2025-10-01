#!/bin/env pwsh
param(
  [string] $StorageAccountName = 'azuresdkartifacts',
  [string] $StorageContainerName = 'public-vcpkg-container'
)

$ctx = New-AzStorageContext `
  -StorageAccountName $StorageAccountName `
  -UseConnectedAccount

$vcpkgBinarySourceSas = New-AzStorageContainerSASToken `
  -Name $StorageContainerName `
  -Permission "rwcl" `
  -Context $ctx `
  -ExpiryTime (Get-Date).AddHours(1)

# Ensure redaction of SAS tokens in logs
Write-Host "##vso[task.setvariable variable=VCPKG_BINARY_SAS_TOKEN;issecret=true;]$vcpkgBinarySourceSas"

Write-Host "Setting vcpkg binary cache to read and write"
Write-Host "##vso[task.setvariable variable=VCPKG_BINARY_SOURCES_SECRET;issecret=true;]clear;x-azcopy-sas,https://$StorageAccountName.blob.core.windows.net/$StorageContainerName,$vcpkgBinarySourceSas,readwrite"
Write-Host "##vso[task.setvariable variable=X_VCPKG_ASSET_SOURCES_SECRET;issecret=true;]clear;x-azurl,https://$StorageAccountName.blob.core.windows.net/$StorageContainerName,$vcpkgBinarySourceSas,readwrite"
