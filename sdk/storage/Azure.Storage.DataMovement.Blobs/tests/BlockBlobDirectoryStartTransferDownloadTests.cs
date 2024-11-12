// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
extern alias BaseBlobs;

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using BaseBlobs::Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [DataMovementBlobsClientTestFixture]
    public class BlockBlobDirectoryStartTransferDownloadTests
        : BlobDirectoryStartTransferDownloadTestBase
    {
        public BlockBlobDirectoryStartTransferDownloadTests(
            bool async,
            BlobClientOptions.ServiceVersion serviceVersion)
        : base(async, serviceVersion)
        {
        }

        protected override async Task CreateBlobClientAsync(
            BlobContainerClient container, string blobName, Stream contents, CancellationToken cancellationToken = default)
        {
            BlockBlobClient blockBlobClient = container.GetBlockBlobClient(blobName);
            if (contents != default)
            {
                await blockBlobClient.UploadAsync(contents, cancellationToken: cancellationToken);
            }
        }

        protected override BlobType GetBlobType()
            => BlobType.Block;
    }
}
