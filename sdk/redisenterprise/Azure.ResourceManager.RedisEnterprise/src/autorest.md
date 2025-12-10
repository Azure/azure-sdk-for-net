# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: RedisEnterprise
namespace: Azure.ResourceManager.RedisEnterprise
require: https://github.com/Azure/azure-rest-api-specs/blob/4c5ec9b4e0b961799cc11f6051f240d18f093c38/specification/redisenterprise/resource-manager/Microsoft.Cache/RedisEnterprise/readme.md
tag: package-2025-07-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true
use-model-reader-writer: true
enable-bicep-serialization: true

# mgmt-debug:
#   show-serialized-names: true

rename-mapping:
  AccessKeys: RedisEnterpriseDataAccessKeys
  AccessKeyType: RedisEnterpriseAccessKeyType
  AccessPolicyAssignmentPropertiesUser.objectId: -|uuid
  AofFrequency.1s: OneSecond
  AofFrequency: PersistenceSettingAofFrequency
  Cluster: RedisEnterpriseCluster
  ClusteringPolicy: RedisEnterpriseClusteringPolicy
  ClusterList: RedisEnterpriseClusterList
  ClusterPropertiesEncryptionCustomerManagedKeyEncryption: RedisEnterpriseCustomerManagedKeyEncryption
  ClusterPropertiesEncryptionCustomerManagedKeyEncryptionKeyIdentity.userAssignedIdentityResourceId: -|arm-id
  ClusterPropertiesEncryptionCustomerManagedKeyEncryptionKeyIdentity: RedisEnterpriseCustomerManagedKeyEncryptionKeyIdentity
  ClusterUpdate: RedisEnterpriseClusterUpdate
  CmkIdentityType: RedisEnterpriseCustomerManagedKeyIdentityType
  Database: RedisEnterpriseDatabase
  DatabaseList: RedisEnterpriseDatabaseList
  DatabasePropertiesGeoReplication: RedisEnterpriseDatabaseGeoReplication
  EvictionPolicy: RedisEnterpriseEvictionPolicy
  ExportClusterParameters: ExportRedisEnterpriseDatabaseParameters
  FlushParameters: FlushRedisEnterpriseDatabaseParameters
  ForceUnlinkParameters.ids: -|arm-id
  ForceUnlinkParameters: ForceUnlinkRedisEnterpriseDatabaseParameters
  HighAvailability: RedisEnterpriseHighAvailability
  ImportClusterParameters: ImportRedisEnterpriseDatabaseParameters
  LinkedDatabase.id: -|arm-id
  LinkedDatabase: RedisEnterpriseLinkedDatabase
  LinkState: RedisEnterpriseDatabaseLinkState
  Module: RedisEnterpriseModule
  OperationStatus.id: -|arm-id
  OperationStatus: RedisEnterpriseOperationStatus
  Persistence.aofEnabled: IsAofEnabled
  Persistence.rdbEnabled: IsRdbEnabled
  Persistence: RedisPersistenceSettings
  PrivateEndpointConnection: RedisEnterprisePrivateEndpointConnection
  PrivateEndpointConnectionListResult: RedisEnterprisePrivateEndpointConnectionListResult
  PrivateEndpointConnectionProvisioningState: RedisEnterprisePrivateEndpointConnectionProvisioningState
  PrivateEndpointServiceConnectionStatus: RedisEnterprisePrivateEndpointServiceConnectionStatus
  PrivateLinkResource: RedisEnterprisePrivateLinkResource
  PrivateLinkResourceListResult: RedisEnterprisePrivateLinkResourceListResult
  PrivateLinkServiceConnectionState: RedisEnterprisePrivateLinkServiceConnectionState
  Protocol.Plaintext: PlainText
  Protocol: RedisEnterpriseClientProtocol
  ProvisioningState: RedisEnterpriseProvisioningStatus
  PublicNetworkAccess: RedisEnterprisePublicNetworkAccess
  RdbFrequency.12h: TwelveHours
  RdbFrequency.1h: OneHour
  RdbFrequency.6h: SixHours
  RdbFrequency: PersistenceSettingRdbFrequency
  RedundancyMode: RedisEnterpriseRedundancyMode
  RegenerateKeyParameters: RedisEnterpriseRegenerateKeyParameters
  ResourceState: RedisEnterpriseClusterResourceState
  Sku: RedisEnterpriseSku
  SkuName: RedisEnterpriseSkuName
  SkuDetails: RedisEnterpriseSkuDetails
  SkuDetailsList: RedisEnterpriseSkuDetailsList
  TlsVersion: RedisEnterpriseTlsVersion

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
  LFU: Lfu
  LRU: Lru
  TTL: Ttl
  OSS: Oss

override-operation-name:
  OperationsStatus_Get: GetRedisEnterpriseOperationsStatus

directive:
  - from: redisenterprise.json
    where: $.definitions
    transform: >
      $.OperationStatus.properties.error['x-ms-client-name'] = 'ErrorResponse';
      $.OperationStatus.properties.startTime['format'] = 'date-time';
      $.OperationStatus.properties.endTime['format'] = 'date-time';

```
