// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
extern alias BaseBlobs;

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using DMBlobs::Azure.Storage.DataMovement.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [DataMovementBlobsClientTestFixture]
    public class BlockBlobDirectoryToAppendBlobDirectoryTests :
        StartTransferBlobDirectoryCopyTestBase<BlockBlobClient, AppendBlobClient>
    {
        public BlockBlobDirectoryToAppendBlobDirectoryTests(
            bool async,
            object serviceVersion)
        : base(async, serviceVersion)
        {
        }

        protected override Task CreateDirectoryInDestinationAsync(
            BlobContainerClient destinationContainer,
            string directoryPath,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            // No-op since blobs are virtual directories
            return Task.CompletedTask;
        }

        protected override Task CreateDirectoryInSourceAsync(
            BlobContainerClient sourceContainer,
            string directoryPath,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            // No-op since blobs are virtual directories
            return Task.CompletedTask;
        }

        protected override Task CreateObjectInDestinationAsync(
            BlobContainerClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = null,
            CancellationToken cancellationToken = default)
            => CreateAppendBlobAsync(container, objectLength, objectName, contents, cancellationToken);

        protected override Task CreateObjectInSourceAsync(
            BlobContainerClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = null,
            TransferPropertiesTestType propertiesTestType = TransferPropertiesTestType.Default,
            CancellationToken cancellationToken = default)
            => CreateBlockBlobAsync(container, objectName, contents, cancellationToken);

        protected override StorageResourceContainer GetDestinationStorageResourceContainer(
            BlobContainerClient containerClient,
            string directoryPath,
            TransferPropertiesTestType propertiesTestType = TransferPropertiesTestType.Default)
        {
            AppendBlobStorageResourceOptions options = default;
            if (propertiesTestType == TransferPropertiesTestType.NewProperties)
            {
                options = new AppendBlobStorageResourceOptions(GetSetValuesResourceOptions());
            }
            else if (propertiesTestType == TransferPropertiesTestType.NoPreserve)
            {
                options = new AppendBlobStorageResourceOptions
                {
                    ContentDisposition = default,
                    ContentLanguage = default,
                    CacheControl = default,
                    ContentType = default,
                    Metadata = default
                };
            }
            return new BlobStorageResourceContainer(containerClient, new BlobStorageResourceContainerOptions()
            {
                BlobDirectoryPrefix = directoryPath,
                BlobType = BlobType.Append,
                BlobOptions = options
            });
        }

        protected override StorageResourceContainer GetSourceStorageResourceContainer(
            BlobContainerClient containerClient,
            string directoryPath)
            => new BlobStorageResourceContainer(
                containerClient,
                new BlobStorageResourceContainerOptions()
                {
                    BlobDirectoryPrefix = directoryPath,
                    BlobType = BlobType.Block
                });

        protected internal override AppendBlobClient GetDestinationBlob(BlobContainerClient containerClient, string blobName)
            => containerClient.GetAppendBlobClient(blobName);

        protected internal override BlockBlobClient GetSourceBlob(BlobContainerClient containerClient, string blobName)
            => containerClient.GetBlockBlobClient(blobName);
    }
}
