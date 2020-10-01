# Release History

## 11.0.0 (2020-06-01)
### REST API version
- This version targets REST API version 2020-05-01.

### Features
- Added `BatchAccountIdentity` property on `BatchAccount` for enabling system assigned identity when `Microsoft.KeyVault` is specified as the `BatchAccount` encryption property.

### Bug Fixes
- **[Breaking]** Convert the `PrivateEndpointConnection` update operation to a long running operation.

## 10.0.0 (2020-04-11)
### REST API version
- This version targets REST API version 2020-03-01.
- **[Warning]** It is not recommended to use this SDK version. Please update to 11.0.0 or greater.

### Features
- Added ability to access the Batch DataPlane API without needing a public DNS entry for the account via the new `PublicNetworkAccess` property on `BatchAccount`.
- Added new `PrivateLinkResource` and `PrivateEndpointConnection` resource types. These are both only used when the `PublicNetworkAccess` property on `BatchAccount` is set to `Disabled`.
  - When `PublicNetworkAccess` is set to `Disabled` a new `PrivateLinkResource` is visible in that account, which can be used to connect to the account using an ARM Private Endpoint in your VNET.
- Added new `PrivateEndpointConnections` property to `BatchAccount`, which displays the private endpoint connections associated with the account.
- Added ability to encrypt `ComputeNode` disk drives using the new `DiskEncryptionConfiguration` property of `VirtualMachineConfiguration`.
- **[Breaking]** The `Id` property of `ImageReference` can now only refer to a Shared Image Gallery image.
- **[Breaking]** Pools can now be provisioned without a public IP using the new `PublicIPAddressConfiguration` property of `NetworkConfiguration`.
  - The `PublicIPs` property of `NetworkConfiguration` has moved in to `PublicIPAddressConfiguration` as well. This property can only be specified if `IPAddressProvisioningType` is `UserManaged`.

## 9.0.0
### REST API version
- This version targets REST API version 2019-08-01.

### Features
- Added ability to specify a collection of public IPs on `NetworkConfiguration` via the new `PublicIPs` property. This guarantees nodes in the Pool will have an 
  IP from the list user provided IPs.
- Added ability to mount remote file-systems on each node of a pool via the `MountConfiguration` property on `Pool`.
- Shared Image Gallery images can now be specified on the `VirtualMachineImageId` property of `ImageReference` by referencing the image via its ARM ID.
- **[Breaking]** When not specified, the default value for `WaitForSuccess` on `StartTask` is now `true` (was `false`).
- **[Breaking]** When not specified, the default value for `Scope` on `AutoUserSpecification` is now always `Pool` (was `Task` on Windows nodes, `Pool` on Linux nodes).

## 8.0.0
### REST API version
- This version targets REST API version 2019-04-01.

### Features
- Added BatchAccount properties `DedicatedCoreQuotaPerVMFamily` and `DedicatedCoreQuotaPerVMFamilyEnforced` to facilitate the transition to per VM family quota
- **[Breaking]** Accounts created with `PoolAllocationMode` set to `UserSubscription` will not return core quota properties `DedicatedCoreQuota` or `LowPriorityCoreQuota`

## 7.0.0
### REST API version
- This version targets REST API version 2018-12-01.

### Features
- **[Breaking]** ResourceFile improvements
  - Added the ability specify an entire Azure Storage container in `ResourceFile`.
  - A new property `HttpUrl` replaces `BlobSource`. This can be any HTTP URL. Previously, this had to be an Azure Blob Storage URL.
  - When constructing a `ResourceFile` you can now choose from one of the following options:
    - `HttpUrl`: Specify an HTTP URL pointing to a specific file to download.
    - `StorageContainerUrl`: Specify an Azure Storage container URL. All blobs matching the `BlobPrefix` in the Storage container will be downloaded.
    - `AutoStorageContainerName`: Specify the name of a container in the Batch registered auto-storage account. All blobs matching the `BlobPrefix` in the Storage container will be downloaded.
- **[Breaking]** Removed `OSDisk` property from `VirtualMachineConfiguration`. This property is no longer supported.
- **[Breaking]** `Application` no longer has a `Packages` property, instead the packages can be retrieved via the new  `ApplicationPackage.List` API.
- **[Breaking]** `TargetOsVersion` is now `OsVersion`, and `CurrentOsVersion` is no longer supported on `CloudServiceConfiguration`.
- Added support on Windows pools for creating users with a specific login mode (either `Batch` or `Interactive`) via `WindowsUserConfiguration.LoginMode`.
- Added support for `ContainerConfiguration` when creating a pool.

### Bug fixes
- Deleting an account will no longer return `NotFound` at the end of the operation

## 6.0.0
### REST API version
- This version targets REST API version 2017-09-01.

### Features
- Adding support for Certificate and Pool operations.

## 5.1.0
### REST API version
- This version targets REST API version 2017-05-01.

### Features
- Added a new `CheckNameAvailability` API which allows you to check if an account name is available on a particular region.

## 5.0.0
### REST API version
- This version targets REST API version 2017-05-01.

### Features
#### Breaking changes
- BatchAccount `CoreQuota` renamed to `DedicatedCoreQuota`.
- The structure of `CloudError` has changed. It now has an `Error` property, and the error information (`code`, `message`, `target`, and `details`) is inside that property.
- The type `UpdateApplicationParameters` was renamed to `ApplicationUpdateParameters`.
- The type `AddApplicationParameters` was renamed to `ApplicationCreateParameters`.

#### Non-breaking changes
- BatchAccount now reports the low-priority core quota as well in the property `LowPriorityCoreQuota`.
- Added a new `Operations` API, which can be used to query the available operations.

### Packaging
- Now targets `netstandard1.4` instead of `netstandard1.5` and `netstandard1.1`.

## 4.2.0
- Added option to create a Batch account which allocates pool nodes in the user's subscription. This is done with `PoolAllocationMode = UserSubscription`. When using this mode, a `KeyVaultReference` must also be supplied.
- Changed classes which appear only in responses to be immutable.
- This version targets REST API version 2017-01-01.

## 4.1.0
- This package version had an issue and was unlisted on NuGet immediately after shipping. This version **should not be used**.

## 3.0.0
- Renamed `AccountResource` to `BatchAccount`.
- Renamed `AccountOperations` to `BatchAccountOperations`. The `IBatchManagementClient.Account` property was also renamed to `IBatchManagementClient.BatchAccount`.
- Split `Application` and `ApplicationPackage` operations up into two separate operation groups. 
- Updated `Application` and `ApplicationPackage` methods to use the standard `Create`, `Delete`, `Update` syntax. For example creating an `Application` is done via `ApplicationOperations.Create`.
- Renamed `SubscriptionOperations` to `LocationOperations` and changed `SubscriptionOperations.GetSubscriptionQuotas` to be `LocationOperations.GetQuotas`.
- This version targets REST API version 2015-12-01.

## 2.1.0
- Added support for .NETStandard.
- Fixed the .NETFramework 4.5 dependencies.
- This version targets REST API version 2015-12-01.