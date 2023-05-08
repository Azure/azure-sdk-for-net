﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
using System.Linq;
using System.Runtime.InteropServices;

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
            public TestEventsRaised EventsRaised;
            public DataTransfer DataTransfer;
            public bool CompletedStatus;

            public VerifyDownloadBlobContentInfo(
                string sourceFile,
                string destinationFile,
                TestEventsRaised eventsRaised,
                bool completed)
            {
                SourceLocalPath = sourceFile;
                DestinationLocalPath = destinationFile;
                EventsRaised = eventsRaised;
                CompletedStatus = completed;
                DataTransfer = default;
            }
        };

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
            List<TransferOptions> options = default)
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
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

            // Populate Options and TestRaisedOptions
            List<TestEventsRaised> eventRaisedList = TestEventsRaised.PopulateTestOptions(blobCount, ref options);

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };

            List<VerifyDownloadBlobContentInfo> downloadedBlobInfo = new List<VerifyDownloadBlobContentInfo>(blobCount);

            // Initialize TransferManager
            TransferManager transferManager = new TransferManager(transferManagerOptions);
            // Upload set of VerifyDownloadBlobContentInfo blobs to download
            for (int i = 0; i < blobCount; i++)
            {
                // Set up Blob to be downloaded
                bool completed = false;
                var data = GetRandomBuffer(size);
                using Stream originalStream = await CreateLimitedMemoryStream(size);
                string localSourceFile = Path.Combine(testDirectory.DirectoryPath, blobNames[i]);
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

                // Create destination file path
                string destFile = string.Concat(localSourceFile, "-dest");

                downloadedBlobInfo.Add(new VerifyDownloadBlobContentInfo(
                    localSourceFile,
                    destFile,
                    eventRaisedList[i],
                    completed));
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
                DataTransfer transfer = await transferManager.StartTransferAsync(
                    sourceResource,
                    destinationResource,
                    options[i]).ConfigureAwait(false);

                downloadedBlobInfo[i].DataTransfer = transfer;
            }

            for (int i = 0; i < downloadedBlobInfo.Count; i++)
            {
                // Assert
                Assert.NotNull(downloadedBlobInfo[i].DataTransfer);
                CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                await downloadedBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                Assert.IsTrue(downloadedBlobInfo[i].DataTransfer.HasCompleted);
                Assert.AreEqual(StorageTransferStatus.Completed, downloadedBlobInfo[i].DataTransfer.TransferStatus);

                // Verify Download
                downloadedBlobInfo[i].EventsRaised.AssertSingleCompletedCheck();
                CheckDownloadFile(downloadedBlobInfo[i].SourceLocalPath, downloadedBlobInfo[i].DestinationLocalPath);
            };
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
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<TransferOptions> optionsList = new List<TransferOptions> { options };
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
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<TransferOptions> optionsList = new List<TransferOptions> { options };
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
            TransferOptions options = new TransferOptions()
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
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            StorageResource sourceResource = new BlockBlobStorageResource(sourceClient);
            StorageResource destinationResource = new LocalFileStorageResource(destFile);
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
            testEventsRaised.AssertSingleFailedCheck();
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
            Assert.NotNull(testEventsRaised.FailedEvents.First().Exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.AreEqual(testEventsRaised.FailedEvents.First().Exception.Message, $"File path `{destFile}` already exists. Cannot overwrite file.");
        }

        [RecordedTest]
        public async Task BlockBlobToLocal_SmallChunk()
        {
            long size = Constants.KB;
            int waitTimeInSec = 10;
            TransferOptions options = new TransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<TransferOptions> optionsList = new List<TransferOptions>() { options };
            await DownloadBlockBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);
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

            TransferOptions options = new TransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512,
            };
            List<TransferOptions> optionsList = new List<TransferOptions>() { options };

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
            List<TransferOptions> options = default)
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

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

            // Populate Options and TestRaisedOptions
            List<TestEventsRaised> eventRaisedList = TestEventsRaised.PopulateTestOptions(blobCount, ref options);

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };

            List<VerifyDownloadBlobContentInfo> downloadedBlobInfo = new List<VerifyDownloadBlobContentInfo>(blobCount);

            // Initialize TransferManager
            TransferManager transferManager = new TransferManager(transferManagerOptions);

            // Upload set of VerifyDownloadBlobContentInfo blobs to download
            for (int i = 0; i < blobCount; i++)
            {
                bool completed = false;
                // Set up Blob to be downloaded
                var data = GetRandomBuffer(size);
                using Stream originalStream = await CreateLimitedMemoryStream(size);
                string localSourceFile = Path.Combine(testDirectory.DirectoryPath, GetNewBlobName());
                await CreateAppendBlob(container, localSourceFile, blobNames[i], size);

                // Create destination file path
                string destFile = Path.GetTempPath() + Path.GetRandomFileName();

                downloadedBlobInfo.Add(new VerifyDownloadBlobContentInfo(
                    localSourceFile,
                    destFile,
                    eventRaisedList[i],
                    completed));
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
                Assert.NotNull(downloadedBlobInfo[i].DataTransfer);
                CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                await downloadedBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                Assert.IsTrue(downloadedBlobInfo[i].DataTransfer.HasCompleted);

                // Verify Download
                downloadedBlobInfo[i].EventsRaised.AssertSingleCompletedCheck();
                CheckDownloadFile(downloadedBlobInfo[i].SourceLocalPath, downloadedBlobInfo[i].DestinationLocalPath);
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
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<TransferOptions> optionsList = new List<TransferOptions> { options };
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
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<TransferOptions> optionsList = new List<TransferOptions> { options };
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
            AppendBlobClient sourceClient = await CreateAppendBlob(testContainer.Container, localSourceFile, blobName, size);

            // Create destination file. So it can get skipped over.
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to overwrite any existing destination.
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
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
            testEventsRaised.AssertSingleSkippedCheck();
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
        }

        [RecordedTest]
        public async Task AppendBlobToLocal_Failure_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.Combine(testDirectory.DirectoryPath, blobName);
            int size = Constants.KB;
            AppendBlobClient sourceClient = await CreateAppendBlob(testContainer.Container, localSourceFile, blobName, size);

            // Make destination file name but do not create the file beforehand.
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to fail and keep track of the failure.
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            StorageResource sourceResource = new AppendBlobStorageResource(sourceClient);
            StorageResource destinationResource = new LocalFileStorageResource(destFile);
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
            testEventsRaised.AssertSingleFailedCheck();
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
            Assert.NotNull(testEventsRaised.FailedEvents.First().Exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.AreEqual(testEventsRaised.FailedEvents.First().Exception.Message, $"File path `{destFile}` already exists. Cannot overwrite file.");
        }

        [RecordedTest]
        public async Task AppendBlobToLocal_FailedEvent()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string blobName = GetNewBlobName();
            int size = Constants.KB;

            // Create local source file to compare to later.
            string localSourceFile = Path.Combine(testDirectory.DirectoryPath, blobName);

            // Create source Append Blob
            AppendBlobClient sourceClient = await CreateAppendBlob(testContainer.Container, localSourceFile, blobName, size);

            // Create destination file path
            string destFile = Path.GetTempFileName();

            // Act - Attempt a transfer even though the destination already exists.
            TransferManager transferManager = new TransferManager();
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            StorageResource sourceResource = new AppendBlobStorageResource(sourceClient);
            StorageResource destinationResource = new LocalFileStorageResource(destFile);

            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transfer.AwaitCompletion(cancellationTokenSource.Token);
            Assert.AreEqual(1, testEventsRaised.FailedEvents.Count);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("Cannot overwrite file."));
            testEventsRaised.AssertSingleFailedCheck();
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.KB, 20)]
        public async Task AppendBlobToLocal_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            TransferOptions options = new TransferOptions();

            List<TransferOptions> optionsList = new List<TransferOptions>() { options };
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
            TransferOptions options = new TransferOptions();

            List<TransferOptions> optionsList = new List<TransferOptions>() { options };
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
            TransferOptions options = new TransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<TransferOptions> optionsList = new List<TransferOptions>() { options };
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
            List<TransferOptions> options = default)
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
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

            // Populate Options and TestRaisedOptions
            List<TestEventsRaised> eventRaisedList = TestEventsRaised.PopulateTestOptions(blobCount, ref options);

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };

            List<VerifyDownloadBlobContentInfo> downloadedBlobInfo = new List<VerifyDownloadBlobContentInfo>(blobCount);
            // Initialize TransferManager
            TransferManager TransferManager = new TransferManager(transferManagerOptions);

            // Upload set of VerifyDownloadBlobContentInfo blobs to download
            for (int i = 0; i < blobCount; i++)
            {
                bool completed = false;
                // Set up Blob to be downloaded
                var data = GetRandomBuffer(size);
                using Stream originalStream = await CreateLimitedMemoryStream(size);
                string localSourceFile = Path.Combine(testDirectory.DirectoryPath, blobNames[i]);
                await CreatePageBlob(container, localSourceFile, blobNames[i], size);

                // Create destination file path
                string destFile = Path.Combine(testDirectory.DirectoryPath, GetNewBlobName());

                downloadedBlobInfo.Add(new VerifyDownloadBlobContentInfo(
                    localSourceFile,
                    destFile,
                    eventRaisedList[i],
                    completed));
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
                Assert.NotNull(downloadedBlobInfo[i].DataTransfer);
                CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                await downloadedBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                Assert.IsTrue(downloadedBlobInfo[i].DataTransfer.HasCompleted);

                // Verify Download
                downloadedBlobInfo[i].EventsRaised.AssertSingleCompletedCheck();
                CheckDownloadFile(downloadedBlobInfo[i].SourceLocalPath, downloadedBlobInfo[i].DestinationLocalPath);
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
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<TransferOptions> optionsList = new List<TransferOptions> { options };
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
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<TransferOptions> optionsList = new List<TransferOptions> { options };
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
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.Combine(testDirectory.DirectoryPath, blobName);
            int size = Constants.KB;
            PageBlobClient sourceClient = await CreatePageBlob(testContainer.Container, localSourceFile, blobName, size);

            // Create destination file. So it can get skipped over.
            string destFile = Path.Combine(testDirectory.DirectoryPath, GetNewBlobName());

            // Act
            // Create options bag to overwrite any existing destination.
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
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
            testEventsRaised.AssertSingleSkippedCheck();
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
        }

        [RecordedTest]
        public async Task PageBlobToLocal_Failure_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.Combine(testDirectory.DirectoryPath, blobName);
            int size = Constants.KB;
            PageBlobClient sourceClient = await CreatePageBlob(testContainer.Container, localSourceFile, blobName, size);

            // Make destination file name but do not create the file beforehand.
            string destFile = await CreateRandomFileAsync(testDirectory.DirectoryPath);

            // Act
            // Create options bag to fail and keep track of the failure.
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            StorageResource sourceResource = new PageBlobStorageResource(sourceClient);
            StorageResource destinationResource = new LocalFileStorageResource(destFile);
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
            testEventsRaised.AssertSingleFailedCheck();
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
            Assert.NotNull(testEventsRaised.FailedEvents.First().Exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.AreEqual(testEventsRaised.FailedEvents.First().Exception.Message, $"File path `{destFile}` already exists. Cannot overwrite file.");
        }

        [RecordedTest]
        public async Task PageBlobToLocal_SmallChunk()
        {
            long size = 12 * Constants.KB;
            int waitTimeInSec = 10;
            TransferOptions options = new TransferOptions()
            {
                InitialTransferSize = Constants.KB,
                MaximumTransferChunkSize = Constants.KB,
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<TransferOptions> optionsList = new List<TransferOptions>() { options };
            await DownloadPageBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);
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

            await DownloadPageBlobsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
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

            TransferOptions options = new TransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512,
            };
            List<TransferOptions> optionsList = new List<TransferOptions>() { options };

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

        #region Single Concurrency
        private async Task<DataTransfer> CreateStartTransfer(
            BlobContainerClient containerClient,
            string localDirectoryPath,
            int concurrency,
            bool createFailedCondition = false,
            TransferOptions options = default,
            int size = Constants.KB)
        {
            // Arrange
            // Create source local file for checking, and source blob
            string sourceBlobName = GetNewBlobName();
            string destFile;
            if (createFailedCondition)
            {
                destFile = await CreateRandomFileAsync(localDirectoryPath);
            }
            else
            {
                destFile = Path.Combine(localDirectoryPath, GetNewBlobName());
            }

            // Create new source block blob.
            string newSourceFile = Path.Combine(localDirectoryPath, sourceBlobName);
            BlockBlobClient blockBlobClient = await CreateBlockBlob(containerClient, newSourceFile, sourceBlobName, size);
            StorageResource sourceResource = new BlockBlobStorageResource(blockBlobClient);
            StorageResource destinationResource = new LocalFileStorageResource(destFile);

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

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer to do a AwaitCompletion
            TransferOptions options = new TransferOptions();
            TestEventsRaised failureTransferHolder = new TestEventsRaised(options);
            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: testDirectory.DirectoryPath,
                concurrency: 1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await transfer.AwaitCompletion(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            failureTransferHolder.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.Completed, transfer.TransferStatus);
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Failed()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail
            };
            TestEventsRaised testEventRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: testDirectory.DirectoryPath,
                concurrency: 1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await transfer.AwaitCompletion(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            testEventRaised.AssertSingleFailedCheck();
            Assert.AreEqual(1, testEventRaised.FailedEvents.Count);
            Assert.IsTrue(testEventRaised.FailedEvents.First().Exception.Message.Contains("Cannot overwrite file."));
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer options with Skipping available
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip
            };
            TestEventsRaised testEventRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: testDirectory.DirectoryPath,
                concurrency: 1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await transfer.AwaitCompletion(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
            testEventRaised.AssertSingleSkippedCheck();
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer to do a EnsureCompleted
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail
            };
            TestEventsRaised testEventRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: testDirectory.DirectoryPath,
                concurrency: 1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            transfer.EnsureCompleted(cancellationTokenSource.Token);

            // Assert
            testEventRaised.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.Completed, transfer.TransferStatus);
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted_Failed()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: testDirectory.DirectoryPath,
                concurrency: 1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            transfer.EnsureCompleted(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            testEventsRaised.AssertSingleFailedCheck();
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("Cannot overwrite file."));
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted_Skipped()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer options with Skipping available
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a EnsureCompleted
            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: testDirectory.DirectoryPath,
                concurrency: 1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            transfer.EnsureCompleted(cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertSingleSkippedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
        }
        #endregion
    }
}
