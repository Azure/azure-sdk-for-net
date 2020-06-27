## Microsoft.Azure.Management.Storage release notes

### Changes in 17.1.0

- Support Create or Update Storage Account with MinimumTlsVersion, AllowBlobPublicAccess

### Changes in 17.0.0

- Support Table and Queue create/get/list/remove
- Support list deleted blob containers
- Support create/update File share with access tier

**Breaking changes**

- The type of Microsoft.Azure.Management.Storage.Models.FileShare.ShareUsageBytes change from int? to long?.

### Changes in 16.0.0

- Support TagFilter in ManagementPolicy
- Support enable File share soft delete in File service properties, list shares include deleted shares, and restore deleted share
- Support create File share with EnabledProtocols, RootSquash, AccessTier
- Support Update File share with RootSquash, AccessTier
- Support get File share with ShareUsageBytes

**Breaking changes**

- In StorageManagementClient.FileShares.Create(), StorageManagementClient.FileShares.Update(), add a madatory parameter with type Microsoft.Azure.Management.Storage.Models.FileShare, to input all share properties, and remove 2 parameters to input share properties: metadata, shareQuota.

### Changes in 15.1.0
- Support create/update/remove/get/list Object Replication Policy on Storage account

### Changes in 15.0.0

- Support create blob contaienr with EncryptionScope
- In get Storage Account, return 2 new properties: CurrentVersionedKeyIdentifier, LastKeyRotationTimestamp, in returned account Encryption KeyVaultProperties

**Breaking changes**

- In StorageManagementClient.BlobContainers.Create(), StorageManagementClient.BlobContainers.Update(), add a madatory parameter with type Microsoft.Azure.Management.Storage.Models.BlobContainer, to input all container properties, and remove 2 parameters to input container properties: metadata, publicAccess.

### Changes in 14.5.0

- Support allowProtectedAppendWrites in blob container ImmutabilityPolicy
- Support create/update/get/list EncryptionScope

### Changes in 14.4.0

- Support Point In Time Restore, to restore blob ranges

### Changes in 14.3.0

- Support Queue/Table Encyrtpion Keytype when create Storage account

### Changes in 14.2.0

- Change the maximum limitation for share size from 100000(GiB) to 102400(GiB)

### Changes in 14.1.0

- Change the maximum limitation for share size from 5120(GiB) to 100000(GiB)
- Add Sku to Blob Service Properties
- Support Share Delete Retention Policy on File Service Properties

### Changes in 14.0.0

- StorageAccounts.GetProperties() will also return PrivateEndpointConnections of the Stroage account
- Support Get/Put one PrivateEndpointConnection of a Stroage account
- Support List PrivateLinkResources of a Stroage account

**Breaking changes**

- Remove parameter "skipToken" from BlobContainers.List()

### Changes in 13.3.0

- Support enable Files Azure Active Directory Domain Service Authentication when create or update Storage account
- Support regenerateKey for Kerberos keys on Storage account
- Support list Kerberos keys on Storage account

### Changes in 13.2.0

- Support set LargeFileSharesState as Enabled on Create or Update Storage account
- Support list Storage Account with NextPageLink

### Changes in 13.1.0

- Support Create/Get/List/Delete File share
- Support Get/Set File service properties 

### Changes in 13.0.0

- Add back StorageManagementClient constructor that takes HttpClient as a parameter
- Support List Blob Service on a Storage account

**Breaking changes**

- ManagementPolicy child property type DateAfterModification.DaysAfterModificationGreaterThan, DateAfterCreation.DaysAfterCreationGreaterThan, changed from int to double.
- Class ListContainerItems is removed, since BlobContainers.List() return value type change from ListContainerItems to IPage<ListContainerItem>.

### Changes in 12.0.0

- Support Create or Update Storage Account with AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions as 'AADDS' or 'None'.

**Breaking changes**

- Remove StorageAccount property: EnableAzureFilesAadIntegration.
- BlobContainers.List() return value type change from ListContainerItems to IPage<ListContainerItem>.

### Changes in 11.0.0

- Upgrade to rest api version 2019-04-01
- Support Revoke UserDelegationKeys on a specified Storage account
- Support Enable/Disable Automatic Snapshot Policy on Blob Service Properties of a specified Storage account 
- Support Create or Update Storage Account with Sku Standard_GZRS and Standard_RAGZRS

**Breaking changes**

- Change the type of StorageAccount.Kind, StorageAccountCreateParameters.Kind, StorageAccountUpdateParameters.Kind, from enum to string.
- Change the type of StorageAccount.Sku.Name, StorageAccountCreateParameters.Sku.Name, StorageAccountUpdateParameters.Sku.Name, from enum to string.

### Changes in 10.0.0

- Microsoft.Azure.Management.Storage SDK is GA
- Upgrade to rest api version 2018-11-01

**Breaking changes**

- Change input parameter of StorageManagementClient.ManagementPolicies.CreateOrUpdate(), the input policy change from Json to ManagementPolicySchema object
- Change output of StorageManagementClient.StorageAccounts.GetManagementPolicies(), the output policy change from Json to ManagementPolicySchema object

### Changes in 9.2.0-preview

- Add "CanFailover" to Storage Account Expend Property GeoReplicationStats

**Breaking changes**

- Change StorageAccountCreateParameters.CustomDomain.UseSubDomain to StorageAccountCreateParameters.CustomDomain.UseSubDomainName
- Change StorageAccountUpdateParameters.CustomDomain.UseSubDomain to StorageAccountUpdateParameters.CustomDomain.UseSubDomainName

### Changes in 9.1.0-preview

- Support trigger Storage Account Failover on RA-GRS accounts, in case of availability issues.
- Support expand the properties of get Storage Accounts, to get Account geoReplicationStats.

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