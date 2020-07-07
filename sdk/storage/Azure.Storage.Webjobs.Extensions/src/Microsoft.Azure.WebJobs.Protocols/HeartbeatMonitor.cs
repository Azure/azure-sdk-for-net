// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Storage;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Protocols
{
    /// <summary>Represents a monitor for running host heartbeats.</summary>
    public class HeartbeatMonitor : IHeartbeatMonitor
    {
        private readonly CloudBlobClient _client;

        /// <summary>Initializes a new instance of the <see cref="HeartbeatMonitor"/> class.</summary>
        /// <param name="client">A blob client for the storage account in which to monitor heartbeats.</param>
        public HeartbeatMonitor(CloudBlobClient client)
        {
            _client = client;
        }

        /// <inheritdoc />
        public async Task<DateTimeOffset?> GetSharedHeartbeatExpirationAsync(string sharedContainerName, string sharedDirectoryName,
            int expirationInSeconds)
        {
            CloudBlobContainer container = _client.GetContainerReference(sharedContainerName);
            CloudBlobDirectory directory = container.GetDirectoryReference(sharedDirectoryName);
            BlobContinuationToken currentToken = null;
            DateTimeOffset? heartbeatExpiration;

            do
            {
                BlobResultSegment segment = await GetNextHeartbeatsAsync(directory, currentToken);

                if (segment == null)
                {
                    return DateTime.MinValue;
                }

                currentToken = segment.ContinuationToken;
                heartbeatExpiration = await GetFirstValidHeartbeatExpirationAsync(segment.Results, expirationInSeconds);
            } while (heartbeatExpiration == null && currentToken != null);

            return heartbeatExpiration;
        }

        private async Task<BlobResultSegment> GetNextHeartbeatsAsync(CloudBlobDirectory directory, BlobContinuationToken currentToken)
        {
            const int batchSize = 100;

            try
            {
                return await directory.ListBlobsSegmentedAsync(useFlatBlobListing: true,
                    blobListingDetails: BlobListingDetails.None,
                    maxResults: batchSize,
                    currentToken: currentToken,
                    options: null,
                    operationContext: null);
            }
            catch (StorageException exception)
            {
                if (exception.IsNotFound())
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        private static async Task<DateTimeOffset?> GetFirstValidHeartbeatExpirationAsync(IEnumerable<IListBlobItem> heartbeats,
            int expirationInSeconds)
        {
            // We're using the flat blob listing, so the more specific ICloudBlob type here is guaranteed.
            foreach (ICloudBlob blob in heartbeats)
            {
                DateTimeOffset expiration = GetHeartbeatExpiration(blob, expirationInSeconds);

                if (IsUnexpired(expiration))
                {
                    return expiration;
                }
                else
                {
                    // Remove any expired heartbeats so that we can answer more efficiently in the future.
                    // If the host instance wakes back up, it will just re-create the heartbeat anyway.
                    await blob.DeleteIfExistsAsync();
                }
            }

            return null;
        }

        /// <inheritdoc />
        public async Task<DateTimeOffset?> GetInstanceHeartbeatExpirationAsync(string sharedContainerName, string sharedDirectoryName,
            string instanceBlobName, int expirationInSeconds)
        {
            CloudBlobContainer container = _client.GetContainerReference(sharedContainerName);
            CloudBlobDirectory directory = container.GetDirectoryReference(sharedDirectoryName);
            ICloudBlob blob = directory.GetBlockBlobReference(instanceBlobName);

            try
            {
                await blob.FetchAttributesAsync();
            }
            catch (StorageException exception)
            {
                if (exception.IsNotFound())
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            DateTimeOffset expiration = GetHeartbeatExpiration(blob, expirationInSeconds);

            if (IsUnexpired(expiration))
            {
                return expiration;
            }
            else
            {
                // Remove any expired heartbeats so that we can answer more efficiently in the future.
                // If the host instance wakes back up, it will just re-create the heartbeat anyway.
                await blob.DeleteIfExistsAsync();
                return null;
            }
        }

        private static DateTimeOffset GetHeartbeatExpiration(ICloudBlob heartbeatBlob, int expirationInSeconds)
        {
            // There always should be a value at this point, but defaulting to MinValue just to be safe...
            DateTimeOffset heartbeat = heartbeatBlob.Properties.LastModified.GetValueOrDefault(DateTimeOffset.MinValue);
            return heartbeat.AddSeconds(expirationInSeconds);
        }

        private static bool IsUnexpired(DateTimeOffset heartbeatExpiration)
        {
            return heartbeatExpiration.UtcDateTime > DateTimeOffset.UtcNow.UtcDateTime;
        }
    }
}
