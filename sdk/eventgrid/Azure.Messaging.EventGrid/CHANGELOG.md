# Release History

## 4.22.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 4.21.0 (2023-11-07)

### Features Added

- Added new system events for Resource Notifications
- Added the `Metadata` property to various Azure Communication Services events.

## 4.20.0 (2023-10-18)

### Bugs Fixed

- Added several communication models into the correct namespace and hid the old ones.

## 4.19.0 (2023-10-11)

### Features Added

- Added new system events for Resource Notifications and Azure Communication Services.

## 4.18.0 (2023-09-12)

### Features Added

- Added new system events for Event Grid and App Configuration.
- Added `Recipient` property to `AcsEmailEngagementTrackingReportReceivedEventData` event.

### Breaking Changes

- `EventGridClient` has been removed for the stable release. It will be included in a subsequent release.

## 4.18.0-beta.1 (2023-07-16)

### Other Changes

- Shipping the `EventGridClient` on top of the latest system events.

## 4.17.0 (2023-06-08)

### Features Added

- Added new system events for Container Service. 

### Breaking Changes

- `EventGridClient` has been removed for the stable release. It will be included in a subsequent release.

## 4.17.0-beta.2 (2023-06-06)

### Other Changes

- Docs updated to remove example that was causing the doc build to fail.

## 4.17.0-beta.1 (2023-05-22)

### Features Added

- Added `EventGridClient` for interacting with topic and subscription namespaces.

## 4.16.0 (2023-05-09)

### Features Added

- Added `AcsIncomingCallEventData` event.
- Added `DeliveryStatusDetails` property to `AcsEmailDeliveryReportReceivedEventData` event.
- Added `HealthCareDicomImageUpdatedEventData` event.
- Added `PartionName` property to Dicom events.

## 4.15.0 (2023-04-13)

### Features Added

- Added new Storage events, `StorageTaskCompletedEventData` and `StorageTaskQueuedEventData`.

## 4.14.1 (2023-03-13)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.30.0` due to an [issue in `ArrayBackedPropertyBag`](https://github.com/Azure/azure-sdk-for-net/pull/34800) in `Azure.Core` version `1.29.0`.

## 4.14.0 (2023-03-06)

### Features Added

- Added new Communication events, `AcsEmailDeliveryReportReceivedEventData` and `AcsEmailEngagementTrackingReportReceivedEventData`.

## 4.13.0 (2023-01-19)

### Features Added

- Added new API Management events.
- Added new DataBox events.

## 4.12.0 (2022-11-08)

### Features Added

- Added extension builder method that can be used to inject an `EventGridPublisherClient` instance using a `TokenCredential` for authentication.
- Added new Dicom Healthcare events.

### Breaking Changes

- Fixed bug where the CloudEvents Distributed Tracing extensions were populated even when distributed tracing was disabled.

## 4.11.0 (2022-07-07)

### Features Added

- Added support for sending events to partner channels.

## 4.11.0-beta.2 (2022-05-10)

### Breaking Changes

- Removed `SendCloudEventsOptions` type in favor of a string parameter that can be used to specify the channel name.

## 4.11.0-beta.1 (2022-04-07)

### Features Added

- Added Partner Topic support for channels

## 4.10.0 (2022-04-05)

### Features Added

- Added Healthcare events

## 4.9.0 (2022-03-08)

### Features Added

- Added new enum values for `MediaJobErrorCategory` and `MediaJobErrorCode`.

## 4.8.2 (2022-02-08)

### Bugs Fixed
- Fixed deserialization bugs in `StorageDirectoryDeletedEventData` and `EventHubCaptureFileCreatedEventData` system events.

## 4.8.1 (2022-01-12)

### Bugs Fixed
- Fix package icon

## 4.8.0 (2022-01-11)

### Features Added
- Added new properties to Communication events
- Added strongly typed models for Resource events

## 4.7.0 (2021-10-05)

### Features Added
- Added API Management events
- Added AcsUserDisconnectedEventData event

## 4.6.0 (2021-08-10)

### Features Added
- Added `ContainerServiceNewKubernetesVersionAvailableEventData` system event.

### Bugs Fixed
- Updated deserialization of KeyVault system events to match the casing used in the events published by the service.

