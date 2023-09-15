# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: EnergyServices
namespace: Azure.ResourceManager.EnergyServices
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/2feaf7f24cc26a7274c9fd79015ae62b1d273986/specification/oep/resource-manager/readme.md
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
  DataPartitionAddOrRemoveRequest: DataPartitionAddOrRemoveContent
  CheckNameAvailabilityRequest: EnergyServiceNameAvailabilityContent
  CheckNameAvailabilityReason: EnergyServiceNameUnavailableReason
  CheckNameAvailabilityResponse: EnergyServiceNameAvailabilityResult
  DataPartitionProperties: DataPartition
  DataPartitionNames: DataPartitionName
```
