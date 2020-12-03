# Release History

## 4.0.0-beta.4 (Unreleased)


## 4.0.0-beta.3 (2020-11-12)

### Changes

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
