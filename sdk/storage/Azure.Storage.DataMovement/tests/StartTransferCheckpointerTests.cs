// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.DataMovement.Models.JobPlan;
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
            await using DisposingBlobContainer test = await GetTestContainerAsync(containerName: containerName);

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

            StorageResource sourceResource = new BlockBlobStorageResource(sasSourceBlob);
            StorageResource destinationResource = new BlockBlobStorageResource(sasDestinationBlob);

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(disposingLocalDirectory.DirectoryPath)
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            TransferOptions transferOptions = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail
            };

            // Start transfer and await for completion. This transfer will fail
            // since the destination already exists.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                transferOptions).ConfigureAwait(false);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            await transfer.AwaitCompletion(cancellationTokenSource.Token).ConfigureAwait(false);

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

        [RecordedTest]
        public async Task CheckpointerMismatch_Source()
        {
            // Arrange
            DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            var containerName = GetNewContainerName();
            await using DisposingBlobContainer test = await GetTestContainerAsync(containerName: containerName);

            // Create source
            var sourceBlobName = GetNewBlobName();
            BlockBlobClient sourceBlob = await CreateBlockBlob(test.Container, Path.GetTempFileName(), sourceBlobName, Constants.KB * 4);

            // Create Destination
            string destinationBlobName = GetNewBlobName();
            BlockBlobClient destinationBlob = await CreateBlockBlob(test.Container, Path.GetTempFileName(), destinationBlobName, Constants.KB * 4);

            StorageResource sourceResource = new BlockBlobStorageResource(sourceBlob);
            StorageResource destinationResource = new BlockBlobStorageResource(destinationBlob);

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(disposingLocalDirectory.DirectoryPath)
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            TransferOptions transferOptions = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail
            };

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                transferOptions).ConfigureAwait(false);

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            await transfer.AwaitCompletion(cancellationTokenSource.Token).ConfigureAwait(false);

            // Act/Assert - resume transfer with wrong source resource.
            BlockBlobClient newSourceBlob = test.Container.GetBlockBlobClient(GetNewBlobName());
            StorageResource wrongSourceResource = new BlockBlobStorageResource(newSourceBlob);

            TransferOptions resumeTransferOptions = new TransferOptions()
            {
                ResumeFromCheckpointId = transfer.Id
            };

            Assert.CatchAsync<ArgumentException>(
                async () => await transferManager.StartTransferAsync(
                    wrongSourceResource,
                    destinationResource,
                    resumeTransferOptions),
                Errors.MismatchResumeTransferArguments(
                    "SourcePath",
                    sourceResource.Uri.AbsoluteUri,
                    wrongSourceResource.Uri.AbsoluteUri).Message);
        }

        [RecordedTest]
        public async Task CheckpointerMismatch_Destination()
        {
            // Arrange
            DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            var containerName = GetNewContainerName();
            await using DisposingBlobContainer test = await GetTestContainerAsync(containerName: containerName);

            // Create source
            var sourceBlobName = GetNewBlobName();
            BlockBlobClient sourceBlob = await CreateBlockBlob(test.Container, Path.GetTempFileName(), sourceBlobName, Constants.KB * 4);

            // Create Destination
            string destinationBlobName = GetNewBlobName();
            BlockBlobClient destinationBlob = await CreateBlockBlob(test.Container, Path.GetTempFileName(), destinationBlobName, Constants.KB * 4);

            StorageResource sourceResource = new BlockBlobStorageResource(sourceBlob);
            StorageResource destinationResource = new BlockBlobStorageResource(destinationBlob);

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(disposingLocalDirectory.DirectoryPath)
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            TransferOptions transferOptions = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail
            };

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                transferOptions).ConfigureAwait(false);

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            await transfer.AwaitCompletion(cancellationTokenSource.Token).ConfigureAwait(false);

            // Act/Assert - resume transfer with wrong destination resource.
            BlockBlobClient newDestinationBlob = test.Container.GetBlockBlobClient(GetNewBlobName());
            StorageResource wrongDestinationResource = new BlockBlobStorageResource(newDestinationBlob);

            TransferOptions resumeTransferOptions = new TransferOptions()
            {
                ResumeFromCheckpointId = transfer.Id
            };

            Assert.CatchAsync<ArgumentException>(
                async () => await transferManager.StartTransferAsync(
                    sourceResource,
                    wrongDestinationResource,
                    resumeTransferOptions),
                Errors.MismatchResumeTransferArguments(
                    "DestinationPath",
                    destinationResource.Uri.AbsoluteUri,
                    wrongDestinationResource.Uri.AbsoluteUri).Message);
        }

        [RecordedTest]
        public async Task CheckpointerMismatch_CreateMode_Overwrite()
        {
            // Arrange
            DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            var containerName = GetNewContainerName();
            await using DisposingBlobContainer test = await GetTestContainerAsync(containerName: containerName);

            // Create source
            var sourceBlobName = GetNewBlobName();
            BlockBlobClient sourceBlob = await CreateBlockBlob(test.Container, Path.GetTempFileName(), sourceBlobName, Constants.KB * 4);

            // Create Destination
            string destinationBlobName = GetNewBlobName();
            BlockBlobClient destinationBlob = await CreateBlockBlob(test.Container, Path.GetTempFileName(), destinationBlobName, Constants.KB * 4);

            StorageResource sourceResource = new BlockBlobStorageResource(sourceBlob);
            StorageResource destinationResource = new BlockBlobStorageResource(destinationBlob);

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(disposingLocalDirectory.DirectoryPath)
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            TransferOptions transferOptions = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail
            };

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                transferOptions).ConfigureAwait(false);

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            await transfer.AwaitCompletion(cancellationTokenSource.Token).ConfigureAwait(false);

            // Act/Assert - resume transfer with wrong CreateMode Resource
            TransferOptions resumeTransferOptions = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
                ResumeFromCheckpointId = transfer.Id
            };

            Assert.CatchAsync<ArgumentException>(
                async () => await transferManager.StartTransferAsync(
                    sourceResource,
                    destinationResource,
                    resumeTransferOptions),
                Errors.MismatchResumeCreateMode(
                    false,
                    StorageResourceCreateMode.Overwrite).Message);
        }
    }
}
