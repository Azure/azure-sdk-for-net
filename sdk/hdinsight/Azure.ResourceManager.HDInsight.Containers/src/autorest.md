# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
require: https://github.com/Azure/azure-rest-api-specs/blob/5372f410f6af3de9559b63defbd556a7b10c4e65/specification/hdinsight/resource-manager/Microsoft.HDInsight/HDInsightOnAks/readme.md
library-name: HDInsightContainers
namespace: Azure.ResourceManager.HDInsight.Containers
clear-output-folder: true
skip-csproj: true
output-folder: Generated/

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
#  '*Uri': 'Uri'  # To DO we need to make sure we can support Uri class before GA
#  '*Uris': 'Uri' # To Do we need to make sure we can support Uri class before GA

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
