# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: PolicyInsights
namespace: Azure.ResourceManager.PolicyInsights
require: https://github.com/Azure/azure-rest-api-specs/blob/aa8a23b8f92477d0fdce7af6ccffee1c604b3c56/specification/policyinsights/resource-manager/readme.md
tag: package-2022-03
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

list-exception:
  - /providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.PolicyInsights/remediations/{remediationName}
  - /subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/remediations/{remediationName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.PolicyInsights/remediations/{remediationName}
  - /providers/Microsoft.PolicyInsights/policyMetadata/{resourceName}
  - /subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/attestations/{attestationName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.PolicyInsights/attestations/{attestationName}

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
  - remove-operation: Remediations_ListDeploymentsAtManagementGroup
  - remove-operation: Remediations_CancelAtManagementGroup
  - remove-operation: Remediations_ListDeploymentsAtResourceGroup
  - remove-operation: Remediations_CancelAtResourceGroup
  - from: remediations.json
    where: $.definitions
    transform: >
      $.ErrorResponse['x-ms-client-name'] = 'RemediationErrorResponse';
      $.ErrorDefinition['x-ms-client-name'] = 'RemediationErrorDefinition';
  - from: attestations.json
    where: $.definitions
    transform: >
      $.ErrorResponse['x-ms-client-name'] = 'AttestationErrorResponse';
      $.ErrorDefinition['x-ms-client-name'] = 'AttestationErrorDefinition';
  - from: policyMetadata.json
    where: $.definitions
    transform: >
      $.ErrorResponse['x-ms-client-name'] = 'PolicyMetadataErrorResponse';
      $.ErrorDefinition['x-ms-client-name'] = 'PolicyMetadataErrorDefinition';
```