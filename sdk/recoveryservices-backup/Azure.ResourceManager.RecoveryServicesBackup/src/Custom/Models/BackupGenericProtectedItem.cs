// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    public partial class BackupGenericProtectedItem
    {
        /// <summary>
        /// SoftDelete Retention Period
        /// Serialized Name: SecuritySettings.immutabilitySettings
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? SoftDeleteRetentionPeriod
        {
            get => SoftDeleteRetentionPeriodInDays;
            set
            {
                SoftDeleteRetentionPeriodInDays = value;
            }
        }
    }
}
