// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal interface IBlobReceiptManager
    {
        BlockBlobClient CreateReference(string hostId, string functionId, string containerName, string blobName,
            string eTag);

        Task<BlobReceipt> TryReadAsync(BlockBlobClient blob, CancellationToken cancellationToken);

        Task<bool> TryCreateAsync(BlockBlobClient blob, CancellationToken cancellationToken);

        Task<string> TryAcquireLeaseAsync(BlockBlobClient blob, CancellationToken cancellationToken);

        Task MarkCompletedAsync(BlockBlobClient blob, string leaseId, CancellationToken cancellationToken);

        Task ReleaseLeaseAsync(BlockBlobClient blob, string leaseId, CancellationToken cancellationToken);
    }
}
