// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    public partial class BackupResourceVaultConfigProperties
    {
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
