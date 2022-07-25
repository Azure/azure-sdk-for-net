# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Logic
namespace: Azure.ResourceManager.Logic
require: https://github.com/Azure/azure-rest-api-specs/blob/353d84dac009c19ae776c25eb361f07e85f26c8d/specification/logic/resource-manager/readme.md
tag: package-2019-05
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/runs/{runName}/operations/{operationId}

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/runs/{runName}/operations/{operationId}: LogicAppWorkflowRunOperation
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/runs/{runName}: LogicAppWorkflowRun
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/runs/{runName}/actions/{actionName}/repetitions/{repetitionName}: LogicAppWorkflowRunActionRepetition
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/runs/{runName}/actions/{actionName}/repetitions/{repetitionName}/requestHistories/{requestHistoryName}: LogicAppWorkflowRunActionRepetitionRequestHistory
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/runs/{runName}/actions/{actionName}/requestHistories/{requestHistoryName}: LogicAppWorkflowRunActionRequestHistory
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/runs/{runName}/actions/{actionName}/scopeRepetitions/{repetitionName}: LogicAppWorkflowRunActionScopeRepetition

mgmt-debug: 
  show-serialized-names: true

rename-mapping:
  AssemblyDefinition: IntegrationAccountAssemblyDefinition
  BatchConfiguration: IntegrationAccountBatchConfiguration
  Workflow: LogicAppWorkflow
  WorkflowListResult: LogicAppWorkflowListResult
  WorkflowRunAction: LogicAppWorkflowRunAction
  WorkflowVersion: LogicAppWorkflowVersion
  WorkflowTrigger: LogicAppWorkflowTrigger
  WorkflowTriggerHistory: LogicAppWorkflowTriggerHistory
  WorkflowState: LogicAppWorkflowState
  WorkflowStatus: LogicAppWorkflowStatus
  WorkflowParameter: LogicAppWorkflowParameterInfo
  WorkflowOutputParameter: LogicAppWorkflowOutputParameterInfo
  WorkflowRun: LogicAppWorkflowRun
  WorkflowRunListResult: LogicAppWorkflowRunListResult
  WorkflowProvisioningState: LogicAppWorkflowProvisioningState
  WorkflowTriggerProvisioningState: LogicAppWorkflowTriggerProvisioningState
  WorkflowRunTrigger: LogicAppWorkflowRunTrigger
  WorkflowVersionListResult: LogicAppWorkflowVersionListResult
  WorkflowTriggerReference: LogicAppWorkflowTriggerReference
  WorkflowTriggerRecurrence: LogicAppWorkflowTriggerRecurrence
  WorkflowTriggerListResult: LogicAppWorkflowTriggerListResult
  WorkflowTriggerListCallbackUrlQueries: LogicAppWorkflowTriggerCallbackQueryParameterInfo
  WorkflowRunActionRepetitionDefinition: LogicAppWorkflowRunActionRepetitionDefinition
  WorkflowRunActionRepetitionDefinitionCollection: LogicAppWorkflowRunActionRepetitionList
  WorkflowTriggerHistoryListResult: LogicAppWorkflowTriggerHistoryListResult
  WorkflowTriggerCallbackUrl: LogicAppWorkflowTriggerCallbackUri
  WorkflowReference: LogicAppWorkflowReference
  WorkflowRunActionListResult: LogicAppWorkflowRunActionListResult
  WsdlService: LogicAppWsdlService
  WsdlImportMethod: LogicAppWsdlImportMethod
  Sku: LogicAppSku
  SkuName: LogicAppSkuName
  
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
  - from: logic.json
    where: $.definitions
    transform: >
      $.RetryHistory.properties.error['x-ms-client-name'] = 'ErrorResponse';
      $.OpenAuthenticationAccessPolicies.properties.policies['x-ms-client-name'] = 'AccessPolicies';

```
