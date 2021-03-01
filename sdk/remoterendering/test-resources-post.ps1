# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# This script is used to generate the Test Configuration file for Storage live tests.
# It is invoked by the https://github.com/Azure/azure-sdk-for-net/blob/master/eng/New-TestResources.ps1
# script after the ARM template, defined in https://github.com/Azure/azure-sdk-for-net/blob/arm-template-storage/sdk/storage/test-resources.json, 
# is finished being deployed. The ARM template is responsible for creating the Storage accounts needed for live tests.

param (
    [hashtable] $DeploymentOutputs,
    [string] $TenantId,
    [string] $TestApplicationId,
    [string] $TestApplicationSecret
)

# outputs from the ARM deployment passed in from New-TestResources
$StorageAccountName = $DeploymentOutputs['REMOTERENDERING_ARR_STORAGE_ACCOUNT_NAME']
$StorageAccountKey = $DeploymentOutputs['REMOTERENDERING_ARR_STORAGE_ACCOUNT_KEY']
$BlobContainerName = $DeploymentOutputs['REMOTERENDERING_ARR_BLOB_CONTAINER_NAME']

$LocalFilePath = Join-Path $PSScriptRoot "TestResources\testBox.fbx"
$TargetBlob = "Input/testBox.fbx"

Write-Verbose ( "Copying test asset to blob storage")

$StorageContext = New-AzStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $StorageAccountKey

$blob = Set-AzStorageBlobContent -File $LocalFilePath -Blob $TargetBlob -Container $BlobContainerName -Context $StorageContext -Force

Write-Verbose ("Test asset successfully copied to blob storage")
