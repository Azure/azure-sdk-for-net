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
    [CodeGenSuppress("NetworkCloudClusterData", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(System.Collections.Generic.IDictionary<string, string>), typeof(Azure.Core.AzureLocation), typeof(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition), typeof(Azure.ResourceManager.NetworkCloud.Models.AnalyticsOutputSettings), typeof(Azure.Core.ResourceIdentifier), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion>), typeof(Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity), typeof(Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus?), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus?), typeof(Azure.Core.ResourceIdentifier), typeof(Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation), typeof(Azure.ResourceManager.NetworkCloud.Models.ClusterType), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.CommandOutputSettings), typeof(Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition>), typeof(Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus?), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation), typeof(Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration), typeof(long?), typeof(Azure.Core.ResourceIdentifier), typeof(Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState?), typeof(Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel?), typeof(Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchive), typeof(Azure.ResourceManager.NetworkCloud.Models.SecretArchiveSettings), typeof(System.DateTimeOffset?), typeof(Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategy), typeof(Azure.ResourceManager.NetworkCloud.Models.VulnerabilityScanningSettingsContainerScan?), typeof(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier>), typeof(Azure.ETag?), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation), typeof(Azure.ResourceManager.Models.ManagedServiceIdentity))]
    [CodeGenSuppress("NetworkCloudBareMetalMachineData", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(System.Collections.Generic.IDictionary<string, string>), typeof(Azure.Core.AzureLocation), typeof(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier>), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials), typeof(string), typeof(string), typeof(Azure.Core.ResourceIdentifier), typeof(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus?), typeof(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus?), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.HardwareInventory), typeof(Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus), typeof(System.Collections.Generic.IEnumerable<string>), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(System.Collections.Generic.IEnumerable<string>), typeof(string), typeof(System.Net.IPAddress), typeof(string), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState?), typeof(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState?), typeof(Azure.Core.ResourceIdentifier), typeof(long), typeof(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState?), typeof(Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionStatus), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus>), typeof(string), typeof(string), typeof(System.Collections.Generic.IEnumerable<string>), typeof(Azure.ETag?), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudAgentPoolData", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(System.Collections.Generic.IDictionary<string, string>), typeof(Azure.Core.AzureLocation), typeof(Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration), typeof(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentConfiguration), typeof(Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration), typeof(System.Collections.Generic.IEnumerable<string>), typeof(long), typeof(Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus?), typeof(string), typeof(string), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel>), typeof(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode), typeof(Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState?), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel>), typeof(Azure.ResourceManager.NetworkCloud.Models.AgentPoolUpgradeSettings), typeof(string), typeof(Azure.ETag?), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudBareMetalMachineKeySetData", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(System.Collections.Generic.IDictionary<string, string>), typeof(Azure.Core.AzureLocation), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus?), typeof(string), typeof(System.DateTimeOffset), typeof(System.Collections.Generic.IEnumerable<System.Net.IPAddress>), typeof(System.DateTimeOffset?), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel), typeof(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState?), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser>), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus>), typeof(Azure.ETag?), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudBmcKeySetData", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(System.Collections.Generic.IDictionary<string, string>), typeof(Azure.Core.AzureLocation), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus?), typeof(string), typeof(System.DateTimeOffset), typeof(System.DateTimeOffset?), typeof(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel), typeof(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState?), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser>), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus>), typeof(Azure.ETag?), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudCloudServicesNetworkData", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(System.Collections.Generic.IDictionary<string, string>), typeof(Azure.Core.AzureLocation), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint>), typeof(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier>), typeof(Azure.Core.ResourceIdentifier), typeof(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus?), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint?), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint>), typeof(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier>), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState?), typeof(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier>), typeof(Azure.ETag?), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudClusterManagerData", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(System.Collections.Generic.IDictionary<string, string>), typeof(Azure.Core.AzureLocation), typeof(Azure.Core.ResourceIdentifier), typeof(System.Collections.Generic.IEnumerable<string>), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion>), typeof(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus?), typeof(string), typeof(Azure.Core.ResourceIdentifier), typeof(Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation), typeof(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState?), typeof(string), typeof(Azure.ETag?), typeof(Azure.ResourceManager.Models.ManagedServiceIdentity))]
    [CodeGenSuppress("NetworkCloudClusterMetricsConfigurationData", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(System.Collections.Generic.IDictionary<string, string>), typeof(Azure.Core.AzureLocation), typeof(long), typeof(Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus?), typeof(string), typeof(System.Collections.Generic.IEnumerable<string>), typeof(System.Collections.Generic.IEnumerable<string>), typeof(Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState?), typeof(Azure.ETag?), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudKubernetesClusterData", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(System.Collections.Generic.IDictionary<string, string>), typeof(Azure.Core.AzureLocation), typeof(System.Collections.Generic.IEnumerable<string>), typeof(Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration), typeof(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier>), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.AvailableUpgrade>), typeof(Azure.Core.ResourceIdentifier), typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodeConfiguration), typeof(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus?), typeof(string), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.FeatureStatus>), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.InitialAgentPoolConfiguration>), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration), typeof(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNetworkConfiguration), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode>), typeof(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState?), typeof(Azure.ETag?), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudKubernetesClusterFeatureData", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(System.Collections.Generic.IDictionary<string, string>), typeof(Azure.Core.AzureLocation), typeof(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureAvailabilityLifecycle?), typeof(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureDetailedStatus?), typeof(string), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.StringKeyValuePair>), typeof(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState?), typeof(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureRequired?), typeof(string), typeof(Azure.ETag?))]
    [CodeGenSuppress("NetworkCloudL2NetworkData", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(System.Collections.Generic.IDictionary<string, string>), typeof(Azure.Core.AzureLocation), typeof(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier>), typeof(Azure.Core.ResourceIdentifier), typeof(Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus?), typeof(string), typeof(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier>), typeof(Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType?), typeof(string), typeof(Azure.Core.ResourceIdentifier), typeof(Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState?), typeof(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier>), typeof(Azure.ETag?), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudL3NetworkData", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(System.Collections.Generic.IDictionary<string, string>), typeof(Azure.Core.AzureLocation), typeof(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier>), typeof(Azure.Core.ResourceIdentifier), typeof(Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus?), typeof(string), typeof(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier>), typeof(Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled?), typeof(Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType?), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.IPAllocationType?), typeof(string), typeof(string), typeof(Azure.Core.ResourceIdentifier), typeof(Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState?), typeof(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier>), typeof(long), typeof(Azure.ETag?), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudOperationStatusResult", typeof(System.DateTimeOffset?), typeof(Azure.ResponseError), typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>), typeof(float?), typeof(string), typeof(string), typeof(System.Uri), typeof(System.Uri), typeof(Azure.Core.ResourceIdentifier), typeof(System.DateTimeOffset?), typeof(string))]
    [CodeGenSuppress("NetworkCloudRackData", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(System.Collections.Generic.IDictionary<string, string>), typeof(Azure.Core.AzureLocation), typeof(string), typeof(Azure.Core.ResourceIdentifier), typeof(Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus?), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState?), typeof(string), typeof(string), typeof(Azure.Core.ResourceIdentifier), typeof(Azure.ETag?), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudStorageApplianceData", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(System.Collections.Generic.IDictionary<string, string>), typeof(Azure.Core.AzureLocation), typeof(Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials), typeof(long?), typeof(long?), typeof(Azure.Core.ResourceIdentifier), typeof(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus?), typeof(string), typeof(System.Net.IPAddress), typeof(string), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState?), typeof(Azure.Core.ResourceIdentifier), typeof(long), typeof(Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature?), typeof(Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus?), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus>), typeof(string), typeof(string), typeof(string), typeof(Azure.ETag?), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudTrunkedNetworkData", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(System.Collections.Generic.IDictionary<string, string>), typeof(Azure.Core.AzureLocation), typeof(System.Collections.Generic.IEnumerable<string>), typeof(Azure.Core.ResourceIdentifier), typeof(Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus?), typeof(string), typeof(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier>), typeof(Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType?), typeof(string), typeof(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier>), typeof(Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState?), typeof(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier>), typeof(System.Collections.Generic.IEnumerable<long>), typeof(Azure.ETag?), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudVirtualMachineConsoleData", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(System.Collections.Generic.IDictionary<string, string>), typeof(Azure.Core.AzureLocation), typeof(Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus?), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled), typeof(System.DateTimeOffset?), typeof(Azure.Core.ResourceIdentifier), typeof(Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState?), typeof(string), typeof(System.Guid?), typeof(Azure.ETag?), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudVirtualMachineData", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(System.Collections.Generic.IDictionary<string, string>), typeof(Azure.Core.AzureLocation), typeof(string), typeof(string), typeof(Azure.Core.ResourceIdentifier), typeof(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod?), typeof(Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment), typeof(Azure.Core.ResourceIdentifier), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation), typeof(long), typeof(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus?), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread?), typeof(long), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment>), typeof(string), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint>), typeof(Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState?), typeof(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState?), typeof(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey>), typeof(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType?), typeof(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType?), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials), typeof(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier>), typeof(Azure.ETag?), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation))]
    [CodeGenSuppress("NetworkCloudVolumeData", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(Azure.Core.ResourceType), typeof(Azure.ResourceManager.Models.SystemData), typeof(System.Collections.Generic.IDictionary<string, string>), typeof(Azure.Core.AzureLocation), typeof(System.Collections.Generic.IEnumerable<string>), typeof(Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus?), typeof(string), typeof(Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState?), typeof(string), typeof(long), typeof(Azure.ETag?), typeof(Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation))]
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
        public static NetworkCloudAgentPoolData NetworkCloudAgentPoolData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, AdministratorConfiguration administratorConfiguration, NetworkCloudAgentConfiguration agentOptions, AttachedNetworkConfiguration attachedNetworkConfiguration, IEnumerable<string> availabilityZones, long count, AgentPoolDetailedStatus? detailedStatus, string detailedStatusMessage, string kubernetesVersion, IEnumerable<KubernetesLabel> labels, NetworkCloudAgentPoolMode mode, AgentPoolProvisioningState? provisioningState, IEnumerable<KubernetesLabel> taints, string upgradeMaxSurge, string vmSkuName)
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
        public static NetworkCloudAgentPoolData NetworkCloudAgentPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration administratorConfiguration = null, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentConfiguration agentOptions = null, Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration attachedNetworkConfiguration = null, System.Collections.Generic.IEnumerable<string> availabilityZones = null, long count = (long)0, Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus?), string detailedStatusMessage = null, string kubernetesVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> labels = null, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode mode = default(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode), Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> taints = null, Azure.ResourceManager.NetworkCloud.Models.AgentPoolUpgradeSettings upgradeSettings = null, string vmSkuName = null)
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
        public static NetworkCloudClusterData NetworkCloudClusterData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition aggregatorOrSingleRackDefinition, Azure.Core.ResourceIdentifier analyticsWorkspaceId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion> availableUpgradeVersions, Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity clusterCapacity, Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus? clusterConnectionStatus, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation clusterExtendedLocation, string clusterLocation, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus? clusterManagerConnectionStatus, Azure.Core.ResourceIdentifier clusterManagerId, Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation clusterServicePrincipal, Azure.ResourceManager.NetworkCloud.Models.ClusterType clusterType, string clusterVersion, Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold computeDeploymentThreshold, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition> computeRackDefinitions, Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus? detailedStatus, string detailedStatusMessage, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation hybridAksExtendedLocation, Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration, long? manualActionCount, Azure.Core.ResourceIdentifier networkFabricId, Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState? provisioningState, System.DateTimeOffset? supportExpireOn, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> workloadResourceIds)

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
        public static MachineSkuSlot MachineSkuSlot(long? rackSlot = default(long?), Azure.ResourceManager.NetworkCloud.Models.BootstrapProtocol? bootstrapProtocol = default(Azure.ResourceManager.NetworkCloud.Models.BootstrapProtocol?), long? cpuCores = default(long?), long? cpuSockets = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.MachineDisk> disks = null, string generation = null, string hardwareVersion = null, long? memoryCapacityGB = default(long?), string model = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNetworkInterface> networkInterfaces = null, long? totalThreads = default(long?), string vendor = null)
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
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData NetworkCloudBareMetalMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds = null, string bmcConnectionString = null, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials bmcCredentials = null, string bmcMacAddress = null, string bootMacAddress = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus? cordonStatus = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus?), Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.HardwareInventory hardwareInventory = null, Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus hardwareValidationStatus = null, System.Collections.Generic.IEnumerable<string> hybridAksClustersAssociatedIds = null, string kubernetesNodeName = null, string kubernetesVersion = null, string machineClusterVersion = null, string machineDetails = null, string machineName = null, System.Collections.Generic.IEnumerable<string> machineRoles = null, string machineSkuId = null, System.Net.IPAddress oamIPv4Address = null, string oamIPv6Address = null, string osImage = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState? powerState = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState?), Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState?), Azure.Core.ResourceIdentifier rackId = null, long rackSlot = (long)0, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState? readyState = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState?), Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionStatus runtimeProtectionStatus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus> secretRotationStatus = null, string serialNumber = null, string serviceTag = null, System.Collections.Generic.IEnumerable<string> virtualMachinesAssociatedIds = null)
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
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData NetworkCloudBareMetalMachineKeySetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string azureGroupId = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus?), string detailedStatusMessage = null, System.DateTimeOffset expireOn = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<System.Net.IPAddress> jumpHostsAllowed = null, System.DateTimeOffset? lastValidatedOn = default(System.DateTimeOffset?), string osGroupName = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel privilegeLevel = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel), Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> userList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus> userListStatus = null)
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
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData NetworkCloudBmcKeySetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string azureGroupId = null, Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus?), string detailedStatusMessage = null, System.DateTimeOffset expireOn = default(System.DateTimeOffset), System.DateTimeOffset? lastValidatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel privilegeLevel = default(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel), Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> userList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus> userListStatus = null)
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
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData NetworkCloudCloudServicesNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> additionalEgressEndpoints = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint? enableDefaultEgressEndpoints = default(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> enabledEgressEndpoints = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> hybridAksClustersAssociatedIds = null, string interfaceName = null, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualMachinesAssociatedIds = null)
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
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData NetworkCloudClusterManagerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.Core.ResourceIdentifier analyticsWorkspaceId = null, System.Collections.Generic.IEnumerable<string> availabilityZones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion> clusterVersions = null, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus?), string detailedStatusMessage = null, Azure.Core.ResourceIdentifier fabricControllerId = null, Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation managerExtendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState?), string vmSize = null)
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
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData NetworkCloudClusterMetricsConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, long collectionInterval = (long)0, Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<string> disabledMetrics = null, System.Collections.Generic.IEnumerable<string> enabledMetrics = null, Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState?))
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
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData NetworkCloudKubernetesClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<string> aadAdminGroupObjectIds = null, Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration administratorConfiguration = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> attachedNetworkIds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.AvailableUpgrade> availableUpgrades = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.Core.ResourceIdentifier connectedClusterId = null, string controlPlaneKubernetesVersion = null, Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodeConfiguration controlPlaneNodeConfiguration = null, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.FeatureStatus> featureStatuses = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.InitialAgentPoolConfiguration> initialAgentPoolConfigurations = null, string kubernetesVersion = null, Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNetworkConfiguration networkConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode> nodes = null, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState?))
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
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData NetworkCloudKubernetesClusterFeatureData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureAvailabilityLifecycle? availabilityLifecycle = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureAvailabilityLifecycle?), Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.StringKeyValuePair> options = null, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState?), Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureRequired? required = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureRequired?), string version = null)
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
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData NetworkCloudL2NetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> hybridAksClustersAssociatedIds = null, Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? hybridAksPluginType = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType?), string interfaceName = null, Azure.Core.ResourceIdentifier l2IsolationDomainId = null, Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualMachinesAssociatedIds = null)
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
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData NetworkCloudL3NetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> hybridAksClustersAssociatedIds = null, Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled? hybridAksIpamEnabled = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled?), Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? hybridAksPluginType = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType?), string interfaceName = null, Azure.ResourceManager.NetworkCloud.Models.IPAllocationType? ipAllocationType = default(Azure.ResourceManager.NetworkCloud.Models.IPAllocationType?), string ipv4ConnectedPrefix = null, string ipv6ConnectedPrefix = null, Azure.Core.ResourceIdentifier l3IsolationDomainId = null, Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualMachinesAssociatedIds = null, long vlan = (long)0)
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
        public static Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult NetworkCloudOperationStatusResult(System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResponseError error = null, Azure.Core.ResourceIdentifier id = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> operations = null, float? percentComplete = default(float?), Azure.Core.ResourceIdentifier resourceId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), string status = null, string exitCode = null, string outputHead = null, System.Uri resultRef = null, System.Uri resultUri = null)
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
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudRackData NetworkCloudRackData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string availabilityZone = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState?), string rackLocation = null, string rackSerialNumber = null, Azure.Core.ResourceIdentifier rackSkuId = null)
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
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData NetworkCloudStorageApplianceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials administratorCredentials = null, long? capacity = default(long?), long? capacityUsed = default(long?), Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus?), string detailedStatusMessage = null, System.Net.IPAddress managementIPv4Address = null, string manufacturer = null, string model = null, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState?), Azure.Core.ResourceIdentifier rackId = null, long rackSlot = (long)0, Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature? remoteVendorManagementFeature = default(Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature?), Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus? remoteVendorManagementStatus = default(Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus> secretRotationStatus = null, string serialNumber = null, string storageApplianceSkuId = null, string version = null)
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
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData NetworkCloudTrunkedNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<string> associatedResourceIds = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> hybridAksClustersAssociatedIds = null, Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? hybridAksPluginType = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType?), string interfaceName = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> isolationDomainIds = null, Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualMachinesAssociatedIds = null, System.Collections.Generic.IEnumerable<long> vlans = null)
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
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData NetworkCloudVirtualMachineConsoleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled enabled = default(Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier privateLinkServiceId = null, Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState?), string keyData = null, System.Guid? virtualMachineAccessId = default(System.Guid?))
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
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData NetworkCloudVirtualMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string adminUsername = null, string availabilityZone = null, Azure.Core.ResourceIdentifier bareMetalMachineId = null, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod? bootMethod = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod?), Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment cloudServicesNetworkAttachment = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation consoleExtendedLocation = null, long cpuCores = (long)0, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread? isolateEmulatorThread = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread?), long memorySizeInGB = (long)0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment> networkAttachments = null, string networkData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint> placementHints = null, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState? powerState = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState?), Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey> sshPublicKeys = null, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile storageProfile = null, string userData = null, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType? virtioInterface = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType?), Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType? vmDeviceModel = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType?), string vmImage = null, Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials vmImageRepositoryCredentials = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> volumes = null)
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
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData NetworkCloudVolumeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<string> attachedTo = null, Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState?), string serialNumber = null, long sizeInMiB = (long)0)
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
        public static Azure.ResourceManager.NetworkCloud.Models.StorageApplianceSkuSlot StorageApplianceSkuSlot(long? rackSlot = default(long?), long? capacityGB = default(long?), string model = null)
            => new StorageApplianceSkuSlot(
                capacityGB,
                model,
                rackSlot,
                serializedAdditionalRawData: null);
    }
}
