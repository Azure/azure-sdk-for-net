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
  lenient-model-deduplication: true
#   prenamer: true
use-model-reader-writer: true

mgmt-debug:
  show-serialized-names: true

batch:
  - tag: package-2020-01-01
  - tag: package-flexibleserver-2025-08-01
enable-bicep-serialization: true

```

``` yaml $(tag) == 'package-2020-01-01'

namespace: Azure.ResourceManager.PostgreSql
require: https://github.com/Azure/azure-rest-api-specs/blob/eca38ee0caf445cb1e79c8e7bbaf9e1dca36479a/specification/postgresql/resource-manager/readme.md
output-folder: $(this-folder)/PostgreSql/Generated
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true

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
  - Replica
  - ReplicationState
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
  - ServerSku
  - ServerState
  - SourceType
  - SslEnforcementEnum
  - SslMode
  - StorageAutogrow
  - StorageType
  - ValidationDetails
  - ValidationMessage
  - ValidationState
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

``` yaml $(tag) == 'package-flexibleserver-2025-08-01'

namespace: Azure.ResourceManager.PostgreSql.FlexibleServers
require: https://github.com/Azure/azure-rest-api-specs/blob/441142c0e20d1d14a022fced9d2837128ba81ca6/specification/postgresql/resource-manager/readme.md
output-folder: $(this-folder)/PostgreSqlFlexibleServers/Generated
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: false

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
  Vcore: VCore
  Vcores: VCores
  UTC: Utc

no-property-type-replacement:
  - PostgreSqlFlexibleServerData

rename-mapping:
  Configuration: PostgreSqlFlexibleServerConfiguration
  ConfigurationDataType: PostgreSqlFlexibleServerConfigurationDataType
  CreateModeForPatch: PostgreSqlFlexibleServerCreateModeForUpdate
  FailoverMode: PostgreSqlFlexibleServerFailoverMode
  FlexibleServerEditionCapability: PostgreSqlFlexibleServerEditionCapability
  GeographicallyRedundantBackup: PostgreSqlFlexibleServerGeoRedundantBackupEnum
  Database: PostgreSqlFlexibleServerDatabase
  FirewallRule: PostgreSqlFlexibleServerFirewallRule
  Server: PostgreSqlFlexibleServer
  PostgresMajorVersion: PostgreSqlFlexibleServerVersion
  MaintenanceWindow: PostgreSqlFlexibleServerMaintenanceWindow
  BackupForPatch: PostgreSqlFlexibleServerBackupProperties
  Storage: PostgreSqlFlexibleServerStorage
  SkuForPatch: PostgreSqlFlexibleServerSku
  Network: PostgreSqlFlexibleServerNetwork
  HighAvailability: PostgreSqlFlexibleServerHighAvailability
#   HighAvailabilityMode: PostgreSqlFlexibleServerHighAvailabilityMode
#   PostgreSqlFlexibleServerHighAvailabilityMode: PostgreSqlFlexibleServerHAMode
  ServerListResult: PostgreSqlFlexibleServerListResult
  ServerState: PostgreSqlFlexibleServerState
  FirewallRuleListResult: PostgreSqlFlexibleServerFirewallRuleListResult
  DatabaseListResult: PostgreSqlFlexibleServerDatabaseListResult
  ConfigurationListResult: PostgreSqlFlexibleServerConfigurationListResult
  VirtualNetworkSubnetUsageParameter: PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter
  DelegatedSubnetUsage: PostgreSqlFlexibleServerDelegatedSubnetUsage
  VirtualNetworkSubnetUsageModel: PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult
  ServerVersionCapability: PostgreSqlFlexibleServerServerVersionCapability
  ServerVersionCapability.supportedVcores: SupportedVCores
  StorageEditionCapability: PostgreSqlFlexibleServerStorageEditionCapability
  ServerEditionCapability: PostgreSqlFlexibleServerEditionCapability
  CapabilitiesListResult: PostgreSqlFlexibleServerCapabilitiesListResult
  CheckNameAvailabilityRequest: PostgreSqlFlexibleServerNameAvailabilityContent
  CheckNameAvailabilityResponse: PostgreSqlFlexibleServerNameAvailabilityResponse
  CheckNameAvailabilityReason: PostgreSqlFlexibleServerNameUnavailableReason
  NameAvailabilityModel: PostgreSqlFlexibleServerNameAvailabilityResult
  CreateMode: PostgreSqlFlexibleServerCreateMode
  SkuTier: PostgreSqlFlexibleServerSkuTier
  CheckNameAvailabilityResponse.nameAvailable: IsNameAvailable
  Storage.storageSizeGB: StorageSizeInGB
  StorageMbCapability.storageSizeMb: StorageSizeInMB
  StorageMbCapability: PostgreSqlFlexibleServerStorageCapability
  RestartParameter: PostgreSqlFlexibleServerRestartParameter
  HighAvailabilityState: PostgreSqlFlexibleServerHAState
  ServerPublicNetworkAccessState: PostgreSqlFlexibleServerPublicNetworkAccessState
  StorageEditionCapability.supportedStorageMb: SupportedStorageCapabilities
  Server.properties.pointInTimeUTC: PointInTimeUtc
  ActiveDirectoryAdministrator: PostgreSqlFlexibleServerActiveDirectoryAdministrator
  MicrosoftEntraAuth: PostgreSqlFlexibleServerActiveDirectoryAuthEnum
  AdministratorListResult: PostgreSqlFlexibleServerAdministratorListResult
  DataEncryptionType: PostgreSqlFlexibleServerKeyType
  AuthConfig: PostgreSqlFlexibleServerAuthConfig
  DataEncryption: PostgreSqlFlexibleServerDataEncryption
  FastProvisioningEditionCapability: PostgreSqlFlexibleServerFastProvisioningEditionCapability
  IdentityType: PostgreSqlFlexibleServerIdentityType
  BackupType: PostgreSqlFlexibleServerBackupOrigin
  PasswordBasedAuth: PostgreSqlFlexibleServerPasswordAuthEnum
  PrincipalType: PostgreSqlFlexibleServerPrincipalType
  ReplicationRole: PostgreSqlFlexibleServerReplicationRole
  BackupAutomaticAndOnDemand: PostgreSqlFlexibleServerBackup
  ServerBackupListResult: PostgreSqlFlexibleServerBackupListResult
  StorageTierCapability: PostgreSqlFlexibleServerStorageTierCapability
  AdminCredentials: PostgreSqlMigrationAdminCredentials
  BackupSettings: PostgreSqlFlexibleServerBackupSettings
  BackupStoreDetails: PostgreSqlFlexibleServerBackupStoreDetails
  Cancel: PostgreSqlMigrationCancel
  LogicalReplicationOnSourceServer: PostgreSqlMigrationLogicalReplicationOnSourceDb
  OverwriteDatabasesOnTargetServer: PostgreSqlMigrationOverwriteDbsInTarget
  StartDataMigration: PostgreSqlMigrationStartDataMigration
  TriggerCutover: PostgreSqlMigrationTriggerCutover
  CapabilityStatus: PostgreSqlFlexbileServerCapabilityStatus
  DbServerMetadata: PostgreSqlServerMetadata
  FastProvisioningSupport: PostgreSqlFlexibleServerFastProvisioningSupported
  Capability.fastProvisioningSupported: SupportFastProvisioning
  Capability: PostgreSqlFlexibleServerCapabilityProperties
  CapturedLog: PostgreSqlFlexibleServerLogFile
  LogFileListResult: PostgreSqlFlexibleServerLogFileListResult
  GeographicallyRedundantBackupSupport: PostgreSqlFlexibleServerGeoBackupSupported
  ZoneRedundantHighAvailabilitySupport: PostgreSqlFlexibleServerZoneRedundantHaSupported
  ZoneRedundantHighAvailabilityAndGeographicallyRedundantBackupSupport: PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported
  StorageAutoGrowthSupport: PostgreSqlFlexibleServerStorageAutoGrowthSupported
  OnlineStorageResizeSupport: PostgreSqlFlexibleServerOnlineResizeSupported
  LocationRestricted: PostgreSqlFlexibleServerZoneRedundantRestricted
  ServerSkuCapability: PostgreSqlFlexibleServerSkuCapability
  CapabilityBase.status: CapabilityStatus
  CapabilityBase: PostgreSqlBaseCapability
  ExecutionStatus: PostgreSqlExecutionStatus
  EncryptionKeyStatus: PostgreSqlKeyStatus
  BackupsLongTermRetentionResponse: PostgreSqlFlexibleServerLtrBackupResult
  LtrPreBackupResponse: PostgreSqlFlexibleServerLtrPreBackupResult
  MigrationListFilter: PostgreSqlMigrationListFilter
  MigrationMode: PostgreSqlMigrationMode
  MigrationNameAvailabilityReason: PostgreSqlMigrationNameUnavailableReason
  MigrationResourceListResult: PostgreSqlMigrationResourceListResult
  MigrationNameAvailability: PostgreSqlCheckMigrationNameAvailabilityContent
  MigrationNameAvailability.nameAvailable: IsNameAvailable
  MigrationSecretParametersForPatch: PostgreSqlMigrationSecretParametersForUpdate
  MigrationSecretParameters: PostgreSqlMigrationSecretParameters
  MigrationState: PostgreSqlMigrationState
  MigrationStatus: PostgreSqlMigrationStatus
  MigrationSubstate: PostgreSqlMigrationSubState
  MigrationSubstateDetails: PostgreSqlMigrationSubStateDetails
  BackupRequestBase: PostgreSqlBackupContent
  AzureManagedDiskPerformanceTier: PostgreSqlManagedDiskPerformanceTier
  BackupsLongTermRetentionRequest: PostgreSqlFlexibleServerLtrBackupContent
  LtrPreBackupRequest: PostgreSqlFlexibleServerLtrPreBackupContent
  Migration: PostgreSqlMigration
  AdministratorMicrosoftEntra.properties.objectId: -|uuid
  DataEncryption.primaryUserAssignedIdentityId: -|arm-id
  AdvancedThreatProtectionSettingsModel: ServerThreatProtectionSettingsModel
  AdministratorMicrosoftEntra: PostgreSqlFlexibleServerActiveDirectoryAdministrator
  LtrServerBackupOperationList: PostgreSqlLtrServerBackupOperationList
  BackupsLongTermRetentionOperation: PostgreSqlLtrServerBackupOperation
  VirtualEndpoint: VirtualEndpointResource
  ReadReplicaPromoteOption: ReplicationPromoteOption
  MigrationDatabaseState: MigrationDbState
  MigrateRolesAndPermissions: MigrateRolesEnum
  DatabaseMigrationState: DbMigrationStatus
  TuningOption: FooTuningOption
  UserAssignedIdentity: PostgreSqlFlexibleServerUserAssignedIdentity

override-operation-name:
  CheckNameAvailability_Execute: CheckPostgreSqlFlexibleServerNameAvailability
  CheckNameAvailabilityWithLocation_Execute: CheckPostgreSqlFlexibleServerNameAvailabilityWithLocation
  CheckMigrationNameAvailability: CheckPostgreSqlMigrationNameAvailability
  LogFiles_ListByServer: GetPostgreSqlFlexibleServerLogFiles

directive:
  - from: swagger-document
    where: $.definitions.ServerPropertiesForPatch
    transform: >
      $.properties.location = {"type": "string", "description": "The location the resource resides in."};
  - from: swagger-document
    where: $.definitions.CheckNameAvailabilityRequest
    transform: >
       $.required = ['name'];
  - from: openapi.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}/configurations/{configurationName}"].patch
    transform: >
      const parameters = $.parameters;
      $.parameters[parameters.length-1].schema["$ref"] = "#/definitions/Configuration"
```
