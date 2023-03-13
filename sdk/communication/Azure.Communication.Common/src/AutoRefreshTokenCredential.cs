// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

#nullable enable

namespace Azure.Communication
{
    [ExcludeFromCodeCoverage]
    internal sealed class AutoRefreshTokenCredential : ICommunicationTokenCredential
    {
        private readonly ThreadSafeRefreshableAccessTokenCache _accessTokenCache;

        public AutoRefreshTokenCredential(CommunicationTokenRefreshOptions options)
            : this(options, null, null)
        { }

        internal AutoRefreshTokenCredential(
            CommunicationTokenRefreshOptions options,
            Func<Action, TimeSpan, ThreadSafeRefreshableAccessTokenCache.IScheduledAction>? scheduler,
            Func<DateTimeOffset>? utcNowProvider)
        {
            if (options.InitialToken is null)
            {
                _accessTokenCache = new ThreadSafeRefreshableAccessTokenCache(
                    Refresh,
                    RefreshAsync,
                    options.RefreshProactively,
                    scheduler,
                    utcNowProvider);
            }
            else
            {
                _accessTokenCache = new ThreadSafeRefreshableAccessTokenCache(
                    Refresh,
                    RefreshAsync,
                    options.RefreshProactively,
                    initialValue: JwtTokenParser.CreateAccessToken(options.InitialToken),
                    scheduler,
                    utcNowProvider);
            }

            AccessToken Refresh(CancellationToken cancellationToken)
                => JwtTokenParser.CreateAccessToken(options.TokenRefresher(cancellationToken));

            async ValueTask<AccessToken> RefreshAsync(CancellationToken cancellationToken)
                => JwtTokenParser.CreateAccessToken(await options.AsyncTokenRefresher(cancellationToken).ConfigureAwait(false));
        }

        public AccessToken GetToken(CancellationToken cancellationToken = default)
            => _accessTokenCache.GetValue(cancellationToken);

        public ValueTask<AccessToken> GetTokenAsync(CancellationToken cancellationToken = default)
            => _accessTokenCache.GetValueAsync(cancellationToken);

        public void Dispose() => _accessTokenCache.Dispose();
    }
}
