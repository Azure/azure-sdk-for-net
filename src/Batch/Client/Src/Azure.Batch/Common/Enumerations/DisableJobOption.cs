// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// Specifies what to do with active tasks during a disable job operation.
    /// </summary>
    public enum DisableJobOption
    {
        /// <summary>
        /// Terminate running tasks and requeue them. The tasks will run again
        /// when the job is enabled.
        /// </summary>
        Requeue,
        
        /// <summary>
        /// Terminate running tasks. The tasks will not run again.
        /// </summary>
        Terminate,
        
        /// <summary>
        /// Allow currently running tasks to complete.
        /// </summary>
        Wait,
    }
}
