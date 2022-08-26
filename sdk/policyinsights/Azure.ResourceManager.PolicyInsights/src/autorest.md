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

request-path-to-parent:
  /providers/Microsoft.PolicyInsights/policyMetadata: /providers/Microsoft.PolicyInsights/policyMetadata/{resourceName}

override-operation-name:
  PolicyMetadata_List: GetAll
operation-positions:
  PolicyMetadata_List: collection

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
  # TODO: Autorest.csharp should combine these redundancy methods into the scope one automatically.
  - from: remediations.json
    where: $.paths
    transform: >
      delete $['/providers/{managementGroupsNamespace}/managementGroups/{managementGroupId}/providers/Microsoft.PolicyInsights/remediations'];
      delete $['/providers/{managementGroupsNamespace}/managementGroups/{managementGroupId}/providers/Microsoft.PolicyInsights/remediations/{remediationName}'];
      delete $['/providers/{managementGroupsNamespace}/managementGroups/{managementGroupId}/providers/Microsoft.PolicyInsights/remediations/{remediationName}/listDeployments'];
      delete $['/providers/{managementGroupsNamespace}/managementGroups/{managementGroupId}/providers/Microsoft.PolicyInsights/remediations/{remediationName}/cancel'];
      delete $['/subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/remediations'];
      delete $['/subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/remediations/{remediationName}'];
      delete $['/subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/remediations/{remediationName}/listDeployments'];
      delete $['/subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/remediations/{remediationName}/cancel'];
      delete $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.PolicyInsights/remediations'];
      delete $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.PolicyInsights/remediations/{remediationName}'];
      delete $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.PolicyInsights/remediations/{remediationName}/listDeployments'];
      delete $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.PolicyInsights/remediations/{remediationName}/cancel'];
  # TODO: Autorest.csharp should combine these redundancy methods into the scope one automatically.
  - from: attestations.json
    where: $.paths
    transform: >
      delete $['/subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/attestations'];
      delete $['/subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/attestations/{attestationName}'];
      delete $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.PolicyInsights/attestations'];
      delete $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.PolicyInsights/attestations/{attestationName}'];
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