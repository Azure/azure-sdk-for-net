// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppRestoreStatus
    {
        // Backward-compat: GA exposed VolumeRestoreRelationshipStatus (the legacy struct in
        // VolumeRestoreRelationshipStatus.cs). The spec uses the unified NetAppRelationshipStatus
        // type (RelationshipStatus property). Forward to it as a different CLR type — @@clientName
        // can't help because the two names refer to *different* types.
        /// <summary> The volume restore relationship status (legacy alias of <see cref="RelationshipStatus"/>). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VolumeRestoreRelationshipStatus? VolumeRestoreRelationshipStatus =>
            RelationshipStatus.HasValue ? new VolumeRestoreRelationshipStatus(RelationshipStatus.Value.ToString()) : null;
    }
}
