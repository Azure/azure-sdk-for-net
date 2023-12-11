﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Messaging.EventHubs.Primitives
{
    /// <summary>
    ///   A storage blob service that keeps track of checkpoints and ownership.
    /// </summary>
    ///
    internal partial class BlobCheckpointStoreInternal : CheckpointStore
    {
#pragma warning disable CA1802 // Use a constant field
        /// <summary>A message to use when throwing exception when checkpoint container or blob does not exists.</summary>
        private static readonly string BlobsResourceDoesNotExist = "The Azure Storage Blobs container or blob used by the Event Processor Client does not exist.";
#pragma warning restore CA1810

        /// <summary>An ETag value to be used for permissive matching when querying Storage.</summary>
        private static readonly ETag IfNoneMatchAllTag = new ETag("*");

        /// <summary>
        ///   Specifies a string that filters the results to return only checkpoint blobs whose name begins
        ///   with the specified prefix.
        /// </summary>
        ///
        private const string CheckpointPrefix = "{0}/{1}/{2}/checkpoint/";

        /// <summary>
        ///   Specifies a string that filters the results to return only legacy checkpoint blobs whose name begins
        ///   with the specified prefix.
        /// </summary>
        ///
        /// <remarks>
        ///   This pattern is specific to the prefix used by the Azure Functions extension.  The legacy
        ///   <c>EventProcessorHost</c> allowed this value to be specified as an option, defaulting to
        ///   an empty prefix.  <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Microsoft.Azure.EventHubs.Processor/src/EventProcessorHost.cs#L64">EventProcessorHost constructor</see>
        ///
        ///   For this to be general-purpose, it will need to be refactored into an option with this
        ///   pattern passed by the Functions extension.
        /// </remarks>
        ///
        private const string FunctionsLegacyCheckpointPrefix = "{0}/{1}/{2}/";

        /// <summary>
        ///   Specifies a string that filters the results to return only ownership blobs whose name begins
        ///   with the specified prefix.
        /// </summary>
        ///
        private const string OwnershipPrefix = "{0}/{1}/{2}/ownership/";

        /// <summary>
        ///   The client used to interact with the Azure Blob Storage service.
        /// </summary>
        ///
        private BlobContainerClient ContainerClient { get; }

        /// <summary>
        ///   Indicates whether to read legacy checkpoints when no current version checkpoints are available.
        /// </summary>
        ///
        private bool InitializeWithLegacyCheckpoints { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BlobCheckpointStoreInternal" /> class.
        /// </summary>
        ///
        /// <param name="blobContainerClient">The client responsible for persisting data to Azure Storage.</param>
        ///
        /// <remarks>
        ///   The blob container referenced by the <paramref name="blobContainerClient" /> is expected to exist.
        /// </remarks>
        ///
        public BlobCheckpointStoreInternal(BlobContainerClient blobContainerClient) : this(blobContainerClient, false)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BlobCheckpointStoreInternal" /> class.
        /// </summary>
        ///
        /// <param name="blobContainerClient">The client responsible for persisting data to Azure Storage.</param>
        /// <param name="initializeWithLegacyCheckpoints">Indicates whether to read legacy checkpoint when no current version checkpoint is available for a partition.</param>
        ///
        /// <remarks>
        ///   The blob container referenced by the <paramref name="blobContainerClient" /> is expected to exist.
        /// </remarks>
        ///
        internal BlobCheckpointStoreInternal(BlobContainerClient blobContainerClient,
                                             bool initializeWithLegacyCheckpoints = false)
        {
            Argument.AssertNotNull(blobContainerClient, nameof(blobContainerClient));

            ContainerClient = blobContainerClient;
            InitializeWithLegacyCheckpoints = initializeWithLegacyCheckpoints;
            BlobsCheckpointStoreCreated(nameof(BlobCheckpointStoreInternal), blobContainerClient.AccountName, blobContainerClient.Name);
        }

        /// <summary>
        ///   Requests a list of the ownership assignments for partitions between each of the cooperating event processor
        ///   instances for a given Event Hub and consumer group pairing.  This operation is used during load balancing to allow
        ///   the processor to discover other active collaborators and to make decisions about how to best balance work
        ///   between them.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <returns>The set of ownership data to take into account when making load balancing decisions.</returns>
        ///
        public override async Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace,
                                                                                                     string eventHubName,
                                                                                                     string consumerGroup,
                                                                                                     CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ListOwnershipStart(fullyQualifiedNamespace, eventHubName, consumerGroup);

            var result = new List<EventProcessorPartitionOwnership>();

            try
            {
                var prefix = string.Format(CultureInfo.InvariantCulture, OwnershipPrefix, fullyQualifiedNamespace.ToLowerInvariant(), eventHubName.ToLowerInvariant(), consumerGroup.ToLowerInvariant());

                await foreach (BlobItem blob in ContainerClient.GetBlobsAsync(traits: BlobTraits.Metadata, prefix: prefix, cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    // In case this key does not exist, ownerIdentifier is set to null.  This will force the PartitionOwnership constructor
                    // to throw an exception.

                    blob.Metadata.TryGetValue(BlobMetadataKey.OwnerIdentifier, out var ownerIdentifier);

                    result.Add(new EventProcessorPartitionOwnership
                    {
                        FullyQualifiedNamespace = fullyQualifiedNamespace,
                        EventHubName = eventHubName,
                        ConsumerGroup = consumerGroup,
                        OwnerIdentifier = ownerIdentifier,
                        PartitionId = blob.Name.Substring(prefix.Length),
                        LastModifiedTime = blob.Properties.LastModified.GetValueOrDefault(),
                        Version = blob.Properties.ETag.ToString()
                    });
                }

                return result;
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ContainerNotFound)
            {
                ListOwnershipError(fullyQualifiedNamespace, eventHubName, consumerGroup, ex);
                throw new RequestFailedException(BlobsResourceDoesNotExist, ex);
            }
            finally
            {
                ListOwnershipComplete(fullyQualifiedNamespace, eventHubName, consumerGroup, result?.Count ?? 0);
            }
        }

        /// <summary>
        ///   Attempts to claim ownership of the specified partitions for processing.  This operation is used by
        ///   load balancing to enable distributing the responsibility for processing partitions for an
        ///   Event Hub and consumer group pairing amongst the active event processors.
        /// </summary>
        ///
        /// <param name="desiredOwnership">The set of partition ownership desired by the event processor instance; this is the set of partitions that it will attempt to request responsibility for processing.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <returns>The set of ownership records for the partitions that were successfully claimed; this is expected to be the <paramref name="desiredOwnership"/> or a subset of those partitions.</returns>
        ///
        public override async Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership,
                                                                                                      CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var claimedOwnership = new List<EventProcessorPartitionOwnership>();
            var metadata = new Dictionary<string, string>();

            Response<BlobContentInfo> contentInfoResponse;
            Response<BlobInfo> infoResponse;

            foreach (EventProcessorPartitionOwnership ownership in desiredOwnership)
            {
                ClaimOwnershipStart(ownership.PartitionId, ownership.FullyQualifiedNamespace, ownership.EventHubName, ownership.ConsumerGroup, ownership.OwnerIdentifier);
                metadata[BlobMetadataKey.OwnerIdentifier] = ownership.OwnerIdentifier;

                var blobRequestConditions = new BlobRequestConditions();
                var blobName = string.Format(CultureInfo.InvariantCulture, OwnershipPrefix + ownership.PartitionId, ownership.FullyQualifiedNamespace.ToLowerInvariant(), ownership.EventHubName.ToLowerInvariant(), ownership.ConsumerGroup.ToLowerInvariant());
                var blobClient = ContainerClient.GetBlobClient(blobName);

                try
                {
                    // Even though documentation states otherwise, we cannot use UploadAsync when the blob already exists in
                    // the current storage SDK.  For this reason, we are using the specified ETag as an indication of what
                    // method to use.
                    //
                    // If an ETag is associated with ownership, assume the blob exists and attempt to update it.

                    if (ownership.Version != null)
                    {
                        try
                        {
                            blobRequestConditions.IfMatch = new ETag(ownership.Version);
                            infoResponse = await blobClient.SetMetadataAsync(metadata, blobRequestConditions, cancellationToken).ConfigureAwait(false);

                            ownership.LastModifiedTime = infoResponse.Value.LastModified;
                            ownership.Version = infoResponse.Value.ETag.ToString();
                        }
                        catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
                        {
                            // This is an unlikely corner case that indicates that the blob was unexpectedly deleted while the
                            // processor is running.  Attempt to recover by resetting the ETag and considering it an upload scenario
                            // to be handled by the next block.

                            ownership.Version = null;
                        }
                    }

                    // If no ETag is associated with ownership, attempt to upload a new blob with the needed metadata.

                    if (ownership.Version == null)
                    {
                        blobRequestConditions.IfNoneMatch = IfNoneMatchAllTag;

                        using var blobContent = new MemoryStream(Array.Empty<byte>());

                        try
                        {
                            contentInfoResponse = await blobClient.UploadAsync(blobContent, metadata: metadata, conditions: blobRequestConditions, cancellationToken: cancellationToken).ConfigureAwait(false);
                        }
                        catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobAlreadyExists)
                        {
                            // A blob could have just been created by another Event Processor that claimed ownership of this
                            // partition.  In this case, there's no point in retrying because we don't have the correct ETag.

                            OwnershipNotClaimable(ownership.PartitionId, ownership.FullyQualifiedNamespace, ownership.EventHubName, ownership.ConsumerGroup, ownership.OwnerIdentifier, ex.Message);
                            continue;
                        }

                        ownership.LastModifiedTime = contentInfoResponse.Value.LastModified;
                        ownership.Version = contentInfoResponse.Value.ETag.ToString();
                    }

                    // Small workaround to retrieve the ETag.  The current storage SDK returns it enclosed in
                    // double quotes ("ETAG_VALUE" instead of ETAG_VALUE).

                    ownership.Version = ownership.Version?.Trim('"');

                    claimedOwnership.Add(ownership);
                    OwnershipClaimed(ownership.PartitionId, ownership.FullyQualifiedNamespace, ownership.EventHubName, ownership.ConsumerGroup, ownership.OwnerIdentifier);
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ConditionNotMet)
                {
                    OwnershipNotClaimable(ownership.PartitionId, ownership.FullyQualifiedNamespace, ownership.EventHubName, ownership.ConsumerGroup, ownership.OwnerIdentifier, ex.ToString());
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ContainerNotFound || ex.ErrorCode == BlobErrorCode.BlobNotFound)
                {
                    ClaimOwnershipError(ownership.PartitionId, ownership.FullyQualifiedNamespace, ownership.EventHubName, ownership.ConsumerGroup, ownership.OwnerIdentifier, ex);
                    throw new RequestFailedException(BlobsResourceDoesNotExist, ex);
                }
                catch (Exception ex)
                {
                    ClaimOwnershipError(ownership.PartitionId, ownership.FullyQualifiedNamespace, ownership.EventHubName, ownership.ConsumerGroup, ownership.OwnerIdentifier, ex);
                    throw;
                }
                finally
                {
                    ClaimOwnershipComplete(ownership.PartitionId, ownership.FullyQualifiedNamespace, ownership.EventHubName, ownership.ConsumerGroup, ownership.OwnerIdentifier);
                }
            }

            return claimedOwnership;
        }

        /// <summary>
        ///   Requests checkpoint information for a specific partition, allowing an event processor to resume reading
        ///   from the next event in the stream.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="partitionId">The identifier of the partition to read a checkpoint for.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal a request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="EventProcessorCheckpoint"/> instance, if a checkpoint was found for the requested partition; otherwise, <c>null</c>.</returns>
        ///
        public override async Task<EventProcessorCheckpoint> GetCheckpointAsync(string fullyQualifiedNamespace,
                                                                                string eventHubName,
                                                                                string consumerGroup,
                                                                                string partitionId,
                                                                                CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            EventProcessorCheckpoint checkpoint = null;

            try
            {
                GetCheckpointStart(fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId);

                try
                {
                    var blobName = string.Format(CultureInfo.InvariantCulture, CheckpointPrefix, fullyQualifiedNamespace.ToLowerInvariant(), eventHubName.ToLowerInvariant(), consumerGroup.ToLowerInvariant()) + partitionId;
                    var blob = await ContainerClient
                        .GetBlobClient(blobName)
                        .GetPropertiesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);

                    checkpoint = CreateCheckpoint(fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId, blob.Value.Metadata, blob.Value.LastModified);
                    return checkpoint;
                }
                catch (RequestFailedException e) when (e.ErrorCode == BlobErrorCode.BlobNotFound)
                {
                    // ignore
                }

                try
                {
                    if (InitializeWithLegacyCheckpoints)
                    {
                        var legacyPrefix = string.Format(CultureInfo.InvariantCulture, FunctionsLegacyCheckpointPrefix, fullyQualifiedNamespace, eventHubName, consumerGroup) + partitionId;
                        checkpoint = await CreateLegacyCheckpoint(fullyQualifiedNamespace, eventHubName, consumerGroup, legacyPrefix, partitionId, cancellationToken).ConfigureAwait(false);
                        return checkpoint;
                    }
                }
                catch (RequestFailedException e) when (e.ErrorCode == BlobErrorCode.BlobNotFound)
                {
                    // ignore
                }

                return null;
            }
            catch (Exception ex)
            {
                GetCheckpointError(fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId, ex);
                throw;
            }
            finally
            {
                GetCheckpointComplete(fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId, checkpoint?.ClientIdentifier, checkpoint?.LastModified ?? default);
            }
        }

        /// <summary>
        ///   Creates or updates a checkpoint for a specific partition, identifying a position in the partition's event stream
        ///   that an event processor should begin reading from.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="partitionId">The identifier of the partition the checkpoint is for.</param>
        /// <param name="clientIdentifier">The unique identifier of the client that authored this checkpoint.</param>
        /// <param name="checkpointStartingPosition">The starting position to associate with the checkpoint, indicating that a processor should begin reading from the next event in the stream.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal a request to cancel the operation.</param>
        ///
        public override async Task UpdateCheckpointAsync(string fullyQualifiedNamespace,
                                                         string eventHubName,
                                                         string consumerGroup,
                                                         string partitionId,
                                                         string clientIdentifier,
                                                         CheckpointPosition checkpointStartingPosition,
                                                         CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            UpdateCheckpointStart(partitionId, fullyQualifiedNamespace, eventHubName, consumerGroup, clientIdentifier, checkpointStartingPosition.SequenceNumber, -1, checkpointStartingPosition.Offset ?? long.MinValue);

            var blobName = string.Format(CultureInfo.InvariantCulture, CheckpointPrefix + partitionId, fullyQualifiedNamespace.ToLowerInvariant(), eventHubName.ToLowerInvariant(), consumerGroup.ToLowerInvariant());
            var blobClient = ContainerClient.GetBlobClient(blobName);

            var metadata = new Dictionary<string, string>()
            {
                { BlobMetadataKey.Offset, (checkpointStartingPosition.Offset ?? long.MinValue).ToString(CultureInfo.InvariantCulture) },
                { BlobMetadataKey.SequenceNumber, (checkpointStartingPosition.SequenceNumber).ToString(CultureInfo.InvariantCulture) },
                { BlobMetadataKey.ClientIdentifier, clientIdentifier ?? string.Empty }
            };

            try
            {
                try
                {
                    // Assume the blob is present and attempt to set the metadata.

                    await blobClient.SetMetadataAsync(metadata, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                catch (RequestFailedException ex) when ((ex.ErrorCode == BlobErrorCode.BlobNotFound) || (ex.ErrorCode == BlobErrorCode.ContainerNotFound))
                {
                    // If the blob wasn't present, fall-back to trying to create a new one.

                    using var blobContent = new MemoryStream(Array.Empty<byte>());
                    await blobClient.UploadAsync(blobContent, metadata: metadata, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ContainerNotFound)
            {
                UpdateCheckpointError(partitionId, fullyQualifiedNamespace, eventHubName, consumerGroup, clientIdentifier, checkpointStartingPosition.SequenceNumber, -1, checkpointStartingPosition.Offset ?? long.MinValue, ex);
                throw new RequestFailedException(BlobsResourceDoesNotExist, ex);
            }
            catch (Exception ex)
            {
                UpdateCheckpointError(partitionId, fullyQualifiedNamespace, eventHubName, consumerGroup, clientIdentifier, checkpointStartingPosition.SequenceNumber, -1, checkpointStartingPosition.Offset ?? long.MinValue, ex);
                throw;
            }
            finally
            {
                UpdateCheckpointComplete(partitionId, fullyQualifiedNamespace, eventHubName, consumerGroup, clientIdentifier, checkpointStartingPosition.SequenceNumber, -1, checkpointStartingPosition.Offset ?? long.MinValue);
            }
        }

        /// <summary>
        ///   Creates a checkpoint instance based on the blob metadata.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="partitionId">The partition id the specific checkpoint is associated with.</param>
        /// <param name="metadata">The metadata of the blob that represents the checkpoint.</param>
        /// <param name="modifiedDate">The date/time that the blob representing the checkpoint was last modified.</param>
        ///
        /// <returns>A <see cref="EventProcessorCheckpoint"/> initialized with checkpoint properties if the checkpoint exists, otherwise <code>null</code>.</returns>
        ///
        private EventProcessorCheckpoint CreateCheckpoint(string fullyQualifiedNamespace,
                                                          string eventHubName,
                                                          string consumerGroup,
                                                          string partitionId,
                                                          IDictionary<string, string> metadata,
                                                          DateTimeOffset modifiedDate)
        {
            var startingPosition = default(EventPosition?);
            var offset = default(long?);
            var sequenceNumber = default(long?);
            var clientIdentifier = default(string);

            if (metadata.TryGetValue(BlobMetadataKey.Offset, out var str) && long.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
            {
                offset = result;
                if (offset != long.MinValue) // This means no value was passed.
                {
                    startingPosition = EventPosition.FromOffset(result, false);
                }
            }
            if (metadata.TryGetValue(BlobMetadataKey.SequenceNumber, out str) && long.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out result))
            {
                sequenceNumber = result;
                if (sequenceNumber != long.MinValue) // This means no value was passed.
                {
                    startingPosition ??= EventPosition.FromSequenceNumber(result, false);
                }
            }
            if (metadata.TryGetValue(BlobMetadataKey.ClientIdentifier, out str))
            {
                clientIdentifier = str;
            }

                // If either the offset or the sequence number was not populated,
                // this is not a valid checkpoint.

                if (!startingPosition.HasValue)
            {
                InvalidCheckpointFound(partitionId, fullyQualifiedNamespace, eventHubName, consumerGroup);
                return null;
            }

            return new BlobStorageCheckpoint()
            {
                FullyQualifiedNamespace = fullyQualifiedNamespace,
                EventHubName = eventHubName,
                ConsumerGroup = consumerGroup,
                PartitionId = partitionId,
                StartingPosition = startingPosition.Value,
                Offset = offset,
                SequenceNumber = sequenceNumber,
                LastModified = modifiedDate,
                ClientIdentifier = clientIdentifier
            };
        }

        /// <summary>
        ///   Creates a checkpoint instance based on the blob name for a legacy checkpoint format.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="partitionId">The partition id the specific checkpoint is associated with.</param>
        /// <param name="blobName">The name of the blob that represents the checkpoint.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A <see cref="EventProcessorCheckpoint"/> initialized with checkpoint properties if the checkpoint exists, otherwise <code>null</code>.</returns>
        ///
        private async Task<EventProcessorCheckpoint> CreateLegacyCheckpoint(string fullyQualifiedNamespace,
                                                                            string eventHubName,
                                                                            string consumerGroup,
                                                                            string blobName,
                                                                            string partitionId,
                                                                            CancellationToken cancellationToken)
        {
            var startingPosition = default(EventPosition?);

            BlobBaseClient blobClient = ContainerClient.GetBlobClient(blobName);
            using var memoryStream = new MemoryStream();
            await blobClient.DownloadToAsync(memoryStream, cancellationToken).ConfigureAwait(false);

            if (TryReadLegacyCheckpoint(
                memoryStream.GetBuffer().AsSpan(0, (int)memoryStream.Length),
                out long? offset,
                out long? sequenceNumber))
            {
                if (offset.HasValue)
                {
                    startingPosition = EventPosition.FromOffset(offset.Value, false);
                }
                else
                {
                    // Skip checkpoints without an offset without logging an error.

                    return null;
                }
            }

            if (!startingPosition.HasValue)
            {
                InvalidCheckpointFound(partitionId, fullyQualifiedNamespace, eventHubName, consumerGroup);

                return null;
            }

            return new BlobStorageCheckpoint
            {
                FullyQualifiedNamespace = fullyQualifiedNamespace,
                EventHubName = eventHubName,
                ConsumerGroup = consumerGroup,
                PartitionId = partitionId,
                StartingPosition = startingPosition.Value,
                Offset = offset,
                SequenceNumber = sequenceNumber,
            };
        }

        /// <summary>
        ///   Attempts to read a legacy checkpoint JSON format and extract an offset and a sequence number
        /// </summary>
        ///
        /// <param name="data">The binary representation of the checkpoint JSON.</param>
        /// <param name="offset">The parsed offset. null if not found.</param>
        /// <param name="sequenceNumber">The parsed sequence number. null if not found.</param>
        ///
        /// <remarks>
        ///   Sample checkpoint JSON:
        ///   {
        ///       "PartitionId":"0",
        ///       "Owner":"681d365b-de1b-4288-9733-76294e17daf0",
        ///       "Token":"2d0c4276-827d-4ca4-a345-729caeca3b82",
        ///       "Epoch":386,
        ///       "Offset":"8591964920",
        ///       "SequenceNumber":960180
        ///   }
        /// </remarks>
        ///
        private static bool TryReadLegacyCheckpoint(Span<byte> data,
                                                    out long? offset,
                                                    out long? sequenceNumber)
        {
            offset = null;
            sequenceNumber = null;

            var hadOffset = false;
            var jsonReader = new Utf8JsonReader(data);

            try
            {
                if (!jsonReader.Read() || jsonReader.TokenType != JsonTokenType.StartObject)
                    return false;

                while (jsonReader.Read() && jsonReader.TokenType == JsonTokenType.PropertyName)
                {
                    switch (jsonReader.GetString())
                    {
                        case "Offset":

                            if (!jsonReader.Read())
                            {
                                return false;
                            }

                            hadOffset = true;

                            var offsetString = jsonReader.GetString();
                            if (!string.IsNullOrEmpty(offsetString))
                            {
                                if (long.TryParse(offsetString, out long offsetValue))
                                {
                                    offset = offsetValue;
                                }
                                else
                                {
                                    return false;
                                }
                            }

                            break;
                        case "SequenceNumber":
                            if (!jsonReader.Read() ||
                                !jsonReader.TryGetInt64(out long sequenceNumberValue))
                            {
                                return false;
                            }

                            sequenceNumber = sequenceNumberValue;
                            break;
                        default:
                            jsonReader.Skip();
                            break;
                    }
                }
            }
            catch (JsonException)
            {
                // Ignore this because if the data is malformed, it will be treated as if the checkpoint didn't exist.

                return false;
            }

            return hadOffset && sequenceNumber != null;
        }

        /// <summary>
        ///   Indicates that an attempt to retrieve a list of ownership has completed.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="ownershipCount">The amount of ownership received from the storage service.</param>
        ///
        partial void ListOwnershipComplete(string fullyQualifiedNamespace,
                                           string eventHubName,
                                           string consumerGroup,
                                           int ownershipCount);

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while retrieving a list of ownership.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="exception">The message for the exception that occurred.</param>
        ///
        partial void ListOwnershipError(string fullyQualifiedNamespace,
                                        string eventHubName,
                                        string consumerGroup,
                                        Exception exception);

        /// <summary>
        ///   Indicates that an attempt to retrieve a list of ownership has started.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        ///
        partial void ListOwnershipStart(string fullyQualifiedNamespace,
                                        string eventHubName,
                                        string consumerGroup);

        /// <summary>
        ///   Indicates that an attempt to retrieve a checkpoint has started.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="partitionId">The partition id the specific checkpoint is associated with.</param>
        ///
        partial void GetCheckpointStart(string fullyQualifiedNamespace,
                                        string eventHubName,
                                        string consumerGroup,
                                        string partitionId);

        /// <summary>
        ///   Indicates that an attempt to retrieve a checkpoint has completed.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="partitionId">The partition id the specific checkpoint is associated with.</param>
        /// <param name="clientIdentifier">The unique identifier of the Event Hubs client that authored this checkpoint.</param>
        /// <param name="lastModified">The date and time the associated checkpoint was last modified.</param>
        ///
        partial void GetCheckpointComplete(string fullyQualifiedNamespace,
                                           string eventHubName,
                                           string consumerGroup,
                                           string partitionId,
                                           string clientIdentifier,
                                           DateTimeOffset lastModified);

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while retrieving a checkpoint.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="partitionId">The partition id the specific checkpoint is associated with.</param>
        /// <param name="exception">The message for the exception that occurred.</param>
        ///
        partial void GetCheckpointError(string fullyQualifiedNamespace,
                                        string eventHubName,
                                        string consumerGroup,
                                        string partitionId,
                                        Exception exception);

        /// <summary>
        ///   Indicates that invalid checkpoint data was found during an attempt to retrieve a list of checkpoints.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition the data is associated with.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the data is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the data is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the data is associated with.</param>
        ///
        partial void InvalidCheckpointFound(string partitionId,
                                            string fullyQualifiedNamespace,
                                            string eventHubName,
                                            string consumerGroup);

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while updating a checkpoint.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being checkpointed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="clientIdentifier">The unique identifier of the client that authored the checkpoint.</param>
        /// <param name="sequenceNumber">The sequence number associated with the checkpoint.</param>
        /// <param name="replicationSegment">The replication segment associated with the checkpoint.</param>
        /// <param name="offset">The offset associated with the checkpoint.</param>
        /// <param name="exception">The message for the exception that occurred.</param>
        ///
        partial void UpdateCheckpointError(string partitionId,
                                           string fullyQualifiedNamespace,
                                           string eventHubName,
                                           string consumerGroup,
                                           string clientIdentifier,
                                           long sequenceNumber,
                                           int replicationSegment,
                                           long offset,
                                           Exception exception);

        /// <summary>
        ///   Indicates that an attempt to update a checkpoint has completed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being checkpointed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="clientIdentifier">The unique identifier of the client that authored the checkpoint.</param>
        /// <param name="sequenceNumber">The sequence number associated with the checkpoint.</param>
        /// <param name="replicationSegment">The replication segment associated with the checkpoint.</param>
        /// <param name="offset">The offset associated with the checkpoint.</param>
        ///
        partial void UpdateCheckpointComplete(string partitionId,
                                              string fullyQualifiedNamespace,
                                              string eventHubName,
                                              string consumerGroup,
                                              string clientIdentifier,
                                              long sequenceNumber,
                                              int replicationSegment,
                                              long offset);

        /// <summary>
        ///   Indicates that an attempt to create/update a checkpoint has started.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being checkpointed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="clientIdentifier">The unique identifier of the client that authored this checkpoint.</param>
        /// <param name="sequenceNumber">The sequence number associated with the checkpoint.</param>
        /// <param name="replicationSegment">The replication segment associated with the checkpoint.</param>
        /// <param name="offset">The offset associated with the checkpoint.</param>
        ///
        partial void UpdateCheckpointStart(string partitionId,
                                           string fullyQualifiedNamespace,
                                           string eventHubName,
                                           string consumerGroup,
                                           string clientIdentifier,
                                           long sequenceNumber,
                                           int replicationSegment,
                                           long offset);

        /// <summary>
        ///   Indicates that an attempt to retrieve claim partition ownership has completed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        ///
        partial void ClaimOwnershipComplete(string partitionId,
                                            string fullyQualifiedNamespace,
                                            string eventHubName,
                                            string consumerGroup,
                                            string ownerIdentifier);

        /// <summary>
        ///   Indicates that an exception was encountered while attempting to retrieve claim partition ownership.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        /// <param name="exception">The message for the exception that occurred.</param>
        ///
        partial void ClaimOwnershipError(string partitionId,
                                         string fullyQualifiedNamespace,
                                         string eventHubName,
                                         string consumerGroup,
                                         string ownerIdentifier,
                                         Exception exception);

        /// <summary>
        ///   Indicates that ownership was unable to be claimed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        /// <param name="message">The message for the failure.</param>
        ///
        partial void OwnershipNotClaimable(string partitionId,
                                           string fullyQualifiedNamespace,
                                           string eventHubName,
                                           string consumerGroup,
                                           string ownerIdentifier,
                                           string message);

        /// <summary>
        ///   Indicates that ownership was successfully claimed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        ///
        partial void OwnershipClaimed(string partitionId,
                                      string fullyQualifiedNamespace,
                                      string eventHubName,
                                      string consumerGroup,
                                      string ownerIdentifier);

        /// <summary>
        ///   Indicates that an attempt to claim a partition ownership has started.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        ///
        partial void ClaimOwnershipStart(string partitionId,
                                         string fullyQualifiedNamespace,
                                         string eventHubName,
                                         string consumerGroup,
                                         string ownerIdentifier);

        /// <summary>
        ///   Indicates that a <see cref="BlobCheckpointStoreInternal" /> was created.
        /// </summary>
        ///
        /// <param name="typeName">The type name for the checkpoint store.</param>
        /// <param name="accountName">The Storage account name corresponding to the associated container client.</param>
        /// <param name="containerName">The name of the associated container client.</param>
        ///
        partial void BlobsCheckpointStoreCreated(string typeName,
                                                 string accountName,
                                                 string containerName);

        /// <summary>
        ///   Contains the information to reflect the state of event processing for a given Event Hub partition.
        ///   Provides access to the offset and the sequence number retrieved from the blob.
        /// </summary>
        ///
        internal class BlobStorageCheckpoint : EventProcessorCheckpoint
        {
            public long? Offset { get; set; }
            public long? SequenceNumber { get; set; }
        }
    }
}
