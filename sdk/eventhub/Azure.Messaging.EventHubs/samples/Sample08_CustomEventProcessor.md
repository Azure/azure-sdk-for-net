# Building a custom processor with PluggableCheckpointStoreEventProcessor&lt;TPartition&gt;

This sample demonstrates using `PluggableCheckpointStoreEventProcessor<TPartition>` to build a custom event processor which uses an existing `CheckpointStore` implementation to manage load balancing and checkpoint state.  This is commonly used when an application's processing needs are biased towards batches of events.  For the majority of scenarios, we recommend using the [EventProcessorClient](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples) from the [Azure.Messaging.EventHubs.Processor](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor) package over implementing your own processor.

## Table of contents

- [Reading events](#reading-events)
- [What does a processor do?](#what-does-a-processor-do)
- [Building the custom event processor](#building-the-custom-event-processor)
- [Using the custom processor](#using-the-custom-processor)
- [Useful customizations](#useful-customizations)
    - [Overriding checkpoints](#overriding-checkpoints)
    - [Static partition assignment](#static-partition-assignment)
- [Extending EventProcessor&lt;TPartition&gt;](#extending-eventprocessortpartition)

## Reading events

When reading events, a consumer is tied to a specific partition of an Event Hub and reads the events in order from that partition.  This means, to read all events from an Event Hub, you'll need one consumer per partition reading events.  For some workloads where the processing can be intensive, you may want these consumers spread out across multiple machines or to dynamically add and remove consumers as the rate of incoming events increases or decreases.  We call this process *load balancing*.  In addition, you'll want to make sure that if one of your consumers has a problem (such as the machine it is running on crashes) you're able to resume your processing at a later time, picking up where you left off.  We call this process *checkpointing*.

While you could write code directly using the `EventHubConsumerClient` or `PartitionReceiver` to handle these cases, the Event Hubs client library offers a set of processor types intended help.

## What does a processor do?

An event processor is a stand-alone client for consuming events in a robust, durable, and scalable way that is suitable for the majority of production scenarios. The key features of an event processor are:

- Reading and processing events across all partitions of an Event Hub at scale with resilience to transient failures and intermittent network issues.

- Processing events cooperatively, where multiple processors dynamically distribute and share the responsibility in the context of a consumer group, gracefully managing the load as processors are added and removed from the group.

- Managing checkpoints and state for processing in a durable manner by interacting with a data store.

The `EventProcessorClient` is an opinionated implementation of an event processor built using Azure Blob Storage to handle storing the state that is used during the load balancing and checkpointing operations.  For many developers, it covers their needs well.  However, some application scenarios require more control to handle higher throughput or specialized needs.  For those scenarios, the `PluggableCheckpointStoreEventProcessor<TPartition>` and `EventProcessor<TPartition>` types exposes lower-level machinery needed to build a custom processor that is tuned for the needs of your application.

## Building the custom event processor

The `PluggableCheckpointStoreEventProcessor<TPartition>` serves as a base for creating a custom event processor that delegates to an existing `CheckpointStore` for managing checkpoint and load balancing data.  It fills a role similar to the `EventProcessorClient`, but also offers native batch processing, the ability to customize data storage, and a greater level of control over communication with the Event Hubs service.  `EventProcessor<TPartition>` is an abstract class, which has two methods for which you'll need to provide implementations.  If you've used the `EventProcessorClient`, these will be familiar to you:

- `OnProcessingEventBatchAsync`: The actual "business logic" of your processor.  This is similar to the `ProcessEventAsync` event exposed by `EventProcessorClient`.

- `OnProcessingErrorAsync`: A handler for observing exceptions from inside the machinery of the event processor itself, which allows your application to detect failure patterns where it may need to intercede.  This is similar to the `ProcessErrorAsync` event exposed by `EventProcessorClient`.

There are also two methods that you are not required to implement, but may find useful to do so:

- `OnInitializingPartitionAsync`: A handler that can be used to observe when the event processor takes ownership of a partition and is preparing to start processing its events.

- `OnPartitionProcessingStoppedAsync`: A handler that can be used to observe when the event processor loses ownership of a partition and is no longer processing its events.

In this sample, we will build a custom event processor which uses Azure Blob Storage for persisting checkpoint and load balancing data.  To do so, we'll make use of the `BlobCheckpointStore` implementation available in the [Azure.Messaging.EventHubs.Processor](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor) package.  Our custom processor will just output the body of events received in a batch and then create a checkpoint so events are not processed again.

```C# Snippet:EventHubs_Sample08_CustomProcessor
public class CustomProcessor : PluggableCheckpointStoreEventProcessor<EventProcessorPartition>
{
    // This example uses a connection string, so only the single constructor
    // was implemented; applications will need to shadow each constructor of
    // the PluggableCheckpointStoreEventProcessor that they are using.

    public CustomProcessor(
        BlobContainerClient storageClient,
        int eventBatchMaximumCount,
        string consumerGroup,
        string fullyQualifiedNamespace,
        string eventHubName,
        TokenCredential credential,
        EventProcessorOptions clientOptions = default)
            : base(
                new BlobCheckpointStore(storageClient),
                eventBatchMaximumCount,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential,
                clientOptions)
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
                await UpdateCheckpointAsync(
                    partition.PartitionId,
                    CheckpointPosition.FromEvent(lastEvent),
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
            //
            // In this case, the partition processing task will fault and be restarted
            // from the last recorded checkpoint.

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
            //
            // In this case, unhandled exceptions will not impact the processor
            // operation but will go unobserved, hiding potential application problems.

            Console.WriteLine($"Exception while processing events: { ex }");
        }

        return Task.CompletedTask;
    }

    protected override Task OnInitializingPartitionAsync(
        EventProcessorPartition partition,
        CancellationToken cancellationToken)
    {
        try
        {
            Console.WriteLine($"Initializing partition { partition.PartitionId }");
        }
        catch (Exception ex)
        {
            // It is very important that you always guard against exceptions in
            // your handler code; the processor does not have enough
            // understanding of your code to determine the correct action to take.
            // Any exceptions from your handlers go uncaught by the processor and
            // will NOT be redirected to the error handler.
            //
            // In this case, the partition processing task will fault and the
            // partition will be initialized again.

            Console.WriteLine($"Exception while initializing a partition: { ex }");
        }

        return Task.CompletedTask;
    }

    protected override Task OnPartitionProcessingStoppedAsync(
        EventProcessorPartition partition,
        ProcessingStoppedReason reason,
        CancellationToken cancellationToken)
    {
        try
        {
            Console.WriteLine(
                $"No longer processing partition { partition.PartitionId } " +
                $"because { reason }");
        }
        catch (Exception ex)
        {
            // It is very important that you always guard against exceptions in
            // your handler code; the processor does not have enough
            // understanding of your code to determine the correct action to take.
            // Any exceptions from your handlers go uncaught by the processor and
            // will NOT be redirected to the error handler.
            //
            // In this case, unhandled exceptions will not impact the processor
            // operation but will go unobserved, hiding potential application problems.

            Console.WriteLine($"Exception while stopping processing for a partition: { ex }");
        }

        return Task.CompletedTask;
    }
}
```

## Using the custom processor

The `CustomProcessor` is used by instantiating it and using the `StartProcessingAsync` and `StopProcessingAsync` methods to control its activity.  Starting the processor does not block; if your application is not performing other activities, it will need to ensure that the host does not exit until you're ready to stop processing events.

```C# Snippet:EventHubs_Sample08_CustomProcessorUse
var credential = new DefaultAzureCredential();

var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
{
    BlobContainerName = blobContainerName
};

var storageClient = new BlobContainerClient(
    blobUriBuilder.ToUri(),
    credential);

var maximumBatchSize = 100;

var processor = new CustomProcessor(
    storageClient,
    maximumBatchSize,
    consumerGroup,
    fullyQualifiedNamespace,
    eventHubName,
    credential);

using var cancellationSource = new CancellationTokenSource();
cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

// Starting the processor does not block when starting; delay
// until the cancellation token is signaled.

try
{
    await processor.StartProcessingAsync(cancellationSource.Token);
    await Task.Delay(Timeout.Infinite, cancellationSource.Token);
}
catch (TaskCanceledException)
{
    // This is expected if the cancellation token is
    // signaled.
}
finally
{
    // Stopping may take up to the length of time defined
    // as the TryTimeout configured for the processor;
    // By default, this is 60 seconds.

    await processor.StopProcessingAsync();
}
```

This should look familiar if you've used `EventProcessorClient` before, but there are a few small differences you need to be aware of:

- The processor works in batches, so when you construct it you need to specify the maximum number of events you'll want to process at once, using the `eventBatchMaximumCount` parameter.  The `IEnumerable<EventData>` that is passed `OnProcessingEventBatchAsync` to will never contain more items than this maximum count, but may contain fewer.

- If `MaximumWaitTime` is set to a value other than `null`, the processor will ensure that `OnProcessingEventBatchAsync` is invoked within that interval whether events were available or not.  This can be useful when you want to be sure that your `OnProcessingEventBatchAsync` method is invoked on a regular cadence, such as for sending heartbeats to a health check.  When events are read, `OnProcessingEventBatchAsync` will be invoked immediately.  When no events were available, the `IEnumerable<EventData>` will contain zero events.   If `MaximumWaitTime` is set to `null`, the processor will only invoke `OnProcessingEventBatchAsync` when events have been read.

- The partition object passed to `OnProcessingErrorAsync` may be `null`.  This happens when the exception is not tied to a specific partition (for example, if an exception was thrown during load balancing), so implementations need to account for that possibility.

## Useful customizations

The customizations in this sample are demonstrated using the `PluggableCheckpointStoreEventProcessor<TPartition>` as a base, but can be used with any processor derrived from `EventProcessor<TPartition>`, including the `EventProcessorClient` from the from the [Azure.Messaging.EventHubs.Processor](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor) package.

### Overriding checkpoints

During normal processor operation, when a partition is being initialized any checkpoint found for it becomes the authoritative position to start reading from.  If no checkpoint found, the global [DefaultStartingPosition](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.primitives.eventprocessoroptions.defaultstartingposition) from the options is used.

In many scenarios, it can be helpful to apply logic to a specific partition for overriding the found checkpoint or customizing the default starting position.  This can be accomplished by overriding the `GetCheckpointAsync` method of the processor.

```C# Snippet:EventHubs_Sample08_CustomCheckpointProcessor
public class CustomCheckpointProcessor : PluggableCheckpointStoreEventProcessor<EventProcessorPartition>
{
    // This example uses a connection string, so only the single constructor
    // was implemented; applications will need to shadow each constructor of
    // the PluggableCheckpointStoreEventProcessor that they are using.

    public CustomCheckpointProcessor(
        BlobContainerClient storageClient,
        int eventBatchMaximumCount,
        string consumerGroup,
        string connectionString,
        string eventHubName,
        EventProcessorOptions clientOptions = default)
            : base(
                new BlobCheckpointStore(storageClient),
                eventBatchMaximumCount,
                consumerGroup,
                connectionString,
                eventHubName,
                clientOptions)
    {
    }

    // Any checkpoint returned by GetCheckpointAsync is treated as the authoritative
    // starting point for the partition; if the return value is null, then the
    // global DefaultStartingPosition specified by the options is used.

    protected async override Task<EventProcessorCheckpoint> GetCheckpointAsync(
        string partitionId,
        CancellationToken cancellationToken)
    {
        EventProcessorCheckpoint checkpoint =
            await base.GetCheckpointAsync(partitionId, cancellationToken);

        // If there was no checkpoint, set the starting point for reading from
        // this specific partition to 5 minutes ago.

        if (checkpoint == null)
        {
            var startingTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(5));

            checkpoint = new EventProcessorCheckpoint
            {
               FullyQualifiedNamespace = this.FullyQualifiedNamespace,
               EventHubName = this.EventHubName,
               ConsumerGroup = this.ConsumerGroup,
               PartitionId = partitionId,
               StartingPosition = EventPosition.FromEnqueuedTime(startingTime)
            };
        }

        return checkpoint;
    }

    // The logic for processing events and handling errors is not
    // interesting for this example; assume that responsibility is
    // delegated to the application.

    protected override Task OnProcessingEventBatchAsync(
        IEnumerable<EventData> events,
        EventProcessorPartition partition,
        CancellationToken cancellationToken) =>
            Application.DoEventProcessing(events, partition.PartitionId, cancellationToken);

    protected override Task OnProcessingErrorAsync(
        Exception exception,
        EventProcessorPartition partition,
        string operationDescription,
        CancellationToken cancellationToken) =>
            Application.HandleErrorAsync(exception, partition.PartitionId, operationDescription, cancellationToken);
}
```

### Static partition assignment

One of the core behaviors of an event processor is that it coordinates with other processors with the same consumer group and Event Hub assigned.  They will share work between them such that each owns an equal share of partitions and will redistribute partitions as needed when the number of processors in the group changes.

In some scenarios, it is beneficial to assign a static set of partitions to a specific processor ensuring a consistent and predictable distribution and preventing partitions from migrating to a new host if a node is temporarily unavailable.  This is often useful when processors are hosted in an orchestrated environment, such as Kubernetes or Service Fabric, where the orchestrator owns responsibility for keeping nodes healthy.

The most effective way to restrict an event processor to an assigned set of partitions is to lie to it about the environment, restricting its view to only its own partitions by overriding `ListPartitionIdsAsync`, `ListOwnershipAsync`, and `ClaimOwnershipAsync`.

```C# Snippet:EventHubs_Sample08_StaticPartitionProcessor
public class StaticPartitionProcessor : PluggableCheckpointStoreEventProcessor<EventProcessorPartition>
{
    private readonly string[] _assignedPartitions;

    // This example uses a connection string, so only the single constructor
    // was implemented; applications will need to shadow each constructor of
    // the PluggableCheckpointStoreEventProcessor that they are using.

    public StaticPartitionProcessor(
        BlobContainerClient storageClient,
        string[] assignedPartitions,
        int eventBatchMaximumCount,
        string consumerGroup,
        string connectionString,
        string eventHubName,
        EventProcessorOptions clientOptions = default)
            : base(
                new BlobCheckpointStore(storageClient),
                eventBatchMaximumCount,
                consumerGroup,
                connectionString,
                eventHubName,
                clientOptions)
    {
        _assignedPartitions = assignedPartitions
            ?? throw new ArgumentNullException(nameof(assignedPartitions));
    }

    // To simplify logic, tell the processor that only its assigned
    // partitions exist for the Event Hub.

    protected override Task<string[]> ListPartitionIdsAsync(
        EventHubConnection connection,
        CancellationToken cancellationToken) =>
            Task.FromResult(_assignedPartitions);

    // Tell the processor that it owns all of the available partitions for the Event Hub.

    protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(
        CancellationToken cancellationToken) =>
            Task.FromResult(
                _assignedPartitions.Select(partition =>
                    new EventProcessorPartitionOwnership
                    {
                        FullyQualifiedNamespace = this.FullyQualifiedNamespace,
                        EventHubName = this.EventHubName,
                        ConsumerGroup = this.ConsumerGroup,
                        PartitionId = partition,
                        OwnerIdentifier = this.Identifier,
                        LastModifiedTime = DateTimeOffset.UtcNow
                    }));

    // Accept any ownership claims attempted by the processor; this allows the processor to
    // simulate renewing ownership so that it continues to own all of its assigned partitions.

    protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(
        IEnumerable<EventProcessorPartitionOwnership> desiredOwnership,
        CancellationToken cancellationToken) =>
             Task.FromResult(desiredOwnership.Select(ownership =>
            {
                ownership.LastModifiedTime = DateTimeOffset.UtcNow;
                return ownership;
            }));

    // The logic for processing events and handling errors is not
    // interesting for this example; assume that responsibility is
    // delegated to the application.

    protected override Task OnProcessingEventBatchAsync(
        IEnumerable<EventData> events,
        EventProcessorPartition partition,
        CancellationToken cancellationToken) =>
            Application.DoEventProcessing(events, partition.PartitionId, cancellationToken);

    protected override Task OnProcessingErrorAsync(
        Exception exception,
        EventProcessorPartition partition,
        string operationDescription,
        CancellationToken cancellationToken) =>
            Application.HandleErrorAsync(exception, partition.PartitionId, operationDescription, cancellationToken);
}
```

## Extending EventProcessor&lt;TPartition&gt;

For the majority of scenarios, extending `PluggableCheckpointStoreEventProcessor<TPartition>` will be the right approach, but more demanding applications may need greater control over storage operations to meet their higher throughput or specialized needs - that's where the [EventProcessor&lt;TPartition&gt;](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample02_EventHubsClients.md) from the [Azure.Messaging.EventHubs](https://www.nuget.org/packages/Azure.Messaging.EventHubs) package is intended to help.  A ste-by-step example of customizing the `EventProcessor<TPartition>` is discussed in the article "[Building A Custom Event Hubs Event Processor with .NET](https://devblogs.microsoft.com/azure-sdk/custom-event-processor/)" on the [Azure SDK blog](https://devblogs.microsoft.com/azure-sdk).  More information on the design and philosophy behind the `EventProcessor<TPartition>` can be found in its [design document](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/design/proposal-event-processor%7BT%7D.md).
