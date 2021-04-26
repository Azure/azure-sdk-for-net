# Azure WebJobs Web PubSub client library for .NET

This extension provides functionality for receiving Web PubSub webhook calls in Azure Functions, allowing you to easily write functions that respond to any event published to Web PubSub.

## Getting started

### Install the package

Install the Web PubSub extension with [NuGet][nuget]:

```Powershell
dotnet add package Microsoft.Azure.WebJobs.Extensions.WebPubSub
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/) and an Azure resource group with a Web PubSub resource. Follow this [step-by-step tutorial](https://review.docs.microsoft.com/azure/azure-web-pubsub/howto-develop-create-instance?branch=release-azure-web-pubsub) to create an Azure Web PubSub instance.

## Key concepts

### Using Web PubSub input binding

Please follow the [input binding tutorial](https://azure.github.io/azure-webpubsub/references/functions-bindings#input-binding) to learn about using this extension for building `WebPubSubConnection` to create Websockets connection to service with input binding.

### Using Web PubSub output binding

Please follow the [output binding tutorial](https://azure.github.io/azure-webpubsub/references/functions-bindings#output-binding) to learn about using this extension for publishing Web PubSub messages.

### Using Web PubSub trigger

Please follow the [trigger binding tutorial](https://azure.github.io/azure-webpubsub/references/functions-bindings#trigger-binding) to learn about triggering an Azure Function when an event is sent from service upstream.

## Examples

### Functions that uses Web PubSub input binding

```C# Snippet:WebPubSubInputBindingFunction
[FunctionName("WebPubSubInputBindingFunction")]
public static WebPubSubConnection Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req,
    [WebPubSubConnection(Hub = "simplechat", UserId = "{query.userid}")] WebPubSubConnection connection)
{
    Console.WriteLine("login");
    return connection;
}
```

### Functions that uses Web PubSub output binding

```c# Snippet:WebPubSubOutputBindingFunction
[FunctionName("WebPubSubOutputBindingFunction")]
public static async Task RunAsync(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req,
    [WebPubSub(Hub = "simplechat")] IAsyncCollector<WebPubSubOperation> operation)
{
    await operation.AddAsync(new SendToAll
    {
        Message = BinaryData.FromString("Hello Web PubSub"),
        DataType = MessageDataType.Text
    });
}
```

### Functions that uses Web PubSub trigger

```C# Snippet:WebPubSubTriggerFunction
[FunctionName("WebPubSubTriggerFunction")]
public static async Task<MessageResponse> RunAsync(
    [WebPubSubTrigger("message", WebPubSubEventType.User)] 
    ConnectionContext context,
    string message,
    MessageDataType dataType)
{
    Console.WriteLine($"Request from: {context.userId}");
    Console.WriteLine($"Request message: {message}");
    Console.WriteLine($"Request message DataType: {dataType}");
    return new MessageResponse
    {
        Message = BinaryData.FromString("ack"),
    };
}
```

## Troubleshooting

Please refer to [Monitor Azure Functions](https://docs.microsoft.com/azure/azure-functions/functions-monitoring) for troubleshooting guidance.

## Next steps

Read the [introduction to Azure Function](https://docs.microsoft.com/azure/azure-functions/functions-overview) or [creating an Azure Function guide](https://docs.microsoft.com/azure/azure-functions/functions-create-first-azure-function).

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

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fsearch%2FMicrosoft.Azure.WebJobs.Extensions.WebPubSub%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/search/Microsoft.Azure.WebJobs.Extensions.WebPubSub/src
[package]: https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.WebPubSub/
[docs]: https://docs.microsoft.com/dotnet/api/Microsoft.Azure.WebJobs.Extensions.WebPubSub
[nuget]: https://www.nuget.org/

[contrib]: https://github.com/Azure/azure-sdk-for-net/tree/master/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
