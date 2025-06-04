// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Shared;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using NUnit.Framework;
using BaseBlobs::Azure.Storage.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public static class BlobTestSetupHelper
    {
        private const int DefaultBufferSize = 4 * Constants.KB * Constants.KB;

        public static async Task CreateBlobsInDirectoryAsync(
            BlobContainerClient container,
            BlobType blobType,
            string pathPrefix,
            int blobCount = 2,
            long objectLength = Constants.KB * 4,
            CancellationToken cancellationToken = default)
        {
            for (int i = 0; i < blobCount; i++)
            {
                string blobName = $"{pathPrefix}/{TestSetupHelper.Randomize("blob")}";
                if (blobType == BlobType.Append)
                {
                    await CreateAppendBlobAsync(
                        container.GetAppendBlobClient(blobName),
                        objectLength,
                        cancellationToken);
                }
                else if (blobType == BlobType.Page)
                {
                    await CreatePageBlobAsync(
                        container.GetPageBlobClient(blobName),
                        objectLength,
                        cancellationToken);
                }
                else
                {
                    await CreateBlockBlobAsync(
                    container.GetBlockBlobClient(blobName),
                    objectLength,
                    cancellationToken);
                }
            }
        }

        public static async Task CreateBlockBlobAsync(
            BlockBlobClient blockBlobClient,
            long? objectLength = Constants.KB * 4,
            CancellationToken cancellationToken = default)
        {
            using Stream originalStream = await TestSetupHelper.CreateLimitedMemoryStream(objectLength.Value, cancellationToken: cancellationToken);
            var data = new byte[0];
            using (var stream = new MemoryStream(data))
            {
                await blockBlobClient.UploadAsync(
                    content: stream,
                    cancellationToken: cancellationToken);
            }
        }

        public static async Task CreateAppendBlobAsync(
            AppendBlobClient appendBlobClient,
            long? objectLength = Constants.KB * 4,
            CancellationToken cancellationToken = default)
        {
            await appendBlobClient.CreateIfNotExistsAsync();
            if (objectLength.Value > 0)
            {
                using Stream originalStream = await TestSetupHelper.CreateLimitedMemoryStream(objectLength.Value, cancellationToken: cancellationToken);
                long offset = 0;
                long blockSize = Math.Min(DefaultBufferSize, objectLength.Value);
                while (offset < objectLength.Value)
                {
                    Stream partStream = WindowStream.GetWindow(originalStream, blockSize);
                    await appendBlobClient.AppendBlockAsync(partStream);
                    offset += blockSize;
                }
            }
        }

        public static async Task CreatePageBlobAsync(
            PageBlobClient pageBlobClient,
            long? objectLength = Constants.KB * 4,
            CancellationToken cancellationToken = default)
        {
            Assert.IsTrue(objectLength.Value % (Constants.KB / 2) == 0, "Cannot create page blob that's not a multiple of 512");
            await pageBlobClient.CreateIfNotExistsAsync(objectLength.Value);
            if (objectLength.Value > 0)
            {
                using Stream originalStream = await TestSetupHelper.CreateLimitedMemoryStream(objectLength.Value, cancellationToken: cancellationToken);
                long offset = 0;
                long blockSize = Math.Min(DefaultBufferSize, objectLength.Value);
                while (offset < objectLength.Value)
                {
                    Stream partStream = WindowStream.GetWindow(originalStream, blockSize);
                    await pageBlobClient.UploadPagesAsync(partStream, offset);
                    offset += blockSize;
                }
            }
        }
    }
}
