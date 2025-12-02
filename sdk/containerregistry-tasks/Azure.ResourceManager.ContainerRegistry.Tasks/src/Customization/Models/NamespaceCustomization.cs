using System;
using Azure.Core;

namespace Azure.ResourceManager.ContainerRegistry
{
    [CodeGenType("ContainerRegistryAgentPoolResource")]
    public partial class ContainerRegistryAgentPoolResource {}
    [CodeGenType("ContainerRegistryAgentPoolData")]
    public partial class ContainerRegistryAgentPoolData {}
    [CodeGenType("ContainerRegistryAgentPoolCollection")]
    public partial class ContainerRegistryAgentPoolCollection {}

    [CodeGenType("ContainerRegistryRunResource")]
    public partial class ContainerRegistryRunResource {}
    [CodeGenType("ContainerRegistryRunData")]
    public partial class ContainerRegistryRunData {}
    [CodeGenType("ContainerRegistryRunCollection")]
    public partial class ContainerRegistryRunCollection {}

    [CodeGenType("ContainerRegistryTaskResource")]
    public partial class ContainerRegistryTaskResource {}
    [CodeGenType("ContainerRegistryTaskData")]
    public partial class ContainerRegistryTaskData {}
    [CodeGenType("ContainerRegistryTaskCollection")]
    public partial class ContainerRegistryTaskCollection {}

