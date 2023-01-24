// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    /// <summary> Backup Vault. </summary>
    public partial class DataProtectionBackupVaultProperties
    {
        /// <summary> Is vault protected by resource guard. </summary>
        public bool? IsVaultProtectedByResourceGuard { get; set; }
    }
}
