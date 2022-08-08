# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: FluidRelay
namespace: Azure.ResourceManager.FluidRelay
require: https://github.com/Azure/azure-rest-api-specs/blob/f92aaf88f4c9d1ffb9a014eba196d887a9288c3a/specification/fluidrelay/resource-manager/readme.md
tag: package-2022-02-15
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
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
  - from: fluidrelay.json
    where: "$.definitions"
    transform: >
       $.FluidRelayContainerProperties.properties.frsContainerId["format"] = "uuid";
       $.FluidRelayContainerProperties.properties.frsTenantId["format"] = "uuid";
       $.FluidRelayServerProperties.properties.frsTenantId["format"] = "uuid";

```
