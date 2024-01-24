// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Backup status. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NetAppVolumeBackupStatus
    {
        /// <summary> Initializes a new instance of NetAppVolumeBackupStatus. </summary>
        internal NetAppVolumeBackupStatus()
        {
        }

        /// <summary> Initializes a new instance of NetAppVolumeBackupStatus. </summary>
        /// <param name="isHealthy"> Backup health status. </param>
        /// <param name="relationshipStatus"> Status of the backup mirror relationship. </param>
        /// <param name="mirrorState"> The status of the backup. </param>
        /// <param name="unhealthyReason"> Reason for the unhealthy backup relationship. </param>
        /// <param name="errorMessage"> Displays error message if the backup is in an error state. </param>
        /// <param name="lastTransferSize"> Displays the last transfer size. </param>
        /// <param name="lastTransferType"> Displays the last transfer type. </param>
        /// <param name="totalTransferBytes"> Displays the total bytes transferred. </param>
        internal NetAppVolumeBackupStatus(bool? isHealthy, NetAppRelationshipStatus? relationshipStatus, NetAppMirrorState? mirrorState, string unhealthyReason, string errorMessage, long? lastTransferSize, string lastTransferType, long? totalTransferBytes)
        {
            IsHealthy = isHealthy;
            RelationshipStatus = relationshipStatus;
            MirrorState = mirrorState;
            UnhealthyReason = unhealthyReason;
            ErrorMessage = errorMessage;
            LastTransferSize = lastTransferSize;
            LastTransferType = lastTransferType;
            TotalTransferBytes = totalTransferBytes;
        }

        /// <summary> Backup health status. </summary>
        public bool? IsHealthy { get; }
        /// <summary> Status of the backup mirror relationship. </summary>
        public NetAppRelationshipStatus? RelationshipStatus { get; }
        /// <summary> The status of the backup. </summary>
        public NetAppMirrorState? MirrorState { get; }
        /// <summary> Reason for the unhealthy backup relationship. </summary>
        public string UnhealthyReason { get; }
        /// <summary> Displays error message if the backup is in an error state. </summary>
        public string ErrorMessage { get; }
        /// <summary> Displays the last transfer size. </summary>
        public long? LastTransferSize { get; }
        /// <summary> Displays the last transfer type. </summary>
        public string LastTransferType { get; }
        /// <summary> Displays the total bytes transferred. </summary>
        public long? TotalTransferBytes { get; }
    }
}
