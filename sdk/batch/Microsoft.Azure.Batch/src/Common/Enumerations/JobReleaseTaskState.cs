// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// The state of a Job Release task.
    /// </summary>
    public enum JobReleaseTaskState
    {
        /// <summary>
        /// The task is currently running.
        /// </summary>
        Running,
        
        /// <summary>
        /// The task has exited, or the Batch service was unable to start the
        /// task due to scheduling errors.
        /// </summary>
        Completed,
    }
}
