# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Automation
namespace: Azure.ResourceManager.Automation
tag: package-all
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true
use-model-reader-writer: true
# mgmt-debug:
#   show-serialized-names: true
```

### Tag: package-all

These settings apply only when `--tag=package-all` is specified on the command line.

```yaml $(tag) == 'package-all'
title: AutomationClient
description: Automation Client
openapi-type: arm

input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/e191949499d1d3b60a1b2a979d9e35f122a94978/specification/automation/resource-manager/Microsoft.Automation/stable/2024-10-23/openapi.json
  - https://github.com/Azure/azure-rest-api-specs/blob/e191949499d1d3b60a1b2a979d9e35f122a94978/specification/automation/resource-manager/Microsoft.Automation/preview/2020-01-13-preview/dscCompilationJob.json

rename-mapping:
  HybridRunbookWorkerCreateParameters: HybridRunbookWorkerCreateOrUpdateContent
  AutomationAccount.properties.publicNetworkAccess: IsPublicNetworkAccessAllowed
  AutomationAccount.properties.disableLocalAuth: IsLocalAuthDisabled
  DscConfiguration.properties.logVerbose: IsLogVerboseEnabled
  DscNodeConfiguration.properties.incrementNodeConfigurationBuild: IsIncrementNodeConfigurationBuildRequired
  Runbook.properties.logVerbose: IsLogVerboseEnabled
  Runbook.properties.logProgress: IsLogProgressEnabled
  SourceControl.properties.autoSync: IsAutoSyncEnabled
  SourceControl.properties.publishRunbook: IsAutoPublishRunbookEnabled
  ActivityParameter.valueFromPipeline: CanTakeValueFromPipeline
  ActivityParameter.valueFromPipelineByPropertyName: CanTakeValueFromPipelineByPropertyName
  ActivityParameter.valueFromRemainingArguments: CanTakeValueValueFromRemainingArguments
  AutomationAccountCreateOrUpdateParameters.properties.publicNetworkAccess: IsPublicNetworkAccessAllowed
  AutomationAccountCreateOrUpdateParameters.properties.disableLocalAuth: IsLocalAuthDisabled
  AutomationAccountUpdateParameters.properties.publicNetworkAccess: IsPublicNetworkAccessAllowed
  AutomationAccountUpdateParameters.properties.disableLocalAuth: IsLocalAuthDisabled
  DscCompilationJobCreateParameters.properties.incrementNodeConfigurationBuild: IsIncrementNodeConfigurationBuildRequired
  DscConfigurationCreateOrUpdateParameters.properties.logVerbose: IsLogVerboseEnabled
  DscConfigurationCreateOrUpdateParameters.properties.logProgress: IsLogProgressEnabled
  DscConfigurationUpdateParameters.properties.logVerbose: IsLogVerboseEnabled
  DscConfigurationUpdateParameters.properties.logProgress: IsLogProgressEnabled
  DscNodeConfigurationCreateOrUpdateParameters.properties.incrementNodeConfigurationBuild: IsIncrementNodeConfigurationBuildRequired
  RunbookCreateOrUpdateParameters.properties.logVerbose: IsLogVerboseEnabled
  RunbookCreateOrUpdateParameters.properties.logProgress: IsLogProgressEnabled
  RunbookDraft.inEdit: IsInEditMode
  RunbookUpdateParameters.properties.logVerbose: IsLogVerboseEnabled
  RunbookUpdateParameters.properties.logProgress: IsLogProgressEnabled
  SourceControlCreateOrUpdateParameters.properties.autoSync: IsAutoSyncEnabled
  SourceControlCreateOrUpdateParameters.properties.publishRunbook: IsAutoPublishRunbookEnabled
  SourceControlUpdateParameters.properties.autoSync: IsAutoSyncEnabled
  SourceControlUpdateParameters.properties.publishRunbook: IsAutoPublishRunbookEnabled
  DscConfigurationAssociationProperty.name: ConfigurationName
  NodeCountProperties.count: NameCount
  ScheduleDay: AutomationDayOfWeek
  FieldDefinition: AutomationConnectionFieldDefinition
  GroupTypeEnum: HybridWorkerGroup
  JobCollectionItem: AutomationJobCollectionItemData
  LinuxProperties: LinuxUpdateConfigurationProperties
  NodeCount: DscNodeCount
  NodeCountProperties: DscNodeCountProperties
  NodeCounts: DscNodeCountListResult
  OperatingSystemType: SoftwareUpdateConfigurationOperatingSystemType
  ProvisioningState: SourceControlProvisioningState
  SourceType: SourceControlSourceType
  SkuNameEnum: AutomationSkuName
  Statistics: AutomationAccountStatistics
  StatisticsListResult: AutomationAccountStatisticsListResult
  StreamType: SourceControlStreamType
  SUCScheduleProperties: SoftwareUpdateConfigurationScheduleProperties
  SyncType: SourceControlSyncType
  TagSettingsProperties: QueryTagSettingsProperties
  TagOperators: QueryTagOperator
  TargetProperties: SoftwareUpdateConfigurationTargetProperties
  TaskProperties: SoftwareUpdateConfigurationTaskProperties
  TestJob: RunbookTestJob
  TestJobCreateParameters: RunbookTestJobCreateContent
  TokenType: SourceControlTokenType
  TypeField: AutomationModuleField
  TypeFieldListResult: AutomationModuleFieldListResult
  UpdateConfiguration: SoftwareUpdateConfigurationSpecificProperties
  UpdateConfigurationNavigation: SoftwareUpdateConfigurationNavigation
  WindowsProperties: WindowsUpdateConfigurationProperties
  WorkerType: HybridWorkerType
  SourceControlSyncJobById: SourceControlSyncJobResult
  SourceControlSyncJobStreamById: SourceControlSyncJobStreamResult
  SourceControlSyncJobStreamsListBySyncJob: SourceControlSyncJobStreamListResult
  DscNode.properties.lastSeen: LastSeenOn
  HybridRunbookWorker.properties.vmResourceId: -|arm-id
  HybridRunbookWorkerCreateParameters.properties.vmResourceId: -|arm-id
  Certificate.properties.expiryTime: ExpireOn
  Schedule.properties.startTimeOffsetMinutes: StartInMinutes
  Schedule.properties.expiryTime: ExpireOn
  Schedule.properties.expiryTimeOffsetMinutes: ExpireInMinutes
  Schedule.properties.nextRun: NextRunOn
  Schedule.properties.nextRunOffsetMinutes: NextRunInMinutes
  SoftwareUpdateConfigurationCollectionItem.properties.nextRun: NextRunOn
  SUCScheduleProperties.startTimeOffsetMinutes: StartInMinutes
  SUCScheduleProperties.expiryTime: ExpireOn
  SUCScheduleProperties.expiryTimeOffsetMinutes: ExpireInMinutes
  SUCScheduleProperties.nextRun: NextRunOn
  SUCScheduleProperties.nextRunOffsetMinutes: NextRunInMinutes
  Webhook.properties.expiryTime: ExpireOn
  WebhookCreateOrUpdateParameters.properties.expiryTime: ExpireOn
  ScheduleCreateOrUpdateParameters.properties.expiryTime: ExpireOn
  Activity.id: -|arm-id
  AgentRegistration.id: -|arm-id
  AgentRegistration.endpoint: -|uri
  AzureQueryProperties.locations: -|azure-location
  DeletedAutomationAccount.properties.automationAccountResourceId: -|arm-id
  JobStream.id: -|arm-id
  SoftwareUpdateConfigurationCollectionItem.id: -|arm-id
  SoftwareUpdateConfigurationMachineRun.id: -|arm-id
  SoftwareUpdateConfigurationMachineRun.properties.targetComputer: TargetComputerId|arm-id
  SoftwareUpdateConfigurationRun.id: -|arm-id
  SoftwareUpdateConfigurationRunTaskProperties.jobId: -|uuid
  SourceControlSyncJobById.id: -|arm-id
  SourceControlSyncJobStream.id: -|arm-id
  SourceControlSyncJobStreamById.id: -|arm-id
  JobNavigation.id: -|uuid
  TokenType.Oauth: OAuth
  JobSchedule.properties.jobScheduleId: -|uuid
  RunbookTypeEnum: AutomationRunbookType
  AgentRegistrationRegenerateKeyParameter: AgentRegistrationRegenerateKeyContent
  HybridRunbookWorkerGroupCreateOrUpdateParameters: HybridRunbookWorkerGroupCreateOrUpdateContent
  RunbookParameter: RunbookParameterDefinition
  DscConfigurationParameter: DscConfigurationParameterDefinition
  ActivityParameter: AutomationActivityParameterDefinition
  CountType.nodeconfiguration: NodeConfiguration
  AutomationErrorResponse: AutomationResponseError
  TypeField.type: FieldType
  LinuxUpdateClasses: LinuxUpdateClassification
  WindowsUpdateClasses: WindowsUpdateClassification
  WindowsProperties.excludedKbNumbers: ExcludedKBNumbers
  WindowsProperties.includedKbNumbers: IncludedKBNumbers
  Certificate.properties.thumbprint: ThumbprintString
  CertificateCreateOrUpdateParameters.properties.thumbprint: ThumbprintString
  ModuleProvisioningState.Canceled: Cancelled

