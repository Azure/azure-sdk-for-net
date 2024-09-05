# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: ContainerOrchestratorRuntime
namespace: Azure.ResourceManager.ContainerOrchestratorRuntime
require: https://github.com/Azure/azure-rest-api-specs/blob/c02b366afa77a3e2a746719cea713b231b4b41bb/specification/kubernetesruntime/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
tag: package-2024-03-01

# mgmt-debug:
#   show-serialized-names: true

rename-mapping:
  ServiceResource.properties.rpObjectId: -|uuid
  ProvisioningState: ContainerOrchestratorProvisioningState
  AccessMode: StorageClassAccessMode

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

```
