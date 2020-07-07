// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs.Extensions.Storage;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal class BlobReceiptManager : IBlobReceiptManager
    {
        private static readonly TimeSpan LeasePeriod = TimeSpan.FromSeconds(30);

        private readonly CloudBlobDirectory _directory;

        public BlobReceiptManager(CloudBlobClient client)
            : this(client.GetContainerReference(HostContainerNames.Hosts)
                .GetDirectoryReference(HostDirectoryNames.BlobReceipts))
        {
        }

        private BlobReceiptManager(CloudBlobDirectory directory)
        {
            _directory = directory;
        }

        public CloudBlockBlob CreateReference(string hostId, string functionId, string containerName,
            string blobName, string eTag)
        {
            // Put the ETag before the blob name to prevent ambiguity since the blob name can contain embedded slashes.
            string receiptName = String.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}/{3}/{4}", hostId, functionId,
                eTag, containerName, blobName);
            return _directory.SafeGetBlockBlobReference(receiptName);
        }

        public async Task<BlobReceipt> TryReadAsync(CloudBlockBlob blob, CancellationToken cancellationToken)
        {
            if (!await blob.TryFetchAttributesAsync(cancellationToken))
            {
                return null;
            }

            return BlobReceipt.FromMetadata(blob.Metadata);
        }

        public async Task<bool> TryCreateAsync(CloudBlockBlob blob, CancellationToken cancellationToken)
        {
            BlobReceipt.Incomplete.ToMetadata(blob.Metadata);
            AccessCondition accessCondition = new AccessCondition { IfNoneMatchETag = "*" };
            bool isContainerNotFoundException = false;

            try
            {
                await blob.UploadTextAsync(String.Empty,
                    encoding: null,
                    accessCondition: accessCondition,
                    options: null,
                    operationContext: null,
                    cancellationToken: cancellationToken);
                return true;
            }
            catch (StorageException exception)
            {
                if (exception.IsNotFoundContainerNotFound())
                {
                    isContainerNotFoundException = true;
                }
                else if (exception.IsConflictBlobAlreadyExists())
                {
                    return false;
                }
                else if (exception.IsPreconditionFailedLeaseIdMissing())
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            Debug.Assert(isContainerNotFoundException);
            await blob.Container.CreateIfNotExistsAsync(cancellationToken);

            try
            {
                await blob.UploadTextAsync(String.Empty,
                    encoding: null,
                    accessCondition: accessCondition,
                    options: null,
                    operationContext: null,
                    cancellationToken: cancellationToken);
                return true;
            }
            catch (StorageException exception)
            {
                if (exception.IsConflictBlobAlreadyExists())
                {
                    return false;
                }
                else if (exception.IsPreconditionFailedLeaseIdMissing())
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<string> TryAcquireLeaseAsync(CloudBlockBlob blob, CancellationToken cancellationToken)
        {
            try
            {
                return await blob.AcquireLeaseAsync(LeasePeriod, null, cancellationToken);
            }
            catch (StorageException exception)
            {
                if (exception.IsConflictLeaseAlreadyPresent())
                {
                    return null;
                }
                else if (exception.IsNotFoundBlobOrContainerNotFound())
                {
                    // If someone deleted the receipt, there's no lease to acquire.
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task MarkCompletedAsync(CloudBlockBlob blob, string leaseId,
            CancellationToken cancellationToken)
        {
            BlobReceipt.Complete.ToMetadata(blob.Metadata);

            try
            {
                await blob.SetMetadataAsync(
                    accessCondition: new AccessCondition { LeaseId = leaseId },
                    options: null,
                    operationContext: null,
                    cancellationToken: cancellationToken);
            }
            catch (StorageException exception)
            {
                if (exception.IsNotFoundBlobOrContainerNotFound())
                {
                    // The user deleted the receipt or its container; nothing to mark complete at this point.
                }
                else if (exception.IsPreconditionFailedLeaseLost())
                {
                    // The lease expired; don't try to mark complete at this point.
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task ReleaseLeaseAsync(CloudBlockBlob blob, string leaseId, CancellationToken cancellationToken)
        {
            try
            {
                // Note that this call returns without throwing if the lease is expired. See the table at:
                // http://msdn.microsoft.com/en-us/library/azure/ee691972.aspx
                await blob.ReleaseLeaseAsync(
                    accessCondition: new AccessCondition { LeaseId = leaseId },
                    options: null,
                    operationContext: null,
                    cancellationToken: cancellationToken);
            }
            catch (StorageException exception)
            {
                if (exception.IsNotFoundBlobOrContainerNotFound())
                {
                    // The user deleted the receipt or its container; nothing to release at this point.
                }
                else if (exception.IsConflictLeaseIdMismatchWithLeaseOperation())
                {
                    // Another lease is active; nothing for this lease to release at this point.
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
