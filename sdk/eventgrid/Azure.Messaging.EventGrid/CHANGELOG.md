# Release History
## 4.0.0-beta.5 (Unreleased)


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
