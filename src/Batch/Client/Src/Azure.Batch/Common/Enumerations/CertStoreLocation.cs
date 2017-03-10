// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    //TODO: If we are doing major breaking changes we could consider renaming this type to "Certificate..."

    /// <summary>
    /// The location of a certificate store on a pool's compute nodes.
    /// </summary>
    public enum CertStoreLocation
    {
        /// <summary>
        /// The X.509 certificate store used by the current user.
        /// </summary>
        CurrentUser,
        
        /// <summary>
        /// The X.509 certificate store assigned to the local machine.
        /// </summary>
        LocalMachine,

        /// <summary>
        /// The service reported an option that is not recognized by this
        /// version of the Batch client.
        /// </summary>
        Unmapped,
    }
}
