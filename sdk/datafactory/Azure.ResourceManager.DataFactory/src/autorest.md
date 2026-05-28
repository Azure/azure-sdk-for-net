# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DataFactory
namespace: Azure.ResourceManager.DataFactory
require: https://github.com/Azure/azure-rest-api-specs/blob/222af3670e36c5083cb0dc8a9c2677a8f77f8958/specification/datafactory/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
  - ChangeDataCapture_CreateOrUpdate  # Missing required property
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

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
  'dataFactoryLocation': 'azure-location'

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
  ETag: ETag|eTag
  Db: DB|db
  CMK: Cmk
  ASC: Asc
  ETA: Eta
  GET: Get
  PUT: Put
  GZip: Gzip
  Pwd: Password
  Ml: ML
  VNet: Vnet
  Bw: BW
  SQL: Sql

keep-plural-enums:
  - ActivityOnInactiveMarkAs

rename-mapping:
  AccessPolicyResponse: DataFactoryDataPlaneAccessPolicyResult
  Activity: PipelineActivity
  ActivityDependency: PipelineActivityDependency
  ActivityPolicy: PipelineActivityPolicy
  ActivityPolicy.secureInput: IsSecureInputEnabled
  ActivityPolicy.secureOutput: IsSecureOutputEnabled
  ActivityRun: PipelineActivityRunInformation
  ActivityRun.activityRunStart: StartOn
  ActivityRun.activityRunEnd: EndOn
  ActivityRunsQueryResponse: PipelineActivityRunsResult
  ActivityState: PipelineActivityState
  AddDataFlowToDebugSessionResponse: DataFactoryDataFlowStartDebugSessionResult
  AvroDataset.typeProperties.location: DataLocation
  AvroFormat: DatasetAvroFormat
  BinaryDataset.typeProperties.location: DataLocation
  CassandraSourceReadConsistencyLevels.ALL: All
  CassandraSourceReadConsistencyLevels.ONE: One
  CassandraSourceReadConsistencyLevels.TWO: Two
  CassandraSourceReadConsistencyLevels.LOCAL_ONE: LocalOne
  ChangeDataCaptureResource: DataFactoryChangeDataCapture
  ChangeDataCaptureListResponse: ChangeDataCaptureListResult
  CMKIdentityDefinition: DataFactoryCmkIdentity
  ConfigurationType: DataFactorySparkConfigurationType
  ConnectionType: MapperConnectionType
  CopySource: CopyActivitySource
  CreateDataFlowDebugSessionRequest: DataFactoryDataFlowDebugSessionContent
  CreateDataFlowDebugSessionRequest.timeToLive: TimeToLiveInMinutes
  CreateDataFlowDebugSessionResponse: DataFactoryDataFlowCreateDebugSessionResult
  CreateRunResponse: PipelineCreateRunResult
  CredentialListResponse: DataFactoryCredentialListResult
  DataFlow: DataFactoryDataFlowProperties
  DataFlowListResponse: DataFactoryDataFlowListResult
  DataFlowDebugCommandResponse: DataFactoryDataFlowDebugCommandResult
  DataFlowDebugPackage: DataFactoryDataFlowDebugPackageContent
  DataFlowDebugResource: DataFactoryDataFlowDebugInfo
  DataFlowDebugSessionInfo.startTime: StartOn|date-time
  DataFlowDebugSessionInfo.timeToLiveInMinutes: TimeToLiveInMinutes
  DataFlowDebugSessionInfo.lastActivityTime: LastActivityOn|date-time
  DataFlowResource: DataFactoryDataFlow
  Dataset: DataFactoryDatasetProperties
  DatasetListResponse: DataFactoryDatasetListResult
  DatasetDataElement.name: ColumnName
  DatasetDataElement.type: ColumnType
  DatasetDebugResource: DataFactoryDatasetDebugInfo
  DatasetResource: DataFactoryDataset
  DatasetSchemaDataElement.name: SchemaColumnName
  DatasetSchemaDataElement.type: SchemaColumnType
  DatasetCompression.type: DatasetCompressionType
  ValueType: DatasetSourceValueType
  DayOfWeek: DataFactoryDayOfWeek
  DaysOfWeek: DataFactoryDayOfWeek
  DelimitedTextDataset.typeProperties.location: DataLocation
  ExcelDataset.typeProperties.location: DataLocation
  ExecuteDataFlowActivityTypePropertiesCompute: ExecuteDataFlowActivityComputeType
  ExecutePipelineActivityPolicy.secureInput: IsSecureInputEnabled
  ExposureControlBatchResponse: ExposureControlBatchResult
  ExposureControlBatchResponse.exposureControlResponses: ExposureControlResults
  ExposureControlRequest: ExposureControlContent
  ExposureControlResponse: ExposureControlResult
  ExpressionV2.value: V2Value;
  Factory: DataFactory
  FactoryListResponse: DataFactoryListResult
  FactoryRepoUpdate: FactoryRepoContent
  FactoryRepoUpdate.factoryResourceId: -|arm-id
  FrequencyType: MapperPolicyRecurrenceFrequencyType
  GetMetadataActivity: GetDatasetMetadataActivity
  GitHubClientSecret: FactoryGitHubClientSecret
  GitHubAccessTokenResponse: GitHubAccessTokenResult
  GlobalParameterListResponse: DataFactoryGlobalParameterListResult
  GlobalParameterResource: DataFactoryGlobalParameter
  GlobalParameterSpecification: DataFactoryGlobalParameterProperties
  GlobalParameterSpecification.type: GlobalParameterType
  HDInsightActivityDebugInfoOption: HDInsightActivityDebugInfoOptionSetting
  HDInsightOnDemandLinkedService.typeProperties.timeToLive: TimeToLiveExpression
  HDInsightOnDemandLinkedService.typeProperties.version: Version
  HttpSource: DataFactoryHttpFileSource
  IntegrationRuntime: DataFactoryIntegrationRuntimeProperties
  IntegrationRuntimeAutoUpdate: IntegrationRuntimeAutoUpdateState
  IntegrationRuntimeCustomerVirtualNetwork.subnetId: SubnetId|arm-id
  IntegrationRuntimeDataFlowProperties.cleanup: ShouldCleanupAfterTtl
  IntegrationRuntimeDataFlowProperties.timeToLive: TimeToLiveInMinutes
  IntegrationRuntimeDataFlowPropertiesCustomPropertiesItem: IntegrationRuntimeDataFlowCustomItem
  IntegrationRuntimeDebugResource: DataFactoryIntegrationRuntimeDebugInfo
  IntegrationRuntimeListResponse: DataFactoryIntegrationRuntimeListResult
  IntegrationRuntimeNodeIpAddress.ipAddress: IPAddress|ip-address
  IntegrationRuntimeOutboundNetworkDependenciesEndpointsResponse: IntegrationRuntimeOutboundNetworkDependenciesResult
  IntegrationRuntimeResource: DataFactoryIntegrationRuntime
  IntegrationRuntimeStatusResponse: DataFactoryIntegrationRuntimeStatusResult
  IntegrationRuntimeVNetProperties.vNetId: VnetId|uuid
  IntegrationRuntimeVNetProperties.subnetId: SubnetId|arm-id
  Factory.properties.createTime: CreatedOn
  Flowlet: DataFactoryFlowletProperties
  JsonDataset.typeProperties.location: DataLocation
  JsonFormat: DatasetJsonFormat
  LinkedIntegrationRuntime.createTime: CreatedOn
  LinkedIntegrationRuntimeRbacAuthorization.resourceId: -|arm-id
  LinkedService: DataFactoryLinkedServiceProperties
  LinkedServiceDebugResource: DataFactoryLinkedServiceDebugInfo
  LinkedServiceListResponse: DataFactoryLinkedServiceListResult
  LinkedServiceResource: DataFactoryLinkedService
  ManagedIdentityCredential: DataFactoryManagedIdentityCredentialProperties
  ManagedIdentityCredential.typeProperties.resourceId: -|arm-id
  ManagedIntegrationRuntimeStatus.typeProperties.createTime: CreatedOn
  ManagedPrivateEndpoint: DataFactoryPrivateEndpointProperties
  ManagedPrivateEndpoint.privateLinkResourceId: -|arm-id
  ManagedPrivateEndpointListResponse: DataFactoryPrivateEndpointListResult
  ManagedVirtualNetworkListResponse: DataFactoryManagedVirtualNetworkListResult
  ManagedPrivateEndpointResource: DataFactoryPrivateEndpoint
  ManagedVirtualNetwork: DataFactoryManagedVirtualNetworkProperties
  ManagedVirtualNetwork.vNetId: VnetId|uuid
  ManagedVirtualNetworkResource: DataFactoryManagedVirtualNetwork
  MappingDataFlow: DataFactoryMappingDataFlowProperties
  MetadataItem: DataFactoryMetadataItemInfo
  Office365Source.endTime: EndOn
  Office365Source.startTime: StartOn
  OrcDataset.typeProperties.location: DataLocation
  OrcFormat: DatasetOrcFormat
  OutputColumn: Office365TableOutputColumn
  ParameterSpecification: EntityParameterSpecification
  ParameterType: EntityParameterType
  ParquetDataset.typeProperties.location: DataLocation
  ParquetFormat: DatasetParquetFormat
  PipelineListResponse: DataFactoryPipelineListResult
  PipelineResource: DataFactoryPipeline
  PipelineRun: DataFactoryPipelineRunInfo
  PipelineRun.lastUpdated: LastUpdatedOn
  PipelineRun.runStart: RunStartOn
  PipelineRun.runEnd: RunEndOn
  PipelineRunInvokedBy: DataFactoryPipelineRunEntityInfo
  PipelineRunsQueryResponse: DataFactoryPipelineRunsQueryResult
  PrivateEndpointConnectionListResponse: DataFactoryPrivateEndpointConnectionListResult
  RemotePrivateEndpointConnection: DataFactoryPrivateEndpointConnectionProperties
  RunFilterParameters: RunFilterContent
  PrivateEndpointConnectionResource: DataFactoryPrivateEndpointConnection
  QueryDataFlowDebugSessionsResponse: DataFlowDebugSessionInfoListResult
  ScriptActivityParameterType.Timespan: TimeSpan
  ScriptActivityTypePropertiesLogSettings: ScriptActivityTypeLogSettings
  ScriptActivityScriptBlock.type: QueryType
  SecretBase: DataFactorySecret
  SecureInputOutputPolicy.secureInput: IsSecureInputEnabled
  SecureInputOutputPolicy.secureOutput: IsSecureOutputEnabled
  SelfHostedIntegrationRuntime.typeProperties.selfContainedInteractiveAuthoringEnabled: IsSelfContainedInteractiveAuthoringEnabled
  SelfHostedIntegrationRuntimeNode.expiryTime: ExpireOn
  SelfHostedIntegrationRuntimeStatus.typeProperties.createTime: CreatedOn
  SelfHostedIntegrationRuntimeStatus.typeProperties.selfContainedInteractiveAuthoringEnabled: IsSelfContainedInteractiveAuthoringEnabled
  SelfHostedIntegrationRuntimeStatus.typeProperties.taskQueueId: -|uuid
  SelfHostedIntegrationRuntimeStatus.typeProperties.serviceUrls: ServiceUriStringList
  SubResourceDebugResource: DataFactoryDebugInfo
  SsisObjectMetadataListResponse: SsisObjectMetadataListResult
  SsisObjectMetadataStatusResponse: SsisObjectMetadataStatusResult
  SsisPackageLocationType.SSISDB: SsisDB
  SsisParameter: SsisParameterInfo
  SsisParameter.required: IsRequired
  SsisParameter.sensitive: IsSensitive
  SsisParameter.valueSet: HasValueSet
  SsisVariable.sensitive: IsSensitive
  SwitchCase: SwitchCaseActivity
  TextFormat: DatasetTextFormat
  Transformation: DataFlowTransformation
  Trigger: DataFactoryTriggerProperties
  TriggerListResponse: DataFactoryTriggerListResult
  TriggerQueryResponse: DataFactoryTriggerQueryResult
  TriggerResource: DataFactoryTrigger
  TriggerRunsQueryResponse: DataFactoryTriggerRunsQueryResult
  TriggerSubscriptionOperationStatus: DataFactoryTriggerSubscriptionOperationResult
  UserAccessPolicy: DataFactoryDataPlaneUserAccessPolicy
  UserAccessPolicy.startTime: StartOn|date-time
  UserAccessPolicy.expireTime: ExpireOn|date-time
  UserProperty: PipelineActivityUserProperty
  VariableSpecification: PipelineVariableSpecification
  VariableType: PipelineVariableType
  WranglingDataFlow: DataFactoryWranglingDataFlowProperties
  XmlDataset.typeProperties.location: DataLocation
  CredentialResource: DataFactoryServiceCredential
  AzureFunctionActivity.typeProperties.headers: RequestHeaders
  WebActivity.typeProperties.headers: RequestHeaders
  WebHookActivity.typeProperties.headers: RequestHeaders
  LinkedService.version: LinkedServiceVersion
  SapOdpLinkedService.typeProperties.sncMode: SncFlag
  SapTableLinkedService.typeProperties.sncMode: SncFlag

prepend-rp-prefix:
  - BlobEventsTrigger
  - BlobEventTypes
  - BlobSink
  - BlobSource
  - BlobTrigger
  - Credential
  - CredentialReference
  - CredentialReferenceType
  - EncryptionConfiguration
  - Expression
  - ExpressionType
  - GlobalParameterType
  - HttpDataset
  - LinkedServiceReference
  - LinkedServiceReferenceType
  - PackageStore
  - PipelinePolicy
  - PipelineReference
  - PipelineReferenceType
  - PublicNetworkAccess
  - PurviewConfiguration
  - PrivateLinkResource
  - PrivateLinkResourceProperties
  - SecureString
  - TriggerReference
  - TriggerReferenceType
  - TriggerRun
  - TriggerRunStatus
  - TriggerRuntimeState
  - LogSettings
  - RecurrenceFrequency
  - RecurrenceSchedule
  - RecurrenceScheduleOccurrence
  - ScheduleTrigger
  - ScriptAction
  - ScriptActivity
  - ScriptType
  - ExpressionV2
  - ExpressionV2Type

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
