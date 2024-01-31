# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: Workloads
namespace: Azure.ResourceManager.Workloads
require: https://github.com/Azure/azure-rest-api-specs/blob/c9a6e0a98a51ebc0c7a346f4fd425ba185f44b31/specification/workloads/resource-manager/readme.md
tag: package-2023-04
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
  skipped-operations:
  - monitors_Update
  - SAPVirtualInstances_Update
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

# mgmt-debug:
#  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  'locations': 'azure-location'
  'appLocation': 'azure-location'
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
  SAP: Sap
  ERS: Ers
  Db: DB|db
  LRS: Lrs
  GRS: Grs
  ZRS: Zrs
  SSD: Ssd
  Ha: HA|ha
  ECC: Ecc

rename-mapping:
  DiskDetails: SupportedConfigurationsDiskDetails
  DiskSkuName: DiskDetailsDiskSkuName
  StopRequest: SapStopContent
  # VirtualMachineConfiguration.vmSize: -|int
  Monitor.properties.monitorSubnet: monitorSubnetId|arm-id
  Monitor.properties.logAnalyticsWorkspaceArmId: -|arm-id
  Monitor.properties.msiArmId: -|arm-id
  Monitor.properties.storageAccountArmId: -|arm-id
  Monitor: SapMonitor
  ProviderInstance: SapProviderInstance
  ErrorDefinition: SapVirtualInstanceErrorDetail
  DiskSku: SapDiskSku
  ImageReference: SapImageReference
  LinuxConfiguration: SapLinuxConfiguration
  NamingPatternType: SapNamingPatternType
  OSConfiguration: SapOSConfiguration
  OSProfile: SapOSProfile
  OSType: SapOSType
  RoutingPreference: SapRoutingPreference
  SoftwareConfiguration: SapSoftwareConfiguration
  SshConfiguration: SapSshConfiguration
  SshKeyPair: SapSshKeyPair
  SshPublicKey: SapSshPublicKey
  SslPreference: SapSslPreference
  StorageConfiguration: SapStorageConfiguration
  VirtualMachineConfiguration: SapVirtualMachineConfiguration
  WindowsConfiguration: SapWindowsConfiguration
  DeployerVmPackages.url: PackageUri
  ExternalInstallationSoftwareConfiguration.centralServerVmId: -|arm-id
  DiscoveryConfiguration.centralServerVmId: -|arm-id
  DiskVolumeConfiguration.sizeGB: SizeInGB
  DiskDetails.sizeGB: SizeInGB
  MountFileShareConfiguration.id: fileShareId|arm-id
  MountFileShareConfiguration.privateEndpointId: -|arm-id

directive:
  - remove-operation: Operations_List
  - from: swagger-document
    where: $.definitions..subnetId
    transform: >
      $['x-ms-format'] = 'arm-id';
  - from: swagger-document
    where: $.definitions..subnet
    transform: >
      $['x-ms-format'] = 'arm-id';
      $['x-ms-client-name'] = 'subnetId';
  - from: swagger-document
    where: $.definitions..virtualMachineId
    transform: >
      $['x-ms-format'] = 'arm-id';
  - from: skus.json
    where: $.definitions
    transform: >
      $.SkuRestriction.properties.restrictionInfo = {
            '$ref': '#/definitions/RestrictionInfo',
            'description': 'The restriction information.'
          };
  - from: monitors.json
    where: $.definitions
    transform: >
      delete $.OperationsDefinition.properties.display['allOf'];
      $.OperationsDefinition.properties.display['$ref'] = '#/definitions/OperationsDisplayDefinition';
```
