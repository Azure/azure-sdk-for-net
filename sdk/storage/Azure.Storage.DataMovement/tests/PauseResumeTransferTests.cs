// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.DataMovement.Models;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.Storage.DataMovement.Models.JobPlan;
using Azure.Core;
using System.Drawing;

namespace Azure.Storage.DataMovement.Tests
{
    public class PauseResumeTransferTests : DataMovementBlobTestBase
    {
        public PauseResumeTransferTests(
            bool async,
            BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, default)
        {
        }

        public enum TransferType
        {
            Upload,
            Download,
            AsyncCopy,
            SyncCopy
        }

        private async Task<LocalFileStorageResource> CreateLocalFileSourceResourceAsync(
            long size,
            string directory)
        {
            string localSourceFile = await CreateRandomFileAsync(directory);
            // create a new file and copy contents of stream into it, and then close the FileStream
            // so the StagedUploadAsync call is not prevented from reading using its FileStream.
            using Stream originalStream = await CreateLimitedMemoryStream(size);
            using (FileStream fileStream = File.Create(localSourceFile))
            {
                await originalStream.CopyToAsync(fileStream);
            }
            return new LocalFileStorageResource(localSourceFile);
        }

        private async Task<BlockBlobStorageResource> CreateBlobSourceResourceAsync(
            long size,
            string blobName,
            BlobContainerClient container,
            BlockBlobStorageResourceOptions options = default)
        {
            BlockBlobClient blobClient = container.GetBlockBlobClient(blobName);

            // create a new file and copy contents of stream into it, and then close the FileStream
            // so the StagedUploadAsync call is not prevented from reading using its FileStream.
            using (Stream originalStream = await CreateLimitedMemoryStream(size))
            {
                // Upload blob to storage account
                originalStream.Position = 0;
                await blobClient.UploadAsync(originalStream);
            }
            return new BlockBlobStorageResource(blobClient, options);
        }

        private BlockBlobStorageResource CreateBlobDestinationResource(
            BlobContainerClient container,
            BlockBlobStorageResourceOptions options = default)
        {
            string blobName = GetNewBlobName();
            BlockBlobClient destinationClient = container.GetBlockBlobClient(blobName);
            return new BlockBlobStorageResource(destinationClient, options);
        }

        private async Task<(StorageResource SourceResource, StorageResource DestinationResource)> CreateStorageResourcesAsync(
            TransferType transferType,
            long size,
            string localDirectory,
            BlobContainerClient sourceContainer,
            BlobContainerClient destinationContainer)
        {
            StorageResource SourceResource = default;
            StorageResource DestinationResource = default;
            if (transferType == TransferType.Download)
            {
                Argument.AssertNotNull(sourceContainer, nameof(sourceContainer));
                Argument.AssertNotNullOrEmpty(localDirectory, nameof(localDirectory));
                SourceResource ??= await CreateBlobSourceResourceAsync(size, GetNewBlobName(), sourceContainer);
                DestinationResource ??= new LocalFileStorageResource(localDirectory);
            }
            else if (transferType == TransferType.SyncCopy || transferType == TransferType.AsyncCopy)
            {
                Argument.AssertNotNull(sourceContainer, nameof(sourceContainer));
                Argument.AssertNotNull(destinationContainer, nameof(destinationContainer));
                BlockBlobStorageResourceOptions options = new BlockBlobStorageResourceOptions()
                {
                    CopyMethod = transferType == TransferType.SyncCopy ? TransferCopyMethod.SyncCopy : TransferCopyMethod.AsyncCopy
                };
                SourceResource ??= await CreateBlobSourceResourceAsync(size, GetNewBlobName(), sourceContainer, options);
                DestinationResource ??= CreateBlobDestinationResource(destinationContainer);
            }
            else
            {
                // Default to Upload
                Argument.AssertNotNullOrEmpty(localDirectory, nameof(localDirectory));
                Argument.AssertNotNull(destinationContainer, nameof(destinationContainer));
                SourceResource ??= await CreateLocalFileSourceResourceAsync(size, localDirectory);
                DestinationResource ??= CreateBlobDestinationResource(destinationContainer);
            }
            return (SourceResource, DestinationResource);
        }

