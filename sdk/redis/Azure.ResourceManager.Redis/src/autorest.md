# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Redis
namespace: Azure.ResourceManager.Redis
require: https://github.com/Azure/azure-rest-api-specs/blob/9069559e0fe5ed52b884ddc658fa539ec67c7ef8/specification/redis/resource-manager/readme.md
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

rename-mapping:
  CheckNameAvailabilityParameters: RedisNameAvailabilityContent
  RedisCommonPropertiesRedisConfiguration: RedisCommonConfiguration
  RedisCommonPropertiesRedisConfiguration.authnotrequired: AuthNotRequired
  RedisCommonPropertiesRedisConfiguration.maxclients: MaxClients
  RedisCommonPropertiesRedisConfiguration.maxmemory-delta: MaxMemoryDelta
  RedisCommonPropertiesRedisConfiguration.maxmemory-reserved: MaxMemoryReserved
  RedisCommonPropertiesRedisConfiguration.maxmemory-policy: MaxMemoryPolicy
  RedisCommonPropertiesRedisConfiguration.maxfragmentationmemory-reserved: MaxFragmentationMemoryReserved
  PrivateEndpointConnection.properties.privateLinkServiceConnectionState: RedisPrivateLinkServiceConnectionState
  PrivateEndpointConnection.properties.provisioningState: RedisProvisioningState
  SkuFamily.C: BasicOrStandard
  SkuFamily.P: Premium
  ScheduleEntries: RedisPatchScheduleSettings
  ScheduleEntry: RedisPatchScheduleSetting
  DefaultName: RedisPatchScheduleDefaultName
  UpgradeNotification: RedisUpgradeNotification
  NotificationListResponse: RedisUpgradeNotificationListResponse
  RedisKeyType: RedisRegenerateKeyType
  ReplicationRole: RedisLinkedServerRole
  RedisCommonPropertiesRedisConfiguration.rdb-backup-enabled: IsRdbBackupEnabled|boolean
  RedisCommonPropertiesRedisConfiguration.aof-backup-enabled: IsAofBackupEnabled|boolean
  RedisCommonPropertiesRedisConfiguration.rdb-backup-max-snapshot-count: -|integer
  RedisForceRebootResponse: RedisForceRebootResult
  RedisCacheAccessPolicyAssignment.properties.objectId: -|uuid
  RedisCommonPropertiesRedisConfiguration.aad-enabled: IsAadEnabled
  Redis.properties.disableAccessKeyAuthentication: IsAccessKeyAuthenticationDisabled
  RedisCreateParameters.properties.disableAccessKeyAuthentication: IsAccessKeyAuthenticationDisabled
  RedisUpdateParameters.properties.disableAccessKeyAuthentication: IsAccessKeyAuthenticationDisabled

prepend-rp-prefix:
  - OperationStatus
  - ProvisioningState
  - PublicNetworkAccess
  - RebootType
  - TlsVersion
  - DayOfWeek

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'staticIP': 'ip-address'
  'startIP': 'ip-address'
  'endIP': 'ip-address'
  'subnetId': 'arm-id'
  'linkedRedisCacheId': 'arm-id'
  'linkedRedisCacheLocation': 'azure-location'
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
  RDB: Rdb

override-operation-name:
  Redis_CheckNameAvailability: CheckRedisNameAvailability
  AsyncOperationStatus_Get: GetAsyncOperationStatus

directive:
  - from: redis.json
    where: $.paths..parameters[?(@.name === 'default')]
    transform: >
      $['x-ms-client-name'] = 'defaultName';
  - from: redis.json
    where: $.definitions
    transform: >
      $.OperationStatus.allOf = [
        {
          "$ref": "../../../../../common-types/resource-management/v2/types.json#/definitions/OperationStatusResult"
        }
      ];
      $.RedisResource['x-ms-client-name'] = 'Redis';
      $.CheckNameAvailabilityParameters.properties.type['x-ms-format'] = 'resource-type';
  - from: types.json
    where: $.definitions.OperationStatusResult
    transform: >
      $.properties.id['x-ms-format'] = 'arm-id';
  - from: redis.json
    where: $.definitions
    transform: >
      $.RedisProperties.properties.accessKeys["x-nullable"] = true;
```
