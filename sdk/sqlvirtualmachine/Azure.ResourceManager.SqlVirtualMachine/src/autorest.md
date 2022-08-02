# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: SqlVirtualMachine
namespace: Azure.ResourceManager.SqlVirtualMachine
require: https://github.com/Azure/azure-rest-api-specs/blob/bab2f4389eb5ca73cdf366ec0a4af3f3eb6e1f6d/specification/sqlvirtualmachine/resource-manager/readme.md
tag: package-2022-02
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  '*ResourceId': 'arm-id'
  'IPAddress': 'ip-address'

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
  ADD: Add
  NEW: New
  ALL: All
  NO: No
  SQL: Sql
  Db: DB
  Ou: OU

prepend-rp-prefix:
  - ClusterConfiguration
  - AssessmentSettings
  - AssessmentDayOfWeek

rename-mapping:
  LoadBalancerConfiguration: AvailabilityGroupListenerLoadBalancerConfiguration
  PrivateIPAddress: AvailabilityGroupListenerPrivateIPAddress
  AgConfiguration: AvailabilityGroupConfiguration
  AgReplica: AvailabilityGroupReplica
  Commit: AvailabilityGroupReplicaCommitMode
  Failover: AvailabilityGroupReplicaFailoverMode
  Role: AvailabilityGroupReplicaRole
  AutoBackupSettings.backupSystemDbs: IsSystemDbsIncludedInBackup
  AutoBackupSettings.enableEncryption: IsEncryptionEnabled
  DayOfWeek: AutoPatchingDayOfWeek
  ConnectivityType: SqlServerConnectivityType
  FullBackupFrequencyType: FullBackupFrequency
  ScaleType: SqlVirtualMachineGroupScaleType
  Schedule: SqlVirtualMachineAssessmentSchedule
  SQLInstanceSettings.maxServerMemoryMB: MaxServerMemoryInMB
  SQLInstanceSettings.minServerMemoryMB: MinServerMemoryInMB

directive:
  - from: sqlvm.json
    where: $.definitions..enable
    transform: >
      $['x-ms-client-name'] = 'IsEnabled';
```
