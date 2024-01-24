// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Backup patch. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NetAppVolumeBackupPatch
    {
        /// <summary> Initializes a new instance of NetAppVolumeBackupPatch. </summary>
        public NetAppVolumeBackupPatch()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; }
        /// <summary> UUID v4 used to identify the Backup. </summary>
        public string BackupId { get; }
        /// <summary> The creation date of the backup. </summary>
        public DateTimeOffset? CreatedOn { get; }
        /// <summary> Azure lifecycle management. </summary>
        public string ProvisioningState { get; }
        /// <summary> Size of backup. </summary>
        public long? Size { get; }
        /// <summary> Label for backup. </summary>
        public string Label { get; set; }
        /// <summary> Type of backup Manual or Scheduled. </summary>
        public NetAppBackupType? BackupType { get; }
        /// <summary> Failure reason. </summary>
        public string FailureReason { get; }
        /// <summary> Volume name. </summary>
        public string VolumeName { get; }
        /// <summary> Manual backup an already existing snapshot. This will always be false for scheduled backups and true/false for manual backups. </summary>
        public bool? UseExistingSnapshot { get; set; }
    }
}
