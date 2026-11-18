// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Microsoft Entra ID from a GitHub Actions workflow using the GitHub OIDC provider and a
    /// federated identity credential. The credential requests an ID token from GitHub and exchanges it for a Microsoft Entra
    /// access token using the client assertion flow.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The credential is configured entirely from environment variables. The GitHub Actions runner sets
    /// <c>ACTIONS_ID_TOKEN_REQUEST_URL</c> and <c>ACTIONS_ID_TOKEN_REQUEST_TOKEN</c> when the workflow or job has the
    /// <c>id-token: write</c> permission. The workflow must also set <c>AZURE_TENANT_ID</c> and <c>AZURE_CLIENT_ID</c> to identify
    /// the Microsoft Entra application whose federated identity credential trusts the workflow.
    /// </para>
    /// <para>
    /// The audience of the GitHub ID token is derived from <see cref="TokenCredentialOptions.AuthorityHost"/>. The Azure Public,
    /// Azure China, Azure US Government, France, Germany, and Singapore government clouds are supported.
    /// </para>
    /// </remarks>
#pragma warning disable AZC0034 // Type moved from Azure.Identity to Azure.Core; name conflict with NuGet Azure.Identity is expected
    [UnsupportedOSPlatform("browser")]
    public class GitHubActionsCredential : TokenCredential
    {
        internal const string CredentialName = nameof(GitHubActionsCredential);
        internal const string Troubleshooting = "See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/githubactionscredential/troubleshoot";
        internal const string RequestTokenEnvironmentVariable = "ACTIONS_ID_TOKEN_REQUEST_TOKEN";
        internal const string RequestUrlEnvironmentVariable = "ACTIONS_ID_TOKEN_REQUEST_URL";

        private static readonly Dictionary<string, string> s_audienceByAuthorityHost = new(StringComparer.OrdinalIgnoreCase)
        {
            ["login.microsoftonline.com"] = "api://AzureADTokenExchange",
            ["login.chinacloudapi.cn"] = "api://AzureADTokenExchangeChina",
            ["login.microsoftonline.us"] = "api://AzureADTokenExchangeUSGov",
            ["login.sovcloud-identity.fr"] = "api://AzureADTokenExchangeFrance",
            ["login.sovcloud-identity.de"] = "api://AzureADTokenExchangeGermany",
            ["login.sovcloud-identity.sg"] = "api://AzureADTokenExchangeGovSG",
        };

        private readonly string _requestToken;
        private readonly string _unavailableMessage;

        internal string TenantId { get; }
        internal string ClientId { get; }
        internal Uri IdTokenRequestUri { get; }
        internal string[] AdditionallyAllowedTenantIds { get; }
        internal MsalConfidentialClient Client { get; }
        internal CredentialPipeline Pipeline { get; }
        internal TenantIdResolverBase TenantIdResolver { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="GitHubActionsCredential"/> with the default options.
        /// The tenant and client IDs are read from the <c>AZURE_TENANT_ID</c> and <c>AZURE_CLIENT_ID</c> environment variables,
        /// and the GitHub OIDC endpoint is read from the <c>ACTIONS_ID_TOKEN_REQUEST_URL</c> and <c>ACTIONS_ID_TOKEN_REQUEST_TOKEN</c>
        /// environment variables set by the GitHub Actions runner.
        /// </summary>
        public GitHubActionsCredential() : this(default)
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="GitHubActionsCredential"/> with the specified options.
        /// The tenant and client IDs are read from the <c>AZURE_TENANT_ID</c> and <c>AZURE_CLIENT_ID</c> environment variables,
        /// and the GitHub OIDC endpoint is read from the <c>ACTIONS_ID_TOKEN_REQUEST_URL</c> and <c>ACTIONS_ID_TOKEN_REQUEST_TOKEN</c>
        /// environment variables set by the GitHub Actions runner.
        /// </summary>
        /// <param name="options">Options that allow to configure the management of the requests sent to Microsoft Entra ID.</param>
        public GitHubActionsCredential(GitHubActionsCredentialOptions options)
        {
            options ??= new GitHubActionsCredentialOptions();

            Pipeline = options.Pipeline ?? CredentialPipeline.GetInstance(options);
            TenantIdResolver = options.TenantIdResolver ?? TenantIdResolverBase.Default;

            _unavailableMessage = GetUnavailableMessage(options, out Uri idTokenRequestUri);
            if (_unavailableMessage != null)
            {
                return;
            }

            _requestToken = options.RequestToken;
            IdTokenRequestUri = idTokenRequestUri;
            TenantId = Validations.ValidateTenantId(options.TenantId, "AZURE_TENANT_ID");
            ClientId = options.ClientId;
            Client = options.MsalClient ?? new MsalConfidentialClient(Pipeline, TenantId, ClientId, GetIdTokenAsync, options);
            AdditionallyAllowedTenantIds = TenantIdResolver.ResolveAddionallyAllowedTenantIds(options.AdditionallyAllowedTenants);
        }

        /// <summary>
        /// Obtains an access token from within a GitHub Actions workflow.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        /// <exception cref="CredentialUnavailableException">Thrown when the credential isn't running in a properly configured GitHub Actions workflow.</exception>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
            => GetTokenCoreAsync(false, requestContext, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Obtains an access token from within a GitHub Actions workflow.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        /// <exception cref="CredentialUnavailableException">Thrown when the credential isn't running in a properly configured GitHub Actions workflow.</exception>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
            => await GetTokenCoreAsync(true, requestContext, cancellationToken).ConfigureAwait(false);

        private async ValueTask<AccessToken> GetTokenCoreAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = Pipeline.StartGetTokenScope($"{CredentialName}.GetToken", requestContext);

            try
            {
                if (_unavailableMessage != null)
                {
                    throw new CredentialUnavailableException(_unavailableMessage);
                }

                string tenantId = TenantIdResolver.Resolve(TenantId, requestContext, AdditionallyAllowedTenantIds);

                AuthenticationResult result = await Client.AcquireTokenForClientAsync(requestContext.Scopes, tenantId, requestContext.Claims, requestContext.IsCaeEnabled, async, cancellationToken).ConfigureAwait(false);

                return scope.Succeeded(result.ToAccessToken());
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e, Troubleshooting);
            }
        }

        internal async Task<string> GetIdTokenAsync(CancellationToken cancellationToken)
        {
            using HttpMessage message = CreateIdTokenRequestMessage();
            await Pipeline.HttpPipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            return ParseIdTokenResponse(message.Response);
        }

        internal HttpMessage CreateIdTokenRequestMessage()
        {
            HttpMessage message = Pipeline.HttpPipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(IdTokenRequestUri);
            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, $"Bearer {_requestToken}");
            message.Request.Headers.SetValue(HttpHeader.Names.Accept, "application/json");
            return message;
        }

        internal static string ParseIdTokenResponse(Response response)
        {
            if (response.Status != 200)
            {
                throw new AuthenticationFailedException($"{CredentialName} authentication failed. The GitHub OIDC token request returned status code {response.Status}. Response: {response.Content}. {Troubleshooting}");
            }

            try
            {
                using JsonDocument document = JsonDocument.Parse(response.Content.ToMemory());
                if (document.RootElement.ValueKind == JsonValueKind.Object &&
                    document.RootElement.TryGetProperty("value", out JsonElement value) &&
                    value.ValueKind == JsonValueKind.String)
                {
                    string idToken = value.GetString();
                    if (!string.IsNullOrEmpty(idToken))
                    {
                        return idToken;
                    }
                }
            }
            catch (JsonException)
            {
                // Handled below so that the response body, which may contain sensitive data, isn't included in the exception.
            }

            throw new AuthenticationFailedException($"{CredentialName} authentication failed. The GitHub OIDC token response didn't contain a valid \"value\" field. {Troubleshooting}");
        }

        internal static string GetAudience(Uri authorityHost)
        {
            return authorityHost != null && s_audienceByAuthorityHost.TryGetValue(authorityHost.Host, out string audience) ? audience : null;
        }

        private static string GetUnavailableMessage(GitHubActionsCredentialOptions options, out Uri idTokenRequestUri)
        {
            idTokenRequestUri = null;

            List<string> missingGitHubVariables = new();
            if (string.IsNullOrWhiteSpace(options.RequestUrl))
            {
                missingGitHubVariables.Add(RequestUrlEnvironmentVariable);
            }
            if (string.IsNullOrWhiteSpace(options.RequestToken))
            {
                missingGitHubVariables.Add(RequestTokenEnvironmentVariable);
            }
            if (missingGitHubVariables.Count > 0)
            {
                return $"{CredentialName} authentication unavailable. Ensure that you're running in a GitHub Actions workflow with 'permissions: id-token: write' so that the following environment variable(s) are set: {string.Join(", ", missingGitHubVariables)}. {Troubleshooting}";
            }

            List<string> missingAzureVariables = new();
            if (string.IsNullOrWhiteSpace(options.TenantId))
            {
                missingAzureVariables.Add("AZURE_TENANT_ID");
            }
            if (string.IsNullOrWhiteSpace(options.ClientId))
            {
                missingAzureVariables.Add("AZURE_CLIENT_ID");
            }
            if (missingAzureVariables.Count > 0)
            {
                return $"{CredentialName} authentication unavailable. Set the following environment variable(s) to identify the Microsoft Entra application: {string.Join(", ", missingAzureVariables)}. {Troubleshooting}";
            }

            if (!Uri.TryCreate(options.RequestUrl, UriKind.Absolute, out Uri requestUrl) || requestUrl.Scheme != Uri.UriSchemeHttps)
            {
                return $"{CredentialName} authentication unavailable. The environment variable {RequestUrlEnvironmentVariable} must be an absolute HTTPS URL. {Troubleshooting}";
            }

            Uri authorityHost = options.AuthorityHost;
            string audience = GetAudience(authorityHost);
            if (audience == null)
            {
                return $"{CredentialName} authentication unavailable. The authority host '{authorityHost}' isn't supported. {Troubleshooting}";
            }

            idTokenRequestUri = BuildRequestUri(requestUrl, audience);
            return null;
        }

        private static Uri BuildRequestUri(Uri requestUrl, string audience)
        {
            var builder = new UriBuilder(requestUrl);
            string audienceQuery = $"audience={Uri.EscapeDataString(audience)}";
            string query = builder.Query;
            builder.Query = string.IsNullOrEmpty(query) || query == "?"
                ? audienceQuery
                : $"{query.TrimStart('?')}&{audienceQuery}";
            return builder.Uri;
        }
    }
#pragma warning restore AZC0034
}
