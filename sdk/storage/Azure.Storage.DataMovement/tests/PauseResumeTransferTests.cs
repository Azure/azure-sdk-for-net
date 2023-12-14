// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.DataMovement.JobPlan;
using Azure.Storage.Test;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class PauseResumeTransferTests : DataMovementBlobTestBase
    {
        private readonly CancellationToken _mockingToken = new();

        public PauseResumeTransferTests(
            bool async,
            BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, default)
        {
        }

        private async Task AssertDirectorySourceAndDestinationAsync(
            TransferDirection transferType,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource,
            BlobContainerClient sourceContainer,
            BlobContainerClient destinationContainer)
        {
            await foreach (StorageResourceItem childSourceResource in sourceResource.GetStorageResourcesAsync())
            {
                StorageResourceItem childDestinationResource;
                if (transferType == TransferDirection.Upload)
                {
                    string destinationChildName = childSourceResource.Uri.LocalPath.Substring(sourceResource.Uri.LocalPath.Length + 1);
                    childDestinationResource = destinationResource.GetStorageResourceReference(destinationChildName);
                }
                else
                {
                    string destinationChildName = childSourceResource.Uri.AbsoluteUri.Substring(sourceResource.Uri.AbsoluteUri.Length + 1);
                    childDestinationResource = destinationResource.GetStorageResourceReference(destinationChildName);
                }
                await AssertSourceAndDestinationAsync(
                    transferType: transferType,
                    sourceResource: childSourceResource,
                    destinationResource: childDestinationResource,
                    sourceContainer: sourceContainer,
                    destinationContainer: destinationContainer);
            }
        }

        private async Task AssertSourceAndDestinationAsync(
            TransferDirection transferType,
            StorageResource sourceResource,
            StorageResource destinationResource,
            BlobContainerClient sourceContainer,
            BlobContainerClient destinationContainer)
        {
            if (transferType == TransferDirection.Upload)
            {
                // Verify Upload by downloading the blob and comparing the values
                BlobUriBuilder destinationBuilder = new BlobUriBuilder(destinationResource.Uri);
                using (FileStream fileStream = File.OpenRead(sourceResource.Uri.LocalPath))
                {
                    await DownloadAndAssertAsync(fileStream, destinationContainer.GetBlockBlobClient(destinationBuilder.BlobName));
                }
            }
            else if (transferType == TransferDirection.Download)
            {
                // Verify Download
                BlobUriBuilder sourceBuilder = new BlobUriBuilder(sourceResource.Uri);
                using (FileStream fileStream = File.OpenRead(destinationResource.Uri.LocalPath))
                {
                    await DownloadAndAssertAsync(fileStream, sourceContainer.GetBlockBlobClient(sourceBuilder.BlobName));
                }
            }
            else
            {
                BlobUriBuilder sourceBuilder = new BlobUriBuilder(sourceResource.Uri);
                BlobUriBuilder destinationBuilder = new BlobUriBuilder(destinationResource.Uri);

                await DownloadCopyBlobAndAssert(
                    sourceContainer.GetBlobBaseClient(sourceBuilder.BlobName),
                    destinationContainer.GetBlobBaseClient(destinationBuilder.BlobName));
            }
        }

        private async Task<StorageResource> CreateLocalFileSourceResourceAsync(
            long size,
            string directory,
            LocalFilesStorageResourceProvider provider)
        {
            string localSourceFile = await CreateRandomFileAsync(directory);
            // create a new file and copy contents of stream into it, and then close the FileStream
            // so the StagedUploadAsync call is not prevented from reading using its FileStream.
            using Stream originalStream = await CreateLimitedMemoryStream(size);
            using (FileStream fileStream = File.Create(localSourceFile))
            {
                await originalStream.CopyToAsync(fileStream);
            }
            return provider.FromFile(localSourceFile);
        }

        private async Task<StorageResource> CreateBlobSourceResourceAsync(
            long size,
            string blobName,
            BlobContainerClient container,
            BlobsStorageResourceProvider provider,
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
            return provider.FromClient(blobClient, options);
        }

        private StorageResource CreateBlobDestinationResource(
            BlobContainerClient container,
            BlobsStorageResourceProvider provider,
            string blobName = default,
            BlockBlobStorageResourceOptions options = default)
        {
            blobName ??= GetNewBlobName();
            BlockBlobClient destinationClient = container.GetBlockBlobClient(blobName);
            return provider.FromClient(destinationClient, options);
        }

        private async Task<(StorageResource SourceResource, StorageResource DestinationResource)> CreateStorageResourcesAsync(
            TransferDirection transferType,
            long size,
            string localDirectory,
            BlobContainerClient sourceContainer,
            BlobContainerClient destinationContainer,
            BlobsStorageResourceProvider blobProvider,
            LocalFilesStorageResourceProvider localProvider,
            string storagePath = default)
        {
            storagePath ??= GetNewBlobName();

            StorageResource SourceResource = default;
            StorageResource DestinationResource = default;
            if (transferType == TransferDirection.Download)
            {
                Argument.AssertNotNull(sourceContainer, nameof(sourceContainer));
                Argument.AssertNotNullOrEmpty(localDirectory, nameof(localDirectory));
                SourceResource ??= await CreateBlobSourceResourceAsync(size, storagePath, sourceContainer, blobProvider);
                DestinationResource ??= localProvider.FromFile(Path.Combine(localDirectory, storagePath));
            }
            else if (transferType == TransferDirection.Copy)
            {
                Argument.AssertNotNull(sourceContainer, nameof(sourceContainer));
                Argument.AssertNotNull(destinationContainer, nameof(destinationContainer));
                SourceResource ??= await CreateBlobSourceResourceAsync(size, storagePath, sourceContainer, blobProvider);
                DestinationResource ??= CreateBlobDestinationResource(destinationContainer, blobProvider, storagePath);
            }
            else
            {
                // Default to Upload
                Argument.AssertNotNullOrEmpty(localDirectory, nameof(localDirectory));
                Argument.AssertNotNull(destinationContainer, nameof(destinationContainer));
                SourceResource ??= await CreateLocalFileSourceResourceAsync(size, localDirectory, localProvider);
                DestinationResource ??= CreateBlobDestinationResource(destinationContainer, blobProvider, storagePath);
            }
            return (SourceResource, DestinationResource);
        }

        /// <summary>
        /// Upload and verify the contents of the blob
        ///
        /// By default in this function an event argument will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        private async Task<DataTransfer> CreateSingleLongTransferAsync(
            TransferManager manager,
            TransferDirection transferType = TransferDirection.Upload,
            string localDirectory = default,
            BlobContainerClient sourceContainer = default,
            BlobContainerClient destinationContainer = default,
            StorageResource sourceResource = default,
            StorageResource destinationResource = default,
            DataTransferOptions transferOptions = default,
            long size = Constants.KB * 100,
            BlobsStorageResourceProvider blobProvider = default,
            LocalFilesStorageResourceProvider localProvider = default)
        {
            Argument.AssertNotNull(manager, nameof(manager));
            if (sourceResource == default && destinationResource == default)
            {
                (StorageResource source, StorageResource dest) = await CreateStorageResourcesAsync(
                    transferType: transferType,
                    size: size,
                    localDirectory: localDirectory,
                    sourceContainer: sourceContainer,
                    destinationContainer: destinationContainer,
                    blobProvider: blobProvider,
                    localProvider: localProvider);
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
            return await manager.StartTransferAsync(sourceResource, destinationResource, transferOptions);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        [RecordedTest]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task TryPauseTransferAsync_Id(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer sourceContainer = await GetTestContainerAsync();
            await using DisposingContainer destinationContainer = await GetTestContainerAsync();

            BlobsStorageResourceProvider blobProvider = new(GetSharedKeyCredential());
            LocalFilesStorageResourceProvider localProvider = new();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointStoreOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                ResumeProviders = new() { blobProvider, localProvider },
            };
            TransferManager transferManager = new TransferManager(options);
            DataTransferOptions transferOptions = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            DataTransfer transfer = await CreateSingleLongTransferAsync(
                manager: transferManager,
                transferType: transferType,
                localDirectory: localDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                size: Constants.KB * 100,
                transferOptions: transferOptions,
                blobProvider: blobProvider,
                localProvider: localProvider);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transferManager.PauseTransferIfRunningAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(DataTransferState.Paused, transfer.TransferStatus.State);

            // Check if Job Plan File exists in checkpointer path.
            JobPartPlanFileName fileName = new JobPartPlanFileName(
                checkpointerPath: checkpointerDirectory.DirectoryPath,
                id: transfer.Id,
                jobPartNumber: 0);
            Assert.IsTrue(File.Exists(fileName.FullPath));
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        [RecordedTest]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task TryPauseTransferAsync_DataTransfer(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer sourceContainer = await GetTestContainerAsync();
            await using DisposingContainer destinationContainer = await GetTestContainerAsync();

            BlobsStorageResourceProvider blobProvider = new(GetSharedKeyCredential());
            LocalFilesStorageResourceProvider localProvider = new();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointStoreOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                ResumeProviders = new() { blobProvider, localProvider },
            };
            DataTransferOptions transferOptions = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);
            TransferManager transferManager = new TransferManager(options);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            DataTransfer transfer = await CreateSingleLongTransferAsync(
                manager: transferManager,
                transferType: transferType,
                localDirectory: localDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                size: Constants.KB * 100,
                transferOptions: transferOptions,
                blobProvider: blobProvider,
                localProvider: localProvider);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transferManager.PauseTransferIfRunningAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(DataTransferState.Paused, transfer.TransferStatus.State);

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
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointStoreOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure
            };
            TransferManager transferManager = new TransferManager(options);

            // Act / Assert
            Assert.CatchAsync(async () => await transferManager.PauseTransferIfRunningAsync("bad transfer Id"));
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        [RecordedTest]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task TryPauseTransferAsync_AlreadyPaused(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer sourceContainer = await GetTestContainerAsync();
            await using DisposingContainer destinationContainer = await GetTestContainerAsync();

            BlobsStorageResourceProvider blobProvider = new(GetSharedKeyCredential());
            LocalFilesStorageResourceProvider localProvider = new();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointStoreOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                ResumeProviders = new() { blobProvider, localProvider },
            };
            DataTransferOptions transferOptions = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);
            TransferManager transferManager = new TransferManager(options);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            DataTransfer transfer = await CreateSingleLongTransferAsync(
                manager: transferManager,
                transferType: transferType,
                localDirectory: localDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                size: Constants.KB * 100,
                transferOptions: transferOptions,
                blobProvider: blobProvider,
                localProvider: localProvider);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transferManager.PauseTransferIfRunningAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(DataTransferState.Paused, transfer.TransferStatus.State);

            CancellationTokenSource cancellationTokenSource2 = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transferManager.PauseTransferIfRunningAsync(transfer.Id, cancellationTokenSource2.Token);

            Assert.AreEqual(DataTransferState.Paused, transfer.TransferStatus.State);

            // Check if Job Plan File exists in checkpointer path.
            JobPartPlanFileName fileName = new JobPartPlanFileName(
                checkpointerPath: checkpointerDirectory.DirectoryPath,
                id: transfer.Id,
                jobPartNumber: 0);
            Assert.IsTrue(File.Exists(fileName.FullPath));
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        [RecordedTest]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task PauseThenResumeTransferAsync(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer sourceContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            await using DisposingContainer destinationContainer = await GetTestContainerAsync();

            BlobsStorageResourceProvider blobProvider = new(GetSharedKeyCredential());
            LocalFilesStorageResourceProvider localProvider = new();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointStoreOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                ResumeProviders = new() { blobProvider, localProvider },
            };
            DataTransferOptions transferOptions = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);
            TransferManager transferManager = new TransferManager(options);
            long size = Constants.KB * 100;

            (StorageResource sResource, StorageResource dResource) = await CreateStorageResourcesAsync(
                transferType: transferType,
                size: size,
                localDirectory: localDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                blobProvider: blobProvider,
                localProvider: localProvider);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            DataTransfer transfer = await CreateSingleLongTransferAsync(
                manager: transferManager,
                sourceResource: sResource,
                destinationResource: dResource,
                transferOptions: transferOptions);

            // Act - Pause Job
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transferManager.PauseTransferIfRunningAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert - Confirm we've paused
            Assert.AreEqual(DataTransferState.Paused, transfer.TransferStatus.State);
            await testEventsRaised.AssertPausedCheck();

            // Act - Resume Job
            DataTransferOptions resumeOptions = new DataTransferOptions();
            TestEventsRaised testEventRaised2 = new TestEventsRaised(resumeOptions);
            DataTransfer resumeTransfer = await transferManager.ResumeTransferAsync(
                transferId: transfer.Id,
                transferOptions: resumeOptions);

            CancellationTokenSource waitTransferCompletion = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await resumeTransfer.WaitForCompletionAsync(waitTransferCompletion.Token);

            // Assert
            await testEventRaised2.AssertSingleCompletedCheck();
            Assert.AreEqual(DataTransferState.Completed, resumeTransfer.TransferStatus.State);
            Assert.IsTrue(resumeTransfer.HasCompleted);

            // Verify transfer
            await AssertSourceAndDestinationAsync(
                transferType: transferType,
                sourceResource: sResource,
                destinationResource: dResource,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        [RecordedTest]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task ResumeTransferAsync(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer sourceContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            await using DisposingContainer destinationContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            BlobsStorageResourceProvider blobProvider = new(GetSharedKeyCredential());
            LocalFilesStorageResourceProvider localProvider = new();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointStoreOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                ResumeProviders = new() { blobProvider, localProvider },
            };
            DataTransferOptions transferOptions = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);
            TransferManager transferManager = new TransferManager(options);
            long size = Constants.KB * 100;

            (StorageResource sResource, StorageResource dResource) = await CreateStorageResourcesAsync(
                transferType: transferType,
                size: size,
                localDirectory: localDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                blobProvider: blobProvider,
                localProvider: localProvider);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            DataTransfer transfer = await CreateSingleLongTransferAsync(
                manager: transferManager,
                sourceResource: sResource,
                destinationResource: dResource,
                transferOptions: transferOptions);

            // Act - Pause Job
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transferManager.PauseTransferIfRunningAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert - Confirm we've paused
            Assert.AreEqual(DataTransferState.Paused, transfer.TransferStatus.State);
            await testEventsRaised.AssertPausedCheck();

            // Act - Resume Job
            DataTransferOptions resumeOptions = new();
            TestEventsRaised testEventRaised2 = new TestEventsRaised(resumeOptions);
            DataTransfer resumeTransfer = await transferManager.ResumeTransferAsync(
                transfer.Id,
                resumeOptions);

            CancellationTokenSource waitTransferCompletion = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await resumeTransfer.WaitForCompletionAsync(waitTransferCompletion.Token);

            // Assert
            await testEventRaised2.AssertSingleCompletedCheck();
            Assert.AreEqual(DataTransferState.Completed, resumeTransfer.TransferStatus.State);
            Assert.IsTrue(resumeTransfer.HasCompleted);

            // Verify transfer
            await AssertSourceAndDestinationAsync(
                transferType: transferType,
                sourceResource: sResource,
                destinationResource: dResource,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        [Test]
        [LiveOnly]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Copy)]
        public async Task ResumeTransferAsync_Options(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer blobContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            BlobsStorageResourceProvider blobProvider = new(GetSharedKeyCredential());
            LocalFilesStorageResourceProvider localProvider = new();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointStoreOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                ResumeProviders = new() { blobProvider, localProvider },
            };
            TransferManager transferManager = new TransferManager(options);

            BlockBlobStorageResourceOptions testOptions = new()
            {
                Metadata = DataProvider.BuildMetadata(),
                Tags = DataProvider.BuildTags(),
                AccessTier = AccessTier.Cool,
                HttpHeaders = new BlobHttpHeaders()
                {
                    ContentLanguage = "en-US",
                },
            };

            long size = Constants.KB;
            StorageResource source;
            StorageResource destination;
            if (transferType == TransferDirection.Upload)
            {
                source = await CreateLocalFileSourceResourceAsync(size, localDirectory.DirectoryPath, localProvider);
                destination = CreateBlobDestinationResource(blobContainer.Container, blobProvider, options: testOptions);
            }
            else // Copy
            {
                source = await CreateBlobSourceResourceAsync(size, GetNewBlobName(), blobContainer.Container, blobProvider);
                destination = CreateBlobDestinationResource(blobContainer.Container, blobProvider, options: testOptions);
            }

            DataTransfer transfer = await transferManager.StartTransferAsync(source, destination);

            // Act - Pause Job
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transferManager.PauseTransferIfRunningAsync(transfer.Id, cancellationTokenSource.Token);
            Assert.AreEqual(DataTransferState.Paused, transfer.TransferStatus.State);

            // Act - Resume Job
            DataTransfer resumeTransfer = await transferManager.ResumeTransferAsync(transfer.Id);
            CancellationTokenSource waitTransferCompletion = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await resumeTransfer.WaitForCompletionAsync(waitTransferCompletion.Token);

            // Assert
            Assert.AreEqual(DataTransferState.Completed, resumeTransfer.TransferStatus.State);
            Assert.IsTrue(resumeTransfer.HasCompleted);

            BlobUriBuilder builder = new BlobUriBuilder(destination.Uri);
            BlockBlobClient blob = blobContainer.Container.GetBlockBlobClient(builder.BlobName);
            BlobProperties props = (await blob.GetPropertiesAsync()).Value;
            Assert.AreEqual(testOptions.Metadata, props.Metadata);
            Assert.AreEqual(testOptions.Tags.Count, props.TagCount);
            Assert.AreEqual(testOptions.AccessTier, new AccessTier(props.AccessTier));
            Assert.AreEqual(testOptions.HttpHeaders.ContentLanguage, props.ContentLanguage);
        }

        private async Task<StorageResource> CreateBlobDirectorySourceResourceAsync(
            long size,
            int blobCount,
            string directoryPath,
            BlobContainerClient container,
            BlobsStorageResourceProvider provider,
            BlobStorageResourceContainerOptions options = default)
        {
            for (int i = 0; i < blobCount; i++)
            {
                BlockBlobClient blobClient = container.GetBlockBlobClient(string.Join("/", directoryPath, GetNewBlobName()));
                // create a new file and copy contents of stream into it, and then close the FileStream
                // so the StagedUploadAsync call is not prevented from reading using its FileStream.
                using (Stream originalStream = await CreateLimitedMemoryStream(size))
                {
                    // Upload blob to storage account
                    originalStream.Position = 0;
                    await blobClient.UploadAsync(originalStream);
                }
            }
            options ??= new();
            options.BlobDirectoryPrefix = directoryPath;
            return provider.FromClient(container, options);
        }

        private async Task<StorageResource> CreateLocalDirectorySourceResourceAsync(
            long size,
            int fileCount,
            string directoryPath,
            LocalFilesStorageResourceProvider provider)
        {
            for (int i = 0; i < fileCount; i++)
            {
                await CreateRandomFileAsync(directoryPath, size: size);
            }
            return provider.FromDirectory(directoryPath);
        }

        private async Task<(StorageResource SourceResource, StorageResource DestinationResource)> CreateStorageResourceContainersAsync(
            TransferDirection transferType,
            long size,
            int transferCount,
            string sourceDirectoryPath,
            string destinationDirectoryPath,
            BlobContainerClient sourceContainer,
            BlobContainerClient destinationContainer,
            BlobsStorageResourceProvider blobProvider,
            LocalFilesStorageResourceProvider localProvider)
        {
            StorageResource SourceResource = default;
            StorageResource DestinationResource = default;
            if (transferType == TransferDirection.Download)
            {
                Argument.AssertNotNull(sourceContainer, nameof(sourceContainer));
                Argument.AssertNotNullOrEmpty(destinationDirectoryPath, nameof(destinationDirectoryPath));
                SourceResource ??= await CreateBlobDirectorySourceResourceAsync(
                    size: size,
                    blobCount: transferCount,
                    directoryPath: GetNewBlobDirectoryName(),
                    container: sourceContainer,
                    provider: blobProvider);
                DestinationResource ??= localProvider.FromDirectory(destinationDirectoryPath);
            }
            else if (transferType == TransferDirection.Copy)
            {
                Argument.AssertNotNull(sourceContainer, nameof(sourceContainer));
                Argument.AssertNotNull(destinationContainer, nameof(destinationContainer));
                BlobStorageResourceContainerOptions options = new BlobStorageResourceContainerOptions()
                {
                    BlobDirectoryPrefix = GetNewBlobDirectoryName(),
                };
                SourceResource ??= await CreateBlobDirectorySourceResourceAsync(
                    size: size,
                    blobCount: transferCount,
                    directoryPath: GetNewBlobDirectoryName(),
                    container: sourceContainer,
                    provider: blobProvider);
                DestinationResource ??= blobProvider.FromClient(destinationContainer, options);
            }
            else
            {
                // Default to Upload
                Argument.AssertNotNullOrEmpty(sourceDirectoryPath, nameof(sourceDirectoryPath));
                Argument.AssertNotNull(destinationContainer, nameof(destinationContainer));
                SourceResource ??= await CreateLocalDirectorySourceResourceAsync(
                    size: size,
                    fileCount: transferCount,
                    directoryPath: sourceDirectoryPath,
                    provider: localProvider);

                BlobStorageResourceContainerOptions options = new()
                {
                    BlobDirectoryPrefix = GetNewBlobDirectoryName()
                };
                DestinationResource ??= blobProvider.FromClient(destinationContainer, options);
            }
            return (SourceResource, DestinationResource);
        }

        /// <summary>
        /// Upload and verify the contents of the blob
        ///
        /// By default in this function an event argument will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        private async Task<DataTransfer> CreateDirectoryLongTransferAsync(
            TransferManager manager,
            TransferDirection transferType = TransferDirection.Upload,
            string sourceDirectory = default,
            string destinationDirectory = default,
            BlobContainerClient sourceContainer = default,
            BlobContainerClient destinationContainer = default,
            StorageResource sourceResource = default,
            StorageResource destinationResource = default,
            DataTransferOptions transferOptions = default,
            int transferCount = 100,
            long size = Constants.MB,
            BlobsStorageResourceProvider blobProvider = default,
            LocalFilesStorageResourceProvider localProvider = default)
        {
            Argument.AssertNotNull(manager, nameof(manager));
            if (sourceResource == default && destinationResource == default)
            {
                (StorageResource source, StorageResource dest) = await CreateStorageResourceContainersAsync(
                    transferType: transferType,
                    size: size,
                    transferCount: transferCount,
                    sourceDirectoryPath: sourceDirectory,
                    destinationDirectoryPath: destinationDirectory,
                    sourceContainer: sourceContainer,
                    destinationContainer: destinationContainer,
                    blobProvider: blobProvider,
                    localProvider: localProvider);
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
            return await manager.StartTransferAsync(sourceResource, destinationResource, transferOptions);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        [RecordedTest]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task TryPauseTransferAsync_Id_Directory(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory sourceDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory destinationDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer sourceContainer = await GetTestContainerAsync();
            await using DisposingContainer destinationContainer = await GetTestContainerAsync();

            BlobsStorageResourceProvider blobProvider = new(GetSharedKeyCredential());
            LocalFilesStorageResourceProvider localProvider = new();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointStoreOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                ResumeProviders = new() { blobProvider, localProvider },
            };
            TransferManager transferManager = new TransferManager(options);
            DataTransferOptions transferOptions = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);

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
                size: Constants.KB * 4,
                transferCount: partCount,
                transferOptions: transferOptions,
                blobProvider: blobProvider,
                localProvider: localProvider);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transferManager.PauseTransferIfRunningAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(DataTransferState.Paused, transfer.TransferStatus.State);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        [RecordedTest]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task TryPauseTransferAsync_DataTransfer_Directory(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory sourceDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory destinationDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer sourceContainer = await GetTestContainerAsync();
            await using DisposingContainer destinationContainer = await GetTestContainerAsync();

            BlobsStorageResourceProvider blobProvider = new(GetSharedKeyCredential());
            LocalFilesStorageResourceProvider localProvider = new();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointStoreOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                ResumeProviders = new() { blobProvider, localProvider },
            };
            TransferManager transferManager = new TransferManager(options);
            DataTransferOptions transferOptions = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);

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
                size: Constants.KB * 4,
                transferCount: partCount,
                transferOptions: transferOptions,
                blobProvider: blobProvider,
                localProvider: localProvider);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transferManager.PauseTransferIfRunningAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(DataTransferState.Paused, transfer.TransferStatus.State);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        [RecordedTest]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task TryPauseTransferAsync_AlreadyPaused_Directory(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory sourceDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory destinationDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer sourceContainer = await GetTestContainerAsync();
            await using DisposingContainer destinationContainer = await GetTestContainerAsync();

            BlobsStorageResourceProvider blobProvider = new(GetSharedKeyCredential());
            LocalFilesStorageResourceProvider localProvider = new();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointStoreOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                ResumeProviders = new() { blobProvider, localProvider },
            };
            TransferManager transferManager = new TransferManager(options);
            DataTransferOptions transferOptions = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);

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
                size: Constants.KB * 4,
                transferCount: partCount,
                transferOptions: transferOptions,
                blobProvider: blobProvider,
                localProvider: localProvider);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transferManager.PauseTransferIfRunningAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(DataTransferState.Paused, transfer.TransferStatus.State);

            CancellationTokenSource cancellationTokenSource2 = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transferManager.PauseTransferIfRunningAsync(transfer.Id, cancellationTokenSource2.Token);

            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(DataTransferState.Paused, transfer.TransferStatus.State);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        [RecordedTest]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task PauseThenResumeTransferAsync_Directory(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory sourceDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory destinationDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer sourceContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            await using DisposingContainer destinationContainer = await GetTestContainerAsync();

            BlobsStorageResourceProvider blobProvider = new(GetSharedKeyCredential());
            LocalFilesStorageResourceProvider localProvider = new();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointStoreOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                ResumeProviders = new() { blobProvider, localProvider },
            };
            TransferManager transferManager = new TransferManager(options);
            DataTransferOptions transferOptions = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);
            long size = Constants.KB * 4;
            int partCount = 4;

            (StorageResource sResource, StorageResource dResource) = await CreateStorageResourceContainersAsync(
                transferType: transferType,
                size: size,
                transferCount: partCount,
                sourceDirectoryPath: sourceDirectory.DirectoryPath,
                destinationDirectoryPath: destinationDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                blobProvider: blobProvider,
                localProvider: localProvider);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            DataTransfer transfer = await CreateDirectoryLongTransferAsync(
                manager: transferManager,
                sourceResource: sResource,
                destinationResource: dResource,
                transferOptions: transferOptions);

            // Act - Pause Job
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(100));
            await transferManager.PauseTransferIfRunningAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert - Confirm we've paused
            Assert.AreEqual(DataTransferState.Paused, transfer.TransferStatus.State);
            await testEventsRaised.AssertPausedCheck();
            int completedBeforePause = testEventsRaised.SingleCompletedEvents.Count;

            // Act - Resume Job
            DataTransferOptions resumeOptions = new()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists
            };
            TestEventsRaised testEventRaised2 = new TestEventsRaised(resumeOptions);
            DataTransfer resumeTransfer = await transferManager.ResumeTransferAsync(
                transferId: transfer.Id,
                transferOptions: resumeOptions);

            CancellationTokenSource waitTransferCompletion = new CancellationTokenSource(TimeSpan.FromSeconds(600));
            await resumeTransfer.WaitForCompletionAsync(waitTransferCompletion.Token);

            // Assert
            await testEventRaised2.AssertContainerCompletedCheck(partCount - completedBeforePause);
            Assert.AreEqual(DataTransferState.Completed, resumeTransfer.TransferStatus.State);
            Assert.IsTrue(resumeTransfer.HasCompleted);

            // Verify transfer
            await AssertDirectorySourceAndDestinationAsync(
                transferType: transferType,
                sourceResource: sResource as StorageResourceContainer,
                destinationResource: dResource as StorageResourceContainer,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35439")]
        [RecordedTest]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task ResumeTransferAsync_Directory(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory sourceDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory destinationDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer sourceContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            await using DisposingContainer destinationContainer = await GetTestContainerAsync();

            BlobsStorageResourceProvider blobProvider = new(GetSharedKeyCredential());
            LocalFilesStorageResourceProvider localProvider = new();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointStoreOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                ResumeProviders = new() { blobProvider, localProvider },
            };
            TransferManager transferManager = new TransferManager(options);
            DataTransferOptions transferOptions = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);
            long size = Constants.KB * 4;
            int partCount = 4;

            (StorageResource sResource, StorageResource dResource) = await CreateStorageResourceContainersAsync(
                transferType: transferType,
                size: size,
                transferCount: partCount,
                sourceDirectoryPath: sourceDirectory.DirectoryPath,
                destinationDirectoryPath: destinationDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                blobProvider: blobProvider,
                localProvider: localProvider);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            DataTransfer transfer = await CreateDirectoryLongTransferAsync(
                manager: transferManager,
                sourceResource: sResource,
                destinationResource: dResource,
                transferOptions: transferOptions);

            // Act - Pause Job
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(100));
            await transferManager.PauseTransferIfRunningAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert - Confirm we've paused
            Assert.AreEqual(DataTransferState.Paused, transfer.TransferStatus.State);
            await testEventsRaised.AssertPausedCheck();
            int completedBeforePause = testEventsRaised.SingleCompletedEvents.Count;

            // Act - Resume Job
            DataTransferOptions resumeOptions = new()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists
            };
            TestEventsRaised testEventsRaised2 = new TestEventsRaised(resumeOptions);
            DataTransfer resumeTransfer = await transferManager.ResumeTransferAsync(
                transfer.Id,
                transferOptions: resumeOptions);

            CancellationTokenSource waitTransferCompletion = new CancellationTokenSource(TimeSpan.FromSeconds(600));
            await resumeTransfer.WaitForCompletionAsync(waitTransferCompletion.Token);

            // Assert
            await testEventsRaised2.AssertContainerCompletedCheck(partCount - completedBeforePause);
            Assert.AreEqual(DataTransferState.Completed, resumeTransfer.TransferStatus.State);
            Assert.IsTrue(resumeTransfer.HasCompleted);

            // Verify transfer
            await AssertDirectorySourceAndDestinationAsync(
                transferType: transferType,
                sourceResource: sResource as StorageResourceContainer,
                destinationResource: dResource as StorageResourceContainer,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container);
        }

        [Ignore("Likely to fail in pipelines and takes a while to run.")]
        [Test, Pairwise]
        [LiveOnly]
        public async Task ResumeTransferAsync_Directory_Large(
            [Values(TransferDirection.Upload, TransferDirection.Download, TransferDirection.Copy)] TransferDirection transferType,
            [Values(100)] int blobCount,
            [Values(0, 500, 2000)] int delayInMs)
        {
            // This test is not really meant to run in a pipeline and may fail locally
            // depending on timing. Its more meant as a starting place to attempt testing
            // pause/resume in different states of the transfer. You may also find adding
            // delays in certain parts of the code while testing can help get more
            // consistent results.

            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory sourceDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory destinationDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer sourceContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            await using DisposingContainer destinationContainer = await GetTestContainerAsync();

            BlobsStorageResourceProvider blobProvider = new(GetSharedKeyCredential());
            LocalFilesStorageResourceProvider localProvider = new();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointerOptions = new TransferCheckpointStoreOptions(checkpointerDirectory.DirectoryPath),
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                ResumeProviders = new() { blobProvider, localProvider },
            };
            TransferManager transferManager = new TransferManager(options);
            long size = Constants.MB;

            (StorageResource sResource, StorageResource dResource) = await CreateStorageResourceContainersAsync(
                transferType: transferType,
                size: size,
                transferCount: blobCount,
                sourceDirectoryPath: sourceDirectory.DirectoryPath,
                destinationDirectoryPath: destinationDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                blobProvider: blobProvider,
                localProvider: localProvider);

            // Start transfer
            DataTransfer transfer = await transferManager.StartTransferAsync(sResource, dResource);

            // Sleep before pausing
            await Task.Delay(delayInMs);

            // Pause Transfer
            CancellationTokenSource pauseCancellation = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transferManager.PauseTransferIfRunningAsync(transfer.Id, pauseCancellation.Token);
            Assert.AreEqual(DataTransferState.Paused, transfer.TransferStatus.State);

            // Resume Transfer
            DataTransfer resumeTransfer = await transferManager.ResumeTransferAsync(transfer.Id);

            CancellationTokenSource waitTransferCompletion = new CancellationTokenSource(TimeSpan.FromSeconds(600));
            await resumeTransfer.WaitForCompletionAsync(waitTransferCompletion.Token);

            // Assert
            Assert.AreEqual(DataTransferState.Completed, resumeTransfer.TransferStatus.State);
            Assert.IsTrue(resumeTransfer.HasCompleted);

            // Verify transfer
            await AssertDirectorySourceAndDestinationAsync(
                transferType: transferType,
                sourceResource: sResource as StorageResourceContainer,
                destinationResource: dResource as StorageResourceContainer,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container);
        }

        [Test]
        public async Task PauseAllTriggersCorrectPauses()
        {
            List<Mock<DataTransfer>> pausable = new();
            List<Mock<DataTransfer>> unpausable = new();
            TransferManager manager = new();
            foreach (DataTransferState state in Enum.GetValues(typeof(DataTransferState)).Cast<DataTransferState>())
            {
                bool canPause = state == DataTransferState.InProgress;
                Mock<DataTransfer> transfer = new(MockBehavior.Loose)
                {
                    CallBase = true,
                };
                transfer.Setup(t => t.CanPause()).Returns(canPause);
                transfer.Setup(t => t.PauseAsync(_mockingToken)).Returns(Task.CompletedTask);
                if (canPause)
                {
                    pausable.Add(transfer);
                }
                else
                {
                    unpausable.Add(transfer);
                }
                manager._dataTransfers.Add(Guid.NewGuid().ToString(), transfer.Object);
            }

            await manager.PauseAllRunningTransfersAsync(_mockingToken);

            foreach (Mock<DataTransfer> transfer in pausable)
            {
                transfer.Verify(t => t.PauseAsync(_mockingToken), Times.Once());
            }
            foreach (Mock<DataTransfer> transfer in pausable.Concat(unpausable))
            {
                transfer.Verify(t => t.CanPause(), Times.Once());
                transfer.VerifyNoOtherCalls();
            }
        }
    }
}
