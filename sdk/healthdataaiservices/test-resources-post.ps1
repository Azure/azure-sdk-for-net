# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# This script prepares the storage account used by the Health Deidentification live tests: it opens the
# storage network ACL, waits until the storage data plane is reachable, and uploads the test documents.

# It is invoked by https://github.com/Azure/azure-sdk-for-net/blob/main/eng/common/TestResources/New-TestResources.ps1
# after test-resources.bicep in this directory has been deployed.

param (
    [hashtable] $DeploymentOutputs,
    [string] $TenantId,
    [string] $TestApplicationId,
    [string] $TestApplicationSecret,

    # Maximum time to wait for each storage readiness check (network ACL and RBAC propagation).
    [int] $ReadinessTimeoutSeconds = 300,

    # Minimum time after the network rule update before tests may start, to allow the DeID service
    # managed identity's storage role assignment to propagate.
    [int] $DeidIdentityMinimumWaitSeconds = 30
)

# Runs $ScriptBlock until it succeeds or $TimeoutSeconds elapses. Role assignments and network ACL changes
# can take minutes to propagate, so a fixed sleep is either too short (flaky tests) or too long (slow happy path).
function Invoke-WithRetry {
    param (
        [Parameter(Mandatory)] [string] $Name,
        [Parameter(Mandatory)] [scriptblock] $ScriptBlock,
        [int] $TimeoutSeconds = $ReadinessTimeoutSeconds,
        [int] $InitialDelaySeconds = 2,
        [int] $MaxDelaySeconds = 30
    )

    $stopwatch = [System.Diagnostics.Stopwatch]::StartNew()
    $delay = $InitialDelaySeconds
    $attempt = 0
    while ($true) {
        $attempt++
        try {
            $result = & $ScriptBlock
            if ($attempt -gt 1) {
                Write-Host "$Name succeeded after $attempt attempts ($([int]$stopwatch.Elapsed.TotalSeconds)s)."
            }
            return $result
        }
        catch {
            $elapsed = [int]$stopwatch.Elapsed.TotalSeconds
            if ($elapsed + $delay -gt $TimeoutSeconds) {
                throw "$Name did not succeed within $TimeoutSeconds seconds ($attempt attempts). Last error: $($_.Exception.Message)"
            }
            Write-Host "$Name not ready yet (attempt $attempt, ${elapsed}s elapsed): $($_.Exception.Message). Retrying in ${delay}s."
            Start-Sleep -Seconds $delay
            $delay = [Math]::Min($delay * 2, $MaxDelaySeconds)
        }
    }
}

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
Invoke-WithRetry -Name "Opening storage network ACL" -ScriptBlock {
    Set-AzStorageAccount -ResourceGroupName $resourceGroup -Name $storageAccountName -NetworkRuleSet $networkRuleSet -ErrorAction Stop | Out-Null
}
$propagationStopwatch = [System.Diagnostics.Stopwatch]::StartNew()

# Wait for the network ACL change and the test principal's Storage Blob Data Contributor role to take effect.
Invoke-WithRetry -Name "Storage container access check" -ScriptBlock {
    Get-AzStorageContainer -Name $containerName -Context $storageContext -ErrorAction Stop | Out-Null
}

# Upload the folder and its contents to the container
# Gets last folder name + filename. example_patient_1/doctor_dictation.txt
$expectedBlobs = @(Get-ChildItem -Path $localFolderPath -Recurse -File | ForEach-Object {
    $relativePath = $_.FullName
    $folderName = Split-Path -Path (Split-Path -Path $relativePath -Parent) -Leaf
    $blobName = Split-Path -Path $relativePath -Leaf
    $destinationBlob = $blobName -replace ":", ""

    $destinationBlob = "$folderName/$destinationBlob"
    $file = $_.FullName
    Write-Host "Uploading file '$destinationBlob'"
    Invoke-WithRetry -Name "Uploading '$destinationBlob'" -ScriptBlock {
        Set-AzStorageBlobContent -File $file -Container $containerName -Blob $destinationBlob -Context $storageContext -Force -ErrorAction Stop | Out-Null
    }
    $destinationBlob
})

# Confirm the uploaded blobs are readable through the data plane before tests start.
Invoke-WithRetry -Name "Uploaded blob verification" -ScriptBlock {
    $actualBlobs = @(Get-AzStorageBlob -Container $containerName -Context $storageContext -ErrorAction Stop | ForEach-Object { $_.Name })
    $missingBlobs = @($expectedBlobs | Where-Object { $actualBlobs -notcontains $_ })
    if ($missingBlobs.Count -gt 0) {
        throw "Missing blobs: $($missingBlobs -join ', ')"
    }
}

Write-Host "Folder '$localFolderPath' uploaded to container '$containerName' successfully."

# The checks above only prove the caller's storage access, not the DeID service managed identity's.
# Keep at least the previous fixed propagation window (measured from the network rule update) for it.
$remainingWaitSeconds = $DeidIdentityMinimumWaitSeconds - [int]$propagationStopwatch.Elapsed.TotalSeconds
if ($remainingWaitSeconds -gt 0) {
    Write-Host "Waiting $remainingWaitSeconds more seconds for the DeID service identity's storage access to propagate."
    Start-Sleep -Seconds $remainingWaitSeconds
}