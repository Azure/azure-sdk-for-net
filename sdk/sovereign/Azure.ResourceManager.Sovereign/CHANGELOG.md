# Release History

## 1.0.0-beta.1 (2026-11-11)

### Features Added

This is the first preview release of the Microsoft Azure Sovereign management client library for .NET, generated from TypeSpec with API version `2026-10-31-preview`.

- Added `SovereignViewResource` and `SovereignViewCollection` to manage Sovereign views.
- Added the `CheckNameAvailability` operation.

### Bugs Fixed

- Expose `RemediationId` when a successful remediation long-running operation returns its action result in the ARM `properties` envelope. Flat responses and standard ARM polling, cancellation, and failure handling are unchanged.