// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// These options are used in both the certificate client and the regular client.
    /// </summary>
    public partial class CodeTransparencyClientOptions : ClientOptions
    {
        /// <summary>
        /// The default time to keep the successful certificate responses that have TLS CA.
        /// </summary>
        public TimeSpan CacheTTL { get; set; } = TimeSpan.FromMinutes(5);

        /// <summary>
        /// The default identity service endpoint.
        /// </summary>
        public Uri IdentityClientEndpoint { get; set; } = new Uri("https://identity.confidential-ledger.core.azure.com/");

        /// <summary>
        /// Used in the regular client constructor.
        /// Creates the <see cref="CodeTransparencyCertificateClient"/> used to get the identity service certificate.
        /// </summary>
        public virtual CodeTransparencyCertificateClient CreateCertificateClient()
        {
            return new CodeTransparencyCertificateClient(IdentityClientEndpoint, this);
        }
    }
}
