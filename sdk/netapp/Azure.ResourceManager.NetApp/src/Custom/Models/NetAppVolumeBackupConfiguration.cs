// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Volume Backup Properties. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NetAppVolumeBackupConfiguration
    {
        /// <summary> Vault Resource ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier VaultId { get; set; }

        /// <summary> Initializes a new instance of NetAppVolumeBackupConfiguration. </summary>
        /// <param name="backupPolicyId"> Backup Policy Resource ID. </param>
        /// <param name="isPolicyEnforced"> Policy Enforced. </param>
        /// <param name="vaultId"> Vault Resource ID. </param>
        /// <param name="isBackupEnabled"> Backup Enabled. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal NetAppVolumeBackupConfiguration(ResourceIdentifier backupPolicyId, bool? isPolicyEnforced, ResourceIdentifier vaultId, bool? isBackupEnabled)
        {
            BackupPolicyId = backupPolicyId;
            IsPolicyEnforced = isPolicyEnforced;
            VaultId = vaultId;
            IsBackupEnabled = isBackupEnabled;
        }
    }
}
