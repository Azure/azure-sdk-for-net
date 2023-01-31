// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Identity
{
    /// <summary>
    ///
    /// </summary>
    public class OnBehalfOfCredentialOptions : TokenCredentialOptions, ITokenCacheOptions, ISupportsDisableInstanceDiscovery
    {
        /// <summary>
        /// The <see cref="TokenCachePersistenceOptions"/>.
        /// </summary>
        public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }

        /// <summary>
        /// Will include x5c header in client claims when acquiring a token to enable subject name / issuer based authentication for the <see cref="ClientCertificateCredential"/>.
        /// </summary>
        public bool SendCertificateChain { get; set; }

        /// <summary>
        /// For multi-tenant applications, specifies additional tenants for which the credential may acquire tokens. Add the wildcard value "*" to allow the credential to acquire tokens for any tenant in which the application is installed.
        /// </summary>
        public IList<string> AdditionallyAllowedTenants => AdditionallyAllowedTenantsCore;

        /// <inheritdoc/>
        public bool DisableInstanceDiscovery { get; set; }
    }
}
