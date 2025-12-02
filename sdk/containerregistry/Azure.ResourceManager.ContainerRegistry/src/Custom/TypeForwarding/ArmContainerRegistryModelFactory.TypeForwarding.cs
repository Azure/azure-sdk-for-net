// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    public static partial class ArmContainerRegistryModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="ContainerRegistry.ContainerRegistryAgentPoolData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="count"> The count of agent machine. </param>
        /// <param name="tier"> The Tier of agent machine. </param>
        /// <param name="os"> The OS of agent machine. </param>
        /// <param name="virtualNetworkSubnetResourceId"> The Virtual Network Subnet Resource Id of the agent machine. </param>
        /// <param name="provisioningState"> The provisioning state of this agent pool. </param>
        /// <returns> A new <see cref="ContainerRegistry.ContainerRegistryAgentPoolData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryAgentPoolData ContainerRegistryAgentPoolData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, int? count = null, string tier = null, ContainerRegistryOS? os = null, ResourceIdentifier virtualNetworkSubnetResourceId = null, ContainerRegistryProvisioningState? provisioningState = null)
        {
            throw null;
            //return ArmContainerRegistryTasksModelFactory.ContainerRegistryAgentPoolData(id, name, resourceType, systemData, tags, location, count, tier, os, virtualNetworkSubnetResourceId, provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="ContainerRegistry.ContainerRegistryRunData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="runId"> The unique identifier for the run. </param>
        /// <param name="status"> The current status of the run. </param>
        /// <param name="lastUpdatedOn"> The last updated time for the run. </param>
        /// <param name="runType"> The type of run. </param>
        /// <param name="agentPoolName"> The dedicated agent pool for the run. </param>
        /// <param name="createdOn"> The time the run was scheduled. </param>
        /// <param name="startOn"> The time the run started. </param>
        /// <param name="finishOn"> The time the run finished. </param>
        /// <param name="outputImages"> The list of all images that were generated from the run. This is applicable if the run generates base image dependencies. </param>
        /// <param name="task"> The task against which run was scheduled. </param>
        /// <param name="imageUpdateTrigger"> The image update trigger that caused the run. This is applicable if the task has base image trigger configured. </param>
        /// <param name="sourceTrigger"> The source trigger that caused the run. </param>
        /// <param name="timerTrigger"> The timer trigger that caused the run. </param>
        /// <param name="platform"> The platform properties against which the run will happen. </param>
        /// <param name="agentCpu"> The machine configuration of the run agent. </param>
        /// <param name="sourceRegistryAuth"> The scope of the credentials that were used to login to the source registry during this run. </param>
        /// <param name="customRegistries"> The list of custom registries that were logged in during this run. </param>
        /// <param name="runErrorMessage"> The error message received from backend systems after the run is scheduled. </param>
        /// <param name="updateTriggerToken"> The update trigger token passed for the Run. </param>
        /// <param name="logArtifact"> The image description for the log artifact. </param>
        /// <param name="provisioningState"> The provisioning state of a run. </param>
        /// <param name="isArchiveEnabled"> The value that indicates whether archiving is enabled or not. </param>
        /// <returns> A new <see cref="ContainerRegistry.ContainerRegistryRunData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryRunData ContainerRegistryRunData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string runId = null, ContainerRegistryRunStatus? status = null, DateTimeOffset? lastUpdatedOn = null, ContainerRegistryRunType? runType = null, string agentPoolName = null, DateTimeOffset? createdOn = null, DateTimeOffset? startOn = null, DateTimeOffset? finishOn = null, IEnumerable<ContainerRegistryImageDescriptor> outputImages = null, string task = null, ContainerRegistryImageUpdateTrigger imageUpdateTrigger = null, ContainerRegistrySourceTriggerDescriptor sourceTrigger = null, ContainerRegistryTimerTriggerDescriptor timerTrigger = null, ContainerRegistryPlatformProperties platform = null, int? agentCpu = null, string sourceRegistryAuth = null, IEnumerable<string> customRegistries = null, string runErrorMessage = null, string updateTriggerToken = null, ContainerRegistryImageDescriptor logArtifact = null, ContainerRegistryProvisioningState? provisioningState = null, bool? isArchiveEnabled = null)
        {
            throw null;
            //return ArmContainerRegistryTasksModelFactory.ContainerRegistryRunData(id, name, resourceType, systemData, runId, status, lastUpdatedOn, runType, agentPoolName, createdOn, startOn, finishOn, outputImages, task, imageUpdateTrigger, sourceTrigger, timerTrigger, platform, agentCpu, sourceRegistryAuth, customRegistries, runErrorMessage, updateTriggerToken, logArtifact, provisioningState, isArchiveEnabled);
        }

        /// <summary> Initializes a new instance of <see cref="ContainerRegistry.ContainerRegistryTaskData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> Identity for the resource. </param>
        /// <param name="provisioningState"> The provisioning state of the task. </param>
        /// <param name="createdOn"> The creation date of task. </param>
        /// <param name="status"> The current status of task. </param>
        /// <param name="platform"> The platform properties against which the run has to happen. </param>
        /// <param name="agentCpu"> The machine configuration of the run agent. </param>
        /// <param name="agentPoolName"> The dedicated agent pool for the task. </param>
        /// <param name="timeoutInSeconds"> Run timeout in seconds. </param>
        /// <param name="step">
        /// The properties of a task step.
        /// Please note <see cref="Models.ContainerRegistryTaskStepProperties"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="Models.ContainerRegistryDockerBuildStep"/>, <see cref="Models.ContainerRegistryEncodedTaskStep"/> and <see cref="Models.ContainerRegistryFileTaskStep"/>.
        /// </param>
        /// <param name="trigger"> The properties that describe all triggers for the task. </param>
        /// <param name="credentials"> The properties that describes a set of credentials that will be used when this run is invoked. </param>
        /// <param name="logTemplate"> The template that describes the repository and tag information for run log artifact. </param>
        /// <param name="isSystemTask"> The value of this property indicates whether the task resource is system task or not. </param>
        /// <returns> A new <see cref="ContainerRegistry.ContainerRegistryTaskData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryTaskData ContainerRegistryTaskData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ManagedServiceIdentity identity = null, ContainerRegistryProvisioningState? provisioningState = null, DateTimeOffset? createdOn = null, ContainerRegistryTaskStatus? status = null, ContainerRegistryPlatformProperties platform = null, int? agentCpu = null, string agentPoolName = null, int? timeoutInSeconds = null, ContainerRegistryTaskStepProperties step = null, ContainerRegistryTriggerProperties trigger = null, ContainerRegistryCredentials credentials = null, string logTemplate = null, bool? isSystemTask = null)
        {
            throw null;
            //return ArmContainerRegistryTasksModelFactory.ContainerRegistryTaskData(id, name, resourceType, systemData, tags, location, identity, provisioningState, createdOn, status, platform, agentCpu, agentPoolName, timeoutInSeconds, step, trigger, credentials, logTemplate, isSystemTask);
        }

        /// <summary> Initializes a new instance of <see cref="ContainerRegistry.ContainerRegistryTaskRunData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="identity"> Identity for the resource. </param>
        /// <param name="location"> The location of the resource. </param>
        /// <param name="provisioningState"> The provisioning state of this task run. </param>
        /// <param name="runRequest">
        /// The request (parameters) for the run
        /// Please note <see cref="ContainerRegistryRunContent"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="ContainerRegistryDockerBuildContent"/>, <see cref="ContainerRegistryEncodedTaskRunContent"/>, <see cref="ContainerRegistryFileTaskRunContent"/> and <see cref="ContainerRegistryTaskRunContent"/>.
        /// </param>
        /// <param name="runResult"> The result of this task run. </param>
        /// <param name="forceUpdateTag"> How the run should be forced to rerun even if the run request configuration has not changed. </param>
        /// <returns> A new <see cref="ContainerRegistry.ContainerRegistryTaskRunData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryTaskRunData ContainerRegistryTaskRunData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ManagedServiceIdentity identity = null, AzureLocation? location = null, ContainerRegistryProvisioningState? provisioningState = null, ContainerRegistryRunContent runRequest = null, ContainerRegistryRunData runResult = null, string forceUpdateTag = null)
        {
            throw null;
            //return ArmContainerRegistryTasksModelFactory.ContainerRegistryTaskRunData(id, name, resourceType, systemData, identity, location, provisioningState, runRequest, runResult, forceUpdateTag);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerRegistryDockerBuildStep"/>. </summary>
        /// <param name="baseImageDependencies"> List of base image dependencies for a step. </param>
        /// <param name="contextPath"> The URL(absolute or relative) of the source context for the task step. </param>
        /// <param name="contextAccessToken"> The token (git PAT or SAS token of storage account blob) associated with the context for a step. </param>
        /// <param name="imageNames"> The fully qualified image names including the repository and tag. </param>
        /// <param name="isPushEnabled"> The value of this property indicates whether the image built should be pushed to the registry or not. </param>
        /// <param name="noCache"> The value of this property indicates whether the image cache is enabled or not. </param>
        /// <param name="dockerFilePath"> The Docker file path relative to the source context. </param>
        /// <param name="target"> The name of the target build stage for the docker build. </param>
        /// <param name="arguments"> The collection of override arguments to be used when executing this build step. </param>
        /// <returns> A new <see cref="Models.ContainerRegistryDockerBuildStep"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryDockerBuildStep ContainerRegistryDockerBuildStep(IEnumerable<ContainerRegistryBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null, IEnumerable<string> imageNames = null, bool? isPushEnabled = null, bool? noCache = null, string dockerFilePath = null, string target = null, IEnumerable<ContainerRegistryRunArgument> arguments = null)
        {
            throw null;
            //return ArmContainerRegistryTasksModelFactory.ContainerRegistryDockerBuildStep(baseImageDependencies, contextPath, contextAccessToken, imageNames, isPushEnabled, noCache, dockerFilePath, target, arguments);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerRegistryFileTaskStep"/>. </summary>
        /// <param name="baseImageDependencies"> List of base image dependencies for a step. </param>
        /// <param name="contextPath"> The URL(absolute or relative) of the source context for the task step. </param>
        /// <param name="contextAccessToken"> The token (git PAT or SAS token of storage account blob) associated with the context for a step. </param>
        /// <param name="taskFilePath"> The task template/definition file path relative to the source context. </param>
        /// <param name="valuesFilePath"> The task values/parameters file path relative to the source context. </param>
        /// <param name="values"> The collection of overridable values that can be passed when running a task. </param>
        /// <returns> A new <see cref="Models.ContainerRegistryFileTaskStep"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryFileTaskStep ContainerRegistryFileTaskStep(IEnumerable<ContainerRegistryBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null, string taskFilePath = null, string valuesFilePath = null, IEnumerable<ContainerRegistryTaskOverridableValue> values = null)
        {
            throw null;
            //return ArmContainerRegistryTasksModelFactory.ContainerRegistryFileTaskStep(baseImageDependencies, contextPath, contextAccessToken, taskFilePath, valuesFilePath, values);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerRegistryEncodedTaskStep"/>. </summary>
        /// <param name="baseImageDependencies"> List of base image dependencies for a step. </param>
        /// <param name="contextPath"> The URL(absolute or relative) of the source context for the task step. </param>
        /// <param name="contextAccessToken"> The token (git PAT or SAS token of storage account blob) associated with the context for a step. </param>
        /// <param name="encodedTaskContent"> Base64 encoded value of the template/definition file content. </param>
        /// <param name="encodedValuesContent"> Base64 encoded value of the parameters/values file content. </param>
        /// <param name="values"> The collection of overridable values that can be passed when running a task. </param>
        /// <returns> A new <see cref="Models.ContainerRegistryEncodedTaskStep"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryEncodedTaskStep ContainerRegistryEncodedTaskStep(IEnumerable<ContainerRegistryBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null, string encodedTaskContent = null, string encodedValuesContent = null, IEnumerable<ContainerRegistryTaskOverridableValue> values = null)
        {
            throw null;
            //return ArmContainerRegistryTasksModelFactory.ContainerRegistryEncodedTaskStep(baseImageDependencies, contextPath, contextAccessToken, encodedTaskContent, encodedValuesContent, values);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerRegistryAgentPoolQueueStatus"/>. </summary>
        /// <param name="count"> The number of pending runs in the queue. </param>
        /// <returns> A new <see cref="Models.ContainerRegistryAgentPoolQueueStatus"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryAgentPoolQueueStatus ContainerRegistryAgentPoolQueueStatus(int? count = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerRegistryBaseImageDependency"/>. </summary>
        /// <param name="type"> The type of the base image dependency. </param>
        /// <param name="registry"> The registry login server. </param>
        /// <param name="repository"> The repository name. </param>
        /// <param name="tag"> The tag name. </param>
        /// <param name="digest"> The sha256-based digest of the image manifest. </param>
        /// <returns> A new <see cref="Models.ContainerRegistryBaseImageDependency"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryBaseImageDependency ContainerRegistryBaseImageDependency(ContainerRegistryBaseImageDependencyType? type = null, string registry = null, string repository = null, string tag = null, string digest = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerRegistryBaseImageTriggerUpdateContent"/>. </summary>
        /// <param name="baseImageTriggerType"> The type of the auto trigger for base image dependency updates. </param>
        /// <param name="updateTriggerEndpoint"> The endpoint URL for receiving the trigger. </param>
        /// <param name="updateTriggerPayloadType"> Type of Payload body for Base image update triggers. </param>
        /// <param name="status"> The current status of trigger. </param>
        /// <param name="name"> The name of the trigger. </param>
        /// <returns> A new <see cref="Models.ContainerRegistryBaseImageTriggerUpdateContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryBaseImageTriggerUpdateContent ContainerRegistryBaseImageTriggerUpdateContent(ContainerRegistryBaseImageTriggerType? baseImageTriggerType = null, string updateTriggerEndpoint = null, ContainerRegistryUpdateTriggerPayloadType? updateTriggerPayloadType = null, ContainerRegistryTriggerStatus? status = null, string name = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerRegistryRunGetLogResult"/>. </summary>
        /// <param name="logLink"> The link to the run logs. </param>
        /// <param name="logArtifactLink"> The link to the run log artifact. </param>
        /// <returns> A new <see cref="Models.ContainerRegistryRunGetLogResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryRunGetLogResult ContainerRegistryRunGetLogResult(string logLink = null, string logArtifactLink = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerRegistrySourceTriggerUpdateContent"/>. </summary>
        /// <param name="sourceRepository"> The properties that describes the source(code) for the task. </param>
        /// <param name="sourceTriggerEvents"> The source event corresponding to the trigger. </param>
        /// <param name="status"> The current status of trigger. </param>
        /// <param name="name"> The name of the trigger. </param>
        /// <returns> A new <see cref="Models.ContainerRegistrySourceTriggerUpdateContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistrySourceTriggerUpdateContent ContainerRegistrySourceTriggerUpdateContent(SourceCodeRepoUpdateContent sourceRepository = null, IEnumerable<ContainerRegistrySourceTriggerEvent> sourceTriggerEvents = null, ContainerRegistryTriggerStatus? status = null, string name = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerRegistryTaskStepProperties"/>. </summary>
        /// <param name="type"> The type of the step. </param>
        /// <param name="baseImageDependencies"> List of base image dependencies for a step. </param>
        /// <param name="contextPath"> The URL(absolute or relative) of the source context for the task step. </param>
        /// <param name="contextAccessToken"> The token (git PAT or SAS token of storage account blob) associated with the context for a step. </param>
        /// <returns> A new <see cref="Models.ContainerRegistryTaskStepProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryTaskStepProperties ContainerRegistryTaskStepProperties(string type = null, IEnumerable<ContainerRegistryBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerRegistryTimerTriggerUpdateContent"/>. </summary>
        /// <param name="schedule"> The CRON expression for the task schedule. </param>
        /// <param name="status"> The current status of trigger. </param>
        /// <param name="name"> The name of the trigger. </param>
        /// <returns> A new <see cref="Models.ContainerRegistryTimerTriggerUpdateContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryTimerTriggerUpdateContent ContainerRegistryTimerTriggerUpdateContent(string schedule = null, ContainerRegistryTriggerStatus? status = null, string name = null)
        {
            throw null;
        }

        /// <summary> Initializes a new instance of <see cref="Models.SourceUploadDefinition"/>. </summary>
        /// <param name="uploadUri"> The URL where the client can upload the source. </param>
        /// <param name="relativePath"> The relative path to the source. This is used to submit the subsequent queue build request. </param>
        /// <returns> A new <see cref="Models.SourceUploadDefinition"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SourceUploadDefinition SourceUploadDefinition(Uri uploadUri = null, string relativePath = null)
        {
            throw null;
        }
    }
}
