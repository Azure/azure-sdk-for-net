// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Batch.Models
{
    /// <summary> The format of the certificate - either Pfx or Cer. If omitted, the default is Pfx. </summary>
    [Obsolete("This type is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum BatchAccountCertificateFormat
    {
        /// <summary> The certificate is a PFX (PKCS#12) formatted certificate or certificate chain. </summary>
        Pfx = 0,
        /// <summary> The certificate is a base64-encoded X.509 certificate. </summary>
        Cer = 1,
    }
}
