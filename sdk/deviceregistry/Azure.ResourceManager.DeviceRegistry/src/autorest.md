# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: DeviceRegistry
namespace: Azure.ResourceManager.DeviceRegistry
require: https://github.com/Azure/azure-rest-api-specs/blob/9549a0e63c97d766ddadd56c71b4ad04c096dd3f/specification/deviceregistry/resource-manager/readme.md
#tag: package-preview-2023-11
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
  Event: AssetEvent

prepend-rp-prefix:
  - Asset
  - AssetEndpointProfile
  - ExtendedLocation
  - ProvisioningState

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
  - remove-operation: 'OperationStatus_Get'

```
