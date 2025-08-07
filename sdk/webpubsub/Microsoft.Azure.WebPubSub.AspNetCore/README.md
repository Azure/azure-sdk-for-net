# Azure Web PubSub service middleware client library for .NET

[Azure Web PubSub Service](https://aka.ms/awps/doc) is a service that enables you to build real-time messaging web applications using WebSockets and the publish-subscribe pattern. Any platform supporting WebSocket APIs can connect to the service easily, e.g. web pages, mobile applications, edge devices, etc. The service manages the WebSocket connections for you and allows up to 100K **concurrent** connections. It provides powerful APIs for you to manage these clients and deliver real-time messages.

Any scenario that requires real-time publish-subscribe messaging between server and clients or among clients, can use Azure Web PubSub service. Traditional real-time features that often require polling from server or submitting HTTP requests, can also use Azure Web PubSub service.

This library can be used to do the following actions. Details about the terms used here are described in [Key concepts](#key-concepts) section.

- Parse upstream requests under CloudNative CloudEvents
- Add validation options for upstream request
- API to add user defined functionality to handle different upstream events

[Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Microsoft.Azure.WebPubSub.AspNetCore/src) |
[Package][package_ref] |
[API reference documentation](https://aka.ms/awps/sdk/csharp) |
[Product documentation](https://aka.ms/awps/doc) |
[Samples][sample_ref] |

## Getting started

### Install the package

Install the client library from [NuGet][package_ref]

```PowerShell
dotnet add package Microsoft.Azure.WebPubSub.AspNetCore
```

### Prerequisites

- An [Azure subscription][azure_sub].
- An existing Azure Web PubSub service instance.

### Authenticate the client

In order to interact with the service, you'll need to provide the Web PubSub service with a valid credential. To make this possible, you'll need the connection string or a key, which you can access in the Azure portal. Besides, if you want to invoke service REST API, you can call `AddWebPubSubServiceClient<THub>()` where `THub` is user implemented [`WebPubSubHub`](#webpubsubhub) listening to important events.

### Configure Web PubSub service options

Configure with connection string:
```C# Snippet:WebPubSubDependencyInjection
public void ConfigureServices(IServiceCollection services)
{
    services.AddWebPubSub(o =>
    {
        o.ServiceEndpoint = new("<connection-string>");
    }).AddWebPubSubServiceClient<SampleHub>();
}
```

Configure with [Azure Identity](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity):
```C# Snippet:WebPubSubDependencyInjectionWithAzureIdentity
public void ConfigureServices(IServiceCollection services)
{
    services.AddWebPubSub(o =>
    {
        o.ServiceEndpoint = new WebPubSubServiceEndpoint(new Uri("<endpoint"), new DefaultAzureCredential());
    }).AddWebPubSubServiceClient<SampleHub>();
}
```

### Map `WebPubSubHub` to endpoint routing

The name of the hub has to match the class name e.g. `SampleHub`.

```C# Snippet:WebPubSubMapHub
public void Configure(IApplicationBuilder app)
{
    app.UseEndpoints(endpoint =>
    {
        endpoint.MapWebPubSubHub<SampleHub>("/eventhandler");
    });
}
```

Hub name can be overriden by using extension method.

```C# Snippet:WebPubSubMapHubCustom
public void Configure(IApplicationBuilder app)
{
    app.UseEndpoints(endpoint =>
    {
        endpoint.MapWebPubSubHub<SampleHub>("/eventhandler", "customHub");
    });
}
```

## Key concepts

For information about general Web PubSub concepts [Concepts in Azure Web PubSub](https://learn.microsoft.com/azure/azure-web-pubsub/key-concepts)

### `WebPubSubHub`

`WebPubSubHub` is an abstract class to let users implement the subscribed Web PubSub service events. After user register the [event handler](https://learn.microsoft.com/azure/azure-web-pubsub/howto-develop-eventhandler) in service side, these events will be forwarded from service to server. And `WebPubSubHub` provides methods mapping to the service events to enable users deal with these events, for example, client management, validations or working with `Azure.Messaging.WebPubSub` to broadcast the messages. See samples below for details.

> NOTE
>
> Among the those methods, `OnConnectAsync()` and `OnMessageReceivedAsync()` are blocking events that service will respect server returns. Besides the mapped correct response, server can throw exceptions whenever the request is against the server side logic. And `UnauthorizedAccessException` and `AuthenticationException` will be converted to `401Unauthorized` and rest will be converted to `500InternalServerError` along with exception message to return service. Then service will drop current client connection.

## Examples

### Handle upstream `Connect` event

```C# Snippet:HandleConnectEvent
private sealed class SampleHub : WebPubSubHub
{
    internal WebPubSubServiceClient<SampleHub> _serviceClient;

    // Need to ensure service client is injected by call `AddServiceHub<SampleHub>` in ConfigureServices.
    public SampleHub(WebPubSubServiceClient<SampleHub> serviceClient)
    {
        _serviceClient = serviceClient;
    }

    public override ValueTask<ConnectEventResponse> OnConnectAsync(ConnectEventRequest request, CancellationToken cancellationToken)
    {
        var response = new ConnectEventResponse
        {
            UserId = request.ConnectionContext.UserId
        };
        return new ValueTask<ConnectEventResponse>(response);
    }
}
```

### Handle upstream MQTT `Connect` event
```C# Snippet:HandleMqttConnectEvent
private sealed class SampleHub2 : WebPubSubHub
{
    internal WebPubSubServiceClient<SampleHub> _serviceClient;

    // Need to ensure service client is injected by call `AddServiceHub<SampleHub2>` in ConfigureServices.
    public SampleHub2(WebPubSubServiceClient<SampleHub> serviceClient)
    {
        _serviceClient = serviceClient;
    }

    public override ValueTask<ConnectEventResponse> OnConnectAsync(ConnectEventRequest request, CancellationToken cancellationToken)
    {
        // By converting the request to MqttConnectEventRequest, you can get the MQTT specific information.
        if (request is MqttConnectEventRequest mqttRequest)
        {
            if (mqttRequest.Mqtt.Username != "baduser")
            {
                var response = mqttRequest.CreateMqttResponse(mqttRequest.ConnectionContext.UserId, null, null);
                // You can customize the user properties that will be sent to the client in the MQTT CONNACK packet.
                response.Mqtt.UserProperties = new List<MqttUserProperty>()
                {
                    new("name", "value")
                };
                return ValueTask.FromResult(response as ConnectEventResponse);
            }
            else
            {
                var errorResponse = mqttRequest.Mqtt.ProtocolVersion switch
                {
                    // You can specify the MQTT specific error code and message.
                    MqttProtocolVersion.V311 => mqttRequest.CreateMqttV311ErrorResponse(MqttV311ConnectReturnCode.NotAuthorized, "not authorized"),
                    MqttProtocolVersion.V500 => mqttRequest.CreateMqttV50ErrorResponse(MqttV500ConnectReasonCode.Banned, "The user is banned."),
                    _ => throw new System.NotSupportedException("Unsupported MQTT protocol version")
                };
                // You can customize the user properties that will be sent to the client in the MQTT CONNACK packet.
                errorResponse.Mqtt.UserProperties = new List<MqttUserProperty>()
                {
                    new("name", "value")
                };
                throw new MqttConnectionException(errorResponse);
            }
        }
        else
        {
            // If you don't need to handle MQTT specific logic, you can still return a general response for MQTT clients.
            return ValueTask.FromResult(request.CreateResponse(request.ConnectionContext.UserId, null, request.Subprotocols.FirstOrDefault(), null));
        }
    }
}
```

### Handle upstream MQTT `Connected` event
```C# Snippet:HandleMqttConnectedEvent
private sealed class SampleHub3 : WebPubSubHub
{
    internal WebPubSubServiceClient<SampleHub> _serviceClient;

    // Need to ensure service client is injected by call `AddServiceHub<SampleHub3>` in ConfigureServices.
    public SampleHub3(WebPubSubServiceClient<SampleHub> serviceClient)
    {
        _serviceClient = serviceClient;
    }

    public override Task OnConnectedAsync(ConnectedEventRequest request)
    {
        if (request.ConnectionContext is MqttConnectionContext mqttContext)
        {
            // Have your own logic here
        }
        return Task.CompletedTask;
    }
}
```


### Handle upstream MQTT `Disconnected` event
```C# Snippet:HandleMqttDisconnectedEvent
private sealed class SampleHub4 : WebPubSubHub
{
    internal WebPubSubServiceClient<SampleHub> _serviceClient;

    // Need to ensure service client is injected by call `AddServiceHub<SampleHub4>` in ConfigureServices.
    public SampleHub4(WebPubSubServiceClient<SampleHub> serviceClient)
    {
        _serviceClient = serviceClient;
    }

    public override Task OnDisconnectedAsync(DisconnectedEventRequest request)
    {
        if (request is MqttDisconnectedEventRequest mqttDisconnected)
        {
            // Have your own logic here
        }
        return Task.CompletedTask;
    }
}
```

## Troubleshooting

### Setting up console logging

You can also easily [enable console logging](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#logging) if you want to dig deeper into the requests you're making against the service.

## Next steps

Please take a look at the [Samples][sample_ref] directory for detailed examples on how to use this library.

## Contributing

This project welcomes contributions and suggestions.
Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution.
For details, visit <https://cla.microsoft.com.>

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment).
Simply follow the instructions provided by the bot.
You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

[azure_sub]: https://azure.microsoft.com/free/dotnet/
[sample_ref]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/webpubsub/Microsoft.Azure.WebPubSub.AspNetCore/tests/Samples/
[package_ref]: https://www.nuget.org/packages/Microsoft.Azure.WebPubSub.AspNetCore/