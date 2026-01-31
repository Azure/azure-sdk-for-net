// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;

namespace Azure.ResourceManager.NetworkCloud.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class MockableNetworkCloudSubscriptionResource : ArmResource
    {
		/// <summary>
        /// Get the list of bare metal machine for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/naksClusters/{naksClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BareMetalMachines_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudBareMetalMachineResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachinesAsync(CancellationToken cancellationToken)
            => GetNetworkCloudBareMetalMachinesAsync(null, null, cancellationToken);

		/// <summary>
        /// Get the list of bare metal machine for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/naksClusters/{naksClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BareMetalMachines_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudBareMetalMachineResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachines(CancellationToken cancellationToken)
            => GetNetworkCloudBareMetalMachines(null, null, cancellationToken);

		/// <summary>
        /// Get the list of bare metal machine for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/naksClusters/{naksClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CloudServicesNetworks_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudCloudServicesNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetworkCloudCloudServicesNetworkResource> GetNetworkCloudCloudServicesNetworksAsync(CancellationToken cancellationToken)
            => GetNetworkCloudCloudServicesNetworksAsync(null, null, cancellationToken);

		/// <summary>
        /// Get the list of bare metal machine for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/naksClusters/{naksClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CloudServicesNetworks_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudCloudServicesNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetworkCloudCloudServicesNetworkResource> GetNetworkCloudCloudServicesNetworks(CancellationToken cancellationToken)
            => GetNetworkCloudCloudServicesNetworks(null, null, cancellationToken);

		/// <summary>
        /// Get the list of bare metal machine for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/naksClusters/{naksClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ClusterManagers_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudClusterManagerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetworkCloudClusterManagerResource> GetNetworkCloudClusterManagersAsync(CancellationToken cancellationToken)
            => GetNetworkCloudClusterManagersAsync(null, null, cancellationToken);

		/// <summary>
        /// Get the list of bare metal machine for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/naksClusters/{naksClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ClusterManagers_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudClusterManagerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetworkCloudClusterManagerResource> GetNetworkCloudClusterManagers(CancellationToken cancellationToken)
            => GetNetworkCloudClusterManagers(null, null, cancellationToken);

		/// <summary>
        /// Get the list of bare metal machine for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/naksClusters/{naksClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Clusters_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudClusterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetworkCloudClusterResource> GetNetworkCloudClustersAsync(CancellationToken cancellationToken)
            => GetNetworkCloudClustersAsync(null, null, cancellationToken);

		/// <summary>
        /// Get the list of bare metal machine for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/naksClusters/{naksClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Clusters_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudClusterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetworkCloudClusterResource> GetNetworkCloudClusters(CancellationToken cancellationToken)
            => GetNetworkCloudClusters(null, null, cancellationToken);

		/// <summary>
        /// Get the list of bare metal machine for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/naksClusters/{naksClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>KubernetesClusters_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudKubernetesClusterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetworkCloudKubernetesClusterResource> GetNetworkCloudKubernetesClustersAsync(CancellationToken cancellationToken)
            => GetNetworkCloudKubernetesClustersAsync(null, null, cancellationToken);

		/// <summary>
        /// Get the list of bare metal machine for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/naksClusters/{naksClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>KubernetesClusters_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudKubernetesClusterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetworkCloudKubernetesClusterResource> GetNetworkCloudKubernetesClusters(CancellationToken cancellationToken)
            => GetNetworkCloudKubernetesClusters(null, null, cancellationToken);

		/// <summary>
        /// Get the list of bare metal machine for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/naksClusters/{naksClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>L2Networks_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudL2NetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetworkCloudL2NetworkResource> GetNetworkCloudL2NetworksAsync(CancellationToken cancellationToken)
            => GetNetworkCloudL2NetworksAsync(null, null, cancellationToken);

		/// <summary>
        /// Get the list of bare metal machine for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/naksClusters/{naksClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>L2Networks_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudL2NetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetworkCloudL2NetworkResource> GetNetworkCloudL2Networks(CancellationToken cancellationToken)
            => GetNetworkCloudL2Networks(null, null, cancellationToken);

		/// <summary>
        /// Get the list of bare metal machine for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/naksClusters/{naksClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>L3Networks_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudL3NetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetworkCloudL3NetworkResource> GetNetworkCloudL3NetworksAsync(CancellationToken cancellationToken)
            => GetNetworkCloudL3NetworksAsync(null, null, cancellationToken);

		/// <summary>
        /// Get the list of bare metal machine for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/naksClusters/{naksClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>L3Networks_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudL3NetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetworkCloudL3NetworkResource> GetNetworkCloudL3Networks(CancellationToken cancellationToken)
            => GetNetworkCloudL3Networks(null, null, cancellationToken);

		/// <summary>
        /// Get the list of bare metal machine for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/naksClusters/{naksClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Racks_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudRackResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetworkCloudRackResource> GetNetworkCloudRacksAsync(CancellationToken cancellationToken)
            => GetNetworkCloudRacksAsync(null, null, cancellationToken);

		/// <summary>
        /// Get the list of bare metal machine for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/naksClusters/{naksClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Racks_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudRackResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetworkCloudRackResource> GetNetworkCloudRacks(CancellationToken cancellationToken)
            => GetNetworkCloudRacks(null, null, cancellationToken);

		/// <summary>
        /// Get the list of storage appliance for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/storageAppliances</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAppliances_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudStorageApplianceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetworkCloudStorageApplianceResource> GetNetworkCloudStorageAppliancesAsync(CancellationToken cancellationToken)
            => GetNetworkCloudStorageAppliancesAsync(null, null, cancellationToken);

		/// <summary>
        /// Get the list of storage appliance for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/storageAppliances</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAppliances_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudStorageApplianceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetworkCloudStorageApplianceResource> GetNetworkCloudStorageAppliances(CancellationToken cancellationToken)
            => GetNetworkCloudStorageAppliances(null, null, cancellationToken);

		/// <summary>
        /// Get the list of trunked networks for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/trunkedNetworks</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TrunkedNetworks_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudTrunkedNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetworkCloudTrunkedNetworkResource> GetNetworkCloudTrunkedNetworksAsync(CancellationToken cancellationToken)
            => GetNetworkCloudTrunkedNetworksAsync(null, null, cancellationToken);

		/// <summary>
        /// Get the list of trunked networks for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/trunkedNetworks</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TrunkedNetworks_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudTrunkedNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetworkCloudTrunkedNetworkResource> GetNetworkCloudTrunkedNetworks(CancellationToken cancellationToken)
            => GetNetworkCloudTrunkedNetworks(null, null, cancellationToken);

		/// <summary>
        /// Get the list of virtual machines for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/virtualMachnies</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachines_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudVirtualMachineResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetworkCloudVirtualMachineResource> GetNetworkCloudVirtualMachinesAsync(CancellationToken cancellationToken)
            => GetNetworkCloudVirtualMachinesAsync(null, null, cancellationToken);

		/// <summary>
        /// Get the list of virtual machines for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/virtualMachnies</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachines_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudVirtualMachineResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetworkCloudVirtualMachineResource> GetNetworkCloudVirtualMachines(CancellationToken cancellationToken)
            => GetNetworkCloudVirtualMachines(null, null, cancellationToken);

        /// <summary>
        /// Get the list of volumes for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/volumes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Volumes_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudVolumeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetworkCloudVolumeResource> GetNetworkCloudVolumesAsync(CancellationToken cancellationToken)
            => GetNetworkCloudVolumesAsync(null, null, cancellationToken);

		/// <summary>
        /// Get the list of volumes for the subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/volumes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Volumes_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudVolumeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetworkCloudVolumeResource> GetNetworkCloudVolumes(CancellationToken cancellationToken)
            => GetNetworkCloudVolumes(null, null, cancellationToken);
    }
}
