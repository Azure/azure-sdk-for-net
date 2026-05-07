// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;

#nullable disable

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    /// <summary> Backup Vault. </summary>
    public partial class DataProtectionBackupVaultProperties
    {
        /// <summary> Initializes a new instance of <see cref="DataProtectionBackupVaultProperties"/>. </summary>
        /// <param name="storageSettings"> Storage Settings. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataProtectionBackupVaultProperties(IEnumerable<DataProtectionBackupStorageSetting> storageSettings)
        {
            Argument.AssertNotNull(storageSettings, nameof(storageSettings));
            StorageSettings = storageSettings.ToList();
            ResourceGuardOperationRequests = new ChangeTrackingList<string>();
            ReplicatedRegions = new ChangeTrackingList<Azure.Core.AzureLocation>();
        }

        /// <summary> Is vault protected by resource guard. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsVaultProtectedByResourceGuard { get; set; }

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
