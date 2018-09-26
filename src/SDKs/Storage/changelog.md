## Microsoft.Azure.Management.Storage release notes

### Changes in 9.0.0-preview

- Upgrade to rest api version 2018-07-01 (ManagementPolicies API still use 2018-03-01-preview)
- Support Create Storage Account with kind FileStorage, BlockBlobStorage and Sku Premium_ZRS
- Support Create or Upgrade Storage Account with Property EnableAzureFilesAadIntegration

**Breaking changes**

- Rename StorageManagementClient.StorageAccounts.CreateOrUpdateManagementPolicies() to StorageManagementClient.ManagementPolicies.CreateOrUpdate()
- Rename StorageManagementClient.StorageAccounts.GetManagementPolicies() to StorageManagementClient.ManagementPolicies.Get()
- Rename StorageManagementClient.StorageAccounts.DeleteManagementPolicies() to StorageManagementClient.ManagementPolicies.Delete()
- StorageManagementClient.Usages.List() is removed, as api version 2018-07-01 not support get global storage resource usage, and only support get storage resource usage by location with StorageManagementClient.Usages.ListByLocation().

### Changes in 8.1.0-preview

- Support HDFS feature 

### Changes in 8.0.0-preview

- Support Management Policy feature 
- Upgrade to rest api version 2018-03-01-preview

**Breaking changes**

- Rename StorageManagementClient.Usage to StorageManagementClient.Usages
- Rename StorageManagementClient.Usage.List() to StorageManagementClient.Usages.List()
- Rename StorageManagementClient.Usage.ListByLocation() to StorageManagementClient.Usages.ListByLocation()

### Changes in 7.2.0-preview

- Support WORM feature
- Add StorageManagementClient.Usage.ListByLocation() to support get storage resource usage by location
- Upgrade to rest api version 2018-02-01

### Changes in 7.1.0-preview

- Support Create or Upgrade Storage Account with kind StorageV2

### Changes in 7.0.0-preview

**Breaking changes**

- When updating storage virtual networks, NetworkRuleSet is used instead of NetworkAcl.

**Notes**

- When updating storage virtual networks, virtualNetworkResourceId is limited to be resource ID of a subnet.
- Added Skus.list() operation, which could list all the available skus for the subscription. 