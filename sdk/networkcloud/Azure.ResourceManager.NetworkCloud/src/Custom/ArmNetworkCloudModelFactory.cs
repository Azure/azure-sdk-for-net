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

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public static partial class ArmNetworkCloudModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.KubernetesClusterNode"/>. </summary>
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
        /// <returns> A new <see cref="Models.KubernetesClusterNode"/> instance for mocking. </returns>
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
                serializedAdditionalRawData: null);
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
            tags ??= new Dictionary<string, string>();
            availabilityZones ??= new List<string>();
            labels ??= new List<KubernetesLabel>();
            taints ??= new List<KubernetesLabel>();

            return new NetworkCloudAgentPoolData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                null,
                extendedLocation,
                administratorConfiguration,
                agentOptions,
                attachedNetworkConfiguration,
                availabilityZones?.ToList(),
                count,
                detailedStatus,
                detailedStatusMessage,
                kubernetesVersion,
                labels?.ToList(),
                mode,
                provisioningState,
                taints?.ToList(),
                new AgentPoolUpgradeSettings()
                {
                    MaxSurge = upgradeMaxSurge
                },
                vmSkuName,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.NetworkAttachment"/>. </summary>
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
        /// <returns> A new <see cref="Models.NetworkAttachment"/> instance for mocking. </returns>
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
                serializedAdditionalRawData: null);
    }
}
