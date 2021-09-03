// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Client certificate info.
    /// </summary>
    public sealed class ClientCertificateInfo
    {
        /// <summary>
        /// Certificate thumbprint.
        /// </summary>
        public string Thumbprint { get; }

        internal ClientCertificateInfo(string thumbprint)
        {
            Thumbprint = thumbprint;
        }
    }
}
