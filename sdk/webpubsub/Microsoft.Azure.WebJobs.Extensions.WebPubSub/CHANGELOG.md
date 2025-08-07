# Release History

## 1.10.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.9.0 (2025-07-29)

### Other Changes
- Upgrade dependency package `Microsoft.AspNetCore.Http` to 2.3.0.
- Upgrade dependency package `Microsoft.Azure.WebPubSub.Common` to 1.4.0.

## 1.8.0 (2024-09-04)
### Features Added
- Added MQTT client events support.

## 1.7.0 (2023-08-28)

### Bugs Fixed
- Fix multi request origins validation.

## 1.6.0 (2023-07-12)

### Bugs Fixed
- Fix secondary key validation failed.
- Fix multi request origins validation.

## 1.5.0 (2023-03-21)

### Bugs Fixed
- Fix `Headers` field in `ConnectEventRequest` that was missed set.

## 1.4.0 (2023-02-01)

### Bugs Fixed
- Fix setting generic converters in JsonSerializerSettings.

## 1.3.0 (2022-11-11)

### Features Added
- Support `Headers` field in `ConnectEventRequest` to carry over client headers.

### Bugs Fixed
- Fix the issue about `expiresAfter` with corner values.

## 1.2.0 (2022-03-08)

### Bugs Fixed
- Fix `CancellationToken` in output binding.(#26704)

## 1.1.0 (2021-11-24)

### Bugs Fixed
- Changed the `ConnectionContext`'s `ConnectionStates` to correctly serialize as proper JSON when used with JavaScript.

### Breaking Changes
- JavaScript developers using `request.connectionContext.states` no longer need to `JSON.parse(...)` its values.  The values are already valid JSON.

## 1.0.0 (2021-11-09)

### Breaking Changes
- Move output binding object to namespace `Microsoft.Azure.WebJobs.Extensions.WebPubSub`.
- Add a few static create methods under `WebPubSubAction` to easily discover available actions.
- Add dependency `Azure.Messageing.WebPubSub` for service calls.
- Rename output binding from `WebPubSubOperation` to `WebPubSubAction`, and add `Action` as suffix for derived classes.
- Rename `operationKind` to `actionName` in output binding for javascript to deserialize.
- Changed the name and type of the `Uri` properties in `WebPubSubConnection` to match other libraries in the Azure SDK for .NET.

## 1.0.0-beta.4 (2021-11-09)

### Features Added
- Add `Connection` attribute to input binding and trigger binding to support upstream validations.
- Add support to `CloseAllConnections` and `CloseGroupConnections`.

### Breaking Changes
- Rename `WebPubSubRequest` input binding to `WebPubSubContext`.
- Move data model dependencies to `Microsft.Azure.WebPubSub.Common`.
- Move output binding objects to sub namespace `Microsoft.Azure.WebJobs.Extensions.WebPubSub.Operations`.
- Move dependency `Azure.Messaging.WebPubSub` to internal for GA needs.

### Bugs Fixed
- Fix json deserialize issues and limited to string only to reduce ambiguity.

## 1.0.0-beta.3 (2021-07-26)

### Other Changes
- Upgrade dependency package `Azure.Messaging.WebPubSub` to 1.0.0-beta.2.

## 1.0.0-beta.2 (2021-07-16)

### Features Added
- Added `WebPubSubRequest` input binding to support Static Web Apps.

### Bugs Fixed
- Fixed exceptions when the library is used in Static Web Apps.

## 1.0.0-beta.1 (2021-04-26)
- The initial beta release of Microsoft.Azure.WebJobs.Extensions.WebPubSub 1.0.0
