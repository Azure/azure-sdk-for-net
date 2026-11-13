// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    /// <summary>
    /// Represents a credential capable of providing an OAuth token.
    /// </summary>
    public abstract class TokenCredential : AuthenticationTokenProvider
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
        /// Gets an <see cref="AuthenticationToken"/> for the provided <paramref name="properties"/>.
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override async ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions properties, CancellationToken cancellationToken) =>
            (await GetTokenAsync(TokenRequestContext.FromGetTokenOptions(properties), cancellationToken).ConfigureAwait(false)).ToAuthenticationToken();

        /// <summary>
        /// Gets an <see cref="AuthenticationToken"/> for the provided <paramref name="properties"/>.
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override AuthenticationToken GetToken(GetTokenOptions properties, CancellationToken cancellationToken) =>
            GetToken(TokenRequestContext.FromGetTokenOptions(properties), cancellationToken).ToAuthenticationToken();

        /// <inheritdoc />
        public override GetTokenOptions? CreateTokenOptions(IReadOnlyDictionary<string, object> properties)
        {
            // Check if scopes are present
            if (properties.TryGetValue(GetTokenOptions.ScopesPropertyName, out var scopesValue))
            {
                return new GetTokenOptions(properties);
            }
            // No scopes provided - insufficient information to create TokenRequestContext
            return null;
        }
    }
}
