# Release History

## 4.7.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 4.6.0 (2025-06-16)

### Other Changes

- Service version is now `7.6`.

## 4.6.0-beta.1 (2025-04-08)

### Features Added

- Added `StartPreRestore` and `StartPreBackup` operations to the `KeyVaultBackupClient`.

### Other Changes

- The default service version is now "7.6-preview.2".

## 4.5.0 (2024-10-14)

### Features Added

- Support for Continuous Access Evaluation (CAE).

## 4.4.0 (2024-02-14)

Changes from both the last release and the last beta include:

### Features Added

- The `sasToken` parameter is now optional in `KeyVaultBackupClient.StartBackup` and `StartBackupAsync`. Managed Identity will be used instead if `sasToken` is null.
- The `sasToken` parameter is now optional in `KeyVaultBackupClient.StartRestore` and `StartRestoreAsync`. Managed Identity will be used instead if `sasToken` is null.
- The `sasToken` parameter is now optional in `KeyVaultBackupClient.StartSelectiveKeyRestore` and `StartSelectiveKeyRestoreAsync`. Managed Identity will be used instead if `sasToken` is null.

### Breaking Changes

- `KeyVaultBackupOperation`, `KeyVaultRestoreOperation`, and `KeyVaultSelectiveKeyRestoreOperation` now throw a `RequestFailedException` with a different error message - but a raw `Response` with more details - when the service returns an error response. ([#41855](https://github.com/Azure/azure-sdk-for-net/issues/41855))

### Bugs Fixed

- When a Key Vault is moved to another tenant, the client is reauthenticated.

### Other Changes

- The default service version is now "7.5".
- Distributed tracing with `ActivitySource` is stable and no longer requires the [Experimental feature-flag](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

## 4.4.0-beta.2 (2023-11-13)

### Other Changes

- Distributed tracing with `ActivitySource` is stable and no longer requires the [Experimental feature-flag](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

## 4.4.0-beta.1 (2023-11-09)

### Features Added

- The `sasToken` parameter is now optional in `KeyVaultBackupClient.StartBackup` and `StartBackupAsync`. Managed Identity will be used instead if `sasToken` is null.
- The `sasToken` parameter is now optional in `KeyVaultBackupClient.StartRestore` and `StartRestoreAsync`. Managed Identity will be used instead if `sasToken` is null.
- The `sasToken` parameter is now optional in `KeyVaultBackupClient.StartSelectiveKeyRestore` and `StartSelectiveKeyRestoreAsync`. Managed Identity will be used instead if `sasToken` is null.

### Bugs Fixed

- When a Key Vault is moved to another tenant, the client is reauthenticated.

### Other Changes

- The default service version is now "7.5-preview.1".

## 4.3.0 (2023-03-14)

### Breaking Changes

The following changes are only breaking from the previous beta. They are not breaking since version 4.4.0 when those types and members did not exist.

- Service version "7.4-preview.1" is not supported.
- Removed `KeyVaultSetting.AsBoolean` and `AsString`, and added `AsBoolean` to new `KeyVaultSetting.Value` property type, `KeyVaultSettingValue`.

### Other Changes

- The default service version is now "7.4".

## 4.3.0-beta.1 (2022-11-09)

### Features Added

- Added `KeyVaultSettingsClient` to get and update Managed HSM settings.

### Other Changes

- The default service version is now "7.4-preview.1".

## 4.2.0 (2022-09-20)

### Breaking Changes

- Verify the challenge resource matches the vault domain.
  This should affect few customers who can set `KeyVaultAdministrationClientOptions.DisableChallengeResourceVerification` to `true` to disable.
  See https://aka.ms/azsdk/blog/vault-uri for more information.

## 4.1.0 (2022-03-24)

Changes from both the last release and the last beta include:

### Features Added

- Support multi-tenant authentication against Managed HSM when using Azure.Identity 1.5.0 or newer. ([#18359](https://github.com/Azure/azure-sdk-for-net/issues/18359))

### Other Changes

- The default service version is now "7.3".

## 4.1.0-beta.3 (2022-02-08)

### Other Changes

- Updated documentation.

## 4.1.0-beta.2 (2021-10-14)

### Features Added

- Support multi-tenant authentication against Managed HSM when using Azure.Identity 1.5.0 or newer. ([#18359](https://github.com/Azure/azure-sdk-for-net/issues/18359))

## 4.1.0-beta.1 (2021-08-10)

### Fixed

- The default service version is now "7.3-preview".

## 4.0.0 (2021-06-15)

- Initial release of `KeyVaultAccessControlClient` to managed role assignments and definitions for Managed HSM.
- Initial release of `KeyVaultBackupClient` to backup and restore Managed HSM.

### Breaking Changes since 4.0.0-beta.5

- Changed `KeyVaultBackupClient.StartSelectiveRestore` and `StartSelectiveRestoreAsync` to `StartSelectiveKeyRestore` and `StartSelectiveKeyRestoreAsync`.
- Return only a `Response` from `KeyVaultAccessControlClient.DeleteRoleAssignment` and `DeleteRoleAssignmentAsync`. HTTP 404 responses no longer throw a `RequestFailedException`.
- Return only a `Response` from `KeyVaultAccessControlClient.DeleteRoleDefinition` and `DeleteRoleDefinitionAsync`. HTTP 404 responses no longer throw a `RequestFailedException`.

## 4.0.0-beta.5 (2021-05-11)

### Changed

- Updated dependency versions

### Breaking Changes

- Changed parameter order in `KeyVaultAccessControlClient.DeleteRoleDefinition` and `KeyVaultAccessControlClient.DeleteRoleDefinitionAsync`.
- Changed parameter order in `KeyVaultAccessControlClient.GetRoleDefinition` and `KeyVaultAccessControlClient.GetRoleDefinitionAsync`.
- Changed parameters for `KeyVaultAccessControlClient.CreateOrUpdateRoleDefinition` and `KeyVaultAccessControlClient.CreateOrUpdateRoleDefinitionAsync` to accept new `CreateOrUpdateRoleDefinitionOptions` class.
- Moved all classes from the `Azure.Security.KeyVault.Administration.Models` namespace to `Azure.Security.KeyVault.Administration`.
- Renamed `BackupOperation` to `KeyVaultBackupOperation`.
- Renamed `KeyVaultRoleAssignmentPropertiesWithScope` to `KeyVaultRoleAssignmentProperties`.
- Renamed `RestoreOperation` to `KeyVaultRestoreOperation`.
- Renamed `SelectiveKeyRestoreOperation` to `KeyVaultSelectiveRestoreOperation`.
- Renamed `SelectiveKeyRestoreResult` to `KeyVaultSelectiveRestoreResult`.

## 4.0.0-beta.4 (2021-02-10)

### Added

- Support in `KeyVaultAccessControlClient` to create, update, and delete custom role definitions.

### Changed

- The default service version is now "7.2" (still in preview).

## 4.0.0-beta.3 (2020-11-12)

### Changed

- Consolidated backup and RBAC client options into a single `KeyVaultAdministrationClientOptions`
- Refactored `BackupOperation` to return `BackupResult`
- Refactor `RestoreOperation` to return `RestoreResult`
- Renamed `KeyVaultPermissions` Not\* properties to Deny\*
- Renamed `KeyVaultRoleAssignment` `Type` property to `RoleAssignmentType`
- Made `KeyVaultRoleAssignmentProperties` internal and moved its properties to method parameters for `CreateRoleAssignment`

## 4.0.0-beta.2 (2020-10-06)

- Bug fixes and performance improvements.

## 4.0.0-beta.1 (2020-09-08)

### Added

- Add `KeyVaultAccessControlClient`.
- Add `KeyVaultBackupClient`.
