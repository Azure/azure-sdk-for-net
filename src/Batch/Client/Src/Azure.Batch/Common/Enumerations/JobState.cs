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
    /// The state of job
    /// </summary>
    public enum JobState
    {
        /// <summary>
        /// The job is available to have tasks scheduled.
        /// </summary>
        Active,
        
        /// <summary>
        /// A user has requested that the job be disabled, but the disable
        /// operation is still in progress (for example, waiting for tasks to
        /// terminate).
        /// </summary>
        Disabling,
        
        /// <summary>
        /// A user has disabled the job. No tasks are running, and no new tasks
        /// will be scheduled.
        /// </summary>
        Disabled,
        
        /// <summary>
        /// A user has requested that the job be enabled, but the enable
        /// operation is still in progress.
        /// </summary>
        Enabling,
        
        /// <summary>
        /// The job is about to complete, either because a Job Manager task has
        /// completed or because the user has terminated the job, but the
        /// terminate operation is still in progress (for example, because Job
        /// Release tasks are running).
        /// </summary>
        Terminating,
        
        /// <summary>
        /// All tasks have terminated, and the system will not accept any more
        /// tasks or any further changes to the job.
        /// </summary>
        Completed,
        
        /// <summary>
        /// A user has requested that the job be deleted, but the delete
        /// operation is still in progress (for example, because the system is
        /// still terminating running tasks).
        /// </summary>
        Deleting,
    }
}
