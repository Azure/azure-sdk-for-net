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
            public AutoResetEvent CompletedStatusWait;

            public VerifyUploadBlobContentInfo(
                string sourceFile,
                BlobBaseClient destinationClient,
                SingleTransferOptions uploadOptions,
                AutoResetEvent completedStatusWait)
            {
                LocalPath = sourceFile;
                DestinationClient = destinationClient;
                UploadOptions = uploadOptions;
                CompletedStatusWait = completedStatusWait;
            }
        };

        internal class VerifyDownloadBlobContentInfo
        {
            public readonly string SourceLocalPath;
            public readonly string DestinationLocalPath;
            public SingleTransferOptions DownloadOptions;
            public AutoResetEvent CompletedStatusWait;

            public VerifyDownloadBlobContentInfo(
                string sourceFile,
                string destinationFile,
                SingleTransferOptions downloadOptions,
                AutoResetEvent completedStatusWait)
            {
                SourceLocalPath = sourceFile;
                DestinationLocalPath = destinationFile;
                DownloadOptions = downloadOptions;
                CompletedStatusWait = completedStatusWait;
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

                    AutoResetEvent completedStatusWait = new AutoResetEvent(false);
                    options[i].TransferStatus += async (TransferStatusEventArgs args) =>
                    {
                        // Assert
                        if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                        {
                            bool exists = await destClient.ExistsAsync();
                            Assert.IsTrue(exists);
                            completedStatusWait.Set();
                        }
                    };
                    options[i].TransferFailed += (TransferFailedEventArgs args) =>
                    {
                        if (args.Exception != null)
                        {
                            Assert.Fail(args.Exception.Message);
                            completedStatusWait.Set();
                        }
                        return Task.CompletedTask;
                    };

                    uploadedBlobInfo.Add(new VerifyUploadBlobContentInfo(
                        localSourceFile,
                        destClient,
                        options[i],
                        completedStatusWait));

                    // Act
                    StorageResource sourceResource = LocalStorageResourceFactory.GetFile(localSourceFile);
                    await blobDataController.StartTransferAsync(sourceResource, destinationResource, options[i]);
                }

                for (int i = 0; i < blobCount; i++)
                {
                    // Assert
                    Assert.IsTrue(uploadedBlobInfo[i].CompletedStatusWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));

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
        public async Task LocalToBlockBlobProgress(long size, int waitTimeInSec)
        {
            AutoResetEvent CompletedProgressBytesWait = new AutoResetEvent(false);
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

            // Assert
            Assert.IsTrue(CompletedProgressBytesWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        public async Task LocalToBlockBlobEventHandler()
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
        public async Task LocalToBlockBlobBlobSize(long fileSize, int waitTimeInSec)
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
        public async Task LocalToBlockBlobConcurrency(int concurrency, int size, int waitTimeInSec)
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
        public async Task LocalToBlockBlobMultiple(int blobCount, long fileSize, int waitTimeInSec)
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

                    AutoResetEvent completedStatusWait = new AutoResetEvent(false);
                    options[i].TransferStatus += async (TransferStatusEventArgs args) =>
                    {
                        // Assert
                        if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                        {
                            bool exists = await destClient.ExistsAsync();
                            Assert.IsTrue(exists);
                            completedStatusWait.Set();
                        }
                    };
                    options[i].TransferFailed += (TransferFailedEventArgs args) =>
                    {
                        if (args.Exception != null)
                        {
                            Assert.Fail(args.Exception.Message);
                            completedStatusWait.Set();
                        }
                        return Task.CompletedTask;
                    };

                    uploadedBlobInfo.Add(new VerifyUploadBlobContentInfo(
                        localSourceFile,
                        destClient,
                        options[i],
                        completedStatusWait));

                    // Act
                    StorageResource sourceResource = LocalStorageResourceFactory.GetFile(localSourceFile);
                    await blobDataController.StartTransferAsync(sourceResource, destinationResource, options[i]);
                }

                for (int i = 0; i < blobCount; i++)
                {
                    // Assert
                    Assert.IsTrue(uploadedBlobInfo[i].CompletedStatusWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));

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
        public async Task LocalToPageBlobProgress(long size, int waitTimeInSec)
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
        public async Task LocalToPageBlobEventHandler()
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
            await UploadPageBlobsAndVerify(
                container: testContainer.Container,
                blobCount: optionsList.Count,
                options: optionsList);

            // Assert
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(400)));
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(Constants.KB * 10, 10)]
        [TestCase(Constants.MB, 60)]
        [TestCase(4 * Constants.MB, 60)]
        [TestCase(257 * Constants.MB, 200)]
        [TestCase(Constants.GB, 1500)]
        public async Task LocalToPageBlobBlobSize(long fileSize, int waitTimeInSec)
        {
            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();

            // Arrange
            var blobName = GetNewBlobName();
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            PageBlobClient destClient = testContainer.Container.GetPageBlobClient(blobName);

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

            await UploadPageBlobsAndVerify(
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
        public async Task LocalToPageBlobConcurrency(int concurrency, int size, int waitTimeInSec)
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
        public async Task LocalToPageBlobMultiple(int blobCount, long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await UploadPageBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                blobCount: blobCount);
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

                    AutoResetEvent completedStatusWait = new AutoResetEvent(false);
                    options[i].TransferStatus += async (TransferStatusEventArgs args) =>
                    {
                        // Assert
                        if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                        {
                            bool exists = await destClient.ExistsAsync();
                            Assert.IsTrue(exists);
                            completedStatusWait.Set();
                        }
                    };
                    options[i].TransferFailed += (TransferFailedEventArgs args) =>
                    {
                        if (args.Exception != null)
                        {
                            Assert.Fail(args.Exception.Message);
                            completedStatusWait.Set();
                        }
                        return Task.CompletedTask;
                    };

                    uploadedBlobInfo.Add(new VerifyUploadBlobContentInfo(
                        localSourceFile,
                        destClient,
                        options[i],
                        completedStatusWait));

                    // Act
                    StorageResource sourceResource = LocalStorageResourceFactory.GetFile(localSourceFile);
                    await blobDataController.StartTransferAsync(sourceResource, destinationResource, options[i]);
                }

                for (int i = 0; i < blobCount; i++)
                {
                    // Assert
                    Assert.IsTrue(uploadedBlobInfo[i].CompletedStatusWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));

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
        public async Task LocalToAppendBlobProgress(long size, int waitTimeInSec)
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
            await UploadAppendBlobsAndVerify(
                container: testContainer.Container,
                blobCount: optionsList.Count,
                options: optionsList);

            // Assert
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(400)));
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(1000, 10)]
        [TestCase(Constants.MB, 60)]
        [TestCase(4 * Constants.MB, 60)]
        [TestCase(257 * Constants.MB, 200)]
        [TestCase(Constants.GB, 1500)]
        public async Task LocalToAppendBlobBlobSize(long fileSize, int waitTimeInSec)
        {
            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            SingleTransferOptions options = new SingleTransferOptions();

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
                    Assert.Fail(args.Exception.Message);
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
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        [TestCase(1, 257 * Constants.MB, 200)]
        [TestCase(1, Constants.MB, 200)]
        [TestCase(4, 257 * Constants.MB, 200)]
        [TestCase(16, 257 * Constants.MB, 200)]
        public async Task LocalToAppendBlobConcurrency(int concurrency, int size, int waitTimeInSec)
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
        public async Task LocalToAppendBlobMultiple(int blobCount, long fileSize, int waitTimeInSec)
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

        #region DirectoryUploadTests
        [RecordedTest]
        public async Task Async_LocalDirectoryToBlobDirectory()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);
            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string openChild = await CreateRandomFileAsync(folder);
            string lockedChild = await CreateRandomFileAsync(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder);

            ContainerTransferOptions options = new ContainerTransferOptions();

            // Act
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager BlobDataController = InstrumentClient(new TransferManager(managerOptions));

            await BlobDataController.StartTransferAsync(sourceResource, destinationResource);

            // Assert - Check List Call
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            Assert.AreEqual(4, blobs.Count());
            // Assert - Check destination blobs
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DirectoryUpload_EmptyFolder()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            // Set up directory to upload
            var dirName = GetNewBlobDirectoryName();
            string folder = CreateRandomDirectory(Path.GetTempPath());

            // Set up destination client
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager dataController = new TransferManager(managerOptions);

            // Act
            await dataController.StartTransferAsync(sourceResource, destinationResource);

            // Assert
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();
            // Assert
            Assert.IsEmpty(blobs);

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DirectoryUpload_SingleFile()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);
            string openChild = await CreateRandomFileAsync(folder);

            ContainerTransferOptions options = new ContainerTransferOptions();

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager dataController = new TransferManager(managerOptions);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            // Act
            DataTransfer transfer = await dataController.StartTransferAsync(sourceResource, destinationResource, options);
            await transfer.AwaitCompletion(cancellationToken: cancellationTokenSource.Token);

            // Assert - Check Response
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert - Check destination blobs
            Assert.AreEqual(1, blobs.Count());
            Assert.AreEqual(blobs.First(), dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DirectoryUpload_SingleSubdirectory()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder);
            string openSubchild2 = await CreateRandomFileAsync(openSubfolder);
            string openSubchild3 = await CreateRandomFileAsync(openSubfolder);

            ContainerTransferOptions options = new ContainerTransferOptions();
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager dataController = new TransferManager(managerOptions);

            // Act
            await dataController.StartTransferAsync(sourceResource, destinationResource, options);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert - Check destination blobs
            Assert.AreEqual(3, blobs.Count());
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild2.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild3.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DirectoryUpload_ManySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder);

            string openSubfolder2 = CreateRandomDirectory(folder);
            string openSubChild2_1 = await CreateRandomFileAsync(openSubfolder2);
            string openSubChild2_2 = await CreateRandomFileAsync(openSubfolder2);
            string openSubChild2_3 = await CreateRandomFileAsync(openSubfolder2);

            string openSubfolder3 = CreateRandomDirectory(folder);
            string openSubChild3_1 = await CreateRandomFileAsync(openSubfolder2);
            string openSubChild3_2 = await CreateRandomFileAsync(openSubfolder2);
            string openSubChild3_3 = await CreateRandomFileAsync(openSubfolder2);

            string openSubfolder4 = CreateRandomDirectory(folder);
            string openSubChild4_1 = await CreateRandomFileAsync(openSubfolder2);
            string openSubChild4_2 = await CreateRandomFileAsync(openSubfolder2);
            string openSubChild4_3 = await CreateRandomFileAsync(openSubfolder2);

            ContainerTransferOptions options = new ContainerTransferOptions();
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager dataController = new TransferManager(managerOptions);

            // Act
            await dataController.StartTransferAsync(sourceResource, destinationResource, options);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert - Check destination blobs
            Assert.AreEqual(10, blobs.Count());
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild2_1.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild2_2.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild2_3.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild3_1.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild3_2.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild3_3.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild4_1.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild4_2.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild4_3.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task DirectoryUpload_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string subfolderName = folder;
            for (int i = 0; i < level; i++)
            {
                string openSubfolder = CreateRandomDirectory(subfolderName);
                string openSubchild = await CreateRandomFileAsync(openSubfolder);
                subfolderName = openSubfolder;
            }

            ContainerTransferOptions options = new ContainerTransferOptions();
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager BlobDataController = new TransferManager(managerOptions);

            // Act
            await BlobDataController.StartTransferAsync(sourceResource, destinationResource, options);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert - Check destination blobs
            Assert.AreEqual(level, blobs.Count());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DirectoryUpload_EmptySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder);
            string openSubchild2 = await CreateRandomFileAsync(openSubfolder);
            string openSubchild3 = await CreateRandomFileAsync(openSubfolder);
            string openSubchild4 = await CreateRandomFileAsync(openSubfolder);
            string openSubchild5 = await CreateRandomFileAsync(openSubfolder);
            string openSubchild6 = await CreateRandomFileAsync(openSubfolder);

            string openSubfolder2 = CreateRandomDirectory(folder);

            string openSubfolder3 = CreateRandomDirectory(folder);

            string openSubfolder4 = CreateRandomDirectory(folder);

            ContainerTransferOptions options = new ContainerTransferOptions();
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager dataController = new TransferManager(managerOptions);

            // Act
            await dataController.StartTransferAsync(sourceResource, destinationResource, options);

            // Assert - Check Response

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert - Check destination blobs
            Assert.AreEqual(6, blobs.Count());
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild2.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild3.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild4.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild5.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild6.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DirectoryUpload_OverwriteTrue()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string openChild = await CreateRandomFileAsync(folder);
            string lockedChild = await CreateRandomFileAsync(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder);

            ContainerTransferOptions options = new ContainerTransferOptions();
            BlobClient blobClient = test.Container.GetBlobClient(dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
            await blobClient.UploadAsync(openChild);

            // Act
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager dataController = new TransferManager(managerOptions);
            await dataController.StartTransferAsync(sourceResource, destinationResource, options);

            // Assert - Check Response
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            Assert.AreEqual(4, blobs.Count());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DirectoryUpload_OverwriteFalse()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            string openChild = await CreateRandomFileAsync(folder);
            string lockedChild = await CreateRandomFileAsync(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder);

            BlobClient blobClient = test.Container.GetBlobClient(dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
            await blobClient.UploadAsync(openChild);

            ContainerTransferOptions options = new ContainerTransferOptions();

            // Act
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager dataController = new TransferManager(managerOptions);
            await dataController.StartTransferAsync(sourceResource, destinationResource, options);

            // Assert - Check Response

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            Assert.AreEqual(4, blobs.Count());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DirectoryUpload_Empty()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            StorageResourceContainer destinationResource = new BlobDirectoryStorageResourceContainer(test.Container, dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(folder);

            ContainerTransferOptions options = new ContainerTransferOptions();

            // Act
            TransferManagerOptions controllerOptions = new TransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager dataController = new TransferManager(controllerOptions);
            await dataController.StartTransferAsync(sourceResource, destinationResource, options);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert
            Assert.IsEmpty(blobs);

            // Cleanup
            Directory.Delete(folder, true);
        }
        #endregion DirectoryUploadTests
    }
}
