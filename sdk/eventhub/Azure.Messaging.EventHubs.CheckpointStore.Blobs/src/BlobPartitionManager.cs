// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.Messaging.EventHubs.CheckpointStore.Blobs
{
    /// <summary>
    ///   A storage blob service that keeps track of checkpoints and ownership.
    /// </summary>
    ///
    public sealed class BlobPartitionManager : PartitionManager
    {
        /// <summary>A regular expression used to capture strings enclosed in double quotes.</summary>
        private static readonly Regex s_doubleQuotesExpression = new Regex("\"(.*)\"", RegexOptions.Compiled);

        /// <summary>The client used to interact with the Azure Blob Storage service.</summary>
        private readonly BlobContainerClient _containerClient;

        /// <summary>Logs activities performed by this partition manager.</summary>
        private readonly Action<string> _logger;

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

            _containerClient = blobContainerClient ?? throw new ArgumentNullException(nameof(blobContainerClient));
            _logger = logger;
        }

        /// <summary>
        ///   Retrieves a complete ownership list from the storage blob service.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        ///
        /// <returns>An enumerable containing all the existing ownership for the associated Event Hub and consumer group.</returns>
        ///
        public override async Task<IEnumerable<PartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace,
                                                                                       string eventHubName,
                                                                                       string consumerGroup)
        {
            List<PartitionOwnership> ownershipList = new List<PartitionOwnership>();

            var prefix = $"{ fullyQualifiedNamespace }/{ eventHubName }/{ consumerGroup }/";
            await foreach (BlobItem blob in _containerClient.GetBlobsAsync(traits: BlobTraits.Metadata, prefix: prefix).ConfigureAwait(false))
            {
                // In case this key does not exist, ownerIdentifier is set to null.  This will force the PartitionOwnership constructor
                // to throw an exception.

                blob.Metadata.TryGetValue(BlobMetadataKey.OwnerIdentifier, out var ownerIdentifier);

                long? offset = null;
                long? sequenceNumber = null;

                if (blob.Metadata.TryGetValue(BlobMetadataKey.Offset, out var str) && long.TryParse(str, out var result))
                {
                    offset = result;
                }

                if (blob.Metadata.TryGetValue(BlobMetadataKey.SequenceNumber, out str) && long.TryParse(str, out result))
                {
                    sequenceNumber = result;
                }

                ownershipList.Add(new InnerPartitionOwnership(
                    fullyQualifiedNamespace,
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
        ///   Attempts to claim ownership of partitions for processing.
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

            Response<BlobContentInfo> contentInfoResponse;
            Response<BlobInfo> infoResponse;

            foreach (PartitionOwnership ownership in partitionOwnership)
            {
                metadata[BlobMetadataKey.OwnerIdentifier] = ownership.OwnerIdentifier;
                metadata[BlobMetadataKey.Offset] = ownership.Offset?.ToString() ?? string.Empty;
                metadata[BlobMetadataKey.SequenceNumber] = ownership.SequenceNumber?.ToString() ?? string.Empty;

                var blobRequestConditions = new BlobRequestConditions();

                var blobName = $"{ ownership.FullyQualifiedNamespace }/{ ownership.EventHubName }/{ ownership.ConsumerGroup }/{ ownership.PartitionId }";
                BlobClient blobClient = _containerClient.GetBlobClient(blobName);

                try
                {
                    // Even though documentation states otherwise, we cannot use UploadAsync when the blob already exists in
                    // the current storage SDK.  For this reason, we are using the specified ETag as an indication of what
                    // method to use.

                    if (ownership.ETag == null)
                    {
                        blobRequestConditions.IfNoneMatch = new ETag("*");

                        MemoryStream blobContent = null;

                        try
                        {
                            blobContent = new MemoryStream(new byte[0]);
                            contentInfoResponse = await blobClient.UploadAsync(blobContent, metadata: metadata, conditions: blobRequestConditions).ConfigureAwait(false);
                        }
                        catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobAlreadyExists)
                        {
                            // A blob could have just been created by another Event Processor that claimed ownership of this
                            // partition.  In this case, there's no point in retrying because we don't have the correct ETag.

                            Log($"Ownership with partition id = '{ ownership.PartitionId }' is not claimable.");
                            continue;
                        }
                        finally
                        {
                            blobContent?.Dispose();
                        }

                        ownership.LastModifiedTime = contentInfoResponse.Value.LastModified;
                        ownership.ETag = contentInfoResponse.Value.ETag.ToString();
                    }
                    else
                    {
                        blobRequestConditions.IfMatch = new ETag(ownership.ETag);

                        try
                        {
                            infoResponse = await blobClient.SetMetadataAsync(metadata, blobRequestConditions).ConfigureAwait(false);
                        }
                        catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
                        {
                            // No ownership was found, which means the ETag should have been set to null in order to
                            // claim this ownership.  For this reason, we consider it a failure and don't try again.

                            Log($"Ownership with partition id = '{ ownership.PartitionId }' is not claimable.");
                            continue;
                        }

                        ownership.LastModifiedTime = infoResponse.Value.LastModified;
                        ownership.ETag = infoResponse.Value.ETag.ToString();
                    }

                    // Small workaround to retrieve the eTag.  The current storage SDK returns it enclosed in
                    // double quotes ('"ETAG_VALUE"' instead of 'ETAG_VALUE').

                    Match match = s_doubleQuotesExpression.Match(ownership.ETag);

                    if (match.Success)
                    {
                        ownership.ETag = match.Groups[1].ToString();
                    }

                    claimedOwnership.Add(ownership);

                    Log($"Ownership with partition id = '{ ownership.PartitionId }' claimed.");
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ConditionNotMet)
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
            var blobName = $"{ checkpoint.FullyQualifiedNamespace }/{ checkpoint.EventHubName }/{ checkpoint.ConsumerGroup }/{ checkpoint.PartitionId }";
            BlobClient blobClient = _containerClient.GetBlobClient(blobName);

            BlobProperties currentBlob;

            try
            {
                currentBlob = (await blobClient.GetPropertiesAsync().ConfigureAwait(false)).Value;
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
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

                var requestConditions = new BlobRequestConditions { IfMatch = currentBlob.ETag };

                try
                {
                    await blobClient.SetMetadataAsync(metadata, requestConditions).ConfigureAwait(false);

                    Log($"Checkpoint with partition id = '{ checkpoint.PartitionId }' updated.");
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ConditionNotMet)
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
        private void Log(string message) => _logger?.Invoke(message);

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
            /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace this partition ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
            /// <param name="eventHubName">The name of the specific Event Hub this partition ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
            /// <param name="consumerGroup">The name of the consumer group this partition ownership is associated with.</param>
            /// <param name="ownerIdentifier">The identifier of the associated <see cref="EventProcessorClient" /> instance.</param>
            /// <param name="partitionId">The identifier of the Event Hub partition this partition ownership is associated with.</param>
            /// <param name="offset">The offset of the last <see cref="EventData" /> received by the associated partition processor.</param>
            /// <param name="sequenceNumber">The sequence number of the last <see cref="EventData" /> received by the associated partition processor.</param>
            /// <param name="lastModifiedTime">The date and time, in UTC, that the last update was made to this ownership.</param>
            /// <param name="eTag">The entity tag needed to update this ownership.</param>
            ///
            public InnerPartitionOwnership(string fullyQualifiedNamespace,
                                           string eventHubName,
                                           string consumerGroup,
                                           string ownerIdentifier,
                                           string partitionId,
                                           long? offset = null,
                                           long? sequenceNumber = null,
                                           DateTimeOffset? lastModifiedTime = null,
                                           string eTag = null) : base(fullyQualifiedNamespace, eventHubName, consumerGroup, ownerIdentifier, partitionId, offset, sequenceNumber, lastModifiedTime, eTag)
            {
            }
        }
    }
}
