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
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Test;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferUploadDirectoryTests : DataMovementBlobTestBase
    {
        public StartTransferUploadDirectoryTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        private List<string> GetTestDirectoryTree(string parentDirectoryPath)
        {
            return new List<string>()
            {
                GetNewBlobName(),
                GetNewBlobName(),
                Path.Combine(GetNewBlobDirectoryName(), GetNewBlobName()),
                Path.Combine(GetNewBlobDirectoryName(), GetNewBlobName()),
            };
        }

        #region Directory Block Blob
        private async Task SetupDirectory(
            string directoryPath,
            List<(string FilePath, long Size)> fileSizes,
            CancellationToken cancellationToken)
        {
            foreach ((string filePath, long size) in fileSizes)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                // Check if the parent subdirectory is already created,
                // if not create it before making the file
                string fullPath = Path.Combine(directoryPath, filePath);
                string subDirectory = Path.GetDirectoryName(fullPath);

                if (!Directory.Exists(subDirectory))
                {
                    Directory.CreateDirectory(subDirectory);
                }

                // Check if it's a directory or not
                using FileStream fs = File.OpenWrite(fullPath);
                using Stream data = await CreateLimitedMemoryStream(size);
                await data.CopyToAsync(fs, bufferSize: 4 * Constants.KB, cancellationToken);
            }
        }

        /// <summary>
        /// Upload and verify the contents of the blob
        ///
        /// By default in this function an event arguement will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        private async Task UploadBlobDirectoryAndVerify(
            string sourceLocalDirectoryPath,
            BlobContainerClient destinationContainer,
            int expectedTransfers,
            string destinationPrefix = default,
            TransferManagerOptions transferManagerOptions = default,
            DataTransferOptions options = default,
            CancellationToken cancellationToken = default)
        {
            // Set transfer options
            options ??= new DataTransferOptions();
            destinationPrefix ??= GetNewBlobDirectoryName();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure
            };

            LocalDirectoryStorageResourceContainer sourceResource = new(sourceLocalDirectoryPath);
            BlobStorageResourceContainer destinationResource = new(destinationContainer, new()
            {
                BlobDirectoryPrefix = destinationPrefix
            });

            await new TransferValidator()
            {
                TransferManager = new(transferManagerOptions)
            }.TransferAndVerifyAsync(
                sourceResource,
                destinationResource,
                TransferValidator.GetLocalFileLister(sourceLocalDirectoryPath),
                TransferValidator.GetBlobLister(destinationContainer, destinationPrefix),
                expectedTransfers,
                options,
                cancellationToken);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(0, 10)]
        [TestCase(100, 10)]
        [TestCase(Constants.KB, 10)]
        public async Task LocalToBlockBlobDirectory_SmallSize(long blobSize, int waitTimeInSec)
        {
            DataTransferOptions options = new DataTransferOptions();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);
            await using DisposingContainer test = await GetTestContainerAsync();

            List<string> files = GetTestDirectoryTree(localDirectory);

            CancellationToken cancellationToken = TestHelper.GetTimeoutToken(waitTimeInSec);
            await SetupDirectory(
                localDirectory,
                files.Select(name => (name, blobSize)).ToList(),
                cancellationToken);
            await UploadBlobDirectoryAndVerify(
                localDirectory,
                test.Container,
                files.Count,
                options: options,
                cancellationToken: cancellationToken);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(4 * Constants.MB, 200)]
        [TestCase(257 * Constants.MB, 500)]
        [TestCase(Constants.GB, 500)]
        public async Task LocalToBlockBlobDirectory_LargeSize(long blobSize, int waitTimeInSec)
        {
            DataTransferOptions options = new DataTransferOptions();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);
            await using DisposingContainer test = await GetTestContainerAsync();

            List<string> files = new()
            {
                GetNewBlobName(),
                GetNewBlobName(),
                $"{GetNewBlobName()}/{GetNewBlobName()}",
                $"{GetNewBlobName()}/{GetNewBlobName()}",
            };

            CancellationToken cancellationToken = TestHelper.GetTimeoutToken(waitTimeInSec);
            await SetupDirectory(
                localDirectory,
                files.Select(name => (name, blobSize)).ToList(),
                cancellationToken);
            await UploadBlobDirectoryAndVerify(
                localDirectory,
                test.Container,
                files.Count,
                options: options,
                cancellationToken: cancellationToken);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task LocalToBlockBlobDirectory_SmallChunks()
        {
            long blobSize = Constants.KB;
            int waitTimeInSec = 25;
            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);
            await using DisposingContainer test = await GetTestContainerAsync();

            List<string> files = GetTestDirectoryTree(localDirectory);

            CancellationToken cancellationToken = TestHelper.GetTimeoutToken(waitTimeInSec);
            await SetupDirectory(
                localDirectory,
                files.Select(name => (name, blobSize)).ToList(),
                cancellationToken);
            await UploadBlobDirectoryAndVerify(
                localDirectory,
                test.Container,
                files.Count,
                options: options,
                cancellationToken: cancellationToken);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task LocalToBlockBlobDirectory_SmallChunks_ManyFiles()
        {
            // Arrange
            long blobSize = 2 * Constants.KB;
            int waitTimeInSec = 25;
            TransferManagerOptions transferManagerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.StopOnAnyFailure,
                MaximumConcurrency = 3,
            };
            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512,
            };

            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);
            await using DisposingContainer test = await GetTestContainerAsync();

            string folder1 = GetNewBlobDirectoryName();
            string folder2 = GetNewBlobDirectoryName();
            List<string> files = new()
            {
                GetNewBlobName(),
                GetNewBlobName(),
                GetNewBlobName(),
                GetNewBlobName(),
                GetNewBlobName(),
                $"{folder1}/{GetNewBlobName()}",
                $"{folder1}/{GetNewBlobName()}",
                $"{folder1}/{GetNewBlobName()}",
                $"{folder2}/{GetNewBlobName()}",
                $"{folder2}/{GetNewBlobName()}",
            };

            CancellationToken cancellationToken = TestHelper.GetTimeoutToken(waitTimeInSec);
            await SetupDirectory(
                localDirectory,
                files.Select(name => (name, blobSize)).ToList(),
                cancellationToken);
            await UploadBlobDirectoryAndVerify(
                localDirectory,
                test.Container,
                files.Count,
                transferManagerOptions: transferManagerOptions,
                options: options,
                cancellationToken: cancellationToken);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_EmptyFolder()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            // Set up directory to upload
            var dirName = GetNewBlobDirectoryName();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);

            // Set up destination client
            StorageResourceContainer destinationResource = new BlobStorageResourceContainer(test.Container, new() { BlobDirectoryPrefix = dirName });
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(localDirectory);

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager transferManager = new TransferManager(managerOptions);
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Act
            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);

            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                tokenSource.Token);
            // Assert
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();
            // Assert
            Assert.IsEmpty(blobs);
            testEventsRaised.AssertUnexpectedFailureCheck();
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_SingleFile()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);

            List<string> files = new()
            {
                GetNewBlobName(),
            };

            CancellationToken cancellationToken = TestHelper.GetTimeoutToken(10);
            await SetupDirectory(
                localDirectory,
                files.Select(name => (name, (long)Constants.KB)).ToList(),
                cancellationToken);
            await UploadBlobDirectoryAndVerify(
                localDirectory,
                test.Container,
                files.Count,
                cancellationToken: cancellationToken);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_ManySubDirectories()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);

            List<string> files = new()
            {
                GetNewBlobName(),
            };
            foreach (string dir in Enumerable.Range(0, 3).Select(_ => GetNewBlobName()))
            {
                foreach (string blob in Enumerable.Range(0, 3).Select(_ => GetNewBlobName()))
                {
                    files.Add($"{dir}/{blob}");
                }
            }

            string blobPrefix = GetNewBlobName();
            CancellationToken cancellationToken = TestHelper.GetTimeoutToken(10);
            await SetupDirectory(
                localDirectory,
                files.Select(name => (name, (long)Constants.KB)).ToList(),
                cancellationToken);
            await UploadBlobDirectoryAndVerify(
                localDirectory,
                test.Container,
                files.Count,
                destinationPrefix: blobPrefix,
                cancellationToken: cancellationToken);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task DirectoryUpload_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);
            string blobName = GetNewBlobName();

            List<string> files = new List<string>();

            string subfolderName = "";
            for (int i = 0; i < level; i++)
            {
                subfolderName = Path.Combine(subfolderName, $"folder{i}");
                files.Add(Path.Combine(subfolderName, GetNewBlobName()));
            }

            CancellationToken cancellationToken = TestHelper.GetTimeoutToken(30);
            await SetupDirectory(
                localDirectory,
                files.Select(name => (name, (long)Constants.KB)).ToList(),
                cancellationToken);
            await UploadBlobDirectoryAndVerify(
                localDirectory,
                test.Container,
                files.Count,
                destinationPrefix: blobName,
                cancellationToken: cancellationToken);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_EmptySubDirectories()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);

            string dirName = GetNewBlobName();
            List<string> files = new List<string>();
            string openSubfolder = CreateRandomDirectory(localDirectory);
            for (int i = 0; i < 6; i++)
            {
                files.Add(await CreateRandomFileAsync(openSubfolder));
            }

            string openSubfolder2 = CreateRandomDirectory(localDirectory);

            string openSubfolder3 = CreateRandomDirectory(localDirectory);

            string openSubfolder4 = CreateRandomDirectory(localDirectory);

            await UploadBlobDirectoryAndVerify(
                localDirectory,
                test.Container,
                expectedTransfers: 6,
                destinationPrefix: dirName,
                cancellationToken: TestHelper.GetTimeoutToken(10));
        }
        #endregion

        #region DirectoryUploadTests

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_OverwriteTrue()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);

            List<string> files = GetTestDirectoryTree(localDirectory);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists
            };
            BlobClient blobClient = test.Container.GetBlobClient(dirName + "/" + files[0]);
            await blobClient.UploadAsync(new BinaryData(GetRandomBuffer(1234)));

            CancellationToken cancellationToken = TestHelper.GetTimeoutToken(10);
            await SetupDirectory(
                localDirectory,
                files.Select(name => (name, (long)Constants.KB)).ToList(),
                cancellationToken);
            await UploadBlobDirectoryAndVerify(
                localDirectory,
                test.Container,
                files.Count,
                destinationPrefix: dirName,
                options: options,
                cancellationToken: cancellationToken);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_OverwriteFalse()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);
            string dirName = GetNewBlobName();

            List<string> files = GetTestDirectoryTree(localDirectory);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists
            };
            BlobClient blobClient = test.Container.GetBlobClient(dirName + "/" + files[0]);
            await blobClient.UploadAsync(new BinaryData(GetRandomBuffer(1234)));

            // Act
            CancellationToken cancellationToken = TestHelper.GetTimeoutToken(10);
            await SetupDirectory(
                localDirectory,
                files.Select(name => (name, (long)Constants.KB)).ToList(),
                cancellationToken);
            await UploadBlobDirectoryAndVerify(
                localDirectory,
                test.Container,
                files.Count,
                destinationPrefix: dirName,
                options: options,
                cancellationToken: cancellationToken);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(BlobType.Block)]
        [TestCase(BlobType.Append)]
        [TestCase(BlobType.Page)]
        public async Task DirectoryUpload_BlobType(BlobType blobType)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string localDirectory = CreateRandomDirectory(testDirectory.DirectoryPath);
            string dirName = GetNewBlobName();

            string file1 = await CreateRandomFileAsync(localDirectory);
            string openSubfolder = CreateRandomDirectory(localDirectory);
            string file2 = await CreateRandomFileAsync(openSubfolder);
            string destinationPrefix = "foo";

            TransferManager transferManager = new TransferManager();

            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(localDirectory);
            BlobStorageResourceContainerOptions options = new BlobStorageResourceContainerOptions()
            {
                BlobType = blobType,
                BlobDirectoryPrefix = destinationPrefix,
            };
            StorageResourceContainer destinationResource = new BlobStorageResourceContainer(
                test.Container,
                options);

            DataTransferOptions containerOptions = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(containerOptions);

            // Act
            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, containerOptions);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            AsyncPageable<BlobItem> blobs = test.Container.GetBlobsAsync(prefix: destinationPrefix);
            await foreach (BlobItem blob in blobs)
            {
                Assert.AreEqual(blob.Properties.BlobType, blobType);
            }
            await testEventsRaised.AssertContainerCompletedCheck(2);
        }
        #endregion DirectoryUploadTests

        #region DirectoryUploadTests_Root

        private async Task<string[]> PopulateLocalTestDirectory(string path)
        {
            string file1 = await CreateRandomFileAsync(path, size: 10);

            string dir1 = CreateRandomDirectory(path);
            string file2 = await CreateRandomFileAsync(dir1, size: 10);
            string file3 = await CreateRandomFileAsync(dir1, size: 10);
            string file4 = await CreateRandomFileAsync(dir1, size: 10);

            string dir2 = CreateRandomDirectory(path);
            string file5 = await CreateRandomFileAsync(dir2, size: 10);

            string[] files = { file1, file2, file3, file4, file5 };
            return files;
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryUpload_Root()
        {
            // Arrange
            using DisposingLocalDirectory source = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer destination = await GetTestContainerAsync();

            string[] files = await PopulateLocalTestDirectory(source.DirectoryPath);

            TransferManager transferManager = new TransferManager();

            StorageResourceContainer sourceResource =
                new LocalDirectoryStorageResourceContainer(source.DirectoryPath);
            StorageResourceContainer destinationResource =
                new BlobStorageResourceContainer(destination.Container);
            DataTransferOptions options = new();
            TestEventsRaised testEventsRaised = new(options);

            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);

            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                tokenSource.Token);

            IEnumerable<string> destinationFiles =
                (await destination.Container.GetBlobsAsync().ToEnumerableAsync()).Select(b => b.Name);

            Assert.IsTrue(files
                .Select(f => f.Substring(source.DirectoryPath.Length + 1).Replace("\\", "/"))
                .OrderBy(f => f)
                .SequenceEqual(destinationFiles.OrderBy(f => f)));
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(DataTransferErrorMode.ContinueOnFailure)]
        [TestCase(DataTransferErrorMode.StopOnAnyFailure)]
        public async Task DirectoryUpload_ErrorHandling(DataTransferErrorMode errorHandling)
        {
            // Arrange
            using DisposingLocalDirectory source = DisposingLocalDirectory.GetTestDirectory();
            await using DisposingContainer destination = await GetTestContainerAsync();

            string[] files = await PopulateLocalTestDirectory(source.DirectoryPath);

            // Create conflict
            await destination.Container.UploadBlobAsync(
                files[0].Substring(source.DirectoryPath.Length + 1), BinaryData.FromString("Hello world"));

            TransferManager transferManager = new TransferManager(new TransferManagerOptions()
            {
                ErrorHandling = errorHandling
            });

            StorageResourceContainer sourceResource =
                new LocalDirectoryStorageResourceContainer(source.DirectoryPath);
            StorageResourceContainer destinationResource =
                new BlobStorageResourceContainer(destination.Container);

            // Conflict should cause failure
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Act
            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);

            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                tokenSource.Token);

            // Assert
            IEnumerable<string> destinationFiles =
                (await destination.Container.GetBlobsAsync().ToEnumerableAsync()).Select(b => b.Name);

            if (errorHandling == DataTransferErrorMode.ContinueOnFailure)
            {
                await testEventsRaised.AssertContainerCompletedWithFailedCheckContinue(1);

                // Verify all files exist, meaning files without conflict were transferred.
                Assert.IsTrue(files
                    .Select(f => f.Substring(source.DirectoryPath.Length + 1).Replace("\\", "/"))
                    .OrderBy(f => f)
                    .SequenceEqual(destinationFiles.OrderBy(f => f)));
            }
            else if (errorHandling == DataTransferErrorMode.StopOnAnyFailure)
            {
                await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);

                // Cannot do any file verification as transfer may proceed while job being cancelled
            }
        }

        #endregion

        #region Single Concurrency
        private async Task CreateTempDirectoryStructure(
            string sourceFolderPath,
            int size)
        {
            await CreateRandomFileAsync(sourceFolderPath, "blob1", size: size);
            await CreateRandomFileAsync(sourceFolderPath, "blob2,", size: size);

            string openSubfolder = CreateRandomDirectory(sourceFolderPath);
            await CreateRandomFileAsync(openSubfolder, "blob3", size: size);
            string lockedSubfolder = CreateRandomDirectory(sourceFolderPath);
            await CreateRandomFileAsync(lockedSubfolder, "blob4", size: size);
        }

        private async Task<DataTransfer> CreateStartTransfer(
            string sourceDirectoryPath,
            BlobContainerClient containerClient,
            int concurrency,
            bool createFailedCondition = false,
            DataTransferOptions options = default,
            int size = Constants.KB)
        {
            // Arrange
            string destinationFolderName = GetNewBlobDirectoryName();
            await CreateTempDirectoryStructure(sourceDirectoryPath, size);

            // Create storage resources
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(sourceDirectoryPath);
            // Create destination folder
            StorageResourceContainer destinationResource = new BlobStorageResourceContainer(containerClient, new() { BlobDirectoryPrefix = destinationFolderName });

            // Create Transfer Manager with single threaded operation
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                MaximumConcurrency = concurrency,
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            // If we want a failure condition to happen
            if (createFailedCondition)
            {
                string destinationBlobName = $"{destinationFolderName}/blob1";
                await CreateBlockBlob(
                    containerClient: containerClient,
                    localSourceFile: Path.Combine(sourceDirectoryPath, GetNewBlobName()),
                    blobName: destinationBlobName,
                    size: size);
            }

            // Start transfer and await for completion.
            return await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                testDirectory.DirectoryPath,
                test.Container,
                1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            await testEventsRaised.AssertContainerCompletedCheck(4);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                testDirectory.DirectoryPath,
                test.Container,
                1,
                true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                testDirectory.DirectoryPath,
                test.Container,
                1,
                true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            await testEventsRaised.AssertContainerCompletedWithSkippedCheck(1);
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a EnsureCompleted
            DataTransfer transfer = await CreateStartTransfer(
                testDirectory.DirectoryPath,
                test.Container,
                1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            TestTransferWithTimeout.WaitForCompletion(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertContainerCompletedCheck(4);
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                testDirectory.DirectoryPath,
                test.Container,
                1,
                true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            TestTransferWithTimeout.WaitForCompletion(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Skipped()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a EnsureCompleted
            DataTransfer transfer = await CreateStartTransfer(
                testDirectory.DirectoryPath,
                test.Container,
                1,
                true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            TestTransferWithTimeout.WaitForCompletion(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertContainerCompletedWithSkippedCheck(1);
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Failed_SmallChunks()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists,
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                sourceDirectoryPath: testDirectory.DirectoryPath,
                containerClient: test.Container,
                concurrency: 1,
                createFailedCondition: true,
                options: options,
                size: Constants.KB * 4);

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            TestTransferWithTimeout.WaitForCompletion(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
        }
        #endregion
    }
}
