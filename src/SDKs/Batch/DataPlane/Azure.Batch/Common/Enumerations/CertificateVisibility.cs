// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// Specifies which user accounts on a compute node should have access to
    /// the private data of a certificate.
    /// </summary>
    [Flags]
    public enum CertificateVisibility
    {
        /// <summary>
        /// The certificate has no visibility.
        /// </summary>
        None = 0,

        /// <summary>
        /// The user account under which the start task is run.
        /// </summary>
        StartTask = 1,
        
        /// <summary>
        /// The accounts under which job tasks are run.
        /// </summary>
        Task = 2,
        
        /// <summary>
        /// The accounts under which users remotely access the node (using
        /// Remote Desktop).
        /// </summary>
        RemoteUser = 4,

        /// <summary>
        /// The service reported an option that is not recognized by this
        /// version of the Batch client.
        /// </summary>
        Unmapped = 8,
    }
}
