// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Represents the type of Subject Alternative Names (SAN) which to apply to an x509 certificate
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
