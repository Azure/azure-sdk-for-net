// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlob;

using System;
using System.Threading.Tasks;
using Azure.Storage.Test.Shared;
using Azure.Storage.DataMovement.Tests;
using DMBlob::Azure.Storage.DataMovement.Blobs;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using System.IO;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    [BlobsClientTestFixture]
    public class BlockBlobToBlockBlobTests : StartTransferCopyTestBase
        <BlobServiceClient,
        BlobContainerClient,
        BlockBlobClient,
        BlobClientOptions,
        BlobServiceClient,
        BlobContainerClient,
        BlockBlobClient,
        BlobClientOptions,
        StorageTestEnvironment>
    {
        private const int MaxReliabilityRetries = 5;
        private const string _blobResourcePrefix = "test-blob-";
        private const string _expectedOverwriteExceptionMessage = "BlobAlreadyExists";
        protected readonly BlobClientOptions.ServiceVersion _serviceVersion;

        public BlockBlobToBlockBlobTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _blobResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            SourceClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
            DestinationClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<bool> SourceExistsAsync(BlockBlobClient objectClient)
            => await objectClient.ExistsAsync();

        protected override async Task<bool> DestinationExistsAsync(BlockBlobClient objectClient)
            => await objectClient.ExistsAsync();

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetSourceDisposingContainerAsync(BlobServiceClient service = null, string containerName = null)
            => await SourceClientBuilder.GetTestContainerAsync(service, containerName);

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDestinationDisposingContainerAsync(BlobServiceClient service = null, string containerName = null)
            => await DestinationClientBuilder.GetTestContainerAsync(service, containerName);

        private async Task<BlockBlobClient> GetBlockBlobClientAsync(
            BlobContainerClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            BlobClientOptions options = null,
            Stream contents = null)
        {
            objectName ??= GetNewObjectName();
            BlockBlobClient blobClient = container.GetBlockBlobClient(objectName);

            if (createResource)
            {
                if (!objectLength.HasValue)
                {
                    throw new InvalidOperationException($"Cannot create a blob without size specified. Either set {nameof(createResource)} to false or specify a {nameof(objectLength)}.");
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
            Uri sourceUri = blobClient.GenerateSasUri(Sas.BlobSasPermissions.All, Recording.UtcNow.AddDays(1));
            return InstrumentClient(new BlockBlobClient(sourceUri, GetOptions()));
        }

        protected override Task<BlockBlobClient> GetSourceObjectClientAsync(
            BlobContainerClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            BlobClientOptions options = null,
            Stream contents = null)
            => GetBlockBlobClientAsync(
                container,
                objectLength,
                createResource,
                objectName,
                options,
                contents);

        protected override StorageResourceItem GetSourceStorageResourceItem(BlockBlobClient objectClient)
            => new BlockBlobStorageResource(objectClient);

        protected override Task<Stream> SourceOpenReadAsync(BlockBlobClient objectClient)
            => objectClient.OpenReadAsync();

        protected override Task<BlockBlobClient> GetDestinationObjectClientAsync(
            BlobContainerClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            BlobClientOptions options = null,
            Stream contents = null)
            => GetBlockBlobClientAsync(
                container,
                objectLength,
                createResource,
                objectName,
                options,
                contents);

        protected override StorageResourceItem GetDestinationStorageResourceItem(BlockBlobClient objectClient)
            => new BlockBlobStorageResource(objectClient);

        protected override Task<Stream> DestinationOpenReadAsync(BlockBlobClient objectClient)
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
    }
}
