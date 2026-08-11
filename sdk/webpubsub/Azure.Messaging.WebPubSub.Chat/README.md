# Azure Web PubSub Chat client library for .NET

Azure Web PubSub Chat is a service client library built on top of [Azure Web PubSub](https://aka.ms/awps/doc) that provides chat primitives such as rooms, conversations, messages, users, members, and role-based permissions. Use this library from your application server to manage chat resources and read message history, while clients exchange messages in real time over WebSocket connections.

Use this library to:

- Generate client access URIs so clients can connect to the service.
- Create and manage chat rooms and their members.
- Create and manage chat users.
- Define custom roles from built-in permissions, and inspect built-in roles.
- Read message history from a conversation, and update or delete messages.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Messaging.WebPubSub.Chat --prerelease
```

### Prerequisites

- You must have a [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).
- An existing Azure Web PubSub service instance.

### Authenticate the client

You can create a `WebPubSubChatServiceClient` using a connection string and a hub name:

```C# Snippet:WebPubSubChatAuthenticateWithConnectionString
var client = new WebPubSubChatServiceClient("<connection-string>", "chat");
```

Or authenticate with an `AzureKeyCredential`:

```C# Snippet:WebPubSubChatAuthenticateWithKeyCredential
var client = new WebPubSubChatServiceClient(
    new Uri("https://<instance>.webpubsub.azure.com"),
    "chat",
    new AzureKeyCredential("<access-key>"));
```

Or authenticate with Microsoft Entra ID using [`Azure.Identity`](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme):

```C# Snippet:WebPubSubChatAuthenticateWithEntraId
var client = new WebPubSubChatServiceClient(
    new Uri("https://<instance>.webpubsub.azure.com"),
    "chat",
    new DefaultAzureCredential());
```

## Key concepts

### Hub

A hub is a logical grouping of client connections used for a single purpose, for example a chat application. The hub name is supplied when the client is created and scopes every operation.

### Room

A room is a container that groups a set of users who can chat with each other. Each room exposes a default conversation used to exchange messages.

### Conversation

A conversation is the stream of messages that belong to a room. Message history is read from a conversation using its identifier (a room's `DefaultConversation`).

### Message

A message is a single entry in a conversation. Messages can carry text or binary content. Messages are sent by connected clients over WebSocket; the service client is used to read history and to update or delete existing messages.

### User and member

A user represents a chat participant. Adding a user to a room creates a room member, which associates the user with a role in that room.

### Role and permission

A role is a named set of permissions. This library ships built-in user permissions (`UserPermissions`), room permissions (`RoomPermissions`), and roles (`ChatRoles`), and you can also define custom roles. A role name must start with the `user.` or `room.` prefix, and must not mix user permissions with room permissions.

## Examples

### Generate a client access URI

```C# Snippet:WebPubSubChatGenerateClientAccessUri
Uri clientAccessUri = client.GetClientAccessUri(new GetClientAccessTokenOptions
{
    UserId = "user1",
    ExpiresAfter = TimeSpan.FromHours(1),
});
```

### Create a room and add a member

```C# Snippet:WebPubSubChatCreateRoomAndMember
// Create (or replace) a room.
ChatRoom room = client.CreateOrReplaceRoom("room1", new ChatRoom("General")).Value;

// Create (or replace) a user with a built-in role.
client.CreateOrReplaceUser("user1", new HumanChatUser("Alice", ChatRoles.UserNormal));

// Add the user to the room as a room member.
client.CreateOrReplaceRoomMember("room1", "user1", new ChatRoomMember(ChatRoles.RoomMember));
```

### Define a custom role from built-in permissions

```C# Snippet:WebPubSubChatDefineCustomRole
var role = new ChatRole(new[]
{
    RoomPermissions.PublishMessage,
    RoomPermissions.History,
    RoomPermissions.InviteUser,
});

client.CreateOrReplaceRole("room.contributor", role);
```

### Inspect a built-in role

```C# Snippet:WebPubSubChatInspectBuiltInRole
ChatRole memberRole = client.GetRole(ChatRoles.RoomMember).Value;

Console.WriteLine($"{memberRole.Name}: {string.Join(", ", memberRole.Permissions)}");
```

### Read message history

```C# Snippet:WebPubSubChatReadMessageHistory
ChatRoom room = client.GetRoom("room1").Value;

foreach (WebPubSubChatMessage message in client.GetMessages(room.DefaultConversation))
{
    Console.WriteLine($"{message.CreatedBy}: {message.Content.Text}");
}
```

More detailed examples are available in the [samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub.Chat/tests/Samples/README.md) folder.

## Troubleshooting

Service operations throw a `RequestFailedException` when the service returns a non-success status code. The exception's `Status` and `ErrorCode` properties provide details about the failure.

```C# Snippet:WebPubSubChatHandleRequestFailure
try
{
    client.GetRoom("does-not-exist");
}
catch (RequestFailedException ex)
{
    Console.WriteLine($"Request failed with status {ex.Status}: {ex.Message}");
}
```

## Next steps

- Explore the [samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub.Chat/tests/Samples/README.md) folder for end-to-end scenarios.
- Learn more about [Azure Web PubSub](https://aka.ms/awps/doc).

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (for example, label, comment). Follow the instructions provided by the bot. You'll only need to do this action once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any other questions or comments.
