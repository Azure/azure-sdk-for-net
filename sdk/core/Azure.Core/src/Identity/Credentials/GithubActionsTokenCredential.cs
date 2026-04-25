// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// Enabled authentication in GitHub Actions using the GitHub OIDC provider.
    /// </summary>
    [System.Runtime.Versioning.UnsupportedOSPlatform("browser")]
    public class GithubActionsTokenCredential : TokenCredential
    {
        private readonly CredentialPipeline _pipeline;
        private readonly GithubActionsTokenCredentialOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="GithubActionsTokenCredential"/> class with default options.
        /// For the credential to work, the environment variables 'ACTIONS_ID_TOKEN_REQUEST_TOKEN' and 'ACTIONS_ID_TOKEN_REQUEST_URL' must be set by the GitHub Actions runtime.
        /// You need to set the 'AZURE_TENANT_ID' and 'AZURE_CLIENT_ID' environment variables to specify the tenant and client ID to use when authenticating with Entra ID.
        /// The credential will request an ID token from the GitHub OIDC provider using the request token and request URL provided in the environment variables, and then exchange that ID token for an access token from Entra ID using the client assertion flow.
        /// </summary>
        public GithubActionsTokenCredential() : this(null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GithubActionsTokenCredential"/>.
        /// For the credential to work, the environment variables 'ACTIONS_ID_TOKEN_REQUEST_TOKEN' and 'ACTIONS_ID_TOKEN_REQUEST_URL' must be set by the GitHub Actions runtime.
        /// You need to set the 'AZURE_TENANT_ID' and 'AZURE_CLIENT_ID' environment variables to specify the tenant and client ID to use when authenticating with Entra ID.
        /// The credential will request an ID token from the GitHub OIDC provider using the request token and request URL provided in the environment variables, and then exchange that ID token for an access token from Entra ID using the client assertion flow.
        /// </summary>
        /// <param name="options">The options for configuring the credential.</param>
        public GithubActionsTokenCredential(GithubActionsTokenCredentialOptions options) : this(null, options)
        {
        }

        internal GithubActionsTokenCredential(CredentialPipeline pipeline, TokenCredentialOptions options = null)
        {
            _options = options as GithubActionsTokenCredentialOptions ?? new GithubActionsTokenCredentialOptions();
            _pipeline = pipeline ?? CredentialPipeline.GetInstance(_options);
        }

        /// <inheritdoc/>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            ValidateSettings();

            var clientAssertionCredential = new ClientAssertionCredential(_options.TenantId, _options.ClientId, (cancallationToken) => GetIdToken(cancellationToken));

            return clientAssertionCredential.GetToken(requestContext, cancellationToken);
        }

        /// <inheritdoc/>
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            ValidateSettings();
            var clientAssertionCredential = new ClientAssertionCredential(_options.TenantId, _options.ClientId, (cancallationToken) => GetIdToken(cancellationToken));
            return clientAssertionCredential.GetTokenAsync(requestContext, cancellationToken);
        }

        private void ValidateSettings()
        {
            if (string.IsNullOrWhiteSpace(_options.RequestToken) || string.IsNullOrWhiteSpace(_options.RequestUrl) || !Uri.TryCreate(_options.RequestUrl, UriKind.Absolute, out _))
            {
                throw new CredentialUnavailableException($"Environment variables '{GithubActionsTokenCredentialOptions.ActionsRequestTokenKey}' and/or '{GithubActionsTokenCredentialOptions.ActionsRequestUrlKey}' are not set.");
            }

            if (string.IsNullOrWhiteSpace(_options.IdTokenAudience))
            {
                throw new ArgumentException("Audience must be set.", nameof(_options.IdTokenAudience));
            }

            if (string.IsNullOrWhiteSpace(_options.TenantId))
            {
                throw new ArgumentException("Tenant ID must be set", nameof(_options.TenantId));
            }

            if (string.IsNullOrWhiteSpace(_options.ClientId))
            {
                throw new ArgumentException("Client ID must be set", nameof(_options.ClientId));
            }
        }

        private async Task<string> GetIdToken(CancellationToken cancellationToken)
        {
            var request = _pipeline.HttpPipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{_options.RequestUrl!}&audience={System.Web.HttpUtility.UrlEncode(_options.IdTokenAudience!)}"));
            request.Headers.Add("Authorization", $"Bearer {_options.RequestToken!}");
            var response = await _pipeline.HttpPipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
            if (response.Status != 200)
            {
                throw new CredentialUnavailableException($"Request to '{request.Uri}' failed with status code '{response.Status}'.");
            }
            return GetOidcTokenResponse(response);
        }

        private string GetOidcTokenResponse(Response response)
        {
            string oidcToken = null;
            try
            {
                Utf8JsonReader reader = new Utf8JsonReader(response.Content);
                while (oidcToken is null && reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.PropertyName)
                    {
                        switch (reader.GetString())
                        {
                            case "value":
                                reader.Read();
                                oidcToken = reader.GetString();
                                break;
                        }
                    }
                }
            }
            catch
            {
                //Just don't want to throw here, we will throw in the next if block
            }
            if (oidcToken is null)
            {
                string error = $"OIDC token not found in response.";
                throw new AuthenticationFailedException(error);
            }
            return oidcToken;
        }
    }
}
