// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    internal abstract class MsalClientBase<TClient>
        where TClient : IClientApplicationBase
    {
        private readonly AsyncLockWithValue<(TClient Client, TokenCache Cache)> _clientAsyncLock;
        private readonly AsyncLockWithValue<(TClient Client, TokenCache Cache)> _clientWithCaeAsyncLock;
        private readonly bool _logAccountDetails;
        private readonly TokenCachePersistenceOptions _tokenCachePersistenceOptions;
        protected internal bool IsSupportLoggingEnabled { get; }
        protected internal bool DisableInstanceDiscovery { get; }
        protected string[] cp1Capabilities = new[] { "CP1" };
        protected internal CredentialPipeline Pipeline { get; }
        internal string TenantId { get; }
        internal string ClientId { get; }
        internal Uri AuthorityHost { get; }

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
            _tokenCachePersistenceOptions = cacheOptions?.TokenCachePersistenceOptions;
            IsSupportLoggingEnabled = options?.IsUnsafeSupportLoggingEnabled ?? false;
            Pipeline = pipeline;
            TenantId = tenantId;
            ClientId = clientId;
            _clientAsyncLock = new AsyncLockWithValue<(TClient Client, TokenCache Cache)>();
            _clientWithCaeAsyncLock = new AsyncLockWithValue<(TClient Client, TokenCache Cache)>();
        }

        protected abstract ValueTask<TClient> CreateClientAsync(bool enableCae, bool async, CancellationToken cancellationToken);

        protected async ValueTask<TClient> GetClientAsync(bool enableCae, bool async, CancellationToken cancellationToken)
        {
            using var asyncLock = enableCae ?
                await _clientWithCaeAsyncLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false) :
                await _clientAsyncLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);

            if (asyncLock.HasValue)
            {
                return asyncLock.Value.Client;
            }

            var client = await CreateClientAsync(enableCae, async, cancellationToken).ConfigureAwait(false);

            TokenCache tokenCache = null;
            if (_tokenCachePersistenceOptions != null)
            {
                tokenCache = new TokenCache(_tokenCachePersistenceOptions, enableCae);
                await tokenCache.RegisterCache(async, client.UserTokenCache, cancellationToken).ConfigureAwait(false);

                if (client is IConfidentialClientApplication cca)
                {
                    await tokenCache.RegisterCache(async, cca.AppTokenCache, cancellationToken).ConfigureAwait(false);
                }
            }

            asyncLock.SetValue((Client: client, Cache: tokenCache));
            return client;
        }

        protected void LogMsal(LogLevel level, string message, bool isPii)
        {
            if (!isPii || IsSupportLoggingEnabled)
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

        internal async ValueTask<TokenCache> GetTokenCache(bool enableCae)
        {
            using var asyncLock = enableCae ?
                await _clientWithCaeAsyncLock.GetLockOrValueAsync(true, default).ConfigureAwait(false) :
                await _clientAsyncLock.GetLockOrValueAsync(true, default).ConfigureAwait(false);

            return asyncLock.HasValue ? asyncLock.Value.Cache : null;
        }
    }
}
