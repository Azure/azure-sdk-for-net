// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeBackupStatus
    {
        /// <summary> Health check. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsHealthy => Healthy;

        /// <summary> Backward-compat: VolumeBackupRelationshipStatus mapped from RelationshipStatus. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VolumeBackupRelationshipStatus? VolumeBackupRelationshipStatus =>
            RelationshipStatus.HasValue ? new VolumeBackupRelationshipStatus(RelationshipStatus.Value.ToString()) : null;
    }
}
