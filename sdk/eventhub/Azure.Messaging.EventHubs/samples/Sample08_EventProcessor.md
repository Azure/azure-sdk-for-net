# Building a custom processor with EventProcessor&lt;TPartition&gt;

This sample demonstrates using `EventProcessor<TPartition>` to build a custom event processor which manages its own load balancing and checkpoint state and then shows how to use it to consume events from Event Hubs. For the majority of scenarios, we recommend using the [EventProcessorClient](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples) from the [Azure.Messaging.EventHubs.Processor](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor) package instead of implementing your own processor library.

## What does a processor do?

When consuming events, the consumer is tied to a specific partition of an Event Hub and reads the events in order from that partition. This means, to read all events from an Event Hub, you'll need one consumer per partition reading and processing events. For some workloads (where the processing can be intensive) you may want these consumers spread out across multiple machines, or even to add and remove consumers as the rate of incoming events increases or decreases. We call this process *load balancing*. In addition, you'll want to make sure that if one of your consumers has a problem (such as the machine it is running on crashes) you're able to resume your processing at a later time, picking up where you left off. We call this process *checkpointing*.

While you could write code directly using the `EventHubConsumerClient` to handle these cases, the Azure SDK also provides a type, `EventProcessorClient`, which handles this for you. It uses the Azure Blob Storage SDK to handle storing the state that's used during the load balancing and checkpointing operations. For many customers, that's sufficient, but some customers have asked for the ability to control how the information related to checkpointing and load balancing is stored. But for customers who have unique needs, we've exposed the lower-level machinery needed to build your own processor, which gives you full control over how this data is stored.

## Building an Event Processor with `EventProcessor<TPartition>`

The low level machinery needed to build you own processor, with full control over how its state is stored, is exposed by the `EventProcessor<TPartition>` class in the `Azure.Messaging.EventHubs.Primitives` namespace. This is an abstract class, which has five methods you'll need to provide implementations for. If you've used the `EventProcessorClient`, the first two will be familiar to you:

- `OnProcessingEventBatchAsync`: The actual "business logic" of your processor. This is similar to the `ProcessEvent` event exposed by `EventProcessorClient`.
- `OnProcessingErrorAsync`: A handler that can be used to observe exceptions from inside the machinery of the EventProcessor itself. This is similar to the `ProcessError` event exposed by `EventProcessorClient`.

The remaining three deal with checkpointing and load balancing.

- `ListOwnershipAsync`: Used by load balancing to see which partitions have been assigned to which processors.
- `ClaimOwnershipAsync`: Used by load balancing to grab ownership of a partition (which may or may not be assigned to another processor).
- `ListCheckpointsAsync`: Used to find the starting point inside a partition when a processor starts reading events from a partition.

The two `On*` methods can only be implemented when we know what we want our event processor to do, but the remaining can be implemented independent of the business logic for processing events.

In this sample, we will use the same storage mechanism as EventProcessorClient, i.e. we will store checkpoint and load balancing state using Azure Blob Storage.

