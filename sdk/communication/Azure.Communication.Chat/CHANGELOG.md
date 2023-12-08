# Release History

## 1.3.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.0 (2023-12-04)

### Features Added

- Added `ChatAttachment` object that contains properties for inline images incoming from Teams Chat Threads.

## 1.2.0-beta.1 (2023-08-15)

## 1.1.2 (2023-06-19)

### Features Added
- Optimized the logic for deserializing types derived from the `CommunicationIdentifier`.
- Added factory methods for `public` models in `ChatModelFactory`.

## 1.1.1 (2022-09-16)

### Features Added
Updated `Azure.Communication.Common` version.

## 1.1.0 (2021-09-15)
Updated `Azure.Communication.Chat` version.

## 1.1.0-beta.1 (2021-07-22)
### Added
- Added support for metadata in messages.
- Added new overloads for sendmessage and updatemessage operations with options : SendChatMessageOptions and UpdateChatMessageOptions. 
- Added support for user display name in typing notifications.
- Added new overloads for sendtypingnotification operation with options : TypingNotificationOptions. 

## 1.0.1 (2021-05-11)

### Bug Fixes
- Changed DateTime.MinValue to DateTimeOffset.MinValue in sample code
- Fixed the bug where Message type is defaulting to text

## 1.0.0 (2021-03-29)

### Breaking Changes

- Renamed client constructors URL variable to `endpoint`.
- Renamed `ChatThread` model to `ChatThreadProperties`.
- Renamed `GetChatThread` operation to `GetPropertie`s and moved it to `ChatThreadClient`.
- Renamed `ChatThreadInfo` model to `ChatThreadItem`.
- Renamed `GetChatThreadsInfo` operation to `GetChatThreads`.
- Made `AddParticipant` throw exception when request fails.
- Renamed parameter `repeatabilityRequestId` to `idempotencyToken`.
- Updated `SendMessage` to use `SendChatMessageResult` instead of `string` for the request result.
- Exposed the list of `invalidparticipants` directly and removed `AddChatParticipantsErrors` and `CreateChatThreadErrors` models for `AddChatParticipantsResult` and `CreateChatThreadResult`.

### Added

- Made list of participants optional for `CreateChatThread`.
- Made `ChatThreadClient` constructor public.

## 1.0.0-beta.5 (2021-03-09)

### Breaking Changes

- Added support for communication identifiers instead of raw strings.
- Removed support for nullable reference types.

## 1.0.0-beta.4 (2021-02-09)

### Breaking Changes

- Updated to Azure.Communication.Common version 1.0.0-beta.4. Now uses `CommunicationUserIdentifier` and `CommunicationIdentifier` in place of `CommunicationUser`, and `CommunicationTokenCredential` instead of `CommunicationUserCredential`.
- Removed `Priority` field from `ChatMessage`.

### Added

- Added support for `CreateChatThreadResult` and `AddChatParticipantsResult` to handle partial errors in batch calls.
- Added idempotency identifier parameter for chat creation calls.
- Added pagination support for `GetReadReceipts`, `GetReadReceiptsAsync` and `GetParticipants`, `GetParticipantsAsync`.
- Added new model for messages and content types: `Text`, `Html`, `ParticipantAdded`, `ParticipantRemoved`, `TopicUpdated`.
- Added new model for errors (`CommunicationError`).
- Added notifications for thread level changes.


## 1.0.0-beta.3 (2020-11-16)

### Added
- Support for mocking all client methods that use models with internal constructors.
- Added unit test for pagination.


## 1.0.0-beta.2 (2020-10-06)
Updated `Azure.Communication.Chat` version.

## 1.0.0-beta.1 (2020-09-22)
This is the first release of Azure Communication Services for chat. For more information, please see the [README][read_me] and [documentation][documentation].

This is a Public Preview version, so breaking changes are possible in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

<!-- LINKS -->
[read_me]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Chat/README.md
[documentation]: https://docs.microsoft.com/azure/communication-services/quickstarts/chat/get-started?pivots=programming-language-csharp

