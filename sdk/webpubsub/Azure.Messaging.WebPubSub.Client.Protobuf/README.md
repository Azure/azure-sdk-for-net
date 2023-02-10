# Azure Web PubSub protobuf protocol client library for .NET

[Web PubSub](https://aka.ms/awps/doc) is an Azure-managed service that helps developers easily build web applications with real-time features and publish-subscribe patterns. Any scenario that requires real-time publish-subscribe messaging between server and clients or among clients can use Web PubSub. Traditional real-time features that often require polling from the server or submitting HTTP requests can also use Web PubSub.

You can use this library to add protobuf subprotocols including `protobuf.reliable.webpubsub.azure.v1` and `protobuf.webpubsub.azure.v1` support to the Azure.Messaging.WebPubSub.Client library.

## Getting started

### Install the package

Install the client library from [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Messaging.WebPubSub.Client.Protobuf --prerelease
```

### Prerequisites

- An [Azure subscription][azure_sub].
- An existing Web PubSub instance. [Create Web PubSub instance](https://learn.microsoft.com/azure/azure-web-pubsub/howto-develop-create-instance)

### Authenticate the client

Not applicable for the library. You should work with `Azure.Messaging.WebPubSub.Client` library.

## Examples

### Specify protobuf subprotocol

You can specify the subprotocol to be used by the client. You can choose to use `protobuf.reliable.webpubsub.azure.v1` or `protobuf.webpubsub.azure.v1` after installing the library as shown below.

```C# Snippet:WebPubSubClient_JsonReliableProtocol
var client = new WebPubSubClient(new Uri("<client-access-uri>"), new WebPubSubClientOptions
{
    Protocol = new WebPubSubProtobufReliableProtocol()
});
```

```C# Snippet:WebPubSubClient_JsonProtocol
var client = new WebPubSubClient(new Uri("<client-access-uri>"), new WebPubSubClientOptions
{
    Protocol = new WebPubSubProtobufProtocol()
});
```

## Troubleshooting

### Setting up console logging

You can also [enable console logging](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#logging) if you want to dig deeper into the requests you're making against the service.

## Next steps

You can also find [more samples here][awps_sample].

## Contributing

This project welcomes contributions and suggestions.
Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution.
For details, visit <https://cla.microsoft.com.>

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment).
Simply follow the instructions provided by the bot.
You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftemplate%2FAzure.Template%2FREADME.png)

[azure_sub]: https://azure.microsoft.com/free/dotnet/
[awps_sample]: https://github.com/Azure/azure-webpubsub/tree/main/samples/csharp
