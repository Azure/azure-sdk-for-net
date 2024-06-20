# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Logic
namespace: Azure.ResourceManager.Logic
require: https://github.com/Azure/azure-rest-api-specs/blob/353d84dac009c19ae776c25eb361f07e85f26c8d/specification/logic/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/runs/{runName}/operations/{operationId}

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/runs/{runName}/operations/{operationId}: LogicWorkflowRunOperation
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/runs/{runName}: LogicWorkflowRun
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/runs/{runName}/actions/{actionName}/repetitions/{repetitionName}: LogicWorkflowRunActionRepetition
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/runs/{runName}/actions/{actionName}/repetitions/{repetitionName}/requestHistories/{requestHistoryName}: LogicWorkflowRunActionRepetitionRequestHistory
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/runs/{runName}/actions/{actionName}/requestHistories/{requestHistoryName}: LogicWorkflowRunActionRequestHistory
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/runs/{runName}/actions/{actionName}/scopeRepetitions/{repetitionName}: LogicWorkflowRunActionScopeRepetition

rename-mapping:
  AS2EnvelopeSettings.autogenerateFileName: AutoGenerateFileName
  SwaggerCustomDynamicTreeParameter.required: IsRequired
  SwaggerXml.attribute: IsAttribute
  SwaggerXml.wrapped: IsWrapped
  AgreementContent: IntegrationAccountAgreementContent
  AssemblyDefinition: IntegrationAccountAssemblyDefinition
  AssemblyProperties: IntegrationAccountAssemblyProperties
  AssemblyCollection: IntegrationAccountAssemblyList
  AgreementType: IntegrationAccountAgreementType
  ApiDeploymentParameterMetadata: LogicApiDeploymentParameterMetadata
  ApiDeploymentParameterMetadataSet: LogicApiDeploymentParameterMetadataSet
  ApiDeploymentParameterVisibility: LogicApiDeploymentParameterVisibility
  ApiOperation: LogicApiOperationInfo
  ApiOperationAnnotation: LogicApiOperationAnnotation
  ApiOperationListResult: LogicApiOperationListResult
  ApiOperationPropertiesDefinition.pageable: IsPageable
  ApiOperationPropertiesDefinition: LogicApiOperationProperties
  ApiReference: LogicApiReference
  ApiResourceBackendService: LogicApiResourceBackendService
  ApiResourceDefinitions: LogicApiResourceDefinitions
  ApiResourceGeneralInformation: LogicApiResourceGeneralInformation
  ApiResourceMetadata: LogicApiResourceMetadata
  ApiResourceGeneralMetadata: LogicApiResourceGeneralMetadata
  ApiResourcePolicies: LogicApiResourcePolicies
  ApiTier: LogicApiTier
  ApiType: LogicApiType
  ArtifactContentPropertiesDefinition: ArtifactContentProperties
  AzureResourceErrorInfo: LogicExpressionErrorInfo
  BatchConfiguration: IntegrationAccountBatchConfiguration
  BatchConfigurationProperties: IntegrationAccountBatchConfigurationProperties
  BatchReleaseCriteria: IntegrationAccountBatchReleaseCriteria
  BusinessIdentity: IntegrationAccountBusinessIdentity
  CallbackUrl: ListOperationCallbackUrl
  ContentLink: LogicContentLink
  ContentHash: LogicContentHash
  DayOfWeek: LogicWorkflowDayOfWeek
  EdifactAcknowledgementSettings.batchFunctionalAcknowledgements: BatchFunctionalAcknowledgement
  EdifactAcknowledgementSettings.batchTechnicalAcknowledgements: BatchTechnicalAcknowledgement
  EncryptionAlgorithm: AS2EncryptionAlgorithm
  ErrorInfo: LogicErrorInfo
  ErrorResponse: LogicErrorResponse
  ErrorResponseCode: IntegrationServiceErrorCode
  EventLevel: IntegrationAccountEventLevel
  ExtendedErrorInfo: IntegrationServiceErrorInfo
  Expression: LogicExpression
  ExpressionRoot: LogicExpressionRoot
  GetCallbackUrlParameters: ListOperationCallbackUrlParameterInfo
  HashingAlgorithm: AS2HashingAlgorithm
  IntegrationServiceEnvironmentManagedApi.properties.runtimeUrls: runtimeUris
  IpAddress: FlowEndpointIPAddress
  IpAddressRange: FlowAccessControlIPAddressRange
  JsonSchema: LogicJsonSchema
  KeyType: LogicKeyType
  KeyVaultReference: IntegrationAccountKeyVaultNameReference
  KeyVaultKeyCollection: IntegrationAccountKeyVaultKeyList
  KeyVaultKey: IntegrationAccountKeyVaultKey
  KeyVaultKey.kid: KeyId|uri
  KeyVaultKey.attributes.enabled: IsEnabled
  KeyVaultKey.attributes.created: CreatedOn
  KeyVaultKey.attributes.updated: UpdatedOn
  KeyVaultKeyReference: IntegrationAccountKeyVaultKeyReference
  KeyVaultKeyReference.keyVault.id: ResourceId
  KeyVaultKeyReference.keyVault.name: ResourceName
  ListKeyVaultKeysDefinition: IntegrationAccountListKeyVaultKeyContent
  MapType: IntegrationAccountMapType
  NetworkConfiguration: IntegrationServiceNetworkConfiguration
  RunActionCorrelation: LogicWorkflowRunActionCorrelation
  RunCorrelation: LogicWorkflowRunCorrelation
  ParameterType: LogicWorkflowParameterType
  PartnerContent: IntegrationAccountPartnerContent
  PartnerType: IntegrationAccountPartnerType
  RecurrenceFrequency: LogicWorkflowRecurrenceFrequency
  RecurrenceSchedule: LogicWorkflowRecurrenceSchedule
  RecurrenceScheduleOccurrence: LogicWorkflowRecurrenceScheduleOccurrence
  RegenerateActionParameter: LogicWorkflowRegenerateActionContent
  RequestHistoryListResult: LogicWorkflowRequestHistoryListResult
  RequestHistory: LogicWorkflowRequestHistory
  RequestHistoryProperties: LogicWorkflowRequestHistoryProperties
  Request: LogicWorkflowRequest
  Response: LogicWorkflowResponse
  RetryHistory: LogicWorkRetryHistory
  ResourceReference: LogicResourceReference
  RepetitionIndex: LogicWorkflowRepetitionIndex
  SchemaType: IntegrationAccountSchemaType
  SetTriggerStateActionDefinition: LogicWorkflowTriggerStateActionContent
  Sku: LogicSku
  SkuName: LogicSkuName
  SigningAlgorithm: AS2SigningAlgorithm
  StatusAnnotation: LogicApiOperationAnnotationStatus
  SwaggerCustomDynamicTreeParameter: SwaggerCustomDynamicTreeParameterInfo
  SwaggerSchema.required: requiredProperties
  SwaggerSchema.ref: Reference
  SwaggerSchema.readOnly: IsReadOnly
  SwaggerSchema.notificationUrlExtension: IsNotificationUrlExtension
  TrackingEventsDefinition: IntegrationAccountTrackingEventsContent
  TrackingEvent: IntegrationAccountTrackingEvent
  TrackingRecordType: IntegrationAccountTrackingRecordType
  TrackEventsOperationOptions: IntegrationAccountTrackEventOperationOption
  TrackingEventErrorInfo: IntegrationAccountTrackingEventErrorInfo
  Workflow: LogicWorkflow
  WorkflowListResult: LogicWorkflowListResult
  WorkflowRunAction: LogicWorkflowRunAction
  WorkflowVersion: LogicWorkflowVersion
  WorkflowState: LogicWorkflowState
  WorkflowStatus: LogicWorkflowStatus
  WorkflowParameter: LogicWorkflowParameterInfo
  WorkflowOutputParameter: LogicWorkflowOutputParameterInfo
  WorkflowRun: LogicWorkflowRun
  WorkflowRunListResult: LogicWorkflowRunListResult
  WorkflowProvisioningState: LogicWorkflowProvisioningState
  WorkflowTriggerProvisioningState: LogicWorkflowTriggerProvisioningState
  WorkflowRunTrigger: LogicWorkflowRunTrigger
  WorkflowVersionListResult: LogicWorkflowVersionListResult
  WorkflowTriggerReference: LogicWorkflowTriggerReference
  WorkflowTriggerRecurrence: LogicWorkflowTriggerRecurrence
  WorkflowTriggerListResult: LogicWorkflowTriggerListResult
  WorkflowTriggerListCallbackUrlQueries: LogicWorkflowTriggerCallbackQueryParameterInfo
  WorkflowRunActionRepetitionDefinition: LogicWorkflowRunActionRepetitionDefinition
  WorkflowRunActionRepetitionDefinitionCollection: LogicWorkflowRunActionRepetitionDefinitionList
  WorkflowTrigger: LogicWorkflowTrigger
  WorkflowTriggerHistory: LogicWorkflowTriggerHistory
  WorkflowTriggerHistory.properties.fired: IsFired
  WorkflowTriggerHistoryListResult: LogicWorkflowTriggerHistoryListResult
  WorkflowTriggerCallbackUrl.method: -|request-method
  WorkflowTriggerCallbackUrl: LogicWorkflowTriggerCallbackUri
  WorkflowReference: LogicWorkflowReference
  WorkflowRunActionListResult: LogicWorkflowRunActionListResult
  WsdlService: LogicWsdlService
  WsdlImportMethod: LogicWsdlImportMethod
  X12AcknowledgementSettings.batchTechnicalAcknowledgements: BatchTechnicalAcknowledgement
  X12AcknowledgementSettings.batchFunctionalAcknowledgements: BatchFunctionalAcknowledgement
  X12AcknowledgementSettings.batchImplementationAcknowledgements: BatchImplementationAcknowledgement

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'trackingId': 'uuid'
  'actionTrackingId': 'uuid'
  'PublicCertificate': 'any'
  'content': 'any'
  'contentType': 'content-type'
  'MessageContentType': 'content-type'
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
  MDN: Mdn
  NRR: Nrr
  EDI: Edi
  XSD: Xsd
  AES128: Aes128
  AES192: Aes192
  AES256: Aes256
  DES3: Des3
  SHA1: Sha1
  SHA2256: Sha2256
  SHA2384: Sha2384
  SHA2512: Sha2512
  SQL: Sql
  SSL: Ssl
  UTF8: Utf8
  B2B: B2B|b2b

