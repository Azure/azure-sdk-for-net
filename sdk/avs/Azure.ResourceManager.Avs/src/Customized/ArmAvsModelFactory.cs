// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Avs.Models
{
    /// <summary> Model factory for models. </summary>
    // The generated overloads cannot be used while CommonClusterProperties keeps virtual properties for ApiCompat.
    // TODO: Remove this model factory workaround once https://github.com/Azure/azure-sdk-for-net/issues/59326 is fixed.
    [CodeGenSuppress("AvsManagementCluster", typeof(int?), typeof(AvsPrivateCloudClusterProvisioningState?), typeof(int?), typeof(IEnumerable<string>), typeof(string))]
    [CodeGenSuppress("AvsManagementCluster", typeof(int?), typeof(AvsPrivateCloudClusterProvisioningState?), typeof(int?), typeof(IEnumerable<string>))]
    [CodeGenSuppress("CommonClusterProperties", typeof(int?), typeof(AvsPrivateCloudClusterProvisioningState?), typeof(int?), typeof(IEnumerable<string>))]
    [CodeGenSuppress("AvsHostProperties", typeof(string), typeof(AvsHostProvisioningState?), typeof(string), typeof(string), typeof(string), typeof(AvsHostMaintenance?), typeof(string))]
    public static partial class ArmAvsModelFactory
    {
        /// <summary> The properties of a management cluster. </summary>
        /// <param name="clusterSize"> The cluster size. </param>
        /// <param name="provisioningState"> The state of the cluster provisioning. </param>
        /// <param name="clusterId"> The identity. </param>
        /// <param name="hosts"> The hosts. </param>
        /// <param name="vsanDatastoreName"> Name of the vsan datastore associated with the cluster. </param>
        /// <returns> A new <see cref="Models.AvsManagementCluster"/> instance for mocking. </returns>
        // Preserve the prior public overload including VsanDatastoreName; generated output is suppressed above.
        public static AvsManagementCluster AvsManagementCluster(int? clusterSize = default, AvsPrivateCloudClusterProvisioningState? provisioningState = default, int? clusterId = default, IEnumerable<string> hosts = default, string vsanDatastoreName = default)
        {
            hosts ??= new ChangeTrackingList<string>();

            return new AvsManagementCluster(clusterSize, provisioningState, clusterId, hosts.ToList(), additionalBinaryDataProperties: null)
            {
                VsanDatastoreName = vsanDatastoreName
            };
        }

        /// <summary> The common properties of a cluster. </summary>
        /// <param name="clusterSize"> The cluster size. </param>
        /// <param name="provisioningState"> The state of the cluster provisioning. </param>
        /// <param name="clusterId"> The identity. </param>
        /// <param name="hosts"> The hosts. </param>
        /// <returns> A new <see cref="Models.CommonClusterProperties"/> instance for mocking. </returns>
        // Preserve the prior public overload for the customized virtual property shape.
        public static CommonClusterProperties CommonClusterProperties(int? clusterSize = default, AvsPrivateCloudClusterProvisioningState? provisioningState = default, int? clusterId = default, IEnumerable<string> hosts = default)
        {
            hosts ??= new ChangeTrackingList<string>();

            return new CommonClusterProperties(clusterSize, provisioningState, clusterId, hosts.ToList(), additionalBinaryDataProperties: null);
        }

        /// <summary>
        /// The properties of a host.
        /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="Models.GeneralAvsHostProperties"/> and <see cref="Models.SpecializedAvsHostProperties"/>.
        /// </summary>
        /// <param name="kind"> The kind of host. </param>
        /// <param name="provisioningState"> The state of the host provisioning. </param>
        /// <param name="displayName"> Display name of the host in VMware vCenter. </param>
        /// <param name="moRefId"> vCenter managed object reference ID of the host. </param>
        /// <param name="fqdn"> Fully qualified domain name of the host. </param>
        /// <param name="maintenance"> If provided, the host is in maintenance. The value is the reason for maintenance. </param>
        /// <param name="faultDomain"></param>
        /// <returns> A new <see cref="Models.AvsHostProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AvsHostProperties AvsHostProperties(string kind = default, AvsHostProvisioningState? provisioningState = default, string displayName = default, string moRefId = default, string fqdn = default, AvsHostMaintenance? maintenance = default, string faultDomain = default)
        {
            return new UnknownAvsHostProperties(
                default,
                provisioningState,
                displayName,
                moRefId,
                fqdn,
                maintenance,
                faultDomain,
                new ChangeTrackingList<HostLicense>(),
                default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AvsManagementCluster"/>. </summary>
        /// <param name="clusterSize"> The cluster size. </param>
        /// <param name="provisioningState"> The state of the cluster provisioning. </param>
        /// <param name="clusterId"> The identity. </param>
        /// <param name="hosts"> The hosts. </param>
        /// <returns> A new <see cref="Models.AvsManagementCluster"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        // Hidden compatibility overload from the previous generated API; delegate to the new overload.
        public static AvsManagementCluster AvsManagementCluster(int? clusterSize, AvsPrivateCloudClusterProvisioningState? provisioningState, int? clusterId, IEnumerable<string> hosts)
            => AvsManagementCluster(clusterSize: clusterSize, provisioningState: provisioningState, clusterId: clusterId, hosts: hosts, vsanDatastoreName: default);
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
                displayName is null && members is null ? default : new WorkloadNetworkVmGroupProperties(displayName, members?.ToList(), status, provisioningState, revision, null),
                null);
        }
    }
}
