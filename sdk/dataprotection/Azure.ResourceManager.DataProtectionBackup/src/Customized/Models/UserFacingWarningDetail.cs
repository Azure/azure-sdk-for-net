// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public partial class UserFacingWarningDetail
    {
        /// <summary> Error details for the warning. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and will be removed in a future release. Please use WarningDetails instead.")]
        public Azure.ResponseError Warning { get => DataProtectionBackupUserFacingError.ToResponseError(WarningDetails); set => WarningDetails = DataProtectionBackupUserFacingError.ToUserFacingError(value); }
    }
}
