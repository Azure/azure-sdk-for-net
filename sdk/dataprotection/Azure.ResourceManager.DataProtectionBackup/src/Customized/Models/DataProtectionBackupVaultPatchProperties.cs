// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public partial class DataProtectionBackupVaultPatchProperties
    {
        /// <summary>
        /// Gets or sets the cross subscription restore state.
        /// </summary>
        [Obsolete("CrossSubscriptionRestoreState is obsolete and will be removed in a future release. Please do not use it any longer.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState? CrossSubscriptionRestoreState{
            get => FeatureSettings?.CrossSubscriptionRestoreState;
            set
            {
                if (FeatureSettings is null)
                    FeatureSettings = new FeatureSettings();
                FeatureSettings.CrossSubscriptionRestoreState = value;
            }
        }
    }
}
