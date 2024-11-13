// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias DMBlobs;
extern alias BaseBlobs;

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Tests;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using Azure.Storage.Test.Shared;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using BaseBlobs::Azure.Storage.Blobs.Models;
using System.Threading;
using System.Linq;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [DataMovementBlobsClientTestFixture]
    public class BlockBlobStartTransferDownloadTests : StartTransferDownloadTestBase<
        BlobServiceClient,
        BlobContainerClient,
        BlockBlobClient,
        BlobClientOptions,
        StorageTestEnvironment>
    {
        private const string _blobResourcePrefix = "test-blob-";
        private const string _expectedOverwriteExceptionMessage = "Cannot overwrite file.";
        private const int MaxReliabilityRetries = 5;
        protected readonly BlobClientOptions.ServiceVersion _serviceVersion;

        public BlockBlobStartTransferDownloadTests(
            bool async,
            BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _blobResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            ClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDisposingContainerAsync(BlobServiceClient service = null, string containerName = null)
            => await ClientBuilder.GetTestContainerAsync(service, containerName);

        protected override async Task<BlockBlobClient> GetObjectClientAsync(
            BlobContainerClient container,
            long? objectLength,
            string objectName,
            bool createObject = false,
            BlobClientOptions options = null,
            Stream contents = null)
        {
            objectName ??= GetNewObjectName();
            BlockBlobClient blobClient = container.GetBlockBlobClient(objectName);

            if (createObject)
            {
                if (!objectLength.HasValue)
                {
                    throw new InvalidOperationException($"Cannot create a blob without size specified. Either set {nameof(createObject)} to false or specify a {nameof(objectLength)}.");
                }

                if (contents != default)
                {
                    await blobClient.UploadAsync(contents);
                }
                else
                {
                    var data = GetRandomBuffer(objectLength.Value);
                    using Stream originalStream = await CreateLimitedMemoryStream(objectLength.Value);
                    await blobClient.UploadAsync(originalStream);
                }
            }
            Uri sourceUri = blobClient.GenerateSasUri(BaseBlobs::Azure.Storage.Sas.BlobSasPermissions.All, Recording.UtcNow.AddDays(1));
            return InstrumentClient(new BlockBlobClient(sourceUri, GetOptions()));
        }

        protected override StorageResourceItem GetStorageResourceItem(BlockBlobClient objectClient)
            => new BlockBlobStorageResource(objectClient);

        protected override Task<Stream> OpenReadAsync(BlockBlobClient objectClient)
            => objectClient.OpenReadAsync();

        public BlobClientOptions GetOptions()
        {
            var options = new BlobClientOptions((BlobClientOptions.ServiceVersion)_serviceVersion)
            {
                Diagnostics = { IsLoggingEnabled = true },
                Retry =
                {
                    Mode = RetryMode.Exponential,
                    MaxRetries = MaxReliabilityRetries,
                    Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 1),
                    MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 60)
                },
            };
            if (Mode != RecordedTestMode.Live)
            {
                options.AddPolicy(new RecordedClientRequestIdPolicy(Recording), HttpPipelinePosition.PerCall);
            }

            return InstrumentClientOptions(options);
        }

        [Test]
        public async Task DownloadTransferTest()
        {
            BlobServiceClient service = ClientBuilder.GetServiceClient_OAuth(TestEnvironment.Credential);
            BlobContainerClient container = service.GetBlobContainerClient("test-download-1");
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            //await container.CreateIfNotExistsAsync();
            //Random random = new();
            //foreach (int i in Enumerable.Range(0, 5))
            //{
            //    byte[] data = new byte[1048576];
            //    random.NextBytes(data);
            //    await container.UploadBlobAsync($"blob{i}", new BinaryData(data));
            //}

            BlobsStorageResourceProvider blobProvider = new();
            LocalFilesStorageResourceProvider localProvider = new();

            TransferManager transferManager = new();
            DataTransferOptions options = new()
            {
                InitialTransferSize = 4096,
                MaximumTransferChunkSize = 4096,
            };
            TestEventsRaised testEvents = new(options);
            DataTransfer transfer = await transferManager.StartTransferAsync(
                blobProvider.FromClient(container),
                localProvider.FromDirectory(testDirectory.DirectoryPath),
                options);

            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(cts.Token);
            testEvents.AssertUnexpectedFailureCheck();

            await foreach (BlobItem blob in container.GetBlobsAsync())
            {
                string localPath = Path.Combine(testDirectory.DirectoryPath, blob.Name);
                var response = await container.GetBlobClient(blob.Name).DownloadContentAsync();
                byte[] expected = response.Value.Content.ToArray();
                byte[] actual = File.ReadAllBytes(localPath);

                Assert.That(actual, Is.EqualTo(expected));
            }
        }
    }
}
