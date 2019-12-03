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

  **Important Note:** The use of C# 8.0 is mandatory to run the [examples](#examples) and the [samples](#next-steps) without modification.  You can still run the samples if you decide to tweak them.

To quickly create the needed Event Hubs resources in Azure and to receive a connection string for them, you can deploy our sample template by clicking:

[![](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-sdk-for-net%2Fmaster%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs%2Fassets%2Fsamples-azure-deploy.json)

If you'd like to run samples that use [Azure.Identity](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity), you'll also need a service principal with the correct roles. To make configuration for the identity samples easier, a [PowerShell script](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/assets/identity-tests-azure-setup.ps1) script is available. Please see the [Contributing Guide](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/CONTRIBUTING.md#Azure-Identity-Samples) for more details about the script.

### Install the package

Install the Azure Event Hubs client library for .NET with [NuGet](https://www.nuget.org/):

```PowerShell
Install-Package Azure.Messaging.EventHubs -Version 5.0.0-preview.6
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

In order to publish events, you'll need to create an `EventHubProducerClient`.  Producers publish events in batches and may request a specific partition, or allow the Event Hubs service to decide which partition events should be published to.  It is recommended to use automatic routing when the publishing of events needs to be highly available or when event data should be distributed evenly among the partitions.  Our example will take advantage of automatic routing.

```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

await using (var producer = new EventHubProducerClient(connectionString, eventHubName))
{
    using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();
    eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("First")));
    eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Second")));
    
    await producer.SendAsync(eventBatch);
}
```

### Read events from an Event Hub

In order to read events from an Event Hub, you'll need to create an `EventHubConsumerClient` for a given consumer group.  When an Event Hub is created, it provides a default consumer group that can be used to get started with exploring Event Hubs.  In our example, we will focus on reading all events that have been published to the Event Hub using an iterator.

**Note:** It is important to note that this approach to consuming is intended to improve the experience of exploring the Event Hubs client library and prototyping.  It is recommended that it not be used in production scenarios.   For production use, we recommend using the [Event Processor Client](./../Azure.Messaging.EventHubs.Processor), as it provides a more robust and performant experience.

```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

await using (var consumer = new EventHubConsumerClient(consumerGroup, connectionString, eventHubName))
{
    using var cancellationSource = new CancellationTokenSource();
    cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

    await foreach (PartitionEvent receivedEvent in consumer.ReadEvents(cancellationSource.Token))
    {
        // At this point, the loop will wait for events to be available in the Event Hub.  When an event
        // is available, the loop will iterate with the event that was received.  Because we did not
        // specify a maximum wait time, the loop will wait forever unless cancellation is requested using
        // the cancellation token.
    }
}
```

### Read events from an Event Hub partition

In order to read events for an Event Hub partition, you'll need to create an `EventHubConsumerClient` for a given consumer group.  When an Event Hub is created, it provides a default consumer group that can be used to get started with exploring Event Hubs.  To read from a specific partition, the consumer will also need to specify where in the event stream to begin receiving events; in our example, we will focus on reading all published events for the first partition of the Event Hub.

```csharp
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

await using (var consumer = new EventHubConsumerClient(consumerGroup, connectionString, eventHubName))
{
    EventPosition startingPosition = EventPosition.Earliest;
    string partitionId = (await consumer.GetPartitionIdsAsync()).First();

    using var cancellationSource = new CancellationTokenSource();
    cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

    await foreach (PartitionEvent receivedEvent in consumer.ReadEventsFromPartitionAsync(partitionId, startingPosition, cancellationSource.Token))
    {
        // At this point, the loop will wait for events to be available in the partition.  When an event
        // is available, the loop will iterate with the event that was received.  Because we did not
        // specify a maximum wait time, the loop will wait forever unless cancellation is requested using
        // the cancellation token.
    }
}
```

### Process events using an Event Processor Client

For the majority of production scenarios, it is recommended that the [Event Processor Client](./../Azure.Messaging.EventHubs.Processor) be used for reading and processing events.  The processor is intended to provide a robust experience for processing events across all partitions of an Event Hub in a performant and fault tolerant manner while providing a means to persist its state.  Event Processor clients are also capable of working cooperatively within the context of a consumer group for a given Event Hub, where they will automatically manage distribution and balancing of work as instances become available or unavailable for the group.

More details can be found in the Event Processor Client [README](./../Azure.Messaging.EventHubs.Processor/README.md) and the accompanying [samples](./../Azure.Messaging.EventHubs.Processor/samples).

## Troubleshooting

### Common exceptions

#### Event Hub Client Closed

This occurs when an operation has been requested on an Event Hub client that has already been closed or disposed of.  It is recommended to check the application code and ensure that objects from the Event Hubs client library are created and closed/disposed in the intended scope.  

#### Timeout

This indicates that the Event Hubs service did not respond to an operation within the expected amount of time.  This may have been caused by a transient network issue or service problem.  The Event Hubs service may or may not have successfully completed the request; the status is not known.  It is recommended to attempt to verify the current state and retry if necessary.  

#### Quota Exceeded

This typically indicates that there are too many active read operations for a single consumer group.  This limit depends on the tier of the Event Hubs namespace, and moving to a higher tier may be desired.  An alternative would be do create additional consumer groups and ensure that the number of consumer client reads for any group is within the limit.  Please see [Azure Event Hubs quotas and limits](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-quotas) for more information.

#### Message Size Exceeded

Event data, both individual and in batches, have a maximum size allowed.  This includes the data of the event, as well as any associated metadata and system overhead.  The best approach for resolving this error is to reduce the number of events being sent in a batch or the size of data included in the message.  Because size limits are subject to change, please refer to [Azure Event Hubs quotas and limits](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-quotas) for specifics.  
### Other exceptions

For detailed information about these and other exceptions that may occur, please refer to [Event Hubs messaging exceptions](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-messaging-exceptions).

## Next steps

Beyond the introductory scenarios discussed, the Azure Event Hubs client library offers support for many additional scenarios to help take advantage of the full feature set of the Azure Event Hubs service.  In order to help explore some of these scenarios, the Event Hubs client library offers a [project of samples](./samples) to serve as an illustration for common scenarios.

The samples are accompanied by a console application which you can use to execute and debug them interactively.  The simplest way to begin is to launch the project for debugging in Visual Studio or your preferred editor and provide the Event Hubs connection information in response to the prompts.  

Each of the samples is self-contained and focused on illustrating one specific scenario.  Each is numbered, with the lower numbers concentrating on basic scenarios and building to more complex scenarios as they increase; though each sample is independent, it will assume an understanding of the content discussed in earlier samples.

The available samples are:

- [Hello world](./samples/Sample01_HelloWorld.cs)  
  An introduction to Event Hubs, illustrating how to create a client and explore an Event Hub.

- [Create an Event Hub client with custom options](./samples/Sample02_ClientWithCustomOptions.cs)  
  An introduction to Event Hubs, exploring additional options for creating the different Event Hub clients.

- [Publish an event batch to an Event Hub](./samples/Sample03_PublishAnEventBatch.cs)  
  An introduction to publishing events, using a batch with single event.  

- [Read events from an Event Hub](./samples/Sample04_ReadEvents.cs)  
  An introduction to reading all events available from an Event Hub.

- [Publish an event batch using a partition key](./samples/Sample05_PublishAnEventBatchWithPartitionKey.cs)  
  An introduction to publishing events using a partition key to group batches together.

- [Publish an event batch to a specific partition](./samples/Sample06_PublishAnEventBatchToASpecificPartition.cs)  
  An introduction to publishing events, specifying a specific partition for the batch to be published to.

- [Publish events with custom metadata](./samples/Sample07_PublishEventsWithCustomMetadata.cs)  
  An example of publishing events, extending the event data with custom metadata.

- [Read only new events from an Event Hub](./samples/Sample08_ReadOnlyNewEvents.cs)  
  An example of reading events, beginning with only those newly available from an Event Hub.

- [Read events from a known position in an Event Hub partition](./samples/Sample09_ReadEventsFromAKnownPosition.cs)  
  An example of reading events from a single Event Hub partition, starting at a well-known position.

- [Publish an event batch with a custom size limit](./samples/Sample10_PublishAnEventBatchWithCustomSizeLimit.cs)  
  An example of publishing events using a custom size limitation with the batch.

- [Authorize using a service principal with client secret](./samples/Sample11_AuthenticateWithClientSecretCredential.cs)  
  An example of interacting with an Event Hub using an Azure Active Directory application with client secret for authorization.

## Contributing  

This project welcomes contributions and suggestions.  Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

Please see our [contributing guide](./CONTRIBUTING.md) for more information.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs%2FREADME.png)
