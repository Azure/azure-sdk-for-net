# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: HybridConnectivity
namespace: Azure.ResourceManager.HybridConnectivity
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/3c162c839b8fe17544d9a3be8383a835dd42eb28/specification/hybridconnectivity/resource-manager/readme.md
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
  'etag': 'etag'
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
