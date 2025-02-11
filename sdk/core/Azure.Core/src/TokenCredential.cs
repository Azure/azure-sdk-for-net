// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    /// <summary>
    /// Represents a credential capable of providing an OAuth token.
    /// </summary>
    public abstract class TokenCredential : TokenProvider<TokenRequestContext>
    {
        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext"/> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A valid <see cref="AccessToken"/>.</returns>
        /// <remarks>Caching and management of the lifespan for the <see cref="AccessToken"/> is considered the responsibility of the caller: each call should request a fresh token being requested.</remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/identity")]
        public abstract ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken);

        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext"/> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A valid <see cref="AccessToken"/>.</returns>
        /// <remarks>Caching and management of the lifespan for the <see cref="AccessToken"/> is considered the responsibility of the caller: each call should request a fresh token being requested.</remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/identity")]
        public abstract AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public override Token GetAccessToken(TokenRequestContext context, CancellationToken cancellationToken)
        {
            if (context is TokenRequestContext trc)
            {
                return GetToken(trc, cancellationToken).ToToken();
            }
            throw new InvalidOperationException("Invalid context type. Expected TokenRequestContext.");
        }

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public override async ValueTask<Token> GetAccessTokenAsync(TokenRequestContext context, CancellationToken cancellationToken)
        {
            if (context is TokenRequestContext trc)
            {
                return (await GetTokenAsync(trc, cancellationToken).ConfigureAwait(false)).ToToken();
            }
            throw new InvalidOperationException("Invalid context type. Expected TokenRequestContext.");
        }

        /// <summary>
        /// Creates a context.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override TokenRequestContext CreateContext(IReadOnlyDictionary<string, object> context)
        {
            if (context is TokenRequestContext trc)
            {
                return trc;
            }
            throw new NotImplementedException("Invalid context type. Expected TokenRequestContext.");
        }
    }
}
