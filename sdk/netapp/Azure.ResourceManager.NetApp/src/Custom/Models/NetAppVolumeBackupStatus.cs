// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeBackupStatus
    {
        // Backward-compat: GA exposed RelationshipStatus. The spec now generates
        // VolumeBackupRelationshipStatus directly, so keep the old property as an alias.
        /// <summary> Status of the backup mirror relationship. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppRelationshipStatus? RelationshipStatus =>
            VolumeBackupRelationshipStatus.HasValue ? new NetAppRelationshipStatus(VolumeBackupRelationshipStatus.Value.ToString()) : null;
    }
}
