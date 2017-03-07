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
