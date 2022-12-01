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

        internal async Task<AppendBlobClient> CreateAppendBlob(
            BlobContainerClient containerClient,
            string localSourceFile,
            string blobName,
            long size)
        {
            AppendBlobClient blobClient = containerClient.GetAppendBlobClient(blobName);
            await blobClient.CreateIfNotExistsAsync().ConfigureAwait(false);
            if (size > 0)
            {
                long offset = 0;
                long blockSize = Math.Min(Constants.DefaultBufferSize, size);
                using Stream originalStream = await CreateLimitedMemoryStream(size);
                using (FileStream fileStream = File.Create(localSourceFile))
                {
                    // Copy source to a file, so we can verify the source against downloaded blob later
                    await originalStream.CopyToAsync(fileStream);
                    originalStream.Position = 0;
                    // Upload blob to storage account
                    while (offset < size)
                    {
                        Stream partStream = WindowStream.GetWindow(originalStream, blockSize);
                        await blobClient.AppendBlockAsync(partStream);
                        offset += blockSize;
                    }
                }
            }
            return blobClient;
        }

        internal async Task<PageBlobClient> CreatePageBlob(
            BlobContainerClient containerClient,
            string localSourceFile,
            string blobName,
            long size)
        {
            Assert.IsTrue(size % (Constants.KB/2) == 0, "Cannot create page blob that's not a multiple of 512");

            PageBlobClient blobClient = containerClient.GetPageBlobClient(blobName);
            await blobClient.CreateIfNotExistsAsync(size).ConfigureAwait(false);
            if (size > 0)
            {
                long offset = 0;
                long blockSize = Math.Min(Constants.DefaultBufferSize, size);
                using Stream originalStream = await CreateLimitedMemoryStream(size);
                using (FileStream fileStream = File.Create(localSourceFile))
                {
                    // Copy source to a file, so we can verify the source against downloaded blob later
                    await originalStream.CopyToAsync(fileStream);
                    originalStream.Position = 0;
                }
                // Upload blob to storage account
                while (offset < size)
                {
                    Stream partStream = WindowStream.GetWindow(originalStream, blockSize);
                    await blobClient.UploadPagesAsync(partStream, offset);
                    offset += blockSize;
                }
            }
            return blobClient;
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
                // Initialize BlobDataController
                TransferManager BlobDataController = new TransferManager(transferManagerOptions);
                // Upload set of VerifyDownloadBlobContentInfo blobs to download
                for (int i = 0; i < blobCount; i++)
                {
                    // Set up Blob to be downloaded
                    bool completed = false;
                    Exception exception = null;
                    var data = GetRandomBuffer(size);
                    using Stream originalStream = await CreateLimitedMemoryStream(size);
                    string localSourceFile = Path.GetTempFileName();
                    BlobClient originalBlob = InstrumentClient(container.GetBlobClient(blobNames[i]));
                    // create a new file and copy contents of stream into it, and then close the FileStream
                    // so the StagedUploadAsync call is not prevented from reading using its FileStream.
                    using (FileStream fileStream = File.Create(localSourceFile))
                    {
                        // Copy source to a file, so we can verify the source against downloaded blob later
                        await originalStream.CopyToAsync(fileStream);
                        // Upload blob to storage account
                        originalStream.Position = 0;
                        await originalBlob.UploadAsync(originalStream);
                    }

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
                    DataTransfer transfer = await BlobDataController.StartTransferAsync(
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
        public async Task BlockBlobToLocal()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            // No Option Download bag or manager options bag, plain download
            await DownloadBlockBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: 10,
                size: 0,
                blobCount: 1).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 400)]
        [TestCase(Constants.GB, 800)]
        public async Task BlockBlobToLocal_Progress(long size, int waitTimeInSec)
        {
            AutoResetEvent CompletedProgressBytesWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await DownloadBlockBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);

            // Assert
            Assert.IsTrue(CompletedProgressBytesWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
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
            await DownloadBlockBlobsAndVerify(
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
        [TestCase(0, 10)]
        [TestCase(100, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 200)]
        [TestCase(Constants.GB, 1500)]
        public async Task BlockBlobToLocal_Size(long size, int waitTimeInSec)
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
            await DownloadBlockBlobsAndVerify(
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
        [TestCase(2, 4 * Constants.MB, 300)]
        [TestCase(6, 4 * Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 600)]
        [TestCase(2, Constants.GB, 2000)]
        public async Task BlockBlobToLocal_Multiple(int blobCount, long size, int waitTimeInSec)
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
        [TestCase(2, 4 * Constants.MB, 300)]
        [TestCase(6, 4 * Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        public async Task BlockBlobToLocal_Concurrency(int concurrency, int size, int waitTimeInSec)
        {
            AutoResetEvent CompletedProgressBytesWait = new AutoResetEvent(false);

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
                // Initialize BlobDataController
                TransferManager BlobDataController = new TransferManager(transferManagerOptions);

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
                    AppendBlobClient sourceBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), credential, GetOptions(true)));
                    StorageResource sourceResource = new AppendBlobStorageResource(sourceBlobClient);
                    StorageResource destinationResource = new LocalFileStorageResource(downloadedBlobInfo[i].DestinationLocalPath);

                    // Act
                    DataTransfer transfer = await BlobDataController.StartTransferAsync(
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
                    Assert.IsTrue(downloadedBlobInfo[i].CompletedStatus);

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
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 400)]
        [TestCase(Constants.GB, 800)]
        public async Task AppendBlobToLocal_Progress(long size, int waitTimeInSec)
        {
            AutoResetEvent CompletedProgressBytesWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await DownloadAppendBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);

            // Assert
            Assert.IsTrue(CompletedProgressBytesWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
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
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(5 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 400)]
        [TestCase(Constants.GB, 800)]
        public async Task AppendBlobToLocal_Size(long size, int waitTimeInSec)
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
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(2, 4 * Constants.MB, 300)]
        [TestCase(6, 4 * Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        public async Task AppendBlobToLocal_Multiple(int blobCount, long size, int waitTimeInSec)
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
        [TestCase(2, 4 * Constants.MB, 300)]
        [TestCase(6, 4 * Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        public async Task AppendBlobToLocal_Concurrency(int concurrency, int size, int waitTimeInSec)
        {
            AutoResetEvent CompletedProgressBytesWait = new AutoResetEvent(false);

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
                // Initialize BlobDataController
                TransferManager BlobDataController = new TransferManager(transferManagerOptions);

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
                    PageBlobClient sourceBlobClient = InstrumentClient(new PageBlobClient(blobUriBuilder.ToUri(), credential, GetOptions(true)));
                    StorageResource sourceResource = new PageBlobStorageResource(sourceBlobClient);
                    StorageResource destinationResource = new LocalFileStorageResource(downloadedBlobInfo[i].DestinationLocalPath);

                    // Act
                    DataTransfer transfer = await BlobDataController.StartTransferAsync(
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
                    Assert.IsTrue(downloadedBlobInfo[i].CompletedStatus);

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
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 400)]
        [TestCase(Constants.GB, 800)]
        public async Task PageBlobToLocal_Progress(long size, int waitTimeInSec)
        {
            SingleTransferOptions options = new SingleTransferOptions();

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
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(8 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 400)]
        [TestCase(Constants.GB, 800)]
        public async Task PageBlobToLocal_Size(long size, int waitTimeInSec)
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
        [TestCase(2, 4 * Constants.MB, 300)]
        [TestCase(6, 4 * Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        public async Task PageBlobToLocal_Multiple(int blobCount, long size, int waitTimeInSec)
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
        [TestCase(2, 4 * Constants.MB, 300)]
        [TestCase(6, 4 * Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        public async Task PageBlobToLocal_Concurrency(int concurrency, int size, int waitTimeInSec)
        {
            AutoResetEvent CompletedProgressBytesWait = new AutoResetEvent(false);

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

        /*
        #region DirectoryDownloadTests
        [RecordedTest]
        public async Task DownloadDirectoryAsync()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            StorageResourceContainer client = test.Container.GetStorageResourceContainer(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string lockedChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder).ConfigureAwait(false);

            string localDirName = folder.Split('\\').Last();

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
            options.ProgressHandler = new Progress<BlobFolderUploadProgress>();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            BlobDataController BlobDataController = InstrumentClient(new BlobDataController(managerOptions));
            await BlobDataController.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            Directory.Delete(folder, true);
            string destinationFolder = CreateRandomDirectory(folder);

            //Act
            await BlobDataController.ScheduleFolderDownloadAsync(client, destinationFolder, downloadOptions).ConfigureAwait(false);

            List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(localItemsAfterDownload, openChild);
                CollectionAssert.Contains(localItemsAfterDownload, lockedChild);
                CollectionAssert.Contains(localItemsAfterDownload, openSubchild);
                CollectionAssert.Contains(localItemsAfterDownload, lockedSubchild);
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync_Empty()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer client = test.Container.GetStorageResourceContainer(dirName);

            ContainerTransferOptions downloadOptions = new BlobFolderDownloadOptions();

            // Act
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            BlobDataController BlobDataController = InstrumentClient(new BlobDataController(managerOptions));
            string destinationFolder = CreateRandomDirectory(folder);

            //Act
            await BlobDataController.ScheduleFolderDownloadAsync(client, destinationFolder, downloadOptions).ConfigureAwait(false);
            List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.IsEmpty(localItemsAfterDownload);

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync_SingleFile()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            StorageResourceContainer client = test.Container.GetStorageResourceContainer(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string sourceFolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(sourceFolder).ConfigureAwait(false);
            string localDirName = sourceFolder.Split('\\').Last();

            string destinationFolder = CreateRandomDirectory(folder);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            BlobDataController BlobDataController = InstrumentClient(new BlobDataController(managerOptions));
            await BlobDataController.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            Directory.Delete(folder, true);

            //Act
            await BlobDataController.ScheduleFolderDownloadAsync(client, destinationFolder, downloadOptions).ConfigureAwait(false);

            List<string> localItemsAfterDownload = Directory.GetFiles(destinationFolder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.Equals(1, localItemsAfterDownload.Count());
            AssertContentFile(openSubchild, destinationFolder + "/" + localItemsAfterDownload.First());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync_SingleSubDirectory()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            StorageResourceContainer client = test.Container.GetStorageResourceContainer(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string mainSubFolder = CreateRandomDirectory(folder);
            string sourceSubFolder = CreateRandomDirectory(mainSubFolder);
            string sourceSubChild = await CreateRandomFileAsync(sourceSubFolder).ConfigureAwait(false);

            string destinationSubfolder = CreateRandomDirectory(mainSubFolder);
            string destinationSubchild = await CreateRandomFileAsync(destinationSubfolder).ConfigureAwait(false);

            string localDirName = folder.Split('\\').Last();

            string destinationFolder = CreateRandomDirectory(folder);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            BlobDataController BlobDataController = InstrumentClient(new BlobDataController(managerOptions));
            await BlobDataController.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            Directory.Delete(folder, true);

            //Act
            await BlobDataController.ScheduleFolderDownloadAsync(client, destinationFolder, downloadOptions).ConfigureAwait(false);

            List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.Equals(1, localItemsAfterDownload.Count());
            Assert.Equals(localItemsAfterDownload.First(), destinationSubchild);
            AssertContentFile(sourceSubChild, destinationSubchild);

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync_ManySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            StorageResourceContainer client = test.Container.GetStorageResourceContainer(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string mainFolder = CreateRandomDirectory(folder);
            string souceSubFolder = CreateRandomDirectory(mainFolder);
            string openSubchild = await CreateRandomFileAsync(souceSubFolder).ConfigureAwait(false);
            string souceSubFolder2 = CreateRandomDirectory(mainFolder);
            string openSubchild2 = await CreateRandomFileAsync(souceSubFolder2).ConfigureAwait(false);
            string souceSubFolder3 = CreateRandomDirectory(mainFolder);
            string openSubchild3 = await CreateRandomFileAsync(souceSubFolder3).ConfigureAwait(false);

            string destinationFolder = CreateRandomDirectory(souceSubFolder);

            string localDirName = folder.Split('\\').Last();

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            BlobDataController BlobDataController = InstrumentClient(new BlobDataController(managerOptions));
            await BlobDataController.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            Directory.Delete(folder, true);

            //Act
            await BlobDataController.ScheduleFolderDownloadAsync(client, destinationFolder, downloadOptions).ConfigureAwait(false);

            List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(localItemsAfterDownload, openSubchild);
                CollectionAssert.Contains(localItemsAfterDownload, openSubchild2);
                CollectionAssert.Contains(localItemsAfterDownload, openSubchild3);
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task DownloadDirectoryAsync_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            StorageResourceContainer client = test.Container.GetStorageResourceContainer(dirName);

            string sourceFolder = CreateRandomDirectory(Path.GetTempPath());
            string destinationFolder = CreateRandomDirectory(Path.GetTempPath());

            string subfolderName = sourceFolder;
            for (int i = 0; i < level; i++)
            {
                string openSubfolder = CreateRandomDirectory(subfolderName);
                string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
                subfolderName = openSubfolder;
            }

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            BlobDataController BlobDataController = InstrumentClient(new BlobDataController(managerOptions));
            await BlobDataController.ScheduleFolderUploadAsync(sourceFolder, client, false, options).ConfigureAwait(false);

            Directory.Delete(sourceFolder, true);

            //Act
            await BlobDataController.ScheduleFolderDownloadAsync(client, destinationFolder, downloadOptions).ConfigureAwait(false);

            List<string> localItemsAfterDownload = Directory.GetFiles(destinationFolder, "*", SearchOption.AllDirectories).ToList();

            Assert.Equals(level, localItemsAfterDownload);

            // Cleanup
            Directory.Delete(sourceFolder, true);
            Directory.Delete(destinationFolder, true);
        }

        // This test is here just to see if DM stuff works, but shouldn't sit in here
        // (just needed to use DisposingBlobContainer). Maybe a refactor for Disposing* stuff out to a
        // test common source might be useful for DMLib tests.

        // Test is disabled as it will not function properly until _toScanQueue > _jobsToProcess
        // transition is implemented.
        [RecordedTest]
        public async Task TransferManager_UploadTwoDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            string dirName = GetNewBlobName();
            StorageResourceContainer client = test.Container.GetStorageResourceContainer(dirName);
            string dirTwoName = GetNewBlobName();
            StorageResourceContainer clientTwo = test.Container.GetStorageResourceContainer(dirTwoName);
            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string lockedChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder).ConfigureAwait(false);
            // Act
            BlobDataController manager = new BlobDataController();
            await manager.ScheduleFolderUploadAsync(folder, client).ConfigureAwait(false);
            await manager.ScheduleFolderUploadAsync(folder, clientTwo).ConfigureAwait(false);
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();
            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirTwoName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirTwoName + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirTwoName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirTwoName + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
            });
            // Cleanup
            Directory.Delete(folder, true);
        }
        #endregion DirectoryDownloadTests
        */
    }
}
