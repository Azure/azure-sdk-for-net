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
using Azure.Storage.Shared;
using DMBlob::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    [BlobShareClientTestFixture]
    public class PageBlobDirectoryToShareDirectoryTests :
        StartTransferCopyToShareDirectoryTestBase
    {
        public PageBlobDirectoryToShareDirectoryTests(
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

            PageBlobClient blobClient = container.GetPageBlobClient(objectName);
            if (contents != default)
            {
                await UploadPagesAsync(blobClient, contents, cancellationToken);
            }
            else
            {
                var data = new byte[0];
                using (var stream = new MemoryStream(data))
                {
                    await UploadPagesAsync(
                        blobClient,
                        stream,
                        cancellationToken);
                }
            }
        }

        private async Task UploadPagesAsync(
            PageBlobClient blobClient,
            Stream contents,
            CancellationToken cancellationToken)
        {
            long size = contents.Length;
            Assert.IsTrue(size % (Constants.KB / 2) == 0, "Cannot create page blob that's not a multiple of 512");
            await blobClient.CreateIfNotExistsAsync(size, new PageBlobCreateOptions()
            {
                Metadata = _defaultMetadata,
                HttpHeaders = new BlobHttpHeaders()
                {
                    ContentType = _defaultContentType,
                    ContentLanguage = _defaultContentLanguageBlob,
                    ContentDisposition = _defaultContentDisposition,
                    CacheControl = _defaultCacheControl,
                }
            });
            long offset = 0;
            long blockSize = Math.Min(Constants.DefaultBufferSize, size);
            while (offset < size)
            {
                Stream partStream = WindowStream.GetWindow(contents, blockSize);
                await blobClient.UploadPagesAsync(partStream, offset, cancellationToken: cancellationToken);
                offset += blockSize;
            }
        }

        protected override StorageResourceContainer GetSourceStorageResourceContainer(BlobContainerClient containerClient, string directoryPath)
            => new BlobStorageResourceContainer(containerClient, new BlobStorageResourceContainerOptions() { BlobDirectoryPrefix = directoryPath, BlobType = BlobType.Page });
    }
}
