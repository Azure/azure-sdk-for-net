// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="DefaultAzureCredential"/> authentication flow and requests made to Azure Identity services.
    /// </summary>
    public class DefaultAzureCredentialOptions : TokenCredentialOptions
    {
        /// <summary>
        /// The tenant id of the user to authenticate, in the case the <see cref="DefaultAzureCredential"/> authenticates through, the
        /// <see cref="InteractiveBrowserCredential"/>. The default is null and will authenticate users to their default tenant.
        /// The value can also be set by setting the environment variable AZURE_TENANT_ID.
        /// </summary>
        public string InteractiveBrowserTenantId { get; set; } = GetNonEmptyStringOrNull(EnvironmentVariables.TenantId);

        /// <summary>
        /// Specifies the tenant id of the preferred authentication account, to be retrieved from the shared token cache for single sign on authentication with
        /// development tools, in the case multiple accounts are found in the shared token.
        /// </summary>
        /// <remarks>
        /// If multiple accounts are found in the shared token cache and no value is specified, or the specified value matches no accounts in
        /// the cache the SharedTokenCacheCredential will not be used for authentication.
        /// </remarks>
        public string SharedTokenCacheTenantId { get; set; } = GetNonEmptyStringOrNull(EnvironmentVariables.TenantId);

        /// <summary>
        /// The tenant id of the user to authenticate, in the case the <see cref="DefaultAzureCredential"/> authenticates through, the
        /// <see cref="VisualStudioCredential"/>. The default is null and will authenticate users to their default tenant.
        /// The value can also be set by setting the environment variable AZURE_TENANT_ID.
        /// </summary>
        public string VisualStudioTenantId { get; set; } = GetNonEmptyStringOrNull(EnvironmentVariables.TenantId);

        /// <summary>
        /// The tenant id of the user to authenticate, in the case the <see cref="DefaultAzureCredential"/> authenticates through, the
        /// <see cref="VisualStudioCodeCredential"/>. The default is null and will authenticate users to their default tenant.
        /// The value can also be set by setting the environment variable AZURE_TENANT_ID.
        /// </summary>
        public string VisualStudioCodeTenantId { get; set; } = GetNonEmptyStringOrNull(EnvironmentVariables.TenantId);

        /// <summary>
        /// Specifies the preferred authentication account to be retrieved from the shared token cache for single sign on authentication with
        /// development tools. In the case multiple accounts are found in the shared token.
        /// </summary>
        /// <remarks>
        /// If multiple accounts are found in the shared token cache and no value is specified, or the specified value matches no accounts in
        /// the cache the SharedTokenCacheCredential will not be used for authentication.
        /// </remarks>
        public string SharedTokenCacheUsername { get; set; } = GetNonEmptyStringOrNull(EnvironmentVariables.Username);

        /// <summary>
        /// Specifies the client id of the selected credential
        /// </summary>
        public string InteractiveBrowserCredentialClientId { get; set; }

        /// <summary>
        /// Specifies the client id of a user assigned ManagedIdentity. If this value is configured, then <see cref="ManagedIdentityResourceId"/> should not be configured.
        /// </summary>
        public string ManagedIdentityClientId { get; set; } = GetNonEmptyStringOrNull(EnvironmentVariables.ClientId);

        /// <summary>
        /// Specifies the resource id of a user assigned ManagedIdentity. If this value is configured, then <see cref="ManagedIdentityClientId"/> should not be configured.
        /// </summary>
        public ResourceIdentifier ManagedIdentityResourceId { get; set; }

        /// <summary>
        /// Specifies timeout for Developer credentials. e.g. Visual Studio, Azure CLI, Azure Powershell.
        /// </summary>
        public TimeSpan? DeveloperCredentialTimeout { get; set; } = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Specifies whether the <see cref="EnvironmentCredential"/> will be excluded from the authentication flow. Setting to true disables reading
        /// authentication details from the process' environment variables.
        /// </summary>
        public bool ExcludeEnvironmentCredential { get; set; }

        /// <summary>
        /// Specifies whether the <see cref="ManagedIdentityCredential"/> will be excluded from the <see cref="DefaultAzureCredential"/> authentication flow.
        /// Setting to true disables authenticating with managed identity endpoints.
        /// </summary>
        public bool ExcludeManagedIdentityCredential { get; set; }

        /// <summary>
        /// Specifies whether the <see cref="SharedTokenCacheCredential"/> will be excluded from the <see cref="DefaultAzureCredential"/> authentication flow.
        /// Setting to true disables single sign on authentication with development tools which write to the shared token cache.
        /// The default is <c>true</c>.
        /// </summary>
        public bool ExcludeSharedTokenCacheCredential { get; set; } = true;

        /// <summary>
        /// Specifies whether the <see cref="InteractiveBrowserCredential"/> will be excluded from the <see cref="DefaultAzureCredential"/> authentication flow.
        /// Setting to true disables launching the default system browser to authenticate in development environments.
        /// The default is <c>true</c>.
        /// </summary>
        public bool ExcludeInteractiveBrowserCredential { get; set; } = true;

        /// <summary>
        /// Specifies whether the <see cref="AzureCliCredential"/> will be excluded from the <see cref="DefaultAzureCredential"/> authentication flow.
        /// </summary>
        public bool ExcludeAzureCliCredential { get; set; }

        /// <summary>
        /// Specifies whether the <see cref="VisualStudioCredential"/> will be excluded from the <see cref="DefaultAzureCredential"/> authentication flow.
        /// </summary>
        public bool ExcludeVisualStudioCredential { get; set; }

        /// <summary>
        /// Specifies whether the <see cref="VisualStudioCodeCredential"/> will be excluded from the <see cref="DefaultAzureCredential"/> authentication flow.
        /// </summary>
        public bool ExcludeVisualStudioCodeCredential { get; set; }

        private static string GetNonEmptyStringOrNull(string str)
        {
            return !string.IsNullOrEmpty(str) ? str : null;
        }

        /// <summary>
        /// Specifies whether the <see cref="AzurePowerShellCredential"/> will be excluded from the <see cref="DefaultAzureCredential"/> authentication flow.
        /// </summary>
        public bool ExcludeAzurePowerShellCredential { get; set; }
    }
}
