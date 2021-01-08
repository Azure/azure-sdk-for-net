# Azure Event Hubs client library for .NET

Azure Event Hubs is a highly scalable publish-subscribe service that can ingest millions of events per second and stream them to multiple consumers. This lets you process and analyze the massive amounts of data produced by your connected devices and applications. Once Event Hubs has collected the data, you can retrieve, transform, and store it by using any real-time analytics provider or with batching/storage adapters.  If you would like to know more about Azure Event Hubs, you may wish to review: [What is Event Hubs](https://docs.microsoft.com/azure/event-hubs/event-hubs-about).

The Azure Event Hubs client library allows for publishing and consuming of Azure Event Hubs events and may be used to:

- Emit telemetry about your application for business intelligence and diagnostic purposes.

- Publish facts about the state of your application which interested parties may observe and use as a trigger for taking action.

- Observe interesting operations and interactions happening within your business or other ecosystem, allowing loosely coupled systems to interact without the need to bind them together.

- Receive events from one or more publishers, transform them to better meet the needs of your ecosystem, then publish the transformed events to a new stream for consumers to observe.

[Source code](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.Messaging.EventHubs/) | [API reference documentation](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs?view=azure-dotnet)) | [Product documentation](https://docs.microsoft.com/azure/event-hubs/) | [Migration guide](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/MigrationGuide.md)

## Getting started

### Prerequisites

- **Azure Subscription:**  To use Azure services, including Azure Event Hubs, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://account.windowsazure.com/Home/Index).

- **Event Hubs namespace with an Event Hub:** To interact with Azure Event Hubs, you'll also need to have a namespace and Event Hub available.  If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [creating an Event Hub using the Azure portal](https://docs.microsoft.com/azure/event-hubs/event-hubs-create).  There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create an Event Hub.

- **C# 8.0:** The Azure Event Hubs client library makes use of new features that were introduced in C# 8.0.  In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 3.0 or higher with a [language version](https://docs.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.  It is also possible to compile with the .NET Core SDK 2.1.x using a language version of `preview`.   

  Visual Studio users wishing to take full advantage of the C# 8.0 syntax will need to use Visual Studio 2019 or later.  Visual Studio 2019, including the free Community edition, can be downloaded [here](https://visualstudio.microsoft.com).  Users of Visual Studio 2017 can take advantage of the C# 8 syntax by making use of the [Microsoft.Net.Compilers NuGet package](https://www.nuget.org/packages/Microsoft.Net.Compilers/) and setting the language version, though the editing experience may not be ideal.

  You can still use the library with previous C# language versions, but will need to manage asynchronous enumerable and asynchronous disposable members manually rather than benefiting from the new syntax.  You may still target any framework version supported by your .NET Core SDK, including earlier versions of .NET Core or the .NET framework.  For more information, see: [how to specify target frameworks](https://docs.microsoft.com/dotnet/standard/frameworks#how-to-specify-target-frameworks).  

  **Important Note:** In order to build or run the [examples](#examples) and the [samples](#next-steps) without modification, use of C# 8.0 is mandatory.  You can still run the samples if you decide to tweak them for other language versions.  An example of doing so is available in the sample: [Earlier Language Versions](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample07_EarlierLanguageVersions.md).

To quickly create a basic set of Event Hubs resources in Azure and to receive a connection string for them, you can deploy our sample template by clicking:

[![](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-sdk-for-net%2Fmaster%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs%2Fassets%2Fsamples-azure-deploy.json)

### Install the package

Install the Azure Event Hubs client library for .NET with [NuGet](https://www.nuget.org/):

```PowerShell
dotnet add package Azure.Messaging.EventHubs
```

### Authenticate the client

For the Event Hubs client library to interact with an Event Hub, it will need to understand how to connect and authorize with it.  The easiest means for doing so is to use a connection string, which is created automatically when creating an Event Hubs namespace.  If you aren't familiar with using connection strings with Event Hubs, you may wish to follow the step-by-step guide to [get an Event Hubs connection string](https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string).
## Key concepts

- An **Event Hub client** is the primary interface for developers interacting with the Event Hubs client library.  There are several different Event Hub clients, each dedicated to a specific use of Event Hubs, such as publishing or consuming events.

- An **Event Hub producer** is a type of client that serves as a source of telemetry data, diagnostics information, usage logs, or other log data, as part of an embedded device solution, a mobile device application, a game title running on a console or other device, some client or server based business solution, or a web site.  

- An **Event Hub consumer** is a type of client which reads information from the Event Hub and allows processing of it. Processing may involve aggregation, complex computation and filtering. Processing may also involve distribution or storage of the information in a raw or transformed fashion. Event Hub consumers are often robust and high-scale platform infrastructure parts with built-in analytics capabilities, like Azure Stream Analytics, Apache Spark, or Apache Storm.  

- A **partition** is an ordered sequence of events that is held in an Event Hub. Partitions are a means of data organization associated with the parallelism required by event consumers.  Azure Event Hubs provides message streaming through a partitioned consumer pattern in which each consumer only reads a specific subset, or partition, of the message stream. As newer events arrive, they are added to the end of this sequence. The number of partitions is specified at the time an Event Hub is created and cannot be changed.

- A **consumer group** is a view of an entire Event Hub. Consumer groups enable multiple consuming applications to each have a separate view of the event stream, and to read the stream independently at their own pace and from their own position.  There can be at most 5 concurrent readers on a partition per consumer group; however it is recommended that there is only one active consumer for a given partition and consumer group pairing. Each active reader receives all of the events from its partition; if there are multiple readers on the same partition, then they will receive duplicate events. 

For more concepts and deeper discussion, see: [Event Hubs Features](https://docs.microsoft.com/azure/event-hubs/event-hubs-features).

## Examples

### Inspect an Event Hub

Many Event Hub operations take place within the scope of a specific partition.  Because partitions are owned by the Event Hub, their names are assigned at the time of creation.  To understand what partitions are available, you query the Event Hub using one of the Event Hub clients.  For illustration, the `EventHubProducerClient` is demonstrated in these examples, but the concept and form are common across clients.

```C# Snippet:EventHubs_ReadMe_Inspect
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

await using (var producer = new EventHubProducerClient(connectionString, eventHubName))
{
    string[] partitionIds = await producer.GetPartitionIdsAsync();
}
```

### Publish events to an Event Hub

In order to publish events, you'll need to create an `EventHubProducerClient`.  Producers publish events in batches and may request a specific partition, or allow the Event Hubs service to decide which partition events should be published to.  It is recommended to use automatic routing when the publishing of events needs to be highly available or when event data should be distributed evenly among the partitions.  Our example will take advantage of automatic routing.

```C# Snippet:EventHubs_ReadMe_Publish
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

await using (var producer = new EventHubProducerClient(connectionString, eventHubName))
{
    using EventDataBatch eventBatch = await producer.CreateBatchAsync();
    eventBatch.TryAdd(new EventData(new BinaryData("First")));
    eventBatch.TryAdd(new EventData(new BinaryData("Second")));

    await producer.SendAsync(eventBatch);
}
```

### Read events from an Event Hub

In order to read events from an Event Hub, you'll need to create an `EventHubConsumerClient` for a given consumer group.  When an Event Hub is created, it provides a default consumer group that can be used to get started with exploring Event Hubs.  In our example, we will focus on reading all events that have been published to the Event Hub using an iterator.

**Note:** It is important to note that this approach to consuming is intended to improve the experience of exploring the Event Hubs client library and prototyping.  It is recommended that it not be used in production scenarios.   For production use, we recommend using the [Event Processor Client](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor), as it provides a more robust and performant experience.

```C# Snippet:EventHubs_ReadMe_Read
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

await using (var consumer = new EventHubConsumerClient(consumerGroup, connectionString, eventHubName))
{
    using var cancellationSource = new CancellationTokenSource();
    cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

    await foreach (PartitionEvent receivedEvent in consumer.ReadEventsAsync(cancellationSource.Token))
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

```C# Snippet:EventHubs_ReadMe_Read
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

await using (var consumer = new EventHubConsumerClient(consumerGroup, connectionString, eventHubName))
{
    using var cancellationSource = new CancellationTokenSource();
    cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

    await foreach (PartitionEvent receivedEvent in consumer.ReadEventsAsync(cancellationSource.Token))
    {
        // At this point, the loop will wait for events to be available in the Event Hub.  When an event
        // is available, the loop will iterate with the event that was received.  Because we did not
        // specify a maximum wait time, the loop will wait forever unless cancellation is requested using
        // the cancellation token.
    }
}
```

### Process events using an Event Processor client

For the majority of production scenarios, it is recommended that the [Event Processor Client](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor) be used for reading and processing events.  The processor is intended to provide a robust experience for processing events across all partitions of an Event Hub in a performant and fault tolerant manner while providing a means to persist its state.  Event Processor clients are also capable of working cooperatively within the context of a consumer group for a given Event Hub, where they will automatically manage distribution and balancing of work as instances become available or unavailable for the group.

Since the `EventProcessorClient` has a dependency on Azure Storage blobs for persistence of its state, you'll need to provide a `BlobContainerClient` for the processor, which has been configured for the storage account and container that should be used.

```C# Snippet:EventHubs_Processor_ReadMe_ProcessUntilCanceled
var cancellationSource = new CancellationTokenSource();
cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

Task processEventHandler(ProcessEventArgs eventArgs) => Task.CompletedTask;
Task processErrorHandler(ProcessErrorEventArgs eventArgs) => Task.CompletedTask;

var storageClient = new BlobContainerClient(storageConnectionString, blobContainerName);
var processor = new EventProcessorClient(storageClient, consumerGroup, eventHubsConnectionString, eventHubName);

processor.ProcessEventAsync += processEventHandler;
processor.ProcessErrorAsync += processErrorHandler;

await processor.StartProcessingAsync();

try
{
    // The processor performs its work in the background; block until cancellation
    // to allow processing to take place.
    await Task.Delay(Timeout.Infinite, cancellationSource.Token);
}
catch (TaskCanceledException)
{
    // This is expected when the delay is canceled.
}

try
{
    await processor.StopProcessingAsync();
}
finally
{
    // To prevent leaks, the handlers should be removed when processing is complete.
    processor.ProcessEventAsync -= processEventHandler;
    processor.ProcessErrorAsync -= processErrorHandler;
}
```

More details can be found in the Event Processor Client [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/README.md) and the accompanying [samples](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples).

### Using an Active Directory principal with the Event Hub clients

The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md) provides Azure Active Directory authentication support which can be used for the Azure client libraries, including Event Hubs.

To make use of an Active Directory principal, one of the available credentials from the `Azure.Identity` library is specified when creating the Event Hubs client.  In addition, the fully qualified Event Hubs namespace and the name of desired Event Hub are supplied in lieu of the Event Hubs connection string.  For illustration, the `EventHubProducerClient` is demonstrated in these examples, but the concept and form are common across clients.

```C# Snippet:EventHubs_ReadMe_PublishIdentity
TokenCredential credential = new DefaultAzureCredential();

var fullyQualifiedNamespace = "<< FULLY-QUALIFIED EVENT HUBS NAMESPACE (like something.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

await using (var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential))
{
    using EventDataBatch eventBatch = await producer.CreateBatchAsync();
    eventBatch.TryAdd(new EventData(new BinaryData("First")));
    eventBatch.TryAdd(new EventData(new BinaryData("Second")));

    await producer.SendAsync(eventBatch);
}
```

When using Azure Active Directory, your principal must be assigned a role which allows access to Event Hubs, such as the `Azure Event Hubs Data Owner` role. For more information about using Azure Active Directory authorization with Event Hubs, please refer to [the associated documentation](https://docs.microsoft.com/azure/event-hubs/authorize-access-azure-active-directory).

## Troubleshooting

### Exception handling

#### Event Hubs Exception

An `EventHubsException` is triggered when an operation specific to Event Hubs has encountered an issue, including both errors within the service and specific to the client.  The exception includes some contextual information to assist in understanding the context of the error and its relative severity.  These are:

- `IsTransient` : This identifies whether or not the exception is considered recoverable.  In the case where it was deemed transient, the appropriate retry policy has already been applied and retries were unsuccessful.

- `Reason` : Provides a set of well-known reasons for the failure that help to categorize and clarify the root cause.  These are intended to allow for applying exception filtering and other logic where inspecting the text of an exception message wouldn't be ideal.   Some key failure reasons are:

  - **Client Closed** : This occurs when an operation has been requested on an Event Hub client that has already been closed or disposed of.  It is recommended to check the application code and ensure that objects from the Event Hubs client library are created and closed/disposed in the intended scope.  

  - **Service Timeout** : This indicates that the Event Hubs service did not respond to an operation within the expected amount of time.  This may have been caused by a transient network issue or service problem.  The Event Hubs service may or may not have successfully completed the request; the status is not known.  It is recommended to attempt to verify the current state and retry if necessary.  

  - **Quota Exceeded** : This typically indicates that there are too many active read operations for a single consumer group.  This limit depends on the tier of the Event Hubs namespace, and moving to a higher tier may be desired.  An alternative would be to create additional consumer groups and ensure that the number of consumer client reads for any group is within the limit.  Please see [Azure Event Hubs quotas and limits](https://docs.microsoft.com/azure/event-hubs/event-hubs-quotas) for more information.

  - **Message Size Exceeded** : Event data as a maximum size allowed for both an individual event and a batch of events.  This includes the data of the event, as well as any associated metadata and system overhead.  The best approach for resolving this error is to reduce the number of events being sent in a batch or the size of data included in the message.  Because size limits are subject to change, please refer to [Azure Event Hubs quotas and limits](https://docs.microsoft.com/azure/event-hubs/event-hubs-quotas) for specifics.  
  
  - **Consumer Disconnected** : A consumer client was disconnected by the Event Hub service from the Event Hub instance.  This typically occurs when a consumer with a higher owner level asserts ownership over a partition and consumer group pairing.
  
  - **Resource Not Found**: An Event Hubs resource, such as an Event Hub, consumer group, or partition, could not be found by the Event Hubs service.  This may indicate that it has been deleted from the service or that there is an issue with the Event Hubs service itself.
  
Reacting to a specific failure reason for the `EventHubsException` can be accomplished in several ways, such as by applying an exception filter clause as part of the `catch` block:

```C# Snippet:EventHubs_ReadMe_ExceptionFilter
try
{
    // Read events using the consumer client
}
catch (EventHubsException ex) when
    (ex.Reason == EventHubsException.FailureReason.ConsumerDisconnected)
{
    // Take action based on a consumer being disconnected
}
```
  
#### Other exceptions

For detailed information about the failures represented by the `EventHubsException` and other exceptions that may occur, please refer to [Event Hubs messaging exceptions](https://docs.microsoft.com/azure/event-hubs/event-hubs-messaging-exceptions).

### Logging and diagnostics

The Event Hubs client library is fully instrumented for logging information at various levels of detail using the .NET `EventSource` to emit information.  Logging is performed for each operation and follows the pattern of marking the starting point of the operation, it's completion, and any exceptions encountered.  Additional information that may offer insight is also logged in the context of the associated operation.

The Event Hubs client logs are available to any `EventListener` by opting into the source named "Azure-Messaging-EventHubs" or opting into all sources that have the trait "AzureEventSource".  To make capturing logs from the Azure client libraries easier, the `Azure.Core` library used by Event Hubs offers an `AzureEventSourceListener`.  More information can be found in the [Azure.Core Diagnostics sample](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md#logging).

The Event Hubs client library is also instrumented for distributed tracing using Application Insights or OpenTelemetry.  More information can be found in the [Azure.Core Diagnostics sample](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md#distributed-tracing).

## Next steps

Beyond the introductory scenarios discussed, the Azure Event Hubs client library offers support for additional scenarios to help take advantage of the full feature set of the Azure Event Hubs service.  In order to help explore some of these scenarios, the Event Hubs client library offers a project of samples to serve as an illustration for common scenarios.  Please see the samples [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/README.md) for details.

## Contributing  

This project welcomes contributions and suggestions.  Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

Please see our [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/CONTRIBUTING.md) for more information.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs%2FREADME.png)
