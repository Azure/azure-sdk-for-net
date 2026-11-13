// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
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

        /// <summary> Gets or sets the alert settings for all job failures. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AzureMonitorAlertsState? AlertSettingsForAllJobFailures
        {
            get
            {
                return MonitoringSettings is null ? default : MonitoringSettings.AlertSettingsForAllJobFailures;
            }
            set
            {
                if (MonitoringSettings is null)
                {
                    MonitoringSettings = new MonitoringSettings();
                }
                MonitoringSettings.AlertSettingsForAllJobFailures = value;
            }
        }
    }
}
