// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using NUnit.Framework;
using System.Threading;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.Shared;
using System.Data.Common;

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferDownloadTests : DataMovementBlobTestBase
    {
        public StartTransferDownloadTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
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

        internal class VerifyDownloadBlobContentInfo
        {
            public readonly string SourceLocalPath;
            public readonly string DestinationLocalPath;
            public SingleTransferOptions DownloadOptions;
            public DataTransfer DataTransfer;
            public bool CompletedStatus;
            public Exception Exception;

            public VerifyDownloadBlobContentInfo(
                string sourceFile,
                string destinationFile,
                SingleTransferOptions downloadOptions,
                bool completed,
                Exception exception)
            {
                SourceLocalPath = sourceFile;
                DestinationLocalPath = destinationFile;
                DownloadOptions = downloadOptions;
                CompletedStatus = completed;
                DataTransfer = default;
                Exception = exception;
            }
        };

        internal SingleTransferOptions CopySingleUploadOptions(SingleTransferOptions options)
        {
            SingleTransferOptions newOptions = new SingleTransferOptions()
            {
                MaximumTransferChunkSize = options?.MaximumTransferChunkSize,
                InitialTransferSize = options?.InitialTransferSize,
            };
            return newOptions;
        }

        #region SingleDownload Block Blob
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
        private async Task DownloadBlockBlobsAndVerify(
            BlobContainerClient container,
            long size = Constants.KB,
            int waitTimeInSec = 10,
            int blobCount = 1,
            TransferManagerOptions transferManagerOptions = default,
            List<string> blobNames = default,
            List<SingleTransferOptions> options = default)
        {
            // Populate blobNames list for number of blobs to be created
            if (blobNames == default || blobNames?.Count < 0)
            {
                blobNames ??= new List<string>();
                for (int i = 0; i < blobCount; i++)
                {
                    blobNames.Add(GetNewBlobName());
                }
            }
            else
            {
                // If blobNames is popluated make sure these number of blobs match
                Assert.AreEqual(blobCount, blobNames.Count);
            }

            // Populate blobNames list for number of blobs to be created
            if (options == default || options?.Count < 0)
            {
                options ??= new List<SingleTransferOptions>(blobCount);
                for (int i = 0; i < blobCount; i++)
                {
                    options.Add(new SingleTransferOptions());
                }
            }
            else
            {
                // If blobNames is popluated make sure these number of blobs match
                Assert.AreEqual(blobCount, options.Count);
            }

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };

            List<VerifyDownloadBlobContentInfo> downloadedBlobInfo = new List<VerifyDownloadBlobContentInfo>(blobCount);
            try
            {
                // Initialize TransferManager
                TransferManager TransferManager = new TransferManager(transferManagerOptions);
                // Upload set of VerifyDownloadBlobContentInfo blobs to download
                for (int i = 0; i < blobCount; i++)
                {
                    // Set up Blob to be downloaded
                    bool completed = false;
                    Exception exception = null;
                    var data = GetRandomBuffer(size);
                    using Stream originalStream = await CreateLimitedMemoryStream(size);
                    string localSourceFile = Path.GetTempFileName();
                    await CreateBlockBlob(container, localSourceFile, blobNames[i], size);

                    // Set up event handler for the respective blob
                    options[i].TransferStatus += (TransferStatusEventArgs args) =>
                    {
                        // Assert
                        if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                        {
                            completed = true;
                        }
                        return Task.CompletedTask;
                    };
                    options[i].TransferFailed += (TransferFailedEventArgs args) =>
                    {
                        exception = args.Exception;
                        return Task.CompletedTask;
                    };

                    // Create destination file path
                    string destFile = Path.GetTempPath() + Path.GetRandomFileName();

                    downloadedBlobInfo.Add(new VerifyDownloadBlobContentInfo(
                        localSourceFile,
                        destFile,
                        options[i],
                        completed,
                        exception));
                }

                // Schedule all download blobs consecutively
                for (int i = 0; i < downloadedBlobInfo.Count; i++)
                {
                    // Create a special blob client for downloading that will
                    // assign client request IDs based on the range so that out
                    // of order operations still get predictable IDs and the
                    // recordings work correctly
                    var credential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
                    BlobUriBuilder blobUriBuilder = new BlobUriBuilder(container.Uri)
                    {
                        BlobName = blobNames[i]
                    };
                    BlockBlobClient sourceBlobClient = InstrumentClient(new BlockBlobClient(blobUriBuilder.ToUri(), credential, GetOptions(true)));
                    StorageResource sourceResource = new BlockBlobStorageResource(sourceBlobClient);
                    StorageResource destinationResource = new LocalFileStorageResource(downloadedBlobInfo[i].DestinationLocalPath);

                    // Act
                    DataTransfer transfer = await TransferManager.StartTransferAsync(
                        sourceResource,
                        destinationResource,
                        options[i]).ConfigureAwait(false);

                    downloadedBlobInfo[i].DataTransfer = transfer;
                }

                for (int i = 0; i < downloadedBlobInfo.Count; i++)
                {
                    // Assert
                    if (downloadedBlobInfo[i].Exception != null)
                    {
                        Assert.Fail(downloadedBlobInfo[i].Exception.Message);
                    }
                    Assert.NotNull(downloadedBlobInfo[i].DataTransfer);
                    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                    await downloadedBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                    Assert.IsTrue(downloadedBlobInfo[i].DataTransfer.HasCompleted);
                    Assert.AreEqual(StorageTransferStatus.Completed, downloadedBlobInfo[i].DataTransfer.TransferStatus);

                    // Verify Download
                    CheckDownloadFile(downloadedBlobInfo[i].SourceLocalPath, downloadedBlobInfo[i].DestinationLocalPath);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            finally
            {
                // Cleanup - temporary local files (blobs cleaned up by diposing container)
                for (int i = 0; i < downloadedBlobInfo.Count; i++)
                {
                    if (File.Exists(downloadedBlobInfo[i].SourceLocalPath))
                    {
                        File.Delete(downloadedBlobInfo[i].SourceLocalPath);
                    }
                    if (File.Exists(downloadedBlobInfo[i].DestinationLocalPath))
                    {
                        File.Delete(downloadedBlobInfo[i].DestinationLocalPath);
                    }
                }
            }
        }

        [RecordedTest]
        public async Task BlockBlobToLocal()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            // No Option Download bag or manager options bag, plain download
            await DownloadBlockBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: 10,
                size: Constants.KB,
                blobCount: 1).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task BlockBlobToLocal_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            BlockBlobClient sourceClient = await CreateBlockBlob(testContainer.Container, localSourceFile, blobName, size);

            // Create destination to overwrite
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions> { options };
            await DownloadBlockBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: 10,
                size: Constants.KB,
                blobCount: 1,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task BlockBlobToLocal_Overwrite_NotExists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            // Act
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions> { options };
            await DownloadBlockBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: 10,
                size: Constants.KB,
                blobCount: 1,
                options: optionsList).ConfigureAwait(false);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33086")]
        [Test]
        [LiveOnly]
        public async Task BlockBlobToLocal_Skip_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            bool skippedSeen = false;
            BlockBlobClient sourceClient = await CreateBlockBlob(testContainer.Container, localSourceFile, blobName, size);

            // Create destination file. So it can get skipped over.
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip,
            };
            options.TransferSkipped += (TransferSkippedEventArgs args) =>
            {
                if (args.SourceResource != null &&
                    args.DestinationResource != null &&
                    args.TransferId != null)
                {
                    skippedSeen = true;
                }
                return Task.CompletedTask;
            };
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                new BlockBlobStorageResource(sourceClient),
                new LocalFileStorageResource(destFile),
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
            Assert.IsTrue(skippedSeen);
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
        }

        [RecordedTest]
        public async Task BlockBlobToLocal_Failure_Exists()
        {
            // Arrange
            Exception exception = default;
            bool sourceResourceCheck = false;
            bool destinationResourceCheck = false;

            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            BlockBlobClient sourceClient = await CreateBlockBlob(testContainer.Container, localSourceFile, blobName, size);

            // Make destination file name but do not create the file beforehand.
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to fail and keep track of the failure.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            StorageResource sourceResource = new BlockBlobStorageResource(sourceClient);
            StorageResource destinationResource = new LocalFileStorageResource(destFile);
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                // We can't Assert here or else it takes down everything.
                if (args.Exception != default)
                {
                    exception = args.Exception;
                }
                if (args.SourceResource.Uri == sourceResource.Uri)
                {
                    sourceResourceCheck = true;
                }
                if (args.DestinationResource.Path == destinationResource.Path)
                {
                    destinationResourceCheck = true;
                }
                return Task.CompletedTask;
            };
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                new BlockBlobStorageResource(sourceClient),
                new LocalFileStorageResource(destFile),
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
            Assert.IsTrue(sourceResourceCheck);
            Assert.IsTrue(destinationResourceCheck);
            Assert.NotNull(exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.AreEqual(exception.Message, $"File path `{destFile}` already exists. Cannot overwite file.");
        }

        [RecordedTest]
        public async Task BlockBlobToLocal_SmallChunk()
        {
            long size = Constants.KB;
            int waitTimeInSec = 10;
            SingleTransferOptions options = new SingleTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await DownloadBlockBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task BlockBlobToLocal_EventHandler()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            string exceptionMessage = default;
            int waitTimeInSec = 10;
            bool seenInProgress = false;
            SingleTransferOptions options = new SingleTransferOptions();
            options.TransferStatus += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    seenInProgress = true;
                }
                return Task.CompletedTask;
            };

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await DownloadBlockBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                options: optionsList).ConfigureAwait(false);

            // Assert
            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                Assert.Fail(exceptionMessage);
            }
            Assert.IsTrue(seenInProgress);
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(100, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.KB, 10)]
        public async Task BlockBlobToLocal_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await DownloadBlockBlobsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 200)]
        [TestCase(Constants.GB, 1500)]
        public async Task BlockBlobToLocal_LargeSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await DownloadBlockBlobsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(2, Constants.KB, 60)]
        [TestCase(6, Constants.KB, 60)]
        [TestCase(2, 4 * Constants.KB, 60)]
        [TestCase(6, 4 * Constants.KB, 60)]
        public async Task BlockBlobToLocal_SmallMultiple(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await DownloadBlockBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 600)]
        [TestCase(2, Constants.GB, 2000)]
        public async Task BlockBlobToLocal_LargeMultiple(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await DownloadBlockBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(2, Constants.KB, 60)]
        [TestCase(6, Constants.KB, 60)]
        [TestCase(6, 4 * Constants.KB, 60)]
        public async Task BlockBlobToLocal_SmallConcurrency(int concurrency, int size, int waitTimeInSec)
        {
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            SingleTransferOptions options = new SingleTransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };

            await DownloadBlockBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                transferManagerOptions: managerOptions,
                options: optionsList).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(2, Constants.MB, 300)]
        [TestCase(6, Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        public async Task BlockBlobToLocal_LargeConcurrency(int concurrency, int size, int waitTimeInSec)
        {
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await DownloadBlockBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                transferManagerOptions: managerOptions).ConfigureAwait(false);
        }
        #endregion SingleDownload Block Blob

        #region SingleDownload Append Blob
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
        private async Task DownloadAppendBlobsAndVerify(
            BlobContainerClient container,
            long size = Constants.KB,
            int waitTimeInSec = 10,
            int blobCount = 1,
            TransferManagerOptions transferManagerOptions = default,
            List<string> blobNames = default,
            List<SingleTransferOptions> options = default)
        {
            // Populate blobNames list for number of blobs to be created
            if (blobNames == default || blobNames?.Count < 0)
            {
                blobNames ??= new List<string>();
                for (int i = 0; i < blobCount; i++)
                {
                    blobNames.Add(GetNewBlobName());
                }
            }
            else
            {
                // If blobNames is popluated make sure these number of blobs match
                Assert.AreEqual(blobCount, blobNames.Count);
            }

            // Populate blobNames list for number of blobs to be created
            if (options == default || options?.Count < 0)
            {
                options ??= new List<SingleTransferOptions>(blobCount);
                for (int i = 0; i < blobCount; i++)
                {
                    options.Add(new SingleTransferOptions());
                }
            }
            else
            {
                // If blobNames is popluated make sure these number of blobs match
                Assert.AreEqual(blobCount, options.Count);
            }

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };

            List<VerifyDownloadBlobContentInfo> downloadedBlobInfo = new List<VerifyDownloadBlobContentInfo>(blobCount);
            try
            {
                // Initialize TransferManager
                TransferManager transferManager = new TransferManager(transferManagerOptions);

                // Upload set of VerifyDownloadBlobContentInfo blobs to download
                for (int i = 0; i < blobCount; i++)
                {
                    bool completed = false;
                    Exception exception = null;
                    // Set up Blob to be downloaded
                    var data = GetRandomBuffer(size);
                    using Stream originalStream = await CreateLimitedMemoryStream(size);
                    string localSourceFile = Path.GetTempFileName();
                    await CreateAppendBlob(container, localSourceFile, blobNames[i], size);

                    // Set up event handler for the respective blob
                    options[i].TransferFailed += (TransferFailedEventArgs args) =>
                    {
                        exception = args.Exception;
                        return Task.CompletedTask;
                    };

                    // Create destination file path
                    string destFile = Path.GetTempPath() + Path.GetRandomFileName();

                    downloadedBlobInfo.Add(new VerifyDownloadBlobContentInfo(
                        localSourceFile,
                        destFile,
                        options[i],
                        completed,
                        exception));
                }

                // Schedule all download blobs consecutively
                for (int i = 0; i < downloadedBlobInfo.Count; i++)
                {
                    // Create a special blob client for downloading that will
                    // assign client request IDs based on the range so that out
                    // of order operations still get predictable IDs and the
                    // recordings work correctly
                    var credential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
                    BlobUriBuilder blobUriBuilder = new BlobUriBuilder(container.Uri)
                    {
                        BlobName = blobNames[i]
                    };
                    AppendBlobClient sourceBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), credential, GetOptions(true)));
                    StorageResource sourceResource = new AppendBlobStorageResource(sourceBlobClient);
                    StorageResource destinationResource = new LocalFileStorageResource(downloadedBlobInfo[i].DestinationLocalPath);

                    // Act
                    DataTransfer transfer = await transferManager.StartTransferAsync(
                        sourceResource,
                        destinationResource,
                        options[i]);
                    downloadedBlobInfo[i].DataTransfer = transfer;
                }

                for (int i = 0; i < downloadedBlobInfo.Count; i++)
                {
                    // Assert
                    if (downloadedBlobInfo[i].Exception != null)
                    {
                        Assert.Fail(downloadedBlobInfo[i].Exception.Message);
                    }
                    Assert.NotNull(downloadedBlobInfo[i].DataTransfer);
                    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                    await downloadedBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                    Assert.IsTrue(downloadedBlobInfo[i].DataTransfer.HasCompleted);

                    // Verify Download
                    CheckDownloadFile(downloadedBlobInfo[i].SourceLocalPath, downloadedBlobInfo[i].DestinationLocalPath);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            finally
            {
                // Cleanup - temporary local files (blobs cleaned up by diposing container)
                for (int i = 0; i < downloadedBlobInfo.Count; i++)
                {
                    if (File.Exists(downloadedBlobInfo[i].SourceLocalPath))
                    {
                        File.Delete(downloadedBlobInfo[i].SourceLocalPath);
                    }
                    if (File.Exists(downloadedBlobInfo[i].DestinationLocalPath))
                    {
                        File.Delete(downloadedBlobInfo[i].DestinationLocalPath);
                    }
                }
            }
        }

        [RecordedTest]
        public async Task AppendBlobToLocal()
        {
            long size = Constants.KB;
            int waitTimeInSec = 10;

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await DownloadAppendBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task AppendBlobToLocal_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            AppendBlobClient sourceClient = await CreateAppendBlob(testContainer.Container, localSourceFile, blobName, size);

            // Create destination to overwrite
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions> { options };
            await DownloadAppendBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: 10,
                size: Constants.KB,
                blobCount: 1,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task AppendBlobToLocal_Overwrite_NotExists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            // Act
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions> { options };
            await DownloadAppendBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: 10,
                size: Constants.KB,
                blobCount: 1,
                options: optionsList).ConfigureAwait(false);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33086")]
        [Test]
        [LiveOnly]
        public async Task AppendBlobToLocal_Skip_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            bool skippedSeen = false;
            AppendBlobClient sourceClient = await CreateAppendBlob(testContainer.Container, localSourceFile, blobName, size);

            // Create destination file. So it can get skipped over.
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip,
            };
            options.TransferSkipped += (TransferSkippedEventArgs args) =>
            {
                if (args.SourceResource != null &&
                    args.DestinationResource != null &&
                    args.TransferId != null)
                {
                    skippedSeen = true;
                }
                return Task.CompletedTask;
            };
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                new AppendBlobStorageResource(sourceClient),
                new LocalFileStorageResource(destFile),
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
            Assert.IsTrue(skippedSeen);
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
        }

        [RecordedTest]
        public async Task AppendBlobToLocal_Failure_Exists()
        {
            // Arrange
            Exception exception = default;
            bool sourceResourceCheck = false;
            bool destinationResourceCheck = false;

            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            AppendBlobClient sourceClient = await CreateAppendBlob(testContainer.Container, localSourceFile, blobName, size);

            // Make destination file name but do not create the file beforehand.
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to fail and keep track of the failure.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            StorageResource sourceResource = new AppendBlobStorageResource(sourceClient);
            StorageResource destinationResource = new LocalFileStorageResource(destFile);
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                // We can't Assert here or else it takes down everything.
                if (args.Exception != default)
                {
                    exception = args.Exception;
                }
                if (args.SourceResource.Uri == sourceResource.Uri)
                {
                    sourceResourceCheck = true;
                }
                if (args.DestinationResource.Path == destinationResource.Path)
                {
                    destinationResourceCheck = true;
                }
                return Task.CompletedTask;
            };
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                new AppendBlobStorageResource(sourceClient),
                new LocalFileStorageResource(destFile),
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
            Assert.IsTrue(sourceResourceCheck);
            Assert.IsTrue(destinationResourceCheck);
            Assert.NotNull(exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.AreEqual(exception.Message, $"File path `{destFile}` already exists. Cannot overwite file.");
        }

        [RecordedTest]
        public async Task AppendBlobToLocal_EventHandler()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            string exceptionMessage = default;
            int waitTimeInSec = 10;
            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();
            options.TransferStatus += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    exceptionMessage = args.Exception.Message;
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await DownloadAppendBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                options: optionsList).ConfigureAwait(false);

            // Assert
            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                Assert.Fail(exceptionMessage);
            }
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        public async Task AppendBlobToLocal_FailedEvent()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            Exception exception = default;
            string blobName = GetNewBlobName();
            int size = Constants.KB;

            // Create local source file to compare to later.
            string localSourceFile = Path.GetTempFileName();

            // Create source Append Blob
            AppendBlobClient sourceClient = await CreateAppendBlob(testContainer.Container, localSourceFile, blobName, size);

            // Create destination file path
            string destFile = Path.GetTempFileName();

            // Act - Attempt a transfer even though the destination already exists.
            TransferManager transferManager = new TransferManager();
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                // We can't Assert here or else it takes down everything.
                if (args.Exception != default)
                {
                    exception = args.Exception;
                }
                return Task.CompletedTask;
            };

            StorageResource sourceResource = new AppendBlobStorageResource(sourceClient);
            StorageResource destinationResource = new LocalFileStorageResource(destFile);

            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(cancellationTokenSource.Token);

            Assert.NotNull(exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.AreEqual(exception.Message, $"File path `{destFile}` already exists. Cannot overwite file.");
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.KB, 20)]
        public async Task AppendBlobToLocal_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            SingleTransferOptions options = new SingleTransferOptions();

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await DownloadAppendBlobsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                options: optionsList).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 400)]
        [TestCase(Constants.GB, 1)]
        [TestCase(Constants.GB, 2)]
        [TestCase(Constants.GB, 8)]
        [TestCase(Constants.GB, 80)]
        public async Task AppendBlobToLocal_LargeSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            string exceptionMessage = default;
            SingleTransferOptions options = new SingleTransferOptions();

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await DownloadAppendBlobsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                options: optionsList).ConfigureAwait(false);

            // Assert
            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                Assert.Fail(exceptionMessage);
            }
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(2, Constants.KB, 60)]
        [TestCase(6, Constants.KB, 60)]
        [TestCase(2, 4 * Constants.KB, 60)]
        [TestCase(6, 4 * Constants.KB, 60)]
        public async Task AppendBlobToLocal_MultipleSmall(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await DownloadAppendBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(2, Constants.MB, 300)]
        [TestCase(6, Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        [TestCase(6, Constants.GB, 1000)]
        public async Task AppendBlobToLocal_MultipleLarge(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await DownloadAppendBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task AppendBlobToLocal_SmallChunk()
        {
            // To test parallel chunked download, this makes it faster to debug
            // and run through.
            long size = Constants.KB;
            int waitTimeInSec = 10;
            SingleTransferOptions options = new SingleTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await DownloadBlockBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(6, 0, 30)]
        [TestCase(2, Constants.KB, 60)]
        [TestCase(6, Constants.KB, 60)]
        [TestCase(2, 2 * Constants.KB, 60)]
        [TestCase(6, 4 * Constants.KB, 60)]
        public async Task AppendBlobToLocal_SmallConcurrency(int concurrency, int size, int waitTimeInSec)
        {
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await DownloadAppendBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                transferManagerOptions: managerOptions).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(2, Constants.MB, 300)]
        [TestCase(6, Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        [TestCase(6, Constants.GB, 1000)]
        [TestCase(32, Constants.GB, 1000)]
        public async Task AppendBlobToLocal_LargeConcurrency(int concurrency, int size, int waitTimeInSec)
        {
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await DownloadAppendBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                transferManagerOptions: managerOptions).ConfigureAwait(false);
        }
        #endregion SingleDownload Append Blob

        #region SingleDownload Page Blob
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
        private async Task DownloadPageBlobsAndVerify(
            BlobContainerClient container,
            long size = Constants.KB,
            int waitTimeInSec = 10,
            int blobCount = 1,
            TransferManagerOptions transferManagerOptions = default,
            List<string> blobNames = default,
            List<SingleTransferOptions> options = default)
        {
            // Populate blobNames list for number of blobs to be created
            if (blobNames == default || blobNames?.Count < 0)
            {
                blobNames ??= new List<string>();
                for (int i = 0; i < blobCount; i++)
                {
                    blobNames.Add(GetNewBlobName());
                }
            }
            else
            {
                // If blobNames is popluated make sure these number of blobs match
                Assert.AreEqual(blobCount, blobNames.Count);
            }

            // Populate blobNames list for number of blobs to be created
            if (options == default || options?.Count < 0)
            {
                options ??= new List<SingleTransferOptions>(blobCount);
                for (int i = 0; i < blobCount; i++)
                {
                    options.Add(new SingleTransferOptions());
                }
            }
            else
            {
                // If blobNames is popluated make sure these number of blobs match
                Assert.AreEqual(blobCount, options.Count);
            }

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };

            List<VerifyDownloadBlobContentInfo> downloadedBlobInfo = new List<VerifyDownloadBlobContentInfo>(blobCount);
            try
            {
                // Initialize TransferManager
                TransferManager TransferManager = new TransferManager(transferManagerOptions);

                // Upload set of VerifyDownloadBlobContentInfo blobs to download
                for (int i = 0; i < blobCount; i++)
                {
                    bool completed = false;
                    Exception exception = null;
                    // Set up Blob to be downloaded
                    var data = GetRandomBuffer(size);
                    using Stream originalStream = await CreateLimitedMemoryStream(size);
                    string localSourceFile = Path.GetTempFileName();
                    await CreatePageBlob(container, localSourceFile, blobNames[i], size);

                    // Set up event handler for the respective blob
                    options[i].TransferFailed += (TransferFailedEventArgs args) =>
                    {
                        exception = args.Exception;
                        return Task.CompletedTask;
                    };

                    // Create destination file path
                    string destFile = Path.GetTempPath() + Path.GetRandomFileName();

                    downloadedBlobInfo.Add(new VerifyDownloadBlobContentInfo(
                        localSourceFile,
                        destFile,
                        options[i],
                        completed,
                        exception));
                }

                // Schedule all download blobs consecutively
                for (int i = 0; i < downloadedBlobInfo.Count; i++)
                {
                    // Create a special blob client for downloading that will
                    // assign client request IDs based on the range so that out
                    // of order operations still get predictable IDs and the
                    // recordings work correctly
                    var credential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
                    BlobUriBuilder blobUriBuilder = new BlobUriBuilder(container.Uri)
                    {
                        BlobName = blobNames[i]
                    };
                    PageBlobClient sourceBlobClient = InstrumentClient(new PageBlobClient(blobUriBuilder.ToUri(), credential, GetOptions(true)));
                    StorageResource sourceResource = new PageBlobStorageResource(sourceBlobClient);
                    StorageResource destinationResource = new LocalFileStorageResource(downloadedBlobInfo[i].DestinationLocalPath);

                    // Act
                    DataTransfer transfer = await TransferManager.StartTransferAsync(
                        sourceResource,
                        destinationResource,
                        options[i]).ConfigureAwait(false);

                    downloadedBlobInfo[i].DataTransfer = transfer;
                }

                for (int i = 0; i < downloadedBlobInfo.Count; i++)
                {
                    // Assert
                    if (downloadedBlobInfo[i].Exception != null)
                    {
                        Assert.Fail(downloadedBlobInfo[i].Exception.Message);
                    }
                    Assert.NotNull(downloadedBlobInfo[i].DataTransfer);
                    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                    await downloadedBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                    Assert.IsTrue(downloadedBlobInfo[i].DataTransfer.HasCompleted);

                    // Verify Download
                    CheckDownloadFile(downloadedBlobInfo[i].SourceLocalPath, downloadedBlobInfo[i].DestinationLocalPath);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            finally
            {
                // Cleanup - temporary local files (blobs cleaned up by diposing container)
                for (int i = 0; i < downloadedBlobInfo.Count; i++)
                {
                    if (File.Exists(downloadedBlobInfo[i].SourceLocalPath))
                    {
                        File.Delete(downloadedBlobInfo[i].SourceLocalPath);
                    }
                    if (File.Exists(downloadedBlobInfo[i].DestinationLocalPath))
                    {
                        File.Delete(downloadedBlobInfo[i].DestinationLocalPath);
                    }
                }
            }
        }

        [RecordedTest]
        public async Task PageBlobToLocal()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await DownloadPageBlobsAndVerify(testContainer.Container).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task PageBlobToLocal_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            PageBlobClient sourceClient = await CreatePageBlob(testContainer.Container, localSourceFile, blobName, size);

            // Create destination to overwrite
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions> { options };
            await DownloadPageBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: 10,
                size: Constants.KB,
                blobCount: 1,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task PageBlobToLocal_Overwrite_NotExists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            // Act
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions> { options };
            await DownloadPageBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: 10,
                size: Constants.KB,
                blobCount: 1,
                options: optionsList).ConfigureAwait(false);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33086")]
        [Test]
        [LiveOnly]
        public async Task PageBlobToLocal_Skip_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            bool skippedSeen = false;
            PageBlobClient sourceClient = await CreatePageBlob(testContainer.Container, localSourceFile, blobName, size);

            // Create destination file. So it can get skipped over.
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip,
            };
            options.TransferSkipped += (TransferSkippedEventArgs args) =>
            {
                if (args.SourceResource != null &&
                    args.DestinationResource != null &&
                    args.TransferId != null)
                {
                    skippedSeen = true;
                }
                return Task.CompletedTask;
            };
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                new PageBlobStorageResource(sourceClient),
                new LocalFileStorageResource(destFile),
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
            Assert.IsTrue(skippedSeen);
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
        }

        [RecordedTest]
        public async Task PageBlobToLocal_Failure_Exists()
        {
            // Arrange
            Exception exception = default;
            bool sourceResourceCheck = false;
            bool destinationResourceCheck = false;

            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            PageBlobClient sourceClient = await CreatePageBlob(testContainer.Container, localSourceFile, blobName, size);

            // Make destination file name but do not create the file beforehand.
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to fail and keep track of the failure.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            StorageResource sourceResource = new PageBlobStorageResource(sourceClient);
            StorageResource destinationResource = new LocalFileStorageResource(destFile);
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                // We can't Assert here or else it takes down everything.
                if (args.Exception != default)
                {
                    exception = args.Exception;
                }
                if (args.SourceResource.Uri == sourceResource.Uri)
                {
                    sourceResourceCheck = true;
                }
                if (args.DestinationResource.Path == destinationResource.Path)
                {
                    destinationResourceCheck = true;
                }
                return Task.CompletedTask;
            };
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                new PageBlobStorageResource(sourceClient),
                new LocalFileStorageResource(destFile),
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
            Assert.IsTrue(sourceResourceCheck);
            Assert.IsTrue(destinationResourceCheck);
            Assert.NotNull(exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.AreEqual(exception.Message, $"File path `{destFile}` already exists. Cannot overwite file.");
        }

        [RecordedTest]
        public async Task PageBlobToLocal_SmallChunk()
        {
            long size = 12 * Constants.KB;
            int waitTimeInSec = 10;
            SingleTransferOptions options = new SingleTransferOptions()
            {
                InitialTransferSize = Constants.KB,
                MaximumTransferChunkSize = Constants.KB,
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await DownloadPageBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task PageBlobToLocal_EventHandler()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            string exceptionMessage = default;
            int waitTimeInSec = 10;
            bool progressSeen = false;
            SingleTransferOptions options = new SingleTransferOptions();
            options.TransferStatus += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    progressSeen = true;
                }
                return Task.CompletedTask;
            };

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await DownloadPageBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                options: optionsList).ConfigureAwait(false);

            // Assert
            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                Assert.Fail(exceptionMessage);
            }
            Assert.IsTrue(progressSeen);
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(2 * Constants.KB, 10)]
        [TestCase(4 * Constants.KB, 10)]
        public async Task PageBlobToLocal_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await DownloadPageBlobsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 400)]
        [TestCase(Constants.GB, 800)]
        public async Task PageBlobToLocal_LargeSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            string exceptionMessage = default;
            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();
            options.TransferStatus += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    exceptionMessage = args.Exception.Message;
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await DownloadPageBlobsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                options: optionsList).ConfigureAwait(false);

            // Assert
            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                Assert.Fail(exceptionMessage);
            }
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(2, 4 * Constants.KB, 60)]
        [TestCase(6, 4 * Constants.KB, 60)]
        public async Task PageBlobToLocal_SmallMultiple(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await DownloadPageBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        public async Task PageBlobToLocal_LargeMultiple(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await DownloadPageBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(2, Constants.KB, 300)]
        [TestCase(6, Constants.KB, 300)]
        [TestCase(2, 4 * Constants.KB, 300)]
        [TestCase(6, 4 * Constants.KB, 300)]
        public async Task PageBlobToLocal_SmallConcurrency(int concurrency, int size, int waitTimeInSec)
        {
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            SingleTransferOptions options = new SingleTransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await DownloadPageBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                transferManagerOptions: managerOptions,
                options: optionsList).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(2, Constants.MB, 300)]
        [TestCase(6, Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        public async Task PageBlobToLocal_LargeConcurrency(int concurrency, int size, int waitTimeInSec)
        {
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await DownloadPageBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                transferManagerOptions: managerOptions).ConfigureAwait(false);
        }
        #endregion SingleDownload Page Blob
    }
}
