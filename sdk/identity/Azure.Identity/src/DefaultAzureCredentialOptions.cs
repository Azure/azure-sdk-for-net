// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="DefaultAzureCredential"/> authentication flow and requests made to Azure Identity services.
    /// </summary>
    public class DefaultAzureCredentialOptions : AzureCredentialOptions
    {
        /// <summary>
        /// Specifies the preferred authentication account in the case multiple accounts are found.
        /// </summary>
        public string PreferredAccountUsername { get; set; }

        /// <summary>
        /// Specifies the client id of the azure ManagedIdentity in the case of user assigned identity.
        /// </summary>
        public string ManagedIdentityClientId { get; set; }

        /// <summary>
        /// Specifies whether the EnvironmentCredential will be included to potentially read authentication details from the process' environment variables.
        /// </summary>
        public bool IncludeEnvironmentCredential { get; set; } = true;

        /// <summary>
        /// Specifies whether the ManagedIdentityCredential will be included to potentially get tokens from the a managed identity endpoint if available.
        /// </summary>
        public bool IncludeManagedIdentityCredential { get; set; } = true;

        /// <summary>
        /// Specifies whether the SharedTokenCacheCredential will be included to potentially get tokens from the shared token cache if avaliable.
        /// </summary>
        public bool IncludeSharedTokenCacheCredential { get; set; } = true;

        /// <summary>
        /// Specifies whether the InteractiveBrowserCredential will be included to potentially get tokens by launching the system default browser to enable a user to log in.
        /// </summary>
        public bool IncludeInteractiveBrowserCredential { get; set; } = false;
    }
}
