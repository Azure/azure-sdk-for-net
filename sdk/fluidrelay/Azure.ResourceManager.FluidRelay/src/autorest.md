# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: fluidrelay
namespace: Azure.ResourceManager.fluidrelay
require: https://github.com/Azure/azure-rest-api-specs/blob/f92aaf88f4c9d1ffb9a014eba196d887a9288c3a/specification/fluidrelay/resource-manager/readme.md
tag: package-2022-02-15
output-folder: Generated/
clear-output-folder: true
skip-csproj: true
 

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
       $.FluidRelayServerUpdate.properties.location["x-ms-format"] = "azure-location";
       $.FluidRelayContainerProperties.properties.frsContainerId["format"] = "uuid";
       $.FluidRelayContainerProperties.properties.frsTenantId["format"] = "uuid";
       $.FluidRelayServerProperties.properties.frsTenantId["format"] = "uuid";

```
