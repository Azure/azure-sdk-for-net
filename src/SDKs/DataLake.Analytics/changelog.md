## Microsoft.Azure.Management.DataLake.Analytics release notes

### Changes in 2.1.1-preview
- Update underlying AutoRest framework to the latest. This cleans up a lot of the generated code, making it easier to read.
- The property `FirewallAllowAzureIps` in the Account object is currently ignored by the service and will not have a value when calling get. This property will be enabled and honored by the service in a future update.

### Changes in 2.0.1-preview
- Add support for firewall rule management in Data Lake Analytics
- Remove minimum value requirements for Job parallelism. If a value < 1 is specified, it will use 1.
- Address minor documentation issues for methods and objects.

### Changes in 2.0.0
- As the first official stable release of the `Microsoft.Azure.Management.DataLake.Analytics` package, changes between this version and the preview version are enumerated below. 
    - All nested properties have been flattened down into their containing objects. For example: `myAccount.Properties.DefaultDataLakeStoreAccount` is now: `myAccount.DefaultDataLakeStoreAccount`
    -  Reorganized account management operations into three distinct operation groups: `Account`, `StorageAccounts` and `DataLakeStoreAccounts`. This results in changes to how certain operations are reached. For example, to get firewall rules previously this would be called: `myClient.Account.GetStorageAccount()`. Now: `myClient.StorageAccounts.Get()`.
    - All object properties have been updated to reflect whether they are required, optional or read-only (un-settable). This more explicitly helps the caller understand what they need to pass in and what they cannot pass in. As a result, there are some read-only properties that previously were not, and will need to be removed from object initialization.
    - Updates to include default values for some optional properties for objects. Please see class documentation for details on these defaults.
    - Added billing support for account creation and updates
    - Added support for CRUD of catalog credentials and initiated deprecation warnings for catalog secret CRUD, which will be removed in a future release.
    - As part of credential CRUD, added cascading delete support for a given credential, which will delete all other catalog resources dependent on the credential automatically.
    - Removed unsupported OData query options
    - Added new `SeverityType` enum values
    - Added deprecation warnings for `CreateSecret`,`UpdateSecret` and `DeleteSecret`
    - Fixed the return type for `UpdateSecret` to properly reflect that nothing is returned.
