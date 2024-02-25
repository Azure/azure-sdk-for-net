# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Confluent
namespace: Azure.ResourceManager.Confluent
require: https://github.com/Azure/azure-rest-api-specs/blob/fca48bec19cc5aab0a45c0769bfca0f667164dbf/specification/confluent/resource-manager/readme.md
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

prepend-rp-prefix:
  - ProvisionState
  - UserDetail
  - OfferDetail
  - SaaSOfferStatus

rename-mapping:
  OrganizationResource: ConfluentOrganization
  OrganizationResource.properties.organizationId: -|uuid
  OrganizationResourceListResult: ConfluentOrganizationListResult
  ConfluentAgreementResource: ConfluentAgreement
  ConfluentAgreementResource.properties.accepted: IsAccepted
  ConfluentAgreementResource.properties.retrieveDatetime: RetrieveOn
  OrganizationResourceUpdate: ConfluentOrganizationPatch
  ConfluentAgreementResourceListResponse: ConfluentAgreementListResult

override-operation-name:
  Validations_ValidateOrganization: ValidateOrganization
directive:
  - remove-operation: OrganizationOperations_List
```
