// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public static class BlobTestSetupHelper
    {
        public static async Task CreateDirectoryBlockBlobsAsync(
            BlobContainerClient container,
            string pathPrefix,
            int blobCount = 2,
            long objectLength = DataMovementBlobStressConstants.KB * 4,
            CancellationToken cancellationToken = default)
        {
            for (int i = 0; i < blobCount; i++)
            {
                string blobName = $"{pathPrefix}/{TestSetupHelper.Randomize("blob")}";
                await CreateBlockBlobAsync(
                    container.GetBlockBlobClient(blobName),
                    objectLength,
                    cancellationToken);
            }
        }

        public static async Task CreateBlockBlobAsync(
            BlockBlobClient blockBlobClient,
            long objectLength = DataMovementBlobStressConstants.KB * 4,
            CancellationToken cancellationToken = default)
        {
            using Stream originalStream = await TestSetupHelper.CreateLimitedMemoryStream(objectLength, cancellationToken: cancellationToken);
            if (originalStream != default)
            {
                await blockBlobClient.UploadAsync(originalStream, cancellationToken: cancellationToken);
            }
            else
            {
                var data = new byte[0];
                using (var stream = new MemoryStream(data))
                {
                    await blockBlobClient.UploadAsync(
                        content: stream,
                        cancellationToken: cancellationToken);
                }
            }
        }
    }
}
