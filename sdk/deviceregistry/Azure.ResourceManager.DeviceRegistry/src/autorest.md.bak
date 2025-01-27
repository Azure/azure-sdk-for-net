# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: DeviceRegistry
namespace: Azure.ResourceManager.DeviceRegistry
require: https://github.com/Azure/azure-rest-api-specs/blob/b440cf2c8cffa273a680b49b082faef69a4bee13/specification/deviceregistry/resource-manager/readme.md
tag: package-preview-2024-09
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

prepend-rp-prefix:
  - Asset
  - AssetEndpointProfile
  - DiscoveredAsset
  - DiscoveredAssetEndpointProfile
  - SchemaRegistry
  - Schema
  - SchemaVersion
  - BillingContainer
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
