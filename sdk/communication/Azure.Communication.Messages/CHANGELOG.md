# Release History

## 1.3.0-beta.2 (2025-10-01)

### Features Added
- Add support for read receipt and typing indicator.

## 1.3.0-beta.1 (2025-04-14)

### Features Added

- Add Unified Messaging.

## 1.2.0-beta.1 (2025-02-11)

### Features Added
- Added Interactive Message.
- Added Reaction Message.
- Added Sticker Message.
- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.1.0 (2024-10-18)

### Features Added
- Added support for additional media message types: documents, videos, and audio.
- Introduced the following new models for enhanced media notifications:
  - `DocumentNotificationContent`: for sending document notifications.
  - `VideoNotificationContent`: for sending video notifications.
  - `AudioNotificationContent`: for sending audio notifications.
  - `ImageNotificationContent`: for sending image notifications.

### Other Changes
- The `MediaNotificationContent` model, previously used for sending image notifications, is being deprecated. A deprecation warning will inform users to transition to the new `ImageNotificationContent` model for future use.

## 1.0.0 (2024-02-29)

### Features Added
- Introduced additional constructors for `MessageTemplateClient` and `NotificationMessagesClient` to support `TokenCredential` authentication methods.
- Introduced a variety of Notification Content models such as `MediaNotificationContent`, `TemplateNotificationContent`, and `TextNotificationContent`, enabling more polymorphic notification types.
- Introduced a variety of message template value models such as `MessageTemplateDocument`, `MessageTemplateImage`, `MessageTemplateVideo`, etc., enabling more polymorphic message template values.
- Added new namespace specific to WhatsApp message templates, including `WhatsAppMessageTemplateBindings`, `WhatsAppMessageTemplateBindingsButton`, and `WhatsAppMessageButtonSubType`, etc.
- Updated `CommunicationMessagesClientOptions` to include a new service version `V2024_02_01` and expanded `CommunicationMessagesModelFactory` with factory methods for new model types.

### Breaking Changes
- Removed the `SendMessageOptions` class in favor of more granular method overloads (`NotificationContent` subclasses) in `NotificationMessagesClient`.
- Changed the way to construct MessageTemplate including message template bindings and values.
- Changed `MessageTemplateItem` class  to support polymorphism, with the introduction of a child class `WhatsAppMessageTemplateItem` containing WhatsApp-specific template contracts.
- Added `GeoPosition`` struct to encapsulate geographic coordinates into a single entity. This change affects any functionality that previously required separate latitude and longitude inputs. 

## 1.0.0-beta.1 (2023-08-15)

This is the first Public Preview release of Azure Communication Services for advanced messages. For more information, please see the [README][read_me].

This is a Public Preview version, so breaking changes are possible in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo][issues].

<!-- LINKS -->
[read_me]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Messages/README.md
[issues]: https://github.com/Azure/azure-sdk-for-net/issues
