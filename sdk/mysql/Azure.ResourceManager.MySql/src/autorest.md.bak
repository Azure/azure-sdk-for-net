# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
csharp: true
clear-output-folder: true
skip-csproj: true
library-name: MySql
#mgmt-debug:
#  show-serialized-names: true
use-model-reader-writer: true

batch:
  - tag: package-flexibleserver-2024-12-01-preview
```

``` yaml $(tag) == 'package-flexibleserver-2024-12-01-preview'
namespace: Azure.ResourceManager.MySql.FlexibleServers
require: https://github.com/Azure/azure-rest-api-specs/blob/bb58530b93212845aeb78120d6762677c7610ef7/specification/mysql/resource-manager/Microsoft.DBforMySQL/FlexibleServers/readme.md
output-folder: $(this-folder)/Generated
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: false
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'locationName': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'PrincipalId': 'uuid'
  '*SubnetId': 'arm-id'
  '*ResourceId': 'arm-id'
  '*UserAssignedIdentityId': 'arm-id'
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

prepend-rp-prefix:
  - Capability

rename-mapping:
  Storage.storageSizeGB: StorageSizeInGB
  SkuCapability.supportedMemoryPerVCoreMB: SupportedMemoryPerVCoreInMB
  ConfigurationListForBatchUpdate.value: Values
  ConfigurationListResult.value: Values
  Configuration: MySqlFlexibleServerConfiguration
  Database: MySqlFlexibleServerDatabase
  FirewallRule: MySqlFlexibleServerFirewallRule
  ServerBackup: MySqlFlexibleServerBackup
  ServerBackupV2: MySqlFlexibleServerBackupV2
  Server: MySqlFlexibleServer
  ServerVersion: MySqlFlexibleServerVersion
  EnableStatusEnum: MySqlFlexibleServerEnableStatusEnum
  ReplicationRole: MySqlFlexibleServerReplicationRole
  DataEncryption: MySqlFlexibleServerDataEncryption
  MaintenanceWindow: MySqlFlexibleServerMaintenanceWindow
  Backup: MySqlFlexibleServerBackupProperties
  Storage: MySqlFlexibleServerStorage
  MySQLServerSku: MySqlFlexibleServerSku
  Network: MySqlFlexibleServerNetwork
  HighAvailability: MySqlFlexibleServerHighAvailability
  HighAvailabilityMode: MySqlFlexibleServerHighAvailabilityMode
  HighAvailabilityState: MySqlFlexibleServerHighAvailabilityState
  ServerForUpdate: MySqlFlexibleServerForUpdate
  ServerListResult: MySqlFlexibleServerListResult
  ServerRestartParameter: MySqlFlexibleServerRestartParameter
  ServerState: MySqlFlexibleServerState
  ServerBackupListResult: MySqlFlexibleServerBackupListResult
  FirewallRuleListResult: MySqlFlexibleServerFirewallRuleListResult
  DatabaseListResult: MySqlFlexibleServerDatabaseListResult
  ConfigurationSource: MySqlFlexibleServerConfigurationSource
  ConfigurationListResult: MySqlFlexibleServerConfigurations
  ConfigurationForBatchUpdate: MySqlFlexibleServerConfigurationForBatchUpdate
  ConfigurationListForBatchUpdate: MySqlFlexibleServerConfigurationListForBatchUpdate
  VirtualNetworkSubnetUsageParameter: MySqlFlexibleServerVirtualNetworkSubnetUsageParameter
  DelegatedSubnetUsage: MySqlFlexibleServerDelegatedSubnetUsage
  VirtualNetworkSubnetUsageResult: MySqlFlexibleServerVirtualNetworkSubnetUsageResult
  SkuCapability: MySqlFlexibleServerSkuCapability
  ServerVersionCapability: MySqlFlexibleServerServerVersionCapability
  StorageEditionCapability: MySqlFlexibleServerStorageEditionCapability
  ServerEditionCapability: MySqlFlexibleServerEditionCapability
  CapabilityProperties: MySqlFlexibleServerCapabilityProperties
  CapabilitiesListResult: MySqlFlexibleServerCapabilitiesListResult
  GetPrivateDnsZoneSuffixResponse: MySqlFlexibleServerPrivateDnsZoneSuffixResponse
  NameAvailabilityRequest: MySqlFlexibleServerNameAvailabilityContent
  NameAvailability: MySqlFlexibleServerNameAvailabilityResult
  CreateMode: MySqlFlexibleServerCreateMode
  DataEncryptionType: MySqlFlexibleServerDataEncryptionType
  ServerSkuTier: MySqlFlexibleServerSkuTier
  IsReadOnly: MySqlFlexibleServerConfigReadOnlyState
  IsDynamicConfig: MySqlFlexibleServerConfigDynamicState
  IsConfigPendingRestart: MySqlFlexibleServerConfigPendingRestartState
  NameAvailability.nameAvailable: IsNameAvailable
  AzureADAdministrator: MySqlFlexibleServerAadAdministrator
  AdministratorListResult: MySqlFlexibleServerAadAdministratorListResult
  AdministratorName: MySqlFlexibleServerAdministratorName
  BackupAndExportRequest: MySqlFlexibleServerBackupAndExportRequest
  BackupAndExportResponse: MySqlFlexibleServerBackupAndExportResult
  BackupFormat: MySqlFlexibleServerBackupFormat
  BackupRequestBase: MySqlFlexibleServerBackupContentBase
  BackupSettings: MySqlFlexibleServerBackupSettings
  BackupStoreDetails: MySqlFlexibleServerBackupStoreDetails
  FullBackupStoreDetails: MySqlFlexibleServerFullBackupStoreDetails
  AdministratorType: MySqlFlexibleServerAdministratorType
  LogFile: MySqlFlexibleServerLogFile
  LogFileListResult: MySqlFlexibleServerLogFileListResult
  OperationStatus: MySqlFlexibleServerBackupAndExportOperationStatus
  ResetAllToDefault: MySqlFlexibleServerConfigurationResetAllToDefault
  ServerGtidSetParameter: MySqlFlexibleServerGtidSetContent
  ValidateBackupResponse: MySqlFlexibleServerValidateBackupResult
  Maintenance: MySqlFlexibleServerMaintenance
  MaintenanceType: MySqlFlexibleServerMaintenanceType
  MaintenanceState: MySqlFlexibleServerMaintenanceState
  MaintenanceProvisioningState: MySqlFlexibleServerMaintenanceProvisioningState
  BackupType: MySqlFlexibleServerBackupType
  ProvisioningState: MySqlFlexibleServerBackupProvisioningState
  Server.properties.privateEndpointConnections: ServerPrivateEndpointConnections
  BatchOfMaintenance: MySqlFlexibleServerBatchOfMaintenance
  FeatureProperty: MySqlFlexibleServerFeatureProperty
  PatchStrategy: MySqlFlexibleServerPatchStrategy
  StorageRedundancyEnum: MySqlFlexibleServerStorageRedundancyType
  ServerDetachVNetParameter: MySqlFlexibleServerDetachVnetContent

override-operation-name:
  CheckNameAvailability_Execute: CheckMySqlFlexibleServerNameAvailability
  CheckNameAvailabilityWithoutLocation_Execute: CheckMySqlFlexibleServerNameAvailabilityWithoutLocation
  Configurations_BatchUpdate: UpdateConfigurations
  BackupAndExport_ValidateBackup: ValidateBackup
  Servers_DetachVNet: DetachVnet

directive:
  - remove-operation: OperationProgress_Get
  - remove-operation: OperationResults_Get

```
