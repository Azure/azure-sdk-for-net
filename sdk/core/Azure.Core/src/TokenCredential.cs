// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    /// <summary>
    /// Represents a credential capable of providing an OAuth token.
    /// </summary>
    public abstract class TokenCredential
    {
        /// <summary>
        /// Returns a <see cref="TimeSpan"/> value representing the amount of time to subtract from the token expiry time, whereupon
        /// attempts will be made to refresh the token. By default this will occur two minutes prior to the expiry of the token.
        /// </summary>
        /// <returns>The duration value representing the amount of time to subtract from the token expiry time.</returns>
        public virtual TokenRefreshOptions RefreshOptions { get; } = new TokenRefreshOptions(TimeSpan.FromMinutes(2));

        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext"/> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A valid <see cref="AccessToken"/>.</returns>
        public abstract ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken);

        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext"/> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A valid <see cref="AccessToken"/>.</returns>
        public abstract AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken);
    }
}
