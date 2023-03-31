// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
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
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.DataMovement.Models;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferUploadTests : DataMovementBlobTestBase
    {
        public StartTransferUploadTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
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

        internal class VerifyUploadBlobContentInfo
        {
            public readonly string LocalPath;
            public BlobBaseClient DestinationClient;
            public SingleTransferOptions UploadOptions;
            public DataTransfer DataTransfer;

            public VerifyUploadBlobContentInfo(
                string sourceFile,
                BlobBaseClient destinationClient,
                SingleTransferOptions uploadOptions,
                DataTransfer dataTransfer)
            {
                LocalPath = sourceFile;
                DestinationClient = destinationClient;
                UploadOptions = uploadOptions;
                DataTransfer = dataTransfer;
            }
        };

        internal SingleTransferOptions CopySingleUploadOptions(SingleTransferOptions options)
        {
            SingleTransferOptions newOptions = new SingleTransferOptions()
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
            int waitTimeInSec = 10,
            TransferManagerOptions transferManagerOptions = default,
            int blobCount = 1,
            List<string> blobNames = default,
            List<SingleTransferOptions> options = default)
        {
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

            // Populate blobNames list for number of blobs to be created
            if (options == default || blobNames?.Count == 0)
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

            List<VerifyUploadBlobContentInfo> uploadedBlobInfo = new List<VerifyUploadBlobContentInfo>(blobCount);
            try
            {
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
                    BlockBlobClient destClient = container.GetBlockBlobClient(blobNames[i]);
                    StorageResource destinationResource = new BlockBlobStorageResource(destClient);

                    // Act
                    StorageResource sourceResource = new LocalFileStorageResource(localSourceFile);
                    DataTransfer transfer = await blobDataController.StartTransferAsync(sourceResource, destinationResource, options[i]);

                    uploadedBlobInfo.Add(new VerifyUploadBlobContentInfo(
                        sourceFile: localSourceFile,
                        destinationClient: destClient,
                        uploadOptions: options[i],
                        dataTransfer: transfer));
                }

                for (int i = 0; i < blobCount; i++)
                {
                    // Assert
                    Assert.NotNull(uploadedBlobInfo[i].DataTransfer);
                    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                    await uploadedBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                    Assert.IsTrue(uploadedBlobInfo[i].DataTransfer.HasCompleted);

                    // Verify Upload
                    using (FileStream fileStream = File.OpenRead(uploadedBlobInfo[i].LocalPath))
                    {
                        await DownloadAndAssertAsync(fileStream, uploadedBlobInfo[i].DestinationClient);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                // Cleanup - temporary local files (blobs cleaned up by diposing container)
                for (int i = 0; i < blobCount; i++)
                {
                    if (File.Exists(uploadedBlobInfo[i].LocalPath))
                    {
                        File.Delete(uploadedBlobInfo[i].LocalPath);
                    }
                }
            }
        }

        [RecordedTest]
        public async Task LocalToBlockBlob()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await UploadBlockBlobsAndVerify(testContainer.Container);
        }

        [RecordedTest]
        public async Task LocalToBlockBlob_EventHandler()
        {
            AutoResetEvent InProgressWait = new AutoResetEvent(false);

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

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
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
            int waitTimeInSec = 10;
            SingleTransferOptions options = new SingleTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            int waitTimeInSec = 10;
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            bool skippedSeen = false;
            BlockBlobClient destinationClient = await CreateBlockBlob(testContainer.Container, originalSourceFile, blobName, size);

            // Act
            // Create new source file
            string newSourceFile = await CreateRandomFileAsync(Path.GetTempPath(), size:size);
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip,
            };
            StorageResource sourceResource = new LocalFileStorageResource(newSourceFile);
            StorageResource destinationResource = new BlockBlobStorageResource(destinationClient);
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
        public async Task LocalToBlockBlob_Failure_Exists()
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

            // Make destination file name but do not create the file beforehand.
            // Create new source file
            string newSourceFile = await CreateRandomFileAsync(Path.GetTempPath(), size: size);

            // Act
            // Create options bag to fail and keep track of the failure.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            StorageResource sourceResource = new LocalFileStorageResource(newSourceFile);
            StorageResource destinationResource = new BlockBlobStorageResource(destinationClient);
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

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(1000, 10)]
        [TestCase(Constants.KB, 20)]
        [TestCase(4 * Constants.KB, 20)]
        public async Task LocalToBlockBlob_SmallSize(long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            SingleTransferOptions options = new SingleTransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions> { options };

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

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
            int waitTimeInSec = 10,
            int blobCount = 1,
            TransferManagerOptions transferManagerOptions = default,
            List<string> blobNames = default,
            List<SingleTransferOptions> options = default)
        {
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

            // Populate blobNames list for number of blobs to be created
            if (options == default || blobNames?.Count == 0)
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

            List<VerifyUploadBlobContentInfo> uploadedBlobInfo = new List<VerifyUploadBlobContentInfo>(blobCount);
            try
            {
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
                    StorageResource destinationResource = new PageBlobStorageResource(destClient);

                    // Act
                    StorageResource sourceResource = new LocalFileStorageResource(localSourceFile);
                    DataTransfer transfer = await blobDataController.StartTransferAsync(sourceResource, destinationResource, options[i]);

                    uploadedBlobInfo.Add(new VerifyUploadBlobContentInfo(
                        localSourceFile,
                        destClient,
                        options[i],
                        transfer));
                }

                for (int i = 0; i < blobCount; i++)
                {
                    // Assert
                    Assert.NotNull(uploadedBlobInfo[i].DataTransfer);
                    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                    await uploadedBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                    Assert.IsTrue(uploadedBlobInfo[i].DataTransfer.HasCompleted);
                    Assert.AreEqual(StorageTransferStatus.Completed, uploadedBlobInfo[i].DataTransfer.TransferStatus);

                    // Verify Upload
                    using (FileStream fileStream = File.OpenRead(uploadedBlobInfo[i].LocalPath))
                    {
                        await DownloadAndAssertAsync(fileStream, uploadedBlobInfo[i].DestinationClient);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                // Cleanup - temporary local files (blobs cleaned up by diposing container)
                for (int i = 0; i < blobCount; i++)
                {
                    if (File.Exists(uploadedBlobInfo[i].LocalPath))
                    {
                        File.Delete(uploadedBlobInfo[i].LocalPath);
                    }
                }
            }
        }

        [RecordedTest]
        public async Task LocalToPageBlob()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            await UploadPageBlobsAndVerify(testContainer.Container);
        }

        [RecordedTest]
        public async Task LocalToPageBlob_EventHandler()
        {
            SingleTransferOptions options = new SingleTransferOptions();
            bool progressSeen = true;
            options.TransferStatus += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    progressSeen = true;
                }
                return Task.CompletedTask;
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await UploadPageBlobsAndVerify(
                container: testContainer.Container,
                blobCount: optionsList.Count,
                options: optionsList);

            // Assert
            Assert.IsTrue(progressSeen);
        }

        [RecordedTest]
        public async Task LocalToPageBlob_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            int waitTimeInSec = 10;
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            bool skippedSeen = false;
            PageBlobClient destinationClient = await CreatePageBlob(testContainer.Container, originalSourceFile, blobName, size);

            // Act
            // Create new source file
            string newSourceFile = await CreateRandomFileAsync(Path.GetTempPath(), size: size);
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip,
            };
            StorageResource sourceResource = new LocalFileStorageResource(newSourceFile);
            StorageResource destinationResource = new PageBlobStorageResource(destinationClient);
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
        public async Task LocalToPageBlob_Failure_Exists()
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

            // Make destination file name but do not create the file beforehand.
            // Create new source file
            string newSourceFile = await CreateRandomFileAsync(Path.GetTempPath(), size: size);

            // Act
            // Create options bag to fail and keep track of the failure.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            StorageResource sourceResource = new LocalFileStorageResource(newSourceFile);
            StorageResource destinationResource = new PageBlobStorageResource(destinationClient);
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

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.KB, 60)]
        [TestCase(5 * Constants.KB, 60)]
        public async Task LocalToPageBlob_SmallSize(long fileSize, int waitTimeInSec)
        {
            SingleTransferOptions options = new SingleTransferOptions();

            // Arrange
            var blobName = GetNewBlobName();
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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
            SingleTransferOptions options = new SingleTransferOptions();

            // Arrange
            var blobName = GetNewBlobName();
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            SingleTransferOptions options = new SingleTransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512,
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions> { options };

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

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
            SingleTransferOptions options = new SingleTransferOptions()
            {
                InitialTransferSize = Constants.KB,
                MaximumTransferChunkSize = Constants.KB
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
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
            int waitTimeInSec = 10,
            int blobCount = 1,
            TransferManagerOptions transferManagerOptions = default,
            List<string> blobNames = default,
            List<SingleTransferOptions> options = default)
        {
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

            // Populate blobNames list for number of blobs to be created
            if (options == default || blobNames?.Count == 0)
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

            List<VerifyUploadBlobContentInfo> uploadedBlobInfo = new List<VerifyUploadBlobContentInfo>(blobCount);
            try
            {
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
                    StorageResource destinationResource = new AppendBlobStorageResource(destClient);

                    // Act
                    StorageResource sourceResource = new LocalFileStorageResource(localSourceFile);
                    DataTransfer transfer = await blobDataController.StartTransferAsync(sourceResource, destinationResource, options[i]);

                    uploadedBlobInfo.Add(new VerifyUploadBlobContentInfo(
                        localSourceFile,
                        destClient,
                        options[i],
                        transfer));
                }

                for (int i = 0; i < blobCount; i++)
                {
                    // Assert
                    Assert.NotNull(uploadedBlobInfo[i].DataTransfer);
                    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                    await uploadedBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                    Assert.IsTrue(uploadedBlobInfo[i].DataTransfer.HasCompleted);
                    Assert.AreEqual(StorageTransferStatus.Completed, uploadedBlobInfo[i].DataTransfer.TransferStatus);

                    // Verify Upload
                    using (FileStream fileStream = File.OpenRead(uploadedBlobInfo[i].LocalPath))
                    {
                        await DownloadAndAssertAsync(fileStream, uploadedBlobInfo[i].DestinationClient);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                // Cleanup - temporary local files (blobs cleaned up by diposing container)
                for (int i = 0; i < blobCount; i++)
                {
                    if (File.Exists(uploadedBlobInfo[i].LocalPath))
                    {
                        File.Delete(uploadedBlobInfo[i].LocalPath);
                    }
                }
            }
        }

        [RecordedTest]
        public async Task LocalToAppendBlob()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await UploadAppendBlobsAndVerify(testContainer.Container);
        }

        [RecordedTest]
        public async Task LocalToAppend_SmallChunk()
        {
            long size = Constants.KB;
            int waitTimeInSec = 10;

            SingleTransferOptions options = new SingleTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 500,
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await UploadAppendBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task LocalToAppendBlobEventHandler()
        {
            AutoResetEvent InProgressWait = new AutoResetEvent(false);

            string exceptionMessage = default;
            SingleTransferOptions options = new SingleTransferOptions();
            bool progressSeen = false;
            options.TransferStatus += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    progressSeen = true;
                }
                return Task.CompletedTask;
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await UploadAppendBlobsAndVerify(
                container: testContainer.Container,
                blobCount: optionsList.Count,
                options: optionsList);

            // Assert
            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                Assert.Fail(exceptionMessage);
            }
            Assert.IsTrue(progressSeen);
        }

        [RecordedTest]
        public async Task LocalToAppendBlob_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            int waitTimeInSec = 10;
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string originalSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            bool skippedSeen = false;
            AppendBlobClient destinationClient = await CreateAppendBlob(testContainer.Container, originalSourceFile, blobName, size);

            // Act
            // Create new source file
            string newSourceFile = await CreateRandomFileAsync(Path.GetTempPath(), size: size);
            // Create options bag to overwrite any existing destination.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip,
            };
            StorageResource sourceResource = new LocalFileStorageResource(newSourceFile);
            StorageResource destinationResource = new AppendBlobStorageResource(destinationClient);
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
        public async Task LocalToAppendBlob_Failure_Exists()
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

            // Make destination file name but do not create the file beforehand.
            // Create new source file
            string newSourceFile = await CreateRandomFileAsync(Path.GetTempPath(), size: size);

            // Act
            // Create options bag to fail and keep track of the failure.
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail,
            };
            StorageResource sourceResource = new LocalFileStorageResource(newSourceFile);
            StorageResource destinationResource = new AppendBlobStorageResource(destinationClient);
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

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(1000, 10)]
        [TestCase(4 * Constants.KB, 60)]
        [TestCase(5 * Constants.KB, 60)]
        public async Task LocalToAppendBlob_SmallSize(long fileSize, int waitTimeInSec)
        {
            // Arrange
            var blobName = GetNewBlobName();
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            AppendBlobClient destClient = testContainer.Container.GetAppendBlobClient(blobName);

            SingleTransferOptions options = new SingleTransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512
            };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions> { options };

            List<string> blobNames = new List<string>() { blobName };

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

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
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

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
            SingleTransferOptions options = default,
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
            StorageResource destinationResource = new BlockBlobStorageResource(destinationClient);

            // Create new source file
            using Stream originalStream = await CreateLimitedMemoryStream(size);
            string localSourceFile = Path.GetTempFileName();
            // create a new file and copy contents of stream into it, and then close the FileStream
            // so the StagedUploadAsync call is not prevented from reading using its FileStream.
            using (FileStream fileStream = File.Create(localSourceFile))
            {
                await originalStream.CopyToAsync(fileStream);
            }
            StorageResource sourceResource = new LocalFileStorageResource(localSourceFile);

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

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(test.Container, 1);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await transfer.AwaitCompletion(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.Completed, transfer.TransferStatus);
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Failed()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail
            };

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
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            // Create transfer options with Skipping available
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip
            };

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
            Assert.AreEqual(StorageTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            // Create transfer to do a EnsureCompleted
            DataTransfer transfer = await CreateStartTransfer(test.Container, 1);

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
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Fail
            };

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
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, transfer.TransferStatus);
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted_Skipped()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync(publicAccessType: Storage.Blobs.Models.PublicAccessType.BlobContainer);

            // Create transfer options with Skipping available
            SingleTransferOptions options = new SingleTransferOptions()
            {
                CreateMode = StorageResourceCreateMode.Skip
            };

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
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(StorageTransferStatus.CompletedWithSkippedTransfers, transfer.TransferStatus);
        }
        #endregion
    }
}
