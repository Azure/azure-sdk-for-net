# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: StreamAnalytics
namespace: Azure.ResourceManager.StreamAnalytics
require: https://github.com/Azure/azure-rest-api-specs/blob/692cb8b5eb71505afa267cfbbee322d520eb15ff/specification/streamanalytics/resource-manager/readme.md
tag: package-2021-10-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

list-exception:
- /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.StreamAnalytics/streamingjobs/{jobName}/transformations/{transformationName}

# add this configuration to avoid the type of cluster is changed to writeablesubresource from ClusterInfo automatically,The writeablesubresource type cannot fail to have the nullable attribute. In tests, the return value of the cluster is null.
no-property-type-replacement:
- ClusterInfo
rename-mapping:
  SampleInput.dataLocale: dataLocalion|azure-location
  StreamingJob.properties.dataLocale: dataLocalion|azure-location
  StreamingJob.properties.jobId: -|uuid
  ClusterJob.id: -|arm-id
  ClusterInfo.id: -|arm-id
  ClusterProperties.clusterId: -|uuid
  LastOutputEventTimestamp.lastOutputEventTime: lastOutputEventOn|date-time
  LastOutputEventTimestamp.lastUpdateTime: lastUpdatedOn|date-time
  PowerBIOutputDataSource.properties.groupId: -|uuid
  PrivateEndpointProperties.createdDate: createdOn|date-time
  PrivateLinkServiceConnection.properties.privateLinkServiceId: -|arm-id
  SampleInputResult.lastArrivalTime: lastArrivedOn|date-time
  SubResource.id: -|arm-id
  SubResource.type: -|resource-type
  DiagnosticCondition.since: -|date-time
  RawReferenceInputDataSource.properties.payload: -|any
  RawStreamInputDataSource.properties.payload: -|any
  AvroSerialization: AvroFormatSerialization
  AzureDataLakeStoreOutputDataSource: DataLakeStoreOutputDataSource
  AzureFunctionOutputDataSource: FunctionOutputDataSource
  AzureMachineLearningServiceFunctionRetrieveDefaultDefinitionParameters: MachineLearningServiceFunctionRetrieveDefaultDefinitionContent
  AzureMachineLearningServiceInputColumn: MachineLearningServiceInputColumn
  AzureMachineLearningServiceOutputColumn: MachineLearningServiceOutputColumn
  AzureMachineLearningServiceFunctionBinding: MachineLearningServiceFunctionBinding
  AzureMachineLearningStudioFunctionBinding: eMachineLearningStudioFunctionBinding
  AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters: MachineLearningStudioFunctionRetrieveDefaultDefinitionContent
  AzureMachineLearningStudioInputColumn: MachineLearningStudioInputColumn
  AzureMachineLearningStudioInputs: MachineLearningStudioInputs
  AzureMachineLearningStudioOutputColumn: MachineLearningStudioOutputColumn
  AzureSqlDatabaseOutputDataSource: SqlDatabaseOutputDataSource
  AzureSqlReferenceInputDataSource: SqlReferenceInputDataSource
  AzureSynapseOutputDataSource: SynapseOutputDataSource
  AzureTableOutputDataSource: TableOutputDataSource
  BlobWriteMode: BlobOutputWriteMode
  CompatibilityLevel: StreamingJobCompatibilityLevel
  Compression: StreamingCompression
  CompressionType: StreamingCompressionType
  ContentStoragePolicy: StreamingJobContentStoragePolicy
  CustomClrSerialization: CustomClrFormatSerialization
  CsvSerialization: CsvFormatSerialization
  DiagnosticCondition: StreamingJobDiagnosticCondition
  Diagnostics: StreamingJobDiagnostics
  Encoding: StreamAnalyticsDataSerializationEncoding
  External: StreamingJobExternal
  Function: StreamingJobFunction
  FunctionBinding: StreamingJobFunctionBinding
  FunctionInput: StreamingJobFunctionInput
  FunctionListResult: StreamingJobFunctionListResult
  FunctionOutput: StreamingJobFunctionOutput
  FunctionProperties: StreamingJobFunctionProperties
  FunctionRetrieveDefaultDefinitionParameters: FunctionRetrieveDefaultDefinitionContent
  Input: StreamingJobInput
  InputListResult: StreamingJobInputListResult
  InputProperties: StreamingJobInputProperties
  InputWatermarkMode: StreamingJobInputWatermarkMode
  InputWatermarkProperties: StreamingJobInputWatermarkProperties
  JavaScriptFunctionRetrieveDefaultDefinitionParameters: JavaScriptFunctionRetrieveDefaultDefinitionContent
  JobState: StreamingJobState
  JobStorageAccount: StreamingJobStorageAccount
  JobType: StreamingJobType
  JsonSerialization: JsonFormatSerialization
  CSharpFunctionRetrieveDefaultDefinitionParameters: CSharpFunctionRetrieveDefaultDefinitionContent
  Output: StreamingJobOutput
  OutputDataSource: StreamingJobOutputDataSource
  OutputErrorPolicy: StreamingJobOutputErrorPolicy
  OutputListResult: StreamingJobOutputListResult
  OutputStartMode: StreamingJobOutputStartMode
  OutputWatermarkMode: StreamingJobOutputWatermarkMode
  OutputWatermarkProperties: StreamingJobOutputWatermarkProperties
  ParquetSerialization: ParquetFormatSerialization
  RefreshConfiguration: StreamingJobRefreshConfiguration
  RefreshType: DataRefreshType
  SampleInput: StreamAnalyticsSampleInputContent
  Serialization: StreamAnalyticsDataSerialization
  Transformation: StreamingJobTransformation
  UpdateMode: StreamingJobFunctionUpdateMode
  UdfType: StreamingJobFunctionUdfType

