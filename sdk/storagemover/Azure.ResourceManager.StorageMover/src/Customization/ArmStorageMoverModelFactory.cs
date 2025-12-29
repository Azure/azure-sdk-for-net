// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.StorageMover;

namespace Azure.ResourceManager.StorageMover.Models
{
    /// <summary> A factory class for creating instances of the models for mocking. </summary>
    public static partial class ArmStorageMoverModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.StorageMover.JobDefinitionData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="description"> A description for the Job Definition. </param>
        /// <param name="copyMode"> Strategy to use for copy. </param>
        /// <param name="sourceName"> The name of the source Endpoint. </param>
        /// <param name="sourceResourceId"> Fully qualified resource ID of the source Endpoint. </param>
        /// <param name="sourceSubpath"> The subpath to use when reading from the source Endpoint. </param>
        /// <param name="targetName"> The name of the target Endpoint. </param>
        /// <param name="targetResourceId"> Fully qualified resource ID of the target Endpoint. </param>
        /// <param name="targetSubpath"> The subpath to use when writing to the target Endpoint. </param>
        /// <param name="latestJobRunName"> The name of the Job Run in a non-terminal state, if exists. </param>
        /// <param name="latestJobRunResourceId"> The fully qualified resource ID of the Job Run in a non-terminal state, if exists. </param>
        /// <param name="latestJobRunStatus"> The current status of the Job Run in a non-terminal state, if exists. </param>
        /// <param name="agentName"> Name of the Agent to assign for new Job Runs of this Job Definition. </param>
        /// <param name="agentResourceId"> Fully qualified resource id of the Agent to assign for new Job Runs of this Job Definition. </param>
        /// <param name="provisioningState"> The provisioning state of this resource. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.StorageMover.JobDefinitionData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static JobDefinitionData JobDefinitionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string description, StorageMoverCopyMode copyMode, string sourceName, ResourceIdentifier sourceResourceId, string sourceSubpath, string targetName, ResourceIdentifier targetResourceId, string targetSubpath, string latestJobRunName, ResourceIdentifier latestJobRunResourceId, JobRunStatus? latestJobRunStatus, string agentName, ResourceIdentifier agentResourceId, StorageMoverProvisioningState? provisioningState)
            => JobDefinitionData(id, name, resourceType, systemData, description, null, copyMode, sourceName, sourceResourceId, sourceSubpath, targetName, targetResourceId, targetSubpath, latestJobRunName, latestJobRunResourceId, latestJobRunStatus, agentName, agentResourceId, provisioningState, null, null, null);

        /// <summary> Initializes a new instance of <see cref="StorageMover.JobDefinitionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="description"> A description for the Job Definition. OnPremToCloud is for migrating data from on-premises to cloud. CloudToCloud is for migrating data between cloud to cloud. </param>
        /// <param name="jobType"> The type of the Job. </param>
        /// <param name="copyMode"> Strategy to use for copy. </param>
        /// <param name="sourceName"> The name of the source Endpoint. </param>
        /// <param name="sourceResourceId"> Fully qualified resource ID of the source Endpoint. </param>
        /// <param name="sourceSubpath"> The subpath to use when reading from the source Endpoint. </param>
        /// <param name="targetName"> The name of the target Endpoint. </param>
        /// <param name="targetResourceId"> Fully qualified resource ID of the target Endpoint. </param>
        /// <param name="targetSubpath"> The subpath to use when writing to the target Endpoint. </param>
        /// <param name="latestJobRunName"> The name of the Job Run in a non-terminal state, if exists. </param>
        /// <param name="latestJobRunResourceId"> The fully qualified resource ID of the Job Run in a non-terminal state, if exists. </param>
        /// <param name="latestJobRunStatus"> The current status of the Job Run in a non-terminal state, if exists. </param>
        /// <param name="agentName"> Name of the Agent to assign for new Job Runs of this Job Definition. </param>
        /// <param name="agentResourceId"> Fully qualified resource id of the Agent to assign for new Job Runs of this Job Definition. </param>
        /// <param name="sourceTargetMapValue"> The list of cloud endpoints to migrate. </param>
        /// <param name="provisioningState"> The provisioning state of this resource. </param>
        /// <returns> A new <see cref="StorageMover.JobDefinitionData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static JobDefinitionData JobDefinitionData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string description, JobType? jobType, StorageMoverCopyMode copyMode, string sourceName, ResourceIdentifier sourceResourceId, string sourceSubpath, string targetName, ResourceIdentifier targetResourceId, string targetSubpath, string latestJobRunName, ResourceIdentifier latestJobRunResourceId, JobRunStatus? latestJobRunStatus, string agentName, ResourceIdentifier agentResourceId, IEnumerable<SourceTargetMap> sourceTargetMapValue, StorageMoverProvisioningState? provisioningState)
            => JobDefinitionData(id, name, resourceType, systemData, description, jobType, copyMode, sourceName, sourceResourceId, sourceSubpath, targetName, targetResourceId, targetSubpath, latestJobRunName, latestJobRunResourceId, latestJobRunStatus, agentName, agentResourceId,  provisioningState, null, null, sourceTargetMapValue);