## 4.5.0 (2021-07-19)

### Features Added
- Added constructor for `EventGridPublisherClient` that takes a `TokenCredential` to enable Azure Active Directory authentication.
- Added `Metadata` property to `AcsChatMessageEditedEventData`, `AcsChatMessageEditedInThreadEventData`, `AcsChatMessageReceivedEventData`, and `AcsChatMessageReceivedInThreadEventData`.
- Added custom converter for `EventGridEvent` that allows this type to be serialized and deserialized using `System.Text.Json` APIs.

## 4.4.0 (2021-06-21)

### Features Added
- Added public constructor and settable property for `SubscriptionValidationResponse`.

### Key Bugs Fixed
- Fix issue where ARM system event data could not be deserialized into their strongly typed models.

## 4.3.0 (2021-06-08)

### New Features
* Added the following new system events:
  - StorageBlobInventoryPolicyCompletedEventData
    
* Updated existing system events:
 - AcsRecordingChunkInfoProperties - Added `ContentLocation` and `MetadataLocation` properties.

### Fixed
- Fixed `SystemEventNames.ServiceBusDeadletterMessagesAvailableWithNoListener` value.

## 4.2.0 (2021-05-10)

### New Features
* Added the following new system events: 
  - PolicyInsightsPolicyStateChangedEventData
  - PolicyInsightsPolicyStateCreatedEventData
  - PolicyInsightsPolicyStateDeletedEventData
  - StorageAsyncOperationInitiatedEventData
  - StorageBlobTierChangedEventData

## 4.1.0 (2021-03-23)

### New Features
- Added new Azure Communication Services system events.

### Fixed
- Fixed system mapping for `AcsChatParticipantAddedToThread` and `AcsChatParticipantRemovedFromThread`.

## 4.0.0 (2021-03-09)

### New Features
- Added single send overloads to allow sending a single event for each event type.

### Breaking Changes
- Moved `CloudEvent` into `Azure.Core` package.
- Changed custom events to be represented as `BinaryData` rather than `object`.
- Removed `Serializer` option from `EventGridPublisherOptions` as serialization can be customized through `BinaryData`.

## 4.0.0-beta.5 (2021-02-09)

### New Features
- Added `TryGetSystemEventData` that attempts to deserialize event data into a known system event.
- Added `EventGridSasBuilder` for constructing SAS tokens.
- Added `SystemEventNames` that contain the names that will be stamped into the event Type for system events.

### Breaking Changes
- Updated `GetData` method to always return `BinaryData` instead of `object`. It no longer deserializes system events.
- Removed the `CloudEvent` constructor overload that took `BinaryData` and replaced with an overload that accepts `ReadOnlyMemory<byte>`
- Replaced use of `EventGridSasCredential` with `AzureSasCredential`.
- Removed `GenerateSharedAccessSignature` in favor of `EventGridSasBuilder`.

## 4.0.0-beta.4 (2020-11-10)

### Fixed
- Fixed bug where missing required properties on CloudEvent would cause deserialization to fail.

## 4.0.0-beta.3 (2020-10-06)

### Fixed
- Fixed bug where we were not parsing the Topic when parsing into EventGridEvents.

### Added

- Added TraceParent/TraceState into CloudEvent extension attributes.
- Added KeyVaultAccessPolicyChangedEventData system event.

### Breaking Changes

- Renamed Azure Communication Services system events.
- Renamed EventGridPublisherClientOptions DataSerializer property to Serializer.

## 4.0.0-beta.2 (2020-09-24)

### Added

- Added support for system events sent by the Azure Communication Services.

## 4.0.0-beta.1 (2020-09-08)
This is the first preview of the Azure Event Grid client library that follows the [.NET Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html). This library is not a drop-in replacement for `Microsoft.Azure.EventGrid`, as code changes would be required to use the new library.

This package's [documentation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventgrid/Azure.Messaging.EventGrid/README.md) and [samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventgrid/Azure.Messaging.EventGrid/samples/README.md) demonstrate the new API.
### Features:
- Configurable publisher client that supports sending user-defined events of the Event Grid, CloudEvents v1.0, or custom schema.
- Ability to parse and deserialize system or user-defined events from JSON to events of the Event Grid or CloudEvents schema.
