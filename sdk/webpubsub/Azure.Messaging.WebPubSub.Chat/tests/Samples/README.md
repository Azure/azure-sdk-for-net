# Azure Web PubSub Chat samples for .NET

This folder contains samples that show how to use the `Azure.Messaging.WebPubSub.Chat` client library.

| Sample | Description |
| ------ | ----------- |
| [Manage rooms and members](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub.Chat/tests/Samples/Sample1_ManageRoomsAndMembers.md) | Create rooms, users, and room members, and generate client access URIs. |
| [Roles and permissions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub.Chat/tests/Samples/Sample2_RolesAndPermissions.md) | Use built-in roles and permissions, and define custom roles. |
| [Read and manage messages](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub.Chat/tests/Samples/Sample3_Messages.md) | Read message history from a conversation, and update or delete messages. |

## Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/).
- An existing Azure Web PubSub service instance.
- The `Azure.Messaging.WebPubSub.Chat` package installed in your project.

## Create the client

Every sample assumes you have created and authenticated a `WebPubSubChatServiceClient`:

```C# Snippet:WebPubSubChatAuthenticateWithConnectionString
var client = new WebPubSubChatServiceClient("<connection-string>", "chat");
```

See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub.Chat/README.md) for other ways to authenticate the client.
