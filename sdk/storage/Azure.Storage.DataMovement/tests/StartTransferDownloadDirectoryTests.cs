// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;
using System.IO;
using Azure.Storage.Blobs.Specialized;
using NUnit.Framework.Internal;
using Microsoft.Extensions.Options;
using System.Drawing;

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferDownloadDirectoryTests : DataMovementBlobTestBase
    {
        public StartTransferDownloadDirectoryTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        /// <summary>
        /// Creates a block blob.
        /// </summary>
        /// <param name="containerClient">The parent container which the blob will be uploaded to</param>
        /// <param name="sourceDirectoryPath">Source Directory name. The source path will be appended to this to create the full path name</param>
        /// <param name="sourceFilePath">The blob name (full path to the blob) and the source file path</param>
        /// <param name="size">Size of the blob</param>
        /// <returns>The local source file path which contains the contents of the source blob.</returns>
        internal async Task CreateBlockBlobAndSourceFile(
            BlobContainerClient containerClient,
            string sourceDirectoryPath,
            string sourceBlobDirectory,
            string sourceFilePath,
            int size)
        {
            var data = GetRandomBuffer(size);
            using Stream originalStream = await CreateLimitedMemoryStream(size);
            string blobName = Path.Combine(sourceBlobDirectory, sourceFilePath);
            BlobClient originalBlob = InstrumentClient(containerClient.GetBlobClient(blobName));
            // create a new file and copy contents of stream into it, and then close the FileStream
            // so the StagedUploadAsync call is not prevented from reading using its FileStream.
            using (FileStream fileStream = File.Create($"{sourceDirectoryPath}\\{sourceFilePath}"))
            {
                // Copy source to a file, so we can verify the source against downloaded blob later
                await originalStream.CopyToAsync(fileStream);
                // Upload blob to storage account
                originalStream.Position = 0;
                await originalBlob.UploadAsync(originalStream);
            }
        }

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
            Assert.IsTrue(transfer.HasCompleted);
            if (exception != default)
            {
                Assert.Fail(exception.StackTrace);
            }
            List<string> destinationFiles = ListFilesInDirectory(destinationLocalPath);
            Assert.Equals(destinationFiles.Count, sourceFiles.Count);
            destinationFiles.Sort();
            sourceFiles.Sort();
            for (int i = 0; i < destinationFiles.Count; i++)
            {
                // Verify Download
                string fullSourcePath = Path.Combine(sourceFilePrefix, sourceFiles[i]);
                CheckDownloadFile(fullSourcePath, destinationFiles[i]);
            }
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(4 * Constants.MB, 200)]
        [TestCase(257 * Constants.MB, 500)]
        [TestCase(Constants.GB, 500)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task DownloadDirectoryAsync(int size, int waitInSec)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            string folderPath = CreateRandomDirectory(Path.GetTempPath());
            string sourceFolderPath = CreateRandomDirectory(folderPath);

            try
            {
                string sourceBlobDirectoryName = sourceFolderPath.Substring(folderPath.Length + 1);
                List<string> blobNames = new List<string>();

                string blobName1 = GetNewBlobName();
                string blobName2 = GetNewBlobName();
                await CreateBlockBlobAndSourceFile(test.Container, sourceFolderPath, sourceBlobDirectoryName, blobName1, size);
                await CreateBlockBlobAndSourceFile(test.Container, sourceFolderPath, sourceBlobDirectoryName, blobName2, size);
                blobNames.Add(blobName1);
                blobNames.Add(blobName2);

                string subDirName = CreateRandomDirectory(sourceFolderPath).Substring(sourceFolderPath.Length + 1);
                string blobName3 = Path.Combine(subDirName, GetNewBlobName());
                await CreateBlockBlobAndSourceFile(test.Container, sourceFolderPath, sourceBlobDirectoryName, blobName3, size);
                blobNames.Add(blobName3);

                string subDirName2 = CreateRandomDirectory(sourceFolderPath).Substring(sourceFolderPath.Length + 1);
                string blobName4 = Path.Combine(subDirName2, GetNewBlobName());
                await CreateBlockBlobAndSourceFile(test.Container, sourceFolderPath, sourceBlobDirectoryName, blobName4, size);
                blobNames.Add(blobName4);

                string localDirName = sourceFolderPath.Split('\\').Last();
                string destinationFolder = CreateRandomDirectory(Path.GetTempPath());

                await DownloadBlobDirectoryAndVerify(
                    test.Container,
                    sourceBlobDirectoryName,
                    sourceFolderPath,
                    blobNames,
                    destinationFolder,
                    waitInSec).ConfigureAwait(false);

                List<string> localItemsAfterDownload = Directory.GetFiles(sourceFolderPath, "*", SearchOption.AllDirectories).ToList();

                // Assert
                Assert.Multiple(() =>
                {
                    CollectionAssert.Contains(localItemsAfterDownload, blobName1);
                    CollectionAssert.Contains(localItemsAfterDownload, blobName2);
                    CollectionAssert.Contains(localItemsAfterDownload, blobName3);
                    CollectionAssert.Contains(localItemsAfterDownload, blobName4);
                });
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

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task DownloadDirectoryAsync_Empty()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            string tempFolder = CreateRandomDirectory(Path.GetTempPath());
            string sourceFolderPath = CreateRandomDirectory(tempFolder);
            try
            {
                string sourceBlobDirectoryName = sourceFolderPath.Substring(sourceFolderPath.Length + 1);
                string folder = CreateRandomDirectory(Path.GetTempPath());

                // Initialize transferManager
                TransferManager transferManager = new TransferManager();

                StorageResourceContainer sourceResource =
                    new BlobDirectoryStorageResourceContainer(test.Container, sourceBlobDirectoryName);
                StorageResourceContainer destinationResource =
                    new LocalDirectoryStorageResourceContainer(folder);

                DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource);

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

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task DownloadDirectoryAsync_SingleFile()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string tempFolder = CreateRandomDirectory(Path.GetTempPath());
            string sourceFolderPath = CreateRandomDirectory(tempFolder);
            try
            {
                string sourceBlobDirectoryName = sourceFolderPath.Substring(sourceFolderPath.Length + 1);
                List<string> blobNames = new List<string>();
                string blobName1 = GetNewBlobName();
                await CreateBlockBlobAndSourceFile(test.Container, sourceFolderPath, sourceBlobDirectoryName, blobName1, Constants.KB);
                blobNames.Add(blobName1);

                string destinationFolder = CreateRandomDirectory(sourceFolderPath);

                await DownloadBlobDirectoryAndVerify(
                    test.Container,
                    sourceBlobDirectoryName,
                    sourceFolderPath,
                    blobNames,
                    destinationFolder).ConfigureAwait(false);

                List<string> localItemsAfterDownload = Directory.GetFiles(destinationFolder, "*", SearchOption.AllDirectories).ToList();

                // Assert
                Assert.Equals(1, localItemsAfterDownload.Count());
                AssertContentFile(blobName1, destinationFolder + "/" + localItemsAfterDownload.First());
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

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task DownloadDirectoryAsync_ManySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string tempFolder = CreateRandomDirectory(Path.GetTempPath());
            string sourceFolderPath = CreateRandomDirectory(tempFolder);
            try
            {
                string sourceBlobDirectoryName = sourceFolderPath.Substring(sourceFolderPath.Length + 1);
                List<string> blobNames = new List<string>();
                string subDir1 = CreateRandomDirectory(sourceFolderPath).Substring(sourceFolderPath.Length + 1);
                string blobName1 = GetNewBlobName();
                await CreateBlockBlobAndSourceFile(test.Container, sourceFolderPath, sourceBlobDirectoryName, blobName1, Constants.KB);
                blobNames.Add(blobName1);
                string subDir2 = CreateRandomDirectory(sourceFolderPath).Substring(sourceFolderPath.Length + 1);
                string blobName2 = GetNewBlobName();
                await CreateBlockBlobAndSourceFile(test.Container, sourceFolderPath, sourceBlobDirectoryName, blobName2, Constants.KB);
                blobNames.Add(blobName2);
                string subDir3 = CreateRandomDirectory(sourceFolderPath).Substring(sourceFolderPath.Length + 1);
                string blobName3 = GetNewBlobName();
                await CreateBlockBlobAndSourceFile(test.Container, sourceFolderPath, sourceBlobDirectoryName, blobName3, Constants.KB);
                blobNames.Add(blobName3);

                string destinationFolder = CreateRandomDirectory(Path.GetTempPath());

                await DownloadBlobDirectoryAndVerify(
                    test.Container,
                    sourceBlobDirectoryName,
                    sourceFolderPath,
                    blobNames,
                    destinationFolder).ConfigureAwait(false);

                // Assert
                List<string> localItemsAfterDownload = Directory.GetFiles(destinationFolder, "*", SearchOption.AllDirectories).ToList();
                Assert.Multiple(() =>
                {
                    CollectionAssert.Contains(localItemsAfterDownload, blobName1);
                    CollectionAssert.Contains(localItemsAfterDownload, blobName2);
                    CollectionAssert.Contains(localItemsAfterDownload, blobName3);
                });
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

        [RecordedTest]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task DownloadDirectoryAsync_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string tempFolder = CreateRandomDirectory(Path.GetTempPath());
            string sourceFolderPath = CreateRandomDirectory(tempFolder);
            try
            {
                string sourceBlobDirectoryName = sourceFolderPath.Substring(sourceFolderPath.Length + 1);
                List<string> blobNames = new List<string>();
                string destinationFolder = CreateRandomDirectory(Path.GetTempPath());

                string subfolderName = sourceFolderPath;
                for (int i = 0; i < level; i++)
                {
                    string subDir = CreateRandomDirectory(subfolderName).Substring(sourceFolderPath.Length + 1);
                    string blobName = GetNewBlobName();
                    await CreateBlockBlobAndSourceFile(test.Container, sourceFolderPath, sourceBlobDirectoryName, blobName, Constants.KB);
                    blobNames.Add(blobName);
                }

                await DownloadBlobDirectoryAndVerify(
                    test.Container,
                    sourceBlobDirectoryName,
                    sourceFolderPath,
                    blobNames,
                    destinationFolder).ConfigureAwait(false);

                List<string> localItemsAfterDownload = Directory.GetFiles(destinationFolder, "*", SearchOption.AllDirectories).ToList();

                Assert.Equals(level, localItemsAfterDownload);
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
        #endregion DirectoryDownloadTests
    }
}
