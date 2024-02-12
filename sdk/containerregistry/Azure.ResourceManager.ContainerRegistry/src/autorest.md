# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: ContainerRegistry
namespace: Azure.ResourceManager.ContainerRegistry
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/8a28143c7271d4496296ed47f70c3cb5a9981e57/specification/containerregistry/resource-manager/readme.md
tag: package-2022-12
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

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  '*ResourceId': 'arm-id'
  'PrincipalId': 'uuid'
  'taskId': 'arm-id'
  'tokenId': 'arm-id'
  'scopeMapId': 'arm-id'

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
  Etag: ETag|etag
  Useragent: UserAgent
  Vaultsecret: VaultSecret
  Pullrequest: PullRequest
  PAT: Pat

keep-plural-enums:
  - ContainerRegistryOS

prepend-rp-prefix:
  - KeyVaultProperties
  - PlatformProperties
  - TaskStepProperties
  - Run
  - RunPatch
  - RunStatus
  - RunType
  - RunListResult
  - Task
  - TaskRun
  - TaskPatch
  - TaskStatus
  - TaskListResult
  - TaskRunListResult
  - ProvisioningState
  - Policies
  - PolicyStatus
  - Replication
  - ReplicationPatch
  - ReplicationListResult
  - Webhook
  - IPRule
  - AgentPool
  - AgentPoolPatch
  - AgentPoolQueueStatus
  - NetworkRuleSet
  - DockerBuildStep
  - TriggerProperties
  - EncryptionStatus
  - ExportPolicy
  - ExportPolicyStatus
  - FileTaskStep
  - ImageDescriptor
  - ImageUpdateTrigger
  - ImportImageParameters
  - ImportMode
  - ImportSource
  - ImportSourceCredentials
  - PublicNetworkAccess
  - RetentionPolicy
  - RunGetLogResult
  - SecretObject
  - SecretObjectType
  - SourceTrigger
  - SourceTriggerDescriptor
  - SourceTriggerEvent
  - TimerTrigger
  - TimerTriggerDescriptor
  - TriggerStatus
  - TrustPolicy
  - TrustPolicyType
  - WebhookAction
  - WebhookPatch
  - WebhookStatus
  - ZoneRedundancy
  - PasswordName
  - AgentPoolListResult
  - AgentProperties
  - EncodedTaskStep
  - OverrideTaskStepProperties
  - QuarantinePolicy
  - UpdateTriggerPayloadType
  - WebhookListResult
  - BaseImageDependency
  - BaseImageDependencyType
  - BaseImageTrigger
  - BaseImageTriggerType
  - Credentials
  - Token
  - TokenCertificate
  - TokenCertificateName
  - TokenListResult
  - TokenPassword
  - TokenPasswordName
  - TokenStatus
  - PipelineRun
  - GenerateCredentialsResult
  - SoftDeletePolicy

