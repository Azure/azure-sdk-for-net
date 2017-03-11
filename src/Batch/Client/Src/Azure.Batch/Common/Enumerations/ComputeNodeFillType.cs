// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// Specifies how tasks should be distributed across compute nodes.
    /// </summary>
    public enum ComputeNodeFillType
    {
        /// <summary>
        /// Tasks should be assigned evenly across all nodes in the pool.
        /// </summary>
        Spread,
        
        /// <summary>
        /// As many tasks as possible (maxTasksPerNode) should be assigned to
        /// each node in the pool before any tasks are assigned to the next
        /// node in the pool.
        /// </summary>
        Pack,

        /// <summary>
        /// The service reported an option that is not recognized by this
        /// version of the Batch client.
        /// </summary>
        Unmapped,
    }
}
