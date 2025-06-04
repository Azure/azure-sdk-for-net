// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias DMBlobs;
extern alias BaseBlobs;

using System;
using System.Threading.Tasks;
using Azure.Storage.Test.Shared;
using Azure.Storage.DataMovement.Tests;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using BaseBlobs::Azure.Storage.Blobs.Models;
using System.IO;
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
            BlobStorageResourceContainerOptions options = new()
            {
                BlobPrefix = GetNewContainerName()
            };
            return BlobsStorageResourceProvider.FromClient(container, options);
        }
    }
}
