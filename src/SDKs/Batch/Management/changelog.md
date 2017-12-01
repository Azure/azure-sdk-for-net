## Microsoft.Azure.Management.Batch release notes

### Changes in 6.0.0
#### REST API version
- This version targets REST API version 2017-09-01.
- Adding support for Certificate and Pool operations.

### Changes in 5.1.0
#### REST API version
- This version targets REST API version 2017-05-01.

#### Features
- Added a new `CheckNameAvailability` API which allows you to check if an account name is available on a particular region.

### Changes in 5.0.0
#### REST API version
- This version targets REST API version 2017-05-01.

#### Features
##### Breaking changes
- BatchAccount `CoreQuota` renamed to `DedicatedCoreQuota`.
- The structure of `CloudError` has changed. It now has an `Error` property, and the error information (`code`, `message`, `target`, and `details`) is inside that property.
- The type `UpdateApplicationParameters` was renamed to `ApplicationUpdateParameters`.
- The type `AddApplicationParameters` was renamed to `ApplicationCreateParameters`.

##### Non-breaking changes
- BatchAccount now reports the low-priority core quota as well in the property `LowPriorityCoreQuota`.
- Added a new `Operations` API, which can be used to query the available operations.

#### Packaging
- Now targets `netstandard1.4` instead of `netstandard1.5` and `netstandard1.1`.

### Changes in 4.2.0
- Added option to create a Batch account which allocates pool nodes in the user's subscription. This is done with `PoolAllocationMode = UserSubscription`. When using this mode, a `KeyVaultReference` must also be supplied.
- Changed classes which appear only in responses to be immutable.
- This version targets REST API version 2017-01-01.

### Changes in 4.1.0
- This package version had an issue and was unlisted on NuGet immediately after shipping. This version **should not be used**.

### Changes in 3.0.0
- Renamed `AccountResource` to `BatchAccount`.
- Renamed `AccountOperations` to `BatchAccountOperations`. The `IBatchManagementClient.Account` property was also renamed to `IBatchManagementClient.BatchAccount`.
- Split `Application` and `ApplicationPackage` operations up into two separate operation groups. 
- Updated `Application` and `ApplicationPackage` methods to use the standard `Create`, `Delete`, `Update` syntax. For example creating an `Application` is done via `ApplicationOperations.Create`.
- Renamed `SubscriptionOperations` to `LocationOperations` and changed `SubscriptionOperations.GetSubscriptionQuotas` to be `LocationOperations.GetQuotas`.
- This version targets REST API version 2015-12-01.

### Changes in 2.1.0
- Added support for .NETStandard.
- Fixed the .NETFramework 4.5 dependencies.
- This version targets REST API version 2015-12-01.