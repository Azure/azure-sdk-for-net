# Guide for migrating to Azure.Messaging.EventHubs from WindowsAzure.ServiceBus

This guide is intended to assist customers of Azure Event Hubs in the migration to the `Azure.Messaging.EventHubs` family of packages from the legacy `WindowsAzure.ServiceBus` and `Microsoft.Azure.ServiceBus.EventProcessorHost` .NET framework packages. It will focus on side-by-side comparisons for similar operations between the two versions, covering the [`Azure.Messaging.EventHubs`](https://www.nuget.org/packages/Azure.Messaging.EventHubs/) and [`Azure.Messaging.EventHubs.Processor`](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor/) packages and their legacy equivalents, [`WindowsAzure.ServiceBus`](https://www.nuget.org/packages/WindowsAzure.ServiceBus/) and [`Microsoft.Azure.ServiceBus.EventProcessorHost`](https://www.nuget.org/packages/Microsoft.Azure.ServiceBus.EventProcessorHost/).

Familiarity with the `WindowsAzure.ServiceBus` and `Microsoft.Azure.ServiceBus.EventProcessorHost` packages is assumed. For those new to the Event Hubs client library for .NET, please refer to the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/README.md), [Event Hubs samples](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples), and the [Event Processor samples](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples) rather than this guide.

## Table of contents