prepend-rp-prefix:
  - AuthenticationMode
  - Cluster
  - ClusterJob
  - ClusterJobListResult
  - ClusterListResult
  - ClusterProperties
  - ClusterProvisioningState
  - ClusterSku
  - ClusterSkuName
  - CompileQuery
  - PrivateEndpoint
  - PrivateEndpointListResult
  - PrivateEndpointProperties
  - PrivateLinkConnectionState
  - PrivateLinkServiceConnection
  - QueryCompilationError
  - QueryCompilationResult
  - QueryFunction
  - QueryInput
  - QueryTestingResult
  - QueryTestingResultStatus
  - ResourceTestStatus
  - SampleInputResult
  - SampleInputResultStatus
  - SubResource
  - StorageAccount
  - SubscriptionQuota
  - SubscriptionQuotasListResult
  - TestInput
  - TestOutput
  - TestQuery
  - TestDatasourceResult
  - TestDatasourceResultStatus

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
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
  GZip: Gzip
  UTF8: Utf8

directive:
- from: definitions.json
  where: $.definitions
  transform: >
    $.Error.properties.error['x-ms-client-flatten'] = true;
    $.Error['x-ms-client-name'] = 'StreamAnalyticsError';
    $.ErrorDetails['x-ms-client-name'] = 'StreamAnalyticsErrorDetails';
- from: inputs.json
  where: $.definitions
  transform: >
    $.ResourceTestStatus.properties.error['x-ms-client-flatten'] = true;
- from: outputs.json
  where: $.definitions
  transform: >
    $.PostgreSQLDataSourceProperties.properties.maxWriterCount['type'] = 'integer';
    $.AzureSqlDatabaseDataSourceProperties.properties.maxWriterCount['type'] = 'integer';
    $.AzureFunctionOutputDataSourceProperties.properties.maxBatchSize['type'] = 'integer';
    $.AzureFunctionOutputDataSourceProperties.properties.maxBatchCount['type'] = 'integer';
    $.AzureSqlDatabaseDataSourceProperties.properties.maxBatchCount['type'] = 'integer';
    $.ServiceBusQueueOutputDataSourceProperties.properties.systemPropertyColumns['additionalProperties'] = { 'type': 'string' };
- from: subscriptions.json
  where: $.definitions
  transform: >
    $.TestQuery.properties.diagnostics['x-ms-client-flatten'] = true;
# Manual fix the Identity model to match the common ManagedServiceIdentity
- from: streamingjobs.json
  where: $.definitions.Identity
  transform: >
    $.properties.principalId['readOnly'] = true;
    $.properties.tenantId['readOnly'] = true;
    delete $.properties.userAssignedIdentities;
    $.properties.type = {
          'type': 'string',
          'description': 'The identity type.',
          'enum': [
            'SystemAssigned',
            'UserAssigned',
            'SystemAssigned,UserAssigned'
          ],
          'x-ms-enum': {
            'name': 'IdentityType',
            'modelAsString': true
          }
        };
- from: swagger-document
  where: $.definitions.StreamingJobProperties.properties.jobStorageAccount
  transform: >
        $["x-nullable"] = true;
- from: swagger-document
  where: $.definitions.PrivateEndpoint.properties.etag
  transform: >
        $["x-nullable"] = true;
- from: swagger-document
  where: $.definitions.StreamingJobProperties.properties.cluster
  transform: >
        $["x-nullable"] = true;
- from: swagger-document
  where: $.definitions.FunctionInput.properties.isConfigurationParameter
  transform: >
        $["x-nullable"] = true;
# Fix format for RefreshRate
- from: swagger-document
  where: $.definitions.AzureSqlReferenceInputDataSourceProperties
  transform: >
    $.properties.refreshRate['format'] = 'time';
    $.properties.refreshRate['x-ms-client-name'] = 'refreshInterval';
- from: swagger-document
  where: $.definitions.BlobReferenceInputDataSourceProperties
  transform: >
    $.properties.fullSnapshotRefreshRate['format'] = 'time';
    $.properties.fullSnapshotRefreshRate['x-ms-client-name'] = 'fullSnapshotRefreshInterval';
- from: swagger-document
  where: $.definitions.BlobReferenceInputDataSourceProperties
  transform: >
    $.properties.deltaSnapshotRefreshRate['format'] = 'time';
    $.properties.deltaSnapshotRefreshRate['x-ms-client-name'] = 'deltaSnapshotRefreshInterval';
# Fix format for timeWindow
- from: swagger-document
  where: $.definitions.OutputProperties
  transform: >
    $.properties.timeWindow['format'] = 'time';
    $.properties.timeWindow['x-ms-client-name'] = 'timeFrame';
```
