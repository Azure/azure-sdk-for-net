// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.DataMovement.Models;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class ProgressHandlerTests : DataMovementBlobTestBase
    {
        public ProgressHandlerTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, default)
        {
        }

        [Test]
        public async Task ProgressHandler_DownloadDirectory()
        {
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            BinaryData data = BinaryData.FromString("Hello World!");

            await testContainer.Container.UploadBlobAsync("file1", data);
            await testContainer.Container.UploadBlobAsync("dir1/file2", data);
            await testContainer.Container.UploadBlobAsync("dir1/file3", data);
            await testContainer.Container.UploadBlobAsync("dir1/file4", data);
            await testContainer.Container.UploadBlobAsync("dir2/file5", data);

            string destinationFolder = CreateRandomDirectory(Path.GetTempPath());
            Console.WriteLine(destinationFolder);

            StorageResourceContainer sourceResource =
                new BlobStorageResourceContainer(testContainer.Container);
            StorageResourceContainer destinationResource =
                new LocalDirectoryStorageResourceContainer(destinationFolder);

            TransferManager transferManager = new TransferManager();

            TestProgressHandler progressHandler = new TestProgressHandler();
            TransferOptions options = new TransferOptions()
            {
                ProgressHandler = progressHandler,
            };

            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);
            await transfer.AwaitCompletion();
            progressHandler.AssertProgress(5);
        }

        [Test]
        public async Task ProgressHandler_DirectoryUpload()
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
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

            TestProgressHandler progressHandler = new TestProgressHandler();
            TransferOptions options = new TransferOptions()
            {
                ProgressHandler = progressHandler,
            };

            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);
            await transfer.AwaitCompletion();
            progressHandler.AssertProgress(5);
        }
    }
}
