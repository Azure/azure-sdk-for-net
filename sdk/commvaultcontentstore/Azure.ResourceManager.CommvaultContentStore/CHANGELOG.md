# Release History

## 1.0.0 (2026-11-06)

### Breaking Changes

- Renamed `LatestLinkedSaaS`, `ActivateResource`, and `CountByProtectionGroups` to `GetLatestLinkedSaaS`, `ActivateSaaSResource`, and `CountProtectedItems`, including their asynchronous variants.
- Renamed backup and restore models, including `BackupConfig` to `CommvaultBackupConfiguration`, `VmListItem` to `CommvaultVirtualMachineReference`, `VmInfo` to `CommvaultVirtualMachineRestoreSettings`, and `RestoreProtectionItemContent` to `RestoreProtectedItemContent`. Their backup configuration and virtual machine list properties have also been renamed.
- Renamed protection group and retention models and members, including `ProtectionGroupResources` to `ProtectionGroupResourceSelection`, `ProtectionGroupResourcesMatchRules` to `ProtectionGroupResourceMatchCriteria`, `CommvaultRetentionTime` to `CommvaultRetentionInterval`, and `ExtendedRetentionTime` to `CommvaultExtendedRetentionPolicy`.
- Renamed role principal, marketplace, SaaS, and patch models and members for consistency. For example, `CommvaultEntityInfo` is now `CommvaultRolePrincipal` and `MarketplaceDetails` is now `CommvaultMarketplaceDetails`.
- Renamed `CloudAccountProperties.SsoUri` to `SingleSignOnUriString`. The SaaS activation GUID is now a `Guid` rather than a `string`.

### Features Added

- First stable release of the Azure.ResourceManager.CommvaultContentStore library.

## 1.0.0-beta.1 (2026-08-14)

### Features Added

- Initial release of the Azure.ResourceManager.CommvaultContentStore library, providing management-plane support for Commvault Content Store resources.