prepend-rp-prefix:
  - Certificate
  - Connection
  - ConnectionType
  - Credential
  - Job
  - JobSchedule
  - Module
  - Runbook
  - RunbookDraft
  - RunbookListResult
  - Schedule
  - ScheduleListResult
  - SourceControl
  - SourceControlListResult
  - Variable
  - VariableListResult
  - Watcher
  - WatcherListResult
  - Webhook
  - WebhookListResult
  - Activity
  - ActivityListResult
  - ActivityOutputType
  - ActivityParameterSet
  - ActivityParameterValidationSet
  - AdvancedSchedule
  - AdvancedScheduleMonthlyOccurrence
  - CertificateListResult
  - ConnectionListResult
  - ConnectionTypeListResult
  - ContentHash
  - ContentLink
  - ContentSource
  - ContentSourceType
  - CountType
  - CredentialListResult
  - EncryptionProperties
  - HttpStatusCode
  - JobListResultV2
  - JobScheduleListResult
  - JobStatus
  - JobStream
  - JobStreamListResult
  - JobStreamType
  - Key
  - KeyListResult
  - KeyVaultProperties
  - LinkedWorkspace
  - ModuleErrorInfo
  - ModuleListResult
  - ScheduleFrequency
  - UsageListResult
  - UsageCounterName

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

