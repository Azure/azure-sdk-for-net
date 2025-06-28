// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Security.KeyVault.Administration.Models
{
    /// <summary> Full restore operation. </summary>
    [CodeGenType("SelectiveKeyRestoreOperation")]
    internal partial class SelectiveKeyRestoreDetailsInternal
    {
        public SelectiveKeyRestoreDetailsInternal(RestoreDetailsInternal restoreDetails) :
            this(restoreDetails.Status, restoreDetails.StatusDetails, restoreDetails.Error, restoreDetails.JobId, restoreDetails.StartTime, restoreDetails.EndTime, new Dictionary<string, BinaryData>())
        { }
    }
}
