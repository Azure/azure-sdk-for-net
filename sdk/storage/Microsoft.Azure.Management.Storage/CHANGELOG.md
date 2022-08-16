## Microsoft.Azure.Management.Storage release notes

### Changes in 25.0.0
- Upgrade to rest api version 2022-05-01.
- Support Create or Update Storage Account with AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions as 'AADKERB'.

**Breaking changes**

- new ActiveDirectoryProperties() parameter change: "domainGuid" moved from the 3rd to the 2nd parameter; "netBiosDomainName", "forestName", "domainSid", "azureStorageSid" changed from required to optional.
- new Encryption() parameter change: "keySource" changed from required to optional, and moved from the 1st to the 2nd parameter; "services" moved from the 2nd to the 1st parameter.

### Changes in 24.0.0
- Upgrade to rest api version 2021-09-01.
- Support create/update Storage account with new property dnsEndpointType.
- Support Storage account new access tier Premium.
- Support Storage account new readonly property storageAccountSkuConversionStatus.
- Support Storage account new readonly property Encryption.KeyVaultProperties.CurrentVersionedKeyExpirationTimestamp.
- Support ManagementPolicy action condition daysAfterCreationGreaterThan on base blob.
- Support ManagementPolicy action condition daysAfterLastTierChangeTimeGreaterThan, only apply to tierToArchive action.
- Support Blob service new property DeleteRetentionPolicy.AllowPermanentDelete.
- Support CORS rule AllowedMethods Patch. 
- Support table new property SignedIdentifiers.
- Support output BlobInventoryPolicySchema property Destination which can be input from old API version.
- Support blob inventory new filter IncludeDeleted, ExcludePrefix.
- Support blob inventory new blob SchemaFields: Tags, Etag, ContentType, ContentEncoding, ContentLanguage, ContentCRC64, CacheControl, ContentDisposition, LeaseStatus, LeaseState, LeaseDuration, ServerEncrypted, Deleted, DeletionId, DeletedTime, RemainingRetentionDays, ImmutabilityPolicyUntilDate, ImmutabilityPolicyMode, LegalHold, CopyId, CopyStatus, CopySource, CopyProgress, CopyCompletionTime, CopyStatusDescription, CustomerProvidedKeySha256, RehydratePriority, ArchiveStatus, XmsBlobSequenceNumber, EncryptionScope, IncrementalCopy, TagCount.
- Support blob inventory new container SchemaFields: Etag, DefaultEncryptionScope, DenyEncryptionScopeOverride, ImmutableStorageWithVersioningEnabled, Deleted, Version, DeletedTime, RemainingRetentionDays.

**Breaking changes**

- StorageManagementClient.LocalUsers.List() output type change from LocalUsers to IEnumerable<LocalUser>.

### Changes in 23.1.0
- Upgrade to rest api version 2021-08-01.
- Support create/update Storage account with enable/disable Sftp and Localuser.
- Support CreateOrUpdate/Delete/Get/List/ListKeys/RegeneratePassword on Storage account local users.
- Support create/update account with AllowedCopyScope.
- Support create/update account with 2 new ActiveDirectoryProperties: samAccountName, accountType.
- Support create/update account with new EncryptionIdentity: FederatedIdentityClientId.

### Changes in 23.0.0
- Upgrade to rest api version 2021-06-01.
- Support Storage account HierarchicalNamespace migration.
- Support create/update Storage account with enable/disable PublicNetworkAccess.
- Support create/update account with ImmutableStorageWithVersioning.
- Support create/update account with defaultToOAuthAuthentication.
- Support blob Inventory new schema fields: AccessTierInferred and Tags.
- Support create/update Blob Container with enableNfsV3RootSquash and enableNfsV3AllSquash.
- Support AllowProtectedAppendWritesAll in set container ImmutabilityPolicy and set container LegalHold.

**Breaking changes**

- Remove StorageFileDataSmbShareOwner from Microsoft.Azure.Management.Storage.Models.DefaultSharePermission.
- In StorageManagementClient.BlobContainers.CreateOrUpdateImmutabilityPolicy(), StorageManagementClient.BlobContainers.ExtendImmutabilityPolicy(), add a madatory parameter with type Microsoft.Azure.Management.Storage.Models.ImmutabilityPolicy, to input all ImmutabilityPolicy properties, and remove 2 parameters to input ImmutabilityPolicy properties: immutabilityPeriodSinceCreationInDays, allowProtectedAppendWrites.
- In Microsoft.Azure.Management.Storage.Models.AccessPolicy, rename Start to StartTime, Expiry to ExpiryTime.

