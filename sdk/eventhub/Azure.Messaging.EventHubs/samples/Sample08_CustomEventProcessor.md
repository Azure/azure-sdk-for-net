# Building a custom processor with EventProcessor&lt;TPartition&gt;

This sample demonstrates using `EventProcessor<TPartition>` to build a custom event processor which manages its own load balancing and checkpoint state and then shows how to use it to consume events from Event Hubs.  For the majority of scenarios, we recommend using the [EventProcessorClient](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples) from the [Azure.Messaging.EventHubs.Processor](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor) package instead of implementing your own processor library.

## Reading events

When reading events, a consumer is tied to a specific partition of an Event Hub and reads the events in order from that partition.  This means, to read all events from an Event Hub, you'll need one consumer per partition reading and processing events.  For some workloads (where the processing can be intensive) you may want these consumers spread out across multiple machines, or even to add and remove consumers as the rate of incoming events increases or decreases.  We call this process *load balancing*.  In addition, you'll want to make sure that if one of your consumers has a problem (such as the machine it is running on crashes) you're able to resume your processing at a later time, picking up where you left off.  We call this process *checkpointing*.

While you could write code directly using the `EventHubConsumerClient` or `PartitionReceiver` to handle these cases, the Event Hubs client library offers a set of processor types intended help.

## What does a processor do?

An event processor is a stand-alone client for consuming events in a robust, durable, and scalable way that is suitable for the majority of production scenarios. The key features of an event processor are:

- Reading and processing events across all partitions of an Event Hub at scale with resilience to transient failures and intermittent network issues.

- Processing events cooperatively, where multiple processors dynamically distribute and share the responsibility in the context of a consumer group, gracefully managing the load as processors are added and removed from the group.

- Managing checkpoints and state for processing in a durable manner by interacting with a data store.

The `EventProcessorClient` is an opinionated implementation of an event processor built using Azure Storage blobs to handle storing the state that's used during the load balancing and checkpointing operations.  For many developers, it covers their needs well.  However, some application scenarios require more control to handle higher throughput or specialized needs.  For those scenarios, the `EventProcessor<TPartition>` exposes the lower-level machinery needed to build a custom processor that is tuned for the needs of your application.

## Building an event processor with EventProcessor&lt;TPartition&gt;

The [EventProcessor&lt;TPartition&gt;](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.primitives.eventprocessor-1) serves as a base for creating a custom event processor.  It fills a role similar to the `EventProcessorClient`, but also offers native batch processing, the ability to customize data storage, and a greater level of control over communication with the Event Hubs service.  `EventProcessor<TPartition>` is an abstract class, which has five methods for which you'll need to provide implementations.  If you've used the `EventProcessorClient`, the first two will be familiar to you:

- `OnProcessingEventBatchAsync`: The actual "business logic" of your processor.  This is similar to the `ProcessEvent` event exposed by `EventProcessorClient`.
- `OnProcessingErrorAsync`: A handler that can be used to observe exceptions from inside the machinery of the EventProcessor itself.  This is similar to the `ProcessError` event exposed by `EventProcessorClient`.

The remaining three deal with checkpointing and load balancing:

- `ListOwnershipAsync`: Used by load balancing to see which partitions have been assigned to which processors.
- `ClaimOwnershipAsync`: Used by load balancing to grab ownership of a partition (which may or may not be assigned to another processor).
- `ListCheckpointsAsync`: Exists only for backwards compatibility and is called only when the `GetCheckpointAsync` method is not overridden.  For more efficient operation, it is recommended to implement `GetCheckpointAsync` and throw from `ListCheckpointsAsync`

There are also three methods that you are not required to implement, but may find useful to do so:

- `GetCheckpontAsync`: Used to query storage for a specific checkpoint.  This method is meant to supersede `ListCheckpointsAsync` and we recommend implementing it for efficiency.

- `OnInitializingPartitionAsync`: A handler that can be used to observe when the event processor takes ownership of a partition and is preparing to start processing its events.

- `OnPartitionProcessingStoppedAsync`: A handler that can be used to observe when the event processor loses ownership of a partition and is no longer processing its events.

In this sample, we will build our custom event processor using Azure Blob Storage to store checkpoint and load balancing state.  We'll encapsulate the storage integration and core operations in a base class, `AzureBlobStorageEventProcessor`, that we can reuse with for different application scenarios.

```C# Snippet:EventHubs_Sample08_AzureBlobStorageEventProcessor
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
```

## Using the custom processor

The `AzureBlobStorageEventProcessor` above is abstract because we did not implement any of the `On*` methods.  By separating the logic for state management and event processing, we can leverage `AzureBlobStorageEventProcessor` to build many different processors, each with their own business logic, by extending `AzureBlobStorageEventProcessor` and implementing `OnProcessingEventBatchAsync` and `OnProcessingErrorAsync`.

Here's a simple processor that just outputs the body of events received in a batch and then creates a checkpoint so they are not processed again:

```C# Snippet:EventHubs_Sample08_CustomProcessor
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
```

This should look familiar if you've used `EventProcessorClient` before, but there are a few small differences you need to be aware of:

- The processor works in batches, so when you construct it you need to specify the maximum number of events you'll want to process at once, using the `eventBatchMaximumCount` parameter.  The `IEnumerable<EventData>` that is passed `OnProcessingEventBatchAsync` to will never contain more items than this maximum count, but may contain fewer.

- If there are fewer unprocessed messages than `eventBatchMaximumCount` the processor also allows for a maximum amount of time that it will wait for more events to become available.  By default, this is 60 seconds, but can be controlled by setting the `MaximumWaitTime` property of the `EventProcessorOptions` parameter.  If this is set to `null` it means that the processor will forever until it has received some events.

- If `MaximumWaitTime` is set, `OnProcessingEventBatchAsync` will be called even if no events have been read.  This can be useful when you want to be sure that your `OnProcessingEventBatchAsync` method is invoked on a regular cadence, such as for sending heartbeats to a health check.  In this case, the `IEnumerable<EventData>` will contain zero events.

- The partition object passed to `OnProcessingErrorAsync` may be `null`.  This happens when the exception is not tied to a specific partition (for example, if an exception was thrown by `ListOwnershipAsync`, it will not be tied to a specific partition and so the partition context will be `null` when the error handler is called), so we need to guard for that case as well.

For a step-by-step discussion of the concepts discussed in this sample, please see the [Building A Custom Event Hubs Event Processor with .NET](https://devblogs.microsoft.com/azure-sdk/custom-event-processor/) article on the [Azure SDK blog](https://devblogs.microsoft.com/azure-sdk).  More detail on the design and philosophy of `EventProcessor<TPartition>` can be found in the [EventProcessor&lt;TPartition&gt; design document](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/design/proposal-event-processor%7BT%7D.md).
