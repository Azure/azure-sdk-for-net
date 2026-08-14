// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public partial class DataProtectionBackupJobProperties
    {
        /// <summary> A List, detailing the errors related to the job. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and will be removed in a future release. Please use JobErrorDetails instead.")]
        public IReadOnlyList<Azure.ResponseError> ErrorDetails =>
            JobErrorDetails?.Select(DataProtectionBackupUserFacingError.ToResponseError).ToList();
    }
}