        /// <summary> Initializes a new instance of <see cref="StorageMover.JobRunData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="status"> The state of the job execution. </param>
        /// <param name="scanStatus"> The status of Agent's scanning of source. </param>
        /// <param name="agentName"> Name of the Agent assigned to this run. </param>
        /// <param name="agentResourceId"> Fully qualified resource id of the Agent assigned to this run. </param>
        /// <param name="executionStartOn"> Start time of the run. Null if no Agent reported that the job has started. </param>
        /// <param name="executionEndOn"> End time of the run. Null if Agent has not reported that the job has ended. </param>
        /// <param name="lastStatusUpdate"> The last updated time of the Job Run. </param>
        /// <param name="itemsScanned"> Number of items scanned so far in source. </param>
        /// <param name="itemsExcluded"> Number of items that will not be transferred, as they are excluded by user configuration. </param>
        /// <param name="itemsUnsupported"> Number of items that will not be transferred, as they are unsupported on target. </param>
        /// <param name="itemsNoTransferNeeded"> Number of items that will not be transferred, as they are already found on target (e.g. mirror mode). </param>
        /// <param name="itemsFailed"> Number of items that were attempted to transfer and failed. </param>
        /// <param name="itemsTransferred"> Number of items successfully transferred to target. </param>
        /// <param name="bytesScanned"> Bytes of data scanned so far in source. </param>
        /// <param name="bytesExcluded"> Bytes of data that will not be transferred, as they are excluded by user configuration. </param>
        /// <param name="bytesUnsupported"> Bytes of data that will not be transferred, as they are unsupported on target. </param>
        /// <param name="bytesNoTransferNeeded"> Bytes of data that will not be transferred, as they are already found on target (e.g. mirror mode). </param>
        /// <param name="bytesFailed"> Bytes of data that were attempted to transfer and failed. </param>
        /// <param name="bytesTransferred"> Bytes of data successfully transferred to target. </param>
        /// <param name="sourceName"> Name of source Endpoint resource. This resource may no longer exist. </param>
        /// <param name="sourceResourceId"> Fully qualified resource id of source Endpoint. This id may no longer exist. </param>
        /// <param name="sourceProperties"> Copy of source Endpoint resource's properties at time of Job Run creation. </param>
        /// <param name="targetName"> Name of target Endpoint resource. This resource may no longer exist. </param>
        /// <param name="targetResourceId"> Fully qualified resource id of of Endpoint. This id may no longer exist. </param>
        /// <param name="targetProperties"> Copy of Endpoint resource's properties at time of Job Run creation. </param>
        /// <param name="jobDefinitionProperties"> Copy of parent Job Definition's properties at time of Job Run creation. </param>
        /// <param name="error"> Error details. </param>
        /// <param name="provisioningState"> The provisioning state of this resource. </param>
        /// <returns> A new <see cref="StorageMover.JobRunData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static JobRunData JobRunData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, JobRunStatus? status, JobRunScanStatus? scanStatus, string agentName, ResourceIdentifier agentResourceId, DateTimeOffset? executionStartOn, DateTimeOffset? executionEndOn, DateTimeOffset? lastStatusUpdate, long? itemsScanned, long? itemsExcluded, long? itemsUnsupported, long? itemsNoTransferNeeded, long? itemsFailed, long? itemsTransferred, long? bytesScanned, long? bytesExcluded, long? bytesUnsupported, long? bytesNoTransferNeeded, long? bytesFailed, long? bytesTransferred, string sourceName, ResourceIdentifier sourceResourceId, BinaryData sourceProperties, string targetName, ResourceIdentifier targetResourceId, BinaryData targetProperties, BinaryData jobDefinitionProperties, JobRunError error, StorageMoverProvisioningState? provisioningState)
            => JobRunData(id, name, resourceType, systemData, status, scanStatus, agentName, agentResourceId, executionStartOn, executionEndOn, lastStatusUpdate, itemsScanned, itemsExcluded, itemsUnsupported, itemsNoTransferNeeded, itemsFailed, itemsTransferred, bytesScanned, bytesExcluded, bytesUnsupported, bytesNoTransferNeeded, bytesFailed, bytesTransferred, sourceName, sourceResourceId, sourceProperties, targetName, targetResourceId, targetProperties, jobDefinitionProperties, error, null, provisioningState);

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.StorageMover.StorageMoverAgentData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="description"> A description for the Agent. </param>
        /// <param name="agentVersion"> The Agent version. </param>
        /// <param name="arcResourceId"> The fully qualified resource ID of the Hybrid Compute resource for the Agent. </param>
        /// <param name="arcVmUuid"> The VM UUID of the Hybrid Compute resource for the Agent. </param>
        /// <param name="agentStatus"> The Agent status. </param>
        /// <param name="lastStatusUpdate"> The last updated time of the Agent status. </param>
        /// <param name="localIPAddress"> Local IP address reported by the Agent. </param>
        /// <param name="memoryInMB"> Available memory reported by the Agent, in MB. </param>
        /// <param name="numberOfCores"> Available compute cores reported by the Agent. </param>
        /// <param name="uptimeInSeconds"> Uptime of the Agent in seconds. </param>
        /// <param name="errorDetails"></param>
        /// <param name="provisioningState"> The provisioning state of this resource. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.StorageMover.StorageMoverAgentData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageMoverAgentData StorageMoverAgentData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string description, string agentVersion, string arcResourceId, string arcVmUuid, StorageMoverAgentStatus? agentStatus, DateTimeOffset? lastStatusUpdate, string localIPAddress, long? memoryInMB, long? numberOfCores, long? uptimeInSeconds, StorageMoverAgentPropertiesErrorDetails errorDetails, StorageMoverProvisioningState? provisioningState)
            => StorageMoverAgentData(id, name, resourceType, systemData, description, agentVersion, arcResourceId, arcVmUuid, agentStatus, lastStatusUpdate, localIPAddress, memoryInMB, numberOfCores, uptimeInSeconds, null, errorDetails, provisioningState);

