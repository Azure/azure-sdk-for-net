// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    /// <summary> BackupGenericProtectedItem backward-compatibility shim. </summary>
    public partial class BackupGenericProtectedItem
    {
        /// <summary>
        /// SoftDelete Retention Period
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? SoftDeleteRetentionPeriod { get; set; }
    }
}
