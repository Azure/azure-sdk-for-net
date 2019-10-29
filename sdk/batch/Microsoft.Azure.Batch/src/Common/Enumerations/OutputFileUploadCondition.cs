// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// The conditions under which a task's output file(s) should be uploaded.
    /// </summary>
    public enum OutputFileUploadCondition
    {
        /// <summary>
        /// Upload the file(s) only after the task process exits with an exit code of 0.
        /// </summary>
        TaskSuccess,

        /// <summary>
        /// Upload the file(s) only after the task process exits with a nonzero exit code.
        /// </summary>
        TaskFailure,

        /// <summary>
        /// Upload the file(s) after the task process exits, no matter what the exit code was.
        /// </summary>
        TaskCompletion
    }
}
