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

        private BlockBlobStorageResource CreateBlobDestinationResourceAsync(
            BlobContainerClient container)
        {
            string blobName = GetNewBlobName();
            BlockBlobClient destinationClient = container.GetBlockBlobClient(blobName);
            return new BlockBlobStorageResource(destinationClient);
        }

        /// <summary>
        /// Upload and verify the contents of the blob
        ///
        /// By default in this function an event arguement will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        private async Task<DataTransfer> CreateLongTransferAsync(
            TransferManager manager,
            string sourceDirectory,
            BlobContainerClient destinationContainer,
            StorageResource sourceResource = default,
            StorageResource destinationResource = default,
            SingleTransferOptions singleTransferOptions = default,
            long size = Constants.MB)
        {
            sourceResource ??= await CreateLocalFileSourceResourceAsync(size, sourceDirectory);
            destinationResource ??= CreateBlobDestinationResourceAsync(destinationContainer);

            // Act
            return await manager.StartTransferAsync(sourceResource, destinationResource, singleTransferOptions);
        }

        [RecordedTest]
        public async Task TryPauseTransferAsync_Id()
        {
            // Arrange
            DisposingLocalDirectory checkpointerDirectory = GetTestLocalDirectory();
            DisposingLocalDirectory sourceDirectory = GetTestLocalDirectory();
            DisposingBlobContainer blobContainer = await GetTestContainerAsync();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 4
            };
            TransferManager transferManager = new TransferManager(options);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            DataTransfer transfer = await CreateLongTransferAsync(
                manager: transferManager,
                sourceDirectory: sourceDirectory.DirectoryPath,
                destinationContainer: blobContainer.Container,
                size: Constants.MB * 20);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            bool pauseSuccess = await transferManager.TryPauseTransferAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            Assert.IsTrue(pauseSuccess);
            Assert.AreEqual(StorageTransferStatus.Paused, transfer.TransferStatus);

            // Check if Job Plan File exists in checkpointer path.
            JobPartPlanFileName fileName = new JobPartPlanFileName(
                checkpointerPath: checkpointerDirectory.DirectoryPath,
                id: transfer.Id,
                jobPartNumber: 0);
            Assert.IsTrue(File.Exists(fileName.FullPath));
        }

        [RecordedTest]
        public async Task TryPauseTransferAsync_DataTransfer()
        {
            // Arrange
            DisposingLocalDirectory checkpointerDirectory = GetTestLocalDirectory();
            DisposingLocalDirectory sourceDirectory = GetTestLocalDirectory();
            DisposingBlobContainer blobContainer = await GetTestContainerAsync();
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
            DataTransfer transfer = await CreateLongTransferAsync(
                manager: transferManager,
                sourceDirectory: sourceDirectory.DirectoryPath,
                destinationContainer: blobContainer.Container,
                size: Constants.MB * 4,
                singleTransferOptions: singleTransferOptions);

            // Act
            bool pauseSuccess = await transferManager.TryPauseTransferAsync(transfer);

            // Assert
            failureTransferHolder.AssertFailureCheck();
            Assert.IsTrue(pauseSuccess);
            Assert.AreEqual(StorageTransferStatus.Paused, transfer.TransferStatus);

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

        [RecordedTest]
        public async Task TryPauseTransferAsync_AlreadyPaused()
        {
            // Arrange
            DisposingLocalDirectory checkpointerDirectory = GetTestLocalDirectory();
            DisposingLocalDirectory sourceDirectory = GetTestLocalDirectory();
            DisposingBlobContainer blobContainer = await GetTestContainerAsync();
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
            DataTransfer transfer = await CreateLongTransferAsync(
                manager: transferManager,
                sourceDirectory: sourceDirectory.DirectoryPath,
                destinationContainer: blobContainer.Container,
                size: Constants.MB * 4,
                singleTransferOptions: singleTransferOptions);

            // Act
            bool pauseSuccess = await transferManager.TryPauseTransferAsync(transfer);

            // Assert
            failureTransferHolder.AssertFailureCheck();
            Assert.IsTrue(pauseSuccess);
            Assert.AreEqual(StorageTransferStatus.Paused, transfer.TransferStatus);

            bool pauseFailure = await transferManager.TryPauseTransferAsync(transfer);

            Assert.IsFalse(pauseFailure);

            // Check if Job Plan File exists in checkpointer path.
            JobPartPlanFileName fileName = new JobPartPlanFileName(
                checkpointerPath: checkpointerDirectory.DirectoryPath,
                id: transfer.Id,
                jobPartNumber: 0);
            Assert.IsTrue(File.Exists(fileName.FullPath));
        }

        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/35439
        [Test]
        public async Task PauseThenResumeTransferAsync()
        {
            // Arrange
            DisposingLocalDirectory checkpointerDirectory = GetTestLocalDirectory();
            DisposingLocalDirectory sourceDirectory = GetTestLocalDirectory();
            DisposingBlobContainer blobContainer = await GetTestContainerAsync();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };
            SingleTransferOptions singleTransferOptions = new SingleTransferOptions();
            FailureTransferHolder failureTransferHolder = new FailureTransferHolder(singleTransferOptions);
            TransferManager transferManager = new TransferManager(options);

            StorageResource sourceResource = await CreateLocalFileSourceResourceAsync(Constants.MB * 4, sourceDirectory.DirectoryPath);
            StorageResource destinationResource = CreateBlobDestinationResourceAsync(blobContainer.Container);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            DataTransfer transfer = await CreateLongTransferAsync(
                manager: transferManager,
                sourceDirectory: sourceDirectory.DirectoryPath,
                destinationContainer: blobContainer.Container,
                sourceResource: sourceResource,
                destinationResource: destinationResource,
                size: Constants.MB * 4,
                singleTransferOptions: singleTransferOptions);

            // Act - Pause Job
            bool pauseSuccess = await transferManager.TryPauseTransferAsync(transfer.Id);

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
            DataTransfer resumeTransfer = await CreateLongTransferAsync(
                manager: transferManager,
                sourceDirectory: sourceDirectory.DirectoryPath,
                destinationContainer: blobContainer.Container,
                sourceResource: sourceResource,
                destinationResource: destinationResource,
                singleTransferOptions: resumeOptions,
                size: Constants.MB * 4);

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await resumeTransfer.AwaitCompletion(cancellationTokenSource.Token);

            resumeFailureHolder.AssertFailureCheck();
            Assert.IsTrue(resumeTransfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.Completed, resumeTransfer.TransferStatus);
        }
    }
}
