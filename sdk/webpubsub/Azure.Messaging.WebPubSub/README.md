# Azure Web PubSub service client library for .NET

[Azure Web PubSub Service](https://aka.ms/awps/doc) is an Azure-managed service that helps developers easily build web applications with real-time features and publish-subscribe pattern. Any scenario that requires real-time publish-subscribe messaging between server and clients or among clients can use Azure Web PubSub service. Traditional real-time features that often require polling from server or submitting HTTP requests can also use Azure Web PubSub service.

You can use this library in your app server side to manage the WebSocket client connections, as shown in below diagram:

![overflow](https://user-images.githubusercontent.com/668244/140014067-25a00959-04dc-47e8-ac25-6957bd0a71ce.png)

Use this library to:

- Send messages to hubs and groups.
- Send messages to particular users and connections.
- Organize users and connections into groups.
- Close connections
- Grant, revoke, and check permissions for an existing connection

Details about the terms used here are described in [Key concepts](#key-concepts) section.

[Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub/src) |
[Package](https://www.nuget.org/packages/Azure.Messaging.WebPubSub) |
[API reference documentation](https://aka.ms/awps/sdk/csharp) |
[Product documentation](https://aka.ms/awps/doc) |
[Samples][samples_ref]

## Getting started

### Install the package

Install the client library from [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Messaging.WebPubSub
```

### Prerequisites

- An [Azure subscription][azure_sub].
- An existing Azure Web PubSub service instance.

### Create and authenticate a `WebPubSubServiceClient`

In order to interact with the service, you'll need to create an instance of the `WebPubSubServiceClient` class. To make this possible, you'll need the connection string or a key, which you can access in the Azure portal.

```C# Snippet:WebPubSubAuthenticate
// Create a WebPubSubServiceClient that will authenticate using a key credential.
var serviceClient = new WebPubSubServiceClient(new Uri(endpoint), "some_hub", new AzureKeyCredential(key));
```

## Key concepts

### Connection

A connection, also known as a client or a client connection, represents an individual WebSocket connection connected to the Web PubSub service. When successfully connected, a unique connection ID is assigned to this connection by the Web PubSub service.

### Hub

A hub is a logical concept for a set of client connections. Usually you use one hub for one purpose, for example, a chat hub, or a notification hub. When a client connection is created, it connects to a hub, and during its lifetime, it belongs to that hub. Different applications can share one Azure Web PubSub service by using different hub names.

### Group

A group is a subset of connections to the hub. You can add a client connection to a group, or remove the client connection from the group, anytime you want. For example, when a client joins a chat room, or when a client leaves the chat room, this chat room can be considered to be a group. A client can join multiple groups, and a group can contain multiple clients.

### User

Connections to Web PubSub can belong to one user. A user might have multiple connections, for example when a single user is connected across multiple devices or multiple browser tabs.

### Message

When a client is connected, it can send messages to the upstream application, or receive messages from the upstream application, through the WebSocket connection.

## Examples

### Generate the full URI containing access token for the connection to use when connects the Azure Web PubSub

```C# Snippet:GetClientAccessUri
// Generate client access URI for userA
serviceClient.GetClientAccessUri(userId: "userA");
// Generate client access URI with initial permissions
serviceClient.GetClientAccessUri(roles: new string[] { "webpubsub.joinLeaveGroup.group1", "webpubsub.sendToGroup.group1" });
// Generate client access URI with initial groups to join when the connection connects
serviceClient.GetClientAccessUri(groups: new string[] { "group1", "group2" });
```

### Send messages to the connections
#### Broadcast a text message to all clients

```C# Snippet:WebPubSubHelloWorld
var serviceClient = new WebPubSubServiceClient(connectionString, "some_hub");

serviceClient.SendToAll("Hello World!");
```

#### Broadcast a JSON message to all clients

```C# Snippet:WebPubSubSendJson
var serviceClient = new WebPubSubServiceClient(connectionString, "some_hub");

serviceClient.SendToAll(RequestContent.Create(
        new
        {
            Foo = "Hello World!",
            Bar = 42
        }),
        ContentType.ApplicationJson);
```

#### Broadcast a binary message to all clients

```C# Snippet:WebPubSubSendBinary
var serviceClient = new WebPubSubServiceClient(connectionString, "some_hub");

Stream stream = BinaryData.FromString("Hello World!").ToStream();
serviceClient.SendToAll(RequestContent.Create(stream), ContentType.ApplicationOctetStream);
```

#### Broadcast messages to clients using filter
Azure Web PubSub supports OData filter syntax to filter out the connections to send messages to.

Details about `filter` syntax please see [OData filter syntax for Azure Web PubSub](https://aka.ms/awps/filter-syntax).

```C# Snippet:WebPubSubSendWithFilter
var serviceClient = new WebPubSubServiceClient(connectionString, "some_hub");

// Use filter to send text message to anonymous connections
serviceClient.SendToAll(
        RequestContent.Create("Hello World!"),
        ContentType.TextPlain,
        filter: ClientConnectionFilter.Create($"userId eq {null}"));

// Use filter to send JSON message to connections in groupA but not in groupB
var group1 = "GroupA";
var group2 = "GroupB";
serviceClient.SendToAll(RequestContent.Create(
        new
        {
            Foo = "Hello World!",
            Bar = 42
        }),
        ContentType.ApplicationJson,
        filter: ClientConnectionFilter.Create($"{group1} in groups and not({group2} in groups)"));
```

### Connection management

#### Add connections for some user to some group:
```C# Snippet:WebPubSubAddUserToGroup
client.AddUserToGroup("some_group", "some_user");

// Avoid sending messages to users who do not exist.
if (client.UserExists("some_user").Value)
{
    client.SendToUser("some_user", "Hi, I am glad you exist!");
}

client.RemoveUserFromGroup("some_group", "some_user");
```

#### Remove connection from all groups
```C# Snippet:WebPubSubRemoveConnectionFromAllGroups
var client = new WebPubSubServiceClient(connectionString, "some_hub");
client.RemoveConnectionFromAllGroups("some_connection");
```

#### List connections in group
Synchronous version:
```C# Snippet:WebPubSubListConnectionsInGroup
foreach (WebPubSubGroupMember member in client.ListConnectionsInGroup("groupName"))
{
    Console.WriteLine($"ConnectionId: {member.ConnectionId}, UserId: {member.UserId}");
}
```

Asynchronous version:
```C# Snippet:WebPubSubListConnectionsInGroupAsync
await foreach (WebPubSubGroupMember member in client.ListConnectionsInGroupAsync("groupName"))
{
    Console.WriteLine($"ConnectionId: {member.ConnectionId}, UserId: {member.UserId}");
}
```

## Troubleshooting

### Setting up console logging

You can also easily [enable console logging](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#logging) if you want to dig deeper into the requests you're making against the service.

## Next steps

Please take a look at the
[samples][samples_ref]
directory for detailed examples on how to use this library.

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

[azure_sub]: https://azure.microsoft.com/free/dotnet/
[samples_ref]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub/tests/Samples/
[awps_sample]: https://github.com/Azure/azure-webpubsub/tree/main/samples/csharp
