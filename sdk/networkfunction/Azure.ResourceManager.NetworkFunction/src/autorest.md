# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: NetworkFunction
namespace: Azure.ResourceManager.NetworkFunction
require: https://github.com/Azure/azure-rest-api-specs/blob/8dac2febba482c00f1a472cc62a63ca5d83dc9f9/specification/networkfunction/resource-manager/readme.md
tag: package-2021-09-01-preview
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
  - remove-operation: NetworkFunction_ListOperations
  - from: swagger-document
    where: $.definitions
    transform: >
      $.SystemData.properties.lastModifiedAt = {
          'type': 'string',
          'format': 'date-time',
          'description': 'The timestamp of resource last modification (UTC)'
        };
      $.ProvisioningState['x-ms-enum']['name'] = 'CollectorProvisioningState';
      $.IngestionSourcesPropertiesFormat.properties.sourceType['x-ms-enum']['name'] = 'IngestionSourceType';
      $.EmissionPolicyDestination.properties.destinationType['x-ms-enum']['name'] = 'EmissionDestinationType';

```
