// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.StorageMover;

namespace Azure.ResourceManager.StorageMover.Models
{
    /// <summary> A factory class for creating instances of the models for mocking. </summary>
    public static partial class ArmStorageMoverModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="StorageMover.JobDefinitionData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static JobDefinitionData JobDefinitionData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string description = default, JobType? jobType = default, StorageMoverCopyMode? copyMode = default, string sourceName = default, ResourceIdentifier sourceResourceId = default, string sourceSubpath = default, string targetName = default, ResourceIdentifier targetResourceId = default, string targetSubpath = default, string latestJobRunName = default, ResourceIdentifier latestJobRunResourceId = default, JobRunStatus? latestJobRunStatus = default, string agentName = default, ResourceIdentifier agentResourceId = default, StorageMoverProvisioningState? provisioningState = default, IEnumerable<ResourceIdentifier> connections = default, StorageMoverScheduleInfo schedule = default, StorageMoverDataIntegrityValidation? dataIntegrityValidation = default, bool? isPermissionsPreserved = default, IEnumerable<SourceTargetMap> sourceTargetMapValue = default)
            => JobDefinitionData(id, name, resourceType, systemData, description, jobType, copyMode.GetValueOrDefault(), sourceName, sourceResourceId, sourceSubpath, targetName, targetResourceId, targetSubpath, latestJobRunName, latestJobRunResourceId, latestJobRunStatus, agentName, agentResourceId, provisioningState, connections, schedule, dataIntegrityValidation, isPermissionsPreserved, sourceTargetMapValue);

        /// <summary>
        /// The resource specific properties for the Storage Mover resource.
        /// </summary>
        /// <param name="endpointType"> The Endpoint resource type. </param>
        /// <param name="description"> A description for the Endpoint. </param>
        /// <param name="provisioningState"> The provisioning state of this resource. </param>
        /// <returns> A new <see cref="Models.EndpointBaseProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EndpointBaseProperties EndpointBaseProperties(string endpointType, string description, StorageMoverProvisioningState? provisioningState)
            => EndpointBaseProperties(endpointType, description, null, provisioningState);

        /// <summary> Initializes a new instance of <see cref="StorageMover.StorageMoverAgentData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageMoverAgentData StorageMoverAgentData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string description = default, string agentVersion = default, string arcResourceId = default, string arcVmUuid = default, StorageMoverAgentStatus? agentStatus = default, DateTimeOffset? lastStatusUpdate = default, string localIPAddress = default, long? memoryInMB = default, long? numberOfCores = default, long? uptimeInSeconds = default, string timeZone = default, StorageMoverAgentPropertiesErrorDetails errorDetails = default, StorageMoverProvisioningState? provisioningState = default, IEnumerable<UploadLimitWeeklyRecurrence> uploadLimitScheduleWeeklyRecurrences = default)
        {
            uploadLimitScheduleWeeklyRecurrences ??= new ChangeTrackingList<UploadLimitWeeklyRecurrence>();

            return new StorageMoverAgentData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                new AgentProperties(
                    description,
                    agentVersion,
                    arcResourceId,
                    arcVmUuid,
                    agentStatus,
                    lastStatusUpdate,
                    localIPAddress,
                    memoryInMB,
                    numberOfCores,
                    uptimeInSeconds,
                    timeZone,
                    new UploadLimitSchedule(uploadLimitScheduleWeeklyRecurrences.ToList(), additionalBinaryDataProperties: null),
                    errorDetails,
                    provisioningState,
                    additionalBinaryDataProperties: null));
        }

        /// <summary> Initializes a new instance of <see cref="StorageMover.StorageMoverAgentData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageMoverAgentData StorageMoverAgentData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string description, string agentVersion, string arcResourceId, string arcVmUuid, StorageMoverAgentStatus? agentStatus, DateTimeOffset? lastStatusUpdate, string localIPAddress, long? memoryInMB, long? numberOfCores, long? uptimeInSeconds, string timeZone, IEnumerable<UploadLimitWeeklyRecurrence> uploadLimitScheduleWeeklyRecurrences, StorageMoverAgentPropertiesErrorDetails errorDetails = default, StorageMoverProvisioningState? provisioningState = default)
            => StorageMoverAgentData(id, name, resourceType, systemData, description, agentVersion, arcResourceId, arcVmUuid, agentStatus, lastStatusUpdate, localIPAddress, memoryInMB, numberOfCores, uptimeInSeconds, timeZone, errorDetails, provisioningState, uploadLimitScheduleWeeklyRecurrences);
    }
}
