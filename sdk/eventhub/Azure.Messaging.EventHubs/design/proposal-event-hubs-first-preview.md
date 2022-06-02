# .NET Event Hubs Client: Track Two Proposal (First Preview)

## Summary

Azure Event Hubs is a highly scalable publish-subscribe service that can ingest millions of events per second and stream them to multiple consumers. This lets you process and analyze the massive amounts of data produced by your connected devices and applications. Once Event Hubs has collected the data, you can retrieve, transform and store it by using any real-time analytics provider or with batching/storage adapters.

The Azure Event Hubs client libraries allow for sending and receiving of Azure Event Hubs events. Most common scenarios call for an application to act as either an event publisher or an event consumer, but rarely both.

An **event publisher** is a source of telemetry data, diagnostics information, usage logs, or other log data, as part of an embedded device solution, a mobile device application, a game title running on a console or other device, some client or server based business solution, or a web site.  

An **event consumer** picks up such information from the Event Hub and processes it. Processing may involve aggregation, complex computation and filtering. Processing may also involve distribution or storage of the information in a raw or transformed fashion. Event Hub consumers are often robust and high-scale platform infrastructure parts with built-in analytics capabilities, like Azure Stream Analytics, Apache Spark, or Apache Storm.  

## Goals

- Provide an API surface that allows for successfully implementing common scenarios with a minimal amount of boilerplate or bootstrapping needed; what a consumer views as one logical operation should feel like a single task when implementing.

- Ensure that the API is as intuitive, discoverable, and straightforward as possible, guiding users of the library to success and minimizing potential pitfalls.

- Present an API that is consistent and familiar across the different languages and technology stacks, while still conforming to the native idioms and conventions for a given ecosystem.

- Focus the API design on the patterns best suited to users of the client library; the API may not mirror the interface used for interacting with the Event Hubs service.
 
- Minimize breaking changes; ensure that changes made are done with a good reason and offer a solid return on investment.  Where possible, preserve the current interface and semantics.

- Prioritize ease of use by providing reasonable defaults for common operations, allowing configuration and advanced behavior to be ignored unless specifically needed by a consuming application.

- Support customization, allowing defaults to be overridden and accepting additional information such that users of the library are in control of behavior in areas supported by the Event Hubs service.

- Embrace testability, ensuring that constructs from the API can be easily mocked within a consuming application such that the consumer may perform testing without the need to interact with the Event Hubs service or include it's own layer of abstraction over the API.

- Make reasonable efforts to avoid redefining the vocabulary and nomenclature used with Event Hubs; to ensure that current client library users can leverage their familiarity, where possible, the new API surface should continue to use existing terminology.  Revisions and new concepts should be introduced only when necessary to reduce confusion and provide more clarity.

- Align the target platforms with those approved as standards by the architecture board for .NET client libraries.  

## Non-Goals

- Introduction of API enhancements that require upstream changes to the Event Hubs service; the track two client library should target the existing Event Hubs service operations.

- Deprecation of the track one packages or source; until such time that the track two API and associated packages are fully reviewed, tested, and deemed ready, the track one packages will continue to be available, accept issues, and receive minor enhancements and bug fixes.

- Preserving compatibility with the current set of target platforms supported by the track one client library.

## Non-Goals for the First Preview

- A full rewrite of the track one codebase; where possible, existing code will be used with as few modifications as possible, allowing the new API surface to be built on proven, reliable, and well-tested code. 

- Support for scenarios outside the identified targets or revisions to associated packages, such as the Event Hubs Processor; the initial efforts will be focused on the API surface for key operations in the core client library.

- Allowing event consumers to specify a handler to be notified when new events appear in a partition _(commonly referred to as the "streaming consumer" pattern)_; this requires additional design and will be deferred until after the preview.

- Support for the Event Hubs plugin model; these are considered an advanced scenario and out of scope for the preview.

- Advanced batching scenarios, such as automatically splitting a set of events too large for a single batch into multiple batches or providing the ability to build a size-constrained batch, are out of scope for the preview.

- Providing a full synchronous API surface; the preview design will be primarily focused on asynchronous operations.  

- Design of the exception hierarchy; the preview will make use of the existing exception surfacing present in the track one client library. 

