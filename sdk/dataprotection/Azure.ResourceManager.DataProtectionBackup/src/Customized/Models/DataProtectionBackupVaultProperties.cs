// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#nullable disable

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
        [Obsolete("CrossSubscriptionRestoreState is obsolete and will be removed in a future release. Please do not use it any longer.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState? CrossSubscriptionRestoreState
        {
            get => FeatureSettings?.CrossSubscriptionRestoreState;
            set
            {
                if (FeatureSettings is null)
                    FeatureSettings = new FeatureSettings();
                FeatureSettings.CrossSubscriptionRestoreState = value;
            }
        }

        internal DataProtectionBackupVaultProperties(MonitoringSettings monitoringSettings, DataProtectionBackupProvisioningState? provisioningState, BackupVaultResourceMoveState? resourceMoveState, BackupVaultResourceMoveDetails resourceMoveDetails, BackupVaultSecuritySettings securitySettings, IList<DataProtectionBackupStorageSetting> storageSettings, bool? isVaultProtectedByResourceGuard, DataProtectionBackupCrossSubscriptionRestoreState dataProtectionBackupCrossSubscriptionRestoreState)
        {
            MonitoringSettings = monitoringSettings;
            ProvisioningState = provisioningState;
            ResourceMoveState = resourceMoveState;
            ResourceMoveDetails = resourceMoveDetails;
            SecuritySettings = securitySettings;
            StorageSettings = storageSettings;
            IsVaultProtectedByResourceGuard = isVaultProtectedByResourceGuard;
            FeatureSettings = null;
            SecureScore = default(SecureScoreLevel);
        }
    }
}
