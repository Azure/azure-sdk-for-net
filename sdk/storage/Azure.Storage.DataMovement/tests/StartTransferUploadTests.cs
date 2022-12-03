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
            public bool CompletedStatus;
            public Exception Exception;

            public VerifyUploadBlobContentInfo(
                string sourceFile,
                BlobBaseClient destinationClient,
                SingleTransferOptions uploadOptions,
                DataTransfer dataTransfer,
                bool completed,
                Exception exception)
            {
                LocalPath = sourceFile;
                DestinationClient = destinationClient;
                UploadOptions = uploadOptions;
                DataTransfer = dataTransfer;
                CompletedStatus = completed;
                Exception = exception;
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
                bool completed = false;
                Exception exception = null;
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

                    options[i].TransferStatus += (TransferStatusEventArgs args) =>
                    {
                        // Assert
                        if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                        {
                            completed = true;
                        }
                        return Task.CompletedTask;
                    };
                    options[i].TransferFailed += (TransferFailedEventArgs args) =>
                    {
                        // If we call Assert.Fail here it will throw an exception within the
                        // event handler and take down everything with it.
                        exception = args.Exception;
                        return Task.CompletedTask;
                    };

                    // Act
                    StorageResource sourceResource = new LocalFileStorageResource(localSourceFile);
                    DataTransfer transfer = await blobDataController.StartTransferAsync(sourceResource, destinationResource, options[i]);

                    uploadedBlobInfo.Add(new VerifyUploadBlobContentInfo(
                        sourceFile: localSourceFile,
                        destinationClient: destClient,
                        uploadOptions: options[i],
                        dataTransfer: transfer,
                        completed: completed,
                        exception: exception));
                }

                for (int i = 0; i < blobCount; i++)
                {
                    // Assert
                    if (uploadedBlobInfo[i].Exception != null)
                    {
                        Assert.Fail(uploadedBlobInfo[i].Exception.Message);
                    }
                    Assert.NotNull(uploadedBlobInfo[i].DataTransfer);
                    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                    await uploadedBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                    Assert.IsTrue(uploadedBlobInfo[i].DataTransfer.HasCompleted);
                    Assert.IsTrue(uploadedBlobInfo[i].CompletedStatus);

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
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 200)]
        [TestCase(Constants.GB, 500)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task LocalToBlockBlob_Progress(long size, int waitTimeInSec)
        {
            SingleTransferOptions options = new SingleTransferOptions();

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await UploadBlockBlobsAndVerify(
                testContainer.Container,
                size,
                waitTimeInSec,
                blobCount: optionsList.Count,
                options: optionsList);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task LocalToBlockBlob_EventHandler()
        {
            AutoResetEvent InProgressWait = new AutoResetEvent(false);

            SingleTransferOptions options = new SingleTransferOptions();
            options.TransferStatus += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    Assert.Fail(args.Exception.Message);
                    InProgressWait.Set();
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
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(400)));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task LocalToBlockBlobBlobSize_SmallChunk()
        {
            long fileSize = Constants.KB;
            int waitTimeInSec = 10;
            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };

            // Arrange
            var blobName = GetNewBlobName();
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient destClient = testContainer.Container.GetBlockBlobClient(blobName);

            options.TransferStatus += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    Assert.Fail(args.Exception.Message);
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };

            List<string> blobNames = new List<string>() { blobName };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };

            await UploadBlockBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                blobCount: blobNames.Count(),
                blobNames: blobNames,
                options: optionsList);

            // Assert
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(1000, 10)]
        [TestCase(Constants.MB, 60)]
        [TestCase(4 * Constants.MB, 60)]
        [TestCase(257 * Constants.MB, 200)]
        [TestCase(Constants.GB, 1500)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task LocalToBlockBlob_Size(long fileSize, int waitTimeInSec)
        {
            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();

            // Arrange
            var blobName = GetNewBlobName();
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient destClient = testContainer.Container.GetBlockBlobClient(blobName);

            options.TransferStatus += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    Assert.Fail(args.Exception.Message);
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };

            List<string> blobNames = new List<string>() { blobName };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };

            await UploadBlockBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                blobCount: blobNames.Count(),
                blobNames: blobNames,
                options: optionsList);

            // Assert
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        [TestCase(1, 257 * Constants.MB, 200)]
        [TestCase(1, Constants.MB, 200)]
        [TestCase(4, 257 * Constants.MB, 200)]
        [TestCase(16, 257 * Constants.MB, 200)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task LocalToBlockBlob_Concurrency(int concurrency, int size, int waitTimeInSec)
        {
            // Arrange
            var blobName = GetNewBlobName();
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient destClient = testContainer.Container.GetBlockBlobClient(blobName);

            List<string> blobNames = new List<string>() { blobName };

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            await UploadBlockBlobsAndVerify(
                size: size,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                blobCount: blobNames.Count(),
                blobNames: blobNames);
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(2, 4 * Constants.MB, 300)]
        [TestCase(6, 4 * Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task LocalToBlockBlob_Multiple(int blobCount, long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await UploadBlockBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
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
                    bool completed = false;
                    Exception exception = null;
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

                    options[i].TransferStatus += (TransferStatusEventArgs args) =>
                    {
                        // Assert
                        if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                        {
                        }
                        return Task.CompletedTask;
                    };
                    options[i].TransferFailed += (TransferFailedEventArgs args) =>
                    {
                        if (args.Exception != null)
                        {
                            // If we call Assert.Fail here it will throw an exception within the
                            // event handler and take down everything with it.
                            //Assert.Fail(args.Exception.Message);
                            //exception = args.Exception;
                        }
                        return Task.CompletedTask;
                    };

                    // Act
                    StorageResource sourceResource = new LocalFileStorageResource(localSourceFile);
                    DataTransfer transfer = await blobDataController.StartTransferAsync(sourceResource, destinationResource, options[i]);

                    uploadedBlobInfo.Add(new VerifyUploadBlobContentInfo(
                        localSourceFile,
                        destClient,
                        options[i],
                        transfer,
                        completed,
                        exception));
                }

                for (int i = 0; i < blobCount; i++)
                {
                    // Assert
                    if (uploadedBlobInfo[i].Exception != null)
                    {
                        Assert.Fail(uploadedBlobInfo[i].Exception.Message);
                    }
                    Assert.NotNull(uploadedBlobInfo[i].DataTransfer);
                    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                    await uploadedBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                    Assert.IsTrue(uploadedBlobInfo[i].DataTransfer.HasCompleted);
                    Assert.IsTrue(uploadedBlobInfo[i].CompletedStatus);

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
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 200)]
        [TestCase(Constants.GB, 500)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task LocalToPageBlob_Progress(long size, int waitTimeInSec)
        {
            AutoResetEvent CompletedProgressBytesWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await UploadPageBlobsAndVerify(
                testContainer.Container,
                size,
                waitTimeInSec,
                blobCount: optionsList.Count,
                options: optionsList);

            // Assert
            Assert.IsTrue(CompletedProgressBytesWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task LocalToPageBlobEventHandler()
        {
            AutoResetEvent InProgressWait = new AutoResetEvent(false);

            string exceptionMessage = default;
            SingleTransferOptions options = new SingleTransferOptions();
            options.TransferStatus += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    exceptionMessage = args.Exception.Message;
                    InProgressWait.Set();
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
            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                Assert.Fail(exceptionMessage);
            }
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(400)));
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(Constants.KB * 10, 10)]
        [TestCase(Constants.MB, 60)]
        [TestCase(4 * Constants.MB, 60)]
        [TestCase(5 * Constants.MB, 60)]
        [TestCase(257 * Constants.MB, 200)]
        [TestCase(Constants.GB, 1500)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task LocalToPageBlob_Size(long fileSize, int waitTimeInSec)
        {
            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();

            // Arrange
            var blobName = GetNewBlobName();
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            PageBlobClient destClient = testContainer.Container.GetPageBlobClient(blobName);
            string exceptionMessage = default;

            options.TransferStatus += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    //Assert.Fail(args.Exception.Message);
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };

            List<string> blobNames = new List<string>() { blobName };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };

            await UploadPageBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                blobCount: blobNames.Count(),
                blobNames: blobNames,
                options: optionsList);

            // Assert
            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                Assert.Fail(exceptionMessage);
            }
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        [TestCase(1, 257 * Constants.MB, 200)]
        [TestCase(1, Constants.MB, 200)]
        [TestCase(4, 257 * Constants.MB, 200)]
        [TestCase(16, 257 * Constants.MB, 200)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task LocalToPageBlob_Concurrency(int concurrency, int size, int waitTimeInSec)
        {
            // Arrange
            var blobName = GetNewBlobName();
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            PageBlobClient destClient = testContainer.Container.GetPageBlobClient(blobName);

            List<string> blobNames = new List<string>() { blobName };

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            await UploadPageBlobsAndVerify(
                size: size,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                blobCount: blobNames.Count(),
                blobNames: blobNames);
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(2, 4 * Constants.MB, 300)]
        [TestCase(6, 4 * Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task LocalToPageBlob_Multiple(int blobCount, long fileSize, int waitTimeInSec)
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
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task LocalToPageBlob_SmallChunks()
        {
            long size = 12 * Constants.KB;
            string exceptionMessage = default;
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

            // Assert
            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                Assert.Fail(exceptionMessage);
            }
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
                    bool completed = false;
                    Exception exception = null;
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

                    AutoResetEvent completedStatusWait = new AutoResetEvent(false);
                    options[i].TransferStatus += (TransferStatusEventArgs args) =>
                    {
                        // Assert
                        if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                        {
                            ///completed = true;
                        }
                        return Task.CompletedTask;
                    };
                    options[i].TransferFailed += (TransferFailedEventArgs args) =>
                    {
                        if (args.Exception != null)
                        {
                            //exception = args.Exception;
                        }
                        //failure = true;
                        return Task.CompletedTask;
                    };

                    // Act
                    StorageResource sourceResource = new LocalFileStorageResource(localSourceFile);
                    DataTransfer transfer = await blobDataController.StartTransferAsync(sourceResource, destinationResource, options[i]);

                    uploadedBlobInfo.Add(new VerifyUploadBlobContentInfo(
                        localSourceFile,
                        destClient,
                        options[i],
                        transfer,
                        completed,
                        exception));
                }

                for (int i = 0; i < blobCount; i++)
                {
                    // Assert
                    if (uploadedBlobInfo[i].Exception != null)
                    {
                        Assert.Fail(uploadedBlobInfo[i].Exception.Message);
                    }
                    Assert.NotNull(uploadedBlobInfo[i].DataTransfer);
                    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                    await uploadedBlobInfo[i].DataTransfer.AwaitCompletion(tokenSource.Token);
                    Assert.IsTrue(uploadedBlobInfo[i].DataTransfer.HasCompleted);
                    Assert.IsTrue(uploadedBlobInfo[i].CompletedStatus);

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
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 200)]
        [TestCase(Constants.GB, 500)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task LocalToAppendBlob_Progress(long size, int waitTimeInSec)
        {
            AutoResetEvent CompletedProgressBytesWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };
            await UploadAppendBlobsAndVerify(
                testContainer.Container,
                size,
                waitTimeInSec,
                blobCount: optionsList.Count,
                options: optionsList);

            // Assert
            Assert.IsTrue(CompletedProgressBytesWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
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
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task LocalToAppendBlobEventHandler()
        {
            AutoResetEvent InProgressWait = new AutoResetEvent(false);

            string exceptionMessage = default;
            SingleTransferOptions options = new SingleTransferOptions();
            options.TransferStatus += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    exceptionMessage = args.Exception.Message;
                    InProgressWait.Set();
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
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(400)));
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(1000, 10)]
        [TestCase(Constants.MB, 60)]
        [TestCase(4 * Constants.MB, 60)]
        [TestCase(5 * Constants.MB, 60)]
        [TestCase(257 * Constants.MB, 200)]
        [TestCase(Constants.GB, 1500)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task LocalToAppendBlob_Size(long fileSize, int waitTimeInSec)
        {
            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();

            string exceptionMessage = default;
            // Arrange
            var blobName = GetNewBlobName();
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            AppendBlobClient destClient = testContainer.Container.GetAppendBlobClient(blobName);

            options.TransferStatus += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.TransferFailed += (TransferFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    exceptionMessage = args.Exception.Message;
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };

            List<string> blobNames = new List<string>() { blobName };
            List<SingleTransferOptions> optionsList = new List<SingleTransferOptions>() { options };

            await UploadAppendBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                blobCount: blobNames.Count(),
                blobNames: blobNames,
                options: optionsList);

            // Assert
            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                Assert.Fail(exceptionMessage);
            }
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        [TestCase(1, 257 * Constants.MB, 200)]
        [TestCase(1, Constants.MB, 200)]
        [TestCase(4, 257 * Constants.MB, 200)]
        [TestCase(16, 257 * Constants.MB, 200)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task LocalToAppendBlob_Concurrency(int concurrency, int size, int waitTimeInSec)
        {
            // Arrange
            var blobName = GetNewBlobName();
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            AppendBlobClient destClient = testContainer.Container.GetAppendBlobClient(blobName);

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
                blobNames: blobNames);
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(2, 4 * Constants.MB, 300)]
        [TestCase(6, 4 * Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task LocalToAppendBlob_Multiple(int blobCount, long fileSize, int waitTimeInSec)
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
    }
}
