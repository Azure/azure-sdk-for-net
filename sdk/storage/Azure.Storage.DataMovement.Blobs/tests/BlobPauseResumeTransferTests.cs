// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias BaseBlobs;
extern alias DMBlobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Test.Shared;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using BaseBlobs::Azure.Storage.Sas;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [DataMovementBlobsClientTestFixture]
    public class BlobPauseResumeTransferTests : PauseResumeTransferTestBase
        <BlobServiceClient,
        BlobContainerClient,
        BlockBlobClient,
        BlobClientOptions,
        StorageTestEnvironment>
    {
        protected readonly BlobClientOptions.ServiceVersion _serviceVersion;

        public BlobPauseResumeTransferTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            ClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDisposingContainerAsync(
            string containerName = default,
            BlobServiceClient service = default)
            => await ClientBuilder.GetTestContainerAsync(service, containerName);

        protected override StorageResourceProvider GetStorageResourceProvider()
            => new BlobsStorageResourceProvider(TestEnvironment.Credential);

        protected override StorageResourceProvider GetContainerSasStorageResourceProvider(BlobContainerClient sourceContainer, BlobContainerClient destinationContainer)
        {
            // Create Source Container SAS
            Uri sourceSasUri = sourceContainer.GenerateSasUri(
                BlobContainerSasPermissions.All,
                DateTimeOffset.UtcNow.AddHours(1));
            string sourceSas = new BlobUriBuilder(sourceSasUri).Sas.ToString();

            // Create Destination Container SAS
            Uri destinationSasUri = destinationContainer.GenerateSasUri(
                BlobContainerSasPermissions.All,
                DateTimeOffset.UtcNow.AddHours(1));
            string destinationSas = new BlobUriBuilder(destinationSasUri).Sas.ToString();

            // Create the provider with a delegate that returns the right SAS per URI
            Func<Uri, CancellationToken, ValueTask<AzureSasCredential>> getSasCredential = (uri, ct) =>
            {
                var builder = new BlobUriBuilder(uri);
                if (builder.BlobContainerName == sourceContainer.Name)
                    return new ValueTask<AzureSasCredential>(new AzureSasCredential(sourceSas));
                if (builder.BlobContainerName == destinationContainer.Name)
                    return new ValueTask<AzureSasCredential>(new AzureSasCredential(destinationSas));
                throw new InvalidOperationException($"Unknown container: {builder.BlobContainerName}");
            };
            return new BlobsStorageResourceProvider(getSasCredential);
        }

        protected override async Task<StorageResource> CreateSourceStorageResourceItemAsync(
            long size,
            string blobName,
            BlobContainerClient container)
        {
            BlockBlobClient blobClient = container.GetBlockBlobClient(blobName);
            // create a new file and copy contents of stream into it, and then close the FileStream
            using (Stream originalStream = await CreateLimitedMemoryStream(size))
            {
                // Upload blob to storage account
                originalStream.Position = 0;
                await blobClient.UploadAsync(originalStream);
            }
            return BlobsStorageResourceProvider.FromClient(blobClient);
        }

        protected override StorageResource CreateDestinationStorageResourceItem(
            string blobName,
            BlobContainerClient container,
            Metadata metadata = default,
            string contentLanguage = default)
        {
            BlockBlobStorageResourceOptions testOptions = new()
            {
                Metadata = metadata,
                ContentLanguage = contentLanguage,
            };
            BlockBlobClient destinationClient = container.GetBlockBlobClient(blobName);
            return BlobsStorageResourceProvider.FromClient(destinationClient, testOptions);
        }

        protected override async Task AssertDestinationProperties(
            string blobName,
            Metadata expectedMetadata,
            string expectedContentLanguage,
            BlobContainerClient container)
        {
            BlockBlobClient blob = container.GetBlockBlobClient(blobName);
            BlobProperties props = (await blob.GetPropertiesAsync()).Value;
            Assert.That(props.Metadata, Is.EqualTo(expectedMetadata));
            Assert.That(props.ContentLanguage, Is.EqualTo(expectedContentLanguage));
        }

        protected override async Task<Stream> GetStreamFromContainerAsync(Uri uri, BlobContainerClient container)
        {
            BlobUriBuilder builder = new BlobUriBuilder(uri);
            BlockBlobClient blobClient = container.GetBlockBlobClient(builder.BlobName);
            if (!await blobClient.ExistsAsync())
            {
                throw new FileNotFoundException($"Blob not found: {uri}");
            }

            MemoryStream stream = new MemoryStream();
            await blobClient.DownloadToAsync(stream);
            stream.Position = 0;
            return stream;
        }

        protected override async Task<StorageResource> CreateSourceStorageResourceContainerAsync(
            long size,
            int blobCount,
            string directoryPath,
            BlobContainerClient container)
        {
            for (int i = 0; i < blobCount; i++)
            {
                if (i % 3 == 0)
                {
                    BlockBlobClient blobClient = container.GetBlockBlobClient(string.Join("/", directoryPath, GetNewItemName()));
                    // create a new file and copy contents of stream into it, and then close the FileStream
                    using (Stream originalStream = await CreateLimitedMemoryStream(size))
                    {
                        // Upload blob to storage account
                        originalStream.Position = 0;
                        await blobClient.UploadAsync(originalStream);
                    }
                }
                else if (i % 3 == 1)
                {
                    AppendBlobClient blobClient = container.GetAppendBlobClient(string.Join("/", directoryPath, GetNewItemName()));
                    await blobClient.CreateAsync();
                    // create a new file and copy contents of stream into it, and then close the FileStream
                    using (Stream originalStream = await CreateLimitedMemoryStream(size))
                    {
                        // Upload blob to storage account
                        originalStream.Position = 0;
                        await blobClient.AppendBlockAsync(originalStream);
                    }
                }
                else
                {
                    PageBlobClient blobClient = container.GetPageBlobClient(string.Join("/", directoryPath, GetNewItemName()));
                    await blobClient.CreateAsync(size);
                    // create a new file and copy contents of stream into it, and then close the FileStream
                    using (Stream originalStream = await CreateLimitedMemoryStream(size))
                    {
                        // Upload blob to storage account
                        originalStream.Position = 0;
                        await blobClient.UploadPagesAsync(originalStream, 0);
                    }
                }
            }
            BlobStorageResourceContainerOptions options = new();
            options.BlobPrefix = directoryPath;
            return BlobsStorageResourceProvider.FromClient(container, options);
        }

        protected override StorageResource CreateDestinationStorageResourceContainer(
            BlobContainerClient container)
        {
            return BlobsStorageResourceProvider.FromClient(container);
        }

        protected override BlobServiceClient GetAzureSasCredentialServiceClient()
        {
            return ClientBuilder.GetServiceClientFromAzureSasCredentialConfig(Tenants.TestConfigDefault, default);
        }

        #region Snapshot Tests
        [Test]
        [Ignore("Live tests only")]
        [TestCase(TransferDirection.Copy)]
        public async Task PauseResumeTransfer_FromSnapshot(TransferDirection transferType)
        {
            // Arrange
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<BlobContainerClient> sourceContainer = await GetDisposingContainerAsync();
            await using IDisposingContainer<BlobContainerClient> destinationContainer = await GetDisposingContainerAsync();

            long size = DataMovementTestConstants.KB * 4;
            string blobName = GetNewItemName();

            // Create source blob
            BlockBlobClient sourceBlob = sourceContainer.Container.GetBlockBlobClient(blobName);
            using (Stream originalStream = await CreateLimitedMemoryStream(size))
            {
                await sourceBlob.UploadAsync(originalStream);
            }

            // Create a snapshot of the source blob
            Response<BlobSnapshotInfo> snapshotResponse = await sourceBlob.CreateSnapshotAsync();
            string snapshotId = snapshotResponse.Value.Snapshot;
            Assert.IsNotNull(snapshotId);

            // Modify the source blob after snapshot
            using (Stream modifiedStream = await CreateLimitedMemoryStream(size))
            {
                await sourceBlob.UploadAsync(modifiedStream);
            }

            // Create source resource from snapshot
            BlockBlobClient snapshotBlob = sourceBlob.WithSnapshot(snapshotId);
            StorageResource sourceResource = new BlockBlobStorageResource(snapshotBlob, new BlockBlobStorageResourceOptions { Snapshot = snapshotId });

            // Create destination resource
            BlockBlobClient destinationBlob = destinationContainer.Container.GetBlockBlobClient(blobName);
            StorageResource destinationResource = BlobsStorageResourceProvider.FromClient(destinationBlob);

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

            // Verify content matches the snapshot (not the modified blob)
            using Stream snapshotStream = new MemoryStream();
            await snapshotBlob.DownloadToAsync(snapshotStream);
            snapshotStream.Position = 0;

            using Stream destinationStream = new MemoryStream();
            await destinationBlob.DownloadToAsync(destinationStream);
            destinationStream.Position = 0;

            Assert.That(destinationStream.Length, Is.EqualTo(snapshotStream.Length));
            CollectionAssert.AreEqual(
                ((MemoryStream)snapshotStream).ToArray(),
                ((MemoryStream)destinationStream).ToArray());
        }

        [Test]
        [Ignore("Live tests only")]
        [TestCase(TransferDirection.Copy)]
        public async Task PauseResumeTransfer_FromBlobVersion(TransferDirection transferType)
        {
            // Arrange - requires versioning enabled on the storage account
            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<BlobContainerClient> sourceContainer = await GetDisposingContainerAsync();
            await using IDisposingContainer<BlobContainerClient> destinationContainer = await GetDisposingContainerAsync();

            long size = DataMovementTestConstants.KB * 4;
            string blobName = GetNewItemName();

            // Create source blob (first version)
            BlockBlobClient sourceBlob = sourceContainer.Container.GetBlockBlobClient(blobName);
            Response<BlobContentInfo> uploadResponse;
            using (Stream originalStream = await CreateLimitedMemoryStream(size))
            {
                uploadResponse = await sourceBlob.UploadAsync(originalStream);
            }

            string versionId = uploadResponse.Value.VersionId?.ToString();
            if (string.IsNullOrEmpty(versionId))
            {
                Assert.Inconclusive("Blob versioning is not enabled on this storage account");
                return;
            }

            // Modify the blob to create a new version
            using (Stream modifiedStream = await CreateLimitedMemoryStream(size))
            {
                await sourceBlob.UploadAsync(modifiedStream);
            }

            // Create source resource from specific version
            BlockBlobClient versionBlob = sourceBlob.WithVersion(versionId);
            StorageResource sourceResource = new BlockBlobStorageResource(versionBlob, new BlockBlobStorageResourceOptions { VersionId = versionId });

            // Create destination resource
            BlockBlobClient destinationBlob = destinationContainer.Container.GetBlockBlobClient(blobName);
            StorageResource destinationResource = BlobsStorageResourceProvider.FromClient(destinationBlob);

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

            // Verify content matches the versioned blob (not the current version)
            using Stream versionStream = new MemoryStream();
            await versionBlob.DownloadToAsync(versionStream);
            versionStream.Position = 0;

            using Stream destinationStream = new MemoryStream();
            await destinationBlob.DownloadToAsync(destinationStream);
            destinationStream.Position = 0;

            Assert.That(destinationStream.Length, Is.EqualTo(versionStream.Length));
            CollectionAssert.AreEqual(
                ((MemoryStream)versionStream).ToArray(),
                ((MemoryStream)destinationStream).ToArray());
        }
        #endregion
    }
}
