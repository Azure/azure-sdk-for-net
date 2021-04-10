# Event Processor Handlers

Once started, the majority of work performed by the `EventProcessorClient` takes place in the background.  Interaction with the host application takes place using .NET [events](https://docs.microsoft.com/dotnet/standard/events/), allowing the processor to surface information and the application to influence processor behavior.  Unlike most .NET events, those used by the processor are asynchronous and allow only a single handler to be subscribed. 

This sample details the means to receive information and interact with the `EventProcessorClient` as it is running and demonstrates how to configure the event handlers for some common scenarios.  To begin, please ensure that you're familiar with the items discussed in the [Getting started](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples#getting-started) section of the README, and have the prerequisites and connection string information available.

## Process Event

The processor will invoke the `ProcessEventAsync` handler when an event read from the Event Hubs service is available for processing or, if the [MaximumWaitTime](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventprocessorclientoptions.maximumwaittime?view=azure-dotnet#Azure_Messaging_EventHubs_EventProcessorClientOptions_MaximumWaitTime) was specified, when that duration has elapsed without an event being available.  This handler will be invoked concurrently, limited to one active call per partition.  While the handler may be processing events from different partitions concurrently, the processor will ensure that the events from the same partition are processed one-at-a-time in the order that they were read from the partition. 

Processing events are covered in more depth for different scenarios in [Sample04_ProcessingEvents](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample04_ProcessingEvents.md).

### Respecting cancellation

The [event arguments](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.processor.processeventargs?view=azure-dotnet) contain a cancellation token that the `EventProcessorClient` uses to signal the handler that processing should cease as soon as possible.  This is most commonly seen when the `EventProcessorClient` is stopping or has encountered an unrecoverable problem.  It is up to the handler to decide whether to take action to process the event and, perhaps, record a checkpoint or to cancel immediately.  If the handler chooses not to process the event, the data will not be lost and the event will be replayed when the partition processed in the future, so long as the event is not used to create a checkpoint. 

```C# Snippet:EventHubs_Processor_Sample03_EventHandlerCancellation
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

        // Process the event.
    }
    catch
    {
        // Take action to handle the exception.
        // It is important that all exceptions are
        // handled and none are permitted to bubble up.
    }

    return Task.CompletedTask;
}

try
{
    processor.ProcessEventAsync += processEventHandler;

    // Starting and stopping the processor are not
    // shown in this example.
}
finally
{
    processor.ProcessEventAsync -= processEventHandler;
}
```

## Process Error

The processor will invoke the `ProcessErrorAsync` handler when an exception has been observed during operation of the processor, occurring as part of its infrastructure.  It is not invoked for exceptions observed in developer-provided code, such as that of the event handlers or other extension points. The `EventProcessorClient` will make every effort to recover from exceptions and continue processing.  Should an exception that cannot be recovered from be encountered, the processor will attempt to forfeit ownership of all partitions that it was processing so that work may be redistributed.  This handler may be invoked concurrently.

### Inspecting error details

The [event arguments](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.processor.processerroreventargs?view=azure-dotnet) contain a cancellation token that the `EventProcessorClient` uses to signal the handler that processing should cease as soon as possible.  This is most commonly seen when the `EventProcessorClient` is stopping or has encountered an unrecoverable problem.  It is up to the handler to decide whether to take action for the error or cancel immediately.  The arguments also contain information about the exception that was observed, the operation that the processor was performing at the time, and the partition that the operation was associated with, if any.

```C# Snippet:EventHubs_Processor_Sample03_ErrorHandlerArgs
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

Task processErrorHandler(ProcessErrorEventArgs args)
{
    try
    {
        if (args.CancellationToken.IsCancellationRequested)
        {
            return Task.CompletedTask;
        }

        Debug.WriteLine("Error in the EventProcessorClient");
        Debug.WriteLine($"\tOperation: { args.Operation ?? "Unknown" }");
        Debug.WriteLine($"\tPartition: { args.PartitionId ?? "None" }");
        Debug.WriteLine($"\tException: { args.Exception }");
        Debug.WriteLine("");
    }
    catch
    {
        // Take action to handle the exception.
        // It is important that all exceptions are
        // handled and none are permitted to bubble up.
    }

    return Task.CompletedTask;
}

try
{
    processor.ProcessErrorAsync += processErrorHandler;

    // Starting and stopping the processor are not
    // shown in this example.
}
finally
{
    processor.ProcessErrorAsync -= processErrorHandler;
}
```

### Reacting to processor errors

The exceptions surfaced to this method may be fatal or non-fatal; because the processor may not be able to accurately predict whether an exception was fatal, such as a non-transient network failure or when the application's state has been corrupted, this handler has responsibility for making the determination as to whether processing should be terminated or restarted.  The handler may safely call `StopProcessingAsync` on the processor instance inline, as the handler is not awaited by the processor when invoked.

In production scenarios, it is recommended that the decision for how an error should be handled be made by considering observations made by this error handler in collaboration with the handlers for other available processor events.  Many applications will also wish to consider data from their monitoring platforms in this decision as well.

This example demonstrates signaling the application to stop processing if the application is out of memory and restarting the processor if it indicates that it has stopped running.

```C# Snippet:EventHubs_Processor_Sample03_ErrorHandlerCancellationRecovery
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

// This token is used to control processing,
// if signaled, then processing will be stopped.

using var cancellationSource = new CancellationTokenSource();

Task processEventHandler(ProcessEventArgs args)
{
    try
    {
        // Process the event.
    }
    catch
    {
        // Handle the exception.
    }

    return Task.CompletedTask;
}

async Task processErrorHandler(ProcessErrorEventArgs args)
{
    try
    {
        // Always log the exception.

        Debug.WriteLine("Error in the EventProcessorClient");
        Debug.WriteLine($"\tOperation: { args.Operation ?? "Unknown" }");
        Debug.WriteLine($"\tPartition: { args.PartitionId ?? "None" }");
        Debug.WriteLine($"\tException: { args.Exception }");
        Debug.WriteLine("");

        // If cancellation was requested, assume that
        // it was in response to an application request
        // and take no action.

        if (args.CancellationToken.IsCancellationRequested)
        {
            return;
        }

        // If out of memory, signal for cancellation.

        if (args.Exception is OutOfMemoryException)
        {
            cancellationSource.Cancel();
            return;
        }

        // If processing stopped and this handler determined
        // the error to be non-fatal, restart processing.

        if ((!processor.IsRunning)
            && (!cancellationSource.IsCancellationRequested))
        {
            // To be safe, request that processing stop before
            // requesting the start; this will ensure that any
            // processor state is fully reset.

            await processor.StopProcessingAsync();
            await processor.StartProcessingAsync(cancellationSource.Token);
        }
    }
    catch
    {
        // Handle the exception.  If fatal, signal
        // for cancellation.
    }
}

try
{
    processor.ProcessEventAsync += processEventHandler;
    processor.ProcessErrorAsync += processErrorHandler;

    try
    {
        // Once processing has started, the delay will
        // block to allow processing until cancellation
        // is requested.

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
finally
{
    processor.ProcessEventAsync -= processEventHandler;
    processor.ProcessErrorAsync -= processErrorHandler;
}
```

## Partition Initializing

When the `EventProcessorClient` begins processing, it will take ownership over a set of Event Hub partitions to process.  For each partition that it owns, the first step is initializing the partition.  To initialize, the processor will invoke the `PartitionInitializingAsync` handler, allowing the host application to track partition ownership and influence how the partition is processed.  This handler is optional and may be invoked concurrently.

### Requesting a default starting point for the partition

When a partition is initialized, one of the decisions made is where in the partition's event stream to begin processing.  If a checkpoint exists for a partition, processing will begin at the next available event after the checkpoint.  When no checkpoint is found for a partition, a default location is used.  One of the common reasons that you may choose to participate in initialization is to influence where to begin processing when a checkpoint is not found, overriding the default.
            
The [event arguments](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.processor.partitioninitializingeventargs?view=azure-dotnet) contain a `DefaultStartingPosition` which can be used to influence where processing begins when a checkpoint is unavailable.  The arguments also contain a cancellation token that the `EventProcessorClient` uses to signal the handler that initialization should cease as soon as possible.  This is most commonly seen when the `EventProcessorClient` is stopping or has encountered an unrecoverable problem.  It is up to the handler to decide whether to take action or to cancel immediately, but there typically is no benefit to continuing initialization when the token has been signaled.

```C# Snippet:EventHubs_Processor_Sample03_InitializeHandlerArgs
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

        Debug.WriteLine($"Initialize partition: { args.PartitionId }");

        // If no checkpoint was found, start processing
        // events enqueued now or in the future.

        EventPosition startPositionWhenNoCheckpoint =
            EventPosition.FromEnqueuedTime(DateTimeOffset.UtcNow);

        args.DefaultStartingPosition = startPositionWhenNoCheckpoint;
    }
    catch
    {
        // Take action to handle the exception.
        // It is important that all exceptions are
        // handled and none are permitted to bubble up.
    }

    return Task.CompletedTask;
}

try
{
    processor.PartitionInitializingAsync += initializeEventHandler;

    // Starting and stopping the processor are not
    // shown in this example.
}
finally
{
    processor.PartitionInitializingAsync -= initializeEventHandler;
}
```

## Partition Closing

The processor will invoke the `PartitionClosingAsync` handler when processing for a partition is being stopped, allowing the host application to track partition ownership.  This scenario commonly occurs when a partition is claimed by another processor instance or when the current processor is shutting down,  This handler is optional and may be invoked concurrently.

### Inspecting closing details

The [event arguments](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.processor.partitionclosingeventargs?view=azure-dotnet) contain a cancellation token that the `EventProcessorClient` uses to signal the handler that processing should cease as soon as possible.  This is most commonly seen when the `EventProcessorClient` is stopping or has encountered an unrecoverable problem.  It is up to the handler to decide whether to take action for the error to cancel immediately.  The arguments also contain information about the reason for closing the partition and the partition being closed.

```C# Snippet:EventHubs_Processor_Sample03_CloseHandlerArgs
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

Task closeEventHandler(PartitionClosingEventArgs args)
{
    try
    {
        if (args.CancellationToken.IsCancellationRequested)
        {
            return Task.CompletedTask;
        }

        string description = args.Reason switch
        {
            ProcessingStoppedReason.OwnershipLost =>
                "Another processor claimed ownership",

            ProcessingStoppedReason.Shutdown =>
                "The processor is shutting down",

            _ => args.Reason.ToString()
        };

        Debug.WriteLine($"Closing partition: { args.PartitionId }");
        Debug.WriteLine($"\tReason: { description }");
    }
    catch
    {
        // Take action to handle the exception.
        // It is important that all exceptions are
        // handled and none are permitted to bubble up.
    }

    return Task.CompletedTask;
}

try
{
    processor.PartitionClosingAsync += closeEventHandler;

    // Starting and stopping the processor are not
    // shown in this example.
}
finally
{
    processor.PartitionClosingAsync -= closeEventHandler;
}
```

# Common guidance for handlers

The following examples discuss common guidance for handlers used with the `EventProcessorClient`.  For illustration, the `ProcessEventAsync` handler is demonstrated, but the concept and form are common across each of the handlers, unless otherwise discussed as a special case.

### Exceptions in handlers

It is extremely important that you always guard against exceptions in your handler code; it is strongly recommended to wrap your entire handler in a `try/catch` block and ensure that you do not re-throw exceptions.  The processor does not have enough understanding of your handler code to determine the correct action to take in the face of an exception nor to understand whether it is safe to assume that processing has not been corrupted.  Any exceptions thrown from your handler will not be caught by the processor and will NOT be redirected to the error handler.  This will typically cause processing for the partition to abort, and be restarted, but may also crash your application process.

```C# Snippet:EventHubs_Processor_Sample03_EventHandlerExceptionHandling
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
        // Process the event.
    }
    catch
    {
        // Take action to handle the exception.
        // It is important that all exceptions are
        // handled and none are permitted to bubble up.
    }

    return Task.CompletedTask;
}

try
{
    processor.ProcessEventAsync += processEventHandler;

    // Starting and stopping the processor are not
    // shown in this example.
}
finally
{
    processor.ProcessEventAsync -= processEventHandler;
}
```

### Stop the processor for fatal exceptions

With the notable exception of the `ProcessErrorAsync` handler, the `EventProcessorClient` will await a handler when it is invoked.  Because of this, you are unable to safely perform operations on the client, such as calling `StopProcessingAsync` when an exception is observed.  Doing so is likely to result in a deadlock.  A common technique to work around this limitation for is to signal a cancellation token observed by the application.

```C# Snippet:EventHubs_Processor_Sample03_EventHandlerStopOnException
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

// This token is used to control processing,
// if signaled, then processing will be stopped.

using var cancellationSource = new CancellationTokenSource();

Task processEventHandler(ProcessEventArgs args)
{
    try
    {
        if (args.CancellationToken.IsCancellationRequested)
        {
            return Task.CompletedTask;
        }

        // Process the event.
    }
    catch
    {
        // Handle the exception.  If fatal,
        // signal for cancellation.

        cancellationSource.Cancel();
    }

    return Task.CompletedTask;
}

Task processErrorHandler(ProcessErrorEventArgs args)
{
    // Process the error, as appropriate for the
    // application.

    return Task.CompletedTask;
}

try
{
    processor.ProcessEventAsync += processEventHandler;
    processor.ProcessErrorAsync += processErrorHandler;

    try
    {
        // Once processing has started, the delay will
        // block to allow processing until cancellation
        // is requested.

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
finally
{
    processor.ProcessEventAsync -= processEventHandler;
    processor.ProcessErrorAsync -= processErrorHandler;
}
```