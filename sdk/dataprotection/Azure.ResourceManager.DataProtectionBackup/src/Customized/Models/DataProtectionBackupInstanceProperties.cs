// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    [CodeGenSuppress("ProtectionErrorDetails")]
    public partial class DataProtectionBackupInstanceProperties
    {
        /// <summary> Specifies the protection error of the resource. </summary>
        public Azure.ResponseError ProtectionErrorDetails { get; }
    }
}
