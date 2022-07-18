# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
namespace: Azure.ResourceManager.Storage
require: https://github.com/Azure/azure-rest-api-specs/blob/a9e895ccfe29d0646795f7ff1cb78e185bd09529/specification/storage/resource-manager/readme.md
tag: package-2021-09
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

list-exception:
- /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}

override-operation-name:
  StorageAccounts_CheckNameAvailability: CheckStorageAccountNameAvailability

request-path-to-singleton-resource:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}: managementPolicies/default
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}: inventoryPolicies/default

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  '*Guid': 'uuid'

rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs|ips
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  Vmos: VmOS
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4|ipv4
  Ipv6: IPv6|ipv6
  Ipsec: IPsec|ipsec
  SSO: Sso
  URI: Uri
  Etag: ETag|etag
  SAS: Sas
  SKU: Sku
  SMB: Smb
  NFS: Nfs
  LRS: Lrs
  ZRS: Zrs
  GRS: Grs
  TLS: Tls

prepend-rp-prefix:
- CorsRules
- CorsRule
- CustomDomain
- DnsEndpointType
- ListKeyExpand
- MinimumTlsVersion
- ProvisioningState
- PermissionScope
- SshPublicKey
- PublicNetworkAccess
- PublicAccess
- RoutingPreference
- RoutingChoice
- UsageName
- UsageUnit

rename-mapping:
  BlobServiceProperties: BlobService
  QueueServiceProperties: QueueService
  FileServiceProperties: FileService
  TableServiceProperties: TableService
  StorageAccountCheckNameAvailabilityParameters: StorageAccountNameAvailabilityContent
  Multichannel.enabled: IsMultiChannelEnabled
  DeletedAccount.properties.creationTime: createOn
  DeletedAccount.properties.deletionTime: deleteOn
  StorageAccount.properties.creationTime: createOn
  StorageAccount.properties.deletionTime: deleteOn
  AccessPolicy.expiryTime: expireOn
  AccountStatus: StorageAccountStatus
  ResourceAccessRule: StorageAccountResourceAccessRule
  NetworkRuleSet: StorageAccountNetworkRuleSet
  VirtualNetworkRule: StorageAccountVirtualNetworkRule
  IPRule: StorageAccountIPRule
  Action: StorageAccountNetworkRuleAction
  State: StorageAccountNetworkRuleState
  Bypass: StorageNetworkBypass
  DefaultAction: StorageNetworkDefaultAction
  EnabledProtocols: FileShareEnabledProtocol
  FileShare.properties.enabledProtocols: enabledProtocol
  Encryption: StorageAccountEncryption
  EncryptionIdentity: StorageAccountEncryptionIdentity
  EncryptionServices: StorageAccountEncryptionServices
  EncryptionService: StorageEncryptionService
  EncryptionService.enabled: IsEnabled
  Endpoints: StorageAccountEndpoints
  KeySource: StorageAccountKeySource
  KeyType: StorageKeyType
  KeyPolicy: StorageAccountKeyPolicy
  KeyPermission: StorageAccountKeyPermission
  KeyCreationTime: StorageAccountKeyCreationTime
  KeyVaultProperties: StorageAccountKeyVaultProperties
  Format: BlobInventoryPolicyFormat
  Schedule: BlobInventoryPolicySchedule
  ObjectType: BlobInventoryPolicyObjectType
  LastAccessTimeTrackingPolicy.enable: IsEnabled
  HttpProtocol: StorageAccountHttpProtocol
  Name: LastAccessTimeTrackingPolicyName
  BlobContainer.properties.leaseDuration: LeaseDuration
  FileShare.properties.leaseDuration: LeaseDuration
  ManagementPolicyRule.enabled: IsEnabled
  RuleType: ManagementPolicyRuleType
  Permissions: AccountSasPermission
  Services: AccountSasSignedService
  AccountSasParameters.signedExpiry: SharedAccessExpireOn
  SignedResourceTypes: AccountSasSignedResourceType
  SignedResource: ServiceSasSignedResourceType
  Reason: StorageAccountNameUnavailableReason
  Restriction: StorageSkuRestriction
  ReasonCode: StorageRestrictionReasonCode
  SKUCapability: StorageSkuCapability
  RestorePolicyProperties.enabled: IsEnabled
  SasPolicy: StorageAccountSasPolicy
  ShareAccessTier: FileShareAccessTier
  TagFilter: ManagementPolicyTagFilter
  TagFilter.op: Operator
  TagProperty: LegalHoldTag
  AccessTier: StorageAccountAccessTier
  StorageAccountSkuConversionStatus.startTime: StartOn
  StorageAccountSkuConversionStatus.endTime: EndOn
  SkuConversionStatus: StorageAccountSkuConversionState
  PrivateLinkResource: StoragePrivateLinkResourceData
  MigrationState: ImmutableStorageWithVersioningMigrationState
  AccessPolicy: StorageServiceAccessPolicy
  ChangeFeed: BlobServiceChangeFeed
  ChangeFeed.enabled: IsEnabled
  CheckNameAvailabilityResult: StorageAccountNameAvailabilityResult
  CheckNameAvailabilityResult.nameAvailable: IsNameAvailable
  BlobContainer.properties.deleted: IsDeleted
  BlobServiceProperties.properties.automaticSnapshotPolicyEnabled: IsAutomaticSnapshotPolicyEnabled
  FileShare.properties.deleted: IsDeleted
  DeleteRetentionPolicy.enabled: IsEnabled
  ImmutableStorageAccount.enabled: IsEnabled
  ImmutableStorageWithVersioning.enabled: IsEnabled
  BlobInventoryPolicyRule.enabled: IsEnabled
  BlobInventoryPolicySchema.enabled: IsEnabled
  ActiveDirectoryPropertiesAccountType: ActiveDirectoryAccountType
  StorageAccount.properties.failoverInProgress: IsFailoverInProgress
  StorageAccount.properties.isNfsV3Enabled: IsNfsV3Enabled
  StorageAccountCreateParameters.properties.isNfsV3Enabled: IsNfsV3Enabled
  StorageAccount.properties.defaultToOAuthAuthentication: IsDefaultToOAuthAuthentication
  StorageAccountCreateParameters.properties.defaultToOAuthAuthentication: IsDefaultToOAuthAuthentication
  StorageAccountUpdateParameters.properties.defaultToOAuthAuthentication: IsDefaultToOAuthAuthentication
  CustomDomain.useSubDomainName: IsUseSubDomainNameEnabled
  RoutingPreference.publishMicrosoftEndpoints: IsMicrosoftEndpointsPublished
  RoutingPreference.publishInternetEndpoints: IsInternetEndpointsPublished

