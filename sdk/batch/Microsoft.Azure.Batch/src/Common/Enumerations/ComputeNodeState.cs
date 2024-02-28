// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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

        /// <summary>
        /// The compute node has been preempted.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The Batch service will not
        /// schedule any new tasks on the compute node and any tasks which were running at the time of preemption were requeued.
        /// The Batch service will attempt to recover nodes which are in this state. After recovery, all data that was on the node
        /// at the time of the preemption is gone.
        /// </para>
        /// <para>
        /// You are not charged for compute nodes that have been preempted.
        /// </para>
        /// <para>
        /// This can only occurr on nodes where <see cref="ComputeNode.IsDedicated"/> is false.
        /// </para>
        /// </remarks>
        Preempted,

        /// <summary>
        /// The Compute Node is undergoing an OS upgrade operation.
        /// </summary>
        UpgradingOS
    }
}
