// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.DataMovement.Models;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferAsyncCopyDirectoryTests : DataMovementBlobTestBase
    {
        public StartTransferAsyncCopyDirectoryTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
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
            int waitTimeInSec = 10,
            TransferManagerOptions transferManagerOptions = default,
            TransferOptions options = default)
        {
            // Set transfer options
            options ??= new TransferOptions();
            TestEventsRaised testEventRaised = new TestEventsRaised(options);

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };

            // Initialize transferManager
            TransferManager transferManager = new TransferManager(transferManagerOptions);

            StorageResourceContainer sourceResource =
                new BlobStorageResourceContainer(container, new() { DirectoryPrefix = sourceBlobPrefix });
            StorageResourceContainer destinationResource =
                new BlobStorageResourceContainer(container,
                new BlobStorageResourceContainerOptions()
                {
                    DirectoryPrefix = destinationBlobPrefix,
                    ResourceOptions = new BlobStorageResourceOptions()
                    {
                        CopyMethod = TransferCopyMethod.AsyncCopy
                    },
                });

            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);

            // Assert
            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
            await transfer.AwaitCompletion(tokenSource.Token);

            await testEventRaised.AssertContainerCompletedCheck(sourceFiles.Count);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.Completed, transfer.TransferStatus);

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

            // Assert
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
                    destblobNames[i].Substring(destinationBlobPrefix.Length + 1));

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
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
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
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
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
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            // Set up directory to upload
            var dirName = GetNewBlobDirectoryName();
            var dirName2 = GetNewBlobDirectoryName();

            // Set up destination client
            StorageResourceContainer destinationResource = new BlobStorageResourceContainer(test.Container, new() { DirectoryPrefix = dirName });
            StorageResourceContainer sourceResource = new BlobStorageResourceContainer(test.Container, new() { DirectoryPrefix = dirName2 });

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager transferManager = new TransferManager(managerOptions);
            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Act
            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource);

            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(tokenSource.Token);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.Completed, transfer.TransferStatus);

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
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

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
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

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
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string sourceBlobDirectoryName = "sourceFolder";
            string fullPath = CreateRandomDirectory(testDirectory.DirectoryPath, sourceBlobDirectoryName);

            List<string> blobNames = new List<string>();

            string subDir = default;
            for (int i = 0; i < level; i++)
            {
                subDir = CreateRandomDirectory(fullPath, $"folder{i}");
                string blobName = Path.Combine(sourceBlobDirectoryName, subDir.Substring(fullPath.Length + 1), GetNewBlobName());
                await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName, Constants.KB);
                blobNames.Add(blobName);
            }

            string destinationFolder = "destFolder";

            await CopyBlobDirectoryAndVerify(
                test.Container,
                sourceBlobDirectoryName,
                fullPath,
                destinationBlobPrefix: destinationFolder,
                blobNames).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task BlockBlobDirectoryToDirectory_OverwriteTrue()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
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

            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite
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
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
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

            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite
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
        public async Task BlockBlobDirectoryToDirectory_Root()
        {
            // Arrange
            string[] files = { "file1", "dir1/file1", "dir1/file2", "dir1/file3", "dir2/file1" };
            BinaryData data = BinaryData.FromString("Hello World");

            await using DisposingBlobContainer source = await GetTestContainerAsync();
            await using DisposingBlobContainer destination = await GetTestContainerAsync();

            foreach (string file in files)
            {
                await source.Container.UploadBlobAsync(file, data);
            }

            TransferManager transferManager = new TransferManager();

            StorageResourceContainer sourceResource =
                new BlobStorageResourceContainer(source.Container);
            StorageResourceContainer destinationResource = new BlobStorageResourceContainer(
                destination.Container,
                new BlobStorageResourceContainerOptions()
                {
                    ResourceOptions = new BlobStorageResourceOptions()
                    {
                        CopyMethod = TransferCopyMethod.AsyncCopy
                    },
                });

            // Act
            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource);

            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(tokenSource.Token);

            // Assert
            Assert.AreEqual(StorageTransferStatus.Completed, transfer.TransferStatus);

            IEnumerable<string> destinationFiles =
                (await destination.Container.GetBlobsAsync().ToEnumerableAsync()).Select(b => b.Name);

            Assert.IsTrue(destinationFiles.OrderBy(f => f).SequenceEqual(files.OrderBy(f => f)));
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
            TransferOptions options = default,
            int size = Constants.KB)
        {
            // Arrange
            // Create source local file for checking, and source blob
            string sourceBlobPrefix = "sourceFolder";
            string destBlobPrefix = "destFolder";
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string sourceFolderPath = CreateRandomDirectory(testDirectory.DirectoryPath, sourceBlobPrefix);
            await CreateBlobDirectoryTree(containerClient, sourceFolderPath, sourceBlobPrefix, size);

            // Create new source block blob.
            StorageResourceContainer sourceResource = new BlobStorageResourceContainer(containerClient, new() { DirectoryPrefix = sourceBlobPrefix });
            StorageResourceContainer destinationResource = new BlobStorageResourceContainer(
                containerClient,
                new BlobStorageResourceContainerOptions()
                {
                    DirectoryPrefix = destBlobPrefix,
                    ResourceOptions = new BlobStorageResourceOptions()
                    {
                        CopyMethod = TransferCopyMethod.AsyncCopy
                    },
                });

            // If we want a failure condition to happen
            if (createFailedCondition)
            {
                await CreateBlockBlob(containerClient, Path.GetTempFileName(), $"{destBlobPrefix}/blob1", size);
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
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            // Create transfer to do a AwaitCompletion
            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventRaised = new TestEventsRaised(options);
            DataTransfer transfer = await CreateStartTransfer(test.Container, 1, options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await transfer.AwaitCompletion(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.Completed, transfer.TransferStatus);
            await testEventRaised.AssertContainerCompletedCheck(4);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion_Failed()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail
            };
            TestEventsRaised testEventRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await transfer.AwaitCompletion(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            Assert.IsTrue(testEventRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
            await testEventRaised.AssertContainerCompletedWithFailedCheck(1);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            // Create transfer options with Skipping available
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip
            };
            TestEventsRaised testEventRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await transfer.AwaitCompletion(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
            await testEventRaised.AssertContainerCompletedWithSkippedCheck(1);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            // Create transfer to do a EnsureCompleted
            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventRaised = new TestEventsRaised(options);
            DataTransfer transfer = await CreateStartTransfer(test.Container, 1, options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            transfer.EnsureCompleted(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.Completed, transfer.TransferStatus);
            await testEventRaised.AssertContainerCompletedCheck(4);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Failed()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail
            };
            TestEventsRaised testEventRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            transfer.EnsureCompleted(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            Assert.IsTrue(testEventRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
            await testEventRaised.AssertContainerCompletedWithFailedCheck(1);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Skipped()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            // Create transfer options with Skipping available
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip
            };
            TestEventsRaised testEventRaised = new TestEventsRaised(options);

            // Create transfer to do a EnsureCompleted
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            transfer.EnsureCompleted(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
            await testEventRaised.AssertContainerCompletedWithSkippedCheck(1);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Failed_SmallChunks()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512
            };
            TestEventsRaised testEventRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                1,
                createFailedCondition: true,
                options: options,
                size: Constants.KB * 4);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            transfer.EnsureCompleted(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            Assert.IsTrue(testEventRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
            await testEventRaised.AssertContainerCompletedWithFailedCheck(1);
        }
        #endregion
    }
}
