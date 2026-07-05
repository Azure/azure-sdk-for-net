# Release History

## 1.2.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.0-beta.1 (2026-03-02)

### Features Added

- Added new API version `2023-08-01` to resource versions.
- Enabled `ignorePropertiesWithoutPath` to filter out properties without valid wire paths.
- Made `SqlServerDatabaseReplicationLink.Name` settable to match the Bicep resource schema.
- 36 singleton resources now have read-only `Name` with correct default values matching Bicep requirements (e.g., `"default"`, `"current"`, `"Default"`, `"ActiveDirectory"`, `"allowPolybaseExport"`).

### Breaking Changes

- `GeoBackupPolicy.State` has been replaced by `GeoBackupPolicyState`. The old property is preserved but hidden for backward compatibility.
- `SqlServerDatabaseReplicationLink.LinkId` has been replaced by `Name`. The old property is preserved but hidden for backward compatibility.
- 21 Name-related enum types (e.g., `BlobAuditingPolicyName`, `TransparentDataEncryptionName`, `EncryptionProtectorName`) have been removed from the generated code. Backward-compatible versions are preserved but hidden from IntelliSense.
- `Name` property on 36 singleton resources is now read-only (setter removed). These resources only accept a single fixed value for `Name`.

## 1.1.0 (2025-06-16)

### Features Added

- Updated to use latest API version.

## 1.0.0 (2024-10-25)

### Features Added

- The new Azure.Provisioning experience.

## 1.0.0-beta.1 (2024-10-04)

### Features Added

- Preview of the new Azure.Provisioning experience.
