# Release History

## 1.13.0-beta.1 (2025-10-22)

### Features Added
- Upgraded api-version tag from 'package-2025-06-01' to 'package-2025-07-01-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/c2c7ee70dea80830fe9ea94aed2cec6182c4e9e6/specification/netapp/resource-manager/readme.md.
- Added `Bucket` resource type
- Added `GetNetAppResourceQuotaLimitsAccountsAsync` to `NetAppAccountResource`

## 1.12.0 (2025-08-25)

### Features Added
- Upgraded api-version tag from 'package-2025-03-01' to 'package-2025-06-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/bf90cab9d5f6060ce1f7775ffac88ed8eda785ca/specification/netapp/resource-manager/readme.md.
- Added `customThroughputMibps` to `CapacityPoolData`
- Added Enum value `Flexible`  to `NetAppFileServiceLevel`
- Added `SplitCloneFromParent` to `NetAppVolumeResource` to convert clone volume to an independent volume
- Added `AcceptGrowCapacityPoolForShortTermCloneSplit` and read only property `InheritedSizeInBytes` to `NetAppVolumeData`

## 1.11.0 (2025-07-25)

### Features Added
- Upgraded api-version tag from 'package-2025-01-01' to 'package-2025-03-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/bf90cab9d5f6060ce1f7775ffac88ed8eda785ca/specification/netapp/resource-manager/readme.md.

## 1.10.0 (2025-05-06)

### Features Added
- Upgraded api-version tag from 'package-2024-09-01' to 'package-2025-01-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/d7a38bf0c0b5fbd9e893e05ad0a7dbee18ac3a8d/specification/netapp/resource-manager/readme.md.
- Added `GetNetAppResourceUsages` and `GetNetAppResourceUsage`
- Added `GetNetAppResourceUsages` and `GetNetAppResourceUsage`
- Added `FederatedClientId` to `NetAppEncryptionIdentity` to support Cross Tennant CMK
- Added `NfsV4IdDomain`, `MultiAdStatus` to `NetAppAccountData.cs`
- Added `DestinationReplications` to `NetAppReplicationObject`
- Added support for ANF Migration Assistant with operations `PeerExternalCluster`, `AuthorizeExternalReplication`, `FinalizeExternalReplication`, `PerformReplicationTransfer` on `NetAppVolumeResource`
- Added `IsLargeVolume` to  `NetAppBackupData`
- `IsRestoring` in `NetAppVolumeData` and `NetAppVolumeGroupVolume` is now a read only property indicating if volume is being resored


## 1.9.0 (2025-02-21)

### Features Added

- Upgraded api-version tag from 'package-2024-07' to 'package-2024-09-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/81330ee21a8300ad377eacbaaf16efabb91d56c0/specification/netapp/resource-manager/readme.md.
- Added `CoolAccessTiering` to `NetAppVolumePatch`, `NetAppVolumeData`, `NetAppVolumeGroupVolume`
- Added `TransitionToCmk` `ChangeKeyVault` and `GetKeyVaultStatus` to `NetAppAccountResource`

## 1.8.0 (2024-10-30)

### Features Added

- Upgraded api-version tag from 'package-2024-03' to 'package-2024-07'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/f37b54b187bac95237c62478a10b94e9cff236f3/specification/netapp/resource-manager/readme.md.
- Added support for external migration replication volumes with operations `PeerExternalClusterAsync`, `AuthorizeExternalReplicationAsync`, `PerformReplicationTransferAsync`, `FinalizeExternalReplicationAsync`
- Added `RemotePath` to `ReplicationObject`
- Added `AvailabilityZone` to `FilePathAvailabilityRequest`
- Added read-only property `EffectiveNetworkFeatures` to `Volume` `VolumeProperties` and `VolumeGroupVolumeProperties`
- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.7.0 (2024-08-16)

### Features Added

- Upgraded api-version tag from 'package-preview-2023-11' to 'package-2024-03'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/aa23ddc02b2b1c5a34c56a49d83b77c0a1aaa614/specification/netapp/resource-manager/readme.md.
- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

### Other Changes

- Upgraded Azure.Core from 1.40.0 to 1.42.0

## 1.6.0 (2024-06-27)

### Features Added

- Upgraded api-version tag from 'package-netapp-2023-07-01' to 'package-netapp-2023-11-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/c54a97d08c5afd7dc04f87a5df65d9dc84c96159/specification/netapp/resource-manager/readme.md.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.38.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.10.2

## 1.5.0 (2024-03-15)

### Features Added

- Upgraded api-version tag from 'package-netapp-2023-05-01' to 'package-netapp-2023-07-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/ac74f8d5cf37351c5b26ecf2df17128d0408bd8e/specification/netapp/resource-manager/readme.md.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.38.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.10.2

## 1.5.0-beta.1 (2024-02-28)

### Features Added

- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Upgraded api-version tag from 'package-netapp-2023-05-01' to 'package-preview-2023-05'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/f5aa38d3f04996bfab6b32dd7e61f02de0c81a7d/specification/netapp/resource-manager/readme.md.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.38.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.10.1

