// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppRestoreStatus
    {
        // Backward-compat: GA exposed RelationshipStatus. The spec now generates
        // VolumeRestoreRelationshipStatus directly, so keep the old property as an alias.
        /// <summary> Status of the restore SnapMirror relationship. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppRelationshipStatus? RelationshipStatus =>
            VolumeRestoreRelationshipStatus.HasValue ? new NetAppRelationshipStatus(VolumeRestoreRelationshipStatus.Value.ToString()) : null;
    }
}
