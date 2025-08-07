// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// Defines values for ComputeNodeDeallocateOption.
    /// </summary>
    public enum ComputeNodeDeallocateOption
    {
        /// <summary>
        /// Terminate running Task processes and requeue the Tasks. The Tasks
        /// will run again when a Compute Node is available. Deallocate the
        /// Compute Node as soon as Tasks have been terminated.
        /// </summary>
        Requeue,
        
        /// <summary>
        /// Terminate running Tasks. The Tasks will be completed with
        /// failureInfo indicating that they were terminated, and will not run
        /// again. Deallocate the Compute Node as soon as Tasks have been
        /// terminated.
        /// </summary>
        Terminate,
        
        /// <summary>
        /// Allow currently running Tasks to complete. Schedule no new Tasks
        /// while waiting. Deallocate the Compute Node when all Tasks have
        /// completed.
        /// </summary>
        TaskCompletion,
        
        /// <summary>
        /// Allow currently running Tasks to complete, then wait for all Task
        /// data retention periods to expire. Schedule no new Tasks while
        /// waiting. Deallocate the Compute Node when all Task retention
        /// periods have expired.
        /// </summary>
        RetainedData,
    }
}

