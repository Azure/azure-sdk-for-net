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
        internal string TenantId { get; }
        internal string ClientId { get; }
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
        /// <param name="serviceConnectionId">The service connection ID, as found in the querystring's resourceId key.</param>
        /// <param name="options">An instance of <see cref="AzurePipelinesCredentialOptions"/>.</param>
        /// <exception cref="System.ArgumentNullException">When <paramref name="tenantId"/>, <paramref name="clientId"/>, or <paramref name="serviceConnectionId"/> is null.</exception>
        public AzurePipelinesCredential(string tenantId, string clientId, string serviceConnectionId, AzurePipelinesCredentialOptions options = default)
        {
            Argument.AssertNotNull(serviceConnectionId, nameof(serviceConnectionId));
            Argument.AssertNotNull(clientId, nameof(clientId));
            Argument.AssertNotNull(tenantId, nameof(tenantId));

            TenantId = Validations.ValidateTenantId(tenantId, nameof(tenantId));
            ClientId = clientId;
            Pipeline = options?.Pipeline ?? CredentialPipeline.GetInstance(options);

            Func<CancellationToken, Task<string>> _assertionCallback = async (cancellationToken) =>
            {
                var message = CreateOidcRequestMessage(serviceConnectionId, options ?? new AzurePipelinesCredentialOptions());
                await Pipeline.HttpPipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                return GetOidcTokenResponse(message);
            };

            Client = options?.MsalClient ?? new MsalConfidentialClient(Pipeline, tenantId, clientId, _assertionCallback, options);
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

                return scope.Succeeded(result.ToAccessToken());
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        internal HttpMessage CreateOidcRequestMessage(string serviceConnectionId, AzurePipelinesCredentialOptions options)
        {
            string CollectionUri = options.CollectionUri ?? throw new CredentialUnavailableException("AzurePipelinesCredential is not available: environment variable SYSTEM_TEAMFOUNDATIONCOLLECTIONURI is not set.");
            string projectId = options.TeamProjectId ?? throw new CredentialUnavailableException("AzurePipelinesCredential is not available: environment variable SYSTEM_TEAMPROJECTID is not set.");
            string planId = options.PlanId ?? throw new CredentialUnavailableException("AzurePipelinesCredential is not available: environment variable SYSTEM_PLANID is not set.");
            string jobId = options.JobId ?? throw new CredentialUnavailableException("AzurePipelinesCredential is not available: environment variable SYSTEM_JOBID is not set.");
            string systemToken = options.SystemAccessToken ?? throw new CredentialUnavailableException("AzurePipelinesCredential is not available: environment variable SYSTEM_ACCESSTOKEN is not set.");
            string hubName = options.HubName ?? throw new CredentialUnavailableException("AzurePipelineCredential is not available: environment variable SYSTEM_HOSTTYPE is not set.");

            var message = Pipeline.HttpPipeline.CreateMessage();

            var requestUri = new Uri($"{CollectionUri}{projectId}/_apis/distributedtask/hubs/{hubName}/plans/{planId}/jobs/{jobId}/oidctoken?api-version={OIDC_API_VERSION}&serviceConnectionId={serviceConnectionId}");
            message.Request.Uri.Reset(requestUri);
            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, $"Bearer {systemToken}");
            message.Request.Headers.SetValue(HttpHeader.Names.ContentType, "application/json");
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
            return oidcToken ?? throw new AuthenticationFailedException("OIDC token not found in response.");
        }
    }
}
