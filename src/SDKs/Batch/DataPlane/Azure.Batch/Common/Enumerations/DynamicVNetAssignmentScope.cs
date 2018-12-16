// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// The scope of dynamic virtual network assignment.
    /// </summary>
    public enum DynamicVNetAssignmentScope
    {
        /// <summary>
        /// No dynamic VNet assignment is enabled.
        /// </summary>
        None,

        /// <summary>
        /// Dynamic VNet assignment is done per-job.
        /// </summary>
        Job
    }
}
