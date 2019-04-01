// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// The state of a Job Preparation task.
    /// </summary>
    public enum JobPreparationTaskState
    {
        /// <summary>
        /// The task is currently running (including retrying).
        /// </summary>
        Running,
        
        /// <summary>
        /// The task has exited with exit code 0, or the task has exhausted its
        /// retry limit, or the Batch service was unable to start the task due
        /// to scheduling errors.
        /// </summary>
        Completed,
    }
}
