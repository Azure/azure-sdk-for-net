// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core.Http;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.Messaging.EventHubs.CheckpointStore.Blob
{
    /// <summary>
    ///   A storage blob service that keeps track of checkpoints and ownership.
    /// </summary>
    ///
    public sealed class BlobPartitionManager : PartitionManager
    {
        /// <summary>The client used to interact with the Azure Blob Storage service.</summary>
        private readonly BlobContainerClient ContainerClient;

        /// <summary>Logs activities performed by this partition manager.</summary>
        private Action<string> Logger;

        /// <summary>
        ///   Initializes a new instance of the <see cref="BlobPartitionManager"/> class.
        /// </summary>
        ///
        /// <param name="blobContainerClient">The client used to interact with the Azure Blob Storage service.</param>
        /// <param name="logger">Logs activities performed by this partition manager.</param>
        ///
        public BlobPartitionManager(BlobContainerClient blobContainerClient,
                                    Action<string> logger = null)
        {
            // TODO: instead of manually checking the instance, make use of the Guard class once it's available.

            ContainerClient = blobContainerClient ?? throw new ArgumentNullException(nameof(blobContainerClient));
            Logger = logger;
        }

        /// <summary>
        ///   Retrieves a complete ownership list from the storage blob service.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        ///
        /// <returns>An enumerable containing all the existing ownership for the associated Event Hub and consumer group.</returns>
        ///
        public override async Task<IEnumerable<PartitionOwnership>> ListOwnershipAsync(string eventHubName,
                                                                                       string consumerGroup)
        {
            List<PartitionOwnership> ownershipList = new List<PartitionOwnership>();

            var prefix = $"{ eventHubName }/{ consumerGroup }/";
            var options = new GetBlobsOptions
            {
                IncludeMetadata = true,
                Prefix = prefix
            };

            await foreach (var response in ContainerClient.GetBlobsAsync(options))
            {
                var blob = response.Value;

                // In case this key does not exist, ownerIdentifier is set to null.  This will force the PartitionOwnership constructor
                // to throw an exception.

                blob.Metadata.TryGetValue(BlobMetadataKey.OwnerIdentifier, out var ownerIdentifier);

                long? offset = null;
                long? sequenceNumber = null;

                if (blob.Metadata.TryGetValue(BlobMetadataKey.Offset, out var str) && Int64.TryParse(str, out var result))
                {
                    offset = result;
                }

                if (blob.Metadata.TryGetValue(BlobMetadataKey.SequenceNumber, out str) && Int64.TryParse(str, out result))
                {
                    sequenceNumber = result;
                }

                ownershipList.Add(new InnerPartitionOwnership(
                    eventHubName,
                    consumerGroup,
                    ownerIdentifier,
                    blob.Name.Substring(prefix.Length),
                    offset,
                    sequenceNumber,
                    blob.Properties.LastModified,
                    blob.Properties.ETag.ToString()
                ));
            }

            return ownershipList;
        }

        /// <summary>
        ///   Tries to claim a list of specified ownership.
        /// </summary>
        ///
        /// <param name="partitionOwnership">An enumerable containing all the ownership to claim.</param>
        ///
        /// <returns>An enumerable containing the successfully claimed ownership.</returns>
        ///
        public override async Task<IEnumerable<PartitionOwnership>> ClaimOwnershipAsync(IEnumerable<PartitionOwnership> partitionOwnership)
        {
            var claimedOwnership = new List<PartitionOwnership>();
            var metadata = new Dictionary<string, string>();

            foreach (var ownership in partitionOwnership)
            {
                metadata[BlobMetadataKey.OwnerIdentifier] = ownership.OwnerIdentifier;
                metadata[BlobMetadataKey.Offset] = ownership.Offset?.ToString() ?? String.Empty;
                metadata[BlobMetadataKey.SequenceNumber] = ownership.SequenceNumber?.ToString() ?? String.Empty;

                var blobAccessConditions = new BlobAccessConditions();

                var blobName = $"{ ownership.EventHubName }/{ ownership.ConsumerGroup }/{ ownership.PartitionId }";
                var blobClient = ContainerClient.GetBlobClient(blobName);

                try
                {
                    // Even though documentation states otherwise, we cannot use UploadAsync when the blob already exists in
                    // the current storage SDK.  For this reason, we are using the specified ETag as an indication of what
                    // method to use.

                    if (ownership.ETag == null)
                    {
                        blobAccessConditions.HttpAccessConditions = new HttpAccessConditions { IfNoneMatch = new ETag("*") };

                        Response<BlobContentInfo> response;

                        try
                        {
                            response = await blobClient.UploadAsync(new MemoryStream(new byte[0]), metadata: metadata, blobAccessConditions: blobAccessConditions);
                        }
                        catch (StorageRequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobAlreadyExists)
                        {
                            // A blob could have just been created by another Event Processor that claimed ownership of this
                            // partition.  In this case, there's no point in retrying because we don't have the correct ETag.

                            Log($"Ownership with partition id = '{ ownership.PartitionId }' is not claimable.");
                            continue;
                        }

                        ownership.LastModifiedTime = response.Value.LastModified;
                        ownership.ETag = response.Value.ETag.ToString();
                    }
                    else
                    {
                        blobAccessConditions.HttpAccessConditions = new HttpAccessConditions { IfMatch = new ETag(ownership.ETag) };

                        Response<BlobInfo> response;

                        try
                        {
                            response = await blobClient.SetMetadataAsync(metadata, blobAccessConditions);
                        }
                        catch (StorageRequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
                        {
                            // No ownership was found, which means the ETag should have been set to null in order to
                            // claim this ownership.  For this reason, we consider it a failure and don't try again.

                            Log($"Ownership with partition id = '{ ownership.PartitionId }' is not claimable.");
                            continue;
                        }

                        ownership.LastModifiedTime = response.Value.LastModified;
                        ownership.ETag = response.Value.ETag.ToString();
                    }

                    // Small workaround to retrieve the eTag.  The current storage SDK returns it enclosed in
                    // double quotes ('"ETAG_VALUE"' instead of 'ETAG_VALUE').

                    var match = Regex.Match(ownership.ETag, "\"(.*)\"");

                    if (match.Success)
                    {
                        ownership.ETag = match.Groups[1].ToString();
                    }

                    claimedOwnership.Add(ownership);

                    Log($"Ownership with partition id = '{ ownership.PartitionId }' claimed.");
                }
                catch (StorageRequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ConditionNotMet)
                {
                    Log($"Ownership with partition id = '{ ownership.PartitionId }' is not claimable.");
                }
            }

            return claimedOwnership;
        }

        /// <summary>
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the storage blob service.
        /// </summary>
        ///
        /// <param name="checkpoint">The checkpoint containing the information to be stored.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public override async Task UpdateCheckpointAsync(Checkpoint checkpoint)
        {
            var blobName = $"{ checkpoint.EventHubName }/{ checkpoint.ConsumerGroup }/{ checkpoint.PartitionId }";
            var blobClient = ContainerClient.GetBlobClient(blobName);

            BlobProperties currentBlob;

            try
            {
                currentBlob = (await blobClient.GetPropertiesAsync()).Value;
            }
            catch (StorageRequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
            {
                Log($"Checkpoint with partition id = '{ checkpoint.PartitionId }' could not be updated because no associated ownership was found.");
                return;
            }

            // In case this key does not exist, ownerIdentifier is set to null.  The OwnerIdentifier in Checkpoint cannot
            // be null as well, so we won't be able to update the associated ownership.

            currentBlob.Metadata.TryGetValue(BlobMetadataKey.OwnerIdentifier, out var ownerIdentifier);

            if (ownerIdentifier == checkpoint.OwnerIdentifier)
            {
                var metadata = new Dictionary<string, string>()
                {
                    { BlobMetadataKey.OwnerIdentifier, checkpoint.OwnerIdentifier },
                    { BlobMetadataKey.Offset, checkpoint.Offset.ToString() },
                    { BlobMetadataKey.SequenceNumber, checkpoint.SequenceNumber.ToString() }
                };

                var accessConditions = new BlobAccessConditions();
                accessConditions.HttpAccessConditions = new HttpAccessConditions { IfMatch = currentBlob.ETag };

                try
                {
                    await blobClient.SetMetadataAsync(metadata, accessConditions);

                    Log($"Checkpoint with partition id = '{ checkpoint.PartitionId }' updated.");
                }
                catch(StorageRequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ConditionNotMet)
                {
                    Log($"Checkpoint with partition id = '{ checkpoint.PartitionId }' could not be updated because eTag has changed.");
                }
            }
            else
            {
                Log($"Checkpoint with partition id = '{ checkpoint.PartitionId }' could not be updated because owner has changed.");
            }
        }

        /// <summary>
        ///   Sends a log message to the current logger, if provided by the user.
        /// </summary>
        ///
        /// <param name="message">The log message to send.</param>
        ///
        private void Log(string message) => Logger?.Invoke(message);

        /// <summary>
        ///   A workaround so we can create <see cref="PartitionOwnership"/> instances.
        ///   This class can be removed once the following issue has been closed: https://github.com/Azure/azure-sdk-for-net/issues/7585
        /// </summary>
        ///
        private class InnerPartitionOwnership : PartitionOwnership
        {
            /// <summary>
            ///   Initializes a new instance of the <see cref="InnerPartitionOwnership"/> class.
            /// </summary>
            ///
            /// <param name="eventHubName">The name of the specific Event Hub this partition ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
            /// <param name="consumerGroup">The name of the consumer group this partition ownership is associated with.</param>
            /// <param name="ownerIdentifier">The identifier of the associated <see cref="EventProcessor{T}" /> instance.</param>
            /// <param name="partitionId">The identifier of the Event Hub partition this partition ownership is associated with.</param>
            /// <param name="offset">The offset of the last <see cref="EventData" /> received by the associated partition processor.</param>
            /// <param name="sequenceNumber">The sequence number of the last <see cref="EventData" /> received by the associated partition processor.</param>
            /// <param name="lastModifiedTime">The date and time, in UTC, that the last update was made to this ownership.</param>
            /// <param name="eTag">The entity tag needed to update this ownership.</param>
            ///
            public InnerPartitionOwnership(string eventHubName,
                                           string consumerGroup,
                                           string ownerIdentifier,
                                           string partitionId,
                                           long? offset = null,
                                           long? sequenceNumber = null,
                                           DateTimeOffset? lastModifiedTime = null,
                                           string eTag = null) : base(eventHubName, consumerGroup, ownerIdentifier, partitionId, offset, sequenceNumber, lastModifiedTime, eTag)
            {
            }
        }
    }
}
