// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 


namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// Indicates whether a pool is resizing.
    /// </summary>
    public enum AllocationState
    {
        /// <summary>
        /// The pool is not resizing. There are no changes to the number of
        /// nodes in the pool in progress.
        /// </summary>
        Steady,
        
        /// <summary>
        /// The pool is resizing; that is, compute nodes are being added to or
        /// removed from the pool.
        /// </summary>
        Resizing,
        
        /// <summary>
        /// The pool was resizing, but the user has requested that the resize
        /// be stopped, but the stop request has not yet been completed.
        /// </summary>
        Stopping,
    }
}
