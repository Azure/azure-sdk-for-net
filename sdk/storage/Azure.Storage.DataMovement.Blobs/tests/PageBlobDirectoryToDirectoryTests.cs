﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
extern alias BaseBlobs;

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using DMBlobs::Azure.Storage.DataMovement.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [DataMovementBlobsClientTestFixture]
    public class PageBlobDirectoryToDirectoryTests :
        StartTransferBlobDirectoryCopyTestBase<PageBlobClient, PageBlobClient>
    {
        public PageBlobDirectoryToDirectoryTests(
            bool async,
            object serviceVersion)
        : base(async, serviceVersion)
        {
        }

        protected override Task CreateObjectInDestinationAsync(
            BlobContainerClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = null,
            CancellationToken cancellationToken = default)
            => CreatePageBlobAsync(container, objectLength, objectName, contents, cancellationToken);

        protected override Task CreateObjectInSourceAsync(
            BlobContainerClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = null,
            TransferPropertiesTestType propertiesType = default,
            CancellationToken cancellationToken = default)
            => CreatePageBlobAsync(container, objectLength, objectName, contents, cancellationToken);

        protected override StorageResourceContainer GetDestinationStorageResourceContainer(
            BlobContainerClient containerClient,
            string directoryPath,
            TransferPropertiesTestType propertiesTestType = TransferPropertiesTestType.Default)
        {
            PageBlobStorageResourceOptions options = default;
            if (propertiesTestType == TransferPropertiesTestType.NewProperties)
            {
                options = new PageBlobStorageResourceOptions(GetSetValuesResourceOptions());
            }
            else if (propertiesTestType == TransferPropertiesTestType.NoPreserve)
            {
                options = new PageBlobStorageResourceOptions
                {
                    ContentDisposition = new(false),
                    ContentLanguage = new(false),
                    CacheControl = new(false),
                    ContentType = new(false),
                    Metadata = new(false)
                };
            }
            else if (propertiesTestType == TransferPropertiesTestType.Preserve)
            {
                options = new PageBlobStorageResourceOptions
                {
                    ContentDisposition = new(true),
                    ContentLanguage = new(true),
                    CacheControl = new(true),
                    ContentType = new(true),
                    Metadata = new(true)
                };
            }
            return new BlobStorageResourceContainer(containerClient, new BlobStorageResourceContainerOptions()
            {
                BlobDirectoryPrefix = directoryPath,
                BlobType = new(BlobType.Page),
                BlobOptions = options
            });
        }

        protected override StorageResourceContainer GetSourceStorageResourceContainer(BlobContainerClient containerClient, string directoryPath)
            => new BlobStorageResourceContainer(containerClient, new BlobStorageResourceContainerOptions() { BlobDirectoryPrefix = directoryPath, BlobType = new(BlobType.Page) });

        protected internal override PageBlobClient GetDestinationBlob(BlobContainerClient containerClient, string blobName)
            => containerClient.GetPageBlobClient(blobName);

        protected internal override PageBlobClient GetSourceBlob(BlobContainerClient containerClient, string blobName)
            => containerClient.GetPageBlobClient(blobName);
    }
}