        /// <summary>
        /// Upload and verify the contents of the blob
        ///
        /// By default in this function an event arguement will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        private async Task<DataTransfer> CreateSingleLongTransferAsync(
            TransferManager manager,
            TransferType transferType = TransferType.Upload,
            string localDirectory = default,
            BlobContainerClient sourceContainer = default,
            BlobContainerClient destinationContainer = default,
            StorageResource sourceResource = default,
            StorageResource destinationResource = default,
            SingleTransferOptions singleTransferOptions = default,
            long size = Constants.MB)
        {
            Argument.AssertNotNull(manager, nameof(manager));
            if (sourceResource == default && destinationResource == default)
            {
                (StorageResource source, StorageResource dest) = await CreateStorageResourcesAsync(
                    transferType: transferType,
                    size: size,
                    localDirectory: localDirectory,
                    sourceContainer: sourceContainer,
                    destinationContainer: destinationContainer);
                sourceResource = source;
                destinationResource = dest;
            }
            else if ((sourceResource == default && destinationResource != default) ||
                    (sourceResource != default && destinationResource == default))
            {
                throw new ArgumentException($"Both {nameof(sourceResource)} or {nameof(destinationResource)} must be specified, " +
                    $"if only one is specified.");
            }

            // Act
            return await manager.StartTransferAsync(sourceResource, destinationResource, singleTransferOptions);
        }

        [Test]
        [TestCase(TransferType.Upload)]
        [TestCase(TransferType.Download)]
        [TestCase(TransferType.AsyncCopy)]
        [TestCase(TransferType.SyncCopy)]
        //[Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        public async Task TryPauseTransferAsync_Id(TransferType transferType)
        {
            // Arrange
            DisposingLocalDirectory checkpointerDirectory = GetTestLocalDirectory();
            DisposingLocalDirectory localDirectory = GetTestLocalDirectory();
            DisposingBlobContainer sourceContainer = await GetTestContainerAsync();
            DisposingBlobContainer destinationContainer = await GetTestContainerAsync();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 4
            };
            TransferManager transferManager = new TransferManager(options);
            SingleTransferOptions singleTransferOptions = new SingleTransferOptions();
            FailureTransferHolder failureTransferHolder = new FailureTransferHolder(singleTransferOptions);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            DataTransfer transfer = await CreateSingleLongTransferAsync(
                manager: transferManager,
                transferType: transferType,
                localDirectory: localDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                size: Constants.MB * 100,
                singleTransferOptions: singleTransferOptions);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            bool pauseSuccess = await transferManager.TryPauseTransferAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            failureTransferHolder.AssertFailureCheck();
            Assert.AreEqual(StorageTransferStatus.Paused, transfer.TransferStatus);
            Assert.IsTrue(pauseSuccess);

