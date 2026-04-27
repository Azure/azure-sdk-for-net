// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppRestoreStatus
    {
        /// <summary> Health check. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsHealthy => Healthy;

        // Backward-compat: VolumeRestoreRelationshipStatus mapped from RelationshipStatus.
        /// <summary> The volume restore relationship status. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VolumeRestoreRelationshipStatus? VolumeRestoreRelationshipStatus =>
            RelationshipStatus.HasValue ? new VolumeRestoreRelationshipStatus(RelationshipStatus.Value.ToString()) : null;
    }
}
