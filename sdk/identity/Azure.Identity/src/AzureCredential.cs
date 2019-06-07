// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    public abstract class AzureCredential : TokenCredential
    {
        private IdentityClient _client;
        private AccessToken _cachedResponse;
        private SemaphoreSlim _refreshLock = new SemaphoreSlim(1, 1);
        private TimeSpan _refreshBuffer;

        static AzureCredential()
        {
            // TODO: update to TokenCredentialProvider once other credential providers are available
            AzureCredential.Default = new EnvironmentCredential();
        }


        protected AzureCredential(IdentityClientOptions options)
        {
            options = options ?? new IdentityClientOptions();

            _client = new IdentityClient(options);

            _refreshBuffer = options.RefreshBuffer;
        }


        public override async ValueTask<string> GetTokenAsync(string[] scopes, CancellationToken cancellationToken = default)
        {
            if (!NeedsRefresh)
            {
                return _cachedResponse.Token;
            }

            await _refreshLock.WaitAsync(cancellationToken).ConfigureAwait(false);

            try
            {
                if (NeedsRefresh)
                {
                    _cachedResponse = await GetTokenCoreAsync(scopes, cancellationToken).ConfigureAwait(false);
                }

                return _cachedResponse.Token;
            }
            finally
            {
                _refreshLock.Release();
            }
        }

        public override string GetToken(string[] scopes, CancellationToken cancellationToken = default)
        {
            if (!NeedsRefresh)
            {
                return _cachedResponse.Token;
            }

            _refreshLock.Wait(cancellationToken);

            try
            {
                if (NeedsRefresh)
                {
                    _cachedResponse = GetTokenCore(scopes, cancellationToken);
                }

                return _cachedResponse.Token;
            }
            finally
            {
                _refreshLock.Release();
            }
        }

        protected abstract Task<AccessToken> GetTokenCoreAsync(string[] scopes, CancellationToken cancellationToken);

        protected abstract AccessToken GetTokenCore(string[] scopes, CancellationToken cancellationToken);

        internal IdentityClient Client { get => _client; set => _client = value; }


        public static TokenCredential Default { get; set; }

        private bool NeedsRefresh => _cachedResponse == null || (DateTime.UtcNow + _refreshBuffer) >= _cachedResponse.ExpiresOn;
    }
}
