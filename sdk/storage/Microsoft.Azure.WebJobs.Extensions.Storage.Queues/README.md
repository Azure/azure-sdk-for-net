# Azure WebJobs Storage Queues client library for .NET

This extension provides functionality for accessing Azure Storage Queues in Azure Functions.

## Getting started

### Install the package

Install the Storage Queues extension with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.WebJobs.Extensions.Storage.Queues
```

### Prerequisites

You need an [Azure subscription][azure_sub] and a
[Storage Account][storage_account_docs] to use this package.

To create a new Storage Account, you can use the [Azure Portal][storage_account_create_portal],
[Azure PowerShell][storage_account_create_ps], or the [Azure CLI][storage_account_create_cli].
Here's an example using the Azure CLI:

```Powershell
az storage account create --name <your-resource-name> --resource-group <your-resource-group-name> --location westus --sku Standard_LRS
```

### Authenticate the client

In order for the extension to access Queues, you will need the connection string which can be found in the [Azure Portal](https://portal.azure.com/) or by using the [Azure CLI](https://learn.microsoft.com/cli/azure) snippet below.

```bash
az storage account show-connection-string -g <your-resource-group-name> -n <your-resource-name>
```

The connection string can be supplied through [AzureWebJobsStorage app setting](https://learn.microsoft.com/azure/azure-functions/functions-app-settings).

## Key concepts

### Using Queue trigger

The queue storage trigger runs a function as messages are added to Azure Queue storage.

Please follow the [tutorial](https://learn.microsoft.com/azure/azure-functions/functions-bindings-storage-queue-trigger?tabs=csharp) to learn about how to listen to queues in Azure Functions.

### Using Queue binding

Azure Functions can create new Azure Queue storage messages by setting up an output binding.

Please follow the [binding tutorial](https://learn.microsoft.com/azure/azure-functions/functions-bindings-storage-queue-output?tabs=csharp) to learn about using this extension for producing messages into queues in Azure Functions.

## Examples

### Listening to queue

The following set of examples shows how to receive and react to messages that are being added to the queue.

#### Binding queue message to string

```C# Snippet:QueueTriggerFunction_String
public static class QueueTriggerFunction_String
{
    [FunctionName("QueueTriggerFunction")]
    public static void Run(
        [QueueTrigger("sample-queue")] string message,
        ILogger logger)
    {
        logger.LogInformation("Received message from sample-queue, content={content}", message);
    }
}
```

#### Binding queue message to BinaryData

```C# Snippet:QueueTriggerFunction_BinaryData
public static class QueueTriggerFunction_BinaryData
{
    [FunctionName("QueueTriggerFunction")]
    public static void Run(
        [QueueTrigger("sample-queue")] BinaryData message,
        ILogger logger)
    {
        logger.LogInformation("Received message from sample-queue, content={content}", message.ToString());
    }
}
```

#### Binding queue message to QueueMessage

```C# Snippet:QueueTriggerFunction_QueueMessage
public static class QueueTriggerFunction_QueueMessage
{
    [FunctionName("QueueTriggerFunction")]
    public static void Run(
        [QueueTrigger("sample-queue")] QueueMessage message,
        ILogger logger)
    {
        logger.LogInformation("Received message from sample-queue, content={content}", message.Body.ToString());
    }
}
```

#### Binding queue message to custom type

```C# Snippet:QueueTriggerFunction_CustomObject
public static class QueueTriggerFunction_CustomObject
{
    public class CustomMessage
    {
        public string Content { get; set; }
    }

