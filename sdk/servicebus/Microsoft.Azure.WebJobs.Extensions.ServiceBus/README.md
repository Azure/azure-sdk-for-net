# Azure WebJobs Service Bus client library for .NET

This extension provides functionality for accessing Azure Service Bus from an Azure Function.

## Getting started

### Install the package

Install the Service Bus extension with [NuGet](https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.ServiceBus/):

```Powershell
dotnet add package Microsoft.Azure.WebJobs.Extensions.ServiceBus --version 5.0.0-beta.1
```

### Prerequisites

- **Azure Subscription:**  To use Azure services, including Azure Service Bus, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://account.windowsazure.com/Home/Index).

- **Service Bus namespace:** To interact with Azure Service Bus, you'll also need to have a namespace available. If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for creating a Service Bus namespace using the Azure portal. There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create a Service bus entity.

To quickly create the needed Service Bus resources in Azure and to receive a connection string for them, you can deploy our sample template by clicking:

[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-sdk-for-net%2Fmaster%2Fsdk%2Fservicebus%2FAzure.Messaging.ServiceBus%2Fassets%2Fsamples-azure-deploy.json)


### Authenticate the Client

For the Service Bus client library to interact with a queue or topic, it will need to understand how to connect and authorize with it.  The easiest means for doing so is to use a connection string, which is created automatically when creating a Service Bus namespace.  If you aren't familiar with shared access policies in Azure, you may wish to follow the step-by-step guide to [get a Service Bus connection string](https://docs.microsoft.com/azure/service-bus-messaging/service-bus-quickstart-topics-subscriptions-portal#get-the-connection-string).

The `Connection` property of `ServiceBusAttribute` and `ServiceBusTriggerAttribute` is used to specify the configuration property that stores the connection string. If not specified, the property `AzureWebJobsServiceBus` is expected to contain the connection string.

For local development, use the `local.settings.json` file to store the connection string:

```json
{
  "Values": {
    "<connection_name>": "Endpoint=sb://<service_bus_namespace>.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=<access key>"
  }
}
```

