// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.Blobs.DataMovement.Tests.Shared;
using NUnit.Framework;
using Azure.Storage.DataMovement;
using System.Net;
using Azure.Core;
using System.Threading;
using Azure.Storage.Test;
using System.Drawing;
using Castle.Core.Internal;
using Microsoft.CodeAnalysis;
using NUnit.Framework.Internal;

namespace Azure.Storage.Blobs.DataMovement.Tests
{
    public class BlobTransferManagerTests : DataMovementBlobTestBase
    {
        public BlobTransferManagerTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
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
            public BlobBaseClient Client;
            public BlobSingleUploadOptions UploadOptions;
            public AutoResetEvent CompletedStatusWait;

            public VerifyUploadBlobContentInfo(
                string sourceFile,
                BlobBaseClient blobClient,
                BlobSingleUploadOptions uploadOptions,
                AutoResetEvent completedStatusWait)
            {
                LocalPath = sourceFile;
                Client = blobClient;
                UploadOptions = uploadOptions;
                CompletedStatusWait = completedStatusWait;
            }
        };

        internal class VerifyDownloadBlobContentInfo
        {
            public readonly string SourceLocalPath;
            public readonly string DestinationLocalPath;
            public BlobSingleDownloadOptions DownloadOptions;
            public AutoResetEvent CompletedStatusWait;

            public VerifyDownloadBlobContentInfo(
                string sourceFile,
                string destinationFile,
                BlobSingleDownloadOptions downloadOptions,
                AutoResetEvent completedStatusWait)
            {
                SourceLocalPath = sourceFile;
                DestinationLocalPath = destinationFile;
                DownloadOptions = downloadOptions;
                CompletedStatusWait = completedStatusWait;
            }
        };

        internal BlobSingleUploadOptions CopySingleUploadOptions(BlobSingleUploadOptions options)
        {
            BlobSingleUploadOptions newOptions = new BlobSingleUploadOptions()
            {
                HttpHeaders = options.HttpHeaders,
                Metadata = options.Metadata,
                Tags = options.Tags,
                Conditions = options.Conditions,
                ProgressHandler = options.ProgressHandler,
                AccessTier = options.AccessTier,
                TransferOptions = options.TransferOptions,
                ImmutabilityPolicy = options.ImmutabilityPolicy,
                LegalHold = options.LegalHold,
                TransferValidationOptions = options.TransferValidationOptions
            };
            return newOptions;
        }