directive:
  - from: swagger-document
    where: $.definitions.FileShareItems.properties.value.items["$ref"]
    transform: return "#/definitions/FileShare"
  - from: swagger-document
    where: $.definitions.ListContainerItems.properties.value.items["$ref"]
    transform: return "#/definitions/BlobContainer"
  - from: swagger-document
    where: $.definitions.ListQueueResource.properties.value.items["$ref"]
    transform: return "#/definitions/StorageQueue"
  - from: swagger-document
    where: $.definitions.BlobRestoreParameters
    transform: >
      $.required = ["timetoRestore", "blobRanges"];
      for (var key in $.properties) {
          var property = $.properties[key];
          delete $.properties[key];
          if (key === 'timeToRestore') {
              $.properties['timetoRestore'] = property;
              $.properties['timetoRestore']['x-ms-client-name'] = 'timeToRestore';
          }
          else{
              $.properties[key] = property;
          }
      }
  # assigning formats
  - from: swagger-document
    where: $.definitions.StorageAccountCheckNameAvailabilityParameters.properties.type
    transform: $["x-ms-format"] = "resource-type";
  - from: swagger-document
    where: $.definitions.DeletedAccountProperties.properties.storageAccountResourceId
    transform: $["x-ms-format"] = "arm-id";
  - from: swagger-document
    where: $.definitions.DeletedAccountProperties.properties.creationTime
    transform: $["format"] = "date-time";
  - from: swagger-document
    where: $.definitions.DeletedAccountProperties.properties.deletionTime
    transform: $["format"] = "date-time";
  - from: swagger-document
    where: $.definitions.StorageAccountProperties.properties.primaryLocation
    transform: $["x-ms-format"] = "azure-location";
  - from: swagger-document
    where: $.definitions.StorageAccountProperties.properties.secondaryLocation
    transform: $["x-ms-format"] = "azure-location";
  - from: swagger-document
    where: $.definitions.StorageAccountSkuConversionStatus.properties.startTime
    transform: $["format"] = "date-time";
  - from: swagger-document
    where: $.definitions.StorageAccountSkuConversionStatus.properties.endTime
    transform: $["format"] = "date-time";
  - from: swagger-document
    where: $.definitions.PrivateLinkResourceProperties.properties.groupId
    transform: $["x-ms-format"] = "arm-id";
  - from: swagger-document
    where: $.definitions.ResourceAccessRule.properties.resourceId
    transform: $["x-ms-format"] = "arm-id";
  - from: swagger-document
    where: $.definitions.VirtualNetworkRule.properties.id
    transform: $["x-ms-format"] = "arm-id";
  - from: swagger-document
    where: $.definitions.Encryption
    transform: $.required = undefined; # this is a fix for swagger issue, and it should be resolved in azure-rest-api-specs/pull/19357
```