    [FunctionName("QueueTriggerFunction")]
    public static void Run(
        [QueueTrigger("sample-queue")] CustomMessage message,
        ILogger logger)
    {
        logger.LogInformation("Received message from sample-queue, content={content}", message.Content);
    }
}
```

#### Binding queue message to JObject

```C# Snippet:QueueTriggerFunction_JObject
public static class QueueTriggerFunction_JObject
{
    [FunctionName("QueueTriggerFunction")]
    public static void Run(
        [QueueTrigger("sample-queue")] JObject message,
        ILogger logger)
    {
        logger.LogInformation("Received message from sample-queue, content={content}", message["content"]);
    }
}
```

### Publishing messages to queue

The following set of examples shows how to add messages to queue by using `Queue` attribute.

The `QueueTrigger` is used just for sample completeness, i.e. any other trigger mechanism can be used instead.

#### Publishing message as string

```C# Snippet:QueueSenderFunction_String_Return
public static class QueueSenderFunction_String_Return
{
    [FunctionName("QueueFunction")]
    [return: Queue("sample-queue-2")]
    public static string Run(
        [QueueTrigger("sample-queue-1")] string message,
        ILogger logger)
    {
        logger.LogInformation("Received message from sample-queue-1, content={content}", message);
        logger.LogInformation("Dispatching message to sample-queue-2");
        return message;
    }
}
```

#### Publishing message as BinaryData

```C# Snippet:QueueSenderFunction_BinaryData_Return
public static class QueueSenderFunction_BinaryData_Return
{
    [FunctionName("QueueFunction")]
    [return: Queue("sample-queue-2")]
    public static BinaryData Run(
        [QueueTrigger("sample-queue-1")] BinaryData message,
        ILogger logger)
    {
        logger.LogInformation("Received message from sample-queue-1, content={content}", message.ToString());
        logger.LogInformation("Dispatching message to sample-queue-2");
        return message;
    }
}
```

#### Publishing message as QueueMessage

```C# Snippet:QueueSenderFunction_QueueMessage_Return
public static class QueueSenderFunction_QueueMessage_Return
{
    [FunctionName("QueueFunction")]
    [return: Queue("sample-queue-2")]
    public static QueueMessage Run(
        [QueueTrigger("sample-queue-1")] QueueMessage message,
        ILogger logger)
    {
        logger.LogInformation("Received message from sample-queue-1, content={content}", message.Body.ToString());
        logger.LogInformation("Dispatching message to sample-queue-2");
        return message;
    }
}
```

#### Publishing message as custom type through out parameter

```C# Snippet:QueueSenderFunction_CustomObject_OutParamter
public static class QueueSenderFunction_CustomObject_OutParamter
{
    public class CustomMessage
    {
        public string Content { get; set; }
    }

    [FunctionName("QueueFunction")]
    public static void Run(
        [QueueTrigger("sample-queue-1")] CustomMessage incomingMessage,
        [Queue("sample-queue-2")] out CustomMessage outgoingMessage,
        ILogger logger)
    {
        logger.LogInformation("Received message from sample-queue-1, content={content}", incomingMessage.Content);
        logger.LogInformation("Dispatching message to sample-queue-2");
        outgoingMessage = incomingMessage;
    }
}
```

#### Publishing message as custom type through collector

```C# Snippet:QueueSenderFunction_CustomObject_Collector
public static class QueueSenderFunction_CustomObject_Collector
{
    public class CustomMessage
    {
        public string Content { get; set; }
    }

    [FunctionName("QueueFunction")]
    public static void Run(
        [QueueTrigger("sample-queue-1")] CustomMessage incomingMessage,
        [Queue("sample-queue-2")] ICollector<CustomMessage> collector,
        ILogger logger)
    {
        logger.LogInformation("Received message from sample-queue-1, content={content}", incomingMessage.Content);
        logger.LogInformation("Dispatching message to sample-queue-2");
        collector.Add(incomingMessage);
    }
}
```

### Accessing queue properties

```C# Snippet:Function_BindingToQueueClient
public static class Function_BindingToQueueClient
{
    [FunctionName("QueueFunction")]
    public static async Task Run(
        [QueueTrigger("sample-queue")] string message,
        [Queue("sample-queue")] QueueClient queueClient,
        ILogger logger)
    {
        logger.LogInformation("Received message from sample-queue, content={content}", message);
        QueueProperties queueProperties = await queueClient.GetPropertiesAsync();
        logger.LogInformation("There are approximatelly {count} messages", queueProperties.ApproximateMessagesCount);
    }
}
```

### Configuring the extension

Please refer to [sample functions app](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Queues/samples/functionapp).

## Troubleshooting

Please refer to [Monitor Azure Functions](https://learn.microsoft.com/azure/azure-functions/functions-monitoring) for troubleshooting guidance.

## Next steps

Read the [introduction to Azure Function](https://learn.microsoft.com/azure/azure-functions/functions-overview) or [creating an Azure Function guide](https://learn.microsoft.com/azure/azure-functions/functions-create-first-azure-function).

## Contributing

See the [Storage CONTRIBUTING.md][storage_contrib] for details on building,
testing, and contributing to this library.

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

<!-- LINKS -->
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://learn.microsoft.com/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src/RequestFailedException.cs
[storage_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
