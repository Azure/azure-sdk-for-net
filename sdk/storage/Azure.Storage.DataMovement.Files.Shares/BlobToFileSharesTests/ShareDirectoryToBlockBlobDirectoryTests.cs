// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlob;
extern alias BaseShares;

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using BaseShares::Azure.Storage.Files.Shares;
using DMBlob::Azure.Storage.DataMovement.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    [BlobShareClientTestFixture]
    public class ShareDirectoryToBlockBlobDirectoryTests : StartTransferCopyFromShareDirectoryTestBase
    {
        public ShareDirectoryToBlockBlobDirectoryTests(
            bool async,
            object serviceVersion)
            : base(async, serviceVersion)
        {
        }

        protected override async Task CreateObjectInDestinationAsync(
            BlobContainerClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = null,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            objectName ??= GetNewObjectName();

            BlockBlobClient blobClient = container.GetBlockBlobClient(objectName);
            if (contents != default)
            {
                await blobClient.UploadAsync(contents, cancellationToken: cancellationToken);
            }
            else
            {
                var data = new byte[0];
                using (var stream = new MemoryStream(data))
                {
                    await blobClient.UploadAsync(
                        content: stream,
                        cancellationToken: cancellationToken);
                }
            }
        }

        protected override async Task CreateObjectInSourceAsync(
            ShareClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = null,
            TransferPropertiesTestType propertiesType = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            objectName ??= GetNewObjectName();
            if (!objectLength.HasValue)
            {
                throw new InvalidOperationException($"Cannot create share file without size specified. Specify {nameof(objectLength)}.");
            }
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);
            await fileClient.CreateAsync(objectLength.Value);

            if (contents != default)
            {
                await fileClient.UploadAsync(contents, cancellationToken: cancellationToken);
            }
        }

        protected override StorageResourceContainer GetDestinationStorageResourceContainer(
            BlobContainerClient sourceContainerClient,
            string directoryPath,
            TransferPropertiesTestType propertiesTestType = default)
        {
            BlockBlobStorageResourceOptions options = default;
            if (propertiesTestType == TransferPropertiesTestType.NewProperties)
            {
                options = new BlockBlobStorageResourceOptions(GetSetValuesResourceOptions());
            }
            else if (propertiesTestType == TransferPropertiesTestType.NoPreserve)
            {
                options = new BlockBlobStorageResourceOptions
                {
                    ContentDisposition = default,
                    ContentLanguage = default,
                    CacheControl = default,
                    ContentType = default,
                    Metadata = default
                };
            }
            return new BlobStorageResourceContainer(sourceContainerClient, new BlobStorageResourceContainerOptions()
            {
                BlobDirectoryPrefix = directoryPath,
                BlobType = BlobType.Block,
                BlobOptions = options
            });
        }
    }
}
