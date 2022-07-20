# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ElasticSan
namespace: Azure.ResourceManager.ElasticSan
require: https://github.com/Azure/azure-rest-api-specs/blob/50ed15bd61ac79f2368d769df0c207a00b9e099f/specification/elasticsan/resource-manager/readme.md
tag: package-2021-11-20-preview
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
  MBps: Mbps
  LRS: Lrs
  Volume: ElasticSanVolume

prepend-rp-prefix:
- EncryptionType
- ProvisioningState

rename-mapping:
  Name: ElasticSanSkuName
  Tier: ElasticSanTier
  Action: VirtualNetworkRuleAction
  State: VirtualNetworkRuleState
```
