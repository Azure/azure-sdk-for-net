# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: FluidRelay
namespace: Azure.ResourceManager.FluidRelay
require: https://github.com/Azure/azure-rest-api-specs/blob/fbe071bba84e3e724573b3fc4efdeb041174d547/specification/fluidrelay/resource-manager/readme.md
tag: package-2022-06-01
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
  Ips: IPs
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri

directive:
  - from: fluidrelay.json
    where: "$.definitions"
    transform: >
       $.FluidRelayContainerProperties.properties.frsContainerId["format"] = "uuid";
       $.FluidRelayContainerProperties.properties.frsTenantId["format"] = "uuid";
       $.FluidRelayServerProperties.properties.frsTenantId["format"] = "uuid";

```
