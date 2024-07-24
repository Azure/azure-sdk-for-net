// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlob;

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Tests;
using DMBlob::Azure.Storage.DataMovement.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    [ShareClientTestFixture]
    public class BlockBlobDirectoryToShareDirectoryTests :
        StartTransferCopyToShareDirectoryTestBase
    {
        public BlockBlobDirectoryToShareDirectoryTests(
            bool async,
            object serviceVersion)
            : base(async, serviceVersion)
        {
        }

        protected override async Task CreateObjectInDestinationAsync(ShareClient container, long? objectLength = null, string objectName = null, Stream contents = null, CancellationToken cancellationToken = default)
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

        protected override async Task CreateObjectInSourceAsync(
            BlobContainerClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = null,
            TransferPropertiesTestType propertiesType = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            objectName ??= GetNewObjectName();

            BlockBlobClient blobClient = container.GetBlockBlobClient(objectName);
            if (contents != default)
            {
                await blobClient.UploadAsync(
                    content: contents,
                    new BlobUploadOptions()
                    {
                        AccessTier = _defaultAccessTier,
                        Metadata = _defaultMetadata,
                        HttpHeaders = new BlobHttpHeaders()
                        {
                            ContentType = _defaultContentType,
                            ContentLanguage = _defaultContentLanguageBlob,
                            ContentDisposition = _defaultContentDisposition,
                            CacheControl = _defaultCacheControl,
                        }
                    },
                    cancellationToken: cancellationToken);
            }
            else
            {
                var data = new byte[0];
                using (var stream = new MemoryStream(data))
                {
                    await blobClient.UploadAsync(
                        content: stream,
                        new BlobUploadOptions()
                        {
                            AccessTier = _defaultAccessTier,
                            Metadata = _defaultMetadata,
                            HttpHeaders = new BlobHttpHeaders()
                            {
                                ContentType = _defaultContentType,
                                ContentLanguage = _defaultContentLanguageBlob,
                                ContentDisposition = _defaultContentDisposition,
                                CacheControl = _defaultCacheControl,
                            }
                        },
                        cancellationToken: cancellationToken);
                }
            }
        }

        protected override StorageResourceContainer GetSourceStorageResourceContainer(BlobContainerClient containerClient, string directoryPath)
            => new BlobStorageResourceContainer(containerClient, new BlobStorageResourceContainerOptions() { BlobDirectoryPrefix = directoryPath, BlobType = new(BlobType.Block) });
    }
}
