# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: ResourceConnector
namespace: Azure.ResourceManager.ResourceConnector
require: https://github.com/Azure/azure-rest-api-specs/blob/616302e10e5ce0f80d2f0eaf8002f3e39d033696/specification/resourceconnector/resource-manager/readme.md
#tag: package-2022-10-27
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

#mgmt-debug: 
#  show-serialized-names: true

prepend-rp-prefix:
  - Appliance
  - Distro
  - Status

rename-mapping:
  ApplianceGetTelemetryConfigResult: ApplianceTelemetryConfigResult
  ApplianceListCredentialResults: ApplianceClusterUserCredentialResult
  ApplianceListKeysResults: ApplianceClusterUserKeysResult
  ArtifactProfile: ApplianceArtifactProfile
  Distro.AKSEdge: AksEdge
  Provider: ApplianceProvider
  Provider.VMWare: VMware
  Provider.HCI: Hci
  SSHKey: ApplianceSshKey
  SupportedVersion: ApplianceSupportedVersion
  SupportedVersionCatalogVersion: ApplianceSupportedVersionCatalogVersion
  SupportedVersionCatalogVersionData: ApplianceSupportedVersionCatalogVersionProperties
  SupportedVersionMetadata: ApplianceSupportedVersionMetadata
  UpgradeGraph: ApplianceUpgradeGraph
  UpgradeGraphProperties: ApplianceUpgradeGraphProperties

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

directive:
  - remove-operation: Appliances_ListOperations
```
