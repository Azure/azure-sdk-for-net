# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: RedisEnterprise
namespace: Azure.ResourceManager.RedisEnterprise
require: https://github.com/Azure/azure-rest-api-specs/blob/bab2f4389eb5ca73cdf366ec0a4af3f3eb6e1f6d/specification/redisenterprise/resource-manager/readme.md
tag: package-2022-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

rename-mapping:
  Cluster: RedisEnterpriseCluster
  ClusterList: RedisEnterpriseClusterList
  ClusterUpdate: RedisEnterpriseClusterUpdate
  ResourceState: RedisEnterpriseClusterResourceState
  Database: RedisEnterpriseDatabase
  DatabaseList: RedisEnterpriseDatabaseList
  AccessKeys: RedisEnterpriseDataAccessKeys
  AccessKeyType: RedisEnterpriseAccessKeyType
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

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

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
      $.LinkedDatabase.properties.id['x-ms-format'] = 'arm-id';
      $.ForceUnlinkParameters.properties.ids.items['x-ms-format'] = 'arm-id';
      $.OperationStatus.properties.id['x-ms-format'] = 'arm-id';
      $.OperationStatus.properties.startTime['format'] = 'date-time';
      $.OperationStatus.properties.endTime['format'] = 'date-time';

```
