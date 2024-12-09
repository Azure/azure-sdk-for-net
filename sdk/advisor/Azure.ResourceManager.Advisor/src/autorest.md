# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Advisor
namespace: Azure.ResourceManager.Advisor
require: https://github.com/Azure/azure-rest-api-specs/blob/db6d33733cd1eb939b863a6cdbcb9de12ac002e1/specification/advisor/resource-manager/readme.md
tag: package-2020-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

acronym-mapping:
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

list-exception:
  - /{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}/suppressions/{name}

override-operation-name:
  Configurations_ListBySubscription: GetConfigurations
  Configurations_ListByResourceGroup: GetConfigurations
  Configurations_CreateInResourceGroup: CreateConfiguration
  Configurations_CreateInSubscription: CreateConfiguration

directive:
  - from: advisor.json
    where: $.paths..parameters[?(@.name === 'resourceUri')]
    transform: >
      $['x-ms-skip-url-encoding'] = true;

```
