# Hello World: Publishing and Processing Events

This sample demonstrates the basic flow of events through an Event Hub, with the goal of quickly allowing you to publish events and process events from the Event Hubs service.  To accomplish this, the `EventHubProducerClient` and `EventProcessorClient` types will be introduced, along with some of the core concepts of Event Hubs.

To begin, please ensure that you're familiar with the items discussed in the [Getting started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples#getting-started) section of the README and have the prerequisites, such as the connection string information, available.

## Table of contents

- [Client lifetime](#client-lifetime)
- [Publish events](#publish-events)
- [Process events](#process-events)

## Client lifetime

Each of the Event Hubs client types is safe to cache and use for the lifetime of the application, which is best practice when the application publishes or reads events regularly or semi-regularly. The clients are responsible for efficient resource management, working to keep resource usage low during periods of inactivity and manage health during periods of higher use.

For the `EventProcessorClient`, calling the `StopProcessingAsync` method when your application is closing will ensure that network resources and other unmanaged objects are cleaned up.  Calling  either the `CloseAsync` or `DisposeAsync` method on the `EventHubProducerClient` will perform the equivalent clean-up.

## Publish events

To publish events, we will make use of the `EventHubsProducerClient`.  Because this is the only area of our sample that will be publishing events, we will close the client once publishing has completed.  In the majority of real-world scenarios, closing the producer when the application exits is the preferred pattern.

So that we have something to process, our example will publish a full batch of events.  The `EventHubDataBatch` exists to ensure that a set of events can safely be published without exceeding the size allowed by the Event Hub.  The `EventDataBatch` queries the service to understand the maximum size and is responsible for accurately measuring each event as it is added to the batch.  When its `TryAdd` method returns `false`, the event is too large to fit into the batch.

```C# Snippet:EventHubs_Processor_Sample01_PublishEvents
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var producer = new EventHubProducerClient(connectionString, eventHubName);

try
{
    using EventDataBatch eventBatch = await producer.CreateBatchAsync();

    for (var counter = 0; counter < int.MaxValue; ++counter)
    {
        var eventBody = new BinaryData($"Event Number: { counter }");
        var eventData = new EventData(eventBody);

        if (!eventBatch.TryAdd(eventData))
        {
            // At this point, the batch is full but our last event was not
            // accepted.  For our purposes, the event is unimportant so we
            // will intentionally ignore it.  In a real-world scenario, a
            // decision would have to be made as to whether the event should
            // be dropped or published on its own.

            break;
        }
    }

    // When the producer publishes the event, it will receive an
    // acknowledgment from the Event Hubs service; so long as there is no
    // exception thrown by this call, the service assumes responsibility for
    // delivery.  Your event data will be published to one of the Event Hub
    // partitions, though there may be a (very) slight delay until it is
    // available to be consumed.

    await producer.SendAsync(eventBatch);
}
catch
{
    // Transient failures will be automatically retried as part of the
    // operation. If this block is invoked, then the exception was either
    // fatal or all retries were exhausted without a successful publish.
}
finally
{
   await producer.CloseAsync();
}
```

## Process events

Now that the events have been published, we'll process them using the `EventProcessorClient`.  It's important to note that because events are not removed when reading, you are likely to see events that had been previously published as well as those from the batch that we just sent, if you're using an existing Event Hub.

The `EventProcessorClient` is associated with a specific Event Hub and [consumer group](https://learn.microsoft.com/azure/event-hubs/event-hubs-features#consumer-groups).  Conceptually, the consumer group is a label that identifies one or more event consumers as a set.  Often, consumer groups are named after the responsibility of the consumer in an application, such as "Telemetry" or "OrderProcessing".  When an Event Hub is created, a default consumer group is created for it.  The default group, named "$Default", is what we'll be using for illustration.

When events are published, they will continue to exist in the Event Hub and be available for consuming until they reach an age greater than the [retention period](https://learn.microsoft.com/azure/event-hubs/event-hubs-faq#what-is-the-maximum-retention-period-for-events).  Once removed, the events are no longer available to be read and cannot be recovered.  Though the Event Hubs service is free to remove events older than the retention period, it does not do so deterministically; there is no guarantee of when events will be removed.

Each `EventProcessorClient` has its own full view of the events each partition of an Event Hub, meaning that events are available to all processors and are not removed from the partition when a processor reads them.  This allows for one or more of the different Event Hub clients to read and process events from the partition at different speeds and beginning with different events without interfering with one another.

An `EventProcessorClient` works cooperatively with other event processors configured for the same Event Hub and consumer group.  The processors will cooperatively distribute the responsibility for partitions among themselves to share work.  If new processor instances appear or existing ones are removed, the work will be automatically redistributed among those processors which are active.

In this example, our processor will work as a single instance and will make use of the default consumer group for the associated Event Hub.

```C# Snippet:EventHubs_Processor_Sample01_ProcessEvents
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var storageClient = new BlobContainerClient(
    storageConnectionString,
    blobContainerName);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    eventHubsConnectionString,
    eventHubName);

var partitionEventCount = new ConcurrentDictionary<string, int>();

async Task processEventHandler(ProcessEventArgs args)
{
    try
    {
        // If the cancellation token is signaled, then the
        // processor has been asked to stop.  It will invoke
        // this handler with any events that were in flight;
        // these will not be lost if not processed.
        //
        // It is up to the handler to decide whether to take
        // action to process the event or to cancel immediately.

        if (args.CancellationToken.IsCancellationRequested)
        {
            return;
        }

        string partition = args.Partition.PartitionId;
        byte[] eventBody = args.Data.EventBody.ToArray();
        Debug.WriteLine($"Event from partition { partition } with length { eventBody.Length }.");

        int eventsSinceLastCheckpoint = partitionEventCount.AddOrUpdate(
            key: partition,
            addValue: 1,
            updateValueFactory: (_, currentCount) => currentCount + 1);

        if (eventsSinceLastCheckpoint >= 50)
        {
            await args.UpdateCheckpointAsync();
            partitionEventCount[partition] = 0;
        }
    }
    catch
    {
        // It is very important that you always guard against
        // exceptions in your handler code; the processor does
        // not have enough understanding of your code to
        // determine the correct action to take.  Any
        // exceptions from your handlers go uncaught by
        // the processor and will NOT be redirected to
        // the error handler.
    }
}

Task processErrorHandler(ProcessErrorEventArgs args)
{
    try
    {
        Debug.WriteLine("Error in the EventProcessorClient");
        Debug.WriteLine($"\tOperation: { args.Operation }");
        Debug.WriteLine($"\tException: { args.Exception }");
        Debug.WriteLine("");
    }
    catch
    {
        // It is very important that you always guard against
        // exceptions in your handler code; the processor does
        // not have enough understanding of your code to
        // determine the correct action to take.  Any
        // exceptions from your handlers go uncaught by
        // the processor and will NOT be handled in any
        // way.
    }

    return Task.CompletedTask;
}

try
{
    using var cancellationSource = new CancellationTokenSource();
    cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

    processor.ProcessEventAsync += processEventHandler;
    processor.ProcessErrorAsync += processErrorHandler;

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
    // The processor will automatically attempt to recover from any
    // failures, either transient or fatal, and continue processing.
    // Errors in the processor's operation will be surfaced through
    // its error handler.
    //
    // If this block is invoked, then something external to the
    // processor was the source of the exception.
}
finally
{
   // It is encouraged that you unregister your handlers when you have
   // finished using the Event Processor to ensure proper cleanup.  This
   // is especially important when using lambda expressions or handlers
   // in any form that may contain closure scopes or hold other references.

   processor.ProcessEventAsync -= processEventHandler;
   processor.ProcessErrorAsync -= processErrorHandler;
}
```
