// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.DataMovement.Tests;
using NUnit.Framework;
using System.IO;
using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    public class StartTransferUploadTests : DataMovementShareTestBase
    {
        public StartTransferUploadTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        #region SingleUpload Share File
        internal class VerifyUploadBlobContentInfo
        {
            public readonly string LocalPath;
            public ShareFileClient DestinationClient;
            public TestEventsRaised EventsRaised;
            public DataTransfer DataTransfer;

            public VerifyUploadBlobContentInfo(
                string sourceFile,
                ShareFileClient destinationClient,
                TestEventsRaised eventsRaised,
                DataTransfer dataTransfer)
            {
                LocalPath = sourceFile;
                DestinationClient = destinationClient;
                EventsRaised = eventsRaised;
                DataTransfer = dataTransfer;
            }
        };

        /// <summary>
        /// Verifies Upload blob contents
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        internal static async Task DownloadAndAssertAsync(Stream stream, ShareFileClient file)
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

                ShareFileDownloadOptions options = new ShareFileDownloadOptions()
                {
                    Range = new HttpRange(startIndex, count)
                };
                Response<ShareFileDownloadInfo> download = await file.DownloadAsync(options);
                actualStream.Seek(0, SeekOrigin.Begin);
                await download.Value.Content.CopyToAsync(actualStream);

                var buffer = new byte[count];
                stream.Seek(i, SeekOrigin.Begin);
                await stream.ReadAsync(buffer, 0, count);

                Assert.That(
                    buffer,
                    Is.EqualTo(actual.AsSpan(0, count).ToArray()));
            }
        }

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
        private async Task UploadShareFilesAndVerify(
            ShareClient share,
            long size = Constants.KB,
            int waitTimeInSec = 30,
            TransferManagerOptions transferManagerOptions = default,
            int blobCount = 1,
            List<string> shareFileNames = default,
            List<DataTransferOptions> options = default)
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Populate shareFileNames list for number of blobs to be created
            if (shareFileNames == default || shareFileNames?.Count == 0)
            {
                shareFileNames ??= new List<string>();
                for (int i = 0; i < blobCount; i++)
                {
                    shareFileNames.Add(GetNewFileName());
                }
            }
            else
            {
                // If shareFileNames is popluated make sure these number of blobs match
                Assert.AreEqual(blobCount, shareFileNames.Count);
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
                string localSourceFile = Path.Combine(testDirectory.DirectoryPath, GetNewFileName());
                // create a new file and copy contents of stream into it, and then close the FileStream
                // so the StagedUploadAsync call is not prevented from reading using its FileStream.
                using (FileStream fileStream = File.OpenWrite(localSourceFile))
                {
                    await originalStream.CopyToAsync(fileStream);
                }

                // Set up destination client
                ShareFileClient destClient = share.GetRootDirectoryClient().GetFileClient(shareFileNames[i]);
                StorageResourceItem destinationResource = new ShareFileStorageResource(destClient);

                // Act
                LocalFilesStorageResourceProvider files = new();
                StorageResource sourceResource = files.FromPath(localSourceFile);
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
        public async Task LocalToShareFile()
        {
            // Arrange
            await using DisposingShare testShare = await GetTestShareAsync();
            using DisposingLocalDirectory localDirectory = DisposingLocalDirectory.GetTestDirectory();

            await UploadShareFilesAndVerify(testShare.Share);
        }

        [RecordedTest]
        public async Task LocalToShareFile_EventHandler()
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
            await using DisposingShare testShare = await GetTestShareAsync();

            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };
            await UploadShareFilesAndVerify(
                share: testShare.Share,
                blobCount: optionsList.Count,
                options: optionsList);

            // Assert
            Assert.IsTrue(progressSeen);
        }

        [RecordedTest]
        public async Task LocalToShareFileSize_SmallChunk()
        {
            long fileSize = Constants.KB;
            int waitTimeInSec = 25;
            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };

            // Arrange
            await using DisposingShare testShare = await GetTestShareAsync();
            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };

            await UploadShareFilesAndVerify(
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                share: testShare.Share,
                options: optionsList);
        }

        [RecordedTest]
        public async Task LocalToShareFile_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingShare testShare = await GetTestShareAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string shareFileName = GetNewFileName();
            string localSourceFile = Path.Combine(testDirectory.DirectoryPath, shareFileName);
            int size = Constants.KB;
            int waitTimeInSec = 10;

            // Create file
            ShareFileClient destClient = await CreateShareFile(testShare.Share.GetRootDirectoryClient(), localSourceFile, shareFileName, size);

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };
            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };
            List<string> shareFileNames = new List<string>() { shareFileName };

            // Start transfer and await for completion.
            await UploadShareFilesAndVerify(
                share: testShare.Share,
                size: size,
                waitTimeInSec: waitTimeInSec,
                shareFileNames: shareFileNames,
                options: optionsList);
        }

        [RecordedTest]
        public async Task LocalToShareFile_Overwrite_NotExists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingShare testShare = await GetTestShareAsync();
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
            await UploadShareFilesAndVerify(
                share: testShare.Share,
                size: size,
                waitTimeInSec: waitTimeInSec,
                options: optionsList);
        }

        [RecordedTest]
        public async Task LocalToShareFile_Skip_Exists()
        {
            // Arrange
            // Create source local file for checking, and source blob
            await using DisposingShare testShare = await GetTestShareAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string shareFileName = GetNewFileName();
            int size = Constants.KB;
            string originalSourceFile = Path.Combine(testDirectory.DirectoryPath, shareFileName);
            ShareFileClient destinationClient = await CreateShareFile(testShare.Share.GetRootDirectoryClient(), originalSourceFile, shareFileName, size);

            // Act
            // Create new source file
            string newSourceFile = await CreateRandomFileAsync(testDirectory.DirectoryPath, size: size);
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists,
            };
            LocalFilesStorageResourceProvider files = new();
            StorageResource sourceResource = files.FromPath(newSourceFile);
            StorageResourceItem destinationResource = new ShareFileStorageResource(destinationClient);
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
        public async Task LocalToShareFile_Failure_Exists()
        {
            // Arrange

            // Create source local file for checking, and source blob
            await using DisposingShare testShare = await GetTestShareAsync();
            string shareFileName = GetNewFileName();
            string originalSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            ShareFileClient destinationClient = await CreateShareFile(testShare.Share.GetRootDirectoryClient(), originalSourceFile, shareFileName, size);

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
            LocalFilesStorageResourceProvider files = new();
            StorageResource sourceResource = files.FromPath(newSourceFile);
            StorageResourceItem destinationResource = new ShareFileStorageResource(destinationClient);
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
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(await destinationClient.ExistsAsync());
            await testEventRaised.AssertSingleFailedCheck();
            Assert.NotNull(testEventRaised.FailedEvents.First().Exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.IsTrue(testEventRaised.FailedEvents.First().Exception.Message.Contains("Cannot overwrite file."));
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
        public async Task LocalToShareFile_SmallSize(long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingShare testShare = await GetTestShareAsync();

            await UploadShareFilesAndVerify(
                share: testShare.Share,
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
        public async Task LocalToShareFile_LargeSize(long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingShare testShare = await GetTestShareAsync();

            await UploadShareFilesAndVerify(
                share: testShare.Share,
                size: fileSize,
                waitTimeInSec: waitTimeInSec);
        }

        [RecordedTest]
        [TestCase(1, Constants.KB, 10)]
        [TestCase(2, Constants.KB, 10)]
        [TestCase(1, 4 * Constants.KB, 60)]
        [TestCase(2, 4 * Constants.KB, 60)]
        [TestCase(4, 16 * Constants.KB, 60)]
        public async Task LocalToShareFile_SmallConcurrency(int concurrency, long size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingShare testShare = await GetTestShareAsync();

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

            await UploadShareFilesAndVerify(
                share: testShare.Share,
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
        public async Task LocalToShareFile_LargeConcurrency(int concurrency, int size, int waitTimeInSec)
        {
            // Arrange
            await using DisposingShare testShare = await GetTestShareAsync();

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            await UploadShareFilesAndVerify(
                share: testShare.Share,
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
        public async Task LocalToShareFile_SmallMultiple(int blobCount, long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingShare testShare = await GetTestShareAsync();

            await UploadShareFilesAndVerify(
                share: testShare.Share,
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
        public async Task LocalToShareFile_LargeMultiple(int blobCount, long fileSize, int waitTimeInSec)
        {
            // Arrange
            await using DisposingShare testShare = await GetTestShareAsync();

            await UploadShareFilesAndVerify(
                share: testShare.Share,
                size: fileSize,
                waitTimeInSec: waitTimeInSec,
                blobCount: blobCount);
        }
        #endregion SingleUpload Share File

        private async Task<DataTransfer> CreateStartTransfer(
            ShareClient shareClient,
            string localDirectoryPath,
            int concurrency,
            bool createFailedCondition = false,
            DataTransferOptions options = default,
            int size = Constants.KB)
        {
            // Arrange
            // Create destination
            string destinationName = GetNewFileName();
            string localFileSource = Path.Combine(localDirectoryPath, GetNewFileName());
            ShareFileClient destinationClient;
            if (createFailedCondition)
            {
                destinationClient = await CreateShareFile(shareClient.GetRootDirectoryClient(), localFileSource, destinationName, size);
            }
            else
            {
                destinationClient = shareClient.GetRootDirectoryClient().GetFileClient(destinationName);
            }
            StorageResourceItem destinationResource = new ShareFileStorageResource(destinationClient);

            // Create new source file
            using Stream originalStream = await CreateLimitedMemoryStream(size);
            string localSourceFile = Path.Combine(localDirectoryPath, destinationName);
            // create a new file and copy contents of stream into it, and then close the FileStream
            // so the StagedUploadAsync call is not prevented from reading using its FileStream.
            using (FileStream fileStream = File.Create(localSourceFile))
            {
                await originalStream.CopyToAsync(fileStream);
            }
            LocalFilesStorageResourceProvider files = new();
            StorageResource sourceResource = files.FromPath(localSourceFile);

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
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingShare test = await GetTestShareAsync();

            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                shareClient: test.Share,
                localDirectoryPath: disposingLocalDirectory.DirectoryPath,
                1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

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
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingShare test = await GetTestShareAsync();

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                shareClient: test.Share,
                localDirectoryPath: disposingLocalDirectory.DirectoryPath,
                concurrency: 1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            await testEventsRaised.AssertSingleFailedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("Cannot overwrite file."));
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingShare test = await GetTestShareAsync();

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                shareClient: test.Share,
                localDirectoryPath: disposingLocalDirectory.DirectoryPath,
                concurrency: 1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            await testEventsRaised.AssertSingleSkippedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
        }
    }
}
