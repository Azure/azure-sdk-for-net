# Azure WebJobs Event Hubs client library for .NET

This extension provides functionality for accessing Azure Event Hubs from an Azure Function.

## Getting started

### Install the package

Install the Event Hubs extension with [NuGet](https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.EventHubs):

```Powershell
dotnet add package Microsoft.Azure.WebJobs.Extensions.EventHubs --version 5.0.0-beta.1
```

### Prerequisites

- **Azure Subscription:**  To use Azure services, including Azure Event Hubs, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://account.windowsazure.com/Home/Index).

- **Event Hubs namespace with an Event Hub:** To interact with Azure Event Hubs, you'll also need to have a namespace and Event Hub available.  If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [creating an Event Hub using the Azure portal](https://docs.microsoft.com/azure/event-hubs/event-hubs-create).  There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create an Event Hub.

- **Azure Storage account with blob storage:** To persist checkpoints as blobs in Azure Storage, you'll need to have an Azure Storage account with blobs available.  If you are not familiar with Azure Storage accounts, you may wish to follow the step-by-step guide for [creating a storage account using the Azure portal](https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?toc=%2Fazure%2Fstorage%2Fblobs%2Ftoc.json&tabs=azure-portal).  There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create storage accounts.

[![Deploy button](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-sdk-for-net%2Fmaster%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs.Processor%2Fassets%2Fsamples-azure-deploy.json)

### Authenticate the Client

For the Event Hubs client library to interact with an Event Hub, it will need to understand how to connect and authorize with it.  The easiest means for doing so is to use a connection string, which is created automatically when creating an Event Hubs namespace.  If you aren't familiar with using connection strings with Event Hubs, you may wish to follow the step-by-step guide to [get an Event Hubs connection string](https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string).

The `Connection` property of `EventHubAttribute` and `EventHubTriggerAttribute` is used to specify the configuration property that stores the connection string.

The `AzureWebJobsStorage` connection string is used to preserve the processing checkpoint information.

For the local development use the `local.settings.json` file to store the connection string:

```json
{
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "<connection_name>": "Endpoint=sb://<event_hub_name>.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Jya7Eh76HU92ibsxuk1ITN8CM8Bt76YLKf5ISjU3jZ8="
  }
}
```

When deployed use the [application settings](https://docs.microsoft.com/azure/azure-functions/functions-how-to-use-azure-function-app-settings) to set the connection string.

#### Managed identity authentication

If your environment has [managed identity](https://docs.microsoft.com/azure/app-service/overview-managed-identity?tabs=dotnet) enabled you can use it to authenticate the Event Hubs extension.
To use managed identity provide the `<connection_name>__fullyQualifiedNamespace` configuration setting.

```json
{
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "<connection_name>__fullyQualifiedNamespace": "<event_hub_name>.servicebus.windows.net"
  }
}
```

Or in the case of deployed app set the same setting in [application settings](https://docs.microsoft.com/azure/azure-functions/functions-how-to-use-azure-function-app-settings):

```
<connection_name>__fullyQualifiedNamespace=<event_hub_name>.servicebus.windows.net
```

## Key concepts

### Event Hub Trigger

The Event Hub Trigger allows a function to be executed when a message is sent to an Event Hub.

Please follow the [Azure Event Hubs trigger tutorial](https://docs.microsoft.com/azure/azure-functions/functions-bindings-event-hubs-trigger?tabs=csharp) to learn more about Event Hub triggers.

### Event Hub Output Binding

The Event Hub Output Binding allows a function to send Event Hub events.

Please follow the [Azure Event Hubs output binding](https://docs.microsoft.com/azure/azure-functions/functions-bindings-event-hubs-output?tabs=csharp) to learn more about Event Hub bindings.

## Examples

### Sending individual event

You can send individual events to an Event Hub by applying the `EventHubAttribute` the function return value. The return value can be of `string` or `EventData` type.

```C# Snippet:BindingToReturnValue
[FunctionName("BindingToReturnValue")]
[return: EventHub("<event_hub_name>", Connection = "<connection_name>")]
public static string Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
{
    // This value would get stored in EventHub event body.
    // The string would be UTF8 encoded
    return $"C# Timer trigger function executed at: {DateTime.Now}";
}
```

### Sending multiple events

To send multiple events from a single Azure Function invocation you can apply the `EventHubAttribute` to the `IAsyncCollector<string>` or `IAsyncCollector<EventData>` parameter.


```C# Snippet:BindingToCollector
[FunctionName("BindingToCollector")]
public static async Task Run(
    [TimerTrigger("0 */5 * * * *")] TimerInfo myTimer,
    [EventHub("<event_hub_name>", Connection = "<connection_name>")] IAsyncCollector<EventData> collector)
{
    // IAsyncCollector allows sending multiple events in a single function invocation
    await collector.AddAsync(new EventData(new BinaryData($"Event 1 added at: {DateTime.Now}")));
    await collector.AddAsync(new EventData(new BinaryData($"Event 2 added at: {DateTime.Now}")));
}
```

### Per-event triggers

To run a function every time an event is sent to Event Hub apply the `EventHubTriggerAttribute` to a `string` or `EventData` parameter.

```C# Snippet:TriggerSingle
[FunctionName("TriggerSingle")]
public static void Run(
    [EventHubTrigger("<event_hub_name>", Connection = "<connection_name>")] string eventBodyAsString,
    ILogger logger)
{
    logger.LogInformation($"C# function triggered to process a message: {eventBodyAsString}");
}
```

### Batch triggers

To run a function for a batch of received events apply the `EventHubTriggerAttribute` to a `string[]` or `EventData[]` parameter.

```C# Snippet:TriggerBatch
[FunctionName("TriggerBatch")]
public static void Run(
    [EventHubTrigger("<event_hub_name>", Connection = "<connection_name>")] EventData[] events,
    ILogger logger)
{
    foreach (var e in events)
    {
        logger.LogInformation($"C# function triggered to process a message: {e.EventBody}");
        logger.LogInformation($"EnqueuedTime={e.EnqueuedTime}");
    }
}
```

## Troubleshooting

Please refer to [Monitor Azure Functions](https://docs.microsoft.com/azure/azure-functions/functions-monitoring) for troubleshooting guidance.

## Next steps

Read the [introduction to Azure Functions](https://docs.microsoft.com/azure/azure-functions/functions-overview) or [creating an Azure Function guide](https://docs.microsoft.com/azure/azure-functions/functions-create-first-azure-function).

## Contributing

See our [CONTRIBUTING.md][contrib] for details on building,
testing, and contributing to this library.

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fsearch%2FMicrosoft.Azure.WebJobs.Extensions.EventHubs%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/search/Microsoft.Azure.WebJobs.Extensions.EventHubs/src
[package]: https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.EventHubs/
[docs]: https://docs.microsoft.com/dotnet/api/Microsoft.Azure.WebJobs.Extensions.EventHubs
[nuget]: https://www.nuget.org/

[contrib]: https://github.com/Azure/azure-sdk-for-net/tree/master/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
