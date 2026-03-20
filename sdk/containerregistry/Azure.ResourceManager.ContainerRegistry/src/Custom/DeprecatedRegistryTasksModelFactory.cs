// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591, SA1402, SA1508

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ContainerRegistry.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    // Backward compatibility: ModelFactory methods for deprecated Task/Run/AgentPool types
    public static partial class ArmContainerRegistryModelFactory
    {
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryAgentPoolData ContainerRegistryAgentPoolData(
            ResourceIdentifier id = null, string name = null, ResourceType resourceType = default,
            SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default,
            int? count = null, string tier = null, ContainerRegistryOS? os = null,
            ResourceIdentifier virtualNetworkSubnetResourceId = null, ContainerRegistryProvisioningState? provisioningState = null)
            => throw null;

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryRunData ContainerRegistryRunData(
            ResourceIdentifier id = null, string name = null, ResourceType resourceType = default,
            SystemData systemData = null, string runId = null, ContainerRegistryRunStatus? status = null,
            DateTimeOffset? lastUpdatedOn = null, ContainerRegistryRunType? runType = null,
            string runErrorMessage = null, DateTimeOffset? createdOn = null, DateTimeOffset? finishOn = null,
            DateTimeOffset? startOn = null, IEnumerable<ContainerRegistryImageDescriptor> outputImages = null,
            string task = null, ContainerRegistryImageUpdateTrigger imageUpdateTrigger = null,
            ContainerRegistrySourceTriggerDescriptor sourceTrigger = null,
            ContainerRegistryTimerTriggerDescriptor timerTrigger = null,
            ContainerRegistryPlatformProperties platform = null, int? agentCpu = null,
            string agentPoolName = null, IEnumerable<string> customRegistries = null,
            string sourceRegistryAuth = null, string updateTriggerToken = null,
            ContainerRegistryImageDescriptor logArtifact = null,
            ContainerRegistryProvisioningState? provisioningState = null, bool? isArchiveEnabled = null)
            => throw null;

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryTaskData ContainerRegistryTaskData(
            ResourceIdentifier id = null, string name = null, ResourceType resourceType = default,
            SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default,
            ManagedServiceIdentity identity = null, ContainerRegistryProvisioningState? provisioningState = null,
            DateTimeOffset? createdOn = null, ContainerRegistryTaskStatus? status = null,
            ContainerRegistryPlatformProperties platform = null, int? agentCpu = null,
            string agentPoolName = null, int? timeoutInSeconds = null,
            ContainerRegistryTaskStepProperties step = null,
            ContainerRegistryTriggerProperties trigger = null,
            ContainerRegistryCredentials credentials = null, string logTemplate = null,
            bool? isSystemTask = null)
            => throw null;

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryTaskRunData ContainerRegistryTaskRunData(
            ResourceIdentifier id = null, string name = null, ResourceType resourceType = default,
            SystemData systemData = null, ManagedServiceIdentity identity = null, AzureLocation? location = null,
            ContainerRegistryProvisioningState? provisioningState = null, ContainerRegistryRunContent runRequest = null,
            ContainerRegistryRunData runResult = null, string forceUpdateTag = null)
            => throw null;

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryAgentPoolQueueStatus ContainerRegistryAgentPoolQueueStatus(int? count = null)
            => throw null;

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryBaseImageDependency ContainerRegistryBaseImageDependency(
            ContainerRegistryBaseImageDependencyType? dependencyType = null, string registry = null,
            string repository = null, string tag = null, string digest = null)
            => throw null;

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryBaseImageTriggerUpdateContent ContainerRegistryBaseImageTriggerUpdateContent(
            ContainerRegistryBaseImageTriggerType? baseImageTriggerType = null, string updateTriggerEndpoint = null,
            ContainerRegistryUpdateTriggerPayloadType? updateTriggerPayloadType = null,
            ContainerRegistryTriggerStatus? status = null, string name = null)
            => throw null;

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryDockerBuildStep ContainerRegistryDockerBuildStep(
            IEnumerable<ContainerRegistryBaseImageDependency> baseImageDependencies = null,
            string contextPath = null, string contextAccessToken = null,
            IEnumerable<string> imageNames = null, bool? isPushEnabled = null,
            bool? noCache = null, string dockerFilePath = null, string target = null,
            IEnumerable<ContainerRegistryRunArgument> arguments = null)
            => throw null;

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryEncodedTaskStep ContainerRegistryEncodedTaskStep(
            IEnumerable<ContainerRegistryBaseImageDependency> baseImageDependencies = null,
            string contextPath = null, string contextAccessToken = null,
            string encodedTaskContent = null, string encodedValuesContent = null,
            IEnumerable<ContainerRegistryTaskOverridableValue> values = null)
            => throw null;

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryFileTaskStep ContainerRegistryFileTaskStep(
            IEnumerable<ContainerRegistryBaseImageDependency> baseImageDependencies = null,
            string contextPath = null, string contextAccessToken = null,
            string taskFilePath = null, string valuesFilePath = null,
            IEnumerable<ContainerRegistryTaskOverridableValue> values = null)
            => throw null;

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryRunGetLogResult ContainerRegistryRunGetLogResult(
            string logLink = null, string logArtifactLink = null)
            => throw null;

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistrySourceTriggerUpdateContent ContainerRegistrySourceTriggerUpdateContent(
            SourceCodeRepoUpdateContent sourceRepository = null,
            IEnumerable<ContainerRegistrySourceTriggerEvent> sourceTriggerEvents = null,
            ContainerRegistryTriggerStatus? status = null, string name = null)
            => throw null;

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryTaskStepProperties ContainerRegistryTaskStepProperties(
            string contextPath = null, IEnumerable<ContainerRegistryBaseImageDependency> baseImageDependencies = null,
            string contextAccessToken = null, string type = null)
            => throw null;

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryTimerTriggerUpdateContent ContainerRegistryTimerTriggerUpdateContent(
            string schedule = null, ContainerRegistryTriggerStatus? status = null, string name = null)
            => throw null;

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SourceUploadDefinition SourceUploadDefinition(Uri uploadUri = null, string relativePath = null)
            => throw null;
    }
}
