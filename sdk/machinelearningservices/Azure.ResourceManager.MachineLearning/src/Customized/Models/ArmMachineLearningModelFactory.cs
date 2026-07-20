// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    [CodeGenSuppress("MachineLearningError", typeof(ResponseError))]
    [CodeGenSuppress("MachineLearningPrivateEndpointConnectionData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(WorkspacePrivateEndpointResource), typeof(MachineLearningPrivateLinkServiceConnectionState), typeof(MachineLearningPrivateEndpointConnectionProvisioningState?), typeof(ManagedServiceIdentity), typeof(MachineLearningSku))]
    [CodeGenSuppress("MachineLearningWorkspaceData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(Uri), typeof(bool?), typeof(bool?), typeof(string), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(string), typeof(string), typeof(Uri), typeof(bool?), typeof(bool?), typeof(bool?), typeof(bool?), typeof(EncryptionProperty), typeof(IEnumerable<string>), typeof(FeatureStoreSettings), typeof(string), typeof(bool?), typeof(ResourceIdentifier), typeof(string), typeof(IEnumerable<string>), typeof(string), typeof(IEnumerable<string>), typeof(ManagedNetworkSettings), typeof(Uri), typeof(NetworkAcls), typeof(MachineLearningNotebookResourceInfo), typeof(string), typeof(IEnumerable<MachineLearningPrivateEndpointConnectionData>), typeof(int?), typeof(bool?), typeof(MachineLearningProvisioningState?), typeof(PublicNetworkAccess?), typeof(ServerlessComputeSettings), typeof(string), typeof(IEnumerable<MachineLearningSharedPrivateLinkResource>), typeof(int?), typeof(string), typeof(IEnumerable<string>), typeof(bool?), typeof(SystemDatastoresAuthMode?), typeof(Guid?), typeof(bool?), typeof(WorkspaceHubConfig), typeof(string), typeof(int?), typeof(ManagedServiceIdentity), typeof(string), typeof(MachineLearningSku))]
    [CodeGenSuppress("MachineLearningWorkspaceGetKeysResult", typeof(string), typeof(RegistryListCredentialsResult), typeof(MachineLearningWorkspaceGetNotebookKeysResult), typeof(string), typeof(string))]
    public static partial class ArmMachineLearningModelFactory
    {
        // These overloads are part of the shipped GA model factory surface. The new TypeSpec shapes can be renamed with decorators when a
        // matching generated target exists, but several overloads depend on custom-only compatibility models or old parameter order/type
        // combinations. Keep only those SDK-side shims and delegate to generated constructors/factories whenever possible.
        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningError"/>. </summary>
        public static MachineLearningError MachineLearningError(ResponseError error = default)
        {
            return new MachineLearningError(error, additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningFqdnEndpointsProperties"/>. </summary>
        public static MachineLearningFqdnEndpointsProperties MachineLearningFqdnEndpointsProperties(string category = default, IEnumerable<MachineLearningFqdnEndpoint> endpoints = default)
        {
            return new MachineLearningFqdnEndpointsProperties(category, endpoints);
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
                triggerType,
                recurrenceSchedule,
                cronSchedule,
                schedule,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningComputeProperties"/>. </summary>
        public static MachineLearningComputeProperties MachineLearningComputeProperties(string computeType = default, string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default)
        {
            return new UnknownCompute(computeType, computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors is null ? null : new List<MachineLearningError>(provisioningErrors), isAttachedCompute, disableLocalAuth, additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningAksCompute"/>. </summary>
        public static MachineLearningAksCompute MachineLearningAksCompute(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default, MachineLearningAksComputeProperties properties = default)
        {
            return new MachineLearningAksCompute(ComputeType.AKS, computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors is null ? null : new List<MachineLearningError>(provisioningErrors), isAttachedCompute, disableLocalAuth, additionalBinaryDataProperties: null, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningKubernetesCompute"/>. </summary>
        public static MachineLearningKubernetesCompute MachineLearningKubernetesCompute(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default, MachineLearningKubernetesProperties properties = default)
        {
            return new MachineLearningKubernetesCompute(ComputeType.Kubernetes, computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors is null ? null : new List<MachineLearningError>(provisioningErrors), isAttachedCompute, disableLocalAuth, additionalBinaryDataProperties: null, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AmlCompute"/>. </summary>
        public static AmlCompute AmlCompute(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default, AmlComputeProperties properties = default)
        {
            return new AmlCompute(ComputeType.AmlCompute, computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors is null ? null : new List<MachineLearningError>(provisioningErrors), isAttachedCompute, disableLocalAuth, additionalBinaryDataProperties: null, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AmlComputeProperties"/>. </summary>
        public static AmlComputeProperties AmlComputeProperties(MachineLearningOSType? osType = default, string vmSize = default, MachineLearningVmPriority? vmPriority = default, string virtualMachineImageId = default, bool? isolatedNetwork = default, AmlComputeScaleSettings scaleSettings = default, MachineLearningUserAccountCredentials userAccountCredentials = default, ResourceIdentifier subnetId = default, MachineLearningRemoteLoginPortPublicAccess? remoteLoginPortPublicAccess = default, MachineLearningAllocationState? allocationState = default, DateTimeOffset? allocationStateTransitionOn = default, IEnumerable<MachineLearningError> errors = default, int? currentNodeCount = default, int? targetNodeCount = default, MachineLearningNodeStateCounts nodeStateCounts = default, bool? enableNodePublicIP = default, BinaryData propertyBag = default)
        {
            return new AmlComputeProperties(osType, vmSize, vmPriority, virtualMachineImageId is null ? null : new VirtualMachineImage(virtualMachineImageId, additionalBinaryDataProperties: null), isolatedNetwork, scaleSettings, userAccountCredentials, subnetId is null ? null : new ResourceId(subnetId, additionalBinaryDataProperties: null), remoteLoginPortPublicAccess, allocationState, allocationStateTransitionOn, errors is null ? null : new List<MachineLearningError>(errors), currentNodeCount, targetNodeCount, nodeStateCounts, enableNodePublicIP, propertyBag, additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningComputeInstance"/>. </summary>
        public static MachineLearningComputeInstance MachineLearningComputeInstance(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default, MachineLearningComputeInstanceProperties properties = default)
        {
            return new MachineLearningComputeInstance(ComputeType.ComputeInstance, computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors is null ? null : new List<MachineLearningError>(provisioningErrors), isAttachedCompute, disableLocalAuth, additionalBinaryDataProperties: null, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningVirtualMachineCompute"/>. </summary>
        public static MachineLearningVirtualMachineCompute MachineLearningVirtualMachineCompute(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default, MachineLearningVirtualMachineProperties properties = default)
        {
            return new MachineLearningVirtualMachineCompute(ComputeType.VirtualMachine, computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors is null ? null : new List<MachineLearningError>(provisioningErrors), isAttachedCompute, disableLocalAuth, additionalBinaryDataProperties: null, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningHDInsightCompute"/>. </summary>
        public static MachineLearningHDInsightCompute MachineLearningHDInsightCompute(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default, MachineLearningHDInsightProperties properties = default)
        {
            return new MachineLearningHDInsightCompute(ComputeType.HDInsight, computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors is null ? null : new List<MachineLearningError>(provisioningErrors), isAttachedCompute, disableLocalAuth, additionalBinaryDataProperties: null, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningDataFactoryCompute"/>. </summary>
        public static MachineLearningDataFactoryCompute MachineLearningDataFactoryCompute(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default)
        {
            return new MachineLearningDataFactoryCompute(ComputeType.DataFactory, computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors is null ? null : new List<MachineLearningError>(provisioningErrors), isAttachedCompute, disableLocalAuth, additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningDatabricksCompute"/>. </summary>
        public static MachineLearningDatabricksCompute MachineLearningDatabricksCompute(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default, MachineLearningDatabricksProperties properties = default)
        {
            return new MachineLearningDatabricksCompute(ComputeType.Databricks, computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors is null ? null : new List<MachineLearningError>(provisioningErrors), isAttachedCompute, disableLocalAuth, additionalBinaryDataProperties: null, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningDataLakeAnalytics"/>. </summary>
        public static MachineLearningDataLakeAnalytics MachineLearningDataLakeAnalytics(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default, string dataLakeStoreAccountName = default)
        {
            return new MachineLearningDataLakeAnalytics(ComputeType.DataLakeAnalytics, computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors is null ? null : new List<MachineLearningError>(provisioningErrors), isAttachedCompute, disableLocalAuth, additionalBinaryDataProperties: null, new DataLakeAnalyticsSchemaProperties(dataLakeStoreAccountName, additionalBinaryDataProperties: null));
        }

        /// <summary> Initializes a new instance of <see cref="Models.MachineLearningSynapseSpark"/>. </summary>
        public static MachineLearningSynapseSpark MachineLearningSynapseSpark(string computeLocation = default, MachineLearningProvisioningState? provisioningState = default, string description = default, DateTimeOffset? createdOn = default, DateTimeOffset? modifiedOn = default, ResourceIdentifier resourceId = default, IEnumerable<MachineLearningError> provisioningErrors = default, bool? isAttachedCompute = default, bool? disableLocalAuth = default, MachineLearningSynapseSparkProperties properties = default)
        {
            return new MachineLearningSynapseSpark(ComputeType.SynapseSpark, computeLocation, provisioningState, description, createdOn, modifiedOn, resourceId, provisioningErrors is null ? null : new List<MachineLearningError>(provisioningErrors), isAttachedCompute, disableLocalAuth, additionalBinaryDataProperties: null, properties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.RegistryPrivateEndpoint"/>. </summary>
        [Obsolete("This overload is no longer used by the generator. Use the generated RegistryPrivateEndpoint overload.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RegistryPrivateEndpoint RegistryPrivateEndpoint(ResourceIdentifier id = default, ResourceIdentifier subnetArmId = default)
        {
            return new RegistryPrivateEndpoint(id, additionalBinaryDataProperties: null, subnetArmId);
        }

        /// <summary> Initializes a new instance of <see cref="Models.PrivateEndpointBase"/>. </summary>
        public static PrivateEndpointBase PrivateEndpointBase(ResourceIdentifier id = default)
        {
            return new PrivateEndpointBase(id, additionalBinaryDataProperties: null);
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
            return new MachineLearningSweepJob(description, properties, tags, additionalBinaryDataProperties: null, componentId, computeId, displayName, experimentName, identity, isArchived, JobType.Sweep, notificationSetting, parentJobName: null, services, status, earlyTermination, inputs, limits, objective, outputs, queueSettings: jobTier.HasValue ? new QueueSettings(jobTier.Value, additionalBinaryDataProperties: null) : null, samplingAlgorithm, searchSpace, trial);
        }
    }
}
