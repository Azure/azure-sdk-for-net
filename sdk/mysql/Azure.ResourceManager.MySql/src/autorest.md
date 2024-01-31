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
  - tag: package-2020-01-01
  - tag: package-flexibleserver-2023-06-01-preview
```

``` yaml $(tag) == 'package-2020-01-01'
namespace: Azure.ResourceManager.MySql
require: https://github.com/Azure/azure-rest-api-specs/blob/b7b77b11ba1f6defc86d309d4ca0d51b2a2646a7/specification/mysql/resource-manager/readme.md
output-folder: $(this-folder)/MySql/Generated
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'locationName': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'sessionId': 'uuid'
  'PrincipalId': 'uuid'
  '*ServerId': 'arm-id'
  '*SubnetId': 'arm-id'
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
  Five6: FivePointSix
  Five7: FivePointSeven
  Eight0: EightPointZero

prepend-rp-prefix:
  - Advisor
  - Capability
  - Configuration
  - Database
  - FirewallRule
  - QueryStatistic
  - QueryText
  - RecommendationAction
  - Server
  - ServerKey
  - ServerSecurityAlertPolicy
  - ServerVersion
  - VirtualNetworkRule
  - WaitStatistic
  - AdministratorType
  - AdvisorResultList
  - ConfigurationListContent
  - CreateMode
  - DatabaseListResult
  - FirewallRuleListResult
  - LogFile
  - LogFileListResult
  - MinimalTlsVersionEnum
  - GeoRedundantBackup
  - InfrastructureEncryption
  - PerformanceTierListResult
  - PerformanceTierServiceLevelObjectives
  - PrivateEndpointProvisioningState
  - PrivateLinkServiceConnectionStateStatus
  - PublicNetworkAccessEnum
  - QueryPerformanceInsightResetDataResult
  - QueryPerformanceInsightResetDataResultState
  - RecommendedActionSessionsOperationStatus
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
  - ServerUpgradeParameters
  - SslEnforcementEnum
  - StorageAutogrow
  - TopQueryStatisticsInput
  - VirtualNetworkRuleListResult
  - VirtualNetworkRuleState
  - WaitStatisticsInput
rename-mapping:
  ServerAdministratorResource: MySqlServerAdministrator
  ServerAdministratorResource.properties.login: LoginAccountName
  ServerAdministratorResource.properties.sid: SecureId
  ServerAdministratorResourceListResult: MySqlServerAdministratorListResult
  AdvisorsResultList: MySqlAdvisorListResult
  QueryTextsResultList: MySqlQueryTextListResult
  TopQueryStatisticsResultList: MySqlTopQueryStatisticsListResult
  RecommendationActionsResultList: MySqlRecommendationActionListResult
  WaitStatisticsResultList: MySqlWaitStatisticsListResult
  PrivateLinkServiceConnectionStateActionsRequire: MySqlPrivateLinkServiceConnectionStateRequiredActions
  RecoverableServerResource: MySqlRecoverableServerResourceData
  RecoverableServerResource.properties.vCore: VCores
  ServerSecurityAlertPolicy.properties.emailAccountAdmins: SendToEmailAccountAdmins
  NameAvailability.nameAvailable: IsNameAvailable
  StorageProfile.storageMB: StorageInMB
  WaitStatistic.properties.totalTimeInMs: TotalTimeInMinutes
  PerformanceTierProperties.minStorageMB: MinStorageInMB
  PerformanceTierProperties.maxStorageMB: MaxStorageInMB
  PerformanceTierProperties.minLargeStorageMB: MinLargeStorageInMB
  PerformanceTierProperties.maxLargeStorageMB: MaxLargeStorageInMB
  PerformanceTierServiceLevelObjectives.maxStorageMB: MaxStorageInMB
  PerformanceTierServiceLevelObjectives.minStorageMB: MinStorageInMB
  PerformanceTierServiceLevelObjectives.vCore: VCores
  NameAvailability: MySqlNameAvailabilityResult
  PerformanceTierProperties: MySqlPerformanceTier
  ConfigurationListResult: MySqlConfigurations
  LogFile.properties.type: LogFileType
  ConfigurationListResult.value: Values
  NameAvailabilityRequest: MySqlNameAvailabilityContent

override-operation-name:
  ServerParameters_ListUpdateConfigurations: UpdateConfigurations
  MySqlServers_Start: Start
  MySqlServers_Stop: Stop
  MySqlServers_Upgrade: Upgrade
  CheckNameAvailability_Execute: CheckMySqlNameAvailability

