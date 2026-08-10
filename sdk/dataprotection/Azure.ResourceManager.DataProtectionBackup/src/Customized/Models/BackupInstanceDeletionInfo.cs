// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    [CodeGenSuppress("BackupInstanceDeletionInfo")]
    public partial class BackupInstanceDeletionInfo
    {
        /// <summary> Initializes a new instance of <see cref="BackupInstanceDeletionInfo"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BackupInstanceDeletionInfo()
        {
        }
    }
}
