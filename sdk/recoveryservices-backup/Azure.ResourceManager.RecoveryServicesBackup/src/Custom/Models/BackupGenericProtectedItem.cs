// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    public abstract partial class BackupGenericProtectedItem
    {
        /// <summary> Initializes a new instance of <see cref="BackupGenericProtectedItem"/> for deserialization. </summary>
        protected BackupGenericProtectedItem()
        {
        }

        /// <summary> SoftDelete Retention Period </summary>
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
