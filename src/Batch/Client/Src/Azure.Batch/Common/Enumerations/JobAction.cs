// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// An action to take on the job containing a task, when that task completes.
    /// </summary>
    public enum JobAction
    {
        /// <summary>
        /// Take no action.
        /// </summary>
        None,

        /// <summary>
        /// Disable the job. 
        /// </summary>
        /// <remarks>This is equivalent to calling <see cref="JobOperations.DisableJob"/> with a disableTasks value of <see cref="DisableJobOption.Requeue"/>.</remarks>
        Disable,

        /// <summary>
        /// Terminate the job.
        /// </summary>
        /// <remarks>The termination reason in <see cref="CloudJob.ExecutionInformation"/> is set to "TaskFailed".</remarks>
        Terminate,
    }
}
