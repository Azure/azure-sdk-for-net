// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    // The model defined in the new definitions is not used, and the missing values ​​are added back through custom code.
    public readonly partial struct BackupManagementType
    {
        private const string BackupProtectedItemCountSummaryValue = "BackupProtectedItemCountSummary";
        private const string BackupProtectionContainerCountSummaryValue = "BackupProtectionContainerCountSummary";

        /// <summary> BackupProtectedItemCountSummary. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BackupManagementType BackupProtectedItemCountSummary { get; } = new BackupManagementType(BackupProtectedItemCountSummaryValue);

        /// <summary> BackupProtectionContainerCountSummary. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BackupManagementType BackupProtectionContainerCountSummary { get; } = new BackupManagementType(BackupProtectionContainerCountSummaryValue);
    }
}
