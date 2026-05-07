// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias BaseShares;
extern alias DMShare;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Test.Shared;
using BaseShares::Azure.Storage.Files.Shares;
using BaseShares::Azure.Storage.Files.Shares.Models;
using BaseShares::Azure.Storage.Sas;
using DMShare::Azure.Storage.DataMovement.Files.Shares;
using NUnit.Framework;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [DataMovementShareClientTestFixture]
    public class ShareFilePauseResumeTransferTests : PauseResumeTransferTestBase
        <ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        protected readonly ShareClientOptions.ServiceVersion _serviceVersion;

        public ShareFilePauseResumeTransferTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            ClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetDisposingContainerAsync(
            string containerName = default,
            ShareServiceClient service = default)
            => await ClientBuilder.GetTestShareAsync(service, containerName);

        protected override StorageResourceProvider GetStorageResourceProvider()
            => new ShareFilesStorageResourceProvider(TestEnvironment.Credential);

        protected override StorageResourceProvider GetContainerSasStorageResourceProvider(ShareClient sourceContainer, ShareClient destinationContainer)
        {
            // Create Source Container SAS
            Uri sourceSasUri = sourceContainer.GenerateSasUri(
                ShareSasPermissions.All,
                DateTimeOffset.UtcNow.AddHours(1));
            string sourceSas = new ShareUriBuilder(sourceSasUri).Sas.ToString();

            // Create Destination Container SAS
            Uri destinationSasUri = destinationContainer.GenerateSasUri(
                ShareSasPermissions.All,
                DateTimeOffset.UtcNow.AddHours(1));
            string destinationSas = new ShareUriBuilder(destinationSasUri).Sas.ToString();

            // Create the provider with a delegate that returns the right SAS per URI
            Func<Uri, CancellationToken, ValueTask<AzureSasCredential>> getSasCredential = (uri, ct) =>
            {
                var builder = new ShareUriBuilder(uri);
                if (builder.ShareName == sourceContainer.Name)
                    return new ValueTask<AzureSasCredential>(new AzureSasCredential(sourceSas));
                if (builder.ShareName == destinationContainer.Name)
                    return new ValueTask<AzureSasCredential>(new AzureSasCredential(destinationSas));
                throw new InvalidOperationException($"Unknown container: {builder.ShareName}");
            };
            return new ShareFilesStorageResourceProvider(getSasCredential);
        }

        protected override async Task<StorageResource> CreateSourceStorageResourceItemAsync(
            long size,
            string fileName,
            ShareClient container)
        {
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(fileName);
            await fileClient.CreateAsync(size);
            // create a new file and copy contents of stream into it, and then close the FileStream
            using (Stream originalStream = await CreateLimitedMemoryStream(size))
            {
                originalStream.Position = 0;
                await fileClient.UploadAsync(originalStream);
            }
            return ShareFilesStorageResourceProvider.FromClient(fileClient);
        }

        protected override StorageResource CreateDestinationStorageResourceItem(
            string fileName,
            ShareClient container,
            Metadata metadata = default,
            string contentLanguage = default)
        {
            ShareFileStorageResourceOptions testOptions = new()
            {
                FileMetadata = metadata,
                ContentLanguage = contentLanguage is null ? null : new[] { contentLanguage }
            };
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(fileName);
            return ShareFilesStorageResourceProvider.FromClient(fileClient, testOptions);
        }

        protected override async Task AssertDestinationProperties(
            string fileName,
            Metadata expectedMetadata,
            string expectedContentLanguage,
            ShareClient container)
        {
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(fileName);
            ShareFileProperties props = (await fileClient.GetPropertiesAsync()).Value;
            Assert.That(props.Metadata, Is.EqualTo(expectedMetadata));
            Assert.That(props.ContentLanguage.First, Is.EqualTo(expectedContentLanguage));
        }

        protected override async Task<Stream> GetStreamFromContainerAsync(Uri uri, ShareClient container)
        {
            var uriBuilder = new ShareUriBuilder(uri);
            string fileName = uriBuilder.DirectoryOrFilePath;
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(fileName);
            if (!await fileClient.ExistsAsync())
            {
                throw new FileNotFoundException($"File not found: {uri}");
            }

            // Download the file to a MemoryStream
            ShareFileDownloadInfo downloadInfo = await fileClient.DownloadAsync();
            MemoryStream memoryStream = new MemoryStream();
            await downloadInfo.Content.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            return memoryStream;
        }

        protected override async Task<StorageResource> CreateSourceStorageResourceContainerAsync(
            long size,
            int count,
            string directoryPath,
            ShareClient container)
        {
            for (int i = 0; i < count; i++)
            {
                ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(GetNewItemName());
                await fileClient.CreateAsync(size);
                // create a new file and copy contents of stream into it, and then close the FileStream
                using (Stream originalStream = await CreateLimitedMemoryStream(size))
                {
                    originalStream.Position = 0;
                    await fileClient.UploadAsync(originalStream);
                }
            }
            return ShareFilesStorageResourceProvider.FromClient(container.GetRootDirectoryClient());
        }

        protected override StorageResource CreateDestinationStorageResourceContainer(
            ShareClient container)
        {
            return ShareFilesStorageResourceProvider.FromClient(container.GetRootDirectoryClient());
        }

        protected override ShareServiceClient GetAzureSasCredentialServiceClient()
            => ClientBuilder.GetServiceClientFromAzureSasCredentialConfig(Tenants.TestConfigDefault, default);

        #region Snapshot Tests
        [Test]
        [Ignore("Live tests only")]
        [TestCase(TransferDirection.Copy)]
        public async Task PauseResumeTransfer_FromShareSnapshot(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<ShareClient> sourceContainer = await GetDisposingContainerAsync();
            await using IDisposingContainer<ShareClient> destinationContainer = await GetDisposingContainerAsync();

            long size = DataMovementTestConstants.KB * 4;
            string fileName = GetNewItemName();

            // Create source file
            ShareFileClient sourceFile = sourceContainer.Container.GetRootDirectoryClient().GetFileClient(fileName);
            await sourceFile.CreateAsync(size);
            using (Stream originalStream = await CreateLimitedMemoryStream(size))
            {
                originalStream.Position = 0;
                await sourceFile.UploadAsync(originalStream);
            }

            // Create a snapshot of the share
            Response<ShareSnapshotInfo> snapshotResponse = await sourceContainer.Container.CreateSnapshotAsync();
            string snapshotId = snapshotResponse.Value.Snapshot;
            Assert.IsNotNull(snapshotId);

            // Modify the source file after snapshot
            using (Stream modifiedStream = await CreateLimitedMemoryStream(size))
            {
                modifiedStream.Position = 0;
                await sourceFile.UploadAsync(modifiedStream);
            }

            // Create source resource from snapshot
            ShareClient snapshotShare = sourceContainer.Container.WithSnapshot(snapshotId);
            ShareFileClient snapshotFile = snapshotShare.GetRootDirectoryClient().GetFileClient(fileName);
            ShareFileStorageResourceOptions snapshotOptions = new ShareFileStorageResourceOptions
            {
                Snapshot = snapshotId
            };
            StorageResource sourceResource = ShareFilesStorageResourceProvider.FromClient(snapshotFile, snapshotOptions);

            // Create destination resource
            ShareFileClient destinationFile = destinationContainer.Container.GetRootDirectoryClient().GetFileClient(fileName);
            StorageResource destinationResource = ShareFilesStorageResourceProvider.FromClient(destinationFile);

            // Create TransferManager, options and provider
            StorageResourceProvider provider = GetStorageResourceProvider();
            TransferManagerOptions transferManagerOptions = new TransferManagerOptions()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(checkpointerDirectory.DirectoryPath),
                ErrorMode = TransferErrorMode.ContinueOnFailure,
                ProvidersForResuming = new List<StorageResourceProvider>() { provider },
            };
            TransferManager transferManager = new TransferManager(transferManagerOptions);
            TransferOptions transferOptions = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);

            // Start transfer
            TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                transferOptions);

            // Pause the transfer
            using CancellationTokenSource pauseTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await transferManager.PauseTransferAsync(transfer.Id, pauseTokenSource.Token);

            // Assert - paused
            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(TransferState.Paused, transfer.Status.State);

            // Resume transfer
            TransferOptions resumeOptions = new TransferOptions()
            {
                CreationMode = StorageResourceCreationMode.OverwriteIfExists
            };
            TestEventsRaised resumeEventsRaised = new TestEventsRaised(resumeOptions);

            TransferOperation resumeTransfer = await transferManager.ResumeTransferAsync(
                transferId: transfer.Id,
                transferOptions: resumeOptions);

            using CancellationTokenSource waitTransferCompletion = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await resumeTransfer.WaitForCompletionAsync(waitTransferCompletion.Token);

            // Assert - completed
            await resumeEventsRaised.AssertSingleCompletedCheck();
            Assert.AreEqual(TransferState.Completed, resumeTransfer.Status.State);
            Assert.IsTrue(resumeTransfer.HasCompleted);

            // Verify content matches the snapshot (not the modified file)
            using Stream snapshotStream = new MemoryStream();
            var snapshotDownload = await snapshotFile.DownloadAsync();
            await snapshotDownload.Value.Content.CopyToAsync(snapshotStream);
            snapshotStream.Position = 0;

            using Stream destinationStream = new MemoryStream();
            var destDownload = await destinationFile.DownloadAsync();
            await destDownload.Value.Content.CopyToAsync(destinationStream);
            destinationStream.Position = 0;

            Assert.That(destinationStream.Length, Is.EqualTo(snapshotStream.Length));
            CollectionAssert.AreEqual(
                ((MemoryStream)snapshotStream).ToArray(),
                ((MemoryStream)destinationStream).ToArray());
        }

        [Test]
        [Ignore("Live tests only")]
        [TestCase(TransferDirection.Copy)]
        public async Task PauseResumeTransfer_FromShareSnapshot_Directory(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<ShareClient> sourceContainer = await GetDisposingContainerAsync();
            await using IDisposingContainer<ShareClient> destinationContainer = await GetDisposingContainerAsync();

            // Use larger files and more count to ensure transfer doesn't complete before pause
            long size = DataMovementTestConstants.MB;
            int fileCount = 5;
            string directoryName = GetNewItemName();

            // Create source directory with files
            ShareDirectoryClient sourceDirectory = sourceContainer.Container.GetDirectoryClient(directoryName);
            await sourceDirectory.CreateAsync();

            for (int i = 0; i < fileCount; i++)
            {
                string fileName = GetNewItemName();
                ShareFileClient fileClient = sourceDirectory.GetFileClient(fileName);
                await fileClient.CreateAsync(size);
                using (Stream originalStream = await CreateLimitedMemoryStream(size))
                {
                    originalStream.Position = 0;
                    await fileClient.UploadAsync(originalStream);
                }
            }

            // Create a snapshot of the share
            Response<ShareSnapshotInfo> snapshotResponse = await sourceContainer.Container.CreateSnapshotAsync();
            string snapshotId = snapshotResponse.Value.Snapshot;
            Assert.IsNotNull(snapshotId);

            // Modify files after snapshot
            var files = sourceDirectory.GetFilesAndDirectoriesAsync();
            await foreach (ShareFileItem fileItem in files)
            {
                if (!fileItem.IsDirectory)
                {
                    ShareFileClient fileClient = sourceDirectory.GetFileClient(fileItem.Name);
                    using (Stream modifiedStream = await CreateLimitedMemoryStream(size))
                    {
                        modifiedStream.Position = 0;
                        await fileClient.UploadAsync(modifiedStream);
                    }
                }
            }

            // Create source resource from snapshot directory
            ShareClient snapshotShare = sourceContainer.Container.WithSnapshot(snapshotId);
            ShareDirectoryClient snapshotDirectory = snapshotShare.GetDirectoryClient(directoryName);
            ShareFileStorageResourceOptions snapshotOptions = new ShareFileStorageResourceOptions
            {
                Snapshot = snapshotId
            };
            StorageResource sourceResource = ShareFilesStorageResourceProvider.FromClient(snapshotDirectory, snapshotOptions);

            // Create destination resource
            ShareDirectoryClient destinationDirectory = destinationContainer.Container.GetDirectoryClient(directoryName);
            // For Azure Files, we need to ensure the destination directory exists before transfer
            await destinationDirectory.CreateIfNotExistsAsync();
            StorageResource destinationResource = ShareFilesStorageResourceProvider.FromClient(destinationDirectory);

            // Create TransferManager and options
            StorageResourceProvider provider = GetStorageResourceProvider();
            TransferManagerOptions transferManagerOptions = new TransferManagerOptions()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(checkpointerDirectory.DirectoryPath),
                ErrorMode = TransferErrorMode.ContinueOnFailure,
                ProvidersForResuming = new List<StorageResourceProvider>() { provider },
            };
            TransferManager transferManager = new TransferManager(transferManagerOptions);
            TransferOptions transferOptions = new TransferOptions()
            {
                // Use small chunk sizes to slow down the transfer so we can pause it
                InitialTransferSize = DataMovementTestConstants.KB,
                MaximumTransferChunkSize = DataMovementTestConstants.KB
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);

            // Start transfer
            TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                transferOptions);

            // Pause the transfer - give it more time for larger files
            using CancellationTokenSource pauseTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transferManager.PauseTransferAsync(transfer.Id, pauseTokenSource.Token);

            // Assert - paused
            await testEventsRaised.AssertPausedCheck();
            Assert.AreEqual(TransferState.Paused, transfer.Status.State);

            // Resume transfer
            TransferOptions resumeOptions = new TransferOptions()
            {
                CreationMode = StorageResourceCreationMode.OverwriteIfExists
            };
            TestEventsRaised resumeEventsRaised = new TestEventsRaised(resumeOptions);

            TransferOperation resumeTransfer = await transferManager.ResumeTransferAsync(
                transferId: transfer.Id,
                transferOptions: resumeOptions);

            using CancellationTokenSource waitTransferCompletion = new CancellationTokenSource(TimeSpan.FromSeconds(600));
            await resumeTransfer.WaitForCompletionAsync(waitTransferCompletion.Token);

            // Assert - completed
            await resumeEventsRaised.AssertContainerCompletedCheck(fileCount);
            Assert.AreEqual(TransferState.Completed, resumeTransfer.Status.State);
            Assert.IsTrue(resumeTransfer.HasCompleted);

            // Verify files were transferred (directory should already exist from transfer)
            var destinationFiles = destinationDirectory.GetFilesAndDirectoriesAsync();
            int destinationFileCount = 0;
            await foreach (ShareFileItem fileItem in destinationFiles)
            {
                if (!fileItem.IsDirectory)
                {
                    destinationFileCount++;
                }
            }
            Assert.AreEqual(fileCount, destinationFileCount, "All files should be transferred");
        }
        #endregion
    }
}
