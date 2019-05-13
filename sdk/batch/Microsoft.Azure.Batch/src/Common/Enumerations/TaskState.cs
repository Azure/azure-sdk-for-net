// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// The state of a task.
    /// </summary>
    public enum TaskState
    {
        /// <summary>
        /// The task is queued and able to run, but is not currently assigned
        /// to a compute node.
        /// </summary>
        Active,
        
        /// <summary>
        /// The task has been assigned to a compute node, but is waiting for a
        /// required Job Preparation task to complete on the node.
        /// </summary>
        Preparing,
        
        /// <summary>
        /// The task is running on a compute node.
        /// </summary>
        Running,
        
        /// <summary>
        /// The task is no longer eligible to run, usually because the task has
        /// finished successfully, or the task has finished unsuccessfully and
        /// has exhausted its retry limit.  A task is also marked as completed
        /// if an error occurred launching the task, or when the task has been
        /// terminated.
        /// </summary>
        Completed,
    }
}
