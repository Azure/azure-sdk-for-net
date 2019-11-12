// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Represents the type of subject alternative names (SANs) which to apply to an X.509 certificate.
    /// </summary>
    public enum SubjectAlternativeNameType
    {
        /// <summary>
        /// Subject Alternative Names which are DNS entries
        /// </summary>
        Dns,

        /// <summary>
        /// Subject Alternative Names which are email identities
        /// </summary>
        Email,

        /// <summary>
        /// Subject Alternative Names which are unique principal names
        /// </summary>
        Upn,
    }
}
