// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Volume Backup Properties. </summary>
    public partial class NetAppVolumeBackupConfiguration
    {
        /// <summary> Vault Resource ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier VaultId { get; set; }

        /// <summary> Backup Enabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsBackupEnabled { get; set; }

        // Formerly PolicyEnforced; renamed to IsPolicyEnforced.
        /// <summary> Compatibility alias for <see cref="IsPolicyEnforced"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? PolicyEnforced
        {
            get => IsPolicyEnforced;
            set => IsPolicyEnforced = value;
        }
    }
}
