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
use-model-reader-writer: true
batch:
  - tag: package-2020-01-01
  - tag: package-flexibleserver-2024-08-01-with-ltrv2
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
``` yaml $(tag) == 'package-flexibleserver-2024-08-01-with-ltrv2'
namespace: Azure.ResourceManager.PostgreSql.FlexibleServers
# Pull settings from both stable and preview readmes
require:
  - https://github.com/Azure/azure-rest-api-specs/blob/7e2cb423d45186cd1bff123f35e7d43bc4c0f268/specification/postgresql/resource-manager/readme.md
  - https://github.com/Azure/azure-rest-api-specs-pr/blob/bdc4b706cf623989c75a599102e8113d70216557/specification/internal-contracts/resource-manager/Microsoft.DBforPostgreSQL/implementedbyowningteam/2026-01-01-preview/readme.md
# Pin roots for reproducible builds
postgresql-2024-08-01-root: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/7e2cb423d45186cd1bff123f35e7d43bc4c0f268/specification/postgresql/resource-manager/Microsoft.DBforPostgreSQL/stable/2024-08-01
ltrv2-2026-preview-root:  https://raw.githubusercontent.com/Azure/azure-rest-api-specs-pr/bdc4b706cf623989c75a599102e8113d70216557/specification/internal-contracts/resource-manager/Microsoft.DBforPostgreSQL/implementedbyowningteam/2026-01-01-preview
common-types-v5: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/7e2cb423d45186cd1bff123f35e7d43bc4c0f268/specification/common-types/resource-management/v5/types.json
# Union of inputs: all stable + preview LTR v2
input-file:
  - $(postgresql-2024-08-01-root)/Administrators.json
  - $(postgresql-2024-08-01-root)/Backups.json
  - $(postgresql-2024-08-01-root)/Capabilities.json
  - $(postgresql-2024-08-01-root)/CheckNameAvailability.json
  - $(postgresql-2024-08-01-root)/Configuration.json
  - $(postgresql-2024-08-01-root)/Databases.json
  - $(postgresql-2024-08-01-root)/FirewallRules.json
  - $(postgresql-2024-08-01-root)/FlexibleServers.json
  - $(postgresql-2024-08-01-root)/LongTermRetentionOperation.json
  - $(postgresql-2024-08-01-root)/Migrations.json
  - $(postgresql-2024-08-01-root)/Operations.json
  - $(postgresql-2024-08-01-root)/PrivateDnsZone.json
  - $(postgresql-2024-08-01-root)/PrivateEndpointConnections.json
  - $(postgresql-2024-08-01-root)/PrivateLinkResources.json
  - $(postgresql-2024-08-01-root)/Replicas.json
  - $(postgresql-2024-08-01-root)/ServerLogs.json
  - $(postgresql-2024-08-01-root)/ServerStartStopRestart.json
  - $(postgresql-2024-08-01-root)/ThreatProtection.json
  - $(postgresql-2024-08-01-root)/VirtualEndpoints.json
  - $(postgresql-2024-08-01-root)/VirtualNetwork.json
  - $(ltrv2-2026-preview-root)/LongTermRetention.json   # LTR V2 preview added on top

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
rename-mapping:
  Configuration: PostgreSqlFlexibleServerConfiguration
  ConfigurationDataType: PostgreSqlFlexibleServerConfigurationDataType
  CreateModeForUpdate: PostgreSqlFlexibleServerCreateModeForUpdate
  FailoverMode: PostgreSqlFlexibleServerFailoverMode
  FlexibleServerEditionCapability: PostgreSqlFlexibleServerEditionCapability
  GeoRedundantBackupEnum: PostgreSqlFlexibleServerGeoRedundantBackupEnum
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
  ServerVersionCapability: PostgreSqlFlexibleServerServerVersionCapability
  ServerVersionCapability.supportedVcores: SupportedVCores
  StorageEditionCapability: PostgreSqlFlexibleServerStorageEditionCapability
  ServerEditionCapability: PostgreSqlFlexibleServerEditionCapability
  CapabilitiesListResult: PostgreSqlFlexibleServerCapabilitiesListResult
  CheckNameAvailabilityRequest: PostgreSqlFlexibleServerNameAvailabilityContent
  CheckNameAvailabilityResponse: PostgreSqlFlexibleServerNameAvailabilityResponse
  CheckNameAvailabilityReason: PostgreSqlFlexibleServerNameUnavailableReason
  NameAvailability: PostgreSqlFlexibleServerNameAvailabilityResult
  CreateMode: PostgreSqlFlexibleServerCreateMode
  SkuTier: PostgreSqlFlexibleServerSkuTier
  CheckNameAvailabilityResponse.nameAvailable: IsNameAvailable
  Storage.storageSizeGB: StorageSizeInGB
  StorageMbCapability.storageSizeMb: StorageSizeInMB
  StorageMbCapability: PostgreSqlFlexibleServerStorageCapability
  RestartParameter: PostgreSqlFlexibleServerRestartParameter
  ServerHAState: PostgreSqlFlexibleServerHAState
  ServerPublicNetworkAccessState: PostgreSqlFlexibleServerPublicNetworkAccessState
  StorageEditionCapability.supportedStorageMb: SupportedStorageCapabilities
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
  AdminCredentials: PostgreSqlMigrationAdminCredentials
  BackupSettings: PostgreSqlFlexibleServerBackupSettings
  BackupStoreDetails: PostgreSqlFlexibleServerBackupStoreDetails
  CancelEnum: PostgreSqlMigrationCancel
  LogicalReplicationOnSourceDbEnum: PostgreSqlMigrationLogicalReplicationOnSourceDb
  OverwriteDbsInTargetEnum: PostgreSqlMigrationOverwriteDbsInTarget
  StartDataMigrationEnum: PostgreSqlMigrationStartDataMigration
  TriggerCutoverEnum: PostgreSqlMigrationTriggerCutover
  CapabilityStatus: PostgreSqlFlexbileServerCapabilityStatus
  DbServerMetadata: PostgreSqlServerMetadata
  FastProvisioningSupportedEnum: PostgreSqlFlexibleServerFastProvisioningSupported
  FlexibleServerCapability.fastProvisioningSupported: SupportFastProvisioning
  FlexibleServerCapability: PostgreSqlFlexibleServerCapabilityProperties
  LogFile: PostgreSqlFlexibleServerLogFile
  LogFileListResult: PostgreSqlFlexibleServerLogFileListResult
  GeoBackupSupportedEnum: PostgreSqlFlexibleServerGeoBackupSupported
  HaMode: PostgreSqlFlexibleServerHAMode
  ZoneRedundantHaSupportedEnum: PostgreSqlFlexibleServerZoneRedundantHaSupported
  ZoneRedundantHaAndGeoBackupSupportedEnum: PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported
  StorageAutoGrowthSupportedEnum: PostgreSqlFlexibleServerStorageAutoGrowthSupported
  OnlineResizeSupportedEnum: PostgreSqlFlexibleServerOnlineResizeSupported
  RestrictedEnum: PostgreSqlFlexibleServerZoneRedundantRestricted
  ServerSkuCapability: PostgreSqlFlexibleServerSkuCapability
  CapabilityBase.status: CapabilityStatus
  CapabilityBase: PostgreSqlBaseCapability
  ExecutionStatus: PostgreSqlExecutionStatus
  KeyStatusEnum: PostgreSqlKeyStatus
  LtrBackupResponse: PostgreSqlFlexibleServerLtrBackupResult
  LtrPreBackupResponse: PostgreSqlFlexibleServerLtrPreBackupResult
  LtrServerBackupOperation: PostgreSqlLtrServerBackupOperation
  LtrServerBackupOperationList: PostgreSqlLtrServerBackupOperationList
  MigrationListFilter: PostgreSqlMigrationListFilter
  MigrationMode: PostgreSqlMigrationMode
  MigrationNameAvailabilityReason: PostgreSqlMigrationNameUnavailableReason
  MigrationResourceListResult: PostgreSqlMigrationResourceListResult
  MigrationNameAvailabilityResource: PostgreSqlCheckMigrationNameAvailabilityContent
  MigrationNameAvailabilityResource.nameAvailable: IsNameAvailable
  MigrationSecretParameters: PostgreSqlMigrationSecretParameters
  MigrationState: PostgreSqlMigrationState
  MigrationStatus: PostgreSqlMigrationStatus
  MigrationSubState: PostgreSqlMigrationSubState
  MigrationSubStateDetails: PostgreSqlMigrationSubStateDetails
  BackupRequestBase: PostgreSqlBackupContent
  AzureManagedDiskPerformanceTiers: PostgreSqlManagedDiskPerformanceTier
  LtrBackupRequest: PostgreSqlFlexibleServerLtrBackupContent
  LtrPreBackupRequest: PostgreSqlFlexibleServerLtrPreBackupContent
  MigrationResource: PostgreSqlMigration
  LtrV2BackupRequest: PostgreSqlFlexibleServerLtrV2BackupContent
  LtrV2BackupResponse: PostgreSqlFlexibleServerLtrV2BackupResult
  LtrV2BackupPreCheckRequest: PostgreSqlFlexibleServerLtrV2BackupPreCheckContent
  LtrV2BackupPreCheckResponse: PostgreSqlFlexibleServerLtrV2BackupPreCheckResult
  LtrV2BackupAccessRequest: PostgreSqlFlexibleServerLtrV2BackupAccessContent
  LtrV2BackupAccessResponse: PostgreSqlFlexibleServerLtrV2BackupAccessResult
override-operation-name:
  CheckNameAvailability_Execute: CheckPostgreSqlFlexibleServerNameAvailability
  CheckNameAvailabilityWithLocation_Execute: CheckPostgreSqlFlexibleServerNameAvailabilityWithLocation
  CheckMigrationNameAvailability: CheckPostgreSqlMigrationNameAvailability
  LogFiles_ListByServer: GetPostgreSqlFlexibleServerLogFiles
# Deduplicate errors across sources by forcing common-types
directive:
# Force preview LTR errors to common-types v5. Unfortunately we are unable to replace with common-types-v5 var, so directly updating the value from that.
  - from: LongTermRetention.json
    where: $.paths..responses.default.schema
    transform: >
      if ($ && $["$ref"]) {
        $["$ref"] = "https://raw.githubusercontent.com/Azure/azure-rest-api-specs/7e2cb423d45186cd1bff123f35e7d43bc4c0f268/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse";
      }
  # Remove local error models in the LTR preview spec to avoid duplicates
  - from: LongTermRetention.json
    where: $.definitions
    transform: >
      if ($.ErrorResponse) { delete $.ErrorResponse; }
      if ($.ErrorDetail)   { delete $.ErrorDetail; }
  # Repeat the original blocks
  - from: Administrators.json
    where: $.definitions
    transform: >
      $.AdministratorProperties.properties.objectId['format'] = 'uuid'
  - from: FlexibleServers.json
    where: $.definitions
    transform: >
      $.DataEncryption.properties.primaryUserAssignedIdentityId['format'] = 'arm-id';
      $.ServerForUpdate.properties.location = {"type": "string", "description": "The location the resource resides in."}
  - from: types.json
    where: $.definitions
    transform: >
      $.CheckNameAvailabilityRequest.required = ['name']
  - from: Configuration.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}/configurations/{configurationName}"].patch
    transform: >
      const parameters = $.parameters;
      $.parameters[parameters.length-1].schema["$ref"] = "#/definitions/Configuration"
```