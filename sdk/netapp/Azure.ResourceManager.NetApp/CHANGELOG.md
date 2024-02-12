# Release History

## 1.5.0-beta.1 (Unreleased)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.4.2 (2023-11-29)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

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
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://docs.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
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

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
