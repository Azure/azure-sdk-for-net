// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
    public class StartTransferSyncCopyDirectoryTests : DataMovementBlobTestBase
    {
        public StartTransferSyncCopyDirectoryTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        /// <summary>
        /// Upload and verify the contents of the blob
        ///
        /// By default in this function an event arguement will be added to the options event handler
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
                new BlobDirectoryStorageResourceContainer(container, sourceBlobPrefix);
            StorageResourceContainer destinationResource =
                new BlobDirectoryStorageResourceContainer(container, destinationBlobPrefix,
                new BlobStorageResourceContainerOptions()
                {
                    CopyMethod = TransferCopyMethod.AsyncCopy,
                });

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
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.Completed, transfer.TransferStatus);

            if (exception != default)
            {
                Assert.Fail(exception.StackTrace);
            }
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

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33082")]
        [Test]
        [LiveOnly]
        [TestCase(0, 10)]
        [TestCase(100, 10)]
        [TestCase(Constants.KB, 10)]
        public async Task BlockBlobDirectoryToDirectory_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            string sourceBlobDirectoryName = "sourceFolder";
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

                string destinationFolder = "destFolder";

                await CopyBlobDirectoryAndVerify(
                    test.Container,
                    sourceBlobDirectoryName,
                    sourceFolderPath,
                    destinationFolder,
                    blobNames,
                    waitTimeInSec).ConfigureAwait(false);
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
        [TestCase(4 * Constants.MB, 200)]
        [TestCase(257 * Constants.MB, 500)]
        [TestCase(Constants.GB, 500)]
        public async Task BlockBlobDirectoryToDirectory_LargeSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            string sourceBlobDirectoryName = "sourceFolder";
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

                string destinationFolder = "destFolder";

                await CopyBlobDirectoryAndVerify(
                    test.Container,
                    sourceBlobDirectoryName,
                    sourceFolderPath,
                    destinationFolder,
                    blobNames,
                    waitTimeInSec).ConfigureAwait(false);
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

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33082")]
        [Test]
        [LiveOnly]
        public async Task BlockBlobDirectoryToDirectory_EmptyFolder()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            // Set up directory to upload
            var dirName = GetNewBlobDirectoryName();
            var dirName2 = GetNewBlobDirectoryName();
            string folder = CreateRandomDirectory(Path.GetTempPath());
            try
            {
                // Set up destination client
                StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);
                StorageResourceContainer sourceResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName2,
                    new BlobStorageResourceContainerOptions()
                    {
                        CopyMethod = TransferCopyMethod.AsyncCopy,
                    });

                TransferManagerOptions managerOptions = new TransferManagerOptions()
                {
                    ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                    MaximumConcurrency = 1,
                };
                TransferManager transferManager = new TransferManager(managerOptions);

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
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                Directory.Delete(folder, true);
            }
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33082")]
        [Test]
        [LiveOnly]
        public async Task BlockBlobDirectoryToDirectory_SingleFile()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            string tempFolder = Path.GetTempPath();
            string sourceFolderName = "sourceFolder";
            string sourceFolderPath = CreateRandomDirectory(tempFolder, sourceFolderName);
            try
            {
                string blobName1 = Path.Combine(sourceFolderName, GetNewBlobName());
                await CreateBlockBlobAndSourceFile(test.Container, tempFolder, blobName1, Constants.KB);
                List<string> blobNames = new List<string>() { blobName1 };

                string destinationFolder = "destFolder";

                await CopyBlobDirectoryAndVerify(
                    container: test.Container,
                    sourceBlobPrefix: sourceFolderName,
                    sourceFilePrefix: sourceFolderPath,
                    destinationBlobPrefix: destinationFolder,
                    blobNames).ConfigureAwait(false);
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

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33082")]
        [Test]
        [LiveOnly]
        public async Task BlockBlobDirectoryToDirectory_ManySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            string tempFolder = CreateRandomDirectory(Path.GetTempPath());
            string blobDirectoryName = "sourceFolder";
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

                string destinationFolder = "destFolder";

                string sourceBlobPrefix = fullSourceFolderPath.Substring(tempFolder.Length + 1);

                await CopyBlobDirectoryAndVerify(
                    container: test.Container,
                    sourceBlobPrefix: sourceBlobPrefix,
                    sourceFilePrefix: fullSourceFolderPath,
                    destinationBlobPrefix: destinationFolder,
                    blobNames).ConfigureAwait(false);
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

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33082")]
        [Test]
        [LiveOnly]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task BlockBlobDirectoryToDirectory_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            string tempFolder = Path.GetTempPath();
            string sourceBlobDirectoryName = "sourceFolder";
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

                string destinationFolder = "destFolder";

                await CopyBlobDirectoryAndVerify(
                    test.Container,
                    sourceBlobDirectoryName,
                    fullPath,
                    destinationBlobPrefix: destinationFolder,
                    blobNames).ConfigureAwait(false);
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

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33082")]
        [Test]
        [LiveOnly]
        public async Task BlockBlobDirectoryToDirectory_OverwriteTrue()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            long size = Constants.KB;
            string tempFolder = Path.GetTempPath();
            string sourceBlobDirectoryName = "sourceFolder";
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

                ContainerTransferOptions options = new ContainerTransferOptions()
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
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                Directory.Delete(sourceFolderPath, true);
            }
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33082")]
        [Test]
        [LiveOnly]
        public async Task BlockBlobDirectoryToDirectory_OverwriteFalse()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            long size = Constants.KB;
            string tempFolder = Path.GetTempPath();
            string sourceBlobDirectoryName = "sourceFolder";
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

                ContainerTransferOptions options = new ContainerTransferOptions()
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
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                Directory.Delete(sourceFolderPath, true);
            }
        }
    }
}
