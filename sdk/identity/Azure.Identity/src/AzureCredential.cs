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
        private AuthenticationResponse _cachedResponse;
        private SemaphoreSlim _refreshLock = new SemaphoreSlim(1, 1);
        private IdentityClientOptions _options;


        static AzureCredential()
        {
            // TODO: update to TokenCredentialProvider once other credential providers are available
            AzureCredential.Default = new EnvironmentCredentialProvider();
        }


        protected AzureCredential(IdentityClientOptions options = null)
        {
            _options = options ?? new IdentityClientOptions();

            _client = new IdentityClient(options);
        }


        public override async ValueTask<string> GetTokenAsync(string[] scopes, CancellationToken cancellationToken = default)
        {
            if (!NeedsRefresh)
            {
                return _cachedResponse.AccessToken;
            }

            await _refreshLock.WaitAsync(cancellationToken).ConfigureAwait(false);

            try
            {
                if (NeedsRefresh)
                {
                    _cachedResponse = await AuthenticateAsync(scopes, cancellationToken).ConfigureAwait(false);
                }

                return _cachedResponse.AccessToken;
            }
            finally
            {
                _refreshLock.Release();
            }
        }

        public override string GetToken(string[] scopes, CancellationToken cancellationToken)
        {
            if (!NeedsRefresh)
            {
                return _cachedResponse.AccessToken;
            }

            lock(_refreshLock)
            {
                if (NeedsRefresh)
                {
                    _cachedResponse = Authenticate(scopes, cancellationToken);
                }

                return _cachedResponse.AccessToken;
            }
        }

        protected abstract Task<AuthenticationResponse> AuthenticateAsync(string[] scopes, CancellationToken cancellationToken);

        protected abstract AuthenticationResponse Authenticate(string[] scopes, CancellationToken cancellationToken);

        internal IdentityClient Client => _client;

        public static TokenCredential Default { get; set; }

        private bool NeedsRefresh => _cachedResponse == null || (DateTime.UtcNow + _options.RefreshBuffer) >= _cachedResponse.ExpiresOn;
    }
}
