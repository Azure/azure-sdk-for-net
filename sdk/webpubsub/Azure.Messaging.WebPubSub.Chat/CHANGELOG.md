# Release History

## 1.0.0-beta.2 (Unreleased)

### Features Added

- Regenerated the client from service API version `2026-08-01-preview`, now the default.
- Added pageable listing of rooms, users, topics, and rooms associated with a user.
- Added topic creation, retrieval, merge-patch updates, and conditional soft deletion, with topic lifecycle states and conversation metadata.
- Added `UpdateTopicOptions` and typed topic update methods returning the updated topic.
- Added `UpdateMessageOptions` for partial message updates, including explicit null assignments to clear the creator or content.

### Breaking Changes

- Renamed `WebPubSubChatConversation.ParentRoom` to `RoomId`, including the model factory parameter; the wire property remains `parentRoom`.
- Renamed typed create-or-replace request parameters from `resource` to `role`, `room`, `member`, `user`, and `topic`.
- The typed `UpdateMessage` and `UpdateMessageAsync` overloads now accept `UpdateMessageOptions` instead of `WebPubSubChatMessage`. The `RequestContent` overloads are unchanged.
- Create message content with `WebPubSubChatMessageContent.FromText` or `FromBinary` instead of a parameterless constructor and writable properties.

### Bugs Fixed


### Other Changes

- Clarified message ID cursor pagination and continuation-token resumption for message listings.

## 1.0.0-beta.1 (2026-09-21)

### Features Added

- Initial beta release of the Azure Web PubSub Chat client library for .NET.
- Added `WebPubSubChatServiceClient` with support for connection string, `AzureKeyCredential`, and Microsoft Entra ID (`TokenCredential`) authentication.
- Added management of chat rooms, room members, users, and roles.
- Added reading of message history from a conversation, and updating and deleting messages.
- Added `GetClientAccessUri` to generate a client access URI for connecting to the service.
- Added generated extensible chat permissions (`ChatPermission`) and built-in roles (`BuiltInChatRoles`).
