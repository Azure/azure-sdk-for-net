// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.DataMovement.Models;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class ProgressHandlerTests : DataMovementBlobTestBase
    {
        private int _size = Constants.KB;
        private string[] _testFiles = { "file1", "dir1/file1", "dir1/file2", "dir1/file3", "dir2/file1" };
        private long[] _expectedBytesTransferred = { 0, 1024, 2048, 3072, 4096, 5120 };

        public ProgressHandlerTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, default)
        {
        }

        private async Task PopulateTestContainer(BlobContainerClient container)
        {
            foreach (string file in _testFiles)
            {
                await container.UploadBlobAsync(file, BinaryData.FromBytes(GetRandomBuffer(_size)));
            }
        }

        private async Task PopulateTestLocalDirectory(string directoryPath)
        {
            // Manually follows _testFiles pattern
            await CreateRandomFileAsync(directoryPath, "file1", size: _size);

            string subFolder = CreateRandomDirectory(directoryPath, "dir1");
            await CreateRandomFileAsync(subFolder, "file1", size: _size);
            await CreateRandomFileAsync(subFolder, "file2", size: _size);
            await CreateRandomFileAsync(subFolder, "file3", size: _size);

            string subFolder2 = CreateRandomDirectory(directoryPath, "dir2");
            await CreateRandomFileAsync(subFolder2, "file1", size: _size);
        }

        private async Task TransferAndAssertProgress(
            StorageResourceContainer source,
            StorageResourceContainer destination,
            long[] expectedBytesTransferred,
            int fileCount,
            int skippedCount = 0,
            int failedCount = 0,
            TransferManagerOptions transferManagerOptions = default,
            ProgressHandlerOptions progressHandlerOptions = default,
            StorageResourceCreateMode createMode = StorageResourceCreateMode.Overwrite)
        {
            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };

            TransferManager transferManager = new TransferManager(transferManagerOptions);

            TestProgressHandler progressHandler = new TestProgressHandler();
            TransferOptions transferOptions = new TransferOptions()
            {
                ProgressHandler = progressHandler,
                ProgressHandlerOptions = progressHandlerOptions ?? new ProgressHandlerOptions()
                {
                    TrackBytesTransferred = true
                },
                CreateMode = createMode,
            };

            DataTransfer transfer = await transferManager.StartTransferAsync(source, destination, transferOptions);
            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(tokenSource.Token);
            Console.WriteLine("Transfer completed");

            progressHandler.AssertProgress(fileCount, skippedCount, failedCount);
            progressHandler.AssertBytesTransferred(expectedBytesTransferred);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
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
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
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
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task ProgressHandler_AsyncCopy()
        {
            // Arrange
            await using DisposingBlobContainer source = await GetTestContainerAsync();
            await using DisposingBlobContainer destination = await GetTestContainerAsync();

            await PopulateTestContainer(source.Container);

            StorageResourceContainer sourceResource =
                new BlobStorageResourceContainer(source.Container);
            StorageResourceContainer destinationResource = new BlobStorageResourceContainer(
                destination.Container,
                new BlobStorageResourceContainerOptions()
                {
                    CopyMethod = TransferCopyMethod.AsyncCopy
                });

            // Act / Assert
            await TransferAndAssertProgress(
                sourceResource,
                destinationResource,
                _expectedBytesTransferred,
                5 /* fileCount */);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(StorageResourceCreateMode.Skip)]
        [TestCase(StorageResourceCreateMode.Fail)]
        public async Task ProgressHandler_Conflict(StorageResourceCreateMode createMode)
        {
            // Arrange
            using DisposingLocalDirectory source = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingBlobContainer destination = await GetTestContainerAsync();

            await PopulateTestLocalDirectory(source.DirectoryPath);

            // Create conflicts
            await destination.Container.UploadBlobAsync(_testFiles[0], BinaryData.FromBytes(GetRandomBuffer(_size)));
            await destination.Container.UploadBlobAsync(_testFiles[2], BinaryData.FromBytes(GetRandomBuffer(_size)));

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
                skippedCount: createMode == StorageResourceCreateMode.Skip ? 2 : 0,
                failedCount: createMode == StorageResourceCreateMode.Fail ? 2 : 0,
                createMode: createMode);
        }
    }
}
