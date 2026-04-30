// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeBackupStatus
    {
        // Backward-compat: GA exposed VolumeBackupRelationshipStatus (the legacy struct in
        // VolumeBackupRelationshipStatus.cs). The spec uses the unified NetAppRelationshipStatus
        // (RelationshipStatus property). Forward as a different CLR type — @@clientName can't help
        // because the two names refer to different types.
        /// <summary> The volume backup relationship status (legacy alias of <see cref="RelationshipStatus"/>). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VolumeBackupRelationshipStatus? VolumeBackupRelationshipStatus =>
            RelationshipStatus.HasValue ? new VolumeBackupRelationshipStatus(RelationshipStatus.Value.ToString()) : null;
    }
}
