# Release History

## 4.5.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Key Bugs Fixed

### Fixed


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

This package's [documentation](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventgrid/Azure.Messaging.EventGrid/README.md) and [samples](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventgrid/Azure.Messaging.EventGrid/samples/README.md) demonstrate the new API.
### Features:
- Configurable publisher client that supports sending user-defined events of the Event Grid, CloudEvents v1.0, or custom schema.
- Ability to parse and deserialize system or user-defined events from JSON to events of the Event Grid or CloudEvents schema.
