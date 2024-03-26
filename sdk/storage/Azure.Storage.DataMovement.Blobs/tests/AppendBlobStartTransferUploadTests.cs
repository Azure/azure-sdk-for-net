// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias DMBlobs;
extern alias BaseBlobs;

using System;
using System.Threading.Tasks;
using Azure.Storage.Test.Shared;
using Azure.Storage.DataMovement.Tests;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using System.IO;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.Storage.Shared;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [DataMovementBlobsClientTestFixture]
    public class AppendBlobStartTransferUploadTests : StartTransferUploadTestBase<
        BlobServiceClient,
        BlobContainerClient,
        AppendBlobClient,
        BlobClientOptions,
        StorageTestEnvironment>
    {
        private const int DefaultBufferSize = 4 * 1024 * 1024;
        private const string _blobResourcePrefix = "test-blob-";
        private const string _expectedOverwriteExceptionMessage = "BlobAlreadyExists";
        private const int MaxReliabilityRetries = 5;
        protected readonly BlobClientOptions.ServiceVersion _serviceVersion;

        public AppendBlobStartTransferUploadTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _blobResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            ClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<bool> ExistsAsync(AppendBlobClient objectClient)
            => await objectClient.ExistsAsync();

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDisposingContainerAsync(BlobServiceClient service = null, string containerName = null)
            => await ClientBuilder.GetTestContainerAsync(service, containerName);

        protected override async Task<AppendBlobClient> GetObjectClientAsync(
            BlobContainerClient container,
            long? resourceLength = null,
            bool createResource = false,
            string objectName = null,
            BlobClientOptions options = null,
            Stream contents = default)
        {
            objectName ??= GetNewObjectName();
            AppendBlobClient blobClient = container.GetAppendBlobClient(objectName);

            if (createResource)
            {
                if (!resourceLength.HasValue)
                {
                    throw new InvalidOperationException($"Cannot create a blob without size specified. Either set {nameof(createResource)} to false or specify a {nameof(resourceLength)}.");
                }

                if (contents != default)
                {
                    await UploadAppendBlocksAsync(blobClient, contents);
                }
                else
                {
                    var data = GetRandomBuffer(resourceLength.Value);
                    using Stream originalStream = await CreateLimitedMemoryStream(resourceLength.Value);
                    await UploadAppendBlocksAsync(blobClient, originalStream);
                }
            }
            Uri sourceUri = blobClient.GenerateSasUri(BaseBlobs::Azure.Storage.Sas.BlobSasPermissions.All, Recording.UtcNow.AddDays(1));
            return InstrumentClient(new AppendBlobClient(sourceUri, GetOptions()));
        }

        private async Task UploadAppendBlocksAsync(AppendBlobClient blobClient, Stream contents)
        {
            await blobClient.CreateIfNotExistsAsync();
            long offset = 0;
            long size = contents.Length;
            long blockSize = Math.Min(DefaultBufferSize, size);
            while (offset < size)
            {
                Stream partStream = WindowStream.GetWindow(contents, blockSize);
                await blobClient.AppendBlockAsync(partStream);
                offset += blockSize;
            }
        }

        protected override StorageResourceItem GetStorageResourceItem(AppendBlobClient objectClient)
            => new AppendBlobStorageResource(objectClient);

        protected override Task<Stream> OpenReadAsync(AppendBlobClient objectClient)
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
