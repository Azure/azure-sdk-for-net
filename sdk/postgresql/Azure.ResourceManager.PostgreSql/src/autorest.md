# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
csharp: true
library-name: PostgreSql
namespace: Azure.ResourceManager.PostgreSql.FlexibleServers
require: https://github.com/Azure/azure-rest-api-specs/blob/96086ecacd33f5e91557e03cf5838d5f45be9f3b/specification/postgresql/resource-manager/readme.md
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

mgmt-debug:
 show-serialized-names: true

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
#   Vcore: VCore
  Vcores: VCores
  UTC: Utc
  Nine5: NinePointFive
  Nine6: NinePointSix
  Ten0: TenPointZero
  Ten2: TenPointTwo

prepend-rp-prefix:
  - Configuration
  - Database
  - FirewallRule
  - Server
  - CreateMode
  - Replica
  - ReplicationState
  - ServerSku
  - ServerState
  - SourceType
  - SslMode
  - StorageType
  - ValidationDetails
  - ValidationMessage
  - ValidationState

rename-mapping:
  Configuration: PostgreSqlFlexibleServerConfiguration
  ConfigurationDataType: PostgreSqlFlexibleServerConfigurationDataType
  CreateModeForPatch: PostgreSqlFlexibleServerCreateModeForUpdate
  FailoverMode: PostgreSqlFlexibleServerFailoverMode
  GeographicallyRedundantBackup: PostgreSqlFlexibleServerGeoRedundantBackupEnum
  Database: PostgreSqlFlexibleServerDatabase
  FirewallRule: PostgreSqlFlexibleServerFirewallRule
  Server: PostgreSqlFlexibleServer
  PostgresMajorVersion: PostgreSqlFlexibleServerVersion
  MaintenanceWindow: PostgreSqlFlexibleServerMaintenanceWindow
  Backup: PostgreSqlFlexibleServerBackupProperties
  Storage: PostgreSqlFlexibleServerStorage
  Sku: PostgreSqlFlexibleServerSku
  Network: PostgreSqlFlexibleServerNetwork
  HighAvailability: PostgreSqlFlexibleServerHighAvailability
  ServerState: PostgreSqlFlexibleServerState
  VirtualNetworkSubnetUsageParameter: PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter
  DelegatedSubnetUsage: PostgreSqlFlexibleServerDelegatedSubnetUsage
  VirtualNetworkSubnetUsageModel: PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult
  ServerVersionCapability: PostgreSqlFlexibleServerServerVersionCapability
  StorageEditionCapability: PostgreSqlFlexibleServerStorageEditionCapability
  ServerEditionCapability: PostgreSqlFlexibleServerEditionCapability
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
  MicrosoftEntraAuth: PostgreSqlFlexibleServerActiveDirectoryAuthEnum
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
  MigrationNameAvailability: PostgreSqlCheckMigrationNameAvailabilityContent
  MigrationNameAvailability.nameAvailable: IsNameAvailable
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
  UserAssignedIdentity: PostgreSqlFlexibleServerUserAssignedIdentity
  HighAvailabilityMode: PostgreSqlFlexibleServerHAMode

override-operation-name:
  PrivateDnsZoneSuffix_Get: ExecuteGetPrivateDnsZoneSuffix
  VirtualNetworkSubnetUsage_List: ExecuteVirtualNetworkSubnetUsage
  NameAvailability_CheckWithLocation: CheckPostgreSqlFlexibleServerNameAvailabilityWithLocation
  NameAvailability_CheckGlobally: CheckPostgreSqlFlexibleServerNameAvailability
  BackupsLongTermRetention_CheckPrerequisites: TriggerLtrPreBackupFlexibleServer
  Migrations_CheckNameAvailability: CheckPostgreSqlMigrationNameAvailability
  BackupsLongTermRetention_Start: StartLtrBackupFlexibleServer
  CapturedLogs_ListByServer: GetPostgreSqlFlexibleServerLogFiles
  CapabilitiesByServer_List: GetServerCapabilities
  CapabilitiesByLocation_List: ExecuteLocationBasedCapabilities

directive:
  - from: swagger-document
    where: $.definitions.UserAssignedIdentity
    transform: >
      $.properties['userAssignedIdentities'] = {
          "type": "object",
          "description": "Map of user assigned managed identities.",
          "additionalProperties": {
              "type": "object",
              "description": "User assigned identity properties",
              "properties": {
                "principalId": {
                  "type": "string",
                  "format": "uuid",
                  "description": "The principal ID of the assigned identity.",
                  "readOnly": true
                },
                "clientId": {
                  "type": "string",
                  "format": "uuid",
                  "description": "The client ID of the assigned identity.",
                  "readOnly": true
                }
              }
            },
        };
  - from: swagger-document
    where: $.definitions.ServerPropertiesForPatch
    transform: >
      $.properties.backup['$ref'] = '#/definitions/Backup';
      $.properties.maintenanceWindow['$ref'] = '#/definitions/MaintenanceWindow';
      $.properties.highAvailability['$ref'] = '#/definitions/HighAvailability';
      $.properties.authConfig['$ref'] = '#/definitions/AuthConfig';
      $.properties.administratorLogin['readOnly'] = false;
  - from: swagger-document
    where: $.definitions.ServerForPatch
    transform: >
      $.properties.sku['$ref'] = '#/definitions/Sku';
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
  - from: swagger-document
    where: $.definitions.MigrationPropertiesForPatch
    transform: >
      $.properties.secretParameters['$ref'] = '#/definitions/MigrationSecretParameters';
  - from: swagger-document
    where: $.definitions.DataEncryption
    transform: >
      $.properties.primaryEncryptionKeyStatus['readOnly'] = false;
      $.properties.geoBackupEncryptionKeyStatus['readOnly'] = false;
```
