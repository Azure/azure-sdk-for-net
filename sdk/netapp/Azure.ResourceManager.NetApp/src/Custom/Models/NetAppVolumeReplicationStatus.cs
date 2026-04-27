// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeReplicationStatus
    {
        // Backward-compat: VolumeReplicationRelationshipStatus mapped from RelationshipStatus.
        /// <summary> The volume replication relationship status. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VolumeReplicationRelationshipStatus? VolumeReplicationRelationshipStatus =>
            RelationshipStatus.HasValue ? new VolumeReplicationRelationshipStatus(RelationshipStatus.Value.ToString()) : null;
    }
}
