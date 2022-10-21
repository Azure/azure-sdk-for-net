// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs;
using Azure.Storage.DataMovement.Models;
using Castle.Core.Internal;
using NUnit.Framework;
using Azure.Storage.Blobs.DataMovement;

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferSyncCopyTests : DataMovementBlobTestBase
    {
        public StartTransferSyncCopyTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        internal class VerifyCopyFromUriInfo
        {
            public readonly string SourceLocalPath;
            public readonly StorageResource SourceResource;
            public readonly StorageResource DestinationResource;
            public readonly BlockBlobClient DestinationClient;
            public SingleTransferOptions CopyOptions;
            public AutoResetEvent CompletedStatusWait;

            public VerifyCopyFromUriInfo(
                string sourceLocalPath,
                StorageResource sourceResource,
                StorageResource destinationResource,
                BlockBlobClient destinationClient,
                SingleTransferOptions copyOptions,
                AutoResetEvent completedStatusWait)
            {
                SourceLocalPath = sourceLocalPath;
                SourceResource = sourceResource;
                DestinationResource = destinationResource;
                DestinationClient = destinationClient;
                CopyOptions = copyOptions;
                CompletedStatusWait = completedStatusWait;
            }
        };

        #region SyncCopy
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
        private async Task CopyBlobsAndVerify(
            BlobContainerClient container,
            long size = Constants.KB,
            int waitTimeInSec = 10,
            int blobCount = 1,
            TransferManagerOptions transferManagerOptions = default,
            List<string> blobNames = default,
            List<SingleTransferOptions> options = default)
        {
            // Populate blobNames list for number of blobs to be created
            if (blobNames.IsNullOrEmpty())
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
            if (options.IsNullOrEmpty())
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

            List<VerifyCopyFromUriInfo> copyBlobInfo = new List<VerifyCopyFromUriInfo>(blobCount);
            try
            {
                // Initialize BlobDataController
                TransferManager BlobDataController = new TransferManager(transferManagerOptions);

                // Upload set of VerifyCopyFromUriInfo blobs to Copy
                for (int i = 0; i < blobCount; i++)
                {
                    // Set up Blob to be Copyed
                    var data = GetRandomBuffer(size);
                    using Stream originalStream = await CreateLimitedMemoryStream(size);
                    string localSourceFile = Path.GetTempFileName();
                    BlockBlobClient originalBlob = InstrumentClient(container.GetBlockBlobClient(blobNames[i]));
                    StorageResource sourceResource = new BlockBlobStorageResource(originalBlob);
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

                    // Set up destination client
                    BlockBlobClient destClient = container.GetBlockBlobClient(string.Concat("dest-", blobNames[i]));
                    StorageResource destinationResource = new BlockBlobStorageResource(destClient);

                    // Set up event handler for the respective blob
                    AutoResetEvent completedStatusWait = new AutoResetEvent(false);
                    options[i].TransferStatusEventHandler += (TransferStatusEventArgs args) =>
                    {
                        // Assert
                        if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                        {
                            completedStatusWait.Set();
                        }
                        return Task.CompletedTask;
                    };
                    options[i].TransferFailedEventHandler += (TransferFailedEventArgs args) =>
                    {
                        if (args.Exception != null)
                        {
                            Assert.Fail(args.Exception.Message);
                            completedStatusWait.Set();
                        }
                        return Task.CompletedTask;
                    };

                    copyBlobInfo.Add(new VerifyCopyFromUriInfo(
                        localSourceFile,
                        sourceResource,
                        destinationResource,
                        destClient,
                        options[i],
                        completedStatusWait));
                }

                // Schedule all Copy blobs consecutively
                for (int i = 0; i < copyBlobInfo.Count; i++)
                {
                    // Act
                    await BlobDataController.StartTransferAsync(
                        copyBlobInfo[i].SourceResource,
                        copyBlobInfo[i].DestinationResource,
                        options[i]).ConfigureAwait(false);
                }

                for (int i = 0; i < copyBlobInfo.Count; i++)
                {
                    // Assert
                    Assert.IsTrue(copyBlobInfo[i].CompletedStatusWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));

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
        public async Task StartTransfer_BlockBlobToBlockBlob()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            // No Option Copy bag or manager options bag, plain Copy
            await CopyBlobsAndVerify(
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
        public async Task StartTransfer_BlockBlobToBlockBlob_Progress(long size, int waitTimeInSec)
        {
            AutoResetEvent CompletedProgressBytesWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();
            ;

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await CopyBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);

            // Assert
            Assert.IsTrue(CompletedProgressBytesWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        public async Task StartTransfer_BlockBlobToBlockBlob_EventHandler()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            int waitTimeInSec = 10;
            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();
            options.TransferStatusEventHandler += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.TransferFailedEventHandler += (TransferFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    Assert.Fail(args.Exception.Message);
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await CopyBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                options: optionsList).ConfigureAwait(false);

            // Assert
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(100, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 300)]
        [TestCase(Constants.GB, 1000)]
        public async Task StartTransfer_BlockBlobToBlockBlob_BlobSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();
            options.TransferStatusEventHandler += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.TransferFailedEventHandler += (TransferFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    Assert.Fail(args.Exception.Message);
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await CopyBlobsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                options: optionsList).ConfigureAwait(false);

            // Assert
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(2, 4 * Constants.MB, 300)]
        [TestCase(6, 4 * Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 600)]
        [TestCase(2, Constants.GB, 2000)]
        public async Task StartTransfer_BlockBlobToBlockBlob_Multiple(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await CopyBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }
        #endregion
    }
}
