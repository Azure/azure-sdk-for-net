// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmContainerServiceModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterAccessProfile"/> for mocking. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="systemData"> Azure Resource Manager metadata. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="kubeConfig"> Base64-encoded Kubernetes configuration file. </param>
        /// <returns> A new <see cref="Models.ManagedClusterAccessProfile"/> instance for mocking. </returns>
        public static ManagedClusterAccessProfile ManagedClusterAccessProfile(
            ResourceIdentifier id = null,
            string name = null,
            ResourceType resourceType = default,
            SystemData systemData = null,
            IDictionary<string, string> tags = null,
            AzureLocation location = default,
            byte[] kubeConfig = null)
        {
            return new ManagedClusterAccessProfile(
                id,
                name,
                resourceType,
                systemData,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                kubeConfig is null ? null : new AccessProfile(kubeConfig, null),
                null);
        }

        /// <summary> Initializes a new instance of <see cref="ContainerService.ContainerServiceAgentPoolData"/> for mocking. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="eTag"> Unique read-only string used to implement optimistic concurrency. The eTag value will change when the resource is updated. Specify an if-match or if-none-match header with the eTag value for a subsequent request to enable optimistic concurrency per the normal eTag convention. </param>
        /// <param name="count"> Number of agents (VMs) to host docker containers. Allowed values must be in the range of 0 to 1000 (inclusive) for user pools and in the range of 1 to 1000 (inclusive) for system pools. The default value is 1. </param>
        /// <param name="vmSize"> The size of the agent pool VMs. VM size availability varies by region. If a node contains insufficient compute resources (memory, cpu, etc) pods might fail to run correctly. For more details on restricted VM sizes, see: https://docs.microsoft.com/azure/aks/quotas-skus-regions. </param>
        /// <param name="osDiskSizeInGB"> OS Disk Size in GB to be used to specify the disk size for every machine in the master/agent pool. If you specify 0, it will apply the default osDisk size according to the vmSize specified. </param>
        /// <param name="osDiskType"> The OS disk type to be used for machines in the agent pool. The default is 'Ephemeral' if the VM supports it and has a cache disk larger than the requested OSDiskSizeGB. Otherwise, defaults to 'Managed'. May not be changed after creation. For more information see [Ephemeral OS](https://docs.microsoft.com/azure/aks/cluster-configuration#ephemeral-os). </param>
        /// <param name="kubeletDiskType"> Determines the placement of emptyDir volumes, container runtime data root, and Kubelet ephemeral storage. </param>
        /// <param name="workloadRuntime"> Determines the type of workload a node can run. </param>
        /// <param name="messageOfTheDay"> Message of the day for Linux nodes, base64-encoded. A base64-encoded string which will be written to /etc/motd after decoding. This allows customization of the message of the day for Linux nodes. It must not be specified for Windows nodes. It must be a static string (i.e., will be printed raw and not be executed as a script). </param>
        /// <param name="vnetSubnetId"> The ID of the subnet which agent pool nodes and optionally pods will join on startup. If this is not specified, a VNET and subnet will be generated and used. If no podSubnetID is specified, this applies to nodes and pods, otherwise it applies to just nodes. This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}. </param>
        /// <param name="podSubnetId"> The ID of the subnet which pods will join when launched. If omitted, pod IPs are statically assigned on the node subnet (see vnetSubnetID for more details). This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}. </param>
        /// <param name="podIPAllocationMode"> Pod IP Allocation Mode. The IP allocation mode for pods in the agent pool. Must be used with podSubnetId. The default is 'DynamicIndividual'. </param>
        /// <param name="maxPods"> The maximum number of pods that can run on a node. </param>
        /// <param name="osType"> The operating system type. The default is Linux. </param>
        /// <param name="osSku"> Specifies the OS SKU used by the agent pool. The default is Ubuntu if OSType is Linux. The default is Windows2019 when Kubernetes &lt;= 1.24 or Windows2022 when Kubernetes &gt;= 1.25 if OSType is Windows. </param>
        /// <param name="maxCount"> The maximum number of nodes for auto-scaling. </param>
        /// <param name="minCount"> The minimum number of nodes for auto-scaling. </param>
        /// <param name="isAutoScalingEnabled"> Whether to enable auto-scaler. </param>
        /// <param name="scaleDownMode"> The scale down mode to use when scaling the Agent Pool. This also effects the cluster autoscaler behavior. If not specified, it defaults to Delete. </param>
        /// <param name="agentPoolType"> The type of Agent Pool. </param>
        /// <param name="mode"> The mode of an agent pool. A cluster must have at least one 'System' Agent Pool at all times. For additional information on agent pool restrictions and best practices, see: https://docs.microsoft.com/azure/aks/use-system-pools. </param>
        /// <param name="orchestratorVersion"> The version of Kubernetes specified by the user. Both patch version &lt;major.minor.patch&gt; (e.g. 1.20.13) and &lt;major.minor&gt; (e.g. 1.20) are supported. When &lt;major.minor&gt; is specified, the latest supported GA patch version is chosen automatically. Updating the cluster with the same &lt;major.minor&gt; once it has been created (e.g. 1.14.x -&gt; 1.14) will not trigger an upgrade, even if a newer patch version is available. As a best practice, you should upgrade all node pools in an AKS cluster to the same Kubernetes version. The node pool version must have the same major version as the control plane. The node pool minor version must be within two minor versions of the control plane version. The node pool version cannot be greater than the control plane version. For more information see [upgrading a node pool](https://docs.microsoft.com/azure/aks/use-multiple-node-pools#upgrade-a-node-pool). </param>
        /// <param name="currentOrchestratorVersion"> The version of Kubernetes the Agent Pool is running. If orchestratorVersion is a fully specified version &lt;major.minor.patch&gt;, this field will be exactly equal to it. If orchestratorVersion is &lt;major.minor&gt;, this field will contain the full &lt;major.minor.patch&gt; version being used. </param>
        /// <param name="nodeImageVersion">
        /// The version of the node image. Setting this value triggers an agentPool rollback.
        /// Only values from `recentlyUsedVersions` are allowed.
        /// </param>
        /// <param name="upgradeSettings"> Settings for upgrading the agentpool. </param>
        /// <param name="provisioningState"> The current deployment or provisioning state. </param>
        /// <param name="availabilityZones"> The list of Availability zones to use for nodes. This can only be specified if the AgentPoolType property is 'VirtualMachineScaleSets'. </param>
        /// <param name="isNodePublicIpEnabled"> Whether each node is allocated its own public IP. Some scenarios may require nodes in a node pool to receive their own dedicated public IP addresses. A common scenario is for gaming workloads, where a console needs to make a direct connection to a cloud virtual machine to minimize hops. For more information see [assigning a public IP per node](https://docs.microsoft.com/azure/aks/use-multiple-node-pools#assign-a-public-ip-per-node-for-your-node-pools). The default is false. </param>
        /// <param name="nodePublicIPPrefixId"> The public IP prefix ID which VM nodes should use IPs from. This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPPrefixes/{publicIPPrefixName}. </param>
        /// <param name="scaleSetPriority"> The Virtual Machine Scale Set priority. </param>
        /// <param name="scaleSetEvictionPolicy"> The Virtual Machine Scale Set eviction policy. The eviction policy specifies what to do with the VM when it is evicted. The default is Delete. For more information about eviction see [spot VMs](https://docs.microsoft.com/azure/virtual-machines/spot-vms). </param>
        /// <param name="spotMaxPrice"> The max price (in US Dollars) you are willing to pay for spot instances. Possible values are any decimal value greater than zero or -1 which indicates default price to be up-to on-demand. Possible values are any decimal value greater than zero or -1 which indicates the willingness to pay any on-demand price. For more details on spot pricing, see [spot VMs pricing](https://docs.microsoft.com/azure/virtual-machines/spot-vms#pricing). </param>
        /// <param name="tags"> The tags to be persisted on the agent pool virtual machine scale set. </param>
        /// <param name="nodeLabels"> The node labels to be persisted across all nodes in agent pool. </param>
        /// <param name="nodeTaints"> The taints added to new nodes during node pool create and scale. For example, key=value:NoSchedule. </param>
        /// <param name="proximityPlacementGroupId"> The ID for Proximity Placement Group. </param>
        /// <param name="kubeletConfig"> The Kubelet configuration on the agent pool nodes. </param>
        /// <param name="linuxOSConfig"> The OS configuration of Linux agent nodes. </param>
        /// <param name="isEncryptionAtHostEnabled"> Whether to enable host based OS and data drive encryption. This is only supported on certain VM sizes and in certain Azure regions. For more information, see: https://docs.microsoft.com/azure/aks/enable-host-encryption. </param>
        /// <param name="isUltraSsdEnabled"> Whether to enable UltraSSD. </param>
        /// <param name="isFipsEnabled"> Whether to use a FIPS-enabled OS. See [Add a FIPS-enabled node pool](https://docs.microsoft.com/azure/aks/use-multiple-node-pools#add-a-fips-enabled-node-pool-preview) for more details. </param>
        /// <param name="gpuInstanceProfile"> GPUInstanceProfile to be used to specify GPU MIG instance profile for supported GPU VM SKU. </param>
        /// <param name="capacityReservationGroupId"> The fully qualified resource ID of the Capacity Reservation Group to provide virtual machines from a reserved group of Virtual Machines. This is of the form: '/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Compute/capacityreservationgroups/{capacityReservationGroupName}' Customers use it to create an agentpool with a specified CRG. For more information see [Capacity Reservation](https://learn.microsoft.com/en-us/azure/virtual-machines/capacity-reservation-overview). </param>
        /// <param name="hostGroupId"> The fully qualified resource ID of the Dedicated Host Group to provision virtual machines from, used only in creation scenario and not allowed to changed once set. This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}. For more information see [Azure dedicated hosts](https://docs.microsoft.com/azure/virtual-machines/dedicated-hosts). </param>
        /// <param name="networkProfile"> Network-related settings of an agent pool. </param>
        /// <param name="securityProfile"> The security settings of an agent pool. </param>
        /// <param name="gpuProfile"> GPU settings for the Agent Pool. </param>
        /// <param name="virtualMachineNodesStatus"> The status of nodes in a VirtualMachines agent pool. </param>
        /// <param name="localDnsProfile"> Configures the per-node local DNS, with VnetDNS and KubeDNS overrides. LocalDNS helps improve performance and reliability of DNS resolution in an AKS cluster. For more details see aka.ms/aks/localdns. </param>
        /// <param name="powerStateCode"> Tells whether the cluster is Running or Stopped. </param>
        /// <param name="creationDataSourceResourceId"> This is the ARM ID of the source object to be used to create the target object. </param>
        /// <param name="isOutboundNatDisabled"> Whether to disable OutboundNAT in windows nodes. The default value is false. Outbound NAT can only be disabled if the cluster outboundType is NAT Gateway and the Windows agent pool does not have node public IP enabled. </param>
        /// <param name="gatewayPublicIPPrefixSize"> The Gateway agent pool associates one public IPPrefix for each static egress gateway to provide public egress. The size of Public IPPrefix should be selected by the user. Each node in the agent pool is assigned with one IP from the IPPrefix. The IPPrefix size thus serves as a cap on the size of the Gateway agent pool. Due to Azure public IPPrefix size limitation, the valid value range is [28, 31] (/31 = 2 nodes/IPs, /30 = 4 nodes/IPs, /29 = 8 nodes/IPs, /28 = 16 nodes/IPs). The default value is 31. </param>
        /// <param name="isArtifactStreamingEnabled"> Artifact streaming speeds up the cold-start of containers on a node through on-demand image loading. To use this feature, container images must also enable artifact streaming on ACR. If not specified, the default is false. </param>
        /// <param name="virtualMachinesScale"> Specifications on how to scale a VirtualMachines agent pool. </param>
        /// <param name="statusProvisioningError"> The error detail information of the agent pool. Preserves the detailed info of failure. If there was no error, this field is omitted. </param>
        /// <returns> A new <see cref="ContainerService.ContainerServiceAgentPoolData"/> instance for mocking. </returns>
        public static ContainerServiceAgentPoolData ContainerServiceAgentPoolData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? eTag, int? count, string vmSize, int? osDiskSizeInGB, ContainerServiceOSDiskType? osDiskType, KubeletDiskType? kubeletDiskType, WorkloadRuntime? workloadRuntime, string messageOfTheDay, ResourceIdentifier vnetSubnetId, ResourceIdentifier podSubnetId, PodIPAllocationMode? podIPAllocationMode, int? maxPods, ContainerServiceOSType? osType, ContainerServiceOSSku? osSku, int? maxCount, int? minCount, bool? isAutoScalingEnabled, ScaleDownMode? scaleDownMode, AgentPoolType? agentPoolType, AgentPoolMode? mode, string orchestratorVersion, string currentOrchestratorVersion, string nodeImageVersion, AgentPoolUpgradeSettings upgradeSettings, string provisioningState, IEnumerable<string> availabilityZones, bool? isNodePublicIpEnabled, ResourceIdentifier nodePublicIPPrefixId, ScaleSetPriority? scaleSetPriority, ScaleSetEvictionPolicy? scaleSetEvictionPolicy, float? spotMaxPrice, IDictionary<string, string> tags, IDictionary<string, string> nodeLabels, IEnumerable<string> nodeTaints, ResourceIdentifier proximityPlacementGroupId, KubeletConfig kubeletConfig, LinuxOSConfig linuxOSConfig, bool? isEncryptionAtHostEnabled, bool? isUltraSsdEnabled, bool? isFipsEnabled, GpuInstanceProfile? gpuInstanceProfile, ResourceIdentifier capacityReservationGroupId, ResourceIdentifier hostGroupId, AgentPoolNetworkProfile networkProfile, AgentPoolSecurityProfile securityProfile, AgentPoolGpuProfile gpuProfile, IEnumerable<AgentPoolVirtualMachineNodes> virtualMachineNodesStatus, LocalDnsProfile localDnsProfile, ContainerServiceStateCode? powerStateCode, ResourceIdentifier creationDataSourceResourceId, bool? isOutboundNatDisabled, int? gatewayPublicIPPrefixSize, bool? isArtifactStreamingEnabled, AgentPoolScaleProfile virtualMachinesScale, ResponseError statusProvisioningError)
        {
            return ContainerServiceAgentPoolData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                eTag: eTag,
                count: count,
                vmSize: vmSize,
                osDiskSizeInGB: osDiskSizeInGB,
                osDiskType: osDiskType,
                kubeletDiskType: kubeletDiskType,
                workloadRuntime: workloadRuntime,
                messageOfTheDay: messageOfTheDay,
                vnetSubnetId: vnetSubnetId,
                podSubnetId: podSubnetId,
                podIPAllocationMode: podIPAllocationMode,
                maxPods: maxPods,
                osType: osType,
                osSku: osSku,
                maxCount: maxCount,
                minCount: minCount,
                isAutoScalingEnabled: isAutoScalingEnabled,
                scaleDownMode: scaleDownMode,
                agentPoolType: agentPoolType,
                mode: mode,
                orchestratorVersion: orchestratorVersion,
                currentOrchestratorVersion: currentOrchestratorVersion,
                nodeImageVersion: nodeImageVersion,
                upgradeSettings: upgradeSettings,
                provisioningState: provisioningState,
                availabilityZones: availabilityZones,
                isNodePublicIpEnabled: isNodePublicIpEnabled,
                nodePublicIPPrefixId: nodePublicIPPrefixId,
                scaleSetPriority: scaleSetPriority,
                scaleSetEvictionPolicy: scaleSetEvictionPolicy,
                spotMaxPrice: spotMaxPrice,
                tags: tags,
                nodeLabels: nodeLabels,
                nodeTaints: nodeTaints,
                proximityPlacementGroupId: proximityPlacementGroupId,
                kubeletConfig: kubeletConfig,
                linuxOSConfig: linuxOSConfig,
                isEncryptionAtHostEnabled: isEncryptionAtHostEnabled,
                isUltraSsdEnabled: isUltraSsdEnabled,
                isFipsEnabled: isFipsEnabled,
                gpuInstanceProfile: gpuInstanceProfile,
                capacityReservationGroupId: capacityReservationGroupId,
                hostGroupId: hostGroupId,
                networkProfile: networkProfile,
                securityProfile: securityProfile,
                gpuProfile: gpuProfile,
                virtualMachineNodesStatus: virtualMachineNodesStatus,
                localDnsProfile: localDnsProfile,
                powerStateCode: powerStateCode,
                creationDataSourceResourceId: creationDataSourceResourceId,
                isOutboundNatDisabled: isOutboundNatDisabled,
                gatewayPublicIPPrefixSize: gatewayPublicIPPrefixSize,
                isArtifactStreamingEnabled: isArtifactStreamingEnabled,
                virtualMachinesScale: virtualMachinesScale,
                statusProvisioningError: statusProvisioningError,
                upgradeStrategy: default,
                isOSDiskFullCachingEnabled: default,
                upgradeSettingsBlueGreen: default,
                nodeInitializationTaints: default,
                preparedImageSpecificationId: default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterAgentPoolProfileProperties"/> for mocking. </summary>
        /// <param name="eTag"> Unique read-only string used to implement optimistic concurrency. The eTag value will change when the resource is updated. Specify an if-match or if-none-match header with the eTag value for a subsequent request to enable optimistic concurrency per the normal eTag convention. </param>
        /// <param name="count"> Number of agents (VMs) to host docker containers. Allowed values must be in the range of 0 to 1000 (inclusive) for user pools and in the range of 1 to 1000 (inclusive) for system pools. The default value is 1. </param>
        /// <param name="vmSize"> The size of the agent pool VMs. VM size availability varies by region. If a node contains insufficient compute resources (memory, cpu, etc) pods might fail to run correctly. For more details on restricted VM sizes, see: https://docs.microsoft.com/azure/aks/quotas-skus-regions. </param>
        /// <param name="osDiskSizeInGB"> OS Disk Size in GB to be used to specify the disk size for every machine in the master/agent pool. If you specify 0, it will apply the default osDisk size according to the vmSize specified. </param>
        /// <param name="osDiskType"> The OS disk type to be used for machines in the agent pool. The default is 'Ephemeral' if the VM supports it and has a cache disk larger than the requested OSDiskSizeGB. Otherwise, defaults to 'Managed'. May not be changed after creation. For more information see [Ephemeral OS](https://docs.microsoft.com/azure/aks/cluster-configuration#ephemeral-os). </param>
        /// <param name="kubeletDiskType"> Determines the placement of emptyDir volumes, container runtime data root, and Kubelet ephemeral storage. </param>
        /// <param name="workloadRuntime"> Determines the type of workload a node can run. </param>
        /// <param name="messageOfTheDay"> Message of the day for Linux nodes, base64-encoded. A base64-encoded string which will be written to /etc/motd after decoding. This allows customization of the message of the day for Linux nodes. It must not be specified for Windows nodes. It must be a static string (i.e., will be printed raw and not be executed as a script). </param>
        /// <param name="vnetSubnetId"> The ID of the subnet which agent pool nodes and optionally pods will join on startup. If this is not specified, a VNET and subnet will be generated and used. If no podSubnetID is specified, this applies to nodes and pods, otherwise it applies to just nodes. This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}. </param>
        /// <param name="podSubnetId"> The ID of the subnet which pods will join when launched. If omitted, pod IPs are statically assigned on the node subnet (see vnetSubnetID for more details). This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}. </param>
        /// <param name="podIPAllocationMode"> Pod IP Allocation Mode. The IP allocation mode for pods in the agent pool. Must be used with podSubnetId. The default is 'DynamicIndividual'. </param>
        /// <param name="maxPods"> The maximum number of pods that can run on a node. </param>
        /// <param name="osType"> The operating system type. The default is Linux. </param>
        /// <param name="osSku"> Specifies the OS SKU used by the agent pool. The default is Ubuntu if OSType is Linux. The default is Windows2019 when Kubernetes &lt;= 1.24 or Windows2022 when Kubernetes &gt;= 1.25 if OSType is Windows. </param>
        /// <param name="maxCount"> The maximum number of nodes for auto-scaling. </param>
        /// <param name="minCount"> The minimum number of nodes for auto-scaling. </param>
        /// <param name="isAutoScalingEnabled"> Whether to enable auto-scaler. </param>
        /// <param name="scaleDownMode"> The scale down mode to use when scaling the Agent Pool. This also effects the cluster autoscaler behavior. If not specified, it defaults to Delete. </param>
        /// <param name="agentPoolType"> The type of Agent Pool. </param>
        /// <param name="mode"> The mode of an agent pool. A cluster must have at least one 'System' Agent Pool at all times. For additional information on agent pool restrictions and best practices, see: https://docs.microsoft.com/azure/aks/use-system-pools. </param>
        /// <param name="orchestratorVersion"> The version of Kubernetes specified by the user. Both patch version &lt;major.minor.patch&gt; (e.g. 1.20.13) and &lt;major.minor&gt; (e.g. 1.20) are supported. When &lt;major.minor&gt; is specified, the latest supported GA patch version is chosen automatically. Updating the cluster with the same &lt;major.minor&gt; once it has been created (e.g. 1.14.x -&gt; 1.14) will not trigger an upgrade, even if a newer patch version is available. As a best practice, you should upgrade all node pools in an AKS cluster to the same Kubernetes version. The node pool version must have the same major version as the control plane. The node pool minor version must be within two minor versions of the control plane version. The node pool version cannot be greater than the control plane version. For more information see [upgrading a node pool](https://docs.microsoft.com/azure/aks/use-multiple-node-pools#upgrade-a-node-pool). </param>
        /// <param name="currentOrchestratorVersion"> The version of Kubernetes the Agent Pool is running. If orchestratorVersion is a fully specified version &lt;major.minor.patch&gt;, this field will be exactly equal to it. If orchestratorVersion is &lt;major.minor&gt;, this field will contain the full &lt;major.minor.patch&gt; version being used. </param>
        /// <param name="nodeImageVersion">
        /// The version of the node image. Setting this value triggers an agentPool rollback.
        /// Only values from `recentlyUsedVersions` are allowed.
        /// </param>
        /// <param name="upgradeSettings"> Settings for upgrading the agentpool. </param>
        /// <param name="provisioningState"> The current deployment or provisioning state. </param>
        /// <param name="powerStateCode"> Tells whether the cluster is Running or Stopped. </param>
        /// <param name="availabilityZones"> The list of Availability zones to use for nodes. This can only be specified if the AgentPoolType property is 'VirtualMachineScaleSets'. </param>
        /// <param name="isNodePublicIpEnabled"> Whether each node is allocated its own public IP. Some scenarios may require nodes in a node pool to receive their own dedicated public IP addresses. A common scenario is for gaming workloads, where a console needs to make a direct connection to a cloud virtual machine to minimize hops. For more information see [assigning a public IP per node](https://docs.microsoft.com/azure/aks/use-multiple-node-pools#assign-a-public-ip-per-node-for-your-node-pools). The default is false. </param>
        /// <param name="nodePublicIPPrefixId"> The public IP prefix ID which VM nodes should use IPs from. This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPPrefixes/{publicIPPrefixName}. </param>
        /// <param name="scaleSetPriority"> The Virtual Machine Scale Set priority. </param>
        /// <param name="scaleSetEvictionPolicy"> The Virtual Machine Scale Set eviction policy. The eviction policy specifies what to do with the VM when it is evicted. The default is Delete. For more information about eviction see [spot VMs](https://docs.microsoft.com/azure/virtual-machines/spot-vms). </param>
        /// <param name="spotMaxPrice"> The max price (in US Dollars) you are willing to pay for spot instances. Possible values are any decimal value greater than zero or -1 which indicates default price to be up-to on-demand. Possible values are any decimal value greater than zero or -1 which indicates the willingness to pay any on-demand price. For more details on spot pricing, see [spot VMs pricing](https://docs.microsoft.com/azure/virtual-machines/spot-vms#pricing). </param>
        /// <param name="tags"> The tags to be persisted on the agent pool virtual machine scale set. </param>
        /// <param name="nodeLabels"> The node labels to be persisted across all nodes in agent pool. </param>
        /// <param name="nodeTaints"> The taints added to new nodes during node pool create and scale. For example, key=value:NoSchedule. </param>
        /// <param name="proximityPlacementGroupId"> The ID for Proximity Placement Group. </param>
        /// <param name="kubeletConfig"> The Kubelet configuration on the agent pool nodes. </param>
        /// <param name="linuxOSConfig"> The OS configuration of Linux agent nodes. </param>
        /// <param name="isEncryptionAtHostEnabled"> Whether to enable host based OS and data drive encryption. This is only supported on certain VM sizes and in certain Azure regions. For more information, see: https://docs.microsoft.com/azure/aks/enable-host-encryption. </param>
        /// <param name="isUltraSsdEnabled"> Whether to enable UltraSSD. </param>
        /// <param name="isFipsEnabled"> Whether to use a FIPS-enabled OS. See [Add a FIPS-enabled node pool](https://docs.microsoft.com/azure/aks/use-multiple-node-pools#add-a-fips-enabled-node-pool-preview) for more details. </param>
        /// <param name="gpuInstanceProfile"> GPUInstanceProfile to be used to specify GPU MIG instance profile for supported GPU VM SKU. </param>
        /// <param name="creationDataSourceResourceId"> This is the ARM ID of the source object to be used to create the target object. </param>
        /// <param name="capacityReservationGroupId"> The fully qualified resource ID of the Capacity Reservation Group to provide virtual machines from a reserved group of Virtual Machines. This is of the form: '/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Compute/capacityreservationgroups/{capacityReservationGroupName}' Customers use it to create an agentpool with a specified CRG. For more information see [Capacity Reservation](https://learn.microsoft.com/en-us/azure/virtual-machines/capacity-reservation-overview). </param>
        /// <param name="hostGroupId"> The fully qualified resource ID of the Dedicated Host Group to provision virtual machines from, used only in creation scenario and not allowed to changed once set. This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}. For more information see [Azure dedicated hosts](https://docs.microsoft.com/azure/virtual-machines/dedicated-hosts). </param>
        /// <param name="networkProfile"> Network-related settings of an agent pool. </param>
        /// <param name="isOutboundNatDisabled"> Whether to disable OutboundNAT in windows nodes. The default value is false. Outbound NAT can only be disabled if the cluster outboundType is NAT Gateway and the Windows agent pool does not have node public IP enabled. </param>
        /// <param name="securityProfile"> The security settings of an agent pool. </param>
        /// <param name="gpuProfile"> GPU settings for the Agent Pool. </param>
        /// <param name="gatewayPublicIPPrefixSize"> The Gateway agent pool associates one public IPPrefix for each static egress gateway to provide public egress. The size of Public IPPrefix should be selected by the user. Each node in the agent pool is assigned with one IP from the IPPrefix. The IPPrefix size thus serves as a cap on the size of the Gateway agent pool. Due to Azure public IPPrefix size limitation, the valid value range is [28, 31] (/31 = 2 nodes/IPs, /30 = 4 nodes/IPs, /29 = 8 nodes/IPs, /28 = 16 nodes/IPs). The default value is 31. </param>
        /// <param name="isArtifactStreamingEnabled"> Artifact streaming speeds up the cold-start of containers on a node through on-demand image loading. To use this feature, container images must also enable artifact streaming on ACR. If not specified, the default is false. </param>
        /// <param name="virtualMachinesScale"> Specifications on how to scale a VirtualMachines agent pool. </param>
        /// <param name="virtualMachineNodesStatus"> The status of nodes in a VirtualMachines agent pool. </param>
        /// <param name="statusProvisioningError"> The error detail information of the agent pool. Preserves the detailed info of failure. If there was no error, this field is omitted. </param>
        /// <param name="localDnsProfile"> Configures the per-node local DNS, with VnetDNS and KubeDNS overrides. LocalDNS helps improve performance and reliability of DNS resolution in an AKS cluster. For more details see aka.ms/aks/localdns. </param>
        /// <returns> A new <see cref="Models.ManagedClusterAgentPoolProfileProperties"/> instance for mocking. </returns>
        public static ManagedClusterAgentPoolProfileProperties ManagedClusterAgentPoolProfileProperties(ETag? eTag, int? count, string vmSize, int? osDiskSizeInGB, ContainerServiceOSDiskType? osDiskType, KubeletDiskType? kubeletDiskType, WorkloadRuntime? workloadRuntime, string messageOfTheDay, ResourceIdentifier vnetSubnetId, ResourceIdentifier podSubnetId, PodIPAllocationMode? podIPAllocationMode, int? maxPods, ContainerServiceOSType? osType, ContainerServiceOSSku? osSku, int? maxCount, int? minCount, bool? isAutoScalingEnabled, ScaleDownMode? scaleDownMode, AgentPoolType? agentPoolType, AgentPoolMode? mode, string orchestratorVersion, string currentOrchestratorVersion, string nodeImageVersion, AgentPoolUpgradeSettings upgradeSettings, string provisioningState, ContainerServiceStateCode? powerStateCode, IEnumerable<string> availabilityZones, bool? isNodePublicIpEnabled, ResourceIdentifier nodePublicIPPrefixId, ScaleSetPriority? scaleSetPriority, ScaleSetEvictionPolicy? scaleSetEvictionPolicy, float? spotMaxPrice, IDictionary<string, string> tags, IDictionary<string, string> nodeLabels, IEnumerable<string> nodeTaints, ResourceIdentifier proximityPlacementGroupId, KubeletConfig kubeletConfig, LinuxOSConfig linuxOSConfig, bool? isEncryptionAtHostEnabled, bool? isUltraSsdEnabled, bool? isFipsEnabled, GpuInstanceProfile? gpuInstanceProfile, ResourceIdentifier creationDataSourceResourceId, ResourceIdentifier capacityReservationGroupId, ResourceIdentifier hostGroupId, AgentPoolNetworkProfile networkProfile, bool? isOutboundNatDisabled, AgentPoolSecurityProfile securityProfile, AgentPoolGpuProfile gpuProfile, int? gatewayPublicIPPrefixSize, bool? isArtifactStreamingEnabled, AgentPoolScaleProfile virtualMachinesScale, IEnumerable<AgentPoolVirtualMachineNodes> virtualMachineNodesStatus, ResponseError statusProvisioningError, LocalDnsProfile localDnsProfile)
        {
            return ManagedClusterAgentPoolProfileProperties(
                eTag: eTag,
                count: count,
                vmSize: vmSize,
                osDiskSizeInGB: osDiskSizeInGB,
                osDiskType: osDiskType,
                kubeletDiskType: kubeletDiskType,
                workloadRuntime: workloadRuntime,
                messageOfTheDay: messageOfTheDay,
                vnetSubnetId: vnetSubnetId,
                podSubnetId: podSubnetId,
                podIPAllocationMode: podIPAllocationMode,
                maxPods: maxPods,
                osType: osType,
                osSku: osSku,
                maxCount: maxCount,
                minCount: minCount,
                isAutoScalingEnabled: isAutoScalingEnabled,
                scaleDownMode: scaleDownMode,
                agentPoolType: agentPoolType,
                mode: mode,
                orchestratorVersion: orchestratorVersion,
                currentOrchestratorVersion: currentOrchestratorVersion,
                nodeImageVersion: nodeImageVersion,
                upgradeSettings: upgradeSettings,
                provisioningState: provisioningState,
                powerStateCode: powerStateCode,
                availabilityZones: availabilityZones,
                isNodePublicIpEnabled: isNodePublicIpEnabled,
                nodePublicIPPrefixId: nodePublicIPPrefixId,
                scaleSetPriority: scaleSetPriority,
                scaleSetEvictionPolicy: scaleSetEvictionPolicy,
                spotMaxPrice: spotMaxPrice,
                tags: tags,
                nodeLabels: nodeLabels,
                nodeTaints: nodeTaints,
                proximityPlacementGroupId: proximityPlacementGroupId,
                kubeletConfig: kubeletConfig,
                linuxOSConfig: linuxOSConfig,
                isEncryptionAtHostEnabled: isEncryptionAtHostEnabled,
                isUltraSsdEnabled: isUltraSsdEnabled,
                isFipsEnabled: isFipsEnabled,
                gpuInstanceProfile: gpuInstanceProfile,
                creationDataSourceResourceId: creationDataSourceResourceId,
                capacityReservationGroupId: capacityReservationGroupId,
                hostGroupId: hostGroupId,
                networkProfile: networkProfile,
                isOutboundNatDisabled: isOutboundNatDisabled,
                securityProfile: securityProfile,
                gpuProfile: gpuProfile,
                gatewayPublicIPPrefixSize: gatewayPublicIPPrefixSize,
                isArtifactStreamingEnabled: isArtifactStreamingEnabled,
                virtualMachinesScale: virtualMachinesScale,
                virtualMachineNodesStatus: virtualMachineNodesStatus,
                statusProvisioningError: statusProvisioningError,
                localDnsProfile: localDnsProfile,
                upgradeStrategy: default,
                isOSDiskFullCachingEnabled: default,
                upgradeSettingsBlueGreen: default,
                nodeInitializationTaints: default,
                preparedImageSpecificationId: default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterAgentPoolProfile"/> for mocking. </summary>
        /// <param name="eTag"> Unique read-only string used to implement optimistic concurrency. The eTag value will change when the resource is updated. Specify an if-match or if-none-match header with the eTag value for a subsequent request to enable optimistic concurrency per the normal eTag convention. </param>
        /// <param name="count"> Number of agents (VMs) to host docker containers. Allowed values must be in the range of 0 to 1000 (inclusive) for user pools and in the range of 1 to 1000 (inclusive) for system pools. The default value is 1. </param>
        /// <param name="vmSize"> The size of the agent pool VMs. VM size availability varies by region. If a node contains insufficient compute resources (memory, cpu, etc) pods might fail to run correctly. For more details on restricted VM sizes, see: https://docs.microsoft.com/azure/aks/quotas-skus-regions. </param>
        /// <param name="osDiskSizeInGB"> OS Disk Size in GB to be used to specify the disk size for every machine in the master/agent pool. If you specify 0, it will apply the default osDisk size according to the vmSize specified. </param>
        /// <param name="osDiskType"> The OS disk type to be used for machines in the agent pool. The default is 'Ephemeral' if the VM supports it and has a cache disk larger than the requested OSDiskSizeGB. Otherwise, defaults to 'Managed'. May not be changed after creation. For more information see [Ephemeral OS](https://docs.microsoft.com/azure/aks/cluster-configuration#ephemeral-os). </param>
        /// <param name="kubeletDiskType"> Determines the placement of emptyDir volumes, container runtime data root, and Kubelet ephemeral storage. </param>
        /// <param name="workloadRuntime"> Determines the type of workload a node can run. </param>
        /// <param name="messageOfTheDay"> Message of the day for Linux nodes, base64-encoded. A base64-encoded string which will be written to /etc/motd after decoding. This allows customization of the message of the day for Linux nodes. It must not be specified for Windows nodes. It must be a static string (i.e., will be printed raw and not be executed as a script). </param>
        /// <param name="vnetSubnetId"> The ID of the subnet which agent pool nodes and optionally pods will join on startup. If this is not specified, a VNET and subnet will be generated and used. If no podSubnetID is specified, this applies to nodes and pods, otherwise it applies to just nodes. This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}. </param>
        /// <param name="podSubnetId"> The ID of the subnet which pods will join when launched. If omitted, pod IPs are statically assigned on the node subnet (see vnetSubnetID for more details). This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}. </param>
        /// <param name="podIPAllocationMode"> Pod IP Allocation Mode. The IP allocation mode for pods in the agent pool. Must be used with podSubnetId. The default is 'DynamicIndividual'. </param>
        /// <param name="maxPods"> The maximum number of pods that can run on a node. </param>
        /// <param name="osType"> The operating system type. The default is Linux. </param>
        /// <param name="osSku"> Specifies the OS SKU used by the agent pool. The default is Ubuntu if OSType is Linux. The default is Windows2019 when Kubernetes &lt;= 1.24 or Windows2022 when Kubernetes &gt;= 1.25 if OSType is Windows. </param>
        /// <param name="maxCount"> The maximum number of nodes for auto-scaling. </param>
        /// <param name="minCount"> The minimum number of nodes for auto-scaling. </param>
        /// <param name="isAutoScalingEnabled"> Whether to enable auto-scaler. </param>
        /// <param name="scaleDownMode"> The scale down mode to use when scaling the Agent Pool. This also effects the cluster autoscaler behavior. If not specified, it defaults to Delete. </param>
        /// <param name="agentPoolType"> The type of Agent Pool. </param>
        /// <param name="mode"> The mode of an agent pool. A cluster must have at least one 'System' Agent Pool at all times. For additional information on agent pool restrictions and best practices, see: https://docs.microsoft.com/azure/aks/use-system-pools. </param>
        /// <param name="orchestratorVersion"> The version of Kubernetes specified by the user. Both patch version &lt;major.minor.patch&gt; (e.g. 1.20.13) and &lt;major.minor&gt; (e.g. 1.20) are supported. When &lt;major.minor&gt; is specified, the latest supported GA patch version is chosen automatically. Updating the cluster with the same &lt;major.minor&gt; once it has been created (e.g. 1.14.x -&gt; 1.14) will not trigger an upgrade, even if a newer patch version is available. As a best practice, you should upgrade all node pools in an AKS cluster to the same Kubernetes version. The node pool version must have the same major version as the control plane. The node pool minor version must be within two minor versions of the control plane version. The node pool version cannot be greater than the control plane version. For more information see [upgrading a node pool](https://docs.microsoft.com/azure/aks/use-multiple-node-pools#upgrade-a-node-pool). </param>
        /// <param name="currentOrchestratorVersion"> The version of Kubernetes the Agent Pool is running. If orchestratorVersion is a fully specified version &lt;major.minor.patch&gt;, this field will be exactly equal to it. If orchestratorVersion is &lt;major.minor&gt;, this field will contain the full &lt;major.minor.patch&gt; version being used. </param>
        /// <param name="nodeImageVersion">
        /// The version of the node image. Setting this value triggers an agentPool rollback.
        /// Only values from `recentlyUsedVersions` are allowed.
        /// </param>
        /// <param name="upgradeSettings"> Settings for upgrading the agentpool. </param>
        /// <param name="provisioningState"> The current deployment or provisioning state. </param>
        /// <param name="powerStateCode"> Tells whether the cluster is Running or Stopped. </param>
        /// <param name="availabilityZones"> The list of Availability zones to use for nodes. This can only be specified if the AgentPoolType property is 'VirtualMachineScaleSets'. </param>
        /// <param name="isNodePublicIpEnabled"> Whether each node is allocated its own public IP. Some scenarios may require nodes in a node pool to receive their own dedicated public IP addresses. A common scenario is for gaming workloads, where a console needs to make a direct connection to a cloud virtual machine to minimize hops. For more information see [assigning a public IP per node](https://docs.microsoft.com/azure/aks/use-multiple-node-pools#assign-a-public-ip-per-node-for-your-node-pools). The default is false. </param>
        /// <param name="nodePublicIPPrefixId"> The public IP prefix ID which VM nodes should use IPs from. This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPPrefixes/{publicIPPrefixName}. </param>
        /// <param name="scaleSetPriority"> The Virtual Machine Scale Set priority. </param>
        /// <param name="scaleSetEvictionPolicy"> The Virtual Machine Scale Set eviction policy. The eviction policy specifies what to do with the VM when it is evicted. The default is Delete. For more information about eviction see [spot VMs](https://docs.microsoft.com/azure/virtual-machines/spot-vms). </param>
        /// <param name="spotMaxPrice"> The max price (in US Dollars) you are willing to pay for spot instances. Possible values are any decimal value greater than zero or -1 which indicates default price to be up-to on-demand. Possible values are any decimal value greater than zero or -1 which indicates the willingness to pay any on-demand price. For more details on spot pricing, see [spot VMs pricing](https://docs.microsoft.com/azure/virtual-machines/spot-vms#pricing). </param>
        /// <param name="tags"> The tags to be persisted on the agent pool virtual machine scale set. </param>
        /// <param name="nodeLabels"> The node labels to be persisted across all nodes in agent pool. </param>
        /// <param name="nodeTaints"> The taints added to new nodes during node pool create and scale. For example, key=value:NoSchedule. </param>
        /// <param name="proximityPlacementGroupId"> The ID for Proximity Placement Group. </param>
        /// <param name="kubeletConfig"> The Kubelet configuration on the agent pool nodes. </param>
        /// <param name="linuxOSConfig"> The OS configuration of Linux agent nodes. </param>
        /// <param name="isEncryptionAtHostEnabled"> Whether to enable host based OS and data drive encryption. This is only supported on certain VM sizes and in certain Azure regions. For more information, see: https://docs.microsoft.com/azure/aks/enable-host-encryption. </param>
        /// <param name="isUltraSsdEnabled"> Whether to enable UltraSSD. </param>
        /// <param name="isFipsEnabled"> Whether to use a FIPS-enabled OS. See [Add a FIPS-enabled node pool](https://docs.microsoft.com/azure/aks/use-multiple-node-pools#add-a-fips-enabled-node-pool-preview) for more details. </param>
        /// <param name="gpuInstanceProfile"> GPUInstanceProfile to be used to specify GPU MIG instance profile for supported GPU VM SKU. </param>
        /// <param name="creationDataSourceResourceId"> This is the ARM ID of the source object to be used to create the target object. </param>
        /// <param name="capacityReservationGroupId"> The fully qualified resource ID of the Capacity Reservation Group to provide virtual machines from a reserved group of Virtual Machines. This is of the form: '/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Compute/capacityreservationgroups/{capacityReservationGroupName}' Customers use it to create an agentpool with a specified CRG. For more information see [Capacity Reservation](https://learn.microsoft.com/en-us/azure/virtual-machines/capacity-reservation-overview). </param>
        /// <param name="hostGroupId"> The fully qualified resource ID of the Dedicated Host Group to provision virtual machines from, used only in creation scenario and not allowed to changed once set. This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}. For more information see [Azure dedicated hosts](https://docs.microsoft.com/azure/virtual-machines/dedicated-hosts). </param>
        /// <param name="networkProfile"> Network-related settings of an agent pool. </param>
        /// <param name="isOutboundNatDisabled"> Whether to disable OutboundNAT in windows nodes. The default value is false. Outbound NAT can only be disabled if the cluster outboundType is NAT Gateway and the Windows agent pool does not have node public IP enabled. </param>
        /// <param name="securityProfile"> The security settings of an agent pool. </param>
        /// <param name="gpuProfile"> GPU settings for the Agent Pool. </param>
        /// <param name="gatewayPublicIPPrefixSize"> The Gateway agent pool associates one public IPPrefix for each static egress gateway to provide public egress. The size of Public IPPrefix should be selected by the user. Each node in the agent pool is assigned with one IP from the IPPrefix. The IPPrefix size thus serves as a cap on the size of the Gateway agent pool. Due to Azure public IPPrefix size limitation, the valid value range is [28, 31] (/31 = 2 nodes/IPs, /30 = 4 nodes/IPs, /29 = 8 nodes/IPs, /28 = 16 nodes/IPs). The default value is 31. </param>
        /// <param name="isArtifactStreamingEnabled"> Artifact streaming speeds up the cold-start of containers on a node through on-demand image loading. To use this feature, container images must also enable artifact streaming on ACR. If not specified, the default is false. </param>
        /// <param name="virtualMachinesScale"> Specifications on how to scale a VirtualMachines agent pool. </param>
        /// <param name="virtualMachineNodesStatus"> The status of nodes in a VirtualMachines agent pool. </param>
        /// <param name="statusProvisioningError"> The error detail information of the agent pool. Preserves the detailed info of failure. If there was no error, this field is omitted. </param>
        /// <param name="localDnsProfile"> Configures the per-node local DNS, with VnetDNS and KubeDNS overrides. LocalDNS helps improve performance and reliability of DNS resolution in an AKS cluster. For more details see aka.ms/aks/localdns. </param>
        /// <param name="name"> Unique name of the agent pool profile in the context of the subscription and resource group. Windows agent pool names must be 6 characters or less. </param>
        /// <returns> A new <see cref="Models.ManagedClusterAgentPoolProfile"/> instance for mocking. </returns>
        public static ManagedClusterAgentPoolProfile ManagedClusterAgentPoolProfile(ETag? eTag, int? count, string vmSize, int? osDiskSizeInGB, ContainerServiceOSDiskType? osDiskType, KubeletDiskType? kubeletDiskType, WorkloadRuntime? workloadRuntime, string messageOfTheDay, ResourceIdentifier vnetSubnetId, ResourceIdentifier podSubnetId, PodIPAllocationMode? podIPAllocationMode, int? maxPods, ContainerServiceOSType? osType, ContainerServiceOSSku? osSku, int? maxCount, int? minCount, bool? isAutoScalingEnabled, ScaleDownMode? scaleDownMode, AgentPoolType? agentPoolType, AgentPoolMode? mode, string orchestratorVersion, string currentOrchestratorVersion, string nodeImageVersion, AgentPoolUpgradeSettings upgradeSettings, string provisioningState, ContainerServiceStateCode? powerStateCode, IEnumerable<string> availabilityZones, bool? isNodePublicIpEnabled, ResourceIdentifier nodePublicIPPrefixId, ScaleSetPriority? scaleSetPriority, ScaleSetEvictionPolicy? scaleSetEvictionPolicy, float? spotMaxPrice, IDictionary<string, string> tags, IDictionary<string, string> nodeLabels, IEnumerable<string> nodeTaints, ResourceIdentifier proximityPlacementGroupId, KubeletConfig kubeletConfig, LinuxOSConfig linuxOSConfig, bool? isEncryptionAtHostEnabled, bool? isUltraSsdEnabled, bool? isFipsEnabled, GpuInstanceProfile? gpuInstanceProfile, ResourceIdentifier creationDataSourceResourceId, ResourceIdentifier capacityReservationGroupId, ResourceIdentifier hostGroupId, AgentPoolNetworkProfile networkProfile, bool? isOutboundNatDisabled, AgentPoolSecurityProfile securityProfile, AgentPoolGpuProfile gpuProfile, int? gatewayPublicIPPrefixSize, bool? isArtifactStreamingEnabled, AgentPoolScaleProfile virtualMachinesScale, IEnumerable<AgentPoolVirtualMachineNodes> virtualMachineNodesStatus, ResponseError statusProvisioningError, LocalDnsProfile localDnsProfile, string name)
        {
            return ManagedClusterAgentPoolProfile(
                eTag: eTag,
                count: count,
                vmSize: vmSize,
                osDiskSizeInGB: osDiskSizeInGB,
                osDiskType: osDiskType,
                kubeletDiskType: kubeletDiskType,
                workloadRuntime: workloadRuntime,
                messageOfTheDay: messageOfTheDay,
                vnetSubnetId: vnetSubnetId,
                podSubnetId: podSubnetId,
                podIPAllocationMode: podIPAllocationMode,
                maxPods: maxPods,
                osType: osType,
                osSku: osSku,
                maxCount: maxCount,
                minCount: minCount,
                isAutoScalingEnabled: isAutoScalingEnabled,
                scaleDownMode: scaleDownMode,
                agentPoolType: agentPoolType,
                mode: mode,
                orchestratorVersion: orchestratorVersion,
                currentOrchestratorVersion: currentOrchestratorVersion,
                nodeImageVersion: nodeImageVersion,
                upgradeSettings: upgradeSettings,
                provisioningState: provisioningState,
                powerStateCode: powerStateCode,
                availabilityZones: availabilityZones,
                isNodePublicIpEnabled: isNodePublicIpEnabled,
                nodePublicIPPrefixId: nodePublicIPPrefixId,
                scaleSetPriority: scaleSetPriority,
                scaleSetEvictionPolicy: scaleSetEvictionPolicy,
                spotMaxPrice: spotMaxPrice,
                tags: tags,
                nodeLabels: nodeLabels,
                nodeTaints: nodeTaints,
                proximityPlacementGroupId: proximityPlacementGroupId,
                kubeletConfig: kubeletConfig,
                linuxOSConfig: linuxOSConfig,
                isEncryptionAtHostEnabled: isEncryptionAtHostEnabled,
                isUltraSsdEnabled: isUltraSsdEnabled,
                isFipsEnabled: isFipsEnabled,
                gpuInstanceProfile: gpuInstanceProfile,
                creationDataSourceResourceId: creationDataSourceResourceId,
                capacityReservationGroupId: capacityReservationGroupId,
                hostGroupId: hostGroupId,
                networkProfile: networkProfile,
                isOutboundNatDisabled: isOutboundNatDisabled,
                securityProfile: securityProfile,
                gpuProfile: gpuProfile,
                gatewayPublicIPPrefixSize: gatewayPublicIPPrefixSize,
                isArtifactStreamingEnabled: isArtifactStreamingEnabled,
                virtualMachinesScale: virtualMachinesScale,
                virtualMachineNodesStatus: virtualMachineNodesStatus,
                statusProvisioningError: statusProvisioningError,
                localDnsProfile: localDnsProfile,
                name: name,
                upgradeStrategy: default,
                isOSDiskFullCachingEnabled: default,
                upgradeSettingsBlueGreen: default,
                nodeInitializationTaints: default,
                preparedImageSpecificationId: default);
        }
        /// <summary> Initializes a new instance of <see cref="Models.AgentPoolGpuProfile"/>. </summary>
        /// <param name="driver"> Whether to install GPU drivers. </param>
        /// <param name="nvidiaManagementMode"> The NVIDIA GPU management mode. </param>
        /// <returns> A new <see cref="Models.AgentPoolGpuProfile"/> instance for mocking. </returns>
        public static AgentPoolGpuProfile AgentPoolGpuProfile(AgentPoolGpuDriver? driver, GpuManagementMode? nvidiaManagementMode)
        {
            return new AgentPoolGpuProfile
            {
                Driver = driver,
                Nvidia = nvidiaManagementMode.HasValue
                    ? new AgentPoolNvidiaGpuProfile { ManagementMode = nvidiaManagementMode }
                    : null
            };
        }

        /// <summary> Initializes a new instance of <see cref="ContainerService.OSOptionProfileData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="osOptionPropertyList"> The list of OS options. </param>
        /// <returns> A new <see cref="ContainerService.OSOptionProfileData"/> instance for mocking. </returns>
        [Obsolete("This function is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OSOptionProfileData OSOptionProfileData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IEnumerable<ContainerServiceOSOptionProperty> osOptionPropertyList)
        {
            osOptionPropertyList ??= new List<ContainerServiceOSOptionProperty>();

            return new OSOptionProfileData(
                id,
                name,
                resourceType,
                systemData,
                osOptionPropertyList?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ContainerServiceOSOptionProperty"/>. </summary>
        /// <param name="osType"> The OS type. </param>
        /// <param name="enableFipsImage"> Whether the image is FIPS-enabled. </param>
        /// <returns> A new <see cref="Models.ContainerServiceOSOptionProperty"/> instance for mocking. </returns>
        [Obsolete("This function is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerServiceOSOptionProperty ContainerServiceOSOptionProperty(string osType = null, bool enableFipsImage = default)
        {
            return new ContainerServiceOSOptionProperty(osType, enableFipsImage, serializedAdditionalRawData: null);
        }

        // This factory method is retained because the generator no longer emits one for AgentPoolUpgradeProfileData.
        // It is required for backward compatibility with existing callers that depend on this public API surface.
        /// <summary> Initializes a new instance of <see cref="ContainerService.AgentPoolUpgradeProfileData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="kubernetesVersion"> The Kubernetes version (major.minor.patch). </param>
        /// <param name="osType"> The operating system type. The default is Linux. </param>
        /// <param name="upgrades"> List of orchestrator types and versions available for upgrade. </param>
        /// <param name="recentlyUsedVersions"> List of versions that the agent pool has recently been on. </param>
        /// <param name="latestNodeImageVersion"> The latest AKS supported node image version. </param>
        /// <returns> A new <see cref="ContainerService.AgentPoolUpgradeProfileData"/> instance for mocking. </returns>
        public static AgentPoolUpgradeProfileData AgentPoolUpgradeProfileData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string kubernetesVersion = null, ContainerServiceOSType osType = default, IEnumerable<AgentPoolUpgradeProfilePropertiesUpgradesItem> upgrades = null, IEnumerable<AgentPoolRecentlyUsedVersion> recentlyUsedVersions = null, string latestNodeImageVersion = null)
        {
            return new AgentPoolUpgradeProfileData(
                id,
                name,
                resourceType,
                systemData,
                new AgentPoolUpgradeProfileProperties(
                    kubernetesVersion,
                    osType,
                    (upgrades ?? new List<AgentPoolUpgradeProfilePropertiesUpgradesItem>()).ToList(),
                    new List<KubernetesVersionComponents>(),
                    (recentlyUsedVersions ?? new List<AgentPoolRecentlyUsedVersion>()).ToList(),
                    latestNodeImageVersion,
                    additionalBinaryDataProperties: null),
                additionalBinaryDataProperties: null);
        }

        // This factory method is retained for backward compatibility. The generated factory now exposes
        // a nested AppMonitoring model in place of the isAppMonitoringAutoInstrumentationEnabled flag.
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterAzureMonitorProfile"/>. </summary>
        /// <param name="metrics"> Metrics profile for the prometheus service addon. </param>
        /// <param name="isAppMonitoringAutoInstrumentationEnabled"> Indicates if Application Monitoring Auto Instrumentation is enabled or not. </param>
        /// <returns> A new <see cref="Models.ManagedClusterAzureMonitorProfile"/> instance for mocking. </returns>
        public static ManagedClusterAzureMonitorProfile ManagedClusterAzureMonitorProfile(ManagedClusterMonitorProfileMetrics metrics = null, bool? isAppMonitoringAutoInstrumentationEnabled = default)
        {
            ManagedClusterAzureMonitorProfileAppMonitoring appMonitoring = null;
            if (isAppMonitoringAutoInstrumentationEnabled.HasValue)
            {
                appMonitoring = new ManagedClusterAzureMonitorProfileAppMonitoring
                {
                    IsAppMonitoringAutoInstrumentationEnabled = isAppMonitoringAutoInstrumentationEnabled
                };
            }
            return new ManagedClusterAzureMonitorProfile(metrics, null, appMonitoring, null);
        }

        // This factory method is retained for backward compatibility. The generated factory now exposes
        // a nested VerticalPodAutoscaler model in place of the isVpaEnabled flag.
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterWorkloadAutoScalerProfile"/>. </summary>
        /// <param name="isKedaEnabled"> Whether to enable KEDA. </param>
        /// <param name="isVpaEnabled"> Whether to enable VPA add-on in cluster. Default value is false. </param>
        /// <returns> A new <see cref="Models.ManagedClusterWorkloadAutoScalerProfile"/> instance for mocking. </returns>
        public static ManagedClusterWorkloadAutoScalerProfile ManagedClusterWorkloadAutoScalerProfile(bool? isKedaEnabled = default, bool? isVpaEnabled = default)
        {
            ManagedClusterVerticalPodAutoscaler verticalPodAutoscaler = isVpaEnabled.HasValue
                ? new ManagedClusterVerticalPodAutoscaler(isVpaEnabled.Value)
                : null;
            ManagedClusterWorkloadAutoScalerProfileKeda keda = isKedaEnabled.HasValue
                ? new ManagedClusterWorkloadAutoScalerProfileKeda(isKedaEnabled.Value)
                : null;
            return new ManagedClusterWorkloadAutoScalerProfile(keda, verticalPodAutoscaler, null);
        }

        // This factory method is retained for backward compatibility. The generated factory added the
        // trailing securityGating parameter.
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterSecurityProfileDefender"/>. </summary>
        /// <param name="logAnalyticsWorkspaceResourceId"> Resource ID of the Log Analytics workspace to be associated with Microsoft Defender. </param>
        /// <param name="isSecurityMonitoringEnabled"> Whether to enable Defender threat detection. </param>
        /// <returns> A new <see cref="Models.ManagedClusterSecurityProfileDefender"/> instance for mocking. </returns>
        public static ManagedClusterSecurityProfileDefender ManagedClusterSecurityProfileDefender(ResourceIdentifier logAnalyticsWorkspaceResourceId = null, bool? isSecurityMonitoringEnabled = default)
        {
            return ManagedClusterSecurityProfileDefender(logAnalyticsWorkspaceResourceId, isSecurityMonitoringEnabled, null);
        }

        // This factory method is retained for backward compatibility. The generated factory now exposes
        // a nested ManagedOutboundIPProfile model in place of the managedOutboundIPCount value and added
        // the outboundPublicIPPrefixes and outboundPublicIPs parameters.
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterNatGatewayProfile"/>. </summary>
        /// <param name="managedOutboundIPCount"> The desired number of outbound IPs created/managed by Azure. </param>
        /// <param name="effectiveOutboundIPs"> The effective outbound IP resources of the cluster NAT gateway. </param>
        /// <param name="idleTimeoutInMinutes"> Desired outbound flow idle timeout in minutes. </param>
        /// <returns> A new <see cref="Models.ManagedClusterNatGatewayProfile"/> instance for mocking. </returns>
        public static ManagedClusterNatGatewayProfile ManagedClusterNatGatewayProfile(int? managedOutboundIPCount = default, IEnumerable<WritableSubResource> effectiveOutboundIPs = null, int? idleTimeoutInMinutes = default)
        {
            ManagedClusterManagedOutboundIPProfile managedOutboundIPProfile = managedOutboundIPCount.HasValue
                ? new ManagedClusterManagedOutboundIPProfile { Count = managedOutboundIPCount }
                : null;
            return new ManagedClusterNatGatewayProfile(null, managedOutboundIPProfile, effectiveOutboundIPs?.ToList(), null, null, idleTimeoutInMinutes, null);
        }

        // This factory method is retained for backward compatibility. The generated factory added the
        // trailing clusterServiceLoadBalancerHealthProbeMode parameter.
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterLoadBalancerProfile"/>. </summary>
        /// <param name="managedOutboundIPs"> Desired managed outbound IPs for the cluster load balancer. </param>
        /// <param name="outboundPublicIPPrefixes"> Desired outbound IP Prefix resources for the cluster load balancer. </param>
        /// <param name="outboundPublicIPs"> Desired outbound IP resources for the cluster load balancer. </param>
        /// <param name="effectiveOutboundIPs"> The effective outbound IP resources of the cluster load balancer. </param>
        /// <param name="allocatedOutboundPorts"> The desired number of allocated SNAT ports per VM. </param>
        /// <param name="idleTimeoutInMinutes"> Desired outbound flow idle timeout in minutes. </param>
        /// <param name="isMultipleStandardLoadBalancersEnabled"> Enable multiple standard load balancers per AKS cluster or not. </param>
        /// <param name="backendPoolType"> The type of the managed inbound Load Balancer BackendPool. </param>
        /// <returns> A new <see cref="Models.ManagedClusterLoadBalancerProfile"/> instance for mocking. </returns>
        public static ManagedClusterLoadBalancerProfile ManagedClusterLoadBalancerProfile(ManagedClusterLoadBalancerProfileManagedOutboundIPs managedOutboundIPs = null, IEnumerable<WritableSubResource> outboundPublicIPPrefixes = null, IEnumerable<WritableSubResource> outboundPublicIPs = null, IEnumerable<WritableSubResource> effectiveOutboundIPs = null, int? allocatedOutboundPorts = default, int? idleTimeoutInMinutes = default, bool? isMultipleStandardLoadBalancersEnabled = default, ManagedClusterLoadBalancerBackendPoolType? backendPoolType = default)
        {
            var result = new ManagedClusterLoadBalancerProfile
            {
                ManagedOutboundIPs = managedOutboundIPs,
                AllocatedOutboundPorts = allocatedOutboundPorts,
                IdleTimeoutInMinutes = idleTimeoutInMinutes,
                IsMultipleStandardLoadBalancersEnabled = isMultipleStandardLoadBalancersEnabled,
                BackendPoolType = backendPoolType
            };
            if (outboundPublicIPPrefixes != null)
            {
                foreach (var item in outboundPublicIPPrefixes)
                {
                    result.OutboundPublicIPPrefixes.Add(item);
                }
            }
            if (outboundPublicIPs != null)
            {
                foreach (var item in outboundPublicIPs)
                {
                    result.OutboundPublicIPs.Add(item);
                }
            }
            if (effectiveOutboundIPs != null)
            {
                foreach (var item in effectiveOutboundIPs)
                {
                    result.EffectiveOutboundIPs.Add(item);
                }
            }
            return result;
        }

        // This factory method is retained for backward compatibility. The generated factory added the
        // trailing defaultDomain parameter.
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterIngressProfileWebAppRouting"/>. </summary>
        /// <param name="isEnabled"> Whether to enable Web App Routing. </param>
        /// <param name="gatewayApiImplementationsIstioMode"> Istio mode for the Gateway API implementation. </param>
        /// <param name="dnsZoneResourceIds"> Resource IDs of the DNS zones to be associated with the Web App Routing add-on. </param>
        /// <param name="nginxDefaultIngressControllerType"> Type of the default NginxIngressController custom resource. </param>
        /// <param name="identity"> Managed identity of the Web Application Routing add-on. </param>
        /// <returns> A new <see cref="Models.ManagedClusterIngressProfileWebAppRouting"/> instance for mocking. </returns>
        public static ManagedClusterIngressProfileWebAppRouting ManagedClusterIngressProfileWebAppRouting(bool? isEnabled = default, GatewayApiIstioMode? gatewayApiImplementationsIstioMode = default, IEnumerable<ResourceIdentifier> dnsZoneResourceIds = null, NginxIngressControllerType? nginxDefaultIngressControllerType = default, ContainerServiceUserAssignedIdentity identity = null)
        {
            return ManagedClusterIngressProfileWebAppRouting(isEnabled, dnsZoneResourceIds, nginxDefaultIngressControllerType, identity);
        }

        // This factory method is retained for backward compatibility. The generated factory added the
        // trailing applicationLoadBalancer parameter.
        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterIngressProfile"/>. </summary>
        /// <param name="webAppRouting"> Web App Routing settings for the ingress profile. </param>
        /// <param name="gatewayApiInstallation"> The Gateway API installation mode. </param>
        /// <returns> A new <see cref="Models.ManagedClusterIngressProfile"/> instance for mocking. </returns>
        public static ManagedClusterIngressProfile ManagedClusterIngressProfile(ManagedClusterIngressProfileWebAppRouting webAppRouting = null, ManagedGatewayType? gatewayApiInstallation = default)
        {
            var result = new ManagedClusterIngressProfile
            {
                WebAppRouting = webAppRouting
            };
            if (gatewayApiInstallation.HasValue)
            {
                result.GatewayApiInstallation = gatewayApiInstallation;
            }
            return result;
        }

        // This factory method is retained for backward compatibility. The generated factory inserted the
        // maxBlockedNodes parameter.
        /// <summary> Initializes a new instance of <see cref="Models.AgentPoolUpgradeSettings"/>. </summary>
        /// <param name="maxSurge"> The maximum number or percentage of nodes that are surged during upgrade. </param>
        /// <param name="maxUnavailable"> The maximum number or percentage of nodes that can be simultaneously unavailable during upgrade. </param>
        /// <param name="drainTimeoutInMinutes"> The amount of time (in minutes) to wait on eviction of pods and graceful termination per node. </param>
        /// <param name="nodeSoakDurationInMinutes"> The amount of time (in minutes) to wait after draining a node and before reimaging it and moving on to next node. </param>
        /// <param name="undrainableNodeBehavior"> Defines the behavior for undrainable nodes during upgrade. </param>
        /// <returns> A new <see cref="Models.AgentPoolUpgradeSettings"/> instance for mocking. </returns>
        public static AgentPoolUpgradeSettings AgentPoolUpgradeSettings(string maxSurge = null, string maxUnavailable = null, int? drainTimeoutInMinutes = default, int? nodeSoakDurationInMinutes = default, UndrainableNodeBehavior? undrainableNodeBehavior = default)
        {
            return new AgentPoolUpgradeSettings
            {
                MaxSurge = maxSurge,
                MaxUnavailable = maxUnavailable,
                DrainTimeoutInMinutes = drainTimeoutInMinutes,
                NodeSoakDurationInMinutes = nodeSoakDurationInMinutes,
                UndrainableNodeBehavior = undrainableNodeBehavior
            };
        }

        /// <summary> Initializes a new instance of <see cref="ContainerService.AgentPoolUpgradeProfileData"/>. </summary>
        /// <returns> A new <see cref="ContainerService.AgentPoolUpgradeProfileData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AgentPoolUpgradeProfileData AgentPoolUpgradeProfileData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string kubernetesVersion, ContainerServiceOSType osType, IEnumerable<AgentPoolUpgradeProfilePropertiesUpgradesItem> upgrades, string latestNodeImageVersion)
        {
            return AgentPoolUpgradeProfileData(id, name, resourceType, systemData, kubernetesVersion, osType, upgrades, null, latestNodeImageVersion);
        }

        /// <summary> Initializes a new instance of <see cref="ContainerService.ContainerServiceAgentPoolData"/>. </summary>
        /// <returns> A new <see cref="ContainerService.ContainerServiceAgentPoolData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerServiceAgentPoolData ContainerServiceAgentPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? eTag = default, int? count = default, string vmSize = null, int? osDiskSizeInGB = default, ContainerServiceOSDiskType? osDiskType = default, KubeletDiskType? kubeletDiskType = default, WorkloadRuntime? workloadRuntime = default, string messageOfTheDay = null, Azure.Core.ResourceIdentifier vnetSubnetId = null, Azure.Core.ResourceIdentifier podSubnetId = null, PodIPAllocationMode? podIPAllocationMode = default, int? maxPods = default, ContainerServiceOSType? osType = default, ContainerServiceOSSku? osSku = default, int? maxCount = default, int? minCount = default, bool? isAutoScalingEnabled = default, ScaleDownMode? scaleDownMode = default, AgentPoolType? agentPoolType = default, AgentPoolMode? mode = default, string orchestratorVersion = null, string currentOrchestratorVersion = null, string nodeImageVersion = null, AgentPoolUpgradeSettings upgradeSettings = null, string provisioningState = null, IEnumerable<string> availabilityZones = null, bool? isNodePublicIpEnabled = default, Azure.Core.ResourceIdentifier nodePublicIPPrefixId = null, ScaleSetPriority? scaleSetPriority = default, ScaleSetEvictionPolicy? scaleSetEvictionPolicy = default, float? spotMaxPrice = default, IDictionary<string, string> tags = null, IDictionary<string, string> nodeLabels = null, IEnumerable<string> nodeTaints = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, KubeletConfig kubeletConfig = null, LinuxOSConfig linuxOSConfig = null, bool? isEncryptionAtHostEnabled = default, bool? isUltraSsdEnabled = default, bool? isFipsEnabled = default, GpuInstanceProfile? gpuInstanceProfile = default, Azure.Core.ResourceIdentifier capacityReservationGroupId = null, Azure.Core.ResourceIdentifier hostGroupId = null, AgentPoolNetworkProfile networkProfile = null, AgentPoolSecurityProfile securityProfile = null, IEnumerable<AgentPoolVirtualMachineNodes> virtualMachineNodesStatus = null, LocalDnsProfile localDnsProfile = null, ContainerServiceStateCode? powerStateCode = default, Azure.Core.ResourceIdentifier creationDataSourceResourceId = null, bool? isOutboundNatDisabled = default, int? gatewayPublicIPPrefixSize = default, bool? isArtifactStreamingEnabled = default, Azure.ResponseError statusProvisioningError = null, string upgradeMaxSurge = null, IEnumerable<ManualScaleProfile> scaleManual = null, IEnumerable<ManualScaleProfile> virtualMachinesScaleManual = null, AgentPoolGpuDriver? gpuDriver = default, bool? enableAutoScaling = default, bool? enableNodePublicIP = default, bool? enableEncryptionAtHost = default, bool? enableFips = default, bool? enableUltraSsd = default)
        {
            var result = ContainerServiceAgentPoolData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                eTag: eTag,
                count: count,
                vmSize: vmSize,
                osDiskSizeInGB: osDiskSizeInGB,
                osDiskType: osDiskType,
                kubeletDiskType: kubeletDiskType,
                workloadRuntime: workloadRuntime,
                messageOfTheDay: messageOfTheDay,
                vnetSubnetId: vnetSubnetId,
                podSubnetId: podSubnetId,
                podIPAllocationMode: podIPAllocationMode,
                maxPods: maxPods,
                osType: osType,
                osSku: osSku,
                maxCount: maxCount,
                minCount: minCount,
                isAutoScalingEnabled: isAutoScalingEnabled,
                scaleDownMode: scaleDownMode,
                agentPoolType: agentPoolType,
                mode: mode,
                orchestratorVersion: orchestratorVersion,
                currentOrchestratorVersion: currentOrchestratorVersion,
                nodeImageVersion: nodeImageVersion,
                upgradeSettings: upgradeSettings,
                provisioningState: provisioningState,
                availabilityZones: availabilityZones,
                isNodePublicIpEnabled: isNodePublicIpEnabled,
                nodePublicIPPrefixId: nodePublicIPPrefixId,
                scaleSetPriority: scaleSetPriority,
                scaleSetEvictionPolicy: scaleSetEvictionPolicy,
                spotMaxPrice: spotMaxPrice,
                tags: tags,
                nodeLabels: nodeLabels,
                nodeTaints: nodeTaints,
                proximityPlacementGroupId: proximityPlacementGroupId,
                kubeletConfig: kubeletConfig,
                linuxOSConfig: linuxOSConfig,
                isEncryptionAtHostEnabled: isEncryptionAtHostEnabled,
                isUltraSsdEnabled: isUltraSsdEnabled,
                isFipsEnabled: isFipsEnabled,
                gpuInstanceProfile: gpuInstanceProfile,
                capacityReservationGroupId: capacityReservationGroupId,
                hostGroupId: hostGroupId,
                networkProfile: networkProfile,
                securityProfile: securityProfile,
                virtualMachineNodesStatus: virtualMachineNodesStatus,
                localDnsProfile: localDnsProfile,
                powerStateCode: powerStateCode,
                creationDataSourceResourceId: creationDataSourceResourceId,
                isOutboundNatDisabled: isOutboundNatDisabled,
                gatewayPublicIPPrefixSize: gatewayPublicIPPrefixSize,
                isArtifactStreamingEnabled: isArtifactStreamingEnabled,
                statusProvisioningError: statusProvisioningError,
                upgradeMaxSurge: upgradeMaxSurge,
                scaleManual: scaleManual,
                virtualMachinesScaleManual: virtualMachinesScaleManual,
                gpuDriver: gpuDriver,
                enableAutoScaling: enableAutoScaling,
                enableNodePublicIP: enableNodePublicIP,
                enableEncryptionAtHost: enableEncryptionAtHost,
                enableFips: enableFips,
                enableUltraSsd: enableUltraSsd,
                virtualMachinesScale: default);
            return result;
        }

        /// <summary> Initializes a new instance of <see cref="ContainerService.ContainerServiceManagedClusterData"/>. </summary>
        /// <returns> A new <see cref="ContainerService.ContainerServiceManagedClusterData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerServiceManagedClusterData ContainerServiceManagedClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default, string provisioningState = null, int? maxAgentPools = default, string kubernetesVersion = null, string currentKubernetesVersion = null, string dnsPrefix = null, string fqdnSubdomain = null, string fqdn = null, string privateFqdn = null, string azurePortalFqdn = null, IEnumerable<ManagedClusterAgentPoolProfile> agentPoolProfiles = null, ContainerServiceLinuxProfile linuxProfile = null, ManagedClusterWindowsProfile windowsProfile = null, ManagedClusterServicePrincipalProfile servicePrincipalProfile = null, IDictionary<string, ManagedClusterAddonProfile> addonProfiles = null, ManagedClusterPodIdentityProfile podIdentityProfile = null, ManagedClusterOidcIssuerProfile oidcIssuerProfile = null, string nodeResourceGroup = null, bool? isRbacEnabled = default, KubernetesSupportPlan? supportPlan = default, ContainerServiceNetworkProfile networkProfile = null, ManagedClusterAadProfile aadProfile = null, ManagedClusterAutoUpgradeProfile autoUpgradeProfile = null, ManagedClusterAutoScalerProfile autoScalerProfile = null, ManagedClusterApiServerAccessProfile apiServerAccessProfile = null, Azure.Core.ResourceIdentifier diskEncryptionSetId = null, IDictionary<string, ContainerServiceUserAssignedIdentity> identityProfile = null, IEnumerable<ContainerServicePrivateLinkResourceData> privateLinkResources = null, bool? isLocalAccountsDisabled = default, ManagedClusterHttpProxyConfig httpProxyConfig = null, ManagedClusterSecurityProfile securityProfile = null, ManagedClusterStorageProfile storageProfile = null, ManagedClusterIngressProfile ingressProfile = null, ContainerServicePublicNetworkAccess? publicNetworkAccess = default, ManagedClusterWorkloadAutoScalerProfile workloadAutoScalerProfile = null, ManagedClusterAzureMonitorProfile azureMonitorProfile = null, ServiceMeshProfile serviceMeshProfile = null, Azure.Core.ResourceIdentifier resourceId = null, ManagedClusterNodeProvisioningProfile nodeProvisioningProfile = null, ManagedClusterBootstrapProfile bootstrapProfile = null, ManagedClusterHostedSystemProfile hostedSystemProfile = null, ContainerServiceStateCode? powerStateCode = default, ManagedClusterNodeResourceGroupRestrictionLevel? nodeResourceGroupRestrictionLevel = default, UpgradeOverrideSettings upgradeOverrideSettings = null, bool? isCostAnalysisEnabled = default, bool? isAIToolchainOperatorEnabled = default, Azure.ResponseError statusProvisioningError = null, Azure.ETag? eTag = default, ManagedClusterSku sku = null, ExtendedLocation extendedLocation = null, ManagedClusterIdentity clusterIdentity = null, string kind = null)
        {
            var result = ContainerServiceManagedClusterData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                provisioningState: provisioningState,
                maxAgentPools: maxAgentPools,
                kubernetesVersion: kubernetesVersion,
                currentKubernetesVersion: currentKubernetesVersion,
                dnsPrefix: dnsPrefix,
                fqdnSubdomain: fqdnSubdomain,
                fqdn: fqdn,
                privateFqdn: privateFqdn,
                azurePortalFqdn: azurePortalFqdn,
                agentPoolProfiles: agentPoolProfiles,
                linuxProfile: linuxProfile,
                windowsProfile: windowsProfile,
                servicePrincipalProfile: servicePrincipalProfile,
                addonProfiles: addonProfiles,
                podIdentityProfile: podIdentityProfile,
                oidcIssuerProfile: oidcIssuerProfile,
                nodeResourceGroup: nodeResourceGroup,
                isRbacEnabled: isRbacEnabled,
                supportPlan: supportPlan,
                networkProfile: networkProfile,
                aadProfile: aadProfile,
                autoUpgradeProfile: autoUpgradeProfile,
                autoScalerProfile: autoScalerProfile,
                apiServerAccessProfile: apiServerAccessProfile,
                diskEncryptionSetId: diskEncryptionSetId,
                identityProfile: identityProfile,
                privateLinkResources: privateLinkResources,
                isLocalAccountsDisabled: isLocalAccountsDisabled,
                httpProxyConfig: httpProxyConfig,
                securityProfile: securityProfile,
                storageProfile: storageProfile,
                ingressProfile: ingressProfile,
                publicNetworkAccess: publicNetworkAccess,
                workloadAutoScalerProfile: workloadAutoScalerProfile,
                azureMonitorProfile: azureMonitorProfile,
                serviceMeshProfile: serviceMeshProfile,
                resourceId: resourceId,
                nodeProvisioningProfile: nodeProvisioningProfile,
                bootstrapProfile: bootstrapProfile,
                hostedSystemProfile: hostedSystemProfile,
                powerStateCode: powerStateCode,
                nodeResourceGroupRestrictionLevel: nodeResourceGroupRestrictionLevel,
                upgradeOverrideSettings: upgradeOverrideSettings,
                isCostAnalysisEnabled: isCostAnalysisEnabled,
                isAIToolchainOperatorEnabled: isAIToolchainOperatorEnabled,
                statusProvisioningError: statusProvisioningError,
                eTag: eTag,
                sku: sku,
                extendedLocation: extendedLocation,
                clusterIdentity: clusterIdentity,
                kind: kind,
                upstreamSchedulerConfigMode: default);
            return result;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterAgentPoolProfile"/>. </summary>
        /// <returns> A new <see cref="Models.ManagedClusterAgentPoolProfile"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagedClusterAgentPoolProfile ManagedClusterAgentPoolProfile(Azure.ETag? eTag = default, int? count = default, string vmSize = null, int? osDiskSizeInGB = default, ContainerServiceOSDiskType? osDiskType = default, KubeletDiskType? kubeletDiskType = default, WorkloadRuntime? workloadRuntime = default, string messageOfTheDay = null, Azure.Core.ResourceIdentifier vnetSubnetId = null, Azure.Core.ResourceIdentifier podSubnetId = null, PodIPAllocationMode? podIPAllocationMode = default, int? maxPods = default, ContainerServiceOSType? osType = default, ContainerServiceOSSku? osSku = default, int? maxCount = default, int? minCount = default, bool? isAutoScalingEnabled = default, ScaleDownMode? scaleDownMode = default, AgentPoolType? agentPoolType = default, AgentPoolMode? mode = default, string orchestratorVersion = null, string currentOrchestratorVersion = null, string nodeImageVersion = null, AgentPoolUpgradeSettings upgradeSettings = null, string provisioningState = null, ContainerServiceStateCode? powerStateCode = default, IEnumerable<string> availabilityZones = null, bool? isNodePublicIpEnabled = default, Azure.Core.ResourceIdentifier nodePublicIPPrefixId = null, ScaleSetPriority? scaleSetPriority = default, ScaleSetEvictionPolicy? scaleSetEvictionPolicy = default, float? spotMaxPrice = default, IDictionary<string, string> tags = null, IDictionary<string, string> nodeLabels = null, IEnumerable<string> nodeTaints = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, KubeletConfig kubeletConfig = null, LinuxOSConfig linuxOSConfig = null, bool? isEncryptionAtHostEnabled = default, bool? isUltraSsdEnabled = default, bool? isFipsEnabled = default, GpuInstanceProfile? gpuInstanceProfile = default, Azure.Core.ResourceIdentifier creationDataSourceResourceId = null, Azure.Core.ResourceIdentifier capacityReservationGroupId = null, Azure.Core.ResourceIdentifier hostGroupId = null, AgentPoolNetworkProfile networkProfile = null, bool? isOutboundNatDisabled = default, AgentPoolSecurityProfile securityProfile = null, AgentPoolGpuDriver? gpuDriver = default, int? gatewayPublicIPPrefixSize = default, bool? isArtifactStreamingEnabled = default, IEnumerable<ManualScaleProfile> virtualMachinesScaleManual = null, IEnumerable<AgentPoolVirtualMachineNodes> virtualMachineNodesStatus = null, Azure.ResponseError statusProvisioningError = null, LocalDnsProfile localDnsProfile = null, string name = null)
        {
            var result = ManagedClusterAgentPoolProfile(
                eTag: eTag,
                count: count,
                vmSize: vmSize,
                osDiskSizeInGB: osDiskSizeInGB,
                osDiskType: osDiskType,
                kubeletDiskType: kubeletDiskType,
                workloadRuntime: workloadRuntime,
                messageOfTheDay: messageOfTheDay,
                vnetSubnetId: vnetSubnetId,
                podSubnetId: podSubnetId,
                podIPAllocationMode: podIPAllocationMode,
                maxPods: maxPods,
                osType: osType,
                osSku: osSku,
                maxCount: maxCount,
                minCount: minCount,
                isAutoScalingEnabled: isAutoScalingEnabled,
                scaleDownMode: scaleDownMode,
                agentPoolType: agentPoolType,
                mode: mode,
                orchestratorVersion: orchestratorVersion,
                currentOrchestratorVersion: currentOrchestratorVersion,
                nodeImageVersion: nodeImageVersion,
                upgradeSettings: upgradeSettings,
                provisioningState: provisioningState,
                powerStateCode: powerStateCode,
                availabilityZones: availabilityZones,
                isNodePublicIpEnabled: isNodePublicIpEnabled,
                nodePublicIPPrefixId: nodePublicIPPrefixId,
                scaleSetPriority: scaleSetPriority,
                scaleSetEvictionPolicy: scaleSetEvictionPolicy,
                spotMaxPrice: spotMaxPrice,
                tags: tags,
                nodeLabels: nodeLabels,
                nodeTaints: nodeTaints,
                proximityPlacementGroupId: proximityPlacementGroupId,
                kubeletConfig: kubeletConfig,
                linuxOSConfig: linuxOSConfig,
                isEncryptionAtHostEnabled: isEncryptionAtHostEnabled,
                isUltraSsdEnabled: isUltraSsdEnabled,
                isFipsEnabled: isFipsEnabled,
                gpuInstanceProfile: gpuInstanceProfile,
                creationDataSourceResourceId: creationDataSourceResourceId,
                capacityReservationGroupId: capacityReservationGroupId,
                hostGroupId: hostGroupId,
                networkProfile: networkProfile,
                isOutboundNatDisabled: isOutboundNatDisabled,
                securityProfile: securityProfile,
                gatewayPublicIPPrefixSize: gatewayPublicIPPrefixSize,
                isArtifactStreamingEnabled: isArtifactStreamingEnabled,
                virtualMachineNodesStatus: virtualMachineNodesStatus,
                statusProvisioningError: statusProvisioningError,
                localDnsProfile: localDnsProfile,
                name: name,
                virtualMachinesScaleManual: virtualMachinesScaleManual);
            result.GpuDriver = gpuDriver;
            return result;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ManagedClusterAgentPoolProfileProperties"/>. </summary>
        /// <returns> A new <see cref="Models.ManagedClusterAgentPoolProfileProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagedClusterAgentPoolProfileProperties ManagedClusterAgentPoolProfileProperties(Azure.ETag? eTag = default, int? count = default, string vmSize = null, int? osDiskSizeInGB = default, ContainerServiceOSDiskType? osDiskType = default, KubeletDiskType? kubeletDiskType = default, WorkloadRuntime? workloadRuntime = default, string messageOfTheDay = null, Azure.Core.ResourceIdentifier vnetSubnetId = null, Azure.Core.ResourceIdentifier podSubnetId = null, PodIPAllocationMode? podIPAllocationMode = default, int? maxPods = default, ContainerServiceOSType? osType = default, ContainerServiceOSSku? osSku = default, int? maxCount = default, int? minCount = default, bool? isAutoScalingEnabled = default, ScaleDownMode? scaleDownMode = default, AgentPoolType? agentPoolType = default, AgentPoolMode? mode = default, string orchestratorVersion = null, string currentOrchestratorVersion = null, string nodeImageVersion = null, AgentPoolUpgradeSettings upgradeSettings = null, string provisioningState = null, ContainerServiceStateCode? powerStateCode = default, IEnumerable<string> availabilityZones = null, bool? isNodePublicIpEnabled = default, Azure.Core.ResourceIdentifier nodePublicIPPrefixId = null, ScaleSetPriority? scaleSetPriority = default, ScaleSetEvictionPolicy? scaleSetEvictionPolicy = default, float? spotMaxPrice = default, IDictionary<string, string> tags = null, IDictionary<string, string> nodeLabels = null, IEnumerable<string> nodeTaints = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, KubeletConfig kubeletConfig = null, LinuxOSConfig linuxOSConfig = null, bool? isEncryptionAtHostEnabled = default, bool? isUltraSsdEnabled = default, bool? isFipsEnabled = default, GpuInstanceProfile? gpuInstanceProfile = default, Azure.Core.ResourceIdentifier creationDataSourceResourceId = null, Azure.Core.ResourceIdentifier capacityReservationGroupId = null, Azure.Core.ResourceIdentifier hostGroupId = null, AgentPoolNetworkProfile networkProfile = null, bool? isOutboundNatDisabled = default, AgentPoolSecurityProfile securityProfile = null, AgentPoolGpuDriver? gpuDriver = default, int? gatewayPublicIPPrefixSize = default, bool? isArtifactStreamingEnabled = default, IEnumerable<ManualScaleProfile> virtualMachinesScaleManual = null, IEnumerable<AgentPoolVirtualMachineNodes> virtualMachineNodesStatus = null, Azure.ResponseError statusProvisioningError = null, LocalDnsProfile localDnsProfile = null)
        {
            var result = ManagedClusterAgentPoolProfileProperties(
                eTag: eTag,
                count: count,
                vmSize: vmSize,
                osDiskSizeInGB: osDiskSizeInGB,
                osDiskType: osDiskType,
                kubeletDiskType: kubeletDiskType,
                workloadRuntime: workloadRuntime,
                messageOfTheDay: messageOfTheDay,
                vnetSubnetId: vnetSubnetId,
                podSubnetId: podSubnetId,
                podIPAllocationMode: podIPAllocationMode,
                maxPods: maxPods,
                osType: osType,
                osSku: osSku,
                maxCount: maxCount,
                minCount: minCount,
                isAutoScalingEnabled: isAutoScalingEnabled,
                scaleDownMode: scaleDownMode,
                agentPoolType: agentPoolType,
                mode: mode,
                orchestratorVersion: orchestratorVersion,
                currentOrchestratorVersion: currentOrchestratorVersion,
                nodeImageVersion: nodeImageVersion,
                upgradeSettings: upgradeSettings,
                provisioningState: provisioningState,
                powerStateCode: powerStateCode,
                availabilityZones: availabilityZones,
                isNodePublicIpEnabled: isNodePublicIpEnabled,
                nodePublicIPPrefixId: nodePublicIPPrefixId,
                scaleSetPriority: scaleSetPriority,
                scaleSetEvictionPolicy: scaleSetEvictionPolicy,
                spotMaxPrice: spotMaxPrice,
                tags: tags,
                nodeLabels: nodeLabels,
                nodeTaints: nodeTaints,
                proximityPlacementGroupId: proximityPlacementGroupId,
                kubeletConfig: kubeletConfig,
                linuxOSConfig: linuxOSConfig,
                isEncryptionAtHostEnabled: isEncryptionAtHostEnabled,
                isUltraSsdEnabled: isUltraSsdEnabled,
                isFipsEnabled: isFipsEnabled,
                gpuInstanceProfile: gpuInstanceProfile,
                creationDataSourceResourceId: creationDataSourceResourceId,
                capacityReservationGroupId: capacityReservationGroupId,
                hostGroupId: hostGroupId,
                networkProfile: networkProfile,
                isOutboundNatDisabled: isOutboundNatDisabled,
                securityProfile: securityProfile,
                gatewayPublicIPPrefixSize: gatewayPublicIPPrefixSize,
                isArtifactStreamingEnabled: isArtifactStreamingEnabled,
                virtualMachineNodesStatus: virtualMachineNodesStatus,
                statusProvisioningError: statusProvisioningError,
                localDnsProfile: localDnsProfile,
                virtualMachinesScaleManual: virtualMachinesScaleManual);
            result.GpuDriver = gpuDriver;
            return result;
        }
    }
}
