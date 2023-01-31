// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Identity
{
    /// <summary>
    /// Options used to configure the <see cref="ClientAssertionCredential"/>.
    /// </summary>
    public class ClientAssertionCredentialOptions : TokenCredentialOptions, ISupportsDisableInstanceDiscovery
    {
        internal CredentialPipeline Pipeline { get; set; }

        internal MsalConfidentialClient MsalClient { get; set; }

        /// <summary>
        /// For multi-tenant applications, specifies additional tenants for which the credential may acquire tokens. Add the wildcard value "*" to allow the credential to acquire tokens for any tenant in which the application is installed.
        /// </summary>
        public IList<string> AdditionallyAllowedTenants => AdditionallyAllowedTenantsCore;

        /// <inheritdoc/>
        public bool DisableInstanceDiscovery { get; set; }
    }
}
