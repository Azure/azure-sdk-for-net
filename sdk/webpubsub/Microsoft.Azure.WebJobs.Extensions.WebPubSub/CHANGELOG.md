# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
