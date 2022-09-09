# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: LoadTestService
namespace: Azure.ResourceManager.LoadTestService
input-file: D:\Work\MALT\azure-rest-api-specs-pr\specification\loadtestservice\resource-manager\Microsoft.LoadTestService\preview\2022-04-15-preview\loadtestservice.json
#require: D:\Work\MALT\azure-rest-api-specs-pr\specification\loadtestservice\resource-manager\Microsoft.LoadTestService\preview\2022-08-01-preview\loadtestservice.json
tag: package-2022-04-15-preview
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

```