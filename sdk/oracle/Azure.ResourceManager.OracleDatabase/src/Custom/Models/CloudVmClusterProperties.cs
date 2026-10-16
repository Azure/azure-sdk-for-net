// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary> CloudVmCluster resource model. </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CloudVmClusterProperties", typeof(string), typeof(int), typeof(ResourceIdentifier), typeof(IEnumerable<string>), typeof(ResourceIdentifier), typeof(string), typeof(ResourceIdentifier), typeof(string))]
    public partial class CloudVmClusterProperties
    {
        /// <summary> Initializes a new instance of <see cref="CloudVmClusterProperties"/>. </summary>
        /// <param name="hostname"> The hostname for the cloud VM cluster. </param>
        /// <param name="cpuCoreCount"> The number of CPU cores enabled on the cloud VM cluster. </param>
        /// <param name="cloudExadataInfrastructureId"> Cloud Exadata Infrastructure ID. </param>
        /// <param name="sshPublicKeys"> The public key portion of one or more key pairs used for SSH access to the cloud VM cluster. </param>
        /// <param name="vnetId"> VNET for network connectivity. </param>
        /// <param name="giVersion"> Oracle Grid Infrastructure (GI) software version. </param>
        /// <param name="subnetId"> Client subnet. </param>
        /// <param name="displayName"> Display Name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="hostname"/>, <paramref name="cloudExadataInfrastructureId"/>, <paramref name="sshPublicKeys"/>, <paramref name="vnetId"/>, <paramref name="giVersion"/>, <paramref name="subnetId"/> or <paramref name="displayName"/> is null. </exception>
        public CloudVmClusterProperties(string hostname, int cpuCoreCount, ResourceIdentifier cloudExadataInfrastructureId, IEnumerable<string> sshPublicKeys, ResourceIdentifier vnetId, string giVersion, ResourceIdentifier subnetId, string displayName)
        {
            Argument.AssertNotNull(hostname, nameof(hostname));
            Argument.AssertNotNull(cloudExadataInfrastructureId, nameof(cloudExadataInfrastructureId));
            Argument.AssertNotNull(sshPublicKeys, nameof(sshPublicKeys));
            Argument.AssertNotNull(vnetId, nameof(vnetId));
            Argument.AssertNotNull(giVersion, nameof(giVersion));
            Argument.AssertNotNull(subnetId, nameof(subnetId));
            Argument.AssertNotNull(displayName, nameof(displayName));

            FileSystemConfigurationDetails = new ChangeTrackingList<FileSystemConfigurationDetails>();
            Hostname = hostname;
            CpuCoreCount = cpuCoreCount;
            CloudExadataInfrastructureId = cloudExadataInfrastructureId;
            SshPublicKeys = sshPublicKeys.ToList();
            ScanIPIds = new ChangeTrackingList<string>();
            VipIds = new ChangeTrackingList<string>();
            VnetId = vnetId;
            GiVersion = giVersion;
            SubnetId = subnetId;
            NsgCidrs = new ChangeTrackingList<CloudVmClusterNsgCidr>();
            DisplayName = displayName;
            ComputeNodeOcids = new ChangeTrackingList<string>();
            DBServerOcids = new ChangeTrackingList<string>();
        }

        /// <summary> The FQDN of the DNS record for the SCAN IP addresses associated with the VM cluster. </summary>
        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("ScanDnsNameV2")]
        public string ScanDnsName { get; }

        /// <summary> The hostname for the cloud VM cluster in earlier API versions. </summary>
        // Retain the legacy property for compatibility without replacing or aliasing HostnameV2.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Hostname { get => HostnameV2; set => HostnameV2 = value; }

        /// <summary> Cloud VM Cluster ocid. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier Ocid { get => new ResourceIdentifier(CloudVmClusterOcid); }
        /// <summary> The OCID of the zone the cloud VM cluster is associated with. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ZoneId { get => new ResourceIdentifier(ZoneOcid); set => ZoneOcid = value.ToString(); }
        /// <summary> The OCID of the DNS record for the SCAN IP addresses that are associated with the cloud VM cluster. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ScanDnsRecordId { get => new ResourceIdentifier(ScanDnsRecordOcid); }
        /// <summary> The list of compute servers to be added to the cloud VM cluster. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ResourceIdentifier> ComputeNodes { get => ComputeNodeOcids?.Select(id => new ResourceIdentifier(id)).ToList(); }
        /// <summary> The OCID of the last maintenance update history entry. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier LastUpdateHistoryEntryId { get => new ResourceIdentifier(LastUpdateHistoryEntryOcid); }
        /// <summary> The list of DB servers. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ResourceIdentifier> DBServers { get => DBServerOcids?.Select(id => new ResourceIdentifier(id)).ToList(); }
        /// <summary> Cluster compartmentId. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier CompartmentId { get => new ResourceIdentifier(CompartmentOcid); }
        /// <summary> Cluster subnet ocid. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier SubnetOcid { get => new ResourceIdentifier(ClusterSubnetOcid); }
    }
}
