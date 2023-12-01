# Processing Events in Batches

This sample demonstrates how events can be processed in batches rather than individually.  To begin, please ensure that you're familiar with the items discussed in the [Processing Events ](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample04_ProcessingEvents.md) sample.  You'll also need to have the prerequisites and connection string information available, as discussed in the [Getting started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples#getting-started) section of the README.

## Table of contents

- [Extending `PluggableCheckpointStoreEventProcessor<TPartition>`](#extending-pluggablecheckpointstoreeventprocessortpartition)
- [Useful customizations](#useful-customizations)
- [Extending EventProcessor&lt;TPartition&gt;](#extending-eventprocessortpartition)

## Extending `PluggableCheckpointStoreEventProcessor<TPartition>`

The approach used by the `EventProcessorClient` of emitting events to the "ProcessEvents" handler is optimized for scenarios where an application wants to eagerly process each event individually as they are available, rather than treating them as a group.  For scenarios where it is more efficient to process events as a batch, it is often advantageous to extend the `PluggableCheckpointStoreEventProcessor<TPartition>` and override the `OnProcessingEventBatchAsync` method for batch support.  

This example will create a simple processor extension that can process events as a batch.

```C# Snippet:EventHubs_Processor_Sample07_ProcessByBatch_Processor
public class SimpleBatchProcessor : PluggableCheckpointStoreEventProcessor<EventProcessorPartition>
{
    // This example uses a connection string, so only the single constructor
    // was implemented; applications will need to shadow each constructor of
    // the EventProcessorClient that they are using.

    public SimpleBatchProcessor(CheckpointStore checkpointStore,
                                int eventBatchMaximumCount,
                                string consumerGroup,
                                string connectionString,
                                string eventHubName,
                                EventProcessorOptions clientOptions = default)
        : base(
            checkpointStore,
            eventBatchMaximumCount,
            consumerGroup,
            connectionString,
            eventHubName,
            clientOptions)
    {
    }

    protected override async Task OnProcessingEventBatchAsync(IEnumerable<EventData> events,
                                                              EventProcessorPartition partition,
                                                              CancellationToken cancellationToken)
    {
        // Like the event handler, it is very important that you guard
        // against exceptions in this override; the processor does not
        // have enough understanding of your code to determine the correct
        // action to take.  Any exceptions from this method go uncaught by
        // the processor and will NOT be handled.  The partition processing
        // task will fault and be restarted from the last recorded checkpoint.

        try
        {
            // The implementation of how events are processed is not relevant in
            // this sample; for illustration, responsibility for managing the processing
            // of events is being delegated to the application.

            await Application.DispatchEventsForProcessing(
                    events,
                    partition.PartitionId,
                    cancellationToken);

            // Create a checkpoint based on the last event in the batch.

            var lastEvent = events.Last();

            await UpdateCheckpointAsync(
                partition.PartitionId,
                CheckpointPosition.FromEvent(lastEvent),
                cancellationToken);
        }
        catch (Exception ex)
        {
            Application.HandleProcessingException(events, partition.PartitionId, ex);
        }

        // Calling the base would only invoke the process event handler and provide no
        // value; we will not call it here.
    }

    protected async override Task OnProcessingErrorAsync(Exception exception,
                                                         EventProcessorPartition partition,
                                                         string operationDescription,
                                                         CancellationToken cancellationToken)
    {
        // Like the event handler, it is very important that you guard
        // against exceptions in this override; the processor does not
        // have enough understanding of your code to determine the correct
        // action to take.  Any exceptions from this method go uncaught by
        // the processor and will NOT be handled.  Unhandled exceptions will
        // not impact the processor operation but will go unobserved, hiding
        // potential application problems.

        try
        {
            await Application.HandleErrorAsync(
                exception,
                partition.PartitionId,
                operationDescription,
                cancellationToken);
        }
        catch (Exception ex)
        {
            Application.LogErrorHandlingFailure(ex);
        }
    }
}
```

The custom batch processor can be used in the same manner as the standard `EventProcessorClient`, with the exception that event handlers do not need to be managed.  

```C# Snippet:EventHubs_Processor_Sample07_ProcessByBatch_Usage
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var storageClient = new BlobContainerClient(
    storageConnectionString,
    blobContainerName);

var checkpointStore = new BlobCheckpointStore(storageClient);
var maximumBatchSize = 100;

var processor = new SimpleBatchProcessor(
    checkpointStore,
    maximumBatchSize,
    consumerGroup,
    eventHubsConnectionString,
    eventHubName);

using var cancellationSource = new CancellationTokenSource();
cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

// There are no event handlers to set for the processor.  All logic
// normally associated with the processor event handlers is
// implemented directly via method override in the custom processor.

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

More detail and a deeper example of customizing `PluggableCheckpointStoreEventProcessor<TPartition>` can be found in the sample "[Building a custom processor with PluggableCheckpointStoreEventProcessor&lt;TPartition&gt;](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample08_CustomEventProcessor.md)". 

## Useful customizations

Some additional customizations for the `EventProcessorClient`, such as overriding checkpoints and static partition assignments can be found in the [Useful customizations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample08_CustomEventProcessor.md#useful-customizations) section of the custom processor example.

## Extending EventProcessor&lt;TPartition&gt;

For the majority of batch scenarios, extending `PluggableCheckpointStoreEventProcessor<TPartition>` will be the right approach, but more demanding applications may need greater control over storage operations to meet their higher throughput or specialized needs - that's where the [EventProcessor&lt;TPartition&gt;](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample02_EventHubsClients.md) from the [Azure.Messaging.EventHubs](https://www.nuget.org/packages/Azure.Messaging.EventHubs) package is intended to help.  A ste-by-step example of customizing the `EventProcessor<TPartition>` is discussed in the article "[Building A Custom Event Hubs Event Processor with .NET](https://devblogs.microsoft.com/azure-sdk/custom-event-processor/)" on the [Azure SDK blog](https://devblogs.microsoft.com/azure-sdk).  More information on the design and philosophy behind the `EventProcessor<TPartition>` can be found in its [design document](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/design/proposal-event-processor%7BT%7D.md).