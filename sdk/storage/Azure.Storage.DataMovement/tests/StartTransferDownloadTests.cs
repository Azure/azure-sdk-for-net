// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using NUnit.Framework;
using System.Threading;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using System.Linq;
using Azure.Storage.Tests;

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
        private async Task SetupContainerAsync(
            BlobContainerClient container,
            string blobPrefix,
            int blobCount,
            long blobSize,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<(string BlobName, byte[] BlobData)> GetBlobDatas(int count, long size)
            {
                foreach (var _ in Enumerable.Range(0, count))
                {
                    yield return (BlobName: GetNewBlobName(), BlobData: GetRandomBuffer(size));
                }
            }
            await SetupContainerAsync(
                container,
                blobPrefix,
                GetBlobDatas(blobCount, blobSize),
                cancellationToken);
        }

        private async Task SetupContainerAsync(
            BlobContainerClient container,
            string blobPrefix,
            IEnumerable<(string BlobName, byte[] BlobData)> blobs,
            CancellationToken cancellationToken = default)
        {
            // Upload set of VerifyDownloadBlobContentInfo blobs to download
            foreach ((string blobName, byte[] blobData) in blobs)
            {
                await container.GetBlobClient(string.IsNullOrEmpty(blobPrefix) ? blobName : $"{blobPrefix}/{blobName}")
                    .UploadAsync(new BinaryData(blobData), cancellationToken);
            }
        }

        private async Task DownloadBlockBlobAndVerify(
            BlockBlobClient blob,
            long size = Constants.KB,
            TransferManagerOptions transferManagerOptions = default,
            DataTransferOptions options = default,
            CancellationToken cancellationToken = default)
        {
            await blob.UploadAsync(new MemoryStream(GetRandomBuffer(size)));
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            string fileName = Recording.Random.NextString(8);
            string filePath = Path.Combine(disposingLocalDirectory.DirectoryPath, fileName);

            BlockBlobStorageResource sourceResource = new(blob);
            LocalFileStorageResource destResource = new(filePath);

            await new TransferValidator().TransferAndVerifyAsync(
                sourceResource,
                destResource,
                async cToken => await blob.OpenReadAsync(cancellationToken: cToken),
                cToken => Task.FromResult(File.OpenRead(filePath) as Stream),
                options,
                cancellationToken);
        }

        [RecordedTest]
        public async Task BlockBlobToLocal()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            // No Option Download bag or manager options bag, plain download
            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(10));
            await DownloadBlockBlobAndVerify(
                testContainer.Container.GetBlockBlobClient(GetNewBlobName()),
                size: Constants.KB,
                cancellationToken: cts.Token).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task BlockBlobToLocal_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            // Create destination to overwrite
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };
            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(10));
            await DownloadBlockBlobAndVerify(
                testContainer.Container.GetBlockBlobClient(GetNewBlobName()),
                size: Constants.KB,
                options: options,
                cancellationToken: cts.Token).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task BlockBlobToLocal_Overwrite_NotExists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };
            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(10));
            await DownloadBlockBlobAndVerify(
                testContainer.Container.GetBlockBlobClient(GetNewBlobName()),
                size: Constants.KB,
                options: options,
                cancellationToken: cts.Token).ConfigureAwait(false);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33086")]
        [Test]
        [LiveOnly]
        public async Task BlockBlobToLocal_Skip_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            bool skippedSeen = false;
            BlockBlobClient sourceClient = await CreateBlockBlob(testContainer.Container, localSourceFile, blobName, size);

            // Create destination file. So it can get skipped over.
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists,
            };
            options.ItemTransferSkipped += (TransferItemSkippedEventArgs args) =>
            {
                if (args.SourceResource != null &&
                    args.DestinationResource != null &&
                    args.TransferId != null)
                {
                    skippedSeen = true;
                }
                return Task.CompletedTask;
            };
            TestEventsRaised testEventsRaised = new(options);
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                new BlockBlobStorageResource(sourceClient),
                new LocalFileStorageResource(destFile),
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(skippedSeen);
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
        }

        [RecordedTest]
        public async Task BlockBlobToLocal_Failure_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            BlockBlobClient sourceClient = await CreateBlockBlob(testContainer.Container, localSourceFile, blobName, size);

            // Make destination file name but do not create the file beforehand.
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to fail and keep track of the failure.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            StorageResourceItem sourceResource = new BlockBlobStorageResource(sourceClient);
            StorageResourceItem destinationResource = new LocalFileStorageResource(destFile);
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                new BlockBlobStorageResource(sourceClient),
                new LocalFileStorageResource(destFile),
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            await testEventsRaised.AssertSingleFailedCheck(1);
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
            Assert.NotNull(testEventsRaised.FailedEvents.First().Exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.AreEqual(testEventsRaised.FailedEvents.First().Exception.Message, $"File path `{destFile}` already exists. Cannot overwrite file.");
        }

        [RecordedTest]
        public async Task BlockBlobToLocal_SmallChunk()
        {
            long size = Constants.KB;
            int waitTimeInSec = 25;
            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };

            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };
            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await DownloadBlockBlobAndVerify(
                testContainer.Container.GetBlockBlobClient(GetNewBlobName()),
                size: size,
                options: options,
                cancellationToken: cts.Token).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(100, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.KB, 10)]
        public async Task BlockBlobToLocal_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await DownloadBlockBlobAndVerify(
                testContainer.Container.GetBlockBlobClient(GetNewBlobName()),
                size: size,
                cancellationToken: cts.Token).ConfigureAwait(false);
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
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await DownloadBlockBlobAndVerify(
                testContainer.Container.GetBlockBlobClient(GetNewBlobName()),
                size: size,
                cancellationToken: cts.Token).ConfigureAwait(false);
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
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            // TODO: concurrency recording issues
            //List<Task> tasks = new();
            foreach (var _ in Enumerable.Range(0, blobCount))
            {
                await DownloadBlockBlobAndVerify(
                    testContainer.Container.GetBlockBlobClient(GetNewBlobName()),
                    size: size,
                    cancellationToken: cts.Token);
            }
            //await Task.WhenAll(tasks).ConfigureAwait(false);
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
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            List<Task> tasks = new();
            foreach (var _ in Enumerable.Range(0, blobCount))
            {
                tasks.Add(DownloadBlockBlobAndVerify(
                    testContainer.Container.GetBlockBlobClient(GetNewBlobName()),
                    size: size,
                    cancellationToken: cts.Token));
            }
            await Task.WhenAll(tasks).ConfigureAwait(false);
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
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512,
            };

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(10));
            await DownloadBlockBlobAndVerify(
                testContainer.Container.GetBlockBlobClient(Recording.Random.NextString(8)),
                transferManagerOptions: managerOptions,
                options: options,
                cancellationToken: cts.Token).ConfigureAwait(false);
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
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await DownloadBlockBlobAndVerify(
                testContainer.Container.GetBlockBlobClient(Recording.Random.NextString(8)),
                transferManagerOptions: managerOptions,
                cancellationToken: cts.Token).ConfigureAwait(false);
        }
        #endregion SingleDownload Block Blob

        #region SingleDownload Append Blob
        private async Task DownloadAppendBlobAndVerify(
            AppendBlobClient blob,
            long size = Constants.KB,
            TransferManagerOptions transferManagerOptions = default,
            DataTransferOptions options = default,
            CancellationToken cancellationToken = default)
        {
            using (Stream appendStream = await blob.OpenWriteAsync(true))
            {
                await new MemoryStream(GetRandomBuffer(size)).CopyToAsync(appendStream, bufferSize: 4 * Constants.KB, cancellationToken);
            }
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            string fileName = Recording.Random.NextString(8);
            string filePath = Path.Combine(disposingLocalDirectory.DirectoryPath, fileName);

            AppendBlobStorageResource sourceResource = new(blob);
            LocalFileStorageResource destResource = new(filePath);

            await new TransferValidator().TransferAndVerifyAsync(
                sourceResource,
                destResource,
                async cToken => await blob.OpenReadAsync(cancellationToken: cToken),
                cToken => Task.FromResult(File.OpenRead(filePath) as Stream),
                options,
                cancellationToken);
        }

        [RecordedTest]
        public async Task AppendBlobToLocal()
        {
            long size = Constants.KB;
            int waitTimeInSec = 10;

            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await DownloadAppendBlobAndVerify(
                testContainer.Container.GetAppendBlobClient(GetNewBlobName()),
                size: size,
                cancellationToken: cts.Token).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task AppendBlobToLocal_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            string localSourceFile = Path.GetTempFileName();

            // Create destination to overwrite
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };
            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(10));
            await DownloadAppendBlobAndVerify(
                testContainer.Container.GetAppendBlobClient(GetNewBlobName()),
                size: Constants.KB,
                options: options,
                cancellationToken: cts.Token).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task AppendBlobToLocal_Overwrite_NotExists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };
            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(10));
            await DownloadAppendBlobAndVerify(
                testContainer.Container.GetAppendBlobClient(GetNewBlobName()),
                size: Constants.KB,
                options: options,
                cancellationToken: cts.Token).ConfigureAwait(false);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33086")]
        [Test]
        [LiveOnly]
        public async Task AppendBlobToLocal_Skip_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            AppendBlobClient sourceClient = await CreateAppendBlob(testContainer.Container, localSourceFile, blobName, size);

            // Create destination file. So it can get skipped over.
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                new AppendBlobStorageResource(sourceClient),
                new LocalFileStorageResource(destFile),
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
            await testEventsRaised.AssertSingleSkippedCheck();
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
        }

        [RecordedTest]
        public async Task AppendBlobToLocal_Failure_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.Combine(testDirectory.DirectoryPath, blobName);
            int size = Constants.KB;
            AppendBlobClient sourceClient = await CreateAppendBlob(testContainer.Container, localSourceFile, blobName, size);

            // Make destination file name but do not create the file beforehand.
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to fail and keep track of the failure.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            StorageResourceItem sourceResource = new AppendBlobStorageResource(sourceClient);
            StorageResourceItem destinationResource = new LocalFileStorageResource(destFile);
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                new AppendBlobStorageResource(sourceClient),
                new LocalFileStorageResource(destFile),
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            await testEventsRaised.AssertSingleFailedCheck(1);
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
            Assert.NotNull(testEventsRaised.FailedEvents.First().Exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.AreEqual(testEventsRaised.FailedEvents.First().Exception.Message, $"File path `{destFile}` already exists. Cannot overwrite file.");
        }

        [RecordedTest]
        public async Task AppendBlobToLocal_FailedEvent()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
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
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            StorageResourceItem sourceResource = new AppendBlobStorageResource(sourceClient);
            StorageResourceItem destinationResource = new LocalFileStorageResource(destFile);

            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);
            Assert.AreEqual(1, testEventsRaised.FailedEvents.Count);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("Cannot overwrite file."));
            await testEventsRaised.AssertSingleFailedCheck(1);
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.KB, 20)]
        public async Task AppendBlobToLocal_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            DataTransferOptions options = new DataTransferOptions();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await DownloadAppendBlobAndVerify(
                testContainer.Container.GetAppendBlobClient(GetNewBlobName()),
                size: size,
                options: options,
                cancellationToken: cts.Token).ConfigureAwait(false);
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
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            string exceptionMessage = default;
            DataTransferOptions options = new DataTransferOptions();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await DownloadAppendBlobAndVerify(
                testContainer.Container.GetAppendBlobClient(GetNewBlobName()),
                size: size,
                options: options,
                cancellationToken: cts.Token).ConfigureAwait(false);

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
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            foreach (var _ in Enumerable.Range(0, blobCount))
            {
                await DownloadAppendBlobAndVerify(
                    testContainer.Container.GetAppendBlobClient(GetNewBlobName()),
                    size: size,
                    cancellationToken: cts.Token).ConfigureAwait(false);
            }
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
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            foreach (var _ in Enumerable.Range(0, blobCount))
            {
                await DownloadAppendBlobAndVerify(
                    testContainer.Container.GetAppendBlobClient(GetNewBlobName()),
                    size: size,
                    cancellationToken: cts.Token).ConfigureAwait(false);
            }
        }

        [RecordedTest]
        public async Task AppendBlobToLocal_SmallChunk()
        {
            // To test parallel chunked download, this makes it faster to debug
            // and run through.
            long size = Constants.KB;
            int waitTimeInSec = 25;
            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };

            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };
            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await DownloadAppendBlobAndVerify(
                testContainer.Container.GetAppendBlobClient(GetNewBlobName()),
                size: size,
                options: options,
                cancellationToken: cts.Token).ConfigureAwait(false);
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
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await DownloadAppendBlobAndVerify(
                testContainer.Container.GetAppendBlobClient(GetNewBlobName()),
                transferManagerOptions: managerOptions,
                cancellationToken: cts.Token).ConfigureAwait(false);
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
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await DownloadAppendBlobAndVerify(
                testContainer.Container.GetAppendBlobClient(GetNewBlobName()),
                transferManagerOptions: managerOptions,
                cancellationToken: cts.Token).ConfigureAwait(false);
        }
        #endregion SingleDownload Append Blob

        #region SingleDownload Page Blob
        private async Task DownloadPageBlobAndVerify(
            PageBlobClient blob,
            long size = Constants.KB,
            TransferManagerOptions transferManagerOptions = default,
            DataTransferOptions options = default,
            CancellationToken cancellationToken = default)
        {
            using (Stream appendStream = await blob.OpenWriteAsync(true, 0, new() { Size = size, }))
            {
                await new MemoryStream(GetRandomBuffer(size)).CopyToAsync(appendStream, bufferSize: 4 * Constants.KB, cancellationToken);
            }
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            string fileName = Recording.Random.NextString(8);
            string filePath = Path.Combine(disposingLocalDirectory.DirectoryPath, fileName);

            PageBlobStorageResource sourceResource = new(blob);
            LocalFileStorageResource destResource = new(filePath);

            await new TransferValidator().TransferAndVerifyAsync(
                sourceResource,
                destResource,
                async cToken => await blob.OpenReadAsync(cancellationToken: cToken),
                cToken => Task.FromResult(File.OpenRead(filePath) as Stream),
                options,
                cancellationToken);
        }

        [RecordedTest]
        public async Task PageBlobToLocal()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            await DownloadPageBlobAndVerify(testContainer.Container.GetPageBlobClient(GetNewBlobName())).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task PageBlobToLocal_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            int size = Constants.KB;

            // Create destination to overwrite
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };
            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(10));
            await DownloadPageBlobAndVerify(
                testContainer.Container.GetPageBlobClient(GetNewBlobName()),
                size: size,
                options: options,
                cancellationToken: cts.Token).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task PageBlobToLocal_Overwrite_NotExists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };
            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(10));
            await DownloadPageBlobAndVerify(
                testContainer.Container.GetPageBlobClient(GetNewBlobName()),
                size: Constants.KB,
                options: options,
                cancellationToken: cts.Token).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task PageBlobToLocal_Skip_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.Combine(testDirectory.DirectoryPath, blobName);
            int size = Constants.KB;
            PageBlobClient sourceClient = await CreatePageBlob(testContainer.Container, localSourceFile, blobName, size);

            // Create destination file. So it can get skipped over.
            string destFile = Path.Combine(testDirectory.DirectoryPath, GetNewBlobName());
            File.Create(destFile).Close();

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                new PageBlobStorageResource(sourceClient),
                new LocalFileStorageResource(destFile),
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
            await testEventsRaised.AssertSingleSkippedCheck();
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
        }

        [RecordedTest]
        public async Task PageBlobToLocal_Failure_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.Combine(testDirectory.DirectoryPath, blobName);
            int size = Constants.KB;
            PageBlobClient sourceClient = await CreatePageBlob(testContainer.Container, localSourceFile, blobName, size);

            // Make destination file name but do not create the file beforehand.
            string destFile = await CreateRandomFileAsync(testDirectory.DirectoryPath);

            // Act
            // Create options bag to fail and keep track of the failure.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            StorageResourceItem sourceResource = new PageBlobStorageResource(sourceClient);
            StorageResourceItem destinationResource = new LocalFileStorageResource(destFile);
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                new PageBlobStorageResource(sourceClient),
                new LocalFileStorageResource(destFile),
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            await testEventsRaised.AssertSingleFailedCheck(1);
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
            Assert.NotNull(testEventsRaised.FailedEvents.First().Exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.AreEqual(testEventsRaised.FailedEvents.First().Exception.Message, $"File path `{destFile}` already exists. Cannot overwrite file.");
        }

        [RecordedTest]
        public async Task PageBlobToLocal_SmallChunk()
        {
            long size = 12 * Constants.KB;
            int waitTimeInSec = 25;
            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = Constants.KB,
                MaximumTransferChunkSize = Constants.KB,
            };

            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await DownloadPageBlobAndVerify(
                testContainer.Container.GetPageBlobClient(GetNewBlobName()),
                size: size,
                options: options,
                cancellationToken: cts.Token).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(2 * Constants.KB, 10)]
        [TestCase(4 * Constants.KB, 10)]
        public async Task PageBlobToLocal_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await DownloadPageBlobAndVerify(
                testContainer.Container.GetPageBlobClient(GetNewBlobName()),
                size: size,
                cancellationToken: cts.Token).ConfigureAwait(false);
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
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await DownloadPageBlobAndVerify(
                testContainer.Container.GetPageBlobClient(GetNewBlobName()),
                size: size,
                cancellationToken: cts.Token).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(2, 4 * Constants.KB, 60)]
        [TestCase(6, 4 * Constants.KB, 60)]
        public async Task PageBlobToLocal_SmallMultiple(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            foreach (var _ in Enumerable.Range(0, blobCount))
            {
                await DownloadPageBlobAndVerify(
                    testContainer.Container.GetPageBlobClient(GetNewBlobName()),
                    size: size,
                    cancellationToken: cts.Token).ConfigureAwait(false);
            }
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
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            foreach (var _ in Enumerable.Range(0, blobCount))
            {
                await DownloadPageBlobAndVerify(
                    testContainer.Container.GetPageBlobClient(GetNewBlobName()),
                    size: size,
                    cancellationToken: cts.Token).ConfigureAwait(false);
            }
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
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512,
            };

            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await DownloadPageBlobAndVerify(
                testContainer.Container.GetPageBlobClient(GetNewBlobName()),
                transferManagerOptions: managerOptions,
                options: options,
                cancellationToken: cts.Token).ConfigureAwait(false);
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
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await DownloadPageBlobAndVerify(
                testContainer.Container.GetPageBlobClient(GetNewBlobName()),
                transferManagerOptions: managerOptions,
                cancellationToken: cts.Token).ConfigureAwait(false);
        }
        #endregion SingleDownload Page Blob

        #region Single Concurrency
        private async Task<DataTransfer> CreateStartTransfer(
            BlobContainerClient containerClient,
            string localDirectoryPath,
            int concurrency,
            bool createFailedCondition = false,
            DataTransferOptions options = default,
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
            StorageResourceItem sourceResource = new BlockBlobStorageResource(blockBlobClient);
            StorageResourceItem destinationResource = new LocalFileStorageResource(destFile);

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
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer to do a AwaitCompletion
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised failureTransferHolder = new TestEventsRaised(options);
            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: testDirectory.DirectoryPath,
                concurrency: 1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                failureTransferHolder,
                cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            failureTransferHolder.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
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
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventRaised,
                cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            await testEventRaised.AssertSingleFailedCheck(1);
            Assert.AreEqual(1, testEventRaised.FailedEvents.Count);
            Assert.IsTrue(testEventRaised.FailedEvents.First().Exception.Message.Contains("Cannot overwrite file."));
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
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
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventRaised,
                cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
            await testEventRaised.AssertSingleSkippedCheck();
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer to do a EnsureCompleted
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
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
            TestTransferWithTimeout.WaitForCompletion(
                transfer,
                testEventRaised,
                cancellationTokenSource.Token);

            // Assert
            testEventRaised.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
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
            TestTransferWithTimeout.WaitForCompletion(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            await testEventsRaised.AssertSingleFailedCheck(1);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("Cannot overwrite file."));
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted_Skipped()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
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
            TestTransferWithTimeout.WaitForCompletion(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleSkippedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
        }
        #endregion
    }
}
