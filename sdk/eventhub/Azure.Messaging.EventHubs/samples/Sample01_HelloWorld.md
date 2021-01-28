# Hello World: Publishing and Reading Events

This sample demonstrates the basic flow of events through an Event Hub, with the goal of quickly allowing you to publish events and read from the Event Hubs service.  To accomplish this, the `EventHubProducerClient` and `EventHubConsumerClient` types will be introduced, along with some of the core concepts of Event Hubs.

To begin, please ensure that you're familiar with the items discussed in the [Getting started](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples#getting-started) section of the README, and have the prerequisites and connection string information available.

## Create the clients

To interact with Event Hubs, a client is needed for each area of functionality - such as publishing and reading of events.  All clients are scoped to a single Event Hub instance under an Event Hubs namespace, and clients that read events are also scoped to a consumer group.  For this example, we'll configure our clients using the set of information that follows.

```C# Snippet:EventHubs_SamplesCommon_ConsumerBasicConfig
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
```

Each of the Event Hubs client types are safe to cache and use for the lifetime of the application, which is best practice when the application publishes or reads events regularly or semi-regularly. The clients hold responsibility for efficient resource management, working to keep resource usage low during periods of inactivity and manage health during periods of higher use. Calling either the `CloseAsync` or `DisposeAsync` method on a client as the application is shutting down will ensure that network resources and other unmanaged objects are properly cleaned up.

```C# Snippet:EventHubs_Sample01_CreateClients
var producer = new EventHubProducerClient(connectionString, eventHubName);
var consumer = new EventHubConsumerClient(consumerGroup, connectionString, eventHubName);
```

## Publish events

To publish events, we will need the `EventHubsProducerClient` that was created.  Because this is the only area of our sample that will be publishing events, we will close the client once publishing has completed.  In the majority of real-world scenarios, closing the producer when the application exits is often the preferred pattern.  

So that we have something to read, our example will publish a full batch of events.  The `EventHubDataBatch` exists to ensure that a set of events can safely be published without exceeding the size allowed by the Event Hub.  The `EventDataBatch` queries the service to understand the maximum size and is responsible for accurately measuring each event as it is added to the batch.  When its `TryAdd` method returns `false`, the event is too large to fit into the batch.

```C# Snippet:EventHubs_Sample01_PublishEvents
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

## Read events

Now that the events have been published, we'll read back all events from the Event Hub using the `EventHubConsumerClient` that was created.  It's important to note that because events are not removed when reading, if you're using an existing Event Hub, you are likely to see events that had been previously published as well as those from the batch that we just sent.

An Event Hub consumer is associated with a specific Event Hub and [consumer group](https://docs.microsoft.com/azure/event-hubs/event-hubs-features#consumer-groups).  Conceptually, the consumer group is a label that identifies one or more event consumers as a set.  Often, consumer groups are named after the responsibility of the consumer in an application, such as "Telemetry" or "OrderProcessing".  When an Event Hub is created, a default consumer group is created for it, named "$Default."  The default group is what we'll be using for illustration.

Each consumer has a unique view of the events in a partition that it reads from, which means that events are available to all consumers and are not removed from the partition when read.  This allows consumers to read and process events from the Event Hub at different speeds without interfering with one another.

When events are published, they will continue to exist in the Event Hub and be available for consuming until they reach an age where they are older than the [retention period](https://docs.microsoft.com//azure/event-hubs/event-hubs-faq#what-is-the-maximum-retention-period-for-events).  Once removed, the events are no longer available to be read and cannot be recovered.  Though the Event Hubs service is free to remove events older than the retention period, it does not do so deterministically; there is no guarantee of when events will be removed.

```C# Snippet:EventHubs_Sample01_ReadEvents
try
{
    // To ensure that we do not wait for an indeterminate length of time, we'll
    // stop reading after we receive five events.  For a fresh Event Hub, those
    // will be the first five that we had published.  We'll also ask for
    // cancellation after 90 seconds, just to be safe.

    using var cancellationSource = new CancellationTokenSource();
    cancellationSource.CancelAfter(TimeSpan.FromSeconds(90));

    var maximumEvents = 5;
    var eventDataRead = new List<string>();

    await foreach (PartitionEvent partitionEvent in consumer.ReadEventsAsync(cancellationSource.Token))
    {
        eventDataRead.Add(partitionEvent.Data.EventBody.ToString());

        if (eventDataRead.Count >= maximumEvents)
        {
            break;
        }
    }

    // At this point, the data sent as the body of each event is held
    // in the eventDataRead set.
}
catch
{
    // Transient failures will be automatically retried as part of the
    // operation. If this block is invoked, then the exception was either
    // fatal or all retries were exhausted without a successful read.
}
finally
{
   await consumer.CloseAsync();
}
```

This example makes use of the `ReadEvents` method of the `EventHubConsumerClient`, which allows it to see events from all [partitions](https://docs.microsoft.com/azure/event-hubs/event-hubs-features#partitions) of an Event Hub.  While this is convenient to use for exploration, we strongly recommend not using it for production scenarios.  `ReadEvents` does not guarantee fairness amongst the partitions during iteration; each of the partitions compete to publish events to be read.  Depending on how service communication takes place, there may be a clustering of events per partition and a noticeable bias for a given partition or subset of partitions.

To read from all partitions in a production application, we recommend preferring the [EventProcessorClient](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples) or a custom [EventProcessor<TPartition>](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs.primitives.eventprocessor-1?view=azure-dotnet) implementation.