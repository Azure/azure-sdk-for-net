# Processing Events in Batches

This sample demonstrates how events can be processed in batches rather than individually.  To begin, please ensure that you're familiar with the items discussed in the [Processing Events ](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample04_ProcessingEvents.md) sample.  You'll also need to have the prerequisites and connection string information available, as discussed in the [Getting started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples#getting-started) section of the README.

## Extending `EventProcessorClient`

The approach used by the `EventProcessorClient` of emitting events to the "ProcessEvents" handler is optimized for scenarios where an application wants to eagerly process each event individually as they are available, rather than treating them as a group.  For scenarios where it is more efficient to process events as a batch, it is often advantageous to extend the processor and override the `OnProcessingEventBatchAsync` method rather than using the "ProcessEvent" handler.  

This example will create a simple processor extension that can process events as a batch.

```C# Snippet:EventHubs_Processor_Sample07_ProcessByBatch_Processor
public class SimpleBatchProcessorClient : EventProcessorClient
{
    // This example uses a connection string, so only the single constructor
    // was implemented; applications will need to shadow each constructor of
    // the EventProcessorClient that they are using.

    public SimpleBatchProcessorClient(BlobContainerClient checkpointStore,
                                      string consumerGroup,
                                      string connectionString,
                                      string eventHubName,
                                      EventProcessorClientOptions clientOptions = default)
        : base(checkpointStore, consumerGroup, connectionString, eventHubName, clientOptions)
    {
        // Though it will not be called, the EventProcessorClient requires an
        // assigned process event handler to start processing.  Assign a no-op here
        // to satisfy validation.

        ProcessEventAsync += _ => Task.CompletedTask;
    }

    protected override async Task OnProcessingEventBatchAsync(IEnumerable<EventData> events,
                                                              EventProcessorPartition partition,
                                                              CancellationToken cancellationToken)
    {
        // Like the event handler, it is very important that you guard
        // against exceptions in this override; the processor does not
        // have enough understanding of your code to determine the correct
        // action to take.  Any exceptions from this method go uncaught by
        // the processor and will NOT be handled and will fault the partition
        // processing task.

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

            await UpdateCheckpointAsync(partition.PartitionId, events.Last(), cancellationToken);
        }
        catch (Exception ex)
        {
            Application.HandleProcessingException(events, partition.PartitionId, ex);
        }

        // Calling the base would only invoke the process event handler and provide no
        // value; we will not call it here.
    }
}
```

The custom batch processor can be used in the same manner as the standard `EventProcessorClient`, with the exception that it is not necessary to manage the "ProcessEvents" handler.

```C# Snippet:EventHubs_Processor_Sample07_ProcessByBatch_Usage
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var storageClient = new BlobContainerClient(
    storageConnectionString,
    blobContainerName);

var processor = new SimpleBatchProcessorClient(
    storageClient,
    consumerGroup,
    eventHubsConnectionString,
    eventHubName);

try
{
    using var cancellationSource = new CancellationTokenSource();
    cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

    // The error handler implementation is not relevant in this sample;
    // for illustration, it is delegating the implementation to the
    // host application.

    processor.ProcessErrorAsync += Application.ProcessorErrorHandler;

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
        // This may take up to the length of time defined
        // as part of the configured TryTimeout of the processor;
        // by default, this is 60 seconds.

        await processor.StopProcessingAsync();
    }
}
catch
{
    // If this block is invoked, then something external to the
    // processor was the source of the exception.
}
finally
{
    // It is encouraged that you unregister your handlers when you have
    // finished using the Event Processor to ensure proper cleanup.

    processor.ProcessErrorAsync -= Application.ProcessorErrorHandler;
}
```

## Extending `EventProcessor<TPartition>`

An important consideration is that batching with the `EventProcessorClient` may boost throughput for many batch scenarios, but more demanding applications may need greater control and less overhead to meet their higher throughput or specialized needs - that's where the [EventProcessor&lt;TPartition&gt;](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample02_EventHubsClients.md) from the [Azure.Messaging.EventHubs](https://www.nuget.org/packages/Azure.Messaging.EventHubs) package is intended to help.  An example of customizing the `EventProcessor<TPartition>` can be found in the sample "[Building a custom processor with EventProcessor&lt;TPartition&gt;](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample08_CustomEventProcessor.md)".  More information on the design and philosophy behind the `EventProcessor<TPartition>` can be found in its [design document](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/design/proposal-event-processor%7BT%7D.md).