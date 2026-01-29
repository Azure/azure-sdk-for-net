// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.RecoveryServices.Models
{
    /// <summary> Monitoring Settings of the vault. </summary>
    public partial class VaultMonitoringSettings
    {
        /// <summary> Gets or sets the azure monitor alert alerts for all job failures. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RecoveryServicesAlertsState? AzureMonitorAlertAlertsForAllJobFailures
        {
            get => AzureMonitorAlertSettings is null ? default : AzureMonitorAlertSettings.AlertsForAllJobFailures;
            set
            {
                if (AzureMonitorAlertSettings is null)
                    AzureMonitorAlertSettings = new RecoveryServicesAzureMonitorAlertSettings();
                AzureMonitorAlertSettings.AlertsForAllJobFailures = value;
            }
        }

        /// <summary> Gets or sets the classic alert alerts for critical operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RecoveryServicesAlertsState? ClassicAlertAlertsForCriticalOperations
        {
            get => ClassicAlertSettings is null ? default : ClassicAlertSettings.AlertsForCriticalOperations;
            set
            {
                if (ClassicAlertSettings is null)
                    ClassicAlertSettings = new RecoveryServicesClassicAlertSettings();
                ClassicAlertSettings.AlertsForCriticalOperations = value;
            }
        }
    }
}
