// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    [CodeGenSuppress("BackupJobExtendedInfo")]
    public partial class BackupJobExtendedInfo
    {
        /// <summary> Initializes a new instance of <see cref="BackupJobExtendedInfo"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BackupJobExtendedInfo()
        {
            AdditionalDetails = new ChangeTrackingDictionary<string, string>();
            SubTasks = new ChangeTrackingList<BackupJobSubTask>();
            WarningDetails = new ChangeTrackingList<UserFacingWarningDetail>();
        }
    }
}
