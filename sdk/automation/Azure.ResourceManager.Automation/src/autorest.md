# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Automation
namespace: Azure.ResourceManager.Automation
require: https://github.com/Azure/azure-rest-api-specs/blob/d1b0569d8adbd342a1111d6a69764d099f5f717c/specification/automation/resource-manager/readme.md
tag: package-2022-02-22
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

directive:
  - from: SoftwareUpdateConfigurationRun.json
    where: $.definitions.softwareUpdateConfigurationRunProperties.properties.configuredDuration
    transform: >
        $["format"] = "duration";
        $["x-ms-format"] = "duration-constant";
```