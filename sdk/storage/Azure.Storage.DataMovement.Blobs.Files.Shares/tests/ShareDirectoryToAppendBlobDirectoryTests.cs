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
using Azure.Storage.Shared;
using DMBlob::Azure.Storage.DataMovement.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    [BlobShareClientTestFixture]
    public class ShareDirectoryToAppendBlobDirectoryTests : StartTransferCopyFromShareDirectoryTestBase
    {
        public ShareDirectoryToAppendBlobDirectoryTests(
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

            AppendBlobClient blobClient = container.GetAppendBlobClient(objectName);
            if (contents != default)
            {
                await UploadAppendBlocksAsync(blobClient, contents, cancellationToken);
            }
            else
            {
                var data = new byte[0];
                using (var stream = new MemoryStream(data))
                {
                    await UploadAppendBlocksAsync(
                        blobClient,
                        stream,
                        cancellationToken);
                }
            }
        }

        private async Task UploadAppendBlocksAsync(
                AppendBlobClient blobClient,
                Stream contents,
                CancellationToken cancellationToken)
        {
            await blobClient.CreateIfNotExistsAsync(
                new AppendBlobCreateOptions()
                {
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
            long offset = 0;
            long size = contents.Length;
            long blockSize = Math.Min(Constants.DefaultBufferSize, size);
            while (offset < size)
            {
                Stream partStream = WindowStream.GetWindow(contents, blockSize);
                await blobClient.AppendBlockAsync(partStream, cancellationToken: cancellationToken);
                offset += blockSize;
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
            return new BlobStorageResourceContainer(sourceContainerClient, new BlobStorageResourceContainerOptions()
            {
                BlobPrefix = directoryPath,
                BlobType = BlobType.Append,
                BlobOptions = options
            });
        }
    }
}
