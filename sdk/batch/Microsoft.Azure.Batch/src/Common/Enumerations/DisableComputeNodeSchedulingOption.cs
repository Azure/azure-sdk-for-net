// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// Specifies what to do with currently running tasks when disable task
    /// scheduling on the compute node.
    /// </summary>
    public enum DisableComputeNodeSchedulingOption
    {
        /// <summary>
        /// Terminate running tasks and requeue them. The tasks will run again
        /// when the job is enabled.
        /// </summary>
        Requeue,
        
        /// <summary>
        /// Terminate running tasks. The tasks will not run again.
        /// </summary>
        Terminate,
        
        /// <summary>
        /// Allow currently running tasks to complete. Schedule no new tasks
        /// while waiting.
        /// </summary>
        TaskCompletion,
    }
}