## 1.4.2 (2023-11-29)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.4.1 (2023-11-07)

### Bugs Fixed

- Fixed serialization issue when VolumeSnapshotProperties.SnapshotPolicyId is empty string

## 1.4.0 (2023-10-19)

- Updated to support ANF api-version 2023-05-01

### Features Added

- Added `QueryNetworkSiblingSetNetAppResource` and `UpdateNetworkSiblingSetNetAppResource` to allow clients to query and update the Networking features for a Networking siblingset related to a ANF Volume
- Added `CoolAccessRetrievalPolicy` to `NetAppVolumePatch` and `NetAppVolumeData`, coolAccessRetrievalPolicy determines the data retrieval behavior from the cool tier to standard storage based on the read pattern for cool access enabled volumes.
- Added `SmbNonBrowsable` to `NetAppVolumePatch`, enables non browsable property for SMB Shares. Only applicable for SMB/DualProtocol volume
- Added `SmbAccessBasedEnumeration` to `NetAppVolumePatch`, Enables access based enumeration share property for SMB Shares. Only applicable for SMB/DualProtocol volume

## 1.3.0 (2023-08-15)

### Features Added

- Updated to support ANF api-version 2022-11-01
- Added `GetGetGroupIdListForLdapUser` to `NetAppVolumeResource` and `NetAppVolumeGroupVolume` to get a list of group Ids for a specific LDAP User
- Added `ActualThroughputMibps` to `NetAppVolumeData` to show actual throughput in MiB/s for auto qosType volumes calculated based on size and serviceLevel
- Added `OriginatingResourceId` to `NetAppVolumeData`, the Id of the snapshot or backup that the volume is restored from.
- Added `Identity` to `NetAppAccountPatch` the identity of the resource
- Added `IsSnapshotDirectoryVisible` to `NetAppVolumePatch`, if enabled (true) the volume will contain a read-only snapshot directory which provides access to each of the volume's snapshots
- Added `AcrossT2Value` to `NetAppVolumeStorageToNetworkProximity`, standard AcrossT2 storage to network connectivity.
- Added `AcrossT2Value`, `T1AndAcrossT2Value`, `T2AndAcrossT2Value`, `T1AndT2AndAcrossT2Value` to `RegionStorageToNetworkProximity` enum

## 1.2.0-beta.1 (2023-05-30)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.0 (2023-04-04)

### Features Added

- Updated to support ANF api-version 2022-09-01
- Added `BackupRestoreFiles` to `NetAppVolumeResource` to restore the specified files from the specified backup to the active file system
- Added `BreakFileLocks` to `NetAppVolumeResource` to allow clients to break file locks on a volume
- Added `FileAccessLog` to `NetAppVolumeData`, a flag indicating whether file access logs are enabled for the volume, based on active diagnostic settings present on the volume.
- Added propperty `PreferredServersForLdapClient` to `NetAppAccountActiveDirectory`, a comma separated list of IPv4 addresses of preferred servers for LDAP client
- Added `VolumeRelocation` to `NetAppVolumeDataProtection`
- Added `DataStoreResourceId` to `NetAppVolumeGroupVolume`
- Added `Tags` property to NetAppVolumeQuotaRulePatch and `AddTag`, `RemoveTag` and `SetTags` to `NetAppVolumeQuotaResource`
- Added `RestoreFiles` for `NetAppVolumeBackupResource`

### Breaking Changes

- `NetAppVault` is no longer needed scheduled for deprecation
- `VaultId` is not longer needed it has been deprecated from `NetAppVolumeBackupConfiguration` in api-version 2022-09-01, but will continue to be supported in pervious api-verisons, 2022-05-01 and older

## 1.0.1 (2023-02-15)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-09-28)

This release is the first stable release of the NetApp Management client library.

### Features Added

- Upgrading to support new service api version 2022-05-01
- Added QueryRegionInfoNetAppResourceAsync
- NetAppAccount has new EncryptionKeySource
- NetAppAccount has new AccountEncryption properties, KeySource, KeyVaultProperties and Identity
- Added AccountEncryption KeySource changed to Enum
- Added RenewCredentialsAsync to NetAppAccountResource
- Added DisableShowmount and EncryptionKeySource to NetAppAccount
- Added CoolnessPeriod, CoolAccess to NetAppVolume and NetAppVolumePatch
- Added optional RelocateVolumeContent to NetAppVolume.RelocateAsync
- Added SmbAccessBasedEnumeration, smbNonBrowsable, keyVaultPrivateEndpointResourceId, deleteBaseSnapshot to NetAppVolumeData

### Breaking Changes

Polishing since last public beta release:
- Prepended `NetApp` prefix to all single / simple model names.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://learn.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.
- Removed `location` from `NetAppVault`

### Other Changes

- Upgraded dependent Azure.ResourceManager to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.1 (2022-08-18)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.NetApp` to `Azure.ResourceManager.NetApp`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
