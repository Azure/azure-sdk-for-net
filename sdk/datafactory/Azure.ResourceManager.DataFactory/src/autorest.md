# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DataFactory
namespace: Azure.ResourceManager.DataFactory
require: https://github.com/Azure/azure-rest-api-specs/blob/de400f7204d30d25543ac967636180728d52a88f/specification/datafactory/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

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
  AddDataFlowToDebugSessionResponse: FactoryDataFlowStartDebugSessionResult
  CreateDataFlowDebugSessionRequest: FactoryDataFlowDebugSessionContent
  CreateDataFlowDebugSessionResponse: FactoryDataFlowCreateDebugSessionResult
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
  DaysOfWeek: FactoryDayOfWeek
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
  IntegrationRuntimeOutboundNetworkDependenciesEndpointsResponse: IntegrationRuntimeOutboundNetworkDependenciesResult

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
  - from: Pipeline.json
    where: $.definitions
    transform: >
      $.PipelineElapsedTimeMetricPolicy.properties.duration['type'] = 'string';
      $.PipelineElapsedTimeMetricPolicy.properties.duration['format'] = 'duration';
      $.Pipeline.properties.runDimensions['x-ms-format'] = 'dfe-string';
      $.UserProperty.properties.value['x-ms-format'] = 'dfe-string';
      $.ActivityPolicy.properties.timeout['x-ms-format'] = 'dfe-duration';
      $.ActivityPolicy.properties.retry['x-ms-format'] = 'dfe-int';
      $.AzureBlobStorageReadSettings.properties.recursive['x-ms-format'] = 'dfe-bool';
      $.AzureBlobStorageReadSettings.properties.wildcardFolderPath['x-ms-format'] = 'dfe-string';
      $.AzureBlobStorageReadSettings.properties.wildcardFileName['x-ms-format'] = 'dfe-string';
      $.AzureBlobStorageReadSettings.properties.prefix['x-ms-format'] = 'dfe-string';
      $.AzureBlobStorageReadSettings.properties.partitionRootPath['x-ms-format'] = 'dfe-string';
      $.AzureBlobStorageReadSettings.properties.modifiedDatetimeStart['x-ms-format'] = 'dfe-date-time-rfc1123';
      $.AzureBlobStorageReadSettings.properties.modifiedDatetimeEnd['x-ms-format'] = 'dfe-date-time-rfc1123';
      $.AmazonS3ReadSettings.properties.recursive['x-ms-format'] = 'dfe-bool';
      $.AmazonS3ReadSettings.properties.wildcardFolderPath['x-ms-format'] = 'dfe-string';
      $.AmazonS3ReadSettings.properties.wildcardFileName['x-ms-format'] = 'dfe-string';
      $.AmazonS3ReadSettings.properties.prefix['x-ms-format'] = 'dfe-string';
      $.AmazonS3ReadSettings.properties.fileListPath['x-ms-format'] = 'dfe-string';
      $.AmazonS3ReadSettings.properties.partitionRootPath['x-ms-format'] = 'dfe-string';
      $.AmazonS3ReadSettings.properties.deleteFilesAfterCompletion['x-ms-format'] = 'dfe-bool';
      $.AmazonS3ReadSettings.properties.modifiedDatetimeStart['x-ms-format'] = 'dfe-date-time-rfc1123';
      $.AmazonS3ReadSettings.properties.modifiedDatetimeEnd['x-ms-format'] = 'dfe-date-time-rfc1123';
      $.AzureBlobFSReadSettings.properties.recursive['x-ms-format'] = 'dfe-bool';
      $.AzureBlobFSReadSettings.properties.wildcardFolderPath['x-ms-format'] = 'dfe-string';
      $.AzureBlobFSReadSettings.properties.wildcardFileName['x-ms-format'] = 'dfe-string';
      $.AzureBlobFSReadSettings.properties.fileListPath['x-ms-format'] = 'dfe-string';
      $.AzureBlobFSReadSettings.properties.partitionRootPath['x-ms-format'] = 'dfe-string';
      $.AzureBlobFSReadSettings.properties.deleteFilesAfterCompletion['x-ms-format'] = 'dfe-bool';
      $.AzureBlobFSReadSettings.properties.modifiedDatetimeStart['x-ms-format'] = 'dfe-date-time-rfc1123';
      $.AzureBlobFSReadSettings.properties.modifiedDatetimeEnd['x-ms-format'] = 'dfe-date-time-rfc1123';
      $.AzureDataLakeStoreReadSettings.properties.recursive['x-ms-format'] = 'dfe-bool';
      $.AzureDataLakeStoreReadSettings.properties.wildcardFolderPath['x-ms-format'] = 'dfe-string';
      $.AzureDataLakeStoreReadSettings.properties.wildcardFileName['x-ms-format'] = 'dfe-string';
      $.AzureDataLakeStoreReadSettings.properties.fileListPath['x-ms-format'] = 'dfe-string';
      $.AzureDataLakeStoreReadSettings.properties.listAfter['x-ms-format'] = 'dfe-string';
      $.AzureDataLakeStoreReadSettings.properties.listBefore['x-ms-format'] = 'dfe-string';
      $.AzureDataLakeStoreReadSettings.properties.partitionRootPath['x-ms-format'] = 'dfe-string';
      $.AzureDataLakeStoreReadSettings.properties.deleteFilesAfterCompletion['x-ms-format'] = 'dfe-bool';
      $.AzureDataLakeStoreReadSettings.properties.modifiedDatetimeStart['x-ms-format'] = 'dfe-date-time-rfc1123';
      $.AzureDataLakeStoreReadSettings.properties.modifiedDatetimeEnd['x-ms-format'] = 'dfe-date-time-rfc1123';
      $.AzureDataLakeStoreReadSettings.properties.recursive['x-ms-format'] = 'dfe-bool';
      $.AzureDataLakeStoreReadSettings.properties.wildcardFolderPath['x-ms-format'] = 'dfe-string';
      $.AzureDataLakeStoreReadSettings.properties.wildcardFileName['x-ms-format'] = 'dfe-string';
      $.AzureDataLakeStoreReadSettings.properties.partitionRootPath['x-ms-format'] = 'dfe-string';
      $.AzureDataLakeStoreReadSettings.properties.modifiedDatetimeStart['x-ms-format'] = 'dfe-date-time-rfc1123';
      $.AzureDataLakeStoreReadSettings.properties.modifiedDatetimeEnd['x-ms-format'] = 'dfe-date-time-rfc1123';
      $.StoreReadSettings.properties.maxConcurrentConnections['x-ms-format'] = 'dfe-int';
      $.StoreReadSettings.properties.disableMetricsCollection['x-ms-format'] = 'dfe-bool';
      $.MicrosoftAccessSource.properties.query['x-ms-format'] = 'dfe-string';
      $.MicrosoftAccessSource.properties.additionalColumns['x-ms-format'] = 'dfe-listOfT';
      $.MicrosoftAccessSource.properties.additionalColumns['x-ms-format-element-definition'] = 'AdditionalColumns';
      $.XmlReadSettings.properties.namespacePrefixes['x-ms-format'] = 'dfe-keyValuePair';
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
