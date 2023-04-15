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
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Options;

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
                DestinationResource ??= new LocalFileStorageResource(Path.Combine(localDirectory, GetNewBlobName()));
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

        [LiveOnly]
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

        [LiveOnly]
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
            Assert.CatchAsync(async () => await transferManager.TryPauseTransferAsync("bad transfer Id"));
        }

        [LiveOnly]
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

        [LiveOnly]
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
            DisposingBlobContainer sourceContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            DisposingBlobContainer destinationContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };
            SingleTransferOptions singleTransferOptions = new SingleTransferOptions();
            FailureTransferHolder failureTransferHolder = new FailureTransferHolder(singleTransferOptions);
            TransferManager transferManager = new TransferManager(options);
            long size = Constants.MB * 40;

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
                singleTransferOptions: resumeOptions);

            CancellationTokenSource waitTransferCompletion = new CancellationTokenSource(TimeSpan.FromSeconds(600));
            await resumeTransfer.AwaitCompletion(waitTransferCompletion.Token);

            resumeFailureHolder.AssertFailureCheck();
            Assert.AreEqual(StorageTransferStatus.Completed, resumeTransfer.TransferStatus);
            Assert.IsTrue(resumeTransfer.HasCompleted);
        }

        private async Task<BlobDirectoryStorageResourceContainer> CreateBlobDirectorySourceResourceAsync(
            long size,
            int blobCount,
            string directoryPath,
            BlobContainerClient container,
            BlobStorageResourceContainerOptions options = default)
        {
            for (int i = 0; i < blobCount; i++)
            {
                BlockBlobClient blobClient = container.GetBlockBlobClient(GetNewBlobName());
                // create a new file and copy contents of stream into it, and then close the FileStream
                // so the StagedUploadAsync call is not prevented from reading using its FileStream.
                using (Stream originalStream = await CreateLimitedMemoryStream(size))
                {
                    // Upload blob to storage account
                    originalStream.Position = 0;
                    await blobClient.UploadAsync(originalStream);
                }
            }
            return new BlobDirectoryStorageResourceContainer(container, directoryPath, options);
        }

        private async Task<LocalDirectoryStorageResourceContainer> CreateLocalDirectorySourceResourceAsync(
            long size,
            int fileCount,
            string directoryPath)
        {
            for (int i = 0; i < fileCount; i++)
            {
                await CreateRandomFileAsync(directoryPath, size: size);
            }
            return new LocalDirectoryStorageResourceContainer(directoryPath);
        }

        private async Task<(StorageResourceContainer SourceResource, StorageResourceContainer DestinationResource)> CreateStorageResourceContainersAsync(
            TransferType transferType,
            long size,
            int transferCount,
            string sourceDirectoryPath,
            string destinationDirectoryPath,
            BlobContainerClient sourceContainer,
            BlobContainerClient destinationContainer)
        {
            StorageResourceContainer SourceResource = default;
            StorageResourceContainer DestinationResource = default;
            if (transferType == TransferType.Download)
            {
                Argument.AssertNotNull(sourceContainer, nameof(sourceContainer));
                Argument.AssertNotNullOrEmpty(destinationDirectoryPath, nameof(destinationDirectoryPath));
                SourceResource ??= await CreateBlobDirectorySourceResourceAsync(
                    size: size,
                    blobCount: transferCount,
                    directoryPath: GetNewBlobDirectoryName(),
                    container: sourceContainer);
                DestinationResource ??= new LocalDirectoryStorageResourceContainer(Path.Combine(destinationDirectoryPath, GetNewBlobName()));
            }
            else if (transferType == TransferType.SyncCopy || transferType == TransferType.AsyncCopy)
            {
                Argument.AssertNotNull(sourceContainer, nameof(sourceContainer));
                Argument.AssertNotNull(destinationContainer, nameof(destinationContainer));
                BlobStorageResourceContainerOptions options = new BlobStorageResourceContainerOptions()
                {
                    CopyMethod = transferType == TransferType.SyncCopy ? TransferCopyMethod.SyncCopy : TransferCopyMethod.AsyncCopy
                };
                SourceResource ??= await CreateBlobDirectorySourceResourceAsync(
                    size: size,
                    blobCount: transferCount,
                    directoryPath: GetNewBlobDirectoryName(),
                    container: sourceContainer);
                DestinationResource ??= new BlobDirectoryStorageResourceContainer(destinationContainer, destinationDirectoryPath, options);
            }
            else
            {
                // Default to Upload
                Argument.AssertNotNullOrEmpty(sourceDirectoryPath, nameof(sourceDirectoryPath));
                Argument.AssertNotNull(destinationContainer, nameof(destinationContainer));
                SourceResource ??= await CreateLocalDirectorySourceResourceAsync(
                    size: size,
                    fileCount: transferCount,
                    directoryPath: sourceDirectoryPath);
                DestinationResource ??= new BlobDirectoryStorageResourceContainer(destinationContainer, destinationDirectoryPath);
            }
            return (SourceResource, DestinationResource);
        }

        /// <summary>
        /// Upload and verify the contents of the blob
        ///
        /// By default in this function an event arguement will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        private async Task<DataTransfer> CreateDirectoryLongTransferAsync(
            TransferManager manager,
            TransferType transferType = TransferType.Upload,
            string sourceDirectory = default,
            string destinationDirectory = default,
            BlobContainerClient sourceContainer = default,
            BlobContainerClient destinationContainer = default,
            StorageResourceContainer sourceResource = default,
            StorageResourceContainer destinationResource = default,
            ContainerTransferOptions containerTransferOptions = default,
            int transferCount = 100,
            long size = Constants.MB)
        {
            Argument.AssertNotNull(manager, nameof(manager));
            if (sourceResource == default && destinationResource == default)
            {
                (StorageResourceContainer source, StorageResourceContainer dest) = await CreateStorageResourceContainersAsync(
                    transferType: transferType,
                    size: size,
                    transferCount: transferCount,
                    sourceDirectoryPath: sourceDirectory,
                    destinationDirectoryPath: destinationDirectory,
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
            return await manager.StartTransferAsync(sourceResource, destinationResource, containerTransferOptions);
        }

        [LiveOnly]
        [Test]
        [TestCase(TransferType.Upload)]
        [TestCase(TransferType.Download)]
        [TestCase(TransferType.AsyncCopy)]
        [TestCase(TransferType.SyncCopy)]
        //[Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        public async Task TryPauseTransferAsync_Id_Directory(TransferType transferType)
        {
            // Arrange
            DisposingLocalDirectory checkpointerDirectory = GetTestLocalDirectory();
            DisposingLocalDirectory sourceDirectory = GetTestLocalDirectory();
            DisposingLocalDirectory destinationDirectory = GetTestLocalDirectory();
            DisposingBlobContainer sourceContainer = await GetTestContainerAsync();
            DisposingBlobContainer destinationContainer = await GetTestContainerAsync();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
            };
            TransferManager transferManager = new TransferManager(options);
            ContainerTransferOptions containerTransferOptions = new ContainerTransferOptions();
            FailureTransferHolder failureTransferHolder = new FailureTransferHolder(containerTransferOptions);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            int partCount = 4;
            DataTransfer transfer = await CreateDirectoryLongTransferAsync(
                manager: transferManager,
                transferType: transferType,
                sourceDirectory: sourceDirectory.DirectoryPath,
                destinationDirectory: destinationDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                size: Constants.MB * 10,
                transferCount: partCount,
                containerTransferOptions: containerTransferOptions);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            bool pauseSuccess = await transferManager.TryPauseTransferAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            failureTransferHolder.AssertFailureCheck();
            Assert.AreEqual(StorageTransferStatus.Paused, transfer.TransferStatus);
            Assert.IsTrue(pauseSuccess);
        }

        [LiveOnly]
        [Test]
        [TestCase(TransferType.Upload)]
        [TestCase(TransferType.Download)]
        [TestCase(TransferType.AsyncCopy)]
        [TestCase(TransferType.SyncCopy)]
        //[Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        public async Task TryPauseTransferAsync_DataTransfer_Directory(TransferType transferType)
        {
            // Arrange
            DisposingLocalDirectory checkpointerDirectory = GetTestLocalDirectory();
            DisposingLocalDirectory sourceDirectory = GetTestLocalDirectory();
            DisposingLocalDirectory destinationDirectory = GetTestLocalDirectory();
            DisposingBlobContainer sourceContainer = await GetTestContainerAsync();
            DisposingBlobContainer destinationContainer = await GetTestContainerAsync();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
            };
            TransferManager transferManager = new TransferManager(options);
            ContainerTransferOptions containerTransferOptions = new ContainerTransferOptions();
            FailureTransferHolder failureTransferHolder = new FailureTransferHolder(containerTransferOptions);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            int partCount = 10;
            DataTransfer transfer = await CreateDirectoryLongTransferAsync(
                manager: transferManager,
                transferType: transferType,
                sourceDirectory: sourceDirectory.DirectoryPath,
                destinationDirectory: destinationDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                size: Constants.MB * 10,
                transferCount: partCount,
                containerTransferOptions: containerTransferOptions);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            bool pauseSuccess = await transferManager.TryPauseTransferAsync(transfer, cancellationTokenSource.Token);

            // Assert
            failureTransferHolder.AssertFailureCheck();
            Assert.AreEqual(StorageTransferStatus.Paused, transfer.TransferStatus);
            Assert.IsTrue(pauseSuccess);
        }

        [LiveOnly]
        [Test]
        [TestCase(TransferType.Upload)]
        [TestCase(TransferType.Download)]
        [TestCase(TransferType.AsyncCopy)]
        [TestCase(TransferType.SyncCopy)]
        //[Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        public async Task TryPauseTransferAsync_AlreadyPaused_Directory(TransferType transferType)
        {
            // Arrange
            DisposingLocalDirectory checkpointerDirectory = GetTestLocalDirectory();
            DisposingLocalDirectory sourceDirectory = GetTestLocalDirectory();
            DisposingLocalDirectory destinationDirectory = GetTestLocalDirectory();
            DisposingBlobContainer sourceContainer = await GetTestContainerAsync();
            DisposingBlobContainer destinationContainer = await GetTestContainerAsync();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
            };
            TransferManager transferManager = new TransferManager(options);
            ContainerTransferOptions containerTransferOptions = new ContainerTransferOptions();
            FailureTransferHolder failureTransferHolder = new FailureTransferHolder(containerTransferOptions);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            int partCount = 10;
            DataTransfer transfer = await CreateDirectoryLongTransferAsync(
                manager: transferManager,
                transferType: transferType,
                sourceDirectory: sourceDirectory.DirectoryPath,
                destinationDirectory: destinationDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                size: Constants.MB * 10,
                transferCount: partCount,
                containerTransferOptions: containerTransferOptions);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            bool pauseSuccess = await transferManager.TryPauseTransferAsync(transfer, cancellationTokenSource.Token);

            // Assert
            failureTransferHolder.AssertFailureCheck();
            Assert.AreEqual(StorageTransferStatus.Paused, transfer.TransferStatus);
            Assert.IsTrue(pauseSuccess);

            CancellationTokenSource cancellationTokenSource2 = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            bool pauseFailure = await transferManager.TryPauseTransferAsync(transfer, cancellationTokenSource2.Token);

            failureTransferHolder.AssertFailureCheck();
            Assert.IsFalse(pauseFailure);
            Assert.AreEqual(StorageTransferStatus.Paused, transfer.TransferStatus);
        }

        [LiveOnly]
        [Test]
        [TestCase(TransferType.Upload)]
        [TestCase(TransferType.Download)]
        [TestCase(TransferType.AsyncCopy)]
        [TestCase(TransferType.SyncCopy)]
        //[Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        public async Task PauseThenResumeTransferAsync_Directory(TransferType transferType)
        {
            // Arrange
            DisposingLocalDirectory checkpointerDirectory = GetTestLocalDirectory();
            DisposingLocalDirectory sourceDirectory = GetTestLocalDirectory();
            DisposingLocalDirectory destinationDirectory = GetTestLocalDirectory();
            DisposingBlobContainer sourceContainer = await GetTestContainerAsync();
            DisposingBlobContainer destinationContainer = await GetTestContainerAsync();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointerOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
            };
            TransferManager transferManager = new TransferManager(options);
            ContainerTransferOptions containerTransferOptions = new ContainerTransferOptions();
            FailureTransferHolder failureTransferHolder = new FailureTransferHolder(containerTransferOptions);
            long size = Constants.MB * 10;
            int partCount = 4;

            (StorageResourceContainer sResource, StorageResourceContainer dResource) = await CreateStorageResourceContainersAsync(
                transferType: transferType,
                size: size,
                transferCount: partCount,
                sourceDirectoryPath: sourceDirectory.DirectoryPath,
                destinationDirectoryPath: destinationDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container);
            StorageResourceContainer sourceResource = sResource;
            StorageResourceContainer destinationResource = dResource;

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            DataTransfer transfer = await CreateDirectoryLongTransferAsync(
                manager: transferManager,
                sourceResource: sourceResource,
                destinationResource: destinationResource,
                containerTransferOptions: containerTransferOptions);

            // Act - Pause Job
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            bool pauseSuccess = await transferManager.TryPauseTransferAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert - Confirm we've paused
            Assert.AreEqual(StorageTransferStatus.Paused, transfer.TransferStatus);
            failureTransferHolder.AssertFailureCheck();
            Assert.IsTrue(pauseSuccess);

            // Act - Resume Job
            ContainerTransferOptions resumeOptions = new ContainerTransferOptions()
            {
                ResumeFromCheckpointId = transfer.Id
            };
            FailureTransferHolder resumeFailureHolder = new FailureTransferHolder(resumeOptions);
            DataTransfer resumeTransfer = await CreateDirectoryLongTransferAsync(
                manager: transferManager,
                sourceResource: sourceResource,
                destinationResource: destinationResource,
                containerTransferOptions: resumeOptions);

            CancellationTokenSource waitTransferCompletion = new CancellationTokenSource(TimeSpan.FromSeconds(600));
            await resumeTransfer.AwaitCompletion(waitTransferCompletion.Token);

            resumeFailureHolder.AssertFailureCheck();
            Assert.AreEqual(StorageTransferStatus.Completed, resumeTransfer.TransferStatus);
            Assert.IsTrue(resumeTransfer.HasCompleted);
        }
    }
}
