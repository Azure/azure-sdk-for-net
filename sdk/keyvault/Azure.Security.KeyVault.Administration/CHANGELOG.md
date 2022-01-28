# Release History

## 4.1.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
