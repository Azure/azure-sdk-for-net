# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ExtendedLocations
namespace: Azure.ResourceManager.ExtendedLocations
require: https://github.com/Azure/azure-rest-api-specs/blob/691920cda83cc0b89a8c821d0bb285100fad22b4/specification/extendedlocation/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

rename-mapping:
  CustomLocationPropertiesAuthentication: CustomLocationAuthentication
  EnabledResourceType: CustomLocationEnabledResourceType
  EnabledResourceTypePropertiesTypesMetadataItem: CustomLocationEnabledResourceTypeMetadata
  EnabledResourceTypesListResult: CustomLocationEnabledResourceTypesResult
  HostType: CustomLocationHostType

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'clusterExtensionIds': 'arm-id'
  'clusterExtensionId': 'arm-id'
  'HostResourceId': 'arm-id'

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
  - remove-operation: 'CustomLocations_ListOperations'
```
