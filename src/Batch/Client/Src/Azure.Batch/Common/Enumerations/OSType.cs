// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 


namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// Specifies the Operation System type.
    /// </summary>
    public enum OSType
    {
        /// <summary>
        /// Linux OS Family.
        /// </summary>
        Linux,
        
        /// <summary>
        /// Windows OS Family.
        /// </summary>
        Windows,

        /// <summary>
        /// The service reported an option that is not recognized by this
        /// version of the Batch client.
        /// </summary>
        Unmapped,
    }
}
