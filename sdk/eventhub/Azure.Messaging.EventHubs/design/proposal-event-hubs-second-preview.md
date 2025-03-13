# .NET Event Hubs Client: Track Two Proposal (Second Preview)

Azure Event Hubs is a highly scalable publish-subscribe service that can ingest millions of events per second and stream them to multiple consumers. This lets you process and analyze the massive amounts of data produced by your connected devices and applications. Once Event Hubs has collected the data, you can retrieve, transform and store it by using any real-time analytics provider or with batching/storage adapters. If you would like to know more about Azure Event Hubs, you may wish to review: [What is Event Hubs](https://learn.microsoft.com/azure/event-hubs/event-hubs-about)? 

## Design Overview

This design is focused on the second preview of the track two Event Hubs client library, and limits the scope of discussion to those areas with active development for the second preview. For wider context and more general discussion of the design goals for the track two Event Hubs client, please see the [.NET Event Hubs Client: Track Two Proposal (First Preview)](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/design/proposal-event-hubs-first-preview.md). 

## Goals for the Second Preview

- Adhere to, and advance, the goals outline in the the [.NET Event Hubs Client: Track Two Proposal (First  Preview)](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/design/proposal-event-hubs-first-preview.md). 

- Continue to align the public API surface area to the guidance outlined in the [Azure SDK Design Guidelines for .NET](https://azuresdkspecs.z5.web.core.windows.net/DotNetSpec.html).

- Design an exception hierarchy that follows the overall pattern used by the track one client, limiting changes and allowing the published [exception guidance](https://learn.microsoft.com/azure/event-hubs/event-hubs-messaging-exceptions) to remain as relevant as possible.

- Streamline the design around timeouts and retries, making the common scenarios easier while allowing developers with advanced scenarios to customize.

- Redesign the "streaming consumer" pattern of receiving events, continuing to offer a streamlined experience where the client library owns the message handling loop.

- Reintroduce the `EventDataBatch` concept, allowing event producers to create a size-limited batch and control its contents.

## Non-Goals for the Second Preview

- Rewriting of the relevant areas of track one codebase; where possible, existing code will be used with as few modifications as possible, allowing the new API surface to be built on proven, reliable, and well-tested code. 

- Support for scenarios outside the identified targets or revisions to associated packages, such as the Event Hubs Processor; the initial efforts will be focused on the API surface for key operations in the core client library.

- Ensuring that cancellation tokens are honored throughout the implementation; they will be accepted as part of the API but may not have an effect depending on acceptance and treatment by the infrastructure provided by the track one client library.

## High Level Scenarios

### Producers can Predict Event Batch Sizes

Bob's Apple Farm has deployed a series of sensors into their orchard to help monitor soil conditions and make more efficient use of irrigation. The sensors submit their data for centralized analysis by publishing events to Azure Event Hubs. Because these sensors have been deployed to fields in a rural area, connectivity options are limited; the sensors are making use of a shared cellular service with limited bandwidth.

To make efficient use of the available bandwidth, avoid unplanned data usage charges, and ensure that sensors are able to share the network fairly, they have been configured to publish events on a scheduled basis and would like to limit the event batches to a known, predictable, maximum size.

### Consumers can Subscribe to Partition Events

Bob's Apple Farm uses the events published by its sensors to feed a continuous analytics pipeline responsible for making informed decisions for managing the orchard in real-time, including when to irrigate, when soil conditions require fertilizer, and, most importantly, when there is a situation that requires human intervention.

Because the processing of this event data is critical for managing the orchard, those responsible for development at Bob's Apple Farm are focused on reducing potential sources of errors, such as boilerplate code for an messaging loop, and prefer to keep their code focused on logic specific to their business. They would like to consume event data published by their sensors without the need to focus on controlling the size of batches, applying explicit back pressure, or worrying about exceptions that occur outside of their core processing logic.

## .NET API for the Second Preview

### Key Types

#### `RetryOptions`

The set of options available for configuring retry behaviors. This includes specifying a timeout per-try, replacing the concept of "operation timeouts" that were offered as part of client options types in the first preview.

#### `RetryPolicy`

Serves as the abstract base for retry policies, allowing developers with advanced retry needs to created customized retry behaviors.

#### `OperationCancelledException` 

This occurs when an operation has been requested on a client, producer, or consumer that has already been closed or disposed of. It is recommended to check the application code and ensure that objects from the Event Hubs client library are created and closed/disposed in the intended scope.

#### `TimeoutException` 

This indicates that the Event Hubs service did not respond to an operation within the expected amount of time. This may have been caused by a transient network issue or service problem. The Event Hubs service may or may not have successfully completed the request; the status is not known. It is recommended to attempt to verify the current state and retry if necessary.

#### `MessageSizeExceededException` 

Event data, both individual and in batches, have a maximum size allowed. This includes the data of the event, as well as any associated metadata and system overhead. The best approach for resolving this error is to reduce the number of events being sent in a batch or the size of data included in the message. Because size limits are subject to change, please refer to [Azure Event Hubs quotas and limits](https://learn.microsoft.com/azure/event-hubs/event-hubs-quotas) for specifics.

#### `QuotaExceededException` 

The messaging entity has reached its maximum allowable size. This exception can happen if the maximum number of consumers have already been created for a given partition and consumer group. Because  limits are subject to change, please refer to [Azure Event Hubs quotas and limits](https://learn.microsoft.com/azure/event-hubs/event-hubs-quotas) for specifics.

#### `DateTimeOffset`

An intrinsic .NET type, the `DateTimeOffset` represents a point in time relative to Coordinated Universal Time (UTC).  Event Hubs client library members representing date/time data are normalized to UTC and will change to using `DateTimeOffset` in the second preview to avoid the ambiguity around time zones associated with the use of `DateTime`.

#### `IAsyncEnumerable<T>`

An intrinsic .NET type currently in preview, the `IAsyncEnumerable<T>` enables iterating over an enumerable in an asynchronous way, allowing for an infinite sequence to be generated from a source requiring asynchronous communication.  The second preview of the Event Hubs client library makes use of this concept in its approach for allowing a "streaming consumer."

### Examples: Configuring Retries

#### Creating an Event Hub client with default retry configuration

```csharp
var connectionString = "<< CONNECTION STRING WITH EVENT HUB >>";
var client = new EventHubClient(connectionString);
```

#### Creating an Event Hub client with custom retry configuration

```csharp
var clientOptions = new EventHubClientOptions();

clientOptions.RetryMode = RetryMode.Fixed;
clientOptions.MaxRetries = 5;
clientOptions.Delay = TimeSpan.FromMilliseconds(250);
clientOptions.MaxDelay = TimeSpan.FromSeconds(2);
clientOptions.TryTimeout = TimeSpan.FromSeconds(90);

var connectionString = "<< CONNECTION STRING WITH EVENT HUB >>";
var client = new EventHubClient(connectionString);
```

#### Use a custom retry policy with an Event Hub client

```csharp
public class CustomRetryPolicy : EventHubsRetryPolicy
{
    public override TimeSpan? CalculateRetryDelay(Exception lastException,
                                                  int retryCount 
    {
        // CUSTOM LOGIC... 
    }
}

var connectionString = "<< CONNECTION STRING WITH EVENT HUB >>";
var client = new EventHubClient(connectionString);

client.RetryPolicy = new CustomRetryPolicy():
```

#### Create a producer with default retry configuration

```csharp
var client = CreateClient();
var producer = client.CreateProducer();
```

#### Create a producer with custom retry configuration

```csharp
var producerOptions = new EventHubProducerOptions(); 

producerOptions.RetryMode = RetryMode.Fixed;
producerOptions.MaxRetries = 5;
producerOptions.Delay = TimeSpan.FromMilliseconds(250);
producerOptions.MaxDelay = TimeSpan.FromSeconds(2);
producerOptions.TryTimeout = TimeSpan.FromSeconds(90);

var client = CreateClient();
var producer = client.CreateProducer(producerOptions);
```

#### Use a custom retry policy with an Event Hub producer

```csharp
public class CustomRetryPolicy : EventHubsRetryPolicy
{
    public override TimeSpan? CalculateRetryDelay(Exception lastException,
                                                  int retryCount 
    {
        // CUSTOM LOGIC... 
    }
}

var client = CreateClient();
var producer = client.CreateProducer();

producer.RetryPolicy = new CustomRetryPolicy():
```

#### Create a consumer with default retry configuration

```csharp
var client = CreateClient();
var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, "fcbac12-43cda", EventPosition.Earliest);
```

#### Create a consumer with custom retry configuration

```csharp
var consumerOptions = new EventHubConsumerOptions
{
    RetryOptions = new RetryOptions
    {
        RetryMode = RetryMode.Exponential,
        MaxRetries = 5,
        Delay = TimeSpan.FromMilliseconds(250),
        MaxDelay = TimeSpan.FromSeconds(2),
        TryTimeout = TimeSpan.FromSeconds(90)
    }
};

var client = CreateClient();
var consumer = client.CreateConsumer("NotTheDefault", "fcbac12-43cda", EventPosition.Earliest, consumerOptions);
```

#### Use a custom retry policy with an Event Hub consumer

```csharp
public class CustomRetryPolicy : EventHubsRetryPolicy
{
    public override TimeSpan? CalculateRetryDelay(Exception lastException,
                                                  int retryCount 
    {
        // CUSTOM LOGIC... 
    }
}

var client = CreateClient();
var consumer = client.CreateConsumer("NotTheDefault", "fcbac12-43cda", EventPosition.Earliest);

consumer.RetryPolicy = new CustomRetryPolicy():
```

### Examples: Publishing with Event Data Batches

#### Create an Event Data Batch with default options

```csharp
var client = CreateClient();
var producer = client.CreateProducer();

using (var eventBatch = producer.CreateEventDataBatch())
{
    // Use the batch
}
```

#### Create an Event Data Batch with custom options

```csharp
var client = CreateClient();
var producer = client.CreateProducer();

var batchOptions = new BatchOptions
{
    MaximumSizeInBytes = 4096,
    PartitionKey = "these-go-to-the-same-partition-with-service-choice"
}

using (var eventBatch = producer.CreateEventDataBatch(batchOptions))
{
    // Use the batch
}
```

#### Fill a batch

```csharp
var client = CreateClient();
var producer = client.CreateProducer();

using (var eventBatch = producer.CreateEventDataBatch())
{
    var eventData = GetNextEvent();

    while (eventBatch.TryAdd(eventData))
    {
        eventData = GetNextEvent();
    }
    
    // Use the event batch
}
```

#### Determine if an event is in an batch

```csharp
var client = CreateClient();
var producer = client.CreateProducer();

using (var eventBatch = CreateAndFillBatch(producer))
{
    var specialEvent = GetSpecialEvent();
    var eventInBatch = eventBatch.Contains(specialEvent);
}
```

#### Determine the current size of an batch

```csharp
var client = CreateClient();
var producer = client.CreateProducer();

using (var eventBatch = CreateAndFillBatch(producer))
{
    var maximumSizeInBytes = eventBatch.MaximumSize;
    var batchSizeInBytes = eventBatch.CurrentSize;
}
```

#### Publish a batch

```csharp
var client = CreateClient();
var producer = client.CreateProducer();

using (var eventBatch = CreateAndFillBatch(producer))
{
    // Options when sending an EventBatch are allowed only
    // on the batch itself, they may not be also provided during
    // the Send.
    
    await producer.Send(eventBatch);
}
```

### Examples: Consuming Events from a Partition

#### Subscribe to events as they are available, waiting as needed 

```csharp
var client = CreateClient();
var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, "fcbac12-43cda", EventPosition.Earliest);

await foreach(var eventData in consumer.SubscribeToPartition(someCancellationToken))
{
    ProcessEvent(eventData);
}
```

#### Subscribe to events as they are available, using a maximum wait time to return control

```csharp
var client = CreateClient();
var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, "fcbac12-43cda", EventPosition.Earliest);
var maximumWaitTime = TimeSpan.FromSeconds(2);

await foreach(var eventData in consumer.SubscribeToPartition(maximumWaitTime, someCancellationToken))
{
    // If the maximum wait time elapsed before an event was 
    // available, it will be null.  This returns control and allows
    // for breaking out of the loop.
    
    if (eventData != null)
    {
        ProcessEvent(eventData);
    }
}
```

### Packages

#### `Azure.Messaging.EventHubs`

The main client library package, containing the core components for interacting with the Azure Event Hubs service.

### Namespaces

#### `Azure.Messaging.EventHubs`

The top-level container for the types in the client library intended to be used by Event Hubs client library users. It is intended that types most frequently used by users for basic operations belong to this namespace to ensure ease of discovery.

##### _Example types:_
 
- `RetryOptions`
- `EventHubsRetryPolicy`
- `BatchOptions`
- `EventDataBatch`

#### `Azure.Messaging.EventHubs.Errors`

The location for exceptions and error-related information and operations. Many of these types are surfaced as information for consumers in response to conditions encountered during a basic operation. It is not intended that consumers need to create these types directly.

##### _Example types:_
 
- `OperationCancelledException`
- `TimeoutException`
- `MessageSizeExceededException`
- `QuotaExceededException`

#### `Azure.Messaging.EventHubs.Core`

The location for internal types used by the Event Hubs library to facilitate operations; these constructs are not intended to be consumed externally. 

##### _Example types:_
 
- `DefaultEventHubsRetryPolicy`
- `SystemMessagePropertyName`

#### `Azure.Messaging.EventHubs.Amqp`

The location for internal types used by the Event Hubs library to facilitate AMQP protocol-related activities; these constructs are not intended to be consumed externally. 

##### _Example types:_
 
- `AmqpMessageConverter`
- `AmqpEventDataBatch`

#### `Azure.Messaging.EventHubs.Diagnostics`

The location for internal types used by the Event Hubs library for diagnostics and logging activities; these constructs are not intended to be consumed externally. 

##### _Example types:_
 
- `EventHubsEventSource`
- `EventHubsDiagnosticSource`
