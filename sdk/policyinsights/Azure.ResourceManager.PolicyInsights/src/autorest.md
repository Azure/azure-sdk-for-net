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
  PolicyRestrictions_CheckAtManagementGroupScope: CheckPolicyRestrictions
  PolicyRestrictions_CheckAtResourceGroupScope: CheckPolicyRestrictions
  PolicyRestrictions_CheckAtSubscriptionScope: CheckPolicyRestrictions
  PolicyEvents_ListQueryResultsForSubscription: GetPolicyEventQueryResults
  PolicyEvents_ListQueryResultsForResourceGroup: GetPolicyEventQueryResults
  PolicyEvents_ListQueryResultsForManagementGroup: GetPolicyEventQueryResults
  PolicyStates_ListQueryResultsForSubscription: GetPolicyStateQueryResults
  PolicyStates_ListQueryResultsForResourceGroup: GetPolicyStateQueryResults
  PolicyStates_ListQueryResultsForManagementGroup: GetPolicyStateQueryResults
  PolicyStates_SummarizeForManagementGroup: SummarizePolicyState
  PolicyStates_SummarizeForSubscription: SummarizePolicyState
  PolicyStates_TriggerResourceGroupEvaluation: TriggerPolicyStateEvaluation
  PolicyStates_TriggerSubscriptionEvaluation: TriggerPolicyStateEvaluation
  Remediations_ListDeploymentsAtResource: GetDeployments

operation-positions:
  PolicyMetadata_List: collection

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'locations': 'azure-location'

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

rename-mapping:
  ComplianceState: PolicyComplianceState
  Attestation.properties.expiresOn: ExpireOn
  Attestation.properties.policyAssignmentId: -|arm-id
  Remediation.properties.policyAssignmentId: -|arm-id
  CheckRestrictionsResult: CheckPolicyRestrictionsResult
  CheckRestrictionsRequest: CheckPolicyRestrictionsContent
  CheckManagementGroupRestrictionsRequest: CheckManagementGroupPolicyRestrictionsContent
  Summary: PolicySummary
  Remediation.properties.filters: Filter
  PolicyAssignmentSummary.policyAssignmentId: -|arm-id
  PolicyAssignmentSummary.policySetDefinitionId: -|arm-id
  SummaryResults: PolicySummaryResults
  PolicyDetails.policyDefinitionId: -|arm-id
  PolicyDetails.policyAssignmentId: -|arm-id
  PolicyDetails.policySetDefinitionId: -|arm-id
  PolicyEvent.policyAssignmentId: -|arm-id
  PolicyEvent.policyDefinitionId: -|arm-id
  PolicyEvent.resourceId: -|arm-id
  PolicyEvent.policySetDefinitionId: -|arm-id
  PolicyEvent.resourceLocation: -|azure-location
  PolicyEventsResourceType: PolicyEventType
  PolicyReference.policyDefinitionId: -|arm-id
  PolicyReference.policySetDefinitionId: -|arm-id
  PolicyReference.policyAssignmentId: -|arm-id
  PolicyState.resourceId: -|arm-id
  PolicyState.policyAssignmentId: -|arm-id
  PolicyState.policyDefinitionId: -|arm-id
  PolicyState.policySetDefinitionId: -|arm-id
  PolicyState.resourceLocation: -|azure-location
  PolicyStatesResource: PolicyStateType
  PolicyStatesSummaryResourceType: PolicyStateSummaryType

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
# resolving duplicate schemas
  - from: remediations.json
    where: $.definitions
    transform: >
      $.ErrorResponse['x-ms-client-name'] = 'RemediationErrorResponse';
      $.ErrorDefinition['x-ms-client-name'] = 'RemediationErrorDefinition';
# resolving duplicate schemas
  - from: attestations.json
    where: $.definitions
    transform: >
      $.ErrorResponse['x-ms-client-name'] = 'AttestationErrorResponse';
      $.ErrorDefinition['x-ms-client-name'] = 'AttestationErrorDefinition';
# resolving duplicate schemas
  - from: policyMetadata.json
    where: $.definitions
    transform: >
      $.ErrorResponse['x-ms-client-name'] = 'PolicyMetadataErrorResponse';
      $.ErrorDefinition['x-ms-client-name'] = 'PolicyMetadataErrorDefinition';
```
