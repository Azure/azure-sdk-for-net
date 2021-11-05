// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the sample
    ///   Sample08_CustomEventProcessor sample.
    /// </summary>
    ///
    /// <remarks>
    ///   These tests are primarily intended to ensure that the sample
    ///   is well-formed and compiles.  There are no live tests due to
    ///   the dependency on Azure.Storage.Blobs, which is not part of
    ///   the Event Hubs core package test environment.
    /// </remarks>
    ///
    [TestFixture]
    public class Sample08_CustomEventProcessorTests
    {
        /// <summary>
        ///   Verifies that a <see cref="CustomProcessor" /> instance
        ///   can be constructed.
        /// </summary>
        ///
        [Test]
        public void CustomProcessorCanBeInstantiated()
        {
            Assert.That(() => new CustomProcessor(5, "dummy", "notreal", "fake", Mock.Of<TokenCredential>(), Mock.Of<BlobContainerClient>()), Throws.Nothing);
        }

        #region Snippet:EventHubs_Sample08_AzureBlobStorageEventProcessor
        public abstract class AzureBlobStorageEventProcessor : EventProcessor<EventProcessorPartition>
        {
            private BlobContainerClient StorageContainer { get; }

            protected AzureBlobStorageEventProcessor(
                int eventBatchMaximumCount,
                string consumerGroup,
                string connectionString,
                BlobContainerClient storageContainer,
                EventProcessorOptions options = null)
                    : base(
                        eventBatchMaximumCount,
                        consumerGroup,
                        connectionString,
                        options)
            {
                StorageContainer = storageContainer;
            }

            protected AzureBlobStorageEventProcessor(
                int eventBatchMaximumCount,
                string consumerGroup,
                string connectionString,
                string eventHubName,
                BlobContainerClient storageContainer,
                EventProcessorOptions options = null)
                    : base(
                        eventBatchMaximumCount,
                        consumerGroup,
                        connectionString,
                        eventHubName,
                        options)
            {
                StorageContainer = storageContainer;
            }

            protected AzureBlobStorageEventProcessor(
                int eventBatchMaximumCount,
                string consumerGroup,
                string fullyQualifiedNamespace,
                string eventHubName,
                TokenCredential credential,
                BlobContainerClient storageContainer,
                EventProcessorOptions options = null)
                    : base(
                        eventBatchMaximumCount,
                        consumerGroup,
                        fullyQualifiedNamespace,
                        eventHubName,
                        credential,
                        options)
            {
                StorageContainer = storageContainer;
            }

            private const string OwnershipPrefixFormat = "{0}/{1}/{2}/ownership/";
            private const string OwnerIdentifierMetadataKey = "ownerid";

            // Ownership information is stored as metadata on blobs in Azure Storage.  To list ownership
            // information we list all the blobs in Blob Storage (with their corresponding metadata) and
            // then extract the ownership information from the metadata.

            protected override async Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(
                CancellationToken cancellationToken = default)
            {
                List<EventProcessorPartitionOwnership> partitonOwnerships =
                    new List<EventProcessorPartitionOwnership>();

                string ownershipBlobsPefix = string.Format(
                    OwnershipPrefixFormat,
                    FullyQualifiedNamespace.ToLowerInvariant(),
                    EventHubName.ToLowerInvariant(),
                    ConsumerGroup.ToLowerInvariant());

                AsyncPageable<BlobItem> blobItems = StorageContainer.GetBlobsAsync(
                    traits: BlobTraits.Metadata,
                    prefix: ownershipBlobsPefix,
                    cancellationToken: cancellationToken);

                await foreach (BlobItem blob in blobItems.ConfigureAwait(false))
                {
                    partitonOwnerships.Add(new EventProcessorPartitionOwnership
                    {
                        ConsumerGroup = ConsumerGroup,
                        EventHubName = EventHubName,
                        FullyQualifiedNamespace = FullyQualifiedNamespace,
                        LastModifiedTime = blob.Properties.LastModified.GetValueOrDefault(),
                        OwnerIdentifier = blob.Metadata[OwnerIdentifierMetadataKey],
                        PartitionId = blob.Name.Substring(ownershipBlobsPefix.Length),
                        Version = blob.Properties.ETag.ToString()
                    });
                }

                return partitonOwnerships;
            }

            // To claim ownership of a partition, we have to write a new blob to Blob Storage
            // (if this partition has never been claimed before) or update the metadata of an existing blob.

            protected override async Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(
                IEnumerable<EventProcessorPartitionOwnership> desiredOwnership,
                CancellationToken cancellationToken = default)
            {
                List<EventProcessorPartitionOwnership> claimedOwnerships = new List<EventProcessorPartitionOwnership>();

                foreach (EventProcessorPartitionOwnership ownership in desiredOwnership)
                {
                    Dictionary<string, string> ownershipMetadata = new Dictionary<string, string>()
                    {
                        { OwnerIdentifierMetadataKey, ownership.OwnerIdentifier },
                    };

                    // Construct the path to the blob and get a blob client for it so we can interact with it.

                    string ownershipBlob = string.Format(
                        OwnershipPrefixFormat + ownership.PartitionId,
                        ownership.FullyQualifiedNamespace.ToLowerInvariant(),
                        ownership.EventHubName.ToLowerInvariant(),
                        ownership.ConsumerGroup.ToLowerInvariant());

                    BlobClient ownershipBlobClient = StorageContainer.GetBlobClient(ownershipBlob);

                    try
                    {
                        if (ownership.Version == null)
                        {
                            // In this case, we are trying to claim ownership of a partition which was previously unowned, and
                            // hence did not have an ownership file.  To ensure only a single host grabs the partition, we use a
                            // conditional request so that we only create our blob in the case where it does not yet exist.

                            using MemoryStream emptyStream = new MemoryStream(Array.Empty<byte>());

                            BlobRequestConditions requestConditions = new BlobRequestConditions
                            {
                                IfNoneMatch = ETag.All
                            };

                            BlobContentInfo info = await ownershipBlobClient.UploadAsync(
                                emptyStream,
                                metadata: ownershipMetadata,
                                conditions: requestConditions,
                                cancellationToken: cancellationToken)
                            .ConfigureAwait(false);

                            claimedOwnerships.Add(new EventProcessorPartitionOwnership
                            {
                                ConsumerGroup = ownership.ConsumerGroup,
                                EventHubName = ownership.EventHubName,
                                FullyQualifiedNamespace = ownership.FullyQualifiedNamespace,
                                LastModifiedTime = info.LastModified,
                                OwnerIdentifier = ownership.OwnerIdentifier,
                                PartitionId = ownership.PartitionId,
                                Version = info.ETag.ToString()
                            });
                        }
                        else
                        {
                            // In this case, the partition is owned by some other host.  The ownership file already exists,
                            // so we just need to change metadata on it.  But we should only do this if the metadata has not
                            // changed between when we listed ownership and when we are trying to claim ownership, i.e.  the
                            // ETag for the file has not changed.

                            BlobRequestConditions requestConditions = new BlobRequestConditions
                            {
                                IfMatch = new ETag(ownership.Version)
                            };

                            BlobInfo info = await ownershipBlobClient.SetMetadataAsync(
                                ownershipMetadata,
                                requestConditions,
                                cancellationToken)
                            .ConfigureAwait(false);

                            claimedOwnerships.Add(new EventProcessorPartitionOwnership
                            {
                                ConsumerGroup = ownership.ConsumerGroup,
                                EventHubName = ownership.EventHubName,
                                FullyQualifiedNamespace = ownership.FullyQualifiedNamespace,
                                LastModifiedTime = info.LastModified,
                                OwnerIdentifier = ownership.OwnerIdentifier,
                                PartitionId = ownership.PartitionId,
                                Version = info.ETag.ToString()
                            });
                        }
                    }
                    catch (RequestFailedException ex) when (
                        ex.ErrorCode == BlobErrorCode.BlobAlreadyExists
                        || ex.ErrorCode == BlobErrorCode.ConditionNotMet)
                    {
                        // In this case, another host has claimed the partition before we did.  That's safe to ignore.
                        // We'll still try to claim other partitions.
                    }
                }

                return claimedOwnerships;
            }

            private const string CheckpointPrefixFormat = "{0}/{1}/{2}/checkpoint/";
            private const string OffsetMetadataKey = "offset";

            // We use the same strategy for recording checkpoint information as ownership information
            // (metadata on a blob in blob storage)

            protected override async Task<EventProcessorCheckpoint> GetCheckpointAsync(
                string partitionId,
                CancellationToken cancellationToken = default)
            {
                try
                {
                    string blobName = string.Format(
                        CheckpointPrefixFormat + partitionId,
                        FullyQualifiedNamespace.ToLowerInvariant(),
                        EventHubName.ToLowerInvariant(),
                        ConsumerGroup.ToLowerInvariant());

                    Response<BlobProperties> blobResponse = await StorageContainer
                        .GetBlobClient(blobName)
                        .GetPropertiesAsync(cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    if (long.TryParse(
                            blobResponse.Value.Metadata[OffsetMetadataKey],
                            NumberStyles.Integer,
                            CultureInfo.InvariantCulture,
                            out long offset))
                    {
                        return new EventProcessorCheckpoint
                        {
                            ConsumerGroup = ConsumerGroup,
                            EventHubName = EventHubName,
                            FullyQualifiedNamespace = FullyQualifiedNamespace,
                            PartitionId = partitionId,
                            StartingPosition = EventPosition.FromOffset(offset, isInclusive: false)
                        };
                    }
                }
                catch (RequestFailedException ex) when (ex.Status == 404)
                {
                    // Ignore; this will occur when no checkpoint is available.
                }

                // Returning null will signal that the default starting position
                // should be used for this partition.

                return null;
            }

            // Allow subclasses to call CheckpointAsync to store checkpoint information without
            // having to understand the details of how checkpoints are stored.

            protected async Task CheckpointAsync(
                EventProcessorPartition partition,
                EventData data,
                CancellationToken cancellationToken = default)
            {
                using MemoryStream emptyStream = new MemoryStream(Array.Empty<byte>());

                string checkpointBlob = string.Format(
                    CheckpointPrefixFormat + partition.PartitionId,
                    FullyQualifiedNamespace.ToLowerInvariant(),
                    EventHubName.ToLowerInvariant(),
                    ConsumerGroup.ToLowerInvariant());

                Dictionary<string, string> checkpointMetadata = new Dictionary<string, string>()
                {
                    { OffsetMetadataKey, data.Offset.ToString(CultureInfo.InvariantCulture) },
                };

                await StorageContainer
                    .GetBlobClient(checkpointBlob)
                    .UploadAsync(
                        emptyStream,
                        metadata: checkpointMetadata,
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }

            // ListCheckpointsAsync exists only for backwards compatibility and is called
            // only when GetCheckpointAsync is not overridden.  However, because it is abstract
            // it must be implemented.  Since we have implemented GetCheckpointAsync, we'll throw
            // here.

            protected override Task<IEnumerable<EventProcessorCheckpoint>> ListCheckpointsAsync(
                CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException("GetCheckpointAsync was implemented and should be used instead.");
            }
        }
        #endregion

        #region Snippet:EventHubs_Sample08_CustomProcessor
        public class CustomProcessor : AzureBlobStorageEventProcessor
        {
            public CustomProcessor(
                int eventBatchMaximumCount,
                string consumerGroup,
                string fullyQualifiedNamespace,
                string eventHubName,
                TokenCredential credential,
                BlobContainerClient storageContainer,
                EventProcessorOptions options = null)
                    : base(
                        eventBatchMaximumCount,
                        consumerGroup,
                        fullyQualifiedNamespace,
                        eventHubName,
                        credential,
                        storageContainer,
                        options)
            {
            }

            protected async override Task OnProcessingEventBatchAsync(
                IEnumerable<EventData> events,
                EventProcessorPartition partition,
                CancellationToken cancellationToken)
            {
                EventData lastEvent = null;

                try
                {
                    Console.WriteLine($"Received events for partition { partition.PartitionId }");

                    foreach (var currentEvent in events)
                    {
                        Console.WriteLine($"Event: { currentEvent.EventBody }");
                        lastEvent = currentEvent;
                    }

                    if (lastEvent != null)
                    {
                        await CheckpointAsync(
                            partition,
                            lastEvent,
                            cancellationToken)
                        .ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    // It is very important that you always guard against exceptions in
                    // your handler code; the processor does not have enough
                    // understanding of your code to determine the correct action to take.
                    // Any exceptions from your handlers go uncaught by the processor and
                    // will NOT be redirected to the error handler.

                    Console.WriteLine($"Exception while processing events: { ex }");
                }
            }

            protected override Task OnProcessingErrorAsync(
                Exception exception,
                EventProcessorPartition partition,
                string operationDescription,
                CancellationToken cancellationToken)
            {
                try
                {
                    if (partition != null)
                    {
                        Console.Error.WriteLine(
                            $"Exception on partition { partition.PartitionId } while " +
                            $"performing { operationDescription }: {exception}");
                    }
                    else
                    {
                        Console.Error.WriteLine(
                            $"Exception while performing { operationDescription }: { exception }");
                    }
                }
                catch (Exception ex)
                {
                    // It is very important that you always guard against exceptions
                    // in your handler code; the processor does not have enough
                    // understanding of your code to determine the correct action to
                    // take.  Any exceptions from your handlers go uncaught by the
                    // processor and will NOT be handled in any way.

                    Console.WriteLine($"Exception while processing events: { ex }");
                }

                return Task.CompletedTask;
            }
        }
        #endregion
    }
}
