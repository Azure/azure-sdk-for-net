﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
using System.Linq;

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferSyncCopyTests : DataMovementBlobTestBase
    {
        public StartTransferSyncCopyTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        internal class VerifyBlockBlobCopyFromUriInfo
        {
            public readonly string SourceLocalPath;
            public readonly StorageResource SourceResource;
            public readonly StorageResource DestinationResource;
            public readonly BlockBlobClient DestinationClient;
            public TestEventsRaised testEventsRaised;
            public DataTransfer DataTransfer;
            public bool CompletedStatus;

            public VerifyBlockBlobCopyFromUriInfo(
                string sourceLocalPath,
                StorageResource sourceResource,
                StorageResource destinationResource,
                BlockBlobClient destinationClient,
                TestEventsRaised eventsRaised,
                bool completed)
            {
                SourceLocalPath = sourceLocalPath;
                SourceResource = sourceResource;
                DestinationResource = destinationResource;
                DestinationClient = destinationClient;
                testEventsRaised = eventsRaised;
                CompletedStatus = completed;
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
            List<string> destinationBlobNames = default,
            List<TransferOptions> options = default)
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
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

            // Populate Options and TestRaisedOptions
            List<TestEventsRaised> eventsRaisedList = TestEventsRaised.PopulateTestOptions(blobCount, ref options);

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };

            List<VerifyBlockBlobCopyFromUriInfo> copyBlobInfo = new List<VerifyBlockBlobCopyFromUriInfo>(blobCount);
            // Initialize BlobDataController
            TransferManager BlobDataController = new TransferManager(transferManagerOptions);

            // Upload set of VerifyCopyFromUriInfo blobs to Copy
            for (int i = 0; i < blobCount; i++)
            {
                bool completed = false;
                // Set up Blob to be Copyed
                var data = GetRandomBuffer(size);
                using Stream originalStream = await CreateLimitedMemoryStream(size);
                string localSourceFile = Path.Combine(testDirectory.DirectoryPath, sourceBlobNames[i]);
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

                StorageResource sourceResource = new BlockBlobStorageResource(originalBlob);
                // Set up destination client
                BlockBlobClient destClient = InstrumentClient(container.GetBlockBlobClient(string.Concat(destinationBlobNames[i])));
                StorageResource destinationResource = new BlockBlobStorageResource(destClient,
                    new BlockBlobStorageResourceOptions()
                    {
                        CopyMethod = TransferCopyMethod.SyncCopy
                    });
                copyBlobInfo.Add(new VerifyBlockBlobCopyFromUriInfo(
                    localSourceFile,
                    sourceResource,
                    destinationResource,
                    destClient,
                    eventsRaisedList[i],
                    completed));
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
                Assert.NotNull(copyBlobInfo[i].DataTransfer);
                CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                await copyBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                Assert.IsTrue(copyBlobInfo[i].DataTransfer.HasCompleted);
                Assert.AreEqual(StorageTransferStatus.Completed, copyBlobInfo[i].DataTransfer.TransferStatus);

                // Verify Copy - using original source File and Copying the destination
                copyBlobInfo[i].testEventsRaised.AssertSingleCompletedCheck();
                using (FileStream fileStream = File.OpenRead(copyBlobInfo[i].SourceLocalPath))
                {
                    await DownloadAndAssertAsync(fileStream, copyBlobInfo[i].DestinationClient).ConfigureAwait(false);
                }
            }
        }

        [RecordedTest]
        public async Task BlockBlobToBlockBlob()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            // No Option Copy bag or manager options bag, plain Copy
            await CopyBlockBlobsAndVerify(testContainer.Container).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task BlockBlobToBlockBlob_SmallChunk()
        {
            long size = Constants.KB;
            int waitTimeInSec = 10;

            TransferOptions options = new TransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            List<TransferOptions> optionsList = new List<TransferOptions>() { options };
            await CopyBlockBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(100, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(2 * Constants.KB, 10)]
        public async Task BlockBlobToBlockBlob_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            await CopyBlockBlobsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(5 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 400)]
        [TestCase(Constants.GB, 1000)]
        public async Task BlockBlobToBlockBlob_LargeSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            await CopyBlockBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task BlockBlobToBlockBlob_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.Combine(testDirectory.DirectoryPath, blobName);
            int size = Constants.KB;
            // Create blob
            BlockBlobClient destClient = await CreateBlockBlob(testContainer.Container, localSourceFile, blobName, size);

            // Act
            // Create options bag to overwrite any existing destination.
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<TransferOptions> optionsList = new List<TransferOptions>() { options };
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            int size = Constants.KB;
            int waitTimeInSec = 10;

            // Act
            // Create options bag to overwrite any existing destination.
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<TransferOptions> optionsList = new List<TransferOptions>() { options };

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.Combine(testDirectory.DirectoryPath, blobName);
            int size = Constants.KB;
            BlockBlobClient destinationClient = await CreateBlockBlob(
                testContainer.Container,
                originalSourceFile,
                blobName,
                size);

            // Act
            // Create options bag to overwrite any existing destination.
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip,
            };

            // Create new source block blob.
            string newSourceFile = Path.Combine(testDirectory.DirectoryPath, GetNewBlobName());
            BlockBlobClient blockBlobClient = await CreateBlockBlob(
                testContainer.Container,
                newSourceFile,
                GetNewBlobName(),
                size);
            StorageResource sourceResource = new BlockBlobStorageResource(blockBlobClient);
            StorageResource destinationResource = new BlockBlobStorageResource(destinationClient);
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

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
            testEventsRaised.AssertSingleSkippedCheck();
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

            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.Combine(testDirectory.DirectoryPath, blobName);
            int size = Constants.KB;
            BlockBlobClient destinationClient = await CreateBlockBlob(testContainer.Container, originalSourceFile, blobName, size);

            // Act
            // Create options bag to fail and keep track of the failure.
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            // Create new source block blob.
            string newSourceFile = Path.Combine(testDirectory.DirectoryPath, GetNewBlobName());
            BlockBlobClient blockBlobClient = await CreateBlockBlob(
                testContainer.Container,
                newSourceFile,
                GetNewBlobName(),
                size);
            StorageResource sourceResource = new BlockBlobStorageResource(blockBlobClient);
            StorageResource destinationResource = new BlockBlobStorageResource(destinationClient,
                new BlockBlobStorageResourceOptions()
                {
                    CopyMethod = TransferCopyMethod.SyncCopy
                });
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
            testEventsRaised.AssertSingleFailedCheck();
            Assert.NotNull(testEventsRaised.FailedEvents.First().Exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("The specified blob already exists."));
            // Verify Upload - That we skipped over and didn't reupload something new.
            using (FileStream fileStream = File.OpenRead(originalSourceFile))
            {
                await DownloadAndAssertAsync(fileStream, destinationClient);
            }
        }

        [RecordedTest]
        public async Task AppendBlobToAppendBlob_Error()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            int size = Constants.KB;

            // Act
            // Create options bag to fail and keep track of the failure.
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            // Create new source block blob.
            string sourceBlobName = GetNewBlobName();
            string newSourceFile = Path.Combine(testDirectory.DirectoryPath, sourceBlobName);
            AppendBlobClient sourceBlob = await CreateAppendBlob(
                testContainer.Container,
                newSourceFile,
                sourceBlobName,
                size);

            // Create failure scenario by creating destinationBlob
            string destinationBlobName = GetNewBlobName();
            AppendBlobClient destinationBlob = await CreateAppendBlob(
                containerClient: testContainer.Container,
                localSourceFile: Path.Combine(testDirectory.DirectoryPath, destinationBlobName),
                blobName: destinationBlobName,
                size: size);

            StorageResource sourceResource = new AppendBlobStorageResource(sourceBlob);
            StorageResource destinationResource = new AppendBlobStorageResource(destinationBlob,
                new AppendBlobStorageResourceOptions()
                {
                    CopyMethod = TransferCopyMethod.SyncCopy
                });
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
            testEventsRaised.AssertSingleFailedCheck();
            Assert.NotNull(testEventsRaised.FailedEvents.First().Exception, "Excepted failure: Failure was supposed to be raised during the test");
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
        }

        [RecordedTest]
        public async Task PageBlobToPageBlob_Error()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            int size = Constants.KB;

            // Act
            // Create options bag to fail and keep track of the failure.
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            // Create new source block blob.
            string newSourceFile = Path.GetTempFileName();
            PageBlobClient sourceClient = await CreatePageBlob(
                testContainer.Container,
                newSourceFile,
                GetNewBlobName(),
                size);
            PageBlobClient destinationClient = testContainer.Container.GetPageBlobClient(GetNewBlobName());
            StorageResource sourceResource = new PageBlobStorageResource(sourceClient);
            StorageResource destinationResource = new PageBlobStorageResource(destinationClient,
                new PageBlobStorageResourceOptions()
                {
                    CopyMethod = TransferCopyMethod.SyncCopy
                });
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
            testEventsRaised.AssertSingleFailedCheck();
            Assert.NotNull(testEventsRaised.FailedEvents.First().Exception, "Excepted failure: Failure was supposed to be raised during the test");
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("The copy source must be a block blob."));
        }
        #endregion

        #region Single Concurrency
        private async Task<DataTransfer> CreateStartTransfer(
            BlobContainerClient containerClient,
            int concurrency,
            bool createFailedCondition = false,
            TransferOptions options = default,
            int size = Constants.KB)
        {
            // Arrange
            // Create source local file for checking, and source blob
            string sourceBlobName = GetNewBlobName();
            string destinationBlobName = GetNewBlobName();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            BlockBlobClient destinationClient;
            if (createFailedCondition)
            {
                destinationClient = await CreateBlockBlob(containerClient, Path.Combine(testDirectory.DirectoryPath, destinationBlobName), destinationBlobName, size);
            }
            else
            {
                destinationClient = containerClient.GetBlockBlobClient(destinationBlobName);
            }

            // Create new source block blob.
            string newSourceFile = Path.Combine(testDirectory.DirectoryPath, sourceBlobName);
            BlockBlobClient blockBlobClient = await CreateBlockBlob(containerClient, newSourceFile, sourceBlobName, size);
            StorageResource sourceResource = new BlockBlobStorageResource(blockBlobClient);
            StorageResource destinationResource = new BlockBlobStorageResource(destinationClient,
                new BlockBlobStorageResourceOptions()
                {
                    CopyMethod = TransferCopyMethod.SyncCopy
                });

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
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(test.Container, 1, options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await transfer.AwaitCompletion(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            testEventsRaised.AssertSingleCompletedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.Completed, transfer.TransferStatus);
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Failed()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail
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
            await transfer.AwaitCompletion(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            testEventsRaised.AssertSingleFailedCheck();
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            // Create transfer options with Skipping available
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip
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
            await transfer.AwaitCompletion(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            testEventsRaised.AssertSingleSkippedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a EnsureCompleted
            DataTransfer transfer = await CreateStartTransfer(test.Container, 1, options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            transfer.EnsureCompleted(cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertSingleCompletedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.Completed, transfer.TransferStatus);
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted_Failed()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail
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
            transfer.EnsureCompleted(cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertSingleFailedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted_Skipped()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            // Create transfer options with Skipping available
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip
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
