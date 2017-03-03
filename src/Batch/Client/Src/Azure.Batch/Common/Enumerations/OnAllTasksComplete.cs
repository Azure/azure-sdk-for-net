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
    /// Specifies an action the Batch service should take when all tasks in the job are in the completed state.
    /// </summary>
    public enum OnAllTasksComplete
    {
        /// <summary>
        /// Do nothing. The job remains active unless terminated or disabled by some other means.
        /// </summary>
        NoAction,

        /// <summary>
        /// Terminate the job. The job's <see cref="JobExecutionInformation.TerminateReason"/> is set to "AllTasksComplete". 
        /// </summary>
        TerminateJob,
    }
}