no-property-type-replacement:
  - JobNavigation

models-to-treat-empty-string-as-null:
  - AutomationWebhookData

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/objectDataTypes/{typeName}/fields: AutomationAccountResource
request-path-to-parent:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/jobs: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/jobs/{jobName}
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/softwareUpdateConfigurations:  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/softwareUpdateConfigurations/{softwareUpdateConfigurationName}
override-operation-name:
  Job_ListByAutomationAccount: GetAll
  ObjectDataTypes_ListFieldsByModuleAndType: GetFieldsByModuleAndType
  Keys_ListByAutomationAccount: GetAutomationAccountKeys
  SoftwareUpdateConfigurationMachineRuns_GetById: GetSoftwareUpdateConfigurationMachineRun
  SoftwareUpdateConfigurationRuns_GetById: GetSoftwareUpdateConfigurationRun
  DscCompilationJobStream_ListByJob: GetDscCompilationJobStreams
  ObjectDataTypes_ListFieldsByType: GetFieldsByType
  TestJobStreams_ListByTestJob: GetTestJobStreams
  SourceControlSyncJob_ListByAutomationAccount: GetSourceControlSyncJobs
  SourceControlSyncJobStreams_ListBySyncJob: GetSourceControlSyncJobStreams
operation-positions:
  Job_ListByAutomationAccount: collection
  SoftwareUpdateConfigurations_List: collection

