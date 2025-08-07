// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Volume Backup Properties. </summary>
    [CodeGenSuppress("NetAppVolumeBackupConfiguration")]
    public partial class NetAppVolumeBackupConfiguration
    {
        /// <summary> Initializes a new instance of <see cref="NetAppVolumeBackupConfiguration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppVolumeBackupConfiguration()
        {
        }
        /// <summary> Vault Resource ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier VaultId { get; set; }

        /// <summary> Backup Enabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsBackupEnabled { get; set; }
    }
}
