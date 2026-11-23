// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Identity
{
    /// <summary>
    /// Options used to configure the <see cref="GitHubActionsCredential"/>.
    /// </summary>
#pragma warning disable AZC0034 // Type moved from Azure.Identity to Azure.Core; name conflict with NuGet Azure.Identity is expected
    public class GitHubActionsCredentialOptions : TokenCredentialOptions, ISupportsDisableInstanceDiscovery, ISupportsAdditionallyAllowedTenants, ISupportsTokenCachePersistenceOptions
    {
        /// <summary>
        /// The tenant ID of the Microsoft Entra application. Read from the <c>AZURE_TENANT_ID</c> environment variable.
        /// </summary>
        internal string TenantId { get; set; } = EnvironmentVariables.TenantId;

        /// <summary>
        /// The client (application) ID of the Microsoft Entra application. Read from the <c>AZURE_CLIENT_ID</c> environment variable.
        /// </summary>
        internal string ClientId { get; set; } = EnvironmentVariables.ClientId;

        /// <summary>
        /// The bearer token used to request an ID token from the GitHub OIDC provider. Read from the <c>ACTIONS_ID_TOKEN_REQUEST_TOKEN</c> environment variable.
        /// </summary>
        internal string RequestToken { get; set; } = EnvironmentVariables.GitHubActionsRequestToken;

        /// <summary>
        /// The URL used to request an ID token from the GitHub OIDC provider. Read from the <c>ACTIONS_ID_TOKEN_REQUEST_URL</c> environment variable.
        /// </summary>
        internal string RequestUrl { get; set; } = EnvironmentVariables.GitHubActionsRequestUrl;

        internal CredentialPipeline Pipeline { get; set; }

        internal MsalConfidentialClient MsalClient { get; set; }

        /// <summary>
        /// Specifies tenants in addition to the tenant specified by <c>AZURE_TENANT_ID</c> for which the credential may acquire tokens.
        /// Add the wildcard value "*" to allow the credential to acquire tokens for any tenant the application can access.
        /// </summary>
        /// <remarks>
        /// Defaults to the value of environment variable <c>AZURE_ADDITIONALLY_ALLOWED_TENANTS</c>.
        /// </remarks>
        public IList<string> AdditionallyAllowedTenants { get; internal set; } = EnvironmentVariables.AdditionallyAllowedTenants;

        /// <inheritdoc/>
        public bool DisableInstanceDiscovery { get; set; }

        /// <inheritdoc/>
        public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }
    }
#pragma warning restore AZC0034
}
