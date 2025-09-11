// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.Storage.Test.Shared;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;
using System.Threading;
using Azure.Storage.DataMovement.JobPlan;
using Azure.Storage.Test;
using Moq;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement.Tests
{
    public abstract class PauseResumeTransferTestBase
        <TServiceClient,
        TContainerClient,
        TObjectClient,
        TClientOptions,
        TEnvironment> : StorageTestBase<TEnvironment>
        where TServiceClient : class
        where TContainerClient : class
        where TObjectClient : class
        where TClientOptions : ClientOptions
        where TEnvironment : StorageTestEnvironment, new()
    {
        public ClientBuilder<TServiceClient, TClientOptions> ClientBuilder { get; protected set; }

        public PauseResumeTransferTestBase(
            bool async,
            RecordedTestMode? mode = null) : base(async, mode)
        {
        }

        protected string GetNewContainerName()
            => $"test-container-{ClientBuilder.Recording.Random.NewGuid()}";
        protected string GetNewItemName()
            => $"test-item-{ClientBuilder.Recording.Random.NewGuid()}";

        #region Abstract Methods
        protected abstract Task<IDisposingContainer<TContainerClient>> GetDisposingContainerAsync(
            string containerName = default,
            TServiceClient service = default);

        protected abstract StorageResourceProvider GetStorageResourceProvider();

        protected abstract Task<StorageResource> CreateSourceStorageResourceItemAsync(
            long size,
            string name,
            TContainerClient container);

        protected abstract StorageResource CreateDestinationStorageResourceItem(
            string name,
            TContainerClient container,
            Metadata metadata = default,
            string contentLanguage = default);

        protected abstract Task AssertDestinationProperties(
            string name,
            Metadata metadata,
            string contentLanguage,
            TContainerClient container);

        protected abstract Task<Stream> GetStreamFromContainerAsync(
            Uri uri,
            TContainerClient container);

        protected abstract Task<StorageResource> CreateSourceStorageResourceContainerAsync(
            long size,
            int count,
            string directoryPath,
            TContainerClient container);

        protected abstract StorageResource CreateDestinationStorageResourceContainer(
            TContainerClient container);
        #endregion

        #region Helper Methods
        private async Task<StorageResource> CreateLocalFileSourceResourceAsync(
            long size,
            string directory)
        {
            string localSourceFile = await CreateRandomFileAsync(directory);
            // create a new file and copy contents of stream into it, and then close the FileStream
            using Stream originalStream = await CreateLimitedMemoryStream(size);
            using (FileStream fileStream = File.Create(localSourceFile))
            {
                await originalStream.CopyToAsync(fileStream);
            }
            return LocalFilesStorageResourceProvider.FromFile(localSourceFile);
        }

        private async Task<(StorageResource SourceResource, StorageResource DestinationResource)> CreateStorageResourcesAsync(
            TransferDirection transferType,
            long size,
            string localDirectory,
            TContainerClient sourceContainer,
            TContainerClient destinationContainer,
            string storagePath = default)
        {
            storagePath ??= GetNewItemName();

            StorageResource SourceResource = default;
            StorageResource DestinationResource = default;
            if (transferType == TransferDirection.Download)
            {
                Argument.AssertNotNull(sourceContainer, nameof(sourceContainer));
                Argument.AssertNotNullOrEmpty(localDirectory, nameof(localDirectory));
                SourceResource ??= await CreateSourceStorageResourceItemAsync(size, storagePath, sourceContainer);
                DestinationResource ??= LocalFilesStorageResourceProvider.FromFile(Path.Combine(localDirectory, storagePath));
            }
            else if (transferType == TransferDirection.Copy)
            {
                Argument.AssertNotNull(sourceContainer, nameof(sourceContainer));
                Argument.AssertNotNull(destinationContainer, nameof(destinationContainer));
                SourceResource ??= await CreateSourceStorageResourceItemAsync(size, storagePath, sourceContainer);
                DestinationResource ??= CreateDestinationStorageResourceItem(storagePath, destinationContainer);
            }
            else
            {
                // Default to Upload
                Argument.AssertNotNullOrEmpty(localDirectory, nameof(localDirectory));
                Argument.AssertNotNull(destinationContainer, nameof(destinationContainer));
                SourceResource ??= await CreateLocalFileSourceResourceAsync(size, localDirectory);
                DestinationResource ??= CreateDestinationStorageResourceItem(storagePath, destinationContainer);
            }
            return (SourceResource, DestinationResource);
        }

        /// <summary>
        /// Upload and verify the contents of the blob
        ///
        /// By default in this function an event argument will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        private async Task<TransferOperation> CreateSingleLongTransferAsync(
            TransferManager manager,
            TransferDirection transferType = TransferDirection.Upload,
            string localDirectory = default,
            TContainerClient sourceContainer = default,
            TContainerClient destinationContainer = default,
            StorageResource sourceResource = default,
            StorageResource destinationResource = default,
            TransferOptions transferOptions = default,
            long size = DataMovementTestConstants.KB * 100)
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
            return await manager.StartTransferAsync(sourceResource, destinationResource, transferOptions);
        }

        private bool StreamsAreEqual(Stream stream1, Stream stream2)
        {
            if (stream1 == stream2)
            {
                return true;
            }
            if (stream1 == null || stream2 == null)
            {
                return false;
            }
            if (!stream1.CanRead || !stream2.CanRead)
            {
                return false;
            }
            if (stream1.Length != stream2.Length)
            {
                return false;
            }

            const int bufferSize = 8192; // Read in chunks
            byte[] buffer1 = new byte[bufferSize];
            byte[] buffer2 = new byte[bufferSize];

            stream1.Position = 0;
            stream2.Position = 0;

            using (BufferedStream bs1 = new BufferedStream(stream1, bufferSize))
            using (BufferedStream bs2 = new BufferedStream(stream2, bufferSize))
            {
                int bytesRead1, bytesRead2;
                while ((bytesRead1 = bs1.Read(buffer1, 0, buffer1.Length)) > 0)
                {
                    bytesRead2 = bs2.Read(buffer2, 0, buffer2.Length);
                    if (bytesRead1 != bytesRead2 || !buffer1.Take(bytesRead1).SequenceEqual(buffer2.Take(bytesRead2)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private async Task VerifyTransferContent(StorageResource sResource, StorageResource dResource,
            TContainerClient sourceContainer, TContainerClient destinationContainer, TransferDirection transferType)
        {
            // Verify transfer
            Stream sourceStream = default;
            Stream destinationStream = default;
            if (transferType == TransferDirection.Upload)
            {
                sourceStream = File.OpenRead(sResource.Uri.LocalPath);
                destinationStream = await GetStreamFromContainerAsync(dResource.Uri, destinationContainer);
            }
            else if (transferType == TransferDirection.Download)
            {
                sourceStream = await GetStreamFromContainerAsync(sResource.Uri, sourceContainer);
                destinationStream = File.OpenRead(dResource.Uri.LocalPath);
            }
            else // Copy
            {
                sourceStream = await GetStreamFromContainerAsync(sResource.Uri, sourceContainer);
                destinationStream = await GetStreamFromContainerAsync(dResource.Uri, destinationContainer);
            }
            Assert.IsTrue(StreamsAreEqual(sourceStream, destinationStream));
        }

        private async Task<StorageResource> CreateLocalDirectorySourceResourceAsync(
            long size,
            int fileCount,
            string directoryPath)
        {
            for (int i = 0; i < fileCount; i++)
            {
                await CreateRandomFileAsync(directoryPath, size: size);
            }
            return LocalFilesStorageResourceProvider.FromDirectory(directoryPath);
        }

        private async Task<(StorageResource SourceResource, StorageResource DestinationResource)> CreateStorageResourceContainersAsync(
            TransferDirection transferType,
            long size,
            int transferCount,
            string sourceDirectoryPath,
            string destinationDirectoryPath,
            TContainerClient sourceContainer,
            TContainerClient destinationContainer)
        {
            StorageResource SourceResource = default;
            StorageResource DestinationResource = default;
            if (transferType == TransferDirection.Download)
            {
                Argument.AssertNotNull(sourceContainer, nameof(sourceContainer));
                Argument.AssertNotNullOrEmpty(destinationDirectoryPath, nameof(destinationDirectoryPath));
                SourceResource ??= await CreateSourceStorageResourceContainerAsync(
                    size: size,
                    count: transferCount,
                    directoryPath: GetNewContainerName(),
                    container: sourceContainer);
                DestinationResource ??= LocalFilesStorageResourceProvider.FromDirectory(destinationDirectoryPath);
            }
            else if (transferType == TransferDirection.Copy)
            {
                Argument.AssertNotNull(sourceContainer, nameof(sourceContainer));
                Argument.AssertNotNull(destinationContainer, nameof(destinationContainer));
                SourceResource ??= await CreateSourceStorageResourceContainerAsync(
                    size: size,
                    count: transferCount,
                    directoryPath: GetNewContainerName(),
                    container: sourceContainer);
                DestinationResource ??= CreateDestinationStorageResourceContainer(destinationContainer);
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
                DestinationResource ??= CreateDestinationStorageResourceContainer(destinationContainer);
            }
            return (SourceResource, DestinationResource);
        }

        /// <summary>
        /// Upload and verify the contents of the blob
        ///
        /// By default in this function an event argument will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        private async Task<TransferOperation> CreateDirectoryLongTransferAsync(
            TransferManager manager,
            TransferDirection transferType = TransferDirection.Upload,
            string sourceDirectory = default,
            string destinationDirectory = default,
            TContainerClient sourceContainer = default,
            TContainerClient destinationContainer = default,
            StorageResource sourceResource = default,
            StorageResource destinationResource = default,
            TransferOptions transferOptions = default,
            int transferCount = 100,
            long size = DataMovementTestConstants.MB)
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
            return await manager.StartTransferAsync(sourceResource, destinationResource, transferOptions);
        }

        private async Task AssertDirectorySourceAndDestinationAsync(
            TransferDirection transferType,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource,
            TContainerClient sourceContainer,
            TContainerClient destinationContainer)
        {
            await foreach (StorageResourceItem childSourceResource in sourceResource.GetStorageResourcesAsync())
            {
                StorageResourceItem childDestinationResource;
                if (transferType == TransferDirection.Upload)
                {
                    string destinationChildName = childSourceResource.Uri.LocalPath.Substring(sourceResource.Uri.LocalPath.Length + 1);
                    childDestinationResource = destinationResource.GetStorageResourceReference(destinationChildName, default);
                }
                else
                {
                    string destinationChildName = childSourceResource.Uri.AbsoluteUri.Substring(sourceResource.Uri.AbsoluteUri.Length + 1);
                    childDestinationResource = destinationResource.GetStorageResourceReference(destinationChildName, default);
                }

                // Verify transfer
                await VerifyTransferContent(childSourceResource, childDestinationResource, sourceContainer, destinationContainer, transferType);
            }
        }

        private bool HasFileTransferReachedInProgressState(List<TransferProgress> progressUpdates)
        {
            return progressUpdates.Any(p => p.InProgressCount > 0);
        }
        #endregion

        private class TestProgressHandler : IProgress<TransferProgress>
        {
            public List<TransferProgress> Updates { get; private set; } = new List<TransferProgress>();

            public void Report(TransferProgress progress)
            {
                Updates.Add(progress);
            }
        }

        #region Tests
        [Test]
        [LiveOnly]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task TryPauseTransferAsync_Id(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> sourceContainer = await GetDisposingContainerAsync();
            await using IDisposingContainer<TContainerClient> destinationContainer = await GetDisposingContainerAsync();

            StorageResourceProvider provider = GetStorageResourceProvider();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(checkpointerDirectory.DirectoryPath),
                ErrorMode = TransferErrorMode.ContinueOnFailure,
                ProvidersForResuming = new List<StorageResourceProvider>() { provider },
            };
            TransferManager transferManager = new TransferManager(options);
            TestProgressHandler progressHandler = new();
            TransferOptions transferOptions = new TransferOptions
            {
                ProgressHandlerOptions = new TransferProgressHandlerOptions
                {
                    ProgressHandler = progressHandler,
                    TrackBytesTransferred = true
                }
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            TransferOperation transfer = await CreateSingleLongTransferAsync(
                manager: transferManager,
                transferType: transferType,
                localDirectory: localDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                size: DataMovementTestConstants.KB * 100,
                transferOptions: transferOptions);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            await transferManager.PauseTransferAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(TransferState.Paused, transfer.Status.State);

            List<TransferProgress> progressUpdates = progressHandler.Updates;
            // We need to check if the transfer has any files that has reached 'InProgress' state when the Job Part Plan File is created.
            if (HasFileTransferReachedInProgressState(progressUpdates))
            {
                // Check if Job Plan File exists in checkpointer path.
                JobPartPlanFileName fileName = new JobPartPlanFileName(
                    checkpointerPath: checkpointerDirectory.DirectoryPath,
                    id: transfer.Id,
                    jobPartNumber: 0);
                Assert.IsTrue(File.Exists(fileName.FullPath));
            }
        }

        [Test]
        [LiveOnly]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task TryPauseTransferAsync_TransferOperation(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> sourceContainer = await GetDisposingContainerAsync();
            await using IDisposingContainer<TContainerClient> destinationContainer = await GetDisposingContainerAsync();

            StorageResourceProvider provider = GetStorageResourceProvider();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(checkpointerDirectory.DirectoryPath),
                ErrorMode = TransferErrorMode.ContinueOnFailure,
                ProvidersForResuming = new List<StorageResourceProvider>() { provider },
            };

            TestProgressHandler progressHandler = new();
            TransferOptions transferOptions = new TransferOptions
            {
                ProgressHandlerOptions = new TransferProgressHandlerOptions
                {
                    ProgressHandler = progressHandler,
                    TrackBytesTransferred = true
                }
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);
            TransferManager transferManager = new TransferManager(options);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            TransferOperation transfer = await CreateSingleLongTransferAsync(
                manager: transferManager,
                transferType: transferType,
                localDirectory: localDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                size: DataMovementTestConstants.KB * 100,
                transferOptions: transferOptions);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            await transferManager.PauseTransferAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(TransferState.Paused, transfer.Status.State);

            List<TransferProgress> progressUpdates = progressHandler.Updates;
            // We need to check if the transfer has any files that has reached 'InProgress' state when the Job Part Plan File is created.
            if (HasFileTransferReachedInProgressState(progressUpdates))
            {
                // Check if Job Plan File exists in checkpointer path.
                JobPartPlanFileName fileName = new JobPartPlanFileName(
                    checkpointerPath: checkpointerDirectory.DirectoryPath,
                    id: transfer.Id,
                    jobPartNumber: 0);
                Assert.IsTrue(File.Exists(fileName.FullPath));
            }
        }

        [RecordedTest]
        public void TryPauseTransferAsync_Error()
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(checkpointerDirectory.DirectoryPath),
                ErrorMode = TransferErrorMode.ContinueOnFailure
            };
            TransferManager transferManager = new TransferManager(options);

            // Act / Assert
            Assert.CatchAsync(async () => await transferManager.PauseTransferAsync("bad transfer Id"));
        }

        [Test]
        [LiveOnly]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task TryPauseTransferAsync_AlreadyPaused(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> sourceContainer = await GetDisposingContainerAsync();
            await using IDisposingContainer<TContainerClient> destinationContainer = await GetDisposingContainerAsync();

            StorageResourceProvider provider = GetStorageResourceProvider();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(checkpointerDirectory.DirectoryPath),
                ErrorMode = TransferErrorMode.ContinueOnFailure,
                ProvidersForResuming = new List<StorageResourceProvider>() { provider },
            };

            TestProgressHandler progressHandler = new();
            TransferOptions transferOptions = new TransferOptions
            {
                ProgressHandlerOptions = new TransferProgressHandlerOptions
                {
                    ProgressHandler = progressHandler,
                    TrackBytesTransferred = true
                }
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);
            TransferManager transferManager = new TransferManager(options);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            TransferOperation transfer = await CreateSingleLongTransferAsync(
                manager: transferManager,
                transferType: transferType,
                localDirectory: localDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                size: DataMovementTestConstants.KB * 100,
                transferOptions: transferOptions);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            await transferManager.PauseTransferAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(TransferState.Paused, transfer.Status.State);

            CancellationTokenSource cancellationTokenSource2 = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transferManager.PauseTransferAsync(transfer.Id, cancellationTokenSource2.Token);

            Assert.AreEqual(TransferState.Paused, transfer.Status.State);

            List<TransferProgress> progressUpdates = progressHandler.Updates;
            // We need to check if the transfer has any files that has reached 'InProgress' state when the Job Part Plan File is created.
            if (HasFileTransferReachedInProgressState(progressUpdates))
            {
                // Check if Job Plan File exists in checkpointer path.
                JobPartPlanFileName fileName = new JobPartPlanFileName(
                    checkpointerPath: checkpointerDirectory.DirectoryPath,
                    id: transfer.Id,
                    jobPartNumber: 0);
                Assert.IsTrue(File.Exists(fileName.FullPath));
            }
        }

        [Test]
        [LiveOnly]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task PauseThenResumeTransferAsync(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> sourceContainer = await GetDisposingContainerAsync();
            await using IDisposingContainer<TContainerClient> destinationContainer = await GetDisposingContainerAsync();

            StorageResourceProvider provider = GetStorageResourceProvider();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(checkpointerDirectory.DirectoryPath),
                ErrorMode = TransferErrorMode.ContinueOnFailure,
                ProvidersForResuming = new List<StorageResourceProvider>() { provider },
            };
            TransferOptions transferOptions = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);
            TransferManager transferManager = new TransferManager(options);
            long size = DataMovementTestConstants.KB * 100;

            (StorageResource sResource, StorageResource dResource) = await CreateStorageResourcesAsync(
                transferType: transferType,
                size: size,
                localDirectory: localDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            TransferOperation transfer = await CreateSingleLongTransferAsync(
                manager: transferManager,
                sourceResource: sResource,
                destinationResource: dResource,
                transferOptions: transferOptions);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            await transferManager.PauseTransferAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(TransferState.Paused, transfer.Status.State);

            // Act - Resume Job
            TransferOptions resumeOptions = new TransferOptions()
            {
                // Enable overwrite on resume, to overwrite destination.
                CreationMode = StorageResourceCreationMode.OverwriteIfExists
            };
            TestEventsRaised testEventRaised2 = new TestEventsRaised(resumeOptions);
            TransferOperation resumeTransfer = await transferManager.ResumeTransferAsync(
                transferId: transfer.Id,
                transferOptions: resumeOptions);

            CancellationTokenSource waitTransferCompletion = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            await resumeTransfer.WaitForCompletionAsync(waitTransferCompletion.Token);

            // Assert
            await testEventRaised2.AssertSingleCompletedCheck();
            Assert.AreEqual(TransferState.Completed, resumeTransfer.Status.State);
            Assert.IsTrue(resumeTransfer.HasCompleted);

            // Verify transfer
            Stream sourceStream = default;
            Stream destinationStream = default;
            if (transferType == TransferDirection.Upload)
            {
                sourceStream = File.OpenRead(sResource.Uri.LocalPath);
                destinationStream = await GetStreamFromContainerAsync(dResource.Uri, destinationContainer.Container);
            }
            else if (transferType == TransferDirection.Download)
            {
                sourceStream = await GetStreamFromContainerAsync(sResource.Uri, sourceContainer.Container);
                destinationStream = File.OpenRead(dResource.Uri.LocalPath);
            }
            else // Copy
            {
                sourceStream = await GetStreamFromContainerAsync(sResource.Uri, sourceContainer.Container);
                destinationStream = await GetStreamFromContainerAsync(dResource.Uri, destinationContainer.Container);
            }
            Assert.IsTrue(StreamsAreEqual(sourceStream, destinationStream));
        }

        [Test]
        [LiveOnly]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task ResumeTransferAsync(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> sourceContainer = await GetDisposingContainerAsync();
            await using IDisposingContainer<TContainerClient> destinationContainer = await GetDisposingContainerAsync();

            StorageResourceProvider provider = GetStorageResourceProvider();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(checkpointerDirectory.DirectoryPath),
                ErrorMode = TransferErrorMode.ContinueOnFailure,
                ProvidersForResuming = new List<StorageResourceProvider>() { provider },
            };
            TransferOptions transferOptions = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);
            TransferManager transferManager = new TransferManager(options);
            long size = DataMovementTestConstants.KB * 100;

            (StorageResource sResource, StorageResource dResource) = await CreateStorageResourcesAsync(
                transferType: transferType,
                size: size,
                localDirectory: localDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            TransferOperation transfer = await CreateSingleLongTransferAsync(
                manager: transferManager,
                sourceResource: sResource,
                destinationResource: dResource,
                transferOptions: transferOptions);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            await transferManager.PauseTransferAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(TransferState.Paused, transfer.Status.State);

            // Act - Resume Job
            TransferOptions resumeOptions = new();
            TestEventsRaised testEventRaised2 = new TestEventsRaised(resumeOptions);
            TransferOperation resumeTransfer = await transferManager.ResumeTransferAsync(
                transfer.Id,
                resumeOptions);

            CancellationTokenSource waitTransferCompletion = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            await resumeTransfer.WaitForCompletionAsync(waitTransferCompletion.Token);

            // Assert
            await testEventRaised2.AssertSingleCompletedCheck();
            Assert.AreEqual(TransferState.Completed, resumeTransfer.Status.State);
            Assert.IsTrue(resumeTransfer.HasCompleted);

            //Verify transfer
            await VerifyTransferContent(sResource, dResource, sourceContainer.Container, destinationContainer.Container, transferType);
        }

        [Test]
        [LiveOnly]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Copy)]
        public async Task ResumeTransferAsync_Options(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> container = await GetDisposingContainerAsync();

            StorageResourceProvider provider = GetStorageResourceProvider();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(checkpointerDirectory.DirectoryPath),
                ErrorMode = TransferErrorMode.ContinueOnFailure,
                ProvidersForResuming = new List<StorageResourceProvider>() { provider },
            };
            TransferManager transferManager = new TransferManager(options);

            Metadata metadata = DataProvider.BuildMetadata();
            string contentLanguage = "en-US";

            string destName = GetNewItemName();
            long size = DataMovementTestConstants.KB;
            StorageResource source;
            StorageResource destination;
            if (transferType == TransferDirection.Upload)
            {
                source = await CreateLocalFileSourceResourceAsync(size, localDirectory.DirectoryPath);
                destination = CreateDestinationStorageResourceItem(destName, container.Container, metadata, contentLanguage);
            }
            else // Copy
            {
                source = await CreateSourceStorageResourceItemAsync(size, GetNewItemName(), container.Container);
                destination = CreateDestinationStorageResourceItem(destName, container.Container, metadata, contentLanguage);
            }

            TransferOperation transfer = await transferManager.StartTransferAsync(source, destination);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            await transferManager.PauseTransferAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            Assert.AreEqual(TransferState.Paused, transfer.Status.State);
            await Task.Delay(150);

            // Act - Resume Job
            TransferOperation resumeTransfer = await transferManager.ResumeTransferAsync(transfer.Id);
            CancellationTokenSource waitTransferCompletion = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            await resumeTransfer.WaitForCompletionAsync(waitTransferCompletion.Token);

            // Assert
            Assert.AreEqual(TransferState.Completed, resumeTransfer.Status.State);
            Assert.IsTrue(resumeTransfer.HasCompleted);

            await AssertDestinationProperties(destName, metadata, contentLanguage, container.Container);
        }

        [Test]
        [LiveOnly]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task TryPauseTransferAsync_Id_Directory(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory sourceDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory destinationDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> sourceContainer = await GetDisposingContainerAsync();
            await using IDisposingContainer<TContainerClient> destinationContainer = await GetDisposingContainerAsync();

            StorageResourceProvider provider = GetStorageResourceProvider();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(checkpointerDirectory.DirectoryPath),
                ErrorMode = TransferErrorMode.ContinueOnFailure,
                ProvidersForResuming = new List<StorageResourceProvider>() { provider },
            };
            TransferManager transferManager = new TransferManager(options);
            TransferOptions transferOptions = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            int partCount = 4;
            TransferOperation transfer = await CreateDirectoryLongTransferAsync(
                manager: transferManager,
                transferType: transferType,
                sourceDirectory: sourceDirectory.DirectoryPath,
                destinationDirectory: destinationDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                size: DataMovementTestConstants.KB * 4,
                transferCount: partCount,
                transferOptions: transferOptions);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            await transferManager.PauseTransferAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(TransferState.Paused, transfer.Status.State);
        }

        [Test]
        [LiveOnly]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task TryPauseTransferAsync_TransferOperation_Directory(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory sourceDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory destinationDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> sourceContainer = await GetDisposingContainerAsync();
            await using IDisposingContainer<TContainerClient> destinationContainer = await GetDisposingContainerAsync();

            StorageResourceProvider provider = GetStorageResourceProvider();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(checkpointerDirectory.DirectoryPath),
                ErrorMode = TransferErrorMode.ContinueOnFailure,
                ProvidersForResuming = new List<StorageResourceProvider>() { provider },
            };
            TransferManager transferManager = new TransferManager(options);
            TransferOptions transferOptions = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            int partCount = 10;
            TransferOperation transfer = await CreateDirectoryLongTransferAsync(
                manager: transferManager,
                transferType: transferType,
                sourceDirectory: sourceDirectory.DirectoryPath,
                destinationDirectory: destinationDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                size: DataMovementTestConstants.KB * 4,
                transferCount: partCount,
                transferOptions: transferOptions);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            await transferManager.PauseTransferAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(TransferState.Paused, transfer.Status.State);
        }

        [Test]
        [LiveOnly]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task TryPauseTransferAsync_AlreadyPaused_Directory(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory sourceDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory destinationDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> sourceContainer = await GetDisposingContainerAsync();
            await using IDisposingContainer<TContainerClient> destinationContainer = await GetDisposingContainerAsync();

            StorageResourceProvider provider = GetStorageResourceProvider();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(checkpointerDirectory.DirectoryPath),
                ErrorMode = TransferErrorMode.ContinueOnFailure,
                ProvidersForResuming = new List<StorageResourceProvider>() { provider },
            };
            TransferManager transferManager = new TransferManager(options);
            TransferOptions transferOptions = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            int partCount = 4;
            TransferOperation transfer = await CreateDirectoryLongTransferAsync(
                manager: transferManager,
                transferType: transferType,
                sourceDirectory: sourceDirectory.DirectoryPath,
                destinationDirectory: destinationDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container,
                size: DataMovementTestConstants.KB * 4,
                transferCount: partCount,
                transferOptions: transferOptions);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            await transferManager.PauseTransferAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(TransferState.Paused, transfer.Status.State);

            CancellationTokenSource cancellationTokenSource2 = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transferManager.PauseTransferAsync(transfer.Id, cancellationTokenSource2.Token);

            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(TransferState.Paused, transfer.Status.State);
        }

        [Test]
        [LiveOnly]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task PauseThenResumeTransferAsync_Directory(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory sourceDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory destinationDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> sourceContainer = await GetDisposingContainerAsync();
            await using IDisposingContainer<TContainerClient> destinationContainer = await GetDisposingContainerAsync();

            StorageResourceProvider provider = GetStorageResourceProvider();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(checkpointerDirectory.DirectoryPath),
                ErrorMode = TransferErrorMode.ContinueOnFailure,
                ProvidersForResuming = new List<StorageResourceProvider>() { provider },
            };
            TransferManager transferManager = new TransferManager(options);
            TransferOptions transferOptions = new TransferOptions()
            {
                InitialTransferSize = DataMovementTestConstants.KB,
                MaximumTransferChunkSize = DataMovementTestConstants.KB
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);
            long size = DataMovementTestConstants.KB * 4;
            int partCount = 4;

            (StorageResource sResource, StorageResource dResource) = await CreateStorageResourceContainersAsync(
                transferType: transferType,
                size: size,
                transferCount: partCount,
                sourceDirectoryPath: sourceDirectory.DirectoryPath,
                destinationDirectoryPath: destinationDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            TransferOperation transfer = await CreateDirectoryLongTransferAsync(
                manager: transferManager,
                sourceResource: sResource,
                destinationResource: dResource,
                transferOptions: transferOptions);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(100));
            await transferManager.PauseTransferAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(TransferState.Paused, transfer.Status.State);
            int completedBeforePause = testEventsRaised.SingleCompletedEvents.Count;

            // Act - Resume Job
            TransferOptions resumeOptions = new()
            {
                CreationMode = StorageResourceCreationMode.OverwriteIfExists
            };
            TestEventsRaised testEventRaised2 = new TestEventsRaised(resumeOptions);
            TransferOperation resumeTransfer = await transferManager.ResumeTransferAsync(
                transferId: transfer.Id,
                transferOptions: resumeOptions);

            CancellationTokenSource waitTransferCompletion = new CancellationTokenSource(TimeSpan.FromSeconds(600));
            await resumeTransfer.WaitForCompletionAsync(waitTransferCompletion.Token);

            // Assert
            await testEventRaised2.AssertContainerCompletedCheck(partCount - completedBeforePause);
            Assert.AreEqual(TransferState.Completed, resumeTransfer.Status.State);
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
        [LiveOnly]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task ResumeTransferAsync_Directory(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory sourceDirectory = DisposingLocalDirectory.GetTestDirectory();
            using DisposingLocalDirectory destinationDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> sourceContainer = await GetDisposingContainerAsync();
            await using IDisposingContainer<TContainerClient> destinationContainer = await GetDisposingContainerAsync();

            StorageResourceProvider provider = GetStorageResourceProvider();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(checkpointerDirectory.DirectoryPath),
                ErrorMode = TransferErrorMode.ContinueOnFailure,
                ProvidersForResuming = new List<StorageResourceProvider>() { provider },
            };
            TransferManager transferManager = new TransferManager(options);
            TransferOptions transferOptions = new TransferOptions()
            {
                InitialTransferSize = DataMovementTestConstants.KB,
                MaximumTransferChunkSize = DataMovementTestConstants.KB
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);
            long size = DataMovementTestConstants.KB * 4;
            int partCount = 4;

            (StorageResource sResource, StorageResource dResource) = await CreateStorageResourceContainersAsync(
                transferType: transferType,
                size: size,
                transferCount: partCount,
                sourceDirectoryPath: sourceDirectory.DirectoryPath,
                destinationDirectoryPath: destinationDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container);

            // Add long-running job to pause, if the job is not big enough
            // then the job might finish before we can pause it.
            TransferOperation transfer = await CreateDirectoryLongTransferAsync(
                manager: transferManager,
                sourceResource: sResource,
                destinationResource: dResource,
                transferOptions: transferOptions);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(100));
            await transferManager.PauseTransferAsync(transfer.Id, cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(TransferState.Paused, transfer.Status.State);
            int completedBeforePause = testEventsRaised.SingleCompletedEvents.Count;

            // Act - Resume Job
            TransferOptions resumeOptions = new()
            {
                CreationMode = StorageResourceCreationMode.OverwriteIfExists
            };
            TestEventsRaised testEventsRaised2 = new TestEventsRaised(resumeOptions);
            TransferOperation resumeTransfer = await transferManager.ResumeTransferAsync(
                transfer.Id,
                transferOptions: resumeOptions);

            CancellationTokenSource waitTransferCompletion = new CancellationTokenSource(TimeSpan.FromSeconds(600));
            await resumeTransfer.WaitForCompletionAsync(waitTransferCompletion.Token);

            // Assert
            await testEventsRaised2.AssertContainerCompletedCheck(partCount - completedBeforePause);
            Assert.AreEqual(TransferState.Completed, resumeTransfer.Status.State);
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
            await using IDisposingContainer<TContainerClient> sourceContainer = await GetDisposingContainerAsync();
            await using IDisposingContainer<TContainerClient> destinationContainer = await GetDisposingContainerAsync();

            StorageResourceProvider provider = GetStorageResourceProvider();
            TransferManagerOptions options = new TransferManagerOptions()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(checkpointerDirectory.DirectoryPath),
                ErrorMode = TransferErrorMode.ContinueOnFailure,
                ProvidersForResuming = new List<StorageResourceProvider>() { provider },
            };
            TransferManager transferManager = new TransferManager(options);
            long size = DataMovementTestConstants.MB;

            (StorageResource sResource, StorageResource dResource) = await CreateStorageResourceContainersAsync(
                transferType: transferType,
                size: size,
                transferCount: blobCount,
                sourceDirectoryPath: sourceDirectory.DirectoryPath,
                destinationDirectoryPath: destinationDirectory.DirectoryPath,
                sourceContainer: sourceContainer.Container,
                destinationContainer: destinationContainer.Container);

            TransferOptions transferOptions = new()
            {
                InitialTransferSize = size / 4,
                MaximumTransferChunkSize = size / 4
            };

            // Start transfer
            TransferOperation transfer = await transferManager.StartTransferAsync(sResource, dResource, transferOptions);

            // Sleep before pausing
            await Task.Delay(delayInMs);

            // Pause Transfer
            CancellationTokenSource pauseCancellation = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transferManager.PauseTransferAsync(transfer.Id, pauseCancellation.Token);
            Assert.AreEqual(TransferState.Paused, transfer.Status.State);

            // Resume Transfer
            TransferOperation resumeTransfer = await transferManager.ResumeTransferAsync(transfer.Id);

            CancellationTokenSource waitTransferCompletion = new CancellationTokenSource(TimeSpan.FromSeconds(600));
            await resumeTransfer.WaitForCompletionAsync(waitTransferCompletion.Token);

            // Assert
            Assert.AreEqual(TransferState.Completed, resumeTransfer.Status.State);
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
            List<Mock<TransferOperation>> pausable = new();
            List<Mock<TransferOperation>> unpausable = new();
            TransferManager manager = new();
            foreach (TransferState state in Enum.GetValues(typeof(TransferState)).Cast<TransferState>())
            {
                bool canPause = state == TransferState.InProgress;
                Mock<TransferOperation> transfer = new(MockBehavior.Loose)
                {
                    CallBase = true,
                };
                transfer.Setup(t => t.CanPause()).Returns(canPause);
                transfer.Setup(t => t.PauseAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
                if (canPause)
                {
                    pausable.Add(transfer);
                }
                else
                {
                    unpausable.Add(transfer);
                }
                manager._transfers.TryAdd(Guid.NewGuid().ToString(), transfer.Object);
            }

            CancellationTokenSource token = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            await manager.PauseAllRunningTransfersAsync(token.Token);

            foreach (Mock<TransferOperation> transfer in pausable)
            {
                transfer.Verify(t => t.PauseAsync(It.IsAny<CancellationToken>()), Times.Once());
            }
            foreach (Mock<TransferOperation> transfer in pausable.Concat(unpausable))
            {
                transfer.Verify(t => t.CanPause(), Times.Once());
                transfer.VerifyNoOtherCalls();
            }
        }
        #endregion
    }
}
