// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options used to configure the <see cref="ClientCertificateCredential"/>.
    /// </summary>
    public class ClientCertificateCredentialOptions : TokenCredentialOptions, ITokenCacheOptions
    {
        /// <summary>
        /// Specifies the <see cref="TokenCachePersistenceOptions"/> to be used by the credential. If not options are specified, the token cache will not be persisted to disk.
        /// </summary>
        public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }

        /// <summary>
        /// Will include x5c header in client claims when acquiring a token to enable subject name / issuer based authentication for the <see cref="ClientCertificateCredential"/>.
        /// </summary>
        public bool SendCertificateChain { get; set; }

        /// <summary>
        /// Specifies either the specific <see cref="RegionalAuthority"/> (preferred), or use <see cref="RegionalAuthority.AutoDiscoverRegion"/> to attempt to auto-detect the region.
        /// If not specified or auto-detection fails the non-regional endpoint will be used.
        /// </summary>
        internal RegionalAuthority? RegionalAuthority { get; set; } = Azure.Identity.RegionalAuthority.FromEnvironment();
    }
}
