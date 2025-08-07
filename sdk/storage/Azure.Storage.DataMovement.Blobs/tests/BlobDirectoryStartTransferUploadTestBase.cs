// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;
extern alias DMBlobs;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Test.Shared;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using DMBlobs::Azure.Storage.DataMovement.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [DataMovementBlobsClientTestFixture]
    public abstract class BlobDirectoryStartTransferUploadTestBase<TObjectClient>
        : StartTransferUploadDirectoryTestBase<
            BlobServiceClient,
            BlobContainerClient,
            TObjectClient,
            BlobClientOptions,
            StorageTestEnvironment>
        where TObjectClient : BlobBaseClient
    {
        public BlobDirectoryStartTransferUploadTestBase(bool async, BlobClientOptions.ServiceVersion serviceVersion, bool isPageBlob = false)
            : base(async, null, isPageBlob)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
        }

        protected abstract Task CreateBlobClientAsync(BlobContainerClient container, string blobName, Stream contents, CancellationToken cancellationToken = default);

        protected abstract BlobType GetBlobType();

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDisposingContainerAsync(
            BlobServiceClient service = default,
            string containerName = default)
            => await ClientBuilder.GetTestContainerAsync(service, containerName);

        protected override TransferValidator.ListFilesAsync GetStorageResourceLister(BlobContainerClient containerClient)
            => TransferValidator.GetBlobLister(containerClient, "");

        protected override async Task InitializeDestinationDataAsync(
            BlobContainerClient containerClient,
            List<(string FilePath, long Size)> fileSizes,
            CancellationToken cancellationToken)
        {
            foreach ((string blobName, long size) in fileSizes)
            {
                await CreateBlobClientAsync(containerClient, blobName, new MemoryStream(GetRandomBuffer(size)), cancellationToken);
            }
        }

        protected override StorageResourceContainer GetStorageResourceContainer(BlobContainerClient containerClient)
        {
            BlobStorageResourceContainerOptions options = new();
            options.BlobType = GetBlobType();
            return new BlobStorageResourceContainer(containerClient, options);
        }
    }
}
