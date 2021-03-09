# Release History

## 1.0.0-beta.5 (2021-03-09)
Updated `Azure.Communication.Chat` version.

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
[read_me]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/communication/Azure.Communication.Chat/README.md
[documentation]: https://docs.microsoft.com/azure/communication-services/quickstarts/chat/get-started?pivots=programming-language-csharp

