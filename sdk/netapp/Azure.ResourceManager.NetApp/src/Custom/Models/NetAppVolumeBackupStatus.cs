// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Backup status. </summary>
    public partial class NetAppVolumeBackupStatus
    {
        /// <summary> Gets or sets the IsHealthy property. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsHealthy => Healthy;

        /// <summary> The status of the backup relationship. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VolumeBackupRelationshipStatus? VolumeBackupRelationshipStatus => RelationshipStatusValue;

        /// <summary> The status of the backup relationship (old API type). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppRelationshipStatus? RelationshipStatus =>
            RelationshipStatusValue.HasValue ? new NetAppRelationshipStatus(RelationshipStatusValue.Value.ToString()) : null;
    }
}
