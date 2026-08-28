# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Initial beta release of the Azure Web PubSub Chat client library for .NET.
- Added `WebPubSubChatServiceClient` with support for connection string, `AzureKeyCredential`, and Microsoft Entra ID (`TokenCredential`) authentication.
- Added management of chat rooms, room members, users, and roles.
- Added reading of message history from a conversation, and updating and deleting messages.
- Added `GetClientAccessUri` to generate a client access URI for connecting to the service.
- Added generated extensible chat permissions (`ChatPermission`) and built-in roles (`BuiltInChatRoles`).

### Breaking Changes

### Bugs Fixed

### Other Changes
