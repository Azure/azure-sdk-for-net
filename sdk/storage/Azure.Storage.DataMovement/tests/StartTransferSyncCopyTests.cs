// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs;
using Azure.Storage.DataMovement.Models;
using NUnit.Framework;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Shared;

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferSyncCopyTests : DataMovementBlobTestBase
    {
        public StartTransferSyncCopyTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

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
            Assert.IsTrue(size % (Constants.KB / 2) == 0, "Cannot create page blob that's not a multiple of 512");

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

        internal class VerifyBlockBlobCopyFromUriInfo
        {
            public readonly string SourceLocalPath;
            public readonly StorageResource SourceResource;
            public readonly StorageResource DestinationResource;
            public readonly BlockBlobClient DestinationClient;
            public SingleTransferOptions CopyOptions;
            public DataTransfer DataTransfer;
            public bool CompletedStatus;
            public Exception Exception;

            public VerifyBlockBlobCopyFromUriInfo(
                string sourceLocalPath,
                StorageResource sourceResource,
                StorageResource destinationResource,
                BlockBlobClient destinationClient,
                SingleTransferOptions copyOptions,
                bool completed,
                Exception exception)
            {
                SourceLocalPath = sourceLocalPath;
                SourceResource = sourceResource;
                DestinationResource = destinationResource;
                DestinationClient = destinationClient;
                CopyOptions = copyOptions;
                CompletedStatus = completed;
                Exception = exception;
                DataTransfer = default;
            }
        };

        #region SyncCopy BlockBlob
        /// <summary>
        /// Upload the blob, then copy the contents to another blob.
        /// Then Copy the blob and verify the contents.
        ///
        /// By default in this function an event arguement will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="waitTimeInSec"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        private async Task CopyBlockBlobsAndVerify(
            BlobContainerClient container,
            long size = Constants.KB,
            int waitTimeInSec = 10,
            int blobCount = 1,
            TransferManagerOptions transferManagerOptions = default,
            List<string> sourceBlobNames = default,
            List<SingleTransferOptions> options = default)
        {
            // Populate blobNames list for number of blobs to be created
            if (sourceBlobNames == default || sourceBlobNames?.Count == 0)
            {
                sourceBlobNames ??= new List<string>();
                for (int i = 0; i < blobCount; i++)
                {
                    sourceBlobNames.Add(GetNewBlobName());
                }
            }
            else
            {
                // If blobNames is popluated make sure these number of blobs match
                Assert.AreEqual(blobCount, sourceBlobNames.Count);
            }

            // Populate blobNames list for number of blobs to be created
            if (options == default || options?.Count == 0)
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

            List<VerifyBlockBlobCopyFromUriInfo> copyBlobInfo = new List<VerifyBlockBlobCopyFromUriInfo>(blobCount);
            try
            {
                // Initialize BlobDataController
                TransferManager BlobDataController = new TransferManager(transferManagerOptions);

                // Upload set of VerifyCopyFromUriInfo blobs to Copy
                for (int i = 0; i < blobCount; i++)
                {
                    bool completed = false;
                    Exception exception = null;
                    // Set up Blob to be Copyed
                    var data = GetRandomBuffer(size);
                    using Stream originalStream = await CreateLimitedMemoryStream(size);
                    string localSourceFile = Path.GetTempFileName();
                    BlockBlobClient originalBlob = InstrumentClient(container.GetBlockBlobClient(sourceBlobNames[i]));
                    // create a new file and copy contents of stream into it, and then close the FileStream
                    // so the StagedUploadAsync call is not prevented from reading using its FileStream.
                    using (FileStream fileStream = File.Create(localSourceFile))
                    {
                        // Copy source to a file, so we can verify the source against Copyed blob later
                        await originalStream.CopyToAsync(fileStream);
                        // Upload blob to storage account
                        originalStream.Position = 0;
                        await originalBlob.UploadAsync(originalStream);
                    }

                    // Set up event handler for the respective blob
                    options[i].TransferFailed += (TransferFailedEventArgs args) =>
                    {
                        exception = args.Exception;
                        return Task.CompletedTask;
                    };

                    StorageResource sourceResource = new BlockBlobStorageResource(originalBlob);
                    // Set up destination client
                    BlockBlobClient destClient = InstrumentClient(container.GetBlockBlobClient(string.Concat("dest-", sourceBlobNames[i])));
                    StorageResource destinationResource = new BlockBlobStorageResource(destClient);
                    copyBlobInfo.Add(new VerifyBlockBlobCopyFromUriInfo(
                        localSourceFile,
                        sourceResource,
                        destinationResource,
                        destClient,
                        options[i],
                        completed,
                        exception));
                }

                // Schedule all Copy blobs consecutively
                for (int i = 0; i < copyBlobInfo.Count; i++)
                {
                    // Act
                    DataTransfer transfer = await BlobDataController.StartTransferAsync(
                        copyBlobInfo[i].SourceResource,
                        copyBlobInfo[i].DestinationResource,
                        options[i]).ConfigureAwait(false);
                    copyBlobInfo[i].DataTransfer = transfer;
                }

                for (int i = 0; i < copyBlobInfo.Count; i++)
                {
                    // Assert
                    if (copyBlobInfo[i].Exception != null)
                    {
                        Assert.Fail(copyBlobInfo[i].Exception.Message);
                    }
                    Assert.NotNull(copyBlobInfo[i].DataTransfer);
                    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                    await copyBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                    Assert.IsTrue(copyBlobInfo[i].DataTransfer.HasCompleted);

                    // Verify Copy - using original source File and Copying the destination
                    using (FileStream fileStream = File.OpenRead(copyBlobInfo[i].SourceLocalPath))
                    {
                        await DownloadAndAssertAsync(fileStream, copyBlobInfo[i].DestinationClient).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            finally
            {
                // Cleanup - temporary local files (blobs cleaned up by diposing container)
                for (int i = 0; i < copyBlobInfo.Count; i++)
                {
                    if (File.Exists(copyBlobInfo[i].SourceLocalPath))
                    {
                        File.Delete(copyBlobInfo[i].SourceLocalPath);
                    }
                }
            }
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task BlockBlobToBlockBlob()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            // No Option Copy bag or manager options bag, plain Copy
            await CopyBlockBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: 10,
                size: 0,
                blobCount: 1).ConfigureAwait(false);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task BlockBlobToBlockBlob_SmallChunk()
        {
            long size = Constants.KB;
            int waitTimeInSec = 10;

            SingleTransferOptions options = new SingleTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await CopyBlockBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task BlockBlobToBlockBlob_EventHandler()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            int waitTimeInSec = 10;
            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();
            string exceptionMessage = default;
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
            await CopyBlockBlobsAndVerify(
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
        [TestCase(5 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 400)]
        [TestCase(Constants.GB, 1000)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task BlockBlobToBlockBlob_BlobSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            SingleTransferOptions options = new SingleTransferOptions();

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await CopyBlockBlobsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(2, 4 * Constants.MB, 300)]
        [TestCase(6, 4 * Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 600)]
        [TestCase(2, Constants.GB, 2000)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task BlockBlobToBlockBlob_Multiple(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            await CopyBlockBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }
        #endregion

        internal class VerifyAppendBlobCopyFromUriInfo
        {
            public readonly string SourceLocalPath;
            public readonly StorageResource SourceResource;
            public readonly StorageResource DestinationResource;
            public readonly AppendBlobClient DestinationClient;
            public SingleTransferOptions CopyOptions;
            public DataTransfer DataTransfer;
            public bool CompletedStatus;
            public Exception Exception;

            public VerifyAppendBlobCopyFromUriInfo(
                string sourceLocalPath,
                StorageResource sourceResource,
                StorageResource destinationResource,
                AppendBlobClient destinationClient,
                SingleTransferOptions copyOptions,
                bool completed,
                Exception exception)
            {
                SourceLocalPath = sourceLocalPath;
                SourceResource = sourceResource;
                DestinationResource = destinationResource;
                DestinationClient = destinationClient;
                CopyOptions = copyOptions;
                CompletedStatus = completed;
                Exception = exception;
                DataTransfer = default;
            }
        };

        #region SyncCopy AppendBlob
        /// <summary>
        /// Upload the blob, then copy the contents to another blob.
        /// Then Copy the blob and verify the contents.
        ///
        /// By default in this function an event arguement will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="waitTimeInSec"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        private async Task CopyAppendBlobsAndVerify(
            BlobContainerClient container,
            long size = Constants.KB,
            int waitTimeInSec = 10,
            int blobCount = 1,
            TransferManagerOptions transferManagerOptions = default,
            List<string> sourceBlobNames = default,
            List<SingleTransferOptions> options = default)
        {
            // Populate blobNames list for number of blobs to be created
            if (sourceBlobNames == default || sourceBlobNames?.Count == 0)
            {
                sourceBlobNames ??= new List<string>();
                for (int i = 0; i < blobCount; i++)
                {
                    sourceBlobNames.Add(GetNewBlobName());
                }
            }
            else
            {
                // If blobNames is popluated make sure these number of blobs match
                Assert.AreEqual(blobCount, sourceBlobNames.Count);
            }

            // Populate blobNames list for number of blobs to be created
            if (options == default || options?.Count == 0)
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

            List<VerifyAppendBlobCopyFromUriInfo> copyBlobInfo = new List<VerifyAppendBlobCopyFromUriInfo>(blobCount);
            try
            {
                // Initialize BlobDataController
                TransferManager BlobDataController = new TransferManager(transferManagerOptions);

                // Upload set of VerifyCopyFromUriInfo blobs to Copy
                for (int i = 0; i < blobCount; i++)
                {
                    // Set up Blob to be Copyed
                    bool completed = false;
                    Exception exception = null;
                    var data = GetRandomBuffer(size);
                    using Stream originalStream = await CreateLimitedMemoryStream(size);
                    string localSourceFile = Path.GetTempFileName();
                    AppendBlobClient originalBlob = await CreateAppendBlob(container, localSourceFile, sourceBlobNames[i], size);

                    // Set up event handler for the respective blob
                    options[i].TransferFailed += (TransferFailedEventArgs args) =>
                    {
                        exception = args.Exception;
                        return Task.CompletedTask;
                    };

                    StorageResource sourceResource = new AppendBlobStorageResource(originalBlob);
                    // Set up destination client
                    AppendBlobClient destClient = InstrumentClient(container.GetAppendBlobClient(string.Concat("dest-", sourceBlobNames[i])));
                    StorageResource destinationResource = new AppendBlobStorageResource(destClient);
                    copyBlobInfo.Add(new VerifyAppendBlobCopyFromUriInfo(
                        localSourceFile,
                        sourceResource,
                        destinationResource,
                        destClient,
                        options[i],
                        completed,
                        exception));
                }

                // Schedule all Copy blobs consecutively
                for (int i = 0; i < copyBlobInfo.Count; i++)
                {
                    // Act
                    DataTransfer transfer = await BlobDataController.StartTransferAsync(
                        copyBlobInfo[i].SourceResource,
                        copyBlobInfo[i].DestinationResource,
                        options[i]).ConfigureAwait(false);
                    copyBlobInfo[i].DataTransfer = transfer;
                }

                for (int i = 0; i < copyBlobInfo.Count; i++)
                {
                    // Assert
                    if (copyBlobInfo[i].Exception != null)
                    {
                        Assert.Fail(copyBlobInfo[i].Exception.Message);
                    }
                    Assert.NotNull(copyBlobInfo[i].DataTransfer);
                    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                    await copyBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                    Assert.IsTrue(copyBlobInfo[i].DataTransfer.HasCompleted);

                    // Verify Copy - using original source File and Copying the destination
                    using (FileStream fileStream = File.OpenRead(copyBlobInfo[i].SourceLocalPath))
                    {
                        await DownloadAndAssertAsync(fileStream, copyBlobInfo[i].DestinationClient).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            finally
            {
                // Cleanup - temporary local files (blobs cleaned up by diposing container)
                for (int i = 0; i < copyBlobInfo.Count; i++)
                {
                    if (File.Exists(copyBlobInfo[i].SourceLocalPath))
                    {
                        File.Delete(copyBlobInfo[i].SourceLocalPath);
                    }
                }
            }
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task AppendBlobToAppendBlob()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            // No Option Copy bag or manager options bag, plain Copy
            await CopyAppendBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: 10,
                size: 0,
                blobCount: 1).ConfigureAwait(false);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task AppendBlobToAppendBlob_SmallChunk()
        {
            long size = Constants.KB;
            int waitTimeInSec = 10;

            SingleTransferOptions options = new SingleTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await CopyAppendBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task AppendBlobToAppendBlob_EventHandler()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            int waitTimeInSec = 10;
            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();
            string exceptionMessage = default;
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
            await CopyAppendBlobsAndVerify(
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
        [TestCase(5 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 400)]
        [TestCase(Constants.GB, 1000)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task AppendBlobToAppendBlob_BlobSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

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
            await CopyAppendBlobsAndVerify(
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
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task AppendBlobToAppendBlob_Multiple(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            await CopyAppendBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }
        #endregion

        #region SyncCopy PageBlob
        internal class VerifyPageBlobCopyFromUriInfo
        {
            public readonly string SourceLocalPath;
            public readonly StorageResource SourceResource;
            public readonly StorageResource DestinationResource;
            public readonly PageBlobClient DestinationClient;
            public SingleTransferOptions CopyOptions;
            public DataTransfer DataTransfer;
            public bool CompletedStatus;
            public Exception Exception;

            public VerifyPageBlobCopyFromUriInfo(
                string sourceLocalPath,
                StorageResource sourceResource,
                StorageResource destinationResource,
                PageBlobClient destinationClient,
                SingleTransferOptions copyOptions,
                bool completed,
                Exception exception)
            {
                SourceLocalPath = sourceLocalPath;
                SourceResource = sourceResource;
                DestinationResource = destinationResource;
                DestinationClient = destinationClient;
                CopyOptions = copyOptions;
                CompletedStatus = completed;
                Exception = exception;
                DataTransfer = default;
            }
        };

        /// <summary>
        /// Upload the blob, then copy the contents to another blob.
        /// Then Copy the blob and verify the contents.
        ///
        /// By default in this function an event arguement will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="waitTimeInSec"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        private async Task CopyPageBlobsAndVerify(
            BlobContainerClient container,
            long size = Constants.KB,
            int waitTimeInSec = 10,
            int blobCount = 1,
            TransferManagerOptions transferManagerOptions = default,
            List<string> sourceBlobNames = default,
            List<SingleTransferOptions> options = default)
        {
            // Populate blobNames list for number of blobs to be created
            if (sourceBlobNames == default || sourceBlobNames?.Count == 0)
            {
                sourceBlobNames ??= new List<string>();
                for (int i = 0; i < blobCount; i++)
                {
                    sourceBlobNames.Add(GetNewBlobName());
                }
            }
            else
            {
                // If blobNames is popluated make sure these number of blobs match
                Assert.AreEqual(blobCount, sourceBlobNames.Count);
            }

            // Populate blobNames list for number of blobs to be created
            if (options == default || options?.Count == 0)
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

            List<VerifyPageBlobCopyFromUriInfo> copyBlobInfo = new List<VerifyPageBlobCopyFromUriInfo>(blobCount);
            try
            {
                // Initialize BlobDataController
                TransferManager BlobDataController = new TransferManager(transferManagerOptions);

                // Upload set of VerifyCopyFromUriInfo blobs to Copy
                for (int i = 0; i < blobCount; i++)
                {
                    bool completed = false;
                    Exception exception = null;
                    // Set up Blob to be Copyed
                    var data = GetRandomBuffer(size);
                    using Stream originalStream = await CreateLimitedMemoryStream(size);
                    string localSourceFile = Path.GetTempFileName();
                    PageBlobClient originalBlob = await CreatePageBlob(container, localSourceFile, sourceBlobNames[i], size);

                    // Set up event handler for the respective blob
                    options[i].TransferFailed += (TransferFailedEventArgs args) =>
                    {
                        exception = args.Exception;
                        return Task.CompletedTask;
                    };

                    StorageResource sourceResource = new PageBlobStorageResource(originalBlob);
                    // Set up destination client
                    PageBlobClient destClient = InstrumentClient(container.GetPageBlobClient(string.Concat("dest-", sourceBlobNames[i])));
                    StorageResource destinationResource = new PageBlobStorageResource(destClient);
                    copyBlobInfo.Add(new VerifyPageBlobCopyFromUriInfo(
                        localSourceFile,
                        sourceResource,
                        destinationResource,
                        destClient,
                        options[i],
                        completed,
                        exception));
                }

                // Schedule all Copy blobs consecutively
                for (int i = 0; i < copyBlobInfo.Count; i++)
                {
                    // Act
                    DataTransfer dataTransfer = await BlobDataController.StartTransferAsync(
                        copyBlobInfo[i].SourceResource,
                        copyBlobInfo[i].DestinationResource,
                        options[i]).ConfigureAwait(false);
                    copyBlobInfo[i].DataTransfer = dataTransfer;
                }

                for (int i = 0; i < copyBlobInfo.Count; i++)
                {
                    // Assert
                    if (copyBlobInfo[i].Exception != null)
                    {
                        Assert.Fail(copyBlobInfo[i].Exception.Message);
                    }
                    Assert.NotNull(copyBlobInfo[i].DataTransfer);
                    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                    await copyBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                    Assert.IsTrue(copyBlobInfo[i].DataTransfer.HasCompleted);

                    // Verify Copy - using original source File and Copying the destination
                    using (FileStream fileStream = File.OpenRead(copyBlobInfo[i].SourceLocalPath))
                    {
                        await DownloadAndAssertAsync(fileStream, copyBlobInfo[i].DestinationClient).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            finally
            {
                // Cleanup - temporary local files (blobs cleaned up by diposing container)
                for (int i = 0; i < copyBlobInfo.Count; i++)
                {
                    if (File.Exists(copyBlobInfo[i].SourceLocalPath))
                    {
                        File.Delete(copyBlobInfo[i].SourceLocalPath);
                    }
                }
            }
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task PageBlobToPageBlob()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            // No Option Copy bag or manager options bag, plain Copy
            await CopyPageBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: 10,
                size: 0,
                blobCount: 1).ConfigureAwait(false);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task PageBlobToPageBlob_SmallChunk()
        {
            long size = 12 * Constants.KB;
            int waitTimeInSec = 10;

            SingleTransferOptions options = new SingleTransferOptions()
            {
                InitialTransferSize = Constants.KB,
                MaximumTransferChunkSize = Constants.KB,
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await CopyPageBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task PageBlobToPageBlob_EventHandler()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            int waitTimeInSec = 10;
            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();
            string exceptionMessage = default;
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
            await CopyPageBlobsAndVerify(
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
        [TestCase(257 * Constants.MB, 200)]
        [TestCase(Constants.GB, 500)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task PageBlobToPageBlob_BlobSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

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
            await CopyPageBlobsAndVerify(
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
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task PageBlobToPageBlob_Multiple(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            await CopyPageBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }
        #endregion
    }
}
