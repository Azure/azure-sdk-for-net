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
directive:
  - remove-operation: NetworkFunction_ListOperations
  - from: swagger-document
    where: $.definitions..etag
    transform: >
      $['x-ms-format'] = 'etag';
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