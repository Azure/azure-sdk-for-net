// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.DataMovement.Models;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class ProgressTrackingTests : DataMovementBlobTestBase
    {
        public ProgressTrackingTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, default)
        {
        }

        private void Progress(StorageTransferProgress progress)
        {
            string message = $"Queued: {progress.QueuedCount}, InProgress: {progress.InProgressCount}, Completed: {progress.CompletedCount}";
            Console.WriteLine(message);
        }

        private void BytesProgress(long bytesTransferred)
        {
            string message = $"Bytes: {bytesTransferred}";
            Console.WriteLine(message);
        }

        [Test]
        public async Task ProgressTracking_DirectoryUpload()
        {
            using DisposingLocalDirectory testDirectory = GetTestLocalDirectory();
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await CreateRandomFileAsync(testDirectory.DirectoryPath, size: Constants.KB);
            await CreateRandomFileAsync(testDirectory.DirectoryPath, size: Constants.KB);

            string subFolder = CreateRandomDirectory(testDirectory.DirectoryPath);
            await CreateRandomFileAsync(subFolder, size: Constants.KB);
            await CreateRandomFileAsync(subFolder, size: Constants.KB);

            string subFolder2 = CreateRandomDirectory(testDirectory.DirectoryPath);
            await CreateRandomFileAsync(subFolder2, size: Constants.KB);

            TransferManager transferManager = new TransferManager();

            StorageResourceContainer sourceResource =
                new LocalDirectoryStorageResourceContainer(testDirectory.DirectoryPath);
            StorageResourceContainer destinationResource =
                new BlobStorageResourceContainer(testContainer.Container);

            IProgress<StorageTransferProgress> progressHandler = new Progress<StorageTransferProgress>(Progress);
            IProgress<long> bytesTransferredHandler = new Progress<long>(BytesProgress);
            TransferOptions options = new TransferOptions()
            {
                ProgressHandler = progressHandler,
                BytesTransferredHandler = bytesTransferredHandler
            };

            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);
            await transfer.AwaitCompletion();
        }
    }
}
