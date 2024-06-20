# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: RedisEnterprise
namespace: Azure.ResourceManager.RedisEnterprise
require: https://github.com/Azure/azure-rest-api-specs/blob/ecc0170a2005f5f38231ae4dbba40594d3c00a04/specification/redisenterprise/resource-manager/readme.md
#tag: package-2024-02
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

rename-mapping:
  Cluster: RedisEnterpriseCluster
  ClusterList: RedisEnterpriseClusterList
  ClusterUpdate: RedisEnterpriseClusterUpdate
  ResourceState: RedisEnterpriseClusterResourceState
  Database: RedisEnterpriseDatabase
  DatabaseList: RedisEnterpriseDatabaseList
  AccessKeys: RedisEnterpriseDataAccessKeys
  AccessKeyType: RedisEnterpriseAccessKeyType
  Capability: RedisEnterpriseCapability
  ClusterPropertiesEncryptionCustomerManagedKeyEncryption: RedisEnterpriseCustomerManagedKeyEncryption
  ClusterPropertiesEncryptionCustomerManagedKeyEncryptionKeyIdentity: RedisEnterpriseCustomerManagedKeyEncryptionKeyIdentity
  CmkIdentityType: RedisEnterpriseCustomerManagedKeyIdentityType
  LocationInfo: RedisEnterpriseLocationInfo
  RegionSkuDetail: RedisEnterpriseRegionSkuDetail
  FlushParameters: FlushRedisEnterpriseDatabaseParameters
  ClusteringPolicy: RedisEnterpriseClusteringPolicy
  TlsVersion: RedisEnterpriseTlsVersion
  RegenerateKeyParameters: RedisEnterpriseRegenerateKeyParameters
  SkuName: RedisEnterpriseSkuName
  Sku: RedisEnterpriseSku
  PrivateLinkServiceConnectionState: RedisEnterprisePrivateLinkServiceConnectionState
  PrivateLinkResourceListResult: RedisEnterprisePrivateLinkResourceListResult
  PrivateLinkResource: RedisEnterprisePrivateLinkResource
  PrivateEndpointServiceConnectionStatus: RedisEnterprisePrivateEndpointServiceConnectionStatus
  PrivateEndpointConnectionProvisioningState: RedisEnterprisePrivateEndpointConnectionProvisioningState
  PrivateEndpointConnectionListResult: RedisEnterprisePrivateEndpointConnectionListResult
  PrivateEndpointConnection: RedisEnterprisePrivateEndpointConnection
  Persistence: RedisPersistenceSettings
  AofFrequency.1s: OneSecond
  AofFrequency: PersistenceSettingAofFrequency
  RdbFrequency.1h: OneHour
  RdbFrequency.6h: SixHours
  RdbFrequency.12h: TwelveHours
  RdbFrequency: PersistenceSettingRdbFrequency
  DatabasePropertiesGeoReplication: RedisEnterpriseDatabaseGeoReplication
  LinkedDatabase: RedisEnterpriseLinkedDatabase
  LinkState: RedisEnterpriseDatabaseLinkState
  ProvisioningState: RedisEnterpriseProvisioningStatus
  EvictionPolicy: RedisEnterpriseEvictionPolicy
  OperationStatus: RedisEnterpriseOperationStatus
  ExportClusterParameters: ExportRedisEnterpriseDatabaseParameters
  ImportClusterParameters: ImportRedisEnterpriseDatabaseParameters
  ForceUnlinkParameters: ForceUnlinkRedisEnterpriseDatabaseParameters
  Module: RedisEnterpriseModule
  Protocol: RedisEnterpriseClientProtocol
  Persistence.aofEnabled: IsAofEnabled
  Persistence.rdbEnabled: IsRdbEnabled
  Protocol.Plaintext: PlainText
  ForceUnlinkParameters.ids: -|arm-id
  ClusterPropertiesEncryptionCustomerManagedKeyEncryptionKeyIdentity.userAssignedIdentityResourceId: -|arm-id
  LinkedDatabase.id: -|arm-id
  OperationStatus.id: -|arm-id
  RegionSkuDetail.resourceType: -|resource-type

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

# mgmt-debug:
#   show-serialized-names: true

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
  Skus_List: GetRedisEnterpriseSkus

directive:
  - from: redisenterprise.json
    where: $.definitions
    transform: >
      $.OperationStatus.properties.error['x-ms-client-name'] = 'ErrorResponse';
      $.OperationStatus.properties.startTime['format'] = 'date-time';
      $.OperationStatus.properties.endTime['format'] = 'date-time';

```
