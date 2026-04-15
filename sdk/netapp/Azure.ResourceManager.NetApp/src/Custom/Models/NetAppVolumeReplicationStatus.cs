// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Replication status. </summary>
    public partial class NetAppVolumeReplicationStatus
    {
        /// <summary> Replication health check. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsHealthy => Healthy;

        /// <summary> The status of the replication relationship. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VolumeReplicationRelationshipStatus? VolumeReplicationRelationshipStatus => RelationshipStatusValue;

        /// <summary> The status of the replication relationship (old API type). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppRelationshipStatus? RelationshipStatus =>
            RelationshipStatusValue.HasValue ? new NetAppRelationshipStatus(RelationshipStatusValue.Value.ToString()) : null;
    }
}
