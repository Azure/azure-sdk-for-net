// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options for configuring the <see cref="EnvironmentCredential"/>.
    /// </summary>
    public class EnvironmentCredentialOptions : TokenCredentialOptions
    {
        /// <summary>
        /// Specifies whether an environment configured to use a certificate will include its x5c header in client claims
        /// when acquiring a token to enable subject name / issuer based authentication.
        /// </summary>
        public bool SendCertificateChain { get; set; }
    }
}
