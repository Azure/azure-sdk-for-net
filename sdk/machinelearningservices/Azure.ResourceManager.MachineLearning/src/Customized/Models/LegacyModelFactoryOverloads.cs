// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore legacy model factory overloads whose return/parameter types were normalized by TypeSpec generation.
    [CodeGenSuppress("MachineLearningPrivateEndpointConnectionData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(WorkspacePrivateEndpointResource), typeof(MachineLearningPrivateLinkServiceConnectionState), typeof(MachineLearningPrivateEndpointConnectionProvisioningState?), typeof(ManagedServiceIdentity), typeof(MachineLearningSku))]
    public static partial class ArmMachineLearningModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningError"/>. </summary>
        public static MachineLearningError MachineLearningError(ResponseError error = default)
        {
            return new MachineLearningError(error);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningFqdnEndpointsProperties"/>. </summary>
        public static MachineLearningFqdnEndpointsProperties MachineLearningFqdnEndpointsProperties(string category = default, IEnumerable<MachineLearningFqdnEndpoint> endpoints = default)
        {
            return new MachineLearningFqdnEndpointsProperties(MachineLearningFqdnEndpoints(category, endpoints));
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningContainerRegistryCredentials"/>. </summary>
        public static MachineLearningContainerRegistryCredentials MachineLearningContainerRegistryCredentials(AzureLocation? location = default, string username = default, IEnumerable<MachineLearningPasswordDetail> passwords = default)
        {
            return new MachineLearningContainerRegistryCredentials(location, username, passwords);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningComputeStartStopSchedule"/>. </summary>
        public static MachineLearningComputeStartStopSchedule MachineLearningComputeStartStopSchedule(string id = default, MachineLearningComputeProvisioningStatus? provisioningStatus = default, MachineLearningScheduleStatus? status = default, MachineLearningComputePowerAction? action = default, MachineLearningTriggerType? triggerType = default, ComputeStartStopRecurrenceSchedule recurrenceSchedule = default, ComputeStartStopCronSchedule cronSchedule = default, MachineLearningScheduleBase schedule = default)
        {
            return new MachineLearningComputeStartStopSchedule(
                id,
                provisioningStatus,
                status,
                action,
                triggerType.HasValue ? new ComputeTriggerType(triggerType.Value.ToString()) : null,
                recurrenceSchedule,
                cronSchedule,
                schedule,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningComputeProperties"/>. </summary>
        public static MachineLearningComputeProperties MachineLearningComputeProperties(string computeType = default, string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default)
        {
            return MachineLearningComputeProperties(computeType, computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors, isAttachedCompute, disableLocalAuth);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningAksCompute"/>. </summary>
        public static MachineLearningAksCompute MachineLearningAksCompute(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default, MachineLearningAksComputeProperties properties = default)
        {
            return MachineLearningAksCompute(computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors, isAttachedCompute, disableLocalAuth, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningKubernetesCompute"/>. </summary>
        public static MachineLearningKubernetesCompute MachineLearningKubernetesCompute(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default, MachineLearningKubernetesProperties properties = default)
        {
            return MachineLearningKubernetesCompute(computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors, isAttachedCompute, disableLocalAuth, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AmlCompute"/>. </summary>
        public static AmlCompute AmlCompute(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default, AmlComputeProperties properties = default)
        {
            return AmlCompute(computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors, isAttachedCompute, disableLocalAuth, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AmlComputeProperties"/>. </summary>
        public static AmlComputeProperties AmlComputeProperties(MachineLearningOSType? osType = default, string vmSize = default, MachineLearningVmPriority? vmPriority = default, string virtualMachineImageId = default, bool? isolatedNetwork = default, AmlComputeScaleSettings scaleSettings = default, MachineLearningUserAccountCredentials userAccountCredentials = default, ResourceIdentifier subnetId = default, MachineLearningRemoteLoginPortPublicAccess? remoteLoginPortPublicAccess = default, MachineLearningAllocationState? allocationState = default, DateTimeOffset? allocationStateTransitionOn = default, IEnumerable<MachineLearningError> errors = default, int? currentNodeCount = default, int? targetNodeCount = default, MachineLearningNodeStateCounts nodeStateCounts = default, bool? enableNodePublicIP = default, BinaryData propertyBag = default)
        {
            return AmlComputeProperties(osType, vmSize, vmPriority, virtualMachineImageId, isolatedNetwork, scaleSettings, userAccountCredentials, subnetId, remoteLoginPortPublicAccess, allocationState, allocationStateTransitionOn, errors, currentNodeCount, targetNodeCount, nodeStateCounts, enableNodePublicIP, propertyBag);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningComputeInstance"/>. </summary>
        public static MachineLearningComputeInstance MachineLearningComputeInstance(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default, MachineLearningComputeInstanceProperties properties = default)
        {
            return MachineLearningComputeInstance(computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors, isAttachedCompute, disableLocalAuth, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningVirtualMachineCompute"/>. </summary>
        public static MachineLearningVirtualMachineCompute MachineLearningVirtualMachineCompute(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default, MachineLearningVirtualMachineProperties properties = default)
        {
            return MachineLearningVirtualMachineCompute(computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors, isAttachedCompute, disableLocalAuth, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningHDInsightCompute"/>. </summary>
        public static MachineLearningHDInsightCompute MachineLearningHDInsightCompute(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default, MachineLearningHDInsightProperties properties = default)
        {
            return MachineLearningHDInsightCompute(computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors, isAttachedCompute, disableLocalAuth, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningDataFactoryCompute"/>. </summary>
        public static MachineLearningDataFactoryCompute MachineLearningDataFactoryCompute(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default)
        {
            return MachineLearningDataFactoryCompute(computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors, isAttachedCompute, disableLocalAuth);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningDatabricksCompute"/>. </summary>
        public static MachineLearningDatabricksCompute MachineLearningDatabricksCompute(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default, MachineLearningDatabricksProperties properties = default)
        {
            return MachineLearningDatabricksCompute(computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors, isAttachedCompute, disableLocalAuth, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningDataLakeAnalytics"/>. </summary>
        public static MachineLearningDataLakeAnalytics MachineLearningDataLakeAnalytics(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default, string dataLakeStoreAccountName = default)
        {
            return MachineLearningDataLakeAnalytics(computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors, isAttachedCompute, disableLocalAuth, dataLakeStoreAccountName);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningSynapseSpark"/>. </summary>
        public static MachineLearningSynapseSpark MachineLearningSynapseSpark(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default, MachineLearningSynapseSparkProperties properties = default)
        {
            return MachineLearningSynapseSpark(computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors, isAttachedCompute, disableLocalAuth, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.RegistryPrivateEndpoint"/>. </summary>
        public static RegistryPrivateEndpoint RegistryPrivateEndpoint(ResourceIdentifier id = default, ResourceIdentifier subnetArmId = default)
        {
            return new RegistryPrivateEndpoint(id)
            {
                SubnetArmId = subnetArmId
            };
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningWorkspaceConnectionProperties"/>. </summary>
        public static MachineLearningWorkspaceConnectionProperties MachineLearningWorkspaceConnectionProperties(string authType = default, MachineLearningConnectionCategory? category = default, ResourceIdentifier createdByWorkspaceArmId = default, DateTimeOffset? expiryOn = default, WorkspaceConnectionGroup? @group = default, bool? isSharedToAll = default, string target = default, IDictionary<string, string> metadata = default, IEnumerable<string> sharedUserList = default, string value = default, MachineLearningValueFormat? valueFormat = default)
        {
            MachineLearningWorkspaceConnectionProperties result = MachineLearningWorkspaceConnectionProperties(authType, category, createdByWorkspaceArmId, error: default, expiryOn, @group, isSharedToAll, metadata, peRequirement: default, peStatus: default, sharedUserList, target, useWorkspaceManagedIdentity: default);
            result.Value = value;
            result.ValueFormat = valueFormat;
            return result;
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearning.MachineLearningPrivateEndpointConnectionData"/>. </summary>
        public static MachineLearningPrivateEndpointConnectionData MachineLearningPrivateEndpointConnectionData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, MachineLearningPrivateEndpoint privateEndpoint = default, MachineLearningPrivateLinkServiceConnectionState privateLinkServiceConnectionState = default, MachineLearningPrivateEndpointConnectionProvisioningState? provisioningState = default, ManagedServiceIdentity identity = default, MachineLearningSku sku = default, string location = default, IDictionary<string, string> tags = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();
            return new MachineLearningPrivateEndpointConnectionData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location is null ? default : new AzureLocation(location),
                privateEndpoint is null && privateLinkServiceConnectionState is null && provisioningState is null
                    ? default
                    : new PrivateEndpointConnectionProperties(
                        privateEndpoint is null ? default : new WorkspacePrivateEndpointResource(privateEndpoint.Id?.ToString(), privateEndpoint.SubnetArmId?.ToString(), additionalBinaryDataProperties: null),
                        privateLinkServiceConnectionState,
                        provisioningState,
                        additionalBinaryDataProperties: null),
                identity,
                sku,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningSweepJob"/>. </summary>
        public static MachineLearningSweepJob MachineLearningSweepJob(string description = default, IDictionary<string, string> properties = default, IDictionary<string, string> tags = default, string displayName = default, MachineLearningJobStatus? status = default, string experimentName = default, IDictionary<string, MachineLearningJobService> services = default, ResourceIdentifier computeId = default, bool? isArchived = default, MachineLearningIdentityConfiguration identity = default, ResourceIdentifier componentId = default, NotificationSetting notificationSetting = default, BinaryData searchSpace = default, SamplingAlgorithm samplingAlgorithm = default, MachineLearningSweepJobLimits limits = default, MachineLearningEarlyTerminationPolicy earlyTermination = default, MachineLearningObjective objective = default, MachineLearningTrialComponent trial = default, IDictionary<string, MachineLearningJobInput> inputs = default, IDictionary<string, MachineLearningJobOutput> outputs = default, JobTier? jobTier = default)
        {
            return new MachineLearningSweepJob(description, properties, tags, componentId, computeId, displayName, experimentName, identity, isArchived, notificationSetting, services, status, earlyTermination, inputs, limits, objective, outputs, new QueueSettings(jobTier, additionalBinaryDataProperties: null), samplingAlgorithm, searchSpace, trial);
        }
    }
}
