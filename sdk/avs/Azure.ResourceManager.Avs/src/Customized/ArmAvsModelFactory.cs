// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Avs.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmAvsModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Avs.AvsPrivateCloudData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="skuName"> The private cloud SKU. </param>
        /// <param name="identity"> The identity of the private cloud, if configured. Current supported identity types: SystemAssigned, None. </param>
        /// <param name="managementCluster"> The default cluster used for management. </param>
        /// <param name="internet"> Connectivity to internet is enabled or disabled. </param>
        /// <param name="identitySources"> vCenter Single Sign On Identity Sources. </param>
        /// <param name="availability"> Properties describing how the cloud is distributed across availability zones. </param>
        /// <param name="encryption"> Customer managed key encryption, can be enabled or disabled. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="circuit"> An ExpressRoute Circuit. </param>
        /// <param name="endpoints"> The endpoints. </param>
        /// <param name="networkBlock"> The block of addresses should be unique across VNet in your subscription as well as on-premise. Make sure the CIDR format is conformed to (A.B.C.D/X) where A,B,C,D are between 0 and 255, and X is between 0 and 22. </param>
        /// <param name="managementNetwork"> Network used to access vCenter Server and NSX-T Manager. </param>
        /// <param name="provisioningNetwork"> Used for virtual machine cold migration, cloning, and snapshot migration. </param>
        /// <param name="vMotionNetwork"> Used for live migration of virtual machines. </param>
        /// <param name="vCenterPassword"> Optionally, set the vCenter admin password when the private cloud is created. </param>
        /// <param name="nsxtPassword"> Optionally, set the NSX-T Manager password when the private cloud is created. </param>
        /// <param name="vCenterCertificateThumbprint"> Thumbprint of the vCenter Server SSL certificate. </param>
        /// <param name="nsxtCertificateThumbprint"> Thumbprint of the NSX-T Manager SSL certificate. </param>
        /// <param name="externalCloudLinks"> Array of cloud link IDs from other clouds that connect to this one. </param>
        /// <param name="secondaryCircuit"> A secondary expressRoute circuit from a separate AZ. Only present in a stretched private cloud. </param>
        /// <param name="nsxPublicIPQuotaRaised"> Flag to indicate whether the private cloud has the quota for provisioned NSX Public IP count raised from 64 to 1024. </param>
        /// <returns> A new <see cref="Avs.AvsPrivateCloudData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AvsPrivateCloudData AvsPrivateCloudData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string skuName, ManagedServiceIdentity identity = null, AvsManagementCluster managementCluster = null, InternetConnectivityState? internet = null, IEnumerable<SingleSignOnIdentitySource> identitySources = null, PrivateCloudAvailabilityProperties availability = null, CustomerManagedEncryption encryption = null, AvsPrivateCloudProvisioningState? provisioningState = null, ExpressRouteCircuit circuit = null, AvsPrivateCloudEndpoints endpoints = null, string networkBlock = null, string managementNetwork = null, string provisioningNetwork = null, string vMotionNetwork = null, string vCenterPassword = null, string nsxtPassword = null, string vCenterCertificateThumbprint = null, string nsxtCertificateThumbprint = null, IEnumerable<ResourceIdentifier> externalCloudLinks = null, ExpressRouteCircuit secondaryCircuit = null, NsxPublicIPQuotaRaisedEnum? nsxPublicIPQuotaRaised = null)
            => AvsPrivateCloudData(id, name, resourceType, systemData, tags, location, managementCluster, internet, identitySources, availability, encryption, null, provisioningState, circuit, endpoints, networkBlock, managementNetwork, provisioningNetwork, vMotionNetwork, vCenterPassword, nsxtPassword, vCenterCertificateThumbprint, nsxtCertificateThumbprint, externalCloudLinks, secondaryCircuit, nsxPublicIPQuotaRaised, null, null, new AvsSku(skuName), identity, null);

        /// <summary> Initializes a new instance of <see cref="Avs.AvsPrivateCloudData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> The SKU (Stock Keeping Unit) assigned to this resource. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. Current supported identity types: None, SystemAssigned. </param>
        /// <param name="managementCluster"> The default cluster used for management. </param>
        /// <param name="internet"> Connectivity to internet is enabled or disabled. </param>
        /// <param name="identitySources"> vCenter Single Sign On Identity Sources. </param>
        /// <param name="availability"> Properties describing how the cloud is distributed across availability zones. </param>
        /// <param name="encryption"> Customer managed key encryption, can be enabled or disabled. </param>
        /// <param name="extendedNetworkBlocks">
        /// Array of additional networks noncontiguous with networkBlock. Networks must be
        /// unique and non-overlapping across VNet in your subscription, on-premise, and
        /// this privateCloud networkBlock attribute. Make sure the CIDR format conforms to
        /// (A.B.C.D/X).
        /// </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="circuit"> An ExpressRoute Circuit. </param>
        /// <param name="endpoints"> The endpoints. </param>
        /// <param name="networkBlock">
        /// The block of addresses should be unique across VNet in your subscription as
        /// well as on-premise. Make sure the CIDR format is conformed to (A.B.C.D/X) where
        /// A,B,C,D are between 0 and 255, and X is between 0 and 22
        /// </param>
        /// <param name="managementNetwork"> Network used to access vCenter Server and NSX-T Manager. </param>
        /// <param name="provisioningNetwork"> Used for virtual machine cold migration, cloning, and snapshot migration. </param>
        /// <param name="vMotionNetwork"> Used for live migration of virtual machines. </param>
        /// <param name="vCenterPassword"> Optionally, set the vCenter admin password when the private cloud is created. </param>
        /// <param name="nsxtPassword"> Optionally, set the NSX-T Manager password when the private cloud is created. </param>
        /// <param name="vCenterCertificateThumbprint"> Thumbprint of the vCenter Server SSL certificate. </param>
        /// <param name="nsxtCertificateThumbprint"> Thumbprint of the NSX-T Manager SSL certificate. </param>
        /// <param name="externalCloudLinks"> Array of cloud link IDs from other clouds that connect to this one. </param>
        /// <param name="secondaryCircuit">
        /// A secondary expressRoute circuit from a separate AZ. Only present in a
        /// stretched private cloud
        /// </param>
        /// <param name="nsxPublicIPQuotaRaised">
        /// Flag to indicate whether the private cloud has the quota for provisioned NSX
        /// Public IP count raised from 64 to 1024
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AvsPrivateCloudData AvsPrivateCloudData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string sku, ManagedServiceIdentity identity = null, AvsManagementCluster managementCluster = null, InternetConnectivityState? internet = null, IEnumerable<SingleSignOnIdentitySource> identitySources = null, PrivateCloudAvailabilityProperties availability = null, CustomerManagedEncryption encryption = null, IEnumerable<string> extendedNetworkBlocks = null, AvsPrivateCloudProvisioningState? provisioningState = null, ExpressRouteCircuit circuit = null, AvsPrivateCloudEndpoints endpoints = null, string networkBlock = null, string managementNetwork = null, string provisioningNetwork = null, string vMotionNetwork = null, string vCenterPassword = null, string nsxtPassword = null, string vCenterCertificateThumbprint = null, string nsxtCertificateThumbprint = null, IEnumerable<ResourceIdentifier> externalCloudLinks = null, ExpressRouteCircuit secondaryCircuit = null, NsxPublicIPQuotaRaisedEnum? nsxPublicIPQuotaRaised = null)
            => AvsPrivateCloudData(id, name, resourceType, systemData, tags, location, managementCluster, internet, identitySources, availability, encryption, extendedNetworkBlocks, provisioningState, circuit, endpoints, networkBlock, managementNetwork, provisioningNetwork, vMotionNetwork, vCenterPassword, nsxtPassword, vCenterCertificateThumbprint, nsxtCertificateThumbprint, externalCloudLinks, secondaryCircuit, nsxPublicIPQuotaRaised, null, null, null, new AvsSku(sku), identity, null);

        /// <summary> Initializes a new instance of <see cref="Avs.AvsPrivateCloudClusterData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="sku"> The SKU (Stock Keeping Unit) assigned to this resource. </param>
        /// <param name="clusterSize"> The cluster size. </param>
        /// <param name="provisioningState"> The state of the cluster provisioning. </param>
        /// <param name="clusterId"> The identity. </param>
        /// <param name="hosts"> The hosts. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AvsPrivateCloudClusterData AvsPrivateCloudClusterData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, string sku, int? clusterSize, AvsPrivateCloudClusterProvisioningState? provisioningState, int? clusterId, IEnumerable<string> hosts)
            => AvsPrivateCloudClusterData(id, name, resourceType, systemData, new AvsSku(sku), clusterSize, provisioningState, clusterId, hosts, null);

        /// <summary> Initializes a new instance of <see cref="Avs.AvsPrivateCloudClusterData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="clusterSize"> The cluster size. </param>
        /// <param name="provisioningState"> The state of the cluster provisioning. </param>
        /// <param name="clusterId"> The identity. </param>
        /// <param name="hosts"> The hosts. </param>
        /// <param name="vsanDatastoreName"> Name of the vsan datastore associated with the cluster. </param>
        /// <param name="sku"> The SKU (Stock Keeping Unit) assigned to this resource. </param>
        /// <returns> A new <see cref="Avs.AvsPrivateCloudClusterData"/> instance for mocking. </returns>
        public static AvsPrivateCloudClusterData AvsPrivateCloudClusterData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, int? clusterSize, AvsPrivateCloudClusterProvisioningState? provisioningState = null, int? clusterId = null, IEnumerable<string> hosts = null, string vsanDatastoreName = null, AvsSku sku = null)
            => AvsPrivateCloudClusterData(id, name, resourceType, systemData, sku, clusterSize, provisioningState, clusterId, hosts, vsanDatastoreName);

        /// <summary> Initializes a new instance of <see cref="Avs.AvsPrivateCloudDatastoreData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> The state of the datastore provisioning. </param>
        /// <param name="netAppVolumeId"> An Azure NetApp Files volume. </param>
        /// <param name="diskPoolVolume"> An iSCSI volume. </param>
        /// <param name="status"> The operational status of the datastore. </param>
        /// <returns> A new <see cref="Avs.AvsPrivateCloudDatastoreData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AvsPrivateCloudDatastoreData AvsPrivateCloudDatastoreData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, AvsPrivateCloudDatastoreProvisioningState? provisioningState, ResourceIdentifier netAppVolumeId, DiskPoolVolume diskPoolVolume, DatastoreStatus? status)
            => AvsPrivateCloudDatastoreData(id, name, resourceType, systemData, provisioningState, netAppVolumeId, diskPoolVolume, null, null, status);

        /// <summary> Initializes a new instance of <see cref="Avs.AvsPrivateCloudDatastoreData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> The state of the datastore provisioning. </param>
        /// <param name="netAppVolumeId"> An Azure NetApp Files volume. </param>
        /// <param name="diskPoolVolume"> An iSCSI volume. </param>
        /// <param name="elasticSanVolumeTargetId"> An Elastic SAN volume. </param>
        /// <param name="status"> The operational status of the datastore. </param>
        /// <returns> A new <see cref="Avs.AvsPrivateCloudDatastoreData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AvsPrivateCloudDatastoreData AvsPrivateCloudDatastoreData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, AvsPrivateCloudDatastoreProvisioningState? provisioningState, ResourceIdentifier netAppVolumeId, DiskPoolVolume diskPoolVolume, ResourceIdentifier elasticSanVolumeTargetId, DatastoreStatus? status)
            => AvsPrivateCloudDatastoreData(id, name, resourceType, systemData, provisioningState, netAppVolumeId, diskPoolVolume, elasticSanVolumeTargetId, null, status);

        /// <summary> Initializes a new instance of <see cref="Avs.WorkloadNetworkVmGroupData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="displayName"> Display name of the VM group. </param>
        /// <param name="members"> Virtual machine members of this group. </param>
        /// <param name="status"> VM Group status. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="revision"> NSX revision number. </param>
        /// <returns> A new <see cref="Avs.WorkloadNetworkVmGroupData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static WorkloadNetworkVmGroupData WorkloadNetworkVmGroupData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string displayName = null, IEnumerable<string> members = null, WorkloadNetworkVmGroupStatus? status = null, WorkloadNetworkVmGroupProvisioningState? provisioningState = null, long? revision = null)
        {
            return new WorkloadNetworkVmGroupData(
                id,
                name,
                resourceType,
                systemData,
                null,
                displayName is null && members is null ? default : new WorkloadNetworkVmGroupProperties(displayName, members.ToList(), status, provisioningState, revision, null));
        }
    }
}
