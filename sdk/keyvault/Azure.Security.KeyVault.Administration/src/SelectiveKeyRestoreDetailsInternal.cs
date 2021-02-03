// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Security.KeyVault.Administration.Models
{
    /// <summary> Full restore operation. </summary>
    [CodeGenModel("SelectiveKeyRestoreOperation")]
    internal partial class SelectiveKeyRestoreDetailsInternal
    {
        public SelectiveKeyRestoreDetailsInternal(RestoreDetailsInternal restoreDetails) :
            this(restoreDetails.Status, restoreDetails.StatusDetails, restoreDetails.Error, restoreDetails.JobId, restoreDetails.StartTime, restoreDetails.EndTime)
        { }
    }
}
