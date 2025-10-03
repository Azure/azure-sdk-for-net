// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;
extern alias DMBlobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.DataMovement.Tests;
using BaseBlobs::Azure.Storage.Blobs;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class ProgressHandlerTests : DataMovementBlobTestBase
    {
        private string[] _testFiles = {
            "file1",
            "dir1/file1",
            "dir1/file2",
            "dir1/file3",
            "dir2/file1"
        };
        private long[] _expectedBytesTransferred = {
            0,
            1024,
            2048,
            3072,
            4096,
            5120
        };

        public ProgressHandlerTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, default)
        {
        }

        private async Task PopulateTestContainer(
            BlobContainerClient container,
            int blobSize = Constants.KB,
            int? blobCount = null)
        {
            // Use known file set
            if (blobCount == null)
            {
                foreach (string file in _testFiles)
                {
                    await container.UploadBlobAsync(file, BinaryData.FromBytes(GetRandomBuffer(blobSize)));
                }
            }
            else
            {
                for (int i = 0; i < blobCount.Value; i++)
                {
                    await container.UploadBlobAsync(GetNewBlobName(), BinaryData.FromBytes(GetRandomBuffer(blobSize)));
                }
            }
        }

        private async Task PopulateTestLocalDirectory(
            string directoryPath,
            int fileSize = Constants.KB,
            int? fileCount = null)
        {
            // Use known file set
            if (fileCount == null)
            {
                // Manually follows _testFiles pattern
                await CreateRandomFileAsync(directoryPath, "file1", size: fileSize);

                string subFolder = CreateRandomDirectory(directoryPath, "dir1");
                await CreateRandomFileAsync(subFolder, "file1", size: fileSize);
                await CreateRandomFileAsync(subFolder, "file2", size: fileSize);
                await CreateRandomFileAsync(subFolder, "file3", size: fileSize);

                string subFolder2 = CreateRandomDirectory(directoryPath, "dir2");
                await CreateRandomFileAsync(subFolder2, "file1", size: fileSize);
            }
            else
            {
                for (int i = 0; i < fileCount.Value; i++)
                {
                    await CreateRandomFileAsync(directoryPath, size: fileSize);
                }
            }
        }

        private long[] CalculateExpectedBytesUpdates(
            int fileSize,
            int fileCount,
            int chunkSize)
        {
            List<long> expectedBytesTransferred = new List<long>();
            int totalBytes = 0;

            // Async copy does not use chunks
            int numUpdates = (fileSize / chunkSize) * fileCount;
            for (int i = 0; i <= numUpdates; i++)
            {
                expectedBytesTransferred.Add(totalBytes);
                totalBytes += chunkSize;
            }

            return expectedBytesTransferred.ToArray();
        }

        private async Task TransferAndAssertProgress(
            StorageResourceContainer source,
            StorageResourceContainer destination,
            long[] expectedBytesTransferred,
            int fileCount,
            int skippedCount = 0,
            int failedCount = 0,
            TransferManagerOptions transferManagerOptions = default,
            TransferOptions transferOptions = default,
            bool trackBytes = true,
            StorageResourceCreationMode createMode = StorageResourceCreationMode.OverwriteIfExists,
            int waitTime = 30)
        {
            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorMode = TransferErrorMode.ContinueOnFailure
            };

            await using TransferManager transferManager = new TransferManager(transferManagerOptions);

            TestProgressHandler progressHandler = new TestProgressHandler();
            transferOptions ??= new TransferOptions();
            transferOptions.ProgressHandlerOptions = new()
            {
                ProgressHandler = progressHandler,
                TrackBytesTransferred = trackBytes
            }
                ;
            transferOptions.CreationMode = createMode;

            TransferOperation transfer = await transferManager.StartTransferAsync(source, destination, transferOptions);
            using CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTime));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            ProgressHandlerAsserts.AssertFileProgress(progressHandler.Updates, fileCount, skippedCount, failedCount);
            ProgressHandlerAsserts.AssertBytesTransferred(progressHandler.Updates, expectedBytesTransferred);
        }

        [Test]
        public async Task ProgressHandler_DownloadDirectory()
        {
            // Arrange
            await using DisposingBlobContainer source = await GetTestContainerAsync();
            using DisposingLocalDirectory destination = DisposingLocalDirectory.GetTestDirectory();

            await PopulateTestContainer(source.Container);

            StorageResourceContainer sourceResource =
                new BlobStorageResourceContainer(source.Container);
            StorageResourceContainer destinationResource =
                new LocalDirectoryStorageResourceContainer(destination.DirectoryPath);

            // Act / Assert
            await TransferAndAssertProgress(
                sourceResource,
                destinationResource,
                _expectedBytesTransferred,
                5 /* fileCount */);
        }

        [Test]
        public async Task ProgressHandler_DirectoryUpload()
        {
            // Arrange
            using DisposingLocalDirectory source = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingBlobContainer destination = await GetTestContainerAsync();

            await PopulateTestLocalDirectory(source.DirectoryPath);

            StorageResourceContainer sourceResource =
                new LocalDirectoryStorageResourceContainer(source.DirectoryPath);
            StorageResourceContainer destinationResource =
                new BlobStorageResourceContainer(destination.Container);

            // Act / Assert
            await TransferAndAssertProgress(
                sourceResource,
                destinationResource,
                _expectedBytesTransferred,
                5 /* fileCount */);
        }

        [Test]
        public async Task ProgressHandler_Copy()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_OAuth();
            await using DisposingBlobContainer source = await GetTestContainerAsync(service);
            await using DisposingBlobContainer destination = await GetTestContainerAsync();

            await PopulateTestContainer(source.Container);

            StorageResourceContainer sourceResource =
                new BlobStorageResourceContainer(source.Container);
            StorageResourceContainer destinationResource =
                new BlobStorageResourceContainer(destination.Container);

            // Act / Assert
            await TransferAndAssertProgress(
                sourceResource,
                destinationResource,
                _expectedBytesTransferred,
                5 /* fileCount */);
        }

        [Test]
        [TestCase(StorageResourceCreationMode.SkipIfExists)]
        [TestCase(StorageResourceCreationMode.FailIfExists)]
        public async Task ProgressHandler_Conflict(StorageResourceCreationMode createMode)
        {
            // Arrange
            using DisposingLocalDirectory source = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingBlobContainer destination = await GetTestContainerAsync();

            await PopulateTestLocalDirectory(source.DirectoryPath);

            // Create conflicts
            await destination.Container.UploadBlobAsync(_testFiles[0], BinaryData.FromBytes(GetRandomBuffer(10)));
            await destination.Container.UploadBlobAsync(_testFiles[2], BinaryData.FromBytes(GetRandomBuffer(10)));

            StorageResourceContainer sourceResource =
                new LocalDirectoryStorageResourceContainer(source.DirectoryPath);
            StorageResourceContainer destinationResource =
                new BlobStorageResourceContainer(destination.Container);

            // Act / Assert
            await TransferAndAssertProgress(
                sourceResource,
                destinationResource,
                _expectedBytesTransferred.Take(_expectedBytesTransferred.Length - 2).ToArray(),
                fileCount: 5,
                skippedCount: createMode == StorageResourceCreationMode.SkipIfExists ? 2 : 0,
                failedCount: createMode == StorageResourceCreationMode.FailIfExists ? 2 : 0,
                createMode: createMode);
        }

        [Test]
        [TestCase(TransferDirection.Upload)]
        [TestCase(TransferDirection.Download)]
        [TestCase(TransferDirection.Copy)]
        public async Task ProgressHandler_Chunks(TransferDirection transferType)
        {
            // Arrange
            // For this test, file size should be multiple of chunk size to make predictable progress updates
            int fileSize = 2 * Constants.KB;
            int fileCount = 10;
            int chunkSize = Constants.KB / 2;

            BlobServiceClient service = GetServiceClient_OAuth();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingBlobContainer sourceContainer = await GetTestContainerAsync(service);
            await using DisposingBlobContainer destinationContainer = await GetTestContainerAsync();

            StorageResourceContainer sourceResource;
            StorageResourceContainer destinationResource;
            if (transferType == TransferDirection.Upload)
            {
                await PopulateTestLocalDirectory(localDirectory.DirectoryPath, fileSize, fileCount);
                sourceResource = new LocalDirectoryStorageResourceContainer(localDirectory.DirectoryPath);
                destinationResource = new BlobStorageResourceContainer(destinationContainer.Container);
            }
            else if (transferType == TransferDirection.Download)
            {
                await PopulateTestContainer(sourceContainer.Container, fileSize, fileCount);
                sourceResource = new BlobStorageResourceContainer(sourceContainer.Container);
                destinationResource = new LocalDirectoryStorageResourceContainer(localDirectory.DirectoryPath);
            }
            else // TransferType.Copy
            {
                await PopulateTestContainer(sourceContainer.Container, fileSize, fileCount);
                sourceResource = new BlobStorageResourceContainer(sourceContainer.Container);
                destinationResource = new BlobStorageResourceContainer(destinationContainer.Container);
            }

            TransferManagerOptions transferManagerOptions = new TransferManagerOptions()
            {
                ErrorMode = TransferErrorMode.StopOnAnyFailure,
                MaximumConcurrency = 3
            };
            TransferOptions transferOptions = new TransferOptions()
            {
                InitialTransferSize = chunkSize,
                MaximumTransferChunkSize = chunkSize
            };

            // Act / Assert
            await TransferAndAssertProgress(
                sourceResource,
                destinationResource,
                CalculateExpectedBytesUpdates(fileSize, fileCount, chunkSize),
                10 /* fileCount */,
                transferManagerOptions: transferManagerOptions,
                transferOptions: transferOptions,
                waitTime: 90);
        }

        [LiveOnly]
        [Test]
        [TestCase(0)]
        [TestCase(150)]
        public async Task ProgressHandler_PauseResume(int delayInMs)
        {
            // Arrange
            await using DisposingBlobContainer source = await GetTestContainerAsync();
            using DisposingLocalDirectory destination = DisposingLocalDirectory.GetTestDirectory();

            await PopulateTestContainer(source.Container);

            BlobsStorageResourceProvider blobProvider = new(TestEnvironment.Credential);

            TransferManagerOptions transferManagerOptions = new()
            {
                ProvidersForResuming = [blobProvider]
            };
            TransferManager transferManager = new(transferManagerOptions);

            TestProgressHandler progressHandler = new();
            TransferOptions transferOptions = new()
            {
                ProgressHandlerOptions = new()
                {
                    ProgressHandler = progressHandler,
                    TrackBytesTransferred = true
                }
            };
            TestEventsRaised testEventsRaised = new(transferOptions);

            // Act - Start transfer
            TransferOperation transfer = await transferManager.StartTransferAsync(
                await blobProvider.FromContainerAsync(source.Container.Uri),
                LocalFilesStorageResourceProvider.FromDirectory(destination.DirectoryPath),
                transferOptions);

            // TODO: This can likely be replaced with something better once mocking is in place
            // Wait for the transfer to start happening
            await Task.Delay(delayInMs);

            // Pause transfer
            using CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transferManager.PauseTransferAsync(transfer.Id, tokenSource.Token);
            Assert.AreEqual(TransferState.Paused, transfer.Status.State);

            // Record the current number of progress updates to use during assertions
            int pause = progressHandler.Updates.Count;

            // Resume transfer
            TransferOperation resumeTransfer = await transferManager.ResumeTransferAsync(
                transfer.Id,
                transferOptions);

            using CancellationTokenSource tokenSource2 = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await resumeTransfer.WaitForCompletionAsync(tokenSource2.Token);

            // Assert
            Assert.AreEqual(TransferState.Completed, resumeTransfer.Status.State);
            ProgressHandlerAsserts.AssertFileProgress(progressHandler.Updates, 5, pauseIndexes: pause);
            ProgressHandlerAsserts.AssertBytesTransferred(progressHandler.Updates, _expectedBytesTransferred);
        }
    }
}
