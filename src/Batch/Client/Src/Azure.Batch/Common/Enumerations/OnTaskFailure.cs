// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// Specifies an action the Batch service should take when any task in the job fails.
    /// </summary>
    public enum OnTaskFailure
    {
        /// <summary>
        /// Do nothing.
        /// </summary>
        NoAction,

        /// <summary>
        /// Take the action associated with the task exit condition in the task's <see cref="CloudTask.ExitConditions"/> collection. (This may still result in no action being taken, if that is what the task specifies.)
        /// </summary>
        PerformExitOptionsJobAction,
    }
}
