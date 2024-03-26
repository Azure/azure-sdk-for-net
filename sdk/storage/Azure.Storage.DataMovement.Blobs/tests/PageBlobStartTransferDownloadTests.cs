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
using Azure.Storage.Blobs.Tests;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using Azure.Storage.Test.Shared;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Shared;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [DataMovementBlobsClientTestFixture]
    public class PageBlobStartTransferDownloadTests : StartTransferDownloadTestBase<
        BlobServiceClient,
        BlobContainerClient,
        PageBlobClient,
        BlobClientOptions,
        StorageTestEnvironment>
    {
        private const int KB = 1024;
        private const int DefaultBufferSize = 4 * 1024 * 1024;
        private const string _blobResourcePrefix = "test-blob-";
        private const string _expectedOverwriteExceptionMessage = "Cannot overwrite file.";
        private const int MaxReliabilityRetries = 5;
        protected readonly BlobClientOptions.ServiceVersion _serviceVersion;

        public PageBlobStartTransferDownloadTests(
            bool async,
            BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _blobResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            ClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDisposingContainerAsync(BlobServiceClient service = null, string containerName = null)
            => await ClientBuilder.GetTestContainerAsync(service, containerName);

        protected override async Task<PageBlobClient> GetObjectClientAsync(
            BlobContainerClient container,
            long? objectLength,
            string objectName,
            bool createObject = false,
            BlobClientOptions options = null,
            Stream contents = null)
        {
            objectName ??= GetNewObjectName();
            PageBlobClient blobClient = container.GetPageBlobClient(objectName);

            if (createObject)
            {
                if (!objectLength.HasValue)
                {
                    throw new InvalidOperationException($"Cannot create a blob without size specified. Either set {nameof(createObject)} to false or specify a {nameof(objectLength)}.");
                }

                if (contents != default)
                {
                    await UploadPagesAsync(blobClient, contents);
                }
                else
                {
                    var data = GetRandomBuffer(objectLength.Value);
                    using Stream originalStream = await CreateLimitedMemoryStream(objectLength.Value);
                    await UploadPagesAsync(blobClient, originalStream);
                }
            }
            Uri sourceUri = blobClient.GenerateSasUri(BaseBlobs::Azure.Storage.Sas.BlobSasPermissions.All, Recording.UtcNow.AddDays(1));
            return InstrumentClient(new PageBlobClient(sourceUri, GetOptions()));
        }

        private async Task UploadPagesAsync(PageBlobClient blobClient, Stream contents)
        {
            long size = contents.Length;
            Assert.IsTrue(size % (KB / 2) == 0, "Cannot create page blob that's not a multiple of 512");
            await blobClient.CreateIfNotExistsAsync(size).ConfigureAwait(false);
            long offset = 0;
            long blockSize = Math.Min(DefaultBufferSize, size);
            while (offset < size)
            {
                Stream partStream = WindowStream.GetWindow(contents, blockSize);
                await blobClient.UploadPagesAsync(partStream, offset);
                offset += blockSize;
            }
        }

        protected override StorageResourceItem GetStorageResourceItem(PageBlobClient objectClient)
            => new PageBlobStorageResource(objectClient);

        protected override Task<Stream> OpenReadAsync(PageBlobClient objectClient)
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
