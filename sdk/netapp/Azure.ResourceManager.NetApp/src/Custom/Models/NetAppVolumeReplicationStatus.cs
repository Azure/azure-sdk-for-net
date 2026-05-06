// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeReplicationStatus
    {
        // Backward-compat: the new generator emits `RelationshipStatus` (typed
        // NetAppRelationshipStatus, the unified enum) as the primary, public, generated
        // property — it is NOT hidden and NOT customized here.
        //
        // The shim below keeps the legacy v1.15 GA name `VolumeReplicationRelationshipStatus`
        // (which used a deprecated string-struct, in VolumeReplicationRelationshipStatus.cs)
        // reachable for source-compat, but marks it [EditorBrowsable(Never)] so IntelliSense
        // steers callers to the better generated `RelationshipStatus` property. @@clientName
        // cannot help because the two names refer to *different* CLR types (legacy struct vs.
        // unified enum) and projecting via clientName would change the return type.
        /// <summary> The volume replication relationship status (legacy alias of <see cref="RelationshipStatus"/>; prefer the latter). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VolumeReplicationRelationshipStatus? VolumeReplicationRelationshipStatus =>
            RelationshipStatus.HasValue ? new VolumeReplicationRelationshipStatus(RelationshipStatus.Value.ToString()) : null;
    }
}