### Changes in 22.0.0
- Upgrade to rest api version 2021-04-01.
- Support File Share lease and delete share with leased share snapshots.
- Support File Share access policy
- Support Blob Container with ImmutableStorageWithVersioning enabled.
- Support new account property AllowCrossTenantReplication
- Support DefaultSharePermission
- Support Blob Inventory GA policy

**Breaking changes**

- BlobInventoryPolicySchema property Destination is removed, and Destination is added to BlobInventoryPolicyRule.
- Following Enum are removed: PutSharesExpand, GetShareExpand, ListSharesExpand. Need to input the expand string in Put/Get/List file share API according to the parameter description.

### Changes in 21.0.0

**Breaking changes**

- StorageAccount.KeyCreationTime type change from Dictionary to 'Microsoft.Azure.Management.Storage.Models.KeyCreationTime'.

### Changes in 20.0.0
- Upgrade to rest api version 2021-02-01.
- Support KeyPolicy,SasPolicy in create/update Storage account.
- Added a new property "CreationTime" to Microsoft.Azure.Management.Storage.Models.StorageAccountKey object.

**Breaking changes**

- StorageManagementClient.FileShares.List() parameter "expand" type change to enum to string.
- StorageManagementClient.FileShares.Create() parameter "expand" type change to enum to string.

### Changes in 19.0.0
- Upgrade to rest api version 2021-01-01
- Support create/get/delete/list File share snapshot
- Support ChangeFeed.RetentionInDays
- Support User Identity in create and update Storage account
- Support RequireInfrastructureEncryption in create Encryption Scope
- Add 2 new properties to Encryption Scope KeyVaultProperties: CurrentVersionedKeyIdentifier, LastKeyRotationTimestamp
- Support add ManagementPolicy action to blob version
- Support ManagementPolicy action TierToCool, TierToArchive on blob snapshot.
- Support add ManagementPolicy with filter blob type as AppendBlob
- Support Update File Service properties with SMB settings: Versions, AuthenticationMethods, KerberosTicketEncryption, ChannelEncryption
- Support EnableNfsV3 in create Storage account
- Support AllowSharedKeyAccess in create/update Storage account

**Breaking changes**

- StorageManagementClient.StorageAccounts.ListByResourceGroup() output type change from IEnumerable<StorageAccount> to IPage<StorageAccount>, to support list account with nextlink.
- Microsoft.Azure.Management.Storage.Models.StorageAccountUpdateParameters.Identity.Type, Microsoft.Azure.Management.Storage.Models.StorageAccountCreateParameters.Identity.Type have default single value as IdentityType.SystemAssigned before. Now must assign value to be used in create or update storage account, since it support multiple value now.
- Microsoft.Azure.Management.Storage.Models.VirtualNetworkRule.State type change from enum to string.

### Changes in 18.0.0-beta
- Upgrade to rest api version 2020-08-01-preview
- Support enanble ContainerDeleteRetentionPolicy in BlobServices properties
- Support enable LastAccessTimeTrackingPolicy in BlobServices properties
- Support DaysAfterLastAccessTimeGreaterThan,EnableAutoTierToHotFromCool in ManagementPolicy BaseBlob Actions
- Support List deleted containers
- Support enable ProtocolSettings.Smb.Multichannel on FileServices properties
- Support ResourceAccessRule in Microsoft.Azure.Management.Storage.Models.NetworkRuleSet
- Support Set ExtendedLocation in create storage account
- Support Blob Inventory rule of storage account

**Breaking changes**

- In StorageManagementClient.FileServices.SetServiceProperties(), add a madatory parameter with type Microsoft.Azure.Management.Storage.Models.FileServiceProperties, to input all FileService properties, and remove 2 parameters to input FileService properties: cors， shareDeleteRetentionPolicy.

### Changes in 17.2.0
- Update BlobServiceProperties.RestorePolicy: add new property "MinRestoreTime", deprecate old property "LastEnabledTime"

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