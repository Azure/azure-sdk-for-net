# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: HardwareSecurityModules
namespace: Azure.ResourceManager.HardwareSecurityModules
require: https://github.com/Azure/azure-rest-api-specs/blob/9a3161dbc683120d907689209a6eebd450af8c3d/specification/hardwaresecuritymodules/resource-manager/readme.md
#tag: package-2023-12-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

rename-mapping:
  NetworkInterface.id: -|arm-id
  OutboundEnvironmentEndpointCollection: OutboundEnvironmentEndpointListResult
  PrivateLinkResource: HardwareSecurityModulesPrivateLinkData

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
  # CodeGen don't support some definitions in v4 & v5 common types, here is an issue https://github.com/Azure/autorest.csharp/issues/3537 opened to fix this problem
  - from: v4/types.json
    where: $.definitions
    transform: >
      delete $.Resource.properties.id.format;
  - from: v5/types.json
    where: $.definitions
    transform: >
      delete $.Resource.properties.id.format;
  # The SystemData is defined in common types
  - from: dedicatedhsm.json
    where: $.definitions
    transform: >
      $.DedicatedHsm.properties.systemData['$ref'] = '../../../../../common-types/resource-management/v3/types.json#/definitions/systemData';
      delete $.SystemData;
      delete $.IdentityType;
  # CodeGen doesn't support `x-ms-client-default`, here is an issue https://github.com/Azure/autorest.csharp/issues/3475 opened to eliminate this attribute
  - from: cloudhsm.json
    where: $.definitions
    transform: >
      delete $.CloudHsmClusterSku.properties.family['x-ms-client-default'];
```
