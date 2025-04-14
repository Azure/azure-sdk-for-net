# Azure WebJobs Web PubSub for Socket.IO client library for .NET

This extension provides functionality for receiving Web PubSub for Socket.IO webhook calls in Azure Functions, allowing you to easily write functions that respond to any event published to Web PubSub for Socket.IO in serverless mode.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/webpubsub/Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO/src) |
[Package](https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO) |
[API reference documentation](https://learn.microsoft.com/dotnet/api/microsoft.azure.webjobs.extensions.webpubsubforsocketio) |
[Product documentation](https://learn.microsoft.com/azure/azure-web-pubsub/socketio-overview) |
[Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/webpubsub/Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO/samples)

## Getting started

### Install the package

Install the Web PubSub for Socket.IO extension with [NuGet][nuget]:

```dotnetcli
dotnet add package Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and an Azure resource group with a Web PubSub for Socket.IO resource. Follow this [Quickstart](https://learn.microsoft.com/azure/azure-web-pubsub/socketio-quickstart#create-a-web-pubsub-for-socketio-resource) to create an Web PubSub for Socket.IO instance.

### Authenticate the client

In order to let the extension work with Web PubSub for Socket.IO, you will need to provide either access keys or identity based configuration to authenticate with the service.

#### Access key based configuration

The `AzureWebJobsStorage` connection string is used to preserve the processing checkpoint information as required refer to [Storage considerations](https://learn.microsoft.com/azure/azure-functions/storage-considerations#storage-account-requirements)

You can find the **Keys** for you Azure Web PubSub service in the [Azure Portal](https://portal.azure.com/).

For the local development, use the `local.settings.json` file to store the connection string. Set `WebPubSubForSocketIOConnectionString` to the connection string copied from the previous step:

```json
{
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "WebPubSubForSocketIOConnectionString": "Endpoint=https://<webpubsub-name>.webpubsub.azure.com;AccessKey=<access-key>;Version=1.0;"
  }
}
```

When deployed use the [application settings](https://learn.microsoft.com/azure/azure-functions/functions-how-to-use-azure-function-app-settings) to set the connection string.

#### Identity based configuration

For the local development, use the `local.settings.json` file to store the connection string. Set `WebPubSubForSocketIOConnectionString` to the connection string copied from the previous step:

```json
{
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "WebPubSubForSocketIOConnectionString__endpoint": "https://<webpubsub-name>.webpubsub.azure.com",
    "WebPubSubForSocketIOConnectionString__tenant": "<tenant id you're in>",
  }
}
```

For using online, the `AzureWebJobsStorage` should refer to [Connecting to host storage with an identity](https://learn.microsoft.com/azure/azure-functions/functions-reference?tabs=blob&pivots=programming-language-csharp#connecting-to-host-storage-with-an-identity)

## Key concepts

### Using SocketIO input binding

Please follow the [input binding tutorial](#functions-that-uses-socketio-input-binding) to learn about using this extension for building `SocketIONegotiationResult` to create Socket.IO client connection negotiation result.

### Using SocketIO output binding

Please follow the [output binding tutorial](#functions-that-uses-socketio-output-binding) to learn about using this extension for publishing Socket.IO messages.

### Using SocketIO trigger

Please follow the [trigger binding tutorial](#functions-that-uses-socketio-trigger) to learn about triggering an Azure Function when an event is sent from service.

For `connect` and all user defined events, function will return values send back service. Then service will depend on the response to proceed the request or else. The responses and events are paired. For example, `Connect` will only respect `SocketIOConnectResponse`, and ignore other returns. If the status code is not a success code, the service will reject this socket. And user defined events response is only useful when client is requesting an event and wait for the acknowledgement. Please follow the [trigger binding return value tutorial](#functions-that-uses-socketio-trigger-return-value-as-acknowledgement) to learn about using the trigger return value.

## Examples

### Functions that uses SocketIO input binding

```C# Snippet:SocketIOBindingFunction
public static class SocketIOBindingFunction
{
    [FunctionName("SocketIOInputBinding")]
    public static IActionResult SocketInputBinding(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req,
        [SocketIONegotiation(Hub = "hub", UserId = "uid")] SocketIONegotiationResult result)
    {
        return new OkObjectResult(result);
    }
}
```

### Functions that uses SocketIO output binding

```C# Snippet:SocketIOOutputBindingFunction
public static class SocketIOOutputBindingFunction
{
    [FunctionName("SocketIOOutputBinding")]
    public static async Task<IActionResult> OutboundBinding(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
        [SocketIO(Hub = "hub")] IAsyncCollector<SocketIOAction> operation,
        ILogger log)
    {
        string userName = Guid.NewGuid().ToString();
        await operation.AddAsync(SocketIOAction.CreateSendToNamespaceAction("new message", new[] { new { username = userName, message = "Hello" } }));
        log.LogInformation("Send to namespace finished.");
        return new OkObjectResult("ok");
    }
}
```

### Functions that uses SocketIO trigger

```C# Snippet:SocketIOTriggerFunction
public static class SocketIOTriggerFunction
{
    [FunctionName("TriggerBindingForConnect")]
    public static SocketIOEventHandlerResponse TriggerBindingForConnect(
        [SocketIOTrigger("hub", "connect")] SocketIOConnectRequest request,
        ILogger log)
    {
        log.LogInformation("Running trigger for: connect");
        return new SocketIOConnectResponse();
    }

