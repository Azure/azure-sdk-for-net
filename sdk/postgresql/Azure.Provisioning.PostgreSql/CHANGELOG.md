# Release History

## 1.2.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.0-beta.2 (2026-03-02)

### Features Added

- `ServerThreatProtectionSettingsModel.Name` now defaults to `"Default"` and is read-only.
- `PostgreSqlServerSecurityAlertPolicy.Name` now defaults to `"Default"` and is read-only.

### Breaking Changes

- `ServerThreatProtectionSettingsModel.Name` is now read-only (setter removed). The property only accepts `"Default"`.
- `PostgreSqlServerSecurityAlertPolicy.Name` is now read-only (setter removed). The property only accepts `"Default"`.
- `PostgreSqlFlexibleServerActiveDirectoryAdministrator.ObjectId` type changed from `BicepValue<Guid>` to `BicepValue<string>` to match the service API.
- Removed generated enums `PostgreSqlSecurityAlertPolicyName` and `ThreatProtectionName`. Backward-compatible versions are preserved but hidden from IntelliSense.
- `ServerThreatProtectionSettingsModel.ThreatProtectionName` property is deprecated. Use `Name` instead.

## 1.2.0-beta.1 (2026-02-27)

### Features Added

- Regenerated from updated `Azure.ResourceManager.PostgreSql` 1.4.1 package, adding PostgreSQL versions 17 and 18 to `PostgreSqlFlexibleServerVersion`.

## 1.1.1 (2025-06-25)

### Bugs Fixed

- Hide some properties that are incorrectly generated in previous versions.

## 1.1.0 (2025-06-16)

### Features Added

- Updated to use latest API version.

### Bugs Fixed

- Fixed a bug when we set the convenient property `PostgreSqlFlexibleServer.StorageSizeInGB`, everything in `PostgreSqlFlexibleServer.Storage` will be overridden. ([#50365](https://github.com/Azure/azure-sdk-for-net/issues/50365))

## 1.0.0 (2024-10-25)

### Features Added

- The new Azure.Provisioning experience.

## 1.0.0-beta.1 (2024-10-04)

### Features Added

- Preview of the new Azure.Provisioning experience.
