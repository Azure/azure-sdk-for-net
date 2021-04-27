# Guide for migrating to Azure.Messaging.EventHubs from Microsoft.Azure.EventHubs

This guide is intended to assist in the migration to the `Azure.Messaging.EventHubs` family of packages from the legacy `Microsoft.Azure.EventHubs` family of packages.  It will focus on side-by-side comparisons for similar operations between the to versions, covering the [`Azure.Messaging.EventHubs`](https://www.nuget.org/packages/Azure.Messaging.EventHubs/) and [`Azure.Messaging.EventHubs.Processor`](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor/) packages and their legacy equivalents, [`Microsoft.Azure.EventHubs`](https://www.nuget.org/packages/Microsoft.Azure.EventHubs/) and [`Microsoft.Azure.EventHubs.Processor`](https://www.nuget.org/packages/Microsoft.Azure.EventHubs.Processor/).

Familiarity with the `Microsoft.Azure.EventHubs` family of packages is assumed.  For those new to the Event Hubs client library for .NET, please refer to the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/README.md), [Event Hubs samples](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples), and the [Event Processor samples](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples) rather than this guide.

## Table of contents

- [Migration benefits](#migration-benefits)
- [General changes](#general-changes)
  - [Package and namespaces](#package-and-namespaces)
  - [Client hierarchy](#client-hierarchy)
  - [Client constructors](#client-constructors)
  - [Publishing events](#publishing-events)
    - [With automatic partition assignment](#publishing-events-with-automatic-partition-assignment)
    - [With a partition key](#publishing-events-with-a-partition-key)
    - [To a specific partition](#publishing-events-to-a-specific-partition)
  - [Reading events](#reading-events)
    - [From all partitions](#reading-events-from-all-partitions)
    - [From a single partition](#reading-events-from-a-single-partition)
- [Migrating Event Processor checkpoints](#migrating-eventprocessorhost-checkpoints)
- [Additional samples](#additional-samples)

## Migration benefits

A natural question to ask when considering whether or not to adopt a new version or library is what the benefits of doing so would be.  As Azure has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem.  One of the most important is that the client libraries for different Azure services have not had a consistent approach to organization, naming, and API structure.  Additionally, many developers have felt that the learning curve was difficult, and the APIs did not offer a good, approachable, and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To try and improve the development experience across Azure services, including Event Hubs, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services.  A set of [.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel that mirrors that of the .NET base class libraries.  Further details are available in the guidelines for those interested.

The new Event Hubs client library is designed to provide an approachable onboarding experience for those new to messaging and/or the Event Hubs service with the goal of enabling a quick initial feedback loop for publishing and consuming events.  A gradual step-up path follows, building on the onboarding experience and shifting from exploration to tackling real-world production scenarios.  For developers with high-throughput scenarios or specialized needs, a set of lower-level primitives are available to offer less abstraction and greater control.

While we believe that there is significant benefit to adopting the new Event Hubs client library, it is important to be aware that the legacy version has not been officially deprecated.  It will continue to be supported with security and bug fixes as well as receiving some minor refinements.  However, in the near future it will not be under active development and new features are unlikely to be added.  There is no guarantee of feature parity between the  and legacy client library versions.

## Cross-service SDK improvements

The `Azure.Messaging.EventHubs` family of packages also provide the ability to share in some of the cross-service improvements made to the Azure development experience, such as:

- Using the new `Azure.Identity` library to share a single authentication between clients
- A unified diagnostics pipeline offering a common view of the activities across each of the client libraries

## General changes

### Package and namespaces

Package names and the namespace root for the Azure client libraries for .NET have changed.  Each will follow the pattern `Azure.[Area].[Service]` where the legacy clients followed the pattern `Microsoft.Azure.[Service]`.  This provides a quick and accessible means to help understand, at a glance, whether you are using the current generation or legacy clients.

In the case of Event Hubs, the client libraries have packages and namespaces that begin with `Azure.Messaging.EventHubs` and were released beginning with version 5.x.x.  The legacy client libraries have packages and namespaces that begin with `Microsoft.Azure.EventHubs` and a version of 4.x.x or below.

### Client hierarchy

The key goal for the Event Hubs client library is to provide a first-class experience for developers, from early exploration of Event Hubs through real-world use.  We wanted to simplify the API surface to focus on scenarios important to the majority of developers without losing support for those with specialized needs.  To achieve this, the client hierarchy has been split into two general categories, mainstream and specialized.  

The mainstream set of clients provides an approachable onboarding experience for those new to Event Hubs with a clear step-up path to production use.  The specialized set of clients is focused on high-throughput and allowing developers a higher degree of control, at the cost of more complexity in their use.  This section will briefly introduce the clients in both categories, with the remainder of the migration guide focused on mainstream scenarios.

#### Mainstream  

In order to allow for a single focus and clear responsibility, the core functionality for publishing and reading events belongs to two distinct clients, rather than the single `EventHubClient` used by previous versions.  The producer and consumer clients operate in the context of a specific Event Hub and offer operations for all partitions. Clients in the `Azure.Messaging.EventHubs` family are not bound to a specific partition, instead offering specific partitions to be provided at the method-level, where needed.

- The [EventHubProducerClient](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.producer?view=azure-dotnet) is responsible for publishing events and supports multiple approaches for selecting the partition to which the event is associated, including automatic routing by the Event Hubs service and specifying an explicit partition.
  
- The [EventHubConsumerClient](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.consumer.eventhubconsumerclient?view=azure-dotnet) supports reading events from a single partition and also offers an easy way to familiarize yourself with Event Hubs by reading from all partitions without the rigor and complexity that you would need in a production application. For reading events from all partitions in a production scenario, we strongly recommend using the [EventProcessorClient](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventprocessorclient?view=azure-dotnet) over the `EventHubConsumerClient`.

- The [EventProcessorClient](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventprocessorclient?view=azure-dotnet) is responsible for reading and processing events for all partitions of an Event Hub. It will collaborate with other instances for the same Event Hub and consumer group pairing to balance work between them.  A high degree of fault tolerance is built-in, allowing the processor to be resilient in the face of errors.  The `EventProcessorClient` can be found in the [Azure.Messaging.EventHubs.Processor](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor/) package. 
  
  One of the key features of the `EventProcessorClient` is enabling tracking of which events have been processed by interacting with a durable storage provider.  This process is commonly referred to as [checkpointing](https://docs.microsoft.com/azure/event-hubs/event-hubs-features#checkpointing) and the persisted state as a checkpoint.  This version of the `EventProcessorClient` supports only Azure Storage Blobs as a backing store.  
  
  **_Important note on checkpoints:_**  The [EventProcessorClient](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventprocessorclient?view=azure-dotnet) does not support legacy checkpoint data created using the `EventProcessorHost` from the `Microsoft.Azure.EventHubs.Processor` package.  In order to allow for a unified format for checkpoint data across languages, a more efficient approach to data storage, and improvements to the algorithm used for managing partition ownership, breaking changes were necessary.  An approach for migrating the legacy `EventProcessorHost` checkpoints can be found in the [checkpoint migration section](#migrating-eventprocessorhost-checkpoints) below.

#### Specialized

- The [PartitionReceiver](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.primitives.partitionreceiver?view=azure-dotnet) is responsible for reading events from a specific partition of an Event Hub, with a greater level of control over communication with the Event Hubs service than is offered by other event consumers.  More detail on the design and philosophy for the `PartitionReceiver` can be found in its [design document](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/design/proposal-partition-receiver.md).

- The [EventProcessor&lt;TPartition&gt;](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.primitives.eventprocessor-1?view=azure-dotnet) provides a base for creating a custom processor for reading and processing events for all partitions of an Event Hub. The `EventProcessor<TPartition>` fills a similar role as the EventProcessorClient, with cooperative load balancing and resiliency as its core features.  However, it also offers native batch processing, the ability to customize checkpoint storage, a greater level of control over communication with the Event Hubs service, and a less opinionated API.  The caveat is that this comes with additional complexity and exists as of an abstract base, which needs to be extended and the core "handler" activities implemented via override. 

  Generally speaking, the `EventProcessorClient` was designed to provide a familiar API to that of the `EventHubConsumerClient` and offer an intuitive "step-up" experience for developers exploring Event Hubs as they advance to production scenarios.  For a large portion of our library users, that covers their needs well.  There's definitely a point, however, where an application requires more control to handle higher throughput or unique needs - that's where the `EventProcessor<TPartition>` is intended to help.  More on the design and philosophy behind this type can be found in its [design document](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/design/proposal-event-processor%7BT%7D.md).

### Client constructors

In the `Microsoft.Azure.EventHubs` library, publishing and reading events started by creating an instance of the `EventHubClient` and then using that as a factory for producers and consumers.  The client can be created using a connection string or a variety of token providers.

Using a connection string:

```C# Snippet:EventHubs_Migrate_T1_CreateWithConnectionString
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var builder = new EventHubsConnectionStringBuilder(connectionString);
builder.EntityPath = eventHubName;

EventHubClient client = EventHubClient.CreateFromConnectionString(builder.ToString());
```

Using an Azure Active Directory credential:

```C# Snippet:EventHubs_Migrate_T1_CreateWithAzureActiveDirectory
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var authority = "<< NAME OF THE AUTHORITY TO ASSOCIATE WITH THE TOKEN >>";
var aadAppId = "<< THE AZURE ACTIVE DIRECTORY APPLICATION ID TO REQUEST A TOKEN FOR >>";
var aadAppSecret = "<< THE AZURE ACTIVE DIRECTORY SECRET TO USE FOR THE TOKEN >>";

AzureActiveDirectoryTokenProvider.AuthenticationCallback authCallback =
    async (audience, authority, state) =>
    {
        var authContext = new AuthenticationContext(authority);
        var clientCredential = new ClientCredential(aadAppId, aadAppSecret);

        AuthenticationResult authResult = await authContext.AcquireTokenAsync(audience, clientCredential);
        return authResult.AccessToken;
    };

EventHubClient client = EventHubClient.CreateWithAzureActiveDirectory(
    new Uri(fullyQualifiedNamespace),
    eventHubName,
    authCallback,
    authority);
```

Using a Managed Identity:

```C# Snippet:EventHubs_Migrate_T1_ManagedIdentity
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

EventHubClient client = EventHubClient.CreateWithManagedIdentity(
    new Uri(fullyQualifiedNamespace),
    eventHubName);
```

In the `Azure.Messaging.EventHubs` library, there is no longer a higher-level client that serves as a factory.  Instead, the producers and consumers are created directly using the `EventHubProducerClient` or `EventHubConsumerClient` for standard cases.  A full description of the client types available can be found above in the [Client hierarchy](#client-hierarchy) section.

Each of the client types supports connection strings as well as Azure Active Directory and other forms of identity.  One key change in `Azure.Messaging.EventHubs` is that when using identity credentials, the [`Azure.Identity`](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md) library is used to offer a consistent and uniform approach to authentication across the client libraries for different Azure services.  For more information on using identity credentials with Event Hubs, please see the [Identity and Shared Access Credentials](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample06_IdentityAndSharedAccessCredentials.md) sample.

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
TokenCredential credential = new DefaultAzureCredential();

var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential);
var consumer = new EventHubConsumerClient(consumerGroup, fullyQualifiedNamespace, eventHubName, credential);
```

### Publishing events

In the `Microsoft.Azure.EventHubs` library, publishing events can be performed by several types, each targeted at a different set of scenarios but with some overlap between them.  Generally, the `EventHubClient` is used when publishing events that are not intended for a specific partition and the `PartitionSender` is used for publishing events to a single partition.

In the `Azure.Messaging.EventHubs` library, the `EventHubProducerClient` is used for all event publishing scenarios.  It's goal is to provide a consistent experience for publishing with a set of options used to control behavior.  For a detailed discussion of common scenarios and options, please see the [Publishing Events](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample04_PublishingEvents.md) sample.

This section will provide a high-level comparison of the most common publishing scenarios.

#### Publishing events with automatic partition assignment

In the `Microsoft.Azure.EventHubs` library, to publish events and allow the Event Hubs service to automatically assign the partition, the `EventHubClient` was used as the publisher for a batch created with its default configuration.

```C# Snippet:EventHubs_Migrate_T1_PublishWithAutomaticRouting
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var builder = new EventHubsConnectionStringBuilder(connectionString);
builder.EntityPath = eventHubName;

EventHubClient client = EventHubClient.CreateFromConnectionString(builder.ToString());

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

    await client.SendAsync(eventBatch);
}
finally
{
    client.Close();
}
```

In the `Azure.Messaging.EventHubs` library, the `EventHubProducerClient` is used as the publisher for a batch created with its default configuration.

```C# Snippet:EventHubs_Sample04_AutomaticRouting
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var producer = new EventHubProducerClient(connectionString, eventHubName);

try
{
    using var eventBatch = await producer.CreateBatchAsync();

    for (var index = 0; index < 5; ++index)
    {
        var eventBody = new BinaryData($"Event #{ index }");
        var eventData = new EventData(eventBody);

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

In the `Microsoft.Azure.EventHubs` library, to publish events and allow the Event Hubs service to automatically assign the partition, the `EventHubClient` was used as the publisher for a batch created with a partition key specified as an option.

```C# Snippet:EventHubs_Migrate_T1_PublishWithAPartitionKey
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var builder = new EventHubsConnectionStringBuilder(connectionString);
builder.EntityPath = eventHubName;

EventHubClient client = EventHubClient.CreateFromConnectionString(builder.ToString());

try
{
    var batchOptions = new BatchOptions
    {
        PartitionKey = "Any Value Will Do..."
    };

    using var eventBatch = client.CreateBatch(batchOptions);

    for (var index = 0; index < 5; ++index)
    {
        var eventData = new EventData(Encoding.UTF8.GetBytes($"Event #{ index }"));

        if (!eventBatch.TryAdd(eventData))
        {
            throw new Exception($"The event at { index } could not be added");
        }
    }

    await client.SendAsync(eventBatch);
}
finally
{
    client.Close();
}
```

In the `Azure.Messaging.EventHubs` library, the `EventHubProducerClient` is used as the publisher for a batch created with a partition key specified as an option.

```C# Snippet:EventHubs_Sample04_PartitionKey
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var producer = new EventHubProducerClient(connectionString, eventHubName);

try
{
    var batchOptions = new CreateBatchOptions
    {
        PartitionKey = "Any Value Will Do..."
    };

    using var eventBatch = await producer.CreateBatchAsync(batchOptions);

    for (var index = 0; index < 5; ++index)
    {
        var eventBody = new BinaryData($"Event #{ index }");
        var eventData = new EventData(eventBody);

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

In the `Microsoft.Azure.EventHubs` library, to publish events and allow the Event Hubs service to automatically assign the partition, a `PartitionSender` is created using the `EventHubClient` and then used as the publisher for a batch created with its default configuration.

```C# Snippet:EventHubs_Migrate_T1_PublishToSpecificPartition
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var builder = new EventHubsConnectionStringBuilder(connectionString);
builder.EntityPath = eventHubName;

EventHubClient client = EventHubClient.CreateFromConnectionString(builder.ToString());
PartitionSender sender = default;

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
    sender = client.CreatePartitionSender(firstPartition);

    await sender.SendAsync(eventBatch);
}
finally
{
    sender?.Close();
    client.Close();
}
```

In the `Azure.Messaging.EventHubs` library, the `EventHubProducerClient` is used as the publisher for a batch created with a partition identifier specified as an option.

```C# Snippet:EventHubs_Sample04_PartitionId
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var producer = new EventHubProducerClient(connectionString, eventHubName);

try
{
    string firstPartition = (await producer.GetPartitionIdsAsync()).First();

    var batchOptions = new CreateBatchOptions
    {
        PartitionId = firstPartition
    };

    using var eventBatch = await producer.CreateBatchAsync(batchOptions);

    for (var index = 0; index < 5; ++index)
    {
        var eventBody = new BinaryData($"Event #{ index }");
        var eventData = new EventData(eventBody);

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

In the `Microsoft.Azure.EventHubs` library, reading events can be performed by either the `EventProcessorHost` or the `PartitionReceiver`, depending on whether you would like to read from all partitions of an Event Hub or a single partition.  Generally, using the `EventProcessorHost` is the preferred approach for most production scenarios.  

The `Azure.Messaging.EventHubs` library also provides multiple types for reading events, with the `EventProcessorClient` focused on reading from all partitions, and the `EventHubConsumerClient` and `PartitionReceiver` focused on reading from a single partition. The `EventProcessorClient` is the preferred approach for most production scenarios.  For a detailed discussion of common scenarios and options, please see the [Event Processor Client](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples) and [Reading Events](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample05_ReadingEvents.md) samples.

#### Reading events from all partitions

In `Microsoft.Azure.EventHubs`, the `EventProcessorHost` provides a framework that allows you to concentrate on writing your business logic to process events while the processor holds responsibility for concerns such as resiliency, balancing work between multiple instances of your program, and supporting the creation of checkpoints to preserve state.  Developers would have to create and register a concrete implementation of `IEventProcessor` to begin consuming events.

```C# Snippet:EventHubs_Migrate_T1_SimpleEventProcessor
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

    public Task ProcessErrorAsync(PartitionContext context, Exception error)
    {
        Debug.WriteLine(
            $"Error for partition: {context.PartitionId}, " +
            $"Error: {error.Message}");

        return Task.CompletedTask;
    }

    public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
    {
        foreach (var eventData in messages)
        {
            var data = Encoding.UTF8.GetString(
                eventData.Body.Array,
                eventData.Body.Offset,
                eventData.Body.Count);

            Debug.WriteLine(
                $"Event received for partition: '{context.PartitionId}', " +
                $"Data: '{data}'");
        }

        return Task.CompletedTask;
    }
}
```

```C# Snippet:EventHubs_Migrate_T1_BasicEventProcessorHost
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var eventProcessorHost = new EventProcessorHost(
    eventHubName,
    consumerGroup,
    eventHubsConnectionString,
    storageConnectionString,
    blobContainerName);

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

In `Azure.Messaging.EventHubs`, the `EventProcessorClient` fills the same role.  It also provides a framework that allows you to concentrate on writing your business logic to process events while the processor holds responsibility for concerns such as resiliency, balancing work between multiple instances of your program, and supporting the creation of checkpoints to preserve state.  Rather than writing your own class, the `EventProcessorClient` offers a set of event handlers to support registering your logic.

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

In the `Microsoft.Azure.EventHubs` library, to read events from a partition, a `PartitionReceiver` is created using the `EventHubClient` and events are read in a pull-based manner.

```C# Snippet:EventHubs_Migrate_T1_ReadFromSpecificPartition
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var builder = new EventHubsConnectionStringBuilder(connectionString);
builder.EntityPath = eventHubName;

EventHubClient client = EventHubClient.CreateFromConnectionString(builder.ToString());
PartitionReceiver receiver = default;

try
{
    string firstPartition = (await client.GetRuntimeInformationAsync()).PartitionIds.First();
    receiver = client.CreateReceiver(consumerGroup, firstPartition, EventPosition.FromStart());

    IEnumerable<EventData> events = await receiver.ReceiveAsync(50);

    foreach (var eventData in events)
    {
       Debug.WriteLine($"Read event of length { eventData.Body.Count } from { firstPartition }");
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
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

var consumer = new EventHubConsumerClient(
    consumerGroup,
    connectionString,
    eventHubName);

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
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

using CancellationTokenSource cancellationSource = new CancellationTokenSource();
cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

string firstPartition;

await using (var producer = new EventHubProducerClient(connectionString, eventHubName))
{
    firstPartition = (await producer.GetPartitionIdsAsync()).First();
}

var receiver = new PartitionReceiver(
    consumerGroup,
    firstPartition,
    EventPosition.Earliest,
    connectionString,
    eventHubName);

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

## Migrating EventProcessorHost checkpoints

In `Microsoft.Azure.EventHubs`, the `EventProcessorHost` supported a model of pluggable storage providers for checkpoint data, using Azure Storage Blobs as the default.  Using the Azure Storage checkpoint manager, the lease and checkpoint information is stored as a JSON blob appearing within the Azure Storage account provided to the `EventProcessorHost`.  More details can be found in the [documentation](https://docs.microsoft.com/azure/event-hubs/event-hubs-event-processor-host#partition-ownership-tracking).

In `Azure.Messaging.EventHubs`, the `EventProcessorClient` is an opinionated implementation, storing checkpoints in Azure Storage Blobs using the blob metadata to track information.  Unfortunately, the `EventProcessorClient` is unable to consume legacy checkpoints due to the differences in format, approach, and the possibility of a custom checkpoint provider having been used.

Though the implementation differs, the core information tracked is consistent and can be migrated using the Azure Blob Storage client library.  The attributes needed from the legacy checkpoint can be visualized as the following structure.

```C# Snippet:EventHubs_Migrate_CheckpointFormat
private class MigrationCheckpoint
{
    public string PartitionId { get; set; }
    public string Offset { get; set; }
    public long SequenceNumber { get; set; }
}
```

The `Azure.Messaging.EventHubs` checkpoints are expected by the `EventProcessorClient` to exist in a specifically named blob per partition that contains two metadata attributes.  Any content of the blob itself is ignored.  Casing is significant where both the name of the blob and the metadata attributes are concerned and must be lowercase.  

```C# Snippet:EventHubs_Migrate_Checkpoints
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER  >>";
var legacyBlobContainerName = "<< NAME OF THE BLOB CONTAINER THAT CONTAINS THE LEGACY DATA>>";

using var cancellationSource = new CancellationTokenSource();

// Read the legacy checkpoints; these are read eagerly, as the number of partitions
// for an Event Hub is limited so the set should be a manageable size to hold in memory.
//
// Note: The ReadLegacyCheckpoints method will be defined in another snippet.

var legacyCheckpoints = await ReadLegacyCheckpoints(
    storageConnectionString,
    legacyBlobContainerName,
    consumerGroup,
    cancellationSource.Token);

// The member names of MigrationCheckpoint match the names of the checkpoint
// names of the checkpoint metadata keys.

var offsetKey = nameof(MigrationCheckpoint.Offset).ToLowerInvariant();
var sequenceKey = nameof(MigrationCheckpoint.SequenceNumber).ToLowerInvariant();

// The checkpoint blobs require a specific naming scheme to be valid for use
// with the EventProcessorClient.

var prefix = string.Format(
    "{0}/{1}/{2}/checkpoint/",
    fullyQualifiedNamespace.ToLowerInvariant(),
    eventHubName.ToLowerInvariant(),
    consumerGroup.ToLowerInvariant());

// Create the storage client to write the migrated checkpoints.  This example
// assumes that the connection string grants the appropriate permissions to create a
// container in the storage account.

var storageClient = new BlobContainerClient(storageConnectionString, blobContainerName);
await storageClient.CreateIfNotExistsAsync(cancellationToken: cancellationSource.Token);

// Translate each of the legacy checkpoints, storing the offset and
// sequence data into the correct blob for use with the EventProcesorClient.

foreach (var checkpoint in legacyCheckpoints)
{
    var metadata = new Dictionary<string, string>()
    {
        { offsetKey, checkpoint.Offset.ToString(CultureInfo.InvariantCulture) },
        { sequenceKey, checkpoint.SequenceNumber.ToString(CultureInfo.InvariantCulture) }
    };

    BlobClient blobClient = storageClient.GetBlobClient($"{ prefix }{ checkpoint.PartitionId }");

    using var content = new MemoryStream(Array.Empty<byte>());
    await blobClient.UploadAsync(content, metadata: metadata, cancellationToken: cancellationSource.Token);
}
```

The following snippet to read and parse legacy checkpoints assumes that the default prefix configuration for the `EventProcessorHost` was used.  If a custom prefix was configured, this code will need to be adjusted to account for the difference in format.

```C# Snippet:EventHubs_Migrate_LegacyCheckpoints
private async Task<List<MigrationCheckpoint>> ReadLegacyCheckpoints(
    string connectionString,
    string container,
    string consumerGroup,
    CancellationToken cancellationToken)
{
    var storageClient = new BlobContainerClient(connectionString, container);

    // If there is no container, no action can be taken.

    if (!(await storageClient.ExistsAsync(cancellationToken)))
    {
        throw new ArgumentException("The source container does not exist.", nameof(container));
    }

    // Read and process the legacy checkpoints.

    var checkpoints = new List<MigrationCheckpoint>();

    await foreach (var blobItem in storageClient.GetBlobsAsync(BlobTraits.All, BlobStates.All, consumerGroup, cancellationToken))
    {
        using var blobContentStream = new MemoryStream();
        await (storageClient.GetBlobClient(blobItem.Name)).DownloadToAsync(blobContentStream);

        var checkpoint = JsonSerializer.Deserialize<MigrationCheckpoint>(Encoding.UTF8.GetString(blobContentStream.ToArray()));
        checkpoints.Add(checkpoint);
    }

    return checkpoints;
}
```

## Additional samples

More examples can be found at:
- [Event Hubs samples](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples)
- [Event Hubs Processor samples](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples)
- [Building a custom Event Hubs Event Processor with .NET](https://devblogs.microsoft.com/azure-sdk/custom-event-processor/) _(blog article)_
