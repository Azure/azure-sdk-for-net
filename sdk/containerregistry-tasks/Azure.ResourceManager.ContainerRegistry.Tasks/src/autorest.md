# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: ContainerRegistryTasks
namespace: Azure.ResourceManager.ContainerRegistry.Tasks
# Temporarily releasing the SDK from the Swagger specification; this will be updated once support for generating SDKs from multiple TypeSpec sources is available.
input-file:
#   - https://github.com/Azure/azure-rest-api-specs/blob/aaea49a20b10e8ab526495309e14fdfdcd23bb7e/specification/containerregistry/resource-manager/Microsoft.ContainerRegistry/Registry/stable/2025-11-01/containerregistry.json
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

rename-mapping:
  Architecture: ContainerRegistryOSArchitecture
  Argument: ContainerRegistryRunArgument
  AuthInfo: SourceCodeRepoAuthInfo
  AuthInfo.expiresIn: ExpireInSeconds
  AuthInfoUpdateParameters: SourceCodeRepoAuthInfoUpdateContent
  BaseImageTriggerUpdateParameters: ContainerRegistryBaseImageTriggerUpdateContent
  DockerBuildRequest: ContainerRegistryDockerBuildContent
  DockerBuildRequest.timeout: TimeoutInSeconds
  DockerBuildStepUpdateParameters: ContainerRegistryDockerBuildStepUpdateContent
  EncodedTaskRunRequest: ContainerRegistryEncodedTaskRunContent
  EncodedTaskRunRequest.timeout: TimeoutInSeconds
  EncodedTaskStepUpdateParameters: ContainerRegistryEncodedTaskStepUpdateContent
  FileTaskRunRequest: ContainerRegistryFileTaskRunContent
  FileTaskRunRequest.timeout: TimeoutInSeconds
  FileTaskStepUpdateParameters: ContainerRegistryFileTaskStepUpdateContent
  ImageUpdateTrigger.id: -|uuid
  OS: ContainerRegistryOS
  PlatformUpdateParameters: ContainerRegistryPlatformUpdateContent
  Run.properties.createTime: CreatedOn
  RunRequest: ContainerRegistryRunContent
  SetValue: ContainerRegistryTaskOverridableValue
  SourceProperties: SourceCodeRepoProperties
  SourceTriggerDescriptor.id: -|uuid
  SourceTriggerUpdateParameters: ContainerRegistrySourceTriggerUpdateContent
  SourceUpdateParameters: SourceCodeRepoUpdateContent
  StepType: ContainerRegistryTaskStepType
  Task.properties.timeout: TimeoutInSeconds
  TaskRunRequest: ContainerRegistryTaskRunContent
  TaskStepProperties.type: ContainerRegistryTaskStepType
  TaskStepUpdateParameters: ContainerRegistryTaskStepUpdateContent
  TaskUpdateParameters.properties.timeout: TimeoutInSeconds
  TimerTriggerUpdateParameters: ContainerRegistryTimerTriggerUpdateContent
  TokenType: SourceCodeRepoAuthTokenType
  TriggerUpdateParameters: ContainerRegistryTriggerUpdateContent
  Variant: ContainerRegistryCpuVariant
  AgentPool: ContainerRegistryAgentPool
  AgentPoolListResult: ContainerRegistryAgentPoolListResult
  AgentPoolQueueStatus: ContainerRegistryAgentPoolQueueStatus
  AgentProperties: ContainerRegistryAgentProperties
  BaseImageDependency: ContainerRegistryBaseImageDependency
  BaseImageDependencyType: ContainerRegistryBaseImageDependencyType
  BaseImageTrigger: ContainerRegistryBaseImageTrigger
  BaseImageTriggerType: ContainerRegistryBaseImageTriggerType
  Credentials: ContainerRegistryCredentials
  DockerBuildStep: ContainerRegistryDockerBuildStep
  EncodedTaskStep: ContainerRegistryEncodedTaskStep
  FileTaskStep: ContainerRegistryFileTaskStep
  ImageDescriptor: ContainerRegistryImageDescriptor
  ImageUpdateTrigger: ContainerRegistryImageUpdateTrigger
  OverrideTaskStepProperties: ContainerRegistryOverrideTaskStepProperties
  PlatformProperties: ContainerRegistryPlatformProperties
  ProvisioningState: ContainerRegistryProvisioningState
  Run: ContainerRegistryRun
  RunGetLogResult: ContainerRegistryRunGetLogResult
  RunListResult: ContainerRegistryRunListResult
  RunStatus: ContainerRegistryRunStatus
  RunType: ContainerRegistryRunType
  SecretObject: ContainerRegistrySecretObject
  SecretObjectType: ContainerRegistrySecretObjectType
  SourceTrigger: ContainerRegistrySourceTrigger
  SourceTriggerDescriptor: ContainerRegistrySourceTriggerDescriptor
  SourceTriggerEvent: ContainerRegistrySourceTriggerEvent
  Task: ContainerRegistryTask
  TaskListResult: ContainerRegistryTaskListResult
  TaskRun: ContainerRegistryTaskRun
  TaskRunListResult: ContainerRegistryTaskRunListResult
  TaskStatus: ContainerRegistryTaskStatus
  TaskStepProperties: ContainerRegistryTaskStepProperties
  TimerTrigger: ContainerRegistryTimerTrigger
  TimerTriggerDescriptor: ContainerRegistryTimerTriggerDescriptor
  TriggerProperties: ContainerRegistryTriggerProperties
  TriggerStatus: ContainerRegistryTriggerStatus
  UpdateTriggerPayloadType: ContainerRegistryUpdateTriggerPayloadType

override-operation-name:
  Schedules_ScheduleRun: ScheduleRun
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
