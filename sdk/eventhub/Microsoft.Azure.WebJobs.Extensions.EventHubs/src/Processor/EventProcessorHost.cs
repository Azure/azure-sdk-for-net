// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using Azure;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.EventHubs.Processor
{
    internal class EventProcessorHost
    {
        private string EventHubPath { get; }
        private string ConsumerGroupName { get; }
        private string EventHubConnectionString { get; }
        private string StorageConnectionString { get; }
        private string LeaseContainerName { get; }
        private string LegacyCheckpointStorageBlobPrefix { get; }
        private Processor CurrentProcessor { get; set; }
        private Action<ExceptionReceivedEventArgs> ExceptionHandler { get; }

        public EventProcessorHost(string eventHubPath, string consumerGroupName, string eventHubConnectionString, string storageConnectionString, string leaseContainerName, string legacyCheckpointStorageBlobPrefix, Action<ExceptionReceivedEventArgs> exceptionHandler)
        {
            EventHubPath = eventHubPath;
            ConsumerGroupName = consumerGroupName;
            EventHubConnectionString = eventHubConnectionString;
            StorageConnectionString = storageConnectionString;
            LeaseContainerName = leaseContainerName;
            LegacyCheckpointStorageBlobPrefix = legacyCheckpointStorageBlobPrefix;
            ExceptionHandler = exceptionHandler;
        }

        public async Task RegisterEventProcessorFactoryAsync(IEventProcessorFactory factory, int maxBatchSize, bool invokeProcessorAfterReceiveTimeout, EventProcessorOptions options)
        {
            if (CurrentProcessor != null)
            {
                throw new InvalidOperationException("Processor has already been started");
            }

            CurrentProcessor = new Processor(maxBatchSize, ConsumerGroupName, EventHubConnectionString, LegacyCheckpointStorageBlobPrefix, EventHubPath, options, factory, invokeProcessorAfterReceiveTimeout, ExceptionHandler, new BlobContainerClient(StorageConnectionString, LeaseContainerName));
            await CurrentProcessor.StartProcessingAsync().ConfigureAwait(false);
        }

        public async Task UnregisterEventProcessorAsync()
        {
            if (CurrentProcessor == null)
            {
                throw new InvalidOperationException("Processor has not been started");
            }

            await CurrentProcessor.StopProcessingAsync().ConfigureAwait(false);
            CurrentProcessor = null;
        }

        internal class Partition : EventProcessorPartition
        {
            public IEventProcessor Processor { get; set; }
            public ProcessorPartitionContext Context { get; set; }
        }

        internal class Processor : EventProcessor<Partition>
        {
            private IEventProcessorFactory ProcessorFactory { get; }
            private bool InvokeProcessorAfterRecieveTimeout { get; }
            private Action<ExceptionReceivedEventArgs> ExceptionHandler { get; }
            private ConcurrentDictionary<string, LeaseInfo> LeaseInfos { get; }

            private BlobContainerClient ContainerClient { get;  }

            // These constants match the constant used by the V5 EventHubs SDK.
            private const string OwnershipPrefixFormat = "{0}/{1}/{2}/ownership/";
            private const string CheckpointPrefixFormat = "{0}/{1}/{2}/checkpoint/";
            private const string OwnerIdentifierMetadataKey = "ownerid";
            private const string OffsetMetadataKey = "offset";
            private const string SequenceNumberMetadataKey = "sequencenumber";

            // In addition to being stored inside the lease blob, the V4 SDK also writes ownership information
            // as metadata on the blob, using this key.
            private const string OwningHostMedataKey = "OWNINGHOST";

            private string LegacyCheckpointStorageBlobPrefix { get; }

            public Processor(int eventBatchMaximumCount, string consumerGroup, string connectionString, string legacyCheckpointStorageBlobPrefix, string eventHubName, EventProcessorOptions options, IEventProcessorFactory processorFactory, bool invokeProcessorAfterRecieveTimeout, Action<ExceptionReceivedEventArgs> exceptionHandler, BlobContainerClient containerClient) : base(eventBatchMaximumCount, consumerGroup, connectionString, eventHubName, options)
            {
                ProcessorFactory = processorFactory;
                InvokeProcessorAfterRecieveTimeout = invokeProcessorAfterRecieveTimeout;
                ExceptionHandler = exceptionHandler;
                LeaseInfos = new ConcurrentDictionary<string, LeaseInfo>();
                ContainerClient = containerClient;
                LegacyCheckpointStorageBlobPrefix = legacyCheckpointStorageBlobPrefix;
            }

            protected override async Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership, CancellationToken cancellationToken)
            {
                List<EventProcessorPartitionOwnership> claimedOwnerships = new List<EventProcessorPartitionOwnership>();

                foreach (EventProcessorPartitionOwnership ownership in desiredOwnership)
                {
                    Dictionary<string, string> ownershipMetadata = new Dictionary<string, string>()
                    {
                        { OwnerIdentifierMetadataKey, ownership.OwnerIdentifier },
                    };

                    // Construct the path to the blob and get a blob client for it so we can interact with it.
                    string ownershipBlob = string.Format(CultureInfo.InvariantCulture, OwnershipPrefixFormat + ownership.PartitionId, ownership.FullyQualifiedNamespace.ToLowerInvariant(), ownership.EventHubName.ToLowerInvariant(), ownership.ConsumerGroup.ToLowerInvariant());
                    BlobClient ownershipBlobClient = ContainerClient.GetBlobClient(ownershipBlob);

                    try
                    {
                        if (ownership.Version == null)
                        {
                            // In this case, we are trying to claim ownership of a partition which was previously unowned, and hence did not have an ownership file. To ensure only a single host grabs the partition,
                            // we use a conditional request so that we only create our blob in the case where it does not yet exist.
                            BlobRequestConditions requestConditions = new BlobRequestConditions() { IfNoneMatch = new ETag("*") };

                            using MemoryStream emptyStream = new MemoryStream(Array.Empty<byte>());
                            BlobContentInfo info = await ownershipBlobClient.UploadAsync(emptyStream, metadata: ownershipMetadata, conditions: requestConditions, cancellationToken: cancellationToken).ConfigureAwait(false);

                            claimedOwnerships.Add(new EventProcessorPartitionOwnership()
                            {
                                ConsumerGroup = ownership.ConsumerGroup,
                                EventHubName = ownership.EventHubName,
                                FullyQualifiedNamespace = ownership.FullyQualifiedNamespace,
                                LastModifiedTime = info.LastModified,
                                OwnerIdentifier = ownership.OwnerIdentifier,
                                PartitionId = ownership.PartitionId,
                                Version = info.ETag.ToString(),
                            });
                        }
                        else
                        {
                            // In this case, the partition is owned by some other host. The ownership file already exists, so we just need to change metadata on it. But we should only do this if the metadata has not
                            // changed between when we listed ownership and when we are trying to claim ownership, i.e. the ETag for the file has not changed.
                            BlobRequestConditions requestConditions = new BlobRequestConditions() { IfMatch = new ETag(ownership.Version) };
                            BlobInfo info = await ownershipBlobClient.SetMetadataAsync(ownershipMetadata, requestConditions, cancellationToken).ConfigureAwait(false);

                            claimedOwnerships.Add(new EventProcessorPartitionOwnership()
                            {
                                ConsumerGroup = ownership.ConsumerGroup,
                                EventHubName = ownership.EventHubName,
                                FullyQualifiedNamespace = ownership.FullyQualifiedNamespace,
                                LastModifiedTime = info.LastModified,
                                OwnerIdentifier = ownership.OwnerIdentifier,
                                PartitionId = ownership.PartitionId,
                                Version = info.ETag.ToString(),
                            });
                        }
                    }
                    catch (RequestFailedException e) when (e.ErrorCode == BlobErrorCode.BlobAlreadyExists || e.ErrorCode == BlobErrorCode.ConditionNotMet)
                    {
                        // In this case, another host has claimed the partition before we did. That's safe to ignore. We'll still try to claim other partitions.
                    }
                }

                return claimedOwnerships;
            }

            protected override async Task<IEnumerable<EventProcessorCheckpoint>> ListCheckpointsAsync(CancellationToken cancellationToken)
            {
                // First, we read information from the location that the EventHubs V5 SDK writes to.
                Dictionary<string, EventProcessorCheckpoint> checkpoints = new Dictionary<string, EventProcessorCheckpoint>();
                string checkpointBlobsPrefix = string.Format(CultureInfo.InvariantCulture, CheckpointPrefixFormat, FullyQualifiedNamespace.ToLowerInvariant(), EventHubName.ToLowerInvariant(), ConsumerGroup.ToLowerInvariant());

                await foreach (BlobItem item in ContainerClient.GetBlobsAsync(traits: BlobTraits.Metadata, prefix: checkpointBlobsPrefix, cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    if (long.TryParse(item.Metadata[OffsetMetadataKey], NumberStyles.Integer, CultureInfo.InvariantCulture, out long offset) &&
                        long.TryParse(item.Metadata[SequenceNumberMetadataKey], NumberStyles.Integer, CultureInfo.InvariantCulture, out long sequenceNumber))
                    {
                        string partitionId = item.Name.Substring(checkpointBlobsPrefix.Length);

                        LeaseInfos.TryAdd(partitionId, new LeaseInfo(offset, sequenceNumber));
                        checkpoints.Add(partitionId, new EventProcessorCheckpoint()
                        {
                            ConsumerGroup = ConsumerGroup,
                            EventHubName = EventHubName,
                            FullyQualifiedNamespace = FullyQualifiedNamespace,
                            PartitionId = partitionId,
                            StartingPosition = EventPosition.FromOffset(offset, isInclusive: false)
                        });
                    }
                }

                // Check to see if there are any additional checkpoints in the older location that the V4 SDK would write to. If so, use them (this is helpful when moving from the V4 to V5 SDK,
                // since it means we will not have to reprocess messages processed and checkpointed by the older SDK).
                string legacyCheckpointAndOwnershipPrefix = $"{LegacyCheckpointStorageBlobPrefix}{ConsumerGroup}/";
                await foreach (BlobItem item in ContainerClient.GetBlobsAsync(prefix: legacyCheckpointAndOwnershipPrefix, cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    string partitionId = item.Name.Substring(legacyCheckpointAndOwnershipPrefix.Length);
                    if (!checkpoints.ContainsKey(partitionId))
                    {
                        using MemoryStream checkpointStream = new MemoryStream();
                        await ContainerClient.GetBlobClient(item.Name).DownloadToAsync(checkpointStream, cancellationToken: cancellationToken).ConfigureAwait(false);
                        checkpointStream.Position = 0;
                        BlobPartitionLease lease = await JsonSerializer.DeserializeAsync<BlobPartitionLease>(checkpointStream, cancellationToken: cancellationToken).ConfigureAwait(false);

                        if (long.TryParse(lease.Offset, out long offset))
                        {
                            LeaseInfos.TryAdd(partitionId, new LeaseInfo(offset, lease.SequenceNumber ?? 0));
                            checkpoints.Add(partitionId, new EventProcessorCheckpoint()
                            {
                                ConsumerGroup = ConsumerGroup,
                                EventHubName = EventHubName,
                                FullyQualifiedNamespace = FullyQualifiedNamespace,
                                PartitionId = partitionId,
                                StartingPosition = EventPosition.FromOffset(offset, isInclusive: false)
                            });
                        }
                    }
                }

                return checkpoints.Values;
            }

            protected override async Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(CancellationToken cancellationToken)
            {
                List<EventProcessorPartitionOwnership> partitonOwnerships = new List<EventProcessorPartitionOwnership>();
                string ownershipBlobsPefix = string.Format(CultureInfo.InvariantCulture, OwnershipPrefixFormat, FullyQualifiedNamespace.ToLowerInvariant(), EventHubName.ToLowerInvariant(), ConsumerGroup.ToLowerInvariant());

                await foreach (BlobItem blob in ContainerClient.GetBlobsAsync(traits: BlobTraits.Metadata, prefix: ownershipBlobsPefix, cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    partitonOwnerships.Add(new EventProcessorPartitionOwnership()
                    {
                        ConsumerGroup = ConsumerGroup,
                        EventHubName = EventHubName,
                        FullyQualifiedNamespace = FullyQualifiedNamespace,
                        LastModifiedTime = blob.Properties.LastModified.GetValueOrDefault(),
                        OwnerIdentifier = blob.Metadata[OwnerIdentifierMetadataKey],
                        PartitionId = blob.Name.Substring(ownershipBlobsPefix.Length),
                        Version = blob.Properties.ETag.Value.ToString(),
                    });
                }

                return partitonOwnerships;
            }

            internal virtual async Task CheckpointAsync(string partitionId, EventData checkpointEvent, CancellationToken cancellationToken = default)
            {
                string checkpointBlob = string.Format(CultureInfo.InvariantCulture, CheckpointPrefixFormat + partitionId, FullyQualifiedNamespace.ToLowerInvariant(), EventHubName.ToLowerInvariant(), ConsumerGroup.ToLowerInvariant());
                Dictionary<string, string> checkpointMetadata = new Dictionary<string, string>()
                {
                    { OffsetMetadataKey, checkpointEvent.Offset.ToString(CultureInfo.InvariantCulture) },
                    { SequenceNumberMetadataKey, checkpointEvent.SequenceNumber.ToString(CultureInfo.InvariantCulture) }
                };

                using MemoryStream emptyStream = new MemoryStream(Array.Empty<byte>());
                await ContainerClient.GetBlobClient(checkpointBlob).UploadAsync(emptyStream, metadata: checkpointMetadata, cancellationToken: cancellationToken).ConfigureAwait(false);

                LeaseInfos[partitionId] = new LeaseInfo(checkpointEvent.Offset, checkpointEvent.SequenceNumber);

                // In addition to writing a checkpoint in the V5 format, we also write one in the older V4 format, as some processes (e.g. the scale controller) expect
                // checkpoints in the older format. This also makes it possible to move to an earlier version of the SDK without having to re-process events.
                BlobPartitionLease lease = new BlobPartitionLease()
                {
                    PartitionId = partitionId,
                    Owner = Identifier,
                    Offset = checkpointEvent.Offset.ToString(CultureInfo.InvariantCulture),
                    SequenceNumber = checkpointEvent.SequenceNumber,
                };

                using MemoryStream legacyCheckpointStream = new MemoryStream();
                await JsonSerializer.SerializeAsync(legacyCheckpointStream, lease).ConfigureAwait(false);

                string legacyCheckpointBlob = $"{LegacyCheckpointStorageBlobPrefix}{ConsumerGroup}/{partitionId}";
                Dictionary<string, string> legacyCheckpoitMetadata = new Dictionary<string, string>()
                {
                    { OwningHostMedataKey, Identifier }
                };

                await ContainerClient.GetBlobClient(checkpointBlob).UploadAsync(legacyCheckpointStream, metadata: legacyCheckpoitMetadata, cancellationToken: cancellationToken).ConfigureAwait(false);
            }

            internal virtual LeaseInfo GetLeaseInfo(string partitionId)
            {
                if (LeaseInfos.TryGetValue(partitionId, out LeaseInfo lease)) {
                    return lease;
                }

                return null;
            }

            protected override Task OnProcessingErrorAsync(Exception exception, Partition partition, string operationDescription, CancellationToken cancellationToken)
            {
                if (partition != null)
                {
                    return partition.Processor.ProcessErrorAsync(partition.Context, exception);
                }

                try
                {
                    ExceptionHandler(new ExceptionReceivedEventArgs(Identifier, operationDescription, null, exception));
                }
                catch (Exception)
                {
                    // Best effort logging.
                }

                return Task.CompletedTask;
            }

            protected override Task OnProcessingEventBatchAsync(IEnumerable<EventData> events, Partition partition, CancellationToken cancellationToken)
            {
                if ((events == null || !events.Any()) && !InvokeProcessorAfterRecieveTimeout)
                {
                    return Task.CompletedTask;
                }

                return partition.Processor.ProcessEventsAsync(partition.Context, events);
            }

            protected override Task OnInitializingPartitionAsync(Partition partition, CancellationToken cancellationToken)
            {
                partition.Processor = ProcessorFactory.CreateEventProcessor();
                partition.Context = new ProcessorPartitionContext(partition.PartitionId, this, ReadLastEnqueuedEventProperties);

                // Since we are re-initializing this partition, any cached information we have about the parititon will be incorrect.
                // Clear it out now, if there is any, we'll refresh it in ListCheckpointsAsync, which EventProcessor will call before starting to pump messages.
                LeaseInfos.TryRemove(partition.PartitionId, out _);
                return partition.Processor.OpenAsync(partition.Context);
            }

            protected override Task OnPartitionProcessingStoppedAsync(Partition partition, ProcessingStoppedReason reason, CancellationToken cancellationToken)
            {
                return partition.Processor.CloseAsync(partition.Context, reason);
            }

            // The V4 SDK stored lease and checkpoint information in a single JSON file with these properties
            private class BlobPartitionLease
            {
                public string PartitionId { get; set; }
                public string Owner { get; set; }
                public string Token { get; set; }
                public long? Epoch { get; set; }
                public string Offset { get; set; }
                public long? SequenceNumber { get; set; }
            }
        }
    }
}