        private async Task SetUpDirectoryForListing(BlobContainerClient container)
        {
            var blobNames = BlobNames;

            var data = GetRandomBuffer(Constants.KB);

            var blobs = new BlockBlobClient[blobNames.Length];

            // Upload Blobs
            for (var i = 0; i < blobNames.Length; i++)
            {
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blobNames[i]));
                blobs[i] = blob;

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }
            }

            // Set metadata on Blob index 3
            IDictionary<string, string> metadata = BuildMetadata();
            await blobs[3].SetMetadataAsync(metadata);
        }

        /// <summary>
        /// Verifies Upload blob contents
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="blob"></param>
        /// <returns></returns>
        private static async Task DownloadAndAssertAsync(Stream stream, BlobBaseClient blob)
        {
            var actual = new byte[Constants.DefaultBufferSize];
            using var actualStream = new MemoryStream(actual);

            // reset the stream before validating
            stream.Seek(0, SeekOrigin.Begin);
            long size = stream.Length;
            // we are testing Upload, not download: so we download in partitions to avoid the default timeout
            for (var i = 0; i < size; i += Constants.DefaultBufferSize * 5 / 2)
            {
                var startIndex = i;
                var count = Math.Min(Constants.DefaultBufferSize, (int)(size - startIndex));

                Response<BlobDownloadInfo> download = await blob.DownloadAsync(new HttpRange(startIndex, count));
                actualStream.Seek(0, SeekOrigin.Begin);
                await download.Value.Content.CopyToAsync(actualStream);

                var buffer = new byte[count];
                stream.Seek(i, SeekOrigin.Begin);
                await stream.ReadAsync(buffer, 0, count);

                TestHelper.AssertSequenceEqual(
                    buffer,
                    actual.AsSpan(0, count).ToArray());
            }
        }

        private static void CompareSourceAndDestinationFiles(string sourceFile, string destinationFile)
        {
            FileStream sourceStream;
            FileStream destinationStream;

            // Open the two files.
            using (sourceStream = new FileStream(sourceFile, FileMode.Open))
            {
                using (destinationStream = new FileStream(destinationFile, FileMode.Open))
                {
                    // Read and compare a byte from each file until either a
                    // non-matching set of bytes is found or until the end of
                    // sourceFile is reached.
                    TestHelper.AssertSequenceEqual(sourceStream.AsBytes(), destinationStream.AsBytes());
                }
            }
        }

        internal class CheckBlobCompletionProgress : IProgress<long>
        {
            private long _expectedSize { get; }
            private AutoResetEvent _completeEvent { get; }
            public CheckBlobCompletionProgress(long expectedSize, AutoResetEvent completeEvent)
            {
                _expectedSize = expectedSize;
                _completeEvent = completeEvent;
            }
            public void Report(long value)
            {
                if (value == _expectedSize)
                {
                    //Console.WriteLine("Completed!");
                    _completeEvent.Set();
                }
                else if (value >= _expectedSize)
                {
                    // Error!!
                    Assert.Fail();
                    _completeEvent.Set();
                }
            }
        };

        [RecordedTest]
        public void Ctor_Defaults()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));

            var containerName = GetNewContainerName();
            var directoryName = GetNewBlobDirectoryName();

            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };

            BlobTransferManager blobTransferManager1 = new BlobTransferManager(managerOptions);
        }

        #region SingleUpload

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
        private async Task UploadBlobsAndVerify(
            BlobContainerClient container,
            long size = Constants.KB,
            int waitTimeInSec = 10,
            int blobCount = 1,
            StorageTransferManagerOptions transferManagerOptions = default,
            List<string> blobNames = default,
            List<BlobSingleUploadOptions> options = default)
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
                options ??= new List<BlobSingleUploadOptions>(blobCount);
                for (int i = 0; i < blobCount; i++)
                {
                    options.Add(new BlobSingleUploadOptions());
                }
            }
            else
            {
                // If blobNames is popluated make sure these number of blobs match
                Assert.AreEqual(blobCount, options.Count);
            }

            transferManagerOptions ??= new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure
            };

            List<VerifyUploadBlobContentInfo> uploadedBlobInfo = new List<VerifyUploadBlobContentInfo>(blobCount);
            try
            {
                // Initialize BlobTransferManager
                BlobTransferManager blobTransferManager = new BlobTransferManager(transferManagerOptions);

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

                    AutoResetEvent completedStatusWait = new AutoResetEvent(false);
                    options[i].TransferStatusEventHandler += async (StorageTransferStatusEventArgs args) =>
                    {
                        // Assert
                        if (args.StorageTransferStatus == StorageTransferStatus.Completed)
                        {
                            bool exists = await destClient.ExistsAsync();
                            Assert.IsTrue(exists);
                            completedStatusWait.Set();
                        }
                    };
                    options[i].UploadFailedEventHandler += (BlobUploadFailedEventArgs args) =>
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
                    await blobTransferManager.ScheduleUploadAsync(localSourceFile, destClient, options[i]).ConfigureAwait(false);
                }

                for (int i = 0; i < blobCount; i++)
                {
                    // Assert
                    Assert.IsTrue(uploadedBlobInfo[i].CompletedStatusWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));

                    // Verify Upload
                    using (FileStream fileStream = File.OpenRead(uploadedBlobInfo[i].LocalPath))
                    {
                        await DownloadAndAssertAsync(fileStream, uploadedBlobInfo[i].Client).ConfigureAwait(false);
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
        public async Task ScheduleUpload_Progress(long size, int waitTimeInSec)
        {
            AutoResetEvent CompletedProgressBytesWait = new AutoResetEvent(false);
            BlobSingleUploadOptions options = new BlobSingleUploadOptions()
            {
                ProgressHandler = new CheckBlobCompletionProgress(size, CompletedProgressBytesWait)
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<BlobSingleUploadOptions> optionsList = new List<BlobSingleUploadOptions>() { options };
            await UploadBlobsAndVerify(
                testContainer.Container,
                size,
                waitTimeInSec,
                blobCount: optionsList.Count,
                options: optionsList).ConfigureAwait(false);

            // Assert
            Assert.IsTrue(CompletedProgressBytesWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        public async Task ScheduleUpload_EventHandler()
        {
            AutoResetEvent InProgressWait = new AutoResetEvent(false);

            BlobSingleUploadOptions options = new BlobSingleUploadOptions();
            options.TransferStatusEventHandler += (StorageTransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.UploadFailedEventHandler += (BlobUploadFailedEventArgs args) =>
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

            List<BlobSingleUploadOptions> optionsList = new List<BlobSingleUploadOptions>() { options };
            await UploadBlobsAndVerify(
                container: testContainer.Container,
                blobCount: optionsList.Count,
                options: optionsList).ConfigureAwait(false);

            // Assert
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(400)));
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(100, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 200)]
        [TestCase(Constants.GB, 500)]
        public async Task ScheduleUpload_BlobSize(long fileSize, int waitTimeInSec)
        {
            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            BlobSingleUploadOptions options = new BlobSingleUploadOptions();

            // Arrange
            var blobName = GetNewBlobName();
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient destClient = testContainer.Container.GetBlockBlobClient(blobName);

            options.TransferStatusEventHandler += (StorageTransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.UploadFailedEventHandler += (BlobUploadFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    Assert.Fail(args.Exception.Message);
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };

            List<string> blobNames = new List<string>() { blobName };
            List<BlobSingleUploadOptions> optionsList = new List<BlobSingleUploadOptions>() { options };

            await UploadBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                blobCount: blobNames.Count(),
                blobNames: blobNames,
                options: optionsList).ConfigureAwait(false);

            // Assert
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        [TestCase(1, 257 * Constants.MB, 200)]
        [TestCase(1, Constants.MB, 200)]
        [TestCase(4, 257 * Constants.MB, 200)]
        [TestCase(16, 257 * Constants.MB, 200)]
        public async Task ScheduleUpload_Concurrency(int concurrency, int size, int waitTimeInSec)
        {
            // Arrange
            var blobName = GetNewBlobName();
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();
            BlockBlobClient destClient = testContainer.Container.GetBlockBlobClient(blobName);

            List<string> blobNames = new List<string>() { blobName };

            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = concurrency,
            };

            await UploadBlobsAndVerify(
                size: size,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                blobCount: blobNames.Count(),
                blobNames: blobNames).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(2, 4 * Constants.MB, 300)]
        [TestCase(6, 4 * Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        public async Task ScheduleUpload_Multiple(int blobCount, long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await UploadBlobsAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                container: testContainer.Container,
                blobCount: blobCount).ConfigureAwait(false);
        }
        #endregion SingleUpload

        #region SingleDownload
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
        private async Task DownloadBlobsAndVerify(
            BlobContainerClient container,
            long size = Constants.KB,
            int waitTimeInSec = 10,
            int blobCount = 1,
            StorageTransferManagerOptions transferManagerOptions = default,
            List<string> blobNames = default,
            List<BlobSingleDownloadOptions> options = default)
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
                options ??= new List<BlobSingleDownloadOptions>(blobCount);
                for (int i = 0; i < blobCount; i++)
                {
                    options.Add(new BlobSingleDownloadOptions());
                }
            }
            else
            {
                // If blobNames is popluated make sure these number of blobs match
                Assert.AreEqual(blobCount, options.Count);
            }

            transferManagerOptions ??= new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure
            };

            List<VerifyDownloadBlobContentInfo> downloadedBlobInfo = new List<VerifyDownloadBlobContentInfo>(blobCount);
            try
            {
                // Initialize BlobTransferManager
                BlobTransferManager blobTransferManager = new BlobTransferManager(transferManagerOptions);

                // Upload set of VerifyDownloadBlobContentInfo blobs to download
                for (int i = 0; i < blobCount; i++)
                {
                    // Set up Blob to be downloaded
                    var data = GetRandomBuffer(size);
                    using Stream originalStream = await CreateLimitedMemoryStream(size);
                    string localSourceFile = Path.GetTempFileName();
                    BlobClient originalBlob = InstrumentClient(container.GetBlobClient(blobNames[i]));
                    // create a new file and copy contents of stream into it, and then close the FileStream
                    // so the StagedUploadAsync call is not prevented from reading using its FileStream.
                    using (FileStream fileStream = File.Create(localSourceFile))
                    {
                        // Copy source to a file, so we can verify the source against downloaded blob later
                        await originalStream.CopyToAsync(fileStream);
                        // Upload blob to storage account
                        originalStream.Position = 0;
                        await originalBlob.UploadAsync(originalStream);
                    }

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
                    options[i].DownloadFailedEventHandler += (BlobDownloadFailedEventArgs args) =>
                    {
                        if (args.Exception != null)
                        {
                            Assert.Fail(args.Exception.Message);
                            completedStatusWait.Set();
                        }
                        return Task.CompletedTask;
                    };

                    // Create destination file path
                    string destFile = Path.GetTempPath() + Path.GetRandomFileName();

                    downloadedBlobInfo.Add(new VerifyDownloadBlobContentInfo(
                        localSourceFile,
                        destFile,
                        options[i],
                        completedStatusWait));
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
                    BlobClient sourceBlobClient = InstrumentClient(new BlobClient(blobUriBuilder.ToUri(), credential, GetOptions(true)));

                    // Act
                    await blobTransferManager.ScheduleDownloadAsync(
                        sourceBlobClient,
                        downloadedBlobInfo[i].DestinationLocalPath,
                        options[i]).ConfigureAwait(false);
                }

                for (int i = 0; i < downloadedBlobInfo.Count; i++)
                {
                    // Assert
                    Assert.IsTrue(downloadedBlobInfo[i].CompletedStatusWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));

                    // Verify Upload
                    CompareSourceAndDestinationFiles(downloadedBlobInfo[i].SourceLocalPath, downloadedBlobInfo[i].DestinationLocalPath);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            finally
            {
                // Cleanup - temporary local files (blobs cleaned up by diposing container)
                for (int i = 0; i < downloadedBlobInfo.Count; i++)
                {
                    if (File.Exists(downloadedBlobInfo[i].SourceLocalPath))
                    {
                        File.Delete(downloadedBlobInfo[i].SourceLocalPath);
                    }
                    if (File.Exists(downloadedBlobInfo[i].DestinationLocalPath))
                    {
                        File.Delete(downloadedBlobInfo[i].DestinationLocalPath);
                    }
                }
            }
        }

        [RecordedTest]
        public async Task ScheduleDownload()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            // No Option Download bag or manager options bag, plain download
            await DownloadBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: 10,
                size: 0,
                blobCount: 1).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 400)]
        [TestCase(Constants.GB, 800)]
        public async Task ScheduleDownload_Progress(long size, int waitTimeInSec)
        {
            AutoResetEvent CompletedProgressBytesWait = new AutoResetEvent(false);
            BlobSingleDownloadOptions options = new BlobSingleDownloadOptions()
            {
                ProgressHandler = new CheckBlobCompletionProgress(size, CompletedProgressBytesWait)
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            List<BlobSingleDownloadOptions> optionsList = new List<BlobSingleDownloadOptions>() { options };
            await DownloadBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);

            // Assert
            Assert.IsTrue(CompletedProgressBytesWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        public async Task ScheduleDownload_EventHandler()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            int waitTimeInSec = 10;
            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            BlobSingleDownloadOptions options = new BlobSingleDownloadOptions();
            options.TransferStatusEventHandler += (StorageTransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.DownloadFailedEventHandler += (BlobDownloadFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    Assert.Fail(args.Exception.Message);
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };

            List<BlobSingleDownloadOptions> optionsList = new List<BlobSingleDownloadOptions>() { options };
            await DownloadBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                options: optionsList).ConfigureAwait(false);

            // Assert
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(100, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 200)]
        [TestCase(Constants.GB, 1000)]
        public async Task ScheduleDownload_BlobSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            AutoResetEvent InProgressWait = new AutoResetEvent(false);
            BlobSingleDownloadOptions options = new BlobSingleDownloadOptions();
            options.TransferStatusEventHandler += (StorageTransferStatusEventArgs args) =>
            {
                // Assert
                if (args.StorageTransferStatus == StorageTransferStatus.InProgress)
                {
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };
            options.DownloadFailedEventHandler += (BlobDownloadFailedEventArgs args) =>
            {
                if (args.Exception != null)
                {
                    Assert.Fail(args.Exception.Message);
                    InProgressWait.Set();
                }
                return Task.CompletedTask;
            };

            List<BlobSingleDownloadOptions> optionsList = new List<BlobSingleDownloadOptions>() { options };
            await DownloadBlobsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                options: optionsList).ConfigureAwait(false);

            // Assert
            Assert.IsTrue(InProgressWait.WaitOne(TimeSpan.FromSeconds(waitTimeInSec)));
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(2, 4 * Constants.MB, 300)]
        [TestCase(6, 4 * Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        public async Task ScheduleDownload_Multiple(int blobCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await DownloadBlobsAndVerify(
                testContainer.Container,
                blobCount: blobCount,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(2, 4 * Constants.MB, 300)]
        [TestCase(6, 4 * Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        public async Task ScheduleDownload_Concurrency(int concurrency, int size, int waitTimeInSec)
        {
            AutoResetEvent CompletedProgressBytesWait = new AutoResetEvent(false);

            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = concurrency,
            };

            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            await DownloadBlobsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                transferManagerOptions: managerOptions).ConfigureAwait(false);
        }
        #endregion SingleDownload

        #region DirectoryUploadTests
        [RecordedTest]
        public async Task ScheduleFolderUploadAsync()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string lockedChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder).ConfigureAwait(false);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            // Act
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));

            await blobTransferManager.ScheduleFolderUploadAsync(folder, client).ConfigureAwait(false);

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
        public async Task ScheduleFolderUpload_EmptyFolder()
        {
            // Arrange
            await using DisposingBlobContainer testContainer = await GetTestContainerAsync();

            // Set up directory to upload
            var dirName = GetNewBlobDirectoryName();
            string folder = CreateRandomDirectory(Path.GetTempPath());

            // Set up destination client
            BlobFolderClient destClient = testContainer.Container.GetBlobFolderClient(dirName);

            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));

            // Act
            await blobTransferManager.ScheduleFolderUploadAsync(folder, destClient).ConfigureAwait(false);

            // Assert
            List<string> blobs = ((List<BlobItem>)await testContainer.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();
            // Assert
            Assert.IsEmpty(blobs);

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task ScheduleDirectoryUploadAsync_SingleFile()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));

            // Act
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

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
        public async Task ScheduleDirectoryUploadAsync_SingleSubdirectory()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string openSubchild2 = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string openSubchild3 = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));

            // Act
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

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
        public async Task ScheduleDirectoryUploadAsync_ManySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            string openSubfolder2 = CreateRandomDirectory(folder);
            string openSubChild2_1 = await CreateRandomFileAsync(openSubfolder2).ConfigureAwait(false);
            string openSubChild2_2 = await CreateRandomFileAsync(openSubfolder2).ConfigureAwait(false);
            string openSubChild2_3 = await CreateRandomFileAsync(openSubfolder2).ConfigureAwait(false);

            string openSubfolder3 = CreateRandomDirectory(folder);
            string openSubChild3_1 = await CreateRandomFileAsync(openSubfolder2).ConfigureAwait(false);
            string openSubChild3_2 = await CreateRandomFileAsync(openSubfolder2).ConfigureAwait(false);
            string openSubChild3_3 = await CreateRandomFileAsync(openSubfolder2).ConfigureAwait(false);

            string openSubfolder4 = CreateRandomDirectory(folder);
            string openSubChild4_1 = await CreateRandomFileAsync(openSubfolder2).ConfigureAwait(false);
            string openSubChild4_2 = await CreateRandomFileAsync(openSubfolder2).ConfigureAwait(false);
            string openSubChild4_3 = await CreateRandomFileAsync(openSubfolder2).ConfigureAwait(false);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));

            // Act
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

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
        public async Task ScheduleDirectoryUploadAsync_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string subfolderName = folder;
            for (int i = 0; i < level; i++)
            {
                string openSubfolder = CreateRandomDirectory(subfolderName);
                string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
                subfolderName = openSubfolder;
            }

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));

            // Act
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert - Check destination blobs
            Assert.AreEqual(level, blobs.Count());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task ScheduleDirectoryUploadAsync_EmptySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string openSubchild2 = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string openSubchild3 = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string openSubchild4 = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string openSubchild5 = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string openSubchild6 = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            string openSubfolder2 = CreateRandomDirectory(folder);

            string openSubfolder3 = CreateRandomDirectory(folder);

            string openSubfolder4 = CreateRandomDirectory(folder);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));

            // Act
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

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

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task ScheduleDirectoryUpload_ImmutableStorageWithVersioning()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string lockedChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder).ConfigureAwait(false);

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddMinutes(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiresOn.Value);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions()
            {
                ImmutabilityPolicy = immutabilityPolicy,
                LegalHold = true,
            };

            // Act
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));

            // Act
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            // Assert - Check Response
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();

            Assert.AreEqual(4, blobs.Count());
            foreach (BlobItem blob in blobs)
            {
                Assert.AreEqual(blob.Properties.ImmutabilityPolicy.ExpiresOn, expectedImmutabilityPolicyExpiry);
                Assert.AreEqual(blob.Properties.ImmutabilityPolicy.PolicyMode, immutabilityPolicy.PolicyMode);
                Assert.IsTrue(blob.Properties.HasLegalHold);
            }

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task ScheduleDirectoryUploadAsync_OverwriteTrue()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string lockedChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder).ConfigureAwait(false);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            BlobClient blobClient = test.Container.GetBlobClient(dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
            await blobClient.UploadAsync(openChild);

            // Act
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            // Assert - Check Response
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            Assert.AreEqual(4, blobs.Count());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_OverwriteFalse()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string lockedChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder).ConfigureAwait(false);

            BlobClient blobClient = test.Container.GetBlobClient(dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
            await blobClient.UploadAsync(openChild);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            // Act
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            // Assert - Check Response

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            Assert.AreEqual(4, blobs.Count());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_Empty()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            // Act
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert
            Assert.IsEmpty(blobs);

            // Cleanup
            Directory.Delete(folder, true);
        }
        #endregion DirectoryUploadTests

        #region DirectoryDownloadTests
        [RecordedTest]
        public async Task DownloadDirectoryAsync()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string lockedChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder).ConfigureAwait(false);

            string localDirName = folder.Split('\\').Last();

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
            options.ProgressHandler = new Progress<BlobFolderUploadProgress>();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            Directory.Delete(folder, true);
            string destinationFolder = CreateRandomDirectory(folder);

            //Act
            await blobTransferManager.ScheduleFolderDownloadAsync(client, destinationFolder, downloadOptions).ConfigureAwait(false);

            List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(localItemsAfterDownload, openChild);
                CollectionAssert.Contains(localItemsAfterDownload, lockedChild);
                CollectionAssert.Contains(localItemsAfterDownload, openSubchild);
                CollectionAssert.Contains(localItemsAfterDownload, lockedSubchild);
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync_Empty()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            string folder = CreateRandomDirectory(Path.GetTempPath());
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();

            // Act
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));
            string destinationFolder = CreateRandomDirectory(folder);

            //Act
            await blobTransferManager.ScheduleFolderDownloadAsync(client, destinationFolder, downloadOptions).ConfigureAwait(false);
            List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.IsEmpty(localItemsAfterDownload);

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync_SingleFile()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string sourceFolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(sourceFolder).ConfigureAwait(false);
            string localDirName = sourceFolder.Split('\\').Last();

            string destinationFolder = CreateRandomDirectory(folder);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            Directory.Delete(folder, true);

            //Act
            await blobTransferManager.ScheduleFolderDownloadAsync(client, destinationFolder, downloadOptions).ConfigureAwait(false);

            List<string> localItemsAfterDownload = Directory.GetFiles(destinationFolder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.Equals(1, localItemsAfterDownload.Count());
            AssertContentFile(openSubchild, destinationFolder + "/" + localItemsAfterDownload.First());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync_SingleSubDirectory()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string mainSubFolder = CreateRandomDirectory(folder);
            string sourceSubFolder = CreateRandomDirectory(mainSubFolder);
            string sourceSubChild = await CreateRandomFileAsync(sourceSubFolder).ConfigureAwait(false);

            string destinationSubfolder = CreateRandomDirectory(mainSubFolder);
            string destinationSubchild = await CreateRandomFileAsync(destinationSubfolder).ConfigureAwait(false);

            string localDirName = folder.Split('\\').Last();

            string destinationFolder = CreateRandomDirectory(folder);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            Directory.Delete(folder, true);

            //Act
            await blobTransferManager.ScheduleFolderDownloadAsync(client, destinationFolder, downloadOptions).ConfigureAwait(false);

            List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.Equals(1, localItemsAfterDownload.Count());
            Assert.Equals(localItemsAfterDownload.First(), destinationSubchild);
            AssertContentFile(sourceSubChild, destinationSubchild);

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync_ManySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string mainFolder = CreateRandomDirectory(folder);
            string souceSubFolder = CreateRandomDirectory(mainFolder);
            string openSubchild = await CreateRandomFileAsync(souceSubFolder).ConfigureAwait(false);
            string souceSubFolder2 = CreateRandomDirectory(mainFolder);
            string openSubchild2 = await CreateRandomFileAsync(souceSubFolder2).ConfigureAwait(false);
            string souceSubFolder3 = CreateRandomDirectory(mainFolder);
            string openSubchild3 = await CreateRandomFileAsync(souceSubFolder3).ConfigureAwait(false);

            string destinationFolder = CreateRandomDirectory(souceSubFolder);

            string localDirName = folder.Split('\\').Last();

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));
            await blobTransferManager.ScheduleFolderUploadAsync(folder, client, false, options).ConfigureAwait(false);

            Directory.Delete(folder, true);

            //Act
            await blobTransferManager.ScheduleFolderDownloadAsync(client, destinationFolder, downloadOptions).ConfigureAwait(false);

            List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(localItemsAfterDownload, openSubchild);
                CollectionAssert.Contains(localItemsAfterDownload, openSubchild2);
                CollectionAssert.Contains(localItemsAfterDownload, openSubchild3);
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task DownloadDirectoryAsync_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string sourceFolder = CreateRandomDirectory(Path.GetTempPath());
            string destinationFolder = CreateRandomDirectory(Path.GetTempPath());

            string subfolderName = sourceFolder;
            for (int i = 0; i < level; i++)
            {
                string openSubfolder = CreateRandomDirectory(subfolderName);
                string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
                subfolderName = openSubfolder;
            }

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            BlobFolderDownloadOptions downloadOptions = new BlobFolderDownloadOptions();
            StorageTransferManagerOptions managerOptions = new StorageTransferManagerOptions()
            {
                ErrorHandling = ErrorHandlingOptions.ContinueOnServiceFailure,
                MaximumConcurrency = 1,
            };
            BlobTransferManager blobTransferManager = InstrumentClient(new BlobTransferManager(managerOptions));
            await blobTransferManager.ScheduleFolderUploadAsync(sourceFolder, client, false, options).ConfigureAwait(false);

            Directory.Delete(sourceFolder, true);

            //Act
            await blobTransferManager.ScheduleFolderDownloadAsync(client, destinationFolder, downloadOptions).ConfigureAwait(false);

            List<string> localItemsAfterDownload = Directory.GetFiles(destinationFolder, "*", SearchOption.AllDirectories).ToList();

            Assert.Equals(level, localItemsAfterDownload);

            // Cleanup
            Directory.Delete(sourceFolder, true);
            Directory.Delete(destinationFolder, true);
        }

        // This test is here just to see if DM stuff works, but shouldn't sit in here
        // (just needed to use DisposingBlobContainer). Maybe a refactor for Disposing* stuff out to a
        // test common source might be useful for DMLib tests.

        // Test is disabled as it will not function properly until _toScanQueue > _jobsToProcess
        // transition is implemented.
        [RecordedTest]
        public async Task TransferManager_UploadTwoDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);
            string dirTwoName = GetNewBlobName();
            BlobFolderClient clientTwo = test.Container.GetBlobFolderClient(dirTwoName);
            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string lockedChild = await CreateRandomFileAsync(folder).ConfigureAwait(false);
            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = await CreateRandomFileAsync(openSubfolder).ConfigureAwait(false);
            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = await CreateRandomFileAsync(lockedSubfolder).ConfigureAwait(false);
            // Act
            BlobTransferManager manager = new BlobTransferManager();
            await manager.ScheduleFolderUploadAsync(folder, client).ConfigureAwait(false);
            await manager.ScheduleFolderUploadAsync(folder, clientTwo).ConfigureAwait(false);
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();
            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirTwoName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirTwoName + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirTwoName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirTwoName + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
            });
            // Cleanup
            Directory.Delete(folder, true);
        }
        #endregion DirectoryDownloadTests
    }
}
