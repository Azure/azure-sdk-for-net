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
using Azure.Storage.Blobs.Tests;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferDownloadDirectoryTests : DataMovementBlobTestBase
    {
        public StartTransferDownloadDirectoryTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        #region DirectoryDownloadTests
        /// <summary>
        /// Upload and verify the contents of the blob
        ///
        /// By default in this function an event argument will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        /// <param name="sourceContainer">The source container which will contains the source blobs</param>
        /// <param name="sourceBlobPrefix">The source blob prefix/folder</param>
        /// <param name="sourceFilePrefix">The local source file prefix to join together with the source prefixes below.</param>
        /// <param name="sourceFiles">The source file paths relative to the sourceFilePrefix</param>
        /// <param name="destinationLocalPath">The destination local path to download the blobs to</param>
        /// <param name="waitTimeInSec">
        /// How long we should wait until we cancel the operation. If this timeout is reached the test will fail.
        /// </param>
        /// <param name="transferManagerOptions">Options for the transfer manager</param>
        /// <param name="options">Options for the transfer Options</param>
        /// <returns></returns>
        private async Task DownloadBlobDirectoryAndVerify(
            BlobContainerClient sourceContainer,
            string sourceBlobPrefix,
            string sourceFilePrefix,
            List<string> sourceFiles,
            string destinationLocalPath,
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

            // Initialize transferManager
            TransferManager transferManager = new TransferManager(transferManagerOptions);

            StorageResourceContainer sourceResource =
                new BlobStorageResourceContainer(sourceContainer, new() { BlobDirectoryPrefix = sourceBlobPrefix });
            StorageResourceContainer destinationResource =
                new LocalDirectoryStorageResourceContainer(destinationLocalPath);

            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);

            // Assert
            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            await testEventsRaised.AssertContainerCompletedCheck(sourceFiles.Count);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.Completed, transfer.TransferStatus);

            // List all files in source blob folder path
            List<string> blobNames = new List<string>();
            await foreach (Page<BlobItem> page in sourceContainer.GetBlobsAsync(prefix: sourceBlobPrefix).AsPages())
            {
                blobNames.AddRange(page.Values.Select((BlobItem item) => item.Name));
            }

            // List all files in the destination local path
            List<string> destinationFiles = FileUtil.ListFileNamesRecursive(destinationLocalPath);
            Assert.AreEqual(destinationFiles.Count, sourceFiles.Count);
            destinationFiles.Sort();
            sourceFiles.Sort();
            blobNames.Sort();
            for (int i = 0; i < destinationFiles.Count; i++)
            {
                // Verify file name to match the
                // (prefix folder path) + (the blob name without the blob folder prefix)
                string destinationName = destinationFiles[i].Substring(destinationLocalPath.Length + 1);
                string sourceBlobNameNoPrefix = blobNames[i].Substring(sourceBlobPrefix.Length + 1);
                Assert.AreEqual(destinationName.Replace('\\', '/'), sourceBlobNameNoPrefix);

                // Verify Download
                string fullSourcePath = Path.Combine(sourceFilePrefix, sourceBlobNameNoPrefix);
                CheckDownloadFile(fullSourcePath, destinationFiles[i]);
            }
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(0, 10)]
        [TestCase(100, 10)]
        [TestCase(Constants.KB, 10)]
        public async Task DownloadDirectoryAsync_Small(int size, int waitInSec)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string sourceBlobDirectoryName = "foo";
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

            string destinationFolder = CreateRandomDirectory(Path.GetTempPath());

            await DownloadBlobDirectoryAndVerify(
                test.Container,
                sourceBlobDirectoryName,
                sourceFolderPath,
                blobNames,
                destinationFolder,
                waitInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 500)]
        [TestCase(400 * Constants.MB, 200)]
        [TestCase(Constants.GB, 500)]
        public async Task DownloadDirectoryAsync_Large(int size, int waitInSec)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string sourceBlobDirectoryName = "foo";
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

            string destinationFolder = CreateRandomDirectory(Path.GetTempPath());

            await DownloadBlobDirectoryAndVerify(
                test.Container,
                sourceBlobDirectoryName,
                sourceFolderPath,
                blobNames,
                destinationFolder,
                waitInSec).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DownloadDirectoryAsync_Empty()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string sourceBlobDirectoryName = "foo";
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            // Initialize transferManager
            TransferManager transferManager = new TransferManager();
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventRaised = new TestEventsRaised(options);

            StorageResourceContainer sourceResource =
                new BlobStorageResourceContainer(test.Container, new() { BlobDirectoryPrefix = sourceBlobDirectoryName });
            StorageResourceContainer destinationResource =
                new LocalDirectoryStorageResourceContainer(destinationFolder);

            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token);

            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.Completed, transfer.TransferStatus);

            List<string> localItemsAfterDownload = Directory.GetFiles(destinationFolder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.IsEmpty(localItemsAfterDownload);
            testEventRaised.AssertUnexpectedFailureCheck();
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DownloadDirectoryAsync_SingleFile()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string tempFolder = CreateRandomDirectory(testDirectory.DirectoryPath);
            string sourceFolderPath = CreateRandomDirectory(tempFolder);

            string sourceBlobDirectoryName = sourceFolderPath.Substring(tempFolder.Length + 1);
            string blobName1 = Path.Combine(sourceBlobDirectoryName, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName1, Constants.KB);
            List<string> blobNames = new List<string>() { blobName1 };

            string destinationFolder = CreateRandomDirectory(sourceFolderPath);

            await DownloadBlobDirectoryAndVerify(
                test.Container,
                sourceBlobDirectoryName,
                sourceFolderPath,
                blobNames,
                destinationFolder).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DownloadDirectoryAsync_ManySubDirectories()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string tempFolder = CreateRandomDirectory(testDirectory.DirectoryPath);
            string blobDirectoryName = "foo";
            string fullSourceFolderPath = CreateRandomDirectory(tempFolder, blobDirectoryName);

            List<string> blobNames = new List<string>();
            string subDir1 = CreateRandomDirectory(fullSourceFolderPath, "bar").Substring(fullSourceFolderPath.Length + 1);
            string blobName1 = Path.Combine(blobDirectoryName, subDir1, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName1, Constants.KB);
            blobNames.Add(blobName1);
            string subDir2 = CreateRandomDirectory(fullSourceFolderPath, "rul").Substring(fullSourceFolderPath.Length + 1);
            string blobName2 = Path.Combine(blobDirectoryName, subDir2, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName2, Constants.KB);
            blobNames.Add(blobName2);
            string subDir3 = CreateRandomDirectory(fullSourceFolderPath, "pik").Substring(fullSourceFolderPath.Length + 1);
            string blobName3 = Path.Combine(blobDirectoryName, subDir3, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName3, Constants.KB);
            blobNames.Add(blobName3);

            string destinationFolder = CreateRandomDirectory(Path.GetTempPath());

            string sourceBlobPrefix = fullSourceFolderPath.Substring(tempFolder.Length + 1);

            await DownloadBlobDirectoryAndVerify(
                sourceContainer: test.Container,
                sourceBlobPrefix: sourceBlobPrefix,
                sourceFilePrefix: fullSourceFolderPath,
                blobNames,
                destinationFolder).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task DownloadDirectoryAsync_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string tempFolder = CreateRandomDirectory(testDirectory.DirectoryPath);
            string sourceBlobDirectoryName = "foo";
            string fullPath = CreateRandomDirectory(tempFolder, sourceBlobDirectoryName);

            List<string> blobNames = new List<string>();

            string subDir = default;
            for (int i = 0; i < level; i++)
            {
                subDir = CreateRandomDirectory(fullPath, $"folder{i}");
                string blobName = Path.Combine(sourceBlobDirectoryName, subDir.Substring(fullPath.Length + 1), GetNewBlobName());
                await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName, Constants.KB);
                blobNames.Add(blobName);
            }

            string destinationFolder = CreateRandomDirectory(Path.GetTempPath());

            await DownloadBlobDirectoryAndVerify(
                test.Container,
                sourceBlobDirectoryName,
                fullPath,
                blobNames,
                destinationFolder).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DownloadDirectoryAsync_SmallChunks_ManyFiles()
        {
            // Arrange
            int blobSize = 2 * Constants.KB;
            await using DisposingContainer test = await GetTestContainerAsync();

            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string tempFolder = CreateRandomDirectory(testDirectory.DirectoryPath);
            string blobDirectoryName = "foo";
            string fullSourceFolderPath = CreateRandomDirectory(tempFolder, blobDirectoryName);

            List<string> blobNames = new List<string>();
            string blobName = Path.Combine(blobDirectoryName, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName, blobSize);
            blobNames.Add(blobName);
            blobName = Path.Combine(blobDirectoryName, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName, blobSize);
            blobNames.Add(blobName);
            blobName = Path.Combine(blobDirectoryName, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName, blobSize);
            blobNames.Add(blobName);
            blobName = Path.Combine(blobDirectoryName, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName, blobSize);
            blobNames.Add(blobName);
            blobName = Path.Combine(blobDirectoryName, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName, blobSize);
            blobNames.Add(blobName);

            string subDir1 = CreateRandomDirectory(fullSourceFolderPath, "bar").Substring(fullSourceFolderPath.Length + 1);
            blobName = Path.Combine(blobDirectoryName, subDir1, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName, blobSize);
            blobNames.Add(blobName);
            blobName = Path.Combine(blobDirectoryName, subDir1, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName, blobSize);
            blobNames.Add(blobName);
            blobName = Path.Combine(blobDirectoryName, subDir1, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName, blobSize);
            blobNames.Add(blobName);
            string subDir2 = CreateRandomDirectory(fullSourceFolderPath, "rul").Substring(fullSourceFolderPath.Length + 1);
            blobName = Path.Combine(blobDirectoryName, subDir2, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName, blobSize);
            blobNames.Add(blobName);
            blobName = Path.Combine(blobDirectoryName, subDir2, GetNewBlobName());
            await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName, blobSize);
            blobNames.Add(blobName);

            using DisposingLocalDirectory destinationFolder = DisposingLocalDirectory.GetTestDirectory();
            string sourceBlobPrefix = fullSourceFolderPath.Substring(tempFolder.Length + 1);

            TransferManagerOptions transferManagerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.StopOnAnyFailure,
                MaximumConcurrency = 3
            };
            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512
            };

            // Act / Assert
            await DownloadBlobDirectoryAndVerify(
                sourceContainer: test.Container,
                sourceBlobPrefix: sourceBlobPrefix,
                sourceFilePrefix: fullSourceFolderPath,
                blobNames,
                destinationFolder.DirectoryPath,
                transferManagerOptions: transferManagerOptions,
                options: options).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DownloadDirectoryAsync_Root()
        {
            // Arrange
            string[] files = { "file1", "dir1/file1", "dir1/file2", "dir1/file3", "dir2/file1" };
            BinaryData data = BinaryData.FromString("Hello World");

            await using DisposingContainer source = await GetTestContainerAsync();
            using DisposingLocalDirectory destination = DisposingLocalDirectory.GetTestDirectory();

            foreach (string file in files)
            {
                await source.Container.UploadBlobAsync(file, data);
            }

            TransferManager transferManager = new TransferManager();

            StorageResourceContainer sourceResource =
                new BlobStorageResourceContainer(source.Container);
            StorageResourceContainer destinationResource =
                new LocalDirectoryStorageResourceContainer(destination.DirectoryPath);

            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource);

            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            IEnumerable<string> destinationFiles = FileUtil.ListFileNamesRecursive(destination.DirectoryPath)
                .Select(f => f.Substring(destination.DirectoryPath.Length + 1).Replace("\\", "/"));

            Assert.IsTrue(destinationFiles.OrderBy(f => f).SequenceEqual(files.OrderBy(f => f)));
        }
        #endregion DirectoryDownloadTests

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
            string destinationFolder,
            int concurrency,
            DataTransferOptions options = default,
            int size = Constants.KB)
        {
            // Arrange
            string sourceBlobPrefix = "sourceFolder";
            string sourceFolderPath = CreateRandomDirectory(Path.GetTempPath(), sourceBlobPrefix);
            await CreateBlobDirectoryTree(containerClient, sourceFolderPath, sourceBlobPrefix, size);

            // Create storage resources
            StorageResourceContainer sourceResource = new BlobStorageResourceContainer(containerClient, new() { BlobDirectoryPrefix = sourceBlobPrefix });
            StorageResourceContainer destinationResource = new LocalDirectoryStorageResourceContainer(destinationFolder);

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
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            // Create transfer to do a AwaitCompletion
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                destinationFolder,
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
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create at least one of the dest files to make it fail
            File.Create(Path.Combine(destinationFolder, "blob1")).Close();

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                destinationFolder,
                1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("Cannot overwrite file."));
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create at least one of the dest files to make it fail
            File.Create(Path.Combine(destinationFolder, "blob1")).Dispose();

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                destinationFolder,
                1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
            await testEventsRaised.AssertContainerCompletedWithSkippedCheck(1);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            // Create transfer to do a EnsureCompleted
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            DataTransfer transfer = await CreateStartTransfer(
                    test.Container,
                    destinationFolder,
                    1,
                    options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.Completed, transfer.TransferStatus);
            await testEventsRaised.AssertContainerCompletedCheck(4);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create at least one of the dest files to make it fail
            File.Create(Path.Combine(destinationFolder, "blob1")).Close();

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                destinationFolder,
                1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("Cannot overwrite file."));
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Skipped()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create at least one of the dest files to make it fail
            File.Create(Path.Combine(destinationFolder, "blob1")).Close();

            // Create transfer to do a EnsureCompleted
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                destinationFolder,
                1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
            await testEventsRaised.AssertContainerCompletedWithSkippedCheck(1);
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

            // Create at least one of the dest files to make it fail
            File.Create(Path.Combine(destinationFolder, "blob1")).Close();

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                destinationFolder,
                1,
                options: options,
                size: Constants.KB * 4);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("Cannot overwrite file."));
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
        }
        #endregion
    }
}