rename-mapping:
  OS: ContainerRegistryOS
  KeyVaultProperties.keyRotationEnabled: IsKeyRotationEnabled
  RegistryNameStatus: ContainerRegistryNameAvailableResult
  RegistryNameStatus.nameAvailable: IsNameAvailable
  RegistryUpdateParameters: ContainerRegistryPatch
  RegistryUpdateParameters.properties.anonymousPullEnabled: IsAnonymousPullEnabled
  RegistryUpdateParameters.properties.adminUserEnabled: IsAdminUserEnabled
  Registry.properties.adminUserEnabled: IsAdminUserEnabled
  RegistryUpdateParameters.properties.dataEndpointEnabled: IsDataEndpointEnabled
  Registry.properties.dataEndpointEnabled: IsDataEndpointEnabled
  Registry.properties.anonymousPullEnabled: IsAnonymousPullEnabled
  ReplicationUpdateParameters.properties.regionEndpointEnabled: IsRegionEndpointEnabled
  Replication.properties.regionEndpointEnabled: IsRegionEndpointEnabled
  Registry: ContainerRegistry
  AuthInfo.expiresIn: ExpireInSeconds
  TaskStepUpdateParameters: ContainerRegistryTaskStepUpdateContent
  DockerBuildStepUpdateParameters: ContainerRegistryDockerBuildStepUpdateContent
  EncodedTaskStepUpdateParameters: ContainerRegistryEncodedTaskStepUpdateContent
  FileTaskStepUpdateParameters: ContainerRegistryFileTaskStepUpdateContent
  TaskRunRequest: ContainerRegistryTaskRunContent
  RunRequest: ContainerRegistryRunContent
  DockerBuildRequest: ContainerRegistryDockerBuildContent
  EncodedTaskRunRequest: ContainerRegistryEncodedTaskRunContent
  FileTaskRunRequest: ContainerRegistryFileTaskRunContent
  TriggerUpdateParameters: ContainerRegistryTriggerUpdateContent
  TimerTriggerUpdateParameters: ContainerRegistryTimerTriggerUpdateContent
  SourceTriggerUpdateParameters: ContainerRegistrySourceTriggerUpdateContent
  BaseImageTriggerUpdateParameters: ContainerRegistryBaseImageTriggerUpdateContent
  Run.properties.createTime: CreatedOn
  Action: ContainerRegistryIPRuleAction
  ActionsRequired: ActionsRequiredForPrivateLinkServiceConsumer
  Architecture: ContainerRegistryOSArchitecture
  Argument: ContainerRegistryRunArgument
  SourceProperties: SourceCodeRepoProperties
  AuthInfo: SourceCodeRepoAuthInfo
  AuthInfoUpdateParameters: SourceCodeRepoAuthInfoUpdateContent
  TokenType: SourceCodeRepoAuthTokenType
  CallbackConfig: ContainerRegistryWebhookCallbackConfig
  Event: ContainerRegistryWebhookEvent
  EventInfo: ContainerRegistryWebhookEventInfo
  EventRequestMessage: ContainerRegistryWebhookEventRequestMessage
  EventContent: ContainerRegistryWebhookEventContent
  EventListResult: ContainerRegistryWebhookEventListResult
  EventResponseMessage: ContainerRegistryWebhookEventResponseMessage
  Target: ContainerRegistryWebhookEventTarget
  Source: ContainerRegistryWebhookEventSource
  Request: ContainerRegistryWebhookEventRequestContent
  ConnectionStatus: ContainerRegistryPrivateLinkServiceConnectionStatus
  DefaultAction: ContainerRegistryNetworkRuleDefaultAction
  EncodedTaskRunRequest.timeout: TimeoutInSeconds
  FileTaskRunRequest.timeout: TimeoutInSeconds
  TaskUpdateParameters.properties.timeout: TimeoutInSeconds
  Task.properties.timeout: TimeoutInSeconds
  DockerBuildRequest.timeout: TimeoutInSeconds
  EncryptionProperty: ContainerRegistryEncryption
  RegenerateCredentialParameters: ContainerRegistryCredentialRegenerateContent
  RegistryListCredentialsResult: ContainerRegistryListCredentialsResult
  RegistryNameCheckRequest: ContainerRegistryNameAvailabilityContent
  RegistryPassword: ContainerRegistryPassword
  RegistryUsage: ContainerRegistryUsage
  RegistryUsageUnit: ContainerRegistryUsageUnit
  SetValue: ContainerRegistryTaskOverridableValue
  SourceUpdateParameters: SourceCodeRepoUpdateContent
  Status: ContainerRegistryResourceStatus
  Variant: ContainerRegistryCpuVariant
  Actor: ContainerRegistryWebhookEventActor
  NetworkRuleBypassOptions: ContainerRegistryNetworkRuleBypassOption
  PlatformUpdateParameters: ContainerRegistryPlatformUpdateContent
  RegistryListResult: ContainerRegistryListResult
  RegistryUsageListResult: ContainerRegistryUsageListResult
  StepType: ContainerRegistryTaskStepType
  TaskStepProperties.type: ContainerRegistryTaskStepType
  ImageUpdateTrigger.id: -|uuid
  SourceTriggerDescriptor.id: -|uuid
  EventContent.id: -|uuid
  Event.id: -|uuid
  EventInfo.id: -|uuid
  Request.id: -|uuid
  ActivationProperties: ConnectedRegistryActivation
  ActivationStatus: ConnectedRegistryActivationStatus
  ConnectionState: ConnectedRegistryConnectionState
  ParentProperties: ConnectedRegistryParent
  ParentProperties.id: -|arm-id
  LoginServerProperties: ConnectedRegistryLoginServer
  LoggingProperties: ConnectedRegistryLogging
  StatusDetailProperties: ConnectedRegistryStatusDetail
  StatusDetailProperties.type: StatusDetailType
  AuditLogStatus: ConnectedRegistryAuditLogStatus
  CertificateType: TlsCertificateLocationType
  GenerateCredentialsParameters: ContainerRegistryGenerateCredentialsContent
  LogLevel: ConnectedRegistryLogLevel
  PipelineRunRequest: PipelineRunContent
  PipelineRunResponse: PipelineRunResult
  ProgressProperties: PipelineProgress
  SyncProperties: ConnectedRegistrySyncProperties
  SyncUpdateProperties: ConnectedRegistrySyncUpdateProperties
  TokenUpdateParameters: ContainerRegistryTokenPatch
  ScopeMap.properties.type: ScopeMapType
  ExportPipelineTargetProperties.type: PipelineTargetType
  TlsCertificateProperties.location: CertificateLocation
  TokenCredentialsProperties: ContainerRegistryTokenCredentials
  ImportSource.registryUri: RegistryAddress

override-operation-name:
  Schedules_ScheduleRun: ScheduleRun
  Registries_CheckNameAvailability: CheckContainerRegistryNameAvailability
  Builds_GetBuildSourceUploadUrl: GetBuildSourceUploadUrl

directive:
  - rename-operation:
      from: Registries_GetBuildSourceUploadUrl
      to: Builds_GetBuildSourceUploadUrl
  - rename-operation:
      from: Registries_ScheduleRun
      to: Schedules_ScheduleRun
  - from: swagger-document
    where: $.definitions
    transform: >
      $.IdentityProperties.properties.principalId.readOnly = true;
      $.IdentityProperties.properties.tenantId.readOnly = true;
      $.UserIdentityProperties.properties.principalId.readOnly = true;
      $.UserIdentityProperties.properties.clientId.readOnly = true;
  - from: containerregistry.json
    where: $.definitions
    transform: >
      $.ConnectedRegistryProperties.properties.clientTokenIds.items['x-ms-format'] = 'arm-id';
      $.ConnectedRegistryUpdateProperties.properties.clientTokenIds.items['x-ms-format'] = 'arm-id';
  - from: swagger-document
    where: $.definitions..expiry
    transform: >
      $['x-ms-client-name'] = 'ExpireOn';
  - from: types.json
    where: $.parameters.SubscriptionIdParameter.format
    transform: >
      return undefined;
```