        /// <summary> Initializes a new instance of <see cref="StorageMover.StorageMoverAgentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="description"> A description for the Agent. </param>
        /// <param name="agentVersion"> The Agent version. </param>
        /// <param name="arcResourceId"> The fully qualified resource ID of the Hybrid Compute resource for the Agent. </param>
        /// <param name="arcVmUuid"> The VM UUID of the Hybrid Compute resource for the Agent. </param>
        /// <param name="agentStatus"> The Agent status. </param>
        /// <param name="lastStatusUpdate"> The last updated time of the Agent status. </param>
        /// <param name="localIPAddress"> Local IP address reported by the Agent. </param>
        /// <param name="memoryInMB"> Available memory reported by the Agent, in MB. </param>
        /// <param name="numberOfCores"> Available compute cores reported by the Agent. </param>
        /// <param name="uptimeInSeconds"> Uptime of the Agent in seconds. </param>
        /// <param name="timeZone"> The agent's local time zone represented in Windows format. </param>
        /// <param name="uploadLimitScheduleWeeklyRecurrences"> The WAN-link upload limit schedule that applies to any Job Run the agent executes. Data plane operations (migrating files) are affected. Control plane operations ensure seamless migration functionality and are not limited by this schedule. The schedule is interpreted with the agent's local time. </param>
        /// <param name="errorDetails"></param>
        /// <param name="provisioningState"> The provisioning state of this resource. </param>
        /// <returns> A new <see cref="StorageMover.StorageMoverAgentData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageMoverAgentData StorageMoverAgentData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string description, string agentVersion, string arcResourceId, string arcVmUuid, StorageMoverAgentStatus? agentStatus, DateTimeOffset? lastStatusUpdate, string localIPAddress, long? memoryInMB, long? numberOfCores, long? uptimeInSeconds, string timeZone, IEnumerable<UploadLimitWeeklyRecurrence> uploadLimitScheduleWeeklyRecurrences, StorageMoverAgentPropertiesErrorDetails errorDetails = null, StorageMoverProvisioningState? provisioningState = null)
            => StorageMoverAgentData(id, name, resourceType, systemData, description, agentVersion, arcResourceId, arcVmUuid, agentStatus, lastStatusUpdate, localIPAddress, memoryInMB, numberOfCores, uptimeInSeconds, timeZone, errorDetails, provisioningState, uploadLimitScheduleWeeklyRecurrences);

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.StorageMover.StorageMoverEndpointData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties">
        /// The resource specific properties for the Storage Mover resource.
        /// Please note <see cref="T:Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties" /> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="T:Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointProperties" />, <see cref="T:Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointProperties" />, <see cref="T:Azure.ResourceManager.StorageMover.Models.NfsMountEndpointProperties" /> and <see cref="T:Azure.ResourceManager.StorageMover.Models.SmbMountEndpointProperties" />.
        /// </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.StorageMover.StorageMoverEndpointData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageMoverEndpointData StorageMoverEndpointData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, EndpointBaseProperties properties)
            => StorageMoverEndpointData(id, name, resourceType, systemData, properties, null);
    }
}
