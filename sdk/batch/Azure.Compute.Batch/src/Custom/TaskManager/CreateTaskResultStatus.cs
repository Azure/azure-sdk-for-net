// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Compute.Batch
{
    /// <summary>
    /// Used by <see cref="TasksWorkflowManager"/> to classify an <see cref="CreateTaskResult"/> as successful or
    /// requiring a retry.
    /// </summary>
    /// <remarks>AddTaskResultStatus is not used to report non-retryable failure; a result handler should throw
    /// <see cref="AddTaskCollectionTerminatedException"/> for that.</remarks>
    public enum CreateTaskResultStatus
    {
        /// <summary>
        /// Classifies the result as a success.
        /// </summary>
        Success,

        /// <summary>
        /// Classifies the result as a failure and to not reprocess.
        /// </summary>
        Failure,

        /// <summary>
        /// Classifies the result as requiring a retry.
        /// </summary>
        Retry
    }
}
