# Guide for migrating to Azure.Messaging.EventHubs from Microsoft.Azure.EventHubs

This guide is intended to assist in the migration to version 5 of the Event Hubs client library from version 4.  It will focus on side-by-side comparisons for similar operations between the v5 packages, [`Azure.Messaging.EventHubs`](https://www.nuget.org/packages/Azure.Messaging.EventHubs/) and [`Azure.Messaging.EventHubs.Processor`](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor/)  and their v4 equivalents, [`Microsoft.Azure.EventHubs`](https://www.nuget.org/packages/Microsoft.Azure.EventHubs/) and [`Microsoft.Azure.EventHubs.Processor`](https://www.nuget.org/packages/Microsoft.Azure.EventHubs.Processor/).

Familiarity with the v4 client library is assumed.  For those new to the Event Hubs client library for .NET, please refer to the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/README.md), [Event Hubs samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples), and the [Event Processor samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples) for the v5 library rather than this guide.

## Table of contents

- [Migration benefits](#migration-benefits)
- [General changes](#general-changes)
  - [Package and namespaces](#package-and-namespaces)
  - [Client hierarchy](#client-hierarchy)
  - [Client constructors](#client-constructors)
  - [Publish events](#publish-events)
  - [Read events](#read-events)
- [Migration samples](#migration-samples)
  - [Migrating code from `PartitionSender` to `EventHubProducerClient` for publishing events to a partition](#migrating-code-from-partitionsender-to-eventhubproducerclient-for-publishing-events-to-a-partition)
  - [Migrating code from `EventHubClient` to `EventHubProducerClient` for publishing events using automatic routing](#migrating-code-from-eventhubclient-to-eventhubproducerclient-for-publishing-events-using-automatic-routing)
  - [Migrating code from `EventHubClient` to `EventHubProducerClient` for publishing events with partition key](#migrating-code-from-eventhubclient-to-eventhubproducerclient-for-publishing-events-with-partition-key)
  - [Migrating code from `PartitionReceiver` to `EventHubConsumerClient` for reading events in batches](#migrating-code-from-partitionreceiver-to-eventhubconsumerclient-for-reading-events-in-batches)
  - [Migrating code from `EventProcessorHost` to `EventProcessorClient` for reading events](#migrating-code-from-eventprocessorhost-to-eventprocessorclient-for-reading-events)
- [Additional samples](#additional-samples)

## Migration benefits

A natural question to ask when considering whether or not to adopt a new version or library is what the benefits of doing so would be.  As Azure has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem.  One of the most important is that the client libraries for different Azure services have not had a consistent approach to organization, naming, and API structure.  Additionally, many developers have felt that the learning curve was difficult, and the APIs did not offer a good, approachable, and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To try and improve the development experience across Azure services, including Event Hubs, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services.  A set of [.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel that mirrors that of the .NET base class libraries.  Further details are available in the guidelines for those interested.

For Event Hubs, the modern client library was designed to provide an approachable onboarding experience for those new to messaging and/or the Event Hubs service with the goal of enabling a quick initial feedback loop for publishing and consuming events.  A gradual step-up path follows, building on the onboarding experience and shifting from exploration to tackling real-world production scenarios.  Finally, a set of specialized clients are available for those developers with high-throughput or special needs and who are interested in working at a lower-level.  This version is under active development and will continue to receive enhancements and improvements on a regular cadence.

The modern Event Hubs client library also provides the ability to share in some of the cross-service improvements made to the Azure development experience, such as using the new `Azure.Identity` library to share a single authentication between clients and a unified diagnostics pipeline offering a common view of the activities across each of the client libraries. 

While we believe that there is significant benefit to adopting the modern version of the Event Hubs client library, it is important to be aware that the legacy version has not been officially deprecated.  It will continue to be supported with security and bug fixes as well as receiving some minor refinements.  However, in the near future it will not be under active development and new features are unlikely to be added.  There is no guarantee of feature parity between the modern and legacy client library versions.

## General changes

### Package and namespaces

Package names and the namespace root for the modern Azure client libraries for .NET have changed.  Each will follow the pattern `Azure.[Area].[Service]` where the legacy clients followed the pattern `Microsoft.Azure.[Service]`.  This provides a quick and accessible means to help understand, at a glance, whether you are using the modern or legacy clients.

In the case of Event Hubs, the modern client libraries have packages and namespaces that begin with `Azure.Messaging.EventHubs` and were released beginning with version 5.  The legacy client libraries have packages and namespaces that begin with `Microsoft.Azure.EventHubs` and a version of 4.x.x or below.

### Client hierarchy

In the interest of simplifying the API surface we've made two distinct
clients, rather than having a single `EventHubClient`:
* [EventHubProducerClient](https://docs.microsoft.com/en-us/dotnet/api/azure.messaging.eventhubs.eventhubproducerclient?view=azure-dotnet-preview)
  for publishing messages.
* [EventHubConsumerClient](https://docs.microsoft.com/en-us/dotnet/api/azure.messaging.eventhubs.eventhubconsumerclient?view=azure-dotnet-preview) 
  for reading messages.

The producer and consumer clients operate in the context of a specific event hub and offer operations for all partitions. Unlike the v4, the clients are not bound to a specific partition, but the methods on them have overloads to handle specific partitions if needed.

The [EventHubConsumerClient](https://docs.microsoft.com/en-us/dotnet/api/azure.messaging.eventhubs.eventhubconsumerclient?view=azure-dotnet-preview) supports reading events from a single partition and also offers an easy way to familiarize yourself with Event Hubs by reading from all partitions without the rigor and complexity that you would need in a production application. For reading events from all partitions in a production scenario, we strongly recommend using the [EventProcessorClient](https://azuresdkdocs.blob.core.windows.net/$web/dotnet/Azure.Messaging.EventHubs.Processor/5.0.0-preview.6/api/Azure.Messaging.EventHubs/Azure.Messaging.EventHubs.EventProcessorClient.html).

The [EventProcessorClient](https://azuresdkdocs.blob.core.windows.net/$web/dotnet/Azure.Messaging.EventHubs.Processor/5.0.0-preview.6/api/Azure.Messaging.EventHubs/Azure.Messaging.EventHubs.EventProcessorClient.html) can be found in the new [Azure.Messaging.EventHubs.Processor](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor/) which replaces the older [Microsoft.Azure.EventHubs.Processor](https://www.nuget.org/packages/Microsoft.Azure.EventHubs.Processor/). Here we have the [EventProcessorClient](https://azuresdkdocs.blob.core.windows.net/$web/dotnet/Azure.Messaging.EventHubs.Processor/5.0.0-preview.6/api/Azure.Messaging.EventHubs/Azure.Messaging.EventHubs.EventProcessorClient.html) which is responsible for consuming events for the configured Event Hub and consumer group across all partitions. It also supports checkpointing and load balancing. Currently, only Azure Storage Blobs is supported for checkpointing.

### Client constructors

| In v4                                          | Equivalent in v5                                                 | Sample |
|------------------------------------------------|------------------------------------------------------------------|--------|
| `EventHubClient.CreateFromConnectionString()`    | `new EventHubProducerClient()` or `new EventHubConsumerClient()` | [Publish Events](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample03_PublishAnEventBatch.cs), [Read Events](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample05_ReadEvents.cs) |
| `EventHubClient.CreateWithAzureActiveDirectory()` or `EventHubClient.CreateWithManagedIdentity()`  | `new EventHubProducerClient(..., TokenCredential)` or `new EventHubConsumerClient(..., TokenCredential)` | [Authenticate with client secret credential](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample11_AuthenticateWithClientSecretCredential.cs)
| `new EventProcessorHost()`                           | `new EventProcessorClient(BlobContainerClient, ...)`               | [Basic Event Processing](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample03_BasicEventProcessing.cs) |

### Publish events

The v4 client allowed for sending a single event or an enumerable of events, which had the potential to fail unexpectedly if the maximum allowable size was exceeded. v5 aims to prevent this by asking that you first create a batch of events using `CreateBatchAsync` and then attempt to add events to that using `TryAdd()`. If the batch accepts an event, you can be confident that it will not violate size constraints when calling Send to publish the batch.

| In v4                                          | Equivalent in v5                                                 | Sample |
|------------------------------------------------|------------------------------------------------------------------|--------|
| `PartitionSender.SendAsync()`                          | `EventHubProducerClient.SendAsync()`                               | [Publish events to a specific partition](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample07_PublishAnEventBatchToASpecificPartition.cs) |
| `EventHubClient.SendAsync()`                          | `EventHubProducerClient.SendAsync()`                               | [Publish events](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample03_PublishAnEventBatch.cs) |

### Read events 

| In v4                                          | Equivalent in v5                                                 | Sample |
|------------------------------------------------|------------------------------------------------------------------|--------|
| `PartitionReceiver.ReceiveAsync()` or `PartitionReceiver.SetReceiveHandler()`                      | `EventHubConsumerClient.ReadEventsFromPartitionAsync()`                               | [Read events](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample09_ReadEventsFromAKnownPosition.cs) |
| `new EventProcessorHost()`                           | `new EventProcessorClient(blobContainerClient, ...)`               | [Basic Event Processing](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample03_BasicEventProcessing.cs) |

## Migration samples

### Migrating code from `PartitionSender` to `EventHubProducerClient` for publishing events to a partition

In v4, events could be published to a single partition using `PartitionSender`. You could also send a single event, a set of events, or a batch. In v5 only batches are supported to ensure that there are no unexpected exceptions generated during send; you can't put it in a batch if it was too large to send.

In v5, this has been consolidated into a more efficient SendAsync(EventDataBatch) method. Batching merges information from multiple events into a single publish message, reducing the amount of network communication needed vs publishing events one at a time. Events are published to a specific partition when partition id is set in [`CreateBatchOptions`](https://docs.microsoft.com/en-us/dotnet/api/azure.messaging.eventhubs.createbatchoptions?view=azure-dotnet-preview) before calling [`CreateBatchAsync(CreateBatchOptions)`](https://docs.microsoft.com/en-us/dotnet/api/azure.messaging.eventhubs.eventhubproducerclient.createbatchasync?view=azure-dotnet-preview#Azure_Messaging_EventHubs_EventHubProducerClient_CreateBatchAsync_Azure_Messaging_EventHubs_CreateBatchOptions_System_Threading_CancellationToken_).

The code below assumes all events fit into a single batch. For more complete example, see sample: [Publish events
to specific partition](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample06_PublishAnEventBatchToASpecificPartition.cs).

In v4:
```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var connectionStringBuilder = new EventHubsConnectionStringBuilder(connectionString){ EntityPath = eventHubName }; 
var eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
PartitionSender partitionSender = eventHubClient.CreatePartitionSender("my-partition-id");
try
{
    EventDataBatch eventBatch = partitionSender.CreateBatch();
    eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("First")));
    eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Second")));

    await partitionSender.SendAsync(eventBatch);
}
finally
{
    await partitionSender.CloseAsync();
    await eventHubClient.CloseAsync();
}
```

In v5:
```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
{
    var batchOptions = new CreateBatchOptions() { PartitionId = "my-partition-id" };
    using EventDataBatch eventBatch = await producerClient.CreateBatchAsync(batchOptions);
    eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("First")));
    eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Second")));
    
    await producerClient.SendAsync(eventBatch);
}
```

### Migrating code from `EventHubClient` to `EventHubProducerClient` for publishing events using automatic routing

In v4, events could be published to an Event Hub that allowed the service to automatically route events to an available partition.

In v5, automatic routing occurs when an [`EventDataBatch`](https://docs.microsoft.com/en-us/dotnet/api/azure.messaging.eventhubs.eventdatabatch?view=azure-dotnet-preview) is created using [`CreateBatchAsync()`](https://docs.microsoft.com/en-us/dotnet/api/azure.messaging.eventhubs.eventhubproducerclient.createbatchasync?view=azure-dotnet-preview#Azure_Messaging_EventHubs_EventHubProducerClient_CreateBatchAsync_System_Threading_CancellationToken_).

In v4:
```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var connectionStringBuilder = new EventHubsConnectionStringBuilder(connectionString){ EntityPath = eventHubName }; 
var eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
try
{
    EventDataBatch eventBatch = eventHubClient.CreateBatch();
    eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("First")));
    eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Second")));

   await eventHubClient.SendAsync(eventBatch);
}
finally
{
    await eventHubClient.CloseAsync();
}
```

In v5:
```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
{
    using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();
    eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("First")));
    eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Second")));
    
    await producerClient.SendAsync(eventBatch);
}
```

### Migrating code from `EventHubClient` to `EventHubProducerClient` for publishing events with partition key

In v4, events could be published with a partition key.

In v5, events are published with a partition key when partition key is set in [`CreateBatchOptions`](https://docs.microsoft.com/en-us/dotnet/api/azure.messaging.eventhubs.createbatchoptions?view=azure-dotnet-preview) before calling [`CreateBatchAsync(CreateBatchOptions)`](https://docs.microsoft.com/en-us/dotnet/api/azure.messaging.eventhubs.eventhubproducerclient.createbatchasync?view=azure-dotnet-preview#Azure_Messaging_EventHubs_EventHubProducerClient_CreateBatchAsync_Azure_Messaging_EventHubs_CreateBatchOptions_System_Threading_CancellationToken_).

In v4:
```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var connectionStringBuilder = new EventHubsConnectionStringBuilder(connectionString){ EntityPath = eventHubName }; 
var eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
try
{
    EventData eventData = new EventData(Encoding.UTF8.GetBytes("First"));
    await eventHubClient.SendAsync(eventData, "my-partition-key");
}
finally
{
    await eventHubClient.CloseAsync();
}
```

In v5:
```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
{
    var batchOptions = new CreateBatchOptions() { PartitionKey = "my-partition-key" };
    using EventDataBatch eventBatch = await producerClient.CreateBatchAsync(batchOptions);
    eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("First")));
    eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Second")));
    
    await producerClient.SendAsync(eventBatch);
}
```

### Migrating code from `PartitionReceiver` to `EventHubConsumerClient` for reading events in batches

In v4, events were read by creating a `PartitionReceiver` and invoking `ReceiveAsync(int)` multiple times to read
events up to a certain number.

In v5, events can be streamed as they come in without having to use a batched read approach.

This code which reads from a partition in v4:
```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var connectionStringBuilder = new EventHubsConnectionStringBuilder(connectionString){ EntityPath = eventHubName }; 
var eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
PartitionReceiver partitionReceiver = client.CreateReceiver("my-consumer-group", "my-partition-id", EventPosition.FromStart());
try
{
    // Gets up to 100 events or until the read timeout elapses.
    IEnumerable<EventData> eventDatas = await partitionReceiver.ReceiveAsync(100);
    // Gets up to next 50 events or until the read timeout elapses.
    IEnumerable<EventData> eventDatas = await partitionReceiver.ReceiveAsync(50);
}
finally
{
    await partitionReceiver.CloseAsync();
    await eventHubClient.CloseAsync();
}
```

Becomes this in v5:
```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

await using (var consumer = new EventHubConsumerClient(consumerGroup, connectionString, eventHubName))
{
    EventPosition startingPosition = EventPosition.Earliest;
    string partitionId = (await consumer.GetPartitionIdsAsync()).First();

    using var cancellationSource = new CancellationTokenSource();
    cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

    await foreach (PartitionEvent receivedEvent in consumer.ReadEventsFromPartitionAsync(partitionId, startingPosition, cancellationSource.Token))
    {
        // At this point, the loop will wait for events to be available in the partition.  When an event
        // is available, the loop will iterate with the event that was read.  Because we did not
        // specify a maximum wait time, the loop will wait forever unless cancellation is requested using
        // the cancellation token.
    }
}
```

See [`ReadEvents.cs`](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample09_ReadEventsFromAKnownPosition.cs) for a sample program demonstrating this.

### Migrating code from `EventProcessorHost` to `EventProcessorClient` for reading events

In v4, `EventProcessorHost` allowed you to balance the load between multiple instances of your program and checkpoint
events when receiving. Developers would have to create and register a concrete implementation of `IEventProcessor` to
begin consuming events.

In v5, `EventProcessorClient` allows you to do the same, the development model is made simpler by using events. Rather than implementing an interface, you subscribe to the events that you are interested in by registering an event handler delegate, following the standard .NET pattern. To use this, include [Azure.Messaging.EventHubs.Processor](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor) as a dependency.

The following code in v4:
```csharp
private static void Main(String[] args) {
    var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
    var blobContainerName = "<< NAME OF THE BLOBS CONTAINER >>";
    var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
    var eventHubName = "<< NAME OF THE EVENT HUB >>";
    var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

    EventProcessorHost eventProcessorHost = new EventProcessorHost(eventHubName, consumerGroup, eventHubsConnectionString, storageConnectionString, blobContainerName);
    
    // Registers the Event Processor Host and starts receiving messages
    await eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>();
    // When you are finished processing events.
    await eventProcessorHost.UnregisterEventProcessorAsync();
}

public class SimpleEventProcessor implements IEventProcessor {
    public Task CloseAsync(PartitionContext context, CloseReason reason)
    {
         Console.WriteLine($"Processor Shutting Down. Partition '{context.PartitionId}', Reason: '{reason}'.");
         return Task.CompletedTask;
    }
    public Task OpenAsync(PartitionContext context)
    {
        Console.WriteLine($"SimpleEventProcessor initialized. Partition: '{context.PartitionId}'");
        return Task.CompletedTask;
    }
    public Task ProcessErrorAsync(PartitionContext context, Exception error)
    {
        Console.WriteLine($"Error on Partition: {context.PartitionId}, Error: {error.Message}");
        return Task.CompletedTask;
    }
    public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
    {
        foreach (var eventData in messages)
        {
            var data = Encoding.UTF8.GetString(eventData.Body.Array, eventData.Body.Offset, eventData.Body.Count);
            Console.WriteLine($"Event received. Partition: '{context.PartitionId}', Data: '{data}', Partition Key: '{eventData.SystemProperties.PartitionKey}'");
        }

        return Task.CompletedTask;
    }
}
```

And in v5, in order to use the `EventProcessorClient`, handlers for event processing and errors must be provided.  These handlers are considered self-contained and developers are responsible for ensuring that exceptions within the handler code are accounted for.

```csharp
private async Task ProcessUntilCanceled(CancellationToken cancellationToken)
{
    var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
    var blobContainerName = "<< NAME OF THE BLOBS CONTAINER >>";
    var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
    var eventHubName = "<< NAME OF THE EVENT HUB >>";
    var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

    async Task processEventHandler(ProcessEventArgs eventArgs)
    {
        Console.WriteLine($"Event Received: { Encoding.UTF8.GetString(eventArgs.Data.Body.ToArray()) }");
        return Task.CompletedTask;
    }

    async Task processErrorHandler(ProcessErrorEventArgs eventArgs)
    {
        Console.WriteLine($"Error on Partition: {eventArgs.PartitionId}, Error: {eventArgs.Exception.Message}");
        return Task.CompletedTask;
    }

    var storageClient = new BlobContainerClient(storageConnectionString, blobContainerName);
    var processor = new EventProcessorClient(storageClient, consumerGroup, eventHubsConnectionString, eventHubName);

    processor.ProcessEventAsync += processEventHandler;
    processor.ProcessErrorAsync += processErrorHandler;
    
    await processor.StartProcessingAsync();
    
    try
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
        
        await processor.StopProcessingAsync();
    }
    finally
    {
        // To prevent leaks, the handlers should be removed when processing is complete
        processor.ProcessEventAsync -= processEventHandler;
        processor.ProcessErrorAsync -= processErrorHandler;
    }
}
```

## Additional samples

More examples can be found at:
- [Event Hubs samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples)
- [Event Hubs Processor samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples)
