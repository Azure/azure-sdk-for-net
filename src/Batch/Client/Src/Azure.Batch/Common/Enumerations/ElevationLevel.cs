// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// The elevation level of the user account used by the Batch service to execute a task.
    /// </summary>
    public enum ElevationLevel
    {
        /// <summary>
        /// The user has standard access permissions.
        /// </summary>
        NonAdmin,

        /// <summary>
        /// The user has elevated access and operates with full Administrator permissions.
        /// </summary>
        Admin
    }
}
