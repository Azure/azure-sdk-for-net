// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlob;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Common;
using Azure.Storage.DataMovement.Files.Shares;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Shared;
using Azure.Storage.Test.Shared;
using DMBlob::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    [ShareClientTestFixture]
    public class ShareDirectoryToPageBlobDirectoryTests : StartTransferCopyFromShareDirectoryTestBase
    {
        public ShareDirectoryToPageBlobDirectoryTests(
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
            await blobClient.CreateIfNotExistsAsync(size, cancellationToken: cancellationToken).ConfigureAwait(false);
            long offset = 0;
            long blockSize = Math.Min(Constants.DefaultBufferSize, size);
            while (offset < size)
            {
                Stream partStream = WindowStream.GetWindow(contents, blockSize);
                await blobClient.UploadPagesAsync(partStream, offset, cancellationToken: cancellationToken);
                offset += blockSize;
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
                    ContentDisposition = new(false),
                    ContentLanguage = new(false),
                    CacheControl = new(false),
                    ContentType = new(false),
                    Metadata = new(false)
                };
            }
            else if (propertiesTestType == TransferPropertiesTestType.Preserve)
            {
                options = new BlockBlobStorageResourceOptions
                {
                    ContentDisposition = new(true),
                    ContentLanguage = new(true),
                    CacheControl = new(true),
                    ContentType = new(true),
                    Metadata = new(true)
                };
            }
            return new BlobStorageResourceContainer(sourceContainerClient, new BlobStorageResourceContainerOptions()
            {
                BlobDirectoryPrefix = directoryPath,
                BlobType = new(BlobType.Page),
                BlobOptions = options
            });
        }
    }
}
