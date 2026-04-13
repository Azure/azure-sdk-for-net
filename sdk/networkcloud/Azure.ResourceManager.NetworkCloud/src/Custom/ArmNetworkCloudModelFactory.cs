// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

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
            => KubernetesClusterNode(agentPoolId, availabilityZone, bareMetalMachineId, cpuCores, detailedStatus, detailedStatusMessage, diskSizeGB, image, kubernetesVersion, labels, memorySizeGB, mode, name, networkAttachments, powerState, role, taints, vmSkuName);

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
        public static NetworkCloudAgentPoolData NetworkCloudAgentPoolData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, AdministratorConfiguration administratorConfiguration, NetworkCloudAgentConfiguration agentOptions, AttachedNetworkConfiguration attachedNetworkConfiguration, IEnumerable<string> availabilityZones, long count, AgentPoolDetailedStatus? detailedStatus, string detailedStatusMessage, string kubernetesVersion, IEnumerable<KubernetesLabel> labels, NetworkCloudAgentPoolMode mode, AgentPoolProvisioningState? provisioningState, IEnumerable<KubernetesLabel> taints, string upgradeMaxSurge, string vmSkuName)
            => NetworkCloudAgentPoolData(id, name, resourceType, systemData, tags, location, null, extendedLocation, administratorConfiguration, agentOptions, attachedNetworkConfiguration, availabilityZones, count, detailedStatus, detailedStatusMessage, kubernetesVersion, labels, mode, provisioningState, taints, new AgentPoolUpgradeSettings() { MaxSurge = upgradeMaxSurge }, vmSkuName);

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
                additionalBinaryDataProperties: null);

        // TODO: All below factory methods should be moved once the MTG issue is resolved.

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="availabilityLifecycle"> The lifecycle indicator of the feature. </param>
        /// <param name="detailedStatus"> The detailed status of the feature. </param>
        /// <param name="detailedStatusMessage"> The descriptive message for the detailed status of the feature. </param>
        /// <param name="options"> The configured options for the feature. </param>
        /// <param name="provisioningState"> The provisioning state of the Kubernetes cluster feature. </param>
        /// <param name="required"> The indicator of if the feature is required or optional. Optional features may be deleted by the user, while required features are managed with the kubernetes cluster lifecycle. </param>
        /// <param name="version"> The version of the feature. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudKubernetesClusterFeatureData NetworkCloudKubernetesClusterFeatureData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, KubernetesClusterFeatureAvailabilityLifecycle? availabilityLifecycle, KubernetesClusterFeatureDetailedStatus? detailedStatus, string detailedStatusMessage, IEnumerable<StringKeyValuePair> options, KubernetesClusterFeatureProvisioningState? provisioningState, KubernetesClusterFeatureRequired? required, string version)
        {
            return NetworkCloudKubernetesClusterFeatureData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, etag: default, availabilityLifecycle: availabilityLifecycle, detailedStatus: detailedStatus, detailedStatusMessage: detailedStatusMessage, options: options, provisioningState: provisioningState, required: required, version: version);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult" />. </summary>
        /// <param name="id"> Fully qualified ID for the async operation. </param>
        /// <param name="resourceId"> Fully qualified ID of the resource against which the original async operation was started. </param>
        /// <param name="name"> Name of the async operation. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentComplete"> Percent of the operation that is complete. </param>
        /// <param name="startOn"> The start time of the operation. </param>
        /// <param name="endOn"> The end time of the operation. </param>
        /// <param name="operations"> The operations list. </param>
        /// <param name="error"> If present, details of the operation error. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudOperationStatusResult NetworkCloudOperationStatusResult(ResourceIdentifier id, ResourceIdentifier resourceId, string name, string status, float? percentComplete, DateTimeOffset? startOn, DateTimeOffset? endOn, IEnumerable<NetworkCloudOperationStatusResult> operations, ResponseError error)
        {
            return NetworkCloudOperationStatusResult(endOn: endOn, error: error, id: id, name: name, operations: operations, percentComplete: percentComplete, resourceId: resourceId, startOn: startOn, status: status, exitCode: default, outputHead: default, resultRef: default, resultUri: default);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster manager associated with the cluster this virtual machine is created on. </param>
        /// <param name="detailedStatus"> The more detailed status of the console. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="enabled"> The indicator of whether the console access is enabled. </param>
        /// <param name="expireOn"> The date and time after which the key will be disallowed access. </param>
        /// <param name="privateLinkServiceId"> The resource ID of the private link service that is used to provide virtual machine console access. </param>
        /// <param name="provisioningState"> The provisioning state of the virtual machine console. </param>
        /// <param name="keyData"> The SSH public key that will be provisioned for user access. The user is expected to have the corresponding SSH private key for logging in. </param>
        /// <param name="virtualMachineAccessId"> The unique identifier for the virtual machine that is used to access the console. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudVirtualMachineConsoleData NetworkCloudVirtualMachineConsoleData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, ConsoleDetailedStatus? detailedStatus, string detailedStatusMessage, ConsoleEnabled enabled, DateTimeOffset? expireOn, ResourceIdentifier privateLinkServiceId, ConsoleProvisioningState? provisioningState, string keyData, Guid? virtualMachineAccessId)
        {
            return NetworkCloudVirtualMachineConsoleData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, etag: default, extendedLocation: extendedLocation, detailedStatus: detailedStatus, detailedStatusMessage: detailedStatusMessage, enabled: enabled, expireOn: expireOn, privateLinkServiceId: privateLinkServiceId, provisioningState: provisioningState, keyData: keyData, virtualMachineAccessId: virtualMachineAccessId);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData" />. </summary>
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
        /// <param name="upgradeSettings"> The configuration of the agent pool. </param>
        /// <param name="vmSkuName"> The name of the VM SKU that determines the size of resources allocated for node VMs. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudAgentPoolData NetworkCloudAgentPoolData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, AdministratorConfiguration administratorConfiguration, NetworkCloudAgentConfiguration agentOptions, AttachedNetworkConfiguration attachedNetworkConfiguration, IEnumerable<string> availabilityZones, long count, AgentPoolDetailedStatus? detailedStatus, string detailedStatusMessage, string kubernetesVersion, IEnumerable<KubernetesLabel> labels, NetworkCloudAgentPoolMode mode, AgentPoolProvisioningState? provisioningState, IEnumerable<KubernetesLabel> taints, AgentPoolUpgradeSettings upgradeSettings, string vmSkuName)
        {
            return NetworkCloudAgentPoolData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, etag: default, extendedLocation: extendedLocation, administratorConfiguration: administratorConfiguration, agentOptions: agentOptions, attachedNetworkConfiguration: attachedNetworkConfiguration, availabilityZones: availabilityZones, count: count, detailedStatus: detailedStatus, detailedStatusMessage: detailedStatusMessage, kubernetesVersion: kubernetesVersion, labels: labels, mode: mode, provisioningState: provisioningState, taints: taints, upgradeSettings: upgradeSettings, vmSkuName: vmSkuName);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="collectionInterval"> The interval in minutes by which metrics will be collected. </param>
        /// <param name="detailedStatus"> The more detailed status of the metrics configuration. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="disabledMetrics"> The list of metrics that are available for the cluster but disabled at the moment. </param>
        /// <param name="enabledMetrics"> The list of metric names that have been chosen to be enabled in addition to the core set of enabled metrics. </param>
        /// <param name="provisioningState"> The provisioning state of the metrics configuration. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudClusterMetricsConfigurationData NetworkCloudClusterMetricsConfigurationData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, long collectionInterval, ClusterMetricsConfigurationDetailedStatus? detailedStatus, string detailedStatusMessage, IEnumerable<string> disabledMetrics, IEnumerable<string> enabledMetrics, ClusterMetricsConfigurationProvisioningState? provisioningState)
        {
            return NetworkCloudClusterMetricsConfigurationData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, etag: default, extendedLocation: extendedLocation, collectionInterval: collectionInterval, detailedStatus: detailedStatus, detailedStatusMessage: detailedStatusMessage, disabledMetrics: disabledMetrics, enabledMetrics: enabledMetrics, provisioningState: provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="azureGroupId"> The object ID of Azure Active Directory group that all users in the list must be in for access to be granted. Users that are not in the group will not have access. </param>
        /// <param name="detailedStatus"> The more detailed status of the key set. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="expireOn"> The date and time after which the users in this key set will be removed from the baseboard management controllers. </param>
        /// <param name="lastValidatedOn"> The last time this key set was validated. </param>
        /// <param name="privilegeLevel"> The access level allowed for the users in this key set. </param>
        /// <param name="provisioningState"> The provisioning state of the baseboard management controller key set. </param>
        /// <param name="userList"> The unique list of permitted users. </param>
        /// <param name="userListStatus"> The status evaluation of each user. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudBmcKeySetData NetworkCloudBmcKeySetData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, string azureGroupId, BmcKeySetDetailedStatus? detailedStatus, string detailedStatusMessage, DateTimeOffset expireOn, DateTimeOffset? lastValidatedOn, BmcKeySetPrivilegeLevel privilegeLevel, BmcKeySetProvisioningState? provisioningState, IEnumerable<KeySetUser> userList, IEnumerable<KeySetUserStatus> userListStatus)
        {
            return NetworkCloudBmcKeySetData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, etag: default, extendedLocation: extendedLocation, azureGroupId: azureGroupId, detailedStatus: detailedStatus, detailedStatusMessage: detailedStatusMessage, expireOn: expireOn, lastValidatedOn: lastValidatedOn, privilegeLevel: privilegeLevel, provisioningState: provisioningState, userList: userList, userListStatus: userListStatus);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Resource ETag. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="azureGroupId"> The object ID of Azure Active Directory group that all users in the list must be in for access to be granted. Users that are not in the group will not have access. </param>
        /// <param name="detailedStatus"> The more detailed status of the key set. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="expireOn"> The date and time after which the users in this key set will be removed from the bare metal machines. </param>
        /// <param name="jumpHostsAllowed"> The list of IP addresses of jump hosts with management network access from which a login will be allowed for the users. </param>
        /// <param name="lastValidatedOn"> The last time this key set was validated. </param>
        /// <param name="osGroupName"> The name of the group that users will be assigned to on the operating system of the machines. </param>
        /// <param name="privilegeLevel"> The access level allowed for the users in this key set. </param>
        /// <param name="provisioningState"> The provisioning state of the bare metal machine key set. </param>
        /// <param name="userList"> The unique list of permitted users. </param>
        /// <param name="userListStatus"> The status evaluation of each user. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudBareMetalMachineKeySetData NetworkCloudBareMetalMachineKeySetData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, ExtendedLocation extendedLocation, string azureGroupId, BareMetalMachineKeySetDetailedStatus? detailedStatus, string detailedStatusMessage, DateTimeOffset expireOn, IEnumerable<IPAddress> jumpHostsAllowed, DateTimeOffset? lastValidatedOn, string osGroupName, BareMetalMachineKeySetPrivilegeLevel privilegeLevel, BareMetalMachineKeySetProvisioningState? provisioningState, IEnumerable<KeySetUser> userList, IEnumerable<KeySetUserStatus> userListStatus)
        {
            return NetworkCloudBareMetalMachineKeySetData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, etag: etag, extendedLocation: extendedLocation, azureGroupId: azureGroupId, detailedStatus: detailedStatus, detailedStatusMessage: detailedStatusMessage, expireOn: expireOn, jumpHostsAllowed: jumpHostsAllowed, lastValidatedOn: lastValidatedOn, osGroupName: osGroupName, privilegeLevel: privilegeLevel, privilegeLevelName: default, provisioningState: provisioningState, userList: userList, userListStatus: userListStatus);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Resource ETag. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="adminUsername"> The name of the administrator to which the ssh public keys will be added into the authorized keys. </param>
        /// <param name="availabilityZone"> The cluster availability zone containing this virtual machine. </param>
        /// <param name="bareMetalMachineId"> The resource ID of the bare metal machine that hosts the virtual machine. </param>
        /// <param name="bootMethod"> Selects the boot method for the virtual machine. </param>
        /// <param name="cloudServicesNetworkAttachment"> The cloud service network that provides platform-level services for the virtual machine. </param>
        /// <param name="clusterId"> The resource ID of the cluster the virtual machine is created for. </param>
        /// <param name="consoleExtendedLocation"> The extended location to use for creation of a VM console resource. </param>
        /// <param name="cpuCores"> The number of CPU cores in the virtual machine. </param>
        /// <param name="detailedStatus"> The more detailed status of the virtual machine. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="isolateEmulatorThread"> Field Deprecated, the value will be ignored if provided. The indicator of whether one of the specified CPU cores is isolated to run the emulator thread for this virtual machine. </param>
        /// <param name="memorySizeInGB"> The memory size of the virtual machine. Allocations are measured in gibibytes. </param>
        /// <param name="networkAttachments"> The list of network attachments to the virtual machine. </param>
        /// <param name="networkData"> The Base64 encoded cloud-init network data. </param>
        /// <param name="placementHints"> The scheduling hints for the virtual machine. </param>
        /// <param name="powerState"> The power state of the virtual machine. </param>
        /// <param name="provisioningState"> The provisioning state of the virtual machine. </param>
        /// <param name="sshPublicKeys"> The list of ssh public keys. Each key will be added to the virtual machine using the cloud-init ssh_authorized_keys mechanism for the adminUsername. </param>
        /// <param name="storageProfile"> The storage profile that specifies size and other parameters about the disks related to the virtual machine. </param>
        /// <param name="userData"> The Base64 encoded cloud-init user data. </param>
        /// <param name="virtioInterface"> Field Deprecated, use virtualizationModel instead. The type of the virtio interface. </param>
        /// <param name="vmDeviceModel"> The type of the device model to use. </param>
        /// <param name="vmImage"> The virtual machine image that is currently provisioned to the OS disk, using the full url and tag notation used to pull the image. </param>
        /// <param name="vmImageRepositoryCredentials"> The credentials used to login to the image repository that has access to the specified image. </param>
        /// <param name="volumes"> The resource IDs of volumes that are attached to the virtual machine. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudVirtualMachineData NetworkCloudVirtualMachineData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, ExtendedLocation extendedLocation, string adminUsername, string availabilityZone, ResourceIdentifier bareMetalMachineId, VirtualMachineBootMethod? bootMethod, NetworkAttachment cloudServicesNetworkAttachment, ResourceIdentifier clusterId, ExtendedLocation consoleExtendedLocation, long cpuCores, VirtualMachineDetailedStatus? detailedStatus, string detailedStatusMessage, VirtualMachineIsolateEmulatorThread? isolateEmulatorThread, long memorySizeInGB, IEnumerable<NetworkAttachment> networkAttachments, string networkData, IEnumerable<VirtualMachinePlacementHint> placementHints, VirtualMachinePowerState? powerState, VirtualMachineProvisioningState? provisioningState, IEnumerable<NetworkCloudSshPublicKey> sshPublicKeys, NetworkCloudStorageProfile storageProfile, string userData, VirtualMachineVirtioInterfaceType? virtioInterface, VirtualMachineDeviceModelType? vmDeviceModel, string vmImage, ImageRepositoryCredentials vmImageRepositoryCredentials, IEnumerable<ResourceIdentifier> volumes)
        {
            return NetworkCloudVirtualMachineData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, etag: etag, extendedLocation: extendedLocation, identity: default, adminUsername: adminUsername, availabilityZone: availabilityZone, bareMetalMachineId: bareMetalMachineId, bootMethod: bootMethod, cloudServicesNetworkAttachment: cloudServicesNetworkAttachment, clusterId: clusterId, consoleExtendedLocation: consoleExtendedLocation, cpuCores: cpuCores, detailedStatus: detailedStatus, detailedStatusMessage: detailedStatusMessage, isolateEmulatorThread: isolateEmulatorThread, memorySizeInGB: memorySizeInGB, networkAttachments: networkAttachments, networkData: networkData, networkDataContent: default, placementHints: placementHints, powerState: powerState, provisioningState: provisioningState, sshPublicKeys: sshPublicKeys, storageProfile: storageProfile, userData: userData, userDataContent: default, virtioInterface: virtioInterface, vmDeviceModel: vmDeviceModel, vmImage: vmImage, vmImageRepositoryCredentials: vmImageRepositoryCredentials, volumes: volumes);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="associatedResourceIds"> The list of resource IDs for the other Microsoft.NetworkCloud resources that have attached this network. </param>
        /// <param name="clusterId"> The resource ID of the Network Cloud cluster this trunked network is associated with. </param>
        /// <param name="detailedStatus"> The more detailed status of the trunked network. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="hybridAksClustersAssociatedIds"> Field Deprecated. These fields will be empty/omitted. The list of Hybrid AKS cluster resource IDs that are associated with this trunked network. </param>
        /// <param name="hybridAksPluginType"> Field Deprecated. The field was previously optional, now it will have no defined behavior and will be ignored. The network plugin type for Hybrid AKS. </param>
        /// <param name="interfaceName"> The default interface name for this trunked network in the virtual machine. This name can be overridden by the name supplied in the network attachment configuration of that virtual machine. </param>
        /// <param name="isolationDomainIds"> The list of resource IDs representing the Network Fabric isolation domains. It can be any combination of l2IsolationDomain and l3IsolationDomain resources. </param>
        /// <param name="provisioningState"> The provisioning state of the trunked network. </param>
        /// <param name="virtualMachinesAssociatedIds"> Field Deprecated. These fields will be empty/omitted. The list of virtual machine resource IDs, excluding any Hybrid AKS virtual machines, that are currently using this trunked network. </param>
        /// <param name="vlans"> The list of vlans that are selected from the isolation domains for trunking. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudTrunkedNetworkData NetworkCloudTrunkedNetworkData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, IEnumerable<string> associatedResourceIds, ResourceIdentifier clusterId, TrunkedNetworkDetailedStatus? detailedStatus, string detailedStatusMessage, IEnumerable<ResourceIdentifier> hybridAksClustersAssociatedIds, HybridAksPluginType? hybridAksPluginType, string interfaceName, IEnumerable<ResourceIdentifier> isolationDomainIds, TrunkedNetworkProvisioningState? provisioningState, IEnumerable<ResourceIdentifier> virtualMachinesAssociatedIds, IEnumerable<long> vlans)
        {
            return NetworkCloudTrunkedNetworkData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, etag: default, extendedLocation: extendedLocation, associatedResourceIds: associatedResourceIds, clusterId: clusterId, detailedStatus: detailedStatus, detailedStatusMessage: detailedStatusMessage, hybridAksClustersAssociatedIds: hybridAksClustersAssociatedIds, hybridAksPluginType: hybridAksPluginType, interfaceName: interfaceName, isolationDomainIds: isolationDomainIds, provisioningState: provisioningState, virtualMachinesAssociatedIds: virtualMachinesAssociatedIds, vlans: vlans);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudRackData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="availabilityZone"> The value that will be used for machines in this rack to represent the availability zones that can be referenced by Hybrid AKS Clusters for node arrangement. </param>
        /// <param name="clusterId"> The resource ID of the cluster the rack is created for. This value is set when the rack is created by the cluster. </param>
        /// <param name="detailedStatus"> The more detailed status of the rack. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="provisioningState"> The provisioning state of the rack resource. </param>
        /// <param name="rackLocation"> The free-form description of the rack location. (e.g. “DTN Datacenter, Floor 3, Isle 9, Rack 2B”). </param>
        /// <param name="rackSerialNumber"> The unique identifier for the rack within Network Cloud cluster. An alternate unique alphanumeric value other than a serial number may be provided if desired. </param>
        /// <param name="rackSkuId"> The SKU for the rack. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudRackData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudRackData NetworkCloudRackData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, string availabilityZone, ResourceIdentifier clusterId, RackDetailedStatus? detailedStatus, string detailedStatusMessage, RackProvisioningState? provisioningState, string rackLocation, string rackSerialNumber, ResourceIdentifier rackSkuId)
        {
            return NetworkCloudRackData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, etag: default, extendedLocation: extendedLocation, availabilityZone: availabilityZone, clusterId: clusterId, detailedStatus: detailedStatus, detailedStatusMessage: detailedStatusMessage, provisioningState: provisioningState, rackLocation: rackLocation, rackSerialNumber: rackSerialNumber, rackSkuId: rackSkuId);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="associatedResourceIds"> The list of resource IDs for the other Microsoft.NetworkCloud resources that have attached this network. </param>
        /// <param name="clusterId"> The resource ID of the Network Cloud cluster this L2 network is associated with. </param>
        /// <param name="detailedStatus"> The more detailed status of the L2 network. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="hybridAksClustersAssociatedIds"> Field Deprecated. These fields will be empty/omitted. The list of Hybrid AKS cluster resource ID(s) that are associated with this L2 network. </param>
        /// <param name="hybridAksPluginType"> Field Deprecated. The field was previously optional, now it will have no defined behavior and will be ignored. The network plugin type for Hybrid AKS. </param>
        /// <param name="interfaceName"> The default interface name for this L2 network in the virtual machine. This name can be overridden by the name supplied in the network attachment configuration of that virtual machine. </param>
        /// <param name="l2IsolationDomainId"> The resource ID of the Network Fabric l2IsolationDomain. </param>
        /// <param name="provisioningState"> The provisioning state of the L2 network. </param>
        /// <param name="virtualMachinesAssociatedIds"> Field Deprecated. These fields will be empty/omitted. The list of virtual machine resource ID(s), excluding any Hybrid AKS virtual machines, that are currently using this L2 network. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudL2NetworkData NetworkCloudL2NetworkData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, IEnumerable<ResourceIdentifier> associatedResourceIds, ResourceIdentifier clusterId, L2NetworkDetailedStatus? detailedStatus, string detailedStatusMessage, IEnumerable<ResourceIdentifier> hybridAksClustersAssociatedIds, HybridAksPluginType? hybridAksPluginType, string interfaceName, ResourceIdentifier l2IsolationDomainId, L2NetworkProvisioningState? provisioningState, IEnumerable<ResourceIdentifier> virtualMachinesAssociatedIds)
        {
            return NetworkCloudL2NetworkData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, etag: default, extendedLocation: extendedLocation, associatedResourceIds: associatedResourceIds, clusterId: clusterId, detailedStatus: detailedStatus, detailedStatusMessage: detailedStatusMessage, hybridAksClustersAssociatedIds: hybridAksClustersAssociatedIds, hybridAksPluginType: hybridAksPluginType, interfaceName: interfaceName, l2IsolationDomainId: l2IsolationDomainId, provisioningState: provisioningState, virtualMachinesAssociatedIds: virtualMachinesAssociatedIds);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="aadAdminGroupObjectIds"> The Azure Active Directory Integration properties. </param>
        /// <param name="administratorConfiguration"> The administrative credentials that will be applied to the control plane and agent pool nodes that do not specify their own values. </param>
        /// <param name="attachedNetworkIds"> The full list of network resource IDs that are attached to this cluster, including those attached only to specific agent pools. </param>
        /// <param name="availableUpgrades"> The list of versions that this Kubernetes cluster can be upgraded to. </param>
        /// <param name="clusterId"> The resource ID of the Network Cloud cluster. </param>
        /// <param name="connectedClusterId"> The resource ID of the connected cluster set up when this Kubernetes cluster is created. </param>
        /// <param name="controlPlaneKubernetesVersion"> The current running version of Kubernetes on the control plane. </param>
        /// <param name="controlPlaneNodeConfiguration"> The defining characteristics of the control plane for this Kubernetes Cluster. </param>
        /// <param name="detailedStatus"> The current status of the Kubernetes cluster. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="featureStatuses"> The current feature settings. </param>
        /// <param name="initialAgentPoolConfigurations"> The agent pools that are created with this Kubernetes cluster for running critical system services and workloads. This data in this field is only used during creation, and the field will be empty following the creation of the Kubernetes Cluster. After creation, the management of agent pools is done using the agentPools sub-resource. </param>
        /// <param name="kubernetesVersion"> The Kubernetes version for this cluster. </param>
        /// <param name="managedResourceGroupConfiguration"> The configuration of the managed resource group associated with the resource. </param>
        /// <param name="networkConfiguration"> The configuration of the Kubernetes cluster networking, including the attachment of networks that span the cluster. </param>
        /// <param name="nodes"> The details of the nodes in this cluster. </param>
        /// <param name="provisioningState"> The provisioning state of the Kubernetes cluster resource. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudKubernetesClusterData NetworkCloudKubernetesClusterData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, IEnumerable<string> aadAdminGroupObjectIds, AdministratorConfiguration administratorConfiguration, IEnumerable<ResourceIdentifier> attachedNetworkIds, IEnumerable<AvailableUpgrade> availableUpgrades, ResourceIdentifier clusterId, ResourceIdentifier connectedClusterId, string controlPlaneKubernetesVersion, ControlPlaneNodeConfiguration controlPlaneNodeConfiguration, KubernetesClusterDetailedStatus? detailedStatus, string detailedStatusMessage, IEnumerable<FeatureStatus> featureStatuses, IEnumerable<InitialAgentPoolConfiguration> initialAgentPoolConfigurations, string kubernetesVersion, ManagedResourceGroupConfiguration managedResourceGroupConfiguration, KubernetesClusterNetworkConfiguration networkConfiguration, IEnumerable<KubernetesClusterNode> nodes, KubernetesClusterProvisioningState? provisioningState)
        {
            return NetworkCloudKubernetesClusterData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, etag: default, extendedLocation: extendedLocation, aadAdminGroupObjectIds: aadAdminGroupObjectIds, administratorConfiguration: administratorConfiguration, attachedNetworkIds: attachedNetworkIds, availableUpgrades: availableUpgrades, clusterId: clusterId, connectedClusterId: connectedClusterId, controlPlaneKubernetesVersion: controlPlaneKubernetesVersion, controlPlaneNodeConfiguration: controlPlaneNodeConfiguration, detailedStatus: detailedStatus, detailedStatusMessage: detailedStatusMessage, featureStatuses: featureStatuses, initialAgentPoolConfigurations: initialAgentPoolConfigurations, kubernetesVersion: kubernetesVersion, managedResourceGroupConfiguration: managedResourceGroupConfiguration, networkConfiguration: networkConfiguration, nodes: nodes, provisioningState: provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Resource ETag. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="additionalEgressEndpoints"> The list of egress endpoints. This allows for connection from a Hybrid AKS cluster to the specified endpoint. </param>
        /// <param name="associatedResourceIds"> The list of resource IDs for the other Microsoft.NetworkCloud resources that have attached this network. </param>
        /// <param name="clusterId"> The resource ID of the Network Cloud cluster this cloud services network is associated with. </param>
        /// <param name="detailedStatus"> The more detailed status of the cloud services network. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="enableDefaultEgressEndpoints"> The indicator of whether the platform default endpoints are allowed for the egress traffic. </param>
        /// <param name="enabledEgressEndpoints"> The full list of additional and default egress endpoints that are currently enabled. </param>
        /// <param name="hybridAksClustersAssociatedIds"> Field Deprecated. These fields will be empty/omitted. The list of Hybrid AKS cluster resource IDs that are associated with this cloud services network. </param>
        /// <param name="interfaceName"> The name of the interface that will be present in the virtual machine to represent this network. </param>
        /// <param name="provisioningState"> The provisioning state of the cloud services network. </param>
        /// <param name="virtualMachinesAssociatedIds"> Field Deprecated. These fields will be empty/omitted. The list of virtual machine resource IDs, excluding any Hybrid AKS virtual machines, that are currently using this cloud services network. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudCloudServicesNetworkData NetworkCloudCloudServicesNetworkData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, ExtendedLocation extendedLocation, IEnumerable<EgressEndpoint> additionalEgressEndpoints, IEnumerable<ResourceIdentifier> associatedResourceIds, ResourceIdentifier clusterId, CloudServicesNetworkDetailedStatus? detailedStatus, string detailedStatusMessage, CloudServicesNetworkEnableDefaultEgressEndpoint? enableDefaultEgressEndpoints, IEnumerable<EgressEndpoint> enabledEgressEndpoints, IEnumerable<ResourceIdentifier> hybridAksClustersAssociatedIds, string interfaceName, CloudServicesNetworkProvisioningState? provisioningState, IEnumerable<ResourceIdentifier> virtualMachinesAssociatedIds)
        {
            return NetworkCloudCloudServicesNetworkData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, etag: etag, extendedLocation: extendedLocation, additionalEgressEndpoints: additionalEgressEndpoints, associatedResourceIds: associatedResourceIds, clusterId: clusterId, detailedStatus: detailedStatus, detailedStatusMessage: detailedStatusMessage, enableDefaultEgressEndpoints: enableDefaultEgressEndpoints, enabledEgressEndpoints: enabledEgressEndpoints, hybridAksClustersAssociatedIds: hybridAksClustersAssociatedIds, interfaceName: interfaceName, provisioningState: provisioningState, storageOptions: default, storageStatus: default, virtualMachinesAssociatedIds: virtualMachinesAssociatedIds);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="adminUsername"> The name of the administrator to which the ssh public keys will be added into the authorized keys. </param>
        /// <param name="availabilityZone"> The cluster availability zone containing this virtual machine. </param>
        /// <param name="bareMetalMachineId"> The resource ID of the bare metal machine that hosts the virtual machine. </param>
        /// <param name="bootMethod"> Selects the boot method for the virtual machine. </param>
        /// <param name="cloudServicesNetworkAttachment"> The cloud service network that provides platform-level services for the virtual machine. </param>
        /// <param name="clusterId"> The resource ID of the cluster the virtual machine is created for. </param>
        /// <param name="cpuCores"> The number of CPU cores in the virtual machine. </param>
        /// <param name="detailedStatus"> The more detailed status of the virtual machine. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="isolateEmulatorThread"> Field Deprecated, the value will be ignored if provided. The indicator of whether one of the specified CPU cores is isolated to run the emulator thread for this virtual machine. </param>
        /// <param name="memorySizeInGB"> The memory size of the virtual machine. Allocations are measured in gibibytes. </param>
        /// <param name="networkAttachments"> The list of network attachments to the virtual machine. </param>
        /// <param name="networkData"> The Base64 encoded cloud-init network data. </param>
        /// <param name="placementHints"> The scheduling hints for the virtual machine. </param>
        /// <param name="powerState"> The power state of the virtual machine. </param>
        /// <param name="provisioningState"> The provisioning state of the virtual machine. </param>
        /// <param name="sshPublicKeys"> The list of ssh public keys. Each key will be added to the virtual machine using the cloud-init ssh_authorized_keys mechanism for the adminUsername. </param>
        /// <param name="storageProfile"> The storage profile that specifies size and other parameters about the disks related to the virtual machine. </param>
        /// <param name="userData"> The Base64 encoded cloud-init user data. </param>
        /// <param name="virtioInterface"> Field Deprecated, use virtualizationModel instead. The type of the virtio interface. </param>
        /// <param name="vmDeviceModel"> The type of the device model to use. </param>
        /// <param name="vmImage"> The virtual machine image that is currently provisioned to the OS disk, using the full url and tag notation used to pull the image. </param>
        /// <param name="vmImageRepositoryCredentials"> The credentials used to login to the image repository that has access to the specified image. </param>
        /// <param name="volumes"> The resource IDs of volumes that are attached to the virtual machine. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudVirtualMachineData NetworkCloudVirtualMachineData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, string adminUsername, string availabilityZone, ResourceIdentifier bareMetalMachineId, VirtualMachineBootMethod? bootMethod, NetworkAttachment cloudServicesNetworkAttachment, ResourceIdentifier clusterId, long cpuCores, VirtualMachineDetailedStatus? detailedStatus, string detailedStatusMessage, VirtualMachineIsolateEmulatorThread? isolateEmulatorThread, long memorySizeInGB, IEnumerable<NetworkAttachment> networkAttachments, string networkData, IEnumerable<VirtualMachinePlacementHint> placementHints, VirtualMachinePowerState? powerState, VirtualMachineProvisioningState? provisioningState, IEnumerable<NetworkCloudSshPublicKey> sshPublicKeys, NetworkCloudStorageProfile storageProfile, string userData, VirtualMachineVirtioInterfaceType? virtioInterface, VirtualMachineDeviceModelType? vmDeviceModel, string vmImage, ImageRepositoryCredentials vmImageRepositoryCredentials, IEnumerable<ResourceIdentifier> volumes)
        {
            return NetworkCloudVirtualMachineData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, etag: default, extendedLocation: extendedLocation, identity: default, adminUsername: adminUsername, availabilityZone: availabilityZone, bareMetalMachineId: bareMetalMachineId, bootMethod: bootMethod, cloudServicesNetworkAttachment: cloudServicesNetworkAttachment, clusterId: clusterId, consoleExtendedLocation: default, cpuCores: cpuCores, detailedStatus: detailedStatus, detailedStatusMessage: detailedStatusMessage, isolateEmulatorThread: isolateEmulatorThread, memorySizeInGB: memorySizeInGB, networkAttachments: networkAttachments, networkData: networkData, networkDataContent: default, placementHints: placementHints, powerState: powerState, provisioningState: provisioningState, sshPublicKeys: sshPublicKeys, storageProfile: storageProfile, userData: userData, userDataContent: default, virtioInterface: virtioInterface, vmDeviceModel: vmDeviceModel, vmImage: vmImage, vmImageRepositoryCredentials: vmImageRepositoryCredentials, volumes: volumes);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudCloudServicesNetworkData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="additionalEgressEndpoints"> The list of egress endpoints. This allows for connection from a Hybrid AKS cluster to the specified endpoint. </param>
        /// <param name="associatedResourceIds"> The list of resource IDs for the other Microsoft.NetworkCloud resources that have attached this network. </param>
        /// <param name="clusterId"> The resource ID of the Network Cloud cluster this cloud services network is associated with. </param>
        /// <param name="detailedStatus"> The more detailed status of the cloud services network. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="enableDefaultEgressEndpoints"> The indicator of whether the platform default endpoints are allowed for the egress traffic. </param>
        /// <param name="enabledEgressEndpoints"> The full list of additional and default egress endpoints that are currently enabled. </param>
        /// <param name="hybridAksClustersAssociatedIds"> Field Deprecated. These fields will be empty/omitted. The list of Hybrid AKS cluster resource IDs that are associated with this cloud services network. </param>
        /// <param name="interfaceName"> The name of the interface that will be present in the virtual machine to represent this network. </param>
        /// <param name="provisioningState"> The provisioning state of the cloud services network. </param>
        /// <param name="virtualMachinesAssociatedIds"> Field Deprecated. These fields will be empty/omitted. The list of virtual machine resource IDs, excluding any Hybrid AKS virtual machines, that are currently using this cloud services network. </param>
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudCloudServicesNetworkData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudCloudServicesNetworkData NetworkCloudCloudServicesNetworkData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, IEnumerable<EgressEndpoint> additionalEgressEndpoints, IEnumerable<ResourceIdentifier> associatedResourceIds, ResourceIdentifier clusterId, CloudServicesNetworkDetailedStatus? detailedStatus, string detailedStatusMessage, CloudServicesNetworkEnableDefaultEgressEndpoint? enableDefaultEgressEndpoints, IEnumerable<EgressEndpoint> enabledEgressEndpoints, IEnumerable<ResourceIdentifier> hybridAksClustersAssociatedIds, string interfaceName, CloudServicesNetworkProvisioningState? provisioningState, IEnumerable<ResourceIdentifier> virtualMachinesAssociatedIds)
        {
            return NetworkCloudCloudServicesNetworkData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, etag: default, extendedLocation: extendedLocation, additionalEgressEndpoints: additionalEgressEndpoints, associatedResourceIds: associatedResourceIds, clusterId: clusterId, detailedStatus: detailedStatus, detailedStatusMessage: detailedStatusMessage, enableDefaultEgressEndpoints: enableDefaultEgressEndpoints, enabledEgressEndpoints: enabledEgressEndpoints, hybridAksClustersAssociatedIds: hybridAksClustersAssociatedIds, interfaceName: interfaceName, provisioningState: provisioningState, storageOptions: default, storageStatus: default, virtualMachinesAssociatedIds: virtualMachinesAssociatedIds);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudBareMetalMachineKeySetData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="azureGroupId"> The object ID of Azure Active Directory group that all users in the list must be in for access to be granted. Users that are not in the group will not have access. </param>
        /// <param name="detailedStatus"> The more detailed status of the key set. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="expireOn"> The date and time after which the users in this key set will be removed from the bare metal machines. </param>
        /// <param name="jumpHostsAllowed"> The list of IP addresses of jump hosts with management network access from which a login will be allowed for the users. </param>
        /// <param name="lastValidatedOn"> The last time this key set was validated. </param>
        /// <param name="osGroupName"> The name of the group that users will be assigned to on the operating system of the machines. </param>
        /// <param name="privilegeLevel"> The access level allowed for the users in this key set. </param>
        /// <param name="provisioningState"> The provisioning state of the bare metal machine key set. </param>
        /// <param name="userList"> The unique list of permitted users. </param>
        /// <param name="userListStatus"> The status evaluation of each user. </param>
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudBareMetalMachineKeySetData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudBareMetalMachineKeySetData NetworkCloudBareMetalMachineKeySetData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, string azureGroupId, BareMetalMachineKeySetDetailedStatus? detailedStatus, string detailedStatusMessage, DateTimeOffset expireOn, IEnumerable<IPAddress> jumpHostsAllowed, DateTimeOffset? lastValidatedOn, string osGroupName, BareMetalMachineKeySetPrivilegeLevel privilegeLevel, BareMetalMachineKeySetProvisioningState? provisioningState, IEnumerable<KeySetUser> userList, IEnumerable<KeySetUserStatus> userListStatus)
        {
            return NetworkCloudBareMetalMachineKeySetData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, etag: default, extendedLocation: extendedLocation, azureGroupId: azureGroupId, detailedStatus: detailedStatus, detailedStatusMessage: detailedStatusMessage, expireOn: expireOn, jumpHostsAllowed: jumpHostsAllowed, lastValidatedOn: lastValidatedOn, osGroupName: osGroupName, privilegeLevel: privilegeLevel, privilegeLevelName: default, provisioningState: provisioningState, userList: userList, userListStatus: userListStatus);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudVolumeData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Resource ETag. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="attachedTo"> The list of resource IDs that attach the volume. It may include virtual machines and Hybrid AKS clusters. </param>
        /// <param name="detailedStatus"> The more detailed status of the volume. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="provisioningState"> The provisioning state of the volume. </param>
        /// <param name="serialNumber"> The unique identifier of the volume. </param>
        /// <param name="sizeInMiB"> The size of the allocation for this volume in Mebibytes. </param>
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudVolumeData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudVolumeData NetworkCloudVolumeData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, ExtendedLocation extendedLocation, IEnumerable<string> attachedTo, VolumeDetailedStatus? detailedStatus, string detailedStatusMessage, VolumeProvisioningState? provisioningState, string serialNumber, long sizeInMiB)
        {
            return NetworkCloudVolumeData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, etag: etag, extendedLocation: extendedLocation, allocatedInSizeMiB: default, attachedTo: attachedTo, detailedStatus: detailedStatus, detailedStatusMessage: detailedStatusMessage, provisioningState: provisioningState, serialNumber: serialNumber, sizeInMiB: sizeInMiB, storageApplianceId: default);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudVolumeData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="attachedTo"> The list of resource IDs that attach the volume. It may include virtual machines and Hybrid AKS clusters. </param>
        /// <param name="detailedStatus"> The more detailed status of the volume. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="provisioningState"> The provisioning state of the volume. </param>
        /// <param name="serialNumber"> The unique identifier of the volume. </param>
        /// <param name="sizeInMiB"> The size of the allocation for this volume in Mebibytes. </param>
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudVolumeData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudVolumeData NetworkCloudVolumeData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, IEnumerable<string> attachedTo, VolumeDetailedStatus? detailedStatus, string detailedStatusMessage, VolumeProvisioningState? provisioningState, string serialNumber, long sizeInMiB)
        {
            return NetworkCloudVolumeData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, etag: default, extendedLocation: extendedLocation, allocatedInSizeMiB: default, attachedTo: attachedTo, detailedStatus: detailedStatus, detailedStatusMessage: detailedStatusMessage, provisioningState: provisioningState, serialNumber: serialNumber, sizeInMiB: sizeInMiB, storageApplianceId: default);
        }
    }
}
