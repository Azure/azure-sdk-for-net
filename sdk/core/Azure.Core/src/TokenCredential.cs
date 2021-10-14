// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Represents a credential capable of providing an OAuth token.
    /// </summary>
    public abstract class TokenCredential
    {
        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext"/> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A valid <see cref="AccessToken"/>.</returns>
        /// <remarks>Caching and management of the lifespan for the <see cref="AccessToken"/> is considered the responsibility of the caller: each call should request a fresh token being requested.</remarks>
        public abstract ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken);

        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext"/> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A valid <see cref="AccessToken"/>.</returns>
        /// <remarks>Caching and management of the lifespan for the <see cref="AccessToken"/> is considered the responsibility of the caller: each call should request a fresh token being requested.</remarks>
        public abstract AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken);

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

        /// <summary>
        /// Creates a static <see cref="TokenCredential"/> that accepts delegates which will produce an <see cref="AccessToken"/>.
        /// </summary>
        /// <remarks>
        /// Typically, the <see cref="TokenCredential"/> created by this method is for use when you have already obtained an <see cref="AccessToken"/>
        /// from some other source and need a <see cref="TokenCredential"/> that will simply return that token. Because the static token can expire,
        /// the delegates offer a mechanism to handle <see cref="AccessToken"/> renewal.
        /// </remarks>
        /// <param name="getTokenAsync">A delegate that returns a <see cref="ValueTask"/> of type <see cref="AccessToken"/>.
        /// If <see cref="GetToken"/> is called, the provided delegate will be executed sync over async.</param>
        /// <returns></returns>
        public static TokenCredential Create(
            Func<TokenRequestContext, CancellationToken, ValueTask<AccessToken>> getTokenAsync) => new StaticTokenCredential(getTokenAsync);

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

            internal StaticTokenCredential(
                Func<TokenRequestContext, CancellationToken, ValueTask<AccessToken>> getTokenAsync)
            {
                _getToken = (context, token) => getTokenAsync(context, token)
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
                        .GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
                _getTokenAsync = getTokenAsync;
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
