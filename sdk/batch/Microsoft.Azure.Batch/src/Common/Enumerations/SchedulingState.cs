// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// Specifies whether the compute node should be available for task
    /// scheduling.
    /// </summary>
    public enum SchedulingState
    {
        /// <summary>
        /// The compute node is available for task scheduling.
        /// </summary>
        Enabled,
        
        /// <summary>
        /// The compute node is not available for task scheduling.
        /// </summary>
        Disabled,
    }
}