- Ensuring that cancellation tokens are honored throughout the implementation; they will be accepted as part of the API but may not have an effect depending on acceptance and treatment by the infrastructure provided by the track one client library.


## High Level Scenarios

### Producers Can Publish Events

Contoso is developing a new first person shooter game, _Hugs and Warfare_, intended to be delivered across multiple platforms including the PC, consoles, and mobile devices.  One of the features offered is for players to be granted badges in real-time for completing in-game actions.  In support of this feature, _Hugs and Warfare_, would like to emit observations about a player's match as they happen so that their complex event processing system can evaluate them against award rules.

Due to the expected popularity of the game, Contoso expects to be sending roughly one million events per second across 300,000 concurrent players.  Because this is an action game, the budget for network activity and latency tolerance are not generous, so maintaining a persistent connection for the duration of a match is preferred over a request/response cycle with higher latency and bandwidth needs.    

### Consumers Can Receive Events

For _Hugs and Warfare_ to fulfill its promise of granting badges to players in real-time for actions they perform in a match, its back-end services need to have access to the stream of observations that the game client is emitting as they become available.  Contoso is also interested in analyzing the observations made by game clients in different ways, allowing them to influence the game design and to drive business decisions.

Because those interested in the observations have different purposes and throughput needs, Contoso's design calls for several sets of consumers to forward observations to downstream systems.  Each set of consumers should be able to see the same stream of observations, so that all observations are available to each interested system.  The different sets are independent from one another and should not have a need to coordinate between them. 

### When a Consumer Recovers from a Crash, They Can Resume Receiving Events

Software, hardware, and networks are inherently unreliable.  In order to provide a good player experience for _Hugs and Warfare_, Contoso has planned for their consumers suffering the occasional crash.  They've chosen to have several monitors which test the consumers and ensure that they are healthy and working correctly.  

In the case where a consumer has been restarted, Contoso's goal is to maximize recovery speed.  To ensure the best possible player experience,   a consumer needs to resume being productive by processing new observations.  Time spent reprocessing observations that had already been seen is wasted and likely to degrade the experience; it is important to understand the position in a stream that the consumer last read and have the ability to begin at an arbitrary point.  

### Producers and Consumers Can View Metadata About an Event Hub

Contoso has invested in a robust DevOps system to support _Hugs and Warfare_, helping to ensure that the back-end services can be deployed and scaled to meet player needs with minimal effort.  As a part of these efforts, the deployment for the observation consumers is self-managing.  When consumers are being deployed, the DevOps process will dynamically inspect the observation stream service to understand how many consumers should be created to process it, and ensure that each deployed consumer is configured to listen to the correct stream.

To help Contoso understand the state of their ecosystem, each game client and back-end service sends telemetry data.  The observation consumers include information about their assigned observation stream, including those attributes that would be needed to restart the consumer and resume processing observations from the last that it had completed.

## .NET API

### Key Types

#### `EventHubClient`

The primary client for interacting with an Event Hub, intended to guide consumers towards the types used for specific Event Hub operations and simplifying the creation of those types.

#### `EventProducer`

Enables publishing event data to an Event Hub, supporting automatic routing of events to available partitions and targeting a specific partition.

#### `EventConsumer` 

Enables receiving event data from a single Event Hub partition, supporting exclusive or non-exclusive access to the partition event streams in the context of a consumer group.

#### `EventProcessorHost`

An opinionated extension of the `EventConsumer`, offering a ready-made solution for receiving events across all partitions and durable tracking of the current state of consumption using Azure Blob Storage.  The `EventHubProcessor` is intended to serve a simple and approachable on-boarding point for consuming Event Hubs data.     

_**(not included in the first preview; will be designed and reviewed as an independent package at a later time)**_

#### `EventData`

The raw data and collection of metadata describing an event that flows through the system.  Both send and receive operations represent their data using this type.

#### `EventPosition`

Provides a means of specifying the location of a specific in the event stream, either by strong association to the desired event or by an event's proximity to a particular point in the stream.  For example, "I'd like the first available event" or "I'd like the first event enqueued at or after 12:00am on October 27th, 2015."

