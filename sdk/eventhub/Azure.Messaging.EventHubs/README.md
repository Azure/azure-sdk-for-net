# Azure Event Hubs client library for .NET

Azure Event Hubs is a highly scalable publish-subscribe service that can ingest millions of events per second and stream them to multiple consumers. This lets you process and analyze the massive amounts of data produced by your connected devices and applications. Once Event Hubs has collected the data, you can retrieve, transform and store it by using any real-time analytics provider or with batching/storage adapters.  If you would like to know more about Azure Event Hubs, you may wish to review: [What is Event Hubs](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-about)? 

The Azure Event Hubs client library allows for publishing and consuming of Azure Event Hubs events and may be used to:

- Emit telemetry about your application for business intelligence and diagnostic purposes.

- Publish facts about the state of your application which interested parties may observe and use as a trigger for taking action.

- Observe interesting operations and interactions happening within your business or other ecosystem, allowing loosely coupled systems to interact without the need to bind them together.

- Receive events from one or more publishers, transform them to better meet the needs of your ecosystem, then publish the transformed events to a new stream for consumers to observe.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs) | [Package (NuGet)](https://www.nuget.org/packages/Azure.Messaging.EventHubs/) | API reference documentation (coming soon) | [Product documentation](https://docs.microsoft.com/en-us/azure/event-hubs/)

## Getting started

### Prerequisites

To use Azure services, including Azure Event Hubs, you'll need a Microsoft Azure Subscription.  If you do not have an existing Azure account, you may sign up for a free trial or use your MSDN subscriber benefits when you [create an account](https://account.windowsazure.com/Home/Index). 

To interact with Azure Event Hubs, you'll also need to have an Event Hub available.  If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [creating an Event Hub using the Azure portal](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-create).  There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create an Event Hub.

To quickly create the needed Event Hubs resources in Azure and view your connection string, you can deploy our sample template by clicking:

[![](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-sdk-for-net%2Fmaster%2Fsdk%2Feventhub%Azure.Messaging.EventHubs%2Fassets%2Fsamples-azure-deploy.json)

### Install the package

Install the Azure Event Hubs client library for .NET with [NuGet](https://www.nuget.org/):

```PowerShell
Install-Package Azure.Messaging.EventHubs -Version 5.0.0-preview.1
```

### Obtain a connection string

For the Event Hubs client library to interact with an Event Hub, it will need to understand how to connect and authorize with it.  The easiest means for doing so is to use a connection string, which is created automatically when creating an Event Hubs namespace.  If you aren't familiar with shared access policies in Azure, you may wish to follow the step-by-step guide to [get an Event Hubs connection string](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string).

### Create an Event Hub client

Once the Event Hub and connection string are available, they can be used to create a client for interacting with Azure Event Hubs.  The simplest way to create an `EventHubClient` is:

```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var client = new EventHubClient(connectionString, eventHubName);
```

## Key concepts

- An **Event Hub client** is the primary interface for developers interacting with the Event Hubs client library, allowing for inspection of Event Hub metadata and providing a guided experience towards specific Event Hub operations such as the creation of producers and consumers.

- An **Event Hub producer** is a source of telemetry data, diagnostics information, usage logs, or other log data, as part of an embedded device solution, a mobile device application, a game title running on a console or other device, some client or server based business solution, or a web site.  

- An **Event Hub consumer** picks up such information from the Event Hub and processes it. Processing may involve aggregation, complex computation and filtering. Processing may also involve distribution or storage of the information in a raw or transformed fashion. Event Hub consumers are often robust and high-scale platform infrastructure parts with built-in analytics capabilities, like Azure Stream Analytics, Apache Spark, or Apache Storm.  

- A **partition** is an ordered sequence of events that is held in an Event Hub. Partitions are a means of data organization associated with the parallelism required by event consumers.  Azure Event Hubs provides message streaming through a partitioned consumer pattern in which each consumer only reads a specific subset, or partition, of the message stream. As newer events arrive, they are added to the end of this sequence. The number of partitions is specified at the time an Event Hub is created and cannot be changed.

- A **consumer group** is a view of an entire Event Hub. Consumer groups enable multiple consuming applications to each have a separate view of the event stream, and to read the stream independently at their own pace and from their own position.  There can be at most 5 concurrent readers on a partition per consumer group; however it is recommended that there is only one active consumer for a given partition and consumer group pairing. Each active reader receives all of the events from its partition; ff there are multiple readers on the same partition, then they will receive duplicate events. 

For more concepts and deeper discussion, see: [Event Hubs Features](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-features)

## Examples

### Inspect an Event Hub

Many Event Hub operations take place within the scope of a specific partition.  Because partitions are owned by the Event Hub, their names are assigned at the time of creation.  To understand what partitions are available, you query the Event Hub using the client.

```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

await using (var client = new EventHubClient(connectionString, eventHubName))
{
    string[] partitionIds = await client.GetPartitionIdsAsync();
}
```

### Consume events from an Event Hub

In order to consume events, you'll need to create an `EventHubConsumer` for a specific partition and consumer group combination.  When an Event Hub is created, it starts with a default consumer group that can be used to get started.  A consumer also needs to specify where in the event stream to begin receiving events; in our example, we will focus on reading new events as they are published.

```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

await using (var client = new EventHubClient(connectionString, eventHubName))
{
    string firstPartition = (await client.GetPartitionIdsAsync()).First();
    string consumerGroup = EventHubConsumer.DefaultConsumerGroup;
    EventPosition startingPosition = EventPosition.Latest;
    
    await using (EventHubConsumer consumer = client.CreateConsumer(consumerGroup, firstPartition, startingPosition))
    {
        int maximumEventBatchSize = 25;
        IEnumerable<EventData> eventBatch = await consumer.Receive(maximumEventBatchSize);
 
        // At this point, the eventBatch may have no events or may have as many as the maximum size requested, 
        // depending on how many events were available in the partition.
    }
}
```

### Publish events to an Event Hub

In order to publish events, you'll need to create an `EventHubProducer`.  Producers may be dedicated to a specific partition, or allow the Event Hubs service to decide which partition events should be published to.  It is recommended to use automatic routing when the publishing of events needs to be highly available or when event data should be distributed evenly among the partitions.  In the our example, we will take advantage of automatic routing.

```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

await using (var client = new EventHubClient(connectionString, eventHubName))
await using (EventHubProducer producer = client.CreateProducer())
{
    var eventsToPublish = new EventData[]
    {
        new EventData(Encoding.UTF8.GetBytes("First")),
        new EventData(Encoding.UTF8.GetBytes("Second"))
    };
    
    await producer.SendAsync(eventsToPublish);
}
```

## Troubleshooting

### Common exceptions

#### Operation Cancelled

This occurs when an operation has been requested on a client, producer, or consumer that has already been closed or disposed of.  It is recommended to check the application code and ensure that objects from the Event Hubs client library are created and closed/disposed in the intended scope.  

#### Timeout

This indicates that the Event Hubs service did not respond to an operation within the expected amount of time.  This may have been caused by a transient network issue or service problem.  The Event Hubs service may or may not have successfully completed the request; the status is not known.  It is recommended to attempt to verify the current state and retry if necessary.  

#### Message Size Exceeded

Event data, both individual and in batches, have a maximum size allowed.  This includes the data of the event, as well as any associated metadata and system overhead.  The best approach for resolving this error is to reduce the number of events being sent in a batch or the size of data included in the message.  Because size limits are subject to change, please refer to [Azure Event Hubs quotas and limits](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-quotas) for specifics.  

### Other exceptions

For detailed information about these and other exceptions that may occur, please refer to [Event Hubs messaging exceptions](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-messaging-exceptions). 

## Next steps

Beyond the scenarios discussed, the Azure Event Hubs client library offers support for many additional scenarios to help take advantage of the full feature set of the Azure Event Hubs service.  In order to help explore some of these scenarios, the following set of samples is available:

- [Hello world](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample1_HelloWorld.cs)  
  An introduction to Event Hubs, illustrating how to connect and query the service.

- [Create an Event Hub client with custom options](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample2_ClientWithCustomOptions.cs)  
  An introduction to Event Hubs, exploring additional options for creating an Event Hub client.
  
- [Publish an event to an Event Hub](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample3_PublishAnEvent3.cs)  
  An introduction to publishing events, using a simple Event Hub producer.
  
- [Publish events using a partition key](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample4_PublishEventsWithPartitionKey.cs)  
  An introduction to publishing events, using a partition key to group them together.
  
- [Publish events to a specific Event Hub partition](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample5_PublishEventsToSpecificPartitions.cs)  
  An introduction to publishing events, using an Event Hub producer that is associated with a specific partition.
  
- [Publish events with custom metadata](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample6_PublishEventsWithCustomMetadata.cs)  
  An example of publishing events, extending the event data with custom metadata.
  
- [Consume events from an Event Hub partition](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample7_ConsumeEvents.cs)  
  An introduction to consuming events, using a simple Event Hub consumer.
  
- [Consume events from an Event Hub partition in batches](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample8_ConsumeEventsByBatch)  
  An example of consuming events, using a batch approach to control throughput.
  
- [Consume events from a known position in the Event Hub partition](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample9_ConsumeEventsFromAKnownPosition)  
  An example of consuming events, starting at a well-known position in the Event Hub partition.

## Contributing  

Please refer to our [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/CONTRIBUTING.md) for more information.
  
![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs%2FFREADME.png)