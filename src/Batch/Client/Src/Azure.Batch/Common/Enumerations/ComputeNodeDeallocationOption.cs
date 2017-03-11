// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// Specifies when compute nodes may be removed from a pool.
    /// </summary>
    public enum ComputeNodeDeallocationOption
    {
        /// <summary>
        /// Terminate running tasks and requeue them. The tasks will run again
        /// when the job is enabled. Remove nodes as soon as tasks have been
        /// terminated.
        /// </summary>
        Requeue,
        
        /// <summary>
        /// Terminate running tasks. The tasks will not run again. Remove nodes
        /// as soon as tasks have been terminated.
        /// </summary>
        Terminate,
        
        /// <summary>
        /// Allow currently running tasks to complete. Schedule no new tasks
        /// while waiting. Remove nodes when all tasks have completed.
        /// </summary>
        TaskCompletion,
        
        /// <summary>
        /// Allow currently running tasks to complete, then wait for all task
        /// data retention periods to expire. Schedule no new tasks while
        /// waiting. Remove nodes when all task retention periods have expired.
        /// </summary>
        RetainedData,
    }
}
