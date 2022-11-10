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
- An existing Azure Web PubSub service instance.

### Authenticate the client

In order to interact with the service, you'll need to create an instance of the `WebPubSubClient` class. To make this possible, you'll need the access token. You can copy and paste the access token from Azure portal which you can access in the Azure portal.

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

## Key concepts

### Connection

A connection, also known as a client or a client connection, represents an individual WebSocket connection connected to the Web PubSub service. When successfully connected, a unique connection ID is assigned to this connection by the Web PubSub service.

### Recovery

If using reliable protocols, a new websocket will try to connect and reuse the connection ID of previous dropped connection. If the websocket connection is successfully connected, the connection is recovered. And all group context will be restored and unreceived messages will be resent.

### Hub

A hub is a logical concept for a set of client connections. Usually you use one hub for one purpose, for example, a chat hub, or a notification hub. When a client connection is created, it connects to a hub, and during its lifetime, it belongs to that hub. Different applications can share one Azure Web PubSub service by using different hub names.

### Group

A group is a subset of connections to the hub. You can add a client connection to a group, or remove the client connection from the group, anytime you want. For example, when a client joins a chat room, or when a client leaves the chat room, this chat room can be considered to be a group. A client can join multiple groups, and a group can contain multiple clients.

### User

Connections to Web PubSub can belong to one user. A user might have multiple connections, for example when a single user is connected across multiple devices or multiple browser tabs.

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

### Handle Connected

The `Connected` event is called after the client receives connected message. The event will be triggered every reconnection.

```C# Snippet:WebPubSubClient_Subscribe_Connected
client.Connected += e =>
{
    Console.WriteLine($"Connection {e.ConnectionId} is connected");
    return Task.CompletedTask;
};
```

### Handle Disconnected

The `Disconnected` is triggered every time the connection closed and can't be recovered

```C# Snippet:WebPubSubClient_Subscribe_Disconnected
client.Disconnected += e =>
{
    Console.WriteLine($"Connection is disconnected");
    return Task.CompletedTask;
};
```

### Handle Stopped

The `Stopped` is triggered when the client is stopped. The client won't try to reconnect after stopped. Usually it happenes when you call `StopAsync`

```C# Snippet:WebPubSubClient_Subscribe_Stopped
client.Stopped += e =>
{
    Console.WriteLine($"Client is stopped");
    return Task.CompletedTask;
};
```

### Handle Server message

The `ServerMessageReceived` is triggered when there's a message from server.

```C# Snippet:WebPubSubClient_Subscribe_ServerMessage
client.ServerMessageReceived += e =>
{
    Console.WriteLine($"Receive message: {e.Message.Data}");
    return Task.CompletedTask;
};
```

### Handle Group message

The `GroupMessageReceived` is triggered when there's a message from groups. You must join the group before you can receive messages from it.

```C# Snippet:WebPubSubClient_Subscribe_GroupMessage
client.GroupMessageReceived += e =>
{
    Console.WriteLine($"Receive group message from {e.Message.Group}: {e.Message.Data}");
    return Task.CompletedTask;
};
```

### Handle restore failure

The `RestoreGroupFailed` is triggered when you enabled `AutoRestoreGroups` and operation of joining group failed after reconnection.

```C# Snippet:WebPubSubClient_Subscribe_RestoreFailed
client.RestoreGroupFailed += e =>
{
    Console.WriteLine($"Restore group failed");
    return Task.CompletedTask;
};
```

## Troubleshooting

### Setting up console logging

You can also easily [enable console logging](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#logging) if you want to dig deeper into the requests you're making against the service.

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
