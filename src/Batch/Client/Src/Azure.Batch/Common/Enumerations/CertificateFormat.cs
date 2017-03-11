// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// Certificate format.
    /// </summary>
    public enum CertificateFormat
    {
        /// <summary>
        /// Personal Information Exchange (PKCS #12) format.
        /// </summary>
        Pfx,
        
        /// <summary>
        /// X.509 certificate format.
        /// </summary>
        Cer,

        /// <summary>
        /// The service reported an option that is not recognized by this
        /// version of the Batch client.
        /// </summary>
        Unmapped,
    }
}
