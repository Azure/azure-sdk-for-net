# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: SqlVirtualMachine
namespace: Azure.ResourceManager.SqlVirtualMachine
require: https://github.com/Azure/azure-rest-api-specs/blob/bab2f4389eb5ca73cdf366ec0a4af3f3eb6e1f6d/specification/sqlvirtualmachine/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  '*ResourceId': 'arm-id'
  'IPAddress': 'ip-address'

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
  ADD: Add
  NEW: New
  ALL: All
  NO: No
  SQL: Sql
  Db: DB
  SqlVirtualMachine: SqlVm
  Wsfc: WindowsServerFailoverCluster

rename-mapping:
  LoadBalancerConfiguration: AvailabilityGroupListenerLoadBalancerConfiguration
  PrivateIPAddress: AvailabilityGroupListenerPrivateIPAddress
  AgConfiguration: AvailabilityGroupConfiguration
  AgReplica: AvailabilityGroupReplica
  AgReplica.sqlVirtualMachineInstanceId: -|arm-id
  Commit: AvailabilityGroupReplicaCommitMode
  Failover: AvailabilityGroupReplicaFailoverMode
  Role: AvailabilityGroupReplicaRole
  AutoBackupSettings.backupSystemDbs: AreSystemDbsIncludedInBackup
  AutoBackupSettings.enableEncryption: IsEncryptionEnabled
  DayOfWeek: SqlVmAutoPatchingDayOfWeek
  ConnectivityType: SqlServerConnectivityType
  FullBackupFrequencyType: SqlVmFullBackupFrequency
  ScaleType: SqlVmGroupScaleType
  Schedule: SqlVmAssessmentSchedule
  SQLInstanceSettings.maxServerMemoryMB: MaxServerMemoryInMB
  SQLInstanceSettings.minServerMemoryMB: MinServerMemoryInMB
  ReadableSecondary: ReadableSecondaryMode
  AutoBackupSettings: SqlVmAutoBackupSettings
  AutoBackupSettings.fullBackupStartTime: FullBackupStartHour
  AutoBackupSettings.retentionPeriod: RetentionPeriodInDays
  AutoPatchingSettings: SqlVmAutoPatchingSettings
  AutoPatchingSettings.maintenanceWindowDuration: MaintenanceWindowDurationInMinutes
  BackupScheduleType: SqVmBackupScheduleType
  ClusterConfiguration: SqlVmClusterConfiguration
  AssessmentSettings: SqlVmAssessmentSettings
  AssessmentDayOfWeek: SqlVmAssessmentDayOfWeek
  ClusterManagerType: SqlVmClusterManagerType
  ClusterSubnetType: SqlVmClusterSubnetType
  StorageConfigurationSettings: SqlVmStorageConfigurationSettings
  StorageConfigurationSettings.sqlSystemDbOnDataDisk: IsSqlSystemDBOnDataDisk
  KeyVaultCredentialSettings: SqlVmKeyVaultCredentialSettings
  ServerConfigurationsManagementSettings: SqlServerConfigurationsManagementSettings
  DiskConfigurationType: SqlVmDiskConfigurationType
  StorageWorkloadType: SqlVmStorageWorkloadType
  AutoBackupDaysOfWeek: SqlVmAutoBackupDayOfWeek
  SqlVirtualMachine.properties.wsfcStaticIp: -|ip-address
  SqlStorageSettings.luns: LogicalUnitNumbers
  SQLTempDbSettings.luns: LogicalUnitNumbers
  WsfcDomainProfile.ouPath: OrganizationalUnitPath

override-operation-name:
  SqlVirtualMachines_ListBySqlVmGroup: GetSqlVmsBySqlVmGroup
directive:
  - from: sqlvm.json
    where: $.definitions..enable
    transform: >
      $['x-ms-client-name'] = 'IsEnabled';
  - from: sqlvm.json
    where: $.definitions.LoadBalancerConfiguration.properties.sqlVirtualMachineInstances.items
    transform: >
      $['x-ms-format'] = 'arm-id';
```
