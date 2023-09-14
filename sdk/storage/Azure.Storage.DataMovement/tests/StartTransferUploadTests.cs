// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
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
using Azure.Storage.Blobs.Tests;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using Microsoft.CodeAnalysis;
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
        private async Task UploadBlockBlobsAndVerify(
            BlobContainerClient container,
            long size = Constants.KB,
            int waitTimeInSec = 30,
            TransferManagerOptions transferManagerOptions = default,
            int blobCount = 1,
            List<string> blobNames = default,
            List<DataTransferOptions> options = default)
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Populate blobNames list for number of blobs to be created
            if (blobNames == default || blobNames?.Count == 0)
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
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure
            };

            List<VerifyUploadBlobContentInfo> uploadedBlobInfo = new List<VerifyUploadBlobContentInfo>(blobCount);

            // Initialize TransferManager
            TransferManager transferManager = new TransferManager(transferManagerOptions);

            // Set up blob to upload
            for (int i = 0; i < blobCount; i++)
            {
                using Stream originalStream = await CreateLimitedMemoryStream(size);
                string localSourceFile = Path.Combine(testDirectory.DirectoryPath, GetNewBlobName());
                // create a new file and copy contents of stream into it, and then close the FileStream
                // so the StagedUploadAsync call is not prevented from reading using its FileStream.
                using (FileStream fileStream = File.OpenWrite(localSourceFile))
                {
                    await originalStream.CopyToAsync(fileStream);
                }

                // Set up destination client
                BlockBlobClient destClient = container.GetBlockBlobClient(blobNames[i]);
                StorageResourceItem destinationResource = new BlockBlobStorageResource(destClient);

                // Act
                StorageResourceItem sourceResource = new LocalFileStorageResource(localSourceFile);
                DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options[i]);

                uploadedBlobInfo.Add(new VerifyUploadBlobContentInfo(
                    sourceFile: localSourceFile,
                    destinationClient: destClient,
                    eventsRaised: eventRaisedList[i],
                    dataTransfer: transfer));
            }

            for (int i = 0; i < blobCount; i++)
            {
                // Assert
                Assert.NotNull(uploadedBlobInfo[i].DataTransfer);
                CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                await uploadedBlobInfo[i].DataTransfer.WaitForCompletionAsync(tokenSource.Token);
                Assert.IsTrue(uploadedBlobInfo[i].DataTransfer.HasCompleted);

                // Verify Upload
                await uploadedBlobInfo[i].EventsRaised.AssertSingleCompletedCheck();
                using (FileStream fileStream = File.OpenRead(uploadedBlobInfo[i].LocalPath))
                {
                    await DownloadAndAssertAsync(fileStream, uploadedBlobInfo[i].DestinationClient);
                }
            }
        }

        [RecordedTest]
        public async Task LocalToBlockBlob()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            await UploadBlockBlobsAndVerify(testContainer.Container);
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
                if (args.StorageTransferStatus == DataTransferStatus.InProgress)
                {
                    progressSeen = true;
                }
                return Task.CompletedTask;
            };

            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };
            await UploadBlockBlobsAndVerify(
                container: testContainer.Container,
                blobCount: optionsList.Count,
                options: optionsList);

            // Assert
            Assert.IsTrue(progressSeen);
        }

        [RecordedTest]
        public async Task LocalToBlockBlobSize_SmallChunk()
        {
            long fileSize = Constants.KB;
            int waitTimeInSec = 25;
            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };

            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };

            await UploadBlockBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                options: optionsList);
        }

        [RecordedTest]
        public async Task LocalToBlockBlob_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            int waitTimeInSec = 10;
            // Create blob
            BlockBlobClient destClient = await CreateBlockBlob(testContainer.Container, localSourceFile, blobName, size);

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };
            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };
            List<string> blobNames = new List<string>() { blobName };

            // Start transfer and await for completion.
            await UploadBlockBlobsAndVerify(
                container: testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                blobNames: blobNames,
                options: optionsList);
        }

        [RecordedTest]
        public async Task LocalToBlockBlob_Overwrite_NotExists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            int size = Constants.KB;
            int waitTimeInSec = 10;

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };
            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };

            // Start transfer and await for completion.
            await UploadBlockBlobsAndVerify(
                container: testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                options: optionsList);
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
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleSkippedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
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
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            Assert.IsTrue(await destinationClient.ExistsAsync());
            await testEventRaised.AssertSingleFailedCheck();
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

            await UploadBlockBlobsAndVerify(
                container: testContainer.Container,
                size: fileSize,
                waitTimeInSec: waitTimeInSec);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(257 * Constants.MB, 600)]
        [TestCase(500 * Constants.MB, 200)]
        [TestCase(700 * Constants.MB, 200)]
        [TestCase(Constants.GB, 1500)]
        public async Task LocalToBlockBlob_LargeSize(long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            await UploadBlockBlobsAndVerify(
                container: testContainer.Container,
                size: fileSize,
                waitTimeInSec: waitTimeInSec);
        }

        [RecordedTest]
        [TestCase(1, Constants.KB, 10)]
        [TestCase(2, Constants.KB, 10)]
        [TestCase(1, 4 * Constants.KB, 60)]
        [TestCase(2, 4 * Constants.KB, 60)]
        [TestCase(4, 16 * Constants.KB, 60)]
        public async Task LocalToBlockBlob_SmallConcurrency(int concurrency, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

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
            List<DataTransferOptions> optionsList = new List<DataTransferOptions> { options };

            await UploadBlockBlobsAndVerify(
                container: testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                transferManagerOptions: managerOptions,
                options: optionsList);
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

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            await UploadBlockBlobsAndVerify(
                container: testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                transferManagerOptions: managerOptions);
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
        public async Task LocalToBlockBlob_SmallMultiple(int blobCount, long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            await UploadBlockBlobsAndVerify(
                container: testContainer.Container,
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                blobCount: blobCount);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        [TestCase(3, Constants.GB, 2000)]
        public async Task LocalToBlockBlob_LargeMultiple(int blobCount, long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            await UploadBlockBlobsAndVerify(
                container: testContainer.Container,
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                blobCount: blobCount);
        }
        #endregion SingleUpload Block Blob

        #region SingleUpload Page Blob
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
        private async Task UploadPageBlobsAndVerify(
            BlobContainerClient container,
            long size = Constants.KB,
            int waitTimeInSec = 30,
            int blobCount = 1,
            TransferManagerOptions transferManagerOptions = default,
            List<string> blobNames = default,
            List<DataTransferOptions> options = default)
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Populate blobNames list for number of blobs to be created
            if (blobNames == default || blobNames?.Count == 0)
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
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure
            };

            List<VerifyUploadBlobContentInfo> uploadedBlobInfo = new List<VerifyUploadBlobContentInfo>(blobCount);

            // Initialize BlobDataController
            TransferManager blobDataController = new TransferManager(transferManagerOptions);

            // Set up blob to upload
            for (int i = 0; i < blobCount; i++)
            {
                using Stream originalStream = await CreateLimitedMemoryStream(size);
                string localSourceFile = Path.GetTempFileName();
                // create a new file and copy contents of stream into it, and then close the FileStream
                // so the StagedUploadAsync call is not prevented from reading using its FileStream.
                using (FileStream fileStream = File.Create(localSourceFile))
                {
                    await originalStream.CopyToAsync(fileStream);
                }

                // Set up destination client
                PageBlobClient destClient = container.GetPageBlobClient(blobNames[i]);
                StorageResourceItem destinationResource = new PageBlobStorageResource(destClient);

                // Act
                StorageResourceItem sourceResource = new LocalFileStorageResource(localSourceFile);
                DataTransfer transfer = await blobDataController.StartTransferAsync(sourceResource, destinationResource, options[i]);

                uploadedBlobInfo.Add(new VerifyUploadBlobContentInfo(
                    localSourceFile,
                    destClient,
                    eventRaisedList[i],
                    transfer));
            }

            for (int i = 0; i < blobCount; i++)
            {
                // Assert
                Assert.NotNull(uploadedBlobInfo[i].DataTransfer);
                CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                await uploadedBlobInfo[i].DataTransfer.WaitForCompletionAsync(tokenSource.Token);
                Assert.IsTrue(uploadedBlobInfo[i].DataTransfer.HasCompleted);
                Assert.AreEqual(DataTransferStatus.Completed, uploadedBlobInfo[i].DataTransfer.TransferStatus);

                // Verify Upload
                await uploadedBlobInfo[i].EventsRaised.AssertSingleCompletedCheck();
                using (FileStream fileStream = File.OpenRead(uploadedBlobInfo[i].LocalPath))
                {
                    await DownloadAndAssertAsync(fileStream, uploadedBlobInfo[i].DestinationClient);
                }
            }
        }

        [RecordedTest]
        public async Task LocalToPageBlob()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            await UploadPageBlobsAndVerify(testContainer.Container);
        }

        [RecordedTest]
        public async Task LocalToPageBlob_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            int waitTimeInSec = 10;
            // Create blob
            PageBlobClient destClient = await CreatePageBlob(testContainer.Container, localSourceFile, blobName, size);

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };
            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };
            List<string> blobNames = new List<string>() { blobName };
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            await UploadPageBlobsAndVerify(
                container: testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                blobNames: blobNames,
                options: optionsList);
        }

        [RecordedTest]
        public async Task LocalToPageBlob_Overwrite_NotExists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            int size = Constants.KB;
            int waitTimeInSec = 10;

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };
            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            await UploadPageBlobsAndVerify(
                container: testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                options: optionsList);
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
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleSkippedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
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
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleFailedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
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
            var blobName = GetNewBlobName();
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            PageBlobClient destClient = testContainer.Container.GetPageBlobClient(blobName);

            await UploadPageBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container);
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
            var blobName = GetNewBlobName();
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            PageBlobClient destClient = testContainer.Container.GetPageBlobClient(blobName);

            await UploadPageBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container);
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(1, Constants.KB, 200)]
        [TestCase(6, Constants.KB, 200)]
        [TestCase(32, Constants.KB, 200)]
        public async Task LocalToPageBlob_SmallConcurrency(int concurrency, int size, int waitTimeInSec)
        {
            // Arrange
            var blobName = GetNewBlobName();
            await using DisposingContainer testContainer = await GetTestContainerAsync();

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
            List<DataTransferOptions> optionsList = new List<DataTransferOptions> { options };

            await UploadPageBlobsAndVerify(
                size: size,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                options: optionsList);
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
            var blobName = GetNewBlobName();
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            await UploadPageBlobsAndVerify(
                size: size,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33003")]
        [Test]
        [LiveOnly]
        [TestCase(2, Constants.KB, 10)]
        [TestCase(6, Constants.KB, 10)]
        [TestCase(2, 2 * Constants.KB, 10)]
        [TestCase(6, 2 * Constants.KB, 10)]
        public async Task LocalToPageBlob_SmallMultiple(int blobCount, long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            await UploadPageBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                blobCount: blobCount);
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

            await UploadPageBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                blobCount: blobCount);
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

            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };
            await UploadPageBlobsAndVerify(
                container: testContainer.Container,
                size: size,
                blobCount: optionsList.Count,
                options: optionsList);
        }
        #endregion SingleUpload Page Blob

        #region SingleUpload Append Blob
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
        private async Task UploadAppendBlobsAndVerify(
            BlobContainerClient container,
            long size = Constants.KB,
            int waitTimeInSec = 30,
            int blobCount = 1,
            TransferManagerOptions transferManagerOptions = default,
            List<string> blobNames = default,
            List<DataTransferOptions> options = default)
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Populate blobNames list for number of blobs to be created
            if (blobNames == default || blobNames?.Count == 0)
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
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure
            };

            List<VerifyUploadBlobContentInfo> uploadedBlobInfo = new List<VerifyUploadBlobContentInfo>(blobCount);

            // Initialize BlobDataController
            TransferManager blobDataController = new TransferManager(transferManagerOptions);

            // Set up blob to upload
            for (int i = 0; i < blobCount; i++)
            {
                using Stream originalStream = await CreateLimitedMemoryStream(size);
                string localSourceFile = Path.GetTempFileName();
                // create a new file and copy contents of stream into it, and then close the FileStream
                // so the StagedUploadAsync call is not prevented from reading using its FileStream.
                using (FileStream fileStream = File.Create(localSourceFile))
                {
                    await originalStream.CopyToAsync(fileStream);
                }

                // Set up destination client
                AppendBlobClient destClient = container.GetAppendBlobClient(blobNames[i]);
                StorageResourceItem destinationResource = new AppendBlobStorageResource(destClient);

                // Act
                StorageResourceItem sourceResource = new LocalFileStorageResource(localSourceFile);
                DataTransfer transfer = await blobDataController.StartTransferAsync(sourceResource, destinationResource, options[i]);

                uploadedBlobInfo.Add(new VerifyUploadBlobContentInfo(
                    localSourceFile,
                    destClient,
                    eventRaisedList[i],
                    transfer));
            }

            for (int i = 0; i < blobCount; i++)
            {
                // Assert
                Assert.NotNull(uploadedBlobInfo[i].DataTransfer);
                CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                await uploadedBlobInfo[i].DataTransfer.WaitForCompletionAsync(tokenSource.Token);
                Assert.IsTrue(uploadedBlobInfo[i].DataTransfer.HasCompleted);
                Assert.AreEqual(DataTransferStatus.Completed, uploadedBlobInfo[i].DataTransfer.TransferStatus);

                // Verify Upload
                await uploadedBlobInfo[i].EventsRaised.AssertSingleCompletedCheck();
                using (FileStream fileStream = File.OpenRead(uploadedBlobInfo[i].LocalPath))
                {
                    await DownloadAndAssertAsync(fileStream, uploadedBlobInfo[i].DestinationClient);
                }
            }
        }

        [RecordedTest]
        public async Task LocalToAppendBlob()
        {
            // Arrange
            await using DisposingContainer testContainer = await GetTestContainerAsync();

            await UploadAppendBlobsAndVerify(testContainer.Container);
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

            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };
            await UploadAppendBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task LocalToAppendBlob_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            int waitTimeInSec = 10;
            // Create blob
            AppendBlobClient destClient = await CreateAppendBlob(testContainer.Container, localSourceFile, blobName, size);

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };
            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };
            List<string> blobNames = new List<string>() { blobName };

            // Start transfer and await for completion.
            await UploadAppendBlobsAndVerify(
                container: testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                blobNames: blobNames,
                options: optionsList);
        }

        [RecordedTest]
        public async Task LocalToAppendBlob_Overwrite_NotExists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            int size = Constants.KB;
            int waitTimeInSec = 10;

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };
            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };

            // Start transfer and await for completion.
            await UploadAppendBlobsAndVerify(
                container: testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                options: optionsList);
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
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleSkippedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
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
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleFailedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
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
            var blobName = GetNewBlobName();
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            AppendBlobClient destClient = testContainer.Container.GetAppendBlobClient(blobName);

            await UploadAppendBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container);
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
            var blobName = GetNewBlobName();
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            AppendBlobClient destClient = testContainer.Container.GetAppendBlobClient(blobName);

            await UploadAppendBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container);
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
            var blobName = GetNewBlobName();
            await using DisposingContainer testContainer = await GetTestContainerAsync();
            AppendBlobClient destClient = testContainer.Container.GetAppendBlobClient(blobName);

            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512
            };
            List<DataTransferOptions> optionsList = new List<DataTransferOptions> { options };

            List<string> blobNames = new List<string>() { blobName };

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            await UploadAppendBlobsAndVerify(
                size: size,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                blobCount: blobNames.Count(),
                blobNames: blobNames,
                options: optionsList);
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

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            await UploadAppendBlobsAndVerify(
                container: testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                transferManagerOptions: managerOptions);
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

            await UploadAppendBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                blobCount: blobCount);
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

            await UploadAppendBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                blobCount: blobCount);
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
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            await testEventsRaised.AssertSingleCompletedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.Completed, transfer.TransferStatus);
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
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            await testEventsRaised.AssertSingleFailedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
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
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            await testEventsRaised.AssertSingleSkippedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
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
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleCompletedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.Completed, transfer.TransferStatus);
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
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleFailedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
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
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleSkippedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
        }
        #endregion

        [Test]
        public async Task SupportsLongFiles()
        {
            long fileSize = 5L * Constants.GB;

            StorageResourceItem srcResource = MockStorageResource.MakeSourceResource(fileSize, false, maxChunkSize: Constants.GB);
            StorageResourceItem dstResource = MockStorageResource.MakeDestinationResource(true, maxChunkSize: Constants.GB);
            TransferManager transferManager = new TransferManager();

            DataTransferOptions options = new();
            TestEventsRaised events = new(options);
            DataTransfer transfer = await transferManager.StartTransferAsync(srcResource, dstResource, options);
            await transfer.WaitForCompletionAsync();

            Assert.IsEmpty(events.FailedEvents);
            Assert.IsTrue(transfer.HasCompleted);
            await events.AssertSingleCompletedCheck();
        }
    }
}
