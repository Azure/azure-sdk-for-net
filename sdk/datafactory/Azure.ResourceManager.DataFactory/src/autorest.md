# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DataFactory
namespace: Azure.ResourceManager.DataFactory
require: https://github.com/Azure/azure-rest-api-specs/blob/de400f7204d30d25543ac967636180728d52a88f/specification/datafactory/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
 
format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'

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
  MWS: Mws

directive:
  - from: Dataset.json
    where: $.definitions
    transform: >
      $.DatasetDataElement.properties.name['x-ms-client-name'] = 'columnName';
      $.DatasetDataElement.properties.type['x-ms-client-name'] = 'columnType';
      $.DatasetSchemaDataElement.properties.name['x-ms-client-name'] = 'schemaColumnName';
      $.DatasetSchemaDataElement.properties.type['x-ms-client-name'] = 'schemaColumnType';
      $.DatasetCompression.properties.type['x-ms-client-name'] = 'datasetCompressionType';

```
