// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

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

        /// <summary> ID of the backup policy with which this item is backed up. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier PolicyId
        {
            get => string.IsNullOrEmpty(PolicyStringId) ? null : new ResourceIdentifier(PolicyId);
            set => PolicyId = new ResourceIdentifier(PolicyStringId);
        }
    }
}
