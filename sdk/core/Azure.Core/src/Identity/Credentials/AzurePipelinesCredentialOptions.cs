// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.Identity
{
    /// <summary>
    /// Options used to configure the <see cref="AzurePipelinesCredential"/>.
    /// </summary>
#pragma warning disable AZC0034 // Type moved from Azure.Identity to Azure.Core; name conflict with NuGet Azure.Identity is expected
    public class AzurePipelinesCredentialOptions : TokenCredentialOptions, ISupportsDisableInstanceDiscovery, ISupportsAdditionallyAllowedTenants, ISupportsTokenCachePersistenceOptions
    {
        internal CredentialPipeline Pipeline { get; set; }

        internal MsalConfidentialClient MsalClient { get; set; }

        /// <summary>
        /// The URI of the OIDC request endpoint.
        /// </summary>
        internal string OidcRequestUri { get; set; } = Environment.GetEnvironmentVariable("SYSTEM_OIDCREQUESTURI");

        /// <inheritdoc/>
        public IList<string> AdditionallyAllowedTenants { get; internal set; } = new List<string>();

        /// <inheritdoc/>
        public bool DisableInstanceDiscovery { get; set; }

        /// <inheritdoc/>
        public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }
    }
#pragma warning restore AZC0034
}
