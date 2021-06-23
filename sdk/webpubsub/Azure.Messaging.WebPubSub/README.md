# Azure Web PubSub service client library for .NET

[Azure Web PubSub Service](https://aka.ms/awps/doc) is a service that enables you to build real-time messaging web applications using WebSockets and the publish-subscribe pattern. Any platform supporting WebSocket APIs can connect to the service easily, e.g. web pages, mobile applications, edge devices, etc. The service manages the WebSocket connections for you and allows up to 100K **concurrent** connections. It provides powerful APIs for you to manage these clients and deliver real-time messages.

Any scenario that requires real-time publish-subscribe messaging between server and clients or among clients, can use Azure Web PubSub service. Traditional real-time features that often require polling from server or submitting HTTP requests, can also use Azure Web PubSub service.

This library can be used to do the following actions. Details about the terms used here are described in [Key concepts](#key-concepts) section.

- Send messages to hubs and groups. 
- Send messages to particular users and connections.
- Organize users and connections into groups.
- Close connections
- Grant, revoke, and check permissions for an existing connection

[Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub/src) |
[Package](https://www.nuget.org/packages/Azure.Messaging.WebPubSub) |
[API reference documentation](https://aka.ms/awps/sdk/csharp) |
[Product documentation](https://aka.ms/awps/doc) |
[Samples][samples_ref]

## Getting started

### Install the package

Install the client library from [NuGet](https://www.nuget.org/):

```PowerShell
dotnet add package Azure.Messaging.WebPubSub --prerelease
```

### Prerequisites

- An [Azure subscription][azure_sub].
- An existing Azure Web PubSub service instance.

### Authenticate the client

In order to interact with the service, you'll need to create an instance of the WebPubSubServiceClient class. To make this possible, you'll need the connection string or a key, which you can access in the Azure portal.

### Create a `WebPubSubServiceClient`

```C# Snippet:WebPubSubAuthenticate
var serviceClient = new WebPubSubServiceClient(new Uri(endpoint), "some_hub", new AzureKeyCredential(key));
```

## Key concepts

### Connection

Connections, represented by a connection id, represent an individual websocket connection to the Web PubSub service. Connection id is always unique.

### Hub

Hub is a logical concept for a set of connections. Connections are always connected to a specific hub. Messages that are broadcast to the hub are dispatched to all connections to that hub. Hub can be used for different applications, different applications can share one Azure Web PubSub service by using different hub names.

### Group

Group allow broadcast messages to a subset of connections to the hub. You can add and remove users and connections as needed. A client can join multiple groups, and a group can contain multiple clients.

### User

Connections to Web PubSub can belong to one user. A user might have multiple connections, for example when a single user is connected across multiple devices or multiple browser tabs.

### Message

Using this library, you can send messages to the client connections. A message can either be string text, JSON or binary payload.

## Examples

### Broadcast a text message to all clients

```C# Snippet:WebPubSubHelloWorld
var serviceClient = new WebPubSubServiceClient(new Uri(endpoint), "some_hub", new AzureKeyCredential(key));

serviceClient.SendToAll("Hello World!");
```

### Broadcast a JSON message to all clients

```C# Snippet:WebPubSubSendJson
var serviceClient = new WebPubSubServiceClient(new Uri(endpoint), "some_hub", new AzureKeyCredential(key));

serviceClient.SendToAll("application/json",
    RequestContent.Create(
        new
        {
            Foo = "Hello World!",
            Bar = 42
        }));
```

### Broadcast a binary message to all clients

```C# Snippet:WebPubSubSendBinary
var serviceClient = new WebPubSubServiceClient(new Uri(endpoint), "some_hub", new AzureKeyCredential(key));

Stream stream = BinaryData.FromString("Hello World!").ToStream();
serviceClient.SendToAll("application/octet-stream", RequestContent.Create(stream));
```

## Troubleshooting

### Setting up console logging
You can also easily [enable console logging](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#logging) if you want to dig deeper into the requests you're making against the service.

## Next steps

Please take a look at the
[samples][samples_ref]
directory for detailed examples on how to use this library.

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

[azure_sub]: https://azure.microsoft.com/free/
[samples_ref]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub/tests/Samples/
