// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// The state of a certificate
    /// </summary>
    public enum CertificateState
    {
        /// <summary>
        /// The certificate is available for use in pools.
        /// </summary>
        Active,
        
        /// <summary>
        /// The user has requested that the certificate be deleted, but the
        /// delete operation has not yet completed. You may not reference the
        /// certificate when creating or updating pools .
        /// </summary>
        Deleting,
        
        /// <summary>
        /// The user requested that the certificate be deleted, but there are
        /// pools that still have references to the certificate, or it is
        /// still installed on one or more compute nodes.
        /// </summary>
        DeleteFailed,
    }
}
