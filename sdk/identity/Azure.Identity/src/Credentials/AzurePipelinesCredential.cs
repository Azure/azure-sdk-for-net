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
    /// Credential which authenticates using an Azure Pipelines service connection. For usage instructions, see
    /// <see href="https://aka.ms/azsdk/net/identity/azurepipelinescredential/usage">Authenticating in Azure
    /// Pipelines with service connections</see>.
    /// </summary>
    public class AzurePipelinesCredential : TokenCredential
    {
        internal const string Troubleshooting = "See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/azurepipelinescredential/troubleshoot";
        internal readonly string[] AdditionallyAllowedTenantIds;
        internal string SystemAccessToken { get; }
        internal string TenantId { get; }
        internal string ServiceConnectionId { get; }
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
        /// <param name="tenantId">The tenant ID for the service connection.</param>
        /// <param name="clientId">The client ID for the service connection.</param>
        /// <param name="serviceConnectionId">The service connection Id for the service connection associated with the pipeline.</param>
        /// <param name="systemAccessToken">The pipeline's <see href="https://learn.microsoft.com/azure/devops/pipelines/build/variables?view=azure-devops%26tabs=yaml#systemaccesstoken">System.AccessToken</see> value.</param>
        /// <param name="options">An instance of <see cref="AzurePipelinesCredentialOptions"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="tenantId"/>, <paramref name="clientId"/>, <paramref name="serviceConnectionId"/>, or <paramref name="systemAccessToken"/> is null.</exception>
        public AzurePipelinesCredential(string tenantId, string clientId, string serviceConnectionId, string systemAccessToken, AzurePipelinesCredentialOptions options = default)
        {
            Argument.AssertNotNull(systemAccessToken, nameof(systemAccessToken));
            Argument.AssertNotNull(clientId, nameof(clientId));
            Argument.AssertNotNull(tenantId, nameof(tenantId));
            Argument.AssertNotNull(serviceConnectionId, nameof(serviceConnectionId));

            SystemAccessToken = systemAccessToken;
            ServiceConnectionId = serviceConnectionId;

            options ??= new AzurePipelinesCredentialOptions();
            TenantId = Validations.ValidateTenantId(tenantId, nameof(tenantId));
            Pipeline = options.Pipeline ?? CredentialPipeline.GetInstance(options);

            Func<CancellationToken, Task<string>> _assertionCallback = async (cancellationToken) =>
            {
                var message = CreateOidcRequestMessage(options ?? new AzurePipelinesCredentialOptions());
                await Pipeline.HttpPipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                return GetOidcTokenResponse(message);
            };

            Client = options?.MsalClient ?? new MsalConfidentialClient(Pipeline, TenantId, clientId, _assertionCallback, options);
            TenantIdResolver = options?.TenantIdResolver ?? TenantIdResolverBase.Default;
            AdditionallyAllowedTenantIds = TenantIdResolver.ResolveAddionallyAllowedTenantIds((options as ISupportsAdditionallyAllowedTenants)?.AdditionallyAllowedTenants);
        }

        /// <summary>
        /// Obtains an access token from within an Azure Pipelines environment.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => GetTokenCoreAsync(false, requestContext, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Obtains an access token from within an Azure Pipelines environment.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => await GetTokenCoreAsync(true, requestContext, cancellationToken).ConfigureAwait(false);

        internal async ValueTask<AccessToken> GetTokenCoreAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = Pipeline.StartGetTokenScope("AzurePipelinesCredential.GetToken", requestContext);

            try
            {
                var tenantId = TenantIdResolver.Resolve(TenantId, requestContext, AdditionallyAllowedTenantIds);

                AuthenticationResult result = await Client.AcquireTokenForClientAsync(requestContext.Scopes, tenantId, requestContext.Claims, requestContext.IsCaeEnabled, async, cancellationToken).ConfigureAwait(false);

                return scope.Succeeded(result.ToAccessToken());
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e, Troubleshooting);
            }
        }

        internal HttpMessage CreateOidcRequestMessage(AzurePipelinesCredentialOptions options)
        {
            string oidcRequestUri = options.OidcRequestUri ?? throw new CredentialUnavailableException("AzurePipelinesCredential is not available: Ensure that you're running this task in an Azure Pipeline so that following missing system variable(s) can be defined: SYSTEM_OIDCREQUESTURI is not set.");
            string systemToken = SystemAccessToken;

            var message = Pipeline.HttpPipeline.CreateMessage();

            var requestUri = new Uri($"{oidcRequestUri}?api-version={OIDC_API_VERSION}&serviceConnectionId={ServiceConnectionId}");
            message.Request.Uri.Reset(requestUri);
            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, $"Bearer {systemToken}");
            message.Request.Headers.SetValue(HttpHeader.Names.ContentType, "application/json");
            // Prevents the service from responding with a redirect HTTP status code (useful for automation).
            message.Request.Headers.SetValue("X-TFS-FedAuthRedirect", "Suppress");
            message.Request.Method = RequestMethod.Post;
            return message;
        }

        internal string GetOidcTokenResponse(HttpMessage message)
        {
            string oidcToken = null;
            try
            {
                Utf8JsonReader reader = new Utf8JsonReader(message.Response.Content);
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
            }
            catch
            {
                //Just don't want to throw here, we will throw in the next if block
            }
            if (oidcToken is null)
            {
                string error = $"OIDC token not found in response. " + Troubleshooting;
                if (message.Response.Status != 200)
                {
                    var is_x_vss_e2eidValueFound = message.Response.Headers.TryGetValue("x-vss-e2eid", out var x_vss_e2eidValue);
                    var is_x_msedge_refValueFound = message.Response.Headers.TryGetValue("x-msedge-ref", out var x_msedge_refValue);

                    error = error + $"\n\nResponse= {message.Response.Content}\n\nx-vss-e2eid= {(is_x_vss_e2eidValueFound ? x_vss_e2eidValue : "Not Found")}\n\nx-msedge-ref= {(is_x_msedge_refValueFound ? x_msedge_refValue : "Not Found")}";
                }
                throw new AuthenticationFailedException(error);
            }
            return oidcToken;
        }
    }
}
