// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeReplicationStatus
    {
        // Backward-compat: GA exposed VolumeReplicationRelationshipStatus (the legacy struct in
        // VolumeReplicationRelationshipStatus.cs). The spec uses the unified NetAppRelationshipStatus
        // (RelationshipStatus property). Forward as a different CLR type — @@clientName can't help
        // because the two names refer to different types.
        /// <summary> The volume replication relationship status (legacy alias of <see cref="RelationshipStatus"/>). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VolumeReplicationRelationshipStatus? VolumeReplicationRelationshipStatus =>
            RelationshipStatus.HasValue ? new VolumeReplicationRelationshipStatus(RelationshipStatus.Value.ToString()) : null;
    }
}
