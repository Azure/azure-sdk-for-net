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
