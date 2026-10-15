# Azure Web PubSub Chat client library for .NET

Azure Web PubSub Chat provides rooms, membership, roles, topics, and persistent
message history for real-time chat applications hosted on Azure Web PubSub.
This library supports service API versions `2026-08-01-preview` (the default)
and `2026-02-01-preview`.

Use the client library for Azure Web PubSub Chat to:

- Manage rooms, users, membership, and permissions from a trusted server.
- Discover rooms, users, and the rooms associated with a user.
- Create topics and manage their lifecycle and conversations.
- Read message history and update or delete messages.
- Generate access URIs for real-time chat clients.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/webpubsub/Azure.Messaging.WebPubSub.Chat) |
[Package (NuGet)](https://www.nuget.org/packages/Azure.Messaging.WebPubSub.Chat) |
[API reference documentation](https://learn.microsoft.com/dotnet/api/azure.messaging.webpubsub.chat) |
[Product documentation](https://learn.microsoft.com/azure/azure-web-pubsub/) |
[Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/webpubsub/Azure.Messaging.WebPubSub.Chat/tests/Samples) |
[Changelog](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub.Chat/CHANGELOG.md)

## Getting started

### Install the package

Install the client library with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Messaging.WebPubSub.Chat --prerelease
```

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/).
- An Azure Web PubSub resource with Chat enabled and support for the preview
  APIs. Follow the [service documentation](https://learn.microsoft.com/azure/azure-web-pubsub/)
  to provision a resource.
- A .NET project compatible with .NET Standard 2.0 or later.
- The resource endpoint, a hub name, and credentials authorized to use Chat.
  Find the endpoint and connection string on the resource's **Keys** page in
  the Azure portal.

### Authenticate the client

Run this library in a trusted server application. Never expose the resource's
access key or connection string to a browser, mobile application, or source
control. Load secrets from secure configuration, such as environment variables
or Azure Key Vault.

For Microsoft Entra ID authentication, install `Azure.Identity`:

```dotnetcli
dotnet add package Azure.Identity
```

Import the namespaces used in the examples:

```csharp
using System;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.Messaging.WebPubSub.Chat;
```

Use `DefaultAzureCredential` with an identity granted the
**Web PubSub Service Owner** role on the resource. For local development, sign
in with `az login`. For production, prefer a managed identity.
See [Microsoft Entra authorization](https://learn.microsoft.com/azure/azure-web-pubsub/howto-authorize-from-application).

```C# Snippet:WebPubSubChatAuthenticateWithEntraId
var client = new WebPubSubChatServiceClient(
    new Uri("https://<instance>.webpubsub.azure.com"),
    "chat",
    new DefaultAzureCredential());
```

Alternatively, use the connection string when local authentication is enabled:

```C# Snippet:WebPubSubChatAuthenticateWithConnectionString
// <ChatDotNet_AuthenticateWithConnectionString>
var client = new WebPubSubChatServiceClient("<connection-string>", "chat");
// </ChatDotNet_AuthenticateWithConnectionString>
```

Both clients use `2026-08-01-preview` by default for Chat resource operations.
When using a token credential, `GetClientAccessUri` obtains a client token through
the separate Web PubSub token API using `2024-12-01`. Connection-string and
access-key clients generate the client token locally.

If you store the endpoint and access key separately, use `AzureKeyCredential`:

```C# Snippet:WebPubSubChatAuthenticateWithKeyCredential
var client = new WebPubSubChatServiceClient(
    new Uri("https://<instance>.webpubsub.azure.com"),
    "chat",
    new AzureKeyCredential("<access-key>"));
```

## Key concepts

- **Client:** `WebPubSubChatServiceClient` targets one resource endpoint and
  hub. Client instances are thread-safe and should be reused.
- **Rooms and users:** Rooms contain members. A `WebPubSubHumanChatUser` has a
  user role, and each membership has a room role. `BuiltInChatRoles` provides
  service-defined roles; `ChatPermission` defines permissions for custom roles.
- **Topics and conversations:** Each room has a default conversation. Topics
  belong to a room and have their own conversation IDs. Topic IDs are supplied
  by the caller; the service returns conversation IDs, creator metadata,
  timestamps, and ETags.
- **Topic lifecycle:** States include `Normal`, `Archived`, and `SoftDeleted`.
  Deleting a topic is a soft delete, not permanent removal. Unknown future
  states are preserved by the extensible `ChatTopicState` type.
- **Conditional writes:** Use a resource's ETag in `MatchConditions.IfMatch`
  to avoid overwriting another writer's changes. `IfNoneMatch = ETag.All`
  creates a resource only when it does not already exist.
- **Pagination:** `Pageable<T>` and `AsyncPageable<T>` fetch more pages as you
  enumerate them. `maxPageSize` is a page-size request, not a total-result
  limit. Save the opaque `Page<T>.ContinuationToken` and pass it to `AsPages`
  to resume enumeration.
- **Real-time messaging:** This server library manages Chat resources and
  history. Sending and receiving live chat messages requires a real-time
  client using the service's Chat protocol; it is not a REST publish operation
  on this client.

## Examples

These examples assume an authenticated `client` as described above.

- [Create a room](#create-a-room)
- [Discover rooms](#discover-rooms)
- [Discover users](#discover-users)
- [Discover a user's rooms](#discover-a-users-rooms)
- [Create a topic](#create-a-topic)
- [Read message history](#read-message-history)
- [Generate a client access URI](#generate-a-client-access-uri)

### Create a room

Create or replace a room with a caller-specified ID:

```C# Snippet:WebPubSubChatCreateRoom
WebPubSubChatRoom room = client.CreateOrReplaceRoom("room1", new WebPubSubChatRoom("General")).Value;

Console.WriteLine($"Room {room.Id} default conversation: {room.DefaultConversation}");
```

See [Manage rooms and members](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub.Chat/tests/Samples/Sample1_ManageRoomsAndMembers.md)
for separate examples of creating users and adding members.

### Discover rooms

Enumerate the rooms in the hub:

```C# Snippet:WebPubSubChatDiscoverRooms
await foreach (WebPubSubChatRoom room in client.GetRoomsAsync(maxPageSize: 20))
{
    Console.WriteLine($"{room.Id}: {room.Title}");
}
```

### Discover users

List user profiles, including polymorphic human-user profiles:

```C# Snippet:WebPubSubChatDiscoverUsers
await foreach (WebPubSubChatUser user in client.GetUsersAsync(maxPageSize: 20))
{
    Console.WriteLine($"{user.Id}: {user.Nickname}");
}
```

### Discover a user's rooms

Create `user1` and add it to a room before running this example.
`ChatUserRoom` is a read-only projection of a room, not a separate resource:

```C# Snippet:WebPubSubChatDiscoverUserRooms
await foreach (ChatUserRoom room in client.GetRoomsForUserAsync("user1"))
{
    Console.WriteLine($"User belongs to {room.Title} ({room.Id})");
}
```

### Create a topic

Create `room1` first. This example creates `planning` only if it does not exist.
Use a different topic ID when rerunning it:

```C# Snippet:WebPubSubChatCreateTopic
ChatTopic topic = await client.CreateOrReplaceTopicAsync(
    "room1", "planning", new ChatTopic("Planning", ChatTopicState.Normal),
    new MatchConditions { IfNoneMatch = ETag.All });
Console.WriteLine($"{topic.Id}: {topic.ConversationId}");
```

See [Topics and discovery](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub.Chat/tests/Samples/Sample4_TopicsAndDiscovery.md)
for separate examples of listing, retrieving, archiving, and soft deleting
topics, as well as resuming pagination.

### Read message history

Given a room returned by an earlier create or get operation, read its default
conversation's history:

```C# Snippet:WebPubSubChatReadMessageHistory
// <ChatDotNet_ReadMessageHistory>
WebPubSubChatRoom room = client.GetRoom("room1").Value;

foreach (WebPubSubChatMessage message in client.GetMessages(room.DefaultConversation))
{
    Console.WriteLine($"{message.CreatedBy}: {message.Content.Text}");
}
// </ChatDotNet_ReadMessageHistory>
```

See [Read and manage messages](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub.Chat/tests/Samples/Sample3_Messages.md)
for querying a conversation and updating or deleting messages.

### Generate a client access URI

Given an existing user, generate a short-lived URI for a real-time client.
Treat the URI as a credential: do not log it or send it to an unauthorized
recipient:

```C# Snippet:WebPubSubChatGenerateClientAccessUri
// <ChatDotNet_GenerateClientAccessUri>
Uri clientAccessUri = client.GetClientAccessUri(new ClientAccessUriOptions
{
    UserId = "user1",
    ExpiresAfter = TimeSpan.FromHours(1),
});
// </ChatDotNet_GenerateClientAccessUri>
```

See [Roles and permissions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub.Chat/tests/Samples/Sample2_RolesAndPermissions.md)
to define custom permissions and inspect built-in roles.

## Troubleshooting

Service failures throw `RequestFailedException`. Inspect `Status` and
`ErrorCode` without logging credentials or access URIs:

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

- **400:** Check resource identifiers, topic titles, and the request body.
  Topic IDs use 1-64 letters, digits, underscores, or hyphens; topic titles
  contain 1-256 characters.
- **401 or 403:** Verify credentials, hub, and resource endpoint. For Entra ID,
  verify the identity's role assignment. Connection strings require local
  authentication to be enabled.
- **404:** Check resource existence and that the service supports the selected
  API version.
- **412:** A conditional write failed. Retrieve the latest resource, reconcile
  changes, and retry with the latest ETag rather than blindly overwriting it.
- **429 or transient 5xx:** Clients retry eligible transient failures according
  to `WebPubSubChatServiceClientOptions.Retry`. Check service capacity and
  [service limits](https://learn.microsoft.com/azure/azure-web-pubsub/resource-planning).

For diagnostics, see [Azure SDK logging](https://learn.microsoft.com/dotnet/azure/sdk/logging).
Avoid enabling content logging for sensitive chat messages in production.

## Next steps

- Browse the [compiled samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/webpubsub/Azure.Messaging.WebPubSub.Chat/tests/Samples)
  for membership, roles, message history, topics, and pagination.
- Read the [Azure Web PubSub documentation](https://learn.microsoft.com/azure/azure-web-pubsub/)
  for resource provisioning, authentication, and real-time application design.
- Report bugs or request features in [GitHub issues](https://github.com/Azure/azure-sdk-for-net/issues).

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (for example, label, comment). Follow the instructions provided by the bot. You'll only need to do this action once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any other questions or comments.
