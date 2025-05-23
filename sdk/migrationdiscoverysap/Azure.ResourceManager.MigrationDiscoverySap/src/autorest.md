# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: MigrationDiscoverySap
namespace: Azure.ResourceManager.MigrationDiscoverySap
require: https://github.com/Azure/azure-rest-api-specs/blob/72bd8aba9c7ce9fccb47e4c651abcc8117427fd0/specification/workloads/resource-manager/Microsoft.Workloads/SAPDiscoverySites/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

rename-mapping:
  ServerInstance: SapDiscoveryServerInstance
  ErrorDefinition: SapDiscoveryErrorDetail
  ConfigurationData: ConfigurationDetail
  ExcelPerformanceData: ExcelPerformanceDetail
  NativePerformanceData: NativePerformanceDetail
  PerformanceData: PerformanceDetail
  DataSource: SapDiscoveryDataSource
  DatabaseType: SapDiscoveryDatabaseType
  DatabaseType.Db2: DB2
  DatabaseType.SAPASE: SapAse
  DatabaseType.SAPDB: SapDB
  ExtendedLocation: SapDiscoveryExtendedLocation
  OperatingSystem: SapDiscoveryOperatingSystem
  OperatingSystem.IBMAIX: IbmAix
  ProvisioningState: SapDiscoveryProvisioningState
  SapInstanceType.APP: App
  SapInstanceType.SCS: Scs

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
  SAP: Sap|sap

```
