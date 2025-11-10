# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: ContainerRegistry
namespace: Azure.ResourceManager.ContainerRegistry
# Temporarily releasing the SDK from the Swagger specification; this will be updated once support for generating SDKs from multiple TypeSpec sources is available.
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/aaea49a20b10e8ab526495309e14fdfdcd23bb7e/specification/containerregistry/resource-manager/Microsoft.ContainerRegistry/Registry/stable/2025-11-01/containerregistry.json
  - https://github.com/Azure/azure-rest-api-specs/blob/aaea49a20b10e8ab526495309e14fdfdcd23bb7e/specification/containerregistry/resource-manager/Microsoft.ContainerRegistry/RegistryTasks/preview/2019-06-01-preview/containerregistry_build.json
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

#mgmt-debug:
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
  - AuthCredential
  - BaseImageDependency
  - BaseImageDependencyType
  - BaseImageTrigger
  - BaseImageTriggerType
  - CacheRule
  - CertificateType
  - CredentialHealth
  - CredentialHealthStatus
  - CredentialName
  - Credentials
  - CredentialSet
  - DockerBuildStep
  - EncodedTaskStep
  - EncryptionStatus
  - ExportPolicy
  - ExportPolicyStatus
  - FileTaskStep
  - GenerateCredentialsResult
  - ImageDescriptor
  - ImageUpdateTrigger
  - ImportImageParameters
  - ImportMode
  - ImportSource
  - ImportSourceCredentials
  - IPRule
  - KeyVaultProperties
  - NetworkRuleSet
  - OverrideTaskStepProperties
  - PasswordName
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
  Action: ContainerRegistryIPRuleAction
  ActivationProperties: ConnectedRegistryActivation
  ActivationStatus: ConnectedRegistryActivationStatus
  Actor: ContainerRegistryWebhookEventActor
  ActionsRequired: ActionsRequiredForPrivateLinkServiceConsumer
  Architecture: ContainerRegistryOSArchitecture
  Argument: ContainerRegistryRunArgument
  AuditLogStatus: ConnectedRegistryAuditLogStatus
  AuthInfo: SourceCodeRepoAuthInfo
  AuthInfo.expiresIn: ExpireInSeconds
  AuthInfoUpdateParameters: SourceCodeRepoAuthInfoUpdateContent
  AzureADAuthenticationAsArmPolicyStatus: AadAuthenticationAsArmPolicyStatus
  BaseImageTriggerUpdateParameters: ContainerRegistryBaseImageTriggerUpdateContent
  CallbackConfig: ContainerRegistryWebhookCallbackConfig
  ConnectionState: ConnectedRegistryConnectionState
  ConnectionStatus: ContainerRegistryPrivateLinkServiceConnectionStatus
  ConnectedRegistry.properties.clientTokenIds: -|arm-id
  ConnectedRegistryUpdateParameters.properties.clientTokenIds: -|arm-id
  DefaultAction: ContainerRegistryNetworkRuleDefaultAction
  DockerBuildRequest: ContainerRegistryDockerBuildContent
  DockerBuildRequest.timeout: TimeoutInSeconds
  DockerBuildStepUpdateParameters: ContainerRegistryDockerBuildStepUpdateContent
  EncodedTaskRunRequest: ContainerRegistryEncodedTaskRunContent
  EncodedTaskRunRequest.timeout: TimeoutInSeconds
  EncodedTaskStepUpdateParameters: ContainerRegistryEncodedTaskStepUpdateContent
  EncryptionProperty: ContainerRegistryEncryption
  Event: ContainerRegistryWebhookEvent
  EventContent: ContainerRegistryWebhookEventContent
  EventContent.id: -|uuid
  EventInfo: ContainerRegistryWebhookEventInfo
  EventInfo.id: -|uuid
  EventListResult: ContainerRegistryWebhookEventListResult
  EventRequestMessage: ContainerRegistryWebhookEventRequestMessage
  EventResponseMessage: ContainerRegistryWebhookEventResponseMessage
  FileTaskRunRequest: ContainerRegistryFileTaskRunContent
  FileTaskRunRequest.timeout: TimeoutInSeconds
  FileTaskStepUpdateParameters: ContainerRegistryFileTaskStepUpdateContent
  GenerateCredentialsParameters: ContainerRegistryGenerateCredentialsContent
  ImageUpdateTrigger.id: -|uuid
  ImportSource.registryUri: RegistryAddress
  KeyVaultProperties.keyRotationEnabled: IsKeyRotationEnabled
  LogLevel: ConnectedRegistryLogLevel
  LoggingProperties: ConnectedRegistryLogging
  LoginServerProperties: ConnectedRegistryLoginServer
  NetworkRuleBypassOptions: ContainerRegistryNetworkRuleBypassOption
  OS: ContainerRegistryOS
  ParentProperties: ConnectedRegistryParent
  ParentProperties.id: -|arm-id
  PlatformUpdateParameters: ContainerRegistryPlatformUpdateContent
  RegenerateCredentialParameters: ContainerRegistryCredentialRegenerateContent
  Registry: ContainerRegistry
  Registry.properties.adminUserEnabled: IsAdminUserEnabled
  Registry.properties.anonymousPullEnabled: IsAnonymousPullEnabled
  Registry.properties.dataEndpointEnabled: IsDataEndpointEnabled
  Registry.properties.networkRuleBypassAllowedForTasks: IsNetworkRuleBypassAllowedForTasks
  RegistryListCredentialsResult: ContainerRegistryListCredentialsResult
  RegistryListResult: ContainerRegistryListResult
  RegistryNameCheckRequest: ContainerRegistryNameAvailabilityContent
  RegistryNameStatus: ContainerRegistryNameAvailableResult
  RegistryNameStatus.nameAvailable: IsNameAvailable
  RegistryPassword: ContainerRegistryPassword
  RegistryUpdateParameters: ContainerRegistryPatch
  RegistryUpdateParameters.properties.adminUserEnabled: IsAdminUserEnabled
  RegistryUpdateParameters.properties.anonymousPullEnabled: IsAnonymousPullEnabled
  RegistryUpdateParameters.properties.dataEndpointEnabled: IsDataEndpointEnabled
  RegistryUpdateParameters.properties.networkRuleBypassAllowedForTasks: IsNetworkRuleBypassAllowedForTasks
  RegistryUsage: ContainerRegistryUsage
  RegistryUsageListResult: ContainerRegistryUsageListResult
  RegistryUsageUnit: ContainerRegistryUsageUnit
  Replication.properties.regionEndpointEnabled: IsRegionEndpointEnabled
  ReplicationUpdateParameters.properties.regionEndpointEnabled: IsRegionEndpointEnabled
  Request: ContainerRegistryWebhookEventRequestContent
  Request.id: -|uuid
  RoleAssignmentMode: ContainerRegistryRoleAssignmentMode
  Run.properties.createTime: CreatedOn
  RunRequest: ContainerRegistryRunContent
  ScopeMap.properties.type: ScopeMapType
  SetValue: ContainerRegistryTaskOverridableValue
  Source: ContainerRegistryWebhookEventSource
  SourceProperties: SourceCodeRepoProperties
  SourceTriggerDescriptor.id: -|uuid
  SourceTriggerUpdateParameters: ContainerRegistrySourceTriggerUpdateContent
  SourceUpdateParameters: SourceCodeRepoUpdateContent
  Status: ContainerRegistryResourceStatus
  StatusDetailProperties: ConnectedRegistryStatusDetail
  StatusDetailProperties.correlationId: -|uuid
  StatusDetailProperties.type: StatusDetailType
  StepType: ContainerRegistryTaskStepType
  SyncProperties: ConnectedRegistrySyncProperties
  SyncUpdateProperties: ConnectedRegistrySyncUpdateProperties
  Target: ContainerRegistryWebhookEventTarget
  Task.properties.timeout: TimeoutInSeconds
  TaskRunRequest: ContainerRegistryTaskRunContent
  TaskStepProperties.type: ContainerRegistryTaskStepType
  TaskStepUpdateParameters: ContainerRegistryTaskStepUpdateContent
  TaskUpdateParameters.properties.timeout: TimeoutInSeconds
  TimerTriggerUpdateParameters: ContainerRegistryTimerTriggerUpdateContent
  TlsCertificateProperties.location: CertificateLocation
  TokenCredentialsProperties: ContainerRegistryTokenCredentials
  TokenType: SourceCodeRepoAuthTokenType
  TokenUpdateParameters: ContainerRegistryTokenPatch
  TriggerUpdateParameters: ContainerRegistryTriggerUpdateContent
  Variant: ContainerRegistryCpuVariant

override-operation-name:
  Schedules_ScheduleRun: ScheduleRun
  Registries_CheckNameAvailability: CheckContainerRegistryNameAvailability
  Builds_GetBuildSourceUploadUrl: GetBuildSourceUploadUrl

directive:
  # these two renames of operation would make the xml doc incorrect, but currently this is required because now the same operation would contain multiple api-versions if we do not rename.
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
      $.LoginServerProperties.properties.tls = {
          "$ref": "#/definitions/TlsProperties",
          "description": "The TLS properties of the connected registry login server.",
          "readOnly": true
        };
      $.TlsProperties.properties.certificate = {
          "$ref": "#/definitions/TlsCertificateProperties",
          "description": "The certificate used to configure HTTPS for the login server.",
          "readOnly": true
        };
  - from: swagger-document
    where: $.definitions..expiry
    transform: >
      $['x-ms-client-name'] = 'ExpireOn';
  - from: types.json
    where: $.parameters.SubscriptionIdParameter.format
    transform: >
      return undefined;
```