    [FunctionName("TriggerBindingForConnected")]
    public static void TriggerBindingForConnected(
        [SocketIOTrigger("hub", "connected")] SocketIOConnectedRequest request,
        [SocketIO(Hub = "hub")] IAsyncCollector<SocketIOAction> collector,
        ILogger log)
    {
        log.LogInformation("Running trigger for: connected");
    }

    [FunctionName("TriggerBindingForDisconnected")]
    public static void TriggerBindingForDisconnected(
        [SocketIOTrigger("hub", "disconnected")] SocketIODisconnectedRequest request,
        [SocketIO(Hub = "hub")] IAsyncCollector<SocketIOAction> collector,
        ILogger log)
    {
        log.LogInformation("Running trigger for: disconnected");
    }

    [FunctionName("TriggerBindingForNewMessage")]
    public static async Task TriggerBindingForNewMessage(
        [SocketIOTrigger("hub", "new message")] SocketIOMessageRequest request,
        [SocketIO(Hub = "hub")] IAsyncCollector<SocketIOAction> collector,
        ILogger log)
    {
        log.LogInformation("Running trigger for: new message");
        await collector.AddAsync(SocketIOAction.CreateSendToNamespaceAction("new message", new[] { new { message = request.Parameters } }, new[] { request.SocketId }));
    }
}
```

### Functions that uses SocketIO trigger return value as Acknowledgement

```C# Snippet:SocketIOTriggerReturnValueFunction
public static class SocketIOTriggerReturnValueFunction
{
    [FunctionName("TriggerBindingForNewMessageAndAck")]
    public static async Task<SocketIOMessageResponse> TriggerBindingForNewMessageAndAck(
        [SocketIOTrigger("hub", "new message")] SocketIOMessageRequest request,
        [SocketIO(Hub = "hub")] IAsyncCollector<SocketIOAction> collector,
        ILogger log)
    {
        log.LogInformation("Running trigger for: new message");
        await collector.AddAsync(SocketIOAction.CreateSendToNamespaceAction("new message", new[] { new { message = request.Parameters } }, new[] { request.SocketId }));
        return new SocketIOMessageResponse(new[] {"ackValue"});
    }
}
```

## Troubleshooting

Please refer to [Monitor Azure Functions](https://learn.microsoft.com/azure/azure-functions/functions-monitoring) for troubleshooting guidance.

## Next steps

Read the [introduction to Azure Function](https://learn.microsoft.com/azure/azure-functions/functions-overview) or [creating an Azure Function guide](https://learn.microsoft.com/azure/azure-functions/functions-create-first-azure-function).

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

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/search/Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO/src
[package]: https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO/
[docs]: https://learn.microsoft.com/dotnet/api/Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
[nuget]: https://www.nuget.org/

[contrib]: https://github.com/Azure/azure-sdk-for-net/tree/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
