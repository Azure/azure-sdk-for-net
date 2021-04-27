# Publishing Events

This sample demonstrates publishing events to an Event Hub.  To begin, please ensure that you're familiar with the items discussed in the [Getting started](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples#getting-started) section of the README, and have the prerequisites and connection string information available.

## Client types

Event publishing is the responsibility of the `EventHubProducerClient`, which supports each of the publishing scenarios supported by the client library.  The `EventHubProducerClient` is safe to cache and use for the lifetime of an application, which is best practice when the events are published regularly or semi-regularly. The `EventHubProducerClient` is responsible for efficient resource management, working to keep resource usage low during periods of inactivity and manage health during periods of higher use. Calling either the `CloseAsync` or `DisposeAsync` method as the application is shutting down will ensure that network resources and other unmanaged objects are properly cleaned up.

## Event lifetime

When events are published, they will continue to exist in the Event Hub and be available for consuming until they reach an age where they are older than the [retention period](https://docs.microsoft.com//azure/event-hubs/event-hubs-faq#what-is-the-maximum-retention-period-for-events).  After that point in time, the Event Hubs service may chose to remove them from the partition.  Once removed, an event is no longer available to be read and cannot be recovered.  Though the Event Hubs service is free to remove events older than the retention period, it does not do so deterministically; there is no guarantee of when events will be removed.

## Publishing and partitions

Every event that is published is sent to one of the [partitions](https://docs.microsoft.com/azure/architecture/reference-architectures/event-hubs/partitioning-in-event-hubs-and-kafka) of the Event Hub. The application may request publishing to a specific partition or allow the Event Hubs service to choose the partition automatically.  The `EventHubProducerClient` is not associated with any specific partition and the same instance can be used for each publishing scenario.

## Publishing size constraints

When publishing, there is a limit to the size (in bytes) that can be sent to the Event Hubs service in a single operation.  To accurately determine the size of an event, it must be measured in the format used by the active protocol as well as account for overhead.  The size limit is controlled by the Event Hubs service and differs for different types of Event Hub instances.  Because of this and because there is no accurate way for an application to calculate the size of an event, the client library offers the `EventDataBatch` to help.

The `EventDataBatch` exists to provide a deterministic and accurate means to measure the size of a message sent to the service, minimizing the chance that a publishing operation will fail.  Because the batch works in cooperation with the service, it has an understanding of the maximum size and has the ability to measure the exact size of an event when serialized for publishing.  For the majority of scenarios, we recommend using the `EventDataBatch` to ensure that your application does not attempt to publish a set of events larger than the Event Hubs service allows.  The majority of examples in this sample will demonstrate a batched approach.

All of the events that belong to an `EventDataBatch` are considered part of a single unit of work.  When a batch is published, the result is atomic; either publishing was successful for all events in the batch, or it has failed for all events.  Partial success or failure when publishing a batch is not possible.

To create an `EventDataBatch`, the `EventProducerClient` must be used, as the size limit is queried from the Event Hubs service the first time that a batch is created.  After the size has been queried once, batch creation will not incur the cost of a service request.   The `EventDataBatch` follows a `TryAdd` pattern; if the call returns `true` then the event was accepted into the batch.  If not, then the event was unable to fit.  To avoid accidentally losing events, it is recommended to check the return value when adding events.

```C# Snippet:EventHubs_Sample04_EventBatch
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var producer = new EventHubProducerClient(connectionString, eventHubName);

try
{
    using var eventBatch = await producer.CreateBatchAsync();

    var eventBody = new BinaryData("This is an event body");
    var eventData = new EventData(eventBody);

    if (!eventBatch.TryAdd(eventData))
    {
        throw new Exception($"The event could not be added.");
    }
}
finally
{
    await producer.CloseAsync();
}
```

The `EventDataBatch` is scoped to a single publish operation.  Once that operation is complete, a new batch should be created for any additional events to be published.  The batch is responsible for unmanaged resources; it is recommended that you `Dispose` the batch after it has been published.

## Publishing events with automatic partition assignment

Allowing automatic assignment to partitions is recommended when publishing needs to be highly available and shouldn't fail if a single partition is experiencing trouble.  Automatic assignment also helps to ensure that event data is evenly distributed among all available partitions, which helps to ensure throughput when publishing and reading data.

When the batch is published, the `EventHubProducerClient` will receive an acknowledgment from the Event Hubs service; so long as no exception is thrown by this call, your application can consider publishing successful.  The service assumes responsibility for delivery of the batch.  All of your event data will be published to one of the Event Hub partitions, thought here may be a slight delay until it is available to be read.

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

## Publishing events with a partition key

When publishing events, it may be desirable to request that the Event Hubs service keep the different event batches together on the same partition.  This can be accomplished by setting a partition key when creating the batch.  The partition key is NOT the identifier of a specific partition.  Rather, it is an arbitrary piece of string data that Event Hubs uses as the basis to compute a hash value.  Event Hubs will associate the hash value with a specific partition, ensuring that any events published with the same partition key are routed to the same partition.
                
There is no means of predicting which partition will be associated with a given partition key; we can only be assured that it will be a consistent choice of partition.  If you have a need to understand which exact partition an event is published to, you will need to specify the partition directly rather than using a partition key.

When the batch is published, the `EventHubProducerClient` will receive an acknowledgment from the Event Hubs service; so long as no exception is thrown by this call, your application can consider publishing successful.  The service assumes responsibility for delivery of the batch.  All of your event data will be published to one of the Event Hub partitions, thought here may be a slight delay until it is available to be read.

**Note:** It is important to be aware that if you are using a partition key, you may not also specify a partition identifier; they are mutually exclusive.

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

## Publishing events to a specific partition

When publishing, it may be desirable to request that the Event Hubs service place a batch on a specific partition, for organization and processing.  For example, you may have designated one partition of your Event Hub as being responsible for all of your telemetry-related events.  This can be accomplished by setting the identifier of the desired partition when creating the batch.  

When the batch is published, the `EventHubProducerClient` will receive an acknowledgment from the Event Hubs service; so long as no exception is thrown by this call, your application can consider publishing successful.  The service assumes responsibility for delivery of the batch.  All of your event data will be published to one of the Event Hub partitions, thought here may be a slight delay until it is available to be read.

**Note:** It is important to be aware that if you are using a partition identifier, you may not also specify a partition key; they are mutually exclusive.

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

## Publishing events with custom metadata

Because an event consists mainly of an opaque set of bytes, it may be difficult for consumers of those events to make informed decisions about how to process them.  In order to allow event publishers to offer better context for consumers, events may also contain custom metadata, in the form of a set of key/value pairs.  One common scenario for the inclusion of metadata is to provide a hint about the type of data contained by an event, so that consumers understand its format and can deserialize it appropriately.

This metadata is not used by, or in any way meaningful to, the Event Hubs service; it exists only for coordination between event publishers and consumers.

```C# Snippet:EventHubs_Sample04_CustomMetadata
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var producer = new EventHubProducerClient(connectionString, eventHubName);

try
{
    using var eventBatch = await producer.CreateBatchAsync();

    var eventBody = new BinaryData("Hello, Event Hubs!");
    var eventData = new EventData(eventBody);
    eventData.Properties.Add("EventType", "com.microsoft.samples.hello-event");
    eventData.Properties.Add("priority", 1);
    eventData.Properties.Add("score", 9.0);

    if (!eventBatch.TryAdd(eventData))
    {
        throw new Exception("The first event could not be added.");
    }

    eventBody = new BinaryData("Goodbye, Event Hubs!");
    eventData = new EventData(eventBody);
    eventData.Properties.Add("EventType", "com.microsoft.samples.goodbye-event");
    eventData.Properties.Add("priority", "17");
    eventData.Properties.Add("blob", true);

    if (!eventBatch.TryAdd(eventData))
    {
        throw new Exception("The second event could not be added.");
    }

    await producer.SendAsync(eventBatch);
}
finally
{
    await producer.CloseAsync();
}
```

## Publishing events without an explicit batch

In scenarios where producers publish events more frequently and aren't concerned with exceeding the size limitation, it is reasonable to bypass the safety offered by using the `EventDataBatch` to offer minor throughput gains and fewer memory allocations.  In support of this scenario, the `EventProducerClient` offers a `SendAsync` overload that accepts a set of events.  This method delegates validation to the Event Hubs service to avoid the performance cost of a client-side measurement.  If the set of events that was published exceeds the size limit, an [EventHubsException](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventhubsexception?view=azure-dotnet) will be surfaced with its `Reason` set to [MessageSizeExceeded](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventhubsexception.failurereason?view=azure-dotnet). 

When events are passed in this form, the `EventProducerClient` will package them as a single publishing operation.  When the set is published, the result is atomic; either publishing was successful for all events, or it has failed for all events.  Partial success or failure when publishing a batch is not possible.

When published, the `EventHubProducerClient` will receive an acknowledgment from the Event Hubs service; so long as no exception is thrown by this call, your application can consider publishing successful.  The service assumes responsibility for delivery of the set.  All of your event data will be published to one of the Event Hub partitions, thought here may be a slight delay until it is available to be read.

```C# Snippet:EventHubs_Sample04_NoBatch
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var producer = new EventHubProducerClient(connectionString, eventHubName);

try
{
    var eventsToSend = new List<EventData>();

    for (var index = 0; index < 10; ++index)
    {
        var eventBody = new BinaryData("Hello, Event Hubs!");
        var eventData = new EventData(eventBody);

        eventsToSend.Add(eventData);
    }

    await producer.SendAsync(eventsToSend);
}
finally
{
    await producer.CloseAsync();
}
```

## Creating and publishing multiple batches

Because an `EventDataBatch` is scoped to a single publish operation, it is often necessary to more than a single batch to publish events.  This can take many forms, with varying levels of sophistication and complexity, depending on an application's needs.  One common approach is to stage the events to be published in a `Queue` and use that as a source for building batches.  

The following illustration breaks the process into discrete steps, transforming the queue of events into a set of batches to be published.  This is done to help isolate the logic of creating batches for readability.  Production applications may wish to publish batches as they become full to make more efficient use of resources.

**Note:** The batch is responsible for unmanaged resources; it is recommended that you `Dispose` the batch after it has been published.

```C# Snippet:EventHubs_Sample04_MultipleBatches
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var producer = new EventHubProducerClient(connectionString, eventHubName);
var batches = default(IEnumerable<EventDataBatch>);
var eventsToSend = new Queue<EventData>();

try
{
    for (var index = 0; index < 1500; ++index)
    {
        eventsToSend.Enqueue(new EventData(new byte[80000]));
    }

    batches = await BuildBatchesAsync(eventsToSend, producer);

    foreach (var batch in batches)
    {
        await producer.SendAsync(batch);
    }
}
finally
{
    foreach (EventDataBatch batch in batches ?? Array.Empty<EventDataBatch>())
    {
        batch.Dispose();
    }

    await producer.CloseAsync();
}
```

```C# Snippet:EventHubs_Sample04_BuildBatches
private static async Task<IReadOnlyList<EventDataBatch>> BuildBatchesAsync(
    Queue<EventData> queuedEvents,
    EventHubProducerClient producer)
{
    var batches = new List<EventDataBatch>();
    var currentBatch = default(EventDataBatch);

    while (queuedEvents.Count > 0)
    {
        currentBatch ??= (await producer.CreateBatchAsync().ConfigureAwait(false));
        EventData eventData = queuedEvents.Peek();

        if (!currentBatch.TryAdd(eventData))
        {
            if (currentBatch.Count == 0)
            {
                throw new Exception("There was an event too large to fit into a batch.");
            }

            batches.Add(currentBatch);
            currentBatch = default;
        }
        else
        {
            queuedEvents.Dequeue();
        }
    }

    if ((currentBatch != default) && (currentBatch.Count > 0))
    {
        batches.Add(currentBatch);
    }

    return batches;
}
```

## Restricting a batch to a custom size limit

In some scenarios, such as when bandwidth is limited or publishers need to maintain control over how much data is transmitted at a time, a custom size limit (in bytes) may be specified when creating an `EventDataBatch`.  This will override the default limit specified by the Event Hub and allows an application to use the `EventDataBatch` to ensure that the size of events can be measured accurately and deterministically.  It is important to note that the custom limit may not exceed the limit specified by the Event Hub.

```C# Snippet:EventHubs_Sample04_CustomBatchSize
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var producer = new EventHubProducerClient(connectionString, eventHubName);

try
{
    var batchOptions = new CreateBatchOptions
    {
        MaximumSizeInBytes = 350
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