// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public abstract partial class DataProtectionBackupDeleteSetting
    {
        /// <summary> Initializes a new instance of <see cref="DataProtectionBackupDeleteSetting"/>. </summary>
        /// <param name="duration"> Duration of deletion after given timespan. </param>
        protected DataProtectionBackupDeleteSetting(TimeSpan duration)  // This constructor is intentionally retained for backward compatibility.
        {
            Duration = duration;
        }
    }
}
