# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
generate-model-factory: false
csharp: true
library-name: BotService
namespace: Azure.ResourceManager.BotService
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/af1be2677e619e483210064ff658e62ec25053aa/specification/botservice/resource-manager/readme.md
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
  - from: botservice.json
    where: $.paths..parameters[?(@.name=='channelName')]
    transform: >
      $ = {
            "$ref": "#/parameters/channelNameParameter"
          };
  - from: botservice.json
    where: $.definitions
    transform: >
      $.EmailChannelAuthMethod['type'] = 'integer';
  - from: botservice.json
    where: $.parameters
    transform: >
      $.channelNameParameter['x-ms-enum']['modelAsString'] = true;

```
