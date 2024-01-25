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
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferSyncCopyDirectoryTests : DataMovementBlobTestBase
    {
        public StartTransferSyncCopyDirectoryTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        /// <summary>
        /// Upload and verify the contents of the blob
        ///
        /// By default in this function an event argument will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        /// <param name="container">The source container which will contains the source blobs</param>
        /// <param name="sourceBlobPrefix">The source blob prefix/folder</param>
        /// <param name="sourceFilePrefix">The local source file prefix to join together with the source prefixes below.</param>
        /// <param name="sourceFiles">The source file paths relative to the sourceFilePrefix</param>
        /// <param name="destinationBlobPrefix">The destination local path to download the blobs to</param>
        /// <param name="waitTimeInSec">
        /// How long we should wait until we cancel the operation. If this timeout is reached the test will fail.
        /// </param>
        /// <param name="transferManagerOptions">Options for the transfer manager</param>
        /// <param name="options">Options for the transfer Options</param>
        /// <returns></returns>
        private async Task CopyBlobDirectoryAndVerify(
            BlobContainerClient container,
            string sourceBlobPrefix,
            string sourceFilePrefix,
            string destinationBlobPrefix,
            List<string> sourceFiles,
            int waitTimeInSec = 30,
            TransferManagerOptions transferManagerOptions = default,
            DataTransferOptions options = default)
        {
            // Set transfer options
            options ??= new DataTransferOptions();
            TestEventsRaised testEventFailed = new TestEventsRaised(options);

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure
            };

            // Initialize transferManager
            TransferManager transferManager = new TransferManager(transferManagerOptions);

            StorageResourceContainer sourceResource =
                new BlobStorageResourceContainer(container, new() { BlobDirectoryPrefix = sourceBlobPrefix });
            StorageResourceContainer destinationResource =
                new BlobStorageResourceContainer(container,
                new BlobStorageResourceContainerOptions()
                {
                    BlobDirectoryPrefix = destinationBlobPrefix,
                });

            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);

            // Assert
            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventFailed,
                tokenSource.Token);

            await testEventFailed.AssertContainerCompletedCheck(sourceFiles.Count);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);

            // List all files in source blob folder path
            List<string> sourceblobNames = new List<string>();
            await foreach (Page<BlobItem> page in container.GetBlobsAsync(prefix: sourceBlobPrefix).AsPages())
            {
                sourceblobNames.AddRange(page.Values.Select((BlobItem item) => item.Name));
            }

            // List all files in the destination blob folder path
            List<string> destblobNames = new List<string>();
            await foreach (Page<BlobItem> page in container.GetBlobsAsync(prefix: destinationBlobPrefix).AsPages())
            {
                destblobNames.AddRange(page.Values.Select((BlobItem item) => item.Name));
            }
            Assert.AreEqual(sourceblobNames.Count, destblobNames.Count);
            sourceFiles.Sort();
            sourceblobNames.Sort();
            destblobNames.Sort();
            for (int i = 0; i < sourceFiles.Count; i++)
            {
                // Verify file name to match the
                // (prefix folder path) + (the blob name without the blob folder prefix)
                string sourceNonPrefixed = sourceblobNames[i].Substring(sourceBlobPrefix.Length + 1);
                Assert.AreEqual(
                    sourceNonPrefixed,
                    destblobNames[i].Substring(destinationBlobPrefix.Length+1));

                // Verify Download
                string sourceFileName = Path.Combine(sourceFilePrefix, sourceNonPrefixed);
                using (FileStream fileStream = File.OpenRead(sourceFileName))
                {
                    BlockBlobClient destinationBlob = container.GetBlockBlobClient(destblobNames[i]);
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
        public async Task BlockBlobDirectoryToDirectory_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            string sourceBlobDirectoryName = "sourceFolder";
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string sourceFolderPath = CreateRandomDirectory(testDirectory.DirectoryPath, sourceBlobDirectoryName);

            List<string> blobNames = new List<string>();

            string blobName1 = Path.Combine(sourceBlobDirectoryName, GetNewBlobName());
            string blobName2 = Path.Combine(sourceBlobDirectoryName, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName1, size);
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName2, size);
            blobNames.Add(blobName1);
            blobNames.Add(blobName2);

            string subDirName = "bar";
            CreateRandomDirectory(sourceFolderPath, subDirName).Substring(sourceFolderPath.Length + 1);
            string blobName3 = Path.Combine(sourceBlobDirectoryName, subDirName, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName3, size);
            blobNames.Add(blobName3);

            string subDirName2 = "pik";
            CreateRandomDirectory(sourceFolderPath, subDirName2).Substring(sourceFolderPath.Length + 1);
            string blobName4 = Path.Combine(sourceBlobDirectoryName, subDirName2, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName4, size);
            blobNames.Add(blobName4);

            string destinationFolder = "destFolder";

            await CopyBlobDirectoryAndVerify(
                test.Container,
                sourceBlobDirectoryName,
                sourceFolderPath,
                destinationFolder,
                blobNames,
                waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(4 * Constants.MB, 200)]
        [TestCase(257 * Constants.MB, 500)]
        [TestCase(Constants.GB, 500)]
        public async Task BlockBlobDirectoryToDirectory_LargeSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            string sourceBlobDirectoryName = "sourceFolder";
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string sourceFolderPath = CreateRandomDirectory(testDirectory.DirectoryPath, sourceBlobDirectoryName);

            List<string> blobNames = new List<string>();

            string blobName1 = Path.Combine(sourceBlobDirectoryName, GetNewBlobName());
            string blobName2 = Path.Combine(sourceBlobDirectoryName, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName1, size);
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName2, size);
            blobNames.Add(blobName1);
            blobNames.Add(blobName2);

            string subDirName = "bar";
            CreateRandomDirectory(sourceFolderPath, subDirName).Substring(sourceFolderPath.Length + 1);
            string blobName3 = Path.Combine(sourceBlobDirectoryName, subDirName, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName3, size);
            blobNames.Add(blobName3);

            string subDirName2 = "pik";
            CreateRandomDirectory(sourceFolderPath, subDirName2).Substring(sourceFolderPath.Length + 1);
            string blobName4 = Path.Combine(sourceBlobDirectoryName, subDirName2, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName4, size);
            blobNames.Add(blobName4);

            string destinationFolder = "destFolder";

            await CopyBlobDirectoryAndVerify(
                test.Container,
                sourceBlobDirectoryName,
                sourceFolderPath,
                destinationFolder,
                blobNames,
                waitTimeInSec).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task BlockBlobDirectoryToDirectory_EmptyFolder()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Set up directory to upload
            var dirName = GetNewBlobDirectoryName();
            var dirName2 = GetNewBlobDirectoryName();
            string folder = CreateRandomDirectory(testDirectory.DirectoryPath);

            // Set up destination client
            StorageResourceContainer destinationResource = new BlobStorageResourceContainer(test.Container, new() { BlobDirectoryPrefix = dirName });
            StorageResourceContainer sourceResource = new BlobStorageResourceContainer(test.Container,
                new BlobStorageResourceContainerOptions()
                {
                    BlobDirectoryPrefix = dirName2,
                });

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
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                tokenSource.Token);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);

            // Assert
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();
            // Assert
            Assert.IsEmpty(blobs);
            testEventsRaised.AssertUnexpectedFailureCheck();
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task BlockBlobDirectoryToDirectory_SingleFile()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            string sourceFolderName = "sourceFolder";
            string sourceFolderPath = CreateRandomDirectory(testDirectory.DirectoryPath, sourceFolderName);

            string blobName1 = Path.Combine(sourceFolderName, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName1, Constants.KB);
            List<string> blobNames = new List<string>() { blobName1 };

            string destinationFolder = "destFolder";

            await CopyBlobDirectoryAndVerify(
                container: test.Container,
                sourceBlobPrefix: sourceFolderName,
                sourceFilePrefix: sourceFolderPath,
                destinationBlobPrefix: destinationFolder,
                blobNames).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task BlockBlobDirectoryToDirectory_ManySubDirectories()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            string blobDirectoryName = "sourceFolder";
            string fullSourceFolderPath = CreateRandomDirectory(testDirectory.DirectoryPath, blobDirectoryName);

            List<string> blobNames = new List<string>();
            string subDir1 = CreateRandomDirectory(fullSourceFolderPath, "bar").Substring(fullSourceFolderPath.Length + 1);
            string blobName1 = Path.Combine(blobDirectoryName, subDir1, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName1, Constants.KB);
            blobNames.Add(blobName1);
            string subDir2 = CreateRandomDirectory(fullSourceFolderPath, "rul").Substring(fullSourceFolderPath.Length + 1);
            string blobName2 = Path.Combine(blobDirectoryName, subDir2, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName2, Constants.KB);
            blobNames.Add(blobName2);
            string subDir3 = CreateRandomDirectory(fullSourceFolderPath, "pik").Substring(fullSourceFolderPath.Length + 1);
            string blobName3 = Path.Combine(blobDirectoryName, subDir3, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName3, Constants.KB);
            blobNames.Add(blobName3);

            string destinationFolder = "destFolder";

            string sourceBlobPrefix = fullSourceFolderPath.Substring(testDirectory.DirectoryPath.Length + 1);

            await CopyBlobDirectoryAndVerify(
                container: test.Container,
                sourceBlobPrefix: sourceBlobPrefix,
                sourceFilePrefix: fullSourceFolderPath,
                destinationBlobPrefix: destinationFolder,
                blobNames).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task BlockBlobDirectoryToDirectory_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            string sourceBlobDirectoryName = "sourceFolder";
            string fullSourceFolderPath = CreateRandomDirectory(testDirectory.DirectoryPath, sourceBlobDirectoryName);

            List<string> blobNames = new List<string>();

            string subDir = default;
            for (int i = 0; i < level; i++)
            {
                subDir = CreateRandomDirectory(fullSourceFolderPath, $"folder{i}");
                string blobName = Path.Combine(sourceBlobDirectoryName, subDir.Substring(fullSourceFolderPath.Length + 1), GetNewBlobName());
                await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName, Constants.KB);
                blobNames.Add(blobName);
            }

            string destinationFolder = "destFolder";

            await CopyBlobDirectoryAndVerify(
                test.Container,
                sourceBlobDirectoryName,
                fullSourceFolderPath,
                destinationBlobPrefix: destinationFolder,
                blobNames).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task BlockBlobDirectoryToDirectory_OverwriteTrue()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            long size = Constants.KB;
            string sourceBlobDirectoryName = "sourceFolder";
            string sourceFolderPath = CreateRandomDirectory(testDirectory.DirectoryPath, sourceBlobDirectoryName);

            List<string> blobNames = new List<string>();
            string blobName1 = Path.Combine(sourceBlobDirectoryName, GetNewBlobName());
            string blobName2 = Path.Combine(sourceBlobDirectoryName, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName1, size);
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName2, size);
            blobNames.Add(blobName1);
            blobNames.Add(blobName2);

            string subDirName = "bar";
            CreateRandomDirectory(sourceFolderPath, subDirName).Substring(sourceFolderPath.Length + 1);
            string blobName3 = Path.Combine(sourceBlobDirectoryName, subDirName, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName3, size);
            blobNames.Add(blobName3);

            string subDirName2 = "pik";
            CreateRandomDirectory(sourceFolderPath, subDirName2).Substring(sourceFolderPath.Length + 1);
            string blobName4 = Path.Combine(sourceBlobDirectoryName, subDirName2, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName4, size);
            blobNames.Add(blobName4);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists
            };

            string destinationFolder = "destFolder";

            // Act
            await CopyBlobDirectoryAndVerify(
                test.Container,
                sourceBlobDirectoryName,
                sourceFolderPath,
                destinationBlobPrefix: destinationFolder,
                blobNames,
                options: options).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task BlockBlobDirectoryToDirectory_OverwriteFalse()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            long size = Constants.KB;
            string sourceBlobDirectoryName = "sourceFolder";
            string sourceFolderPath = CreateRandomDirectory(testDirectory.DirectoryPath, sourceBlobDirectoryName);

            List<string> blobNames = new List<string>();
            string blobName1 = Path.Combine(sourceBlobDirectoryName, GetNewBlobName());
            string blobName2 = Path.Combine(sourceBlobDirectoryName, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName1, size);
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName2, size);
            blobNames.Add(blobName1);
            blobNames.Add(blobName2);

            string subDirName = "bar";
            CreateRandomDirectory(sourceFolderPath, subDirName).Substring(sourceFolderPath.Length + 1);
            string blobName3 = Path.Combine(sourceBlobDirectoryName, subDirName, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName3, size);
            blobNames.Add(blobName3);

            string subDirName2 = "pik";
            CreateRandomDirectory(sourceFolderPath, subDirName2).Substring(sourceFolderPath.Length + 1);
            string blobName4 = Path.Combine(sourceBlobDirectoryName, subDirName2, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName4, size);
            blobNames.Add(blobName4);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists
            };

            string destinationFolder = "destFolder";

            // Act
            await CopyBlobDirectoryAndVerify(
                test.Container,
                sourceBlobDirectoryName,
                sourceFolderPath,
                destinationBlobPrefix: destinationFolder,
                blobNames,
                options: options).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task BlockBlobDirectoryToDirectory_OAuth()
        {
            // Arrange
            long size = Constants.KB;
            int waitTimeInSec = 10;
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_OAuth();
            var containerName = GetNewContainerName();
            await using DisposingContainer testContainer = await GetTestContainerAsync(
                service,
                containerName,
                publicAccessType: PublicAccessType.BlobContainer);
            string sourceBlobDirectoryName = "sourceFolder";
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string sourceFolderPath = CreateRandomDirectory(testDirectory.DirectoryPath, sourceBlobDirectoryName);

            List<string> blobNames = new List<string>();

            string blobName1 = Path.Combine(sourceBlobDirectoryName, GetNewBlobName());
            string blobName2 = Path.Combine(sourceBlobDirectoryName, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(testContainer.Container, testDirectory.DirectoryPath, blobName1, size);
            await CreateBlockBlobAndSourceFile(testContainer.Container, testDirectory.DirectoryPath, blobName2, size);
            blobNames.Add(blobName1);
            blobNames.Add(blobName2);

            string subDirName = "bar";
            CreateRandomDirectory(sourceFolderPath, subDirName).Substring(sourceFolderPath.Length + 1);
            string blobName3 = Path.Combine(sourceBlobDirectoryName, subDirName, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(testContainer.Container, testDirectory.DirectoryPath, blobName3, size);
            blobNames.Add(blobName3);

            string subDirName2 = "pik";
            CreateRandomDirectory(sourceFolderPath, subDirName2).Substring(sourceFolderPath.Length + 1);
            string blobName4 = Path.Combine(sourceBlobDirectoryName, subDirName2, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(testContainer.Container, testDirectory.DirectoryPath, blobName4, size);
            blobNames.Add(blobName4);

            string destinationFolder = "destFolder";

            await CopyBlobDirectoryAndVerify(
                testContainer.Container,
                sourceBlobDirectoryName,
                sourceFolderPath,
                destinationFolder,
                blobNames,
                waitTimeInSec).ConfigureAwait(false);
        }

        #region Single Concurrency
        private async Task CreateBlobDirectoryTree(
            BlobContainerClient client,
            string sourceFolderPath,
            string sourceBlobDirectoryName,
            int size)
        {
            string blobName1 = Path.Combine(sourceBlobDirectoryName, "blob1");
            string blobName2 = Path.Combine(sourceBlobDirectoryName, "blob2");
            await CreateBlockBlob(client, Path.GetTempFileName(), blobName1, size);
            await CreateBlockBlob(client, Path.GetTempFileName(), blobName2, size);

            string subDirName = "bar";
            CreateRandomDirectory(sourceFolderPath, subDirName).Substring(sourceFolderPath.Length + 1);
            string blobName3 = Path.Combine(sourceBlobDirectoryName, subDirName, "blob3");
            await CreateBlockBlob(client, Path.GetTempFileName(), blobName3, size);

            string subDirName2 = "pik";
            CreateRandomDirectory(sourceFolderPath, subDirName2).Substring(sourceFolderPath.Length + 1);
            string blobName4 = Path.Combine(sourceBlobDirectoryName, subDirName2, "blob4");
            await CreateBlockBlob(client, Path.GetTempFileName(), blobName4, size);
        }

        private async Task<DataTransfer> CreateStartTransfer(
            BlobContainerClient containerClient,
            int concurrency,
            bool createFailedCondition = false,
            DataTransferOptions options = default,
            int size = Constants.KB)
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            // Arrange
            // Create source local file for checking, and source blob
            string sourceBlobPrefix = "sourceFolder";
            string destBlobPrefix = "destFolder";
            string sourceFolderPath = CreateRandomDirectory(testDirectory.DirectoryPath, sourceBlobPrefix);
            await CreateBlobDirectoryTree(containerClient, sourceFolderPath, sourceBlobPrefix, size);

            // Create new source block blob.
            StorageResourceContainer sourceResource = new BlobStorageResourceContainer(containerClient, new() { BlobDirectoryPrefix = sourceBlobPrefix });
            StorageResourceContainer destinationResource = new BlobStorageResourceContainer(containerClient,
                new BlobStorageResourceContainerOptions()
                {
                    BlobDirectoryPrefix = destBlobPrefix,
                });

            // If we want a failure condition to happen
            if (createFailedCondition)
            {
                string destBlobName = $"{destBlobPrefix}/blob1";
                await CreateBlockBlob(containerClient, Path.Combine(testDirectory.DirectoryPath, "blob1"), destBlobName, size);
            }

            // Create Transfer Manager with single threaded operation
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                MaximumConcurrency = concurrency,
            };
            TransferManager transferManager = new TransferManager(managerOptions);

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

            // Create transfer to do a AwaitCompletion
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            DataTransfer transfer = await CreateStartTransfer(test.Container, 1, options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
            await testEventsRaised.AssertContainerCompletedWithSkippedCheck(1);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            // Create transfer to do a EnsureCompleted
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            DataTransfer transfer = await CreateStartTransfer(test.Container, 1, options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            TestTransferWithTimeout.WaitForCompletion(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            TestTransferWithTimeout.WaitForCompletion(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Skipped()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a EnsureCompleted
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            TestTransferWithTimeout.WaitForCompletion(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
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
                test.Container,
                1,
                createFailedCondition: true,
                options: options,
                size: Constants.KB * 4);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            TestTransferWithTimeout.WaitForCompletion(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
        }
        #endregion
    }
}
