# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
csharp: true
clear-output-folder: true
skip-csproj: true
library-name: PostgreSql

modelerfour:
  flatten-payloads: false

batch:
  - tag: package-2020-01-01
  - tag: package-flexibleserver-2022-12-01
```

``` yaml $(tag) == 'package-2020-01-01'

namespace: Azure.ResourceManager.PostgreSql
require: https://github.com/Azure/azure-rest-api-specs/blob/eca38ee0caf445cb1e79c8e7bbaf9e1dca36479a/specification/postgresql/resource-manager/readme.md
output-folder: $(this-folder)/PostgreSql/Generated

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'locationName': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'PrincipalId': 'uuid'
  '*ServerId': 'arm-id'
  '*SubnetId': 'arm-id'
  'ResourceType': 'resource-type'
  '*IPAddress': 'ip-address'

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
  Nine5: NinePointFive
  Nine6: NinePointSix
  Ten0: TenPointZero
  Ten2: TenPointTwo


prepend-rp-prefix:
  - Configuration
  - Database
  - FirewallRule
  - Server
  - ServerKey
  - ServerSecurityAlertPolicy
  - ServerVersion
  - VirtualNetworkRule
  - AdministratorType
  - ConfigurationListContent
  - CreateMode
  - DatabaseListResult
  - FirewallRuleListResult
  - LogFile
  - LogFileListResult
  - MinimalTlsVersionEnum
  - GeoRedundantBackup
  - InfrastructureEncryption
  - NameAvailabilityRequest
  - PerformanceTierListResult
  - PerformanceTierProperties
  - PerformanceTierServiceLevelObjectives
  - PrivateEndpointProvisioningState
  - PrivateLinkServiceConnectionStateStatus
  - PublicNetworkAccessEnum
  - StorageProfile
  - ServerPropertiesForCreate
  - ServerPropertiesForDefaultCreate
  - ServerPropertiesForRestore
  - ServerPropertiesForGeoRestore
  - ServerPropertiesForReplica
  - SecurityAlertPolicyName
  - ServerKeyListResult
  - ServerKeyType
  - ServerListResult
  - ServerPrivateEndpointConnection
  - ServerPrivateEndpointConnectionProperties
  - ServerPrivateLinkServiceConnectionStateProperty
  - ServerSecurityAlertPolicyListResult
  - ServerSecurityAlertPolicyState
  - ServerState
  - SslEnforcementEnum
  - StorageAutogrow
  - VirtualNetworkRuleListResult
  - VirtualNetworkRuleState
rename-mapping:
  ServerAdministratorResource: PostgreSqlServerAdministrator
  ServerAdministratorResource.properties.login: LoginAccountName
  ServerAdministratorResource.properties.sid: SecureId
  ServerAdministratorResourceListResult: PostgreSqlServerAdministratorListResult
  PrivateLinkServiceConnectionStateActionsRequire: PostgreSqlPrivateLinkServiceConnectionStateRequiredActions
  RecoverableServerResource: PostgreSqlRecoverableServerResourceData
  RecoverableServerResource.properties.vCore: VCores
  ServerSecurityAlertPolicy.properties.emailAccountAdmins: SendToEmailAccountAdmins
  NameAvailability.nameAvailable: IsNameAvailable
  StorageProfile.storageMB: StorageInMB
  PerformanceTierProperties.minStorageMB: MinStorageInMB
  PerformanceTierProperties.maxStorageMB: MaxStorageInMB
  PerformanceTierProperties.minLargeStorageMB: MinLargeStorageInMB
  PerformanceTierProperties.maxLargeStorageMB: MaxLargeStorageInMB
  PerformanceTierServiceLevelObjectives.maxStorageMB: MaxStorageInMB
  PerformanceTierServiceLevelObjectives.minStorageMB: MinStorageInMB
  PerformanceTierServiceLevelObjectives.vCore: VCores
  NameAvailability: PostgreSqlNameAvailabilityResult
  ConfigurationListResult: PostgreSqlConfigurationList
  LogFile.properties.type: LogFileType
override-operation-name:
  ServerParameters_ListUpdateConfigurations: UpdateConfigurations
  CheckNameAvailability_Execute: CheckPostgreSqlNameAvailability
directive:
  - from: postgresql.json
    where: $.definitions
    transform: >
      $.ServerPrivateEndpointConnection.properties.id['x-ms-format'] = 'arm-id';
      $.RecoverableServerProperties.properties.lastAvailableBackupDateTime['format'] = 'date-time';
```

``` yaml $(tag) == 'package-flexibleserver-2022-12-01'

namespace: Azure.ResourceManager.PostgreSql.FlexibleServers
require: https://github.com/Azure/azure-rest-api-specs/blob/deba715c80b5b523a84d32fa2764c0f6e867b4d0/specification/postgresql/resource-manager/readme.md
output-folder: $(this-folder)/PostgreSqlFlexibleServers/Generated

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'locationName': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  '*ResourceId': 'arm-id'
  'ResourceType': 'resource-type'
  '*IPAddress': 'ip-address'

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
  Vcore: VCore
  Vcores: VCores
  UTC: Utc

