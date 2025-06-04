# Azure Web PubSub Event Handler events data model client library for .NET

This library defines the class to process with Azure Web PubSub service upstream requests.

## Getting started

### Install the package

Install the client library from [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Microsoft.Azure.WebPubSub.Common
```

### Prerequisites

- An [Azure subscription][azure_sub].
- An existing Azure Web PubSub service instance.

### Authenticate the client

Not applicable for the library. You should work with a client library to deserialize service requests in a friendly way.

## Key concepts

### Events

Connect, Connected, Disconnected are system events indicate connection stage. And Connect is a blocking event that service will wait for the response to determine next action. Any error returned will drop the connection.

User events are message event. It's also a blocking event which service is waiting for response. And server can return information in the response which will be sent to the caller directly.

### WebPubSubEventRequest

WebPubSubEventRequest, represents a abstract request come from service side. In detail, it should be ValidationRequest or one of the 4 events, which are ConnectEventRequest, ConnectedEventRequest, UserEventRequest and DisconnectedEventRequest. ValidationRequest represent the request for [Abuse Protection](https://github.com/cloudevents/spec/blob/v1.0.1/http-webhook.md#4-abuse-protection).

### WebPubSubEventResponse

WebPubSubEventResponse, represents a abstract response should return to service. In detail, it should be EventErrorResponse or one of the 2 blocking events, which are ConnectEventResponse and UserEventResponse.

## Examples

Check Microsoft.Azure.WebPubSub.AspNetCore for E2E using examples.

## Troubleshooting

You can also easily [enable console logging](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#logging) if you want to dig deeper into the requests you're making against the service.

## Next steps

Please take a look at the
[samples][samples_ref]
directory for detailed examples on how to use this library.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact opencode@microsoft.com with any additional questions or comments.

[azure_sub]: https://azure.microsoft.com/free/dotnet/
[samples_ref]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub/tests/Samples/