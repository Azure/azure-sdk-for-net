// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.

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
