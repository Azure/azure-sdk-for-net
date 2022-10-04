// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.Blobs.DataMovement.Tests.Shared;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement;
using Castle.Core.Internal;
using NUnit.Framework;

namespace Azure.Storage.Blobs.DataMovement.Tests
{
    public class BlobServiceCopyTests : DataMovementBlobTestBase
    {
        public BlobServiceCopyTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        internal class VerifyCopyFromUriInfo
        {
            public readonly string SourceLocalPath;
            public readonly Uri SourceUri;
            public readonly BlockBlobClient DestinationClient;
            public BlobSingleCopyOptions CopyOptions;
            public AutoResetEvent CompletedStatusWait;

            public VerifyCopyFromUriInfo(
                string sourceLocalPath,
                Uri sourceUri,
                BlockBlobClient destinationClient,
                BlobSingleCopyOptions copyOptions,
                AutoResetEvent completedStatusWait)
            {
                SourceLocalPath = sourceLocalPath;
                SourceUri = sourceUri;
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
            StorageTransferManagerOptions transferManagerOptions = default,
            List<string> blobNames = default,
            BlobCopyMethod copyMethod = BlobCopyMethod.Copy,
            List<BlobSingleCopyOptions> options = default)
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
                options ??= new List<BlobSingleCopyOptions>(blobCount);
                for (int i = 0; i < blobCount; i++)
                {
                    options.Add(new BlobSingleCopyOptions());
                }
            }
            else
            {
                // If blobNames is popluated make sure these number of blobs match
                Assert.AreEqual(blobCount, options.Count);
            }

            transferManagerOptions ??= new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };

            List<VerifyCopyFromUriInfo> copyBlobInfo = new List<VerifyCopyFromUriInfo>(blobCount);
            try
            {
                // Initialize BlobTransferManager
                BlobTransferManager blobTransferManager = new BlobTransferManager(transferManagerOptions);

                // Upload set of VerifyCopyFromUriInfo blobs to Copy
                for (int i = 0; i < blobCount; i++)
                {
                    // Set up Blob to be Copyed
                    var data = GetRandomBuffer(size);
                    using Stream originalStream = await CreateLimitedMemoryStream(size);
                    string localSourceFile = Path.GetTempFileName();
                    BlobClient originalBlob = InstrumentClient(container.GetBlobClient(blobNames[i]));
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

                    // Set up event handler for the respective blob
                    AutoResetEvent completedStatusWait = new AutoResetEvent(false);
                    options[i].TransferStatusEventHandler += (StorageTransferStatusEventArgs args) =>
                    {
                        // Assert
                        if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                        {
                            completedStatusWait.Set();
                        }
                        return Task.CompletedTask;
                    };
                    options[i].CopyFailedEventHandler += (BlobSingleCopyFailedEventArgs args) =>
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
                        originalBlob.Uri,
                        destClient,
                        options[i],
                        completedStatusWait));
                }

                // Schedule all Copy blobs consecutively
                for (int i = 0; i < copyBlobInfo.Count; i++)
                {
                    // Act
                    await blobTransferManager.ScheduleCopyAsync(
                        sourceUri: copyBlobInfo[i].SourceUri,
                        destinationClient: copyBlobInfo[i].DestinationClient,
                        copyMethod: copyMethod,
                        copyOptions: options[i]).ConfigureAwait(false);
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
        public async Task ScheduleSyncCopy()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            // No Option Copy bag or manager options bag, plain Copy
            await CopyBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: 10,
                size: 0,
                copyMethod: BlobCopyMethod.SyncCopy,
                blobCount: 1).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 400)]
        [TestCase(Constants.GB, 800)]
        public async Task ScheduleSyncCopy_Progress(long size, int waitTimeInSec)
        {
            AutoResetEvent CompletedProgressBytesWait = new AutoResetEvent(false);
            BlobSingleCopyOptions options = new BlobSingleCopyOptions()
            {
                ProgressHandler = new CheckBlobCompletionProgress(size, CompletedProgressBytesWait)
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<BlobSingleCopyOptions> optionsList = new List<BlobSingleCopyOptions>() { options };
            await CopyBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                copyMethod: BlobCopyMethod.SyncCopy,
                options: optionsList).ConfigureAwait(false);

            // Assert
            Assert.IsTrue(CompletedProgressBytesWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        public async Task ScheduleSyncCopy_EventHandler()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            int waitTimeInSec = 10;
            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            BlobSingleCopyOptions options = new BlobSingleCopyOptions();
            options.TransferStatusEventHandler += (StorageTransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.CopyFailedEventHandler += (BlobSingleCopyFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    Assert.Fail(args.Exception.Message);
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };

            List<BlobSingleCopyOptions> optionsList = new List<BlobSingleCopyOptions>() { options };
            await CopyBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                copyMethod: BlobCopyMethod.SyncCopy,
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
        public async Task ScheduleSyncCopy_BlobSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            BlobSingleCopyOptions options = new BlobSingleCopyOptions();
            options.TransferStatusEventHandler += (StorageTransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.CopyFailedEventHandler += (BlobSingleCopyFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    Assert.Fail(args.Exception.Message);
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };

            List<BlobSingleCopyOptions> optionsList = new List<BlobSingleCopyOptions>() { options };
            await CopyBlobsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                copyMethod: BlobCopyMethod.SyncCopy,
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
        public async Task ScheduleSyncCopy_Multiple(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await CopyBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                copyMethod: BlobCopyMethod.SyncCopy,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }
        #endregion
    }
}
