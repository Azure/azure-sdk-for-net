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
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferUploadDirectoryTests : DataMovementBlobTestBase
    {
        public StartTransferUploadDirectoryTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        private string[] BlobNames
            => new[]
            {
                    "foo",
                    "bar",
                    "baz",
                    "foo/foo",
                    "foo/bar",
                    "baz/foo",
                    "baz/foo/bar",
                    "baz/bar/foo"
            };

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

            destinationPrefix ??= "foo";

            // Initialize transferManager
            TransferManager transferManager = new TransferManager(transferManagerOptions);

            StorageResourceContainer sourceResource =
                new LocalDirectoryStorageResourceContainer(localDirectoryPath);
            StorageResourceContainer destinationResource =
                new BlobDirectoryStorageResourceContainer(destinationContainer, destinationPrefix);

            // Set up blob to upload
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
                Assert.Fail(exception.Message);
            }

            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.Completed, transfer.TransferStatus);

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
            ContainerTransferOptions options = new ContainerTransferOptions();
            List<string> files = new List<string>();
            string localDirectory = CreateRandomDirectory(Path.GetTempPath());
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            try
            {
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
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                Directory.Delete(localDirectory, true);
            }
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
            ContainerTransferOptions options = new ContainerTransferOptions();
            List<string> files = new List<string>();
            string localDirectory = CreateRandomDirectory(Path.GetTempPath());
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            try
            {
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
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                Directory.Delete(localDirectory, true);
            }
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task LocalToBlockBlobDirectory_SmallChunks()
        {
            long blobSize = Constants.KB;
            int waitTimeInSec = 10;
            ContainerTransferOptions options = new ContainerTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };
            List<string> files = new List<string>();
            string localDirectory = CreateRandomDirectory(Path.GetTempPath());
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            try
            {
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
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                Directory.Delete(localDirectory, true);
            }
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_EmptyFolder()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            // Set up directory to upload
            var dirName = GetNewBlobDirectoryName();
            string folder = CreateRandomDirectory(Path.GetTempPath());
            try
            {
                // Set up destination client
                StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);
                StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

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

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_SingleFile()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            List<string> files = new List<string>();
            string folder = CreateRandomDirectory(Path.GetTempPath());
            try
            {
                StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);
                string openChild = await CreateRandomFileAsync(folder);
                files.Add(openChild);

                // Arrange
                await UploadBlobDirectoryAndVerify(
                    test.Container,
                    folder,
                    files,
                    waitTimeInSec: 10);
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

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_ManySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            string folder = CreateRandomDirectory(Path.GetTempPath());
            List<string> files = new List<string>();

            try
            {
                string openSubfolder = CreateRandomDirectory(folder);
                string openSubchild = await CreateRandomFileAsync(openSubfolder);
                files.Add(openSubchild);

                string openSubfolder2 = CreateRandomDirectory(folder);
                string openSubChild2_1 = await CreateRandomFileAsync(openSubfolder2);
                string openSubChild2_2 = await CreateRandomFileAsync(openSubfolder2);
                string openSubChild2_3 = await CreateRandomFileAsync(openSubfolder2);
                files.Add(openSubChild2_1);
                files.Add(openSubChild2_2);
                files.Add(openSubChild2_3);

                string openSubfolder3 = CreateRandomDirectory(folder);
                string openSubChild3_1 = await CreateRandomFileAsync(openSubfolder2);
                string openSubChild3_2 = await CreateRandomFileAsync(openSubfolder2);
                string openSubChild3_3 = await CreateRandomFileAsync(openSubfolder2);
                files.Add(openSubChild3_1);
                files.Add(openSubChild3_2);
                files.Add(openSubChild3_3);

                string openSubfolder4 = CreateRandomDirectory(folder);
                string openSubChild4_1 = await CreateRandomFileAsync(openSubfolder2);
                string openSubChild4_2 = await CreateRandomFileAsync(openSubfolder2);
                string openSubChild4_3 = await CreateRandomFileAsync(openSubfolder2);
                files.Add(openSubChild4_1);
                files.Add(openSubChild4_2);
                files.Add(openSubChild4_3);

                await UploadBlobDirectoryAndVerify(
                    test.Container,
                    folder,
                    files,
                    destinationPrefix: dirName,
                    waitTimeInSec: 10);
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

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task DirectoryUpload_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();

            string folder = CreateRandomDirectory(Path.GetTempPath());
            List<string> files = new List<string>();

            try
            {
                string subfolderName = folder;
                for (int i = 0; i < level; i++)
                {
                    string openSubfolder = CreateRandomDirectory(subfolderName);
                    files.Add(await CreateRandomFileAsync(openSubfolder));
                    subfolderName = openSubfolder;
                }

                await UploadBlobDirectoryAndVerify(
                         test.Container,
                         folder,
                         files,
                         destinationPrefix: dirName,
                         waitTimeInSec: 10);
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

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_EmptySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            string folder = CreateRandomDirectory(Path.GetTempPath());
            List<string> files = new List<string>();
            try
            {
                string openSubfolder = CreateRandomDirectory(folder);
                for (int i = 0; i < 6; i++)
                {
                    files.Add(await CreateRandomFileAsync(openSubfolder));
                }

                string openSubfolder2 = CreateRandomDirectory(folder);

                string openSubfolder3 = CreateRandomDirectory(folder);

                string openSubfolder4 = CreateRandomDirectory(folder);

                await UploadBlobDirectoryAndVerify(
                    test.Container,
                    folder,
                    files,
                    destinationPrefix: dirName,
                    waitTimeInSec: 10);
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
        #endregion

        #region DirectoryUploadTests

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_OverwriteTrue()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            string folder = CreateRandomDirectory(Path.GetTempPath());
            try
            {
                List<string> files = new List<string>();
                string file1 = await CreateRandomFileAsync(folder);
                string file2 = await CreateRandomFileAsync(folder);
                files.Add(file1);
                files.Add(file2);

                string openSubfolder = CreateRandomDirectory(folder);
                string file3 = await CreateRandomFileAsync(openSubfolder);
                files.Add(file3);

                string lockedSubfolder = CreateRandomDirectory(folder);
                string file4 = await CreateRandomFileAsync(lockedSubfolder);
                files.Add(file4);

                ContainerTransferOptions options = new ContainerTransferOptions()
                {
                    CreateMode = StorageResourceCreateMode.Overwrite
                };
                BlobClient blobClient = test.Container.GetBlobClient(dirName + "/" + file1.Substring(folder.Length + 1).Replace('\\', '/'));
                await blobClient.UploadAsync(file1);

                // Act
                await UploadBlobDirectoryAndVerify(
                    test.Container,
                    folder,
                    files,
                    destinationPrefix: dirName,
                    waitTimeInSec: 10);
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

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_OverwriteFalse()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            string folder = CreateRandomDirectory(Path.GetTempPath());
            try
            {
                List<string> files = new List<string>();
                string file1 = await CreateRandomFileAsync(folder);
                string file2 = await CreateRandomFileAsync(folder);
                files.Add(file1);
                files.Add(file2);

                string openSubfolder = CreateRandomDirectory(folder);
                string file3 = await CreateRandomFileAsync(openSubfolder);
                files.Add(file3);

                string lockedSubfolder = CreateRandomDirectory(folder);
                string file4 = await CreateRandomFileAsync(lockedSubfolder);
                files.Add(file4);

                ContainerTransferOptions options = new ContainerTransferOptions()
                {
                    CreateMode = StorageResourceCreateMode.Overwrite
                };
                BlobClient blobClient = test.Container.GetBlobClient(dirName + "/" + file1.Substring(folder.Length + 1).Replace('\\', '/'));
                await blobClient.UploadAsync(file1);

                // Act
                await UploadBlobDirectoryAndVerify(
                    test.Container,
                    folder,
                    files,
                    destinationPrefix: dirName,
                    waitTimeInSec: 10);
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

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(BlobType.Block)]
        [TestCase(BlobType.Append)]
        [TestCase(BlobType.Page)]
        public async Task DirectoryUpload_BlobType(BlobType blobType)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            string folder = CreateRandomDirectory(Path.GetTempPath());
            try
            {
                string file1 = await CreateRandomFileAsync(folder);
                string openSubfolder = CreateRandomDirectory(folder);
                string file2 = await CreateRandomFileAsync(openSubfolder);
                string destinationPrefix = "foo";

                TransferManager transferManager = new TransferManager();

                StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);
                BlobStorageResourceContainerOptions options = new BlobStorageResourceContainerOptions()
                {
                    BlobType = blobType
                };
                StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(
                    test.Container,
                    destinationPrefix,
                    options);

                // Act
                DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource);
                await transfer.AwaitCompletion();

                // Assert
                AsyncPageable<BlobItem> blobs = test.Container.GetBlobsAsync(prefix: destinationPrefix);
                await foreach (BlobItem blob in blobs)
                {
                    Assert.AreEqual(blob.Properties.BlobType, blobType);
                }
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
        #endregion DirectoryUploadTests

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
            BlobContainerClient containerClient,
            string sourceFolder,
            string destinationFolder,
            int concurrency,
            bool createFailedCondition = false,
            ContainerTransferOptions options = default,
            int size = Constants.KB)
        {
            // Arrange
            await CreateTempDirectoryStructure(sourceFolder, size);

            // Create storage resources
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(sourceFolder);
            // Create destination folder
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(containerClient, destinationFolder);

            // Create Transfer Manager with single threaded operation
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                MaximumConcurrency = concurrency,
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            // If we want a failure condition to happen
            if (createFailedCondition)
            {
                await CreateBlockBlob(containerClient, Path.GetTempFileName(), $"{destinationFolder}/blob1", size);
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
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            string sourceFolder = CreateRandomDirectory(Path.GetTempPath());
            string destFolderName = "destFolder";

            try
            {
                // Create transfer to do a AwaitCompletion
                DataTransfer transfer = await CreateStartTransfer(
                    test.Container,
                    sourceFolder,
                    destFolderName,
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
                Directory.Delete(sourceFolder, true);
            }
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35209")]
        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion_Failed()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            string sourceFolder = CreateRandomDirectory(Path.GetTempPath());
            string destFolderName = "destFolder";

            try
            {
                ContainerTransferOptions options = new ContainerTransferOptions()
                {
                    CreateMode = StorageResourceCreateMode.Fail
                };

                // Create transfer to do a AwaitCompletion
                DataTransfer transfer = await CreateStartTransfer(
                    test.Container,
                    sourceFolder,
                    destFolderName,
                    1,
                    true,
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
                Directory.Delete(sourceFolder, true);
            }
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35209")]
        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            string sourceFolder = CreateRandomDirectory(Path.GetTempPath());
            string destFolderName = "destFolder";

            try
            {
                // Create transfer options with Skipping available
                ContainerTransferOptions options = new ContainerTransferOptions()
                {
                    CreateMode = StorageResourceCreateMode.Skip
                };

                // Create transfer to do a AwaitCompletion
                DataTransfer transfer = await CreateStartTransfer(
                    test.Container,
                    sourceFolder,
                    destFolderName,
                    1,
                    true,
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
                Directory.Delete(sourceFolder, true);
            }
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            string sourceFolder = CreateRandomDirectory(Path.GetTempPath());
            string destFolderName = "destFolder";

            try
            {
                // Create transfer to do a EnsureCompleted
                DataTransfer transfer = await CreateStartTransfer(
                        test.Container,
                        sourceFolder,
                        destFolderName,
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
                Directory.Delete(sourceFolder, true);
            }
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35209")]
        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Failed()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            string sourceFolder = CreateRandomDirectory(Path.GetTempPath());
            string destFolderName = "destFolder";

            try
            {
                ContainerTransferOptions options = new ContainerTransferOptions()
                {
                    CreateMode = StorageResourceCreateMode.Fail
                };

                // Create transfer to do a AwaitCompletion
                DataTransfer transfer = await CreateStartTransfer(
                    test.Container,
                    sourceFolder,
                    destFolderName,
                    1,
                    true,
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
                Directory.Delete(sourceFolder, true);
            }
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/35209")]
        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Skipped()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            string sourceFolder = CreateRandomDirectory(Path.GetTempPath());
            string destFolderName = "destFolder";

            try
            {
                // Create transfer options with Skipping available
                ContainerTransferOptions options = new ContainerTransferOptions()
                {
                    CreateMode = StorageResourceCreateMode.Skip
                };

                // Create transfer to do a EnsureCompleted
                DataTransfer transfer = await CreateStartTransfer(
                    test.Container,
                    sourceFolder,
                    destFolderName,
                    1,
                    true,
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
                Directory.Delete(sourceFolder, true);
            }
        }
        #endregion
    }
}
