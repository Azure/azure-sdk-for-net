# Publishing Events

This sample demonstrates publishing events to an Event Hub.  To begin, please ensure that you're familiar with the items discussed in the [Getting started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples#getting-started) section of the README, and have the prerequisites and connection string information available.

## Table of contents

- [Client types](#client-types)
- [Buffering versus explicit batching](#buffering-versus-explicit-batching)
- [Event lifetime](#event-lifetime)
- [Publishing size constraints](#publishing-size-constraints)
- [Publishing and partitions](#publishing-and-partitions)
- [Publishing events with automatic partition assignment](#publishing-events-with-automatic-partition-assignment)
- [Publishing events with a partition key](#publishing-events-with-a-partition-key)
- [Publishing events to a specific partition](#publishing-events-to-a-specific-partition)
- [Publishing events with custom metadata](#publishing-events-with-custom-metadata)
- [Guidance for buffered producer handler implementation](#guidance-for-buffered-producer-handler-implementation)
- [Tuning throughput for buffered publishing](#tuning-throughput-for-buffered-publishing)
- [Creating and publishing multiple batches](#creating-and-publishing-multiple-batches)
- [Publishing events with an implicit batch](#publishing-events-with-an-implicit-batch)
- [Restricting a batch to a custom size limit](#restricting-a-batch-to-a-custom-size-limit)

## Client types

Event publishing is the responsibility of an event producer.  The client library offers two producers, the `EventHubProducerClient` and `EventHubBufferedProducerClient`, each tailored to a unique pattern of use, but applicable to the same application scenarios.  This sample will include code snippets for both types, unless the concept is not applicable to one.  More information about the available event producers can be found in [Sample02_EventHubsClients](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample02_EventHubsClients.md).

Each of the event producer client types are safe to cache and use for the lifetime of an application, which is best practice when the events are published regularly or semi-regularly. The event producers are responsible for efficient resource management, adapting to periods of inactivity and higher use automatically.  Calling either the `CloseAsync` or `DisposeAsync` method as the application is shutting down will ensure that network resources and other unmanaged objects are properly cleaned up.

## Buffering versus explicit batching

The main consideration for choosing a buffered or non-buffered producer is determinism.  When publishing with the `EventHubProducerClient`, each request to publish is an independent operation; when the call completes, your application knows whether the events were successfully published or an exception was encountered.  This requires your application to be responsible for managing the publishing flow, controlling how batches of events are built, and when they are published.  For many applications, ensuring efficient publishing can introduce a non-trivial amount of complexity.

The `EventHubBufferedProducerClient` aims to reduce complexity by owning the responsibility for efficiently managing batches and publishing.  To do so, applications enqueue events into a buffer which the producer reads and publishes in batches when they are ready.  Because publishing happens automatically at some point after an event was enqueued, your application is not aware of the outcome immediately; it must register event handlers that the producer calls to notify the application of publishing success or failure.

## Event lifetime

When events are published, they will continue to exist in the Event Hub and be available for consuming until they reach an age where they are older than the [retention period](https://learn.microsoft.com/azure/event-hubs/event-hubs-faq#what-is-the-maximum-retention-period-for-events).  After that point in time, the Event Hubs service may chose to remove them from the partition.  Once removed, an event is no longer available to be read and cannot be recovered.  Though the Event Hubs service is free to remove events older than the retention period, it does not do so deterministically; there is no guarantee of when events will be removed.

## Publishing size constraints

There is a limit to the size (in bytes) that can be published in a single operation.  To accurately determine the size of an event, it must be measured in the format used by the active protocol in order to properly account for overhead.  The size limit is controlled by the Event Hubs service and differs for different types of Event Hub instances.

Applications using the `EventHubBufferedProducerClient` do not need to track size limitations; the producer will ensure that batches are correctly sized when publishing.

When using the `EventHubProducerClient`, the application holds responsibility for managing the size of events to be published.  Because there is no accurate way for an application to calculate the size of an event, the client library offers the `EventDataBatch` to help.

The `EventDataBatch` exists to provide a deterministic and accurate means to measure the size of a message sent to the service, minimizing the chance that a publishing operation will fail.  Because the batch works in cooperation with the service, it has an understanding of the maximum size and has the ability to measure the exact size of an event when serialized for publishing.  For the majority of `EventHubProducerClient` scenarios, we recommend using the `EventDataBatch` to ensure that your application does not attempt to publish a set of events larger than the limit.  The majority of examples in this sample will demonstrate a batched approach.

All of the events that belong to an `EventDataBatch` are considered part of a single unit of work.  When a batch is published, the result is atomic; either publishing was successful for all events in the batch, or it has failed for all events.  Partial success or failure when publishing a batch is not possible.

To create an `EventDataBatch`, the `EventProducerClient` must be used, as the size limit is queried from the Event Hubs service the first time that a batch is created.  After the size has been queried once, batch creation will not incur the cost of a service request.   The `EventDataBatch` follows a `TryAdd` pattern; if the call returns `true` then the event was accepted into the batch.  If not, then the event was unable to fit.  To avoid accidentally losing events, it is recommended to check the return value when adding events.

```C# Snippet:EventHubs_Sample04_EventBatch
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

    var eventData = new EventData("This is an event body");

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

The `EventDataBatch` is scoped to a single publish operation.  Once that operation is complete, a new batch should be created for any additional events to be published.  Because the batch is responsible for unmanaged resources, it is recommended that you `Dispose` the batch after it has been published.

## Publishing and partitions

Every event that is published is sent to one of the [partitions](https://learn.microsoft.com/azure/architecture/reference-architectures/event-hubs/partitioning-in-event-hubs-and-kafka) of the Event Hub. The application may request publishing to a specific partition, grouped using a partition key,  or allow the partition to be chosen automatically.

When using the `EventHubProducerClient`, each batch must choose the partition assignment strategy at the time it is created, and that strategy is applied to all events in the batch.   The `EventHubBufferedProducerClient` allows the partition assignment strategy to be chosen for each individual event that is enqueued, and the producer will ensure that batches are constructed with the proper strategy.

## Publishing events with automatic partition assignment

Allowing automatic assignment to partitions is recommended when publishing needs to be highly available and shouldn't fail if a single partition is experiencing trouble.  Automatic assignment also helps to ensure that event data is evenly distributed among all available partitions, which helps to ensure throughput when publishing and reading data.

### Event Hub Buffered Producer Client

When using the `EventHubBufferedProducerClient`, events enqueued with no options specified will be automatically routed.  Because the producer manages publishing, there is no explicit call.  When the producer is closed, it will ensure that any remaining enqueued events have been published.  All of your event data will be published to one of the Event Hub partitions, though there may be a slight delay until it is available to be read.

```C# Snippet:EventHubs_Sample04_AutomaticRoutingBuffered
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

var producer = new EventHubBufferedProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential);

// The failure handler is required and invoked after all allowable
// retries were applied.

producer.SendEventBatchFailedAsync += args =>
{
    Debug.WriteLine($"Publishing failed for { args.EventBatch.Count } events.  Error: '{ args.Exception.Message }'");
    return Task.CompletedTask;
};

// The success handler is optional.

producer.SendEventBatchSucceededAsync += args =>
{
   Debug.WriteLine($"{ args.EventBatch.Count } events were published to partition: '{ args.PartitionId }.");
   return Task.CompletedTask;
};

try
{
    for (var index = 0; index < 5; ++index)
    {
        var eventData = new EventData($"Event #{ index }");
        await producer.EnqueueEventAsync(eventData);
    }
}
finally
{
    // Closing the producer will flush any
    // enqueued events that have not been published.

    await producer.CloseAsync();
}
```

### Event Hub Producer Client

When using the `EventHubProducerClient` a batch is first created and then published.  The `SendAsync` call will receive an acknowledgment from the Event Hubs service; so long as no exception is thrown, your application can consider publishing successful.  All of your event data will be published to one of the Event Hub partitions, though there may be a slight delay until it is available to be read.

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

## Publishing events with a partition key

When publishing events, it may be desirable to request that the Event Hubs service keep the different event batches together on the same partition.  This can be accomplished by setting a partition key when creating the batch.  The partition key is NOT the identifier of a specific partition.  Rather, it is an arbitrary piece of string data that Event Hubs uses as the basis to compute a hash value.  Event Hubs will associate the hash value with a specific partition, ensuring that any events published with the same partition key are routed to the same partition.

There is no means of predicting which partition will be associated with a given partition key; we can only be assured that it will be a consistent choice of partition.  If you have a need to understand which exact partition an event is published to, you will need to specify the partition directly rather than using a partition key.

### Event Hub Buffered Producer Client

When using the `EventHubBufferedProducerClient`, events are enqueued with a partition key option.  Because the producer manages publishing, there is no explicit call.  When the producer is closed, it will ensure that any remaining enqueued events have been published.  All of your event data will be published to one of the Event Hub partitions, though there may be a slight delay until it is available to be read.

**Note:** It is important to be aware that if you are using a partition key, you may not also specify a partition identifier; they are mutually exclusive.

```C# Snippet:EventHubs_Sample04_PartitionKeyBuffered
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

var producer = new EventHubBufferedProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential);

// The failure handler is required and invoked after all allowable
// retries were applied.

producer.SendEventBatchFailedAsync += args =>
{
    Debug.WriteLine($"Publishing failed for { args.EventBatch.Count } events.  Error: '{ args.Exception.Message }'");
    return Task.CompletedTask;
};

// The success handler is optional.

producer.SendEventBatchSucceededAsync += args =>
{
   Debug.WriteLine($"{ args.EventBatch.Count } events were published to partition: '{ args.PartitionId }.");
   return Task.CompletedTask;
};

try
{
    var enqueueOptions = new EnqueueEventOptions
    {
        PartitionKey = "Any Value Will Do..."
    };

    for (var index = 0; index < 5; ++index)
    {
        var eventData = new EventData($"Event #{ index }");
        await producer.EnqueueEventAsync(eventData, enqueueOptions);
    }
}
finally
{
    // Closing the producer will flush any
    // enqueued events that have not been published.

    await producer.CloseAsync();
}
```

### Event Hub Producer Client

When using the `EventHubProducerClient` a batch is first created with a partition key option and then published.  The `SendAsync` call will receive an acknowledgment from the Event Hubs service; so long as no exception is thrown, your application can consider publishing successful.  All of your event data will be published to one of the Event Hub partitions, though there may be a slight delay until it is available to be read.

**Note:** It is important to be aware that if you are using a partition key, you may not also specify a partition identifier; they are mutually exclusive.

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

## Publishing events to a specific partition

When publishing, it may be desirable to request that the Event Hubs service place a batch on a specific partition, for organization and processing.  For example, you may have designated one partition of your Event Hub as being responsible for all of your telemetry-related events.  This can be accomplished by setting the identifier of the desired partition when creating the batch.

### Event Hub Buffered Producer Client

When using the `EventHubBufferedProducerClient`, events are enqueued with a partition identifier option.  Because the producer manages publishing, there is no explicit call.  When the producer is closed, it will ensure that any remaining enqueued events have been published.  All of your event data will be published to one of the Event Hub partitions, though there may be a slight delay until it is available to be read.

**Note:** It is important to be aware that if you are using a partition key, you may not also specify a partition identifier; they are mutually exclusive.

```C# Snippet:EventHubs_Sample04_PartitionIdBuffered
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

var producer = new EventHubBufferedProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential);

// The failure handler is required and invoked after all allowable
// retries were applied.

producer.SendEventBatchFailedAsync += args =>
{
    Debug.WriteLine($"Publishing failed for { args.EventBatch.Count } events.  Error: '{ args.Exception.Message }'");
    return Task.CompletedTask;
};

// The success handler is optional.

producer.SendEventBatchSucceededAsync += args =>
{
   Debug.WriteLine($"{ args.EventBatch.Count } events were published to partition: '{ args.PartitionId }.");
   return Task.CompletedTask;
};

try
{
    string firstPartition = (await producer.GetPartitionIdsAsync()).First();

    var enqueueOptions = new EnqueueEventOptions
    {
        PartitionId = firstPartition
    };

    for (var index = 0; index < 5; ++index)
    {
        var eventData = new EventData($"Event #{ index }");
        await producer.EnqueueEventAsync(eventData, enqueueOptions);
    }
}
finally
{
    // Closing the producer will flush any
    // enqueued events that have not been published.

    await producer.CloseAsync();
}
```

### Event Hub Producer Client

When using the `EventHubProducerClient` a batch is first created with a partition identifier option and then published.  The `SendAsync` call will receive an acknowledgment from the Event Hubs service; so long as no exception is thrown, your application can consider publishing successful.  All of your event data will be published to one of the Event Hub partitions, though there may be a slight delay until it is available to be read.

**Note:** It is important to be aware that if you are using a partition identifier, you may not also specify a partition key; they are mutually exclusive.

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

## Publishing events with custom metadata

Because an event consists mainly of an opaque set of bytes, it may be difficult for consumers of those events to make informed decisions about how to process them.  In order to allow event publishers to offer better context for consumers, events may also contain custom metadata.  One common scenario for the inclusion of metadata is to provide a hint about the type of data contained by an event, so that consumers understand its format and can deserialize it appropriately.

This metadata is not used by, or in any way meaningful to, the Event Hubs service; it exists only for coordination between event publishers and consumers.

```C# Snippet:EventHubs_Sample04_CustomMetadata
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

var producer = new EventHubBufferedProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential);

// The failure handler is required and invoked after all allowable
// retries were applied.

producer.SendEventBatchFailedAsync += args =>
{
    Debug.WriteLine($"Publishing failed for { args.EventBatch.Count } events.  Error: '{ args.Exception.Message }'");
    return Task.CompletedTask;
};

// The success handler is optional.

producer.SendEventBatchSucceededAsync += args =>
{
   Debug.WriteLine($"{ args.EventBatch.Count } events were published to partition: '{ args.PartitionId }.");
   return Task.CompletedTask;
};

try
{
    var eventData = new EventData("Hello, Event Hubs!")
    {
       MessageId = "H1",
       ContentType = "application/json"
    };

    eventData.Properties.Add("EventType", "com.microsoft.samples.hello-event");
    eventData.Properties.Add("priority", 1);
    eventData.Properties.Add("score", 9.0);

    await producer.EnqueueEventAsync(eventData);

    eventData = new EventData("Goodbye, Event Hubs!")
    {
       MessageId = "G1",
       ContentType = "application/json"
    };

    eventData.Properties.Add("EventType", "com.microsoft.samples.goodbye-event");
    eventData.Properties.Add("priority", "17");
    eventData.Properties.Add("blob", true);

    await producer.EnqueueEventAsync(eventData);
}
finally
{
    // Closing the producer will flush any
    // enqueued events that have not been published.

    await producer.CloseAsync();
}
```

## Guidance for buffered producer handler implementation

One important consideration for buffered publishing is to understand the impact of the code in the `SendEventBatchSucceededAsync` and `SendEventBatchFailedAsync` handlers.  Because the producer will await the execution of these handlers after a batch is published, the time that it takes the handler to complete its work will influence how quickly another batch can be prepared and published.  For maximum throughput, it is advised that handlers be kept as lightweight as possible and avoid long-running operations.

It is also important that you guard against exceptions in your handler code; it is strongly recommended to wrap your entire handler in a try/catch block and ensure that you do not re-throw exceptions.  Any exceptions thrown from your handler will be caught by the buffered producer, logged, and then ignored.  This ensures that the producer is resilient to handler errors but makes it difficult for applications to detect unhandled exceptions in their handler code.

## Tuning throughput for buffered publishing

To ensure consistent performance and throughput, it is common for applications to make decisions around the pattern of publishing that they use - adjusting the frequency that batches are sent and how many operations take place concurrently.  Because the `EventHubBufferedProducerClient` manages batches and publishing in the background, your application cannot directly control these aspects.

Because the handlers are awaited, it is strongly advised that you *not* invoke `CloseAsync` or `DisposeAsync` from the handlers; doing so is likely to result in a deadlock scenario.  It is safe to attempt to resend events by adding them to the back of the buffer by calling `EnqueueEventAsync` or `EnqueueEventsAsync`

By default, the `EventHubBufferedProducerClient` uses a set of values that will perform well for general-case scenarios, balancing consistent performance with ensuring that the order of events is maintained.  In the case where your application has different needs, it can provide a set of options when constructing the producer that will influence publishing behavior and help ensure that it is optimal for your specific scenarios.

The performance-related settings are:

- **MaximumWaitTime**: This is the longest that the producer will wait for a batch to be full before publishing.  For applications that publish frequently, waiting longer for a full batch may improve efficiency.  For applications that publish infrequently or sporadically, a lower value will ensure that events are not held in buffer waiting.  The default wait time is 1 second.

- **MaximumConcurrentSends**: The number of concurrent `SendAsync` calls that the producer will make.  Each call is a network request that publishes a single batch.  A higher degree of concurrency can improve throughput for applications that use an Event Hub with a large number of partitions.  Because the producer is highly asynchronous and is running background tasks, we recommend being careful when selecting a value to avoid creating contention in the thread pool.  Testing under normal load is essential.  The default concurrency is equal to the number of cores in the host environment.

- **MaximumConcurrentSendsPerPartition**: The number of concurrent `SendAsync` calls that can be active for a given partition.  To maintain the order of events, there should be only a single active send per partition.  For applications where preserving the ordering of events is not needed, increasing this value may improve throughput.  It is important to note that the _MaximumConcurrentSends_ setting is the dominant constraint and will not be exceeded by this setting.  The default concurrency is 1 send per partition.

- **MaximumEventBufferLengthPerPartition**: The maximum number of events that can be buffered for each individual partition.  This is intended to ensure that your application does not run out of memory if buffering happens more frequently than events can be published.  When this limit is reached, your application can continue to call `EnqueueEventAsync` or `EnqueueEventsAsync` without an error; the call will block until space is available.  For applications that publish a high number of smaller-sized events, increasing this limit may help to improve throughput.  For scenarios where the application is buffering large events and needs to control memory use, lowering this limit may be helpful.  The default buffer length is 1500 events per partition.

- **EnableIdempotentRetries**: Indicates whether or not events should be published using idempotent semantics for retries.   If enabled, retries during publishing will attempt to avoid duplication with a small cost to overall performance and throughput.

  **_NOTE:_** Enabling idempotent retries does not guarantee exactly-once semantics.  The Event Hubs at-least-once delivery contract still applies; duplicates are still possible but the chance of them occurring is much lower when idempotent retries are enabled.

```C# Snippet:EventHubs_Sample04_BufferedConfiguration
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

var options = new EventHubBufferedProducerClientOptions
{
    MaximumWaitTime = TimeSpan.FromSeconds(1),
    MaximumConcurrentSends = 5,
    MaximumConcurrentSendsPerPartition = 1,
    MaximumEventBufferLengthPerPartition = 5000,
    EnableIdempotentRetries = true
};

var producer = new EventHubBufferedProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential,
    options);

// The failure handler is required and invoked after all allowable
// retries were applied.

producer.SendEventBatchFailedAsync += args =>
{
    Debug.WriteLine($"Publishing failed for { args.EventBatch.Count } events.  Error: '{ args.Exception.Message }'");
    return Task.CompletedTask;
};

// The success handler is optional.

producer.SendEventBatchSucceededAsync += args =>
{
   Debug.WriteLine($"{ args.EventBatch.Count } events were published to partition: '{ args.PartitionId }.");
   return Task.CompletedTask;
};

try
{
    for (var index = 0; index < 5; ++index)
    {
        var eventData = new EventData($"Event #{ index }");
        await producer.EnqueueEventAsync(eventData);
    }
}
finally
{
    // Closing the producer will flush any
    // enqueued events that have not been published.

    await producer.CloseAsync();
}
```

## Creating and publishing multiple batches

Because an `EventDataBatch` is scoped to a single publish operation, it is often necessary to more than a single batch to publish events.  This can take many forms, with varying levels of sophistication and complexity, depending on an application's needs.  One common approach is to stage the events to be published in a `Queue` and use that as a source for building batches.

The following illustration breaks the process into discrete steps, transforming the queue of events into a set of batches to be published.  This is done to help isolate the logic of creating batches for readability.  Production applications may wish to publish batches as they become full to make more efficient use of resources.

**Note:** The batch is responsible for unmanaged resources; it is recommended that you `Dispose` the batch after it has been published.

```C# Snippet:EventHubs_Sample04_MultipleBatches
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

var producer = new EventHubProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential);

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

## Publishing events with an implicit batch

In scenarios where an application using the `EventProducerClient` wishes to publish events more frequently and is not concerned with exceeding the size limitation, it is reasonable to bypass the safety offered by using the `EventDataBatch` to offer minor throughput gains and fewer memory allocations.  In support of this scenario, the `EventProducerClient` offers a `SendAsync` overload that accepts a set of events.  This method delegates validation to the Event Hubs service to avoid the performance cost of a client-side measurement.  If the set of events that was published exceeds the size limit, an [EventHubsException](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventhubsexception?view=azure-dotnet) will be surfaced with its `Reason` set to [MessageSizeExceeded](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.eventhubsexception.failurereason?view=azure-dotnet).

When events are passed in this form, the `EventProducerClient` will package them as a single publishing operation.  When the set is published, the result is atomic; either publishing was successful for all events, or it has failed for all events.  Partial success or failure when publishing a batch is not possible.

When published, the `EventHubProducerClient` will receive an acknowledgment from the Event Hubs service; so long as no exception is thrown by this call, your application can consider publishing successful.  The service assumes responsibility for delivery of the set.  All of your event data will be published to one of the Event Hub partitions, though there may be a slight delay until it is available to be read.

```C# Snippet:EventHubs_Sample04_NoBatch
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

var producer = new EventHubProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential);

try
{
    var eventsToSend = new List<EventData>();

    for (var index = 0; index < 10; ++index)
    {
        var eventData = new EventData("Hello, Event Hubs!");
        eventsToSend.Add(eventData);
    }

    await producer.SendAsync(eventsToSend);
}
finally
{
    await producer.CloseAsync();
}
```

## Restricting a batch to a custom size limit

In some scenarios, such as when bandwidth is limited or publishers need to maintain control over how much data is transmitted at a time, a custom size limit (in bytes) may be specified when creating an `EventDataBatch`.  This will override the default limit specified by the Event Hub and allows an application to use the `EventDataBatch` to ensure that the size of events can be measured accurately and deterministically.  It is important to note that the custom limit may not exceed the limit specified by the Event Hub.

```C# Snippet:EventHubs_Sample04_CustomBatchSize
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
        MaximumSizeInBytes = 350
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
