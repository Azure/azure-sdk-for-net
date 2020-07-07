// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Storage.Blob;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal interface IBlobReceiptManager
    {
        CloudBlockBlob CreateReference(string hostId, string functionId, string containerName, string blobName,
            string eTag);

        Task<BlobReceipt> TryReadAsync(CloudBlockBlob blob, CancellationToken cancellationToken);

        Task<bool> TryCreateAsync(CloudBlockBlob blob, CancellationToken cancellationToken);

        Task<string> TryAcquireLeaseAsync(CloudBlockBlob blob, CancellationToken cancellationToken);

        Task MarkCompletedAsync(CloudBlockBlob blob, string leaseId, CancellationToken cancellationToken);

        Task ReleaseLeaseAsync(CloudBlockBlob blob, string leaseId, CancellationToken cancellationToken);
    }
}