### Examples: Creating a Client

#### Using an Event Hub connection string with default options

```csharp
var connectionString = "<< CONNECTION STRING WITH EVENT HUB >>";
var client = new EventHubClient(connectionString);
```

#### Using an namespace connection string with default options

```csharp
var connectionString = "<< CONNECTION STRING FOR NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var client = new EventHubClient(connectionString, eventHubName);
```

#### Using an Event Hub connection string with custom options

```csharp
var clientOptions = new EventHubClientOptions
{
    TransportType = TransportType.AmqpWebSockets,
    DefaultTimeout = new TimeSpan.FromMinutes(1),
    Retry = new ExponentialRetry(TimeSpan.FromSeconds(0.25), TimeSpan.FromMinutes(10), 5),
    Proxy = new WebProxy("http://proxyserver:80", true)
};

var connectionString = "<< CONNECTION STRING WITH EVENT HUB >>";
var client = new EventHubClient(connectionString, clientOptions);

```

#### Using a namespace connection string with custom options

```csharp
var clientOptions = new EventHubClientOptions
{
    TransportType = TransportType.AmqpWebSockets,
    DefaultTimeout = new TimeSpan.FromMinutes(1),
    Retry = new ExponentialRetry(TimeSpan.FromSeconds(0.25), TimeSpan.FromMinutes(10), 5),
    Proxy = new WebProxy("http://proxyserver:80", true)
};

var connectionString = "<< CONNECTION STRING FOR NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var client = new EventHubClient(connectionString, eventHubName, clientOptions);
```

#### Using a token-based credential with custom options

```csharp
var clientOptions = new EventHubClientOptions
{
    TransportType = TransportType.AmqpTcp;
    DefaultTimeout = TimeSpan.FromSeconds(38)
};

var credential = AquireAzureIdentityTokenFromAnotherLibrary();
var client = new EventHubClient("hellokitty.servicebus.windows.net", "telemetry-hub", credential, clientOptions);
```

#### Using a shared key credential with default options

```csharp
var credential = new EventHubsSharedKeyCredential("<< KEY NAME >>", "<< SHARED KEY >>");
var client = new EventHubClient("hellokitty.servicebus.windows.net", "telemetry-hub", credential);
```

### Examples: Viewing Metadata

#### For an Event Hub

```csharp
var client = CreateClient();
var eventHubProperties = await client.GetPropertiesAsync();

Console.WriteLine($"Event Hub Path: { eventHubProperties.Path }");
Console.WriteLine($"The Event Hub was created at { eventHubProperties.CreatedAtUtc }");
Console.WriteLine($"The partitions are: { String.Join(", ", eventHubProperties.PartitionIds) }");
```

#### For a partition

```csharp
var client = CreateClient();
var firstPartition = (await client.GetPropertiesAsync()).PartitionIds[0];
var partitionInformation = await client.GetPartitionPropertiesAsync(firstPartition);

Console.WriteLine($"Event Hub Path: { partitionInformation.EventHubPath }");
Console.WriteLine($"Partition Id: { partitionInformation.Id }");
Console.WriteLine($"Is the Partition Empty? { partitionInformation.IsEmpty }");
Console.WriteLine($"The last offset enqueued in the partition was: { partitionInformation.LastEnqueuedOffset }");
```

#### Just the identifiers for each partition of the Event Hub

```csharp
var client = CreateClient();
var partitionIds = await client.GetPartitionIdsAsync();

Console.WriteLine($"The partitions are: { String.Join(", ", partitionIds) }");
```

### Examples: Creating an Event Producer

#### Create a producer with default options, allowing automatic routing of events to partitions

```csharp
var client = CreateClient();
var producer = client.CreateProducer();
```

#### Create a producer for a specific partition

```csharp
var options = new EventHubProducerOptions
{
    PartitionId = "abs32234-fccdba"
};

var client = CreateClient();
var producer = client.CreateProducer(options);
```

#### Create a producer for automatic partition routing with custom options

```csharp
var options = new EventHubProducerOptions
{
    Timeout = new TimeSpan.FromMinutes(1),
    Retry = new ExponentialRetry(TimeSpan.FromSeconds(0.25), TimeSpan.FromMinutes(10), 5), 
};

var client = CreateClient();
var producer = client.CreateProducer(options);
```

