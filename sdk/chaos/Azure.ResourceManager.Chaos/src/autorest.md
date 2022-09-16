# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Chaos
namespace: Azure.ResourceManager.Chaos
require: https://github.com/Azure/azure-rest-api-specs/blob/650a2be17c499104c7ad20f7a38f33f582170308/specification/chaos/resource-manager/readme.md
tag: package-2022-07-01-preview
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
  - from: experiments.json
    where: $.definitions
    transform: >
      $.delayAction.properties.duration['x-ms-format'] = 'duration-constant';
      $.continuousAction.properties.duration['x-ms-format'] = 'duration-constant';

```