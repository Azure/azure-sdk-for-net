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
    public class PageBlobDirectoryStartTransferDownloadTests
        : BlobDirectoryStartTransferDownloadTestBase
    {
        public PageBlobDirectoryStartTransferDownloadTests(
            bool async,
            BlobClientOptions.ServiceVersion serviceVersion)
        : base(async, serviceVersion)
        {
        }

        protected override async Task CreateBlobClientAsync(
            BlobContainerClient container, string blobName, Stream contents, CancellationToken cancellationToken = default)
        {
            PageBlobClient pageBlobClient = container.GetPageBlobClient(blobName);
            await pageBlobClient.CreateAsync(512 * 10);
            if (contents != default)
            {
                if (contents.Length == 0 || contents.Length % 512 != 0)
                {
                    // cannot upload a page that has a Content-Length of 0 or not a multiple of 512
                    int newLength = ((int)contents.Length / 512 + 1) * 512;
                    contents = new MemoryStream(GetRandomBuffer(newLength));
                }
                await pageBlobClient.UploadPagesAsync(contents, 0, cancellationToken: cancellationToken);
            }
        }

        protected override BlobType GetBlobType()
            => BlobType.Page;
    }
}
