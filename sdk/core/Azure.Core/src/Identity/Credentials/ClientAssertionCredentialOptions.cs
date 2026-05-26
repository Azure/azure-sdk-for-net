// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Azure.Identity
{
    /// <summary>
    /// Options used to configure the <see cref="ClientAssertionCredential"/>.
    /// </summary>
#pragma warning disable AZC0034 // Type moved from Azure.Identity to Azure.Core; name conflict with NuGet Azure.Identity is expected
    [TypeForwardedFrom("Azure.Identity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=92742159e12e44c8")]
    public class ClientAssertionCredentialOptions : TokenCredentialOptions, ISupportsDisableInstanceDiscovery, ISupportsAdditionallyAllowedTenants, ISupportsTokenCachePersistenceOptions
    {
        internal CredentialPipeline Pipeline { get; set; }

        internal MsalConfidentialClient MsalClient { get; set; }

        /// <summary>
        /// For multi-tenant applications, specifies additional tenants for which the credential may acquire tokens. Add the wildcard value "*" to allow the credential to acquire tokens for any tenant in which the application is installed.
        /// </summary>
        public IList<string> AdditionallyAllowedTenants { get; internal set; } = new List<string>();

        /// <inheritdoc/>
        public bool DisableInstanceDiscovery { get; set; }

        /// <inheritdoc/>
        public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }
    }
#pragma warning restore AZC0034
}
