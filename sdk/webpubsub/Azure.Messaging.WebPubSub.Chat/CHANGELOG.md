# Release History

## 1.0.0-beta.2 (Unreleased)

### Features Added

- Regenerated the client from service API version `2026-08-01-preview`, now the default. The `2026-02-01-preview` version remains selectable.
- Added pageable listing of rooms, users, topics, and rooms associated with a user.
- Added topic creation, retrieval, merge-patch updates, and conditional soft deletion, with topic lifecycle states and conversation metadata.
- Added `UpdateTopicOptions` and typed topic update methods returning the updated topic.
- Added `UpdateMessageOptions` for partial message updates, including explicit null assignments to clear the creator or content.

### Breaking Changes

- The typed `UpdateMessage` and `UpdateMessageAsync` overloads now accept `UpdateMessageOptions` instead of `WebPubSubChatMessage`. The `RequestContent` overloads are unchanged.

### Bugs Fixed

- Topic construction no longer requires a state. An unset state is omitted from requests.
- Fixed `GetRoomsForUser` pagination to expose page-size and continuation-token parameters.
- Added the resource provider namespace to client diagnostics.

### Other Changes

## 1.0.0-beta.1 (2026-09-21)

### Features Added

- Initial beta release of the Azure Web PubSub Chat client library for .NET.
- Added `WebPubSubChatServiceClient` with support for connection string, `AzureKeyCredential`, and Microsoft Entra ID (`TokenCredential`) authentication.
- Added management of chat rooms, room members, users, and roles.
- Added reading of message history from a conversation, and updating and deleting messages.
- Added `GetClientAccessUri` to generate a client access URI for connecting to the service.
- Added generated extensible chat permissions (`ChatPermission`) and built-in roles (`BuiltInChatRoles`).
