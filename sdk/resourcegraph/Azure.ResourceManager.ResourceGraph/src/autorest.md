# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ResourceGraph
namespace: Azure.ResourceManager.ResourceGraph
require: https://github.com/Azure/azure-rest-api-specs/blob/1bd335533d57d11a33d41be9b5841e6986ec3567/specification/resourcegraph/resource-manager/readme.md
# default tag is a preview version
tag: 2024-04
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

rename-mapping:
  ErrorDetails: FacetErrorDetails
  QueryRequest: ResourceQueryContent
  QueryRequestOptions: ResourceQueryRequestOptions
  QueryResponse: ResourceQueryResult
  DateTimeInterval.start: StartOn
  DateTimeInterval.end: EndOn
  GraphQueryResource: ResourceGraphQuery
  GraphQueryResource.properties.timeModified: ModifiedOn

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

override-operation-name:
  Resources: GetResources
  # ResourcesHistory: GetResourceHistory

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

directive:
  # Remove resourceshistory.json and resourcechanges.json since these 2 are preview
  - from: resourceshistory.json
    where: $.paths
    transform: >
      for (var path in $)
      {
          delete $[path];
      }
  - from: resourcechanges.json
    where: $.paths
    transform: >
      for (var path in $)
      {
          delete $[path];
      }
```
