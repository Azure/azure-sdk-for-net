# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DataFactory
namespace: Azure.ResourceManager.DataFactory
require: https://github.com/Azure/azure-rest-api-specs/blob/de400f7204d30d25543ac967636180728d52a88f/specification/datafactory/resource-manager/readme.md
tag: package-2018-06
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

mgmt-debug: 
  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'PurviewResourceId': 'arm-id'

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
  MWS: Mws
  Etag: ETag|etag
  Db: DB|db

rename-mapping:
  AccessPolicyResponse: FactoryDataPlaneAccessAccessPolicyResult
  Activity: PipelineActivityInfo
  ActivityDependency: PipelineActivityDependencyInfo
  ActivityPolicy: PipelineActivityPolicyInfo
  ActivityRun: PipelineActivityRunInfo
  ActivityRunsQueryResponse: PipelineActivityRunsQueryResult
  AppendVariableActivity: PipelineActivityAppendVariableInfo
  CopySource: CopyActivitySource
  CreateRunResponse: CreateRunResult
  EncryptionConfiguration: FactoryEncryptionConfiguration
  ExposureControlBatchResponse: ExposureControlBatchResult
  ExposureControlResponse: ExposureControlResult
  ExposureControlRequest: ExposureControlContent
  Factory: DataFactory
  GitHubAccessTokenResponse: GitHubAccessTokenResult
  IntegrationRuntimeResource: DataFactoryIntegrationRuntime
  LinkedServiceResource: DataFactoryLinkedService
  ManagedPrivateEndpointResource: DataFactoryPrivateEndpoint
  ManagedVirtualNetworkResource: DataFactoryVirtualNetwork
  PipelineResource: DataFactoryPipeline
  PrivateEndpointConnectionResource: DataFactoryPrivateEndpointConnection
  PublicNetworkAccess: FactoryPublicNetworkAccess
  PurviewConfiguration: FactoryPurviewConfiguration
  RunFilterParameters: RunFilterContent
  SsisObjectMetadataStatusResponse: SsisObjectMetadataStatusResult
  TriggerResource: DataFactoryTrigger
  Trigger: DataFactoryTriggerProperties
  IntegrationRuntimeStatusResponse: IntegrationRuntimeStatusResult
  # Dataset
  DatasetDataElement.name: ColumnName
  DatasetDataElement.type: columnType
  DatasetSchemaDataElement.name: schemaColumnName
  DatasetSchemaDataElement.type: schemaColumnType
  DatasetCompression.type: datasetCompressionType
  Dataset: FactoryDatasetDefinition
  DatasetResource: DataFactoryDataset
  HttpDataset: HttpFileDataset
  # DataFlow
  DataFlow: FactoryDataFlowDefinition
  DataFlowResource: DataFactoryDataFlow
  Flowlet: FactoryFlowletDefinition
  MappingDataFlow: FactoryMappingDataFlowDefinition
  WranglingDataFlow: FactoryWranglingDataFlowDefinition
  # Debug resource
  AddDataFlowToDebugSessionResponse: FactoryDataFlowDebugSessionStartResult
  CreateDataFlowDebugSessionRequest: FactoryDataFlowDebugSessionContent
  CreateDataFlowDebugSessionResponse: FactoryDataFlowDebugSessionCreateResult
  DataFlowDebugResource: FactoryDataFlowDebugInfo
  DataFlowDebugCommandResponse: FactoryDataFlowDebugCommandResult
  DataFlowDebugPackage: FactoryDataFlowDebugPackageContent
  DatasetDebugResource: FactoryDatasetDebugInfo
  IntegrationRuntimeDebugResource: FactoryIntegrationRuntimeDebugInfo
  LinkedServiceDebugResource: FactoryLinkedServiceDebugInfo
  SubResourceDebugResource: FactoryDebugInfo
  # GlobalParameter
  GlobalParameterResource: DataFactoryGlobalParameter
  GlobalParameterSpecification: FactoryGlobalParameterSpecification
  GlobalParameterType: FactoryGlobalParameterType
  # IntegrationRuntime
  IntegrationRuntime: IntegrationRuntimeDefinition
  
# prepend-rp-prefix:
#  - DataFlowDefinition

override-operation-name:
  ActivityRuns_QueryByPipelineRun: GetActivityRunsByPipelineRun
  PipelineRuns_QueryByFactory: GetPipelineRuns
  TriggerRuns_QueryByFactory: GetTriggerRuns
  DataFlowDebugSession_QueryByFactory: GetDataFlowDebugSessions
  ExposureControl_QueryFeatureValuesByFactory: GetExposureControlFeatureValues
  Triggers_QueryByFactory: GetTriggers
  Factories_ConfigureFactoryRepo: ConfigureFactoryRepo

directive:
  - from: datafactory.json
    where: $.paths
    transform: >
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataFactory/factories/{factoryName}/addDataFlowToDebugSession'].post.parameters[4].name = 'content';
      $['/subscriptions/{subscriptionId}/providers/Microsoft.DataFactory/locations/{locationId}/getFeatureValue'].post.parameters[3].name = 'content';
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataFactory/factories/{factoryName}/getFeatureValue'].post.parameters[4].name = 'content';
#  - from: DataFlow.json
#    where: $.definitions
#    transform: >
#      $.DataFlow['x-ms-client-name'] = 'FactoryDataFlowDefinition';
```
