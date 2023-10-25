// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using Azure.Storage.DataMovement.JobPlan;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferCheckpointerTests : DataMovementBlobTestBase
    {
        public StartTransferCheckpointerTests(
            bool async,
            BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, default)
        {
        }

        // This test is written to ensure that SAS stored in the
        // the path are not stored in the job plan file
        // We expect only the path and the URL without the query
        // to be stored
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/36016")]
        [RecordedTest]
        public async Task CheckpointerWithSasAsync()
        {
            // Arrange
            DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            var containerName = GetNewContainerName();
            var sourceBlobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName);

            BlobBaseClient sourceBlob = await CreateBlockBlob(
                containerClient: test.Container,
                localSourceFile: Path.Combine(disposingLocalDirectory.DirectoryPath, sourceBlobName),
                blobName: sourceBlobName,
                size: Constants.KB * 4);

            // Create Source with SAS
            BlockBlobClient sasSourceBlob = InstrumentClient(
                GetServiceClient_BlobServiceSas_Blob(
                    containerName: containerName,
                    blobName: sourceBlobName)
                .GetBlobContainerClient(containerName)
                .GetBlockBlobClient(sourceBlobName));

            // Create Destination with SAS
            string destinationBlobName = GetNewBlobName();
            BlockBlobClient destinationBlob = await CreateBlockBlob(
                containerClient: test.Container,
                localSourceFile: Path.Combine(disposingLocalDirectory.DirectoryPath, destinationBlobName),
                blobName: destinationBlobName,
                size: Constants.KB*4);
            BlockBlobClient sasDestinationBlob = InstrumentClient(
                GetServiceClient_BlobServiceSas_Blob(
                    containerName: containerName,
                    blobName: destinationBlobName)
                .GetBlobContainerClient(containerName)
                .GetBlockBlobClient(destinationBlobName));

            StorageResourceItem sourceResource = new BlockBlobStorageResource(sasSourceBlob);
            StorageResourceItem destinationResource = new BlockBlobStorageResource(sasDestinationBlob);

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointStoreOptions(disposingLocalDirectory.DirectoryPath)
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            DataTransferOptions transferOptions = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };

            // Start transfer and await for completion. This transfer will fail
            // since the destination already exists.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                transferOptions).ConfigureAwait(false);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Check the transfer files made and the source and destination
            JobPartPlanFileName checkpointerFileName = new JobPartPlanFileName(
                checkpointerPath: disposingLocalDirectory.DirectoryPath,
                id: transfer.Id,
                jobPartNumber: 0);
            Assert.IsTrue(File.Exists(checkpointerFileName.FullPath));

            // Check contents for checkpointer file without the SAS
            using (FileStream stream = File.OpenRead(checkpointerFileName.FullPath))
            {
                JobPartPlanHeader deserializedHeader = JobPartPlanHeader.Deserialize(stream);

                Assert.IsNotNull(deserializedHeader);

                Assert.AreEqual(sourceBlob.Uri.AbsoluteUri, deserializedHeader.SourcePath);
                Assert.AreEqual(destinationBlob.Uri.AbsoluteUri, deserializedHeader.DestinationPath);
            }
        }
    }
}
