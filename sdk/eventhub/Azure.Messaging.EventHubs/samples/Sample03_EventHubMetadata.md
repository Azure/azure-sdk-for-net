# Event Hub Metadata

This sample discusses the metadata available for an Event Hub instance and demonstrates how to query and inspect the information.  To begin, please ensure that you're familiar with the items discussed in the [Getting started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples#getting-started) section of the README, and have the prerequisites and connection string information available.

## Table of contents

- [Client types](#client-types)
- [Query the properties of an Event Hub](#query-the-properties-of-an-event-hub)
- [Query the partitions of an Event Hub](#query-the-partitions-of-an-event-hub)
- [Query the properties of a partition](#query-the-properties-of-a-partition)

# Client types

Querying and inspecting metadata is a common scenario when publishing and reading events.  As a result, the core operations are available to the `EventHubProducerClient` and `EventHubConsumerClient`.

Both the `EventHubProducerClient` and `EventHubConsumerClient` are safe to cache and use for the lifetime of an application, which is best practice when the application publishes or reads events regularly or semi-regularly. The clients are responsible for efficient resource management, working to keep resource usage low during periods of inactivity and manage health during periods of higher use. Calling either the `CloseAsync` or `DisposeAsync` method on a client as the application is shutting down will ensure that network resources and other unmanaged objects are properly cleaned up.

# Query the properties of an Event Hub

Because the Event Hubs clients operate on a specific Event Hub, it is often helpful for them to have knowledge of its context.  In particular, it is common for clients to understand the partitions available.  The ability to query the Event Hub properties is available using the `EventHubProducerClient` and `EventHubConsumerClient`.  For illustration, the `EventHubProducerClient` is demonstrated, but the concept and form are common across both clients.

```C# Snippet:EventHubs_Sample03_InspectHub
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

var producer = new EventHubProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential);

try
{
    EventHubProperties properties = await producer.GetEventHubPropertiesAsync();

    Debug.WriteLine("The Event Hub has the following properties:");
    Debug.WriteLine($"\tThe path to the Event Hub from the namespace is: { properties.Name }");
    Debug.WriteLine($"\tThe Event Hub was created at: { properties.CreatedOn }, in UTC.");
    Debug.WriteLine($"\tThe following partitions are available: [{ string.Join(", ", properties.PartitionIds) }]");
}
finally
{
    await producer.CloseAsync();
}
```

# Query the partitions of an Event Hub

Due to their importance, there is also a shorthand way to query the partitions of an Event Hub.  This capability is available using the `EventHubProducerClient` and `EventHubConsumerClient`.  For illustration, the `EventHubProducerClient` is demonstrated, but the concept and form are common across both clients.

```C# Snippet:EventHubs_Sample03_QueryPartitions
var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

var producer = new EventHubProducerClient(
    fullyQualifiedNamespace,
    eventHubName,
    credential);

try
{
    string[] partitions = await producer.GetPartitionIdsAsync();
    Debug.WriteLine($"The following partitions are available: [{ string.Join(", ", partitions) }]");
}
finally
{
    await producer.CloseAsync();
}
```

# Query the properties of a partition

Some application scenarios call for understanding the "backlog" of events in an Event Hub, where an event being consumed is compared with the latest event available in the partition to understand how many events have accumulated and have yet to be processed.  This allows applications to make reasoned decisions about scaling consumers or throttling publishers to ensure that event processing does not fall too far behind. To support this, the `EventHubProducerClient` and `EventHubConsumerClient` provide the ability to query partitions of the Event Hub for information about its current state.

This query is useful for occasionally inspecting partitions, but should not be used frequently as it may negatively impact performance by saturating the connection.  When this information is needed often, an option can be set when reading events to query the last published event information for a partition in real-time.  More detail can be found in [Sample05_ReadingEvents](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample05_ReadingEvents.md#query-partition-information-while-reading).

For illustration, the `EventHubConsumerClient` is demonstrated, but the concept and form are common across both clients.

```C# Snippet:EventHubs_Sample03_InspectPartition
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
    string[] partitions = await consumer.GetPartitionIdsAsync();
    string firstPartition = partitions.FirstOrDefault();

    PartitionProperties partitionProperties = await consumer.GetPartitionPropertiesAsync(firstPartition);

    Debug.WriteLine($"Partition: { partitionProperties.Id }");
    Debug.WriteLine($"\tThe partition contains no events: { partitionProperties.IsEmpty }");
    Debug.WriteLine($"\tThe first sequence number is: { partitionProperties.BeginningSequenceNumber }");
    Debug.WriteLine($"\tThe last sequence number is: { partitionProperties.LastEnqueuedSequenceNumber }");
    Debug.WriteLine($"\tThe last offset is: { partitionProperties.LastEnqueuedOffsetString }");
    Debug.WriteLine($"\tThe last enqueued time is: { partitionProperties.LastEnqueuedTime }, in UTC.");
}
finally
{
    await consumer.CloseAsync();
}
```
