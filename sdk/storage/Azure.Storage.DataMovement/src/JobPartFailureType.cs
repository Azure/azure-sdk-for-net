// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Internally defines the type of failure that is occurred during the transfer in order
    /// to properly clean up a job part that completed with failures or was paused.
    /// </summary>
    internal enum JobPartFailureType
    {
        /// <summary>
        /// Was unable to either authenticate or access the storage resource destination.
        /// </summary>
        AccessDenied = 3,

        /// <summary>
        /// If the storage resource already exists and <see cref="StorageResourceCreateMode.Overwrite"/>
        /// or <see cref="StorageResourceCreateMode.Skip"/> was not enabled, then it's a failure caused
        /// by the file already existing.
        /// </summary>
        CannotOvewrite = 2,

        /// <summary>
        /// Failure occurred due to unclassified error.
        /// </summary>
        Other = 1,

        /// <summary>
        /// No error occurred
        /// </summary>
        None = 0,
    }
}
