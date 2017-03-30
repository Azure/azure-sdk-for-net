// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    using System;

    /// <summary>
    /// The Batch resources that can be accessed by a task using an authentication token provided via the <see cref="CloudTask.AuthenticationTokenSettings"/> property.
    /// </summary>
    [Flags]
    public enum AccessScope
    {
        /// <summary>
        /// The authentication token does not grant access to any resources.
        /// </summary>
        None = 0,
        
        /// <summary>
        /// The authentication token permits access to the job that contains the task.
        /// </summary>
        Job = 1
    }
}
