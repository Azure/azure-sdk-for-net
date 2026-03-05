// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary>
    /// Replication status
    /// </summary>
    public partial class NetAppVolumeReplicationStatus
    {
        /// <summary> Initializes a new instance of <see cref="NetAppVolumeReplicationStatus"/>. </summary>
        internal NetAppVolumeReplicationStatus()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetAppVolumeReplicationStatus"/>. </summary>
        internal NetAppVolumeReplicationStatus(bool? isHealthy, NetAppRelationshipStatus? relationshipStatus, NetAppMirrorState? mirrorState, string totalProgress, string errorMessage)
        {
            IsHealthy = isHealthy;
            RelationshipStatus = relationshipStatus;
            MirrorState = mirrorState;
            TotalProgress = totalProgress;
            ErrorMessage = errorMessage;
        }

        /// <summary> Replication health check. </summary>
        public bool? IsHealthy { get; }

        /// <summary> Status of the mirror relationship. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppRelationshipStatus? RelationshipStatus { get; }

        /// <summary> The mirror state property. </summary>
        public NetAppMirrorState? MirrorState { get; }

        /// <summary> The progress of the replication. </summary>
        public string TotalProgress { get; }

        /// <summary> Displays error message if the replication is in an error state. </summary>
        public string ErrorMessage { get; }
    }
}