rename-mapping:
  Configuration: PostgreSqlFlexibleServerConfiguration
  ConfigurationDataType: PostgreSqlFlexibleServerConfigurationDataType
  CreateModeForUpdate: PostgreSqlFlexibleServerCreateModeForUpdate
  FailoverMode: PostgreSqlFlexibleServerFailoverMode
  FlexibleServerEditionCapability: PostgreSqlFlexibleServerEditionCapability
  GeoRedundantBackupEnum: PostgreSqlFlexibleServerGeoRedundantBackupEnum
  HyperscaleNodeEditionCapability: PostgreSqlFlexibleServerHyperscaleNodeEditionCapability
  NodeTypeCapability: PostgreSqlFlexibleServerNodeTypeCapability
  Database: PostgreSqlFlexibleServerDatabase
  FirewallRule: PostgreSqlFlexibleServerFirewallRule
  Server: PostgreSqlFlexibleServer
  ServerVersion: PostgreSqlFlexibleServerVersion
  MaintenanceWindow: PostgreSqlFlexibleServerMaintenanceWindow
  Backup: PostgreSqlFlexibleServerBackupProperties
  Storage: PostgreSqlFlexibleServerStorage
  Sku: PostgreSqlFlexibleServerSku
  Network: PostgreSqlFlexibleServerNetwork
  HighAvailability: PostgreSqlFlexibleServerHighAvailability
  HighAvailabilityMode: PostgreSqlFlexibleServerHighAvailabilityMode
  ServerListResult: PostgreSqlFlexibleServerListResult
  ServerState: PostgreSqlFlexibleServerState
  FirewallRuleListResult: PostgreSqlFlexibleServerFirewallRuleListResult
  DatabaseListResult: PostgreSqlFlexibleServerDatabaseListResult
  ConfigurationListResult: PostgreSqlFlexibleServerConfigurationListResult
  VirtualNetworkSubnetUsageParameter: PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter
  DelegatedSubnetUsage: PostgreSqlFlexibleServerDelegatedSubnetUsage
  VirtualNetworkSubnetUsageResult: PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult
  VcoreCapability: PostgreSqlFlexibleServerVCoreCapability
  ServerVersionCapability: PostgreSqlFlexibleServerServerVersionCapability
  ServerVersionCapability.supportedVcores: SupportedVCores
  StorageEditionCapability: PostgreSqlFlexibleServerStorageEditionCapability
  ServerEditionCapability: PostgreSqlFlexibleServerEditionCapability
  CapabilityProperties: PostgreSqlFlexibleServerCapabilityProperties
  CapabilityProperties.geoBackupSupported: IsGeoBackupSupported
  CapabilityProperties.zoneRedundantHaSupported: IsZoneRedundantHASupported
  CapabilityProperties.zoneRedundantHaAndGeoBackupSupported: IsZoneRedundantHAAndGeoBackupSupported
  CapabilitiesListResult: PostgreSqlFlexibleServerCapabilitiesListResult
  CheckNameAvailabilityRequest: PostgreSqlFlexibleServerNameAvailabilityRequest
  CheckNameAvailabilityResponse: PostgreSqlFlexibleServerNameAvailabilityResponse
  CheckNameAvailabilityReason: PostgreSqlFlexibleServerNameUnavailableReason
  NameAvailability: PostgreSqlFlexibleServerNameAvailabilityResult
  CreateMode: PostgreSqlFlexibleServerCreateMode
  SkuTier: PostgreSqlFlexibleServerSkuTier
  CheckNameAvailabilityResponse.nameAvailable: IsNameAvailable
  Storage.storageSizeGB: StorageSizeInGB
  StorageMBCapability.storageSizeMB: StorageSizeInMB
  StorageMBCapability: PostgreSqlFlexibleServerStorageCapability
  VcoreCapability.supportedMemoryPerVcoreMB: SupportedMemoryPerVCoreInMB
  RestartParameter: PostgreSqlFlexibleServerRestartParameter
  ServerHAState: PostgreSqlFlexibleServerHAState
  ServerPublicNetworkAccessState: PostgreSqlFlexibleServerPublicNetworkAccessState
  CapabilityProperties.supportedHAMode: SupportedHAModes
  StorageEditionCapability.supportedStorageMB: SupportedStorageCapabilities
  Server.properties.pointInTimeUTC: PointInTimeUtc
  ActiveDirectoryAdministrator: PostgreSqlFlexibleServerActiveDirectoryAdministrator
  ActiveDirectoryAuthEnum: PostgreSqlFlexibleServerActiveDirectoryAuthEnum
  AdministratorListResult: PostgreSqlFlexibleServerAdministratorListResult
  ArmServerKeyType: PostgreSqlFlexibleServerKeyType
  AuthConfig: PostgreSqlFlexibleServerAuthConfig
  DataEncryption: PostgreSqlFlexibleServerDataEncryption
  FastProvisioningEditionCapability: PostgreSqlFlexibleServerFastProvisioningEditionCapability
  IdentityType: PostgreSqlFlexibleServerIdentityType
  Origin: PostgreSqlFlexibleServerBackupOrigin
  PasswordAuthEnum: PostgreSqlFlexibleServerPasswordAuthEnum
  PrincipalType: PostgreSqlFlexibleServerPrincipalType
  ReplicationRole: PostgreSqlFlexibleServerReplicationRole
  ServerBackup: PostgreSqlFlexibleServerBackup
  ServerBackupListResult: PostgreSqlFlexibleServerBackupListResult
  StorageTierCapability: PostgreSqlFlexibleServerStorageTierCapability
  UserAssignedIdentity: PostgreSqlFlexibleServerUserAssignedIdentity
override-operation-name:
  CheckNameAvailability_Execute: CheckPostgreSqlFlexibleServerNameAvailability
  CheckNameAvailabilityWithLocation_Execute: CheckPostgreSqlFlexibleServerNameAvailabilityWithLocation
directive:
  - from: Administrators.json
    where: $.definitions
    transform: >
      $.AdministratorProperties.properties.objectId['format'] = 'uuid'
  - from: FlexibleServers.json
    where: $.definitions
    transform: >
      $.DataEncryption.properties.primaryUserAssignedIdentityId['format'] = 'arm-id'
```