directive:
  - remove-operation: Workflows_Update
  - from: logic.json
    where: $.definitions
    transform: >
      $.ErrorResponse.properties.error['x-ms-client-flatten'] = true;
      $.OpenAuthenticationAccessPolicies.properties.policies['x-ms-client-name'] = 'AccessPolicies';
      $.ResourceReference.properties.id['x-ms-format'] = 'arm-id';
      $.ResourceReference.properties.type['x-ms-format'] = 'resource-type';
      $.IpAddress.properties.address['x-ms-client-name'] = 'CidrAddress';
      $.IntegrationServiceEnvironmentSkuDefinition.properties.resourceType['x-ms-format'] = 'resource-type';
      $.KeyVaultKeyReference.properties.keyVault['x-ms-client-flatten'] = true;
      $.KeyVaultKeyReference.properties.keyVault.properties.id['x-ms-format'] = 'arm-id';
      $.KeyVaultKeyReference.properties.keyVault.properties.type['x-ms-format'] = 'resource-type';
      $.WorkflowTriggerRecurrence.properties.startTime['format'] = 'date-time';
      $.WorkflowTriggerRecurrence.properties.endTime['format'] = 'date-time';
      $.RecurrenceSchedule.properties.weekDays.items['x-ms-enum']['name'] = 'DayOfWeek';
      $.CallbackUrl.properties.value['x-ms-client-name'] = 'url';
      $.KeyVaultKey.properties.attributes.properties.created['format'] = 'unixtime';
      $.KeyVaultKey.properties.attributes.properties.updated['format'] = 'unixtime';
      $.KeyVaultKey.properties.attributes['x-ms-client-flatten'] = true;

```