```C# Snippet:EventHubs_Sample08_AzureBlobStorageEventProcessor
public abstract class AzureBlobStorageEventProcessor<TPartition> : EventProcessor<TPartition> where TPartition : EventProcessorPartition, new()
{
    private BlobContainerClient StorageContainer { get; }

    protected AzureBlobStorageEventProcessor(int eventBatchMaximumCount, string consumerGroup, string connectionString, BlobContainerClient storageContainer, EventProcessorOptions options = null)
        : base(eventBatchMaximumCount, consumerGroup, connectionString, options)
    {
        StorageContainer = storageContainer;
    }

    protected AzureBlobStorageEventProcessor(int eventBatchMaximumCount, string consumerGroup, string connectionString, string eventHubName, BlobContainerClient storageContainer, EventProcessorOptions options = null)
        : base(eventBatchMaximumCount, consumerGroup, connectionString, eventHubName, options)
    {
        StorageContainer = storageContainer;
    }

    protected AzureBlobStorageEventProcessor(int eventBatchMaximumCount, string consumerGroup, string fullyQualifiedNamespace, string eventHubName, TokenCredential credential, BlobContainerClient storageContainer, EventProcessorOptions options = null)
        : base(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options)
    {
        StorageContainer = storageContainer;
    }

    private const string OwnershipPrefixFormat = "{0}/{1}/{2}/ownership/";
    private const string OwnerIdentifierMetadataKey = "ownerid";

    // Ownership information is stored as metadata on blobs in Azure Storage. To list ownership information we list all the blobs in blob storage (with their coresponding metadata) and then
    // extract the ownership information from the metadata.
    protected override async Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(CancellationToken cancellationToken = default)
    {
        List<EventProcessorPartitionOwnership> partitonOwnerships = new List<EventProcessorPartitionOwnership>();
        string ownershipBlobsPefix = string.Format(OwnershipPrefixFormat, FullyQualifiedNamespace.ToLowerInvariant(), EventHubName.ToLowerInvariant(), ConsumerGroup.ToLowerInvariant());

        await foreach (BlobItem blob in StorageContainer.GetBlobsAsync(traits: BlobTraits.Metadata, prefix: ownershipBlobsPefix, cancellationToken: cancellationToken).ConfigureAwait(false))
        {
            partitonOwnerships.Add(new EventProcessorPartitionOwnership()
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

    // To claim ownership of a partition, we have to write a blob to blob storage (if this partition has never been claimed before) or update the metadata of an existing blob.
    protected override async Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership, CancellationToken cancellationToken = default)
    {
        List<EventProcessorPartitionOwnership> claimedOwnerships = new List<EventProcessorPartitionOwnership>();
    
        foreach (EventProcessorPartitionOwnership ownership in desiredOwnership)
        {
            Dictionary<string, string> ownershipMetadata = new Dictionary<string, string>()
            {
                { OwnerIdentifierMetadataKey, ownership.OwnerIdentifier },
            };

            // Construct the path to the blob and get a blob client for it so we can interact with it.
            string ownershipBlob = string.Format(OwnershipPrefixFormat + ownership.PartitionId, ownership.FullyQualifiedNamespace.ToLowerInvariant(), ownership.EventHubName.ToLowerInvariant(), ownership.ConsumerGroup.ToLowerInvariant());
            BlobClient ownershipBlobClient = StorageContainer.GetBlobClient(ownershipBlob);

            try
            {
                if (ownership.Version == null)
                {
                    // In this case, we are trying to claim ownership of a partition which was previously unowned, and hence did not have an ownership file. To ensure only a single host grabs the partition, 
                    // we use a conditional request so that we only create our blob in the case where it does not yet exist.
                    BlobRequestConditions requestConditions = new BlobRequestConditions() { IfNoneMatch = ETag.All };

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
                        Version = info.ETag.ToString()
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
                        Version = info.ETag.ToString()
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

    private const string CheckpointPrefixFormat = "{0}/{1}/{2}/checkpoint/";
    private const string OffsetMetadataKey = "offset";

    // We use the same strategy for recording checkpoint information as ownership information (metadata on a blob in blob storage)
    protected override async Task<IEnumerable<EventProcessorCheckpoint>> ListCheckpointsAsync(CancellationToken cancellationToken = default)
    {
        List<EventProcessorCheckpoint> checkpoints = new List<EventProcessorCheckpoint>();
        string checkpointBlobsPrefix = string.Format(CheckpointPrefixFormat, FullyQualifiedNamespace.ToLowerInvariant(), EventHubName.ToLowerInvariant(), ConsumerGroup.ToLowerInvariant());

        await foreach (BlobItem item in StorageContainer.GetBlobsAsync(traits: BlobTraits.Metadata, prefix: checkpointBlobsPrefix, cancellationToken: cancellationToken).ConfigureAwait(false))
        {
            if (long.TryParse(item.Metadata[OffsetMetadataKey], NumberStyles.Integer, CultureInfo.InvariantCulture, out long offset))
            {
                checkpoints.Add(new EventProcessorCheckpoint()
                {
                    ConsumerGroup = ConsumerGroup,
                    EventHubName = EventHubName,
                    FullyQualifiedNamespace = FullyQualifiedNamespace,
                    PartitionId = item.Name.Substring(checkpointBlobsPrefix.Length),
                    StartingPosition = EventPosition.FromOffset(offset, isInclusive: false)
                });
            }
        }

        return checkpoints;
    }

    // Allow subclasses to call CheckpointAsync to store checkpoint information without having to understand the details of how checkpoints are stored.
    protected async Task CheckpointAsync(TPartition partition, EventData data, CancellationToken cancellationToken = default)
    {
        string checkpointBlob = string.Format(CheckpointPrefixFormat + partition.PartitionId, FullyQualifiedNamespace.ToLowerInvariant(), EventHubName.ToLowerInvariant(), ConsumerGroup.ToLowerInvariant());
        Dictionary<string, string> checkpointMetadata = new Dictionary<string, string>()
        {
            { OffsetMetadataKey, data.Offset.ToString(CultureInfo.InvariantCulture) },
        };

        using MemoryStream emptyStream = new MemoryStream(Array.Empty<byte>());
        await StorageContainer.GetBlobClient(checkpointBlob).UploadAsync(emptyStream, metadata: checkpointMetadata, cancellationToken: cancellationToken).ConfigureAwait(false);
    }        
}
```

