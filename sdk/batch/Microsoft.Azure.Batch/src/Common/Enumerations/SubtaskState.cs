// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// The state of a subtask.
    /// </summary>
    public enum SubtaskState
    {
        /// <summary>
        /// The subtask has been assigned to a compute node, but is waiting for a
        /// required Job Preparation task to complete on the node.
        /// </summary>
        Preparing,

        /// <summary>
        /// The subtask is running on a compute node.
        /// </summary>
        Running,

        /// <summary>
        /// The subtask is no longer eligible to run, usually because the it has
        /// finished successfully, or the subtask has finished unsuccessfully and
        /// has exhausted its retry limit.  A subtask is also marked as completed
        /// if an error occurred launching the subtask, or when the subtask has been
        /// terminated.
        /// </summary>
        Completed,
    }
}
