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
    /// The state of a job schedule.
    /// </summary>
    public enum JobScheduleState
    {
        /// <summary>
        /// The job schedule is active and will create jobs as per its schedule.
        /// </summary>
        Active,
        
        /// <summary>
        /// The schedule has terminated, either by reaching its end time or by
        /// the user terminating it explicitly.
        /// </summary>
        Completed,
        
        /// <summary>
        /// The user has disabled the schedule. The scheduler will not initiate
        /// any new jobs will on this schedule, but any existing active job
        /// will continue to run.
        /// </summary>
        Disabled,
        
        /// <summary>
        /// The schedule has no more work to do, or has been explicitly
        /// terminated by the user, but the termination operation is still in
        /// progress. The scheduler will not initiate any new jobs for this
        /// schedule, nor is any existing job active.
        /// </summary>
        Terminating,
        
        /// <summary>
        /// The user has requested that the schedule be deleted, but the delete
        /// operation is still in progress. The scheduler will not initiate
        /// any new jobs for this schedule, but any existing active job will
        /// continue to run. The schedule will be deleted when the existing
        /// job completes.
        /// </summary>
        Deleting,
    }
}
