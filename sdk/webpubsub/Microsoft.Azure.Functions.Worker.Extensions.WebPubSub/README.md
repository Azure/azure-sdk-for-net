# Azure Web PubSub extension of isolated-process Azure Functions client library for .NET

This extension defines the binding types and triggers in the .NET isolated worker process for Azure Functions, allowing you to write functions that respond to any event published to Web PubSub.

[Source code][source] |
Package |
API reference documentation |
[Product documentation](https://aka.ms/awps/doc) |
[Samples]

## Getting started

### Install the package

Install the client library from [NuGet]:

```dotnetcli
dotnet add package Microsoft.Azure.Functions.Worker.Extensions.WebPubSub
```

### Prerequisites

You must have an [Azure subscription][free_subs] and an Azure resource group with a Web PubSub resource. Follow this [step-by-step tutorial][tutorial] to create an Azure Web PubSub instance.

### Authenticate the client

In order to let the extension work with Azure Web PubSub service, you will need to provide a valid `ConnectionString`.

You can find the **Keys** for you Azure Web PubSub service in the [Azure Portal][portal].

The `AzureWebJobsStorage` connection string is used to preserve the processing checkpoint information as required refer to [Storage considerations][storage]

For the local development use the `local.settings.json` file to store the connection string, `<connection-string>` can be set to `WebPubSubConnectionString` as default supported in the extension, or you can set customized names by mapping it with `Connection = <connection-string>` in function binding attributes:

```json
{
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "<connection-string>": "Endpoint=https://<webpubsub-name>.webpubsub.azure.com;AccessKey=<access-key>;Version=1.0;"
  }
}
```
When deployed use the [application settings][app_setting] to set the connection string.

## Key concepts

### Using Web PubSub input binding

Please follow the [input binding tutorial](#functions-that-uses-web-pubsub-input-binding) to learn about using this extension for building `WebPubSubConnection` to create Websockets connection to service with input binding.

### Using Web PubSub output binding

Please follow the [output binding tutorial](#functions-that-uses-web-pubsub-output-binding) to learn about using this extension for publishing Web PubSub messages.

### Using Web PubSub trigger

Please follow the [trigger binding tutorial](#functions-that-uses-web-pubsub-trigger) to learn about triggering an Azure Function when an event is sent from service upstream.

In `Connect` and `UserEvent` events, function will respect return values to send back service. Then service will depend on the response to proceed the request or else. The responses and events are paired. For example, `Connect` will only respect `ConnectEventResponse` or `EventErrorResponse`, and ignore other returns. When `EventErrorResponse` is returned, service will drop client connection.

## Examples

### Functions that uses Web PubSub input binding

Use `WebPubSubConnectionInput` to build the client negotiate URL.

```C# Snippet:WebPubSubConnectionInputFunction
[Function("Negotiate")]
public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequestData req,
[WebPubSubConnectionInput(Hub = "<web_pubsub_hub>", Connection = "<web_pubsub_connection_name>")] WebPubSubConnection connectionInfo)
{
    var response = req.CreateResponse(HttpStatusCode.OK);
    response.WriteAsJsonAsync(connectionInfo);
    return response;
}
```

Use `WebPubSubContextInput` to read Web PubSub request under `HttpTrigger`. This is useful when work with Static Web Apps which supports `HttpTrigger` functions only.

```C# Snippet:WebPubSubContextInputFunction
// validate method when upstream set as http://<func-host>/api/{event}
[Function("validate")]
public static HttpResponseData Validate(
    [HttpTrigger(AuthorizationLevel.Anonymous, "options")] HttpRequestData req,
    [WebPubSubContextInput] WebPubSubContext wpsReq)
{
    return BuildHttpResponseData(req, wpsReq.Response);
}

// Respond AbuseProtection to put header correctly.
private static HttpResponseData BuildHttpResponseData(HttpRequestData request, SimpleResponse wpsResponse)
{
    var response = request.CreateResponse();
    response.StatusCode = (HttpStatusCode)wpsResponse.Status;
    response.Body = response.Body;
    foreach (var header in wpsResponse.Headers)
    {
        response.Headers.Add(header.Key, header.Value);
    }
    return response;
}
```

### Functions that uses Web PubSub output binding

```C# Snippet:WebPubSubOutputFunction
[Function("Notification")]
[WebPubSubOutput(Hub = "<web_pubsub_hub>", Connection = "<web_pubsub_connection_name>")]
public static WebPubSubAction Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
{
    return new SendToAllAction
    {
        Data = BinaryData.FromString($"Hello SendToAll."),
        DataType = WebPubSubDataType.Text
    };
}
```

### Functions that uses Web PubSub trigger

```C# Snippet:WebPubSubTriggerUserEventFunction
[Function("Broadcast")]
public static UserEventResponse Run(
[WebPubSubTrigger("<web_pubsub_hub>", WebPubSubEventType.User, "message")] UserEventRequest request)
{
    return new UserEventResponse("[SYSTEM ACK] Received.");
}
```

For more details see the [samples README][samples].

## Troubleshooting

Please refer to [Monitor Azure Functions][monitor] for troubleshooting guidance.

## Next steps

Read the [introduction to Azure Function][func_intro] or [creating an Azure Function guide][create].

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
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/webpubsub/Microsoft.Azure.Functions.Worker.Extensions.WebPubSub/src
<!-- [package] TODO: add after initial release -->
<!-- [api_docs] TODO: add after initial release -->
[samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/webpubsub/Microsoft.Azure.Functions.Worker.Extensions.WebPubSub/samples
[nuget]: https://www.nuget.org/
[free_subs]: https://azure.microsoft.com/free/dotnet/
[portal]: https://portal.azure.com/
[tutorial]: https://learn.microsoft.com/azure/azure-web-pubsub/howto-develop-create-instance
[storage]: https://learn.microsoft.com/azure/azure-functions/storage-considerations#storage-account-requirements
[app_setting]: https://learn.microsoft.com/azure/azure-functions/functions-how-to-use-azure-function-app-settings
[monitor]: https://learn.microsoft.com/azure/azure-functions/functions-monitoring
[func_intro]: https://learn.microsoft.com/azure/azure-functions/functions-overview
[create]: https://learn.microsoft.com/azure/azure-functions/functions-overview

[contrib]: https://github.com/Azure/azure-sdk-for-net/tree/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
