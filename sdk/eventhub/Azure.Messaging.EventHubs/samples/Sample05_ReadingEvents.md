# Reading Events

This sample demonstrates reading events from an Event Hub.  To begin, please ensure that you're familiar with the items discussed in the [Getting started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples#getting-started) section of the README, and have the prerequisites and connection string information available.

## Table of contents

- [Client types](#client-types)
- [Event lifetime](#event-lifetime)
- [Reading and consumer groups](#reading-and-consumer-groups)
- [Reading and partitions](#reading-and-partitions)
- [Read events from all partitions](#read-events-from-all-partitions)
- [Read events from all partitions with a maximum wait time](#read-events-from-all-partitions-with-a-maximum-wait-time)
- [Read events from all partitions, starting at the end](#read-events-from-all-partitions-starting-at-the-end)
- [Read events from a partition](#read-events-from-a-partition)
- [Read events from a partition with a maximum wait time](#read-events-from-a-partition-with-a-maximum-wait-time)
- [Read events from a partition, starting from a specific date and time](#read-events-from-a-partition-starting-from-a-specific-date-and-time)
- [Read events from a partition, starting from a specific offset](#read-events-from-a-partition-starting-from-a-specific-offset)
- [Read events from a partition, starting from a specific sequence number](#read-events-from-a-partition-starting-from-a-specific-sequence-number)
- [Query partition information while reading](#query-partition-information-while-reading)
- [Read events from a partition using the `PartitionReceiver`](#read-events-from-a-partition-using-the-partitionreceiver)

## Client types

Reading events is the responsibility of an event consumer.  The client library offers several different consumers, each intended to support a specific set of scenarios.  The `EventHubConsumerClient` will be the focal point of the samples, as it offers an approachable onboarding experience for exploring Event Hubs as well as supporting some production scenarios.  More detail about the available event consumers, including those with more specialized uses, can be found in [Sample02_EventHubsClients](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample02_EventHubsClients.md).

Each of the event consumer client types are safe to cache and use for the lifetime of an application, which is best practice when the events are read regularly or semi-regularly. The event consumers are efficient resource management, adapting to periods of inactivity and higher use automatically.  Calling either the `CloseAsync` or `DisposeAsync` method as the application is shutting down will ensure that network resources and other unmanaged objects are properly cleaned up.

## Event lifetime

When events are published, they will continue to exist in the Event Hub and be available for consuming until they reach an age where they are older than the [retention period](https://learn.microsoft.com/azure/event-hubs/event-hubs-faq#what-is-the-maximum-retention-period-for-events).  After that point in time, the Event Hubs service may chose to remove them from the partition.  Once removed, an event is no longer available to be read and cannot be recovered.  Though the Event Hubs service is free to remove events older than the retention period, it does not do so deterministically; there is no guarantee of when events will be removed.

## Reading and consumer groups

An Event Hub consumer is associated with a specific Event Hub and [consumer group](https://learn.microsoft.com/azure/event-hubs/event-hubs-features#consumer-groups).  Conceptually, the consumer group is a label that identifies one or more event consumers as a set.  Often, consumer groups are named after the responsibility of the consumer in an application, such as "Telemetry" or "OrderProcessing".  When an Event Hub is created, a default consumer group is created for it, named "$Default." These examples will make use of the default consumer group for illustration.

Each consumer has a unique view of the events in a partition that it reads from, which means that events are available to all consumers and are not removed from the partition when read.  This allows consumers to read and process events from the Event Hub at different speeds without interfering with one another.

## Reading and partitions

Every event that is published is sent to one of the [partitions](https://learn.microsoft.com/azure/architecture/reference-architectures/event-hubs/partitioning-in-event-hubs-and-kafka) of the Event Hub. When reading events, an application may be interested in reading events from all partitions or limiting to a single partition, depending on the application scenarios and throughput needs.  The `EventHubConsumerClient` is not associated with any specific partition and the same instance can be used for reading from multiple partitions.

The `EventHubConsumerClient` supports reading events from a single partition and also offers an easy way to familiarize yourself with Event Hubs by reading from all partitions without the rigor and complexity that you would need in a production application.  For reading events from all partitions in a production scenario, we strongly recommend using the [EventProcessorClient](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples) from the [Azure.Messaging.EventHubs.Processor](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor) package over the `EventHubConsumerClient`.

## Read events from all partitions

The `ReadEventsAsync` method of the `EventHubConsumerClient` allows events to be read from each partition for prototyping and exploring, but is not a recommended approach for production scenarios.  Events are consumed as an [Async Enumerable](https://learn.microsoft.com/archive/msdn-magazine/2019/november/csharp-iterating-with-async-enumerables-in-csharp-8), where enumeration will emit events one-by-one.  By default, reading starts from the beginning of partitions and all events present will be surfaced.

Because an Event Hub represents a potentially infinite series of events, the enumerator will not exit when no events are available in the Event Hub partitions.  Instead, it will wait for more events to be published.  To stop reading, applications will need to either signal a [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken?view=netcore-3.1) or call `break` from the body of the loop.

This example illustrates stopping after either 3 events have been read or 45 seconds has elapsed, whichever occurs first.

```C# Snippet:EventHubs_Sample05_ReadAllPartitions
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
    cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

    int eventsRead = 0;
    int maximumEvents = 3;

    await foreach (PartitionEvent partitionEvent in consumer.ReadEventsAsync(cancellationSource.Token))
    {
        string readFromPartition = partitionEvent.Partition.PartitionId;
        byte[] eventBodyBytes = partitionEvent.Data.EventBody.ToArray();

        Debug.WriteLine($"Read event of length { eventBodyBytes.Length } from { readFromPartition }");
        eventsRead++;

        if (eventsRead >= maximumEvents)
        {
            break;
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
    await consumer.CloseAsync();
}
```

## Read events from all partitions with a maximum wait time

When using `ReadEventAsync`, it can sometimes be advantageous to ensure that the [Async Enumerable](https://learn.microsoft.com/archive/msdn-magazine/2019/november/csharp-iterating-with-async-enumerables-in-csharp-8) returns control to the application's code in the loop body periodically, whether an event was available or not.  This allows for the application to detect when events are no longer being published and is often used for emitting heartbeat data as a health check for consumers.

This example illustrates waiting for a maximum of one second for an event to be read; if no event was available in that time, the loop ticks with an empty `PartitionEvent`.  Once the example loop has ticked a total of 10 times, with or without an event available, it will exit.

```C# Snippet:EventHubs_Sample05_ReadAllPartitionsWaitTime
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
    int loopTicks = 0;
    int maximumTicks = 10;

    var options = new ReadEventOptions
    {
       MaximumWaitTime = TimeSpan.FromSeconds(1)
    };

    await foreach (PartitionEvent partitionEvent in consumer.ReadEventsAsync(options))
    {
        if (partitionEvent.Data != null)
        {
            string readFromPartition = partitionEvent.Partition.PartitionId;
            byte[] eventBodyBytes = partitionEvent.Data.EventBody.ToArray();

            Debug.WriteLine($"Read event of length { eventBodyBytes.Length } from { readFromPartition }");
        }
        else
        {
            Debug.WriteLine("Wait time elapsed; no event was available.");
        }

        loopTicks++;

        if (loopTicks >= maximumTicks)
        {
            break;
        }
    }
}
finally
{
    await consumer.CloseAsync();
}
```
## Read events from all partitions, starting at the end

By default, reading starts from the beginning of partitions.  It is possible to request reading from the end of each partition instead by setting `startReadingAtEarliestEvent` to `false`.  One important thing to note is that when a consumer reads from the end of the partition, it will only see events that are published after the `ReadEventsAsync` call has been made; any events that were published to the partition before reading will not be visible.  As a result, any events to be read will need to be published in another process, another thread, or within the loop body.

This example illustrates reading from the end of each partition, and will do so for 30 seconds regardless of how many events have been read.

```C# Snippet:EventHubs_Sample05_ReadAllPartitionsFromLatest
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

    await foreach (PartitionEvent partitionEvent in consumer.ReadEventsAsync(
        startReadingAtEarliestEvent: false,
        cancellationToken: cancellationSource.Token))
    {
        string readFromPartition = partitionEvent.Partition.PartitionId;
        byte[] eventBodyBytes = partitionEvent.Data.EventBody.ToArray();

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

## Read events from a partition

The `ReadEventsFromPartitionAsync` method of the `EventHubConsumerClient` allows events to be read from a specific partition and is suitable for production scenarios.  Events are consumed as an [Async Enumerable](https://learn.microsoft.com/archive/msdn-magazine/2019/november/csharp-iterating-with-async-enumerables-in-csharp-8), where enumeration will emit events one-by-one.  `ReadEventsFromPartitionAsync` targets a single partition, allowing consumers to request reading from a specific location in the partition's event stream by creating an [EventPosition](https://learn.microsoft.com/dotnet/api/azure.messaging.eventhubs.consumer.eventposition?view=azure-dotnet).

Because an Event Hub represents a potentially infinite series of events, the enumerator will not exit when no further events are available in the Event Hub partitions.  Instead, it will wait for more events to be published.  To stop reading, applications will need to either signal a [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken?view=netcore-3.1) or call `break` from the body of the loop.

This example illustrates the `CancellationToken` approach, reading from the beginning of the partition for only 30 seconds, regardless of how many events are read.

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

## Read events from a partition with a maximum wait time

When using `ReadEventsFromPartitionAsync`, it can sometimes be advantageous to ensure that the [Async Enumerable](https://learn.microsoft.com/archive/msdn-magazine/2019/november/csharp-iterating-with-async-enumerables-in-csharp-8) returns control to the application's code in the loop body periodically, whether an event was available or not.  This allows for the application to detect when events are no longer being published and is often used for emitting heartbeat data as a health check for consumers.

This example illustrates waiting for a maximum of one second for an event to be read; if no event was available, the loop ticks with an empty `PartitionEvent`.  Once the example loop has ticked a total of 10 times, with or without an event available, it will exit.

```C# Snippet:EventHubs_Sample05_ReadPartitionWaitTime
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

    int loopTicks = 0;
    int maximumTicks = 10;

    var options = new ReadEventOptions
    {
       MaximumWaitTime = TimeSpan.FromSeconds(1)
    };

    await foreach (PartitionEvent partitionEvent in consumer.ReadEventsFromPartitionAsync(
        firstPartition,
        startingPosition,
        options))
    {
        if (partitionEvent.Data != null)
        {
            string readFromPartition = partitionEvent.Partition.PartitionId;
            byte[] eventBodyBytes = partitionEvent.Data.EventBody.ToArray();

            Debug.WriteLine($"Read event of length { eventBodyBytes.Length } from { readFromPartition }");
        }
        else
        {
            Debug.WriteLine("Wait time elapsed; no event was available.");
        }

        loopTicks++;

        if (loopTicks >= maximumTicks)
        {
            break;
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
    await consumer.CloseAsync();
}
```

## Read events from a partition, starting from a specific date and time

When reading event from a partition, consumers can request to begin reading from the partition's event stream at a specific point in time.  This example illustrates reading events starting with an hour prior to the current time, and will continue reading for a duration of 30 seconds before cancellation is triggered.

```C# Snippet:EventHubs_Sample05_ReadPartitionFromDate
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

    DateTimeOffset oneHourAgo = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromHours(1));
    EventPosition startingPosition = EventPosition.FromEnqueuedTime(oneHourAgo);

    string firstPartition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();

    await foreach (PartitionEvent partitionEvent in consumer.ReadEventsFromPartitionAsync(
        firstPartition,
        startingPosition,
        cancellationSource.Token))
    {
        string readFromPartition = partitionEvent.Partition.PartitionId;
        byte[] eventBodyBytes = partitionEvent.Data.EventBody.ToArray();

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

## Read events from a partition, starting from a specific offset

When reading event from a partition, consumers can request to begin reading from the partition's event stream at a specific offset.  This is often used when a consumer has already processed some events from the partition and would like to resume from that point rather than reprocessing.  Offsets in a partition are not guaranteed to be contiguous, nor follow a strict pattern.  It is not recommended to attempt to calculate offsets.

This example illustrates reading events starting with the last offset that was published to the partition, and will do so for 30 seconds regardless of how many events have been read.

```C# Snippet:EventHubs_Sample05_ReadPartitionFromOffset
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
    PartitionProperties properties = await consumer.GetPartitionPropertiesAsync(firstPartition, cancellationSource.Token);
    EventPosition startingPosition = EventPosition.FromOffset(properties.LastEnqueuedOffsetString);

    await foreach (PartitionEvent partitionEvent in consumer.ReadEventsFromPartitionAsync(
        firstPartition,
        startingPosition,
        cancellationSource.Token))
    {
        string readFromPartition = partitionEvent.Partition.PartitionId;
        byte[] eventBodyBytes = partitionEvent.Data.EventBody.ToArray();

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

## Read events from a partition, starting from a specific sequence number

When reading event from a partition, consumers can request to begin reading from the partition's event stream at a specific sequence number.  This is often used when a consumer has already processed some events from the partition and would like to resume from that point rather than reprocessing.  Sequence numbers follow a consistent pattern within the context of a specific partition; they will be contiguous and in increasing order.

This example illustrates reading events starting with the last sequence number that was published to the partition, and will do so for 30 seconds regardless of how many events have been read.

```C# Snippet:EventHubs_Sample05_ReadPartitionFromSequence
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
    PartitionProperties properties = await consumer.GetPartitionPropertiesAsync(firstPartition, cancellationSource.Token);
    EventPosition startingPosition = EventPosition.FromSequenceNumber(properties.LastEnqueuedSequenceNumber);

    await foreach (PartitionEvent partitionEvent in consumer.ReadEventsFromPartitionAsync(
        firstPartition,
        startingPosition,
        cancellationSource.Token))
    {
        string readFromPartition = partitionEvent.Partition.PartitionId;
        byte[] eventBodyBytes = partitionEvent.Data.EventBody.ToArray();

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

## Query partition information while reading

Some application scenarios call for understanding the "backlog" of events in an Event Hub, where an event being consumed is compared with the latest event available in the partition to understand how many events have accumulated and have yet to be processed.  This allows applications to make reasoned decisions about scaling consumers or throttling publishers to ensure that event processing does not fall too far behind.

While the `EventHubConsumerClient` can be used to directly query the partition, doing so frequently is likely to impact performance.  When partition information is needed often, an option can be set when reading events to query the last published event information for the partition in real-time and surface it with events being processed.

This example illustrates requesting information on the last published event for the partition while reading events.  Reading will be performed for 30 seconds regardless of how many events have been read.

```C# Snippet:EventHubs_Sample05_ReadPartitionTrackLastEnqueued
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

    var options = new ReadEventOptions
    {
        TrackLastEnqueuedEventProperties = true
    };

    await foreach (PartitionEvent partitionEvent in consumer.ReadEventsFromPartitionAsync(
        firstPartition,
        startingPosition,
        options,
        cancellationSource.Token))
    {
        LastEnqueuedEventProperties properties =
            partitionEvent.Partition.ReadLastEnqueuedEventProperties();

        Debug.WriteLine($"Partition: { partitionEvent.Partition.PartitionId }");
        Debug.WriteLine($"\tThe last sequence number is: { properties.SequenceNumber }");
        Debug.WriteLine($"\tThe last offset is: { properties.OffsetString }");
        Debug.WriteLine($"\tThe last enqueued time is: { properties.EnqueuedTime }, in UTC.");
        Debug.WriteLine($"\tThe information was updated at: { properties.LastReceivedTime }, in UTC.");
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

## Read events from a partition using the `PartitionReceiver`

When an application is working at a high volume and is willing to accept additional complexity to maximize throughput, the `PartitionReceiver` is worthy of consideration.  It provides a very thin wrapper over the Event Hubs transport, allowing events to be read in batches as well as supporting options to control transport behavior.  More detail on the design and philosophy for the `PartitionReceiver` can be found in its [design document](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/design/proposal-partition-receiver.md).

Because the receiver endeavors to avoid adding overhead, it does not follow the patterns established in the `EventHubConsumerClient` nor offer some of its convenience.  Of particular note is that the model for reading events is based on polling with its `ReceiveBatchAsync` method instead of an iterator.  It is also important to be aware that the transport library is timeout-based and will not honor cancellation when a service operation is active.
This example illustrates the basic flow of reading events and will do so for 30 seconds regardless of how many events have been read.

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
