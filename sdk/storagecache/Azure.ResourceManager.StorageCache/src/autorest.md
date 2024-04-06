# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: StorageCache
namespace: Azure.ResourceManager.StorageCache
require: https://github.com/Azure/azure-rest-api-specs/blob/907b79c0a6a660826e54dc1f16ea14b831b201d2/specification/storagecache/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true
use-model-reader-writer: true

rename-mapping:
  Cache.properties.mountAddresses: -|ip-address
  Cache: StorageCache
  CacheActiveDirectorySettings.primaryDnsIpAddress: -|ip-address
  CacheActiveDirectorySettings.secondaryDnsIpAddress: -|ip-address
  CacheNetworkSettings.utilityAddresses: -|ip-address
  CacheNetworkSettings.dnsServers: -|ip-address
  CacheUpgradeSettings.upgradeScheduleEnabled: EnableUpgradeSchedule
  CacheUsernameDownloadSettings.extendedGroups: EnableExtendedGroups
  CacheUsernameDownloadSettingsCredentials.bindDn: BindDistinguishedName
  CacheEncryptionSettings.rotationToLatestKeyVersionEnabled: EnableRotationToLatestKeyVersion
  NfsAccessRule.suid: AllowSuid
  NfsAccessRule.submountAccess: AllowSubmountAccess
  NfsAccessRule.rootSquash: EnableRootSquash
  NfsAccessRuleAccess.ro: ReadOnly
  NfsAccessRuleAccess.rw: ReadWrite
  CacheActiveDirectorySettings: StorageCacheActiveDirectorySettings
  CacheActiveDirectorySettingsCredentials: StorageCacheActiveDirectorySettingsCredentials
  CacheDirectorySettings: StorageCacheDirectorySettings
  CacheEncryptionSettings: StorageCacheEncryptionSettings
  CacheHealth: StorageCacheHealth
  CacheNetworkSettings: StorageCacheNetworkSettings
  CacheSecuritySettings: StorageCacheSecuritySettings
  CacheSku: StorageCacheSkuInfo
  CachesListResult: StorageCachesResult
  CacheUpgradeSettings: StorageCacheUpgradeSettings
  CacheUpgradeStatus: StorageCacheUpgradeStatus
  CacheUsernameDownloadSettings: StorageCacheUsernameDownloadSettings
  CacheUsernameDownloadSettingsCredentials: StorageCacheUsernameDownloadCredential
  Condition: OutstandingCondition
  FirmwareStatusType: StorageCacheFirmwareStatusType
  HealthStateType: StorageCacheHealthStateType
  KeyVaultKeyReference: StorageCacheEncryptionKeyVaultKeyReference
  PrimingJobIdParameter: PrimingJobContent
  ProvisioningStateType: StorageCacheProvisioningStateType
  OperationalStateType: StorageTargetOperationalStateType
  ReasonCode: StorageCacheRestrictionReasonCode
  Restriction: StorageCacheRestriction
  ResourceSku: StorageCacheSku
  ResourceSkuCapabilities: StorageCacheSkuCapability
  ResourceSkuLocationInfo: StorageCacheSkuLocationInfo
  ResourceSkusResult: StorageCacheSkusResult
  ResourceUsage: StorageCacheUsage
  ResourceUsageName: StorageCacheUsageName
  ResourceUsagesListResult: StorageCacheUsagesResult
  UsageModel: StorageCacheUsageModel
  UsageModelDisplay: StorageCacheUsageModelDisplay
  UsageModelsResult: StorageCacheUsageModelsResult
  UsernameSource: StorageCacheUsernameSourceType
  UsernameDownloadedType: StorageCacheUsernameDownloadedType
  Nfs3Target.verificationTimer: VerificationDelayInSeconds
  Nfs3Target.writeBackTimer: WriteBackDelayInSeconds
  BlobNfsTarget.verificationTimer: VerificationDelayInSeconds
  BlobNfsTarget.writeBackTimer: WriteBackDelayInSeconds

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

acronym-mapping:
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
  AmlFilesystem: AmlFileSystem

override-operation-name:
  Caches_SpaceAllocation: UpdateSpaceAllocation
  StorageTargets_DnsRefresh: RefreshDns
  AscUsages_List: GetStorageCacheUsages
  Skus_List: GetStorageCacheSkus
  Caches_DebugInfo: EnableDebugInfo

directive:
  - remove-operation: AscOperations_Get
  - rename-operation:
      from: StorageTarget_Flush
      to: StorageTargets_Flush
  - rename-operation:
      from: StorageTarget_Suspend
      to: StorageTargets_Suspend
  - rename-operation:
      from: StorageTarget_Resume
      to: StorageTargets_Resume
  - rename-operation:
      from: StorageTarget_Invalidate
      to: StorageTargets_Invalidate
  - from: storagecache.json
    where: $.definitions
    transform: >
      $.Cache.properties.properties.properties.subnet = {
            'description': 'Subnet used for the Cache.',
            'type': 'string',
            'x-ms-format': 'arm-id',
            'x-ms-mutability': [
              'read',
              'create'
            ]
        };
      $.BlobNfsTarget.properties.target = {
            'description': 'Resource ID of the storage container.',
            'type': 'string',
            'x-ms-format': 'arm-id',
            'x-ms-mutability': [
              'read',
              'create'
            ]
        };
      $.ClfsTarget.properties.target = {
            'description': 'Resource ID of storage container.',
            'type': 'string',
            'x-ms-format': 'arm-id',
            'x-ms-mutability': [
              'read',
              'create'
            ]
        };
      $.PrimingJob.properties.primingManifestUrl = {
            'description': 'The URL for the priming manifest file to download. This file must be readable from the HPC Cache. When the file is in Azure blob storage the URL should include a Shared Access Signature (SAS) granting read permissions on the blob.',
            'type': 'string',
            'x-ms-mutability': [
              'create'
            ],
            'x-ms-secret': true
        };

```
