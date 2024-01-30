# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: PolicyInsights
namespace: Azure.ResourceManager.PolicyInsights
require: https://github.com/Azure/azure-rest-api-specs/blob/05a9cdab363b8ec824094ee73950c04594325172/specification/policyinsights/resource-manager/readme.md
tag: package-2022-09
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
  skipped-operations:
  - PolicyEvents_ListQueryResultsForResourceGroupLevelPolicyAssignment
  - PolicyStates_ListQueryResultsForResourceGroupLevelPolicyAssignment
  - PolicyStates_SummarizeForResourceGroupLevelPolicyAssignment
  - PolicyEvents_ListQueryResultsForPolicySetDefinition
  - PolicyEvents_ListQueryResultsForPolicyDefinition
  - PolicyEvents_ListQueryResultsForSubscriptionLevelPolicyAssignment
  - PolicyStates_ListQueryResultsForPolicySetDefinition
  - PolicyStates_SummarizeForPolicySetDefinition
  - PolicyStates_ListQueryResultsForPolicyDefinition
  - PolicyStates_SummarizeForPolicyDefinition
  - PolicyStates_ListQueryResultsForSubscriptionLevelPolicyAssignment
  - PolicyStates_SummarizeForSubscriptionLevelPolicyAssignment
  - PolicyEvents_ListQueryResultsForResource
  - PolicyStates_ListQueryResultsForResource
  - PolicyStates_SummarizeForResource
  - PolicyTrackedResources_ListQueryResultsForResource
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

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
  PolicyEvents_ListQueryResultsForResource: GetPolicyEventQueryResults
#  PolicyEvents_ListQueryResultsForPolicySetDefinition: GetPolicyEventQueryResults
#  PolicyEvents_ListQueryResultsForPolicyDefinition: GetPolicyEventQueryResults
#  PolicyEvents_ListQueryResultsForSubscriptionLevelPolicyAssignment: GetPolicyEventQueryResults
#  PolicyEvents_ListQueryResultsForResourceGroupLevelPolicyAssignment: GetPolicyEventQueryResults
  PolicyStates_ListQueryResultsForSubscription: GetPolicyStateQueryResults
  PolicyStates_ListQueryResultsForResourceGroup: GetPolicyStateQueryResults
  PolicyStates_ListQueryResultsForManagementGroup: GetPolicyStateQueryResults
  PolicyStates_ListQueryResultsForResource: GetPolicyStateQueryResults
#  PolicyStates_ListQueryResultsForPolicySetDefinition: GetPolicyStateQueryResults
#  PolicyStates_ListQueryResultsForPolicyDefinition: GetPolicyStateQueryResults
#  PolicyStates_ListQueryResultsForSubscriptionLevelPolicyAssignment: GetPolicyStateQueryResults
#  PolicyStates_ListQueryResultsForResourceGroupLevelPolicyAssignment: GetPolicyStateQueryResults
  PolicyStates_SummarizeForManagementGroup: SummarizePolicyStates
  PolicyStates_SummarizeForSubscription: SummarizePolicyStates
  PolicyStates_SummarizeForResourceGroup: SummarizePolicyStates
  PolicyStates_SummarizeForResource: SummarizePolicyStates
#  PolicyStates_SummarizeForPolicySetDefinition: SummarizePolicyStates
#  PolicyStates_SummarizeForPolicyDefinition: SummarizePolicyStates
#  PolicyStates_SummarizeForSubscriptionLevelPolicyAssignment: SummarizePolicyStates
#  PolicyStates_SummarizeForResourceGroupLevelPolicyAssignment: SummarizePolicyStates
  PolicyStates_TriggerResourceGroupEvaluation: TriggerPolicyStateEvaluation
  PolicyStates_TriggerSubscriptionEvaluation: TriggerPolicyStateEvaluation
  Remediations_ListDeploymentsAtResource: GetDeployments
  Remediations_CancelAtResource: Cancel
  PolicyTrackedResources_ListQueryResultsForSubscription: GetPolicyTrackedResourceQueryResults
  PolicyTrackedResources_ListQueryResultsForResourceGroup: GetPolicyTrackedResourceQueryResults
  PolicyTrackedResources_ListQueryResultsForManagementGroup: GetPolicyTrackedResourceQueryResults
  PolicyTrackedResources_ListQueryResultsForResource: GetPolicyTrackedResourceQueryResults

operation-positions:
  PolicyMetadata_List: collection

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'locations': 'azure-location'

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
  Odata: OData|odata
  QueryOptions: PolicyQuerySettings|policyQuerySettings

rename-mapping:
  ComplianceState: PolicyComplianceState
  Attestation: PolicyAttestation
  Remediation: PolicyRemediation
  Attestation.properties.expiresOn: ExpireOn
  Attestation.properties.policyAssignmentId: -|arm-id
  Attestation.properties.assessmentDate: AssessOn
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
  PolicyEvent.resourceType: ResourceTypeString
  PolicyEventsResourceType: PolicyEventType
  PolicyReference.policyDefinitionId: -|arm-id
  PolicyReference.policySetDefinitionId: -|arm-id
  PolicyReference.policyAssignmentId: -|arm-id
  PolicyState.resourceId: -|arm-id
  PolicyState.policyAssignmentId: -|arm-id
  PolicyState.policyDefinitionId: -|arm-id
  PolicyState.policySetDefinitionId: -|arm-id
  PolicyState.resourceLocation: -|azure-location
  PolicyState.resourceType: ResourceTypeString
  PolicyStatesResource: PolicyStateType
  PolicyStatesSummaryResourceType: PolicyStateSummaryType
  IfNotExistsEvaluationDetails.resourceId: -|arm-id
  PolicyDefinitionSummary.policyDefinitionId: -|arm-id
  PolicyTrackedResource: PolicyTrackedResourceRecord
  PolicyTrackedResource.lastUpdateUtc: LastUpdateOn
  PolicyTrackedResource.trackedResourceId: -|arm-id
  RemediationDeployment.remediatedResourceId: -|arm-id
  RemediationDeployment.deploymentId: -|arm-id
  RemediationDeployment.resourceLocation: -|azure-location
  TrackedResourceModificationDetails.deploymentId: -|arm-id
  PolicyTrackedResourcesResourceType: PolicyTrackedResourceType

models-to-treat-empty-string-as-null:
  - PolicyAssignmentSummary
  - PolicyDetails
  - PolicyEvent
  - PolicyReference
  - PolicyState
  - PolicyMetadataData
  - SlimPolicyMetadata

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
  - from: policyEvents.json
    where: $.parameters
    transform: >
      $.policyEventsResourceParameter['x-ms-client-name'] = 'policyEventType';
  - from: policyStates.json
    where: $.parameters
    transform: >
      $.policyStatesResourceParameter['x-ms-client-name'] = 'policyStateType';
      $.policyStatesSummaryResourceParameter['x-ms-client-name'] = 'policyStateSummaryType';
  - from: policyTrackedResources.json
    where: $.parameters
    transform: >
      $.policyTrackedResourcesResourceParameter['x-ms-client-name'] = 'policyTrackedResourceType';
```
