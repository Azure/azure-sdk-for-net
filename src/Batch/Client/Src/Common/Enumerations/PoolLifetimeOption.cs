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
    /// Specifies the minimum lifetime of created auto pools, and how multiple
    /// jobs on a schedule are assigned to pools.
    /// </summary>
    public enum PoolLifetimeOption
    {
        /// <summary>
        /// The pool exists for the lifetime of the job schedule.
        /// </summary>
        JobSchedule,
        
        /// <summary>
        /// The pool exists for the lifetime of the job to which it is
        /// dedicated.
        /// </summary>
        Job,

        /// <summary>
        /// The service reported an option that is not recognized by this
        /// version of the Batch client.
        /// </summary>
        Unmapped,
    }
}
