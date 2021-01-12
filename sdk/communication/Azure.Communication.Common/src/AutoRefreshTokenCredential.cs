// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Communication
{
    internal sealed class AutoRefreshTokenCredential : ICommunicationTokenCredential
    {
        private readonly ThreadSafeRefreshableAccessTokenCache _accessTokenCache;

        public AutoRefreshTokenCredential(
            Func<CancellationToken, string> tokenRefresher,
            Func<CancellationToken, ValueTask<string>> asyncTokenRefresher,
            string? initialToken,
            bool refreshProactively)
            : this(tokenRefresher, asyncTokenRefresher, initialToken, refreshProactively, null, null)
        { }

        internal AutoRefreshTokenCredential(
            Func<CancellationToken, string> tokenRefresher,
            Func<CancellationToken, ValueTask<string>> asyncTokenRefresher,
            string? initialToken,
            bool refreshProactively,
            Func<Action, TimeSpan, ThreadSafeRefreshableAccessTokenCache.IScheduledAction>? scheduler,
            Func<DateTimeOffset>? utcNowProvider)
        {
            if (initialToken == null)
            {
                _accessTokenCache = new ThreadSafeRefreshableAccessTokenCache(
                    Refresh,
                    RefreshAsync,
                    refreshProactively,
                    scheduler,
                    utcNowProvider);
            }
            else
            {
                _accessTokenCache = new ThreadSafeRefreshableAccessTokenCache(
                    Refresh,
                    RefreshAsync,
                    refreshProactively,
                    initialValue: JwtTokenParser.CreateAccessToken(initialToken),
                    scheduler,
                    utcNowProvider);
            }

            AccessToken Refresh(CancellationToken cancellationToken)
                => JwtTokenParser.CreateAccessToken(tokenRefresher(cancellationToken));

            async ValueTask<AccessToken> RefreshAsync(CancellationToken cancellationToken)
                => JwtTokenParser.CreateAccessToken(await asyncTokenRefresher(cancellationToken).ConfigureAwait(false));
        }

        public AccessToken GetToken(CancellationToken cancellationToken = default)
            => _accessTokenCache.GetValue(cancellationToken);

        public ValueTask<AccessToken> GetTokenAsync(CancellationToken cancellationToken = default)
            => _accessTokenCache.GetValueAsync(cancellationToken);

        public void Dispose() => _accessTokenCache.Dispose();
    }
}
