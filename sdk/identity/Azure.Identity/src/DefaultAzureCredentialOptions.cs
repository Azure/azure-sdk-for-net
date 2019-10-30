// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="DefaultAzureCredential"/> authentication flow and requests made to Azure Identity services.
    /// </summary>
    public class DefaultAzureCredentialOptions : TokenCredentialOptions
    {
        /// <summary>
        /// Specifies the preferred authentication account to be retrieved from the shared token cache for single sign on authentication with
        /// development tools. In the case multiple accounts are found in the shared token.
        /// </summary>
        /// <remarks>
        /// If multiple accounts are found in the shared token cache and no value is specified, or the specified value matches no accounts in
        /// the cache the SharedTokenCacheCredential will not be used for authentication.
        /// </remarks>
        public string SharedTokenCacheUsername { get; set; }

        /// <summary>
        /// Specifies the client id of the azure ManagedIdentity in the case of user assigned identity.
        /// </summary>
        public string ManagedIdentityClientId { get; set; }

        /// <summary>
        /// Specifies whether the <see cref="EnvironmentCredential"/> will be excluded from the authentication flow. Setting to true disables reading
        /// authentication details from the process' environment variables.
        /// </summary>
        public bool ExcludeEnvironmentCredential { get; set; } = false;

        /// <summary>
        /// Specifies whether the <see cref="ManagedIdentityCredential"/> will be excluded from the <see cref="DefaultAzureCredential"/> authentication flow.
        /// Setting to true disables authenticating with managed identity endpoints.
        /// </summary>
        public bool ExcludeManagedIdentityCredential { get; set; } = false;

        /// <summary>
        /// Specifies whether the <see cref="SharedTokenCacheCredential"/> will be excluded from the <see cref="DefaultAzureCredential"/> authentication flow.
        /// Setting to true disables single sign on authentication with development tools which write to the shared token cache.
        /// </summary>
        public bool ExcludeSharedTokenCacheCredential { get; set; } = false;

        /// <summary>
        /// Specifies whether the <see cref="InteractiveBrowserCredential"/> will be excluded from the <see cref="DefaultAzureCredential"/> authentication flow.
        /// Setting to true disables launching the default system browser to authenticate in developement environments.
        /// </summary>
        public bool ExcludeInteractiveBrowserCredential { get; set; } = true;
    }
}
