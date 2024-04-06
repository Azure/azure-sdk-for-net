# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Automation
namespace: Azure.ResourceManager.Automation
require: https://github.com/Azure/azure-rest-api-specs/blob/d1b0569d8adbd342a1111d6a69764d099f5f717c/specification/automation/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
# mgmt-debug:
#   show-serialized-names: true

rename-mapping:
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
  ErrorResponse: AutomationResponseError
  TypeField.type: FieldType
  LinuxUpdateClasses: LinuxUpdateClassification
  WindowsUpdateClasses: WindowsUpdateClassification
  WindowsProperties.excludedKbNumbers: ExcludedKBNumbers
  WindowsProperties.includedKbNumbers: IncludedKBNumbers
  Certificate.properties.thumbprint: ThumbprintString
  CertificateCreateOrUpdateParameters.properties.thumbprint: ThumbprintString

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
  - from: softwareUpdateConfigurationMachineRun.json
    where: $.definitions
    transform: >
        $.updateConfigurationMachineRunProperties.properties.configuredDuration['format'] = 'duration';
  - from: softwareUpdateConfigurationRun.json
    where: $.definitions
    transform: >
        $.softwareUpdateConfigurationRunProperties.properties.configuredDuration['format'] = 'duration';
  - from: dscConfiguration.json
    where: $
    transform: >
        $.consumes =  [ "application/json" ];
        $.produces =  [ "application/json" ];
  - from: softwareUpdateConfiguration.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/softwareUpdateConfigurations'].get
    transform: >
      $['x-ms-pageable'] = {
        'nextLinkName': null
      };
  - from: account.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/listKeys'].post
    transform: >
      $['x-ms-pageable'] = {
            'nextLinkName': null,
            'itemName': 'keys'
          }

```
