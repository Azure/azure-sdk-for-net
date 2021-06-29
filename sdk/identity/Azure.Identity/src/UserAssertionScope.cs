// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Creates a scope which will be used by <see cref="OnBehalfOfCredential"/> to request tokens on behalf of the user's token used to initialize
    /// the <see cref="UserAssertionScope"/> instance.
    /// </summary>
    public class UserAssertionScope : IDisposable
    {
        private static AsyncLocal<UserAssertionScope> _currentAsyncLocal = new();
        internal UserAssertion UserAssertion { get; }
        internal MsalConfidentialClient Client { get; set; }
        internal ITokenCacheOptions CacheOptions { get; }

        /// <summary>
        /// The current value of the <see cref="AsyncLocal{UserAssertion}"/>.
        /// </summary>
        internal static UserAssertionScope Current => _currentAsyncLocal.Value;

        /// <summary>
        /// Initializes a new instance of <see cref="UserAssertionScope"/> using the supplied access token.
        /// </summary>
        /// <param name="accessToken">The access token that will be used by <see cref="OnBehalfOfCredential"/> as the user assertion when requesting On-Behalf-Of tokens.</param>
        /// <param name="hydrateCache"> The delegate to be called which retrieves the cache from persistence for this user assertion partition. </param>
        /// <param name="persistCache"> The delegate to be called with the current state of the token cache on each time it is updated for this <see cref="UserAssertionScope"/> instance. </param>
        public UserAssertionScope(string accessToken, Func<Task<ReadOnlyMemory<byte>>> hydrateCache = null, Func<ReadOnlyMemory<byte>, Task> persistCache = null)
        {
            UserAssertion = new UserAssertion(accessToken);
            _currentAsyncLocal.Value = this;
            CacheOptions = new UserAssertionCacheOptions(hydrateCache, persistCache);
        }

        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _currentAsyncLocal.Value = default;
        }

        internal class UserAssertionCacheOptions : UnsafeTokenCacheOptions, ITokenCacheOptions
        {
            private Func<Task<ReadOnlyMemory<byte>>> _hydrateCache;
            internal Func<ReadOnlyMemory<byte>, Task> _persistCache;

            public UserAssertionCacheOptions(Func<Task<ReadOnlyMemory<byte>>> hydrateCache, Func<ReadOnlyMemory<byte>, Task> persistCache)
            {
                _hydrateCache = hydrateCache ?? (() => Task.FromResult(ReadOnlyMemory<byte>.Empty));
                _persistCache = persistCache ?? (_ => Task.CompletedTask);
            }

            protected internal override Task<ReadOnlyMemory<byte>> RefreshCacheAsync() { throw new NotImplementedException(); }

            protected internal override Task<ReadOnlyMemory<byte>> RefreshCacheAsync(TokenCacheNotificationArgs args)
            {
                return _hydrateCache();
            }

            protected internal override Task TokenCacheUpdatedAsync(TokenCacheUpdatedArgs tokenCacheUpdatedArgs)
            {
                return _persistCache(tokenCacheUpdatedArgs.UnsafeCacheData);
            }

            public TokenCachePersistenceOptions TokenCachePersistenceOptions => this;
        }
    }
}
