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
        /// <param name="options"> The <see cref="UserAssertionScopeOptions"/> to configure this instance.</param>
        public UserAssertionScope(string accessToken,UserAssertionScopeOptions options = null)
        {
            UserAssertion = new UserAssertion(accessToken);
            _currentAsyncLocal.Value = this;
            CacheOptions = new UserAssertionCacheOptions(options);
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
            private Func<TokenCacheNotificationDetails, Task<UserAssertionCacheDetails>> _hydrateCache;
            internal Func<UserAssertionCacheDetails, Task> _persistCache;

            public UserAssertionCacheOptions(UserAssertionScopeOptions options)
            {
                _hydrateCache = options?.HydrateCache ?? ((d) => Task.FromResult(new UserAssertionCacheDetails { CacheBytes = ReadOnlyMemory<byte>.Empty }));
                _persistCache = options?.PersistCache ?? (_ => Task.CompletedTask);
            }

            protected internal override Task<ReadOnlyMemory<byte>> RefreshCacheAsync() { throw new NotImplementedException(); }

            protected internal override Task<UserAssertionCacheDetails> RefreshCacheAsync(TokenCacheNotificationDetails details)
            {
                return _hydrateCache(details);
            }

            protected internal override Task TokenCacheUpdatedAsync(TokenCacheUpdatedArgs tokenCacheUpdatedArgs)
            {
                return _persistCache(new UserAssertionCacheDetails { CacheBytes = tokenCacheUpdatedArgs.UnsafeCacheData });
            }

            public TokenCachePersistenceOptions TokenCachePersistenceOptions => this;
        }
    }
}
