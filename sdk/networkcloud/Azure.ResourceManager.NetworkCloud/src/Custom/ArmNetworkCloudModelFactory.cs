// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    // CodeGenSuppress for the generated backward-compat overload of NetworkCloudOperationStatusResult.
    // The generator produces invalid C#: it mixes positional args after named args when calling the
    // main overload, because the new parameters (exitCode, outputHead, resultRef, resultUri) from
    // OperationStatusResultProperties (flattened via @@flattenProperty in back-compat.tsp) are inserted
    // as named defaults between reordered positional args. The corrected overload is defined below.
    [CodeGenSuppress("NetworkCloudOperationStatusResult", typeof(ResourceIdentifier), typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(float?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<NetworkCloudOperationStatusResult>), typeof(ResponseError))]
    public static partial class ArmNetworkCloudModelFactory
    {
        /// <summary> Initializes a new instance of KubernetesClusterNode. </summary>
        /// <param name="agentPoolId"> The resource ID of the agent pool that this node belongs to. This value is not represented on control plane nodes. </param>
        /// <param name="availabilityZone"> The availability zone this node is running within. </param>
        /// <param name="bareMetalMachineId"> The resource ID of the bare metal machine that hosts this node. </param>
        /// <param name="cpuCores"> The number of CPU cores configured for this node, derived from the VM SKU specified. </param>
        /// <param name="detailedStatus"> The detailed state of this node. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="diskSizeGB"> The size of the disk configured for this node. </param>
        /// <param name="image"> The machine image used to deploy this node. </param>
        /// <param name="kubernetesVersion"> The currently running version of Kubernetes and bundled features running on this node. </param>
        /// <param name="labels"> The list of labels on this node that have been assigned to the agent pool containing this node. </param>
        /// <param name="memorySizeGB"> The amount of memory configured for this node, derived from the vm SKU specified. </param>
        /// <param name="mode"> The mode of the agent pool containing this node. Not applicable for control plane nodes. </param>
        /// <param name="name"> The name of this node, as realized in the Kubernetes cluster. </param>
        /// <param name="networkAttachments"> The NetworkAttachments made to this node. </param>
        /// <param name="powerState"> The power state of this node. </param>
        /// <param name="role"> The role of this node in the cluster. </param>
        /// <param name="taints"> The list of taints that have been assigned to the agent pool containing this node. </param>
        /// <param name="vmSkuName"> The VM SKU name that was used to create this cluster node. </param>
        /// <returns> A new KubernetesClusterNode instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KubernetesClusterNode KubernetesClusterNode(string agentPoolId, string availabilityZone, string bareMetalMachineId, long? cpuCores, KubernetesClusterNodeDetailedStatus? detailedStatus, string detailedStatusMessage, long? diskSizeGB, string image, string kubernetesVersion, IEnumerable<KubernetesLabel> labels, long? memorySizeGB, NetworkCloudAgentPoolMode? mode, string name, IEnumerable<NetworkAttachment> networkAttachments, KubernetesNodePowerState? powerState, KubernetesNodeRole? role, IEnumerable<KubernetesLabel> taints, string vmSkuName)
        {
            labels ??= new List<KubernetesLabel>();
            networkAttachments ??= new List<NetworkAttachment>();
            taints ??= new List<KubernetesLabel>();

            return new KubernetesClusterNode(
                new ResourceIdentifier(agentPoolId),
                availabilityZone,
                new ResourceIdentifier(bareMetalMachineId),
                cpuCores,
                detailedStatus,
                detailedStatusMessage,
                diskSizeGB,
                image,
                kubernetesVersion,
                labels?.ToList(),
                memorySizeGB,
                mode,
                name,
                networkAttachments?.ToList(),
                powerState,
                role,
                taints?.ToList(),
                vmSkuName,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudAgentPoolData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="administratorConfiguration"> The administrator credentials to be used for the nodes in this agent pool. </param>
        /// <param name="agentOptions"> The configurations that will be applied to each agent in this agent pool. </param>
        /// <param name="attachedNetworkConfiguration"> The configuration of networks being attached to the agent pool for use by the workloads that run on this Kubernetes cluster. </param>
        /// <param name="availabilityZones"> The list of availability zones of the Network Cloud cluster used for the provisioning of nodes in this agent pool. If not specified, all availability zones will be used. </param>
        /// <param name="count"> The number of virtual machines that use this configuration. </param>
        /// <param name="detailedStatus"> The current status of the agent pool. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="kubernetesVersion"> The Kubernetes version running in this agent pool. </param>
        /// <param name="labels"> The labels applied to the nodes in this agent pool. </param>
        /// <param name="mode"> The selection of how this agent pool is utilized, either as a system pool or a user pool. System pools run the features and critical services for the Kubernetes Cluster, while user pools are dedicated to user workloads. Every Kubernetes cluster must contain at least one system node pool with at least one node. </param>
        /// <param name="provisioningState"> The provisioning state of the agent pool. </param>
        /// <param name="taints"> The taints applied to the nodes in this agent pool. </param>
        /// <param name="upgradeMaxSurge"> The configuration of the agent pool. </param>
        /// <param name="vmSkuName"> The name of the VM SKU that determines the size of resources allocated for node VMs. </param>
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudAgentPoolData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudAgentPoolData NetworkCloudAgentPoolData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, AdministratorConfiguration administratorConfiguration, NetworkCloudAgentConfiguration agentOptions, AttachedNetworkConfiguration attachedNetworkConfiguration, IEnumerable<string> availabilityZones, long count, AgentPoolDetailedStatus? detailedStatus, string detailedStatusMessage, string kubernetesVersion, IEnumerable<KubernetesLabel> labels, NetworkCloudAgentPoolMode mode, AgentPoolProvisioningState? provisioningState, IEnumerable<KubernetesLabel> taints, string upgradeMaxSurge, string vmSkuName)
        {
            return NetworkCloudAgentPoolData(
                id, name, resourceType, systemData, tags, location, extendedLocation,
                administratorConfiguration, agentOptions, attachedNetworkConfiguration,
                availabilityZones, count, detailedStatus, detailedStatusMessage, kubernetesVersion,
                labels, mode, provisioningState, taints,
                new AgentPoolUpgradeSettings() { MaxSurge = upgradeMaxSurge },
                vmSkuName);
        }

        /// <summary> Initializes a new instance of NetworkAttachment. </summary>
        /// <param name="attachedNetworkId">
        /// The resource ID of the associated network attached to the virtual machine.
        /// It can be one of cloudServicesNetwork, l3Network, l2Network or trunkedNetwork resources.
        /// </param>
        /// <param name="defaultGateway">
        /// The indicator of whether this is the default gateway.
        /// Only one of the attached networks (including the CloudServicesNetwork attachment) for a single machine may be specified as True.
        /// </param>
        /// <param name="ipAllocationMethod">
        /// The IP allocation mechanism for the virtual machine.
        /// Dynamic and Static are only valid for l3Network which may also specify Disabled.
        /// Otherwise, Disabled is the only permitted value.
        /// </param>
        /// <param name="ipv4Address">
        /// The IPv4 address of the virtual machine.
        ///
        /// This field is used only if the attached network has IPAllocationType of IPV4 or DualStack.
        ///
        /// If IPAllocationMethod is:
        /// Static - this field must contain a user specified IPv4 address from within the subnet specified in the attached network.
        /// Dynamic - this field is read-only, but will be populated with an address from within the subnet specified in the attached network.
        /// Disabled - this field will be empty.
        /// </param>
        /// <param name="ipv6Address">
        /// The IPv6 address of the virtual machine.
        ///
        /// This field is used only if the attached network has IPAllocationType of IPV6 or DualStack.
        ///
        /// If IPAllocationMethod is:
        /// Static - this field must contain an IPv6 address range from within the range specified in the attached network.
        /// Dynamic - this field is read-only, but will be populated with an range from within the subnet specified in the attached network.
        /// Disabled - this field will be empty.
        /// </param>
        /// <param name="macAddress"> The MAC address of the interface for the virtual machine that corresponds to this network attachment. </param>
        /// <param name="networkAttachmentName">
        /// The associated network's interface name.
        /// If specified, the network attachment name has a maximum length of 15 characters and must be unique to this virtual machine.
        /// If the user doesn’t specify this value, the default interface name of the network resource will be used.
        /// For a CloudServicesNetwork resource, this name will be ignored.
        /// </param>
        /// <returns> A new NetworkAttachment instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkAttachment NetworkAttachment(string attachedNetworkId, DefaultGateway? defaultGateway, VirtualMachineIPAllocationMethod ipAllocationMethod, string ipv4Address, string ipv6Address, string macAddress, string networkAttachmentName)

            => new NetworkAttachment(
                new ResourceIdentifier(attachedNetworkId),
                defaultGateway,
                ipAllocationMethod,
                ipv4Address,
                ipv6Address,
                macAddress,
                networkAttachmentName,
                additionalBinaryDataProperties: null);

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudAgentPoolData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudAgentPoolData NetworkCloudAgentPoolData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, AdministratorConfiguration administratorConfiguration, NetworkCloudAgentConfiguration agentOptions, AttachedNetworkConfiguration attachedNetworkConfiguration, IEnumerable<string> availabilityZones, long count, AgentPoolDetailedStatus? detailedStatus, string detailedStatusMessage, string kubernetesVersion, IEnumerable<KubernetesLabel> labels, NetworkCloudAgentPoolMode mode, AgentPoolProvisioningState? provisioningState, IEnumerable<KubernetesLabel> taints, AgentPoolUpgradeSettings upgradeSettings, string vmSkuName)
        {
            var properties = new AgentPoolProperties(
                administratorConfiguration,
                agentOptions,
                attachedNetworkConfiguration,
                availabilityZones?.ToList() ?? (IList<string>)new ChangeTrackingList<string>(),
                count,
                labels?.ToList() ?? (IList<KubernetesLabel>)new ChangeTrackingList<KubernetesLabel>(),
                mode,
                taints?.ToList() ?? (IList<KubernetesLabel>)new ChangeTrackingList<KubernetesLabel>(),
                upgradeSettings,
                vmSkuName,
                detailedStatus,
                detailedStatusMessage,
                kubernetesVersion,
                provisioningState,
                additionalBinaryDataProperties: null);

            return new NetworkCloudAgentPoolData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                properties,
                default,
                extendedLocation);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudBareMetalMachineKeySetData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudBareMetalMachineKeySetData NetworkCloudBareMetalMachineKeySetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, string azureGroupId, BareMetalMachineKeySetDetailedStatus? detailedStatus, string detailedStatusMessage, DateTimeOffset expireOn, IEnumerable<IPAddress> jumpHostsAllowed, DateTimeOffset? lastValidatedOn, string osGroupName, BareMetalMachineKeySetPrivilegeLevel privilegeLevel, BareMetalMachineKeySetProvisioningState? provisioningState, IEnumerable<KeySetUser> userList, IEnumerable<KeySetUserStatus> userListStatus)
        {
            return NetworkCloudBareMetalMachineKeySetData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                extendedLocation: extendedLocation,
                azureGroupId: azureGroupId,
                detailedStatus: detailedStatus,
                detailedStatusMessage: detailedStatusMessage,
                expireOn: expireOn,
                jumpHostsAllowed: jumpHostsAllowed,
                lastValidatedOn: lastValidatedOn,
                osGroupName: osGroupName,
                privilegeLevel: privilegeLevel,
                provisioningState: provisioningState,
                userList: userList,
                userListStatus: userListStatus);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudBareMetalMachineKeySetData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudBareMetalMachineKeySetData NetworkCloudBareMetalMachineKeySetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, ExtendedLocation extendedLocation, string azureGroupId, BareMetalMachineKeySetDetailedStatus? detailedStatus, string detailedStatusMessage, DateTimeOffset expireOn, IEnumerable<IPAddress> jumpHostsAllowed, DateTimeOffset? lastValidatedOn, string osGroupName, BareMetalMachineKeySetPrivilegeLevel privilegeLevel, BareMetalMachineKeySetProvisioningState? provisioningState, IEnumerable<KeySetUser> userList, IEnumerable<KeySetUserStatus> userListStatus)
        {
            return NetworkCloudBareMetalMachineKeySetData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                etag: etag,
                extendedLocation: extendedLocation,
                azureGroupId: azureGroupId,
                detailedStatus: detailedStatus,
                detailedStatusMessage: detailedStatusMessage,
                expireOn: expireOn,
                jumpHostsAllowed: jumpHostsAllowed,
                lastValidatedOn: lastValidatedOn,
                osGroupName: osGroupName,
                privilegeLevel: privilegeLevel,
                provisioningState: provisioningState,
                userList: userList,
                userListStatus: userListStatus);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudBmcKeySetData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudBmcKeySetData NetworkCloudBmcKeySetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, string azureGroupId, BmcKeySetDetailedStatus? detailedStatus, string detailedStatusMessage, DateTimeOffset expireOn, DateTimeOffset? lastValidatedOn, BmcKeySetPrivilegeLevel privilegeLevel, BmcKeySetProvisioningState? provisioningState, IEnumerable<KeySetUser> userList, IEnumerable<KeySetUserStatus> userListStatus)
        {
            return NetworkCloudBmcKeySetData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                extendedLocation: extendedLocation,
                azureGroupId: azureGroupId,
                detailedStatus: detailedStatus,
                detailedStatusMessage: detailedStatusMessage,
                expireOn: expireOn,
                lastValidatedOn: lastValidatedOn,
                privilegeLevel: privilegeLevel,
                provisioningState: provisioningState,
                userList: userList,
                userListStatus: userListStatus);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudCloudServicesNetworkData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudCloudServicesNetworkData NetworkCloudCloudServicesNetworkData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, IEnumerable<EgressEndpoint> additionalEgressEndpoints, IEnumerable<ResourceIdentifier> associatedResourceIds, ResourceIdentifier clusterId, CloudServicesNetworkDetailedStatus? detailedStatus, string detailedStatusMessage, CloudServicesNetworkEnableDefaultEgressEndpoint? enableDefaultEgressEndpoints, IEnumerable<EgressEndpoint> enabledEgressEndpoints, IEnumerable<ResourceIdentifier> hybridAksClustersAssociatedIds, string interfaceName, CloudServicesNetworkProvisioningState? provisioningState, IEnumerable<ResourceIdentifier> virtualMachinesAssociatedIds)
        {
            return NetworkCloudCloudServicesNetworkData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                extendedLocation: extendedLocation,
                additionalEgressEndpoints: additionalEgressEndpoints,
                associatedResourceIds: associatedResourceIds,
                clusterId: clusterId,
                detailedStatus: detailedStatus,
                detailedStatusMessage: detailedStatusMessage,
                enableDefaultEgressEndpoints: enableDefaultEgressEndpoints,
                enabledEgressEndpoints: enabledEgressEndpoints,
                hybridAksClustersAssociatedIds: hybridAksClustersAssociatedIds,
                interfaceName: interfaceName,
                provisioningState: provisioningState,
                virtualMachinesAssociatedIds: virtualMachinesAssociatedIds);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudCloudServicesNetworkData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudCloudServicesNetworkData NetworkCloudCloudServicesNetworkData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, ExtendedLocation extendedLocation, IEnumerable<EgressEndpoint> additionalEgressEndpoints, IEnumerable<ResourceIdentifier> associatedResourceIds, ResourceIdentifier clusterId, CloudServicesNetworkDetailedStatus? detailedStatus, string detailedStatusMessage, CloudServicesNetworkEnableDefaultEgressEndpoint? enableDefaultEgressEndpoints, IEnumerable<EgressEndpoint> enabledEgressEndpoints, IEnumerable<ResourceIdentifier> hybridAksClustersAssociatedIds, string interfaceName, CloudServicesNetworkProvisioningState? provisioningState, IEnumerable<ResourceIdentifier> virtualMachinesAssociatedIds)
        {
            return NetworkCloudCloudServicesNetworkData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                etag: etag,
                extendedLocation: extendedLocation,
                additionalEgressEndpoints: additionalEgressEndpoints,
                associatedResourceIds: associatedResourceIds,
                clusterId: clusterId,
                detailedStatus: detailedStatus,
                detailedStatusMessage: detailedStatusMessage,
                enableDefaultEgressEndpoints: enableDefaultEgressEndpoints,
                enabledEgressEndpoints: enabledEgressEndpoints,
                hybridAksClustersAssociatedIds: hybridAksClustersAssociatedIds,
                interfaceName: interfaceName,
                provisioningState: provisioningState,
                virtualMachinesAssociatedIds: virtualMachinesAssociatedIds);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudClusterMetricsConfigurationData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudClusterMetricsConfigurationData NetworkCloudClusterMetricsConfigurationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, long collectionInterval, ClusterMetricsConfigurationDetailedStatus? detailedStatus, string detailedStatusMessage, IEnumerable<string> disabledMetrics, IEnumerable<string> enabledMetrics, ClusterMetricsConfigurationProvisioningState? provisioningState)
        {
            return NetworkCloudClusterMetricsConfigurationData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                extendedLocation: extendedLocation,
                collectionInterval: collectionInterval,
                detailedStatus: detailedStatus,
                detailedStatusMessage: detailedStatusMessage,
                disabledMetrics: disabledMetrics,
                enabledMetrics: enabledMetrics,
                provisioningState: provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudKubernetesClusterData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudKubernetesClusterData NetworkCloudKubernetesClusterData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, IEnumerable<string> aadAdminGroupObjectIds, AdministratorConfiguration administratorConfiguration, IEnumerable<ResourceIdentifier> attachedNetworkIds, IEnumerable<AvailableUpgrade> availableUpgrades, ResourceIdentifier clusterId, ResourceIdentifier connectedClusterId, string controlPlaneKubernetesVersion, ControlPlaneNodeConfiguration controlPlaneNodeConfiguration, KubernetesClusterDetailedStatus? detailedStatus, string detailedStatusMessage, IEnumerable<FeatureStatus> featureStatuses, IEnumerable<InitialAgentPoolConfiguration> initialAgentPoolConfigurations, string kubernetesVersion, ManagedResourceGroupConfiguration managedResourceGroupConfiguration, KubernetesClusterNetworkConfiguration networkConfiguration, IEnumerable<KubernetesClusterNode> nodes, KubernetesClusterProvisioningState? provisioningState)
        {
            return NetworkCloudKubernetesClusterData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                extendedLocation: extendedLocation,
                aadAdminGroupObjectIds: aadAdminGroupObjectIds,
                administratorConfiguration: administratorConfiguration,
                attachedNetworkIds: attachedNetworkIds,
                availableUpgrades: availableUpgrades,
                clusterId: clusterId,
                connectedClusterId: connectedClusterId,
                controlPlaneKubernetesVersion: controlPlaneKubernetesVersion,
                controlPlaneNodeConfiguration: controlPlaneNodeConfiguration,
                detailedStatus: detailedStatus,
                detailedStatusMessage: detailedStatusMessage,
                featureStatuses: featureStatuses,
                initialAgentPoolConfigurations: initialAgentPoolConfigurations,
                kubernetesVersion: kubernetesVersion,
                managedResourceGroupConfiguration: managedResourceGroupConfiguration,
                networkConfiguration: networkConfiguration,
                nodes: nodes,
                provisioningState: provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudKubernetesClusterFeatureData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudKubernetesClusterFeatureData NetworkCloudKubernetesClusterFeatureData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, KubernetesClusterFeatureAvailabilityLifecycle? availabilityLifecycle, KubernetesClusterFeatureDetailedStatus? detailedStatus, string detailedStatusMessage, IEnumerable<StringKeyValuePair> options, KubernetesClusterFeatureProvisioningState? provisioningState, KubernetesClusterFeatureRequired? @required, string version)
        {
            return NetworkCloudKubernetesClusterFeatureData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                availabilityLifecycle: availabilityLifecycle,
                detailedStatus: detailedStatus,
                detailedStatusMessage: detailedStatusMessage,
                options: options,
                provisioningState: provisioningState,
                @required: @required,
                version: version);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudL2NetworkData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudL2NetworkData NetworkCloudL2NetworkData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, IEnumerable<ResourceIdentifier> associatedResourceIds, ResourceIdentifier clusterId, L2NetworkDetailedStatus? detailedStatus, string detailedStatusMessage, IEnumerable<ResourceIdentifier> hybridAksClustersAssociatedIds, HybridAksPluginType? hybridAksPluginType, string interfaceName, ResourceIdentifier l2IsolationDomainId, L2NetworkProvisioningState? provisioningState, IEnumerable<ResourceIdentifier> virtualMachinesAssociatedIds)
        {
            return NetworkCloudL2NetworkData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                extendedLocation: extendedLocation,
                associatedResourceIds: associatedResourceIds,
                clusterId: clusterId,
                detailedStatus: detailedStatus,
                detailedStatusMessage: detailedStatusMessage,
                hybridAksClustersAssociatedIds: hybridAksClustersAssociatedIds,
                hybridAksPluginType: hybridAksPluginType,
                interfaceName: interfaceName,
                l2IsolationDomainId: l2IsolationDomainId,
                provisioningState: provisioningState,
                virtualMachinesAssociatedIds: virtualMachinesAssociatedIds);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.Models.NetworkCloudOperationStatusResult"/>. </summary>
        /// <param name="id"> Fully qualified ID for the async operation. </param>
        /// <param name="resourceId"> Fully qualified ID of the resource against which the original async operation was started. </param>
        /// <param name="name"> Name of the async operation. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentComplete"> Percent of the operation that is complete. </param>
        /// <param name="startOn"> The start time of the operation. </param>
        /// <param name="endOn"> The end time of the operation. </param>
        /// <param name="operations"> The operations list. </param>
        /// <param name="error"> If present, details of the operation error. </param>
        /// <returns> A new <see cref="NetworkCloud.Models.NetworkCloudOperationStatusResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudOperationStatusResult NetworkCloudOperationStatusResult(ResourceIdentifier id, ResourceIdentifier resourceId, string name, string status, float? percentComplete, DateTimeOffset? startOn, DateTimeOffset? endOn, IEnumerable<NetworkCloudOperationStatusResult> operations, ResponseError error)
        {
            return NetworkCloudOperationStatusResult(
                endOn: endOn,
                error: error,
                id: id,
                name: name,
                operations: operations,
                percentComplete: percentComplete,
                resourceId: resourceId,
                startOn: startOn,
                status: status);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudRackData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudRackData NetworkCloudRackData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, string availabilityZone, ResourceIdentifier clusterId, RackDetailedStatus? detailedStatus, string detailedStatusMessage, RackProvisioningState? provisioningState, string rackLocation, string rackSerialNumber, ResourceIdentifier rackSkuId)
        {
            return NetworkCloudRackData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                extendedLocation: extendedLocation,
                availabilityZone: availabilityZone,
                clusterId: clusterId,
                detailedStatus: detailedStatus,
                detailedStatusMessage: detailedStatusMessage,
                provisioningState: provisioningState,
                rackLocation: rackLocation,
                rackSerialNumber: rackSerialNumber,
                rackSkuId: rackSkuId);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudTrunkedNetworkData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudTrunkedNetworkData NetworkCloudTrunkedNetworkData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, IEnumerable<string> associatedResourceIds, ResourceIdentifier clusterId, TrunkedNetworkDetailedStatus? detailedStatus, string detailedStatusMessage, IEnumerable<ResourceIdentifier> hybridAksClustersAssociatedIds, HybridAksPluginType? hybridAksPluginType, string interfaceName, IEnumerable<ResourceIdentifier> isolationDomainIds, TrunkedNetworkProvisioningState? provisioningState, IEnumerable<ResourceIdentifier> virtualMachinesAssociatedIds, IEnumerable<long> vlans)
        {
            return NetworkCloudTrunkedNetworkData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                extendedLocation: extendedLocation,
                associatedResourceIds: associatedResourceIds,
                clusterId: clusterId,
                detailedStatus: detailedStatus,
                detailedStatusMessage: detailedStatusMessage,
                hybridAksClustersAssociatedIds: hybridAksClustersAssociatedIds,
                hybridAksPluginType: hybridAksPluginType,
                interfaceName: interfaceName,
                isolationDomainIds: isolationDomainIds,
                provisioningState: provisioningState,
                virtualMachinesAssociatedIds: virtualMachinesAssociatedIds,
                vlans: vlans);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudVirtualMachineConsoleData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudVirtualMachineConsoleData NetworkCloudVirtualMachineConsoleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, ConsoleDetailedStatus? detailedStatus, string detailedStatusMessage, ConsoleEnabled enabled, DateTimeOffset? expireOn, ResourceIdentifier privateLinkServiceId, ConsoleProvisioningState? provisioningState, string keyData, Guid? virtualMachineAccessId)
        {
            return NetworkCloudVirtualMachineConsoleData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                extendedLocation: extendedLocation,
                detailedStatus: detailedStatus,
                detailedStatusMessage: detailedStatusMessage,
                enabled: enabled,
                expireOn: expireOn,
                privateLinkServiceId: privateLinkServiceId,
                provisioningState: provisioningState,
                keyData: keyData,
                virtualMachineAccessId: virtualMachineAccessId);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudVolumeData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudVolumeData NetworkCloudVolumeData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, IEnumerable<string> attachedTo, VolumeDetailedStatus? detailedStatus, string detailedStatusMessage, VolumeProvisioningState? provisioningState, string serialNumber, long sizeInMiB)
        {
            return NetworkCloudVolumeData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                extendedLocation: extendedLocation,
                attachedTo: attachedTo,
                detailedStatus: detailedStatus,
                detailedStatusMessage: detailedStatusMessage,
                provisioningState: provisioningState,
                serialNumber: serialNumber,
                sizeInMiB: sizeInMiB);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudVolumeData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudVolumeData NetworkCloudVolumeData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, ExtendedLocation extendedLocation, IEnumerable<string> attachedTo, VolumeDetailedStatus? detailedStatus, string detailedStatusMessage, VolumeProvisioningState? provisioningState, string serialNumber, long sizeInMiB)
        {
            return NetworkCloudVolumeData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                etag: etag,
                extendedLocation: extendedLocation,
                attachedTo: attachedTo,
                detailedStatus: detailedStatus,
                detailedStatusMessage: detailedStatusMessage,
                provisioningState: provisioningState,
                serialNumber: serialNumber,
                sizeInMiB: sizeInMiB);
        }
    }
}
