// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// The type of identity associated with a Batch pool.
    /// </summary>
    public enum PoolIdentityType
    {
        /// <summary>
        /// Batch pool has user assigned identities with it.
        /// </summary>
        UserAssigned,

        /// <summary>
        /// Batch pool has no identity associated with it. Setting `None` in update pool will remove existing identities.
        /// </summary>
        None
    }
}
