# Release History

## 5.0.0-beta.6 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 5.0.0-beta.5 (2021-07-07)

### Breaking Changes
- Renamed `ServiceBusEntityType` property to `EntityType`.
- Renamed `messageActions` and `sessionActions` parameters to `actions` in `MessageProcessor` and `SessionMessageProcessor`.
- Renamed `MaxBatchSize` to `MaxMessageBatchSize` in `ServiceBusOptions`.

## 5.0.0-beta.4 (2021-06-22)

### Added
- Added `AutoCompleteMessages` property to `ServiceBusTriggerAttribute` which allows configuring autocompletion at the function level.

### Key Bug Fixes
- Fix binding for DateTime parameters
- Avoid exception that occurred when a function settles messages and `AutoCompleteMessages` is true for multiple dispatch functions.
- Avoid null reference exception that could occur when no messages are available for a multiple dispatch function.

## 5.0.0-beta.3 (2021-05-18)

### Added
- Added `JsonSerializerSettings` property to `ServiceBusOptions`.

### Breaking Changes
- Made `Constants` class internal.
- Made `ServiceBusWebJobsStartup` class internal.
- Renamed `EntityType` to `ServiceBusEntityType`.
- Removed `receiver` parameter from `MessageProcessor` constructor.
- Removed `client` parameter from `SessionMessageProcessor` constructor.

### Key Bug Fixes
- The web proxy specified in configuration is now respected.
- Binding to JObject is now supported.

## 5.0.0-beta.2 (2021-04-07)

### Added
- Add AAD support

### Breaking Changes
- Changed the API signatures for the methods in `MessagingProvider`.
- Added `receiver` parameter to `MessageProcessor` constructor.
- Added `client` parameter to `SessionMessageProcessor` constructor.

## 5.0.0-beta.1 (2021-03-23)

- The initial release of Microsoft.Azure.WebJobs.Extensions.ServiceBus 5.0.0
