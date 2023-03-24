// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;
using System.IO;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Options;

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
        /// By default in this function an event arguement will be added to the options event handler
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
            int waitTimeInSec = 10,
            TransferManagerOptions transferManagerOptions = default,
            ContainerTransferOptions options = default)
        {
            // Set transfer options
            options ??= new ContainerTransferOptions();

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };

            // Initialize transferManager
            TransferManager transferManager = new TransferManager(transferManagerOptions);

            StorageResourceContainer sourceResource =
                new BlobDirectoryStorageResourceContainer(sourceContainer, sourceBlobPrefix);
            StorageResourceContainer destinationResource =
                new LocalDirectoryStorageResourceContainer(destinationLocalPath);

            Exception exception = default;
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    // If we call Assert.Fail here it will throw an exception within the
                    // event handler and take down everything with it.
                    //Assert.Fail(args.Exception.Message);
                    exception = args.Exception;
                }
                return Task.CompletedTask;
            };
            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);

            // Assert
            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
            await transfer.AwaitCompletion(tokenSource.Token);

            if (exception != default)
            {
                Assert.Fail(exception.StackTrace);
            }
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.Completed, transfer.TransferStatus);

            // List all files in source blob folder path
            List<string> blobNames = new List<string>();
            await foreach (Page<BlobItem> page in sourceContainer.GetBlobsAsync(prefix: sourceBlobPrefix).AsPages())
            {
                blobNames.AddRange(page.Values.Select((BlobItem item) => item.Name));
            }

            // List all files in the destination local path
            List<string> destinationFiles = ListFilesInDirectory(destinationLocalPath);
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
                Assert.AreEqual(destinationName, sourceBlobNameNoPrefix.Replace("/", "\\"));

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
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            string sourceBlobDirectoryName = "foo";
            string tempFolder = Path.GetTempPath();
            string sourceFolderPath = CreateRandomDirectory(tempFolder, sourceBlobDirectoryName);

            try
            {
                List<string> blobNames = new List<string>();

                string blobName1 = Path.Combine(sourceBlobDirectoryName, GetNewBlobName());
                string blobName2 = Path.Combine(sourceBlobDirectoryName, GetNewBlobName());
                await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName1, size);
                await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName2, size);
                blobNames.Add(blobName1);
                blobNames.Add(blobName2);

                string subDirName = "bar";
                CreateRandomDirectory(sourceFolderPath, subDirName).Substring(sourceFolderPath.Length + 1);
                string blobName3 = Path.Combine(sourceBlobDirectoryName, subDirName, GetNewBlobName());
                await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName3, size);
                blobNames.Add(blobName3);

                string subDirName2 = "pik";
                CreateRandomDirectory(sourceFolderPath, subDirName2).Substring(sourceFolderPath.Length + 1);
                string blobName4 = Path.Combine(sourceBlobDirectoryName, subDirName2, GetNewBlobName());
                await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName4, size);
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
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                Directory.Delete(sourceFolderPath, true);
            }
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
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            string sourceBlobDirectoryName = "foo";
            string tempFolder = Path.GetTempPath();
            string sourceFolderPath = CreateRandomDirectory(tempFolder, sourceBlobDirectoryName);

            try
            {
                List<string> blobNames = new List<string>();

                string blobName1 = Path.Combine(sourceBlobDirectoryName, GetNewBlobName());
                string blobName2 = Path.Combine(sourceBlobDirectoryName, GetNewBlobName());
                await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName1, size);
                await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName2, size);
                blobNames.Add(blobName1);
                blobNames.Add(blobName2);

                string subDirName = "bar";
                CreateRandomDirectory(sourceFolderPath, subDirName).Substring(sourceFolderPath.Length + 1);
                string blobName3 = Path.Combine(sourceBlobDirectoryName, subDirName, GetNewBlobName());
                await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName3, size);
                blobNames.Add(blobName3);

                string subDirName2 = "pik";
                CreateRandomDirectory(sourceFolderPath, subDirName2).Substring(sourceFolderPath.Length + 1);
                string blobName4 = Path.Combine(sourceBlobDirectoryName, subDirName2, GetNewBlobName());
                await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName4, size);
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
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                Directory.Delete(sourceFolderPath, true);
            }
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DownloadDirectoryAsync_Empty()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            string tempFolder = CreateRandomDirectory(Path.GetTempPath());
            string sourceFolderPath = CreateRandomDirectory(tempFolder);
            try
            {
                string sourceBlobDirectoryName = sourceFolderPath.Substring(tempFolder.Length + 1);
                string folder = CreateRandomDirectory(Path.GetTempPath());

                // Initialize transferManager
                TransferManager transferManager = new TransferManager();

                StorageResourceContainer sourceResource =
                    new BlobDirectoryStorageResourceContainer(test.Container, sourceBlobDirectoryName);
                StorageResourceContainer destinationResource =
                    new LocalDirectoryStorageResourceContainer(folder);

                DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource);
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
                await transfer.AwaitCompletion(cancellationTokenSource.Token);

                Assert.IsTrue(transfer.HasCompleted);
                Assert.AreEqual(StorageTransferStatus.Completed, transfer.TransferStatus);

                List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

                // Assert
                Assert.IsEmpty(localItemsAfterDownload);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                Directory.Delete(sourceFolderPath, true);
            }
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DownloadDirectoryAsync_SingleFile()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string tempFolder = CreateRandomDirectory(Path.GetTempPath());
            string sourceFolderPath = CreateRandomDirectory(tempFolder);
            try
            {
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
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                Directory.Delete(sourceFolderPath, true);
            }
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DownloadDirectoryAsync_ManySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string tempFolder = CreateRandomDirectory(Path.GetTempPath());
            string blobDirectoryName = "foo";
            string fullSourceFolderPath = CreateRandomDirectory(tempFolder, blobDirectoryName);
            try
            {
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
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                Directory.Delete(fullSourceFolderPath, true);
            }
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task DownloadDirectoryAsync_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string tempFolder = Path.GetTempPath();
            string sourceBlobDirectoryName = "foo";
            string fullPath = CreateRandomDirectory(tempFolder, sourceBlobDirectoryName);
            try
            {
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
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                Directory.Delete(fullPath, true);
            }
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
            ContainerTransferOptions options = default,
            int size = Constants.KB)
        {
            // Arrange
            string sourceBlobPrefix = "sourceFolder";
            string sourceFolderPath = CreateRandomDirectory(Path.GetTempPath(), sourceBlobPrefix);
            await CreateBlobDirectoryTree(containerClient, sourceFolderPath, sourceBlobPrefix, size);

            // Create storage resources
            StorageResourceContainer sourceResource = new BlobDirectoryStorageResourceContainer(containerClient, sourceBlobPrefix);
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
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            string destinationFolder = CreateRandomDirectory(Path.GetTempPath());

            try
            {
                // Create transfer to do a AwaitCompletion
                DataTransfer transfer = await CreateStartTransfer(
                    test.Container,
                    destinationFolder,
                    1);

                // Act
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                await transfer.AwaitCompletion(cancellationTokenSource.Token).ConfigureAwait(false);

                // Assert
                Assert.NotNull(transfer);
                Assert.IsTrue(transfer.HasCompleted);
                Assert.AreEqual(StorageTransferStatus.Completed, transfer.TransferStatus);
            }
            finally
            {
                Directory.Delete(destinationFolder, true);
            }
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion_Failed()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            string destinationFolder = CreateRandomDirectory(Path.GetTempPath());

            try
            {
                ContainerTransferOptions options = new ContainerTransferOptions()
                {
                    CreateMode = StorageResourceCreateMode.Fail
                };

                // Create at least one of the dest files to make it fail
                File.Create(Path.Combine(destinationFolder, "blob1")).Close();

                // Create transfer to do a AwaitCompletion
                DataTransfer transfer = await CreateStartTransfer(
                    test.Container,
                    destinationFolder,
                    1,
                    options: options);

                // Act
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                await transfer.AwaitCompletion(cancellationTokenSource.Token).ConfigureAwait(false);

                // Assert
                Assert.NotNull(transfer);
                Assert.IsTrue(transfer.HasCompleted);
                Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            }
            finally
            {
                Directory.Delete(destinationFolder, true);
            }
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            string destinationFolder = CreateRandomDirectory(Path.GetTempPath());

            try
            {
                // Create transfer options with Skipping available
                ContainerTransferOptions options = new ContainerTransferOptions()
                {
                    CreateMode = StorageResourceCreateMode.Skip
                };

                // Create at least one of the dest files to make it fail
                File.Create(Path.Combine(destinationFolder, "blob1")).Close();

                // Create transfer to do a AwaitCompletion
                DataTransfer transfer = await CreateStartTransfer(
                    test.Container,
                    destinationFolder,
                    1,
                    options: options);

                // Act
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                await transfer.AwaitCompletion(cancellationTokenSource.Token).ConfigureAwait(false);

                // Assert
                Assert.NotNull(transfer);
                Assert.IsTrue(transfer.HasCompleted);
                Assert.AreEqual(StorageTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
            }
            finally
            {
                Directory.Delete(destinationFolder, true);
            }
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            string destinationFolder = CreateRandomDirectory(Path.GetTempPath());

            try
            {
                // Create transfer to do a EnsureCompleted
                DataTransfer transfer = await CreateStartTransfer(
                        test.Container,
                        destinationFolder,
                        1);

                // Act
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                transfer.EnsureCompleted(cancellationTokenSource.Token);

                // Assert
                Assert.NotNull(transfer);
                Assert.IsTrue(transfer.HasCompleted);
                Assert.AreEqual(StorageTransferStatus.Completed, transfer.TransferStatus);
            }
            finally
            {
                Directory.Delete(destinationFolder, true);
            }
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Failed()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            string destinationFolder = CreateRandomDirectory(Path.GetTempPath());

            try
            {
                ContainerTransferOptions options = new ContainerTransferOptions()
                {
                    CreateMode = StorageResourceCreateMode.Fail
                };

                // Create at least one of the dest files to make it fail
                File.Create(Path.Combine(destinationFolder, "blob1")).Close();

                // Create transfer to do a AwaitCompletion
                DataTransfer transfer = await CreateStartTransfer(
                    test.Container,
                    destinationFolder,
                    1,
                    options: options);

                // Act
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                transfer.EnsureCompleted(cancellationTokenSource.Token);

                // Assert
                Assert.NotNull(transfer);
                Assert.IsTrue(transfer.HasCompleted);
                Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            }
            finally
            {
                Directory.Delete(destinationFolder, true);
            }
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Skipped()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            string destinationFolder = CreateRandomDirectory(Path.GetTempPath());

            try
            {
                // Create transfer options with Skipping available
                ContainerTransferOptions options = new ContainerTransferOptions()
                {
                    CreateMode = StorageResourceCreateMode.Skip
                };

                // Create at least one of the dest files to make it fail
                File.Create(Path.Combine(destinationFolder, "blob1")).Close();

                // Create transfer to do a EnsureCompleted
                DataTransfer transfer = await CreateStartTransfer(
                    test.Container,
                    destinationFolder,
                    1,
                    options: options);

                // Act
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                transfer.EnsureCompleted(cancellationTokenSource.Token);

                // Assert
                Assert.NotNull(transfer);
                Assert.IsTrue(transfer.HasCompleted);
                Assert.AreEqual(StorageTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
            }
            finally
            {
                Directory.Delete(destinationFolder, true);
            }
        }
        #endregion
    }
}
