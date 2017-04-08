## Microsoft.Azure.Management.Batch release notes

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