directive:
  # These 2 operations read like some LRO related operations. Remove them first.
  - remove-operation: LocationBasedRecommendedActionSessionsResult_List
  - remove-operation: LocationBasedRecommendedActionSessionsOperationStatus_Get
  - rename-operation:
      from: Servers_Start
      to: MySqlServers_Start
  - rename-operation:
      from: Servers_Stop
      to: MySqlServers_Stop
  - rename-operation:
      from: Servers_Upgrade
      to: MySqlServers_Upgrade
  - from: mysql.json
    where: $.definitions
    transform: >
      $.ServerPrivateEndpointConnection.properties.id['x-ms-format'] = 'arm-id';
      $.RecoverableServerProperties.properties.lastAvailableBackupDateTime['format'] = 'date-time';

```

``` yaml $(tag) == 'package-flexibleserver-2023-06-01-preview'
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/b7b77b11ba1f6defc86d309d4ca0d51b2a2646a7/specification/common-types/resource-management/v5/privatelinks.json
namespace: Azure.ResourceManager.MySql.FlexibleServers
require: https://github.com/Azure/azure-rest-api-specs/blob/b7b77b11ba1f6defc86d309d4ca0d51b2a2646a7/specification/mysql/resource-manager/readme.md
output-folder: $(this-folder)/MySqlFlexibleServers/Generated
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

rename-mapping:
  Storage.storageSizeGB: StorageSizeInGB
  SkuCapability.supportedMemoryPerVCoreMB: SupportedMemoryPerVCoreInMB
  ConfigurationListForBatchUpdate.value: Values
  ConfigurationListResult.value: Values
  Configuration: MySqlFlexibleServerConfiguration
  Database: MySqlFlexibleServerDatabase
  FirewallRule: MySqlFlexibleServerFirewallRule
  ServerBackup: MySqlFlexibleServerBackup
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
  ServerProperties: MySqlFlexibleServerProperties
  ServerPropertiesForUpdate: MySqlFlexibleServerPropertiesForUpdate
  ServerForUpdate: MySqlFlexibleServerForUpdate
  ServerListResult: MySqlFlexibleServerListResult
  ServerRestartParameter: MySqlFlexibleServerRestartParameter
  ServerState: MySqlFlexibleServerState
  ServerBackupListResult: MySqlFlexibleServerBackupListResult
  FirewallRuleProperties: MySqlFlexibleServerFirewallRuleProperties
  FirewallRuleListResult: MySqlFlexibleServerFirewallRuleListResult
  DatabaseListResult: MySqlFlexibleServerDatabaseListResult
  ConfigurationSource: MySqlFlexibleServerConfigurationSource
  ConfigurationListResult: MySqlFlexibleServerConfigurationListResult
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

override-operation-name:
  CheckNameAvailability_Execute: CheckMySqlFlexibleServerNameAvailability
  CheckNameAvailabilityWithoutLocation_Execute: CheckMySqlFlexibleServerNameAvailabilityWithoutLocation
  Configurations_BatchUpdate: UpdateConfigurations
  BackupAndExport_ValidateBackup: ValidateBackup

directive:
  - from: FlexibleServers.json
    where: $.definitions
    transform: >
      $.MySQLServerIdentity['x-ms-client-flatten'] = false;
      $.MySQLServerIdentity.properties.userAssignedIdentities.additionalProperties['$ref'] = '#/definitions/UserAssignedIdentity';
      delete $.MySQLServerIdentity.properties.userAssignedIdentities.additionalProperties.items;
      $.ServerProperties.properties.privateEndpointConnections.items['$ref'] = '../../../../../../common-types/resource-management/v5/privatelinks.json#/definitions/PrivateEndpointConnection';

  # Add a new mode for update operation
  - from: Configurations.json
    where: $.definitions
    transform: >
      $.MySqlFlexibleServerConfigurations =  {
          'type': 'object',
          'properties': {
            'values': {
              'type': 'array',
              'items': {
                '$ref': '#/definitions/Configuration'
              },
              'description': 'The list of server configurations.'
            }
          },
          'description': 'A list of server configurations.'
        };
  - from: Configurations.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/flexibleServers/{serverName}/updateConfigurations'].post
    transform: >
      $.responses['200']['schema']['$ref'] = '#/definitions/MySqlFlexibleServerConfigurations';

```
