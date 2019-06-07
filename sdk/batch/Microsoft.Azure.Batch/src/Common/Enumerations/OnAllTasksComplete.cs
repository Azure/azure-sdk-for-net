// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
