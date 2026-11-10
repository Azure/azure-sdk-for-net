// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Identity
{
    /// <summary>
    /// Options used to configure the <see cref="GitHubActionsTokenCredential"/>.
    /// </summary>
#pragma warning disable AZC0034 // Type moved from Azure.Identity to Azure.Core; name conflict with NuGet Azure.Identity is expected
    public class GitHubActionsTokenCredentialOptions : TokenCredentialOptions
    {
        /// <summary>
        /// The client ID (app ID) of the service principal the credential will authenticate. This value defaults to the value of the environment variable AZURE_CLIENT_ID.
        /// </summary>
        internal string ClientId { get; set; } = EnvironmentVariables.ClientId;

        /// <summary>
        /// The ID of the tenant to which the credential will authenticate by default. This value defaults to the value of the environment variable AZURE_TENANT_ID.
        /// </summary>
        internal string TenantId { get; set; } = EnvironmentVariables.TenantId;

        internal const string ActionsRequestTokenKey = "ACTIONS_ID_TOKEN_REQUEST_TOKEN";
        /// <summary>
        /// The token used to request an ID token from the GitHub Actions OIDC provider. This value defaults to the value of the environment variable ACTIONS_ID_TOKEN_REQUEST_TOKEN.
        /// </summary>
        internal string RequestToken { get; set; } = EnvironmentVariables.GitHubActionsRequestToken;

        internal const string ActionsRequestUrlKey = "ACTIONS_ID_TOKEN_REQUEST_URL";
        /// <summary>
        /// The URL used to request an ID token from the GitHub Actions OIDC provider. This value defaults to the value of the environment variable ACTIONS_ID_TOKEN_REQUEST_URL.
        /// </summary>
        internal string RequestUrl { get; set; } = EnvironmentVariables.GitHubActionsRequestUrl;

        /// <summary>
        /// The default audience to use when requesting an ID token from the GitHub Actions OIDC provider.
        /// </summary>
        public const string DefaultIdTokenAudience = "api://AzureADTokenExchange";

        /// <summary>
        /// The audience to use when requesting an ID token from the GitHub Actions OIDC provider. This value defaults to "api://AzureADTokenExchange".
        /// </summary>
        public string IdTokenAudience { get; set; } = DefaultIdTokenAudience;

        /// <summary>
        /// The User-Agent to use when requesting an ID token from the GitHub Actions OIDC provider. This value defaults to "actions/oidc-client (1.0)".
        /// </summary>
        public string IdTokenUserAgent { get; set; } = "actions/oidc-client (1.0)";
    }
#pragma warning restore AZC0034
}
