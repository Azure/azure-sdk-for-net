# Azure Event Hubs Event Processor client library for .NET

Azure Event Hubs is a highly scalable publish-subscribe service that can ingest millions of events per second and stream them to multiple consumers. This lets you process and analyze the massive amounts of data produced by your connected devices and applications. Once Event Hubs has collected the data, you can retrieve, transform, and store it by using any real-time analytics provider or with batching/storage adapters.  If you would like to know more about Azure Event Hubs, you may wish to review: [What is Event Hubs](https://docs.microsoft.com/azure/event-hubs/event-hubs-about).

The Event Processor client library is a companion to the Azure Event Hubs client library, providing a stand-alone client for consuming events in a robust, durable, and scalable way that is suitable for the majority of production scenarios.  An opinionated implementation built using Azure Storage blobs, the Event Processor is recommended for:

- Reading and processing events across all partitions of an Event Hub at scale with resilience to transient failures and intermittent network issues.

- Processing events cooperatively, where multiple processors dynamically distribute and share the responsibility in the context of a consumer group, gracefully managing the load as processors are added and removed from the group.

- Managing checkpoints and state for processing in a durable manner using Azure Storage blobs as the underlying data store.

[Source code](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor/) | [API reference documentation](https://docs.microsoft.com/dotnet/api/azure.messaging.eventhubs?view=azure-dotnet) | [Product documentation](https://docs.microsoft.com/azure/event-hubs/)

## Getting started

### Prerequisites

- **Azure Subscription:**  To use Azure services, including Azure Event Hubs, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://account.windowsazure.com/Home/Index).

- **Event Hubs namespace with an Event Hub:** To interact with Azure Event Hubs, you'll also need to have a namespace and Event Hub available.  If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [creating an Event Hub using the Azure portal](https://docs.microsoft.com/azure/event-hubs/event-hubs-create).  There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create an Event Hub.

- **Azure Storage account with blob storage:** To persist checkpoints as blobs in Azure Storage, you'll need to have an Azure Storage account with blobs available.  If you are not familiar with Azure Storage accounts, you may wish to follow the step-by-step guide for [creating a storage account using the Azure portal](https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?toc=%2Fazure%2Fstorage%2Fblobs%2Ftoc.json&tabs=azure-portal).  There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create storage accounts.

- **C# 8.0:** The Azure Event Hubs client library makes use of new features that were introduced in C# 8.0.  In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 3.0 or higher with a [language version](https://docs.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.  It is also possible to compile with the .NET Core SDK 2.1.x using a language version of `preview`.   

  Visual Studio users wishing to take full advantage of the C# 8.0 syntax will need to use Visual Studio 2019 or later.  Visual Studio 2019, including the free Community edition, can be downloaded [here](https://visualstudio.microsoft.com).  Users of Visual Studio 2017 can take advantage of the C# 8 syntax by making use of the [Microsoft.Net.Compilers NuGet package](https://www.nuget.org/packages/Microsoft.Net.Compilers/) and setting the language version, though the editing experience may not be ideal.

  You can still use the library with previous C# language versions, but will need to manage asynchronous enumerable and asynchronous disposable members manually rather than benefiting from the new syntax.  You may still target any framework version supported by your .NET Core SDK, including earlier versions of .NET Core or the .NET framework.  For more information, see: [how to specify target frameworks](https://docs.microsoft.com/dotnet/standard/frameworks#how-to-specify-target-frameworks).  
  
  **Important Note:** In order to build or run the [examples](#examples) and the [samples](#next-steps) without modification, use of C# 8.0 is mandatory.  You can still run the samples if you decide to tweak them for other language versions.

To quickly create the needed resources in Azure and to receive connection strings for them, you can deploy our sample template by clicking:  

[![](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-sdk-for-net%2Fmaster%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs.Processor%2Fassets%2Fsamples-azure-deploy.json)

### Install the package

Install the Azure Event Hubs Event Processor client library for .NET using [NuGet](https://www.nuget.org/):

```PowerShell
dotnet add package Azure.Messaging.EventHubs.Processor
```

### Authenticate the client

#### Obtain an Event Hubs connection string

For the Event Hubs client library to interact with an Event Hub, it will need to understand how to connect and authorize with it.  The easiest means for doing so is to use a connection string, which is created automatically when creating an Event Hubs namespace.  If you aren't familiar with using connection strings with Event Hubs, you may wish to follow the step-by-step guide to [get an Event Hubs connection string](https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string).

#### Obtain an Azure Storage connection string

For the event processor client to make use of Azure Storage blobs for checkpointing, it will need to understand how to connect to a storage account and authorize with it.  The most straightforward method of doing so is to use a connection string, which is generated at the time that the storage account is created.  If you aren't familiar with storage account connection string authorization in Azure, you may wish to follow the step-by-step guide to [configure Azure Storage connection strings](https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string).

## Key concepts

- An **event processor** is a construct intended to manage the responsibilities associated with connecting to a given Event Hub and processing events from each of its partitions, in the context of a specific consumer group.  The act of processing events read from the partition and handling any errors that occur is delegated by the event processor to code that you provide, allowing your logic to concentrate on delivering business value while the processor handles the tasks associated with reading events, managing the partitions, and allowing state to be persisted in the form of checkpoints. 

- **Checkpointing** is a process by which readers mark and persist their position for events that have been processed for a partition. Checkpointing is the responsibility of the consumer and occurs on a per-partition, typically in the context of a specific consumer group.  For the `EventProcessorClient`, this means that, for a consumer group and partition combination, the processor must keep track of its current position in the event stream.  If you would like more information, please refer to [checkpointing ](https://docs.microsoft.com/azure/event-hubs/event-hubs-features#checkpointing) in the Event Hubs product documentation.

  When an event processor connects, it will begin reading events at the checkpoint that was previously persisted by the last processor of that partition in that consumer group, if one exists.  As an event processor reads and acts on events in the partition, it should periodically create checkpoints to both mark the events as "complete" by downstream applications and to provide resiliency should an event processor or the environment hosting it fail.  Should it be necessary, it is possible to reprocess events that were previously marked as "complete" by specifying an earlier offset through this checkpointing process.

- A **partition** is an ordered sequence of events that is held in an Event Hub. Partitions are a means of data organization associated with the parallelism required by event consumers.  Azure Event Hubs provides message streaming through a partitioned consumer pattern in which each consumer only reads a specific subset, or partition, of the message stream. As newer events arrive, they are added to the end of this sequence. The number of partitions is specified at the time an Event Hub is created and cannot be changed.

- A **consumer group** is a view of an entire Event Hub. Consumer groups enable multiple consuming applications to each have a separate view of the event stream, and to read the stream independently at their own pace and from their own position.  There can be at most 5 concurrent readers on a partition per consumer group; however it is recommended that there is only one active consumer for a given partition and consumer group pairing. Each active reader receives all of the events from its partition; if there are multiple readers on the same partition, then they will receive duplicate events.

For more concepts and deeper discussion, see: [Event Hubs Features](https://docs.microsoft.com/azure/event-hubs/event-hubs-features).

## Examples

### Creating an Event Processor client

Since the `EventProcessorClient` has a dependency on Azure Storage blobs for persistence of its state, you'll need to provide a `BlobContainerClient` for the processor, which has been configured for the storage account and container that should be used.

```C# Snippet:EventHubs_Processor_ReadMe_Create
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

BlobContainerClient storageClient = new BlobContainerClient(storageConnectionString, blobContainerName);

EventProcessorClient processor = new EventProcessorClient
(
    storageClient,
    consumerGroup,
    eventHubsConnectionString,
    eventHubName
);
```

### Configure the event and error handlers

In order to use the `EventProcessorClient`, handlers for event processing and errors must be provided.  These handlers are considered self-contained and developers are responsible for ensuring that exceptions within the handler code are accounted for.

```C# Snippet:EventHubs_Processor_ReadMe_ConfigureHandlers
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

async Task processEventHandler(ProcessEventArgs eventArgs)
{
    try
    {
        // Perform the application-specific processing for an event.  This method
        // is intended for illustration and is not defined in this snippet.
        await DoSomethingWithTheEvent(eventArgs.Partition, eventArgs.Data);
    }
    catch
    {
        // Handle the exception from handler code
    }
}

async Task processErrorHandler(ProcessErrorEventArgs eventArgs)
{
    try
    {
        // Perform the application-specific processing for an error.  This method
        // is intended for illustration and is not defined in this snippet.
        await DoSomethingWithTheError(eventArgs.Exception);
    }
    catch
    {
        // Handle the exception from handler code
    }
}

var storageClient = new BlobContainerClient(storageConnectionString, blobContainerName);
var processor = new EventProcessorClient(storageClient, consumerGroup, eventHubsConnectionString, eventHubName);

processor.ProcessEventAsync += processEventHandler;
processor.ProcessErrorAsync += processErrorHandler;
```

### Start and stop processing

The `EventProcessorClient` will perform its processing in the background once it has been explicitly started and continue doing so until it has been explicitly stopped.  While this allows the application code to perform other tasks, it also places the responsibility of ensuring that the process does not terminate during processing if there are no other tasks being performed.

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

### Using an Active Directory principal with the Event Processor client

The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md) provides Azure Active Directory authentication support which can be used for the Azure client libraries, including Event Hubs and Azure Storage.

To make use of an Active Directory principal, one of the available credentials from the `Azure.Identity` library is specified when creating the Event Hubs client.  In addition, the fully qualified Event Hubs namespace and the name of desired Event Hub are supplied in lieu of the Event Hubs connection string.

To make use of an Active Directory principal with Azure Storage blob containers, the fully qualified URL to the container must be provided when creating the storage client.  Details about the valid URI formats for accessing Blob storage may be found in [Naming and Referencing Containers, Blobs, and Metadata](https://docs.microsoft.com/rest/api/storageservices/Naming-and-Referencing-Containers--Blobs--and-Metadata#resource-uri-syntax).  

```C# Snippet:EventHubs_Processor_ReadMe_CreateWithIdentity
TokenCredential credential = new DefaultAzureCredential();

string blobStorageUrl ="<< FULLY-QUALIFIED CONTAINER URL (like https://myaccount.blob.core.windows.net/mycontainer) >>";
BlobContainerClient storageClient = new BlobContainerClient(new Uri(blobStorageUrl), credential);

var fullyQualifiedNamespace = "<< FULLY-QUALIFIED EVENT HUBS NAMESPACE (like something.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

EventProcessorClient processor = new EventProcessorClient
(
    storageClient,
    consumerGroup,
    fullyQualifiedNamespace,
    eventHubName,
    credential
);
```

When using Azure Active Directory with Event Hubs, your principal must be assigned a role which allows reading from Event Hubs, such as the `Azure Event Hubs Data Receiver` role. For more information about using Azure Active Directory authorization with Event Hubs, please refer to [the associated documentation](https://docs.microsoft.com/azure/event-hubs/authorize-access-azure-active-directory).

When using Azure Active Directory with Azure Storage, your principal must be assigned a role which allows read, write, and delete access to blobs, such as the `Storage Blob Data Contributor` role.  For more information about using Active Directory Authorization with Azure Storage, please refer to the [the associated documentation](https://docs.microsoft.com/azure/storage/common/storage-auth-aad) and the [Azure Storage authorization sample](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Blobs/samples/Sample02_Auth.cs).

## Troubleshooting

### Exception handling

#### Event Processor client exceptions

The Event Processor client makes every attempt to be resilient in the face of exceptions and will take the necessary actions to continue processing unless it is impossible to do so.  No action from developers is needed for this to take place; it is natively part of the processor's behavior.

In order to allow developers the opportunity to inspect and react to exceptions that occur within the Event Processor client operations, they are surfaced via the `ProcessError` event.  The arguments for this event offer details about the exception and the context in which it was observed.  Developers may perform normal operations on the Event Processor client from within this event handler, such as stopping and/or restarting it in response to errors, but may not otherwise influence the processor's exception behavior.  

For a basic example of implementing the error handler, please see the sample: [Event Processor Handlers](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample03_EventProcessorHandlers.md#process-error).

#### Exceptions in event handlers

Because the Event Processor client lacks the appropriate context to understand the severity of exceptions within the event handlers that developers provide, it cannot assume what actions would be a reasonable response to them.  As a result, developers are considered responsible for exceptions that occur within the event handlers they provide using `try/catch` blocks and other standard language constructs.  

The Event Processor client will not attempt to detect exceptions in developer code nor surface them explicitly.  The resulting behavior will depend on the processor's hosting environment and the context in which the event handler was called.  Because this may vary between different scenarios, it is strongly recommended that developers code their event handlers defensively and account for potential exceptions.

#### Exception details

For detailed information about exceptions that may occur, please refer to the Event Hubs client library [README]( https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/README.md#event-hubs-exception) and the service documentation for [Event Hubs messaging exceptions](https://docs.microsoft.com/azure/event-hubs/event-hubs-messaging-exceptions). 

### Logging and diagnostics

The Event Processor client library is fully instrumented for logging information at various levels of detail using the .NET `EventSource` to emit information.  Logging is performed for each operation and follows the pattern of marking the starting point of the operation, it's completion, and any exceptions encountered.  Additional information that may offer insight is also logged in the context of the associated operation.

The Event Processor client logs are available to any `EventListener` by opting into the source named "Azure-Messaging-EventHubs-Processor-EventProcessorClient" or opting into all sources that have the trait "AzureEventSource".  To make capturing logs from the Azure client libraries easier, the `Azure.Core` library used by Event Hubs offers an `AzureEventSourceListener`.  More information can be found in the [Azure.Core Diagnostics sample](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md#logging).

The Event Processor library is also instrumented for distributed tracing using Application Insights or OpenTelemetry.  More information can be found in the [Azure.Core Diagnostics sample](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md#distributed-tracing).

## Next steps

Beyond the scenarios discussed, the Azure Event Hubs Processor library offers support for additional scenarios to help take advantage of the full feature set of the `EventProcessorClient`.  In order to help explore some of these scenarios, the Event Hubs Processor client library offers a project of samples to serve as an illustration for common scenarios.  Please see the samples [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/README.md) for details.

## Contributing  

This project welcomes contributions and suggestions.  Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

Please see our [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/CONTRIBUTING.md) for more information.
  
![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs.Processor%2FREADME.png)
