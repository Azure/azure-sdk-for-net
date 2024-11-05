# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: OracleDatabase
namespace: Azure.ResourceManager.OracleDatabase
require: https://github.com/Azure/azure-rest-api-specs/blob/ec7ee8842bf615c2f0354bf8b5b8725fdac9454a/specification/oracle/resource-manager/readme.md
#tag: package-2023-09-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
use-write-core: true

#mgmt-debug:
#  show-serialized-names: true

rename-mapping:
  DataCollectionOptions: DiagnosticCollectionConfig
  DbNode: CloudVmClusterDBNode
  DbNodeProperties: CloudVmClusterDbNodeProperties
  DbServer: OracleDBServer
  DbServerProperties: OracleDBServerProperties
  DbSystemShape: OracleDBSystemShape
  DbSystemShapeProperties: OracleDBSystemShapeProperties
  DnsPrivateView: OracleDnsPrivateView
  DnsPrivateViewProperties: OracleDnsPrivateViewProperties
  DnsPrivateZone: OracleDnsPrivateZone
  DnsPrivateZoneProperties: OracleDnsPrivateZoneProperties
  GiVersion: OracleGIVersion
  GiVersionProperties: OracleGIVersionProperties
  SystemVersion: OracleSystemVersion
  VirtualNetworkAddress: CloudVmClusterVirtualNetworkAddress
  VirtualNetworkAddressProperties: CloudVmClusterVirtualNetworkAddressProperties
  ActivationLinks: CloudAccountActivationLinks
  AllConnectionStringType: AutonomousDatabaseConnectionStringType
  AddRemoveDbNode: CloudVmClusterDBNodeContent
  ApexDetailsType: OracleApexDetailsType
  AutonomousDatabaseBaseProperties.timeCreated: CreatedOn
  AutonomousDatabaseBaseProperties.timeMaintenanceBegin: MaintenanceBeginOn
  AutonomousDatabaseBaseProperties.timeMaintenanceEnd: MaintenanceEndOn
  AutonomousDatabaseBaseProperties.nextLongTermBackupTimeStamp: NextLongTermBackupCreatedOn
  AutonomousDatabaseBaseProperties.timeDataGuardRoleChanged: DataGuardRoleChangedOn|date-time
  AutonomousDatabaseBaseProperties.timeDeletionOfFreeAutonomousDatabase: FreeAutonomousDatabaseDeletedOn|date-time
  #AutonomousDatabaseBaseProperties.timeLocalDataGuardEnabled: LocalDataGuardEnabledOn|date-time
  AutonomousDatabaseBaseProperties.timeOfLastFailover: LastFailoverHappenedOn|date-time
  AutonomousDatabaseBaseProperties.timeOfLastRefresh: LastRefreshHappenedOn|date-time
  AutonomousDatabaseBaseProperties.timeOfLastRefreshPoint: LastRefreshPointTimestamp|date-time
  AutonomousDatabaseBaseProperties.timeOfLastSwitchover: LastSwitchoverHappenedOn|date-time
  AutonomousDatabaseBaseProperties.timeReclamationOfFreeAutonomousDatabase: FreeAutonomousDatabaseStoppedOn|date-time
  AutonomousDatabaseCloneProperties.timeUntilReconnectCloneEnabled: ReconnectCloneEnabledOn|date-time
  AutonomousDatabaseStandbySummary.timeDataGuardRoleChanged: DataGuardRoleChangedOn|date-time
  AutonomousDatabaseStandbySummary.timeDisasterRecoveryRoleChanged: DisasterRecoveryRoleChangedOn|date-time
  AzureResourceProvisioningState: OracleDatabaseProvisioningState
  CloneType: AutonomousDatabaseCloneType
  CloudExadataInfrastructureProperties.timeCreated: CreatedOn|date-time
  CloudVmClusterProperties.timeCreated: CreatedOn|date-time
  VirtualNetworkAddressProperties.timeAssigned: AssignedOn
  ComputeModel: AutonomousDatabaseComputeModel
  ConnectionStringType: AutonomousDatabaseConnectionStrings
  ProfileType: AutonomousDatabaseConnectionStringProfile
  ConnectionUrlType: AutonomousDatabaseConnectionUrls
  ConsumerGroup: ConnectionConsumerGroup
  CustomerContact: OracleCustomerContact
  DatabaseEditionType: OracleDatabaseEditionType
  DataBaseType: OracleDataBaseType
  DbNodeActionEnum: DbNodeActionType
  DbServerPatchingDetails.timePatchingEnded: PatchingEndedOn
  DbServerPatchingDetails.timePatchingStarted: PatchingStartedOn
  DbServerProperties.timeCreated: CreatedOn
  DbServerProperties.exadataInfrastructureId: -|arm-id
  DiskRedundancy: CloudVmClusterDiskRedundancy
  DnsPrivateViewProperties.timeCreated: CreatedOn
  DnsPrivateViewProperties.timeUpdated: UpdatedOn
  DnsPrivateZoneProperties.timeCreated: CreatedOn
  GenerateType: WalletGenerateType
  HostFormatType: ConnectionHostFormatType
  Intent: OracleSubscriptionUpdateIntent
  LicenseModel: OracleLicenseModel
  LongTermBackUpScheduleDetails.timeOfBackup: BackupOn
  Month: MaintenanceMonth
  MonthName: MaintenanceMonthName
  NsgCidr: CloudVmClusterNsgCidr
  Objective: IormObjective
  OpenModeType: AutonomousDatabaseModeType
  PatchingMode: MaintenancePatchingMode
  PeerDbDetails: AutonomousDatabaseActionContent
  PermissionLevelType: AutonomousDatabasePermissionLevelType
  PortRange: CloudVmClusterPortRange
  Preference: MaintenancePreference
  PrivateIpAddressesFilter: PrivateIPAddressesContent
  PrivateIpAddressProperties: PrivateIPAddressResult
  PrivateIpAddressProperties.subnetId: -|arm-id
  ProtocolType: ConnectionProtocolType
  ProtocolType.TCP: Tcp
  ResourceProvisioningState: OracleDatabaseResourceProvisioningState
  RoleType: DataGuardRoleType
  SaasSubscriptionDetails.timeCreated: CreatedOn
  ScheduledOperationsType.scheduledStartTime: AutoStartOn|date-time
  ScheduledOperationsType.scheduledStopTime: AutoStopOn|date-time
  ScheduledOperationsTypeUpdate.scheduledStartTime: AutoStartOn|date-time
  ScheduledOperationsTypeUpdate.scheduledStopTime: AutoStopOn|date-time
  SessionModeType: ConnectionSessionModeType
  SourceType: AutonomousDatabaseSourceType
  SyntaxFormatType.Ezconnectplus: EzconnectPlus
  SystemVersionProperties: OracleSystemVersionProperties
  TlsAuthenticationType: ConnectionTlsAuthenticationType
  WorkloadType: AutonomousDatabaseWorkloadType
  WorkloadType.AJD: Ajd
  ZoneType: OracleDnsPrivateZoneType

prepend-rp-prefix:
  - DayOfWeek
  - DayOfWeekName
  - MaintenanceWindow

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
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
  Db: DB|db

```
