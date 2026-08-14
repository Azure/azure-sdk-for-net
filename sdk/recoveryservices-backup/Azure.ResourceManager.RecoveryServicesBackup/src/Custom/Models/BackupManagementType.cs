// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
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
