# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: HybridConnectivity
namespace: Azure.ResourceManager.HybridConnectivity
require: https://github.com/Azure/azure-rest-api-specs/blob/a416080c85111fbe4e0a483a1b99f1126ca6e97c/specification/hybridconnectivity/resource-manager/readme.md
tag: package-2021-10-06-preview
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
  Vmos: VmOS
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
  - rename-model:
      from: EndpointAccessResource
      to: TargetResourceEndpointAccess
  - from: swagger-document
    where: $.definitions.EndpointProperties.properties.type
    transform: >
      $["x-ms-client-name"] = "EndpointType";
      $["x-ms-enum"]["name"] = "EndpointType"
  - from: swagger-document
    where: $.parameters.ResourceUriParameter
    transform: >
      $["x-ms-client-name"] = "scope"

```
