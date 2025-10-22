# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ManagedServices
namespace: Azure.ResourceManager.ManagedServices
# default tag is package-2022-10
require: https://github.com/Azure/azure-rest-api-specs/blob/55dd4f72d2b2769c1e02f2b952e597f806d40f9a/specification/managedservices/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
  - OperationsWithScope_List
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

requestion-path-to-parent:
  /{scope}/providers/Microsoft.ManagedServices/marketplaceRegistrationDefinitions: /{scope}/providers/Microsoft.ManagedServices/marketplaceRegistrationDefinitions/{marketplaceIdentifier}

rename-mapping:
  MarketplaceRegistrationDefinition: ManagedServicesMarketplaceRegistration
  MarketplaceRegistrationDefinitionProperties: ManagedServicesMarketplaceRegistrationProperties
  RegistrationDefinition: ManagedServicesRegistration
  RegistrationDefinitionProperties: ManagedServicesRegistrationProperties
  RegistrationDefinitionList: ManagedServicesRegistrationListResult
  RegistrationAssignmentList: ManagedServicesRegistrationAssignmentListResult
  RegistrationAssignmentPropertiesRegistrationDefinition: ManagedServicesRegistrationAssignmentRegistrationData
  RegistrationAssignmentPropertiesRegistrationDefinitionProperties: ManagedServicesRegistrationAssignmentRegistrationProperties
  RegistrationAssignmentProperties.registrationDefinitionId: registrationId|arm-id

prepend-rp-prefix:
  - Authorization
  - RegistrationAssignment
  - RegistrationAssignmentProperties
  - ProvisioningState
  - EligibleApprover
  - EligibleAuthorization
  - JustInTimeAccessPolicy

format-by-name-rules:
  'tenantId': 'uuid'
  '*TenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'principalId': 'uuid'
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
  - remove-operation: OperationsWithScope_List # this is an operation that lists all the RestApis in a scope. We have one operation to list operations on the tenant level in resourcemanager, therefore this operation should be here
  - remove-operation: MarketplaceRegistrationDefinitionsWithoutScope_List
  - remove-operation: MarketplaceRegistrationDefinitionsWithoutScope_Get
  - from: managedservices.json
    where: $.parameters.registrationDefinitionIdParameter
    transform: >
      $['x-ms-client-name'] = 'registrationId';
```
