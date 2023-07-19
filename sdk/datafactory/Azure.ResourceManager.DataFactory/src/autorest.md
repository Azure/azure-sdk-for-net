# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
generate-model-factory: false
csharp: true
library-name: DataFactory
namespace: Azure.ResourceManager.DataFactory
require: https://github.com/Azure/azure-rest-api-specs/blob/cd06d327e115cdb55f8e7c9fd1b23fa551b5b750/specification/datafactory/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

#mgmt-debug: 
#  show-serialized-names: true

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
  GZip: Gzip
  Pwd: Password

rename-mapping:
  # Property
  ActivityRun.activityRunEnd: EndOn
  CassandraSourceReadConsistencyLevels.ALL: All
  CassandraSourceReadConsistencyLevels.ONE: One
  CassandraSourceReadConsistencyLevels.TWO: Two
  CassandraSourceReadConsistencyLevels.LOCAL_ONE: LocalOne
  CreateDataFlowDebugSessionRequest.timeToLive: TimeToLiveInMinutes
  DataFlowDebugSessionInfo.startTime: StartOn
  DataFlowDebugSessionInfo.timeToLiveInMinutes: TimeToLiveInMinutes
  DataFlowDebugSessionInfo.lastActivityTime: LastActivityOn
  DatasetDataElement.name: ColumnName
  DatasetDataElement.type: columnType
  DatasetSchemaDataElement.name: schemaColumnName
  DatasetSchemaDataElement.type: schemaColumnType
  DatasetCompression.type: datasetCompressionType
  ExposureControlBatchResponse.exposureControlResponses: ExposureControlResults
  FactoryRepoUpdate.factoryResourceId: -|arm-id
  HDInsightOnDemandLinkedService.typeProperties.timeToLive: TimeToLiveExpression
  IntegrationRuntimeCustomerVirtualNetwork.subnetId: SubnetId|arm-id
  IntegrationRuntimeDataFlowProperties.timeToLive: TimeToLiveInMinutes
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
  ActivityPolicy.secureInput: EnableSecureInput
  ActivityPolicy.secureOutput: EnableSecureOutput
  ExecutePipelineActivityPolicy.secureInput: EnableSecureInput
  SsisParameter.required: IsRequired
  SsisParameter.sensitive: IsSensitive
  SsisParameter.valueSet: HasValueSet
  SsisVariable.sensitive: IsSensitive
  AvroDataset.typeProperties.location: DataLocation
  BinaryDataset.typeProperties.location: DataLocation
  DelimitedTextDataset.typeProperties.location: DataLocation
  ExcelDataset.typeProperties.location: DataLocation
  JsonDataset.typeProperties.location: DataLocation
  OrcDataset.typeProperties.location: DataLocation
  ParquetDataset.typeProperties.location: DataLocation
  XmlDataset.typeProperties.location: DataLocation
  IntegrationRuntimeDataFlowProperties.cleanup: ShouldCleanupAfterTtl
  SsisPackageLocationType.SSISDB: SsisDB
  # Factory
  Factory: DataFactory
  FactoryListResponse: DataFactoryListResult
  # Dataset
  Dataset: DataFactoryDatasetDefinition
  DatasetResource: DataFactoryDataset
  HttpDataset: DataFactoryHttpDataset
  AvroFormat: DatasetAvroFormat
  JsonFormat: DatasetJsonFormat
  OrcFormat: DatasetOrcFormat
  ParquetFormat: DatasetParquetFormat
  TextFormat: DatasetTextFormat
  # DataFlow
  DataFlow: DataFactoryDataFlowDefinition
  DataFlowResource: DataFactoryDataFlow
  Flowlet: DataFactoryFlowletDefinition
  MappingDataFlow: DataFactoryMappingDataFlowDefinition
  WranglingDataFlow: DataFactoryWranglingDataFlowDefinition
  Transformation: DataFlowTransformation
  # Data source
  BlobSink: DataFactoryBlobSink
  BlobSource: DataFactoryBlobSource
  # Debug resource
  AddDataFlowToDebugSessionResponse: DataFactoryDataFlowStartDebugSessionResult
  CreateDataFlowDebugSessionRequest: DataFactoryDataFlowDebugSessionContent
  CreateDataFlowDebugSessionResponse: DataFactoryDataFlowCreateDebugSessionResult
  DataFlowDebugResource: DataFactoryDataFlowDebugInfo
  DataFlowDebugCommandResponse: DataFactoryDataFlowDebugCommandResult
  DataFlowDebugPackage: DataFactoryDataFlowDebugPackageContent
  DatasetDebugResource: DataFactoryDatasetDebugInfo
  IntegrationRuntimeDebugResource: DataFactoryIntegrationRuntimeDebugInfo
  LinkedServiceDebugResource: DataFactoryLinkedServiceDebugInfo
  SubResourceDebugResource: DataFactoryDebugInfo
  # GlobalParameter
  GlobalParameterResource: DataFactoryGlobalParameter
  GlobalParameterSpecification: DataFactoryGlobalParameterSpecification
  GlobalParameterType: DataFactoryGlobalParameterType
  ParameterSpecification: EntityParameterSpecification
  ParameterDefinitionSpecification: EntityParameterDefinitionSpecification
  ParameterType: EntityParameterType
  # IntegrationRuntime
  IntegrationRuntime: DataFactoryIntegrationRuntimeDefinition
  IntegrationRuntimeResource: DataFactoryIntegrationRuntime
  IntegrationRuntimeStatusResponse: DataFactoryIntegrationRuntimeStatusResult
  PackageStore: DataFactoryPackageStore
  # LinkedService
  LinkedService: DataFactoryLinkedServiceDefinition
  LinkedServiceResource: DataFactoryLinkedService
  LinkedServiceReference: DataFactoryLinkedServiceReference
  LinkedServiceReferenceType: DataFactoryLinkedServiceReferenceType
  # Network
  ManagedVirtualNetworkResource: DataFactoryManagedVirtualNetwork
  PublicNetworkAccess: DataFactoryPublicNetworkAccess
  # Pipeline
  PipelineResource: DataFactoryPipeline
  PipelineListResponse: DataFactoryPipelineListResult
  PipelinePolicy: DataFactoryPipelinePolicy
  PipelineReference: DataFactoryPipelineReference
  PipelineReferenceType: DataFactoryPipelineReferenceType
  PipelineRun: DataFactoryPipelineRunInfo
  PipelineRunInvokedBy: DataFactoryPipelineRunEntityInfo
  PipelineRunsQueryResponse: DataFactoryPipelineRunsQueryResult
  Activity: DataFactoryActivity
  ActivityRun: DataFactoryActivityRunInfo
  ActivityRunsQueryResponse: DataFactoryActivityRunsResult
  CopySource: CopyActivitySource
  CreateRunResponse: PipelineCreateRunResult
  Expression: DataFactoryExpressionDefinition
  ExpressionType: DataFactoryExpressionType
  GetMetadataActivity: GetDatasetMetadataActivity
  SwitchCase: SwitchCaseActivity
  UserProperty: ActivityUserProperty
  VariableSpecification: PipelineVariableSpecification
  VariableType: PipelineVariableType
  # Private link
  ManagedPrivateEndpointResource: DataFactoryPrivateEndpoint
  RemotePrivateEndpointConnection: DataFactoryPrivateEndpointProperties
  PrivateEndpointConnectionResource: DataFactoryPrivateEndpointConnection
  PrivateLinkResource: DataFactoryPrivateLinkResource
  PrivateLinkResourceProperties: DataFactoryPrivateLinkResourceProperties
  # Trigger
  BlobEventsTrigger: DataFactoryBlobEventsTrigger
  BlobEventTypes: DataFactoryBlobEventType
  BlobTrigger: DataFactoryBlobTrigger
  TriggerResource: DataFactoryTrigger
  Trigger: DataFactoryTriggerDefinition
  TriggerListResponse: DataFactoryTriggerListResult
  TriggerQueryResponse: DataFactoryTriggerQueryResult
  TriggerReference: DataFactoryTriggerReference
  TriggerReferenceType: DataFactoryTriggerReferenceType
  TriggerRun: DataFactoryTriggerRun
  TriggerRunsQueryResponse: DataFactoryTriggerRunsQueryResult
  TriggerRunStatus: DataFactoryTriggerRunStatus
  TriggerRuntimeState: DataFactoryTriggerRuntimeState
  TriggerSubscriptionOperationStatus: DataFactoryTriggerSubscriptionOperationResult
  # Others
  UserAccessPolicy: DataFactoryDataPlaneUserAccessPolicy
  AccessPolicyResponse: DataFactoryDataPlaneAccessPolicyResult
  CredentialReference: DataFactoryCredentialReference
  CredentialReferenceType: DataFactoryCredentialReferenceType
  DaysOfWeek: DataFactoryDayOfWeek
  EncryptionConfiguration: DataFactoryEncryptionConfiguration
  ExposureControlBatchResponse: ExposureControlBatchResult
  ExposureControlResponse: ExposureControlResult
  ExposureControlRequest: ExposureControlContent
  HDInsightActivityDebugInfoOption: HDInsightActivityDebugInfoOptionSetting
  GitHubAccessTokenResponse: GitHubAccessTokenResult
  HttpSource: DataFactoryHttpFileSource
  MetadataItem: DataFactoryMetadataItemInfo
  PurviewConfiguration: DataFactoryPurviewConfiguration
  RunFilterParameters: RunFilterContent
  SecretBase: DataFactorySecretBaseDefinition
  SecureString: DataFactorySecretString
  SsisObjectMetadataStatusResponse: SsisObjectMetadataStatusResult
  SsisParameter: SsisParameterInfo
  IntegrationRuntimeOutboundNetworkDependenciesEndpointsResponse: IntegrationRuntimeOutboundNetworkDependenciesResult
  ManagedIdentityCredential: DataFactoryManagedIdentityCredentialDefinition
  ManagedIdentityCredentialResource: DataFactoryManagedIdentityCredential

