// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs.Primitives;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using Newtonsoft.Json;

    class AzureStorageCheckpointLeaseManager : ICheckpointManager, ILeaseManager
    {
        static string MetaDataOwnerName = "OWNINGHOST";

        EventProcessorHost host;
        TimeSpan leaseDuration;
        TimeSpan leaseRenewInterval;

        static readonly TimeSpan storageMaximumExecutionTime = TimeSpan.FromMinutes(2);
        readonly CloudStorageAccount cloudStorageAccount;
        readonly string leaseContainerName;
        readonly string storageBlobPrefix;
        BlobRequestOptions defaultRequestOptions;
        OperationContext operationContext = null;
        CloudBlobContainer eventHubContainer;
        CloudBlobDirectory consumerGroupDirectory;

        internal AzureStorageCheckpointLeaseManager(string storageConnectionString, string leaseContainerName, string storageBlobPrefix)
            : this(CloudStorageAccount.Parse(storageConnectionString), leaseContainerName, storageBlobPrefix)
        {
        }

        internal AzureStorageCheckpointLeaseManager(CloudStorageAccount cloudStorageAccount, string leaseContainerName, string storageBlobPrefix)
        {
            Guard.ArgumentNotNull(nameof(cloudStorageAccount), cloudStorageAccount);

            try
            {
                NameValidator.ValidateContainerName(leaseContainerName);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException(
                    "Azure Storage lease container name is invalid. Please check naming conventions at https://msdn.microsoft.com/en-us/library/azure/dd135715.aspx",
                    nameof(leaseContainerName));
            }

            this.cloudStorageAccount = cloudStorageAccount;
            this.leaseContainerName = leaseContainerName;

            // Convert all-whitespace prefix to empty string. Convert null prefix to empty string.
            // Then the rest of the code only has one case to worry about.
            this.storageBlobPrefix = (storageBlobPrefix != null) ? storageBlobPrefix.Trim() : "";
        }

        // The EventProcessorHost can't pass itself to the AzureStorageCheckpointLeaseManager constructor
        // because it is still being constructed. Do other initialization here also because it might throw and
        // hence we don't want it in the constructor.
        internal void Initialize(EventProcessorHost host)
        {
            this.host = host;

            // Assign partition manager options.
            this.leaseDuration = host.PartitionManagerOptions.LeaseDuration;
            this.leaseRenewInterval = host.PartitionManagerOptions.RenewInterval;

            // Create storage default request options.
            this.defaultRequestOptions = new BlobRequestOptions()
            {
                // Gets or sets the server timeout interval for a single HTTP request.
                ServerTimeout = TimeSpan.FromSeconds(this.LeaseRenewInterval.TotalSeconds / 2),

                // Gets or sets the maximum execution time across all potential retries for the request.
                MaximumExecutionTime = TimeSpan.FromSeconds(this.LeaseRenewInterval.TotalSeconds)
            };

#if FullNetFx
            // Proxy enabled?
            if (this.host.EventProcessorOptions != null && this.host.EventProcessorOptions.WebProxy != null)
            {
                this.operationContext = new OperationContext
                {
                    Proxy = this.host.EventProcessorOptions.WebProxy
                };
            }
#endif

            // Create storage client and configure max execution time.
            // Max execution time will apply to any storage call unless otherwise specified by custom request options.
            var storageClient = this.cloudStorageAccount.CreateCloudBlobClient();
            storageClient.DefaultRequestOptions = new BlobRequestOptions
            {
                MaximumExecutionTime = AzureStorageCheckpointLeaseManager.storageMaximumExecutionTime
            };

            this.eventHubContainer = storageClient.GetContainerReference(this.leaseContainerName);
            this.consumerGroupDirectory = this.eventHubContainer.GetDirectoryReference(this.storageBlobPrefix + this.host.ConsumerGroupName);
        }

        //
        // In this implementation, checkpoints are data that's actually in the lease blob, so checkpoint operations
        // turn into lease operations under the covers.
        //
        public Task<bool> CheckpointStoreExistsAsync()
        {
            return LeaseStoreExistsAsync();
        }

        public Task<bool> CreateCheckpointStoreIfNotExistsAsync()
        {
            // Because we control the caller, we know that this method will only be called after createLeaseStoreIfNotExists.
            // In this implementation, it's the same store, so the store will always exist if execution reaches here.
            return Task.FromResult(true);
        }

        public async Task<Checkpoint> GetCheckpointAsync(string partitionId)
        {
            AzureBlobLease lease = (AzureBlobLease)await GetLeaseAsync(partitionId).ConfigureAwait(false);
            Checkpoint checkpoint = null;
            if (lease != null && !string.IsNullOrEmpty(lease.Offset))
            {
                checkpoint = new Checkpoint(partitionId)
                {
                    Offset = lease.Offset,
                    SequenceNumber = lease.SequenceNumber
                };
            }

            return checkpoint;
        }

        public Task<Checkpoint> CreateCheckpointIfNotExistsAsync(string partitionId)
        {
            // Normally the lease will already be created, checkpoint store is initialized after lease store.
            return Task.FromResult<Checkpoint>(null);
        }

        public async Task UpdateCheckpointAsync(Lease lease, Checkpoint checkpoint)
        {
            AzureBlobLease newLease = new AzureBlobLease((AzureBlobLease) lease)
            {
                Offset = checkpoint.Offset,
                SequenceNumber = checkpoint.SequenceNumber
            };

            await this.UpdateLeaseAsync(newLease).ConfigureAwait(false);
        }

        public Task DeleteCheckpointAsync(string partitionId)
        {
            // Make this a no-op to avoid deleting leases by accident.
            return Task.FromResult(0);
        }

        //
        // Lease operations.
        //
        public TimeSpan LeaseRenewInterval => this.leaseRenewInterval;

        public TimeSpan LeaseDuration => this.leaseDuration;

        public Task<bool> LeaseStoreExistsAsync()
        {
            return this.eventHubContainer.ExistsAsync(null, this.operationContext);
        }

        public Task<bool> CreateLeaseStoreIfNotExistsAsync()
        {
            return this.eventHubContainer.CreateIfNotExistsAsync(null, this.operationContext);
        }

        public async Task<bool> DeleteLeaseStoreAsync()
        {
            bool retval = true;

            BlobContinuationToken outerContinuationToken = null;
            do
            {
                BlobResultSegment outerResultSegment = await this.eventHubContainer.ListBlobsSegmentedAsync(outerContinuationToken).ConfigureAwait(false);
                outerContinuationToken = outerResultSegment.ContinuationToken;
                foreach (IListBlobItem blob in outerResultSegment.Results)
                {
                    if (blob is CloudBlobDirectory)
                    {
                        BlobContinuationToken innerContinuationToken = null;
                        do
                        {
                            BlobResultSegment innerResultSegment = await ((CloudBlobDirectory)blob).ListBlobsSegmentedAsync(innerContinuationToken).ConfigureAwait(false);
                            innerContinuationToken = innerResultSegment.ContinuationToken;
                            foreach (IListBlobItem subBlob in innerResultSegment.Results)
                            {
                                try
                                {
                                    await ((CloudBlockBlob)subBlob).DeleteIfExistsAsync().ConfigureAwait(false);
                                }
                                catch (StorageException e)
                                {
                                    ProcessorEventSource.Log.AzureStorageManagerWarning(this.host.HostName, "N/A", "Failure while deleting lease store:", e.ToString());
                                    retval = false;
                                }
                            }
                        }
                        while (innerContinuationToken != null);
                    }
                    else if (blob is CloudBlockBlob)
                    {
                        try
                        {
                            await ((CloudBlockBlob)blob).DeleteIfExistsAsync().ConfigureAwait(false);
                        }
                        catch (StorageException e)
                        {
                            ProcessorEventSource.Log.AzureStorageManagerWarning(this.host.HostName, "N/A", "Failure while deleting lease store:", e.ToString());
                            retval = false;
                        }
                    }
                }
            }
            while (outerContinuationToken != null);

            return retval;
        }

        public async Task<Lease> GetLeaseAsync(string partitionId) // throws URISyntaxException, IOException, StorageException
        {
            CloudBlockBlob leaseBlob = GetBlockBlobReference(partitionId);

            await leaseBlob.FetchAttributesAsync(null, defaultRequestOptions, this.operationContext).ConfigureAwait(false);

            return await DownloadLeaseAsync(partitionId, leaseBlob).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Lease>> GetAllLeasesAsync()
        {
            var leaseList = new List<Lease>();
            BlobContinuationToken continuationToken = null;

            do
            {
                var listBlobsTask = this.consumerGroupDirectory.ListBlobsSegmentedAsync(
                    true,
                    BlobListingDetails.Metadata,
                    null,
                    continuationToken,
                    this.defaultRequestOptions,
                    this.operationContext);

                // ListBlobsSegmentedAsync honors neither timeout settings in request options nor cancellation token and thus intermittently hangs.
                // This provides a workaround until we have storage.blob library fixed.
                BlobResultSegment leaseBlobsResult;
                using (var cts = new CancellationTokenSource())
                {
                    var delayTask = Task.Delay(this.LeaseRenewInterval, cts.Token);
                    var completedTask = await Task.WhenAny(listBlobsTask, delayTask).ConfigureAwait(false);

                    if (completedTask == listBlobsTask)
                    {
                        cts.Cancel();
                        leaseBlobsResult = await listBlobsTask;
                    }
                    else
                    {
                        // Throw OperationCanceledException, caller will log the failures appropriately.
                        throw new OperationCanceledException();
                    }
                }

                foreach (CloudBlockBlob leaseBlob in leaseBlobsResult.Results)
                {
                    // Try getting owner name from existing blob.
                    // This might return null when run on the existing lease after SDK upgrade.
                    leaseBlob.Metadata.TryGetValue(MetaDataOwnerName, out var owner);

                    // Discover partition id from URI path of the blob.
                    var partitionId = leaseBlob.Uri.AbsolutePath.Split('/').Last();

                    leaseList.Add(new AzureBlobLease(partitionId, owner, leaseBlob));
                }

                continuationToken = leaseBlobsResult.ContinuationToken;

            } while (continuationToken != null);

            return leaseList;
        }

        public async Task<Lease> CreateLeaseIfNotExistsAsync(string partitionId) // throws URISyntaxException, IOException, StorageException
        {
            AzureBlobLease returnLease;
            try
            {
                CloudBlockBlob leaseBlob = GetBlockBlobReference(partitionId);
                returnLease = new AzureBlobLease(partitionId, leaseBlob);
                string jsonLease = JsonConvert.SerializeObject(returnLease);

                ProcessorEventSource.Log.AzureStorageManagerInfo(
                    this.host.HostName,
                    partitionId,
                    "CreateLeaseIfNotExist - leaseContainerName: " + this.leaseContainerName +
                    " consumerGroupName: " + this.host.ConsumerGroupName + " storageBlobPrefix: " + this.storageBlobPrefix);

                // Don't provide default request options for upload call.
                // This request will respect client's default options.
                await leaseBlob.UploadTextAsync(
                    jsonLease,
                    null,
                    AccessCondition.GenerateIfNoneMatchCondition("*"),
                    null,
                    this.operationContext).ConfigureAwait(false);
            }
            catch (StorageException se)
            {
                if (se.RequestInformation.ErrorCode == BlobErrorCodeStrings.BlobAlreadyExists ||
                     se.RequestInformation.ErrorCode == BlobErrorCodeStrings.LeaseIdMissing) // occurs when somebody else already has leased the blob
                {
                    // The blob already exists.
                    ProcessorEventSource.Log.AzureStorageManagerInfo(this.host.HostName, partitionId, "Lease already exists");
                    returnLease = (AzureBlobLease)await GetLeaseAsync(partitionId).ConfigureAwait(false);
                }
                else
                {
                    ProcessorEventSource.Log.AzureStorageManagerError(
                        this.host.HostName,
                        partitionId,
                        "CreateLeaseIfNotExist StorageException - leaseContainerName: " + this.leaseContainerName +
                        " consumerGroupName: " + this.host.ConsumerGroupName + " storageBlobPrefix: " + this.storageBlobPrefix,
                        se.ToString());
                    throw;
                }
            }

            return returnLease;
        }

        public Task DeleteLeaseAsync(Lease lease)
        {
            var azureBlobLease = (AzureBlobLease)lease;
            ProcessorEventSource.Log.AzureStorageManagerInfo(this.host.HostName, azureBlobLease.PartitionId, "Deleting lease");
            return azureBlobLease.Blob.DeleteIfExistsAsync();
        }

        public Task<bool> AcquireLeaseAsync(Lease lease)
        {
            return AcquireLeaseCoreAsync((AzureBlobLease)lease);
        }

        async Task<bool> AcquireLeaseCoreAsync(AzureBlobLease lease)
        {
            CloudBlockBlob leaseBlob = lease.Blob;
            bool retval = true;
            string newLeaseId = Guid.NewGuid().ToString();
            string partitionId = lease.PartitionId;
            try
            {
                bool renewLease = false;
                string newToken;

                await leaseBlob.FetchAttributesAsync(null, this.defaultRequestOptions, this.operationContext).ConfigureAwait(false);

                if (leaseBlob.Properties.LeaseState == LeaseState.Leased)
                {
                    if (string.IsNullOrEmpty(lease.Token))
                    {
                        // We reach here in a race condition: when this instance of EventProcessorHost scanned the
                        // lease blobs, this partition was unowned (token is empty) but between then and now, another
                        // instance of EPH has established a lease (getLeaseState() is LEASED). We normally enforce
                        // that we only steal the lease if it is still owned by the instance which owned it when we
                        // scanned, but we can't do that when we don't know who owns it. The safest thing to do is just
                        // fail the acquisition. If that means that one EPH instance gets more partitions than it should,
                        // rebalancing will take care of that quickly enough.
                        return false;
                    }

                    ProcessorEventSource.Log.AzureStorageManagerInfo(this.host.HostName, lease.PartitionId, "Need to ChangeLease");
                    renewLease = true;
                    newToken = await leaseBlob.ChangeLeaseAsync(
                        newLeaseId,
                        AccessCondition.GenerateLeaseCondition(lease.Token),
                        this.defaultRequestOptions,
                        this.operationContext).ConfigureAwait(false);
                }
                else
                {
                    ProcessorEventSource.Log.AzureStorageManagerInfo(this.host.HostName, lease.PartitionId, "Need to AcquireLease");
                    newToken = await leaseBlob.AcquireLeaseAsync(
                        leaseDuration,
                        newLeaseId,
                        null,
                        this.defaultRequestOptions,
                        this.operationContext).ConfigureAwait(false);
                }

                lease.Token = newToken;
                lease.Owner = this.host.HostName;
                lease.IncrementEpoch(); // Increment epoch each time lease is acquired or stolen by a new host

                // Renew lease here if needed?
                // ChangeLease doesn't renew so we should avoid lease expiring before next renew interval.
                if (renewLease)
                {
                    await this.RenewLeaseCoreAsync(lease).ConfigureAwait(false);
                }

                // Update owner in the metadata first since clients get ownership information by looking at metadata.
                lease.Blob.Metadata[MetaDataOwnerName] = lease.Owner;
                await lease.Blob.SetMetadataAsync(
                    AccessCondition.GenerateLeaseCondition(lease.Token),
                    this.defaultRequestOptions,
                    this.operationContext).ConfigureAwait(false);

                // Then update deserialized lease content.
                await leaseBlob.UploadTextAsync(
                    JsonConvert.SerializeObject(lease),
                    null,
                    AccessCondition.GenerateLeaseCondition(lease.Token),
                    this.defaultRequestOptions,
                    this.operationContext).ConfigureAwait(false);
            }
            catch (StorageException se)
            {
                throw HandleStorageException(partitionId, se);
            }

            return retval;
        }

        public Task<bool> RenewLeaseAsync(Lease lease)
        {
            return RenewLeaseCoreAsync((AzureBlobLease)lease);
        }

        async Task<bool> RenewLeaseCoreAsync(AzureBlobLease lease)
        {
            CloudBlockBlob leaseBlob = lease.Blob;
            string partitionId = lease.PartitionId;

            try
            {
                await leaseBlob.RenewLeaseAsync(
                    AccessCondition.GenerateLeaseCondition(lease.Token),
                    this.defaultRequestOptions,
                    this.operationContext).ConfigureAwait(false);
            }
            catch (StorageException se)
            {
                throw HandleStorageException(partitionId, se);
            }

            return true;
        }

        public Task<bool> ReleaseLeaseAsync(Lease lease)
        {
            return ReleaseLeaseCoreAsync((AzureBlobLease)lease);
        }

        async Task<bool> ReleaseLeaseCoreAsync(AzureBlobLease lease)
        {
            ProcessorEventSource.Log.AzureStorageManagerInfo(this.host.HostName, lease.PartitionId, "Releasing lease");

            CloudBlockBlob leaseBlob = lease.Blob;
            string partitionId = lease.PartitionId;

            try
            {
                string leaseId = lease.Token;
                AzureBlobLease releasedCopy = new AzureBlobLease(lease)
                {
                    Token = string.Empty,
                    Owner = string.Empty
                };

                // Remove owner in the metadata.
                leaseBlob.Metadata.Remove(MetaDataOwnerName);

                await leaseBlob.SetMetadataAsync(
                    AccessCondition.GenerateLeaseCondition(leaseId),
                    this.defaultRequestOptions,
                    this.operationContext).ConfigureAwait(false);

                await leaseBlob.UploadTextAsync(
                    JsonConvert.SerializeObject(releasedCopy),
                    null,
                    AccessCondition.GenerateLeaseCondition(leaseId),
                    this.defaultRequestOptions,
                    this.operationContext).ConfigureAwait(false);

                await leaseBlob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId), this.defaultRequestOptions, this.operationContext).ConfigureAwait(false);
            }
            catch (StorageException se)
            {
                throw HandleStorageException(partitionId, se);
            }

            return true;
        }

        public Task<bool> UpdateLeaseAsync(Lease lease)
        {
            return UpdateLeaseCoreAsync((AzureBlobLease)lease);
        }

        async Task<bool> UpdateLeaseCoreAsync(AzureBlobLease lease)
        {
            if (lease == null)
            {
                return false;
            }

            string partitionId = lease.PartitionId;
            ProcessorEventSource.Log.AzureStorageManagerInfo(this.host.HostName, partitionId, "Updating lease");

            string token = lease.Token;
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }

            CloudBlockBlob leaseBlob = lease.Blob;
            try
            {
                string jsonToUpload = JsonConvert.SerializeObject(lease);
                ProcessorEventSource.Log.AzureStorageManagerInfo(this.host.HostName, lease.PartitionId, $"Raw JSON uploading: {jsonToUpload}");

                // This is on the code path of checkpoint call thus don't provide default request options for upload call.
                // This request will respect client's default options.
                await leaseBlob.UploadTextAsync(
                    jsonToUpload,
                    null,
                    AccessCondition.GenerateLeaseCondition(token),
                    null,
                    this.operationContext).ConfigureAwait(false);
            }
            catch (StorageException se)
            {
                throw HandleStorageException(partitionId, se);
            }

            return true;
        }

        async Task<Lease> DownloadLeaseAsync(string partitionId, CloudBlockBlob blob) // throws StorageException, IOException
        {
            string jsonLease = await blob.DownloadTextAsync(null, null, this.defaultRequestOptions, this.operationContext).ConfigureAwait(false);

            ProcessorEventSource.Log.AzureStorageManagerInfo(this.host.HostName, partitionId, "Raw JSON downloaded: " + jsonLease);
            AzureBlobLease rehydrated = (AzureBlobLease)JsonConvert.DeserializeObject(jsonLease, typeof(AzureBlobLease));
            AzureBlobLease blobLease = new AzureBlobLease(rehydrated, blob);

            return blobLease;
        }

        Exception HandleStorageException(string partitionId, StorageException se)
        {
            ProcessorEventSource.Log.AzureStorageManagerInfo(this.host.HostName, partitionId, "HandleStorageException - HttpStatusCode " + se.RequestInformation.HttpStatusCode);
            if (se.RequestInformation.HttpStatusCode == 409 || // conflict
                se.RequestInformation.HttpStatusCode == 412) // precondition failed
            {
                ProcessorEventSource.Log.AzureStorageManagerInfo(this.host.HostName, partitionId,
                    "HandleStorageException - Error code: " + se.RequestInformation.ErrorCode);
                ProcessorEventSource.Log.AzureStorageManagerInfo(this.host.HostName, partitionId,
                    "HandleStorageException - Error message: " + se.RequestInformation.ExtendedErrorInformation?.ErrorMessage);

                if (se.RequestInformation.ErrorCode == null ||
                    se.RequestInformation.ErrorCode == BlobErrorCodeStrings.LeaseLost ||
                    se.RequestInformation.ErrorCode == BlobErrorCodeStrings.LeaseIdMismatchWithLeaseOperation ||
                    se.RequestInformation.ErrorCode == BlobErrorCodeStrings.LeaseIdMismatchWithBlobOperation)
                {
                    return new LeaseLostException(partitionId, se);
                }
            }

            return se;
        }

        CloudBlockBlob GetBlockBlobReference(string partitionId)
        {
            return this.consumerGroupDirectory.GetBlockBlobReference(partitionId);
        }
    }
}