## Using the Custom Processor

The `AzureBlobStorageEventProcessor<TPartiton>` above is abstract because we did not implement any of the `On*` methods. By separating the logic for state management and event processing, we can leverage `AzureBlobStorageEventProcessor<TPartiton>` to build many different processors, each with their own business logic, by extending `AzureBlobStorageEventProcessor<TPartiton>` and implementing `OnProcessingEventBatchAsync` and `OnProcessingErrorAsync`.

Here's a simple processor that just counts the number of events received in a batch and then creates a checkpoint so they are not processed again:

```C# Snippet:EventHubs_Sample08_CustomProcessor
class CustomProcessor : AzureBlobStorageEventProcessor<EventProcessorPartition>
{
    public CustomProcessor(int eventBatchMaximumCount, string consumerGroup, string fullyQualifiedNamespace, string eventHubName, TokenCredential credential, BlobContainerClient storageContainer, EventProcessorOptions options = null) : base(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, storageContainer, options)
    {
    }

    protected async override Task OnProcessingEventBatchAsync(IEnumerable<EventData> events, EventProcessorPartition partition, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Received batch of {events.Count()} events for partition {partition.PartitionId}");

        if (events.Any())
        {
            await CheckpointAsync(partition, events.Last(), cancellationToken);
        }
    }

    protected async override Task OnProcessingErrorAsync(Exception exception, EventProcessorPartition partition, string operationDescription, CancellationToken cancellationToken)
    {
        if (partition != null)
        {
            Console.Error.WriteLine($"Exception on partition {partition.PartitionId} while performing {operationDescription}: {exception.Message}");
        }
        else
        {
            Console.Error.WriteLine($"Exception while performing {operationDescription}: {exception.Message}");
        }        
    }    
}
```

This should look familiar if you've used `EventProcessorClient` before, but there are a few small differences you need to be aware of:

- The processor works in batches, so when you construct it you need to specify the maximum number of events you'll want to process at once, using the `eventBatchMaximumCount` parameter. The `IEnumerable<EventData>` that is passed `OnProcessingEventBatchAsync` to will never contain more items than this maximum count.
- If there are fewer unprocessed messages than `eventBatchMaximumCount` the processor also contains a maximum amount of time it will wait for more events to show up. By default, this is 60 seconds, but can be controlled by setting the `MaximumWaitTime` property of the `EventProcessorOptions` parameter. If this is set to `null` it means that the processor will until it has received `eventBatchMaximumCount` events, otherwise it will deliver a batch that has fewer events in it.
- If `MaximumWaitTime` is set, `OnProcessingEventBatchAsync` will be called even if no events have been consumed. In this case, the `IEnumerable<EventData>` will contain zero events (so we have to guard our call to `.Last()` which fails if there is no event.)
- The partition object passed to `OnProcessingErrorAsync` may be `null`, this happens when the exception is not tied to a specific partition (for example, if an exception was thrown by `ListOwnershipAsync`, it will not be tied to a specific partition and so the partition context will be `null` when the error handler is called), so we need to guard for that case as well.

More detail on the design and philosophy of `EventProcessor<TPartition>` can be found in the [EventProcessor&lt;TPartition&gt; design document](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/design/event-processor%7BT%7D-proposal.md)
