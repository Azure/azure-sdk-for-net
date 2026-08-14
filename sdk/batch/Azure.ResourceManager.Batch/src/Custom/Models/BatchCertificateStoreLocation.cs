// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Batch.Models
{
    /// <summary> The location of the certificate store on the compute node into which to install the certificate. </summary>
    [Obsolete("This type is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum BatchCertificateStoreLocation
    {
        /// <summary> Certificates should be installed to the CurrentUser certificate store. </summary>
        CurrentUser = 0,
        /// <summary> Certificates should be installed to the LocalMachine certificate store. </summary>
        LocalMachine = 1,
    }
}
