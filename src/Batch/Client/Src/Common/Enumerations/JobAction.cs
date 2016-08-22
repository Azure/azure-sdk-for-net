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
    /// <summary>
    /// An action to take on the job containing a task, when that task completes.
    /// </summary>
    public enum JobAction
    {
        /// <summary>
        /// Take no action.
        /// </summary>
        None,

        /// <summary>
        /// Disable the job. 
        /// </summary>
        /// <remarks>This is equivalent to calling <see cref="JobOperations.DisableJob"/> with a disableTasks value of <see cref="DisableJobOption.Requeue"/>.</remarks>
        Disable,

        /// <summary>
        /// Terminate the job.
        /// </summary>
        /// <remarks>The termination reason in <see cref="CloudJob.ExecutionInformation"/> is set to "TaskFailed".</remarks>
        Terminate,
    }
}
