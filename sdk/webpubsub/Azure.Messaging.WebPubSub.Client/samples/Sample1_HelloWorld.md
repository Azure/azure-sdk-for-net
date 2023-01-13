# Create clients, publish and subscribe to group messages

This sample demonstrates the basic usage of Azure Web PubSub service, with the goal of quickly allowing you to publish to groups and subscribe to messages from groups. To accomplish this, the `WebPubSubClient` will be introduced, along with some of the core concepts of Azure Web PubSub service.

## Create the clients

A Client uses a Client Access URL to connect and authenticate with the service. The Uri follow the patten as `wss://<service_name>.webpubsub.azure.com/client/hubs/<hub_name>?access_token=<token>`. There're multiple ways to get a Client Access URL. As a quick start, you can copy and paste from Azure Portal, and for production, you usually need a negotiation server to generate the Uri.

### Use Client Access URL from Azure Portal

As a quick start, you can go to the Portal and copy the **Client Access URL** from **Key** blade.

![get_client_url](https://learn.microsoft.com/azure/azure-web-pubsub/media/howto-websocket-connect/generate-client-url.png)

As shown in the diagram, the client will be granted permission of sending messages to the specific group and joining the specific group. Learn more about client permission, see [permissions](https://learn.microsoft.com/azure/azure-web-pubsub/reference-json-reliable-webpubsub-subprotocol#permissions)

```C# Snippet:WebPubSubClient_Construct
var client = new WebPubSubClient(new Uri("<client-access-uri>"));
```

### Use negotiation server to generate Client Access URL

In production, a client usually fetches the Client Access URL from a negotiation server. The server holds the connection string and generates the Client Access URL through `WebPubSubServiceClient`. As a sample, the code snippet below just demonstrates how to generate the Client Access URL inside a single process.

```C# Snippet:WebPubSubClient_Construct2
var client = new WebPubSubClient(new WebPubSubClientCredential(token =>
{
    // In common practice, you will have a negotiation server for generating token. Client should fetch token from it.
    return FetchClientAccessTokenFromServerAsync(token);
}));
```

```C# Snippet:WebPubSubClient_GenerateClientAccessUri
public async ValueTask<Uri> FetchClientAccessTokenFromServerAsync(CancellationToken token)
{
    var serviceClient = new WebPubSubServiceClient("<< Connection String >>", "hub");
    return await serviceClient.GetClientAccessUriAsync();
}
```

The client is responsible for making a connection to the service and efficiently publishing messages or subscribing to messages from groups. By default, `WebPubSubClient` uses `json.reliable.webpubsub.azure.v1` subprotocol.

## Subscribe to messages

Messages can come from groups or from servers. The client can register a callback to be notified when messages have been received. The callbacks share the same lifetime with the client, so you can subscribe to them before you start the client. If the client has permission to join groups, it can join the group to subscribe to messages from that group. But note joining group operation must be called after the client has been started.

```C# Snippet:WebPubSubClient_Subscribe_ServerMessage
client.ServerMessageReceived += eventArgs =>
{
    Console.WriteLine($"Receive message: {eventArgs.Message.Data}");
    return Task.CompletedTask;
};
```

```C# Snippet:WebPubSubClient_Subscribe_GroupMessage
client.GroupMessageReceived += eventArgs =>
{
    Console.WriteLine($"Receive group message from {eventArgs.Message.Group}: {eventArgs.Message.Data}");
    return Task.CompletedTask;
};
```

## Start client

After you call `client.StartAsync()`, the client starts to make connections to the service and be ready for sending messages.

```csharp
await client.StartAsync();
```

## Publish messages to group or server

To publish messages, a `WebPubSubClient` need to be created and started. The client can send events to the server or send messages to groups.

```C# Snippet:WebPubSubClient_SendToGroup
// Send message to group "testGroup"
await client.SendToGroupAsync("testGroup", BinaryData.FromString("hello world"), WebPubSubDataType.Text);
```

```C# Snippet:WebPubSubClient_SendEvent
// Send custom event to server
await client.SendEventAsync("testEvent", BinaryData.FromString("hello world"), WebPubSubDataType.Text);
```
