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
  'runId': 'uuid'
  'activityRunId': 'uuid'
  'pipelineRunId': 'uuid'
  'sessionId': 'uuid'
  'encryptedCredential': 'any'
  'dataFactoryLocation': 'azure-location'

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
  CMK: Cmk
  ASC: Asc
  ETA: Eta
  GET: Get
  PUT: Put

rename-mapping:
  # Property
  ActivityRun.activityRunEnd: EndOn
  CassandraSourceReadConsistencyLevels.ALL: All
  CassandraSourceReadConsistencyLevels.ONE: One
  CassandraSourceReadConsistencyLevels.TWO: Two
  CassandraSourceReadConsistencyLevels.LOCAL_ONE: LocalOne
  CreateDataFlowDebugSessionRequest.timeToLive: TtlInMinutes
  DataFlowDebugSessionInfo.startTime: StartOn
  DataFlowDebugSessionInfo.timeToLiveInMinutes: TtlInMinutes
  DataFlowDebugSessionInfo.lastActivityTime: LastActivityOn
  DatasetDataElement.name: ColumnName
  DatasetDataElement.type: columnType
  DatasetSchemaDataElement.name: schemaColumnName
  DatasetSchemaDataElement.type: schemaColumnType
  DatasetCompression.type: datasetCompressionType
  ExposureControlBatchResponse.exposureControlResponses: ExposureControlResults
  FactoryRepoUpdate.factoryResourceId: -|arm-id
  HDInsightOnDemandLinkedService.typeProperties.timeToLive: TtlExpression
  IntegrationRuntimeCustomerVirtualNetwork.subnetId: SubnetId|arm-id
  IntegrationRuntimeDataFlowProperties.timeToLive: TtlInMinutes
  IntegrationRuntimeNodeIpAddress.ipAddress: IPAddress|ip-address
  IntegrationRuntimeVNetProperties.vNetId: VnetId|uuid
  IntegrationRuntimeVNetProperties.subnetId: SubnetId|arm-id
  Factory.properties.createTime: CreatedOn
  LinkedIntegrationRuntime.createTime: CreatedOn
  ManagedIntegrationRuntimeStatus.typeProperties.createTime: CreatedOn
  ManagedVirtualNetwork.vNetId: VnetId|uuid
  ManagedPrivateEndpoint.privateLinkResourceId: -|arm-id
  Office365Source.endTime: EndOn
  Office365Source.startTime: StartOn
  SelfHostedIntegrationRuntimeStatus.typeProperties.createTime: CreatedOn
  ScriptActivityParameterType.Timespan: TimeSpan
  SelfHostedIntegrationRuntimeNode.expiryTime: ExpireOn
  SelfHostedIntegrationRuntimeStatus.typeProperties.taskQueueId: -|uuid
  SelfHostedIntegrationRuntimeStatus.typeProperties.serviceUrls: serviceUris
  # Factory
  Factory: DataFactory
  FactoryListResponse: FactoryListResult
  # Dataset
  Dataset: FactoryDatasetDefinition
  DatasetResource: FactoryDataset
  HttpDataset: HttpFileDataset
  AvroFormat: DatasetAvroFormat
  JsonFormat: DatasetJsonFormat
  OrcFormat: DatasetOrcFormat
  ParquetFormat: DatasetParquetFormat
  TextFormat: DatasetTextFormat
  # DataFlow
  DataFlow: FactoryDataFlowDefinition
  DataFlowResource: FactoryDataFlow
  Flowlet: FactoryFlowletDefinition
  MappingDataFlow: FactoryMappingDataFlowDefinition
  WranglingDataFlow: FactoryWranglingDataFlowDefinition
  Transformation: DataFlowTransformation
  # Data source
  BlobSink: AzureBlobSink
  BlobSource: AzureBlobSource
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
  GlobalParameterResource: FactoryGlobalParameter
  GlobalParameterSpecification: FactoryGlobalParameterSpecification
  GlobalParameterType: FactoryGlobalParameterType
  ParameterSpecification: EntityParameterSpecification
  ParameterDefinitionSpecification: EntityParameterDefinitionSpecification
  ParameterType: EntityParameterType
  # IntegrationRuntime
  IntegrationRuntime: IntegrationRuntimeDefinition
  IntegrationRuntimeResource: FactoryIntegrationRuntime
  IntegrationRuntimeStatusResponse: IntegrationRuntimeStatusResult
  PackageStore: IntegrationRuntimeSsisPackageStore
  # LinkedService
  LinkedService: FactoryLinkedServiceDefinition
  LinkedServiceReference: FactoryLinkedServiceReference
  LinkedServiceReferenceType: FactoryLinkedServiceReferenceType
  LinkedServiceResource: FactoryLinkedService
  # Network
  ManagedVirtualNetworkResource: FactoryVirtualNetwork
  PublicNetworkAccess: FactoryPublicNetworkAccess
  # Pipeline
  PipelineResource: FactoryPipeline
  PipelineListResponse: FactoryPipelineListResult
  PipelinePolicy: FactoryPipelinePolicy
  PipelineReference: FactoryPipelineReference
  PipelineReferenceType: FactoryPipelineReferenceType
  PipelineRun: FactoryPipelineRunInfo
  PipelineRunInvokedBy: FactoryPipelineRunInvokedByInfo
  PipelineRunsQueryResponse: FactoryPipelineRunsQueryResult
  Activity: PipelineActivity
  ActivityRun: ActivityRunInfo
  ActivityRunsQueryResponse: ActivityRunsResult
  CopySource: CopyActivitySource
  CreateRunResponse: PipelineCreateRunResult
  Expression: FactoryExpressionDefinition
  ExpressionType: FactoryExpressionType
  GetMetadataActivity: GetDatasetMetadataActivity
  SwitchCase: SwitchCaseActivity
  UserProperty: ActivityUserProperty
  VariableSpecification: PipelineVariableSpecification
  VariableType: PipelineVariableType
  # Private link
  ManagedPrivateEndpointResource: FactoryPrivateEndpoint
  RemotePrivateEndpointConnection: FactoryPrivateEndpointProperties
  PrivateEndpointConnectionResource: FactoryPrivateEndpointConnection
  PrivateLinkResource: FactoryPrivateLinkResource
  PrivateLinkResourceProperties: FactoryPrivateLinkResourceProperties
  # Trigger
  BlobEventsTrigger: AzureBlobEventsTrigger
  BlobEventTypes: AzureBlobEventType
  BlobTrigger: AzureBlobTrigger
  TriggerResource: FactoryTrigger
  Trigger: FactoryTriggerDefinition
  TriggerListResponse: FactoryTriggerListResult
  TriggerQueryResponse: FactoryTriggerQueryResult
  TriggerReference: FactoryTriggerReference
  TriggerReferenceType: FactoryTriggerReferenceType
  TriggerRun: FactoryTriggerRun
  TriggerRunsQueryResponse: FactoryTriggerRunsQueryResult
  TriggerRunStatus: FactoryTriggerRunStatus
  TriggerRuntimeState: FactoryTriggerRuntimeState
  TriggerSubscriptionOperationStatus: FactoryTriggerSubscriptionOperationResult
  # Others
  UserAccessPolicy: FactoryDataPlaneUserAccessPolicy
  AccessPolicyResponse: FactoryDataPlaneAccessPolicyResult
  CredentialReference: FactoryCredentialReference
  CredentialReferenceType: FactoryCredentialReferenceType
  EncryptionConfiguration: FactoryEncryptionConfiguration
  ExposureControlBatchResponse: ExposureControlBatchResult
  ExposureControlResponse: ExposureControlResult
  ExposureControlRequest: ExposureControlContent
  HDInsightActivityDebugInfoOption: HDInsightActivityDebugInfoOptionSetting
  GitHubAccessTokenResponse: GitHubAccessTokenResult
  HttpSource: HttpFileSource
  MetadataItem: FactoryMetadataItemInfo
  PurviewConfiguration: FactoryPurviewConfiguration
  RunFilterParameters: RunFilterContent
  SecretBase: FactorySecretBaseDefinition
  SecureString: FactorySecretString
  SsisObjectMetadataStatusResponse: SsisObjectMetadataStatusResult
  SsisParameter: SsisParameterInfo
  
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
    where: $.parameters
    transform: >
      $.locationId['x-ms-format'] = 'arm-id';
  - from: datafactory.json
    where: $.definitions
    transform: >
      $.DataFlowDebugSessionInfo.properties.lastActivityTime['format'] = 'date-time';
      $.UpdateIntegrationRuntimeRequest.properties.updateDelayOffset['format'] = 'duration';
  - from: Pipeline.json
    where: $.definitions
    transform: >
      $.PipelineElapsedTimeMetricPolicy.properties.duration['type'] = 'string';
      $.PipelineElapsedTimeMetricPolicy.properties.duration['format'] = 'duration';
  - from: IntegrationRuntime.json
    where: $.definitions
    transform: >
      $.SelfHostedIntegrationRuntimeStatusTypeProperties.properties.updateDelayOffset['format'] = 'duration';
      $.SelfHostedIntegrationRuntimeStatusTypeProperties.properties.localTimeZoneOffset['format'] = 'duration';
```
