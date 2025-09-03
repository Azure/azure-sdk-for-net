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
    [CodeGenSuppress("NetworkCloudClusterData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(NetworkCloudRackDefinition), typeof(AnalyticsOutputSettings), typeof(ResourceIdentifier), typeof(IEnumerable<ClusterAvailableUpgradeVersion>), typeof(ClusterCapacity), typeof(ClusterConnectionStatus?), typeof(ExtendedLocation), typeof(string), typeof(ClusterManagerConnectionStatus?), typeof(ResourceIdentifier), typeof(ServicePrincipalInformation), typeof(ClusterType), typeof(string), typeof(CommandOutputSettings), typeof(ValidationThreshold), typeof(IEnumerable<NetworkCloudRackDefinition>), typeof(ClusterDetailedStatus?), typeof(string), typeof(ExtendedLocation), typeof(ManagedResourceGroupConfiguration), typeof(long?), typeof(ResourceIdentifier), typeof(ClusterProvisioningState?), typeof(RuntimeProtectionEnforcementLevel?), typeof(ClusterSecretArchive), typeof(SecretArchiveSettings), typeof(DateTimeOffset?), typeof(ClusterUpdateStrategy), typeof(VulnerabilityScanningSettingsContainerScan?), typeof(IEnumerable<ResourceIdentifier>), typeof(ETag?), typeof(ExtendedLocation), typeof(ManagedServiceIdentity))]
    [CodeGenSuppress("NetworkCloudBareMetalMachineData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(IEnumerable<ResourceIdentifier>), typeof(string), typeof(AdministrativeCredentials), typeof(string), typeof(string), typeof(ResourceIdentifier), typeof(BareMetalMachineCordonStatus?), typeof(BareMetalMachineDetailedStatus?), typeof(string), typeof(HardwareInventory), typeof(HardwareValidationStatus), typeof(IEnumerable<string>), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(string), typeof(IPAddress), typeof(string), typeof(string), typeof(BareMetalMachinePowerState?), typeof(BareMetalMachineProvisioningState?), typeof(ResourceIdentifier), typeof(long), typeof(BareMetalMachineReadyState?), typeof(RuntimeProtectionStatus), typeof(IEnumerable<SecretRotationStatus>), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(ETag?), typeof(ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudAgentPoolData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(AdministratorConfiguration), typeof(NetworkCloudAgentConfiguration), typeof(AttachedNetworkConfiguration), typeof(IEnumerable<string>), typeof(long), typeof(AgentPoolDetailedStatus?), typeof(string), typeof(string), typeof(IEnumerable<KubernetesLabel>), typeof(NetworkCloudAgentPoolMode), typeof(AgentPoolProvisioningState?), typeof(IEnumerable<KubernetesLabel>), typeof(AgentPoolUpgradeSettings), typeof(string), typeof(ETag?), typeof(ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudBareMetalMachineKeySetData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(string), typeof(BareMetalMachineKeySetDetailedStatus?), typeof(string), typeof(DateTimeOffset), typeof(IEnumerable<IPAddress>), typeof(DateTimeOffset?), typeof(string), typeof(BareMetalMachineKeySetPrivilegeLevel), typeof(BareMetalMachineKeySetProvisioningState?), typeof(IEnumerable<KeySetUser>), typeof(IEnumerable<KeySetUserStatus>), typeof(ETag?), typeof(ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudBmcKeySetData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(string), typeof(BmcKeySetDetailedStatus?), typeof(string), typeof(DateTimeOffset), typeof(DateTimeOffset?), typeof(BmcKeySetPrivilegeLevel), typeof(BmcKeySetProvisioningState?), typeof(IEnumerable<KeySetUser>), typeof(IEnumerable<KeySetUserStatus>), typeof(ETag?), typeof(ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudCloudServicesNetworkData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(IEnumerable<EgressEndpoint>), typeof(IEnumerable<ResourceIdentifier>), typeof(ResourceIdentifier), typeof(CloudServicesNetworkDetailedStatus?), typeof(string), typeof(CloudServicesNetworkEnableDefaultEgressEndpoint?), typeof(IEnumerable<EgressEndpoint>), typeof(IEnumerable<ResourceIdentifier>), typeof(string), typeof(CloudServicesNetworkProvisioningState?), typeof(IEnumerable<ResourceIdentifier>), typeof(ETag?), typeof(ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudClusterManagerData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(ResourceIdentifier), typeof(IEnumerable<string>), typeof(IEnumerable<ClusterAvailableVersion>), typeof(ClusterManagerDetailedStatus?), typeof(string), typeof(ResourceIdentifier), typeof(ManagedResourceGroupConfiguration), typeof(ExtendedLocation), typeof(ClusterManagerProvisioningState?), typeof(string), typeof(ETag?), typeof(ManagedServiceIdentity))]
    [CodeGenSuppress("NetworkCloudClusterMetricsConfigurationData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(long), typeof(ClusterMetricsConfigurationDetailedStatus?), typeof(string), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(ClusterMetricsConfigurationProvisioningState?), typeof(ETag?), typeof(ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudKubernetesClusterData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(IEnumerable<string>), typeof(AdministratorConfiguration), typeof(IEnumerable<ResourceIdentifier>), typeof(IEnumerable<AvailableUpgrade>), typeof(ResourceIdentifier), typeof(ResourceIdentifier), typeof(string), typeof(ControlPlaneNodeConfiguration), typeof(KubernetesClusterDetailedStatus?), typeof(string), typeof(IEnumerable<FeatureStatus>), typeof(IEnumerable<InitialAgentPoolConfiguration>), typeof(string), typeof(ManagedResourceGroupConfiguration), typeof(KubernetesClusterNetworkConfiguration), typeof(IEnumerable<KubernetesClusterNode>), typeof(KubernetesClusterProvisioningState?), typeof(ETag?), typeof(ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudKubernetesClusterFeatureData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(KubernetesClusterFeatureAvailabilityLifecycle?), typeof(KubernetesClusterFeatureDetailedStatus?), typeof(string), typeof(IEnumerable<StringKeyValuePair>), typeof(KubernetesClusterFeatureProvisioningState?), typeof(KubernetesClusterFeatureRequired?), typeof(string), typeof(ETag?))]
    [CodeGenSuppress("NetworkCloudL2NetworkData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(IEnumerable<ResourceIdentifier>), typeof(ResourceIdentifier), typeof(L2NetworkDetailedStatus?), typeof(string), typeof(IEnumerable<ResourceIdentifier>), typeof(HybridAksPluginType?), typeof(string), typeof(ResourceIdentifier), typeof(L2NetworkProvisioningState?), typeof(IEnumerable<ResourceIdentifier>), typeof(ETag?), typeof(ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudL3NetworkData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(IEnumerable<ResourceIdentifier>), typeof(ResourceIdentifier), typeof(L3NetworkDetailedStatus?), typeof(string), typeof(IEnumerable<ResourceIdentifier>), typeof(HybridAksIpamEnabled?), typeof(HybridAksPluginType?), typeof(string), typeof(IPAllocationType?), typeof(string), typeof(string), typeof(ResourceIdentifier), typeof(L3NetworkProvisioningState?), typeof(IEnumerable<ResourceIdentifier>), typeof(long), typeof(ETag?), typeof(ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudOperationStatusResult", typeof(DateTimeOffset?), typeof(ResponseError), typeof(ResourceIdentifier), typeof(string), typeof(IEnumerable<NetworkCloudOperationStatusResult>), typeof(float?), typeof(string), typeof(string), typeof(Uri), typeof(Uri), typeof(ResourceIdentifier), typeof(DateTimeOffset?), typeof(string))]
    [CodeGenSuppress("NetworkCloudRackData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(string), typeof(ResourceIdentifier), typeof(RackDetailedStatus?), typeof(string), typeof(RackProvisioningState?), typeof(string), typeof(string), typeof(ResourceIdentifier), typeof(ETag?), typeof(ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudStorageApplianceData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(AdministrativeCredentials), typeof(long?), typeof(long?), typeof(ResourceIdentifier), typeof(StorageApplianceDetailedStatus?), typeof(string), typeof(IPAddress), typeof(string), typeof(string), typeof(StorageApplianceProvisioningState?), typeof(ResourceIdentifier), typeof(long), typeof(RemoteVendorManagementFeature?), typeof(RemoteVendorManagementStatus?), typeof(IEnumerable<SecretRotationStatus>), typeof(string), typeof(string), typeof(string), typeof(ETag?), typeof(ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudTrunkedNetworkData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(IEnumerable<string>), typeof(ResourceIdentifier), typeof(TrunkedNetworkDetailedStatus?), typeof(string), typeof(IEnumerable<ResourceIdentifier>), typeof(HybridAksPluginType?), typeof(string), typeof(IEnumerable<ResourceIdentifier>), typeof(TrunkedNetworkProvisioningState?), typeof(IEnumerable<ResourceIdentifier>), typeof(IEnumerable<long>), typeof(ETag?), typeof(ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudVirtualMachineConsoleData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(ConsoleDetailedStatus?), typeof(string), typeof(ConsoleEnabled), typeof(DateTimeOffset?), typeof(ResourceIdentifier), typeof(ConsoleProvisioningState?), typeof(string), typeof(Guid?), typeof(ETag?), typeof(ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudVirtualMachineData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(string), typeof(string), typeof(ResourceIdentifier), typeof(VirtualMachineBootMethod?), typeof(NetworkAttachment), typeof(ResourceIdentifier), typeof(ExtendedLocation), typeof(long), typeof(VirtualMachineDetailedStatus?), typeof(string), typeof(VirtualMachineIsolateEmulatorThread?), typeof(long), typeof(IEnumerable<NetworkAttachment>), typeof(string), typeof(IEnumerable<VirtualMachinePlacementHint>), typeof(VirtualMachinePowerState?), typeof(VirtualMachineProvisioningState?), typeof(IEnumerable<NetworkCloudSshPublicKey>), typeof(NetworkCloudStorageProfile), typeof(string), typeof(VirtualMachineVirtioInterfaceType?), typeof(VirtualMachineDeviceModelType?), typeof(string), typeof(ImageRepositoryCredentials), typeof(IEnumerable<ResourceIdentifier>), typeof(ETag?), typeof(ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudVolumeData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(IEnumerable<string>), typeof(VolumeDetailedStatus?), typeof(string), typeof(VolumeProvisioningState?), typeof(string), typeof(long), typeof(ETag?), typeof(ExtendedLocation))]
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
                null,
                extendedLocation,
                serializedAdditionalRawData: null);
        }
        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudAgentPoolData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Resource ETag. </param>
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
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudAgentPoolData"/> instance for mocking. </returns>
        public static NetworkCloudAgentPoolData NetworkCloudAgentPoolData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ETag? etag = default(ETag?), ExtendedLocation extendedLocation = null, AdministratorConfiguration administratorConfiguration = null, NetworkCloudAgentConfiguration agentOptions = null, AttachedNetworkConfiguration attachedNetworkConfiguration = null, IEnumerable<string> availabilityZones = null, long count = (long)0, AgentPoolDetailedStatus? detailedStatus = default(AgentPoolDetailedStatus?), string detailedStatusMessage = null, string kubernetesVersion = null, IEnumerable<KubernetesLabel> labels = null, NetworkCloudAgentPoolMode mode = default(NetworkCloudAgentPoolMode), AgentPoolProvisioningState? provisioningState = default(AgentPoolProvisioningState?), IEnumerable<KubernetesLabel> taints = null, AgentPoolUpgradeSettings upgradeSettings = null, string vmSkuName = null)
            => new NetworkCloudAgentPoolData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
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
                upgradeSettings,
                vmSkuName,
                etag,
                extendedLocation,
                serializedAdditionalRawData: null
                );

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

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudClusterData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster manager associated with the cluster. </param>
        /// <param name="aggregatorOrSingleRackDefinition"> The rack definition that is intended to reflect only a single rack in a single rack cluster, or an aggregator rack in a multi-rack cluster. </param>
        /// <param name="analyticsWorkspaceId"> Field Deprecated. The resource ID of the Log Analytics Workspace that will be used for storing relevant logs. </param>
        /// <param name="availableUpgradeVersions"> The list of cluster runtime version upgrades available for this cluster. </param>
        /// <param name="clusterCapacity"> The capacity supported by this cluster. </param>
        /// <param name="clusterConnectionStatus"> The latest heartbeat status between the cluster manager and the cluster. </param>
        /// <param name="clusterExtendedLocation"> The extended location (custom location) that represents the cluster's control plane location. This extended location is used to route the requests of child objects of the cluster that are handled by the platform operator. </param>
        /// <param name="clusterLocation"> The customer-provided location information to identify where the cluster resides. </param>
        /// <param name="clusterManagerConnectionStatus"> The latest connectivity status between cluster manager and the cluster. </param>
        /// <param name="clusterManagerId"> The resource ID of the cluster manager that manages this cluster. This is set by the Cluster Manager when the cluster is created. </param>
        /// <param name="clusterServicePrincipal"> The service principal to be used by the cluster during Arc Appliance installation. </param>
        /// <param name="clusterType"> The type of rack configuration for the cluster. </param>
        /// <param name="clusterVersion"> The current runtime version of the cluster. </param>
        /// <param name="computeDeploymentThreshold"> The validation threshold indicating the allowable failures of compute machines during environment validation and deployment. </param>
        /// <param name="computeRackDefinitions">
        /// The list of rack definitions for the compute racks in a multi-rack
        /// cluster, or an empty list in a single-rack cluster.
        /// </param>
        /// <param name="detailedStatus"> The current detailed status of the cluster. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the detailed status. </param>
        /// <param name="hybridAksExtendedLocation"> Field Deprecated. This field will not be populated in an upcoming version. The extended location (custom location) that represents the Hybrid AKS control plane location. This extended location is used when creating provisioned clusters (Hybrid AKS clusters). </param>
        /// <param name="managedResourceGroupConfiguration"> The configuration of the managed resource group associated with the resource. </param>
        /// <param name="manualActionCount"> The count of Manual Action Taken (MAT) events that have not been validated. </param>
        /// <param name="networkFabricId"> The resource ID of the Network Fabric associated with the cluster. </param>
        /// <param name="provisioningState"> The provisioning state of the cluster. </param>
        /// <param name="supportExpireOn"> The support end date of the runtime version of the cluster. </param>
        /// <param name="workloadResourceIds"> The list of workload resource IDs that are hosted within this cluster. </param>
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudClusterData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkCloudClusterData NetworkCloudClusterData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, NetworkCloudRackDefinition aggregatorOrSingleRackDefinition, ResourceIdentifier analyticsWorkspaceId, IEnumerable<ClusterAvailableUpgradeVersion> availableUpgradeVersions, ClusterCapacity clusterCapacity, ClusterConnectionStatus? clusterConnectionStatus, ExtendedLocation clusterExtendedLocation, string clusterLocation, ClusterManagerConnectionStatus? clusterManagerConnectionStatus, ResourceIdentifier clusterManagerId, ServicePrincipalInformation clusterServicePrincipal, ClusterType clusterType, string clusterVersion, ValidationThreshold computeDeploymentThreshold, IEnumerable<NetworkCloudRackDefinition> computeRackDefinitions, ClusterDetailedStatus? detailedStatus, string detailedStatusMessage, ExtendedLocation hybridAksExtendedLocation, ManagedResourceGroupConfiguration managedResourceGroupConfiguration, long? manualActionCount, ResourceIdentifier networkFabricId, ClusterProvisioningState? provisioningState, DateTimeOffset? supportExpireOn, IEnumerable<ResourceIdentifier> workloadResourceIds)

            => new NetworkCloudClusterData(
                 id,
                 name,
                 resourceType,
                 systemData,
                 tags,
                 location,
                 aggregatorOrSingleRackDefinition,
                 null,
                 analyticsWorkspaceId,
                 availableUpgradeVersions?.ToList(),
                 clusterCapacity,
                 clusterConnectionStatus,
                 clusterExtendedLocation,
                 clusterLocation,
                 clusterManagerConnectionStatus,
                 clusterManagerId,
                 clusterServicePrincipal,
                 clusterType,
                 clusterVersion,
                 null,
                 computeDeploymentThreshold,
                 computeRackDefinitions?.ToList(),
                 detailedStatus,
                 detailedStatusMessage,
                 hybridAksExtendedLocation,
                 managedResourceGroupConfiguration,
                 manualActionCount,
                 networkFabricId,
                 provisioningState,
                 null,
                 null,
                 null,
                 supportExpireOn,
                 null,
                 null,
                 workloadResourceIds?.ToList(),
                 null,
                 extendedLocation,
                 null,
                 serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of <see cref="Models.MachineSkuSlot"/>. </summary>
        /// <param name="rackSlot"> The position in the rack for the machine. </param>
        /// <param name="bootstrapProtocol"> The type of bootstrap protocol used. </param>
        /// <param name="cpuCores"> The count of CPU cores for this machine. </param>
        /// <param name="cpuSockets"> The count of CPU sockets for this machine. </param>
        /// <param name="disks"> The list of disks. </param>
        /// <param name="generation"> The generation of the architecture. </param>
        /// <param name="hardwareVersion"> The hardware version of the machine. </param>
        /// <param name="memoryCapacityGB"> The maximum amount of memory. Measured in gibibytes. </param>
        /// <param name="model"> The model of the machine. </param>
        /// <param name="networkInterfaces"> The list of network interfaces. </param>
        /// <param name="totalThreads"> The count of SMT and physical core threads for this machine. </param>
        /// <param name="vendor"> The make of the machine. </param>
        public static MachineSkuSlot MachineSkuSlot(long? rackSlot = default(long?), BootstrapProtocol? bootstrapProtocol = default(BootstrapProtocol?), long? cpuCores = default(long?), long? cpuSockets = default(long?), IEnumerable<MachineDisk> disks = null, string generation = null, string hardwareVersion = null, long? memoryCapacityGB = default(long?), string model = null, IEnumerable<NetworkCloudNetworkInterface> networkInterfaces = null, long? totalThreads = default(long?), string vendor = null)
           => new MachineSkuSlot(
                bootstrapProtocol,
                cpuCores,
                cpuSockets,
                disks?.ToList(),
                generation,
                hardwareVersion,
                memoryCapacityGB,
                model,
                networkInterfaces?.ToList(),
                totalThreads,
                vendor,
                rackSlot,
                serializedAdditionalRawData: null
            );

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudBareMetalMachineData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Resource ETag. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="associatedResourceIds"> The list of resource IDs for the other Microsoft.NetworkCloud resources that have attached this network. </param>
        /// <param name="bmcConnectionString"> The connection string for the baseboard management controller including IP address and protocol. </param>
        /// <param name="bmcCredentials"> The credentials of the baseboard management controller on this bare metal machine. </param>
        /// <param name="bmcMacAddress"> The MAC address of the BMC device. </param>
        /// <param name="bootMacAddress"> The MAC address of a NIC connected to the PXE network. </param>
        /// <param name="clusterId"> The resource ID of the cluster this bare metal machine is associated with. </param>
        /// <param name="cordonStatus"> The cordon status of the bare metal machine. </param>
        /// <param name="detailedStatus"> The more detailed status of the bare metal machine. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="hardwareInventory"> The hardware inventory, including information acquired from the model/sku information and from the ironic inspector. </param>
        /// <param name="hardwareValidationStatus"> The details of the latest hardware validation performed for this bare metal machine. </param>
        /// <param name="hybridAksClustersAssociatedIds"> Field Deprecated. These fields will be empty/omitted. The list of the resource IDs for the HybridAksClusters that have nodes hosted on this bare metal machine. </param>
        /// <param name="kubernetesNodeName"> The name of this machine represented by the host object in the Cluster's Kubernetes control plane. </param>
        /// <param name="kubernetesVersion"> The version of Kubernetes running on this machine. </param>
        /// <param name="machineClusterVersion"> The cluster version that has been applied to this machine during deployment or a version update. </param>
        /// <param name="machineDetails"> The custom details provided by the customer. </param>
        /// <param name="machineName"> The OS-level hostname assigned to this machine. </param>
        /// <param name="machineRoles"> The list of roles that are assigned to the cluster node running on this machine. </param>
        /// <param name="machineSkuId"> The unique internal identifier of the bare metal machine SKU. </param>
        /// <param name="oamIPv4Address"> The IPv4 address that is assigned to the bare metal machine during the cluster deployment. </param>
        /// <param name="oamIPv6Address"> The IPv6 address that is assigned to the bare metal machine during the cluster deployment. </param>
        /// <param name="osImage"> The image that is currently provisioned to the OS disk. </param>
        /// <param name="powerState"> The power state derived from the baseboard management controller. </param>
        /// <param name="provisioningState"> The provisioning state of the bare metal machine. </param>
        /// <param name="rackId"> The resource ID of the rack where this bare metal machine resides. </param>
        /// <param name="rackSlot"> The rack slot in which this bare metal machine is located, ordered from the bottom up i.e. the lowest slot is 1. </param>
        /// <param name="readyState"> The indicator of whether the bare metal machine is ready to receive workloads. </param>
        /// <param name="runtimeProtectionStatus"> The runtime protection status of the bare metal machine. </param>
        /// <param name="secretRotationStatus"> The list of statuses that represent secret rotation activity. </param>
        /// <param name="serialNumber"> The serial number of the bare metal machine. </param>
        /// <param name="serviceTag"> The discovered value of the machine's service tag. </param>
        /// <param name="virtualMachinesAssociatedIds"> Field Deprecated. These fields will be empty/omitted. The list of the resource IDs for the VirtualMachines that are hosted on this bare metal machine. </param>
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudBareMetalMachineData"/> instance for mocking. </returns>
        public static NetworkCloudBareMetalMachineData NetworkCloudBareMetalMachineData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ETag? etag = default(ETag?), ExtendedLocation extendedLocation = null, IEnumerable<ResourceIdentifier> associatedResourceIds = null, string bmcConnectionString = null, AdministrativeCredentials bmcCredentials = null, string bmcMacAddress = null, string bootMacAddress = null, ResourceIdentifier clusterId = null, BareMetalMachineCordonStatus? cordonStatus = default(BareMetalMachineCordonStatus?), BareMetalMachineDetailedStatus? detailedStatus = default(BareMetalMachineDetailedStatus?), string detailedStatusMessage = null, HardwareInventory hardwareInventory = null, HardwareValidationStatus hardwareValidationStatus = null, IEnumerable<string> hybridAksClustersAssociatedIds = null, string kubernetesNodeName = null, string kubernetesVersion = null, string machineClusterVersion = null, string machineDetails = null, string machineName = null, IEnumerable<string> machineRoles = null, string machineSkuId = null, IPAddress oamIPv4Address = null, string oamIPv6Address = null, string osImage = null, BareMetalMachinePowerState? powerState = default(BareMetalMachinePowerState?), BareMetalMachineProvisioningState? provisioningState = default(BareMetalMachineProvisioningState?), ResourceIdentifier rackId = null, long rackSlot = (long)0, BareMetalMachineReadyState? readyState = default(BareMetalMachineReadyState?), RuntimeProtectionStatus runtimeProtectionStatus = null, IEnumerable<SecretRotationStatus> secretRotationStatus = null, string serialNumber = null, string serviceTag = null, IEnumerable<string> virtualMachinesAssociatedIds = null)
        => new NetworkCloudBareMetalMachineData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                associatedResourceIds?.ToList(),
                bmcConnectionString,
                bmcCredentials,
                bmcMacAddress,
                bootMacAddress,
                clusterId,
                cordonStatus,
                detailedStatus,
                detailedStatusMessage,
                hardwareInventory,
                hardwareValidationStatus,
                hybridAksClustersAssociatedIds?.ToList(),
                kubernetesNodeName,
                kubernetesVersion,
                machineClusterVersion,
                machineDetails,
                machineName,
                machineRoles?.ToList(),
                machineSkuId,
                oamIPv4Address,
                oamIPv6Address,
                osImage,
                powerState,
                provisioningState,
                rackId,
                rackSlot,
                readyState,
                runtimeProtectionStatus,
                secretRotationStatus?.ToList(),
                serialNumber,
                serviceTag,
                virtualMachinesAssociatedIds?.ToList(),
                etag,
                extendedLocation,
                serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudClusterData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Resource ETag. </param>
        /// <param name="extendedLocation"> The extended location of the cluster manager associated with the cluster. </param>
        /// <param name="identity"> The identity for the resource. </param>
        /// <param name="aggregatorOrSingleRackDefinition"> The rack definition that is intended to reflect only a single rack in a single rack cluster, or an aggregator rack in a multi-rack cluster. </param>
        /// <param name="analyticsOutputSettings"> The settings for the log analytics workspace used for output of logs from this cluster. </param>
        /// <param name="analyticsWorkspaceId"> Field Deprecated. The resource ID of the Log Analytics Workspace that will be used for storing relevant logs. </param>
        /// <param name="availableUpgradeVersions"> The list of cluster runtime version upgrades available for this cluster. </param>
        /// <param name="clusterCapacity"> The capacity supported by this cluster. </param>
        /// <param name="clusterConnectionStatus"> The latest heartbeat status between the cluster manager and the cluster. </param>
        /// <param name="clusterExtendedLocation"> The extended location (custom location) that represents the cluster's control plane location. This extended location is used to route the requests of child objects of the cluster that are handled by the platform operator. </param>
        /// <param name="clusterLocation"> The customer-provided location information to identify where the cluster resides. </param>
        /// <param name="clusterManagerConnectionStatus"> The latest connectivity status between cluster manager and the cluster. </param>
        /// <param name="clusterManagerId"> The resource ID of the cluster manager that manages this cluster. This is set by the Cluster Manager when the cluster is created. </param>
        /// <param name="clusterServicePrincipal"> The service principal to be used by the cluster during Arc Appliance installation. </param>
        /// <param name="clusterType"> The type of rack configuration for the cluster. </param>
        /// <param name="clusterVersion"> The current runtime version of the cluster. </param>
        /// <param name="commandOutputSettings"> The settings for commands run in this cluster, such as bare metal machine run read only commands and data extracts. </param>
        /// <param name="computeDeploymentThreshold"> The validation threshold indicating the allowable failures of compute machines during environment validation and deployment. </param>
        /// <param name="computeRackDefinitions">
        /// The list of rack definitions for the compute racks in a multi-rack
        /// cluster, or an empty list in a single-rack cluster.
        /// </param>
        /// <param name="detailedStatus"> The current detailed status of the cluster. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the detailed status. </param>
        /// <param name="hybridAksExtendedLocation"> Field Deprecated. This field will not be populated in an upcoming version. The extended location (custom location) that represents the Hybrid AKS control plane location. This extended location is used when creating provisioned clusters (Hybrid AKS clusters). </param>
        /// <param name="managedResourceGroupConfiguration"> The configuration of the managed resource group associated with the resource. </param>
        /// <param name="manualActionCount"> The count of Manual Action Taken (MAT) events that have not been validated. </param>
        /// <param name="networkFabricId"> The resource ID of the Network Fabric associated with the cluster. </param>
        /// <param name="provisioningState"> The provisioning state of the cluster. </param>
        /// <param name="runtimeProtectionEnforcementLevel"> The settings for cluster runtime protection. </param>
        /// <param name="secretArchive"> The configuration for use of a key vault to store secrets for later retrieval by the operator. </param>
        /// <param name="secretArchiveSettings"> The settings for the secret archive used to hold credentials for the cluster. </param>
        /// <param name="supportExpireOn"> The support end date of the runtime version of the cluster. </param>
        /// <param name="updateStrategy"> The strategy for updating the cluster. </param>
        /// <param name="vulnerabilityScanningContainerScan"> The settings for how security vulnerability scanning is applied to the cluster. </param>
        /// <param name="workloadResourceIds"> The list of workload resource IDs that are hosted within this cluster. </param>
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudClusterData"/> instance for mocking. </returns>
        public static NetworkCloudClusterData NetworkCloudClusterData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ETag? etag = default(ETag?), ExtendedLocation extendedLocation = null, ManagedServiceIdentity identity = null, NetworkCloudRackDefinition aggregatorOrSingleRackDefinition = null, AnalyticsOutputSettings analyticsOutputSettings = null, ResourceIdentifier analyticsWorkspaceId = null, IEnumerable<ClusterAvailableUpgradeVersion> availableUpgradeVersions = null, ClusterCapacity clusterCapacity = null, ClusterConnectionStatus? clusterConnectionStatus = default(ClusterConnectionStatus?), ExtendedLocation clusterExtendedLocation = null, string clusterLocation = null, ClusterManagerConnectionStatus? clusterManagerConnectionStatus = default(ClusterManagerConnectionStatus?), ResourceIdentifier clusterManagerId = null, ServicePrincipalInformation clusterServicePrincipal = null, ClusterType clusterType = default(ClusterType), string clusterVersion = null, CommandOutputSettings commandOutputSettings = null, ValidationThreshold computeDeploymentThreshold = null, IEnumerable<NetworkCloudRackDefinition> computeRackDefinitions = null, ClusterDetailedStatus? detailedStatus = default(ClusterDetailedStatus?), string detailedStatusMessage = null, ExtendedLocation hybridAksExtendedLocation = null, ManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, long? manualActionCount = default(long?), ResourceIdentifier networkFabricId = null, ClusterProvisioningState? provisioningState = default(ClusterProvisioningState?), RuntimeProtectionEnforcementLevel? runtimeProtectionEnforcementLevel = default(RuntimeProtectionEnforcementLevel?), ClusterSecretArchive secretArchive = null, SecretArchiveSettings secretArchiveSettings = null, DateTimeOffset? supportExpireOn = default(DateTimeOffset?), ClusterUpdateStrategy updateStrategy = null, VulnerabilityScanningSettingsContainerScan? vulnerabilityScanningContainerScan = default(VulnerabilityScanningSettingsContainerScan?), IEnumerable<ResourceIdentifier> workloadResourceIds = null)
            => new NetworkCloudClusterData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                aggregatorOrSingleRackDefinition,
                analyticsOutputSettings,
                analyticsWorkspaceId,
                availableUpgradeVersions?.ToList(),
                clusterCapacity,
                clusterConnectionStatus,
                clusterExtendedLocation,
                clusterLocation,
                clusterManagerConnectionStatus,
                clusterManagerId,
                clusterServicePrincipal,
                clusterType,
                clusterVersion,
                commandOutputSettings,
                computeDeploymentThreshold,
                computeRackDefinitions?.ToList(),
                detailedStatus,
                detailedStatusMessage,
                hybridAksExtendedLocation,
                managedResourceGroupConfiguration,
                manualActionCount,
                networkFabricId,
                provisioningState,
                runtimeProtectionEnforcementLevel != null ? new RuntimeProtectionConfiguration(runtimeProtectionEnforcementLevel, serializedAdditionalRawData: null) : null,
                secretArchive,
                secretArchiveSettings,
                supportExpireOn,
                updateStrategy,
                vulnerabilityScanningContainerScan != null ? new VulnerabilityScanningSettings(vulnerabilityScanningContainerScan, serializedAdditionalRawData: null) : null,
                workloadResourceIds?.ToList(),
                etag,
                extendedLocation,
                identity,
                serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudBareMetalMachineKeySetData"/>. </summary>
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
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudBareMetalMachineKeySetData"/> instance for mocking. </returns>
        public static NetworkCloudBareMetalMachineKeySetData NetworkCloudBareMetalMachineKeySetData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ETag? etag = default(ETag?), ExtendedLocation extendedLocation = null, string azureGroupId = null, BareMetalMachineKeySetDetailedStatus? detailedStatus = default(BareMetalMachineKeySetDetailedStatus?), string detailedStatusMessage = null, DateTimeOffset expireOn = default(DateTimeOffset), IEnumerable<IPAddress> jumpHostsAllowed = null, DateTimeOffset? lastValidatedOn = default(DateTimeOffset?), string osGroupName = null, BareMetalMachineKeySetPrivilegeLevel privilegeLevel = default(BareMetalMachineKeySetPrivilegeLevel), BareMetalMachineKeySetProvisioningState? provisioningState = default(BareMetalMachineKeySetProvisioningState?), IEnumerable<KeySetUser> userList = null, IEnumerable<KeySetUserStatus> userListStatus = null)
            => new NetworkCloudBareMetalMachineKeySetData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                azureGroupId,
                detailedStatus,
                detailedStatusMessage,
                expireOn,
                jumpHostsAllowed?.ToList(),
                lastValidatedOn,
                osGroupName,
                privilegeLevel,
                provisioningState,
                userList?.ToList(),
                userListStatus?.ToList(),
                etag,
                extendedLocation,
                serializedAdditionalRawData: null
                );

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudBmcKeySetData"/>. </summary>
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
        /// <param name="expireOn"> The date and time after which the users in this key set will be removed from the baseboard management controllers. </param>
        /// <param name="lastValidatedOn"> The last time this key set was validated. </param>
        /// <param name="privilegeLevel"> The access level allowed for the users in this key set. </param>
        /// <param name="provisioningState"> The provisioning state of the baseboard management controller key set. </param>
        /// <param name="userList"> The unique list of permitted users. </param>
        /// <param name="userListStatus"> The status evaluation of each user. </param>
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudBmcKeySetData"/> instance for mocking. </returns>
        public static NetworkCloudBmcKeySetData NetworkCloudBmcKeySetData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ETag? etag = default(ETag?), ExtendedLocation extendedLocation = null, string azureGroupId = null, BmcKeySetDetailedStatus? detailedStatus = default(BmcKeySetDetailedStatus?), string detailedStatusMessage = null, DateTimeOffset expireOn = default(DateTimeOffset), DateTimeOffset? lastValidatedOn = default(DateTimeOffset?), BmcKeySetPrivilegeLevel privilegeLevel = default(BmcKeySetPrivilegeLevel), BmcKeySetProvisioningState? provisioningState = default(BmcKeySetProvisioningState?), IEnumerable<KeySetUser> userList = null, IEnumerable<KeySetUserStatus> userListStatus = null)
            => new NetworkCloudBmcKeySetData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                azureGroupId,
                detailedStatus,
                detailedStatusMessage,
                expireOn,
                lastValidatedOn,
                privilegeLevel,
                provisioningState,
                userList?.ToList(),
                userListStatus?.ToList(),
                etag,
                extendedLocation,
                serializedAdditionalRawData: null
                );

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudCloudServicesNetworkData"/>. </summary>
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
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudCloudServicesNetworkData"/> instance for mocking. </returns>
        public static NetworkCloudCloudServicesNetworkData NetworkCloudCloudServicesNetworkData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ETag? etag = default(ETag?), ExtendedLocation extendedLocation = null, IEnumerable<EgressEndpoint> additionalEgressEndpoints = null, IEnumerable<ResourceIdentifier> associatedResourceIds = null, ResourceIdentifier clusterId = null, CloudServicesNetworkDetailedStatus? detailedStatus = default(CloudServicesNetworkDetailedStatus?), string detailedStatusMessage = null, CloudServicesNetworkEnableDefaultEgressEndpoint? enableDefaultEgressEndpoints = default(CloudServicesNetworkEnableDefaultEgressEndpoint?), IEnumerable<EgressEndpoint> enabledEgressEndpoints = null, IEnumerable<ResourceIdentifier> hybridAksClustersAssociatedIds = null, string interfaceName = null, CloudServicesNetworkProvisioningState? provisioningState = default(CloudServicesNetworkProvisioningState?), IEnumerable<ResourceIdentifier> virtualMachinesAssociatedIds = null)
        => new NetworkCloudCloudServicesNetworkData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                additionalEgressEndpoints?.ToList(),
                associatedResourceIds?.ToList(),
                clusterId,
                detailedStatus,
                detailedStatusMessage,
                enableDefaultEgressEndpoints,
                enabledEgressEndpoints?.ToList(),
                hybridAksClustersAssociatedIds?.ToList(),
                interfaceName,
                provisioningState,
                virtualMachinesAssociatedIds?.ToList(),
                etag,
                extendedLocation,
                serializedAdditionalRawData: null
                );

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudClusterManagerData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Resource ETag. </param>
        /// <param name="identity"> The identity of the cluster manager. </param>
        /// <param name="analyticsWorkspaceId"> The resource ID of the Log Analytics workspace that is used for the logs collection. </param>
        /// <param name="availabilityZones"> Field deprecated, this value will no longer influence the cluster manager allocation process and will be removed in a future version. The Azure availability zones within the region that will be used to support the cluster manager resource. </param>
        /// <param name="clusterVersions"> The list of the cluster versions the manager supports. It is used as input in clusterVersion property of a cluster resource. </param>
        /// <param name="detailedStatus"> The detailed status that provides additional information about the cluster manager. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="fabricControllerId"> The resource ID of the fabric controller that has one to one mapping with the cluster manager. </param>
        /// <param name="managedResourceGroupConfiguration"> The configuration of the managed resource group associated with the resource. </param>
        /// <param name="managerExtendedLocation"> The extended location (custom location) that represents the cluster manager's control plane location. This extended location is used when creating cluster and rack manifest resources. </param>
        /// <param name="provisioningState"> The provisioning state of the cluster manager. </param>
        /// <param name="vmSize"> Field deprecated, this value will no longer influence the cluster manager allocation process and will be removed in a future version. The size of the Azure virtual machines to use for hosting the cluster manager resource. </param>
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudClusterManagerData"/> instance for mocking. </returns>
        public static NetworkCloudClusterManagerData NetworkCloudClusterManagerData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ETag? etag = default(ETag?), ManagedServiceIdentity identity = null, ResourceIdentifier analyticsWorkspaceId = null, IEnumerable<string> availabilityZones = null, IEnumerable<ClusterAvailableVersion> clusterVersions = null, ClusterManagerDetailedStatus? detailedStatus = default(ClusterManagerDetailedStatus?), string detailedStatusMessage = null, ResourceIdentifier fabricControllerId = null, ManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, ExtendedLocation managerExtendedLocation = null, ClusterManagerProvisioningState? provisioningState = default(ClusterManagerProvisioningState?), string vmSize = null)
            => new NetworkCloudClusterManagerData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                analyticsWorkspaceId,
                availabilityZones?.ToList(),
                clusterVersions?.ToList(),
                detailedStatus,
                detailedStatusMessage,
                fabricControllerId,
                managedResourceGroupConfiguration,
                managerExtendedLocation,
                provisioningState,
                vmSize,
                etag,
                identity,
                serializedAdditionalRawData: null
                );

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudClusterMetricsConfigurationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Resource ETag. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="collectionInterval"> The interval in minutes by which metrics will be collected. </param>
        /// <param name="detailedStatus"> The more detailed status of the metrics configuration. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="disabledMetrics"> The list of metrics that are available for the cluster but disabled at the moment. </param>
        /// <param name="enabledMetrics"> The list of metric names that have been chosen to be enabled in addition to the core set of enabled metrics. </param>
        /// <param name="provisioningState"> The provisioning state of the metrics configuration. </param>
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudClusterMetricsConfigurationData"/> instance for mocking. </returns>
        public static NetworkCloudClusterMetricsConfigurationData NetworkCloudClusterMetricsConfigurationData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ETag? etag = default(ETag?), ExtendedLocation extendedLocation = null, long collectionInterval = (long)0, ClusterMetricsConfigurationDetailedStatus? detailedStatus = default(ClusterMetricsConfigurationDetailedStatus?), string detailedStatusMessage = null, IEnumerable<string> disabledMetrics = null, IEnumerable<string> enabledMetrics = null, ClusterMetricsConfigurationProvisioningState? provisioningState = default(ClusterMetricsConfigurationProvisioningState?))
            => new NetworkCloudClusterMetricsConfigurationData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                collectionInterval,
                detailedStatus,
                detailedStatusMessage,
                disabledMetrics?.ToList(),
                enabledMetrics?.ToList(),
                provisioningState,
                etag,
                extendedLocation,
                serializedAdditionalRawData: null
                );

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudKubernetesClusterData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Resource ETag. </param>
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
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudKubernetesClusterData"/> instance for mocking. </returns>
        public static NetworkCloudKubernetesClusterData NetworkCloudKubernetesClusterData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ETag? etag = default(ETag?), ExtendedLocation extendedLocation = null, IEnumerable<string> aadAdminGroupObjectIds = null, AdministratorConfiguration administratorConfiguration = null, IEnumerable<ResourceIdentifier> attachedNetworkIds = null, IEnumerable<AvailableUpgrade> availableUpgrades = null, ResourceIdentifier clusterId = null, ResourceIdentifier connectedClusterId = null, string controlPlaneKubernetesVersion = null, ControlPlaneNodeConfiguration controlPlaneNodeConfiguration = null, KubernetesClusterDetailedStatus? detailedStatus = default(KubernetesClusterDetailedStatus?), string detailedStatusMessage = null, IEnumerable<FeatureStatus> featureStatuses = null, IEnumerable<InitialAgentPoolConfiguration> initialAgentPoolConfigurations = null, string kubernetesVersion = null, ManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, KubernetesClusterNetworkConfiguration networkConfiguration = null, IEnumerable<KubernetesClusterNode> nodes = null, KubernetesClusterProvisioningState? provisioningState = default(KubernetesClusterProvisioningState?))
            => new NetworkCloudKubernetesClusterData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                aadAdminGroupObjectIds != null ? new NetworkCloudAadConfiguration(aadAdminGroupObjectIds?.ToList(), serializedAdditionalRawData: null) : null,
                administratorConfiguration,
                attachedNetworkIds?.ToList(),
                availableUpgrades?.ToList(),
                clusterId,
                connectedClusterId,
                controlPlaneKubernetesVersion,
                controlPlaneNodeConfiguration,
                detailedStatus,
                detailedStatusMessage,
                featureStatuses?.ToList(),
                initialAgentPoolConfigurations?.ToList(),
                kubernetesVersion,
                managedResourceGroupConfiguration,
                networkConfiguration,
                nodes?.ToList(),
                provisioningState,
                etag,
                extendedLocation,
                serializedAdditionalRawData: null
                );

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudKubernetesClusterFeatureData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Resource ETag. </param>
        /// <param name="availabilityLifecycle"> The lifecycle indicator of the feature. </param>
        /// <param name="detailedStatus"> The detailed status of the feature. </param>
        /// <param name="detailedStatusMessage"> The descriptive message for the detailed status of the feature. </param>
        /// <param name="options"> The configured options for the feature. </param>
        /// <param name="provisioningState"> The provisioning state of the Kubernetes cluster feature. </param>
        /// <param name="required"> The indicator of if the feature is required or optional. Optional features may be deleted by the user, while required features are managed with the kubernetes cluster lifecycle. </param>
        /// <param name="version"> The version of the feature. </param>
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudKubernetesClusterFeatureData"/> instance for mocking. </returns>
        public static NetworkCloudKubernetesClusterFeatureData NetworkCloudKubernetesClusterFeatureData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ETag? etag = default(ETag?), KubernetesClusterFeatureAvailabilityLifecycle? availabilityLifecycle = default(KubernetesClusterFeatureAvailabilityLifecycle?), KubernetesClusterFeatureDetailedStatus? detailedStatus = default(KubernetesClusterFeatureDetailedStatus?), string detailedStatusMessage = null, IEnumerable<StringKeyValuePair> options = null, KubernetesClusterFeatureProvisioningState? provisioningState = default(KubernetesClusterFeatureProvisioningState?), KubernetesClusterFeatureRequired? required = default(KubernetesClusterFeatureRequired?), string version = null)
            => new NetworkCloudKubernetesClusterFeatureData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                availabilityLifecycle,
                detailedStatus,
                detailedStatusMessage,
                options?.ToList(),
                provisioningState,
                required,
                version,
                etag,
                serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudL2NetworkData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Resource ETag. </param>
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
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudL2NetworkData"/> instance for mocking. </returns>
        public static NetworkCloudL2NetworkData NetworkCloudL2NetworkData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ETag? etag = default(ETag?), ExtendedLocation extendedLocation = null, IEnumerable<ResourceIdentifier> associatedResourceIds = null, ResourceIdentifier clusterId = null, L2NetworkDetailedStatus? detailedStatus = default(L2NetworkDetailedStatus?), string detailedStatusMessage = null, IEnumerable<ResourceIdentifier> hybridAksClustersAssociatedIds = null, HybridAksPluginType? hybridAksPluginType = default(HybridAksPluginType?), string interfaceName = null, ResourceIdentifier l2IsolationDomainId = null, L2NetworkProvisioningState? provisioningState = default(L2NetworkProvisioningState?), IEnumerable<ResourceIdentifier> virtualMachinesAssociatedIds = null)
            => new NetworkCloudL2NetworkData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                associatedResourceIds?.ToList(),
                clusterId,
                detailedStatus,
                detailedStatusMessage,
                hybridAksClustersAssociatedIds?.ToList(),
                hybridAksPluginType,
                interfaceName,
                l2IsolationDomainId,
                provisioningState,
                virtualMachinesAssociatedIds?.ToList(),
                etag,
                extendedLocation,
                serializedAdditionalRawData: null
                );

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudL3NetworkData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Resource ETag. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="associatedResourceIds"> The list of resource IDs for the other Microsoft.NetworkCloud resources that have attached this network. </param>
        /// <param name="clusterId"> The resource ID of the Network Cloud cluster this L3 network is associated with. </param>
        /// <param name="detailedStatus"> The more detailed status of the L3 network. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="hybridAksClustersAssociatedIds"> Field Deprecated. These fields will be empty/omitted. The list of Hybrid AKS cluster resource IDs that are associated with this L3 network. </param>
        /// <param name="hybridAksIpamEnabled"> Field Deprecated. The field was previously optional, now it will have no defined behavior and will be ignored. The indicator of whether or not to disable IPAM allocation on the network attachment definition injected into the Hybrid AKS Cluster. </param>
        /// <param name="hybridAksPluginType"> Field Deprecated. The field was previously optional, now it will have no defined behavior and will be ignored. The network plugin type for Hybrid AKS. </param>
        /// <param name="interfaceName"> The default interface name for this L3 network in the virtual machine. This name can be overridden by the name supplied in the network attachment configuration of that virtual machine. </param>
        /// <param name="ipAllocationType"> The type of the IP address allocation, defaulted to "DualStack". </param>
        /// <param name="ipv4ConnectedPrefix">
        /// The IPV4 prefix (CIDR) assigned to this L3 network. Required when the IP allocation type
        /// is IPV4 or DualStack.
        /// </param>
        /// <param name="ipv6ConnectedPrefix">
        /// The IPV6 prefix (CIDR) assigned to this L3 network. Required when the IP allocation type
        /// is IPV6 or DualStack.
        /// </param>
        /// <param name="l3IsolationDomainId"> The resource ID of the Network Fabric l3IsolationDomain. </param>
        /// <param name="provisioningState"> The provisioning state of the L3 network. </param>
        /// <param name="virtualMachinesAssociatedIds"> Field Deprecated. These fields will be empty/omitted. The list of virtual machine resource IDs, excluding any Hybrid AKS virtual machines, that are currently using this L3 network. </param>
        /// <param name="vlan"> The VLAN from the l3IsolationDomain that is used for this network. </param>
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudL3NetworkData"/> instance for mocking. </returns>
        public static NetworkCloudL3NetworkData NetworkCloudL3NetworkData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ETag? etag = default(ETag?), ExtendedLocation extendedLocation = null, IEnumerable<ResourceIdentifier> associatedResourceIds = null, ResourceIdentifier clusterId = null, L3NetworkDetailedStatus? detailedStatus = default(L3NetworkDetailedStatus?), string detailedStatusMessage = null, IEnumerable<ResourceIdentifier> hybridAksClustersAssociatedIds = null, HybridAksIpamEnabled? hybridAksIpamEnabled = default(HybridAksIpamEnabled?), HybridAksPluginType? hybridAksPluginType = default(HybridAksPluginType?), string interfaceName = null, IPAllocationType? ipAllocationType = default(IPAllocationType?), string ipv4ConnectedPrefix = null, string ipv6ConnectedPrefix = null, ResourceIdentifier l3IsolationDomainId = null, L3NetworkProvisioningState? provisioningState = default(L3NetworkProvisioningState?), IEnumerable<ResourceIdentifier> virtualMachinesAssociatedIds = null, long vlan = (long)0)
        => new NetworkCloudL3NetworkData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                associatedResourceIds?.ToList(),
                clusterId,
                detailedStatus,
                detailedStatusMessage,
                hybridAksClustersAssociatedIds?.ToList(),
                hybridAksIpamEnabled,
                hybridAksPluginType,
                interfaceName,
                ipAllocationType,
                ipv4ConnectedPrefix,
                ipv6ConnectedPrefix,
                l3IsolationDomainId,
                provisioningState,
                virtualMachinesAssociatedIds?.ToList(),
                vlan,
                etag,
                extendedLocation,
                serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of <see cref="Models.NetworkCloudOperationStatusResult"/>. </summary>
        /// <param name="endOn"> The end time of the operation. </param>
        /// <param name="error"> If present, details of the operation error. </param>
        /// <param name="id"> Fully qualified ID for the async operation. </param>
        /// <param name="name"> Name of the async operation. </param>
        /// <param name="operations"> The operations list. </param>
        /// <param name="percentComplete"> Percent of the operation that is complete. </param>
        /// <param name="resourceId"> Fully qualified ID of the resource against which the original async operation was started. </param>
        /// <param name="startOn"> The start time of the operation. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="exitCode"> For actions that run commands or scripts, the exit code of the script execution. </param>
        /// <param name="outputHead"> For actions that run commands or scripts, the leading bytes of the output of the script execution. </param>
        /// <param name="resultRef"> For actions that run commands or scripts, a reference to the location of the result. </param>
        /// <param name="resultUri"> For actions that run commands or scripts, the URL where the full output of the script output can be retrieved. </param>
        /// <returns> A new <see cref="Models.NetworkCloudOperationStatusResult"/> instance for mocking. </returns>
        public static NetworkCloudOperationStatusResult NetworkCloudOperationStatusResult(DateTimeOffset? endOn = default(DateTimeOffset?), ResponseError error = null, ResourceIdentifier id = null, string name = null, IEnumerable<NetworkCloudOperationStatusResult> operations = null, float? percentComplete = default(float?), ResourceIdentifier resourceId = null, DateTimeOffset? startOn = default(DateTimeOffset?), string status = null, string exitCode = null, string outputHead = null, Uri resultRef = null, Uri resultUri = null)
            => new NetworkCloudOperationStatusResult(
                endOn,
                error,
                id,
                name,
                operations?.ToList(),
                percentComplete,
                exitCode,
                outputHead,
                resultRef,
                resultUri,
                resourceId,
                startOn,
                status,
                serializedAdditionalRawData: null
                );

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudRackData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Resource ETag. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="availabilityZone"> The value that will be used for machines in this rack to represent the availability zones that can be referenced by Hybrid AKS Clusters for node arrangement. </param>
        /// <param name="clusterId"> The resource ID of the cluster the rack is created for. This value is set when the rack is created by the cluster. </param>
        /// <param name="detailedStatus"> The more detailed status of the rack. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="provisioningState"> The provisioning state of the rack resource. </param>
        /// <param name="rackLocation"> The free-form description of the rack location. (e.g. “DTN Datacenter, Floor 3, Isle 9, Rack 2B”). </param>
        /// <param name="rackSerialNumber"> The unique identifier for the rack within Network Cloud cluster. An alternate unique alphanumeric value other than a serial number may be provided if desired. </param>
        /// <param name="rackSkuId"> The SKU for the rack. </param>
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudRackData"/> instance for mocking. </returns>
        public static NetworkCloudRackData NetworkCloudRackData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ETag? etag = default(ETag?), ExtendedLocation extendedLocation = null, string availabilityZone = null, ResourceIdentifier clusterId = null, RackDetailedStatus? detailedStatus = default(RackDetailedStatus?), string detailedStatusMessage = null, RackProvisioningState? provisioningState = default(RackProvisioningState?), string rackLocation = null, string rackSerialNumber = null, ResourceIdentifier rackSkuId = null)
            => new NetworkCloudRackData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                availabilityZone,
                clusterId,
                detailedStatus,
                detailedStatusMessage,
                provisioningState,
                rackLocation,
                rackSerialNumber,
                rackSkuId,
                etag,
                extendedLocation,
                serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudStorageApplianceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Resource ETag. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="administratorCredentials"> The credentials of the administrative interface on this storage appliance. </param>
        /// <param name="capacity"> The total capacity of the storage appliance. Measured in GiB. </param>
        /// <param name="capacityUsed"> The amount of storage consumed. </param>
        /// <param name="clusterId"> The resource ID of the cluster this storage appliance is associated with. Measured in GiB. </param>
        /// <param name="detailedStatus"> The detailed status of the storage appliance. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="managementIPv4Address"> The endpoint for the management interface of the storage appliance. </param>
        /// <param name="manufacturer"> The manufacturer of the storage appliance. </param>
        /// <param name="model"> The model of the storage appliance. </param>
        /// <param name="provisioningState"> The provisioning state of the storage appliance. </param>
        /// <param name="rackId"> The resource ID of the rack where this storage appliance resides. </param>
        /// <param name="rackSlot"> The slot the storage appliance is in the rack based on the BOM configuration. </param>
        /// <param name="remoteVendorManagementFeature"> The indicator of whether the storage appliance supports remote vendor management. </param>
        /// <param name="remoteVendorManagementStatus"> The indicator of whether the remote vendor management feature is enabled or disabled, or unsupported if it is an unsupported feature. </param>
        /// <param name="secretRotationStatus"> The list of statuses that represent secret rotation activity. </param>
        /// <param name="serialNumber"> The serial number for the storage appliance. </param>
        /// <param name="storageApplianceSkuId"> The SKU for the storage appliance. </param>
        /// <param name="version"> The version of the storage appliance. </param>
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudStorageApplianceData"/> instance for mocking. </returns>
        public static NetworkCloudStorageApplianceData NetworkCloudStorageApplianceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ETag? etag = default(ETag?), ExtendedLocation extendedLocation = null, AdministrativeCredentials administratorCredentials = null, long? capacity = default(long?), long? capacityUsed = default(long?), ResourceIdentifier clusterId = null, StorageApplianceDetailedStatus? detailedStatus = default(StorageApplianceDetailedStatus?), string detailedStatusMessage = null, IPAddress managementIPv4Address = null, string manufacturer = null, string model = null, StorageApplianceProvisioningState? provisioningState = default(StorageApplianceProvisioningState?), ResourceIdentifier rackId = null, long rackSlot = (long)0, RemoteVendorManagementFeature? remoteVendorManagementFeature = default(RemoteVendorManagementFeature?), RemoteVendorManagementStatus? remoteVendorManagementStatus = default(RemoteVendorManagementStatus?), IEnumerable<SecretRotationStatus> secretRotationStatus = null, string serialNumber = null, string storageApplianceSkuId = null, string version = null)
                => new NetworkCloudStorageApplianceData(
                    id,
                    name,
                    resourceType,
                    systemData,
                    tags,
                    location,
                    administratorCredentials,
                    capacity,
                    capacityUsed,
                    clusterId,
                    detailedStatus,
                    detailedStatusMessage,
                    managementIPv4Address,
                    manufacturer,
                    model,
                    provisioningState,
                    rackId,
                    rackSlot,
                    remoteVendorManagementFeature,
                    remoteVendorManagementStatus,
                    secretRotationStatus?.ToList(),
                    serialNumber,
                    storageApplianceSkuId,
                    version,
                    etag,
                    extendedLocation,
                    serializedAdditionalRawData: null
                    );

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudTrunkedNetworkData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Resource ETag. </param>
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
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudTrunkedNetworkData"/> instance for mocking. </returns>
        public static NetworkCloudTrunkedNetworkData NetworkCloudTrunkedNetworkData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ETag? etag = default(ETag?), ExtendedLocation extendedLocation = null, IEnumerable<string> associatedResourceIds = null, ResourceIdentifier clusterId = null, TrunkedNetworkDetailedStatus? detailedStatus = default(TrunkedNetworkDetailedStatus?), string detailedStatusMessage = null, IEnumerable<ResourceIdentifier> hybridAksClustersAssociatedIds = null, HybridAksPluginType? hybridAksPluginType = default(HybridAksPluginType?), string interfaceName = null, IEnumerable<ResourceIdentifier> isolationDomainIds = null, TrunkedNetworkProvisioningState? provisioningState = default(TrunkedNetworkProvisioningState?), IEnumerable<ResourceIdentifier> virtualMachinesAssociatedIds = null, IEnumerable<long> vlans = null)
            => new NetworkCloudTrunkedNetworkData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                associatedResourceIds?.ToList(),
                clusterId,
                detailedStatus,
                detailedStatusMessage,
                hybridAksClustersAssociatedIds?.ToList(),
                hybridAksPluginType,
                interfaceName,
                isolationDomainIds?.ToList(),
                provisioningState,
                virtualMachinesAssociatedIds?.ToList(),
                vlans?.ToList(),
                etag,
                extendedLocation,
                serializedAdditionalRawData: null
                );

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudVirtualMachineConsoleData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Resource ETag. </param>
        /// <param name="extendedLocation"> The extended location of the cluster manager associated with the cluster this virtual machine is created on. </param>
        /// <param name="detailedStatus"> The more detailed status of the console. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="enabled"> The indicator of whether the console access is enabled. </param>
        /// <param name="expireOn"> The date and time after which the key will be disallowed access. </param>
        /// <param name="privateLinkServiceId"> The resource ID of the private link service that is used to provide virtual machine console access. </param>
        /// <param name="provisioningState"> The provisioning state of the virtual machine console. </param>
        /// <param name="keyData"> The SSH public key that will be provisioned for user access. The user is expected to have the corresponding SSH private key for logging in. </param>
        /// <param name="virtualMachineAccessId"> The unique identifier for the virtual machine that is used to access the console. </param>
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudVirtualMachineConsoleData"/> instance for mocking. </returns>
        public static NetworkCloudVirtualMachineConsoleData NetworkCloudVirtualMachineConsoleData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ETag? etag = default(ETag?), ExtendedLocation extendedLocation = null, ConsoleDetailedStatus? detailedStatus = default(ConsoleDetailedStatus?), string detailedStatusMessage = null, ConsoleEnabled enabled = default(ConsoleEnabled), DateTimeOffset? expireOn = default(DateTimeOffset?), ResourceIdentifier privateLinkServiceId = null, ConsoleProvisioningState? provisioningState = default(ConsoleProvisioningState?), string keyData = null, Guid? virtualMachineAccessId = default(Guid?))
            => new NetworkCloudVirtualMachineConsoleData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                detailedStatus,
                detailedStatusMessage,
                enabled,
                expireOn,
                privateLinkServiceId,
                provisioningState,
                keyData != null ? new NetworkCloudSshPublicKey(keyData, serializedAdditionalRawData: null) : null,
                virtualMachineAccessId,
                etag,
                extendedLocation,
                serializedAdditionalRawData: null
                );

        /// <summary> Initializes a new instance of <see cref="NetworkCloud.NetworkCloudVirtualMachineData"/>. </summary>
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
        /// <returns> A new <see cref="NetworkCloud.NetworkCloudVirtualMachineData"/> instance for mocking. </returns>
        public static NetworkCloudVirtualMachineData NetworkCloudVirtualMachineData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ETag? etag = default(ETag?), ExtendedLocation extendedLocation = null, string adminUsername = null, string availabilityZone = null, ResourceIdentifier bareMetalMachineId = null, VirtualMachineBootMethod? bootMethod = default(VirtualMachineBootMethod?), NetworkAttachment cloudServicesNetworkAttachment = null, ResourceIdentifier clusterId = null, ExtendedLocation consoleExtendedLocation = null, long cpuCores = (long)0, VirtualMachineDetailedStatus? detailedStatus = default(VirtualMachineDetailedStatus?), string detailedStatusMessage = null, VirtualMachineIsolateEmulatorThread? isolateEmulatorThread = default(VirtualMachineIsolateEmulatorThread?), long memorySizeInGB = (long)0, IEnumerable<NetworkAttachment> networkAttachments = null, string networkData = null, IEnumerable<VirtualMachinePlacementHint> placementHints = null, VirtualMachinePowerState? powerState = default(VirtualMachinePowerState?), VirtualMachineProvisioningState? provisioningState = default(VirtualMachineProvisioningState?), IEnumerable<NetworkCloudSshPublicKey> sshPublicKeys = null, NetworkCloudStorageProfile storageProfile = null, string userData = null, VirtualMachineVirtioInterfaceType? virtioInterface = default(VirtualMachineVirtioInterfaceType?), VirtualMachineDeviceModelType? vmDeviceModel = default(VirtualMachineDeviceModelType?), string vmImage = null, ImageRepositoryCredentials vmImageRepositoryCredentials = null, IEnumerable<ResourceIdentifier> volumes = null)
            => new NetworkCloudVirtualMachineData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                adminUsername,
                availabilityZone,
                bareMetalMachineId,
                bootMethod,
                cloudServicesNetworkAttachment,
                clusterId,
                consoleExtendedLocation,
                cpuCores,
                detailedStatus,
                detailedStatusMessage,
                isolateEmulatorThread,
                memorySizeInGB,
                networkAttachments?.ToList(),
                networkData,
                placementHints?.ToList(),
                powerState,
                provisioningState,
                sshPublicKeys?.ToList(),
                storageProfile,
                userData,
                virtioInterface,
                vmDeviceModel,
                vmImage,
                vmImageRepositoryCredentials,
                volumes?.ToList(),
                etag,
                extendedLocation,
                serializedAdditionalRawData: null
                );

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
        public static NetworkCloudVolumeData NetworkCloudVolumeData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ETag? etag = default(ETag?), ExtendedLocation extendedLocation = null, IEnumerable<string> attachedTo = null, VolumeDetailedStatus? detailedStatus = default(VolumeDetailedStatus?), string detailedStatusMessage = null, VolumeProvisioningState? provisioningState = default(VolumeProvisioningState?), string serialNumber = null, long sizeInMiB = (long)0)
            => new NetworkCloudVolumeData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                attachedTo?.ToList(),
                detailedStatus,
                detailedStatusMessage,
                provisioningState,
                serialNumber,
                sizeInMiB,
                etag,
                extendedLocation,
                serializedAdditionalRawData: null
                );

        /// <summary> Initializes a new instance of <see cref="Models.StorageApplianceSkuSlot"/>. </summary>
        /// <param name="rackSlot"> The position in the rack for the storage appliance. </param>
        /// <param name="capacityGB"> The maximum capacity of the storage appliance. Measured in gibibytes. </param>
        /// <param name="model"> The model of the storage appliance. </param>
        /// <returns> A new <see cref="Models.StorageApplianceSkuSlot"/> instance for mocking. </returns>
        public static StorageApplianceSkuSlot StorageApplianceSkuSlot(long? rackSlot = default(long?), long? capacityGB = default(long?), string model = null)
            => new StorageApplianceSkuSlot(
                capacityGB,
                model,
                rackSlot,
                serializedAdditionalRawData: null);
    }
}
