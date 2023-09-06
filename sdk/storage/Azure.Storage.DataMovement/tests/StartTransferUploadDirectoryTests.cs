// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferUploadDirectoryTests : DataMovementBlobTestBase
    {
        public StartTransferUploadDirectoryTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        #region Directory Block Blob
        /// <summary>
        /// Upload and verify the contents of the blob
        ///
        /// By default in this function an event arguement will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="waitTimeInSec"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        private async Task UploadBlobDirectoryAndVerify(
            BlobContainerClient destinationContainer,
            string localDirectoryPath,
            List<string> files,
            string destinationPrefix = default,
            int waitTimeInSec = 30,
            TransferManagerOptions transferManagerOptions = default,
            DataTransferOptions options = default)
        {
            // Set transfer options
            options ??= new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure
            };

            destinationPrefix ??= "foo";

            // Initialize transferManager
            TransferManager transferManager = new TransferManager(transferManagerOptions);

            StorageResourceContainer sourceResource =
                new LocalDirectoryStorageResourceContainer(localDirectoryPath);
            StorageResourceContainer destinationResource =
                new BlobStorageResourceContainer(destinationContainer, new() { BlobDirectoryPrefix = destinationPrefix });

            // Set up blob to upload
            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);

            // Assert
            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            await testEventsRaised.AssertContainerCompletedCheck(files.Count);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.Completed, transfer.TransferStatus);

            // Assert - Check Response
            List<string> blobs = ((List<BlobItem>)await destinationContainer.GetBlobsAsync(prefix: destinationPrefix).ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert - Check destination blobs
            Assert.AreEqual(files.Count, blobs.Count());

            for (int i = 0; i < files.Count; i++)
            {
                // Verify Upload
                using (FileStream fileStream = File.OpenRead(files[i]))
                {
                    string blobName = $"{destinationPrefix}/{files[i].Substring(localDirectoryPath.Length+1)}";
                    BlockBlobClient destinationBlob = destinationContainer.GetBlockBlobClient(blobName);
                    Assert.IsTrue(await destinationBlob.ExistsAsync());
                    await DownloadAndAssertAsync(fileStream, destinationBlob);
                }
            }
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(0, 10)]
        [TestCase(100, 10)]
        [TestCase(Constants.KB, 10)]
        public async Task LocalToBlockBlobDirectory_SmallSize(long blobSize, int waitTimeInSec)
        {
            DataTransferOptions options = new DataTransferOptions();
            List<string> files = new List<string>();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);
            await using DisposingContainer test = await GetTestContainerAsync();

            files.Add(await CreateRandomFileAsync(localDirectory, size: blobSize));
            files.Add(await CreateRandomFileAsync(localDirectory, size: blobSize));

            string openSubfolder = CreateRandomDirectory(localDirectory);
            files.Add(await CreateRandomFileAsync(openSubfolder, size: blobSize));
            string lockedSubfolder = CreateRandomDirectory(localDirectory);
            files.Add(await CreateRandomFileAsync(lockedSubfolder, size: blobSize));

            // Arrange
            await UploadBlobDirectoryAndVerify(
                test.Container,
                localDirectory,
                files,
                waitTimeInSec: waitTimeInSec,
                options: options);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(4 * Constants.MB, 200)]
        [TestCase(257 * Constants.MB, 500)]
        [TestCase(Constants.GB, 500)]
        public async Task LocalToBlockBlobDirectory_LargeSize(long blobSize, int waitTimeInSec)
        {
            DataTransferOptions options = new DataTransferOptions();
            List<string> files = new List<string>();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);
            await using DisposingContainer test = await GetTestContainerAsync();

            files.Add(await CreateRandomFileAsync(localDirectory, size: blobSize));
            files.Add(await CreateRandomFileAsync(localDirectory, size: blobSize));

            string openSubfolder = CreateRandomDirectory(localDirectory);
            files.Add(await CreateRandomFileAsync(openSubfolder, size: blobSize));
            string lockedSubfolder = CreateRandomDirectory(localDirectory);
            files.Add(await CreateRandomFileAsync(lockedSubfolder, size: blobSize));

            // Arrange
            await UploadBlobDirectoryAndVerify(
                test.Container,
                localDirectory,
                files,
                waitTimeInSec: waitTimeInSec,
                options: options);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task LocalToBlockBlobDirectory_SmallChunks()
        {
            long blobSize = Constants.KB;
            int waitTimeInSec = 25;
            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };
            List<string> files = new List<string>();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);
            await using DisposingContainer test = await GetTestContainerAsync();

            files.Add(await CreateRandomFileAsync(localDirectory, size: blobSize));
            files.Add(await CreateRandomFileAsync(localDirectory, size: blobSize));

            string openSubfolder = CreateRandomDirectory(localDirectory);
            files.Add(await CreateRandomFileAsync(openSubfolder, size: blobSize));
            string lockedSubfolder = CreateRandomDirectory(localDirectory);
            files.Add(await CreateRandomFileAsync(lockedSubfolder, size: blobSize));

            // Arrange
            await UploadBlobDirectoryAndVerify(
                test.Container,
                localDirectory,
                files,
                waitTimeInSec: waitTimeInSec,
                options: options);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task LocalToBlockBlobDirectory_SmallChunks_ManyFiles()
        {
            // Arrange
            long blobSize = 2 * Constants.KB;
            int waitTimeInSec = 25;
            TransferManagerOptions transferManagerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.StopOnAnyFailure,
                MaximumConcurrency = 3,
            };
            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512,
            };
            List<string> files = new List<string>();

            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);
            await using DisposingContainer test = await GetTestContainerAsync();

            files.Add(await CreateRandomFileAsync(localDirectory, size: blobSize));
            files.Add(await CreateRandomFileAsync(localDirectory, size: blobSize));
            files.Add(await CreateRandomFileAsync(localDirectory, size: blobSize));
            files.Add(await CreateRandomFileAsync(localDirectory, size: blobSize));
            files.Add(await CreateRandomFileAsync(localDirectory, size: blobSize));

            string openSubfolder = CreateRandomDirectory(localDirectory);
            files.Add(await CreateRandomFileAsync(openSubfolder, size: blobSize));
            files.Add(await CreateRandomFileAsync(openSubfolder, size: blobSize));
            files.Add(await CreateRandomFileAsync(openSubfolder, size: blobSize));
            string openSubfolder2 = CreateRandomDirectory(localDirectory);
            files.Add(await CreateRandomFileAsync(openSubfolder2, size: blobSize));
            files.Add(await CreateRandomFileAsync(openSubfolder2, size: blobSize));

            // Act / Assert
            await UploadBlobDirectoryAndVerify(
                test.Container,
                localDirectory,
                files,
                waitTimeInSec: waitTimeInSec,
                transferManagerOptions: transferManagerOptions,
                options: options);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_EmptyFolder()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            // Set up directory to upload
            var dirName = GetNewBlobDirectoryName();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);

            // Set up destination client
            StorageResourceContainer destinationResource = new BlobStorageResourceContainer(test.Container, new() { BlobDirectoryPrefix = dirName });
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(localDirectory);

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager transferManager = new TransferManager(managerOptions);
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Act
            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);

            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(tokenSource.Token);
            // Assert
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();
            // Assert
            Assert.IsEmpty(blobs);
            testEventsRaised.AssertUnexpectedFailureCheck();
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_SingleFile()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobStorageResourceContainer(test.Container, new() { BlobDirectoryPrefix = dirName });

            List<string> files = new List<string>();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);

            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(localDirectory);
            string openChild = await CreateRandomFileAsync(localDirectory);
            files.Add(openChild);

            // Arrange
            await UploadBlobDirectoryAndVerify(
                test.Container,
                localDirectory,
                files,
                waitTimeInSec: 10);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_ManySubDirectories()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);

            string dirName = GetNewBlobName();
            List<string> files = new List<string>();

            string openSubfolder = CreateRandomDirectory(localDirectory);
            string openSubchild = await CreateRandomFileAsync(openSubfolder);
            files.Add(openSubchild);

            string openSubfolder2 = CreateRandomDirectory(localDirectory);
            string openSubChild2_1 = await CreateRandomFileAsync(openSubfolder2);
            string openSubChild2_2 = await CreateRandomFileAsync(openSubfolder2);
            string openSubChild2_3 = await CreateRandomFileAsync(openSubfolder2);
            files.Add(openSubChild2_1);
            files.Add(openSubChild2_2);
            files.Add(openSubChild2_3);

            string openSubfolder3 = CreateRandomDirectory(localDirectory);
            string openSubChild3_1 = await CreateRandomFileAsync(openSubfolder2);
            string openSubChild3_2 = await CreateRandomFileAsync(openSubfolder2);
            string openSubChild3_3 = await CreateRandomFileAsync(openSubfolder2);
            files.Add(openSubChild3_1);
            files.Add(openSubChild3_2);
            files.Add(openSubChild3_3);

            string openSubfolder4 = CreateRandomDirectory(localDirectory);
            string openSubChild4_1 = await CreateRandomFileAsync(openSubfolder2);
            string openSubChild4_2 = await CreateRandomFileAsync(openSubfolder2);
            string openSubChild4_3 = await CreateRandomFileAsync(openSubfolder2);
            files.Add(openSubChild4_1);
            files.Add(openSubChild4_2);
            files.Add(openSubChild4_3);

            await UploadBlobDirectoryAndVerify(
                test.Container,
                localDirectory,
                files,
                destinationPrefix: dirName,
                waitTimeInSec: 10);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task DirectoryUpload_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);
            string dirName = GetNewBlobName();

            List<string> files = new List<string>();

            string subfolderName = localDirectory;
            for (int i = 0; i < level; i++)
            {
                string openSubfolder = CreateRandomDirectory(subfolderName);
                files.Add(await CreateRandomFileAsync(openSubfolder));
                subfolderName = openSubfolder;
            }

            await UploadBlobDirectoryAndVerify(
                        test.Container,
                        localDirectory,
                        files,
                        destinationPrefix: dirName,
                        waitTimeInSec: 10);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_EmptySubDirectories()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);

            string dirName = GetNewBlobName();
            List<string> files = new List<string>();
            string openSubfolder = CreateRandomDirectory(localDirectory);
            for (int i = 0; i < 6; i++)
            {
                files.Add(await CreateRandomFileAsync(openSubfolder));
            }

            string openSubfolder2 = CreateRandomDirectory(localDirectory);

            string openSubfolder3 = CreateRandomDirectory(localDirectory);

            string openSubfolder4 = CreateRandomDirectory(localDirectory);

            await UploadBlobDirectoryAndVerify(
                test.Container,
                localDirectory,
                files,
                destinationPrefix: dirName,
                waitTimeInSec: 10);
        }
        #endregion

        #region DirectoryUploadTests

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_OverwriteTrue()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);

            List<string> files = new List<string>();
            string file1 = await CreateRandomFileAsync(localDirectory);
            string file2 = await CreateRandomFileAsync(localDirectory);
            files.Add(file1);
            files.Add(file2);

            string openSubfolder = CreateRandomDirectory(localDirectory);
            string file3 = await CreateRandomFileAsync(openSubfolder);
            files.Add(file3);

            string lockedSubfolder = CreateRandomDirectory(localDirectory);
            string file4 = await CreateRandomFileAsync(lockedSubfolder);
            files.Add(file4);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists
            };
            BlobClient blobClient = test.Container.GetBlobClient(dirName + "/" + file1.Substring(localDirectory.Length + 1).Replace('\\', '/'));
            await blobClient.UploadAsync(file1);

            // Act
            await UploadBlobDirectoryAndVerify(
                test.Container,
                localDirectory,
                files,
                destinationPrefix: dirName,
                waitTimeInSec: 10,
                options: options);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_OverwriteFalse()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);
            string dirName = GetNewBlobName();

            List<string> files = new List<string>();
            string file1 = await CreateRandomFileAsync(localDirectory);
            string file2 = await CreateRandomFileAsync(localDirectory);
            files.Add(file1);
            files.Add(file2);

            string openSubfolder = CreateRandomDirectory(localDirectory);
            string file3 = await CreateRandomFileAsync(openSubfolder);
            files.Add(file3);

            string lockedSubfolder = CreateRandomDirectory(localDirectory);
            string file4 = await CreateRandomFileAsync(lockedSubfolder);
            files.Add(file4);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists
            };
            BlobClient blobClient = test.Container.GetBlobClient(dirName + "/" + file1.Substring(localDirectory.Length + 1).Replace('\\', '/'));
            await blobClient.UploadAsync(file1);

            // Act
            await UploadBlobDirectoryAndVerify(
                test.Container,
                localDirectory,
                files,
                destinationPrefix: dirName,
                waitTimeInSec: 10,
                options: options);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(BlobType.Block)]
        [TestCase(BlobType.Append)]
        [TestCase(BlobType.Page)]
        public async Task DirectoryUpload_BlobType(BlobType blobType)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);
            string dirName = GetNewBlobName();

            string file1 = await CreateRandomFileAsync(localDirectory);
            string openSubfolder = CreateRandomDirectory(localDirectory);
            string file2 = await CreateRandomFileAsync(openSubfolder);
            string destinationPrefix = "foo";

            TransferManager transferManager = new TransferManager();

            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(localDirectory);
            BlobStorageResourceContainerOptions options = new BlobStorageResourceContainerOptions()
            {
                BlobType = blobType,
                BlobDirectoryPrefix = destinationPrefix,
            };
            StorageResourceContainer destinationResource = new BlobStorageResourceContainer(
                test.Container,
                options);

            DataTransferOptions containerOptions = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(containerOptions);

            // Act
            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, containerOptions);
            await transfer.WaitForCompletionAsync();

            // Assert
            AsyncPageable<BlobItem> blobs = test.Container.GetBlobsAsync(prefix: destinationPrefix);
            await foreach (BlobItem blob in blobs)
            {
                Assert.AreEqual(blob.Properties.BlobType, blobType);
            }
            await testEventsRaised.AssertContainerCompletedCheck(2);
        }
        #endregion DirectoryUploadTests

        #region DirectoryUploadTests_Root

        private async Task<string[]> PopulateLocalTestDirectory(string path)
        {
            string file1 = await CreateRandomFileAsync(path, size: 10);

            string dir1 = CreateRandomDirectory(path);
            string file2 = await CreateRandomFileAsync(dir1, size: 10);
            string file3 = await CreateRandomFileAsync(dir1, size: 10);
            string file4 = await CreateRandomFileAsync(dir1, size: 10);

            string dir2 = CreateRandomDirectory(path);
            string file5 = await CreateRandomFileAsync(dir2, size: 10);

            string[] files = { file1, file2, file3, file4, file5 };
            return files;
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_Root()
        {
            // Arrange
            using DisposingLocalDirectory source = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer destination = await GetTestContainerAsync();

            string[] files = await PopulateLocalTestDirectory(source.DirectoryPath);

            TransferManager transferManager = new TransferManager();

            StorageResourceContainer sourceResource =
                new LocalDirectoryStorageResourceContainer(source.DirectoryPath);
            StorageResourceContainer destinationResource =
                new BlobStorageResourceContainer(destination.Container);

            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource);

            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            IEnumerable<string> destinationFiles =
                (await destination.Container.GetBlobsAsync().ToEnumerableAsync()).Select(b => b.Name);

            Assert.IsTrue(files
                .Select(f => f.Substring(source.DirectoryPath.Length + 1).Replace("\\", "/"))
                .OrderBy(f => f)
                .SequenceEqual(destinationFiles.OrderBy(f => f)));
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(DataTransferErrorMode.ContinueOnFailure)]
        [TestCase(DataTransferErrorMode.StopOnAnyFailure)]
        public async Task DirectoryUpload_ErrorHandling(DataTransferErrorMode errorHandling)
        {
            // Arrange
            using DisposingLocalDirectory source = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer destination = await GetTestContainerAsync();

            string[] files = await PopulateLocalTestDirectory(source.DirectoryPath);

            // Create conflict
            await destination.Container.UploadBlobAsync(
                files[0].Substring(source.DirectoryPath.Length + 1), BinaryData.FromString("Hello world"));

            TransferManager transferManager = new TransferManager(new TransferManagerOptions()
            {
                ErrorHandling = errorHandling
            });

            StorageResourceContainer sourceResource =
                new LocalDirectoryStorageResourceContainer(source.DirectoryPath);
            StorageResourceContainer destinationResource =
                new BlobStorageResourceContainer(destination.Container);

            // Conflict should cause failure
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Act
            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);

            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            // Assert
            IEnumerable<string> destinationFiles =
                (await destination.Container.GetBlobsAsync().ToEnumerableAsync()).Select(b => b.Name);

            if (errorHandling == DataTransferErrorMode.ContinueOnFailure)
            {
                await testEventsRaised.AssertContainerCompletedWithFailedCheckContinue(1);

                // Verify all files exist, meaning files without conflict were transferred.
                Assert.IsTrue(files
                    .Select(f => f.Substring(source.DirectoryPath.Length + 1).Replace("\\", "/"))
                    .OrderBy(f => f)
                    .SequenceEqual(destinationFiles.OrderBy(f => f)));
            }
            else if (errorHandling == DataTransferErrorMode.StopOnAnyFailure)
            {
                await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);

                // Cannot do any file verification as transfer may proceed while job being cancelled
            }
        }

        #endregion

        #region Single Concurrency
        private async Task CreateTempDirectoryStructure(
            string sourceFolderPath,
            int size)
        {
            await CreateRandomFileAsync(sourceFolderPath, "blob1", size: size);
            await CreateRandomFileAsync(sourceFolderPath, "blob2,", size: size);

            string openSubfolder = CreateRandomDirectory(sourceFolderPath);
            await CreateRandomFileAsync(openSubfolder, "blob3", size: size);
            string lockedSubfolder = CreateRandomDirectory(sourceFolderPath);
            await CreateRandomFileAsync(lockedSubfolder, "blob4", size: size);
        }

        private async Task<DataTransfer> CreateStartTransfer(
            string sourceDirectoryPath,
            BlobContainerClient containerClient,
            int concurrency,
            bool createFailedCondition = false,
            DataTransferOptions options = default,
            int size = Constants.KB)
        {
            // Arrange
            string destinationFolderName = GetNewBlobDirectoryName();
            await CreateTempDirectoryStructure(sourceDirectoryPath, size);

            // Create storage resources
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(sourceDirectoryPath);
            // Create destination folder
            StorageResourceContainer destinationResource = new BlobStorageResourceContainer(containerClient, new() { BlobDirectoryPrefix = destinationFolderName });

            // Create Transfer Manager with single threaded operation
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                MaximumConcurrency = concurrency,
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            // If we want a failure condition to happen
            if (createFailedCondition)
            {
                string destinationBlobName = $"{destinationFolderName}/blob1";
                await CreateBlockBlob(
                    containerClient: containerClient,
                    localSourceFile: Path.Combine(sourceDirectoryPath, GetNewBlobName()),
                    blobName: destinationBlobName,
                    size: size);
            }

            // Start transfer and await for completion.
            return await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                testDirectory.DirectoryPath,
                test.Container,
                1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.Completed, transfer.TransferStatus);
            await testEventsRaised.AssertContainerCompletedCheck(4);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                testDirectory.DirectoryPath,
                test.Container,
                1,
                true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                testDirectory.DirectoryPath,
                test.Container,
                1,
                true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            await testEventsRaised.AssertContainerCompletedWithSkippedCheck(1);
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a EnsureCompleted
            DataTransfer transfer = await CreateStartTransfer(
                testDirectory.DirectoryPath,
                test.Container,
                1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertContainerCompletedCheck(4);
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.Completed, transfer.TransferStatus);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                testDirectory.DirectoryPath,
                test.Container,
                1,
                true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Skipped()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a EnsureCompleted
            DataTransfer transfer = await CreateStartTransfer(
                testDirectory.DirectoryPath,
                test.Container,
                1,
                true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertContainerCompletedWithSkippedCheck(1);
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Failed_SmallChunks()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists,
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                sourceDirectoryPath: testDirectory.DirectoryPath,
                containerClient: test.Container,
                concurrency: 1,
                createFailedCondition: true,
                options: options,
                size: Constants.KB * 4);

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
        }
        #endregion
    }
}
