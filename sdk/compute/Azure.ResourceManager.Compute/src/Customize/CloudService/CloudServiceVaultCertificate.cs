// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceVaultCertificate
    {
        /// <summary> Initializes a new instance of CloudServiceVaultCertificate. </summary>
        public CloudServiceVaultCertificate()
        {
        }

        /// <summary> The certificate URI. </summary>
        public Uri CertificateUri { get; set; }

        /// <summary> Whether this is a bootstrap certificate. </summary>
        public bool? IsBootstrapCertificate { get; set; }
    }
}
