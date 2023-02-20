# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: ResourceHealth
namespace: Azure.ResourceManager.ResourceHealth
require: https://github.com/Azure/azure-rest-api-specs/tree/5ad3e3cef3193e676d3d4abe80423515f19c9a1e/specification/resourcehealth/resource-manager/readme.md
# tag: package-preview-2022-10
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

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/providers/Microsoft.ResourceHealth/events/{eventTrackingId}/impactedResources/{impactedResourceName}: EventImpactedResource
  /providers/Microsoft.ResourceHealth/events/{eventTrackingId}/impactedResources/{impactedResourceName}: EventImpactedResource

directive:
  - from: ResourceHealth.json
    where: $.definitions
    transform: >
      $.availabilityStatus.properties.type['x-ms-client-name'] = 'ResourceType';
      $.link.properties.type['x-ms-client-name'] = 'LinkType';
```