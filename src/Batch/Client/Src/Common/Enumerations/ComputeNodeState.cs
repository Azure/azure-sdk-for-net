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
    /// The state of a compute node.
    /// </summary>
    public enum ComputeNodeState
    {
        /// <summary>
        /// The compute node is not currently running a task.
        /// </summary>
        Idle,
        
        /// <summary>
        /// The compute node is rebooting.
        /// </summary>
        Rebooting,
        
        /// <summary>
        /// The compute node is being reimaged.
        /// </summary>
        Reimaging,
        
        /// <summary>
        /// The compute node is running one or more tasks (other than the start
        /// task).
        /// </summary>
        Running,
        
        /// <summary>
        /// The compute node cannot be used for task execution due to errors.
        /// </summary>
        Unusable,
        
        /// <summary>
        /// The Batch service has obtained the underlying virtual machine from
        /// Azure Compute, but it has not yet started to join a pool.
        /// </summary>
        Creating,
        
        /// <summary>
        /// The Batch service is starting on the underlying virtual machine.
        /// </summary>
        Starting,
        
        /// <summary>
        /// The start task has started running on the compute node, but
        /// waitForSuccess is set and the start task has not yet completed.
        /// </summary>
        WaitingForStartTask,
        
        /// <summary>
        /// The start task has failed on the compute node (and exhausted all
        /// retries), and waitForSuccess is set.  The node is not usable for
        /// running tasks.
        /// </summary>
        StartTaskFailed,
        
        /// <summary>
        /// The Batch service has lost contact with the compute node, and does
        /// not know its true state.
        /// </summary>
        Unknown,
        
        /// <summary>
        /// The compute node is leaving the pool, either because the user
        /// explicitly removed it or because the pool is resizing or
        /// autoscaling down.
        /// </summary>
        LeavingPool,

        /// <summary>
        /// The Batch service will not schedule any new tasks on the compute
        /// node.
        /// </summary>
        Offline,
    }
}
