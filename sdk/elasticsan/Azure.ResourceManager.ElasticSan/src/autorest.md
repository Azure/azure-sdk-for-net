# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: elasticsan
namespace: Azure.ResourceManager.elasticsan
require: https://github.com/Azure/azure-rest-api-specs/blob/50ed15bd61ac79f2368d769df0c207a00b9e099f/specification/elasticsan/resource-manager/readme.md
tag: package-2021-11-20-preview
output-folder: Generated/
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
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
  MBps: Mbps
  LRS: Lrs
  Volume: ElasticSanVolume
directive:
  - from: elasticsan.json
    where: $.definitions
    transform: >
      $.Sku.properties.name['x-ms-enum']['name'] = 'ElasticSanSkuName';
      $.Sku.properties.tier['x-ms-enum']['name'] = 'ElasticSanTier';
      $.VirtualNetworkRule.properties.state['x-ms-enum']['name'] = 'VirtualNetworkRuleState';
      $.SkuLocationInfo.properties.location['x-ms-format'] = 'azure-location';

```