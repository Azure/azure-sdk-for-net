# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: Fabric
namespace: Azure.ResourceManager.Fabric
require: https://github.com/Azure/azure-rest-api-specs/blob/1754617c39d7a2f072ba014b3bb699ddea35f8b6/specification/fabric/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
  sample: false # temp
skip-csproj: true
modelerfour:
  flatten-payloads: false
  flatten-models: false
use-model-reader-writer: true

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

rename-mapping:
  CheckNameAvailabilityResponse: FabricCheckNameAvailabilityResult
  CheckNameAvailabilityRequest: FabricCheckNameAvailabilityContent
  CheckNameAvailabilityReason: FabricNameUnavailableReason
  CheckNameAvailabilityResult: FabricCheckNameAvailabilityResult
  ProvisioningState: FabricProvisioningState
  ResourceState: FabricResourceState
  RpSkuDetailsForNewResource: FabricSkuDetailsForNewCapacity
  RpSkuDetailsForNewResource.locations: -|azure-location
  RpSkuDetailsForExistingResource: FabricSkuDetailsForExistingCapacity
  RpSku: FabricSku
  RpSkuTier: FabricSkuTier
```
