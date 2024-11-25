// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;
extern alias DMBlobs;
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Test.Shared;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using BaseBlobs::Azure.Storage.Blobs.Models;
using DMBlobs::Azure.Storage.Blobs;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [TestFixture(true, BlobClientOptions.ServiceVersion.V2024_11_04, null)]
    [TestFixture(false, BlobClientOptions.ServiceVersion.V2024_11_04, null)]
    public class BlobContainerClientExtensionsIntegrationTests : StorageTestBase<StorageTestEnvironment>
    {
        protected ClientBuilder<BlobServiceClient, BlobClientOptions> ClientBuilder { get; }

        protected readonly BlobClientOptions.ServiceVersion _serviceVersion;

        public BlobContainerClientExtensionsIntegrationTests(bool async, BlobClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode = null)
            : base(async, mode)
        {
            _serviceVersion = serviceVersion;
            ClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, _serviceVersion);
        }

        private async Task<BlockBlobClient> CreateBlockBlobAsync(
            BlobContainerClient containerClient,
            string blobName,
            long size,
            BlobUploadOptions options = default)
        {
            BlockBlobClient blobClient = containerClient.GetBlockBlobClient(blobName);

            using Stream originalStream = await CreateLimitedMemoryStream(size);
            await blobClient.UploadAsync(originalStream, options);
            return blobClient;
        }

        #region StartUploadDirectoryAsyncTests
        private async Task CreateTempDirectoryStructureAsync(
            string directoryPath,
            int size)
        {
            await CreateRandomFileAsync(directoryPath, "blob0", size: size);
            await CreateRandomFileAsync(directoryPath, "blob1", size: size);

            string openSubfolder = CreateRandomDirectory(directoryPath);
            await CreateRandomFileAsync(openSubfolder, "blob2", size: size);
            string lockedSubfolder = CreateRandomDirectory(directoryPath);
            await CreateRandomFileAsync(lockedSubfolder, "blob3", size: size);
        }

        private async Task<DataTransfer> CreateStartUploadDirectoryAsync_WithOptions(
            string directoryPath,
            BlobContainerClient containerClient,
            bool createFailedCondition = false,
            DataTransferOptions options = default,
            int size = Constants.KB)
        {
            await CreateTempDirectoryStructureAsync(directoryPath, size);
            BlobContainerClientTransferOptions transferOptions = new BlobContainerClientTransferOptions
            {
                TransferOptions = options,
            };

            // If we want a failure condition to happen
            if (createFailedCondition)
            {
                await CreateBlockBlobAsync(
                    containerClient: containerClient,
                    blobName: "blob0",
                    size: size);
            }

            return await containerClient.StartUploadDirectoryAsync(directoryPath, transferOptions);
        }

        private async Task<DataTransfer> CreateStartUploadDirectoryAsync_WithDirectoryPrefix(
            string directoryPath,
            BlobContainerClient containerClient,
            string blobDirectoryPrefix = default,
            int size = Constants.KB)
        {
            await CreateTempDirectoryStructureAsync(directoryPath, size);
            return await containerClient.StartUploadDirectoryAsync(directoryPath, blobDirectoryPrefix);
        }

        [RecordedTest]
        public async Task StartUploadDirectoryAsync_WithOptions()
        {
            // Create a temp local directory
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            string directoryPath = disposingLocalDirectory.DirectoryPath;

            // Create a temp blob container
            await using var disposingContainer = await ClientBuilder.GetTestContainerAsync(publicAccessType: PublicAccessType.None);
            BlobContainerClient containerClient = disposingContainer.Container;

            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Act
            DataTransfer dataTransfer = await CreateStartUploadDirectoryAsync_WithOptions(directoryPath, containerClient, false, options, 1);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                dataTransfer,
                testEventsRaised,
                cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.IsNotNull(dataTransfer);
            Assert.IsTrue(dataTransfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, dataTransfer.TransferStatus.State);
            var blobItems = await containerClient.GetBlobsAsync().ToListAsync();
            Assert.AreEqual(4, blobItems.Count);
            HashSet<string> allBlobNames = new HashSet<string>();
            foreach (var blobItem in blobItems)
            {
                string blobName = blobItem.Name;
                string blobNameSuffix = blobName.Substring(blobName.Length - 5);
                allBlobNames.Add(blobNameSuffix);
            }
            for (int i = 0; i < 4; i++)
            {
                Assert.IsTrue(allBlobNames.Contains($"blob{i}"));
            }
            await testEventsRaised.AssertContainerCompletedCheck(4);
        }

        [RecordedTest]
        public async Task StartUploadDirectoryAsync_WithDirectoryPrefix()
        {
            // Create a temp local directory
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            string directoryPath = disposingLocalDirectory.DirectoryPath;

            // Create a temp blob container
            await using var disposingContainer = await ClientBuilder.GetTestContainerAsync(publicAccessType: PublicAccessType.None);
            BlobContainerClient containerClient = disposingContainer.Container;

            string blobDirectoryPrefix = "foo";

            // Act
            DataTransfer dataTransfer = await CreateStartUploadDirectoryAsync_WithDirectoryPrefix(directoryPath, containerClient, blobDirectoryPrefix, 1);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await dataTransfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.IsNotNull(dataTransfer);
            Assert.IsTrue(dataTransfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, dataTransfer.TransferStatus.State);
            var blobItems = await containerClient.GetBlobsAsync().ToListAsync();
            Assert.AreEqual(4, blobItems.Count);
            HashSet<string> allBlobNames = new HashSet<string>();
            foreach (var blobItem in blobItems)
            {
                string blobName = blobItem.Name;
                string blobNamePrefix = blobName.Substring(0, blobDirectoryPrefix.Length);
                Assert.AreEqual(blobNamePrefix, blobDirectoryPrefix);
                string blobNameSuffix = blobName.Substring(blobName.Length - 5);
                allBlobNames.Add(blobNameSuffix);
            }
            for (int i = 0; i < 4; i++)
            {
                Assert.IsTrue(allBlobNames.Contains($"blob{i}"));
            }
        }

        [RecordedTest]
        public async Task StartUploadDirectoryAsync_WithOptions_Failed()
        {
            // Create a temp local directory
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            string directoryPath = disposingLocalDirectory.DirectoryPath;

            // Create a temp blob container
            await using var disposingContainer = await ClientBuilder.GetTestContainerAsync(publicAccessType: PublicAccessType.None);
            BlobContainerClient containerClient = disposingContainer.Container;

            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Act
            DataTransfer dataTransfer = await CreateStartUploadDirectoryAsync_WithOptions(directoryPath, containerClient, true, options, 1);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                dataTransfer,
                testEventsRaised,
                cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
            Assert.NotNull(dataTransfer);
            Assert.IsTrue(dataTransfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, dataTransfer.TransferStatus.State);
            Assert.AreEqual(true, dataTransfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
        }

        [RecordedTest]
        public async Task StartUploadDirectoryAsync_WithOptions_Skipped()
        {
            // Create a temp local directory
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            string directoryPath = disposingLocalDirectory.DirectoryPath;

            // Create a temp blob container
            await using var disposingContainer = await ClientBuilder.GetTestContainerAsync(publicAccessType: PublicAccessType.None);
            BlobContainerClient containerClient = disposingContainer.Container;

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Act
            DataTransfer dataTransfer = await CreateStartUploadDirectoryAsync_WithOptions(directoryPath, containerClient, true, options, 1);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                dataTransfer,
                testEventsRaised,
                cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            await testEventsRaised.AssertContainerCompletedWithSkippedCheck(1);
            Assert.NotNull(dataTransfer);
            Assert.IsTrue(dataTransfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, dataTransfer.TransferStatus.State);
            Assert.AreEqual(true, dataTransfer.TransferStatus.HasSkippedItems);
        }
        #endregion StartUploadDirectoryAsyncTests

        #region StartDownloadToDirectoryAsyncTests
        private async Task CreateBlobDirectoryTree(
            BlobContainerClient client,
            string sourceLocalFolderPath,
            string sourceBlobDirectoryName,
            int size)
        {
            string blobName0 = string.Concat(sourceBlobDirectoryName, "/blob0");
            string blobName1 = string.Concat(sourceBlobDirectoryName, "/blob1");
            await CreateBlockBlobAsync(client, blobName0, size);
            await CreateBlockBlobAsync(client, blobName1, size);

            string subDirName = "bar";
            CreateRandomDirectory(sourceLocalFolderPath, subDirName);
            string blobName2 = string.Concat(sourceBlobDirectoryName, "/", subDirName, "/blob2");
            await CreateBlockBlobAsync(client, blobName2, size);

            string subDirName2 = "pik";
            CreateRandomDirectory(sourceLocalFolderPath, subDirName2);
            string blobName3 = string.Concat(sourceBlobDirectoryName, "/", subDirName2, "/blob3");
            await CreateBlockBlobAsync(client, blobName3, size);
        }

        private async Task<DataTransfer> CreateStartDownloadToDirectoryAsync_WithOptions(
            string directoryPath,
            BlobContainerClient containerClient,
            DataTransferOptions options = default,
            int size = Constants.KB)
        {
            string sourceBlobPrefix = "sourceFolder";
            string sourceLocalFolderPath = CreateRandomDirectory(Path.GetTempPath(), sourceBlobPrefix);
            await CreateBlobDirectoryTree(containerClient, sourceLocalFolderPath, sourceBlobPrefix, size);

            BlobContainerClientTransferOptions transferOptions = new BlobContainerClientTransferOptions
            {
                TransferOptions = options,
            };

            return await containerClient.StartDownloadToDirectoryAsync(directoryPath, transferOptions);
        }

        private async Task<DataTransfer> CreateStartDownloadToDirectoryAsync_WithDirectoryPrefix(
            string directoryPath,
            BlobContainerClient containerClient,
            string prefixFilter = default,
            int size = Constants.KB)
        {
            string sourceBlobPrefix = "sourceFolder";
            string sourceLocalFolderPath = CreateRandomDirectory(Path.GetTempPath(), sourceBlobPrefix);
            await CreateBlobDirectoryTree(containerClient, sourceLocalFolderPath, sourceBlobPrefix, size);
            string blobDirectoryPrefix = string.Concat(sourceBlobPrefix, prefixFilter);

            return await containerClient.StartDownloadToDirectoryAsync(directoryPath, blobDirectoryPrefix);
        }

        [RecordedTest]
        public async Task StartDownloadToDirectoryAsync_WithOptions()
        {
            // Create a temp local directory
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            string directoryPath = disposingLocalDirectory.DirectoryPath;

            // Create a temp blob container
            await using var disposingContainer = await ClientBuilder.GetTestContainerAsync(publicAccessType: PublicAccessType.None);
            BlobContainerClient containerClient = disposingContainer.Container;

            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Act
            DataTransfer dataTransfer = await CreateStartDownloadToDirectoryAsync_WithOptions(directoryPath, containerClient, options, 1);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                dataTransfer,
                testEventsRaised,
                cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(dataTransfer);
            Assert.IsTrue(dataTransfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, dataTransfer.TransferStatus.State);
            string[] allLocalFilePaths = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);
            Assert.AreEqual(4, allLocalFilePaths.Length);
            HashSet<string> allFileNames = new HashSet<string>();
            foreach (string filePath in allLocalFilePaths)
            {
                string fileName = Path.GetFileName(filePath);
                allFileNames.Add(fileName);
            }
            for (int i = 0; i < 4; i++)
            {
                Assert.IsTrue(allFileNames.Contains($"blob{i}"));
            }
            await testEventsRaised.AssertContainerCompletedCheck(4);
        }

        [RecordedTest]
        public async Task StartDownloadToDirectoryAsync_WithDirectoryPrefix()
        {
            // Create a temp local directory
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            string directoryPath = disposingLocalDirectory.DirectoryPath;

            // Create a temp blob container
            await using var disposingContainer = await ClientBuilder.GetTestContainerAsync(publicAccessType: PublicAccessType.None);
            BlobContainerClient containerClient = disposingContainer.Container;

            string prefixFilter = "/pik"; // should only download blob3 based on dir prefix

            // Act
            DataTransfer dataTransfer = await CreateStartDownloadToDirectoryAsync_WithDirectoryPrefix(directoryPath, containerClient, prefixFilter, 1);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await dataTransfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(dataTransfer);
            Assert.IsTrue(dataTransfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, dataTransfer.TransferStatus.State);
            string[] allLocalFilePaths = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);
            Assert.AreEqual(1, allLocalFilePaths.Length);
            string localFileName = Path.GetFileName(allLocalFilePaths.First());
            Assert.AreEqual("blob3", localFileName);
        }

        [RecordedTest]
        public async Task StartDownloadToDirectoryAsync_WithOptions_Failed()
        {
            // Create a temp local directory
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            string directoryPath = disposingLocalDirectory.DirectoryPath;

            // Create a temp blob container
            await using var disposingContainer = await ClientBuilder.GetTestContainerAsync(publicAccessType: PublicAccessType.None);
            BlobContainerClient containerClient = disposingContainer.Container;

            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create at least one of the dest files to make it fail
            string folderPath = Path.Combine(directoryPath, "sourceFolder");
            Directory.CreateDirectory(folderPath);
            File.Create(Path.Combine(folderPath, "blob0")).Close();

            // Act
            DataTransfer dataTransfer = await CreateStartDownloadToDirectoryAsync_WithOptions(directoryPath, containerClient, options, 1);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                dataTransfer,
                testEventsRaised,
                cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(dataTransfer);
            Assert.IsTrue(dataTransfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, dataTransfer.TransferStatus.State);
            Assert.AreEqual(true, dataTransfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("Cannot overwrite file."));
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
        }

        [RecordedTest]
        public async Task StartDownloadToDirectoryAsync_WithOptions_Skipped()
        {
            // Create a temp local directory
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            string directoryPath = disposingLocalDirectory.DirectoryPath;

            // Create a temp blob container
            await using var disposingContainer = await ClientBuilder.GetTestContainerAsync(publicAccessType: PublicAccessType.None);
            BlobContainerClient containerClient = disposingContainer.Container;

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create at least one of the dest files to make it fail
            string folderPath = Path.Combine(directoryPath, "sourceFolder");
            Directory.CreateDirectory(folderPath);
            File.Create(Path.Combine(folderPath, "blob0")).Dispose();

            // Act
            DataTransfer dataTransfer = await CreateStartDownloadToDirectoryAsync_WithOptions(directoryPath, containerClient, options, 1);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                dataTransfer,
                testEventsRaised,
                cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(dataTransfer);
            Assert.IsTrue(dataTransfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, dataTransfer.TransferStatus.State);
            Assert.AreEqual(true, dataTransfer.TransferStatus.HasSkippedItems);
            await testEventsRaised.AssertContainerCompletedWithSkippedCheck(1);
        }
        #endregion StartDownloadToDirectoryAsyncTests
    }
}
