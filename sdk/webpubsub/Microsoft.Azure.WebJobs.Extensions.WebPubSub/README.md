# Azure WebJobs Web PubSub client library for .NET

This extension provides functionality for receiving Web PubSub webhook calls in Azure Functions, allowing you to easily write functions that respond to any event published to Web PubSub.

[Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Microsoft.Azure.WebJobs.Extensions.WebPubSub/src) |
[Package](https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.WebPubSub) |
[API reference documentation](https://learn.microsoft.com/dotnet/api/microsoft.azure.webjobs.extensions.webpubsub) |
[Product documentation](https://aka.ms/awps/doc) |
[Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/webpubsub/Microsoft.Azure.WebJobs.Extensions.WebPubSub/samples)

## Getting started

### Install the package

Install the Web PubSub extension with [NuGet][nuget]:

```dotnetcli
dotnet add package Microsoft.Azure.WebJobs.Extensions.WebPubSub
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and an Azure resource group with a Web PubSub resource. Follow this [step-by-step tutorial](https://learn.microsoft.com/azure/azure-web-pubsub/howto-develop-create-instance) to create an Azure Web PubSub instance.

### Authenticate the client

In order to let the extension work with Azure Web PubSub service, you will need to provide a valid `ConnectionString`.

You can find the **Keys** for you Azure Web PubSub service in the [Azure Portal](https://portal.azure.com/).

The `AzureWebJobsStorage` connection string is used to preserve the processing checkpoint information as required refer to [Storage considerations](https://learn.microsoft.com/azure/azure-functions/storage-considerations#storage-account-requirements)

For the local development use the `local.settings.json` file to store the connection string, `<connection-string>` can be set to `WebPubSubConnectionString` as default supported in the extension, or you can set customized names by mapping it with `Connection = <connection-string>` in function binding attributes:

```json
{
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "<connection-string>": "Endpoint=https://<webpubsub-name>.webpubsub.azure.com;AccessKey=<access-key>;Version=1.0;"
  }
}
```
When deployed use the [application settings](https://learn.microsoft.com/azure/azure-functions/functions-how-to-use-azure-function-app-settings) to set the connection string.

## Key concepts

### Using Web PubSub input binding

Please follow the [input binding tutorial](#functions-that-uses-web-pubsub-input-binding) to learn about using this extension for building `WebPubSubConnection` to create Websockets connection to service with input binding.

### Using Web PubSub output binding

Please follow the [output binding tutorial](#functions-that-uses-web-pubsub-output-binding) to learn about using this extension for publishing Web PubSub messages.

### Using Web PubSub trigger

Please follow the [trigger binding tutorial](#functions-that-uses-web-pubsub-trigger) to learn about triggering an Azure Function when an event is sent from service upstream.

In `Connect` and `UserEvent` events, function will respect return values to send back service. Then service will depend on the response to proceed the request or else. The responses and events are paired. For example, `Connect` will only respect `ConnectEventResponse` or `EventErrorResponse`, and ignore other returns. When `EventErrorResponse` is returned, service will drop client connection. Please follow the [trigger binding return value tutorial](#functions-that-uses-web-pubsub-trigger-return-value) to learn about using the trigger return value.

## Examples

### Functions that uses Web PubSub input binding

```C# Snippet:WebPubSubConnectionBindingFunction
public static class WebPubSubConnectionBindingFunction
{
    [FunctionName("WebPubSubConnectionBindingFunction")]
    public static WebPubSubConnection Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req,
        [WebPubSubConnection(Hub = "hub", UserId = "{query.userid}", Connection = "<connection-string>")] WebPubSubConnection connection)
    {
        Console.WriteLine("login");
        return connection;
    }
}
```

### Functions that uses Web PubSub output binding

```C# Snippet:WebPubSubOutputBindingFunction
public static class WebPubSubOutputBindingFunction
{
    [FunctionName("WebPubSubOutputBindingFunction")]
    public static async Task RunAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req,
        [WebPubSub(Hub = "hub", Connection = "<connection-string>")] IAsyncCollector<WebPubSubAction> action)
    {
        await action.AddAsync(WebPubSubAction.CreateSendToAllAction("Hello Web PubSub!", WebPubSubDataType.Text));
    }
}
```

### Functions that uses Web PubSub trigger

```C# Snippet:WebPubSubTriggerFunction
[FunctionName("WebPubSubTriggerFunction")]
public static void Run(
    ILogger logger,
    [WebPubSubTrigger("hub", WebPubSubEventType.User, "message")] UserEventRequest request,
    string data,
    WebPubSubDataType dataType)
{
    logger.LogInformation("Request from: {user}, data: {data}, dataType: {dataType}",
        request.ConnectionContext.UserId, data, dataType);
}
```

### Functions that uses Web PubSub trigger return value

```C# Snippet:WebPubSubTriggerReturnValueFunction
public static class WebPubSubTriggerReturnValueFunction
{
    [FunctionName("WebPubSubTriggerReturnValueFunction")]
    public static UserEventResponse Run(
        [WebPubSubTrigger("hub", WebPubSubEventType.User, "message")] UserEventRequest request)
    {
        return request.CreateResponse(BinaryData.FromString("ack"), WebPubSubDataType.Text);
    }
}
```

### Functions that handles MQTT Client "connect" event
```C# Snippet:MqttConnectEventTriggerFunction
[FunctionName("mqttConnect")]
public static WebPubSubEventResponse Run(
        [WebPubSubTrigger("hub", WebPubSubEventType.System, "connect", ClientProtocols = WebPubSubTriggerAcceptedClientProtocols.Mqtt)] MqttConnectEventRequest request,
        ILogger log)
{
    if (request.ConnectionContext.ConnectionId != "attacker")
    {
        return request.CreateMqttResponse(request.ConnectionContext.UserId, Array.Empty<string>(), new string[] { "webpubsub.joinLeaveGroup.group1", "webpubsub.sendToGroup.group2" });
    }
    else
    {
        if (request.Mqtt.ProtocolVersion == MqttProtocolVersion.V311)
        {
            return request.CreateMqttV311ErrorResponse(MqttV311ConnectReturnCode.NotAuthorized);
        }
        else
        {
            return request.CreateMqttV50ErrorResponse(MqttV500ConnectReasonCode.NotAuthorized);
        }
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
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/search/Microsoft.Azure.WebJobs.Extensions.WebPubSub/src
[package]: https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.WebPubSub/
[docs]: https://learn.microsoft.com/dotnet/api/Microsoft.Azure.WebJobs.Extensions.WebPubSub
[nuget]: https://www.nuget.org/

[contrib]: https://github.com/Azure/azure-sdk-for-net/tree/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
