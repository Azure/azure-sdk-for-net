// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public partial class DataProtectionBackupVaultPatchProperties
    {
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
