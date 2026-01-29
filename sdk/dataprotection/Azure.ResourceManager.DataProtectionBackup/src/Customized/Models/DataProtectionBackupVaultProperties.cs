// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

#nullable disable

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    /// <summary> Backup Vault. </summary>
    public partial class DataProtectionBackupVaultProperties
    {
        /// <summary> Is vault protected by resource guard. </summary>
        public bool? IsVaultProtectedByResourceGuard { get; set; }

        /// <summary>
        /// Gets or sets the cross subscription restore state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataProtectionBackupCrossSubscriptionRestoreState? CrossSubscriptionRestoreState
        {
            get => FeatureSettings is null ? default : FeatureSettings.CrossSubscriptionRestoreState;
            set
            {
                if (FeatureSettings is null)
                    FeatureSettings = new BackupVaultFeatureSettings();
                FeatureSettings.CrossSubscriptionRestoreState = value;
            }
        }
    }
}
