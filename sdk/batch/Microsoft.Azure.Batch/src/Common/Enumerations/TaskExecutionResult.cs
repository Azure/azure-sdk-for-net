// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// The result of task execution.
    /// </summary>
    public enum TaskExecutionResult
    {
        /// <summary>
        /// The task ran successfully.
        /// </summary>
        Success,

        /// <summary>
        /// There was an error during processing of the task. The failure may have occurred before the task process was launched, while the task process was executing, or after the task process exited.
        /// </summary>
        Failure
    }
}
