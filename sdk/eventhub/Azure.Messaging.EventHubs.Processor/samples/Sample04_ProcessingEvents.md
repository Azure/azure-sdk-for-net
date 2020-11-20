# Processing Events

This sample demonstrates scenarios for processing events read from the Event Hubs service.  To begin, please ensure that you're familiar with the items discussed in the [Event Processor Handlers](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample03_EventProcessorHandlers.md) sample.  You'll also need to have the prerequisites and connection string information available, as discussed in the [Getting started](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples#getting-started) section of the README.

## Client types

The `EventProcessorClient` is intended to provide a robust and resilient client for processing events from an Event Hub and is capable of automatically managing the recovery process for transient failures.  It will also collaborate with other `EventProcessorClient` instances to dynamically distribute and share processing responsibility as processors are added and removed from the group.

The `EventProcessorClient` is safe to cache and use for the lifetime of the application, which is best practice when the application processes events regularly or semi-regularly. The processor is responsible for efficient resource management, working to keep resource usage low during periods of inactivity and manage health during periods of higher use. Calling the `StopProcessingAsync` method when your application is closing will ensure that network resources and other unmanaged objects are cleaned up. 

## Event lifetime

When events are published, they will continue to exist in the Event Hub and be available for consuming until they reach an age greater than the [retention period](https://docs.microsoft.com//azure/event-hubs/event-hubs-faq#what-is-the-maximum-retention-period-for-events).  Once removed, the events are no longer available to be read and cannot be recovered.  Though the Event Hubs service is free to remove events older than the retention period, it does not do so deterministically; there is no guarantee of when events will be removed.

## Processing and consumer groups

An `EventProcessorClient` is associated with a specific Event Hub and [consumer group](https://docs.microsoft.com/azure/event-hubs/event-hubs-features#consumer-groups).  Conceptually, the consumer group is a label that identifies one or more event consumers as a set.  Often, consumer groups are named after the responsibility of the consumer in an application, such as "Telemetry" or "OrderProcessing".  When an Event Hub is created, a default consumer group is created for it, named "$Default." These examples will make use of the default consumer group for illustration.

## Processing and partitions

Every event that is published is sent to one of the [partitions](https://docs.microsoft.com/azure/architecture/reference-architectures/event-hubs/partitioning-in-event-hubs-and-kafka) of the Event Hub. When processing events, the `EventProcessorClient` will take ownership over a set of partitions to process, treating each as an independent unit of work.  This allows the processor to isolate partitions from one another, helping to ensure that a failure in one partition does not impact processing for another.  

## Checkpointing

Checkpointing is a process by which a processor records its position in the event stream for an Event Hub partition, marking which events have been processed.  The `EventProcessorClient` uses Blob Storage to track checkpoints for an Event Hub, consumer group, and partition combination.  This information is shared with other processors configured to process the Event Hub for the same consumer group, allowing processors to avoid reprocessing events.

When an event processor connects, it will begin reading events at the checkpoint that was previously persisted by the last processor of that partition in that consumer group, if one exists.  As an event processor reads and acts on events in the partition, it should periodically create checkpoints to both mark the events as "complete" by downstream applications and to provide resiliency should an event processor or the environment hosting it fail.   Should it be necessary, it is possible to reprocess events that were previously marked as "complete" by specifying an earlier offset through this checkpointing process.

## Load balancing

If more than one `EventProcessorClient` is configured to process an Event Hub, belongs to the same consumer group, and make use of the same Blob Storage container, those processors will collaborate using Blob storage to share responsibility for processing the partitions of the Event Hub.  Each `EventProcessorClient` will claim ownership of partitions until each had an equal share; the processors will ensure that each partition belongs to only a single processor.  As processors are added or removed from the group, the partitions will be redistributed to keep the work even. 

An important call-out is that Event Hubs has an [at-least-once delivery guarantee](https://docs.microsoft.com/azure/event-grid/compare-messaging-services#event-hubs); it is highly recommended to ensure that your processing is resilient to event duplication in whatever way is appropriate for your application scenarios.  

This can be observed when a processor is starting up, as it will attempt to claim ownership of partitions by taking those that do not currently have owners.  In the case where a processor isn’t able to reach its fair share by claiming unowned partitions, it will attempt to steal ownership from other processors.  During this time, the new owner will begin reading from the last recorded checkpoint.  At the same time, the old owner may be dispatching the events that it last read to the handler for processing; it will not understand that ownership has changed until it attempts to read the next set of events from the Event Hubs service.

As a result, you are likely to see some duplicate events being processed when `EventProcessorClients` join or leave the consumer group, which will subside when the processors have reached a stable state with respect to load balancing.  The duration of that window will differ depending on the configuration of your processor and your checkpointing strategy.   

## Starting and stopping processing

Once it has been configured, the `EventProcessorClient` must be explicitly started by calling its [StartProcessingAsync](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventprocessorclient.startprocessingasync?view=azure-dotnet#Azure_Messaging_EventHubs_EventProcessorClient_StartProcessingAsync_System_Threading_CancellationToken_) method to begin processing.  After being started, processing is performed in the background and will continue until the processor has been explicitly stopped by calling its [StopProcessingAsync](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventprocessorclient.stopprocessingasync?view=azure-dotnet) method.  While this allows the application code to perform other tasks, it also places the responsibility of ensuring that the process does not terminate during processing if there are no other tasks being performed.

 When stopping, the processor will relinquish ownership of partitions that it was responsible for processing and clean up network resources used for communication with the Event Hubs service.  As a result, this method will perform network I/O and may need to wait for partition reads that were active to complete.  Due to service calls and network latency, an invocation of this method may take slightly longer than the configured [MaximumWaitTime](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventprocessorclientoptions.maximumwaittime?view=azure-dotnet#Azure_Messaging_EventHubs_EventProcessorClientOptions_MaximumWaitTime).  In the case where the wait time was not configured, stopping may take slightly longer than the [TryTimeout](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventhubsretryoptions.trytimeout?view=azure-dotnet#Azure_Messaging_EventHubs_EventHubsRetryOptions_TryTimeout) of the active retry policy.  By default, this is 60 seconds.  
 
 For more information on configuring the `TryTimeout`, see:  [Configuring the timeout used for Event Hubs service operations](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample02_EventProcessorConfiguration.md#configuring-the-timeout-used-for-event-hubs-service-operations).
 
## Interacting with the processor while running

The act of processing events read from the partition and handling any errors that occur is delegated by the `EventProcessorClient` to code that you provide using the [.NET event pattern](https://docs.microsoft.com/dotnet/csharp/event-pattern).  This allows your logic to concentrate on delivering business value while the processor handles the tasks associated with reading events, managing the partitions, and allowing state to be persisted in the form of checkpoints.

An in-depth discussion of the handlers used with the `EventProcessorClient` along with guidance for implementing them can be found in the sample:  [Event Processor Handlers](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample03_EventProcessorHandlers.md).  The following examples will assume familiarity with best practices for handler implementation and will often avoid going into detail in the interest of brevity.

## Basic event processing

At minimum, the `EventProcessorClient` will make sure that you've registered a handler for processing events and receiving notification about exceptions the processor encounters before it will begin processing events.  This example illustrates a common general pattern for processing, without taking checkpointing into consideration.

```C# Snippet:EventHubs_Processor_Sample04_BasicEventProcessing
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

Task processEventHandler(ProcessEventArgs args)
{
    try
    {
        if (args.CancellationToken.IsCancellationRequested)
        {
            return Task.CompletedTask;
        }

        string partition = args.Partition.PartitionId;
        byte[] eventBody = args.Data.EventBody.ToArray();
        Debug.WriteLine($"Event from partition { partition } with length { eventBody.Length }.");
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

    return Task.CompletedTask;
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
    catch (Exception ex)
    {
        // It is very important that you always guard against
        // exceptions in your handler code; the processor does
        // not have enough understanding of your code to
        // determine the correct action to take.  Any
        // exceptions from your handlers go uncaught by
        // the processor and will NOT be handled in any
        // way.

        Application.HandleErrorException(args, ex);
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

## Checkpointing while processing

A checkpoint is based on an event that is sent to the `ProcessEventAsync` handler and represents the last event that should be considered as processed for the partition; when a processor reads that checkpoint, the next available event in the partition would be used as the starting point for processing. Checkpointing is the responsibility of the application and must be explicitly created; the `EventProcessorClient` does not implicitly create checkpoints on behalf of the application.

The creation of checkpoints comes at a cost, both in terms of processing performance/throughput and a potential monetary cost associated with the underlying storage resource.  While it may seem desirable to create checkpoints for each event that is processed, that is typically considered an anti-pattern for most scenarios.  When deciding how frequently to checkpoint, you'll need to consider the trade-off between the costs of creating the checkpoint against the costs of processing events.  For scenarios where processing events is very cheap, it is often a better approach to checkpoint once per some number of events or once per time interval.  For scenarios where processing events is more expensive, it may be a better approach to checkpoint more frequently.

In either case, it is important to understand that your processing must be tolerant of receiving the same event to be processed more than once; the Event Hubs service, like most messaging platforms, guarantees at-least-once delivery.  Even were you to create a checkpoint for each event that you process, it is entirely possible that you would receive that same event again from the service.

This example illustrates checkpointing after 25 events have been processed for a given partition.  

```C# Snippet:EventHubs_Processor_Sample04_CheckpointByEventCount
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

const int EventsBeforeCheckpoint = 25;
var partitionEventCount = new ConcurrentDictionary<string, int>();

async Task processEventHandler(ProcessEventArgs args)
{
    try
    {
        await Application.ProcessEventAsync(
            args.Data,
            args.Partition,
            args.CancellationToken);

        // If the number of events that have been processed
        // since the last checkpoint was created exceeds the
        // checkpointing threshold, a new checkpoint will be
        // created and the count reset.

        string partition = args.Partition.PartitionId;

        int eventsSinceLastCheckpoint = partitionEventCount.AddOrUpdate(
            key: partition,
            addValue: 1,
            updateValueFactory: (_, currentCount) => currentCount + 1);

        if (eventsSinceLastCheckpoint >= EventsBeforeCheckpoint)
        {
            await args.UpdateCheckpointAsync();
            partitionEventCount[partition] = 0;
        }
    }
    catch (Exception ex)
    {
        Application.HandleProcessingException(args, ex);
    }
}

try
{
    using var cancellationSource = new CancellationTokenSource();
    cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

    // The error handler is not relevant for this sample; for
    // illustration, it is delegating the implementation to the
    // host application.

    processor.ProcessEventAsync += processEventHandler;
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
   // finished using the Event Processor to ensure proper cleanup

   processor.ProcessEventAsync -= processEventHandler;
   processor.ProcessErrorAsync -= Application.ProcessorErrorHandler;
}
```

## Requesting a default starting point for processing

When a partition is initialized, one of the decisions made is where in the partition's event stream to begin processing. If a checkpoint exists for a partition, processing will begin at the next available event after the checkpoint.  When no checkpoint is found for a partition, a default location is used. One of the common reasons that you may choose to participate in initialization is to influence where to begin processing when a checkpoint is not found, overriding the default.

This example will demonstrate choosing to start with the event closest to being on or after the current date and time.

```C# Snippet:EventHubs_Processor_Sample04_InitializePartition
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

Task initializeEventHandler(PartitionInitializingEventArgs args)
{
    try
    {
        if (args.CancellationToken.IsCancellationRequested)
        {
            return Task.CompletedTask;
        }

        // If no checkpoint was found, start processing
        // events enqueued now or in the future.

        EventPosition startPositionWhenNoCheckpoint =
            EventPosition.FromEnqueuedTime(DateTimeOffset.UtcNow);

        args.DefaultStartingPosition = startPositionWhenNoCheckpoint;
    }
    catch (Exception ex)
    {
        Application.HandleInitializeException(args, ex);
    }

    return Task.CompletedTask;
}

try
{
    using var cancellationSource = new CancellationTokenSource();
    cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

    // The event handlers for processing events and errors are
    // not relevant for this sample; for illustration, they're
    // delegating the implementation to the host application.

    processor.PartitionInitializingAsync += initializeEventHandler;
    processor.ProcessEventAsync += Application.ProcessorEventHandler;
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
   // finished using the Event Processor to ensure proper cleanup

   processor.PartitionInitializingAsync -= initializeEventHandler;
   processor.ProcessEventAsync -= Application.ProcessorEventHandler;
   processor.ProcessErrorAsync -= Application.ProcessorErrorHandler;
}
```

## Batch processing

In order to ensure efficient communication with the Event Hubs service and the best throughput possible for dispatching events to be processed, the Event Processor client is eagerly reading from each partition of the Event Hub and staging events.  The processor will dispatch an event to the "ProcessEvent" handler immediately when one is available.  Each call to the handler passes a single event and the context of the partition from which the event was read.  This pattern is intended to allow developers to act on an event as soon as possible, and present a straightforward and understandable interface.

This approach is optimized for scenarios where the processing of events can be performed quickly and without heavy resource costs.  For scenarios where that is not the case, it may be advantageous to collect the events into batches and send them to be processed outside of the context of the "ProcessEvent" handler.  In this example, the `processEventHandler` will group events into batches of 50 by partition, sending them to the application to process when the batch size was reached.

One important thing to note is that batching with the `EventProcessorClient` may boost throughput, but more demanding applications may need more control and less ceremony to meet their higher throughput or specialized needs - that's where the [EventProcessor&lt;TPartition&gt;](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample02_EventHubsClients.md) from the [Azure.Messaging.EventHubs](https://www.nuget.org/packages/Azure.Messaging.EventHubs) package is intended to help.  More on the design and philosophy behind the `EventProcessor<TPartition>` can be found in its [design document](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/design/event-processor%7BT%7D-proposal.md).

```C# Snippet:EventHubs_Processor_Sample04_ProcessByBatch
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

const int EventsInBatch = 50;
var partitionEventBatches = new ConcurrentDictionary<string, List<EventData>>();
var checkpointNeeded = false;

async Task processEventHandler(ProcessEventArgs args)
{
    try
    {
        string partition = args.Partition.PartitionId;

        List<EventData> partitionBatch =
            partitionEventBatches.GetOrAdd(
                partition,
                new List<EventData>());

        partitionBatch.Add(args.Data);

        if (partitionBatch.Count >= EventsInBatch)
        {
            await Application.ProcessEventBatchAsync(
                partitionBatch,
                args.Partition,
                args.CancellationToken);

            checkpointNeeded = true;
            partitionBatch.Clear();
        }

        if (checkpointNeeded)
        {
            await args.UpdateCheckpointAsync();
            checkpointNeeded = false;
        }
    }
    catch (Exception ex)
    {
        Application.HandleProcessingException(args, ex);
    }
}

try
{
    using var cancellationSource = new CancellationTokenSource();
    cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

    // The error handler is not relevant for this sample; for
    // illustration, it is delegating the implementation to the
    // host application.

    processor.ProcessEventAsync += processEventHandler;
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

   processor.ProcessEventAsync -= processEventHandler;
   processor.ProcessErrorAsync -= Application.ProcessorErrorHandler;
}
```

## Heartbeat while processing events

It is often helpful for an application to understand whether an `EventProcessorClient` instance is still healthy but no events were available for its partitions versus when the processor or its host may have stopped.  This can be accomplished by setting a maximum wait time for events to be available to read from the Event Hubs service.  

When the wait time is set, if no events are read within that interval, the processor will invoke the `ProcessEventAsync` handler and pass a set of arguments that indicates no event was available, using the [MaximumWaitTime](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventprocessorclientoptions.maximumwaittime?view=azure-dotnet) of the `EventProcessorClientOptions`.

This example demonstrates emitting a heartbeat to the host application whenever an event is processed or after a maximum of 250 milliseconds passes with no event.

```C# Snippet:EventHubs_Processor_Sample04_ProcessWithHeartbeat
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var storageClient = new BlobContainerClient(
    storageConnectionString,
    blobContainerName);

var processorOptions = new EventProcessorClientOptions
{
    MaximumWaitTime = TimeSpan.FromMilliseconds(250)
};

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    eventHubsConnectionString,
    eventHubName,
    processorOptions);

async Task processEventHandler(ProcessEventArgs args)
{
    try
    {
        if (args.HasEvent)
        {
            await Application.ProcessEventAndCheckpointAsync(
                args.Data,
                args.Partition,
                args.CancellationToken);
        }

        await Application.SendHeartbeatAsync(args.CancellationToken);
    }
    catch (Exception ex)
    {
        Application.HandleProcessingException(args, ex);
    }
}

try
{
    using var cancellationSource = new CancellationTokenSource();
    cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

    // The error handler is not relevant for this sample; for
    // illustration, it is delegating the implementation to the
    // host application.

    processor.ProcessEventAsync += processEventHandler;
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
        // This may take slightly longer than the length of
        // time defined as part of the MaximumWaitTime configured
        // for the processor; in this example, 250 milliseconds.

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

   processor.ProcessEventAsync -= processEventHandler;
   processor.ProcessErrorAsync -= Application.ProcessorErrorHandler;
}
```