// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    internal abstract class MsalClientBase<TClient>
        where TClient : IClientApplicationBase
    {
        private readonly AsyncLockWithValue<TClient> _clientAsyncLock;
        private bool _logAccountDetails;

        protected internal bool IsPiiLoggingEnabled { get; }
        protected internal bool DisableInstanceDiscovery { get; }

        /// <summary>
        /// For mocking purposes only.
        /// </summary>
        protected MsalClientBase()
        {
        }

        protected MsalClientBase(CredentialPipeline pipeline, string tenantId, string clientId, TokenCredentialOptions options)
        {
            // This validation is performed as a backstop. Validation in TokenCredentialOptions.AuthorityHost prevents users from explicitly
            // setting AuthorityHost to a non TLS endpoint. However, the AuthorityHost can also be set by the AZURE_AUTHORITY_HOST environment
            // variable rather than in code. In this case we need to validate the endpoint before we use it. However, we can't validate in
            // CredentialPipeline as this is also used by the ManagedIdentityCredential which allows non TLS endpoints. For this reason
            // we validate here as all other credentials will create an MSAL client.
            Validations.ValidateAuthorityHost(options?.AuthorityHost);
            AuthorityHost = options?.AuthorityHost ?? AzureAuthorityHosts.GetDefault();
            _logAccountDetails = options?.Diagnostics?.IsAccountIdentifierLoggingEnabled ?? false;
            DisableInstanceDiscovery = options is ISupportsDisableInstanceDiscovery supportsDisableInstanceDiscovery && supportsDisableInstanceDiscovery.DisableInstanceDiscovery;
            ISupportsTokenCachePersistenceOptions cacheOptions = options as ISupportsTokenCachePersistenceOptions;
            IsPiiLoggingEnabled = options?.IsLoggingPIIEnabled ?? false;
            Pipeline = pipeline;
            TenantId = tenantId;
            ClientId = clientId;
            TokenCache = cacheOptions?.TokenCachePersistenceOptions == null ? null : new TokenCache(cacheOptions?.TokenCachePersistenceOptions);
            _clientAsyncLock = new AsyncLockWithValue<TClient>();
        }

        internal string TenantId { get; }

        internal string ClientId { get; }

        internal TokenCache TokenCache { get; }

        internal Uri AuthorityHost { get; }

        protected internal CredentialPipeline Pipeline { get; }

        protected abstract ValueTask<TClient> CreateClientAsync(bool async, CancellationToken cancellationToken);

        protected async ValueTask<TClient> GetClientAsync(bool async, CancellationToken cancellationToken)
        {
            using var asyncLock = await _clientAsyncLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);
            if (asyncLock.HasValue)
            {
                return asyncLock.Value;
            }

            var client = await CreateClientAsync(async, cancellationToken).ConfigureAwait(false);

            if (TokenCache != null)
            {
                await TokenCache.RegisterCache(async, client.UserTokenCache, cancellationToken).ConfigureAwait(false);

                if (client is IConfidentialClientApplication cca)
                {
                    await TokenCache.RegisterCache(async, cca.AppTokenCache, cancellationToken).ConfigureAwait(false);
                }
            }

            asyncLock.SetValue(client);
            return client;
        }

        protected void LogMsal(LogLevel level, string message, bool isPii)
        {
            if (!isPii || IsPiiLoggingEnabled)
            {
                AzureIdentityEventSource.Singleton.LogMsal(level, message);
            }
        }

        protected void LogAccountDetails(AuthenticationResult result)
        {
            if (_logAccountDetails)
            {
                var accountDetails = TokenHelper.ParseAccountInfoFromToken(result.AccessToken);
                AzureIdentityEventSource.Singleton.AuthenticatedAccountDetails(accountDetails.ClientId, accountDetails.TenantId ?? result.TenantId, accountDetails.Upn ?? result.Account?.Username, accountDetails.ObjectId ?? result.UniqueId);
            }
        }
    }
}