-   [Migration benefits](#migration-benefits)
-   [General changes](#general-changes)
    -   [Package and namespaces](#package-and-namespaces)
    -   [Client hierarchy](#client-hierarchy)
    -   [Client constructors](#client-constructors)
    -   [Publishing events](#publishing-events)
        -   [With automatic partition assignment](#publishing-events-with-automatic-partition-assignment)
        -   [With a partition key](#publishing-events-with-a-partition-key)
        -   [To a specific partition](#publishing-events-to-a-specific-partition)
    -   [Reading events](#reading-events)
        -   [From all partitions](#reading-events-from-all-partitions)
        -   [From a single partition](#reading-events-from-a-single-partition)
-   [Additional samples](#additional-samples)

## Migration benefits

A natural question to ask when considering whether or not to adopt a new version or library is what the benefits of doing so would be. As Azure has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem. One of the most important is that the client libraries for different Azure services have not had a consistent approach to organization, naming, and API structure. Additionally, many developers have felt that the learning curve was difficult, and the APIs did not offer a good, approachable, and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To improve the development experience across Azure services, including Event Hubs, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services. A set of [.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel that mirrors that of the .NET base class libraries. Further details are available in the guidelines for those interested.

The new Event Hubs client library is designed to provide an approachable onboarding experience for those new to messaging and/or the Event Hubs service with the goal of enabling a quick initial feedback loop for publishing and consuming events. A gradual step-up path follows, building on the onboarding experience and shifting from exploration to tackling real-world production scenarios. For developers with high-throughput scenarios or specialized needs, a set of lower-level primitives are available to offer less abstraction and greater control.

While we strongly encourage moving to the `Azure.Messaging.EventHubs` family of packages, it is important to be aware that the legacy `WindowsAzure.Servicebus` package has not yet been officially deprecated.  It will continue to be supported with critical security and bug fixes, and may receive some minor refinements.  However, it is no longer under active development and will not receive new features or many minor fixes.  There is no guarantee of feature parity between the and legacy client library versions.

## Cross-service SDK improvements

The `Azure.Messaging.EventHubs` family of packages also provide the ability to share in some of the cross-service improvements made to the Azure development experience, such as:

-   Using the new `Azure.Identity` library to share a single authentication between clients
-   A unified diagnostics pipeline offering a common view of the activities across each of the client libraries

## General changes

### Package and namespaces

Package names and the namespace root for the Azure client libraries for .NET have changed. Each will follow the pattern `Azure.[Area].[Service]` where the legacy clients followed the pattern `WindowsAzure.[Service]` or `Microsoft.Azure.[Service]`. This provides a quick and accessible means to help understand, at a glance, whether you are using the current generation or legacy clients.

In the case of Event Hubs, the client libraries have packages and namespaces that begin with `Azure.Messaging.EventHubs` and were released beginning with version 5.x.x. The legacy client libraries have the namespace `Microsoft.ServiceBus.Messaging`.

### Client hierarchy

The key goal for the Event Hubs client library is to provide a first-class experience for developers, from early exploration of Event Hubs through real-world use. We wanted to simplify the API surface to focus on scenarios important to the majority of developers without losing support for those with specialized needs. To achieve this, the client hierarchy has been split into two general categories, mainstream and specialized.

The mainstream set of clients provides an approachable onboarding experience for those new to Event Hubs with a clear step-up path to production use. The specialized set of clients is focused on high-throughput and allowing developers a higher degree of control, at the cost of more complexity in their use. This section will briefly introduce the clients in both categories, with the remainder of the migration guide focused on mainstream scenarios.

#### Mainstream

In order to allow for a single focus and clear responsibility, the core functionality for publishing and reading events belongs to distinct clients, rather than the single `EventHubClient` used by previous versions. The producer and consumer clients operate in the context of a specific Event Hub and offer operations for all partitions. Clients in the `Azure.Messaging.EventHubs` family are not bound to a specific partition, instead offering specific partitions to be provided at the method-level, where needed.

-   The [EventHubProducerClient](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.producer?view=azure-dotnet) is responsible for publishing events and supports multiple approaches for selecting the partition to which the event is associated, including automatic routing by the Event Hubs service and specifying an explicit partition.

- The [EventHubBufferedProducerClient](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.producer?view=azure-dotnet) publishes events using a deferred model where events are collected into a buffer and the producer has responsibility for implicitly batching and sending them.  More on the design and philosophy behind this type can be found in its [design document](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/design/proposal-event-hub-buffered-producer.md).

-   The [EventHubConsumerClient](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.consumer.eventhubconsumerclient?view=azure-dotnet) supports reading events from a single partition and also offers an easy way to familiarize yourself with Event Hubs by reading from all partitions without the rigor and complexity that you would need in a production application. For reading events from all partitions in a production scenario, we strongly recommend using the [EventProcessorClient](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventprocessorclient?view=azure-dotnet) over the `EventHubConsumerClient`.

-   The [EventProcessorClient](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventprocessorclient?view=azure-dotnet) is responsible for reading and processing events for all partitions of an Event Hub. It will collaborate with other instances for the same Event Hub and consumer group pairing to balance work between them. A high degree of fault tolerance is built-in, allowing the processor to be resilient in the face of errors. The `EventProcessorClient` can be found in the [Azure.Messaging.EventHubs.Processor](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor/) package.

    One of the key features of the `EventProcessorClient` is enabling tracking of which events have been processed by interacting with a durable storage provider. This process is commonly referred to as [checkpointing](https://learn.microsoft.com/azure/event-hubs/event-hubs-features#checkpointing) and the persisted state as a checkpoint. This version of the `EventProcessorClient` supports only Azure Storage Blobs as a backing store.

    **_Important note on checkpoints:_** The [EventProcessorClient](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventprocessorclient?view=azure-dotnet) does not support legacy checkpoint data created using the `EventProcessorHost` from the `Microsoft.Azure.ServiceBus.EventProcessorHost` package. In order to allow for a unified format for checkpoint data across languages, a more efficient approach to data storage, and improvements to the algorithm used for managing partition ownership, breaking changes were necessary.

#### Specialized

- The [PartitionReceiver](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.primitives.partitionreceiver?view=azure-dotnet) is responsible for reading events from a specific partition of an Event Hub, with a greater level of control over communication with the Event Hubs service than is offered by other event consumers.  More detail on the design and philosophy for the `PartitionReceiver` can be found in its [design document](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/design/proposal-partition-receiver.md).

- The [PluggableCheckpointStoreEventProcessor&lt;TPartition&gt;](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.primitives.PluggableCheckpointStoreEventProcessor-1?view=azure-dotnet) provides a base for creating a custom processor for reading and processing events from all partitions of an Event Hub, using the provided checkpoint store for state persistence. It fills a role similar to the [EventProcessorClient](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples) from the [Azure.Messaging.EventHubs.Processor](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor) package, with cooperative load balancing and resiliency as its core features.  However, `PluggableCheckpointStoreEventProcessor<TPartition>` also offers native batch processing, a greater level of control over communication with the Event Hubs service, and a less opinionated API.  The caveat is that this comes with additional complexity and exists as an abstract base, which needs to be extended.

- The [EventProcessor&lt;TPartition&gt;](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.primitives.eventprocessor-1?view=azure-dotnet) is our lowest-level base for creating a custom processor allowing the greatest degree of customizability. It fills a role similar to the [PluggableCheckpointStoreEventProcessor&lt;TPartition&gt;](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.primitives.PluggableCheckpointStoreEventProcessor-1?view=azure-dotnet), with cooperative load balancing, resiliency, and batch processing as its core features.  However, `EventProcessor<TPartition>` also provides the ability to customize checkpoint storage, including using different stores for ownership and checkpoint data.  `EventProcessor<TPartition>` exists as an abstract base, which needs to be extended.  More on the design and philosophy behind this type can be found in its [design document](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/design/proposal-event-processor%7BT%7D.md).

### Client constructors

In the `WindowsAzure.ServiceBus` library, publishing and reading events started by creating an instance of the `EventHubClient` and then using that as a factory for producers and consumers. The client can be created using a connection string or a variety of token providers.

Using a connection string:

```C#
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

EventHubClient client = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);
```

Using Azure Active Directory:

The sample [Role based access sample with WindowsAzure.ServiceBus SDK](https://github.com/Azure/azure-event-hubs/tree/master/samples/DotNet/Microsoft.ServiceBus/RBAC/EventHubsSenderReceiverRbac) demonstrates using the `MessageFactory` to create an instance of `EventHubClient` that will authenticate using Azure Active Directory.

In the `Azure.Messaging.EventHubs` library, there is no longer a higher-level client that serves as a factory. Instead, the producers and consumers are created directly using the `EventHubProducerClient` or `EventHubConsumerClient` for standard cases. A full description of the client types available can be found above in the [Client hierarchy](#client-hierarchy) section.

Each of the client types supports connection strings as well as Azure Active Directory and other forms of identity. One key change in `Azure.Messaging.EventHubs` is that when using identity credentials, the [`Azure.Identity`](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md) library is used to offer a consistent and uniform approach to authentication across the client libraries for different Azure services. For more information on using identity credentials with Event Hubs, please see the [Identity and Shared Access Credentials](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample06_IdentityAndSharedAccessCredentials.md) sample.

Using a connection string:

```C# Snippet:EventHubs_Migrate_CreateWithConnectionString
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

var producer = new EventHubProducerClient(connectionString, eventHubName);
var consumer = new EventHubConsumerClient(consumerGroup, connectionString, eventHubName);
```

Using an `Azure.Identity` credential:

```C# Snippet:EventHubs_Migrate_CreateWithDefaultAzureCredential
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();
var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential);
var consumer = new EventHubConsumerClient(consumerGroup, fullyQualifiedNamespace, eventHubName, credential);
```

### Publishing events

In the `WindowsAzure.ServiceBus` library, publishing events can be performed by several types, each targeted at a different set of scenarios but with some overlap between them. Generally, the `EventHubClient` is used when publishing events that are not intended for a specific partition and the `EventHubSender` is used for publishing events to a single partition.

In the `Azure.Messaging.EventHubs` library, the `EventHubProducerClient` is used for all event publishing scenarios. It's goal is to provide a consistent experience for publishing with a set of options used to control behavior. For a detailed discussion of common scenarios and options, please see the [Publishing Events](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample04_PublishingEvents.md) sample.

This section will provide a high-level comparison of the most common publishing scenarios.

#### Publishing events with automatic partition assignment

In the `WindowsAzure.ServiceBus` library, to publish events and allow the Event Hubs service to automatically assign the partition, the `EventHubClient` was used as the publisher for a batch created with its default configuration.

```C#
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

EventHubClient client = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);

try
{
    using var eventBatch = client.CreateBatch();

    for (var index = 0; index < 5; ++index)
    {
        var eventData = new EventData(Encoding.UTF8.GetBytes($"Event #{ index }"));

        if (!eventBatch.TryAdd(eventData))
        {
            throw new Exception($"The event at { index } could not be added");
        }
    }

    await client.SendBatchAsync(eventBatch.ToEnumerable());
}
finally
{
    client.Close();
}
```

In the `Azure.Messaging.EventHubs` library, the `EventHubProducerClient` is used as the publisher for a batch created with its default configuration.

```C# Snippet:EventHubs_Sample04_AutomaticRouting
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

var producer = new EventHubProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential);

try
{
    using EventDataBatch eventBatch = await producer.CreateBatchAsync();

    for (var index = 0; index < 5; ++index)
    {
        var eventData = new EventData($"Event #{ index }");

        if (!eventBatch.TryAdd(eventData))
        {
            throw new Exception($"The event at { index } could not be added.");
        }
    }

    await producer.SendAsync(eventBatch);
}
finally
{
    await producer.CloseAsync();
}
```

#### Publishing events with a partition key

In the `WindowsAzure.ServiceBus` library, to publish events and allow the Event Hubs service to automatically assign the partition, the `EventHubClient` was used as the publisher for a batch created with a partition key specified as an option.

```C#
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

EventHubClient client = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);

try
{
    using var eventBatch = client.CreateBatch();

    for (var index = 0; index < 5; ++index)
    {
        var eventData = new EventData(Encoding.UTF8.GetBytes($"Event #{ index }"));
        eventData.PartitionKey = "Any Value Will Do...";

        if (!eventBatch.TryAdd(eventData))
        {
            throw new Exception($"The event at { index } could not be added");
        }
    }

    await client.SendBatchAsync(eventBatch.ToEnumerable());
}
finally
{
    client.Close();
}
```

In the `Azure.Messaging.EventHubs` library, the `EventHubProducerClient` is used as the publisher for a batch created with a partition key specified as an option.

```C# Snippet:EventHubs_Sample04_PartitionKey
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

var producer = new EventHubProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential);

try
{
    var batchOptions = new CreateBatchOptions
    {
        PartitionKey = "Any Value Will Do..."
    };

    using EventDataBatch eventBatch = await producer.CreateBatchAsync(batchOptions);

    for (var index = 0; index < 5; ++index)
    {
        var eventData = new EventData($"Event #{ index }");

        if (!eventBatch.TryAdd(eventData))
        {
            throw new Exception($"The event at { index } could not be added.");
        }
    }

    await producer.SendAsync(eventBatch);
}
finally
{
    await producer.CloseAsync();
}
```

#### Publishing events to a specific partition

In the `WindowsAzure.ServiceBus` library, to publish events to a specific partition, a `EventHubSender` is created using the `EventHubClient` and then used as the publisher for a batch created with its default configuration.

```C#
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

EventHubClient client = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);
EventHubSender sender = default;

try
{
    using var eventBatch = client.CreateBatch();

    for (var index = 0; index < 5; ++index)
    {
        var eventData = new EventData(Encoding.UTF8.GetBytes($"Event #{ index }"));

        if (!eventBatch.TryAdd(eventData))
        {
            throw new Exception($"The event at { index } could not be added");
        }
    }

    string firstPartition = (await client.GetRuntimeInformationAsync()).PartitionIds.First();
    sender = client.CreatePartitionedSender(firstPartition);

    await sender.SendBatchAsync(eventBatch.ToEnumerable());
}
finally
{
    sender?.Close();
    client.Close();
}
```

In the `Azure.Messaging.EventHubs` library, the `EventHubProducerClient` is used as the publisher for a batch created with a partition identifier specified as an option.

```C# Snippet:EventHubs_Sample04_PartitionId
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

var producer = new EventHubProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential);

try
{
    string firstPartition = (await producer.GetPartitionIdsAsync()).First();

    var batchOptions = new CreateBatchOptions
    {
        PartitionId = firstPartition
    };

    using EventDataBatch eventBatch = await producer.CreateBatchAsync(batchOptions);

    for (var index = 0; index < 5; ++index)
    {
        var eventData = new EventData($"Event #{ index }");

        if (!eventBatch.TryAdd(eventData))
        {
            throw new Exception($"The event at { index } could not be added.");
        }
    }

    await producer.SendAsync(eventBatch);
}
finally
{
    await producer.CloseAsync();
}
```

### Reading events

In the older packages, reading events can be performed by either the `EventProcessorHost` or the `EventHubReceiver`, depending on whether you would like to read from all partitions of an Event Hub or a single partition. Generally, using the `EventProcessorHost` is the preferred approach for most production scenarios.

The `Azure.Messaging.EventHubs` library also provides multiple types for reading events, with the `EventProcessorClient` focused on reading from all partitions, and the `EventHubConsumerClient` and `PartitionReceiver` focused on reading from a single partition. The `EventProcessorClient` is the preferred approach for most production scenarios. For a detailed discussion of common scenarios and options, please see the [Event Processor Client](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples) and [Reading Events](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample05_ReadingEvents.md) samples.

#### Reading events from all partitions

In `Microsoft.Azure.ServiceBus.EventProcessorHost`, the `EventProcessorHost` provides a framework that allows you to concentrate on writing your business logic to process events while the processor holds responsibility for concerns such as resiliency, balancing work between multiple instances of your program, and supporting the creation of checkpoints to preserve state. Developers would have to create and register a concrete implementation of `IEventProcessor` to begin consuming events.

```C#
public class SimpleEventProcessor : IEventProcessor
{
    public Task CloseAsync(PartitionContext context, CloseReason reason)
    {
         Debug.WriteLine($"Partition '{context.PartitionId}' is closing.");
         return Task.CompletedTask;
    }

    public Task OpenAsync(PartitionContext context)
    {
        Debug.WriteLine($"Partition: '{context.PartitionId}' was initialized.");
        return Task.CompletedTask;
    }

    public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
    {
        foreach (var eventData in messages)
        {
            byte[] eventBody = eventData.GetBytes();
            Debug.WriteLine($"Event from partition { context.PartitionId } with length { eventBody.Length }.");
        }

        return Task.CompletedTask;
    }
}
```

```C#
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var eventProcessorHost = new EventProcessorHost(
    eventHubName,
    consumerGroup,
    eventHubsConnectionString,
    storageConnectionString);

try
{
    // Registering the processor class will also signal the
    // host to begin processing events.

    await eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>();

    // The processor runs in the background, to allow it to process,
    // this example will wait for 30 seconds and then trigger
    // cancellation.

    using var cancellationSource = new CancellationTokenSource();
    cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

    await Task.Delay(Timeout.Infinite, cancellationSource.Token);
}
catch (TaskCanceledException)
{
    // This is expected when the cancellation token is
    // signaled.
}
finally
{
    // Unregistering the processor class will signal the
    // host to stop processing.

    await eventProcessorHost.UnregisterEventProcessorAsync();
}
```

In `Azure.Messaging.EventHubs`, the `EventProcessorClient` fills the same role. It also provides a framework that allows you to concentrate on writing your business logic to process events while the processor holds responsibility for concerns such as resiliency, balancing work between multiple instances of your program, and supporting the creation of checkpoints to preserve state. Rather than writing your own class, the `EventProcessorClient` offers a set of event handlers to support registering your logic.

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

#### Reading events from a single partition

In the `WindowsAzure.ServiceBus` library, to read events from a partition, a `EventHubReceiver` is created using the `EventHubClient` and events are read in a pull-based manner.

```C#
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroupName = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

EventHubClient client = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);
EventHubConsumerGroup consumerGroup = ehClient.GetConsumerGroup(consumerGroupName);
EventHubReceiver receiver = default;

try
{
    string firstPartition = (await client.GetRuntimeInformationAsync()).PartitionIds.First();
    receiver = await consumerGroup.CreateReceiverAsync(firstPartition, EventHubConsumerGroup.StartOfStream);

    IEnumerable<EventData> events = await receiver.ReceiveAsync(50);

    foreach (var eventData in events)
    {
       byte[] eventBody = eventData.GetBytes();
       Debug.WriteLine($"Read event of length { eventBody.Length } from { firstPartition }");
    }
}
finally
{
    receiver?.Close();
    client.Close();
}
```

In the `Azure.Messaging.EventHubs` library, the `EventHubConsumerClient` can be used to read events from a partition in a streaming manner using the asynchronous enumerator pattern.

```C# Snippet:EventHubs_Sample05_ReadPartition
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();
var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

var consumer = new EventHubConsumerClient(
    consumerGroup,
    fullyQualifiedNamespace,
    eventHubName,
    credential);

try
{
    using CancellationTokenSource cancellationSource = new CancellationTokenSource();
    cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

    string firstPartition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
    EventPosition startingPosition = EventPosition.Earliest;

    await foreach (PartitionEvent partitionEvent in consumer.ReadEventsFromPartitionAsync(
        firstPartition,
        startingPosition,
        cancellationSource.Token))
    {
        string readFromPartition = partitionEvent.Partition.PartitionId;
        ReadOnlyMemory<byte> eventBodyBytes = partitionEvent.Data.EventBody.ToMemory();

        Debug.WriteLine($"Read event of length { eventBodyBytes.Length } from { readFromPartition }");
    }
}
catch (TaskCanceledException)
{
    // This is expected if the cancellation token is
    // signaled.
}
finally
{
    await consumer.CloseAsync();
}
```

For those that prefer a batched approach to reading, `Azure.Messaging.EventHubs` also offers a `PartitionReceiver` that follows pull-based semantics.

```C# Snippet:EventHubs_Sample05_ReadPartitionWithReceiver
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();
var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

using CancellationTokenSource cancellationSource = new CancellationTokenSource();
cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

string firstPartition;

await using (var producer = new EventHubProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential))
{
    firstPartition = (await producer.GetPartitionIdsAsync()).First();
}

var receiver = new PartitionReceiver(
    consumerGroup,
    firstPartition,
    EventPosition.Earliest,
    fullyQualifiedNamespace,
    eventHubName,
    credential);

try
{
    while (!cancellationSource.IsCancellationRequested)
    {
        int batchSize = 50;
        TimeSpan waitTime = TimeSpan.FromSeconds(1);

        IEnumerable<EventData> eventBatch = await receiver.ReceiveBatchAsync(
            batchSize,
            waitTime,
            cancellationSource.Token);

        foreach (EventData eventData in eventBatch)
        {
            byte[] eventBodyBytes = eventData.EventBody.ToArray();
            Debug.WriteLine($"Read event of length { eventBodyBytes.Length } from { firstPartition }");
        }
    }
}
catch (TaskCanceledException)
{
    // This is expected if the cancellation token is
    // signaled.
}
finally
{
    await receiver.CloseAsync();
}
```

## Additional samples

More examples can be found at:

-   [Event Hubs samples](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples)
-   [Event Hubs Processor samples](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples)
-   [Building a custom Event Hubs Event Processor with .NET](https://devblogs.microsoft.com/azure-sdk/custom-event-processor/) _(blog article)_