directive:
  # Align dscCompilationJob.json definitions with openapi.json to eliminate duplicate schemas
  - from: dscCompilationJob.json
    where: $.definitions.JobStream
    transform: >
      $['type'] = 'object';
  - from: dscCompilationJob.json
    where: $.definitions.JobStreamListResult
    transform: >
      $['type'] = 'object';
      $['required'] = ['value'];
      $.properties.value.description = 'The JobStream items on this page';
      $.properties.nextLink.description = 'The link to the next page of items';
      $.properties.nextLink['format'] = 'uri';
  - from: dscCompilationJob.json
    where: $.definitions.JobStreamProperties
    transform: >
      $['type'] = 'object';
      delete $['x-ms-client-flatten'];
      $.properties.summary['x-nullable'] = true;
      delete $.properties.time['x-nullable'];
      $.properties.value.additionalProperties = {};
      $.properties.streamType = {
        '$ref': '#/definitions/JobStreamType',
        'description': 'Gets or sets the stream type.'
      };
  - from: dscCompilationJob.json
    where: $.definitions
    transform: >
      $['JobStreamType'] = {
        'type': 'string',
        'description': 'Gets or sets the stream type.',
        'enum': ['Progress', 'Output', 'Warning', 'Error', 'Debug', 'Verbose', 'Any'],
        'x-ms-enum': {
          'name': 'JobStreamType',
          'modelAsString': true
        }
      };
  # New swagger shares PythonPackageCreateParameters between Python2 and Python3.
  # Clone a dedicated definition for Python2 to preserve backward-compatible type name.
  - from: openapi.json
    where: $.definitions
    transform: >
      if (!$['Python2PackageCreateParameters']) {
        $['Python2PackageCreateParameters'] = JSON.parse(JSON.stringify($['PythonPackageCreateParameters']));
      }
  - from: openapi.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/python2Packages/{packageName}'].put.parameters[?(@.name=='parameters')]
    transform: >
      $.schema = { '$ref': '#/definitions/Python2PackageCreateParameters' };
  # New swagger shares PythonPackageUpdateParameters between Python2 and Python3.
  # Clone a dedicated definition for Python2 to preserve backward-compatible type name.
  - from: openapi.json
    where: $.definitions
    transform: >
      if (!$['Python2PackageUpdateParameters']) {
        $['Python2PackageUpdateParameters'] = JSON.parse(JSON.stringify($['PythonPackageUpdateParameters']));
      }
  - from: openapi.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/python2Packages/{packageName}'].patch.parameters[?(@.name=='parameters')]
    transform: >
      $.schema = { '$ref': '#/definitions/Python2PackageUpdateParameters' };
  - from: openapi.json
    where: $.definitions
    transform: >
        $.updateConfigurationMachineRunProperties.properties.configuredDuration['format'] = 'duration';
  - from: openapi.json
    where: $.definitions
    transform: >
        $.softwareUpdateConfigurationRunProperties.properties.configuredDuration['format'] = 'duration';
  - from: openapi.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/softwareUpdateConfigurations'].get
    transform: >
      $['x-ms-pageable'] = {
        'nextLinkName': null
      };
  - from: openapi.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/listKeys'].post
    transform: >
      $['x-ms-pageable'] = {
            'nextLinkName': null,
            'itemName': 'keys'
          }
  - from: openapi.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/webhooks/generateUri'].post
    transform: >
      $.produces = ["application/json"]
  - from: openapi.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/runbooks/{runbookName}/draft/content'].get
    transform: >
      $.produces = ["text/powershell"]
  - from: openapi.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/runbooks/{runbookName}/content'].get
    transform: >
      $.produces = ["text/powershell"]
  - from: openapi.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/jobs/{jobName}/output'].get
    transform: >
      $.produces = ["text/plain"]
  - from: openapi.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/jobs/{jobName}/runbookContent'].get
    transform: >
      $.produces = ["text/powershell"]
  - from: openapi.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/configurations/{configurationName}/content'].get
    transform: >
      $.produces = ["text/powershell"]
  - from: openapi.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}/reports/{reportId}/content'].get
    transform: >
      $.produces = ["application/json"];
      $.responses['200'].schema['type'] = 'object';
  - from: openapi.json
    where: $.definitions.JobProperties.properties.provisioningState
    transform: >
      delete $['readOnly'];
  - from: openapi.json
    where: $.definitions.HybridRunbookWorkerCreateParameters.properties.name
    transform: >
      delete $['readOnly'];
  - from: openapi.json
    where: $.definitions.ModuleUpdateParameters.properties.location
    transform: >
      delete $['readOnly'];
  - from: openapi.json
    where: $.definitions.ModuleUpdateParameters.properties.name
    transform: >
      delete $['readOnly'];
  - from: openapi.json
    where: $.definitions.JobScheduleProperties.properties.parameters
    transform: >
      $['readOnly'] = true;
  - from: openapi.json
    where: $.definitions.RunbookProperties.properties.provisioningState
    transform: >
      $['x-ms-enum']['name'] = 'RunbookProvisioningState';
  - from: openapi.json
    where: $.definitions.DscConfigurationProperties.properties.provisioningState
    transform: >
      $['x-ms-enum']['name'] = 'DscConfigurationProvisioningState';
  - from: openapi.json
    where: $.definitions.ModuleProvisioningState
    transform: >
      $['x-ms-enum']['modelAsString'] = false;
  # DscCompilationJob only appears in responses, so the generator classifies it as output-only.
  # Marking it as input+output restores the public constructor and property setters lost in v1.1.1 → v1.2.0.
  - from: dscCompilationJob.json
    where: $.definitions.DscCompilationJob
    transform: >
      $['x-csharp-usage'] = 'model,input,output';
```
