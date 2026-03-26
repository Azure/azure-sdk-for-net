# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

- Added `EventGridSenderClientSettings` to support creating a `EventGridSenderClient` from `IConfiguration`, including configuration-based credential resolution and dependency injection registration.
- Added `EventGridReceiverClientSettings` to support creating a `EventGridReceiverClient` from `IConfiguration`, including configuration-based credential resolution and dependency injection registration.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0 (2025-05-09)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

### Bugs Fixed

- Add tracing information to CloudEvents when tracing is enabled.

## 1.0.0 (2024-06-11)

### Features Added

- Initial GA release of Azure.Messaging.EventGrid.Namespaces.

### Other Changes

- `EventGridClient` was split into `EventGridSenderClient` and `EventGridReceiverClient`.
- `ReceiveResult.Value` was renamed to `ReceiveResult.Details`.

## 1.0.0-beta.1 (2024-04-11)

### Features Added

- Initial beta release of Azure.Messaging.EventGrid.Namespaces.
