# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: ContainerRegistry
namespace: Azure.ResourceManager.ContainerRegistry
require: /mnt/vss/_work/1/s/azure-rest-api-specs/specification/containerregistry/resource-manager/readme.md
tag: package-2021-09
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
  '*ResourceId': 'arm-id'
  'PrincipalId': 'uuid'

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

rename-mapping:
  OS: ContainerRegistryOS
  KeyVaultProperties.keyRotationEnabled: IsKeyRotationEnabled
  RegistryNameStatus: ContainerRegistryNameAvailableResult
  RegistryNameStatus.nameAvailable: IsNameAvailable
  RegistryPatch: ContainerRegistryPatch
  RegistryUpdateParameters.properties.adminUserEnabled: IsAdminUserEnabled
  Registry.properties.adminUserEnabled: IsAdminUserEnabled
  RegistryUpdateParameters.properties.dataEndpointEnabled: IsDataEndpointEnabled
  Registry.properties.dataEndpointEnabled: IsDataEndpointEnabled
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
  EncodedTaskRunRequest: ContainerRegistryEncodedTaskRunRequest
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
  Credentials: ContainerRegistryRunCredentials
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
  ImageUpdateTrigger.id: -|uuid
  SourceTriggerDescriptor.id: -|uuid
  EventContent.id: -|uuid
  Event.id: -|uuid
  EventInfo.id: -|uuid
  Request.id: -|uuid

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
```
