// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeReplicationStatus
    {
        // Backward-compat: GA exposed RelationshipStatus. The spec now generates
        // VolumeReplicationRelationshipStatus directly, so keep the old property as an alias.
        /// <summary> Status of the mirror relationship. </summary>
        public NetAppRelationshipStatus? RelationshipStatus =>
            VolumeReplicationRelationshipStatus.HasValue ? new NetAppRelationshipStatus(VolumeReplicationRelationshipStatus.Value.ToString()) : null;
    }
}
