// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlob;
extern alias BaseShares;

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using DMBlob::Azure.Storage.DataMovement.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    [BlobShareClientTestFixture]
    public class BlockBlobDirectoryToShareDirectoryTests :
        StartTransferCopyToShareDirectoryTestBase
    {
        public BlockBlobDirectoryToShareDirectoryTests(
            bool async,
            object serviceVersion)
            : base(async, serviceVersion)
        {
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
            => new BlobStorageResourceContainer(containerClient, new BlobStorageResourceContainerOptions() { BlobDirectoryPrefix = directoryPath, BlobType = BlobType.Block });
    }
}