When deployed, use the [application settings](https://docs.microsoft.com/azure/azure-functions/functions-how-to-use-azure-function-app-settings) to set the connection string.

#### Managed identity authentication

If your environment has [managed identity](https://docs.microsoft.com/azure/app-service/overview-managed-identity?tabs=dotnet) enabled you can use it to authenticate the Service Bus extension.
To use managed identity provide the `<connection_name>__fullyQualifiedNamespace` configuration setting.

```json
{
  "Values": {
    "<connection_name>__fullyQualifiedNamespace": "<service_bus_namespace>.servicebus.windows.net"
  }
}
```

Or in the case of deployed app set the same setting in [application settings](https://docs.microsoft.com/azure/azure-functions/functions-how-to-use-azure-function-app-settings):

```
<connection_name>__fullyQualifiedNamespace=<service_bus_namespace>.servicebus.windows.net
```


## Key concepts

### Service Bus Trigger

The Service Bus Trigger allows a function to be executed when a message is sent to a Service Bus queue or topic.

Please follow the [Azure Service Bus trigger tutorial](https://docs.microsoft.com/azure/azure-functions/functions-bindings-service-bus-trigger?tabs=csharp) to learn more about Service Bus triggers.

### Service Bus Output Binding

The Service Bus Output Binding allows a function to send Service Bus messages.

Please follow the [Azure Service Bus output binding](https://docs.microsoft.com/azure/azure-functions/functions-bindings-service-bus-output?tabs=csharp) to learn more about Service Bus bindings.

## Examples

### Sending individual messages

You can send individual messages to a queue or topic by applying the `ServiceBus` attribute to the function return value. The return value can be of type `string`, `byte[]`, or `ServiceBusMessage`.
```C# Snippet:ServiceBusBindingToReturnValue
[FunctionName("BindingToReturnValue")]
[return: ServiceBus("<queue_or_topic_name>", Connection = "<connection_name>")]
public static string BindToReturnValue([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
{
    // This value would get stored in Service Bus message body.
    // The string would be UTF8 encoded.
    return $"C# Timer trigger function executed at: {DateTime.Now}";
}
```

You can also use an `out` parameter of type `string`, `byte[]`, or `ServiceBusMessage`.
```C# Snippet:ServiceBusBindingToOutputParameter
[FunctionName("BindingToOutputParameter")]
public static void Run(
[TimerTrigger("0 */5 * * * *")] TimerInfo myTimer,
[ServiceBus("<queue_or_topic_name>", Connection = "<connection_name>")] out ServiceBusMessage message)
{
    message = new ServiceBusMessage($"C# Timer trigger function executed at: {DateTime.Now}");
}
```

### Sending multiple messages

To send multiple messages from a single Azure Function invocation you can apply the `ServiceBus` attribute to the `IAsyncCollector<string>` or `IAsyncCollector<ServiceBusReceivedMessage>` parameter.
```C# Snippet:ServiceBusBindingToCollector
[FunctionName("BindingToCollector")]
public static async Task Run(
    [TimerTrigger("0 */5 * * * *")] TimerInfo myTimer,
    [ServiceBus("<queue_or_topic_name>", Connection = "<connection_name>")] IAsyncCollector<ServiceBusMessage> collector)
{
    // IAsyncCollector allows sending multiple messages in a single function invocation
    await collector.AddAsync(new ServiceBusMessage(new BinaryData($"Message 1 added at: {DateTime.Now}")));
    await collector.AddAsync(new ServiceBusMessage(new BinaryData($"Message 2 added at: {DateTime.Now}")));
}
```

### Using binding to strongly-typed models

To use strongly-typed model classes with the ServiceBus binding apply the `ServiceBus` attribute to the model parameter. Doing so will attempt to deserialize the `ServiceBusMessage.Body`into the strongly-typed model.
```C# Snippet:ServiceBusTriggerSingleModel
[FunctionName("TriggerSingleModel")]
public static void Run(
    [ServiceBusTrigger("<queue_name>", Connection = "<connection_name>")] Dog dog,
    ILogger logger)
{
    logger.LogInformation($"Who's a good dog? {dog.Name} is!");
}
```

### Sending multiple messages using ServiceBusSender

You can also bind to the `ServiceBusSender` directly to have the most control over message sending.
```C# Snippet:ServiceBusBindingToSender
[FunctionName("BindingToSender")]
public static async Task Run(
    [TimerTrigger("0 */5 * * * *")] TimerInfo myTimer,
    [ServiceBus("<queue_or_topic_name>", Connection = "<connection_name>")] ServiceBusSender sender)
{
    await sender.SendMessagesAsync(new[]
    {
        new ServiceBusMessage(new BinaryData($"Message 1 added at: {DateTime.Now}")),
        new ServiceBusMessage(new BinaryData($"Message 2 added at: {DateTime.Now}"))
    });
}
```

### Per-message triggers

To run a function every time a message is sent to a Service Bus queue or subscription apply the `ServiceBusTrigger` attribute to a `string`, `byte[]`, or `ServiceBusReceivedMessage` parameter.
```C# Snippet:ServiceBusTriggerSingle
[FunctionName("TriggerSingle")]
public static void Run(
    [ServiceBusTrigger("<queue_name>", Connection = "<connection_name>")] string messageBodyAsString,
    ILogger logger)
{
    logger.LogInformation($"C# function triggered to process a message: {messageBodyAsString}");
}
```

### Batch triggers

To run a function for a batch of received messages apply the `ServiceBusTrigger` attribute to a `string[]`, or `ServiceBusReceivedMessage[]` parameter.
```C# Snippet:ServiceBusTriggerBatch
[FunctionName("TriggerBatch")]
public static void Run(
    [ServiceBusTrigger("<queue_name>", Connection = "<connection_name>")] ServiceBusReceivedMessage[] messages,
    ILogger logger)
{
    foreach (ServiceBusReceivedMessage message in messages)
    {
        logger.LogInformation($"C# function triggered to process a message: {message.Body}");
        logger.LogInformation($"EnqueuedTime={message.EnqueuedTime}");
    }
}
```

### Message settlement

You can configure messages to be automatically completed after your function executes using the `ServiceBusOptions`. If you want more control over message settlement, you can bind to the `MessageActions` with both per-message and batch triggers.
```C# Snippet:ServiceBusBindingToMessageActions
[FunctionName("BindingToMessageActions")]
public static async Task Run(
    [ServiceBusTrigger("<queue_name>", Connection = "<connection_name>")]
    ServiceBusReceivedMessage[] messages,
    ServiceBusMessageActions messageActions)
{
    foreach (ServiceBusReceivedMessage message in messages)
    {
        if (message.MessageId == "1")
        {
            await messageActions.DeadLetterMessageAsync(message);
        }
        else
        {
            await messageActions.CompleteMessageAsync(message);
        }
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

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fservicebus%2FMicrosoft.Azure.WebJobs.Extensions.ServiceBus%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/servicebus/Microsoft.Azure.WebJobs.Extensions.ServiceBus/src
[package]: https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.ServiceBus/
[docs]: https://docs.microsoft.com/dotnet/api/Microsoft.Azure.WebJobs.Extensions.ServiceBus
[nuget]: https://www.nuget.org/

[contrib]: https://github.com/Azure/azure-sdk-for-net/tree/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
