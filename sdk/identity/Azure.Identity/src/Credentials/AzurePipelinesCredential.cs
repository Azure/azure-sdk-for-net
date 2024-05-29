// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Credential which authenticates using an Azure Pipelines service connection.
    /// </summary>
    public class AzurePipelinesCredential : TokenCredential
    {
        internal readonly string[] AdditionallyAllowedTenantIds;
        internal string SystemAccessToken { get; }
        internal string TenantId { get; }
        internal MsalConfidentialClient Client { get; }
        internal CredentialPipeline Pipeline { get; }
        internal TenantIdResolverBase TenantIdResolver { get; }
        private const string OIDC_API_VERSION = "7.1";

        /// <summary>
        /// Protected constructor for <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        protected AzurePipelinesCredential()
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="AzurePipelinesCredential"/>.
        /// </summary>
        /// <param name="systemAccessToken">The pipeline's System.AccessToken value.</param>
        /// <param name="clientId">The client ID for the service connection. If not provided, the credential will attempt to read the value from the AZURESUBSCRIPTION_CLIENT_ID environment variable.</param>
        /// <param name="tenantId">The tenant ID for the service connection. If not provided, the credential will attempt to read the value from the AZURESUBSCRIPTION_TENANT_ID environment variable.</param>
        /// <param name="options">An instance of <see cref="AzurePipelinesCredentialOptions"/>.</param>
        /// <exception cref="System.ArgumentNullException">When <paramref name="systemAccessToken"/> is null.</exception>
        public AzurePipelinesCredential(string systemAccessToken, string clientId = null, string tenantId = null, AzurePipelinesCredentialOptions options = default)
        {
            Argument.AssertNotNull(systemAccessToken, nameof(systemAccessToken));
            SystemAccessToken = systemAccessToken;

            options ??= new AzurePipelinesCredentialOptions();
            TenantId = Validations.ValidateTenantId(tenantId ?? options.TenantId, nameof(tenantId));
            // var clientId = options.ClientId;
            Pipeline = options.Pipeline ?? CredentialPipeline.GetInstance(options);

            Func<CancellationToken, Task<string>> _assertionCallback = async (cancellationToken) =>
            {
                var message = CreateOidcRequestMessage(options ?? new AzurePipelinesCredentialOptions());
                await Pipeline.HttpPipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                return GetOidcTokenResponse(message);
            };

            Client = options?.MsalClient ?? new MsalConfidentialClient(Pipeline, TenantId, clientId ?? options.ClientId, _assertionCallback, options);
            TenantIdResolver = options?.TenantIdResolver ?? TenantIdResolverBase.Default;
            AdditionallyAllowedTenantIds = TenantIdResolver.ResolveAddionallyAllowedTenantIds((options as ISupportsAdditionallyAllowedTenants)?.AdditionallyAllowedTenants);
        }

        /// <inheritdoc />
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => GetTokenCoreAsync(false, requestContext, cancellationToken).EnsureCompleted();

        /// <inheritdoc />
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => await GetTokenCoreAsync(true, requestContext, cancellationToken).ConfigureAwait(false);

        internal async ValueTask<AccessToken> GetTokenCoreAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = Pipeline.StartGetTokenScope("AzurePipelinesCredential.GetToken", requestContext);

            try
            {
                var tenantId = TenantIdResolver.Resolve(TenantId, requestContext, AdditionallyAllowedTenantIds);

                AuthenticationResult result = await Client.AcquireTokenForClientAsync(requestContext.Scopes, tenantId, requestContext.Claims, requestContext.IsCaeEnabled, async, cancellationToken).ConfigureAwait(false);

                return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        internal HttpMessage CreateOidcRequestMessage(AzurePipelinesCredentialOptions options)
        {
            string serviceConnectionId = options.ServiceConnectionId ?? throw new CredentialUnavailableException("AzurePipelinesCredential is not available: environment variable AZURESUBSCRIPTION_SERVICE_CONNECTION_ID is not set.");
            string oidcRequestUri = options.OidcRequestUri ?? throw new CredentialUnavailableException("AzurePipelinesCredential is not available: environment variable SYSTEM_OIDCREQUESTURI is not set.");
            string systemToken = SystemAccessToken;

            var message = Pipeline.HttpPipeline.CreateMessage();

            var requestUri = new Uri($"{oidcRequestUri}?api-version={OIDC_API_VERSION}&serviceConnectionId={serviceConnectionId}");
            message.Request.Uri.Reset(requestUri);
            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, $"Bearer {systemToken}");
            message.Request.Headers.SetValue(HttpHeader.Names.ContentType, "application/json");
            message.Request.Method = RequestMethod.Post;
            return message;
        }

        internal string GetOidcTokenResponse(HttpMessage message)
        {
            Utf8JsonReader reader = new Utf8JsonReader(message.Response.Content);
            string oidcToken = null;
            while (oidcToken is null && reader.Read())
            {
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    switch (reader.GetString())
                    {
                        case "oidcToken":
                            reader.Read();
                            oidcToken = reader.GetString();
                            break;
                    }
                }
            }
            return oidcToken ?? throw new AuthenticationFailedException($"OIDC token not found in response.\n\nResponse= {message.Response.Content}");
        }
    }
}
