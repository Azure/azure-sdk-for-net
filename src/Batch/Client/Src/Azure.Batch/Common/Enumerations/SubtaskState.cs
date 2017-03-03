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
    /// The state of a subtask.
    /// </summary>
    public enum SubtaskState
    {
        /// <summary>
        /// The subtask has been assigned to a compute node, but is waiting for a
        /// required Job Preparation task to complete on the node.
        /// </summary>
        Preparing,

        /// <summary>
        /// The subtask is running on a compute node.
        /// </summary>
        Running,

        /// <summary>
        /// The subtask is no longer eligible to run, usually because the it has
        /// finished successfully, or the subtask has finished unsuccessfully and
        /// has exhausted its retry limit.  A subtask is also marked as completed
        /// if an error occurred launching the subtask, or when the subtask has been
        /// terminated.
        /// </summary>
        Completed,
    }
}
