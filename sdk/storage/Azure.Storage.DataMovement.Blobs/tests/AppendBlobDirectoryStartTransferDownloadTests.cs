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
    public class AppendBlobDirectoryStartTransferDownloadTests
        : BlobDirectoryStartTransferDownloadTestBase
    {
        public AppendBlobDirectoryStartTransferDownloadTests(
            bool async,
            BlobClientOptions.ServiceVersion serviceVersion)
        : base(async, serviceVersion)
        {
        }

        protected override async Task CreateBlobClientAsync(
            BlobContainerClient container, string blobName, Stream contents, CancellationToken cancellationToken = default)
        {
            AppendBlobClient appendBlobClient = container.GetAppendBlobClient(blobName);
            await appendBlobClient.CreateIfNotExistsAsync();
            if (contents != default)
            {
                if (contents.Length != 0)
                {
                    // cannot append a stream that has a Content-Length of 0
                    await appendBlobClient.AppendBlockAsync(contents, cancellationToken: cancellationToken);
                }
            }
        }

        protected override BlobType GetBlobType()
            => BlobType.Append;
    }
}
