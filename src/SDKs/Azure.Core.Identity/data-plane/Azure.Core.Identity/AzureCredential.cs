using Azure.Core.Credentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Identity
{
    public abstract class AzureCredential : TokenCredential
    {
        private IdentityClient _client;
        private AuthenticationResponse _cachedResponse;
        private SemaphoreSlim _refreshLock = new SemaphoreSlim(1, 1);


        static AzureCredential()
        {
            // TODO: Initialize default credential
        }

        protected AzureCredential(IdentityClientOptions options = null)
        {
            _client = new IdentityClient(options);
        }

        public override async ValueTask<string> GetTokenAsync(IEnumerable<string> scopes, CancellationToken cancellationToken = default)
        {
            if ((_cachedResponse != null) && !_cachedResponse.NeedsRefresh())
            {
                return _cachedResponse.AccessToken;
            }

            await _refreshLock.WaitAsync(cancellationToken).ConfigureAwait(false);

            try
            {
                if ((_cachedResponse == null) || _cachedResponse.NeedsRefresh())
                {
                    _cachedResponse = await Authenticate(scopes, cancellationToken).ConfigureAwait(false);
                }

                return _cachedResponse.AccessToken;
            }
            finally
            {
                _refreshLock.Release();
            }
        }

        internal virtual async Task<AuthenticationResponse> Authenticate(IEnumerable<string> scopes, CancellationToken cancellationToken)
        {
            await Task.CompletedTask.ConfigureAwait(false);

            return null;
        }

        internal IdentityClient Client => _client;

        public static TokenCredential Default { get; set; }
    }
}
