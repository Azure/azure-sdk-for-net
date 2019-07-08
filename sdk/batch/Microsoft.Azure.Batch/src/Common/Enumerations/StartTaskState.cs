// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// The state of a start task on a compute node.
    /// </summary>
    public enum StartTaskState
    {
        /// <summary>
        /// The start task is currently running.
        /// </summary>
        Running,
        
        /// <summary>
        /// The start task has exited with exit code 0, or the start task has
        /// failed and the retry limit has reached, or the start task process
        /// did not run due to scheduling errors.
        /// </summary>
        Completed,
    }
}
