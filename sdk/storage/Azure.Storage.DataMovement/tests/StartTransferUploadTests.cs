// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferUploadTests : DataMovementBlobTestBase
    {
        public StartTransferUploadTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        internal class VerifyUploadBlobContentInfo
        {
            public readonly string LocalPath;
            public BlobBaseClient DestinationClient;
            public TestEventsRaised EventsRaised;
            public DataTransfer DataTransfer;

            public VerifyUploadBlobContentInfo(
                string sourceFile,
                BlobBaseClient destinationClient,
                TestEventsRaised eventsRaised,
                DataTransfer dataTransfer)
            {
                LocalPath = sourceFile;
                DestinationClient = destinationClient;
                EventsRaised = eventsRaised;
                DataTransfer = dataTransfer;
            }
        };

        internal DataTransferOptions CopySingleUploadOptions(DataTransferOptions options)
        {
            DataTransferOptions newOptions = new DataTransferOptions()
            {
                MaximumTransferChunkSize = options.MaximumTransferChunkSize,
                InitialTransferSize = options.InitialTransferSize,
            };
            return newOptions;
        }

        #region SingleUpload Block Blob
        private async Task UploadBlockBlobAndVerify(
            string filePath,
            BlockBlobClient blob,
            int size = Constants.KB,
            TransferManagerOptions transferManagerOptions = default,
            DataTransferOptions options = default,
            CancellationToken cancellationToken = default)
        {
            using (Stream fs = File.OpenWrite(filePath))
            {
                await new MemoryStream(GetRandomBuffer(size)).CopyToAsync(fs, bufferSize: Constants.KB, cancellationToken);
            }

            LocalFileStorageResource sourceResource = new(filePath);
            BlockBlobStorageResource destResource = new(blob);

            await new TransferValidator()
            {
                TransferManager = new TransferManager(transferManagerOptions)
            }.TransferAndVerifyAsync(
                sourceResource,
                destResource,
                async cToken => await blob.OpenReadAsync(cancellationToken: cToken),
                cToken => Task.FromResult(File.OpenRead(filePath) as Stream),
                options,
                cancellationToken);
        }

        [RecordedTest]
        public async Task LocalToBlockBlob()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            await UploadBlockBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetBlockBlobClient(GetNewBlobName()));
        }

        [RecordedTest]
        public async Task LocalToBlockBlob_EventHandler()
        {
            AutoResetEvent InProgressWait = new AutoResetEvent(false);

            bool progressSeen = false;
            DataTransferOptions options = new DataTransferOptions();
            options.TransferStatusChanged += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.TransferStatus.State == DataTransferState.InProgress)
                {
                    progressSeen = true;
                }
                return Task.CompletedTask;
            };

            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            await UploadBlockBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetBlockBlobClient(GetNewBlobName()),
                options: options);

            // Assert
            Assert.IsTrue(progressSeen);
        }

        [RecordedTest]
        public async Task LocalToBlockBlobSize_SmallChunk()
        {
            int fileSize = Constants.KB;
            int waitTimeInSec = 25;
            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };

            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadBlockBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetBlockBlobClient(GetNewBlobName()),
                size: fileSize,
                options: options,
                cancellationToken: cts.Token);
        }

        [RecordedTest]
        public async Task LocalToBlockBlob_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            int size = Constants.KB;
            int waitTimeInSec = 10;

            // Create blob
            BlockBlobClient destClient = testContainer.Container.GetBlockBlobClient(GetNewBlobName());
            await destClient.UploadAsync(new MemoryStream(GetRandomBuffer(size)));

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadBlockBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                destClient,
                size: size,
                options: options,
                cancellationToken: cts.Token);
        }

        [RecordedTest]
        public async Task LocalToBlockBlob_Overwrite_NotExists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            int size = Constants.KB;
            int waitTimeInSec = 10;

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadBlockBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetBlockBlobClient(GetNewBlobName()),
                size: size,
                options: options,
                cancellationToken: cts.Token);
        }

        [RecordedTest]
        public async Task LocalToBlockBlob_Skip_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string blobName = GetNewBlobName();
            int size = Constants.KB;
            string originalSourceFile = Path.Combine(testDirectory.DirectoryPath, blobName);
            BlockBlobClient destinationClient = await CreateBlockBlob(testContainer.Container, originalSourceFile, blobName, size);

            // Act
            // Create new source file
            string newSourceFile = await CreateRandomFileAsync(Path.GetTempPath(), size:size);
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists,
            };
            StorageResourceItem sourceResource = new LocalFileStorageResource(newSourceFile);
            StorageResourceItem destinationResource = new BlockBlobStorageResource(destinationClient);
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleSkippedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
            Assert.IsTrue(await destinationClient.ExistsAsync());
            // Verify Upload - That we skipped over and didn't reupload something new.
            using (FileStream fileStream = File.OpenRead(originalSourceFile))
            {
                await DownloadAndAssertAsync(fileStream, destinationClient);
            }
        }

        [RecordedTest]
        public async Task LocalToBlockBlob_Failure_Exists()
        {
            // Arrange

            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            BlockBlobClient destinationClient = await CreateBlockBlob(testContainer.Container, originalSourceFile, blobName, size);

            // Make destination file name but do not create the file beforehand.
            // Create new source file
            string newSourceFile = await CreateRandomFileAsync(Path.GetTempPath(), size: size);

            // Act
            // Create options bag to fail and keep track of the failure.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists,
            };
            TestEventsRaised testEventRaised = new TestEventsRaised(options);
            StorageResourceItem sourceResource = new LocalFileStorageResource(newSourceFile);
            StorageResourceItem destinationResource = new BlockBlobStorageResource(destinationClient);
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(await destinationClient.ExistsAsync());
            await testEventRaised.AssertSingleFailedCheck(1);
            Assert.NotNull(testEventRaised.FailedEvents.First().Exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.IsTrue(testEventRaised.FailedEvents.First().Exception.Message.Contains("The specified blob already exists."));
            // Verify Upload - That we skipped over and didn't reupload something new.
            using (FileStream fileStream = File.OpenRead(originalSourceFile))
            {
                await DownloadAndAssertAsync(fileStream, destinationClient);
            }
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(1000, 10)]
        [TestCase(Constants.KB, 20)]
        [TestCase(4 * Constants.KB, 20)]
        public async Task LocalToBlockBlob_SmallSize(long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadBlockBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetBlockBlobClient(GetNewBlobName()),
                cancellationToken: cts.Token);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(257 * Constants.MB, 600)]
        [TestCase(500 * Constants.MB, 200)]
        [TestCase(700 * Constants.MB, 200)]
        [TestCase(Constants.GB, 1500)]
        public async Task LocalToBlockBlob_LargeSize(int fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadBlockBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetBlockBlobClient(GetNewBlobName()),
                size: fileSize,
                cancellationToken: cts.Token);
        }

        [RecordedTest]
        [TestCase(1, Constants.KB, 10)]
        [TestCase(2, Constants.KB, 10)]
        [TestCase(1, 4 * Constants.KB, 60)]
        [TestCase(2, 4 * Constants.KB, 60)]
        [TestCase(4, 16 * Constants.KB, 60)]
        public async Task LocalToBlockBlob_SmallConcurrency(int concurrency, int size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

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

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadBlockBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetBlockBlobClient(GetNewBlobName()),
                size: size,
                transferManagerOptions: managerOptions,
                options: options,
                cancellationToken: cts.Token);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(1, 257 * Constants.MB, 200)]
        [TestCase(4, 257 * Constants.MB, 200)]
        [TestCase(16, 257 * Constants.MB, 200)]
        [TestCase(16, Constants.GB, 200)]
        [TestCase(32, Constants.GB, 200)]
        public async Task LocalToBlockBlob_LargeConcurrency(int concurrency, int size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadBlockBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetBlockBlobClient(GetNewBlobName()),
                size: size,
                transferManagerOptions: managerOptions,
                cancellationToken: cts.Token);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33003")]
        [Test]
        [LiveOnly]
        [TestCase(2, 0, 30)]
        [TestCase(2, Constants.KB, 30)]
        [TestCase(6, Constants.KB, 30)]
        [TestCase(32, Constants.KB, 30)]
        [TestCase(2, 2 * Constants.KB, 30)]
        [TestCase(6, 2 * Constants.KB, 30)]
        public async Task LocalToBlockBlob_SmallMultiple(int blobCount, int fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            foreach (var _ in Enumerable.Range(0, blobCount))
            {
                CancellationTokenSource cts = new();
                cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
                await UploadBlockBlobAndVerify(
                    Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                    testContainer.Container.GetBlockBlobClient(GetNewBlobName()),
                    size: fileSize,
                    cancellationToken: cts.Token);
            }
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        [TestCase(3, Constants.GB, 2000)]
        public async Task LocalToBlockBlob_LargeMultiple(int blobCount, int fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            foreach (var _ in Enumerable.Range(0, blobCount))
            {
                CancellationTokenSource cts = new();
                cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
                await UploadBlockBlobAndVerify(
                    Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                    testContainer.Container.GetBlockBlobClient(GetNewBlobName()),
                    size: fileSize,
                    cancellationToken: cts.Token);
            }
        }
        #endregion SingleUpload Block Blob

        #region SingleUpload Page Blob
        private async Task UploadPageBlobAndVerify(
            string filePath,
            PageBlobClient blob,
            long size = Constants.KB,
            TransferManagerOptions transferManagerOptions = default,
            DataTransferOptions options = default,
            CancellationToken cancellationToken = default)
        {
            using (Stream fs = File.OpenWrite(filePath))
            {
                await (await CreateLimitedMemoryStream(size)).CopyToAsync(fs, bufferSize: Constants.KB, cancellationToken);
            }

            LocalFileStorageResource sourceResource = new(filePath);
            PageBlobStorageResource destResource = new(blob);

            await new TransferValidator()
            {
                TransferManager = new TransferManager(transferManagerOptions)
            }.TransferAndVerifyAsync(
                sourceResource,
                destResource,
                async cToken => await blob.OpenReadAsync(cancellationToken: cToken),
                cToken => Task.FromResult(File.OpenRead(filePath) as Stream),
                options,
                cancellationToken);
        }

        [RecordedTest]
        public async Task LocalToPageBlob()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            await UploadPageBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetPageBlobClient(GetNewBlobName()));
        }

        [RecordedTest]
        public async Task LocalToPageBlob_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            string blobName = GetNewBlobName();
            int size = Constants.KB;
            int waitTimeInSec = 10;

            // Create blob
            PageBlobClient destClient = testContainer.Container.GetPageBlobClient(blobName);
            await destClient.CreateAsync(size);
            await destClient.UploadPagesAsync(new MemoryStream(GetRandomBuffer(size)), 0L);

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };

            // Start transfer and await for completion.
            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadPageBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                destClient,
                size: size,
                options: options,
                cancellationToken: cts.Token);
        }

        [RecordedTest]
        public async Task LocalToPageBlob_Overwrite_NotExists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            int size = Constants.KB;
            int waitTimeInSec = 10;

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };

            // Start transfer and await for completion.
            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadPageBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetPageBlobClient(GetNewBlobName()),
                size: size,
                options: options,
                cancellationToken: cts.Token);
        }

        [RecordedTest]
        public async Task LocalToPageBlob_Skip_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            PageBlobClient destinationClient = await CreatePageBlob(testContainer.Container, originalSourceFile, blobName, size);

            // Act
            // Create new source file
            string newSourceFile = await CreateRandomFileAsync(Path.GetTempPath(), size: size);
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists,
            };
            StorageResourceItem sourceResource = new LocalFileStorageResource(newSourceFile);
            StorageResourceItem destinationResource = new PageBlobStorageResource(destinationClient);
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleSkippedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
            Assert.IsTrue(await destinationClient.ExistsAsync());
            // Verify Upload - That we skipped over and didn't reupload something new.
            using (FileStream fileStream = File.OpenRead(originalSourceFile))
            {
                await DownloadAndAssertAsync(fileStream, destinationClient);
            }
        }

        [RecordedTest]
        public async Task LocalToPageBlob_Failure_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            PageBlobClient destinationClient = await CreatePageBlob(testContainer.Container, originalSourceFile, blobName, size);

            // Make destination file name but do not create the file beforehand.
            // Create new source file
            string newSourceFile = await CreateRandomFileAsync(Path.GetTempPath(), size: size);

            // Act
            // Create options bag to fail and keep track of the failure.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            StorageResourceItem sourceResource = new LocalFileStorageResource(newSourceFile);
            StorageResourceItem destinationResource = new PageBlobStorageResource(destinationClient);
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleFailedCheck(1);
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(await destinationClient.ExistsAsync());
            Assert.NotNull(testEventsRaised.FailedEvents.First().Exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("The specified blob already exists."));
            // Verify Upload - That we skipped over and didn't reupload something new.
            using (FileStream fileStream = File.OpenRead(originalSourceFile))
            {
                await DownloadAndAssertAsync(fileStream, destinationClient);
            }
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.KB, 60)]
        [TestCase(5 * Constants.KB, 60)]
        public async Task LocalToPageBlob_SmallSize(long fileSize, int waitTimeInSec)
        {
            DataTransferOptions options = new DataTransferOptions();

            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadPageBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetPageBlobClient(GetNewBlobName()),
                size: fileSize,
                cancellationToken: cts.Token);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(257 * Constants.MB, 200)]
        [TestCase(400 * Constants.MB, 400)]
        [TestCase(800 * Constants.MB, 400)]
        [TestCase(Constants.GB, 1500)]
        public async Task LocalToPageBlob_LargeSize(long fileSize, int waitTimeInSec)
        {
            DataTransferOptions options = new DataTransferOptions();

            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadPageBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetPageBlobClient(GetNewBlobName()),
                size: fileSize,
                cancellationToken: cts.Token);
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(1, Constants.KB, 200)]
        [TestCase(6, Constants.KB, 200)]
        [TestCase(32, Constants.KB, 200)]
        public async Task LocalToPageBlob_SmallConcurrency(int concurrency, int size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

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

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadPageBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetPageBlobClient(GetNewBlobName()),
                size: size,
                options: options,
                cancellationToken: cts.Token);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(1, Constants.MB, 200)]
        [TestCase(2, Constants.MB, 300)]
        [TestCase(6, Constants.MB, 300)]
        [TestCase(1, 257 * Constants.MB, 200)]
        [TestCase(2, 257 * Constants.MB, 300)]
        [TestCase(6, 257 * Constants.MB, 300)]
        [TestCase(32, 257 * Constants.MB, 1000)]
        public async Task LocalToPageBlob_LargeConcurrency(int concurrency, int size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadPageBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetPageBlobClient(GetNewBlobName()),
                size: size,
                cancellationToken: cts.Token);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33003")]
        [Test]
        [LiveOnly]
        [TestCase(2, Constants.KB, 10)]
        [TestCase(6, Constants.KB, 10)]
        [TestCase(2, 2 * Constants.KB, 10)]
        [TestCase(6, 2 * Constants.KB, 10)]
        public async Task LocalToPageBlob_SmallMultiple(int blobCount, int fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            foreach (var _ in Enumerable.Range(0, blobCount))
            {
                await UploadPageBlobAndVerify(
                    Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                    testContainer.Container.GetPageBlobClient(GetNewBlobName()),
                    size: fileSize,
                    cancellationToken: cts.Token);
            }
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(2, 4 * Constants.MB, 60)]
        [TestCase(6, 4 * Constants.MB, 60)]
        [TestCase(2, Constants.GB, 1000)]
        [TestCase(6, Constants.GB, 6000)]
        [TestCase(32, Constants.GB, 32000)]
        [TestCase(100, Constants.GB, 10000)]
        public async Task LocalToPageBlob_LargeMultiple(int blobCount, long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            foreach (var _ in Enumerable.Range(0, blobCount))
            {
                await UploadPageBlobAndVerify(
                    Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                    testContainer.Container.GetPageBlobClient(GetNewBlobName()),
                    size: fileSize,
                    cancellationToken: cts.Token);
            }
        }

        [RecordedTest]
        public async Task LocalToPageBlob_SmallChunks()
        {
            long size = 12 * Constants.KB;
            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = Constants.KB,
                MaximumTransferChunkSize = Constants.KB
            };

            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            await UploadPageBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetPageBlobClient(GetNewBlobName()),
                size: size,
                options: options);
        }
        #endregion SingleUpload Page Blob

        #region SingleUpload Append Blob
        private async Task UploadAppendBlobAndVerify(
            string filePath,
            AppendBlobClient blob,
            long size = Constants.KB,
            TransferManagerOptions transferManagerOptions = default,
            DataTransferOptions options = default,
            CancellationToken cancellationToken = default)
        {
            using (Stream fs = File.OpenWrite(filePath))
            {
                await (await CreateLimitedMemoryStream(size)).CopyToAsync(fs, bufferSize: Constants.KB, cancellationToken);
            }

            LocalFileStorageResource sourceResource = new(filePath);
            AppendBlobStorageResource destResource = new(blob);

            await new TransferValidator()
            {
                TransferManager = new TransferManager(transferManagerOptions)
            }.TransferAndVerifyAsync(
                sourceResource,
                destResource,
                async cToken => await blob.OpenReadAsync(cancellationToken: cToken),
                cToken => Task.FromResult(File.OpenRead(filePath) as Stream),
                options,
                cancellationToken);
        }

        [RecordedTest]
        public async Task LocalToAppendBlob()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            await UploadAppendBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetAppendBlobClient(GetNewBlobName()));
        }

        [RecordedTest]
        public async Task LocalToAppend_SmallChunk()
        {
            long size = Constants.KB;
            int waitTimeInSec = 25;

            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 500,
            };

            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadAppendBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetAppendBlobClient(GetNewBlobName()),
                options: options,
                size: size,
                cancellationToken: cts.Token).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task LocalToAppendBlob_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            int size = Constants.KB;
            int waitTimeInSec = 10;
            // Create blob
            AppendBlobClient destClient = testContainer.Container.GetAppendBlobClient(GetNewBlobName());
            await (await CreateLimitedMemoryStream(size)).CopyToAsync(await destClient.OpenWriteAsync(true));

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };

            // Start transfer and await for completion.
            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadAppendBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                destClient,
                size: size,
                options: options,
                cancellationToken: cts.Token);
        }

        [RecordedTest]
        public async Task LocalToAppendBlob_Overwrite_NotExists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();
            int size = Constants.KB;
            int waitTimeInSec = 10;

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };

            // Start transfer and await for completion.
            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadAppendBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetAppendBlobClient(GetNewBlobName()),
                size: size,
                options: options,
                cancellationToken: cts.Token);
        }

        [RecordedTest]
        public async Task LocalToAppendBlob_Skip_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            AppendBlobClient destinationClient = await CreateAppendBlob(testContainer.Container, originalSourceFile, blobName, size);

            // Act
            // Create new source file
            string newSourceFile = await CreateRandomFileAsync(Path.GetTempPath(), size: size);
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists,
            };
            StorageResourceItem sourceResource = new LocalFileStorageResource(newSourceFile);
            StorageResourceItem destinationResource = new AppendBlobStorageResource(destinationClient);
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleSkippedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
            Assert.IsTrue(await destinationClient.ExistsAsync());
            // Verify Upload - That we skipped over and didn't reupload something new.
            using (FileStream fileStream = File.OpenRead(originalSourceFile))
            {
                await DownloadAndAssertAsync(fileStream, destinationClient);
            }
        }

        [RecordedTest]
        public async Task LocalToAppendBlob_Failure_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            AppendBlobClient destinationClient = await CreateAppendBlob(testContainer.Container, originalSourceFile, blobName, size);

            // Make destination file name but do not create the file beforehand.
            // Create new source file
            string newSourceFile = await CreateRandomFileAsync(Path.GetTempPath(), size: size);

            // Act
            // Create options bag to fail and keep track of the failure.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            StorageResourceItem sourceResource = new LocalFileStorageResource(newSourceFile);
            StorageResourceItem destinationResource = new AppendBlobStorageResource(destinationClient);
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleFailedCheck(1);
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(await destinationClient.ExistsAsync());
            Assert.NotNull(testEventsRaised.FailedEvents.First().Exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("The specified blob already exists."));
            // Verify Upload - That we skipped over and didn't reupload something new.
            using (FileStream fileStream = File.OpenRead(originalSourceFile))
            {
                await DownloadAndAssertAsync(fileStream, destinationClient);
            }
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(1000, 10)]
        [TestCase(4 * Constants.KB, 60)]
        [TestCase(5 * Constants.KB, 60)]
        public async Task LocalToAppendBlob_SmallSize(long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadAppendBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetAppendBlobClient(GetNewBlobName()),
                size: fileSize,
                cancellationToken: cts.Token);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(Constants.MB, 60)]
        [TestCase(257 * Constants.MB, 600)]
        [TestCase(400 * Constants.MB, 500)]
        [TestCase(800 * Constants.MB, 500)]
        [TestCase(Constants.GB, 1500)]
        public async Task LocalToAppendBlob_LargeSize(long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadAppendBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetAppendBlobClient(GetNewBlobName()),
                size: fileSize,
                cancellationToken: cts.Token);
        }

        [RecordedTest]
        [TestCase(1, Constants.KB, 10)]
        [TestCase(1, 4 * Constants.KB, 20)]
        [TestCase(6, 4 * Constants.KB, 20)]
        [TestCase(6, 10 * Constants.KB, 20)]
        [TestCase(32, 10 * Constants.KB, 20)]
        public async Task LocalToAppendBlob_SmallConcurrency(int concurrency, int size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512
            };

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadAppendBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetAppendBlobClient(GetNewBlobName()),
                size: size,
                options: options,
                cancellationToken: cts.Token);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(1, Constants.MB, 200)]
        [TestCase(6, Constants.MB, 200)]
        [TestCase(32, Constants.MB, 200)]
        [TestCase(1, 500 * Constants.MB, 200)]
        [TestCase(4, 500 * Constants.MB, 200)]
        [TestCase(16, 500 * Constants.MB, 200)]
        [TestCase(16, Constants.GB, 200)]
        [TestCase(32, Constants.GB, 200)]
        public async Task LocalToAppendBlob_LargeConcurrency(int concurrency, int size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            await UploadAppendBlobAndVerify(
                Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                testContainer.Container.GetAppendBlobClient(GetNewBlobName()),
                size: size,
                transferManagerOptions: managerOptions,
                cancellationToken: cts.Token);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33003")]
        [Test]
        [LiveOnly]
        [TestCase(2, 0, 30)]
        [TestCase(6, 0, 30)]
        [TestCase(2, Constants.KB, 30)]
        [TestCase(6, Constants.KB, 30)]
        [TestCase(2, 2 * Constants.KB, 30)]
        [TestCase(6, 2 * Constants.KB, 30)]
        public async Task LocalToAppendBlob_SmallMultiple(int blobCount, long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            foreach (var _ in Enumerable.Range(0, blobCount))
            {
                await UploadAppendBlobAndVerify(
                    Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                    testContainer.Container.GetAppendBlobClient(GetNewBlobName()),
                    size: fileSize,
                    cancellationToken: cts.Token);
            }
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(2, Constants.MB, 300)]
        [TestCase(6, Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 1000)]
        [TestCase(2, 400 * Constants.MB, 400)]
        [TestCase(6, 400 * Constants.MB, 600)]
        [TestCase(32, 400 * Constants.MB, 1000)]
        [TestCase(2, Constants.GB, 1000)]
        [TestCase(6, Constants.GB, 6000)]
        [TestCase(32, Constants.GB, 32000)]
        [TestCase(100, Constants.GB, 10000)]
        public async Task LocalToAppendBlob_LargeMultiple(int blobCount, long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(waitTimeInSec));
            foreach (var _ in Enumerable.Range(0, blobCount))
            {
                await UploadAppendBlobAndVerify(
                    Path.Combine(localDirectory.DirectoryPath, GetNewBlobName()),
                    testContainer.Container.GetAppendBlobClient(GetNewBlobName()),
                    size: fileSize,
                    cancellationToken: cts.Token);
            }
        }
        #endregion SingleUpload Append Blob

        #region Single Concurrency
        private async Task<DataTransfer> CreateStartTransfer(
            BlobContainerClient containerClient,
            int concurrency,
            bool createFailedCondition = false,
            DataTransferOptions options = default,
            int size = Constants.KB)
        {
            // Arrange
            // Create destination
            string destinationBlobName = GetNewBlobName();
            BlockBlobClient destinationClient;
            if (createFailedCondition)
            {
                destinationClient = await CreateBlockBlob(containerClient, Path.GetTempFileName(), destinationBlobName, size);
            }
            else
            {
                destinationClient = containerClient.GetBlockBlobClient(destinationBlobName);
            }
            StorageResourceItem destinationResource = new BlockBlobStorageResource(destinationClient);

            // Create new source file
            using Stream originalStream = await CreateLimitedMemoryStream(size);
            string localSourceFile = Path.GetTempFileName();
            // create a new file and copy contents of stream into it, and then close the FileStream
            // so the StagedUploadAsync call is not prevented from reading using its FileStream.
            using (FileStream fileStream = File.Create(localSourceFile))
            {
                await originalStream.CopyToAsync(fileStream);
            }
            StorageResourceItem sourceResource = new LocalFileStorageResource(localSourceFile);

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

            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(test.Container, 1, options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            await testEventsRaised.AssertSingleCompletedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            await testEventsRaised.AssertSingleFailedCheck(1);
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            await testEventsRaised.AssertSingleSkippedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a EnsureCompleted
            DataTransfer transfer = await CreateStartTransfer(test.Container, 1, options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            TestTransferWithTimeout.WaitForCompletion(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleCompletedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            TestTransferWithTimeout.WaitForCompletion(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleFailedCheck(1);
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted_Skipped()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a EnsureCompleted
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                1,
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
