// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.

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