    [CodeGenType("ContainerRegistryTaskRunResource")]
    public partial class ContainerRegistryTaskRunResource {}
    [CodeGenType("ContainerRegistryTaskRunData")]
    public partial class ContainerRegistryTaskRunData {}
    [CodeGenType("ContainerRegistryTaskRunCollection")]
    public partial class ContainerRegistryTaskRunCollection {}
}

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    [CodeGenType("ContainerRegistryAgentPoolListResult")]
    public partial class ContainerRegistryAgentPoolListResult {}
    [CodeGenType("ContainerRegistryAgentPoolPatch")]
    public partial class ContainerRegistryAgentPoolPatch {}
    [CodeGenType("ContainerRegistryAgentPoolQueueStatus")]
    public partial class ContainerRegistryAgentPoolQueueStatus {}
    [CodeGenType("ContainerRegistryAgentProperties")]
    public partial class ContainerRegistryAgentProperties {}
    [CodeGenType("ContainerRegistryBaseImageDependency")]
    public partial class ContainerRegistryBaseImageDependency {}
    [CodeGenType("ContainerRegistryBaseImageDependencyType")]
    public partial class ContainerRegistryBaseImageDependencyType {}
    [CodeGenType("ContainerRegistryBaseImageTrigger")]
    public partial class ContainerRegistryBaseImageTrigger {}
    [CodeGenType("ContainerRegistryBaseImageTriggerType")]
    public partial class ContainerRegistryBaseImageTriggerType {}
    [CodeGenType("ContainerRegistryCredentials")]
    public partial class ContainerRegistryCredentials {}
    [CodeGenType("ContainerRegistryDockerBuildStep")]
    public partial class ContainerRegistryDockerBuildStep {}
    [CodeGenType("ContainerRegistryEncodedTaskStep")]
    public partial class ContainerRegistryEncodedTaskStep {}
    [CodeGenType("ContainerRegistryFileTaskStep")]
    public partial class ContainerRegistryFileTaskStep {}
    [CodeGenType("ContainerRegistryImageDescriptor")]
    public partial class ContainerRegistryImageDescriptor {}
    [CodeGenType("ContainerRegistryImageUpdateTrigger")]
    public partial class ContainerRegistryImageUpdateTrigger {}
    [CodeGenType("ContainerRegistryOverrideTaskStepProperties")]
    public partial class ContainerRegistryOverrideTaskStepProperties {}
    [CodeGenType("ContainerRegistryPlatformProperties")]
    public partial class ContainerRegistryPlatformProperties {}
    [CodeGenType("ContainerRegistryProvisioningState")]
    public partial class ContainerRegistryProvisioningState {}
    [CodeGenType("ContainerRegistryRunGetLogResult")]
    public partial class ContainerRegistryRunGetLogResult {}
    [CodeGenType("ContainerRegistryRunListResult")]
    public partial class ContainerRegistryRunListResult {}
    [CodeGenType("ContainerRegistryRunPatch")]
    public partial class ContainerRegistryRunPatch {}
    [CodeGenType("ContainerRegistryRunStatus")]
    public partial class ContainerRegistryRunStatus {}
    [CodeGenType("ContainerRegistryRunType")]
    public partial class ContainerRegistryRunType {}
    [CodeGenType("ContainerRegistrySecretObject")]
    public partial class ContainerRegistrySecretObject {}
    [CodeGenType("ContainerRegistrySecretObjectType")]
    public partial class ContainerRegistrySecretObjectType {}
    [CodeGenType("ContainerRegistrySourceTrigger")]
    public partial class ContainerRegistrySourceTrigger {}
    [CodeGenType("ContainerRegistrySourceTriggerDescriptor")]
    public partial class ContainerRegistrySourceTriggerDescriptor {}
    [CodeGenType("ContainerRegistrySourceTriggerEvent")]
    public partial class ContainerRegistrySourceTriggerEvent {}
    [CodeGenType("ContainerRegistryTaskListResult")]
    public partial class ContainerRegistryTaskListResult {}
    [CodeGenType("ContainerRegistryTaskPatch")]
    public partial class ContainerRegistryTaskPatch {}
    [CodeGenType("ContainerRegistryTaskRunListResult")]
    public partial class ContainerRegistryTaskRunListResult {}
    [CodeGenType("ContainerRegistryTaskRunPatch")]
    public partial class ContainerRegistryTaskRunPatch {}
    [CodeGenType("ContainerRegistryTaskStatus")]
    public partial class ContainerRegistryTaskStatus {}
    [CodeGenType("ContainerRegistryTaskStepProperties")]
    public partial class ContainerRegistryTaskStepProperties {}
    [CodeGenType("ContainerRegistryTaskStepType")]
    public partial class ContainerRegistryTaskStepType {}
    [CodeGenType("ContainerRegistryTimerTrigger")]
    public partial class ContainerRegistryTimerTrigger {}
    [CodeGenType("ContainerRegistryTimerTriggerDescriptor")]
    public partial class ContainerRegistryTimerTriggerDescriptor {}
    [CodeGenType("ContainerRegistryTriggerProperties")]
    public partial class ContainerRegistryTriggerProperties {}
    [CodeGenType("ContainerRegistryTriggerStatus")]
    public partial class ContainerRegistryTriggerStatus {}
    [CodeGenType("ContainerRegistryUpdateTriggerPayloadType")]
    public partial class ContainerRegistryUpdateTriggerPayloadType {}

    [CodeGenType("ContainerRegistryBaseImageTriggerUpdateContent")]
    public partial class ContainerRegistryBaseImageTriggerUpdateContent {}
    [CodeGenType("ContainerRegistryCpuVariant")]
    public partial class ContainerRegistryCpuVariant {}
    [CodeGenType("ContainerRegistryDockerBuildContent")]
    public partial class ContainerRegistryDockerBuildContent {}
    [CodeGenType("ContainerRegistryDockerBuildStepUpdateContent")]
    public partial class ContainerRegistryDockerBuildStepUpdateContent {}
    [CodeGenType("ContainerRegistryEncodedTaskRunContent")]
    public partial class ContainerRegistryEncodedTaskRunContent {}
    [CodeGenType("ContainerRegistryEncodedTaskStepUpdateContent")]
    public partial class ContainerRegistryEncodedTaskStepUpdateContent {}
    [CodeGenType("ContainerRegistryFileTaskRunContent")]
    public partial class ContainerRegistryFileTaskRunContent {}
    [CodeGenType("ContainerRegistryFileTaskStepUpdateContent")]
    public partial class ContainerRegistryFileTaskStepUpdateContent {}
    [CodeGenType("ContainerRegistryOS")]
    public partial class ContainerRegistryOS {}
    [CodeGenType("ContainerRegistryOSArchitecture")]
    public partial class ContainerRegistryOSArchitecture {}
    [CodeGenType("ContainerRegistryPlatformUpdateContent")]
    public partial class ContainerRegistryPlatformUpdateContent {}
    [CodeGenType("ContainerRegistryRunArgument")]
    public partial class ContainerRegistryRunArgument {}
    [CodeGenType("ContainerRegistryRunContent")]
    public partial class ContainerRegistryRunContent {}
    [CodeGenType("ContainerRegistrySourceTriggerUpdateContent")]
    public partial class ContainerRegistrySourceTriggerUpdateContent {}
    [CodeGenType("ContainerRegistryTaskOverridableValue")]
    public partial class ContainerRegistryTaskOverridableValue {}
    [CodeGenType("ContainerRegistryTaskRunContent")]
    public partial class ContainerRegistryTaskRunContent {}
    [CodeGenType("ContainerRegistryTaskStepUpdateContent")]
    public partial class ContainerRegistryTaskStepUpdateContent {}
    [CodeGenType("ContainerRegistryTimerTriggerUpdateContent")]
    public partial class ContainerRegistryTimerTriggerUpdateContent {}
    [CodeGenType("ContainerRegistryTriggerUpdateContent")]
    public partial class ContainerRegistryTriggerUpdateContent {}
    [CodeGenType("CustomRegistryCredentials")]
    public partial class CustomRegistryCredentials {}
    [CodeGenType("SourceCodeRepoAuthInfo")]
    public partial class SourceCodeRepoAuthInfo {}
    [CodeGenType("SourceCodeRepoAuthInfoUpdateContent")]
    public partial class SourceCodeRepoAuthInfoUpdateContent {}
    [CodeGenType("SourceCodeRepoAuthTokenType")]
    public partial class SourceCodeRepoAuthTokenType {}
    [CodeGenType("SourceCodeRepoProperties")]
    public partial class SourceCodeRepoProperties {}
    [CodeGenType("SourceCodeRepoUpdateContent")]
    public partial class SourceCodeRepoUpdateContent {}
    [CodeGenType("SourceControlType")]
    public partial class SourceControlType {}
    [CodeGenType("SourceRegistryCredentials")]
    public partial class SourceRegistryCredentials {}
    [CodeGenType("SourceRegistryLoginMode")]
    public partial class SourceRegistryLoginMode {}
    [CodeGenType("SourceUploadDefinition")]
    public partial class SourceUploadDefinition {}
    [CodeGenType("UnknownRunRequest")]
    public partial class UnknownRunRequest {}
    [CodeGenType("UnknownTaskStepProperties")]
    public partial class UnknownTaskStepProperties {}
    [CodeGenType("UnknownTaskStepUpdateParameters")]
    public partial class UnknownTaskStepUpdateParameters {}
}
