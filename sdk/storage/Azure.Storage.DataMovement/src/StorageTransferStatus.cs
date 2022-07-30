// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the status of the Transfer Job
    /// </summary>
    public enum StorageTransferStatus
    {
        /// <summary>
        /// The Job has been queued up but has not yet begun any transfers.
        /// </summary>
        Queued = 1,

        /// <summary>
        /// The Job has started, but has not yet completed.
        /// </summary>
        InProgress = 2,

        /// <summary>
        /// Paused jobs
        /// </summary>
        Paused = 3,

        /// <summary>
        /// The Job has completed.
        /// </summary>
        Completed = 4
    };
}
