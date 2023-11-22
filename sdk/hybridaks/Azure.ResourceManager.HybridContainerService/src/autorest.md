# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: HybridContainerService
namespace: Azure.ResourceManager.HybridContainerService
require: https://github.com/Azure/azure-rest-api-specs/blob/21467ecae50d3ec069557cc6841d91fd805cc3b3/specification/hybridaks/resource-manager/readme.md
# tag: package-preview-2023-11
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
  skipped-operations:
  - HybridContainerService_ListOrchestrators
  - HybridContainerService_ListVMSkus
skip-csproj: true
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

rename-mapping:
  ProvisionedClustersResponse: ProvisionedCluster

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
  - AgentPool
  - VirtualNetworks
```
