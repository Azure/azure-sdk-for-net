# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: HDInsight
namespace: Azure.ResourceManager.HDInsight
require: https://github.com/Azure/azure-rest-api-specs/blob/bab2f4389eb5ca73cdf366ec0a4af3f3eb6e1f6d/specification/hdinsight/resource-manager/readme.md
tag: package-2021-06
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
  RSA: Rsa
  RSA15: Rsa15

directive:
  - from: cluster.json
    where: $.definitions
    transform: >
      $.Resource["x-ms-client-name"] = 'HDInsightClusterResponseData';
      $.StorageAccount.properties.saskey["x-ms-client-name"] = 'SasKey';

```