            // Check if Job Plan File exists in checkpointer path.
            JobPartPlanFileName fileName = new JobPartPlanFileName(
                checkpointerPath: checkpointerDirectory.DirectoryPath,
                id: transfer.Id,
                jobPartNumber: 0);
            Assert.IsTrue(File.Exists(fileName.FullPath));
        }

        [Test]
        [TestCase(TransferType.Upload)]
        [TestCase(TransferType.Download)]
        [TestCase(TransferType.AsyncCopy)]
        [TestCase(TransferType.SyncCopy)]
        //[Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        public async Task TryPauseTransferAsync_DataTransfer(TransferType transferType)
        {
            // Arrange
            DisposingLocalDirectory checkpointerDirectory = GetTestLocalDirectory();
            DisposingLocalDirectory localDirectory = GetTestLocalDirectory();
            DisposingBlobContainer sourceContainer = await GetTestContainerAsync();
            DisposingBlobContainer destinationContainer = await GetTestContainerAsync();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };
            SingleTransferOptions singleTransferOptions = new SingleTransferOptions();
            FailureTransferHolder failureTransferHolder = new FailureTransferHolder(singleTransferOptions);
            TransferManager transferManager = new TransferManager(options);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            DataTransfer transfer = await CreateSingleLongTransferAsync(
                manager: transferManager,
                transferType: transferType,
                localDirectory: localDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                size: Constants.MB * 100,
                singleTransferOptions: singleTransferOptions);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            bool pauseSuccess = await transferManager.TryPauseTransferAsync(transfer, cancellationTokenSource.Token);

            // Assert
            failureTransferHolder.AssertFailureCheck();
            Assert.AreEqual(StorageTransferStatus.Paused, transfer.TransferStatus);
            Assert.IsTrue(pauseSuccess);

            // Check if Job Plan File exists in checkpointer path.
            JobPartPlanFileName fileName = new JobPartPlanFileName(
                checkpointerPath: checkpointerDirectory.DirectoryPath,
                id: transfer.Id,
                jobPartNumber: 0);
            Assert.IsTrue(File.Exists(fileName.FullPath));
        }

        [RecordedTest]
        public void TryPauseTransferAsync_Error()
        {
            // Arrange
            DisposingLocalDirectory checkpointerDirectory = GetTestLocalDirectory();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };
            TransferManager transferManager = new TransferManager(options);

            // Act / Assert
            Assert.CatchAsync( async () => await transferManager.TryPauseTransferAsync("bad transfer Id"));
        }

        [Test]
        [TestCase(TransferType.Upload)]
        [TestCase(TransferType.Download)]
        [TestCase(TransferType.AsyncCopy)]
        [TestCase(TransferType.SyncCopy)]
        //[Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        public async Task TryPauseTransferAsync_AlreadyPaused(TransferType transferType)
        {
            // Arrange
            DisposingLocalDirectory checkpointerDirectory = GetTestLocalDirectory();
            DisposingLocalDirectory localDirectory = GetTestLocalDirectory();
            DisposingBlobContainer sourceContainer = await GetTestContainerAsync();
            DisposingBlobContainer destinationContainer = await GetTestContainerAsync();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };
            SingleTransferOptions singleTransferOptions = new SingleTransferOptions();
            FailureTransferHolder failureTransferHolder = new FailureTransferHolder(singleTransferOptions);
            TransferManager transferManager = new TransferManager(options);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            DataTransfer transfer = await CreateSingleLongTransferAsync(
                manager: transferManager,
                transferType: transferType,
                localDirectory: localDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                size: Constants.MB * 100,
                singleTransferOptions: singleTransferOptions);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            bool pauseSuccess = await transferManager.TryPauseTransferAsync(transfer, cancellationTokenSource.Token);

            // Assert
            failureTransferHolder.AssertFailureCheck();
            Assert.AreEqual(StorageTransferStatus.Paused, transfer.TransferStatus);
            Assert.IsTrue(pauseSuccess);

            CancellationTokenSource cancellationTokenSource2 = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            bool pauseFailure = await transferManager.TryPauseTransferAsync(transfer, cancellationTokenSource2.Token);

            Assert.IsFalse(pauseFailure);

            // Check if Job Plan File exists in checkpointer path.
            JobPartPlanFileName fileName = new JobPartPlanFileName(
                checkpointerPath: checkpointerDirectory.DirectoryPath,
                id: transfer.Id,
                jobPartNumber: 0);
            Assert.IsTrue(File.Exists(fileName.FullPath));
        }

        [Test]
        [TestCase(TransferType.Upload)]
        [TestCase(TransferType.Download)]
        [TestCase(TransferType.AsyncCopy)]
        [TestCase(TransferType.SyncCopy)]
        //[Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        public async Task PauseThenResumeTransferAsync(TransferType transferType)
        {
            // Arrange
            DisposingLocalDirectory checkpointerDirectory = GetTestLocalDirectory();
            DisposingLocalDirectory localDirectory = GetTestLocalDirectory();
            DisposingBlobContainer sourceContainer = await GetTestContainerAsync();
            DisposingBlobContainer destinationContainer = await GetTestContainerAsync();
            ;
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };
            SingleTransferOptions singleTransferOptions = new SingleTransferOptions();
            FailureTransferHolder failureTransferHolder = new FailureTransferHolder(singleTransferOptions);
            TransferManager transferManager = new TransferManager(options);
            long size = Constants.MB * 100;

            (StorageResource sResource, StorageResource dResource) = await CreateStorageResourcesAsync(
                transferType: transferType,
                size: size,
                localDirectory: localDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container);
            StorageResource sourceResource = sResource;
            StorageResource destinationResource = dResource;

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            DataTransfer transfer = await CreateSingleLongTransferAsync(
                manager: transferManager,
                sourceResource: sourceResource,
                destinationResource: destinationResource,
                size: Constants.MB * 100,
                singleTransferOptions: singleTransferOptions);

            // Act - Pause Job
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            bool pauseSuccess = await transferManager.TryPauseTransferAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert - Confirm we've paused
            Assert.AreEqual(StorageTransferStatus.Paused, transfer.TransferStatus);
            failureTransferHolder.AssertFailureCheck();
            Assert.IsTrue(pauseSuccess);

            // Act - Resume Job
            SingleTransferOptions resumeOptions = new SingleTransferOptions()
            {
                ResumeFromCheckpointId = transfer.Id
            };
            FailureTransferHolder resumeFailureHolder = new FailureTransferHolder(resumeOptions);
            DataTransfer resumeTransfer = await CreateSingleLongTransferAsync(
                manager: transferManager,
                sourceResource: sourceResource,
                destinationResource: destinationResource,
                singleTransferOptions: resumeOptions,
                size: Constants.MB * 4);

            CancellationTokenSource waitTransferCompletion = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await resumeTransfer.AwaitCompletion(waitTransferCompletion.Token);

            resumeFailureHolder.AssertFailureCheck();
            Assert.AreEqual(StorageTransferStatus.Completed, resumeTransfer.TransferStatus);
            Assert.IsTrue(resumeTransfer.HasCompleted);
        }
    }
}
