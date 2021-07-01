// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// The placement policy for allocating nodes in the pool.
    /// The default value is regional.
    /// </summary>
    public enum NodePlacementPolicyType
    {
        /// <summary>
        /// All nodes in the pool will be allocated in the same region.
        /// </summary>
        Regional,

        /// <summary>
        /// Nodes in the pool will be spread across different availability zones with best effort balancing.
        /// </summary>
        Zonal,
    }
}
