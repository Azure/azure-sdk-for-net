# Release History

## 1.3.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.0 (2026-10-15)

### Features Added

- Stable release of the features previously introduced in `1.2.0-beta.1` and `1.2.0-beta.2`.

### Bugs Fixed

- Restored automatic name generation for `FileShare` and `BlobContainer` to use 3-63 characters consisting of lowercase letters, numbers, and hyphens. Mixed-case identifiers are lowercased, and underscores and unsupported punctuation are removed.

## 1.2.0-beta.2 (2026-10-13)

### Features Added

- Updated the default Azure Storage resource API version to `2026-06-01`, while retaining previously supported explicit API versions.
- Added `AdvancedPlatformMetricsRule`, `ContextCache`, `ContextCacheContainer`, `StorageConnector`, and `StorageDataShare` resources and related models.
- Added support for the `Smart` storage account access tier, `AllowedCopyScope.All`, `TaskExecutionTriggerType.MockRun`, shared-key access settings, cross-tenant delegation SAS, data collaboration policies, blob static websites, and object replication tag settings.
- Added `StorageBuiltInRole.StorageFileDataSmbMIAdmin` for the Storage File Data SMB MI Admin role (`a235d3ee-5935-4cfb-8cc5-a3303ad5995e`).

### Bugs Fixed

- Fixed `StorageActiveDirectoryProperties.DomainGuid` to share its value with `ActiveDirectoryDomainGuid`, preventing conflicting assignments from emitting an outdated domain GUID.

## 1.2.0-beta.1 (2026-03-02)

### Breaking Changes

- `StorageAccount.PrivateEndpointConnections` has been renamed to `StorageAccount.PrivateEndpointConnectionResources` and its type changed from `BicepList<StoragePrivateEndpointConnectionData>` to `BicepList<StoragePrivateEndpointConnection>`. The old property is preserved but marked as obsolete.
- `StorageActiveDirectoryProperties.DomainGuid` has been renamed to `StorageActiveDirectoryProperties.ActiveDirectoryDomainGuid`. The old property is preserved but marked as obsolete.
- `ExecutionTrigger.TriggerType` has been renamed to `ExecutionTrigger.TaskExecutionTriggerType` with type changed from `ExecutionTriggerType` to `TaskExecutionTriggerType`. The old property is preserved but marked as obsolete.

### Other Changes

- Regenerated from `Azure.ResourceManager.Storage` version 1.6.0 with new API version `2025-06-01`.

## 1.1.2 (2025-07-15)

### Bugs Fixed

- `Name` property of `TableService` now always has the value of `default` since this is its only valid value. Fixes [#51210](https://github.com/Azure/azure-sdk-for-net/issues/51210)

## 1.1.1 (2025-06-25)

### Bugs Fixed

- Hide some properties that are incorrectly generated in previous versions.

## 1.1.0 (2025-06-16)

### Features Added

- Updated to use latest API version.

## 1.0.1 (2025-05-15)

### Bugs Fixed

- Fixed the `Name` of `QueueService` should always be `default`. (https://github.com/Azure/azure-sdk-for-net/issues/49898)

## 1.0.0 (2024-10-25)

### Features Added

- The new Azure.Provisioning experience.

## 1.0.0-beta.1 (2024-10-04)

### Features Added

- Preview of the new Azure.Provisioning experience.
