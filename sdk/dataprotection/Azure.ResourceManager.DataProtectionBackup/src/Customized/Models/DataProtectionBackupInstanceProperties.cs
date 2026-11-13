// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public partial class DataProtectionBackupInstanceProperties
    {
        /// <summary> Specifies the protection error of the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and will be removed in a future release. Please use ResourceProtectionErrorDetails instead.")]
        public Azure.ResponseError ProtectionErrorDetails { get => DataProtectionBackupUserFacingError.ToResponseError(ResourceProtectionErrorDetails); }
    }
}
