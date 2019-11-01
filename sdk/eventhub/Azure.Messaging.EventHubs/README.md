# Azure Event Hubs client library for .NET

Azure Event Hubs is a highly scalable publish-subscribe service that can ingest millions of events per second and stream them to multiple consumers. This lets you process and analyze the massive amounts of data produced by your connected devices and applications. Once Event Hubs has collected the data, you can retrieve, transform and store it by using any real-time analytics provider or with batching/storage adapters.  If you would like to know more about Azure Event Hubs, you may wish to review: [What is Event Hubs](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-about)?

The Azure Event Hubs client library allows for publishing and consuming of Azure Event Hubs events and may be used to:

- Emit telemetry about your application for business intelligence and diagnostic purposes.

- Publish facts about the state of your application which interested parties may observe and use as a trigger for taking action.

- Observe interesting operations and interactions happening within your business or other ecosystem, allowing loosely coupled systems to interact without the need to bind them together.

- Receive events from one or more publishers, transform them to better meet the needs of your ecosystem, then publish the transformed events to a new stream for consumers to observe.

[Source code](.) | [Package (NuGet)](https://www.nuget.org/packages/Azure.Messaging.EventHubs/) | [API reference documentation](https://azure.github.io/azure-sdk-for-net/eventhub.html) | [Product documentation](https://docs.microsoft.com/en-us/azure/event-hubs/)

## Getting started

### Prerequisites

- **Microsoft Azure Subscription:**  To use Azure services, including Azure Event Hubs, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a free trial or use your MSDN subscriber benefits when you [create an account](https://account.windowsazure.com/Home/Index).

- **Event Hubs namespace with an Event Hub:** To interact with Azure Event Hubs, you'll also need to have a namespace and Event Hub available.  If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [creating an Event Hub using the Azure portal](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-create).  There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create an Event Hub.

- **C# 8.0:** The Azure Event Hubs client library makes use of new features that were introduced in C# 8.0.  You can still use the library with older versions of C#, but some of its functionality won't be available.  In order to enable these features, you need to [target .NET Core 3.0](https://docs.microsoft.com/en-us/dotnet/standard/frameworks#how-to-specify-target-frameworks) or [specify the language version](https://docs.microsoft.com/en-gb/dotnet/csharp/language-reference/configure-language-version#override-a-default) you want to use (8.0 or above).  If you are using Visual Studio, versions prior to Visual Studio 2019 are not compatible with the tools needed to build C# 8.0 projects.  Visual Studio 2019, including the free Community edition, can be downloaded [here](https://visualstudio.microsoft.com/vs/).

  **Important Note:** The use of C# 8.0 is mandatory to run the [examples](#examples) and the [samples](#next-steps) below.  It's necessary to run them without modification.  You can still run the samples if you decide to tweak them.

To quickly create the needed Event Hubs resources in Azure and to receive a connection string for them, you can deploy our sample template by clicking:

[![](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-sdk-for-net%2Fmaster%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs%2Fassets%2Fsamples-azure-deploy.json)

### Install the package

Install the Azure Event Hubs client library for .NET with [NuGet](https://www.nuget.org/):

```PowerShell
Install-Package Azure.Messaging.EventHubs -Version 5.0.0-preview.5
```

### Obtain a connection string

For the Event Hubs client library to interact with an Event Hub, it will need to understand how to connect and authorize with it.  The easiest means for doing so is to use a connection string, which is created automatically when creating an Event Hubs namespace.  If you aren't familiar with shared access policies in Azure, you may wish to follow the step-by-step guide to [get an Event Hubs connection string](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string).

## Key concepts

- An **Event Hub client** is the primary interface for developers interacting with the Event Hubs client library.  There are several different Event Hub clients, each dedicated to a specific use of Event Hubs, such as publishing or consuming events.

- An **Event Hub producer** is a type of client that serves as a source of telemetry data, diagnostics information, usage logs, or other log data, as part of an embedded device solution, a mobile device application, a game title running on a console or other device, some client or server based business solution, or a web site.  

- An **Event Hub consumer** is a type of client which reads information from the Event Hub and allows processing of it. Processing may involve aggregation, complex computation and filtering. Processing may also involve distribution or storage of the information in a raw or transformed fashion. Event Hub consumers are often robust and high-scale platform infrastructure parts with built-in analytics capabilities, like Azure Stream Analytics, Apache Spark, or Apache Storm.  

- A **partition** is an ordered sequence of events that is held in an Event Hub. Partitions are a means of data organization associated with the parallelism required by event consumers.  Azure Event Hubs provides message streaming through a partitioned consumer pattern in which each consumer only reads a specific subset, or partition, of the message stream. As newer events arrive, they are added to the end of this sequence. The number of partitions is specified at the time an Event Hub is created and cannot be changed.

- A **consumer group** is a view of an entire Event Hub. Consumer groups enable multiple consuming applications to each have a separate view of the event stream, and to read the stream independently at their own pace and from their own position.  There can be at most 5 concurrent readers on a partition per consumer group; however it is recommended that there is only one active consumer for a given partition and consumer group pairing. Each active reader receives all of the events from its partition; if there are multiple readers on the same partition, then they will receive duplicate events. 

For more concepts and deeper discussion, see: [Event Hubs Features](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-features).

## Examples

### Inspect an Event Hub

Many Event Hub operations take place within the scope of a specific partition.  Because partitions are owned by the Event Hub, their names are assigned at the time of creation.  To understand what partitions are available, you query the Event Hub using one of the Event Hub clients.

```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

await using (var client = new EventHubProducerClient(connectionString, eventHubName))
{
    string[] partitionIds = await client.GetPartitionIdsAsync();
}
```

### Publish events to an Event Hub

In order to publish events, you'll need to create an `EventHubProducerClient`.  Producers may publish events to a specific partition, or allow the Event Hubs service to decide which partition events should be published to.  It is recommended to use automatic routing when the publishing of events needs to be highly available or when event data should be distributed evenly among the partitions.  Our example will take advantage of automatic routing.

```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

await using (var producer = new EventHubProducerClient(connectionString, eventHubName))
{
    var eventsToPublish = new EventData[]
    {
        new EventData(Encoding.UTF8.GetBytes("First")),
        new EventData(Encoding.UTF8.GetBytes("Second"))
    };
    
    await producer.SendAsync(eventsToPublish);
}
```

### Consume events from an Event Hub partition

In order to consume events for an Event Hub partition, you'll need to create an `EventHubConsumerClient` for that partition and consumer group combination.  When an Event Hub is created, it provides a default consumer group that can be used to get started.  A consumer also needs to specify where in the event stream to begin receiving events; in our example, we will focus on reading all published events in a partition using an iterator.

```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

EventPosition startingPosition = EventPosition.Earliest;
string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
string partitionId;

await using (var client = new EventHubProducerClient(connectionString, eventHubName))
{
    partitionId = (await client.GetPartitionIdsAsync()).First();
}
    
await using (var consumer = new EventHubConsumerClient(consumerGroup, partitionId, startingPosition, connectionString, eventHubName))
{
    using var cancellationSource = new CancellationTokenSource();
    cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));
    
    await foreach (EventData receivedEvent in consumer.SubcribeToEvents(cancellationSource.Token))
    {
        // At this point, the loop will wait for events to be available in the partition.  When an event 
        // is available, the loop will iterate with the event that was received.  Because we did not 
        // specify a maximum wait time, the loop will wait forever unless cancellation is requested using
        // the cancellation token.
    }
}
```

### Consume events using an Event Processor Client

To consume events for all partitions of an Event Hub, you'll create an `EventProcessorClient` for a specific consumer group.  When an Event Hub is created, it provides a default consumer group that can be used to get started.

The `EventProcessorClient` delegates processing of events to a handler delegate that you provide, allowing your logic to focus on the events received while the processor holds responsibility for managing the underlying Event Hubs operations.  In our example, we will focus on building the `EventProcessorClient` and use a very minimal processor handler that does no actual processing.

**Important Note:** This sample makes use of the `InMemoryPartitionManager`, which is recommended only for exploring the event processor.  It uses volatile memory to store checkpoints which track the state of processing for each partition.  This means that each time the event processor is run with a new `InMemoryPartitionManager` instance, it will re-process all events, rather than starting where a checkpoint was last created.

```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
PartitionManager partitionManager = new InMemoryPartitionManager(Console.WriteLine);

await using (var processor = new EventProcessorClient(consumerGroup, client, partitionManager, connectionString, eventHubName))
{
    // This example implements only the essential methods for processing events
    // and handling errors.  There are also methods that you can provide which influence 
    // a partition being initialized for processing and to be notified when a partition will no
    // longer be processed.
    
    processor.ProcessEventsAsync = (PartitionContext partitionContext, EventData eventToProcess) =>
    {
        // Perform processing of the event here.
        
        return Task.CompletedTask;
    };
    
    processor.ProcessExceptionAsync = (PartitionContext partitionContext, Exception exception) =>
    {
        // Any exception which occurs as a result of the event processor itself will be passed to 
        // this delegate so it may be handled.  The processor will continue to process events if 
        // it is able to unless this handler explicitly requests that it stop doing so.
        //
        // It is important to note that this does not include exceptions during event processing; those
        // are considered responsibility of the developer implementing the event processing handler.  It
        // is, therefore, highly encouraged that best practices for exception handling practices are
        // followed with that delegate.
                    
        return Task.CompletedTask;
    }
    
    await processor.StartAsync();
        
    // At this point, the processor is consuming events from each partition of the Event Hub and
    // delegating them for processing.  These operations occur in the background and will not block. 
    //
    // In this example, we'll stop processing after two minutes has elapsed.
        
    await Task.Delay(TimeSpan.FromMinutes(2));
    await processor.StopAsync();
}
```
## Troubleshooting

### Common exceptions

#### Event Hub Client Closed

This occurs when an operation has been requested on an Event Hub client that has already been closed or disposed of.  It is recommended to check the application code and ensure that objects from the Event Hubs client library are created and closed/disposed in the intended scope.  

#### Timeout

This indicates that the Event Hubs service did not respond to an operation within the expected amount of time.  This may have been caused by a transient network issue or service problem.  The Event Hubs service may or may not have successfully completed the request; the status is not known.  It is recommended to attempt to verify the current state and retry if necessary.  

#### Message Size Exceeded

Event data, both individual and in batches, have a maximum size allowed.  This includes the data of the event, as well as any associated metadata and system overhead.  The best approach for resolving this error is to reduce the number of events being sent in a batch or the size of data included in the message.  Because size limits are subject to change, please refer to [Azure Event Hubs quotas and limits](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-quotas) for specifics.  
### Other exceptions

For detailed information about these and other exceptions that may occur, please refer to [Event Hubs messaging exceptions](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-messaging-exceptions). 

## Next steps

Beyond the scenarios discussed, the Azure Event Hubs client library offers support for many additional scenarios to help take advantage of the full feature set of the Azure Event Hubs service.  In order to help explore some of these scenarios, the Event Hubs client library offers a [project of samples](./samples) to serve as an illustration for common scenarios.

The samples are accompanied by a console application which you can use to execute and debug them interactively.  The simplest way to begin is to launch the project for debugging in Visual Studio or your preferred IDE and provide the Event Hubs connection information in response to the prompts.  

Each of the samples is self-contained and focused on illustrating one specific scenario.  Each is numbered, with the lower numbers concentrating on basic scenarios and building to more complex scenarios as they increase; though each sample is independent, it will assume an understanding of the content discussed in earlier samples.

The available samples are:

- [Hello world](./samples/Sample01_HelloWorld.cs)
  An introduction to Event Hubs, illustrating how to create a client and explore an Event Hub.

- [Create an Event Hub client with custom options](./samples/Sample02_ClientWithCustomOptions.cs)
  An introduction to Event Hubs, exploring additional options for creating the different Event Hub clients.
  
- [Publish an event to an Event Hub](./samples/Sample03_PublishAnEvent.cs)
  An introduction to publishing events, using a simple Event Hub producer client.
  
- [Publish events using a partition key](./samples/Sample04_PublishEventsWithPartitionKey.cs)
  An introduction to publishing events, using a partition key to group them together.
  
- [Publish a size-limited batch of events](./samples/Sample05_PublishAnEventBatch.cs)
  An introduction to publishing events, using a size-aware batch to ensure the size does not exceed the transport size limits.

- [Publish events to a specific Event Hub partition](./samples/Sample06_PublishEventsToSpecificPartitions.cs)
  An introduction to publishing events, using an Event Hub producer client that is associated with a specific partition.
  
- [Publish events with custom metadata](./samples/Sample07_PublishEventsWithCustomMetadata.cs)
  An example of publishing events, extending the event data with custom metadata.
  
- [Consume events from an Event Hub partition](./samples/Sample08_ConsumeEvents.cs)
  An introduction to consuming events, using a simple Event Hub consumer client.
  
- [Consume events from an Event Hub partition, limiting the period of time to wait for an event](./samples/Sample09_ConsumeEventsWithMaximumWaitTime.cs)
  An introduction to consuming events, using an Event Hub consumer client with maximum wait time.

- [Consume events from a known position in the Event Hub partition](./samples/Sample10_ConsumeEventsFromAKnownPosition.cs)
  An example of consuming events, starting at a well-known position in the Event Hub partition.
  
- [Consume events from an Event Hub partition in batches](./samples/Sample11_ConsumeEventsByBatch.cs)
  An example of consuming events, using a batch approach to control throughput.
  
- [Consume events from all partitions of an Event Hub with the Event Processor](./samples/Sample12_ConsumeEventsWithEventProcessor.cs)
  An example of consuming events from all Event Hub partitions at once, using the Event Processor client.

## Contributing  

This project welcomes contributions and suggestions.  Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

Please see our [contributing guide](./CONTRIBUTING.md) for more information.
  
![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs%2FFREADME.png)