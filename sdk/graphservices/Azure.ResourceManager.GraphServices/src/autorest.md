# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: GraphServices
namespace: Azure.ResourceManager.GraphServices
require: https://github.com/Azure/azure-rest-api-specs/blob/7b9aa4cc7456fd7ef2bc3166dba1a77bec6bd52e/specification/graphservicesprod/resource-manager/readme.md
# tag: package-2022-09-22-preview
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

prepend-rp-prefix:
    - ProvisioningState
    - AccountResource
    - AccountResourceList
    - AccountPatchResource
    - AccountResourceProperties
    
directive:
    - remove-operation: 'Operation_List'

```
