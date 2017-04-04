// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
