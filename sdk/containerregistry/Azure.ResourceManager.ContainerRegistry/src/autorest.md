# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: ContainerRegistry
namespace: Azure.ResourceManager.ContainerRegistry
require: https://github.com/Azure/azure-rest-api-specs/blob/46f0876572153f2d941e862613abb95953f71d34/specification/containerregistry/resource-manager/Microsoft.ContainerRegistry/Registry/readme.md
tag: package-2025-11-dotnetmix
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
enable-bicep-serialization: true

# mgmt-debug:
#  show-serialized-names: true

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
  - AgentPool
  - AgentPoolListResult
  - AgentPoolQueueStatus
  - AgentProperties
  - Archive
  - ArchiveVersion
  - AuthCredential
  - BaseImageDependency
  - BaseImageDependencyType
  - BaseImageTrigger
  - BaseImageTriggerType
  - CacheRule
  - CertificateType
  - CredentialName
  - CredentialHealth
  - CredentialHealthStatus
  - Credentials
  - CredentialSet
  - DockerBuildStep
  - EncodedTaskStep
  - EncryptionStatus
  - ExportPipeline
  - ExportPolicy
  - ExportPolicyStatus
  - FileTaskStep
  - GenerateCredentialsResult
  - ImageDescriptor
  - ImageUpdateTrigger
  - ImportImageParameters
  - ImportMode
  - ImportPipeline
  - ImportSource
  - ImportSourceCredentials
  - IPRule
  - KeyVaultProperties
  - MetadataSearch
  - NetworkRuleSet
  - OverrideTaskStepProperties
  - PasswordName
  - PipelineOptions
  - PipelineRun
  - PipelineRunSourceProperties
  - PipelineRunSourceType
  - PipelineRunTargetProperties
  - PipelineRunTargetType
  - PipelineSourceType
  - PlatformProperties
  - Policies
  - PolicyStatus
  - ProvisioningState
  - PublicNetworkAccess
  - QuarantinePolicy
  - Replication
  - ReplicationListResult
  - RetentionPolicy
  - Run
  - RunGetLogResult
  - RunListResult
  - RunStatus
  - RunType
  - SecretObject
  - SecretObjectType
  - SoftDeletePolicy
  - SourceTrigger
  - SourceTriggerDescriptor
  - SourceTriggerEvent
  - Task
  - TaskListResult
  - TaskRun
  - TaskRunListResult
  - TaskStatus
  - TaskStepProperties
  - TimerTrigger
  - TimerTriggerDescriptor
  - TlsCertificateProperties
  - TlsProperties
  - TlsStatus
  - Token
  - TokenCertificate
  - TokenCertificateName
  - TokenListResult
  - TokenPassword
  - TokenPasswordName
  - TokenStatus
  - TriggerProperties
  - TriggerStatus
  - TrustPolicy
  - TrustPolicyType
  - UpdateTriggerPayloadType
  - Webhook
  - WebhookAction
  - WebhookListResult
  - WebhookStatus
  - ZoneRedundancy

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
  StatusDetailProperties.correlationId: -|uuid
  AuditLogStatus: ConnectedRegistryAuditLogStatus
  GenerateCredentialsParameters: ContainerRegistryGenerateCredentialsContent
  LogLevel: ConnectedRegistryLogLevel
  PipelineRunRequest: ConnectedRegistryPipelineRunContent
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
  AzureADAuthenticationAsArmPolicyStatus: AadAuthenticationAsArmPolicyStatus
  PackageSourceType: ArchivePackageSourceType
  RoleAssignmentMode: ContainerRegistryRoleAssignmentMode
  ConnectedRegistry.properties.clientTokenIds: -|arm-id
  ConnectedRegistryUpdateParameters.properties.clientTokenIds: -|arm-id
  PrivateLinkResource.properties.requiredZoneNames: RequiredZoneNamesList

override-operation-name:
  Schedules_ScheduleRun: ScheduleRun
  Registries_CheckNameAvailability: CheckContainerRegistryNameAvailability
  Builds_GetBuildSourceUploadUrl: GetBuildSourceUploadUrl

directive:
  - from: containerregistry_build.json
    where: $.info
    transform: >
      $['title'] = 'ContainerRegistryManagementClient';
  # these two renames of operation would make the xml doc incorrect, but currently this is required because now the same operation would contain multiple api-versions if we do not rename.
  - rename-operation:
      from: Registries_GetBuildSourceUploadUrl
      to: Builds_GetBuildSourceUploadUrl
  - rename-operation:
      from: Registries_ScheduleRun
      to: Schedules_ScheduleRun
  - from: swagger-document
    where: $.definitions..expiry
    transform: >
      $['x-ms-client-name'] = 'ExpireOn';
```

### Tag: package-2025-11-dotnetmix

These settings apply only when `--tag=package-2025-11-dotnetmix` is specified on the command line.

``` yaml $(tag) == 'package-2025-11-dotnetmix'
input-file:
  - https://github.com/kazrael2119/azure-rest-api-specs/tree/46f0876572153f2d941e862613abb95953f71d34/specification/containerregistry/resource-manager/Microsoft.ContainerRegistry/Registry/stable/2025-11-01/containerregistry.json
  - https://github.com/kazrael2119/azure-rest-api-specs/tree/46f0876572153f2d941e862613abb95953f71d34/specification/containerregistry/resource-manager/Microsoft.ContainerRegistry/RegistryTasks/preview/2025-03-01-preview/containerregistry_build.json
```
