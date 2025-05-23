# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Maps
namespace: Azure.ResourceManager.Maps
require: https://github.com/Azure/azure-rest-api-specs/blob/d8220a01ae67dedf6f0bbb5deebe941dc7b728d3/specification/maps/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

rename-mapping:
  CreatorList: MapsCreatorListResult
  Kind: MapsAccountKind
  Name: MapsSkuName
  MapsAccountProperties.uniqueId: -|uuid
  MapsAccountUpdateParameters.properties.uniqueId: -|uuid
  MapsAccountKeys.primaryKeyLastUpdated: primaryKeyLastUpdatedOn|date-time
  MapsAccountKeys.secondaryKeyLastUpdated: secondaryKeyLastUpdatedOn|date-time

prepend-rp-prefix:
  - Creator
  - CreatorProperties
  - KeyType
  - LinkedResource
  - SigningKey
  - CorsRule
  - Encryption
  - InfrastructureEncryption
  - IdentityType

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
  AccountSasContent: MapsAccountSasContent

directive:
  - remove-operation: 'Maps_ListOperations'
  - remove-operation: 'Maps_ListSubscriptionOperations'

```
