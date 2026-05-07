// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public partial class BackupInstanceProtectionStatusDetails
    {
        /// <summary> Specifies the protection status error of the resource. </summary>
        [Obsolete("This property is deprecated and not supported. Retrieve the error details from the new ProtectionStatusErrorDetails property.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResponseError ErrorDetails { get => throw new NotSupportedException("This property is deprecated and not supported. Retrieve the error details from the new ProtectionStatusErrorDetails property."); }
    }
}
