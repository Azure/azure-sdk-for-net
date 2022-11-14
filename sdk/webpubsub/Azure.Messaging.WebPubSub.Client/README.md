# Azure Web PubSub client library for .NET

[Azure Web PubSub Service](https://aka.ms/awps/doc) is an Azure-managed service that helps developers easily build web applications with real-time features and publish-subscribe pattern. Any scenario that requires real-time publish-subscribe messaging between server and clients or among clients can use Azure Web PubSub service. Traditional real-time features that often require polling from server or submitting HTTP requests can also use Azure Web PubSub service.

You can use this library in your client side to manage the WebSocket client connections, as shown in below diagram:

![overflow](https://user-images.githubusercontent.com/668244/140014067-25a00959-04dc-47e8-ac25-6957bd0a71ce.png)

Use this library to:

- Send messages to groups
- Send event to event handlers
- Join and leave groups
- Listen messages from groups and servers

Details about the terms used here are described in [Key concepts](#key-concepts) section.

[Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub.Client/src) |
[API reference documentation](https://aka.ms/awps/sdk/csharp) |
[Product documentation](https://aka.ms/awps/doc) |

## Getting started

### Install the package

Install the client library from [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Messaging.WebPubSub.Client
```

### Prerequisites

- An [Azure subscription][azure_sub].
- An existing Azure Web PubSub service instance. [Create Azure Web PubSub service instance](https://learn.microsoft.com/azure/azure-web-pubsub/howto-develop-create-instance)

### Authenticate the client

In order to interact with the service, you'll need to create an instance of the `WebPubSubClient` class. To make this possible, you'll need an access token. You can copy and paste an access token from Azure portal.

```C# Snippet:WebPubSubClient_Construct
var client = new WebPubSubClient(new Uri("<client-access-uri>"));
```

And in production, you usually get `ClientAccessUri` from a negotiate server.

```C# Snippet:WebPubSubClient_Construct2
var client = new WebPubSubClient(new WebPubSubClientCredential(token =>
{
    // In common practice, you will have a negotiation server for generating token. Client should fetch token from it.
    return FetchClientAccessTokenFromServerAsync(token);
}));
```

The `FetchClientAccessTokenFromServerAsync` usually fetch the token from server via Http request. And in the server side, you can use `WebPubSubServiceClient` to generate token and response to the fetch request.

```C# Snippet:WebPubSubClient_GenerateClientAccessUri
var serviceClient = new WebPubSubServiceClient("<< Connection String >>", "hub");
return await serviceClient.GetClientAccessUriAsync();
```

## Key concepts

### Connection

A connection, also known as a client connection, represents an individual WebSocket connection connected to the Web PubSub service. When successfully connected, the Web PubSub service assigns the connection a unique connection ID. Each `WebPubSubClient` creates its own exclusive connection.

### Recovery

If using reliable protocols, a new WebSocket will try to reconnect using the connection ID of the lost connection. If the WebSocket connection is successfully connected, the connection is recovered. And all group contexts will be recovered, and unreceived messages will be resent.

### Hub

A hub is a logical concept representing a collection of client connections. Usually, you use one hub for one purpose: for example, a chat hub, or a notification hub. When a client connection is created, it connects to a hub and, and during its lifetime, it is bound to that hub. Different applications can share one Azure Web PubSub service by using different hub names.

### Group

A group is a subset of connections to the hub. You can add and remove connections from a group at any time. For example, a chat room can be considered a group.  When clients join and leave the room, they are added and removed from the group. A connection can belong to multiple groups, and a group can contain multiple connections.

### User

Connections to Web PubSub can belong to one user. A user might have multiple connections, for example when a single user is connected across multiple devices or browser tabs.

### Message

When a client is connected, it can send messages to the upstream application, or receive messages from the upstream application, through the WebSocket connection. Also, it can send messages to groups and receive message from joined groups.

## Examples

### Send to groups

```C# Snippet:WebPubSubClient_SendToGroup
// Send message to group "testGroup"
await client.SendToGroupAsync("testGroup", BinaryData.FromString("hello world"), WebPubSubDataType.Text);
```

### Send events to event handler

```C# Snippet:WebPubSubClient_SendEvent
// Send custom event to server
await client.SendEventAsync("testEvent", BinaryData.FromString("hello world"), WebPubSubDataType.Text);
```

### Handle the Connected event

The `Connected` event is called after the client receives connected message. The event will be triggered every reconnection.

```C# Snippet:WebPubSubClient_Subscribe_Connected
client.Connected += eventArgs =>
{
    Console.WriteLine($"Connection {eventArgs.ConnectionId} is connected");
    return Task.CompletedTask;
};
```

### Handle the Disconnected event

The `Disconnected` event is triggered every time the connection closed and could not be recovered

```C# Snippet:WebPubSubClient_Subscribe_Disconnected
client.Disconnected += eventArgs =>
{
    Console.WriteLine($"Connection is disconnected");
    return Task.CompletedTask;
};
```

### Handle the Stopped event

The `Stopped` event is triggered when the client is stopped. The client won't try to reconnect after being stopped. This event is typically the result of calling `StopAsync` or disabling the `AutoReconnect`

```C# Snippet:WebPubSubClient_Subscribe_Stopped
client.Stopped += eventArgs =>
{
    Console.WriteLine($"Client is stopped");
    return Task.CompletedTask;
};
```

### Handle the Server message event

The `ServerMessageReceived` event is triggered when there's a message from server.

```C# Snippet:WebPubSubClient_Subscribe_ServerMessage
client.ServerMessageReceived += eventArgs =>
{
    Console.WriteLine($"Receive message: {eventArgs.Message.Data}");
    return Task.CompletedTask;
};
```

### Handle the Group message event

The `GroupMessageReceived` event is triggered when there's a message from a group. You must join a group before you can receive messages from it.

```C# Snippet:WebPubSubClient_Subscribe_GroupMessage
client.GroupMessageReceived += eventArgs =>
{
    Console.WriteLine($"Receive group message from {eventArgs.Message.Group}: {eventArgs.Message.Data}");
    return Task.CompletedTask;
};
```

### Handle the restore failure event

The `RestoreGroupFailed` event is triggered when the `AutoRejoinGroups` is enabled and rejoining a group fails after reconnection.

```C# Snippet:WebPubSubClient_Subscribe_RestoreFailed
client.RejoinGroupFailed += eventArgs =>
{
    Console.WriteLine($"Restore group failed");
    return Task.CompletedTask;
};
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
