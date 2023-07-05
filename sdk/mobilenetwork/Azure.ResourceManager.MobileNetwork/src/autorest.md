# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: MobileNetwork
namespace: Azure.ResourceManager.MobileNetwork
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/a8cb7f03bd77ce9162e96592bfbeb1e0b2060262/specification/mobilenetwork/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

request-path-to-resource-name:
  /providers/Microsoft.MobileNetwork/packetCoreControlPlaneVersions/{versionName}: TenantPacketCoreControlPlaneVersion
  /subscriptions/{subscriptionId}/providers/Microsoft.MobileNetwork/packetCoreControlPlaneVersions/{versionName}: SubscriptionPacketCoreControlPlaneVersion

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

directive:
  # CodeGen don't support some definitions in v4 & v5 common types, here is an issue https://github.com/Azure/autorest.csharp/issues/3537 opened to fix this problem
  - from: v5/types.json
    where: $.definitions
    transform: >
      delete $.Resource.properties.id.format;
  # CodeGen don't support some definitions in v4 & v5 common types, in v4 and v5 subscriptionId has the format of uuid, but the generator is not correctly handling it right now
  - from: v5/types.json
    where: $.parameters.SubscriptionIdParameter
    transform: >
      delete $.format;
```
