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
    public partial class CloudVmClusterProperties
    {
        /// <summary> Cloud VM Cluster ocid. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier Ocid { get => new ResourceIdentifier(CloudVmClusterOcid); }
        /// <summary> The OCID of the zone the cloud VM cluster is associated with. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ZoneId { get => new ResourceIdentifier(ZoneOcid) ; set => ZoneOcid = value.ToString(); }
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
