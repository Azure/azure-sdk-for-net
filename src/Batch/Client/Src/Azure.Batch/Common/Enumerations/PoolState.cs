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
    /// The state of a pool.
    /// </summary>
    public enum PoolState
    {
        /// <summary>
        /// The pool is available to run tasks subject to the availability of compute nodes.
        /// </summary>
        Active,
        
        /// <summary>
        /// The user has requested that the pool be deleted, but the delete
        /// operation has not yet completed.
        /// </summary>
        Deleting,
        
        /// <summary>
        /// The user has requested that the operating system of the pool's
        /// nodes be upgraded, but the upgrade operation has not yet completed
        /// (that is, some nodes in the pool have not yet been upgraded).
        /// </summary>
        Upgrading,
    }
}