### Examples: Publishing Events

#### Publish a single event to an arbitrary partition

```csharp
var client = CreateClient();
var producer = client.CreateProducer();

await producer.SendAsync(new EventData(GetNextThingBytes()));
```

#### Publish events to an arbitrary partition

```csharp
var events = new[]
{
    new EventData(GetNextThingBytes()),
    new EventData(GetNextThingBytes())
};

var client = CreateClient();
var producer = client.CreateProducer();

await producer.SendAsync(events);
```

#### Publish events to a specific partition

```csharp
var options = new EventHubProducerOptions
{
    PartitionId = "abs32234-fccdba"
};

var client = CreateClient();
var producer = client.CreateProducer(options);

var events = new[]
{
    new EventData(GetNextThingBytes()),
    new EventData(GetNextThingBytes())
};

await producer.SendAsync(events);
```

#### Publish events with custom metadata to an arbitrary partition

```csharp
var playerShot = new EventData(GetPlayerShotBody());
playerShot.Properties["eventType"] = "Sample.EventTypes.PlayerShot";
playerShot.Properties["intendedConsumer"] = "CEP";

var playerDied = new EventData(GetPlayerDiedBody());
playerDied.Properties["eventType"] = "Sample.EventTypes.PlayerDied";
playerDied.Properties["intendedConsumer"] = "Telemetry";

var client = CreateClient();
var producer = client.CreateProducer();

await producer.SendAsync(new[] { playerShot, playerDied });
```

#### Send events that may exceed the batch size limit to an arbitrary partition

```csharp
var eventsToSend = GetPendingEvents(); 
var client = CreateClient();
var producer = client.CreateProducer();
 
try
{
    await producer.SendAsync(eventsToSend);
}
catch (MessageSizeExceededException)
{
    Console.WriteLine("There were too many events in the batch");
}
```

#### Send events with common partition hashing key to an arbitrary partition

```csharp
var sendOptions = new SendOptions
{
    PartitionKey = "these-go-to-the-same-partition-with-service-choice"
};

var eventsToSend = GetPendingEvents(); 
var client = CreateClient();
var producer = client.CreateProducer();

await producer.SendAsync(eventsToSend, sendOptions);
```

### Examples: Creating an Event Consumer

#### A consumer for a specific partition, starting with the first event in the partition

```csharp
var client = CreateClient();
var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, "fcbac12-43cda", EventPosition.Earliest);
```

#### A consumer for a specific partition with custom options

```csharp
var options = new EventHubConsumerOptions
{
    Retry = new ExponentialRetry(TimeSpan.FromSeconds(0.25), TimeSpan.FromMinutes(10), 5)
};

var client = CreateClient();
var consumer = client.CreateConsumer("NotTheDefault", fcbac12-43cda", EventPosition.Latest, options);
```

#### A consumer that asserts exclusive ownership of a partition for a consumer group

```csharp
var options = new EventHubConsumerOptions
{
    OwnerLevel = 100
};

var client = CreateClient();
var consumer = client.CreateConsumer("TelemetryConsumers", "abc-321", EventPosition.Latest, options);
```

### Examples: Consuming Events from a Partition

#### Read all events 

```csharp
var client = CreateClient();
var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, "fcbac12-43cda", EventPosition.Earliest);
var done = false;

while (!done)
{
    var batch = await consumer.ReceiveAsync(25);
    done = ProcessEvents(batch);
}
```

#### Read only newly queued events using a maximum wait time specific to this request

```csharp
var client = CreateClient();
var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, "abc4321", EventPosition.Latest);
var consecutiveEmpties = 0;

while (consecutiveEmpties < 5)
{
    var batch = await consumer.ReceiveAsync(25, TimeSpan.FromSeconds(2));
    
    if (!ProcessEvents(batch))
    {
        ++consecutiveEmpties;
    }
}
```

#### Read events starting at a specific offset

```csharp
var client = CreateClient();
var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, "fcbac12-43cda", EventPosition.FromOffSet(65));
var done = false;

while (!done)
{
    var batch = await consumer.ReceiveAsync(25);
    done = ProcessEvents(batch);
}
```

