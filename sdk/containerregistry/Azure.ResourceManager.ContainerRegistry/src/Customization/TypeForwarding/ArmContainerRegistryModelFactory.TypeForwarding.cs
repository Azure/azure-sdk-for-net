using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ContainerRegistry;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    public static partial class ArmContainerRegistryModelFactory
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryAgentPoolData ContainerRegistryAgentPoolData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, int? count = null, string tier = null, ContainerRegistryOS? os = null, ResourceIdentifier virtualNetworkSubnetResourceId = null, ContainerRegistryProvisioningState? provisioningState = null)
        {
            return ArmContainerRegistryTasksModelFactory.ContainerRegistryAgentPoolData(id, name, resourceType, systemData, tags, location, count, tier, os, virtualNetworkSubnetResourceId, provisioningState);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryRunData ContainerRegistryRunData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string runId = null, ContainerRegistryRunStatus? status = null, DateTimeOffset? lastUpdatedOn = null, ContainerRegistryRunType? runType = null, string agentPoolName = null, DateTimeOffset? createdOn = null, DateTimeOffset? startOn = null, DateTimeOffset? finishOn = null, IEnumerable<ContainerRegistryImageDescriptor> outputImages = null, string task = null, ContainerRegistryImageUpdateTrigger imageUpdateTrigger = null, ContainerRegistrySourceTriggerDescriptor sourceTrigger = null, ContainerRegistryTimerTriggerDescriptor timerTrigger = null, ContainerRegistryPlatformProperties platform = null, int? agentCpu = null, string sourceRegistryAuth = null, IEnumerable<string> customRegistries = null, string runErrorMessage = null, string updateTriggerToken = null, ContainerRegistryImageDescriptor logArtifact = null, ContainerRegistryProvisioningState? provisioningState = null, bool? isArchiveEnabled = null)
        {
            return ArmContainerRegistryTasksModelFactory.ContainerRegistryRunData(id, name, resourceType, systemData, runId, status, lastUpdatedOn, runType, agentPoolName, createdOn, startOn, finishOn, outputImages, task, imageUpdateTrigger, sourceTrigger, timerTrigger, platform, agentCpu, sourceRegistryAuth, customRegistries, runErrorMessage, updateTriggerToken, logArtifact, provisioningState, isArchiveEnabled);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryTaskData ContainerRegistryTaskData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ManagedServiceIdentity identity = null, ContainerRegistryProvisioningState? provisioningState = null, DateTimeOffset? createdOn = null, ContainerRegistryTaskStatus? status = null, ContainerRegistryPlatformProperties platform = null, int? agentCpu = null, string agentPoolName = null, int? timeoutInSeconds = null, ContainerRegistryTaskStepProperties step = null, ContainerRegistryTriggerProperties trigger = null, ContainerRegistryCredentials credentials = null, string logTemplate = null, bool? isSystemTask = null)
        {
            return ArmContainerRegistryTasksModelFactory.ContainerRegistryTaskData(id, name, resourceType, systemData, tags, location, identity, provisioningState, createdOn, status, platform, agentCpu, agentPoolName, timeoutInSeconds, step, trigger, credentials, logTemplate, isSystemTask);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryTaskRunData ContainerRegistryTaskRunData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ManagedServiceIdentity identity = null, AzureLocation? location = null, ContainerRegistryProvisioningState? provisioningState = null, ContainerRegistryRunContent runRequest = null, ContainerRegistryRunData runResult = null, string forceUpdateTag = null)
        {
            return ArmContainerRegistryTasksModelFactory.ContainerRegistryTaskRunData(id, name, resourceType, systemData, identity, location, provisioningState, runRequest, runResult, forceUpdateTag);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryDockerBuildStep ContainerRegistryDockerBuildStep(IEnumerable<ContainerRegistryBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null, IEnumerable<string> imageNames = null, bool? isPushEnabled = null, bool? noCache = null, string dockerFilePath = null, string target = null, IEnumerable<ContainerRegistryRunArgument> arguments = null)
        {
            return ArmContainerRegistryTasksModelFactory.ContainerRegistryDockerBuildStep(baseImageDependencies, contextPath, contextAccessToken, imageNames, isPushEnabled, noCache, dockerFilePath, target, arguments);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryFileTaskStep ContainerRegistryFileTaskStep(IEnumerable<ContainerRegistryBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null, string taskFilePath = null, string valuesFilePath = null, IEnumerable<ContainerRegistryTaskOverridableValue> values = null)
        {
            return ArmContainerRegistryTasksModelFactory.ContainerRegistryFileTaskStep(baseImageDependencies, contextPath, contextAccessToken, taskFilePath, valuesFilePath, values);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryEncodedTaskStep ContainerRegistryEncodedTaskStep(IEnumerable<ContainerRegistryBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null, string encodedTaskContent = null, string encodedValuesContent = null, IEnumerable<ContainerRegistryTaskOverridableValue> values = null)
        {
            return ArmContainerRegistryTasksModelFactory.ContainerRegistryEncodedTaskStep(baseImageDependencies, contextPath, contextAccessToken, encodedTaskContent, encodedValuesContent, values);
        }
    }
}
