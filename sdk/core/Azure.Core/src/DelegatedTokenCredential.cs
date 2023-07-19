// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// A factory for creating a delegated <see cref="TokenCredential"/> capable of providing an OAuth token.
    /// </summary>
    public static class DelegatedTokenCredential
    {
        /// <summary>
        /// Creates a static <see cref="TokenCredential"/> that accepts delegates which will produce an <see cref="AccessToken"/>.
        /// </summary>
        /// <remarks>
        /// Typically, the <see cref="TokenCredential"/> created by this method is for use when you have already obtained an <see cref="AccessToken"/>
        /// from some other source and need a <see cref="TokenCredential"/> that will simply return that token. Because the static token can expire,
        /// the delegates offer a mechanism to handle <see cref="AccessToken"/> renewal.
        /// </remarks>
        /// <param name="getToken">A delegate that returns an <see cref="AccessToken"/>.</param>
        /// <param name="getTokenAsync">A delegate that returns a <see cref="ValueTask"/> of type <see cref="AccessToken"/>.</param>
        /// <returns></returns>
        public static TokenCredential Create(
            Func<TokenRequestContext, CancellationToken, AccessToken> getToken,
            Func<TokenRequestContext, CancellationToken, ValueTask<AccessToken>> getTokenAsync) => new StaticTokenCredential(getToken, getTokenAsync);

        /// <summary>
        /// Creates a static <see cref="TokenCredential"/> that accepts delegates which will produce an <see cref="AccessToken"/>.
        /// </summary>
        /// <remarks>
        /// Typically, the <see cref="TokenCredential"/> created by this method is for use when you have already obtained an <see cref="AccessToken"/>
        /// from some other source and need a <see cref="TokenCredential"/> that will simply return that token. Because the static token can expire,
        /// the delegates offer a mechanism to handle <see cref="AccessToken"/> renewal.
        /// </remarks>
        /// <param name="getToken">A delegate that returns an <see cref="AccessToken"/>.</param>
        /// <returns></returns>
        public static TokenCredential Create(
            Func<TokenRequestContext, CancellationToken, AccessToken> getToken) => new StaticTokenCredential(getToken);

        private class StaticTokenCredential : TokenCredential
        {
            private readonly Func<TokenRequestContext, CancellationToken, AccessToken> _getToken;
            private readonly Func<TokenRequestContext, CancellationToken, ValueTask<AccessToken>> _getTokenAsync;

            internal StaticTokenCredential(
                Func<TokenRequestContext, CancellationToken, AccessToken> getToken,
                Func<TokenRequestContext, CancellationToken, ValueTask<AccessToken>> getTokenAsync)
            {
                _getToken = getToken;
                _getTokenAsync = getTokenAsync;
            }

            internal StaticTokenCredential(
                Func<TokenRequestContext, CancellationToken, AccessToken> getToken)
            {
                _getToken = getToken;
                _getTokenAsync = (context, token) => new ValueTask<AccessToken>(_getToken(context, token));
            }

            /// <inheritdoc cref="GetTokenAsync"/>
            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                _getTokenAsync(requestContext, cancellationToken);

            /// <inheritdoc cref="GetToken"/>
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                _getToken(requestContext, cancellationToken);
        }
    }
}
