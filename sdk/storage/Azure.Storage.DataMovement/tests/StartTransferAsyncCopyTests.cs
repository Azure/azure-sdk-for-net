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

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferAsyncCopyTests : DataMovementBlobTestBase
    {
        public StartTransferAsyncCopyTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        internal class VerifyBlockCopyFromUriInfo
        {
            public readonly string SourceLocalPath;
            public readonly StorageResource SourceResource;
            public readonly StorageResource DestinationResource;
            public readonly BlockBlobClient DestinationClient;
            public SingleTransferOptions CopyOptions;
            public DataTransfer DataTransfer;
            public bool CompletedStatus;
            public Exception Exception;

            public VerifyBlockCopyFromUriInfo(
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

        internal class VerifyPageCopyFromUriInfo
        {
            public readonly string SourceLocalPath;
            public readonly StorageResource SourceResource;
            public readonly StorageResource DestinationResource;
            public readonly PageBlobClient DestinationClient;
            public SingleTransferOptions CopyOptions;
            public DataTransfer DataTransfer;
            public bool CompletedStatus;
            public Exception Exception;

            public VerifyPageCopyFromUriInfo(
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

        internal class VerifyAppendCopyFromUriInfo
        {
            public readonly string SourceLocalPath;
            public readonly StorageResource SourceResource;
            public readonly StorageResource DestinationResource;
            public readonly AppendBlobClient DestinationClient;
            public SingleTransferOptions CopyOptions;
            public DataTransfer DataTransfer;
            public bool CompletedStatus;
            public Exception Exception;

            public VerifyAppendCopyFromUriInfo(
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

        #region SyncCopy Source Block Blob
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
            List<string> destinationBlobNames = default,
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
            if (destinationBlobNames == default || destinationBlobNames?.Count == 0)
            {
                destinationBlobNames ??= new List<string>();
                for (int i = 0; i < blobCount; i++)
                {
                    destinationBlobNames.Add(GetNewBlobName());
                }
            }
            else
            {
                // If blobNames is popluated make sure these number of blobs match
                Assert.AreEqual(blobCount, destinationBlobNames.Count);
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

            List<VerifyBlockCopyFromUriInfo> copyBlobInfo = new List<VerifyBlockCopyFromUriInfo>(blobCount);
            try
            {
                // Initialize BlobDataController
                TransferManager transferManager = new TransferManager(transferManagerOptions);

                // Upload set of VerifyCopyFromUriInfo blobs to Copy
                for (int i = 0; i < blobCount; i++)
                {
                    bool completed = false;
                    Exception exception = null;
                    // Set up Blob to be Copyed
                    using Stream originalStream = await CreateLimitedMemoryStream(size);
                    string localSourceFile = Path.GetTempFileName();
                    BlockBlobClient originalBlob = await CreateBlockBlob(container, localSourceFile, sourceBlobNames[i], size);

                    // Set up event handler for the respective blob
                    AutoResetEvent completedStatusWait = new AutoResetEvent(false);
                    options[i].TransferFailed += (TransferFailedEventArgs args) =>
                    {
                        exception = args.Exception;
                        return Task.CompletedTask;
                    };

                    StorageResource sourceResource = new BlockBlobStorageResource(originalBlob);
                    // Set up destination client
                    BlockBlobClient destClient = InstrumentClient(container.GetBlockBlobClient(string.Concat(destinationBlobNames[i])));
                    StorageResource destinationResource = new BlockBlobStorageResource(destClient,
                        new BlockBlobStorageResourceOptions()
                        {
                            CopyMethod = TransferCopyMethod.AsyncCopy,
                        });
                    copyBlobInfo.Add(new VerifyBlockCopyFromUriInfo(
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
                    DataTransfer transfer = await transferManager.StartTransferAsync(
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
        public async Task BlockBlobToBlockBlob_SmallChunks()
        {
            long size = Constants.KB;
            int waitTimeInSec = 10;

            SingleTransferOptions options = new SingleTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            // No Option Copy bag or manager options bag, plain Copy
            await CopyBlockBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task BlockBlobToBlockBlob_SmallProgress()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await CopyBlockBlobsAndVerify(testContainer.Container).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task BlockBlobToBlockBlob_EventHandler()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

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
            await CopyBlockBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                options: optionsList).ConfigureAwait(false);

            Assert.IsTrue(progressSeen);
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(100, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(2 * Constants.KB, 10)]
        public async Task BlockBlobToBlockBlob_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            await CopyBlockBlobsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 400)]
        [TestCase(400 * Constants.MB, 400)]
        [TestCase(800 * Constants.MB, 400)]
        [TestCase(Constants.GB, 1000)]
        public async Task BlockBlobToBlockBlob_LargeSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            await CopyBlockBlobsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33003")]
        [Test]
        [LiveOnly]
        [TestCase(2, 0, 30)]
        [TestCase(6, 0, 30)]
        [TestCase(2, 100, 30)]
        [TestCase(6, 100, 30)]
        [TestCase(2, Constants.KB, 300)]
        [TestCase(6, Constants.KB, 300)]
        public async Task BlockBlobToBlockBlob_SmallMultiple(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            await CopyBlockBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(2, 4 * Constants.MB, 300)]
        [TestCase(6, 4 * Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 600)]
        [TestCase(2, Constants.GB, 2000)]
        public async Task BlockBlobToBlockBlob_LargeMultiple(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            await CopyBlockBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task BlockBlobToPageBlob_ExpectedError()
        {
            // Arrange
            Exception exception = default;
            bool sourceResourceCheck = false;
            bool destinationResourceCheck = false;
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            int size = Constants.KB;

            // Act
            // Create options bag to fail and keep track of the failure.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            // Create new source block blob.
            string newSourceFile = Path.GetTempFileName();
            BlockBlobClient blockBlobClient = await CreateBlockBlob(
                testContainer.Container,
                newSourceFile,
                GetNewBlobName(),
                size);

            // Create destination of a blob type that's not the same as the source
            PageBlobClient pageBlobClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());
            await pageBlobClient.CreateAsync(size);
            StorageResource sourceResource = new BlockBlobStorageResource(blockBlobClient);
            StorageResource destinationResource = new PageBlobStorageResource(
                pageBlobClient,
                new PageBlobStorageResourceOptions()
                {
                    CopyMethod = TransferCopyMethod.AsyncCopy,
                });
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                // We can't Assert here or else it takes down everything.
                if (args.Exception != default)
                {
                    exception = args.Exception;
                }
                if (args.SourceResource.Path == sourceResource.Path)
                {
                    sourceResourceCheck = true;
                }
                if (args.DestinationResource.Uri == destinationResource.Uri)
                {
                    destinationResourceCheck = true;
                }
                return Task.CompletedTask;
            };
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            Assert.IsTrue(sourceResourceCheck);
            Assert.IsTrue(destinationResourceCheck);
            Assert.NotNull(exception, "Excepted failure: Failure was supposed to be raised during the test");
            Assert.IsTrue(exception.Message.Contains("The blob type is invalid for this operation."));
        }

        [RecordedTest]
        public async Task BlockBlobToAppendBlob_ExpectedError()
        {
            // Arrange
            Exception exception = default;
            bool sourceResourceCheck = false;
            bool destinationResourceCheck = false;
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            int size = Constants.KB;

            // Act
            // Create options bag to fail and keep track of the failure.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            // Create new source block blob.
            string newSourceFile = Path.GetTempFileName();
            BlockBlobClient blockBlobClient = await CreateBlockBlob(
                testContainer.Container,
                newSourceFile,
                GetNewBlobName(),
                size);

            // Create destination of a blob type that's not the same as the source
            AppendBlobClient appendBlobClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());
            await appendBlobClient.CreateAsync();

            StorageResource sourceResource = new BlockBlobStorageResource(blockBlobClient);
            StorageResource destinationResource = new AppendBlobStorageResource(
                appendBlobClient,
                new AppendBlobStorageResourceOptions()
                {
                    CopyMethod = TransferCopyMethod.AsyncCopy,
                });
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                // We can't Assert here or else it takes down everything.
                if (args.Exception != default)
                {
                    exception = args.Exception;
                }
                if (args.SourceResource.Path == sourceResource.Path)
                {
                    sourceResourceCheck = true;
                }
                if (args.DestinationResource.Uri == destinationResource.Uri)
                {
                    destinationResourceCheck = true;
                }
                return Task.CompletedTask;
            };
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            Assert.IsTrue(sourceResourceCheck);
            Assert.IsTrue(destinationResourceCheck);
            Assert.NotNull(exception, "Excepted failure: Failure was supposed to be raised during the test");
            Assert.IsTrue(exception.Message.Contains("The blob type is invalid for this operation."));
        }

        [RecordedTest]
        public async Task BlockBlobToBlockBlob_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            // Create blob
            BlockBlobClient destClient = await CreateBlockBlob(testContainer.Container, localSourceFile, blobName, size);

            // Act
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            List<string> blobNames = new List<string>() { blobName };

            // Start transfer and await for completion.
            await CopyBlockBlobsAndVerify(
                container: testContainer.Container,
                destinationBlobNames: blobNames,
                options: optionsList);
        }

        [RecordedTest]
        public async Task BlockBlobToBlockBlob_Overwrite_NotExists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            int size = Constants.KB;
            int waitTimeInSec = 10;

            // Act
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };

            // Start transfer and await for completion.
            await CopyBlockBlobsAndVerify(
                container: testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                options: optionsList);
        }

        [RecordedTest]
        public async Task BlockBlobToBlockBlob_Skip_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            bool skippedSeen = false;
            BlockBlobClient destinationClient = await CreateBlockBlob(
                testContainer.Container,
                originalSourceFile,
                blobName,
                size);

            // Act
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip,
            };

            // Create new source block blob.
            string newSourceFile = Path.GetTempFileName();
            BlockBlobClient blockBlobClient = await CreateBlockBlob(
                testContainer.Container,
                newSourceFile,
                GetNewBlobName(),
                size);
            StorageResource sourceResource = new BlockBlobStorageResource(blockBlobClient);
            StorageResource destinationResource = new BlockBlobStorageResource(destinationClient,
                new BlockBlobStorageResourceOptions()
                {
                    CopyMethod = TransferCopyMethod.AsyncCopy,
                });
            options.TransferSkipped += (TransferSkippedEventArgs args) =>
            {
                if (args.SourceResource.Path == sourceResource.Path &&
                    args.DestinationResource.Uri == destinationResource.Uri &&
                    args.TransferId != null)
                {
                    skippedSeen = true;
                }
                return Task.CompletedTask;
            };
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
            Assert.IsTrue(skippedSeen);
            Assert.IsTrue(await destinationClient.ExistsAsync());
            // Verify Upload - That we skipped over and didn't reupload something new.
            using (FileStream fileStream = File.OpenRead(originalSourceFile))
            {
                await DownloadAndAssertAsync(fileStream, destinationClient);
            }
        }

        [RecordedTest]
        public async Task BlockBlobToBlockBlob_Failure_Exists()
        {
            // Arrange
            Exception exception = default;
            bool sourceResourceCheck = false;
            bool destinationResourceCheck = false;

            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            BlockBlobClient destinationClient = await CreateBlockBlob(testContainer.Container, originalSourceFile, blobName, size);

            // Act
            // Create options bag to fail and keep track of the failure.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            // Create new source block blob.
            string newSourceFile = Path.GetTempFileName();
            BlockBlobClient blockBlobClient = await CreateBlockBlob(
                testContainer.Container,
                newSourceFile,
                GetNewBlobName(),
                size);
            StorageResource sourceResource = new BlockBlobStorageResource(blockBlobClient);
            StorageResource destinationResource = new BlockBlobStorageResource(destinationClient,
                new BlockBlobStorageResourceOptions()
                {
                    CopyMethod = TransferCopyMethod.AsyncCopy,
                });
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                // We can't Assert here or else it takes down everything.
                if (args.Exception != default)
                {
                    exception = args.Exception;
                }
                if (args.SourceResource.Path == sourceResource.Path)
                {
                    sourceResourceCheck = true;
                }
                if (args.DestinationResource.Uri == destinationResource.Uri)
                {
                    destinationResourceCheck = true;
                }
                return Task.CompletedTask;
            };
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            Assert.IsTrue(await destinationClient.ExistsAsync());
            Assert.IsTrue(sourceResourceCheck);
            Assert.IsTrue(destinationResourceCheck);
            Assert.NotNull(exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.IsTrue(exception.Message.Contains("The specified blob already exists."));
            // Verify Upload - That we skipped over and didn't reupload something new.
            using (FileStream fileStream = File.OpenRead(originalSourceFile))
            {
                await DownloadAndAssertAsync(fileStream, destinationClient);
            }
        }
        #endregion AsyncCopy Source Block Blob

        #region AsyncCopy Source PageBlob
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
            List<string> destinationBlobNames = default,
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
            if (destinationBlobNames == default || destinationBlobNames?.Count == 0)
            {
                destinationBlobNames ??= new List<string>();
                for (int i = 0; i < blobCount; i++)
                {
                    destinationBlobNames.Add(GetNewBlobName());
                }
            }
            else
            {
                // If blobNames is popluated make sure these number of blobs match
                Assert.AreEqual(blobCount, destinationBlobNames.Count);
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

            List<VerifyPageCopyFromUriInfo> copyBlobInfo = new List<VerifyPageCopyFromUriInfo>(blobCount);
            try
            {
                // Initialize BlobDataController
                TransferManager transferManager = new TransferManager(transferManagerOptions);

                // Upload set of VerifyCopyFromUriInfo blobs to Copy
                for (int i = 0; i < blobCount; i++)
                {
                    bool completed = false;
                    Exception exception = null;
                    // Set up Blob to be Copyed
                    using Stream originalStream = await CreateLimitedMemoryStream(size);
                    string localSourceFile = Path.GetTempFileName();
                    PageBlobClient originalBlob = await CreatePageBlob(container, localSourceFile, sourceBlobNames[i], size);

                    // Set up event handler for the respective blob
                    AutoResetEvent completedStatusWait = new AutoResetEvent(false);
                    options[i].TransferFailed += (TransferFailedEventArgs args) =>
                    {
                        exception = args.Exception;
                        return Task.CompletedTask;
                    };

                    StorageResource sourceResource = new PageBlobStorageResource(originalBlob);
                    // Set up destination client
                    PageBlobClient destClient = InstrumentClient(container.GetPageBlobClient(string.Concat(destinationBlobNames[i])));
                    StorageResource destinationResource = new PageBlobStorageResource(destClient,
                        new PageBlobStorageResourceOptions()
                        {
                            CopyMethod = TransferCopyMethod.AsyncCopy,
                        });
                    copyBlobInfo.Add(new VerifyPageCopyFromUriInfo(
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
                    DataTransfer transfer = await transferManager.StartTransferAsync(
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
        public async Task PageBlobToPageBlob_SmallChunks()
        {
            long size = Constants.KB;
            int waitTimeInSec = 10;

            SingleTransferOptions options = new SingleTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            // No Option Copy bag or manager options bag, plain Copy
            await CopyPageBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task PageBlobToPageBlob_SmallProgress()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await CopyPageBlobsAndVerify(testContainer.Container).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task PageBlobToPageBlob_EventHandler()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

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
            await CopyPageBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                options: optionsList).ConfigureAwait(false);

            Assert.IsTrue(progressSeen);
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(512, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(2 * Constants.KB, 10)]
        public async Task PageBlobToPageBlob_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            await CopyPageBlobsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 400)]
        [TestCase(400 * Constants.MB, 400)]
        [TestCase(800 * Constants.MB, 400)]
        [TestCase(Constants.GB, 1000)]
        public async Task PageBlobToPageBlob_LargeSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            await CopyPageBlobsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33003")]
        [Test]
        [LiveOnly]
        [TestCase(2, 0, 30)]
        [TestCase(6, 0, 30)]
        [TestCase(2, 100, 30)]
        [TestCase(6, 100, 30)]
        [TestCase(2, Constants.KB, 300)]
        [TestCase(6, Constants.KB, 300)]
        public async Task PageBlobToPageBlob_SmallMultiple(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            await CopyPageBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(2, 4 * Constants.MB, 300)]
        [TestCase(6, 4 * Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 600)]
        [TestCase(2, Constants.GB, 2000)]
        public async Task PageBlobToPageBlob_LargeMultiple(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            await CopyPageBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task PageBlobToPageBlob_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            // Create blob
            PageBlobClient destClient = await CreatePageBlob(testContainer.Container, localSourceFile, blobName, size);

            // Act
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            List<string> blobNames = new List<string>() { blobName };

            // Start transfer and await for completion.
            await CopyPageBlobsAndVerify(
                container: testContainer.Container,
                destinationBlobNames: blobNames,
                options: optionsList);
        }

        [RecordedTest]
        public async Task PageBlobToPageBlob_Overwrite_NotExists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            int size = Constants.KB;
            int waitTimeInSec = 10;

            // Act
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };

            // Start transfer and await for completion.
            await CopyPageBlobsAndVerify(
                container: testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                options: optionsList);
        }

        [RecordedTest]
        public async Task PageBlobToPageBlob_Skip_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            bool skippedSeen = false;
            PageBlobClient destinationClient = await CreatePageBlob(
                testContainer.Container,
                originalSourceFile,
                blobName,
                size);

            // Act
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip,
            };

            // Create new source block blob.
            string newSourceFile = Path.GetTempFileName();
            PageBlobClient blockBlobClient = await CreatePageBlob(
                testContainer.Container,
                newSourceFile,
                GetNewBlobName(),
                size);
            StorageResource sourceResource = new PageBlobStorageResource(blockBlobClient);
            StorageResource destinationResource = new PageBlobStorageResource(destinationClient,
                new PageBlobStorageResourceOptions()
                {
                    CopyMethod = TransferCopyMethod.AsyncCopy,
                });
            options.TransferSkipped += (TransferSkippedEventArgs args) =>
            {
                if (args.SourceResource.Path == sourceResource.Path &&
                    args.DestinationResource.Uri == destinationResource.Uri &&
                    args.TransferId != null)
                {
                    skippedSeen = true;
                }
                return Task.CompletedTask;
            };
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
            Assert.IsTrue(skippedSeen);
            Assert.IsTrue(await destinationClient.ExistsAsync());
            // Verify Upload - That we skipped over and didn't reupload something new.
            using (FileStream fileStream = File.OpenRead(originalSourceFile))
            {
                await DownloadAndAssertAsync(fileStream, destinationClient);
            }
        }

        [RecordedTest]
        public async Task PageBlobToPageBlob_Failure_Exists()
        {
            // Arrange
            Exception exception = default;
            bool sourceResourceCheck = false;
            bool destinationResourceCheck = false;

            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            PageBlobClient destinationClient = await CreatePageBlob(testContainer.Container, originalSourceFile, blobName, size);

            // Act
            // Create options bag to fail and keep track of the failure.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            // Create new source block blob.
            string newSourceFile = Path.GetTempFileName();
            PageBlobClient blockBlobClient = await CreatePageBlob(
                testContainer.Container,
                newSourceFile,
                GetNewBlobName(),
                size);
            StorageResource sourceResource = new PageBlobStorageResource(blockBlobClient);
            StorageResource destinationResource = new PageBlobStorageResource(destinationClient,
                new PageBlobStorageResourceOptions()
                {
                    CopyMethod = TransferCopyMethod.AsyncCopy,
                });
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                // We can't Assert here or else it takes down everything.
                if (args.Exception != default)
                {
                    exception = args.Exception;
                }
                if (args.SourceResource.Path == sourceResource.Path)
                {
                    sourceResourceCheck = true;
                }
                if (args.DestinationResource.Uri == destinationResource.Uri)
                {
                    destinationResourceCheck = true;
                }
                return Task.CompletedTask;
            };
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            Assert.IsTrue(await destinationClient.ExistsAsync());
            Assert.IsTrue(sourceResourceCheck);
            Assert.IsTrue(destinationResourceCheck);
            Assert.NotNull(exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.IsTrue(exception.Message.Contains("The specified blob already exists."));
            // Verify Upload - That we skipped over and didn't reupload something new.
            using (FileStream fileStream = File.OpenRead(originalSourceFile))
            {
                await DownloadAndAssertAsync(fileStream, destinationClient);
            }
        }
        #endregion AsyncCopy Source PageBlob

        #region AsyncCopy Source AppendBlob
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
            List<string> destinationBlobNames = default,
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
            if (destinationBlobNames == default || destinationBlobNames?.Count == 0)
            {
                destinationBlobNames ??= new List<string>();
                for (int i = 0; i < blobCount; i++)
                {
                    destinationBlobNames.Add(GetNewBlobName());
                }
            }
            else
            {
                // If blobNames is popluated make sure these number of blobs match
                Assert.AreEqual(blobCount, destinationBlobNames.Count);
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

            List<VerifyAppendCopyFromUriInfo> copyBlobInfo = new List<VerifyAppendCopyFromUriInfo>(blobCount);
            try
            {
                // Initialize BlobDataController
                TransferManager transferManager = new TransferManager(transferManagerOptions);

                // Upload set of VerifyCopyFromUriInfo blobs to Copy
                for (int i = 0; i < blobCount; i++)
                {
                    bool completed = false;
                    Exception exception = null;
                    // Set up Blob to be Copyed
                    using Stream originalStream = await CreateLimitedMemoryStream(size);
                    string localSourceFile = Path.GetTempFileName();
                    AppendBlobClient originalBlob = await CreateAppendBlob(container, localSourceFile, sourceBlobNames[i], size);

                    // Set up event handler for the respective blob
                    AutoResetEvent completedStatusWait = new AutoResetEvent(false);
                    options[i].TransferFailed += (TransferFailedEventArgs args) =>
                    {
                        exception = args.Exception;
                        return Task.CompletedTask;
                    };

                    StorageResource sourceResource = new AppendBlobStorageResource(originalBlob);
                    // Set up destination client
                    AppendBlobClient destClient = InstrumentClient(container.GetAppendBlobClient(string.Concat(destinationBlobNames[i])));
                    StorageResource destinationResource = new AppendBlobStorageResource(destClient,
                        new AppendBlobStorageResourceOptions()
                        {
                            CopyMethod = TransferCopyMethod.AsyncCopy,
                        });
                    copyBlobInfo.Add(new VerifyAppendCopyFromUriInfo(
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
                    DataTransfer transfer = await transferManager.StartTransferAsync(
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
        public async Task AppendBlobToAppendBlob_SmallChunks()
        {
            long size = Constants.KB;
            int waitTimeInSec = 10;

            SingleTransferOptions options = new SingleTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            // No Option Copy bag or manager options bag, plain Copy
            await CopyAppendBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task AppendBlobToAppendBlob_SmallProgress()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await CopyAppendBlobsAndVerify(testContainer.Container).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task AppendBlobToAppendBlob_EventHandler()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

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
            await CopyAppendBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                options: optionsList).ConfigureAwait(false);

            Assert.IsTrue(progressSeen);
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(512, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(2 * Constants.KB, 10)]
        public async Task AppendBlobToAppendBlob_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            await CopyAppendBlobsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 400)]
        [TestCase(400 * Constants.MB, 400)]
        [TestCase(800 * Constants.MB, 400)]
        [TestCase(Constants.GB, 1000)]
        public async Task AppendBlobToAppendBlob_LargeSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            await CopyAppendBlobsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33003")]
        [Test]
        [LiveOnly]
        [TestCase(2, 0, 30)]
        [TestCase(6, 0, 30)]
        [TestCase(2, 100, 30)]
        [TestCase(6, 100, 30)]
        [TestCase(2, Constants.KB, 300)]
        [TestCase(6, Constants.KB, 300)]
        public async Task AppendBlobToAppendBlob_SmallMultiple(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            await CopyAppendBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(2, 4 * Constants.MB, 300)]
        [TestCase(6, 4 * Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 600)]
        [TestCase(2, Constants.GB, 2000)]
        public async Task AppendBlobToAppendBlob_LargeMultiple(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            await CopyAppendBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task AppendBlobToAppendBlob_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            // Create blob
            AppendBlobClient destClient = await CreateAppendBlob(testContainer.Container, localSourceFile, blobName, size);

            // Act
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            List<string> blobNames = new List<string>() { blobName };

            // Start transfer and await for completion.
            await CopyAppendBlobsAndVerify(
                container: testContainer.Container,
                destinationBlobNames: blobNames,
                options: optionsList);
        }

        [RecordedTest]
        public async Task AppendBlobToAppendBlob_Overwrite_NotExists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            int size = Constants.KB;
            int waitTimeInSec = 10;

            // Act
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };

            // Start transfer and await for completion.
            await CopyAppendBlobsAndVerify(
                container: testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                options: optionsList);
        }

        [RecordedTest]
        public async Task AppendBlobToAppendBlob_Skip_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            bool skippedSeen = false;
            AppendBlobClient destinationClient = await CreateAppendBlob(
                testContainer.Container,
                originalSourceFile,
                blobName,
                size);

            // Act
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip,
            };

            // Create new source block blob.
            string newSourceFile = Path.GetTempFileName();
            AppendBlobClient blockBlobClient = await CreateAppendBlob(
                testContainer.Container,
                newSourceFile,
                GetNewBlobName(),
                size);
            StorageResource sourceResource = new AppendBlobStorageResource(blockBlobClient);
            StorageResource destinationResource = new AppendBlobStorageResource(destinationClient,
                new AppendBlobStorageResourceOptions()
                {
                    CopyMethod = TransferCopyMethod.AsyncCopy,
                });
            options.TransferSkipped += (TransferSkippedEventArgs args) =>
            {
                if (args.SourceResource.Path == sourceResource.Path &&
                    args.DestinationResource.Uri == destinationResource.Uri &&
                    args.TransferId != null)
                {
                    skippedSeen = true;
                }
                return Task.CompletedTask;
            };
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
            Assert.IsTrue(skippedSeen);
            Assert.IsTrue(await destinationClient.ExistsAsync());
            // Verify Upload - That we skipped over and didn't reupload something new.
            using (FileStream fileStream = File.OpenRead(originalSourceFile))
            {
                await DownloadAndAssertAsync(fileStream, destinationClient);
            }
        }

        [RecordedTest]
        public async Task AppendBlobToAppendBlob_Failure_Exists()
        {
            // Arrange
            Exception exception = default;
            bool sourceResourceCheck = false;
            bool destinationResourceCheck = false;

            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            AppendBlobClient destinationClient = await CreateAppendBlob(testContainer.Container, originalSourceFile, blobName, size);

            // Act
            // Create options bag to fail and keep track of the failure.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            // Create new source block blob.
            string newSourceFile = Path.GetTempFileName();
            AppendBlobClient blockBlobClient = await CreateAppendBlob(
                testContainer.Container,
                newSourceFile,
                GetNewBlobName(),
                size);
            StorageResource sourceResource = new AppendBlobStorageResource(blockBlobClient);
            StorageResource destinationResource = new AppendBlobStorageResource(destinationClient,
                new AppendBlobStorageResourceOptions()
                {
                    CopyMethod = TransferCopyMethod.AsyncCopy,
                });
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                // We can't Assert here or else it takes down everything.
                if (args.Exception != default)
                {
                    exception = args.Exception;
                }
                if (args.SourceResource.Path == sourceResource.Path)
                {
                    sourceResourceCheck = true;
                }
                if (args.DestinationResource.Uri == destinationResource.Uri)
                {
                    destinationResourceCheck = true;
                }
                return Task.CompletedTask;
            };
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            Assert.IsTrue(await destinationClient.ExistsAsync());
            Assert.IsTrue(sourceResourceCheck);
            Assert.IsTrue(destinationResourceCheck);
            Assert.NotNull(exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.IsTrue(exception.Message.Contains("The specified blob already exists."));
            // Verify Upload - That we skipped over and didn't reupload something new.
            using (FileStream fileStream = File.OpenRead(originalSourceFile))
            {
                await DownloadAndAssertAsync(fileStream, destinationClient);
            }
        }
        #endregion AsyncCopy Source AppendBlob
    }
}
