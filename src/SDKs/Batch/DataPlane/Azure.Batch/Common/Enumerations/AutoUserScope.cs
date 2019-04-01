// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// The scope of the user account used by the Batch service to execute a task.
    /// </summary>
    public enum AutoUserScope
    {
        /// <summary>
        /// The task runs as a new user created specifically for the task.
        /// </summary>
        Task,

        /// <summary>
        /// The task runs as the common auto user account which is created on every node in a pool.
        /// </summary>
        Pool
    }
}
