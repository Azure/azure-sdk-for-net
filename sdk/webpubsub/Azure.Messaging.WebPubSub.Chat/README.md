# Azure Web PubSub Chat client library for .NET

Azure.Messaging.WebPubSub.Chat is a client library for developing .NET applications with rich experience.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Messaging.WebPubSub.Chat --prerelease
```

### Prerequisites

- You must have a [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the client

Create a `WebPubSubChatServiceClient` using the connection string for your Web PubSub resource and the target hub name.

```C# Snippet:WebPubSubChatAuthenticateWithConnectionString
// <ChatDotNet_AuthenticateWithConnectionString>
var client = new WebPubSubChatServiceClient("<connection-string>", "chat");
// </ChatDotNet_AuthenticateWithConnectionString>
```

## Key concepts

## Examples

### Generate a client access URI

```C# Snippet:WebPubSubChatGenerateClientAccessUri
// <ChatDotNet_GenerateClientAccessUri>
Uri clientAccessUri = client.GetClientAccessUri(new ClientAccessUriOptions
{
    UserId = "user1",
    ExpiresAfter = TimeSpan.FromHours(1),
});
// </ChatDotNet_GenerateClientAccessUri>
```

### Create a room and add a member

```C# Snippet:WebPubSubChatCreateRoomAndMember
// <ChatDotNet_CreateRoomAndMember>
// Create (or replace) a room.
WebPubSubChatRoom room = client.CreateOrReplaceRoom("room1", new WebPubSubChatRoom("General")).Value;

// Create (or replace) a user with a built-in role.
client.CreateOrReplaceUser("user1", new WebPubSubHumanChatUser("Alice", BuiltInChatRoles.UserNormal));

// Add the user to the room as a room member.
client.CreateOrReplaceRoomMember("room1", "user1", new WebPubSubChatRoomMember(BuiltInChatRoles.RoomMember));
// </ChatDotNet_CreateRoomAndMember>
```

### Define a custom role from built-in permissions

```C# Snippet:WebPubSubChatDefineCustomRole
// <ChatDotNet_DefineCustomRole>
var role = new WebPubSubChatRole(new[]
{
    ChatPermission.RoomPublishMessage,
    ChatPermission.RoomHistory,
    ChatPermission.RoomInvite,
});

client.CreateOrReplaceRole("room.contributor", role);
// </ChatDotNet_DefineCustomRole>
```

### Inspect a built-in role

```C# Snippet:WebPubSubChatInspectBuiltInRole
// <ChatDotNet_InspectBuiltInRole>
WebPubSubChatRole memberRole = client.GetRole(BuiltInChatRoles.RoomMember).Value;

Console.WriteLine($"{memberRole.Name}: {string.Join(", ", memberRole.Permissions)}");
// </ChatDotNet_InspectBuiltInRole>
```

### Read message history

```C# Snippet:WebPubSubChatReadMessageHistory
// <ChatDotNet_ReadMessageHistory>
WebPubSubChatRoom room = client.GetRoom("room1").Value;

foreach (WebPubSubChatMessage message in client.GetMessages(room.DefaultConversation))
{
    Console.WriteLine($"{message.CreatedBy}: {message.Content.Text}");
}
// </ChatDotNet_ReadMessageHistory>
```

More detailed examples are available in the [samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub.Chat/tests/Samples/README.md) folder.

## Troubleshooting

## Next steps

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (for example, label, comment). Follow the instructions provided by the bot. You'll only need to do this action once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any other questions or comments.