override-operation-name:
  ActivityRuns_QueryByPipelineRun: GetActivityRun
  PipelineRuns_QueryByFactory: GetPipelineRuns
  TriggerRuns_QueryByFactory: GetTriggerRuns
  DataFlowDebugSession_QueryByFactory: GetDataFlowDebugSessions
  Triggers_QueryByFactory: GetTriggers
  Factories_ConfigureFactoryRepo: ConfigureFactoryRepoInformation
  DataFlowDebugSession_AddDataFlow: AddDataFlowToDebugSession
  DataFlowDebugSession_ExecuteCommand: ExecuteDataFlowDebugSessionCommand
  ExposureControl_GetFeatureValueByFactory: GetExposureControlFeature
  ExposureControl_QueryFeatureValuesByFactory: GetExposureControlFeatures
  IntegrationRuntimes_ListOutboundNetworkDependenciesEndpoints: GetOutboundNetworkDependencies

directive:
  - from: datafactory.json
    where: $.parameters
    transform: >
      $.locationId['x-ms-format'] = 'azure-location';
  - from: datafactory.json
    where: $.definitions
    transform: >
      $.DataFlowDebugSessionInfo.properties.lastActivityTime['format'] = 'date-time';
      $.UpdateIntegrationRuntimeRequest.properties.updateDelayOffset['format'] = 'duration';
      $.LinkedServiceReference.properties.type['x-ms-enum']['name'] = 'LinkedServiceReferenceType';
#  - from: Pipeline.json
#    where: $.definitions
#    transform: >
#      $.PipelineElapsedTimeMetricPolicy.properties.duration['type'] = 'string';
#      $.PipelineElapsedTimeMetricPolicy.properties.duration['format'] = 'duration';
  - from: IntegrationRuntime.json
    where: $.definitions
    transform: >
      $.SelfHostedIntegrationRuntimeStatusTypeProperties.properties.updateDelayOffset['format'] = 'duration';
      $.SelfHostedIntegrationRuntimeStatusTypeProperties.properties.localTimeZoneOffset['format'] = 'duration';
  # The definition of userAssignedIdentities is not same as the ManagedServiceIdentity, but the actual json text is same, so remove this property here to normalize with shared ManagedServiceIdentity.
  - from: datafactory.json
    where: $.definitions
    transform: >
      delete $.FactoryIdentity.properties.userAssignedIdentities;
```
