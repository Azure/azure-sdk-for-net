# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
csharp: true
library-name: WorkloadOrchestration
namespace: Azure.ResourceManager.WorkloadOrchestration
require: https://github.com/Azure/azure-rest-api-specs/blob/229dfd2b11c491c4c48a738d8f16a2629957225a/specification/edge/resource-manager/Microsoft.Edge/configurationmanager/readme.md
tag: package-2025-06-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
operations-to-skip-lro-api-version-override:
- SolutionVersions_CreateOrUpdate
- SolutionTemplates_Delete
- SolutionTemplates_CreateVersion
- SolutionTemplates_RemoveVersion
- SolutionTemplates_CreateOrUpdate
- SolutionTemplateVersions_BulkDeploySolution
- SolutionTemplateVersions_BulkPublishSolution
- SolutionTemplateVersions_BulkReviewSolution
- SolutionVersions_Delete
- SolutionVersions_Update
- Solutions_Delete
- Solutions_Update
- Solutions_CreateOrUpdate
- Targets_Delete
- Targets_Update
- Targets_CreateOrUpdate
- Targets_InstallSolution
- Targets_PublishSolutionVersion
- Targets_RemoveRevision
- Targets_ResolveConfiguration
- Targets_ReviewSolutionVersion
- Targets_UninstallSolution
- Targets_UnstageSolutionVersion
- Targets_UpdateExternalValidationStatus
- Contexts_Delete
- Contexts_Update
- Contexts_CreateOrUpdate
- Schemas_Delete
- Schemas_CreateVersion
- Schemas_CreateOrUpdate
- SchemaVersions_Delete
- SchemaVersions_CreateOrUpdate
- ConfigTemplates_Delete
- ConfigTemplates_CreateVersion
- ConfigTemplates_CreateOrUpdate
- WorkflowVersions_Delete
- WorkflowVersions_Update
- WorkflowVersions_CreateOrUpdate
- Workflows_Delete
- Workflows_Update
- Workflows_CreateOrUpdate
- Executions_Delete
- Executions_Update
- Executions_CreateOrUpdate
- Diagnostics_Delete
- Diagnostics_Update
- Diagnostics_CreateOrUpdate
- DynamicSchemas_Delete
- DynamicSchemas_CreateOrUpdate
- DynamicSchemaVersions_Delete
- DynamicSchemaVersions_CreateOrUpdate
- Instances_Delete
- Instances_Update
- Instances_CreateOrUpdate
- SiteReferences_Delete
- SiteReferences_Update
- SiteReferences_CreateOrUpdate

# Skip API version resolution entirely for all resources
skip-api-version-override: true

# mgmt-debug:
#  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  'locations': 'azure-location'
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

