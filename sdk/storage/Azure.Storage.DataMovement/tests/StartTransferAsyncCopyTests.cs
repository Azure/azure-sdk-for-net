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
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Models;
using NUnit.Framework;
using Azure.Storage.DataMovement.Blobs;
using System.Linq;

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
            public TestEventsRaised EventsRaised;
            public DataTransfer DataTransfer;
            public bool CompletedStatus;

            public VerifyBlockCopyFromUriInfo(
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
                EventsRaised = eventsRaised;
                CompletedStatus = completed;
                DataTransfer = default;
            }
        };

        internal class VerifyPageCopyFromUriInfo
        {
            public readonly string SourceLocalPath;
            public readonly StorageResource SourceResource;
            public readonly StorageResource DestinationResource;
            public readonly PageBlobClient DestinationClient;
            public TestEventsRaised EventsRaised;
            public DataTransfer DataTransfer;
            public bool CompletedStatus;

            public VerifyPageCopyFromUriInfo(
                string sourceLocalPath,
                StorageResource sourceResource,
                StorageResource destinationResource,
                PageBlobClient destinationClient,
                TestEventsRaised eventsRaised,
                bool completed)
            {
                SourceLocalPath = sourceLocalPath;
                SourceResource = sourceResource;
                DestinationResource = destinationResource;
                DestinationClient = destinationClient;
                EventsRaised = eventsRaised;
                CompletedStatus = completed;
                DataTransfer = default;
            }
        };

        internal class VerifyAppendCopyFromUriInfo
        {
            public readonly string SourceLocalPath;
            public readonly StorageResource SourceResource;
            public readonly StorageResource DestinationResource;
            public readonly AppendBlobClient DestinationClient;
            public TestEventsRaised EventsRaised;
            public DataTransfer DataTransfer;
            public bool CompletedStatus;

            public VerifyAppendCopyFromUriInfo(
                string sourceLocalPath,
                StorageResource sourceResource,
                StorageResource destinationResource,
                AppendBlobClient destinationClient,
                TestEventsRaised eventsRaised,
                bool completed)
            {
                SourceLocalPath = sourceLocalPath;
                SourceResource = sourceResource;
                DestinationResource = destinationResource;
                DestinationClient = destinationClient;
                EventsRaised = eventsRaised;
                CompletedStatus = completed;
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
            List<TestEventsRaised> eventRaisedList = TestEventsRaised.PopulateTestOptions(blobCount, ref options);

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };

            List<VerifyBlockCopyFromUriInfo> copyBlobInfo = new List<VerifyBlockCopyFromUriInfo>(blobCount);
            // Initialize BlobDataController
            TransferManager transferManager = new TransferManager(transferManagerOptions);

            // Upload set of VerifyCopyFromUriInfo blobs to Copy
            for (int i = 0; i < blobCount; i++)
            {
                bool completed = false;
                // Set up Blob to be Copyed
                using Stream originalStream = await CreateLimitedMemoryStream(size);
                string localSourceFile = Path.Combine(testDirectory.DirectoryPath, sourceBlobNames[i]);
                BlockBlobClient originalBlob = await CreateBlockBlob(container, localSourceFile, sourceBlobNames[i], size);

                // Set up event handler for the respective blob
                AutoResetEvent completedStatusWait = new AutoResetEvent(false);

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
                    eventRaisedList[i],
                    completed));
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
                Assert.NotNull(copyBlobInfo[i].DataTransfer);
                CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                await copyBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                Assert.IsTrue(copyBlobInfo[i].DataTransfer.HasCompleted);

                // Verify Copy - using original source File and Copying the destination
                using (FileStream fileStream = File.OpenRead(copyBlobInfo[i].SourceLocalPath))
                {
                    await DownloadAndAssertAsync(fileStream, copyBlobInfo[i].DestinationClient).ConfigureAwait(false);
                }
                copyBlobInfo[i].EventsRaised.AssertSingleCompletedCheck();
            }
        }

        [RecordedTest]
        public async Task BlockBlobToBlockBlob_SmallChunks()
        {
            long size = Constants.KB;
            int waitTimeInSec = 10;

            TransferOptions options = new TransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };
            List<TransferOptions> optionsList = new List<TransferOptions>() { options };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

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
        [TestCase(257 * Constants.MB, 400)]
        [TestCase(400 * Constants.MB, 400)]
        [TestCase(800 * Constants.MB, 400)]
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
        public async Task BlockBlobToPageBlob_ExpectedError()
        {
            // Arrange
            Exception exception = default;
            bool sourceResourceCheck = false;
            bool destinationResourceCheck = false;
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            int size = Constants.KB;

            // Act
            // Create options bag to fail and keep track of the failure.
            TransferOptions options = new TransferOptions()
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            int size = Constants.KB;

            // Act
            // Create options bag to fail and keep track of the failure.
            TransferOptions options = new TransferOptions()
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.Combine(testDirectory.DirectoryPath, blobName);
            int size = Constants.KB;
            bool skippedSeen = false;
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
            // Create new source block blob.
            string sourceBlobName = GetNewBlobName();
            string newSourceFile = Path.Combine(testDirectory.DirectoryPath, sourceBlobName);
            BlockBlobClient blockBlobClient = await CreateBlockBlob(
                testContainer.Container,
                newSourceFile,
                sourceBlobName,
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
            List<TestEventsRaised> eventRaisedList = TestEventsRaised.PopulateTestOptions(blobCount, ref options);

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };

            List<VerifyPageCopyFromUriInfo> copyBlobInfo = new List<VerifyPageCopyFromUriInfo>(blobCount);

            // Initialize BlobDataController
            TransferManager transferManager = new TransferManager(transferManagerOptions);

            // Upload set of VerifyCopyFromUriInfo blobs to Copy
            for (int i = 0; i < blobCount; i++)
            {
                bool completed = false;
                // Set up Blob to be Copyed
                using Stream originalStream = await CreateLimitedMemoryStream(size);
                string localSourceFile = Path.Combine(testDirectory.DirectoryPath, sourceBlobNames[i]);
                PageBlobClient originalBlob = await CreatePageBlob(container, localSourceFile, sourceBlobNames[i], size);

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
                    eventRaisedList[i],
                    completed));
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
                Assert.NotNull(copyBlobInfo[i].DataTransfer);
                CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                await copyBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                Assert.IsTrue(copyBlobInfo[i].DataTransfer.HasCompleted);

                // Verify Copy - using original source File and Copying the destination
                using (FileStream fileStream = File.OpenRead(copyBlobInfo[i].SourceLocalPath))
                {
                    await DownloadAndAssertAsync(fileStream, copyBlobInfo[i].DestinationClient).ConfigureAwait(false);
                }
                copyBlobInfo[i].EventsRaised.AssertSingleCompletedCheck();
            }
        }

        [RecordedTest]
        public async Task PageBlobToPageBlob_SmallChunks()
        {
            long size = Constants.KB;
            int waitTimeInSec = 10;

            TransferOptions options = new TransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };
            List<TransferOptions> optionsList = new List<TransferOptions>() { options };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

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
        [TestCase(0, 10)]
        [TestCase(512, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(2 * Constants.KB, 10)]
        public async Task PageBlobToPageBlob_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

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
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<TransferOptions> optionsList = new List<TransferOptions>() { options };
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
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<TransferOptions> optionsList = new List<TransferOptions>() { options };

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
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.Combine(testDirectory.DirectoryPath, blobName);
            int size = Constants.KB;
            bool skippedSeen = false;
            PageBlobClient destinationClient = await CreatePageBlob(
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
            TestEventsRaised testEventRaised = new TestEventsRaised(options);

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
            testEventRaised.AssertUnexpectedFailureCheck();
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
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.Combine(testDirectory.DirectoryPath, blobName);
            int size = Constants.KB;
            PageBlobClient destinationClient = await CreatePageBlob(testContainer.Container, originalSourceFile, blobName, size);

            // Act
            // Create options bag to fail and keep track of the failure.
            TransferOptions options = new TransferOptions()
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
            List<TestEventsRaised> eventRaisedList = TestEventsRaised.PopulateTestOptions(blobCount, ref options);

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure
            };

            List<VerifyAppendCopyFromUriInfo> copyBlobInfo = new List<VerifyAppendCopyFromUriInfo>(blobCount);

            // Initialize BlobDataController
            TransferManager transferManager = new TransferManager(transferManagerOptions);

            // Upload set of VerifyCopyFromUriInfo blobs to Copy
            for (int i = 0; i < blobCount; i++)
            {
                bool completed = false;
                // Set up Blob to be Copyed
                using Stream originalStream = await CreateLimitedMemoryStream(size);
                string localSourceFile = Path.Combine(testDirectory.DirectoryPath, sourceBlobNames[i]);
                AppendBlobClient originalBlob = await CreateAppendBlob(container, localSourceFile, sourceBlobNames[i], size);

                // Set up event handler for the respective blob
                AutoResetEvent completedStatusWait = new AutoResetEvent(false);

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
                    eventRaisedList[i],
                    completed));
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
                Assert.NotNull(copyBlobInfo[i].DataTransfer);
                CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                await copyBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                Assert.IsTrue(copyBlobInfo[i].DataTransfer.HasCompleted);

                // Verify Copy - using original source File and Copying the destination
                using (FileStream fileStream = File.OpenRead(copyBlobInfo[i].SourceLocalPath))
                {
                    await DownloadAndAssertAsync(fileStream, copyBlobInfo[i].DestinationClient).ConfigureAwait(false);
                }
                copyBlobInfo[i].EventsRaised.AssertSingleCompletedCheck();
            }
        }

        [RecordedTest]
        public async Task AppendBlobToAppendBlob_SmallChunks()
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

            await CopyAppendBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task AppendBlobToAppendBlob_SmallProgress()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            // Act
            await CopyAppendBlobsAndVerify(
                testContainer.Container).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(512, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(2 * Constants.KB, 10)]
        public async Task AppendBlobToAppendBlob_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

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
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<TransferOptions> optionsList = new List<TransferOptions>() { options };
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
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Overwrite,
            };
            List<TransferOptions> optionsList = new List<TransferOptions>() { options };

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
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.Combine(testDirectory.DirectoryPath, blobName);
            int size = Constants.KB;
            bool skippedSeen = false;
            AppendBlobClient destinationClient = await CreateAppendBlob(
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
            TestEventsRaised testEventRaised = new TestEventsRaised(options);
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

            testEventRaised.AssertSingleSkippedCheck();
            Assert.AreEqual(sourceResource.Path, testEventRaised.SkippedEvents.First().SourceResource.Path);
            Assert.AreEqual(destinationResource.Uri, testEventRaised.SkippedEvents.First().DestinationResource.Uri);
            Assert.AreEqual(transfer.Id, testEventRaised.SkippedEvents.First().TransferId);

            // Verify Upload - That we skipped over and didn't reupload something new.
            using (FileStream fileStream = File.OpenRead(originalSourceFile))
            {
                await DownloadAndAssertAsync(fileStream, destinationClient);
            }
        }

        [RecordedTest]
        public async Task AppendBlobToAppendBlob_Failure_Exists()
        {
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.Combine(testDirectory.DirectoryPath, blobName);
            int size = Constants.KB;
            AppendBlobClient destinationClient = await CreateAppendBlob(testContainer.Container, originalSourceFile, blobName, size);

            // Act
            // Create options bag to fail and keep track of the failure.
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail
            };
            TestEventsRaised failureTracking = new TestEventsRaised(options);
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
            Assert.AreEqual(1, failureTracking.FailedEvents.Count);
            TransferFailedEventArgs args = failureTracking.FailedEvents.First();
            Assert.AreEqual(sourceResource, args.SourceResource);
            Assert.AreEqual(destinationResource, args.DestinationResource);
            Assert.NotNull(args.Exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.IsTrue(args.Exception.Message.Contains("The specified blob already exists."));
            // Verify Upload - That we skipped over and didn't reupload something new.
            using (FileStream fileStream = File.OpenRead(originalSourceFile))
            {
                await DownloadAndAssertAsync(fileStream, destinationClient);
            }
        }
        #endregion AsyncCopy Source AppendBlob

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
            string destinationBlobName = GetNewBlobName();
            BlockBlobClient destinationClient;
            if (createFailedCondition)
            {
                destinationClient = await CreateBlockBlob(containerClient, Path.GetTempFileName(), sourceBlobName, size);
            }
            else
            {
                destinationClient = containerClient.GetBlockBlobClient(destinationBlobName);
            }

            // Create new source block blob.
            string newSourceFile = Path.Combine(localDirectoryPath, sourceBlobName);
            BlockBlobClient blockBlobClient = await CreateBlockBlob(containerClient, newSourceFile, sourceBlobName, size);
            StorageResource sourceResource = new BlockBlobStorageResource(blockBlobClient);
            StorageResource destinationResource = new BlockBlobStorageResource(destinationClient, new BlockBlobStorageResourceOptions()
            {
                CopyMethod = TransferCopyMethod.AsyncCopy,
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
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer to do a AwaitCompletion
            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventRaised = new TestEventsRaised(options);

            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: testDirectory.DirectoryPath,
                concurrency: 1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await transfer.AwaitCompletion(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            testEventRaised.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.Completed, transfer.TransferStatus);
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Failed()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
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
            Assert.AreEqual(1, testEventRaised.FailedEvents.Count);
            Assert.IsTrue(testEventRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
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
            testEventRaised.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer to do a EnsureCompleted
            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventRaised = new TestEventsRaised(options);
            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: testDirectory.DirectoryPath,
                concurrency: 1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            transfer.EnsureCompleted(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.Completed, transfer.TransferStatus);
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted_Failed()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
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
            transfer.EnsureCompleted(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
            Assert.AreEqual(1, testEventRaised.FailedEvents.Count);
            Assert.IsTrue(testEventRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted_Skipped()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer options with Skipping available
            TransferOptions options = new TransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip
            };
            TestEventsRaised testEventRaised = new TestEventsRaised(options);

            // Create transfer to do a EnsureCompleted
            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: testDirectory.DirectoryPath,
                concurrency: 1,
                createFailedCondition: true,
                options: options);

            // Act
            testEventRaised.AssertUnexpectedFailureCheck();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            transfer.EnsureCompleted(cancellationTokenSource.Token);

            // Assert
            testEventRaised.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
        }
        #endregion
    }
}
