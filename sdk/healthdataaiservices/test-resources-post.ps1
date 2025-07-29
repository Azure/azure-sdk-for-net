# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# This script is used to set up SIP Configuration domains for Azure Communication Services SIP Routing SDK GA tests

# It is invoked by the https://github.com/Azure/azure-sdk-for-net/blob/main/eng/New-TestResources.ps1
# script after the ARM template, defined in https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/test-resources.json,
# is finished being deployed. The ARM template is responsible for creating the Storage accounts needed for live tests.

param (
    [hashtable] $DeploymentOutputs,
    [string] $TenantId,
    [string] $TestApplicationId,
    [string] $TestApplicationSecret
)

# Retrieve the connection string from environment variables
$resourceGroup = $DeploymentOutputs['HEALTHDATAAISERVICES_RESOURCE_GROUP']
$endpoint = $DeploymentOutputs['HEALTHDATAAISERVICES_DEID_SERVICE_ENDPOINT']
$storageAccountName = $DeploymentOutputs['HEALTHDATAAISERVICES_STORAGE_ACCOUNT_NAME']
$containerName = $DeploymentOutputs['HEALTHDATAAISERVICES_STORAGE_CONTAINER_NAME']

# Set the local folder path to upload
$localFolderPath = Join-Path $PSScriptRoot "Azure.Health.Deidentification\tests\Data\example_patient_1"

# Check if the connection string is present
if ([string]::IsNullOrWhiteSpace($storageAccountName)) {
    Write-Host "Error: Azure Storage Name string not found in environment variables."
    exit 1
}

# Load the Azure Storage module
Import-Module Az.Storage

# Connect to the storage account
$storageContext = New-AzStorageContext -StorageAccountName $storageAccountName -UseConnectedAccount

# FIXME Remove once vpn team fixes the network acl issue
# TODO: disable local storage account auth
$networkRuleSet = New-Object -TypeName Microsoft.Azure.Commands.Management.Storage.Models.PSNetworkRuleSet
$networkRuleSet.DefaultAction = "Allow"
Set-AzStorageAccount -ResourceGroupName $resourceGroup -Name $storageAccountName -NetworkRuleSet $networkRuleSet

# Sleep for 15 seconds to allow the network rule to take effect
Write-Host "[Fix] Temporary sleep to allow network rule to take effect."
Start-Sleep -Seconds 30

Get-AzStorageContainer -Name $containerName -Context $storageContext

# Upload the folder and its contents to the container
# Gets last folder name + filename. example_patient_1/doctor_dictation.txt
Get-ChildItem -Path $localFolderPath -Recurse | ForEach-Object {
    $relativePath = $_.FullName
    $folderName = Split-Path -Path (Split-Path -Path $relativePath -Parent) -Leaf
    $blobName = Split-Path -Path $relativePath -Leaf
    $destinationBlob = $blobName -replace ":", ""

    $destinationBlob = "$folderName/$destinationBlob"
    Write-Host "Uploading file '$destinationBlob'"
    Set-AzStorageBlobContent -File $_.FullName -Container $containerName -Blob $destinationBlob -Context $storageContext -Force
}

Write-Host "Folder '$localFolderPath' uploaded to container '$containerName' successfully."