rename-mapping:
  InstallSolutionParameter: WorkloadOrchestrationInstallSolutionContent
  BulkDeploySolutionParameter: WorkloadOrchestrationBulkDeploySolutionContent
  DeployJobParameter: WorkloadOrchestrationDeployJobContent
  BulkPublishSolutionParameter: WorkloadOrchestrationBulkPublishSolutionContent
  SolutionTemplateParameter: WorkloadOrchestrationSolutionTemplateContent
  RemoveRevisionParameter: WorkloadOrchestrationRemoveRevisionContent
  UpdateExternalValidationStatusParameter: WorkloadOrchestrationUpdateExternalValidationStatusContent
  VersionParameter: WorkloadOrchestrationVersionContent
  SolutionDependencyParameter: WorkloadOrchestrationSolutionDependencyContent
  SolutionVersionParameter: WorkloadOrchestrationSolutionVersionContent
  UninstallSolutionParameter: WorkloadOrchestrationUninstallSolutionContent
  PublishJobParameter: WorkloadOrchestrationPublishJobContent
  BulkReviewSolutionParameter: WorkloadOrchestrationBulkReviewSolutionContent
  RemoveVersionResponse: WorkloadOrchestrationRemoveVersionResult
  TaskOption: WorkloadOrchestrationTaskConfig
  # Resource and collection mappings to maintain Edge prefix for main resources
  Context: EdgeContext
  ContextCollection: EdgeContextCollection
  ContextData: EdgeContextData
  ContextResource: EdgeContextResource
  Schema: EdgeSchema
  SchemaCollection: EdgeSchemaCollection
  SchemaData: EdgeSchemaData
  SchemaResource: EdgeSchemaResource
  SchemaVersion: EdgeSchemaVersion
  SchemaVersionCollection: EdgeSchemaVersionCollection
  SchemaVersionData: EdgeSchemaVersionData
  SchemaVersionResource: EdgeSchemaVersionResource
  ConfigTemplate: EdgeConfigTemplate
  ConfigTemplateCollection: EdgeConfigTemplateCollection
  ConfigTemplateData: EdgeConfigTemplateData
  ConfigTemplateResource: EdgeConfigTemplateResource
  ConfigTemplateVersion: EdgeConfigTemplateVersion
  ConfigTemplateVersionCollection: EdgeConfigTemplateVersionCollection
  ConfigTemplateVersionData: EdgeConfigTemplateVersionData
  ConfigTemplateVersionResource: EdgeConfigTemplateVersionResource
  Target: EdgeTarget
  TargetCollection: EdgeTargetCollection
  TargetData: EdgeTargetData
  TargetResource: EdgeTargetResource
  SolutionTemplate: EdgeSolutionTemplate
  SolutionTemplateCollection: EdgeSolutionTemplateCollection
  SolutionTemplateData: EdgeSolutionTemplateData
  SolutionTemplateResource: EdgeSolutionTemplateResource
  SolutionTemplateVersion: EdgeSolutionTemplateVersion
  SolutionTemplateVersionCollection: EdgeSolutionTemplateVersionCollection
  SolutionTemplateVersionData: EdgeSolutionTemplateVersionData
  SolutionTemplateVersionResource: EdgeSolutionTemplateVersionResource
  SolutionVersion: EdgeSolutionVersion
  SolutionVersionCollection: EdgeSolutionVersionCollection
  SolutionVersionData: EdgeSolutionVersionData
  SolutionVersionResource: EdgeSolutionVersionResource
  Workflow: EdgeWorkflow
  WorkflowCollection: EdgeWorkflowCollection
  WorkflowData: EdgeWorkflowData
  WorkflowResource: EdgeWorkflowResource
  WorkflowVersion: EdgeWorkflowVersion
  WorkflowVersionCollection: EdgeWorkflowVersionCollection
  WorkflowVersionData: EdgeWorkflowVersionData
  WorkflowVersionResource: EdgeWorkflowVersionResource
  Instance: EdgeDeploymentInstance
  InstanceCollection: EdgeDeploymentInstanceCollection
  InstanceData: EdgeDeploymentInstanceData
  InstanceResource: EdgeDeploymentInstanceResource
  InstanceHistory: EdgeDeploymentInstanceHistory
  InstanceHistoryCollection: EdgeDeploymentInstanceHistoryCollection
  InstanceHistoryData: EdgeDeploymentInstanceHistoryData
  InstanceHistoryResource: EdgeDeploymentInstanceHistoryResource
  # Additional mappings for other types that need Edge prefix
  Solution: EdgeSolution
  SolutionCollection: EdgeSolutionCollection
  SolutionData: EdgeSolutionData
  SolutionResource: EdgeSolutionResource
  Job: EdgeJob
  JobCollection: EdgeJobCollection
  JobData: EdgeJobData
  JobResource: EdgeJobResource
  Execution: EdgeExecution
  ExecutionCollection: EdgeExecutionCollection
  ExecutionData: EdgeExecutionData
  ExecutionResource: EdgeExecutionResource
  Diagnostic: EdgeDiagnostic
  DiagnosticCollection: EdgeDiagnosticCollection
  DiagnosticData: EdgeDiagnosticData
  DiagnosticResource: EdgeDiagnosticResource
  DynamicSchema: EdgeDynamicSchema
  DynamicSchemaCollection: EdgeDynamicSchemaCollection
  DynamicSchemaData: EdgeDynamicSchemaData
  DynamicSchemaResource: EdgeDynamicSchemaResource
  DynamicSchemaVersion: EdgeDynamicSchemaVersion
  DynamicSchemaVersionCollection: EdgeDynamicSchemaVersionCollection
  DynamicSchemaVersionData: EdgeDynamicSchemaVersionData
  DynamicSchemaVersionResource: EdgeDynamicSchemaVersionResource
  SchemaReference: EdgeSchemaReference
  SchemaReferenceCollection: EdgeSchemaReferenceCollection
  SchemaReferenceData: EdgeSchemaReferenceData
  SchemaReferenceResource: EdgeSchemaReferenceResource
  SiteReference: EdgeSiteReference
  SiteReferenceCollection: EdgeSiteReferenceCollection
  SiteReferenceData: EdgeSiteReferenceData
  SiteReferenceResource: EdgeSiteReferenceResource
  # Patch models
  ContextPatch: EdgeContextPatch
  TargetPatch: EdgeTargetPatch
  SchemaPatch: EdgeSchemaPatch
  SchemaVersionPatch: EdgeSchemaVersionPatch
  SolutionPatch: EdgeSolutionPatch
  SolutionTemplatePatch: EdgeSolutionTemplatePatch
  SolutionVersionPatch: EdgeSolutionVersionPatch
  WorkflowPatch: EdgeWorkflowPatch
  WorkflowVersionPatch: EdgeWorkflowVersionPatch
  ConfigTemplatePatch: EdgeConfigTemplatePatch
  ConfigTemplateVersionPatch: EdgeConfigTemplateVersionPatch
  SolutionTemplateVersionPatch: EdgeSolutionTemplateVersionPatch
  Deployment: EdgeDeployment
  DeploymentCollection: EdgeDeploymentCollection
  DeploymentData: EdgeDeploymentData
  DeploymentResource: EdgeDeploymentResource
  DeploymentPatch: EdgeDeploymentPatch
  DeploymentVersion: EdgeDeploymentVersion
  DeploymentVersionCollection: EdgeDeploymentVersionCollection
  DeploymentVersionData: EdgeDeploymentVersionData
  DeploymentVersionResource: EdgeDeploymentVersionResource
  DeploymentVersionPatch: EdgeDeploymentVersionPatch

directive:
  - remove-operation: Operations_List
