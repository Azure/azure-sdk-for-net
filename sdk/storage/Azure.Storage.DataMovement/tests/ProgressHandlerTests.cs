// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Tests;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
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
            DataTransferOptions transferOptions = default,
            bool trackBytes = true,
            StorageResourceCreationPreference createMode = StorageResourceCreationPreference.OverwriteIfExists,
            int waitTime = 30)
        {
            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure
            };

            TransferManager transferManager = new TransferManager(transferManagerOptions);

            TestProgressHandler progressHandler = new TestProgressHandler();
            transferOptions ??= new DataTransferOptions();
            transferOptions.ProgressHandlerOptions = new ProgressHandlerOptions(progressHandler, trackBytes);
            transferOptions.CreationPreference = createMode;

            DataTransfer transfer = await transferManager.StartTransferAsync(source, destination, transferOptions);
            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTime));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            ProgressHandlerAsserts.AssertFileProgress(progressHandler.Updates, fileCount, skippedCount, failedCount);
            ProgressHandlerAsserts.AssertBytesTransferred(progressHandler.Updates, expectedBytesTransferred);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task ProgressHandler_DownloadDirectory()
        {
            // Arrange
            await using DisposingContainer source = await GetTestContainerAsync();
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
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task ProgressHandler_DirectoryUpload()
        {
            // Arrange
            using DisposingLocalDirectory source = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer destination = await GetTestContainerAsync();

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
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task ProgressHandler_Copy()
        {
            // Arrange
            await using DisposingContainer source = await GetTestContainerAsync(publicAccessType: PublicAccessType.Blob);
            await using DisposingContainer destination = await GetTestContainerAsync();

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
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(StorageResourceCreationPreference.SkipIfExists)]
        [TestCase(StorageResourceCreationPreference.FailIfExists)]
        public async Task ProgressHandler_Conflict(StorageResourceCreationPreference createMode)
        {
            // Arrange
            using DisposingLocalDirectory source = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer destination = await GetTestContainerAsync();

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
                skippedCount: createMode == StorageResourceCreationPreference.SkipIfExists ? 2 : 0,
                failedCount: createMode == StorageResourceCreationPreference.FailIfExists ? 2 : 0,
                createMode: createMode);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
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

            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer sourceContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.Blob);
            await using DisposingContainer destinationContainer = await GetTestContainerAsync();

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
                ErrorHandling = DataTransferErrorMode.StopOnAnyFailure,
                MaximumConcurrency = 3
            };
            DataTransferOptions transferOptions = new DataTransferOptions()
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
                waitTime: 30);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35558")]
        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(0)]
        [TestCase(150)]
        public async Task ProgressHandler_PauseResume(int delayInMs)
        {
            // Arrange
            await using DisposingContainer source = await GetTestContainerAsync();
            using DisposingLocalDirectory destination = DisposingLocalDirectory.GetTestDirectory();

            await PopulateTestContainer(source.Container);

            StorageResourceContainer sourceResource =
                new BlobStorageResourceContainer(source.Container);
            StorageResourceContainer destinationResource =
                new LocalDirectoryStorageResourceContainer(destination.DirectoryPath);

            TransferManager transferManager = new TransferManager();

            TestProgressHandler progressHandler = new TestProgressHandler();
            DataTransferOptions transferOptions = new DataTransferOptions()
            {
                ProgressHandlerOptions = new ProgressHandlerOptions(progressHandler, true)
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);

            // Act - Start transfer
            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, transferOptions);

            // TODO: This can likely be replaced with something better once mocking is in place
            // Wait for the transfer to start happening
            await Task.Delay(delayInMs);

            // Pause transfer
            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transferManager.PauseTransferIfRunningAsync(transfer.Id, tokenSource.Token);
            Assert.AreEqual(DataTransferState.Paused, transfer.TransferStatus);

            // Record the current number of progress updates to use during assertions
            int pause = progressHandler.Updates.Count;

            // Resume transfer
            DataTransfer resumeTransfer = await transferManager.ResumeTransferAsync(
                transfer.Id,
                transferOptions);

            tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await resumeTransfer.WaitForCompletionAsync(tokenSource.Token);

            // Assert
            Assert.AreEqual(DataTransferState.Completed, resumeTransfer.TransferStatus);
            ProgressHandlerAsserts.AssertFileProgress(progressHandler.Updates, 5, pauseIndexes: pause);
            ProgressHandlerAsserts.AssertBytesTransferred(progressHandler.Updates, _expectedBytesTransferred);
        }
    }
}
