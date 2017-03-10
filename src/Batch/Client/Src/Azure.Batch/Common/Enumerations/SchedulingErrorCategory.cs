// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// The category of a task scheduling error.
    /// </summary>
    public enum SchedulingErrorCategory
    {
        /// <summary>
        /// The error was in the task specification provided by the user.
        /// </summary>
        UserError,
        
        /// <summary>
        /// The error occurred in the Batch service.
        /// </summary>
        ServerError,

        /// <summary>
        /// The service reported an option that is not recognized by this
        /// version of the Batch client.
        /// </summary>
        Unmapped,
    }
}