#### Read events starting at a specific sequence number (inclusive) 

```csharp
var client = CreateClient();
var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, "fcbac12-43cda", EventPosition.FromSequenceNumber(44, true));
var done = false;

while (!done)
{
    var batch = await consumer.ReceiveAsync(25);
    done = ProcessEvents(batch);
}
```

#### Read events starting at a specific moment in time

```csharp
var client = CreateClient();
var consumer = client.CreateConsumer("Group", 0", EventPosition.FromEnqueuedTime(DateTimeOffset.Parse("2015-10-25T12:00:00Z")));
var done = false;

while (!done)
{
    var batch = await consumer.ReceiveAsync(25);
    done = ProcessEvents(batch);
}
```

### Examples: Saving Recovery State

```csharp
var client = CreateClient();
var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, "a-partition", EventPosition.Latest);
var done = false;

while (!done)
{
    var batch = await consumer.ReceiveAsync(25);
    done = ProcessEvents(batch);
    
    var lastEvent = batch.Last();
    PersistCheckpoint(lastEvent.Offset, lastEvent.EnqueuedTimeUtc);
}
```

### Packages

#### `Azure.Messaging.EventHubs`

The main client library package, containing the core components for interacting with the Azure Event Hubs service.

#### `Azure.Messaging.EventHubs.Processor`

The package containing the `EventProcessorHost`, allowing for interested consumers to take advantage of an opinionated, ready-made construct for receiving Event Hubs data and managing state.  

_**(not included for the first preview; will be designed and reviewed at a later time)**_

### Namespaces

#### `Azure.Messaging.EventHubs`

The top-level container for the types in the client library intended to be used by Event Hubs client library users. It is intended that types most frequently used by users for basic operations belong to this namespace to ensure ease of discovery.

##### _Example Types:_
 
- `EventHubClient`
- `EventHubProducer`
- `EventHubConsumer`
- `EventData`

#### `Azure.Messaging.EventHubs.Metadata`

The location for types associated with metadata about an Event Hub instance or events.  These types are intended to be used as read-only information for consumers and are surfaced from the API on more discoverable types, such as `EventHubClient.GetPropertiesAsync`.

##### _Example Types:_
 
- `EventHubProperties`
- `PartitionProperties`

#### `Azure.Messaging.EventHubs.Errors`

The location for exceptions and error-related information and operations. Many of these types are surfaced as information for consumers in response to conditions encountered during a basic operation.  It is not intended that consumers need to create these types directly.

##### _Example Types:_
 
- `MessageSizeExceededException`
- `EventHubsException`

#### `Azure.Messaging.EventHubs.Plugins`

The location for types associated with customizing Event Hubs operations, for example, allowing an event to be transformed before it is sent.  These types are surfaced to consumers as base constructs for building on top of.  

_**(not included for the first preview; will be considered and reviewed at a later time)**_

##### _Example Types:_
 
- `EventDataProcessor`

#### `Azure.Messaging.EventHubs.Core`

The location for internal types used by the Event Hubs library to facilitate operations; these constructs are not intended to be consumed externally. 

##### _Example Types:_
 
- `MessagingEntity`
- `SystemMessagePropertyName`

#### `Azure.Messaging.EventHubs.Amqp`

The location for internal types used by the Event Hubs library to facilitate AMQP protocol-related activities; these constructs are not intended to be consumed externally. 

##### _Example Types:_
 
- `AmqpEventHubClient`
- `AmqpEventHubConsumer`
- `ActiveClientLinkManager`

#### `Azure.Messaging.EventHubs.Diagnostics`

The location for internal types used by the Event Hubs library for diagnostics and logging activities; these constructs are not intended to be consumed externally. 

##### _Example Types:_
 
- `EventHubsEventSource`
- `EventHubsDiagnosticSource`

#### `Azure.Messaging.EventHubs.Authorization`

The location for types associated with authorizing operations against an Event Hub instance.  While some of these types may intended for consumers, the need for them is surfaced as part of the API for more discoverable types, such as `EventHubClient`.  

##### _Example Types:_
 
- `EventHubsSharedKeyCredential`