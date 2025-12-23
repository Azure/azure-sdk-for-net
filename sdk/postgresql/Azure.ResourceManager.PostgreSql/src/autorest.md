# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
csharp: true
library-name: PostgreSql
namespace: Azure.ResourceManager.PostgreSql.FlexibleServers
require: https://github.com/Azure/azure-rest-api-specs/blob/b24c97bfc136b01dd46a1c8ddcecd0bb5a1ab152/specification/postgresql/resource-manager/readme.md
#tag: package-flexibleserver-2025-08-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: false
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true
use-model-reader-writer: true
enable-bicep-serialization: true

#mgmt-debug:
#  show-serialized-names: true

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
  'PrincipalId': 'uuid'
  '*ServerId': 'arm-id'
  '*SubnetId': 'arm-id'

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
  Nine5: NinePointFive
  Nine6: NinePointSix
  Ten0: TenPointZero
  Ten2: TenPointTwo

no-property-type-replacement:
  - PostgreSqlFlexibleServerData

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
