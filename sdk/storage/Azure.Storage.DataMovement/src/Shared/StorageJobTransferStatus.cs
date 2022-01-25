// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Defines the status of the <see cref="TransferJobInternal"/>.
    /// </summary>
    public enum StorageJobTransferStatus
    {
        /// <summary>
        /// The Job has been queued up but has not yet begun any transfers.
        /// </summary>
        Queued,

        /// <summary>
        /// The Job has started, but has not yet completed.
        /// </summary>
        InProgress,

        /// <summary>
        /// The Job has completed with no failures.
        /// </summary>
        Completed,

        /// <summary>
        /// The Job has completed with errors.
        /// </summary>
        CompletedWithErrors,

        /// <summary>
        /// Completed with failures.
        /// </summary>
        CompletedWithFailures,

        /// <summary>
        /// Completed with errors and skipped files.
        /// </summary>
        CompletedWithErrorsAndSkipped
    };
}
