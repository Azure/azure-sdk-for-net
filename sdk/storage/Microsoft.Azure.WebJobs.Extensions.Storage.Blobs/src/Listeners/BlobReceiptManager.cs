// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Classifiers;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using BlobRequestConditions = Azure.Storage.Blobs.Models.BlobRequestConditions;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal class BlobReceiptManager : IBlobReceiptManager
    {
        private static readonly TimeSpan LeasePeriod = TimeSpan.FromSeconds(30);
        private readonly BlobContainerClient _blobContainerClient;

        public BlobReceiptManager(BlobServiceClient client)
        {
            this._blobContainerClient = client.GetBlobContainerClient(HostContainerNames.Hosts);
        }

        public BlockBlobClient CreateReference(string hostId, string functionId, string containerName,
            string blobName, string eTag)
        {
            // Put the ETag before the blob name to prevent ambiguity since the blob name can contain embedded slashes.
            string receiptName = String.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}/{3}/{4}", hostId, functionId,
                eTag, containerName, blobName);
            return _blobContainerClient.SafeGetBlockBlobReference(HostDirectoryNames.BlobReceipts, receiptName);
        }

        public async Task<BlobReceipt> TryReadAsync(BlockBlobClient blob, CancellationToken cancellationToken)
        {
            var properties = await blob.FetchPropertiesOrNullIfNotExistAsync(cancellationToken).ConfigureAwait(false);
            if (properties == null)
            {
                return null;
            }

            return BlobReceipt.FromMetadata(properties.Metadata);
        }

        public async Task<bool> TryCreateAsync(BlockBlobClient blob, CancellationToken cancellationToken)
        {
            Dictionary<string, string> metadata = new Dictionary<string, string>();
            BlobReceipt.Incomplete.ToMetadata(metadata);
            BlobRequestConditions accessCondition = new BlobRequestConditions { IfNoneMatch = new ETag("*") };
            bool isContainerNotFoundException = false;

            try
            {
                await blob.UploadAsync(
                    new MemoryStream(),
                    new BlobUploadOptions()
                    {
                        Conditions = accessCondition,
                        Metadata = metadata,
                    },
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
                return true;
            }
            catch (RequestFailedException exception)
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
            await _blobContainerClient.CreateIfNotExistsAsync(cancellationToken: cancellationToken).ConfigureAwait(false);

            try
            {
                await blob.UploadAsync(
                    new MemoryStream(),
                    new BlobUploadOptions()
                    {
                        Conditions = accessCondition,
                        Metadata = metadata,
                    },
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
                return true;
            }
            catch (RequestFailedException exception)
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

        public async Task<string> TryAcquireLeaseAsync(BlockBlobClient blob, CancellationToken cancellationToken)
        {
            var context = new RequestContext()
            {
                CancellationToken = cancellationToken
            };
            context.AddClassifier(LeaseAlreadyPresentResponseClassificationHandler.GetClassifier(classifyAsError: false));

            try
            {
                Response response = await blob.GetBlobLeaseClient().AcquireAsync(
                    LeasePeriod,
                    conditions: null,
                    context)
                    .ConfigureAwait(false);

                return response.Headers.TryGetValue("x-ms-lease-id", out string leaseId) ? leaseId : null;
            }
            catch (RequestFailedException exception) when (exception.IsNotFoundBlobOrContainerNotFound())
            {
                // If someone deleted the receipt, there's no lease to acquire.
                return null;
            }
        }

        public async Task MarkCompletedAsync(BlockBlobClient blob, string leaseId,
            CancellationToken cancellationToken)
        {
            var metadata = (await blob.GetPropertiesAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Metadata;
            BlobReceipt.Complete.ToMetadata(metadata);

            try
            {
                await blob.SetMetadataAsync(
                        metadata,
                        new BlobRequestConditions()
                        {
                            LeaseId = leaseId,
                        },
                        cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (RequestFailedException exception)
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

        public async Task ReleaseLeaseAsync(BlockBlobClient blob, string leaseId, CancellationToken cancellationToken)
        {
            try
            {
                // Note that this call returns without throwing if the lease is expired. See the table at:
                // http://msdn.microsoft.com/en-us/library/azure/ee691972.aspx
                await blob.GetBlobLeaseClient(leaseId).ReleaseAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException exception)
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
